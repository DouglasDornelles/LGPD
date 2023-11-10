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
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class documentocopiaregistros : GXProcedure
   {
      public documentocopiaregistros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public documentocopiaregistros( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocumentoId_Copia ,
                           string aP1_DocumentoNome_Copia ,
                           out int aP2_DocumentoId_Copiado )
      {
         this.AV8DocumentoId_Copia = aP0_DocumentoId_Copia;
         this.AV26DocumentoNome_Copia = aP1_DocumentoNome_Copia;
         this.AV9DocumentoId_Copiado = 0 ;
         initialize();
         executePrivate();
         aP2_DocumentoId_Copiado=this.AV9DocumentoId_Copiado;
      }

      public int executeUdp( int aP0_DocumentoId_Copia ,
                             string aP1_DocumentoNome_Copia )
      {
         execute(aP0_DocumentoId_Copia, aP1_DocumentoNome_Copia, out aP2_DocumentoId_Copiado);
         return AV9DocumentoId_Copiado ;
      }

      public void executeSubmit( int aP0_DocumentoId_Copia ,
                                 string aP1_DocumentoNome_Copia ,
                                 out int aP2_DocumentoId_Copiado )
      {
         documentocopiaregistros objdocumentocopiaregistros;
         objdocumentocopiaregistros = new documentocopiaregistros();
         objdocumentocopiaregistros.AV8DocumentoId_Copia = aP0_DocumentoId_Copia;
         objdocumentocopiaregistros.AV26DocumentoNome_Copia = aP1_DocumentoNome_Copia;
         objdocumentocopiaregistros.AV9DocumentoId_Copiado = 0 ;
         objdocumentocopiaregistros.context.SetSubmitInitialConfig(context);
         objdocumentocopiaregistros.initialize();
         Submit( executePrivateCatch,objdocumentocopiaregistros);
         aP2_DocumentoId_Copiado=this.AV9DocumentoId_Copiado;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((documentocopiaregistros)stateInfo).executePrivate();
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
         AV27Count = 0;
         /* Using cursor P00732 */
         pr_default.execute(0, new Object[] {AV8DocumentoId_Copia});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A75DocumentoId = P00732_A75DocumentoId[0];
            A106DocumentoProcessoId = P00732_A106DocumentoProcessoId[0];
            n106DocumentoProcessoId = P00732_n106DocumentoProcessoId[0];
            A110DocumentoControladorId = P00732_A110DocumentoControladorId[0];
            n110DocumentoControladorId = P00732_n110DocumentoControladorId[0];
            A36AbrangenciaGeograficaId = P00732_A36AbrangenciaGeograficaId[0];
            n36AbrangenciaGeograficaId = P00732_n36AbrangenciaGeograficaId[0];
            A27CategoriaId = P00732_A27CategoriaId[0];
            n27CategoriaId = P00732_n27CategoriaId[0];
            A7EncarregadoId = P00732_A7EncarregadoId[0];
            n7EncarregadoId = P00732_n7EncarregadoId[0];
            A33FerramentaColetaId = P00732_A33FerramentaColetaId[0];
            n33FerramentaColetaId = P00732_n33FerramentaColetaId[0];
            A39FrequenciaTratamentoId = P00732_A39FrequenciaTratamentoId[0];
            n39FrequenciaTratamentoId = P00732_n39FrequenciaTratamentoId[0];
            A13PersonaId = P00732_A13PersonaId[0];
            n13PersonaId = P00732_n13PersonaId[0];
            A20SubprocessoId = P00732_A20SubprocessoId[0];
            n20SubprocessoId = P00732_n20SubprocessoId[0];
            A48TempoRetencaoId = P00732_A48TempoRetencaoId[0];
            n48TempoRetencaoId = P00732_n48TempoRetencaoId[0];
            A30TipoDadoId = P00732_A30TipoDadoId[0];
            n30TipoDadoId = P00732_n30TipoDadoId[0];
            A45TipoDescarteId = P00732_A45TipoDescarteId[0];
            n45TipoDescarteId = P00732_n45TipoDescarteId[0];
            A24AreaResponsavelId = P00732_A24AreaResponsavelId[0];
            n24AreaResponsavelId = P00732_n24AreaResponsavelId[0];
            A79DocumentoBaseLegalNorm = P00732_A79DocumentoBaseLegalNorm[0];
            n79DocumentoBaseLegalNorm = P00732_n79DocumentoBaseLegalNorm[0];
            A80DocumentoBaseLegalNormIntExt = P00732_A80DocumentoBaseLegalNormIntExt[0];
            n80DocumentoBaseLegalNormIntExt = P00732_n80DocumentoBaseLegalNormIntExt[0];
            A81DocumentoDadosCriancaAdolesc = P00732_A81DocumentoDadosCriancaAdolesc[0];
            n81DocumentoDadosCriancaAdolesc = P00732_n81DocumentoDadosCriancaAdolesc[0];
            A82DocumentoDadosGrupoVul = P00732_A82DocumentoDadosGrupoVul[0];
            n82DocumentoDadosGrupoVul = P00732_n82DocumentoDadosGrupoVul[0];
            A77DocumentoFinalidadeTratamento = P00732_A77DocumentoFinalidadeTratamento[0];
            n77DocumentoFinalidadeTratamento = P00732_n77DocumentoFinalidadeTratamento[0];
            A84DocumentoFluxoTratDadosDesc = P00732_A84DocumentoFluxoTratDadosDesc[0];
            n84DocumentoFluxoTratDadosDesc = P00732_n84DocumentoFluxoTratDadosDesc[0];
            A83DocumentoMedidaSegurancaDesc = P00732_A83DocumentoMedidaSegurancaDesc[0];
            n83DocumentoMedidaSegurancaDesc = P00732_n83DocumentoMedidaSegurancaDesc[0];
            A105DocumentoOperador = P00732_A105DocumentoOperador[0];
            n105DocumentoOperador = P00732_n105DocumentoOperador[0];
            A78DocumentoPrevColetaDados = P00732_A78DocumentoPrevColetaDados[0];
            n78DocumentoPrevColetaDados = P00732_n78DocumentoPrevColetaDados[0];
            AV10Documento = new SdtDocumento(context);
            AV10Documento.gxTpr_Documentonome = AV26DocumentoNome_Copia;
            if ( ! P00732_n106DocumentoProcessoId[0] || ! (0==A106DocumentoProcessoId) || ! ( A106DocumentoProcessoId == 0 ) )
            {
               AV10Documento.gxTpr_Documentoprocessoid = A106DocumentoProcessoId;
            }
            else
            {
               AV10Documento.gxTv_SdtDocumento_Documentoprocessoid_SetNull();
            }
            if ( ! P00732_n110DocumentoControladorId[0] || ! (0==A110DocumentoControladorId) || ! ( A110DocumentoControladorId == 0 ) )
            {
               AV10Documento.gxTpr_Documentocontroladorid = A110DocumentoControladorId;
            }
            else
            {
               AV10Documento.gxTpr_Documentocontroladorid = 0;
            }
            if ( ! P00732_n36AbrangenciaGeograficaId[0] || ! (0==A36AbrangenciaGeograficaId) || ! ( A36AbrangenciaGeograficaId == 0 ) )
            {
               AV10Documento.gxTpr_Abrangenciageograficaid = A36AbrangenciaGeograficaId;
            }
            else
            {
               AV10Documento.gxTv_SdtDocumento_Abrangenciageograficaid_SetNull();
            }
            if ( ! P00732_n27CategoriaId[0] || ! (0==A27CategoriaId) || ! ( A27CategoriaId == 0 ) )
            {
               AV10Documento.gxTpr_Categoriaid = A27CategoriaId;
            }
            else
            {
               AV10Documento.gxTv_SdtDocumento_Categoriaid_SetNull();
            }
            if ( ! P00732_n7EncarregadoId[0] || ! (0==A7EncarregadoId) || ! ( A7EncarregadoId == 0 ) )
            {
               AV10Documento.gxTpr_Encarregadoid = A7EncarregadoId;
            }
            else
            {
               AV10Documento.gxTv_SdtDocumento_Encarregadoid_SetNull();
            }
            if ( ! P00732_n33FerramentaColetaId[0] || ! (0==A33FerramentaColetaId) || ! ( A33FerramentaColetaId == 0 ) )
            {
               AV10Documento.gxTpr_Ferramentacoletaid = A33FerramentaColetaId;
            }
            else
            {
               AV10Documento.gxTv_SdtDocumento_Ferramentacoletaid_SetNull();
            }
            if ( ! P00732_n39FrequenciaTratamentoId[0] || ! (0==A39FrequenciaTratamentoId) || ! ( A39FrequenciaTratamentoId == 0 ) )
            {
               AV10Documento.gxTpr_Frequenciatratamentoid = A39FrequenciaTratamentoId;
            }
            else
            {
               AV10Documento.gxTv_SdtDocumento_Frequenciatratamentoid_SetNull();
            }
            if ( ! P00732_n13PersonaId[0] || ! (0==A13PersonaId) || ! ( A13PersonaId == 0 ) )
            {
               AV10Documento.gxTpr_Personaid = A13PersonaId;
            }
            else
            {
               AV10Documento.gxTv_SdtDocumento_Personaid_SetNull();
            }
            if ( ! P00732_n20SubprocessoId[0] || ! (0==A20SubprocessoId) || ! ( A13PersonaId == 0 ) )
            {
               AV10Documento.gxTpr_Subprocessoid = A20SubprocessoId;
            }
            else
            {
               AV10Documento.gxTv_SdtDocumento_Subprocessoid_SetNull();
            }
            if ( ! P00732_n48TempoRetencaoId[0] || ! (0==A48TempoRetencaoId) || ! ( A48TempoRetencaoId == 0 ) )
            {
               AV10Documento.gxTpr_Temporetencaoid = A48TempoRetencaoId;
            }
            else
            {
               AV10Documento.gxTv_SdtDocumento_Temporetencaoid_SetNull();
            }
            if ( ! P00732_n30TipoDadoId[0] || ! (0==A30TipoDadoId) || ! ( A30TipoDadoId == 0 ) )
            {
               AV10Documento.gxTpr_Tipodadoid = A30TipoDadoId;
            }
            else
            {
               AV10Documento.gxTv_SdtDocumento_Tipodadoid_SetNull();
            }
            if ( ! P00732_n45TipoDescarteId[0] || ! (0==A45TipoDescarteId) || ! ( A45TipoDescarteId == 0 ) )
            {
               AV10Documento.gxTpr_Tipodescarteid = A45TipoDescarteId;
            }
            else
            {
               AV10Documento.gxTv_SdtDocumento_Tipodescarteid_SetNull();
            }
            if ( ! P00732_n24AreaResponsavelId[0] || ! (0==A24AreaResponsavelId) || ! ( A24AreaResponsavelId == 0 ) )
            {
               AV10Documento.gxTpr_Arearesponsavelid = A24AreaResponsavelId;
            }
            else
            {
               AV10Documento.gxTv_SdtDocumento_Arearesponsavelid_SetNull();
            }
            AV10Documento.gxTpr_Documentobaselegalnorm = A79DocumentoBaseLegalNorm;
            AV10Documento.gxTpr_Documentobaselegalnormintext = A80DocumentoBaseLegalNormIntExt;
            AV10Documento.gxTpr_Documentodadoscriancaadolesc = A81DocumentoDadosCriancaAdolesc;
            AV10Documento.gxTpr_Documentodadosgrupovul = A82DocumentoDadosGrupoVul;
            AV10Documento.gxTpr_Documentofinalidadetratamento = A77DocumentoFinalidadeTratamento;
            AV10Documento.gxTpr_Documentofluxotratdadosdesc = A84DocumentoFluxoTratDadosDesc;
            AV10Documento.gxTpr_Documentomedidasegurancadesc = A83DocumentoMedidaSegurancaDesc;
            AV10Documento.gxTpr_Documentooperador = A105DocumentoOperador;
            AV10Documento.gxTpr_Documentoprevcoletadados = A78DocumentoPrevColetaDados;
            GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.Today( context) ) ;
            AV10Documento.gxTpr_Documentodatainclusao = GXt_dtime1;
            AV10Documento.gxTpr_Documentoativo = true;
            AV10Documento.Insert();
            AV9DocumentoId_Copiado = AV10Documento.gxTpr_Documentoid;
            if ( AV10Documento.Success() )
            {
               context.CommitDataStores("documentocopiaregistros",pr_default);
               /* Using cursor P00733 */
               pr_default.execute(1, new Object[] {AV8DocumentoId_Copia});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A75DocumentoId = P00733_A75DocumentoId[0];
                  A63FonteRetencaoId = P00733_A63FonteRetencaoId[0];
                  AV16DocFonteRetencao = new SdtDocFonteRetencao(context);
                  AV16DocFonteRetencao.gxTpr_Documentoid = AV9DocumentoId_Copiado;
                  AV16DocFonteRetencao.gxTpr_Fonteretencaoid = A63FonteRetencaoId;
                  AV16DocFonteRetencao.Insert();
                  if ( AV16DocFonteRetencao.Success() )
                  {
                     context.CommitDataStores("documentocopiaregistros",pr_default);
                  }
                  else
                  {
                     AV35GXV2 = 1;
                     AV34GXV1 = AV16DocFonteRetencao.GetMessages();
                     while ( AV35GXV2 <= AV34GXV1.Count )
                     {
                        AV23Message = ((GeneXus.Utils.SdtMessages_Message)AV34GXV1.Item(AV35GXV2));
                        GX_msglist.addItem(AV23Message.gxTpr_Description);
                        AV35GXV2 = (int)(AV35GXV2+1);
                     }
                  }
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               /* Using cursor P00734 */
               pr_default.execute(2, new Object[] {AV8DocumentoId_Copia});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A75DocumentoId = P00734_A75DocumentoId[0];
                  A60SetorInternoId = P00734_A60SetorInternoId[0];
                  AV17DocSetorInterno = new SdtDocSetorInterno(context);
                  AV17DocSetorInterno.gxTpr_Documentoid = AV9DocumentoId_Copiado;
                  AV17DocSetorInterno.gxTpr_Setorinternoid = A60SetorInternoId;
                  AV17DocSetorInterno.Insert();
                  if ( AV17DocSetorInterno.Success() )
                  {
                     context.CommitDataStores("documentocopiaregistros",pr_default);
                  }
                  else
                  {
                     AV38GXV4 = 1;
                     AV37GXV3 = AV17DocSetorInterno.GetMessages();
                     while ( AV38GXV4 <= AV37GXV3.Count )
                     {
                        AV23Message = ((GeneXus.Utils.SdtMessages_Message)AV37GXV3.Item(AV38GXV4));
                        GX_msglist.addItem(AV23Message.gxTpr_Description);
                        AV38GXV4 = (int)(AV38GXV4+1);
                     }
                  }
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               /* Using cursor P00735 */
               pr_default.execute(3, new Object[] {AV8DocumentoId_Copia});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A75DocumentoId = P00735_A75DocumentoId[0];
                  A57CompartInternoId = P00735_A57CompartInternoId[0];
                  AV18DocCompartInterno = new SdtDocCompartInterno(context);
                  AV18DocCompartInterno.gxTpr_Documentoid = AV9DocumentoId_Copiado;
                  AV18DocCompartInterno.gxTpr_Compartinternoid = A57CompartInternoId;
                  AV18DocCompartInterno.Insert();
                  if ( AV18DocCompartInterno.Success() )
                  {
                     context.CommitDataStores("documentocopiaregistros",pr_default);
                  }
                  else
                  {
                     AV41GXV6 = 1;
                     AV40GXV5 = AV18DocCompartInterno.GetMessages();
                     while ( AV41GXV6 <= AV40GXV5.Count )
                     {
                        AV23Message = ((GeneXus.Utils.SdtMessages_Message)AV40GXV5.Item(AV41GXV6));
                        GX_msglist.addItem(AV23Message.gxTpr_Description);
                        AV41GXV6 = (int)(AV41GXV6+1);
                     }
                  }
                  pr_default.readNext(3);
               }
               pr_default.close(3);
               /* Using cursor P00736 */
               pr_default.execute(4, new Object[] {AV8DocumentoId_Copia});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A75DocumentoId = P00736_A75DocumentoId[0];
                  A54EnvolvidosColetaId = P00736_A54EnvolvidosColetaId[0];
                  AV19DocEnvolvidosColeta = new SdtDocEnvolvidosColeta(context);
                  AV19DocEnvolvidosColeta.gxTpr_Documentoid = AV9DocumentoId_Copiado;
                  AV19DocEnvolvidosColeta.gxTpr_Envolvidoscoletaid = A54EnvolvidosColetaId;
                  AV19DocEnvolvidosColeta.Insert();
                  if ( AV19DocEnvolvidosColeta.Success() )
                  {
                     context.CommitDataStores("documentocopiaregistros",pr_default);
                  }
                  else
                  {
                     AV44GXV8 = 1;
                     AV43GXV7 = AV19DocEnvolvidosColeta.GetMessages();
                     while ( AV44GXV8 <= AV43GXV7.Count )
                     {
                        AV23Message = ((GeneXus.Utils.SdtMessages_Message)AV43GXV7.Item(AV44GXV8));
                        GX_msglist.addItem(AV23Message.gxTpr_Description);
                        AV44GXV8 = (int)(AV44GXV8+1);
                     }
                  }
                  pr_default.readNext(4);
               }
               pr_default.close(4);
               /* Using cursor P00737 */
               pr_default.execute(5, new Object[] {AV8DocumentoId_Copia});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A75DocumentoId = P00737_A75DocumentoId[0];
                  A51MedidaSegurancaId = P00737_A51MedidaSegurancaId[0];
                  AV28DocMedidaSeguranca = new SdtDocMedidaSeguranca(context);
                  AV28DocMedidaSeguranca.gxTpr_Documentoid = AV9DocumentoId_Copiado;
                  AV28DocMedidaSeguranca.gxTpr_Medidasegurancaid = A51MedidaSegurancaId;
                  AV28DocMedidaSeguranca.Insert();
                  if ( AV28DocMedidaSeguranca.Success() )
                  {
                     context.CommitDataStores("documentocopiaregistros",pr_default);
                  }
                  else
                  {
                     AV47GXV10 = 1;
                     AV46GXV9 = AV28DocMedidaSeguranca.GetMessages();
                     while ( AV47GXV10 <= AV46GXV9.Count )
                     {
                        AV23Message = ((GeneXus.Utils.SdtMessages_Message)AV46GXV9.Item(AV47GXV10));
                        GX_msglist.addItem(AV23Message.gxTpr_Description);
                        AV47GXV10 = (int)(AV47GXV10+1);
                     }
                  }
                  pr_default.readNext(5);
               }
               pr_default.close(5);
               /* Using cursor P00738 */
               pr_default.execute(6, new Object[] {AV8DocumentoId_Copia});
               while ( (pr_default.getStatus(6) != 101) )
               {
                  A75DocumentoId = P00738_A75DocumentoId[0];
                  A95DocAnexoArquivo = P00738_A95DocAnexoArquivo[0];
                  A94DocAnexoDescricao = P00738_A94DocAnexoDescricao[0];
                  A93DocAnexoId = P00738_A93DocAnexoId[0];
                  AV12DocAnexo = new SdtDocAnexo(context);
                  AV12DocAnexo.gxTpr_Documentoid = AV9DocumentoId_Copiado;
                  AV12DocAnexo.gxTpr_Docanexoarquivo = A95DocAnexoArquivo;
                  AV12DocAnexo.gxTpr_Docanexodescricao = A94DocAnexoDescricao;
                  AV12DocAnexo.gxTpr_Docanexodatainclusao = DateTimeUtil.Today( context);
                  if ( AV12DocAnexo.Success() )
                  {
                     context.CommitDataStores("documentocopiaregistros",pr_default);
                  }
                  else
                  {
                     AV50GXV12 = 1;
                     AV49GXV11 = AV12DocAnexo.GetMessages();
                     while ( AV50GXV12 <= AV49GXV11.Count )
                     {
                        AV23Message = ((GeneXus.Utils.SdtMessages_Message)AV49GXV11.Item(AV50GXV12));
                        GX_msglist.addItem(AV23Message.gxTpr_Description);
                        AV50GXV12 = (int)(AV50GXV12+1);
                     }
                  }
                  pr_default.readNext(6);
               }
               pr_default.close(6);
               /* Using cursor P00739 */
               pr_default.execute(7, new Object[] {AV8DocumentoId_Copia});
               while ( (pr_default.getStatus(7) != 101) )
               {
                  A75DocumentoId = P00739_A75DocumentoId[0];
                  A98DocDicionarioId = P00739_A98DocDicionarioId[0];
                  A102DocDicionarioFinalidade = P00739_A102DocDicionarioFinalidade[0];
                  A100DocDicionarioPodeEliminar = P00739_A100DocDicionarioPodeEliminar[0];
                  A99DocDicionarioSensivel = P00739_A99DocDicionarioSensivel[0];
                  A119DocDicionarioTipoTransfInterGa = P00739_A119DocDicionarioTipoTransfInterGa[0];
                  A101DocDicionarioTransfInter = P00739_A101DocDicionarioTransfInter[0];
                  A72HipoteseTratamentoId = P00739_A72HipoteseTratamentoId[0];
                  A69InformacaoId = P00739_A69InformacaoId[0];
                  AV21DocDIcionarioId_Copia = (short)(A98DocDicionarioId);
                  AV13DocDicionario = new SdtDocDicionario(context);
                  AV13DocDicionario.gxTpr_Documentoid = AV9DocumentoId_Copiado;
                  AV13DocDicionario.gxTpr_Docdicionariofinalidade = A102DocDicionarioFinalidade;
                  AV13DocDicionario.gxTpr_Docdicionariopodeeliminar = A100DocDicionarioPodeEliminar;
                  AV13DocDicionario.gxTpr_Docdicionariosensivel = A99DocDicionarioSensivel;
                  AV13DocDicionario.gxTpr_Docdicionariotipotransfintergarantia = A119DocDicionarioTipoTransfInterGa;
                  AV13DocDicionario.gxTpr_Docdicionariotransfinter = A101DocDicionarioTransfInter;
                  if ( ! P00739_n72HipoteseTratamentoId[0] || ! (0==A72HipoteseTratamentoId) || ! ( A72HipoteseTratamentoId == 0 ) )
                  {
                     AV13DocDicionario.gxTpr_Hipotesetratamentoid = A72HipoteseTratamentoId;
                  }
                  else
                  {
                     AV13DocDicionario.gxTpr_Hipotesetratamentoid = 0;
                  }
                  if ( ! P00739_n69InformacaoId[0] || ! (0==A69InformacaoId) || ! ( A69InformacaoId == 0 ) )
                  {
                     AV13DocDicionario.gxTpr_Informacaoid = A69InformacaoId;
                  }
                  else
                  {
                     AV13DocDicionario.gxTpr_Informacaoid = 0;
                  }
                  AV13DocDicionario.gxTpr_Docdicionariodatainclusao = DateTimeUtil.Today( context);
                  AV13DocDicionario.Insert();
                  AV21DocDIcionarioId_Copia = (short)(AV13DocDicionario.gxTpr_Docdicionarioid);
                  if ( AV13DocDicionario.Success() )
                  {
                     context.CommitDataStores("documentocopiaregistros",pr_default);
                     /* Using cursor P007310 */
                     pr_default.execute(8, new Object[] {AV21DocDIcionarioId_Copia});
                     while ( (pr_default.getStatus(8) != 101) )
                     {
                        A98DocDicionarioId = P007310_A98DocDicionarioId[0];
                        A66CompartTercExternoId = P007310_A66CompartTercExternoId[0];
                        AV22DicionarioCompartTercExt = new SdtDicionarioCompartTercExt(context);
                        AV22DicionarioCompartTercExt.gxTpr_Docdicionarioid = A98DocDicionarioId;
                        AV22DicionarioCompartTercExt.gxTpr_Comparttercexternoid = A66CompartTercExternoId;
                        AV22DicionarioCompartTercExt.Insert();
                        if ( AV22DicionarioCompartTercExt.Success() )
                        {
                           context.CommitDataStores("documentocopiaregistros",pr_default);
                        }
                        else
                        {
                           AV54GXV14 = 1;
                           AV53GXV13 = AV22DicionarioCompartTercExt.GetMessages();
                           while ( AV54GXV14 <= AV53GXV13.Count )
                           {
                              AV23Message = ((GeneXus.Utils.SdtMessages_Message)AV53GXV13.Item(AV54GXV14));
                              GX_msglist.addItem(AV23Message.gxTpr_Description);
                              AV54GXV14 = (int)(AV54GXV14+1);
                           }
                        }
                        pr_default.readNext(8);
                     }
                     pr_default.close(8);
                     /* Using cursor P007311 */
                     pr_default.execute(9, new Object[] {AV21DocDIcionarioId_Copia});
                     while ( (pr_default.getStatus(9) != 101) )
                     {
                        A98DocDicionarioId = P007311_A98DocDicionarioId[0];
                        A4PaisId = P007311_A4PaisId[0];
                        AV29DicionarioPais = new SdtDicionarioPais(context);
                        AV29DicionarioPais.gxTpr_Docdicionarioid = A98DocDicionarioId;
                        AV29DicionarioPais.gxTpr_Paisid = A4PaisId;
                        AV29DicionarioPais.Insert();
                        if ( AV29DicionarioPais.Success() )
                        {
                           context.CommitDataStores("documentocopiaregistros",pr_default);
                        }
                        else
                        {
                           AV57GXV16 = 1;
                           AV56GXV15 = AV29DicionarioPais.GetMessages();
                           while ( AV57GXV16 <= AV56GXV15.Count )
                           {
                              AV23Message = ((GeneXus.Utils.SdtMessages_Message)AV56GXV15.Item(AV57GXV16));
                              GX_msglist.addItem(AV23Message.gxTpr_Description);
                              AV57GXV16 = (int)(AV57GXV16+1);
                           }
                        }
                        pr_default.readNext(9);
                     }
                     pr_default.close(9);
                  }
                  else
                  {
                     AV59GXV18 = 1;
                     AV58GXV17 = AV13DocDicionario.GetMessages();
                     while ( AV59GXV18 <= AV58GXV17.Count )
                     {
                        AV23Message = ((GeneXus.Utils.SdtMessages_Message)AV58GXV17.Item(AV59GXV18));
                        GX_msglist.addItem(AV23Message.gxTpr_Description);
                        AV59GXV18 = (int)(AV59GXV18+1);
                     }
                  }
                  pr_default.readNext(7);
               }
               pr_default.close(7);
               /* Using cursor P007312 */
               pr_default.execute(10, new Object[] {AV8DocumentoId_Copia});
               while ( (pr_default.getStatus(10) != 101) )
               {
                  A75DocumentoId = P007312_A75DocumentoId[0];
                  A42OperadorId = P007312_A42OperadorId[0];
                  A87DocOperadorColeta = P007312_A87DocOperadorColeta[0];
                  A89DocOperadorCompartilhamento = P007312_A89DocOperadorCompartilhamento[0];
                  A90DocOperadorEliminacao = P007312_A90DocOperadorEliminacao[0];
                  A91DocOperadorProcessamento = P007312_A91DocOperadorProcessamento[0];
                  A88DocOperadorRetencao = P007312_A88DocOperadorRetencao[0];
                  A86DocOperadorId = P007312_A86DocOperadorId[0];
                  AV14DocOperador = new SdtDocOperador(context);
                  AV14DocOperador.gxTpr_Documentoid = AV9DocumentoId_Copiado;
                  AV14DocOperador.gxTpr_Operadorid = A42OperadorId;
                  AV14DocOperador.gxTpr_Docoperadorcoleta = A87DocOperadorColeta;
                  AV14DocOperador.gxTpr_Docoperadorcompartilhamento = A89DocOperadorCompartilhamento;
                  AV14DocOperador.gxTpr_Docoperadoreliminacao = A90DocOperadorEliminacao;
                  AV14DocOperador.gxTpr_Docoperadorprocessamento = A91DocOperadorProcessamento;
                  AV14DocOperador.gxTpr_Docoperadorretencao = A88DocOperadorRetencao;
                  AV14DocOperador.gxTpr_Docoperadordatainclusao = DateTimeUtil.Today( context);
                  AV14DocOperador.Insert();
                  if ( AV14DocOperador.Success() )
                  {
                     context.CommitDataStores("documentocopiaregistros",pr_default);
                  }
                  else
                  {
                     AV62GXV20 = 1;
                     AV61GXV19 = AV14DocOperador.GetMessages();
                     while ( AV62GXV20 <= AV61GXV19.Count )
                     {
                        AV23Message = ((GeneXus.Utils.SdtMessages_Message)AV61GXV19.Item(AV62GXV20));
                        GX_msglist.addItem(AV23Message.gxTpr_Description);
                        AV62GXV20 = (int)(AV62GXV20+1);
                     }
                  }
                  pr_default.readNext(10);
               }
               pr_default.close(10);
            }
            else
            {
               AV64GXV22 = 1;
               AV63GXV21 = AV10Documento.GetMessages();
               while ( AV64GXV22 <= AV63GXV21.Count )
               {
                  AV23Message = ((GeneXus.Utils.SdtMessages_Message)AV63GXV21.Item(AV64GXV22));
                  GX_msglist.addItem(AV23Message.gxTpr_Description);
                  AV64GXV22 = (int)(AV64GXV22+1);
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "documentocadastrowp.aspx"+GXUtil.UrlEncode(StringUtil.RTrim("UPD")) + "," + GXUtil.UrlEncode(StringUtil.LTrimStr(AV9DocumentoId_Copiado,8,0)) + "," + GXUtil.UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("documentocadastrowp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         this.cleanup();
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
         scmdbuf = "";
         P00732_A75DocumentoId = new int[1] ;
         P00732_A106DocumentoProcessoId = new int[1] ;
         P00732_n106DocumentoProcessoId = new bool[] {false} ;
         P00732_A110DocumentoControladorId = new int[1] ;
         P00732_n110DocumentoControladorId = new bool[] {false} ;
         P00732_A36AbrangenciaGeograficaId = new int[1] ;
         P00732_n36AbrangenciaGeograficaId = new bool[] {false} ;
         P00732_A27CategoriaId = new int[1] ;
         P00732_n27CategoriaId = new bool[] {false} ;
         P00732_A7EncarregadoId = new int[1] ;
         P00732_n7EncarregadoId = new bool[] {false} ;
         P00732_A33FerramentaColetaId = new int[1] ;
         P00732_n33FerramentaColetaId = new bool[] {false} ;
         P00732_A39FrequenciaTratamentoId = new int[1] ;
         P00732_n39FrequenciaTratamentoId = new bool[] {false} ;
         P00732_A13PersonaId = new int[1] ;
         P00732_n13PersonaId = new bool[] {false} ;
         P00732_A20SubprocessoId = new int[1] ;
         P00732_n20SubprocessoId = new bool[] {false} ;
         P00732_A48TempoRetencaoId = new int[1] ;
         P00732_n48TempoRetencaoId = new bool[] {false} ;
         P00732_A30TipoDadoId = new int[1] ;
         P00732_n30TipoDadoId = new bool[] {false} ;
         P00732_A45TipoDescarteId = new int[1] ;
         P00732_n45TipoDescarteId = new bool[] {false} ;
         P00732_A24AreaResponsavelId = new int[1] ;
         P00732_n24AreaResponsavelId = new bool[] {false} ;
         P00732_A79DocumentoBaseLegalNorm = new string[] {""} ;
         P00732_n79DocumentoBaseLegalNorm = new bool[] {false} ;
         P00732_A80DocumentoBaseLegalNormIntExt = new string[] {""} ;
         P00732_n80DocumentoBaseLegalNormIntExt = new bool[] {false} ;
         P00732_A81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         P00732_n81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         P00732_A82DocumentoDadosGrupoVul = new bool[] {false} ;
         P00732_n82DocumentoDadosGrupoVul = new bool[] {false} ;
         P00732_A77DocumentoFinalidadeTratamento = new string[] {""} ;
         P00732_n77DocumentoFinalidadeTratamento = new bool[] {false} ;
         P00732_A84DocumentoFluxoTratDadosDesc = new string[] {""} ;
         P00732_n84DocumentoFluxoTratDadosDesc = new bool[] {false} ;
         P00732_A83DocumentoMedidaSegurancaDesc = new string[] {""} ;
         P00732_n83DocumentoMedidaSegurancaDesc = new bool[] {false} ;
         P00732_A105DocumentoOperador = new bool[] {false} ;
         P00732_n105DocumentoOperador = new bool[] {false} ;
         P00732_A78DocumentoPrevColetaDados = new bool[] {false} ;
         P00732_n78DocumentoPrevColetaDados = new bool[] {false} ;
         A79DocumentoBaseLegalNorm = "";
         A80DocumentoBaseLegalNormIntExt = "";
         A77DocumentoFinalidadeTratamento = "";
         A84DocumentoFluxoTratDadosDesc = "";
         A83DocumentoMedidaSegurancaDesc = "";
         AV10Documento = new SdtDocumento(context);
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         P00733_A75DocumentoId = new int[1] ;
         P00733_A63FonteRetencaoId = new int[1] ;
         AV16DocFonteRetencao = new SdtDocFonteRetencao(context);
         AV34GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV23Message = new GeneXus.Utils.SdtMessages_Message(context);
         P00734_A75DocumentoId = new int[1] ;
         P00734_A60SetorInternoId = new int[1] ;
         AV17DocSetorInterno = new SdtDocSetorInterno(context);
         AV37GXV3 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P00735_A75DocumentoId = new int[1] ;
         P00735_A57CompartInternoId = new int[1] ;
         AV18DocCompartInterno = new SdtDocCompartInterno(context);
         AV40GXV5 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P00736_A75DocumentoId = new int[1] ;
         P00736_A54EnvolvidosColetaId = new int[1] ;
         AV19DocEnvolvidosColeta = new SdtDocEnvolvidosColeta(context);
         AV43GXV7 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P00737_A75DocumentoId = new int[1] ;
         P00737_A51MedidaSegurancaId = new int[1] ;
         AV28DocMedidaSeguranca = new SdtDocMedidaSeguranca(context);
         AV46GXV9 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P00738_A75DocumentoId = new int[1] ;
         P00738_A95DocAnexoArquivo = new string[] {""} ;
         P00738_A94DocAnexoDescricao = new string[] {""} ;
         P00738_A93DocAnexoId = new int[1] ;
         A95DocAnexoArquivo = "";
         A94DocAnexoDescricao = "";
         AV12DocAnexo = new SdtDocAnexo(context);
         AV49GXV11 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P00739_A75DocumentoId = new int[1] ;
         P00739_A98DocDicionarioId = new int[1] ;
         P00739_A102DocDicionarioFinalidade = new string[] {""} ;
         P00739_A100DocDicionarioPodeEliminar = new bool[] {false} ;
         P00739_A99DocDicionarioSensivel = new bool[] {false} ;
         P00739_A119DocDicionarioTipoTransfInterGa = new string[] {""} ;
         P00739_A101DocDicionarioTransfInter = new bool[] {false} ;
         P00739_A72HipoteseTratamentoId = new int[1] ;
         P00739_A69InformacaoId = new int[1] ;
         A102DocDicionarioFinalidade = "";
         A119DocDicionarioTipoTransfInterGa = "";
         AV13DocDicionario = new SdtDocDicionario(context);
         P00739_n72HipoteseTratamentoId = new bool[] {false} ;
         P00739_n69InformacaoId = new bool[] {false} ;
         P007310_A98DocDicionarioId = new int[1] ;
         P007310_A66CompartTercExternoId = new int[1] ;
         AV22DicionarioCompartTercExt = new SdtDicionarioCompartTercExt(context);
         AV53GXV13 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P007311_A98DocDicionarioId = new int[1] ;
         P007311_A4PaisId = new int[1] ;
         AV29DicionarioPais = new SdtDicionarioPais(context);
         AV56GXV15 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV58GXV17 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P007312_A75DocumentoId = new int[1] ;
         P007312_A42OperadorId = new int[1] ;
         P007312_A87DocOperadorColeta = new bool[] {false} ;
         P007312_A89DocOperadorCompartilhamento = new bool[] {false} ;
         P007312_A90DocOperadorEliminacao = new bool[] {false} ;
         P007312_A91DocOperadorProcessamento = new bool[] {false} ;
         P007312_A88DocOperadorRetencao = new bool[] {false} ;
         P007312_A86DocOperadorId = new int[1] ;
         AV14DocOperador = new SdtDocOperador(context);
         AV61GXV19 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV63GXV21 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXKey = "";
         GXEncryptionTmp = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.documentocopiaregistros__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documentocopiaregistros__default(),
            new Object[][] {
                new Object[] {
               P00732_A75DocumentoId, P00732_A106DocumentoProcessoId, P00732_n106DocumentoProcessoId, P00732_A110DocumentoControladorId, P00732_n110DocumentoControladorId, P00732_A36AbrangenciaGeograficaId, P00732_n36AbrangenciaGeograficaId, P00732_A27CategoriaId, P00732_n27CategoriaId, P00732_A7EncarregadoId,
               P00732_n7EncarregadoId, P00732_A33FerramentaColetaId, P00732_n33FerramentaColetaId, P00732_A39FrequenciaTratamentoId, P00732_n39FrequenciaTratamentoId, P00732_A13PersonaId, P00732_n13PersonaId, P00732_A20SubprocessoId, P00732_n20SubprocessoId, P00732_A48TempoRetencaoId,
               P00732_n48TempoRetencaoId, P00732_A30TipoDadoId, P00732_n30TipoDadoId, P00732_A45TipoDescarteId, P00732_n45TipoDescarteId, P00732_A24AreaResponsavelId, P00732_n24AreaResponsavelId, P00732_A79DocumentoBaseLegalNorm, P00732_n79DocumentoBaseLegalNorm, P00732_A80DocumentoBaseLegalNormIntExt,
               P00732_n80DocumentoBaseLegalNormIntExt, P00732_A81DocumentoDadosCriancaAdolesc, P00732_n81DocumentoDadosCriancaAdolesc, P00732_A82DocumentoDadosGrupoVul, P00732_n82DocumentoDadosGrupoVul, P00732_A77DocumentoFinalidadeTratamento, P00732_n77DocumentoFinalidadeTratamento, P00732_A84DocumentoFluxoTratDadosDesc, P00732_n84DocumentoFluxoTratDadosDesc, P00732_A83DocumentoMedidaSegurancaDesc,
               P00732_n83DocumentoMedidaSegurancaDesc, P00732_A105DocumentoOperador, P00732_n105DocumentoOperador, P00732_A78DocumentoPrevColetaDados, P00732_n78DocumentoPrevColetaDados
               }
               , new Object[] {
               P00733_A75DocumentoId, P00733_A63FonteRetencaoId
               }
               , new Object[] {
               P00734_A75DocumentoId, P00734_A60SetorInternoId
               }
               , new Object[] {
               P00735_A75DocumentoId, P00735_A57CompartInternoId
               }
               , new Object[] {
               P00736_A75DocumentoId, P00736_A54EnvolvidosColetaId
               }
               , new Object[] {
               P00737_A75DocumentoId, P00737_A51MedidaSegurancaId
               }
               , new Object[] {
               P00738_A75DocumentoId, P00738_A95DocAnexoArquivo, P00738_A94DocAnexoDescricao, P00738_A93DocAnexoId
               }
               , new Object[] {
               P00739_A75DocumentoId, P00739_A98DocDicionarioId, P00739_A102DocDicionarioFinalidade, P00739_A100DocDicionarioPodeEliminar, P00739_A99DocDicionarioSensivel, P00739_A119DocDicionarioTipoTransfInterGa, P00739_A101DocDicionarioTransfInter, P00739_A72HipoteseTratamentoId, P00739_A69InformacaoId
               }
               , new Object[] {
               P007310_A98DocDicionarioId, P007310_A66CompartTercExternoId
               }
               , new Object[] {
               P007311_A98DocDicionarioId, P007311_A4PaisId
               }
               , new Object[] {
               P007312_A75DocumentoId, P007312_A42OperadorId, P007312_A87DocOperadorColeta, P007312_A89DocOperadorCompartilhamento, P007312_A90DocOperadorEliminacao, P007312_A91DocOperadorProcessamento, P007312_A88DocOperadorRetencao, P007312_A86DocOperadorId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV27Count ;
      private short AV21DocDIcionarioId_Copia ;
      private int AV8DocumentoId_Copia ;
      private int AV9DocumentoId_Copiado ;
      private int A75DocumentoId ;
      private int A106DocumentoProcessoId ;
      private int A110DocumentoControladorId ;
      private int A36AbrangenciaGeograficaId ;
      private int A27CategoriaId ;
      private int A7EncarregadoId ;
      private int A33FerramentaColetaId ;
      private int A39FrequenciaTratamentoId ;
      private int A13PersonaId ;
      private int A20SubprocessoId ;
      private int A48TempoRetencaoId ;
      private int A30TipoDadoId ;
      private int A45TipoDescarteId ;
      private int A24AreaResponsavelId ;
      private int A63FonteRetencaoId ;
      private int AV35GXV2 ;
      private int A60SetorInternoId ;
      private int AV38GXV4 ;
      private int A57CompartInternoId ;
      private int AV41GXV6 ;
      private int A54EnvolvidosColetaId ;
      private int AV44GXV8 ;
      private int A51MedidaSegurancaId ;
      private int AV47GXV10 ;
      private int A93DocAnexoId ;
      private int AV50GXV12 ;
      private int A98DocDicionarioId ;
      private int A72HipoteseTratamentoId ;
      private int A69InformacaoId ;
      private int A66CompartTercExternoId ;
      private int AV54GXV14 ;
      private int A4PaisId ;
      private int AV57GXV16 ;
      private int AV59GXV18 ;
      private int A42OperadorId ;
      private int A86DocOperadorId ;
      private int AV62GXV20 ;
      private int AV64GXV22 ;
      private string scmdbuf ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private DateTime GXt_dtime1 ;
      private bool n106DocumentoProcessoId ;
      private bool n110DocumentoControladorId ;
      private bool n36AbrangenciaGeograficaId ;
      private bool n27CategoriaId ;
      private bool n7EncarregadoId ;
      private bool n33FerramentaColetaId ;
      private bool n39FrequenciaTratamentoId ;
      private bool n13PersonaId ;
      private bool n20SubprocessoId ;
      private bool n48TempoRetencaoId ;
      private bool n30TipoDadoId ;
      private bool n45TipoDescarteId ;
      private bool n24AreaResponsavelId ;
      private bool n79DocumentoBaseLegalNorm ;
      private bool n80DocumentoBaseLegalNormIntExt ;
      private bool A81DocumentoDadosCriancaAdolesc ;
      private bool n81DocumentoDadosCriancaAdolesc ;
      private bool A82DocumentoDadosGrupoVul ;
      private bool n82DocumentoDadosGrupoVul ;
      private bool n77DocumentoFinalidadeTratamento ;
      private bool n84DocumentoFluxoTratDadosDesc ;
      private bool n83DocumentoMedidaSegurancaDesc ;
      private bool A105DocumentoOperador ;
      private bool n105DocumentoOperador ;
      private bool A78DocumentoPrevColetaDados ;
      private bool n78DocumentoPrevColetaDados ;
      private bool A100DocDicionarioPodeEliminar ;
      private bool A99DocDicionarioSensivel ;
      private bool A101DocDicionarioTransfInter ;
      private bool A87DocOperadorColeta ;
      private bool A89DocOperadorCompartilhamento ;
      private bool A90DocOperadorEliminacao ;
      private bool A91DocOperadorProcessamento ;
      private bool A88DocOperadorRetencao ;
      private string A84DocumentoFluxoTratDadosDesc ;
      private string A83DocumentoMedidaSegurancaDesc ;
      private string A102DocDicionarioFinalidade ;
      private string A119DocDicionarioTipoTransfInterGa ;
      private string AV26DocumentoNome_Copia ;
      private string A79DocumentoBaseLegalNorm ;
      private string A80DocumentoBaseLegalNormIntExt ;
      private string A77DocumentoFinalidadeTratamento ;
      private string A95DocAnexoArquivo ;
      private string A94DocAnexoDescricao ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00732_A75DocumentoId ;
      private int[] P00732_A106DocumentoProcessoId ;
      private bool[] P00732_n106DocumentoProcessoId ;
      private int[] P00732_A110DocumentoControladorId ;
      private bool[] P00732_n110DocumentoControladorId ;
      private int[] P00732_A36AbrangenciaGeograficaId ;
      private bool[] P00732_n36AbrangenciaGeograficaId ;
      private int[] P00732_A27CategoriaId ;
      private bool[] P00732_n27CategoriaId ;
      private int[] P00732_A7EncarregadoId ;
      private bool[] P00732_n7EncarregadoId ;
      private int[] P00732_A33FerramentaColetaId ;
      private bool[] P00732_n33FerramentaColetaId ;
      private int[] P00732_A39FrequenciaTratamentoId ;
      private bool[] P00732_n39FrequenciaTratamentoId ;
      private int[] P00732_A13PersonaId ;
      private bool[] P00732_n13PersonaId ;
      private int[] P00732_A20SubprocessoId ;
      private bool[] P00732_n20SubprocessoId ;
      private int[] P00732_A48TempoRetencaoId ;
      private bool[] P00732_n48TempoRetencaoId ;
      private int[] P00732_A30TipoDadoId ;
      private bool[] P00732_n30TipoDadoId ;
      private int[] P00732_A45TipoDescarteId ;
      private bool[] P00732_n45TipoDescarteId ;
      private int[] P00732_A24AreaResponsavelId ;
      private bool[] P00732_n24AreaResponsavelId ;
      private string[] P00732_A79DocumentoBaseLegalNorm ;
      private bool[] P00732_n79DocumentoBaseLegalNorm ;
      private string[] P00732_A80DocumentoBaseLegalNormIntExt ;
      private bool[] P00732_n80DocumentoBaseLegalNormIntExt ;
      private bool[] P00732_A81DocumentoDadosCriancaAdolesc ;
      private bool[] P00732_n81DocumentoDadosCriancaAdolesc ;
      private bool[] P00732_A82DocumentoDadosGrupoVul ;
      private bool[] P00732_n82DocumentoDadosGrupoVul ;
      private string[] P00732_A77DocumentoFinalidadeTratamento ;
      private bool[] P00732_n77DocumentoFinalidadeTratamento ;
      private string[] P00732_A84DocumentoFluxoTratDadosDesc ;
      private bool[] P00732_n84DocumentoFluxoTratDadosDesc ;
      private string[] P00732_A83DocumentoMedidaSegurancaDesc ;
      private bool[] P00732_n83DocumentoMedidaSegurancaDesc ;
      private bool[] P00732_A105DocumentoOperador ;
      private bool[] P00732_n105DocumentoOperador ;
      private bool[] P00732_A78DocumentoPrevColetaDados ;
      private bool[] P00732_n78DocumentoPrevColetaDados ;
      private int[] P00733_A75DocumentoId ;
      private int[] P00733_A63FonteRetencaoId ;
      private int[] P00734_A75DocumentoId ;
      private int[] P00734_A60SetorInternoId ;
      private int[] P00735_A75DocumentoId ;
      private int[] P00735_A57CompartInternoId ;
      private int[] P00736_A75DocumentoId ;
      private int[] P00736_A54EnvolvidosColetaId ;
      private int[] P00737_A75DocumentoId ;
      private int[] P00737_A51MedidaSegurancaId ;
      private int[] P00738_A75DocumentoId ;
      private string[] P00738_A95DocAnexoArquivo ;
      private string[] P00738_A94DocAnexoDescricao ;
      private int[] P00738_A93DocAnexoId ;
      private int[] P00739_A75DocumentoId ;
      private int[] P00739_A98DocDicionarioId ;
      private string[] P00739_A102DocDicionarioFinalidade ;
      private bool[] P00739_A100DocDicionarioPodeEliminar ;
      private bool[] P00739_A99DocDicionarioSensivel ;
      private string[] P00739_A119DocDicionarioTipoTransfInterGa ;
      private bool[] P00739_A101DocDicionarioTransfInter ;
      private int[] P00739_A72HipoteseTratamentoId ;
      private int[] P00739_A69InformacaoId ;
      private bool[] P00739_n72HipoteseTratamentoId ;
      private bool[] P00739_n69InformacaoId ;
      private int[] P007310_A98DocDicionarioId ;
      private int[] P007310_A66CompartTercExternoId ;
      private int[] P007311_A98DocDicionarioId ;
      private int[] P007311_A4PaisId ;
      private int[] P007312_A75DocumentoId ;
      private int[] P007312_A42OperadorId ;
      private bool[] P007312_A87DocOperadorColeta ;
      private bool[] P007312_A89DocOperadorCompartilhamento ;
      private bool[] P007312_A90DocOperadorEliminacao ;
      private bool[] P007312_A91DocOperadorProcessamento ;
      private bool[] P007312_A88DocOperadorRetencao ;
      private int[] P007312_A86DocOperadorId ;
      private int aP2_DocumentoId_Copiado ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV34GXV1 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV37GXV3 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV40GXV5 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV43GXV7 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV46GXV9 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV49GXV11 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV53GXV13 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV56GXV15 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV58GXV17 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV61GXV19 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV63GXV21 ;
      private SdtDocumento AV10Documento ;
      private GeneXus.Utils.SdtMessages_Message AV23Message ;
      private SdtDocAnexo AV12DocAnexo ;
      private SdtDocDicionario AV13DocDicionario ;
      private SdtDocOperador AV14DocOperador ;
      private SdtDocFonteRetencao AV16DocFonteRetencao ;
      private SdtDocSetorInterno AV17DocSetorInterno ;
      private SdtDocCompartInterno AV18DocCompartInterno ;
      private SdtDocEnvolvidosColeta AV19DocEnvolvidosColeta ;
      private SdtDicionarioCompartTercExt AV22DicionarioCompartTercExt ;
      private SdtDocMedidaSeguranca AV28DocMedidaSeguranca ;
      private SdtDicionarioPais AV29DicionarioPais ;
   }

   public class documentocopiaregistros__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class documentocopiaregistros__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00732;
        prmP00732 = new Object[] {
        new ParDef("@AV8DocumentoId_Copia",GXType.Int32,8,0)
        };
        Object[] prmP00733;
        prmP00733 = new Object[] {
        new ParDef("@AV8DocumentoId_Copia",GXType.Int32,8,0)
        };
        Object[] prmP00734;
        prmP00734 = new Object[] {
        new ParDef("@AV8DocumentoId_Copia",GXType.Int32,8,0)
        };
        Object[] prmP00735;
        prmP00735 = new Object[] {
        new ParDef("@AV8DocumentoId_Copia",GXType.Int32,8,0)
        };
        Object[] prmP00736;
        prmP00736 = new Object[] {
        new ParDef("@AV8DocumentoId_Copia",GXType.Int32,8,0)
        };
        Object[] prmP00737;
        prmP00737 = new Object[] {
        new ParDef("@AV8DocumentoId_Copia",GXType.Int32,8,0)
        };
        Object[] prmP00738;
        prmP00738 = new Object[] {
        new ParDef("@AV8DocumentoId_Copia",GXType.Int32,8,0)
        };
        Object[] prmP00739;
        prmP00739 = new Object[] {
        new ParDef("@AV8DocumentoId_Copia",GXType.Int32,8,0)
        };
        Object[] prmP007310;
        prmP007310 = new Object[] {
        new ParDef("@AV21DocDIcionarioId_Copia",GXType.Int16,4,0)
        };
        Object[] prmP007311;
        prmP007311 = new Object[] {
        new ParDef("@AV21DocDIcionarioId_Copia",GXType.Int16,4,0)
        };
        Object[] prmP007312;
        prmP007312 = new Object[] {
        new ParDef("@AV8DocumentoId_Copia",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00732", "SELECT [DocumentoId], [DocumentoProcessoId], [DocumentoControladorId], [AbrangenciaGeograficaId], [CategoriaId], [EncarregadoId], [FerramentaColetaId], [FrequenciaTratamentoId], [PersonaId], [SubprocessoId], [TempoRetencaoId], [TipoDadoId], [TipoDescarteId], [AreaResponsavelId], [DocumentoBaseLegalNorm], [DocumentoBaseLegalNormIntExt], [DocumentoDadosCriancaAdolesc], [DocumentoDadosGrupoVul], [DocumentoFinalidadeTratamento], [DocumentoFluxoTratDadosDesc], [DocumentoMedidaSegurancaDesc], [DocumentoOperador], [DocumentoPrevColetaDados] FROM [Documento] WHERE [DocumentoId] = @AV8DocumentoId_Copia ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00732,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00733", "SELECT [DocumentoId], [FonteRetencaoId] FROM [DocFonteRetencao] WHERE [DocumentoId] = @AV8DocumentoId_Copia ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00733,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00734", "SELECT [DocumentoId], [SetorInternoId] FROM [DocSetorInterno] WHERE [DocumentoId] = @AV8DocumentoId_Copia ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00734,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00735", "SELECT [DocumentoId], [CompartInternoId] FROM [DocCompartInterno] WHERE [DocumentoId] = @AV8DocumentoId_Copia ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00735,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00736", "SELECT [DocumentoId], [EnvolvidosColetaId] FROM [DocEnvolvidosColeta] WHERE [DocumentoId] = @AV8DocumentoId_Copia ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00736,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00737", "SELECT [DocumentoId], [MedidaSegurancaId] FROM [DocMedidaSeguranca] WHERE [DocumentoId] = @AV8DocumentoId_Copia ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00737,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00738", "SELECT [DocumentoId], [DocAnexoArquivo], [DocAnexoDescricao], [DocAnexoId] FROM [DocAnexo] WHERE [DocumentoId] = @AV8DocumentoId_Copia ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00738,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("P00739", "SELECT [DocumentoId], [DocDicionarioId], [DocDicionarioFinalidade], [DocDicionarioPodeEliminar], [DocDicionarioSensivel], [DocDicionarioTipoTransfInterGa], [DocDicionarioTransfInter], [HipoteseTratamentoId], [InformacaoId] FROM [DocDicionario] WHERE [DocumentoId] = @AV8DocumentoId_Copia ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00739,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P007310", "SELECT [DocDicionarioId], [CompartTercExternoId] FROM [DicionarioCompartTercExt] WHERE [DocDicionarioId] = @AV21DocDIcionarioId_Copia ORDER BY [DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007310,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P007311", "SELECT [DocDicionarioId], [PaisId] FROM [DicionarioPais] WHERE [DocDicionarioId] = @AV21DocDIcionarioId_Copia ORDER BY [DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007311,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P007312", "SELECT [DocumentoId], [OperadorId], [DocOperadorColeta], [DocOperadorCompartilhamento], [DocOperadorEliminacao], [DocOperadorProcessamento], [DocOperadorRetencao], [DocOperadorId] FROM [DocOperador] WHERE [DocumentoId] = @AV8DocumentoId_Copia ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007312,100, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((int[]) buf[3])[0] = rslt.getInt(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((int[]) buf[5])[0] = rslt.getInt(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((int[]) buf[7])[0] = rslt.getInt(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((int[]) buf[9])[0] = rslt.getInt(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((int[]) buf[11])[0] = rslt.getInt(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((int[]) buf[13])[0] = rslt.getInt(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((int[]) buf[15])[0] = rslt.getInt(9);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((int[]) buf[17])[0] = rslt.getInt(10);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((int[]) buf[19])[0] = rslt.getInt(11);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((int[]) buf[21])[0] = rslt.getInt(12);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              ((int[]) buf[23])[0] = rslt.getInt(13);
              ((bool[]) buf[24])[0] = rslt.wasNull(13);
              ((int[]) buf[25])[0] = rslt.getInt(14);
              ((bool[]) buf[26])[0] = rslt.wasNull(14);
              ((string[]) buf[27])[0] = rslt.getVarchar(15);
              ((bool[]) buf[28])[0] = rslt.wasNull(15);
              ((string[]) buf[29])[0] = rslt.getVarchar(16);
              ((bool[]) buf[30])[0] = rslt.wasNull(16);
              ((bool[]) buf[31])[0] = rslt.getBool(17);
              ((bool[]) buf[32])[0] = rslt.wasNull(17);
              ((bool[]) buf[33])[0] = rslt.getBool(18);
              ((bool[]) buf[34])[0] = rslt.wasNull(18);
              ((string[]) buf[35])[0] = rslt.getVarchar(19);
              ((bool[]) buf[36])[0] = rslt.wasNull(19);
              ((string[]) buf[37])[0] = rslt.getLongVarchar(20);
              ((bool[]) buf[38])[0] = rslt.wasNull(20);
              ((string[]) buf[39])[0] = rslt.getLongVarchar(21);
              ((bool[]) buf[40])[0] = rslt.wasNull(21);
              ((bool[]) buf[41])[0] = rslt.getBool(22);
              ((bool[]) buf[42])[0] = rslt.wasNull(22);
              ((bool[]) buf[43])[0] = rslt.getBool(23);
              ((bool[]) buf[44])[0] = rslt.wasNull(23);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              return;
     }
  }

}

}
