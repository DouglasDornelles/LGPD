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
         domain["ABRANG�NCIA GEOGR�FICA"] = "ABRANG�NCIA GEOGR�FICA";
         domain["FREQU�NCIA DE TRATAMENTO DE DADOS"] = "FREQU�NCIA DE TRATAMENTO DOS DADOS";
         domain["FONTE DE RETEN��O/ARMAZENAMENTO"] = "FONTE DE RETEN��O/ARMAZENAMENTO";
         domain["TIPO DE DESCARTE"] = "TIPO DE DESCARTE";
         domain["TEMPO DE GUARDA/RETEN��O"] = "TEMPO DE GUARDA/RETEN��O";
         domain["PREVIS�O PARA COLETA DE DADOS"] = "PREVIS�O PARA COLETA DE DADOS";
         domain["BASE LEGAL - NORMATIVO"] = "BASE LEGAL - NORMATIVO";
         domain["BASE LEGAL - NORMATIVO (INTERO E EXTERNO)"] = "BASE LEGAL - NORMATIVO (INTERNO E EXTERNO)";
         domain["DADOS DE GRUPOS VULNER�VEIS"] = "DADOS DE GRUPOS VULNER�VEIS";
         domain["DADOS DE CRIAN�A/ADOLESCENTE"] = "DADOS DE CRIAN�A/ADOLESCENTE";
         domain["SETORES INTERNOS ENVOLVIDOS"] = "SETORES INTERNOS ENVOLVIDOS";
         domain["FORMA DE COMPARTILHAMENTO INTERNO"] = "FORMA DE COMPARTILHAMENTO INTERNO";
         domain["ENVOLVIDOS NA COLETA"] = "ENVOLVIDOS NA COLETA";
         domain["MEDIDA DE SEGURAN�A"] = "MEDIDA DE SEGURAN�A";
         domain["DESCRI��O DA MEDIDA DE SEGURAN�A"] = "DESCRI��O DA MEDIDA DE SEGURAN�A";
         domain["DESCRI��O DO FLUXO DE TRATAMENTO DE DADOS"] = "DESCRI��O DO FLUXO DE TRATAMENTO DE DADOS";
         domain["INFORMA��O"] = "INFORMA��O";
         domain["PODE ELIMINAR"] = "PODE ELIMINAR";
         domain["POSSUI DADOS SENS�VEIS"] = "POSSUI DADOS SENS�VEIS";
         domain["HIP�TESE DE TRATAMENTO"] = "HIP�TESE DE TRATAMENTO";
         domain["TRANSFER�NCIA INTERNACIONAL"] = "TRANSFER�NCIA INTERNACIONAL";
         domain["PA�S"] = "PA�S";
         domain["TIPO DE GARANTIA PARA TRANSFER�NCIA INTERNACIONAL"] = "TIPO DE GARANTIA PARA TRANSFER�NCIA INTERNACIONAL";
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
            domainMap["AbrangenciaGeografica"] = "ABRANG�NCIA GEOGR�FICA";
            domainMap["FrequenciaTratamento"] = "FREQU�NCIA DE TRATAMENTO DE DADOS";
            domainMap["FonteRetencao"] = "FONTE DE RETEN��O/ARMAZENAMENTO";
            domainMap["TipoDescarte"] = "TIPO DE DESCARTE";
            domainMap["TempoRetencao"] = "TEMPO DE GUARDA/RETEN��O";
            domainMap["PrevisaoColetaDados"] = "PREVIS�O PARA COLETA DE DADOS";
            domainMap["BaseLegalNormativo"] = "BASE LEGAL - NORMATIVO";
            domainMap["BaseLegalNormativoIntExt"] = "BASE LEGAL - NORMATIVO (INTERO E EXTERNO)";
            domainMap["DadosVulneraveis"] = "DADOS DE GRUPOS VULNER�VEIS";
            domainMap["DadosCriancaAdolescente"] = "DADOS DE CRIAN�A/ADOLESCENTE";
            domainMap["SetorInterno"] = "SETORES INTERNOS ENVOLVIDOS";
            domainMap["CompartilhamentoInterno"] = "FORMA DE COMPARTILHAMENTO INTERNO";
            domainMap["EnvolvidosColeta"] = "ENVOLVIDOS NA COLETA";
            domainMap["MedidaSeguranca"] = "MEDIDA DE SEGURAN�A";
            domainMap["MedidaSegurancaDesc"] = "DESCRI��O DA MEDIDA DE SEGURAN�A";
            domainMap["FluxoTratamentoDados"] = "DESCRI��O DO FLUXO DE TRATAMENTO DE DADOS";
            domainMap["Informacao"] = "INFORMA��O";
            domainMap["PodeEliminar"] = "PODE ELIMINAR";
            domainMap["DadosSensiveis"] = "POSSUI DADOS SENS�VEIS";
            domainMap["HipoteseTratamento"] = "HIP�TESE DE TRATAMENTO";
            domainMap["TransferenciaInternacional"] = "TRANSFER�NCIA INTERNACIONAL";
            domainMap["Pais"] = "PA�S";
            domainMap["GarantiaTransferenciaInternacional"] = "TIPO DE GARANTIA PARA TRANSFER�NCIA INTERNACIONAL";
            domainMap["CompartilhamentoTerceirosExternos"] = "COMPARTILHAMENTO TERCEIROS/EXTERNOS";
            domainMap["Finalidade"] = "FINALIDADE";
            domainMap["Operador"] = "OPERADOR";
            domainMap["OperadorNome"] = "NOME DO OPERADOR";
         }
         return (string)domainMap[key] ;
      }

   }

}
