using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gxdomaincampo
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaincampo ()
      {
         domain["PROCESSO"] = "PROCESSO";
         domain["SUB-PROCESSO"] = "SUB-PROCESSO";
         domain["CONTROLADOR"] = "CONTROLADOR";
         domain["PERSONA"] = "PERSONA";
         domain["ENCARREGADO"] = "ENCARREGADO";
         domain["FINALIDADE DO TRATAMENTO DE DADOS"] = "FINALIDADE DO TRATAMENTO DE DADOS";
         domain["CATEGORIA"] = "CATEGORIA";
         domain["TIPO DO DADO"] = "TIPO DO DADO";
         domain["FERRAMENTA DE COLETA DE DADOS"] = "FERRAMENTA DE COLETA DE DADOS";
         domain["ABRANGÊNCIA GEOGRÁFICA"] = "ABRANGÊNCIA GEOGRÁFICA";
         domain["FREQUÊNCIA DE TRATAMENTO DE DADOS"] = "FREQUÊNCIA DE TRATAMENTO DOS DADOS";
         domain["FONTE DE RETENÇÃO/ARMAZENAMENTO"] = "FONTE DE RETENÇÃO/ARMAZENAMENTO";
         domain["TIPO DE DESCARTE"] = "TIPO DE DESCARTE";
         domain["TEMPO DE GUARDA/RETENÇÃO"] = "TEMPO DE GUARDA/RETENÇÃO";
         domain["PREVISÃO PARA COLETA DE DADOS"] = "PREVISÃO PARA COLETA DE DADOS";
         domain["BASE LEGAL - NORMATIVO"] = "BASE LEGAL - NORMATIVO";
         domain["BASE LEGAL - NORMATIVO (INTERO E EXTERNO)"] = "BASE LEGAL - NORMATIVO (INTERNO E EXTERNO)";
         domain["DADOS DE GRUPOS VULNERÁVEIS"] = "DADOS DE GRUPOS VULNERÁVEIS";
         domain["DADOS DE CRIANÇA/ADOLESCENTE"] = "DADOS DE CRIANÇA/ADOLESCENTE";
         domain["SETORES INTERNOS ENVOLVIDOS"] = "SETORES INTERNOS ENVOLVIDOS";
         domain["FORMA DE COMPARTILHAMENTO INTERNO"] = "FORMA DE COMPARTILHAMENTO INTERNO";
         domain["ENVOLVIDOS NA COLETA"] = "ENVOLVIDOS NA COLETA";
         domain["MEDIDA DE SEGURANÇA"] = "MEDIDA DE SEGURANÇA";
         domain["DESCRIÇÃO DA MEDIDA DE SEGURANÇA"] = "DESCRIÇÃO DA MEDIDA DE SEGURANÇA";
         domain["DESCRIÇÃO DO FLUXO DE TRATAMENTO DE DADOS"] = "DESCRIÇÃO DO FLUXO DE TRATAMENTO DE DADOS";
         domain["INFORMAÇÃO"] = "INFORMAÇÃO";
         domain["PODE ELIMINAR"] = "PODE ELIMINAR";
         domain["POSSUI DADOS SENSÍVEIS"] = "POSSUI DADOS SENSÍVEIS";
         domain["HIPÓTESE DE TRATAMENTO"] = "HIPÓTESE DE TRATAMENTO";
         domain["TRANSFERÊNCIA INTERNACIONAL"] = "TRANSFERÊNCIA INTERNACIONAL";
         domain["PAÍS"] = "PAÍS";
         domain["TIPO DE GARANTIA PARA TRANSFERÊNCIA INTERNACIONAL"] = "TIPO DE GARANTIA PARA TRANSFERÊNCIA INTERNACIONAL";
         domain["COMPARTILHAMENTO TERCEIROS/EXTERNOS"] = "COMPARTILHAMENTO TERCEIROS/EXTERNOS";
         domain["FINALIDADE"] = "FINALIDADE";
         domain["OPERADOR"] = "OPERADOR";
         domain["NOME DO OPERADOR"] = "NOME DO OPERADOR";
      }

      public static string getDescription( IGxContext context ,
                                           string key )
      {
         string rtkey;
         string value;
         rtkey = ((key==null) ? "" : StringUtil.Trim( (string)(key)));
         value = (string)(domain[rtkey]==null?"":domain[rtkey]);
         return value ;
      }

      public static GxSimpleCollection<string> getValues( )
      {
         GxSimpleCollection<string> value = new GxSimpleCollection<string>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (string key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public static string getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["Processo"] = "PROCESSO";
            domainMap["SubProcesso"] = "SUB-PROCESSO";
            domainMap["Controlador"] = "CONTROLADOR";
            domainMap["Persona"] = "PERSONA";
            domainMap["Encarregado"] = "ENCARREGADO";
            domainMap["FinalidadeTratamento"] = "FINALIDADE DO TRATAMENTO DE DADOS";
            domainMap["Categoria"] = "CATEGORIA";
            domainMap["TipoDado"] = "TIPO DO DADO";
            domainMap["FerramentaColeta"] = "FERRAMENTA DE COLETA DE DADOS";
            domainMap["AbrangenciaGeografica"] = "ABRANGÊNCIA GEOGRÁFICA";
            domainMap["FrequenciaTratamento"] = "FREQUÊNCIA DE TRATAMENTO DE DADOS";
            domainMap["FonteRetencao"] = "FONTE DE RETENÇÃO/ARMAZENAMENTO";
            domainMap["TipoDescarte"] = "TIPO DE DESCARTE";
            domainMap["TempoRetencao"] = "TEMPO DE GUARDA/RETENÇÃO";
            domainMap["PrevisaoColetaDados"] = "PREVISÃO PARA COLETA DE DADOS";
            domainMap["BaseLegalNormativo"] = "BASE LEGAL - NORMATIVO";
            domainMap["BaseLegalNormativoIntExt"] = "BASE LEGAL - NORMATIVO (INTERO E EXTERNO)";
            domainMap["DadosVulneraveis"] = "DADOS DE GRUPOS VULNERÁVEIS";
            domainMap["DadosCriancaAdolescente"] = "DADOS DE CRIANÇA/ADOLESCENTE";
            domainMap["SetorInterno"] = "SETORES INTERNOS ENVOLVIDOS";
            domainMap["CompartilhamentoInterno"] = "FORMA DE COMPARTILHAMENTO INTERNO";
            domainMap["EnvolvidosColeta"] = "ENVOLVIDOS NA COLETA";
            domainMap["MedidaSeguranca"] = "MEDIDA DE SEGURANÇA";
            domainMap["MedidaSegurancaDesc"] = "DESCRIÇÃO DA MEDIDA DE SEGURANÇA";
            domainMap["FluxoTratamentoDados"] = "DESCRIÇÃO DO FLUXO DE TRATAMENTO DE DADOS";
            domainMap["Informacao"] = "INFORMAÇÃO";
            domainMap["PodeEliminar"] = "PODE ELIMINAR";
            domainMap["DadosSensiveis"] = "POSSUI DADOS SENSÍVEIS";
            domainMap["HipoteseTratamento"] = "HIPÓTESE DE TRATAMENTO";
            domainMap["TransferenciaInternacional"] = "TRANSFERÊNCIA INTERNACIONAL";
            domainMap["Pais"] = "PAÍS";
            domainMap["GarantiaTransferenciaInternacional"] = "TIPO DE GARANTIA PARA TRANSFERÊNCIA INTERNACIONAL";
            domainMap["CompartilhamentoTerceirosExternos"] = "COMPARTILHAMENTO TERCEIROS/EXTERNOS";
            domainMap["Finalidade"] = "FINALIDADE";
            domainMap["Operador"] = "OPERADOR";
            domainMap["OperadorNome"] = "NOME DO OPERADOR";
         }
         return (string)domainMap[key] ;
      }

   }

}
