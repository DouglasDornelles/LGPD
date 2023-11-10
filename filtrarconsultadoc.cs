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
   public class filtrarconsultadoc : GXProcedure
   {
      public filtrarconsultadoc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public filtrarconsultadoc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( SdtFiltrosDocumento aP0_FiltrosDocumento ,
                           bool aP1_IsBuscaAvancada ,
                           out GxSimpleCollection<int> aP2_Documentos )
      {
         this.AV9FiltrosDocumento = aP0_FiltrosDocumento;
         this.AV10IsBuscaAvancada = aP1_IsBuscaAvancada;
         this.AV8Documentos = new GxSimpleCollection<int>() ;
         initialize();
         executePrivate();
         aP2_Documentos=this.AV8Documentos;
      }

      public GxSimpleCollection<int> executeUdp( SdtFiltrosDocumento aP0_FiltrosDocumento ,
                                                 bool aP1_IsBuscaAvancada )
      {
         execute(aP0_FiltrosDocumento, aP1_IsBuscaAvancada, out aP2_Documentos);
         return AV8Documentos ;
      }

      public void executeSubmit( SdtFiltrosDocumento aP0_FiltrosDocumento ,
                                 bool aP1_IsBuscaAvancada ,
                                 out GxSimpleCollection<int> aP2_Documentos )
      {
         filtrarconsultadoc objfiltrarconsultadoc;
         objfiltrarconsultadoc = new filtrarconsultadoc();
         objfiltrarconsultadoc.AV9FiltrosDocumento = aP0_FiltrosDocumento;
         objfiltrarconsultadoc.AV10IsBuscaAvancada = aP1_IsBuscaAvancada;
         objfiltrarconsultadoc.AV8Documentos = new GxSimpleCollection<int>() ;
         objfiltrarconsultadoc.context.SetSubmitInitialConfig(context);
         objfiltrarconsultadoc.initialize();
         Submit( executePrivateCatch,objfiltrarconsultadoc);
         aP2_Documentos=this.AV8Documentos;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((filtrarconsultadoc)stateInfo).executePrivate();
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
         if ( AV10IsBuscaAvancada )
         {
            if ( AV9FiltrosDocumento.gxTpr_Isdocumento || AV9FiltrosDocumento.gxTpr_Istratamento )
            {
               pr_default.dynParam(0, new Object[]{ new Object[]{
                                                    AV9FiltrosDocumento.gxTpr_Nome ,
                                                    AV9FiltrosDocumento.gxTpr_Processo ,
                                                    AV9FiltrosDocumento.gxTpr_Subprocesso ,
                                                    AV9FiltrosDocumento.gxTpr_Arearesponsavel ,
                                                    AV9FiltrosDocumento.gxTpr_Controlador ,
                                                    AV9FiltrosDocumento.gxTpr_Encarregado ,
                                                    AV9FiltrosDocumento.gxTpr_Persona ,
                                                    AV9FiltrosDocumento.gxTpr_Finalidadetratamento ,
                                                    AV9FiltrosDocumento.gxTpr_Categoria ,
                                                    AV9FiltrosDocumento.gxTpr_Tipodado ,
                                                    AV9FiltrosDocumento.gxTpr_Ferramentacoleta ,
                                                    AV9FiltrosDocumento.gxTpr_Abrangenciageografica ,
                                                    AV9FiltrosDocumento.gxTpr_Frequenciatratamento ,
                                                    AV9FiltrosDocumento.gxTpr_Tipodescarte ,
                                                    AV9FiltrosDocumento.gxTpr_Temporetencao ,
                                                    AV9FiltrosDocumento.gxTpr_Prevcoletadados ,
                                                    AV9FiltrosDocumento.gxTpr_Baselegal ,
                                                    AV9FiltrosDocumento.gxTpr_Baselegalextint ,
                                                    AV9FiltrosDocumento.gxTpr_Dadosgrupovulneravel ,
                                                    AV9FiltrosDocumento.gxTpr_Dadoscriancaadolescente ,
                                                    A106DocumentoProcessoId ,
                                                    A20SubprocessoId ,
                                                    A24AreaResponsavelId ,
                                                    A110DocumentoControladorId ,
                                                    A7EncarregadoId ,
                                                    A13PersonaId ,
                                                    A27CategoriaId ,
                                                    A30TipoDadoId ,
                                                    A33FerramentaColetaId ,
                                                    A36AbrangenciaGeograficaId ,
                                                    A39FrequenciaTratamentoId ,
                                                    A45TipoDescarteId ,
                                                    A48TempoRetencaoId ,
                                                    A78DocumentoPrevColetaDados ,
                                                    A82DocumentoDadosGrupoVul ,
                                                    A81DocumentoDadosCriancaAdolesc } ,
                                                    new int[]{
                                                    TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                                    TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                                    TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                                    TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                                    TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                    }
               });
               /* Using cursor P006A2 */
               pr_default.execute(0, new Object[] {AV9FiltrosDocumento.gxTpr_Nome, AV9FiltrosDocumento.gxTpr_Processo, AV9FiltrosDocumento.gxTpr_Subprocesso, AV9FiltrosDocumento.gxTpr_Arearesponsavel, AV9FiltrosDocumento.gxTpr_Controlador, AV9FiltrosDocumento.gxTpr_Encarregado, AV9FiltrosDocumento.gxTpr_Persona, AV9FiltrosDocumento.gxTpr_Finalidadetratamento, AV9FiltrosDocumento.gxTpr_Categoria, AV9FiltrosDocumento.gxTpr_Tipodado, AV9FiltrosDocumento.gxTpr_Ferramentacoleta, AV9FiltrosDocumento.gxTpr_Abrangenciageografica, AV9FiltrosDocumento.gxTpr_Frequenciatratamento, AV9FiltrosDocumento.gxTpr_Tipodescarte, AV9FiltrosDocumento.gxTpr_Temporetencao, AV9FiltrosDocumento.gxTpr_Prevcoletadados, AV9FiltrosDocumento.gxTpr_Baselegal, AV9FiltrosDocumento.gxTpr_Baselegalextint, AV9FiltrosDocumento.gxTpr_Dadosgrupovulneravel, AV9FiltrosDocumento.gxTpr_Dadoscriancaadolescente});
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A81DocumentoDadosCriancaAdolesc = P006A2_A81DocumentoDadosCriancaAdolesc[0];
                  n81DocumentoDadosCriancaAdolesc = P006A2_n81DocumentoDadosCriancaAdolesc[0];
                  A82DocumentoDadosGrupoVul = P006A2_A82DocumentoDadosGrupoVul[0];
                  n82DocumentoDadosGrupoVul = P006A2_n82DocumentoDadosGrupoVul[0];
                  A80DocumentoBaseLegalNormIntExt = P006A2_A80DocumentoBaseLegalNormIntExt[0];
                  n80DocumentoBaseLegalNormIntExt = P006A2_n80DocumentoBaseLegalNormIntExt[0];
                  A79DocumentoBaseLegalNorm = P006A2_A79DocumentoBaseLegalNorm[0];
                  n79DocumentoBaseLegalNorm = P006A2_n79DocumentoBaseLegalNorm[0];
                  A78DocumentoPrevColetaDados = P006A2_A78DocumentoPrevColetaDados[0];
                  n78DocumentoPrevColetaDados = P006A2_n78DocumentoPrevColetaDados[0];
                  A48TempoRetencaoId = P006A2_A48TempoRetencaoId[0];
                  n48TempoRetencaoId = P006A2_n48TempoRetencaoId[0];
                  A45TipoDescarteId = P006A2_A45TipoDescarteId[0];
                  n45TipoDescarteId = P006A2_n45TipoDescarteId[0];
                  A39FrequenciaTratamentoId = P006A2_A39FrequenciaTratamentoId[0];
                  n39FrequenciaTratamentoId = P006A2_n39FrequenciaTratamentoId[0];
                  A36AbrangenciaGeograficaId = P006A2_A36AbrangenciaGeograficaId[0];
                  n36AbrangenciaGeograficaId = P006A2_n36AbrangenciaGeograficaId[0];
                  A33FerramentaColetaId = P006A2_A33FerramentaColetaId[0];
                  n33FerramentaColetaId = P006A2_n33FerramentaColetaId[0];
                  A30TipoDadoId = P006A2_A30TipoDadoId[0];
                  n30TipoDadoId = P006A2_n30TipoDadoId[0];
                  A27CategoriaId = P006A2_A27CategoriaId[0];
                  n27CategoriaId = P006A2_n27CategoriaId[0];
                  A77DocumentoFinalidadeTratamento = P006A2_A77DocumentoFinalidadeTratamento[0];
                  n77DocumentoFinalidadeTratamento = P006A2_n77DocumentoFinalidadeTratamento[0];
                  A13PersonaId = P006A2_A13PersonaId[0];
                  n13PersonaId = P006A2_n13PersonaId[0];
                  A7EncarregadoId = P006A2_A7EncarregadoId[0];
                  n7EncarregadoId = P006A2_n7EncarregadoId[0];
                  A110DocumentoControladorId = P006A2_A110DocumentoControladorId[0];
                  n110DocumentoControladorId = P006A2_n110DocumentoControladorId[0];
                  A24AreaResponsavelId = P006A2_A24AreaResponsavelId[0];
                  n24AreaResponsavelId = P006A2_n24AreaResponsavelId[0];
                  A20SubprocessoId = P006A2_A20SubprocessoId[0];
                  n20SubprocessoId = P006A2_n20SubprocessoId[0];
                  A106DocumentoProcessoId = P006A2_A106DocumentoProcessoId[0];
                  n106DocumentoProcessoId = P006A2_n106DocumentoProcessoId[0];
                  A76DocumentoNome = P006A2_A76DocumentoNome[0];
                  n76DocumentoNome = P006A2_n76DocumentoNome[0];
                  A75DocumentoId = P006A2_A75DocumentoId[0];
                  A85DocumentoAtivo = P006A2_A85DocumentoAtivo[0];
                  n85DocumentoAtivo = P006A2_n85DocumentoAtivo[0];
                  if ( AV9FiltrosDocumento.gxTpr_Situacao == 0 )
                  {
                     AV12DocumentosFiltrados.Add(A75DocumentoId, 0);
                  }
                  else if ( ( AV9FiltrosDocumento.gxTpr_Situacao == 1 ) && ! A85DocumentoAtivo )
                  {
                     AV12DocumentosFiltrados.Add(A75DocumentoId, 0);
                  }
                  else if ( ( AV9FiltrosDocumento.gxTpr_Situacao == 2 ) && ( A85DocumentoAtivo ) )
                  {
                     AV12DocumentosFiltrados.Add(A75DocumentoId, 0);
                  }
                  pr_default.readNext(0);
               }
               pr_default.close(0);
            }
            if ( AV9FiltrosDocumento.gxTpr_Isdicionario )
            {
               pr_default.dynParam(1, new Object[]{ new Object[]{
                                                    AV9FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Informacao ,
                                                    AV9FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Hipotesetratamento ,
                                                    AV9FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Transfint ,
                                                    AV9FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Pais ,
                                                    AV9FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Dadosensivel ,
                                                    AV9FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Eliminardado ,
                                                    AV9FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Tipotransfint ,
                                                    AV9FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Finalidadedicio ,
                                                    A69InformacaoId ,
                                                    A72HipoteseTratamentoId ,
                                                    A101DocDicionarioTransfInter ,
                                                    A99DocDicionarioSensivel ,
                                                    A100DocDicionarioPodeEliminar } ,
                                                    new int[]{
                                                    TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                    TypeConstants.BOOLEAN
                                                    }
               });
               /* Using cursor P006A3 */
               pr_default.execute(1, new Object[] {AV9FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Informacao, AV9FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Hipotesetratamento, AV9FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Transfint, AV9FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Dadosensivel, AV9FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Eliminardado, AV9FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Tipotransfint, AV9FiltrosDocumento.gxTpr_Docdicionario.gxTpr_Finalidadedicio});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A102DocDicionarioFinalidade = P006A3_A102DocDicionarioFinalidade[0];
                  A119DocDicionarioTipoTransfInterGa = P006A3_A119DocDicionarioTipoTransfInterGa[0];
                  A100DocDicionarioPodeEliminar = P006A3_A100DocDicionarioPodeEliminar[0];
                  A99DocDicionarioSensivel = P006A3_A99DocDicionarioSensivel[0];
                  A101DocDicionarioTransfInter = P006A3_A101DocDicionarioTransfInter[0];
                  A72HipoteseTratamentoId = P006A3_A72HipoteseTratamentoId[0];
                  A69InformacaoId = P006A3_A69InformacaoId[0];
                  A75DocumentoId = P006A3_A75DocumentoId[0];
                  A98DocDicionarioId = P006A3_A98DocDicionarioId[0];
                  if ( AV9FiltrosDocumento.gxTpr_Isdocumento || AV9FiltrosDocumento.gxTpr_Istratamento )
                  {
                     if ( (AV12DocumentosFiltrados.IndexOf(A75DocumentoId)>0) )
                     {
                        AV13DocumentosDicionario.Add(A75DocumentoId, 0);
                     }
                  }
                  else
                  {
                     AV13DocumentosDicionario.Add(A75DocumentoId, 0);
                  }
                  pr_default.readNext(1);
               }
               pr_default.close(1);
            }
            if ( AV9FiltrosDocumento.gxTpr_Isoperador )
            {
               pr_default.dynParam(2, new Object[]{ new Object[]{
                                                    AV9FiltrosDocumento.gxTpr_Docoperador.gxTpr_Operador ,
                                                    AV9FiltrosDocumento.gxTpr_Docoperador.gxTpr_Operadorcadastrado ,
                                                    AV9FiltrosDocumento.gxTpr_Docoperador.gxTpr_Operadorcoleta ,
                                                    AV9FiltrosDocumento.gxTpr_Docoperador.gxTpr_Operadorretencao ,
                                                    AV9FiltrosDocumento.gxTpr_Docoperador.gxTpr_Operadorcompartilhamento ,
                                                    AV9FiltrosDocumento.gxTpr_Docoperador.gxTpr_Operadoreliminacao ,
                                                    AV9FiltrosDocumento.gxTpr_Docoperador.gxTpr_Operadorprocessamento ,
                                                    A105DocumentoOperador ,
                                                    A42OperadorId ,
                                                    A87DocOperadorColeta ,
                                                    A88DocOperadorRetencao ,
                                                    A89DocOperadorCompartilhamento ,
                                                    A90DocOperadorEliminacao ,
                                                    A91DocOperadorProcessamento } ,
                                                    new int[]{
                                                    TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                                    TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                    }
               });
               /* Using cursor P006A4 */
               pr_default.execute(2, new Object[] {AV9FiltrosDocumento.gxTpr_Docoperador.gxTpr_Operador, AV9FiltrosDocumento.gxTpr_Docoperador.gxTpr_Operadorcadastrado, AV9FiltrosDocumento.gxTpr_Docoperador.gxTpr_Operadorcoleta, AV9FiltrosDocumento.gxTpr_Docoperador.gxTpr_Operadorretencao, AV9FiltrosDocumento.gxTpr_Docoperador.gxTpr_Operadorcompartilhamento, AV9FiltrosDocumento.gxTpr_Docoperador.gxTpr_Operadoreliminacao, AV9FiltrosDocumento.gxTpr_Docoperador.gxTpr_Operadorprocessamento});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A91DocOperadorProcessamento = P006A4_A91DocOperadorProcessamento[0];
                  A90DocOperadorEliminacao = P006A4_A90DocOperadorEliminacao[0];
                  A89DocOperadorCompartilhamento = P006A4_A89DocOperadorCompartilhamento[0];
                  A88DocOperadorRetencao = P006A4_A88DocOperadorRetencao[0];
                  A87DocOperadorColeta = P006A4_A87DocOperadorColeta[0];
                  A42OperadorId = P006A4_A42OperadorId[0];
                  A105DocumentoOperador = P006A4_A105DocumentoOperador[0];
                  n105DocumentoOperador = P006A4_n105DocumentoOperador[0];
                  A75DocumentoId = P006A4_A75DocumentoId[0];
                  A86DocOperadorId = P006A4_A86DocOperadorId[0];
                  A105DocumentoOperador = P006A4_A105DocumentoOperador[0];
                  n105DocumentoOperador = P006A4_n105DocumentoOperador[0];
                  if ( AV9FiltrosDocumento.gxTpr_Isdocumento || AV9FiltrosDocumento.gxTpr_Istratamento )
                  {
                     if ( (AV12DocumentosFiltrados.IndexOf(A75DocumentoId)>0) )
                     {
                        if ( AV9FiltrosDocumento.gxTpr_Isdicionario )
                        {
                           if ( (AV13DocumentosDicionario.IndexOf(A75DocumentoId)>0) )
                           {
                              AV14DocumentosOperador.Add(A75DocumentoId, 0);
                           }
                        }
                        else
                        {
                           AV14DocumentosOperador.Add(A75DocumentoId, 0);
                        }
                     }
                  }
                  else
                  {
                     if ( AV9FiltrosDocumento.gxTpr_Isdicionario )
                     {
                        if ( (AV13DocumentosDicionario.IndexOf(A75DocumentoId)>0) )
                        {
                           AV14DocumentosOperador.Add(A75DocumentoId, 0);
                        }
                     }
                     else
                     {
                        AV14DocumentosOperador.Add(A75DocumentoId, 0);
                     }
                  }
                  pr_default.readNext(2);
               }
               pr_default.close(2);
            }
            if ( AV9FiltrosDocumento.gxTpr_Isoperador )
            {
               AV21GXV1 = 1;
               while ( AV21GXV1 <= AV14DocumentosOperador.Count )
               {
                  AV15DocumentoId_Aux = (int)(AV14DocumentosOperador.GetNumeric(AV21GXV1));
                  AV8Documentos.Add(AV15DocumentoId_Aux, 0);
                  AV21GXV1 = (int)(AV21GXV1+1);
               }
            }
            else
            {
               if ( AV9FiltrosDocumento.gxTpr_Isdicionario )
               {
                  AV22GXV2 = 1;
                  while ( AV22GXV2 <= AV13DocumentosDicionario.Count )
                  {
                     AV15DocumentoId_Aux = (int)(AV13DocumentosDicionario.GetNumeric(AV22GXV2));
                     AV8Documentos.Add(AV15DocumentoId_Aux, 0);
                     AV22GXV2 = (int)(AV22GXV2+1);
                  }
               }
               else
               {
                  AV23GXV3 = 1;
                  while ( AV23GXV3 <= AV12DocumentosFiltrados.Count )
                  {
                     AV15DocumentoId_Aux = (int)(AV12DocumentosFiltrados.GetNumeric(AV23GXV3));
                     AV8Documentos.Add(AV15DocumentoId_Aux, 0);
                     AV23GXV3 = (int)(AV23GXV3+1);
                  }
               }
            }
         }
         else
         {
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV9FiltrosDocumento.gxTpr_Nome ,
                                                 AV9FiltrosDocumento.gxTpr_Processo ,
                                                 AV9FiltrosDocumento.gxTpr_Subprocesso ,
                                                 AV9FiltrosDocumento.gxTpr_Arearesponsavel ,
                                                 AV9FiltrosDocumento.gxTpr_Controlador ,
                                                 AV9FiltrosDocumento.gxTpr_Encarregado ,
                                                 AV9FiltrosDocumento.gxTpr_Persona ,
                                                 A106DocumentoProcessoId ,
                                                 A20SubprocessoId ,
                                                 A24AreaResponsavelId ,
                                                 A110DocumentoControladorId ,
                                                 A7EncarregadoId ,
                                                 A13PersonaId } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                                 TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                                 }
            });
            /* Using cursor P006A5 */
            pr_default.execute(3, new Object[] {AV9FiltrosDocumento.gxTpr_Nome, AV9FiltrosDocumento.gxTpr_Processo, AV9FiltrosDocumento.gxTpr_Subprocesso, AV9FiltrosDocumento.gxTpr_Arearesponsavel, AV9FiltrosDocumento.gxTpr_Controlador, AV9FiltrosDocumento.gxTpr_Encarregado, AV9FiltrosDocumento.gxTpr_Persona});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A13PersonaId = P006A5_A13PersonaId[0];
               n13PersonaId = P006A5_n13PersonaId[0];
               A7EncarregadoId = P006A5_A7EncarregadoId[0];
               n7EncarregadoId = P006A5_n7EncarregadoId[0];
               A110DocumentoControladorId = P006A5_A110DocumentoControladorId[0];
               n110DocumentoControladorId = P006A5_n110DocumentoControladorId[0];
               A24AreaResponsavelId = P006A5_A24AreaResponsavelId[0];
               n24AreaResponsavelId = P006A5_n24AreaResponsavelId[0];
               A20SubprocessoId = P006A5_A20SubprocessoId[0];
               n20SubprocessoId = P006A5_n20SubprocessoId[0];
               A106DocumentoProcessoId = P006A5_A106DocumentoProcessoId[0];
               n106DocumentoProcessoId = P006A5_n106DocumentoProcessoId[0];
               A76DocumentoNome = P006A5_A76DocumentoNome[0];
               n76DocumentoNome = P006A5_n76DocumentoNome[0];
               A75DocumentoId = P006A5_A75DocumentoId[0];
               A85DocumentoAtivo = P006A5_A85DocumentoAtivo[0];
               n85DocumentoAtivo = P006A5_n85DocumentoAtivo[0];
               if ( AV9FiltrosDocumento.gxTpr_Situacao == 0 )
               {
                  AV8Documentos.Add(A75DocumentoId, 0);
               }
               else if ( ( AV9FiltrosDocumento.gxTpr_Situacao == 1 ) && ! A85DocumentoAtivo )
               {
                  AV8Documentos.Add(A75DocumentoId, 0);
               }
               else if ( ( AV9FiltrosDocumento.gxTpr_Situacao == 2 ) && ( A85DocumentoAtivo ) )
               {
                  AV8Documentos.Add(A75DocumentoId, 0);
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
         }
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
         AV8Documentos = new GxSimpleCollection<int>();
         scmdbuf = "";
         P006A2_A81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         P006A2_n81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         P006A2_A82DocumentoDadosGrupoVul = new bool[] {false} ;
         P006A2_n82DocumentoDadosGrupoVul = new bool[] {false} ;
         P006A2_A80DocumentoBaseLegalNormIntExt = new string[] {""} ;
         P006A2_n80DocumentoBaseLegalNormIntExt = new bool[] {false} ;
         P006A2_A79DocumentoBaseLegalNorm = new string[] {""} ;
         P006A2_n79DocumentoBaseLegalNorm = new bool[] {false} ;
         P006A2_A78DocumentoPrevColetaDados = new bool[] {false} ;
         P006A2_n78DocumentoPrevColetaDados = new bool[] {false} ;
         P006A2_A48TempoRetencaoId = new int[1] ;
         P006A2_n48TempoRetencaoId = new bool[] {false} ;
         P006A2_A45TipoDescarteId = new int[1] ;
         P006A2_n45TipoDescarteId = new bool[] {false} ;
         P006A2_A39FrequenciaTratamentoId = new int[1] ;
         P006A2_n39FrequenciaTratamentoId = new bool[] {false} ;
         P006A2_A36AbrangenciaGeograficaId = new int[1] ;
         P006A2_n36AbrangenciaGeograficaId = new bool[] {false} ;
         P006A2_A33FerramentaColetaId = new int[1] ;
         P006A2_n33FerramentaColetaId = new bool[] {false} ;
         P006A2_A30TipoDadoId = new int[1] ;
         P006A2_n30TipoDadoId = new bool[] {false} ;
         P006A2_A27CategoriaId = new int[1] ;
         P006A2_n27CategoriaId = new bool[] {false} ;
         P006A2_A77DocumentoFinalidadeTratamento = new string[] {""} ;
         P006A2_n77DocumentoFinalidadeTratamento = new bool[] {false} ;
         P006A2_A13PersonaId = new int[1] ;
         P006A2_n13PersonaId = new bool[] {false} ;
         P006A2_A7EncarregadoId = new int[1] ;
         P006A2_n7EncarregadoId = new bool[] {false} ;
         P006A2_A110DocumentoControladorId = new int[1] ;
         P006A2_n110DocumentoControladorId = new bool[] {false} ;
         P006A2_A24AreaResponsavelId = new int[1] ;
         P006A2_n24AreaResponsavelId = new bool[] {false} ;
         P006A2_A20SubprocessoId = new int[1] ;
         P006A2_n20SubprocessoId = new bool[] {false} ;
         P006A2_A106DocumentoProcessoId = new int[1] ;
         P006A2_n106DocumentoProcessoId = new bool[] {false} ;
         P006A2_A76DocumentoNome = new string[] {""} ;
         P006A2_n76DocumentoNome = new bool[] {false} ;
         P006A2_A75DocumentoId = new int[1] ;
         P006A2_A85DocumentoAtivo = new bool[] {false} ;
         P006A2_n85DocumentoAtivo = new bool[] {false} ;
         A80DocumentoBaseLegalNormIntExt = "";
         A79DocumentoBaseLegalNorm = "";
         A77DocumentoFinalidadeTratamento = "";
         A76DocumentoNome = "";
         AV12DocumentosFiltrados = new GxSimpleCollection<int>();
         P006A3_A102DocDicionarioFinalidade = new string[] {""} ;
         P006A3_A119DocDicionarioTipoTransfInterGa = new string[] {""} ;
         P006A3_A100DocDicionarioPodeEliminar = new bool[] {false} ;
         P006A3_A99DocDicionarioSensivel = new bool[] {false} ;
         P006A3_A101DocDicionarioTransfInter = new bool[] {false} ;
         P006A3_A72HipoteseTratamentoId = new int[1] ;
         P006A3_A69InformacaoId = new int[1] ;
         P006A3_A75DocumentoId = new int[1] ;
         P006A3_A98DocDicionarioId = new int[1] ;
         A102DocDicionarioFinalidade = "";
         A119DocDicionarioTipoTransfInterGa = "";
         AV13DocumentosDicionario = new GxSimpleCollection<int>();
         P006A4_A91DocOperadorProcessamento = new bool[] {false} ;
         P006A4_A90DocOperadorEliminacao = new bool[] {false} ;
         P006A4_A89DocOperadorCompartilhamento = new bool[] {false} ;
         P006A4_A88DocOperadorRetencao = new bool[] {false} ;
         P006A4_A87DocOperadorColeta = new bool[] {false} ;
         P006A4_A42OperadorId = new int[1] ;
         P006A4_A105DocumentoOperador = new bool[] {false} ;
         P006A4_n105DocumentoOperador = new bool[] {false} ;
         P006A4_A75DocumentoId = new int[1] ;
         P006A4_A86DocOperadorId = new int[1] ;
         AV14DocumentosOperador = new GxSimpleCollection<int>();
         P006A5_A13PersonaId = new int[1] ;
         P006A5_n13PersonaId = new bool[] {false} ;
         P006A5_A7EncarregadoId = new int[1] ;
         P006A5_n7EncarregadoId = new bool[] {false} ;
         P006A5_A110DocumentoControladorId = new int[1] ;
         P006A5_n110DocumentoControladorId = new bool[] {false} ;
         P006A5_A24AreaResponsavelId = new int[1] ;
         P006A5_n24AreaResponsavelId = new bool[] {false} ;
         P006A5_A20SubprocessoId = new int[1] ;
         P006A5_n20SubprocessoId = new bool[] {false} ;
         P006A5_A106DocumentoProcessoId = new int[1] ;
         P006A5_n106DocumentoProcessoId = new bool[] {false} ;
         P006A5_A76DocumentoNome = new string[] {""} ;
         P006A5_n76DocumentoNome = new bool[] {false} ;
         P006A5_A75DocumentoId = new int[1] ;
         P006A5_A85DocumentoAtivo = new bool[] {false} ;
         P006A5_n85DocumentoAtivo = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.filtrarconsultadoc__default(),
            new Object[][] {
                new Object[] {
               P006A2_A81DocumentoDadosCriancaAdolesc, P006A2_n81DocumentoDadosCriancaAdolesc, P006A2_A82DocumentoDadosGrupoVul, P006A2_n82DocumentoDadosGrupoVul, P006A2_A80DocumentoBaseLegalNormIntExt, P006A2_n80DocumentoBaseLegalNormIntExt, P006A2_A79DocumentoBaseLegalNorm, P006A2_n79DocumentoBaseLegalNorm, P006A2_A78DocumentoPrevColetaDados, P006A2_n78DocumentoPrevColetaDados,
               P006A2_A48TempoRetencaoId, P006A2_n48TempoRetencaoId, P006A2_A45TipoDescarteId, P006A2_n45TipoDescarteId, P006A2_A39FrequenciaTratamentoId, P006A2_n39FrequenciaTratamentoId, P006A2_A36AbrangenciaGeograficaId, P006A2_n36AbrangenciaGeograficaId, P006A2_A33FerramentaColetaId, P006A2_n33FerramentaColetaId,
               P006A2_A30TipoDadoId, P006A2_n30TipoDadoId, P006A2_A27CategoriaId, P006A2_n27CategoriaId, P006A2_A77DocumentoFinalidadeTratamento, P006A2_n77DocumentoFinalidadeTratamento, P006A2_A13PersonaId, P006A2_n13PersonaId, P006A2_A7EncarregadoId, P006A2_n7EncarregadoId,
               P006A2_A110DocumentoControladorId, P006A2_n110DocumentoControladorId, P006A2_A24AreaResponsavelId, P006A2_n24AreaResponsavelId, P006A2_A20SubprocessoId, P006A2_n20SubprocessoId, P006A2_A106DocumentoProcessoId, P006A2_n106DocumentoProcessoId, P006A2_A76DocumentoNome, P006A2_n76DocumentoNome,
               P006A2_A75DocumentoId, P006A2_A85DocumentoAtivo, P006A2_n85DocumentoAtivo
               }
               , new Object[] {
               P006A3_A102DocDicionarioFinalidade, P006A3_A119DocDicionarioTipoTransfInterGa, P006A3_A100DocDicionarioPodeEliminar, P006A3_A99DocDicionarioSensivel, P006A3_A101DocDicionarioTransfInter, P006A3_A72HipoteseTratamentoId, P006A3_A69InformacaoId, P006A3_A75DocumentoId, P006A3_A98DocDicionarioId
               }
               , new Object[] {
               P006A4_A91DocOperadorProcessamento, P006A4_A90DocOperadorEliminacao, P006A4_A89DocOperadorCompartilhamento, P006A4_A88DocOperadorRetencao, P006A4_A87DocOperadorColeta, P006A4_A42OperadorId, P006A4_A105DocumentoOperador, P006A4_n105DocumentoOperador, P006A4_A75DocumentoId, P006A4_A86DocOperadorId
               }
               , new Object[] {
               P006A5_A13PersonaId, P006A5_n13PersonaId, P006A5_A7EncarregadoId, P006A5_n7EncarregadoId, P006A5_A110DocumentoControladorId, P006A5_n110DocumentoControladorId, P006A5_A24AreaResponsavelId, P006A5_n24AreaResponsavelId, P006A5_A20SubprocessoId, P006A5_n20SubprocessoId,
               P006A5_A106DocumentoProcessoId, P006A5_n106DocumentoProcessoId, P006A5_A76DocumentoNome, P006A5_n76DocumentoNome, P006A5_A75DocumentoId, P006A5_A85DocumentoAtivo, P006A5_n85DocumentoAtivo
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV9FiltrosDocumento_gxTpr_Processo ;
      private int AV9FiltrosDocumento_gxTpr_Subprocesso ;
      private int AV9FiltrosDocumento_gxTpr_Arearesponsavel ;
      private int AV9FiltrosDocumento_gxTpr_Controlador ;
      private int AV9FiltrosDocumento_gxTpr_Encarregado ;
      private int AV9FiltrosDocumento_gxTpr_Persona ;
      private int AV9FiltrosDocumento_gxTpr_Categoria ;
      private int AV9FiltrosDocumento_gxTpr_Tipodado ;
      private int AV9FiltrosDocumento_gxTpr_Ferramentacoleta ;
      private int AV9FiltrosDocumento_gxTpr_Abrangenciageografica ;
      private int AV9FiltrosDocumento_gxTpr_Frequenciatratamento ;
      private int AV9FiltrosDocumento_gxTpr_Tipodescarte ;
      private int AV9FiltrosDocumento_gxTpr_Temporetencao ;
      private int A106DocumentoProcessoId ;
      private int A20SubprocessoId ;
      private int A24AreaResponsavelId ;
      private int A110DocumentoControladorId ;
      private int A7EncarregadoId ;
      private int A13PersonaId ;
      private int A27CategoriaId ;
      private int A30TipoDadoId ;
      private int A33FerramentaColetaId ;
      private int A36AbrangenciaGeograficaId ;
      private int A39FrequenciaTratamentoId ;
      private int A45TipoDescarteId ;
      private int A48TempoRetencaoId ;
      private int A75DocumentoId ;
      private int AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Informacao ;
      private int AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Hipotesetratamento ;
      private int AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Pais ;
      private int A69InformacaoId ;
      private int A72HipoteseTratamentoId ;
      private int A98DocDicionarioId ;
      private int AV9FiltrosDocumento_gxTpr_Docoperador_gxTpr_Operadorcadastrado ;
      private int A42OperadorId ;
      private int A86DocOperadorId ;
      private int AV21GXV1 ;
      private int AV15DocumentoId_Aux ;
      private int AV22GXV2 ;
      private int AV23GXV3 ;
      private string scmdbuf ;
      private bool AV10IsBuscaAvancada ;
      private bool AV9FiltrosDocumento_gxTpr_Prevcoletadados ;
      private bool AV9FiltrosDocumento_gxTpr_Dadosgrupovulneravel ;
      private bool AV9FiltrosDocumento_gxTpr_Dadoscriancaadolescente ;
      private bool A78DocumentoPrevColetaDados ;
      private bool A82DocumentoDadosGrupoVul ;
      private bool A81DocumentoDadosCriancaAdolesc ;
      private bool n81DocumentoDadosCriancaAdolesc ;
      private bool n82DocumentoDadosGrupoVul ;
      private bool n80DocumentoBaseLegalNormIntExt ;
      private bool n79DocumentoBaseLegalNorm ;
      private bool n78DocumentoPrevColetaDados ;
      private bool n48TempoRetencaoId ;
      private bool n45TipoDescarteId ;
      private bool n39FrequenciaTratamentoId ;
      private bool n36AbrangenciaGeograficaId ;
      private bool n33FerramentaColetaId ;
      private bool n30TipoDadoId ;
      private bool n27CategoriaId ;
      private bool n77DocumentoFinalidadeTratamento ;
      private bool n13PersonaId ;
      private bool n7EncarregadoId ;
      private bool n110DocumentoControladorId ;
      private bool n24AreaResponsavelId ;
      private bool n20SubprocessoId ;
      private bool n106DocumentoProcessoId ;
      private bool n76DocumentoNome ;
      private bool A85DocumentoAtivo ;
      private bool n85DocumentoAtivo ;
      private bool AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Transfint ;
      private bool AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Dadosensivel ;
      private bool AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Eliminardado ;
      private bool A101DocDicionarioTransfInter ;
      private bool A99DocDicionarioSensivel ;
      private bool A100DocDicionarioPodeEliminar ;
      private bool AV9FiltrosDocumento_gxTpr_Docoperador_gxTpr_Operador ;
      private bool AV9FiltrosDocumento_gxTpr_Docoperador_gxTpr_Operadorcoleta ;
      private bool AV9FiltrosDocumento_gxTpr_Docoperador_gxTpr_Operadorretencao ;
      private bool AV9FiltrosDocumento_gxTpr_Docoperador_gxTpr_Operadorcompartilhamento ;
      private bool AV9FiltrosDocumento_gxTpr_Docoperador_gxTpr_Operadoreliminacao ;
      private bool AV9FiltrosDocumento_gxTpr_Docoperador_gxTpr_Operadorprocessamento ;
      private bool A105DocumentoOperador ;
      private bool A87DocOperadorColeta ;
      private bool A88DocOperadorRetencao ;
      private bool A89DocOperadorCompartilhamento ;
      private bool A90DocOperadorEliminacao ;
      private bool A91DocOperadorProcessamento ;
      private bool n105DocumentoOperador ;
      private string AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Tipotransfint ;
      private string AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Finalidadedicio ;
      private string A102DocDicionarioFinalidade ;
      private string A119DocDicionarioTipoTransfInterGa ;
      private string AV9FiltrosDocumento_gxTpr_Nome ;
      private string AV9FiltrosDocumento_gxTpr_Finalidadetratamento ;
      private string AV9FiltrosDocumento_gxTpr_Baselegal ;
      private string AV9FiltrosDocumento_gxTpr_Baselegalextint ;
      private string A80DocumentoBaseLegalNormIntExt ;
      private string A79DocumentoBaseLegalNorm ;
      private string A77DocumentoFinalidadeTratamento ;
      private string A76DocumentoNome ;
      private GxSimpleCollection<int> AV8Documentos ;
      private GxSimpleCollection<int> AV12DocumentosFiltrados ;
      private GxSimpleCollection<int> AV13DocumentosDicionario ;
      private GxSimpleCollection<int> AV14DocumentosOperador ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] P006A2_A81DocumentoDadosCriancaAdolesc ;
      private bool[] P006A2_n81DocumentoDadosCriancaAdolesc ;
      private bool[] P006A2_A82DocumentoDadosGrupoVul ;
      private bool[] P006A2_n82DocumentoDadosGrupoVul ;
      private string[] P006A2_A80DocumentoBaseLegalNormIntExt ;
      private bool[] P006A2_n80DocumentoBaseLegalNormIntExt ;
      private string[] P006A2_A79DocumentoBaseLegalNorm ;
      private bool[] P006A2_n79DocumentoBaseLegalNorm ;
      private bool[] P006A2_A78DocumentoPrevColetaDados ;
      private bool[] P006A2_n78DocumentoPrevColetaDados ;
      private int[] P006A2_A48TempoRetencaoId ;
      private bool[] P006A2_n48TempoRetencaoId ;
      private int[] P006A2_A45TipoDescarteId ;
      private bool[] P006A2_n45TipoDescarteId ;
      private int[] P006A2_A39FrequenciaTratamentoId ;
      private bool[] P006A2_n39FrequenciaTratamentoId ;
      private int[] P006A2_A36AbrangenciaGeograficaId ;
      private bool[] P006A2_n36AbrangenciaGeograficaId ;
      private int[] P006A2_A33FerramentaColetaId ;
      private bool[] P006A2_n33FerramentaColetaId ;
      private int[] P006A2_A30TipoDadoId ;
      private bool[] P006A2_n30TipoDadoId ;
      private int[] P006A2_A27CategoriaId ;
      private bool[] P006A2_n27CategoriaId ;
      private string[] P006A2_A77DocumentoFinalidadeTratamento ;
      private bool[] P006A2_n77DocumentoFinalidadeTratamento ;
      private int[] P006A2_A13PersonaId ;
      private bool[] P006A2_n13PersonaId ;
      private int[] P006A2_A7EncarregadoId ;
      private bool[] P006A2_n7EncarregadoId ;
      private int[] P006A2_A110DocumentoControladorId ;
      private bool[] P006A2_n110DocumentoControladorId ;
      private int[] P006A2_A24AreaResponsavelId ;
      private bool[] P006A2_n24AreaResponsavelId ;
      private int[] P006A2_A20SubprocessoId ;
      private bool[] P006A2_n20SubprocessoId ;
      private int[] P006A2_A106DocumentoProcessoId ;
      private bool[] P006A2_n106DocumentoProcessoId ;
      private string[] P006A2_A76DocumentoNome ;
      private bool[] P006A2_n76DocumentoNome ;
      private int[] P006A2_A75DocumentoId ;
      private bool[] P006A2_A85DocumentoAtivo ;
      private bool[] P006A2_n85DocumentoAtivo ;
      private string[] P006A3_A102DocDicionarioFinalidade ;
      private string[] P006A3_A119DocDicionarioTipoTransfInterGa ;
      private bool[] P006A3_A100DocDicionarioPodeEliminar ;
      private bool[] P006A3_A99DocDicionarioSensivel ;
      private bool[] P006A3_A101DocDicionarioTransfInter ;
      private int[] P006A3_A72HipoteseTratamentoId ;
      private int[] P006A3_A69InformacaoId ;
      private int[] P006A3_A75DocumentoId ;
      private int[] P006A3_A98DocDicionarioId ;
      private bool[] P006A4_A91DocOperadorProcessamento ;
      private bool[] P006A4_A90DocOperadorEliminacao ;
      private bool[] P006A4_A89DocOperadorCompartilhamento ;
      private bool[] P006A4_A88DocOperadorRetencao ;
      private bool[] P006A4_A87DocOperadorColeta ;
      private int[] P006A4_A42OperadorId ;
      private bool[] P006A4_A105DocumentoOperador ;
      private bool[] P006A4_n105DocumentoOperador ;
      private int[] P006A4_A75DocumentoId ;
      private int[] P006A4_A86DocOperadorId ;
      private int[] P006A5_A13PersonaId ;
      private bool[] P006A5_n13PersonaId ;
      private int[] P006A5_A7EncarregadoId ;
      private bool[] P006A5_n7EncarregadoId ;
      private int[] P006A5_A110DocumentoControladorId ;
      private bool[] P006A5_n110DocumentoControladorId ;
      private int[] P006A5_A24AreaResponsavelId ;
      private bool[] P006A5_n24AreaResponsavelId ;
      private int[] P006A5_A20SubprocessoId ;
      private bool[] P006A5_n20SubprocessoId ;
      private int[] P006A5_A106DocumentoProcessoId ;
      private bool[] P006A5_n106DocumentoProcessoId ;
      private string[] P006A5_A76DocumentoNome ;
      private bool[] P006A5_n76DocumentoNome ;
      private int[] P006A5_A75DocumentoId ;
      private bool[] P006A5_A85DocumentoAtivo ;
      private bool[] P006A5_n85DocumentoAtivo ;
      private GxSimpleCollection<int> aP2_Documentos ;
      private SdtFiltrosDocumento AV9FiltrosDocumento ;
   }

   public class filtrarconsultadoc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006A2( IGxContext context ,
                                             string AV9FiltrosDocumento_gxTpr_Nome ,
                                             int AV9FiltrosDocumento_gxTpr_Processo ,
                                             int AV9FiltrosDocumento_gxTpr_Subprocesso ,
                                             int AV9FiltrosDocumento_gxTpr_Arearesponsavel ,
                                             int AV9FiltrosDocumento_gxTpr_Controlador ,
                                             int AV9FiltrosDocumento_gxTpr_Encarregado ,
                                             int AV9FiltrosDocumento_gxTpr_Persona ,
                                             string AV9FiltrosDocumento_gxTpr_Finalidadetratamento ,
                                             int AV9FiltrosDocumento_gxTpr_Categoria ,
                                             int AV9FiltrosDocumento_gxTpr_Tipodado ,
                                             int AV9FiltrosDocumento_gxTpr_Ferramentacoleta ,
                                             int AV9FiltrosDocumento_gxTpr_Abrangenciageografica ,
                                             int AV9FiltrosDocumento_gxTpr_Frequenciatratamento ,
                                             int AV9FiltrosDocumento_gxTpr_Tipodescarte ,
                                             int AV9FiltrosDocumento_gxTpr_Temporetencao ,
                                             bool AV9FiltrosDocumento_gxTpr_Prevcoletadados ,
                                             string AV9FiltrosDocumento_gxTpr_Baselegal ,
                                             string AV9FiltrosDocumento_gxTpr_Baselegalextint ,
                                             bool AV9FiltrosDocumento_gxTpr_Dadosgrupovulneravel ,
                                             bool AV9FiltrosDocumento_gxTpr_Dadoscriancaadolescente ,
                                             int A106DocumentoProcessoId ,
                                             int A20SubprocessoId ,
                                             int A24AreaResponsavelId ,
                                             int A110DocumentoControladorId ,
                                             int A7EncarregadoId ,
                                             int A13PersonaId ,
                                             int A27CategoriaId ,
                                             int A30TipoDadoId ,
                                             int A33FerramentaColetaId ,
                                             int A36AbrangenciaGeograficaId ,
                                             int A39FrequenciaTratamentoId ,
                                             int A45TipoDescarteId ,
                                             int A48TempoRetencaoId ,
                                             bool A78DocumentoPrevColetaDados ,
                                             bool A82DocumentoDadosGrupoVul ,
                                             bool A81DocumentoDadosCriancaAdolesc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[20];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [DocumentoDadosCriancaAdolesc], [DocumentoDadosGrupoVul], [DocumentoBaseLegalNormIntExt], [DocumentoBaseLegalNorm], [DocumentoPrevColetaDados], [TempoRetencaoId], [TipoDescarteId], [FrequenciaTratamentoId], [AbrangenciaGeograficaId], [FerramentaColetaId], [TipoDadoId], [CategoriaId], [DocumentoFinalidadeTratamento], [PersonaId], [EncarregadoId], [DocumentoControladorId], [AreaResponsavelId], [SubprocessoId], [DocumentoProcessoId], [DocumentoNome], [DocumentoId], [DocumentoAtivo] FROM [Documento]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9FiltrosDocumento_gxTpr_Nome)) )
         {
            AddWhere(sWhereString, "((CHARINDEX(RTRIM(@AV9FiltrosDocumento__Nome), [DocumentoNome])) >= 1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV9FiltrosDocumento_gxTpr_Processo) )
         {
            AddWhere(sWhereString, "([DocumentoProcessoId] = @AV9FiltrosDocumento__Processo)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV9FiltrosDocumento_gxTpr_Subprocesso) )
         {
            AddWhere(sWhereString, "([SubprocessoId] = @AV9Filtr_1Subprocesso)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV9FiltrosDocumento_gxTpr_Arearesponsavel) )
         {
            AddWhere(sWhereString, "([AreaResponsavelId] = @AV9Filtr_2Arearesponsavel)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV9FiltrosDocumento_gxTpr_Controlador) )
         {
            AddWhere(sWhereString, "([DocumentoControladorId] = @AV9Filtr_3Controlador)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV9FiltrosDocumento_gxTpr_Encarregado) )
         {
            AddWhere(sWhereString, "([EncarregadoId] = @AV9Filtr_4Encarregado)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV9FiltrosDocumento_gxTpr_Persona) )
         {
            AddWhere(sWhereString, "([PersonaId] = @AV9FiltrosDocumento__Persona)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9FiltrosDocumento_gxTpr_Finalidadetratamento)) )
         {
            AddWhere(sWhereString, "((CHARINDEX(RTRIM(@AV9Filtr_5Finalidadetratament), [DocumentoFinalidadeTratamento])) >= 1)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (0==AV9FiltrosDocumento_gxTpr_Categoria) )
         {
            AddWhere(sWhereString, "([CategoriaId] = @AV9Filtr_6Categoria)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (0==AV9FiltrosDocumento_gxTpr_Tipodado) )
         {
            AddWhere(sWhereString, "([TipoDadoId] = @AV9FiltrosDocumento__Tipodado)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (0==AV9FiltrosDocumento_gxTpr_Ferramentacoleta) )
         {
            AddWhere(sWhereString, "([FerramentaColetaId] = @AV9Filtr_7Ferramentacoleta)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (0==AV9FiltrosDocumento_gxTpr_Abrangenciageografica) )
         {
            AddWhere(sWhereString, "([AbrangenciaGeograficaId] = @AV9Filtr_8Abrangenciageografi)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV9FiltrosDocumento_gxTpr_Frequenciatratamento) )
         {
            AddWhere(sWhereString, "([FrequenciaTratamentoId] = @AV9Filtr_9Frequenciatratament)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (0==AV9FiltrosDocumento_gxTpr_Tipodescarte) )
         {
            AddWhere(sWhereString, "([TipoDescarteId] = @AV9Filtr_10Tipodescarte)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! (0==AV9FiltrosDocumento_gxTpr_Temporetencao) )
         {
            AddWhere(sWhereString, "([TempoRetencaoId] = @AV9Filtr_11Temporetencao)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! (false==AV9FiltrosDocumento_gxTpr_Prevcoletadados) )
         {
            AddWhere(sWhereString, "([DocumentoPrevColetaDados] = @AV9Filtr_12Prevcoletadados)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9FiltrosDocumento_gxTpr_Baselegal)) )
         {
            AddWhere(sWhereString, "((CHARINDEX(RTRIM(@AV9Filtr_13Baselegal), [DocumentoBaseLegalNorm])) >= 1)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9FiltrosDocumento_gxTpr_Baselegalextint)) )
         {
            AddWhere(sWhereString, "((CHARINDEX(RTRIM(@AV9Filtr_14Baselegalextint), [DocumentoBaseLegalNormIntExt])) >= 1)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! (false==AV9FiltrosDocumento_gxTpr_Dadosgrupovulneravel) )
         {
            AddWhere(sWhereString, "([DocumentoDadosGrupoVul] = @AV9Filtr_15Dadosgrupovulnerav)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! (false==AV9FiltrosDocumento_gxTpr_Dadoscriancaadolescente) )
         {
            AddWhere(sWhereString, "([DocumentoDadosCriancaAdolesc] = @AV9Filtr_16Dadoscriancaadoles)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [DocumentoId]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006A3( IGxContext context ,
                                             int AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Informacao ,
                                             int AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Hipotesetratamento ,
                                             bool AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Transfint ,
                                             int AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Pais ,
                                             bool AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Dadosensivel ,
                                             bool AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Eliminardado ,
                                             string AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Tipotransfint ,
                                             string AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Finalidadedicio ,
                                             int A69InformacaoId ,
                                             int A72HipoteseTratamentoId ,
                                             bool A101DocDicionarioTransfInter ,
                                             bool A99DocDicionarioSensivel ,
                                             bool A100DocDicionarioPodeEliminar )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [DocDicionarioFinalidade], [DocDicionarioTipoTransfInterGa], [DocDicionarioPodeEliminar], [DocDicionarioSensivel], [DocDicionarioTransfInter], [HipoteseTratamentoId], [InformacaoId], [DocumentoId], [DocDicionarioId] FROM [DocDicionario]";
         if ( ! (0==AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Informacao) )
         {
            AddWhere(sWhereString, "([InformacaoId] = @AV9Filtr_17Docdicionario_17In)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (0==AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Hipotesetratamento) )
         {
            AddWhere(sWhereString, "([HipoteseTratamentoId] = @AV9Filtr_18Docdicionario_18Hi)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (false==AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Transfint) )
         {
            AddWhere(sWhereString, "([DocDicionarioTransfInter] = @AV9Filtr_19Docdicionario_19Tr)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (false==AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Dadosensivel) )
         {
            AddWhere(sWhereString, "([DocDicionarioSensivel] = @AV9Filtr_20Docdicionario_20Da)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (false==AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Eliminardado) )
         {
            AddWhere(sWhereString, "([DocDicionarioPodeEliminar] = @AV9Filtr_21Docdicionario_21El)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Tipotransfint)) )
         {
            AddWhere(sWhereString, "((CHARINDEX(RTRIM(@AV9Filtr_22Docdicionario_22Ti), [DocDicionarioTipoTransfInterGa])) >= 1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9FiltrosDocumento_gxTpr_Docdicionario_gxTpr_Finalidadedicio)) )
         {
            AddWhere(sWhereString, "((CHARINDEX(RTRIM(@AV9Filtr_23Docdicionario_23Fi), [DocDicionarioFinalidade])) >= 1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [DocDicionarioId]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P006A4( IGxContext context ,
                                             bool AV9FiltrosDocumento_gxTpr_Docoperador_gxTpr_Operador ,
                                             int AV9FiltrosDocumento_gxTpr_Docoperador_gxTpr_Operadorcadastrado ,
                                             bool AV9FiltrosDocumento_gxTpr_Docoperador_gxTpr_Operadorcoleta ,
                                             bool AV9FiltrosDocumento_gxTpr_Docoperador_gxTpr_Operadorretencao ,
                                             bool AV9FiltrosDocumento_gxTpr_Docoperador_gxTpr_Operadorcompartilhamento ,
                                             bool AV9FiltrosDocumento_gxTpr_Docoperador_gxTpr_Operadoreliminacao ,
                                             bool AV9FiltrosDocumento_gxTpr_Docoperador_gxTpr_Operadorprocessamento ,
                                             bool A105DocumentoOperador ,
                                             int A42OperadorId ,
                                             bool A87DocOperadorColeta ,
                                             bool A88DocOperadorRetencao ,
                                             bool A89DocOperadorCompartilhamento ,
                                             bool A90DocOperadorEliminacao ,
                                             bool A91DocOperadorProcessamento )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[7];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[DocOperadorProcessamento], T1.[DocOperadorEliminacao], T1.[DocOperadorCompartilhamento], T1.[DocOperadorRetencao], T1.[DocOperadorColeta], T1.[OperadorId], T2.[DocumentoOperador], T1.[DocumentoId], T1.[DocOperadorId] FROM ([DocOperador] T1 INNER JOIN [Documento] T2 ON T2.[DocumentoId] = T1.[DocumentoId])";
         if ( ! (false==AV9FiltrosDocumento_gxTpr_Docoperador_gxTpr_Operador) )
         {
            AddWhere(sWhereString, "(T2.[DocumentoOperador] = @AV9Filtr_24Docoperador_24Oper)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! (0==AV9FiltrosDocumento_gxTpr_Docoperador_gxTpr_Operadorcadastrado) )
         {
            AddWhere(sWhereString, "(T1.[OperadorId] = @AV9Filtr_25Docoperador_25Oper)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (false==AV9FiltrosDocumento_gxTpr_Docoperador_gxTpr_Operadorcoleta) )
         {
            AddWhere(sWhereString, "(T1.[DocOperadorColeta] = @AV9Filtr_26Docoperador_26Oper)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (false==AV9FiltrosDocumento_gxTpr_Docoperador_gxTpr_Operadorretencao) )
         {
            AddWhere(sWhereString, "(T1.[DocOperadorRetencao] = @AV9Filtr_27Docoperador_27Oper)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (false==AV9FiltrosDocumento_gxTpr_Docoperador_gxTpr_Operadorcompartilhamento) )
         {
            AddWhere(sWhereString, "(T1.[DocOperadorCompartilhamento] = @AV9Filtr_28Docoperador_28Oper)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! (false==AV9FiltrosDocumento_gxTpr_Docoperador_gxTpr_Operadoreliminacao) )
         {
            AddWhere(sWhereString, "(T1.[DocOperadorEliminacao] = @AV9Filtr_29Docoperador_29Oper)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (false==AV9FiltrosDocumento_gxTpr_Docoperador_gxTpr_Operadorprocessamento) )
         {
            AddWhere(sWhereString, "(T1.[DocOperadorProcessamento] = @AV9Filtr_30Docoperador_30Oper)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[DocOperadorId]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P006A5( IGxContext context ,
                                             string AV9FiltrosDocumento_gxTpr_Nome ,
                                             int AV9FiltrosDocumento_gxTpr_Processo ,
                                             int AV9FiltrosDocumento_gxTpr_Subprocesso ,
                                             int AV9FiltrosDocumento_gxTpr_Arearesponsavel ,
                                             int AV9FiltrosDocumento_gxTpr_Controlador ,
                                             int AV9FiltrosDocumento_gxTpr_Encarregado ,
                                             int AV9FiltrosDocumento_gxTpr_Persona ,
                                             int A106DocumentoProcessoId ,
                                             int A20SubprocessoId ,
                                             int A24AreaResponsavelId ,
                                             int A110DocumentoControladorId ,
                                             int A7EncarregadoId ,
                                             int A13PersonaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[7];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT [PersonaId], [EncarregadoId], [DocumentoControladorId], [AreaResponsavelId], [SubprocessoId], [DocumentoProcessoId], [DocumentoNome], [DocumentoId], [DocumentoAtivo] FROM [Documento]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9FiltrosDocumento_gxTpr_Nome)) )
         {
            AddWhere(sWhereString, "((CHARINDEX(RTRIM(@AV9FiltrosDocumento__Nome), [DocumentoNome])) >= 1)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! (0==AV9FiltrosDocumento_gxTpr_Processo) )
         {
            AddWhere(sWhereString, "([DocumentoProcessoId] = @AV9FiltrosDocumento__Processo)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! (0==AV9FiltrosDocumento_gxTpr_Subprocesso) )
         {
            AddWhere(sWhereString, "([SubprocessoId] = @AV9Filtr_1Subprocesso)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! (0==AV9FiltrosDocumento_gxTpr_Arearesponsavel) )
         {
            AddWhere(sWhereString, "([AreaResponsavelId] = @AV9Filtr_2Arearesponsavel)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! (0==AV9FiltrosDocumento_gxTpr_Controlador) )
         {
            AddWhere(sWhereString, "([DocumentoControladorId] = @AV9Filtr_3Controlador)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! (0==AV9FiltrosDocumento_gxTpr_Encarregado) )
         {
            AddWhere(sWhereString, "([EncarregadoId] = @AV9Filtr_4Encarregado)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! (0==AV9FiltrosDocumento_gxTpr_Persona) )
         {
            AddWhere(sWhereString, "([PersonaId] = @AV9FiltrosDocumento__Persona)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [DocumentoId]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P006A2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (bool)dynConstraints[18] , (bool)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] , (int)dynConstraints[22] , (int)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] , (int)dynConstraints[29] , (int)dynConstraints[30] , (int)dynConstraints[31] , (int)dynConstraints[32] , (bool)dynConstraints[33] , (bool)dynConstraints[34] , (bool)dynConstraints[35] );
               case 1 :
                     return conditional_P006A3(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (bool)dynConstraints[2] , (int)dynConstraints[3] , (bool)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (bool)dynConstraints[10] , (bool)dynConstraints[12] , (bool)dynConstraints[13] );
               case 2 :
                     return conditional_P006A4(context, (bool)dynConstraints[0] , (int)dynConstraints[1] , (bool)dynConstraints[2] , (bool)dynConstraints[3] , (bool)dynConstraints[4] , (bool)dynConstraints[5] , (bool)dynConstraints[6] , (bool)dynConstraints[7] , (int)dynConstraints[8] , (bool)dynConstraints[9] , (bool)dynConstraints[10] , (bool)dynConstraints[11] , (bool)dynConstraints[12] , (bool)dynConstraints[13] );
               case 3 :
                     return conditional_P006A5(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006A2;
          prmP006A2 = new Object[] {
          new ParDef("@AV9FiltrosDocumento__Nome",GXType.VarChar,100,0) ,
          new ParDef("@AV9FiltrosDocumento__Processo",GXType.Int32,8,0) ,
          new ParDef("@AV9Filtr_1Subprocesso",GXType.Int32,8,0) ,
          new ParDef("@AV9Filtr_2Arearesponsavel",GXType.Int32,8,0) ,
          new ParDef("@AV9Filtr_3Controlador",GXType.Int32,8,0) ,
          new ParDef("@AV9Filtr_4Encarregado",GXType.Int32,8,0) ,
          new ParDef("@AV9FiltrosDocumento__Persona",GXType.Int32,8,0) ,
          new ParDef("@AV9Filtr_5Finalidadetratament",GXType.VarChar,100,0) ,
          new ParDef("@AV9Filtr_6Categoria",GXType.Int32,8,0) ,
          new ParDef("@AV9FiltrosDocumento__Tipodado",GXType.Int32,8,0) ,
          new ParDef("@AV9Filtr_7Ferramentacoleta",GXType.Int32,8,0) ,
          new ParDef("@AV9Filtr_8Abrangenciageografi",GXType.Int32,8,0) ,
          new ParDef("@AV9Filtr_9Frequenciatratament",GXType.Int32,8,0) ,
          new ParDef("@AV9Filtr_10Tipodescarte",GXType.Int32,8,0) ,
          new ParDef("@AV9Filtr_11Temporetencao",GXType.Int32,8,0) ,
          new ParDef("@AV9Filtr_12Prevcoletadados",GXType.Boolean,4,0) ,
          new ParDef("@AV9Filtr_13Baselegal",GXType.VarChar,100,0) ,
          new ParDef("@AV9Filtr_14Baselegalextint",GXType.VarChar,100,0) ,
          new ParDef("@AV9Filtr_15Dadosgrupovulnerav",GXType.Boolean,4,0) ,
          new ParDef("@AV9Filtr_16Dadoscriancaadoles",GXType.Boolean,4,0)
          };
          Object[] prmP006A3;
          prmP006A3 = new Object[] {
          new ParDef("@AV9Filtr_17Docdicionario_17In",GXType.Int32,8,0) ,
          new ParDef("@AV9Filtr_18Docdicionario_18Hi",GXType.Int32,8,0) ,
          new ParDef("@AV9Filtr_19Docdicionario_19Tr",GXType.Boolean,4,0) ,
          new ParDef("@AV9Filtr_20Docdicionario_20Da",GXType.Boolean,4,0) ,
          new ParDef("@AV9Filtr_21Docdicionario_21El",GXType.Boolean,4,0) ,
          new ParDef("@AV9Filtr_22Docdicionario_22Ti",GXType.VarChar,10000,0) ,
          new ParDef("@AV9Filtr_23Docdicionario_23Fi",GXType.VarChar,10000,0)
          };
          Object[] prmP006A4;
          prmP006A4 = new Object[] {
          new ParDef("@AV9Filtr_24Docoperador_24Oper",GXType.Boolean,4,0) ,
          new ParDef("@AV9Filtr_25Docoperador_25Oper",GXType.Int32,8,0) ,
          new ParDef("@AV9Filtr_26Docoperador_26Oper",GXType.Boolean,4,0) ,
          new ParDef("@AV9Filtr_27Docoperador_27Oper",GXType.Boolean,4,0) ,
          new ParDef("@AV9Filtr_28Docoperador_28Oper",GXType.Boolean,4,0) ,
          new ParDef("@AV9Filtr_29Docoperador_29Oper",GXType.Boolean,4,0) ,
          new ParDef("@AV9Filtr_30Docoperador_30Oper",GXType.Boolean,4,0)
          };
          Object[] prmP006A5;
          prmP006A5 = new Object[] {
          new ParDef("@AV9FiltrosDocumento__Nome",GXType.VarChar,100,0) ,
          new ParDef("@AV9FiltrosDocumento__Processo",GXType.Int32,8,0) ,
          new ParDef("@AV9Filtr_1Subprocesso",GXType.Int32,8,0) ,
          new ParDef("@AV9Filtr_2Arearesponsavel",GXType.Int32,8,0) ,
          new ParDef("@AV9Filtr_3Controlador",GXType.Int32,8,0) ,
          new ParDef("@AV9Filtr_4Encarregado",GXType.Int32,8,0) ,
          new ParDef("@AV9FiltrosDocumento__Persona",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006A2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006A3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006A3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006A4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006A4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006A5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006A5,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((bool[]) buf[8])[0] = rslt.getBool(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((int[]) buf[20])[0] = rslt.getInt(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((int[]) buf[26])[0] = rslt.getInt(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((int[]) buf[28])[0] = rslt.getInt(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((int[]) buf[30])[0] = rslt.getInt(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((int[]) buf[32])[0] = rslt.getInt(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((int[]) buf[34])[0] = rslt.getInt(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((int[]) buf[36])[0] = rslt.getInt(19);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((string[]) buf[38])[0] = rslt.getVarchar(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((int[]) buf[40])[0] = rslt.getInt(21);
                ((bool[]) buf[41])[0] = rslt.getBool(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 2 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((bool[]) buf[6])[0] = rslt.getBool(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                return;
             case 3 :
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
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
       }
    }

 }

}
