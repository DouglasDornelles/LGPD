using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "Documento" )]
   [XmlType(TypeName =  "Documento" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtDocumento : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocumento( )
      {
      }

      public SdtDocumento( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetCallingAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( int AV75DocumentoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV75DocumentoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"DocumentoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Documento");
         metadata.Set("BT", "Documento");
         metadata.Set("PK", "[ \"DocumentoId\" ]");
         metadata.Set("PKAssigned", "[ \"DocumentoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"AbrangenciaGeograficaId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"AreaResponsavelId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"CategoriaId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ControladorId\" ],\"FKMap\":[ \"DocumentoControladorId-ControladorId\" ] },{ \"FK\":[ \"EncarregadoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"FerramentaColetaId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"FrequenciaTratamentoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"PersonaId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ProcessoId\" ],\"FKMap\":[ \"DocumentoProcessoId-ProcessoId\" ] },{ \"FK\":[ \"SubprocessoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"TempoRetencaoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"TipoDadoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"TipoDescarteId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Documentoid_Z");
         state.Add("gxTpr_Documentonome_Z");
         state.Add("gxTpr_Subprocessoid_Z");
         state.Add("gxTpr_Encarregadoid_Z");
         state.Add("gxTpr_Personaid_Z");
         state.Add("gxTpr_Documentofinalidadetratamento_Z");
         state.Add("gxTpr_Categoriaid_Z");
         state.Add("gxTpr_Tipodadoid_Z");
         state.Add("gxTpr_Ferramentacoletaid_Z");
         state.Add("gxTpr_Abrangenciageograficaid_Z");
         state.Add("gxTpr_Frequenciatratamentoid_Z");
         state.Add("gxTpr_Tipodescarteid_Z");
         state.Add("gxTpr_Temporetencaoid_Z");
         state.Add("gxTpr_Documentoprevcoletadados_Z");
         state.Add("gxTpr_Documentobaselegalnorm_Z");
         state.Add("gxTpr_Documentobaselegalnormintext_Z");
         state.Add("gxTpr_Documentodadoscriancaadolesc_Z");
         state.Add("gxTpr_Documentodadosgrupovul_Z");
         state.Add("gxTpr_Documentoativo_Z");
         state.Add("gxTpr_Documentooperador_Z");
         state.Add("gxTpr_Documentoprocessoid_Z");
         state.Add("gxTpr_Documentoprocessonome_Z");
         state.Add("gxTpr_Documentodatainclusao_Z_Nullable");
         state.Add("gxTpr_Documentodataalteracao_Z_Nullable");
         state.Add("gxTpr_Documentocontroladorid_Z");
         state.Add("gxTpr_Arearesponsavelid_Z");
         state.Add("gxTpr_Documentousuarioinclusao_Z");
         state.Add("gxTpr_Documentousuarioalteracao_Z");
         state.Add("gxTpr_Documentoisoperador_Z");
         state.Add("gxTpr_Documentonome_N");
         state.Add("gxTpr_Subprocessoid_N");
         state.Add("gxTpr_Encarregadoid_N");
         state.Add("gxTpr_Personaid_N");
         state.Add("gxTpr_Documentofinalidadetratamento_N");
         state.Add("gxTpr_Categoriaid_N");
         state.Add("gxTpr_Tipodadoid_N");
         state.Add("gxTpr_Ferramentacoletaid_N");
         state.Add("gxTpr_Abrangenciageograficaid_N");
         state.Add("gxTpr_Frequenciatratamentoid_N");
         state.Add("gxTpr_Tipodescarteid_N");
         state.Add("gxTpr_Temporetencaoid_N");
         state.Add("gxTpr_Documentoprevcoletadados_N");
         state.Add("gxTpr_Documentobaselegalnorm_N");
         state.Add("gxTpr_Documentobaselegalnormintext_N");
         state.Add("gxTpr_Documentodadoscriancaadolesc_N");
         state.Add("gxTpr_Documentodadosgrupovul_N");
         state.Add("gxTpr_Documentomedidasegurancadesc_N");
         state.Add("gxTpr_Documentofluxotratdadosdesc_N");
         state.Add("gxTpr_Documentoativo_N");
         state.Add("gxTpr_Documentooperador_N");
         state.Add("gxTpr_Documentoprocessoid_N");
         state.Add("gxTpr_Documentodatainclusao_N");
         state.Add("gxTpr_Documentodataalteracao_N");
         state.Add("gxTpr_Documentocontroladorid_N");
         state.Add("gxTpr_Arearesponsavelid_N");
         state.Add("gxTpr_Documentousuarioinclusao_N");
         state.Add("gxTpr_Documentousuarioalteracao_N");
         state.Add("gxTpr_Documentoisoperador_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtDocumento sdt;
         sdt = (SdtDocumento)(source);
         gxTv_SdtDocumento_Documentoid = sdt.gxTv_SdtDocumento_Documentoid ;
         gxTv_SdtDocumento_Documentonome = sdt.gxTv_SdtDocumento_Documentonome ;
         gxTv_SdtDocumento_Subprocessoid = sdt.gxTv_SdtDocumento_Subprocessoid ;
         gxTv_SdtDocumento_Encarregadoid = sdt.gxTv_SdtDocumento_Encarregadoid ;
         gxTv_SdtDocumento_Personaid = sdt.gxTv_SdtDocumento_Personaid ;
         gxTv_SdtDocumento_Documentofinalidadetratamento = sdt.gxTv_SdtDocumento_Documentofinalidadetratamento ;
         gxTv_SdtDocumento_Categoriaid = sdt.gxTv_SdtDocumento_Categoriaid ;
         gxTv_SdtDocumento_Tipodadoid = sdt.gxTv_SdtDocumento_Tipodadoid ;
         gxTv_SdtDocumento_Ferramentacoletaid = sdt.gxTv_SdtDocumento_Ferramentacoletaid ;
         gxTv_SdtDocumento_Abrangenciageograficaid = sdt.gxTv_SdtDocumento_Abrangenciageograficaid ;
         gxTv_SdtDocumento_Frequenciatratamentoid = sdt.gxTv_SdtDocumento_Frequenciatratamentoid ;
         gxTv_SdtDocumento_Tipodescarteid = sdt.gxTv_SdtDocumento_Tipodescarteid ;
         gxTv_SdtDocumento_Temporetencaoid = sdt.gxTv_SdtDocumento_Temporetencaoid ;
         gxTv_SdtDocumento_Documentoprevcoletadados = sdt.gxTv_SdtDocumento_Documentoprevcoletadados ;
         gxTv_SdtDocumento_Documentobaselegalnorm = sdt.gxTv_SdtDocumento_Documentobaselegalnorm ;
         gxTv_SdtDocumento_Documentobaselegalnormintext = sdt.gxTv_SdtDocumento_Documentobaselegalnormintext ;
         gxTv_SdtDocumento_Documentodadoscriancaadolesc = sdt.gxTv_SdtDocumento_Documentodadoscriancaadolesc ;
         gxTv_SdtDocumento_Documentodadosgrupovul = sdt.gxTv_SdtDocumento_Documentodadosgrupovul ;
         gxTv_SdtDocumento_Documentomedidasegurancadesc = sdt.gxTv_SdtDocumento_Documentomedidasegurancadesc ;
         gxTv_SdtDocumento_Documentofluxotratdadosdesc = sdt.gxTv_SdtDocumento_Documentofluxotratdadosdesc ;
         gxTv_SdtDocumento_Documentoativo = sdt.gxTv_SdtDocumento_Documentoativo ;
         gxTv_SdtDocumento_Documentooperador = sdt.gxTv_SdtDocumento_Documentooperador ;
         gxTv_SdtDocumento_Documentoprocessoid = sdt.gxTv_SdtDocumento_Documentoprocessoid ;
         gxTv_SdtDocumento_Documentoprocessonome = sdt.gxTv_SdtDocumento_Documentoprocessonome ;
         gxTv_SdtDocumento_Documentodatainclusao = sdt.gxTv_SdtDocumento_Documentodatainclusao ;
         gxTv_SdtDocumento_Documentodataalteracao = sdt.gxTv_SdtDocumento_Documentodataalteracao ;
         gxTv_SdtDocumento_Documentocontroladorid = sdt.gxTv_SdtDocumento_Documentocontroladorid ;
         gxTv_SdtDocumento_Arearesponsavelid = sdt.gxTv_SdtDocumento_Arearesponsavelid ;
         gxTv_SdtDocumento_Documentousuarioinclusao = sdt.gxTv_SdtDocumento_Documentousuarioinclusao ;
         gxTv_SdtDocumento_Documentousuarioalteracao = sdt.gxTv_SdtDocumento_Documentousuarioalteracao ;
         gxTv_SdtDocumento_Documentoisoperador = sdt.gxTv_SdtDocumento_Documentoisoperador ;
         gxTv_SdtDocumento_Mode = sdt.gxTv_SdtDocumento_Mode ;
         gxTv_SdtDocumento_Initialized = sdt.gxTv_SdtDocumento_Initialized ;
         gxTv_SdtDocumento_Documentoid_Z = sdt.gxTv_SdtDocumento_Documentoid_Z ;
         gxTv_SdtDocumento_Documentonome_Z = sdt.gxTv_SdtDocumento_Documentonome_Z ;
         gxTv_SdtDocumento_Subprocessoid_Z = sdt.gxTv_SdtDocumento_Subprocessoid_Z ;
         gxTv_SdtDocumento_Encarregadoid_Z = sdt.gxTv_SdtDocumento_Encarregadoid_Z ;
         gxTv_SdtDocumento_Personaid_Z = sdt.gxTv_SdtDocumento_Personaid_Z ;
         gxTv_SdtDocumento_Documentofinalidadetratamento_Z = sdt.gxTv_SdtDocumento_Documentofinalidadetratamento_Z ;
         gxTv_SdtDocumento_Categoriaid_Z = sdt.gxTv_SdtDocumento_Categoriaid_Z ;
         gxTv_SdtDocumento_Tipodadoid_Z = sdt.gxTv_SdtDocumento_Tipodadoid_Z ;
         gxTv_SdtDocumento_Ferramentacoletaid_Z = sdt.gxTv_SdtDocumento_Ferramentacoletaid_Z ;
         gxTv_SdtDocumento_Abrangenciageograficaid_Z = sdt.gxTv_SdtDocumento_Abrangenciageograficaid_Z ;
         gxTv_SdtDocumento_Frequenciatratamentoid_Z = sdt.gxTv_SdtDocumento_Frequenciatratamentoid_Z ;
         gxTv_SdtDocumento_Tipodescarteid_Z = sdt.gxTv_SdtDocumento_Tipodescarteid_Z ;
         gxTv_SdtDocumento_Temporetencaoid_Z = sdt.gxTv_SdtDocumento_Temporetencaoid_Z ;
         gxTv_SdtDocumento_Documentoprevcoletadados_Z = sdt.gxTv_SdtDocumento_Documentoprevcoletadados_Z ;
         gxTv_SdtDocumento_Documentobaselegalnorm_Z = sdt.gxTv_SdtDocumento_Documentobaselegalnorm_Z ;
         gxTv_SdtDocumento_Documentobaselegalnormintext_Z = sdt.gxTv_SdtDocumento_Documentobaselegalnormintext_Z ;
         gxTv_SdtDocumento_Documentodadoscriancaadolesc_Z = sdt.gxTv_SdtDocumento_Documentodadoscriancaadolesc_Z ;
         gxTv_SdtDocumento_Documentodadosgrupovul_Z = sdt.gxTv_SdtDocumento_Documentodadosgrupovul_Z ;
         gxTv_SdtDocumento_Documentoativo_Z = sdt.gxTv_SdtDocumento_Documentoativo_Z ;
         gxTv_SdtDocumento_Documentooperador_Z = sdt.gxTv_SdtDocumento_Documentooperador_Z ;
         gxTv_SdtDocumento_Documentoprocessoid_Z = sdt.gxTv_SdtDocumento_Documentoprocessoid_Z ;
         gxTv_SdtDocumento_Documentoprocessonome_Z = sdt.gxTv_SdtDocumento_Documentoprocessonome_Z ;
         gxTv_SdtDocumento_Documentodatainclusao_Z = sdt.gxTv_SdtDocumento_Documentodatainclusao_Z ;
         gxTv_SdtDocumento_Documentodataalteracao_Z = sdt.gxTv_SdtDocumento_Documentodataalteracao_Z ;
         gxTv_SdtDocumento_Documentocontroladorid_Z = sdt.gxTv_SdtDocumento_Documentocontroladorid_Z ;
         gxTv_SdtDocumento_Arearesponsavelid_Z = sdt.gxTv_SdtDocumento_Arearesponsavelid_Z ;
         gxTv_SdtDocumento_Documentousuarioinclusao_Z = sdt.gxTv_SdtDocumento_Documentousuarioinclusao_Z ;
         gxTv_SdtDocumento_Documentousuarioalteracao_Z = sdt.gxTv_SdtDocumento_Documentousuarioalteracao_Z ;
         gxTv_SdtDocumento_Documentoisoperador_Z = sdt.gxTv_SdtDocumento_Documentoisoperador_Z ;
         gxTv_SdtDocumento_Documentonome_N = sdt.gxTv_SdtDocumento_Documentonome_N ;
         gxTv_SdtDocumento_Subprocessoid_N = sdt.gxTv_SdtDocumento_Subprocessoid_N ;
         gxTv_SdtDocumento_Encarregadoid_N = sdt.gxTv_SdtDocumento_Encarregadoid_N ;
         gxTv_SdtDocumento_Personaid_N = sdt.gxTv_SdtDocumento_Personaid_N ;
         gxTv_SdtDocumento_Documentofinalidadetratamento_N = sdt.gxTv_SdtDocumento_Documentofinalidadetratamento_N ;
         gxTv_SdtDocumento_Categoriaid_N = sdt.gxTv_SdtDocumento_Categoriaid_N ;
         gxTv_SdtDocumento_Tipodadoid_N = sdt.gxTv_SdtDocumento_Tipodadoid_N ;
         gxTv_SdtDocumento_Ferramentacoletaid_N = sdt.gxTv_SdtDocumento_Ferramentacoletaid_N ;
         gxTv_SdtDocumento_Abrangenciageograficaid_N = sdt.gxTv_SdtDocumento_Abrangenciageograficaid_N ;
         gxTv_SdtDocumento_Frequenciatratamentoid_N = sdt.gxTv_SdtDocumento_Frequenciatratamentoid_N ;
         gxTv_SdtDocumento_Tipodescarteid_N = sdt.gxTv_SdtDocumento_Tipodescarteid_N ;
         gxTv_SdtDocumento_Temporetencaoid_N = sdt.gxTv_SdtDocumento_Temporetencaoid_N ;
         gxTv_SdtDocumento_Documentoprevcoletadados_N = sdt.gxTv_SdtDocumento_Documentoprevcoletadados_N ;
         gxTv_SdtDocumento_Documentobaselegalnorm_N = sdt.gxTv_SdtDocumento_Documentobaselegalnorm_N ;
         gxTv_SdtDocumento_Documentobaselegalnormintext_N = sdt.gxTv_SdtDocumento_Documentobaselegalnormintext_N ;
         gxTv_SdtDocumento_Documentodadoscriancaadolesc_N = sdt.gxTv_SdtDocumento_Documentodadoscriancaadolesc_N ;
         gxTv_SdtDocumento_Documentodadosgrupovul_N = sdt.gxTv_SdtDocumento_Documentodadosgrupovul_N ;
         gxTv_SdtDocumento_Documentomedidasegurancadesc_N = sdt.gxTv_SdtDocumento_Documentomedidasegurancadesc_N ;
         gxTv_SdtDocumento_Documentofluxotratdadosdesc_N = sdt.gxTv_SdtDocumento_Documentofluxotratdadosdesc_N ;
         gxTv_SdtDocumento_Documentoativo_N = sdt.gxTv_SdtDocumento_Documentoativo_N ;
         gxTv_SdtDocumento_Documentooperador_N = sdt.gxTv_SdtDocumento_Documentooperador_N ;
         gxTv_SdtDocumento_Documentoprocessoid_N = sdt.gxTv_SdtDocumento_Documentoprocessoid_N ;
         gxTv_SdtDocumento_Documentodatainclusao_N = sdt.gxTv_SdtDocumento_Documentodatainclusao_N ;
         gxTv_SdtDocumento_Documentodataalteracao_N = sdt.gxTv_SdtDocumento_Documentodataalteracao_N ;
         gxTv_SdtDocumento_Documentocontroladorid_N = sdt.gxTv_SdtDocumento_Documentocontroladorid_N ;
         gxTv_SdtDocumento_Arearesponsavelid_N = sdt.gxTv_SdtDocumento_Arearesponsavelid_N ;
         gxTv_SdtDocumento_Documentousuarioinclusao_N = sdt.gxTv_SdtDocumento_Documentousuarioinclusao_N ;
         gxTv_SdtDocumento_Documentousuarioalteracao_N = sdt.gxTv_SdtDocumento_Documentousuarioalteracao_N ;
         gxTv_SdtDocumento_Documentoisoperador_N = sdt.gxTv_SdtDocumento_Documentoisoperador_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("DocumentoId", gxTv_SdtDocumento_Documentoid, false, includeNonInitialized);
         AddObjectProperty("DocumentoNome", gxTv_SdtDocumento_Documentonome, false, includeNonInitialized);
         AddObjectProperty("DocumentoNome_N", gxTv_SdtDocumento_Documentonome_N, false, includeNonInitialized);
         AddObjectProperty("SubprocessoId", gxTv_SdtDocumento_Subprocessoid, false, includeNonInitialized);
         AddObjectProperty("SubprocessoId_N", gxTv_SdtDocumento_Subprocessoid_N, false, includeNonInitialized);
         AddObjectProperty("EncarregadoId", gxTv_SdtDocumento_Encarregadoid, false, includeNonInitialized);
         AddObjectProperty("EncarregadoId_N", gxTv_SdtDocumento_Encarregadoid_N, false, includeNonInitialized);
         AddObjectProperty("PersonaId", gxTv_SdtDocumento_Personaid, false, includeNonInitialized);
         AddObjectProperty("PersonaId_N", gxTv_SdtDocumento_Personaid_N, false, includeNonInitialized);
         AddObjectProperty("DocumentoFinalidadeTratamento", gxTv_SdtDocumento_Documentofinalidadetratamento, false, includeNonInitialized);
         AddObjectProperty("DocumentoFinalidadeTratamento_N", gxTv_SdtDocumento_Documentofinalidadetratamento_N, false, includeNonInitialized);
         AddObjectProperty("CategoriaId", gxTv_SdtDocumento_Categoriaid, false, includeNonInitialized);
         AddObjectProperty("CategoriaId_N", gxTv_SdtDocumento_Categoriaid_N, false, includeNonInitialized);
         AddObjectProperty("TipoDadoId", gxTv_SdtDocumento_Tipodadoid, false, includeNonInitialized);
         AddObjectProperty("TipoDadoId_N", gxTv_SdtDocumento_Tipodadoid_N, false, includeNonInitialized);
         AddObjectProperty("FerramentaColetaId", gxTv_SdtDocumento_Ferramentacoletaid, false, includeNonInitialized);
         AddObjectProperty("FerramentaColetaId_N", gxTv_SdtDocumento_Ferramentacoletaid_N, false, includeNonInitialized);
         AddObjectProperty("AbrangenciaGeograficaId", gxTv_SdtDocumento_Abrangenciageograficaid, false, includeNonInitialized);
         AddObjectProperty("AbrangenciaGeograficaId_N", gxTv_SdtDocumento_Abrangenciageograficaid_N, false, includeNonInitialized);
         AddObjectProperty("FrequenciaTratamentoId", gxTv_SdtDocumento_Frequenciatratamentoid, false, includeNonInitialized);
         AddObjectProperty("FrequenciaTratamentoId_N", gxTv_SdtDocumento_Frequenciatratamentoid_N, false, includeNonInitialized);
         AddObjectProperty("TipoDescarteId", gxTv_SdtDocumento_Tipodescarteid, false, includeNonInitialized);
         AddObjectProperty("TipoDescarteId_N", gxTv_SdtDocumento_Tipodescarteid_N, false, includeNonInitialized);
         AddObjectProperty("TempoRetencaoId", gxTv_SdtDocumento_Temporetencaoid, false, includeNonInitialized);
         AddObjectProperty("TempoRetencaoId_N", gxTv_SdtDocumento_Temporetencaoid_N, false, includeNonInitialized);
         AddObjectProperty("DocumentoPrevColetaDados", gxTv_SdtDocumento_Documentoprevcoletadados, false, includeNonInitialized);
         AddObjectProperty("DocumentoPrevColetaDados_N", gxTv_SdtDocumento_Documentoprevcoletadados_N, false, includeNonInitialized);
         AddObjectProperty("DocumentoBaseLegalNorm", gxTv_SdtDocumento_Documentobaselegalnorm, false, includeNonInitialized);
         AddObjectProperty("DocumentoBaseLegalNorm_N", gxTv_SdtDocumento_Documentobaselegalnorm_N, false, includeNonInitialized);
         AddObjectProperty("DocumentoBaseLegalNormIntExt", gxTv_SdtDocumento_Documentobaselegalnormintext, false, includeNonInitialized);
         AddObjectProperty("DocumentoBaseLegalNormIntExt_N", gxTv_SdtDocumento_Documentobaselegalnormintext_N, false, includeNonInitialized);
         AddObjectProperty("DocumentoDadosCriancaAdolesc", gxTv_SdtDocumento_Documentodadoscriancaadolesc, false, includeNonInitialized);
         AddObjectProperty("DocumentoDadosCriancaAdolesc_N", gxTv_SdtDocumento_Documentodadoscriancaadolesc_N, false, includeNonInitialized);
         AddObjectProperty("DocumentoDadosGrupoVul", gxTv_SdtDocumento_Documentodadosgrupovul, false, includeNonInitialized);
         AddObjectProperty("DocumentoDadosGrupoVul_N", gxTv_SdtDocumento_Documentodadosgrupovul_N, false, includeNonInitialized);
         AddObjectProperty("DocumentoMedidaSegurancaDesc", gxTv_SdtDocumento_Documentomedidasegurancadesc, false, includeNonInitialized);
         AddObjectProperty("DocumentoMedidaSegurancaDesc_N", gxTv_SdtDocumento_Documentomedidasegurancadesc_N, false, includeNonInitialized);
         AddObjectProperty("DocumentoFluxoTratDadosDesc", gxTv_SdtDocumento_Documentofluxotratdadosdesc, false, includeNonInitialized);
         AddObjectProperty("DocumentoFluxoTratDadosDesc_N", gxTv_SdtDocumento_Documentofluxotratdadosdesc_N, false, includeNonInitialized);
         AddObjectProperty("DocumentoAtivo", gxTv_SdtDocumento_Documentoativo, false, includeNonInitialized);
         AddObjectProperty("DocumentoAtivo_N", gxTv_SdtDocumento_Documentoativo_N, false, includeNonInitialized);
         AddObjectProperty("DocumentoOperador", gxTv_SdtDocumento_Documentooperador, false, includeNonInitialized);
         AddObjectProperty("DocumentoOperador_N", gxTv_SdtDocumento_Documentooperador_N, false, includeNonInitialized);
         AddObjectProperty("DocumentoProcessoId", gxTv_SdtDocumento_Documentoprocessoid, false, includeNonInitialized);
         AddObjectProperty("DocumentoProcessoId_N", gxTv_SdtDocumento_Documentoprocessoid_N, false, includeNonInitialized);
         AddObjectProperty("DocumentoProcessoNome", gxTv_SdtDocumento_Documentoprocessonome, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtDocumento_Documentodatainclusao;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("DocumentoDataInclusao", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocumentoDataInclusao_N", gxTv_SdtDocumento_Documentodatainclusao_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtDocumento_Documentodataalteracao;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("DocumentoDataAlteracao", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocumentoDataAlteracao_N", gxTv_SdtDocumento_Documentodataalteracao_N, false, includeNonInitialized);
         AddObjectProperty("DocumentoControladorId", gxTv_SdtDocumento_Documentocontroladorid, false, includeNonInitialized);
         AddObjectProperty("DocumentoControladorId_N", gxTv_SdtDocumento_Documentocontroladorid_N, false, includeNonInitialized);
         AddObjectProperty("AreaResponsavelId", gxTv_SdtDocumento_Arearesponsavelid, false, includeNonInitialized);
         AddObjectProperty("AreaResponsavelId_N", gxTv_SdtDocumento_Arearesponsavelid_N, false, includeNonInitialized);
         AddObjectProperty("DocumentoUsuarioInclusao", gxTv_SdtDocumento_Documentousuarioinclusao, false, includeNonInitialized);
         AddObjectProperty("DocumentoUsuarioInclusao_N", gxTv_SdtDocumento_Documentousuarioinclusao_N, false, includeNonInitialized);
         AddObjectProperty("DocumentoUsuarioAlteracao", gxTv_SdtDocumento_Documentousuarioalteracao, false, includeNonInitialized);
         AddObjectProperty("DocumentoUsuarioAlteracao_N", gxTv_SdtDocumento_Documentousuarioalteracao_N, false, includeNonInitialized);
         AddObjectProperty("DocumentoIsOperador", gxTv_SdtDocumento_Documentoisoperador, false, includeNonInitialized);
         AddObjectProperty("DocumentoIsOperador_N", gxTv_SdtDocumento_Documentoisoperador_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtDocumento_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtDocumento_Initialized, false, includeNonInitialized);
            AddObjectProperty("DocumentoId_Z", gxTv_SdtDocumento_Documentoid_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoNome_Z", gxTv_SdtDocumento_Documentonome_Z, false, includeNonInitialized);
            AddObjectProperty("SubprocessoId_Z", gxTv_SdtDocumento_Subprocessoid_Z, false, includeNonInitialized);
            AddObjectProperty("EncarregadoId_Z", gxTv_SdtDocumento_Encarregadoid_Z, false, includeNonInitialized);
            AddObjectProperty("PersonaId_Z", gxTv_SdtDocumento_Personaid_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoFinalidadeTratamento_Z", gxTv_SdtDocumento_Documentofinalidadetratamento_Z, false, includeNonInitialized);
            AddObjectProperty("CategoriaId_Z", gxTv_SdtDocumento_Categoriaid_Z, false, includeNonInitialized);
            AddObjectProperty("TipoDadoId_Z", gxTv_SdtDocumento_Tipodadoid_Z, false, includeNonInitialized);
            AddObjectProperty("FerramentaColetaId_Z", gxTv_SdtDocumento_Ferramentacoletaid_Z, false, includeNonInitialized);
            AddObjectProperty("AbrangenciaGeograficaId_Z", gxTv_SdtDocumento_Abrangenciageograficaid_Z, false, includeNonInitialized);
            AddObjectProperty("FrequenciaTratamentoId_Z", gxTv_SdtDocumento_Frequenciatratamentoid_Z, false, includeNonInitialized);
            AddObjectProperty("TipoDescarteId_Z", gxTv_SdtDocumento_Tipodescarteid_Z, false, includeNonInitialized);
            AddObjectProperty("TempoRetencaoId_Z", gxTv_SdtDocumento_Temporetencaoid_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoPrevColetaDados_Z", gxTv_SdtDocumento_Documentoprevcoletadados_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoBaseLegalNorm_Z", gxTv_SdtDocumento_Documentobaselegalnorm_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoBaseLegalNormIntExt_Z", gxTv_SdtDocumento_Documentobaselegalnormintext_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoDadosCriancaAdolesc_Z", gxTv_SdtDocumento_Documentodadoscriancaadolesc_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoDadosGrupoVul_Z", gxTv_SdtDocumento_Documentodadosgrupovul_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoAtivo_Z", gxTv_SdtDocumento_Documentoativo_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoOperador_Z", gxTv_SdtDocumento_Documentooperador_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoProcessoId_Z", gxTv_SdtDocumento_Documentoprocessoid_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoProcessoNome_Z", gxTv_SdtDocumento_Documentoprocessonome_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtDocumento_Documentodatainclusao_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("DocumentoDataInclusao_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtDocumento_Documentodataalteracao_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("DocumentoDataAlteracao_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("DocumentoControladorId_Z", gxTv_SdtDocumento_Documentocontroladorid_Z, false, includeNonInitialized);
            AddObjectProperty("AreaResponsavelId_Z", gxTv_SdtDocumento_Arearesponsavelid_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoUsuarioInclusao_Z", gxTv_SdtDocumento_Documentousuarioinclusao_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoUsuarioAlteracao_Z", gxTv_SdtDocumento_Documentousuarioalteracao_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoIsOperador_Z", gxTv_SdtDocumento_Documentoisoperador_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoNome_N", gxTv_SdtDocumento_Documentonome_N, false, includeNonInitialized);
            AddObjectProperty("SubprocessoId_N", gxTv_SdtDocumento_Subprocessoid_N, false, includeNonInitialized);
            AddObjectProperty("EncarregadoId_N", gxTv_SdtDocumento_Encarregadoid_N, false, includeNonInitialized);
            AddObjectProperty("PersonaId_N", gxTv_SdtDocumento_Personaid_N, false, includeNonInitialized);
            AddObjectProperty("DocumentoFinalidadeTratamento_N", gxTv_SdtDocumento_Documentofinalidadetratamento_N, false, includeNonInitialized);
            AddObjectProperty("CategoriaId_N", gxTv_SdtDocumento_Categoriaid_N, false, includeNonInitialized);
            AddObjectProperty("TipoDadoId_N", gxTv_SdtDocumento_Tipodadoid_N, false, includeNonInitialized);
            AddObjectProperty("FerramentaColetaId_N", gxTv_SdtDocumento_Ferramentacoletaid_N, false, includeNonInitialized);
            AddObjectProperty("AbrangenciaGeograficaId_N", gxTv_SdtDocumento_Abrangenciageograficaid_N, false, includeNonInitialized);
            AddObjectProperty("FrequenciaTratamentoId_N", gxTv_SdtDocumento_Frequenciatratamentoid_N, false, includeNonInitialized);
            AddObjectProperty("TipoDescarteId_N", gxTv_SdtDocumento_Tipodescarteid_N, false, includeNonInitialized);
            AddObjectProperty("TempoRetencaoId_N", gxTv_SdtDocumento_Temporetencaoid_N, false, includeNonInitialized);
            AddObjectProperty("DocumentoPrevColetaDados_N", gxTv_SdtDocumento_Documentoprevcoletadados_N, false, includeNonInitialized);
            AddObjectProperty("DocumentoBaseLegalNorm_N", gxTv_SdtDocumento_Documentobaselegalnorm_N, false, includeNonInitialized);
            AddObjectProperty("DocumentoBaseLegalNormIntExt_N", gxTv_SdtDocumento_Documentobaselegalnormintext_N, false, includeNonInitialized);
            AddObjectProperty("DocumentoDadosCriancaAdolesc_N", gxTv_SdtDocumento_Documentodadoscriancaadolesc_N, false, includeNonInitialized);
            AddObjectProperty("DocumentoDadosGrupoVul_N", gxTv_SdtDocumento_Documentodadosgrupovul_N, false, includeNonInitialized);
            AddObjectProperty("DocumentoMedidaSegurancaDesc_N", gxTv_SdtDocumento_Documentomedidasegurancadesc_N, false, includeNonInitialized);
            AddObjectProperty("DocumentoFluxoTratDadosDesc_N", gxTv_SdtDocumento_Documentofluxotratdadosdesc_N, false, includeNonInitialized);
            AddObjectProperty("DocumentoAtivo_N", gxTv_SdtDocumento_Documentoativo_N, false, includeNonInitialized);
            AddObjectProperty("DocumentoOperador_N", gxTv_SdtDocumento_Documentooperador_N, false, includeNonInitialized);
            AddObjectProperty("DocumentoProcessoId_N", gxTv_SdtDocumento_Documentoprocessoid_N, false, includeNonInitialized);
            AddObjectProperty("DocumentoDataInclusao_N", gxTv_SdtDocumento_Documentodatainclusao_N, false, includeNonInitialized);
            AddObjectProperty("DocumentoDataAlteracao_N", gxTv_SdtDocumento_Documentodataalteracao_N, false, includeNonInitialized);
            AddObjectProperty("DocumentoControladorId_N", gxTv_SdtDocumento_Documentocontroladorid_N, false, includeNonInitialized);
            AddObjectProperty("AreaResponsavelId_N", gxTv_SdtDocumento_Arearesponsavelid_N, false, includeNonInitialized);
            AddObjectProperty("DocumentoUsuarioInclusao_N", gxTv_SdtDocumento_Documentousuarioinclusao_N, false, includeNonInitialized);
            AddObjectProperty("DocumentoUsuarioAlteracao_N", gxTv_SdtDocumento_Documentousuarioalteracao_N, false, includeNonInitialized);
            AddObjectProperty("DocumentoIsOperador_N", gxTv_SdtDocumento_Documentoisoperador_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtDocumento sdt )
      {
         if ( sdt.IsDirty("DocumentoId") )
         {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentoid = sdt.gxTv_SdtDocumento_Documentoid ;
         }
         if ( sdt.IsDirty("DocumentoNome") )
         {
            gxTv_SdtDocumento_Documentonome_N = (short)(sdt.gxTv_SdtDocumento_Documentonome_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentonome = sdt.gxTv_SdtDocumento_Documentonome ;
         }
         if ( sdt.IsDirty("SubprocessoId") )
         {
            gxTv_SdtDocumento_Subprocessoid_N = (short)(sdt.gxTv_SdtDocumento_Subprocessoid_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Subprocessoid = sdt.gxTv_SdtDocumento_Subprocessoid ;
         }
         if ( sdt.IsDirty("EncarregadoId") )
         {
            gxTv_SdtDocumento_Encarregadoid_N = (short)(sdt.gxTv_SdtDocumento_Encarregadoid_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Encarregadoid = sdt.gxTv_SdtDocumento_Encarregadoid ;
         }
         if ( sdt.IsDirty("PersonaId") )
         {
            gxTv_SdtDocumento_Personaid_N = (short)(sdt.gxTv_SdtDocumento_Personaid_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Personaid = sdt.gxTv_SdtDocumento_Personaid ;
         }
         if ( sdt.IsDirty("DocumentoFinalidadeTratamento") )
         {
            gxTv_SdtDocumento_Documentofinalidadetratamento_N = (short)(sdt.gxTv_SdtDocumento_Documentofinalidadetratamento_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentofinalidadetratamento = sdt.gxTv_SdtDocumento_Documentofinalidadetratamento ;
         }
         if ( sdt.IsDirty("CategoriaId") )
         {
            gxTv_SdtDocumento_Categoriaid_N = (short)(sdt.gxTv_SdtDocumento_Categoriaid_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Categoriaid = sdt.gxTv_SdtDocumento_Categoriaid ;
         }
         if ( sdt.IsDirty("TipoDadoId") )
         {
            gxTv_SdtDocumento_Tipodadoid_N = (short)(sdt.gxTv_SdtDocumento_Tipodadoid_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Tipodadoid = sdt.gxTv_SdtDocumento_Tipodadoid ;
         }
         if ( sdt.IsDirty("FerramentaColetaId") )
         {
            gxTv_SdtDocumento_Ferramentacoletaid_N = (short)(sdt.gxTv_SdtDocumento_Ferramentacoletaid_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Ferramentacoletaid = sdt.gxTv_SdtDocumento_Ferramentacoletaid ;
         }
         if ( sdt.IsDirty("AbrangenciaGeograficaId") )
         {
            gxTv_SdtDocumento_Abrangenciageograficaid_N = (short)(sdt.gxTv_SdtDocumento_Abrangenciageograficaid_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Abrangenciageograficaid = sdt.gxTv_SdtDocumento_Abrangenciageograficaid ;
         }
         if ( sdt.IsDirty("FrequenciaTratamentoId") )
         {
            gxTv_SdtDocumento_Frequenciatratamentoid_N = (short)(sdt.gxTv_SdtDocumento_Frequenciatratamentoid_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Frequenciatratamentoid = sdt.gxTv_SdtDocumento_Frequenciatratamentoid ;
         }
         if ( sdt.IsDirty("TipoDescarteId") )
         {
            gxTv_SdtDocumento_Tipodescarteid_N = (short)(sdt.gxTv_SdtDocumento_Tipodescarteid_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Tipodescarteid = sdt.gxTv_SdtDocumento_Tipodescarteid ;
         }
         if ( sdt.IsDirty("TempoRetencaoId") )
         {
            gxTv_SdtDocumento_Temporetencaoid_N = (short)(sdt.gxTv_SdtDocumento_Temporetencaoid_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Temporetencaoid = sdt.gxTv_SdtDocumento_Temporetencaoid ;
         }
         if ( sdt.IsDirty("DocumentoPrevColetaDados") )
         {
            gxTv_SdtDocumento_Documentoprevcoletadados_N = (short)(sdt.gxTv_SdtDocumento_Documentoprevcoletadados_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentoprevcoletadados = sdt.gxTv_SdtDocumento_Documentoprevcoletadados ;
         }
         if ( sdt.IsDirty("DocumentoBaseLegalNorm") )
         {
            gxTv_SdtDocumento_Documentobaselegalnorm_N = (short)(sdt.gxTv_SdtDocumento_Documentobaselegalnorm_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentobaselegalnorm = sdt.gxTv_SdtDocumento_Documentobaselegalnorm ;
         }
         if ( sdt.IsDirty("DocumentoBaseLegalNormIntExt") )
         {
            gxTv_SdtDocumento_Documentobaselegalnormintext_N = (short)(sdt.gxTv_SdtDocumento_Documentobaselegalnormintext_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentobaselegalnormintext = sdt.gxTv_SdtDocumento_Documentobaselegalnormintext ;
         }
         if ( sdt.IsDirty("DocumentoDadosCriancaAdolesc") )
         {
            gxTv_SdtDocumento_Documentodadoscriancaadolesc_N = (short)(sdt.gxTv_SdtDocumento_Documentodadoscriancaadolesc_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentodadoscriancaadolesc = sdt.gxTv_SdtDocumento_Documentodadoscriancaadolesc ;
         }
         if ( sdt.IsDirty("DocumentoDadosGrupoVul") )
         {
            gxTv_SdtDocumento_Documentodadosgrupovul_N = (short)(sdt.gxTv_SdtDocumento_Documentodadosgrupovul_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentodadosgrupovul = sdt.gxTv_SdtDocumento_Documentodadosgrupovul ;
         }
         if ( sdt.IsDirty("DocumentoMedidaSegurancaDesc") )
         {
            gxTv_SdtDocumento_Documentomedidasegurancadesc_N = (short)(sdt.gxTv_SdtDocumento_Documentomedidasegurancadesc_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentomedidasegurancadesc = sdt.gxTv_SdtDocumento_Documentomedidasegurancadesc ;
         }
         if ( sdt.IsDirty("DocumentoFluxoTratDadosDesc") )
         {
            gxTv_SdtDocumento_Documentofluxotratdadosdesc_N = (short)(sdt.gxTv_SdtDocumento_Documentofluxotratdadosdesc_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentofluxotratdadosdesc = sdt.gxTv_SdtDocumento_Documentofluxotratdadosdesc ;
         }
         if ( sdt.IsDirty("DocumentoAtivo") )
         {
            gxTv_SdtDocumento_Documentoativo_N = (short)(sdt.gxTv_SdtDocumento_Documentoativo_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentoativo = sdt.gxTv_SdtDocumento_Documentoativo ;
         }
         if ( sdt.IsDirty("DocumentoOperador") )
         {
            gxTv_SdtDocumento_Documentooperador_N = (short)(sdt.gxTv_SdtDocumento_Documentooperador_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentooperador = sdt.gxTv_SdtDocumento_Documentooperador ;
         }
         if ( sdt.IsDirty("DocumentoProcessoId") )
         {
            gxTv_SdtDocumento_Documentoprocessoid_N = (short)(sdt.gxTv_SdtDocumento_Documentoprocessoid_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentoprocessoid = sdt.gxTv_SdtDocumento_Documentoprocessoid ;
         }
         if ( sdt.IsDirty("DocumentoProcessoNome") )
         {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentoprocessonome = sdt.gxTv_SdtDocumento_Documentoprocessonome ;
         }
         if ( sdt.IsDirty("DocumentoDataInclusao") )
         {
            gxTv_SdtDocumento_Documentodatainclusao_N = (short)(sdt.gxTv_SdtDocumento_Documentodatainclusao_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentodatainclusao = sdt.gxTv_SdtDocumento_Documentodatainclusao ;
         }
         if ( sdt.IsDirty("DocumentoDataAlteracao") )
         {
            gxTv_SdtDocumento_Documentodataalteracao_N = (short)(sdt.gxTv_SdtDocumento_Documentodataalteracao_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentodataalteracao = sdt.gxTv_SdtDocumento_Documentodataalteracao ;
         }
         if ( sdt.IsDirty("DocumentoControladorId") )
         {
            gxTv_SdtDocumento_Documentocontroladorid_N = (short)(sdt.gxTv_SdtDocumento_Documentocontroladorid_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentocontroladorid = sdt.gxTv_SdtDocumento_Documentocontroladorid ;
         }
         if ( sdt.IsDirty("AreaResponsavelId") )
         {
            gxTv_SdtDocumento_Arearesponsavelid_N = (short)(sdt.gxTv_SdtDocumento_Arearesponsavelid_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Arearesponsavelid = sdt.gxTv_SdtDocumento_Arearesponsavelid ;
         }
         if ( sdt.IsDirty("DocumentoUsuarioInclusao") )
         {
            gxTv_SdtDocumento_Documentousuarioinclusao_N = (short)(sdt.gxTv_SdtDocumento_Documentousuarioinclusao_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentousuarioinclusao = sdt.gxTv_SdtDocumento_Documentousuarioinclusao ;
         }
         if ( sdt.IsDirty("DocumentoUsuarioAlteracao") )
         {
            gxTv_SdtDocumento_Documentousuarioalteracao_N = (short)(sdt.gxTv_SdtDocumento_Documentousuarioalteracao_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentousuarioalteracao = sdt.gxTv_SdtDocumento_Documentousuarioalteracao ;
         }
         if ( sdt.IsDirty("DocumentoIsOperador") )
         {
            gxTv_SdtDocumento_Documentoisoperador_N = (short)(sdt.gxTv_SdtDocumento_Documentoisoperador_N);
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentoisoperador = sdt.gxTv_SdtDocumento_Documentoisoperador ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "DocumentoId" )]
      [  XmlElement( ElementName = "DocumentoId"   )]
      public int gxTpr_Documentoid
      {
         get {
            return gxTv_SdtDocumento_Documentoid ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            if ( gxTv_SdtDocumento_Documentoid != value )
            {
               gxTv_SdtDocumento_Mode = "INS";
               this.gxTv_SdtDocumento_Documentoid_Z_SetNull( );
               this.gxTv_SdtDocumento_Documentonome_Z_SetNull( );
               this.gxTv_SdtDocumento_Subprocessoid_Z_SetNull( );
               this.gxTv_SdtDocumento_Encarregadoid_Z_SetNull( );
               this.gxTv_SdtDocumento_Personaid_Z_SetNull( );
               this.gxTv_SdtDocumento_Documentofinalidadetratamento_Z_SetNull( );
               this.gxTv_SdtDocumento_Categoriaid_Z_SetNull( );
               this.gxTv_SdtDocumento_Tipodadoid_Z_SetNull( );
               this.gxTv_SdtDocumento_Ferramentacoletaid_Z_SetNull( );
               this.gxTv_SdtDocumento_Abrangenciageograficaid_Z_SetNull( );
               this.gxTv_SdtDocumento_Frequenciatratamentoid_Z_SetNull( );
               this.gxTv_SdtDocumento_Tipodescarteid_Z_SetNull( );
               this.gxTv_SdtDocumento_Temporetencaoid_Z_SetNull( );
               this.gxTv_SdtDocumento_Documentoprevcoletadados_Z_SetNull( );
               this.gxTv_SdtDocumento_Documentobaselegalnorm_Z_SetNull( );
               this.gxTv_SdtDocumento_Documentobaselegalnormintext_Z_SetNull( );
               this.gxTv_SdtDocumento_Documentodadoscriancaadolesc_Z_SetNull( );
               this.gxTv_SdtDocumento_Documentodadosgrupovul_Z_SetNull( );
               this.gxTv_SdtDocumento_Documentoativo_Z_SetNull( );
               this.gxTv_SdtDocumento_Documentooperador_Z_SetNull( );
               this.gxTv_SdtDocumento_Documentoprocessoid_Z_SetNull( );
               this.gxTv_SdtDocumento_Documentoprocessonome_Z_SetNull( );
               this.gxTv_SdtDocumento_Documentodatainclusao_Z_SetNull( );
               this.gxTv_SdtDocumento_Documentodataalteracao_Z_SetNull( );
               this.gxTv_SdtDocumento_Documentocontroladorid_Z_SetNull( );
               this.gxTv_SdtDocumento_Arearesponsavelid_Z_SetNull( );
               this.gxTv_SdtDocumento_Documentousuarioinclusao_Z_SetNull( );
               this.gxTv_SdtDocumento_Documentousuarioalteracao_Z_SetNull( );
               this.gxTv_SdtDocumento_Documentoisoperador_Z_SetNull( );
            }
            gxTv_SdtDocumento_Documentoid = value;
            SetDirty("Documentoid");
         }

      }

      [  SoapElement( ElementName = "DocumentoNome" )]
      [  XmlElement( ElementName = "DocumentoNome"   )]
      public string gxTpr_Documentonome
      {
         get {
            return gxTv_SdtDocumento_Documentonome ;
         }

         set {
            gxTv_SdtDocumento_Documentonome_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentonome = value;
            SetDirty("Documentonome");
         }

      }

      public void gxTv_SdtDocumento_Documentonome_SetNull( )
      {
         gxTv_SdtDocumento_Documentonome_N = 1;
         gxTv_SdtDocumento_Documentonome = "";
         SetDirty("Documentonome");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentonome_IsNull( )
      {
         return (gxTv_SdtDocumento_Documentonome_N==1) ;
      }

      [  SoapElement( ElementName = "SubprocessoId" )]
      [  XmlElement( ElementName = "SubprocessoId"   )]
      public int gxTpr_Subprocessoid
      {
         get {
            return gxTv_SdtDocumento_Subprocessoid ;
         }

         set {
            gxTv_SdtDocumento_Subprocessoid_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Subprocessoid = value;
            SetDirty("Subprocessoid");
         }

      }

      public void gxTv_SdtDocumento_Subprocessoid_SetNull( )
      {
         gxTv_SdtDocumento_Subprocessoid_N = 1;
         gxTv_SdtDocumento_Subprocessoid = 0;
         SetDirty("Subprocessoid");
         return  ;
      }

      public bool gxTv_SdtDocumento_Subprocessoid_IsNull( )
      {
         return (gxTv_SdtDocumento_Subprocessoid_N==1) ;
      }

      [  SoapElement( ElementName = "EncarregadoId" )]
      [  XmlElement( ElementName = "EncarregadoId"   )]
      public int gxTpr_Encarregadoid
      {
         get {
            return gxTv_SdtDocumento_Encarregadoid ;
         }

         set {
            gxTv_SdtDocumento_Encarregadoid_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Encarregadoid = value;
            SetDirty("Encarregadoid");
         }

      }

      public void gxTv_SdtDocumento_Encarregadoid_SetNull( )
      {
         gxTv_SdtDocumento_Encarregadoid_N = 1;
         gxTv_SdtDocumento_Encarregadoid = 0;
         SetDirty("Encarregadoid");
         return  ;
      }

      public bool gxTv_SdtDocumento_Encarregadoid_IsNull( )
      {
         return (gxTv_SdtDocumento_Encarregadoid_N==1) ;
      }

      [  SoapElement( ElementName = "PersonaId" )]
      [  XmlElement( ElementName = "PersonaId"   )]
      public int gxTpr_Personaid
      {
         get {
            return gxTv_SdtDocumento_Personaid ;
         }

         set {
            gxTv_SdtDocumento_Personaid_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Personaid = value;
            SetDirty("Personaid");
         }

      }

      public void gxTv_SdtDocumento_Personaid_SetNull( )
      {
         gxTv_SdtDocumento_Personaid_N = 1;
         gxTv_SdtDocumento_Personaid = 0;
         SetDirty("Personaid");
         return  ;
      }

      public bool gxTv_SdtDocumento_Personaid_IsNull( )
      {
         return (gxTv_SdtDocumento_Personaid_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentoFinalidadeTratamento" )]
      [  XmlElement( ElementName = "DocumentoFinalidadeTratamento"   )]
      public string gxTpr_Documentofinalidadetratamento
      {
         get {
            return gxTv_SdtDocumento_Documentofinalidadetratamento ;
         }

         set {
            gxTv_SdtDocumento_Documentofinalidadetratamento_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentofinalidadetratamento = value;
            SetDirty("Documentofinalidadetratamento");
         }

      }

      public void gxTv_SdtDocumento_Documentofinalidadetratamento_SetNull( )
      {
         gxTv_SdtDocumento_Documentofinalidadetratamento_N = 1;
         gxTv_SdtDocumento_Documentofinalidadetratamento = "";
         SetDirty("Documentofinalidadetratamento");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentofinalidadetratamento_IsNull( )
      {
         return (gxTv_SdtDocumento_Documentofinalidadetratamento_N==1) ;
      }

      [  SoapElement( ElementName = "CategoriaId" )]
      [  XmlElement( ElementName = "CategoriaId"   )]
      public int gxTpr_Categoriaid
      {
         get {
            return gxTv_SdtDocumento_Categoriaid ;
         }

         set {
            gxTv_SdtDocumento_Categoriaid_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Categoriaid = value;
            SetDirty("Categoriaid");
         }

      }

      public void gxTv_SdtDocumento_Categoriaid_SetNull( )
      {
         gxTv_SdtDocumento_Categoriaid_N = 1;
         gxTv_SdtDocumento_Categoriaid = 0;
         SetDirty("Categoriaid");
         return  ;
      }

      public bool gxTv_SdtDocumento_Categoriaid_IsNull( )
      {
         return (gxTv_SdtDocumento_Categoriaid_N==1) ;
      }

      [  SoapElement( ElementName = "TipoDadoId" )]
      [  XmlElement( ElementName = "TipoDadoId"   )]
      public int gxTpr_Tipodadoid
      {
         get {
            return gxTv_SdtDocumento_Tipodadoid ;
         }

         set {
            gxTv_SdtDocumento_Tipodadoid_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Tipodadoid = value;
            SetDirty("Tipodadoid");
         }

      }

      public void gxTv_SdtDocumento_Tipodadoid_SetNull( )
      {
         gxTv_SdtDocumento_Tipodadoid_N = 1;
         gxTv_SdtDocumento_Tipodadoid = 0;
         SetDirty("Tipodadoid");
         return  ;
      }

      public bool gxTv_SdtDocumento_Tipodadoid_IsNull( )
      {
         return (gxTv_SdtDocumento_Tipodadoid_N==1) ;
      }

      [  SoapElement( ElementName = "FerramentaColetaId" )]
      [  XmlElement( ElementName = "FerramentaColetaId"   )]
      public int gxTpr_Ferramentacoletaid
      {
         get {
            return gxTv_SdtDocumento_Ferramentacoletaid ;
         }

         set {
            gxTv_SdtDocumento_Ferramentacoletaid_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Ferramentacoletaid = value;
            SetDirty("Ferramentacoletaid");
         }

      }

      public void gxTv_SdtDocumento_Ferramentacoletaid_SetNull( )
      {
         gxTv_SdtDocumento_Ferramentacoletaid_N = 1;
         gxTv_SdtDocumento_Ferramentacoletaid = 0;
         SetDirty("Ferramentacoletaid");
         return  ;
      }

      public bool gxTv_SdtDocumento_Ferramentacoletaid_IsNull( )
      {
         return (gxTv_SdtDocumento_Ferramentacoletaid_N==1) ;
      }

      [  SoapElement( ElementName = "AbrangenciaGeograficaId" )]
      [  XmlElement( ElementName = "AbrangenciaGeograficaId"   )]
      public int gxTpr_Abrangenciageograficaid
      {
         get {
            return gxTv_SdtDocumento_Abrangenciageograficaid ;
         }

         set {
            gxTv_SdtDocumento_Abrangenciageograficaid_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Abrangenciageograficaid = value;
            SetDirty("Abrangenciageograficaid");
         }

      }

      public void gxTv_SdtDocumento_Abrangenciageograficaid_SetNull( )
      {
         gxTv_SdtDocumento_Abrangenciageograficaid_N = 1;
         gxTv_SdtDocumento_Abrangenciageograficaid = 0;
         SetDirty("Abrangenciageograficaid");
         return  ;
      }

      public bool gxTv_SdtDocumento_Abrangenciageograficaid_IsNull( )
      {
         return (gxTv_SdtDocumento_Abrangenciageograficaid_N==1) ;
      }

      [  SoapElement( ElementName = "FrequenciaTratamentoId" )]
      [  XmlElement( ElementName = "FrequenciaTratamentoId"   )]
      public int gxTpr_Frequenciatratamentoid
      {
         get {
            return gxTv_SdtDocumento_Frequenciatratamentoid ;
         }

         set {
            gxTv_SdtDocumento_Frequenciatratamentoid_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Frequenciatratamentoid = value;
            SetDirty("Frequenciatratamentoid");
         }

      }

      public void gxTv_SdtDocumento_Frequenciatratamentoid_SetNull( )
      {
         gxTv_SdtDocumento_Frequenciatratamentoid_N = 1;
         gxTv_SdtDocumento_Frequenciatratamentoid = 0;
         SetDirty("Frequenciatratamentoid");
         return  ;
      }

      public bool gxTv_SdtDocumento_Frequenciatratamentoid_IsNull( )
      {
         return (gxTv_SdtDocumento_Frequenciatratamentoid_N==1) ;
      }

      [  SoapElement( ElementName = "TipoDescarteId" )]
      [  XmlElement( ElementName = "TipoDescarteId"   )]
      public int gxTpr_Tipodescarteid
      {
         get {
            return gxTv_SdtDocumento_Tipodescarteid ;
         }

         set {
            gxTv_SdtDocumento_Tipodescarteid_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Tipodescarteid = value;
            SetDirty("Tipodescarteid");
         }

      }

      public void gxTv_SdtDocumento_Tipodescarteid_SetNull( )
      {
         gxTv_SdtDocumento_Tipodescarteid_N = 1;
         gxTv_SdtDocumento_Tipodescarteid = 0;
         SetDirty("Tipodescarteid");
         return  ;
      }

      public bool gxTv_SdtDocumento_Tipodescarteid_IsNull( )
      {
         return (gxTv_SdtDocumento_Tipodescarteid_N==1) ;
      }

      [  SoapElement( ElementName = "TempoRetencaoId" )]
      [  XmlElement( ElementName = "TempoRetencaoId"   )]
      public int gxTpr_Temporetencaoid
      {
         get {
            return gxTv_SdtDocumento_Temporetencaoid ;
         }

         set {
            gxTv_SdtDocumento_Temporetencaoid_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Temporetencaoid = value;
            SetDirty("Temporetencaoid");
         }

      }

      public void gxTv_SdtDocumento_Temporetencaoid_SetNull( )
      {
         gxTv_SdtDocumento_Temporetencaoid_N = 1;
         gxTv_SdtDocumento_Temporetencaoid = 0;
         SetDirty("Temporetencaoid");
         return  ;
      }

      public bool gxTv_SdtDocumento_Temporetencaoid_IsNull( )
      {
         return (gxTv_SdtDocumento_Temporetencaoid_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentoPrevColetaDados" )]
      [  XmlElement( ElementName = "DocumentoPrevColetaDados"   )]
      public bool gxTpr_Documentoprevcoletadados
      {
         get {
            return gxTv_SdtDocumento_Documentoprevcoletadados ;
         }

         set {
            gxTv_SdtDocumento_Documentoprevcoletadados_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentoprevcoletadados = value;
            SetDirty("Documentoprevcoletadados");
         }

      }

      public void gxTv_SdtDocumento_Documentoprevcoletadados_SetNull( )
      {
         gxTv_SdtDocumento_Documentoprevcoletadados_N = 1;
         gxTv_SdtDocumento_Documentoprevcoletadados = false;
         SetDirty("Documentoprevcoletadados");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentoprevcoletadados_IsNull( )
      {
         return (gxTv_SdtDocumento_Documentoprevcoletadados_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentoBaseLegalNorm" )]
      [  XmlElement( ElementName = "DocumentoBaseLegalNorm"   )]
      public string gxTpr_Documentobaselegalnorm
      {
         get {
            return gxTv_SdtDocumento_Documentobaselegalnorm ;
         }

         set {
            gxTv_SdtDocumento_Documentobaselegalnorm_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentobaselegalnorm = value;
            SetDirty("Documentobaselegalnorm");
         }

      }

      public void gxTv_SdtDocumento_Documentobaselegalnorm_SetNull( )
      {
         gxTv_SdtDocumento_Documentobaselegalnorm_N = 1;
         gxTv_SdtDocumento_Documentobaselegalnorm = "";
         SetDirty("Documentobaselegalnorm");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentobaselegalnorm_IsNull( )
      {
         return (gxTv_SdtDocumento_Documentobaselegalnorm_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentoBaseLegalNormIntExt" )]
      [  XmlElement( ElementName = "DocumentoBaseLegalNormIntExt"   )]
      public string gxTpr_Documentobaselegalnormintext
      {
         get {
            return gxTv_SdtDocumento_Documentobaselegalnormintext ;
         }

         set {
            gxTv_SdtDocumento_Documentobaselegalnormintext_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentobaselegalnormintext = value;
            SetDirty("Documentobaselegalnormintext");
         }

      }

      public void gxTv_SdtDocumento_Documentobaselegalnormintext_SetNull( )
      {
         gxTv_SdtDocumento_Documentobaselegalnormintext_N = 1;
         gxTv_SdtDocumento_Documentobaselegalnormintext = "";
         SetDirty("Documentobaselegalnormintext");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentobaselegalnormintext_IsNull( )
      {
         return (gxTv_SdtDocumento_Documentobaselegalnormintext_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentoDadosCriancaAdolesc" )]
      [  XmlElement( ElementName = "DocumentoDadosCriancaAdolesc"   )]
      public bool gxTpr_Documentodadoscriancaadolesc
      {
         get {
            return gxTv_SdtDocumento_Documentodadoscriancaadolesc ;
         }

         set {
            gxTv_SdtDocumento_Documentodadoscriancaadolesc_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentodadoscriancaadolesc = value;
            SetDirty("Documentodadoscriancaadolesc");
         }

      }

      public void gxTv_SdtDocumento_Documentodadoscriancaadolesc_SetNull( )
      {
         gxTv_SdtDocumento_Documentodadoscriancaadolesc_N = 1;
         gxTv_SdtDocumento_Documentodadoscriancaadolesc = false;
         SetDirty("Documentodadoscriancaadolesc");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentodadoscriancaadolesc_IsNull( )
      {
         return (gxTv_SdtDocumento_Documentodadoscriancaadolesc_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentoDadosGrupoVul" )]
      [  XmlElement( ElementName = "DocumentoDadosGrupoVul"   )]
      public bool gxTpr_Documentodadosgrupovul
      {
         get {
            return gxTv_SdtDocumento_Documentodadosgrupovul ;
         }

         set {
            gxTv_SdtDocumento_Documentodadosgrupovul_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentodadosgrupovul = value;
            SetDirty("Documentodadosgrupovul");
         }

      }

      public void gxTv_SdtDocumento_Documentodadosgrupovul_SetNull( )
      {
         gxTv_SdtDocumento_Documentodadosgrupovul_N = 1;
         gxTv_SdtDocumento_Documentodadosgrupovul = false;
         SetDirty("Documentodadosgrupovul");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentodadosgrupovul_IsNull( )
      {
         return (gxTv_SdtDocumento_Documentodadosgrupovul_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentoMedidaSegurancaDesc" )]
      [  XmlElement( ElementName = "DocumentoMedidaSegurancaDesc"   )]
      public string gxTpr_Documentomedidasegurancadesc
      {
         get {
            return gxTv_SdtDocumento_Documentomedidasegurancadesc ;
         }

         set {
            gxTv_SdtDocumento_Documentomedidasegurancadesc_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentomedidasegurancadesc = value;
            SetDirty("Documentomedidasegurancadesc");
         }

      }

      public void gxTv_SdtDocumento_Documentomedidasegurancadesc_SetNull( )
      {
         gxTv_SdtDocumento_Documentomedidasegurancadesc_N = 1;
         gxTv_SdtDocumento_Documentomedidasegurancadesc = "";
         SetDirty("Documentomedidasegurancadesc");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentomedidasegurancadesc_IsNull( )
      {
         return (gxTv_SdtDocumento_Documentomedidasegurancadesc_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentoFluxoTratDadosDesc" )]
      [  XmlElement( ElementName = "DocumentoFluxoTratDadosDesc"   )]
      public string gxTpr_Documentofluxotratdadosdesc
      {
         get {
            return gxTv_SdtDocumento_Documentofluxotratdadosdesc ;
         }

         set {
            gxTv_SdtDocumento_Documentofluxotratdadosdesc_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentofluxotratdadosdesc = value;
            SetDirty("Documentofluxotratdadosdesc");
         }

      }

      public void gxTv_SdtDocumento_Documentofluxotratdadosdesc_SetNull( )
      {
         gxTv_SdtDocumento_Documentofluxotratdadosdesc_N = 1;
         gxTv_SdtDocumento_Documentofluxotratdadosdesc = "";
         SetDirty("Documentofluxotratdadosdesc");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentofluxotratdadosdesc_IsNull( )
      {
         return (gxTv_SdtDocumento_Documentofluxotratdadosdesc_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentoAtivo" )]
      [  XmlElement( ElementName = "DocumentoAtivo"   )]
      public bool gxTpr_Documentoativo
      {
         get {
            return gxTv_SdtDocumento_Documentoativo ;
         }

         set {
            gxTv_SdtDocumento_Documentoativo_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentoativo = value;
            SetDirty("Documentoativo");
         }

      }

      public void gxTv_SdtDocumento_Documentoativo_SetNull( )
      {
         gxTv_SdtDocumento_Documentoativo_N = 1;
         gxTv_SdtDocumento_Documentoativo = false;
         SetDirty("Documentoativo");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentoativo_IsNull( )
      {
         return (gxTv_SdtDocumento_Documentoativo_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentoOperador" )]
      [  XmlElement( ElementName = "DocumentoOperador"   )]
      public bool gxTpr_Documentooperador
      {
         get {
            return gxTv_SdtDocumento_Documentooperador ;
         }

         set {
            gxTv_SdtDocumento_Documentooperador_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentooperador = value;
            SetDirty("Documentooperador");
         }

      }

      public void gxTv_SdtDocumento_Documentooperador_SetNull( )
      {
         gxTv_SdtDocumento_Documentooperador_N = 1;
         gxTv_SdtDocumento_Documentooperador = false;
         SetDirty("Documentooperador");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentooperador_IsNull( )
      {
         return (gxTv_SdtDocumento_Documentooperador_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentoProcessoId" )]
      [  XmlElement( ElementName = "DocumentoProcessoId"   )]
      public int gxTpr_Documentoprocessoid
      {
         get {
            return gxTv_SdtDocumento_Documentoprocessoid ;
         }

         set {
            gxTv_SdtDocumento_Documentoprocessoid_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentoprocessoid = value;
            SetDirty("Documentoprocessoid");
         }

      }

      public void gxTv_SdtDocumento_Documentoprocessoid_SetNull( )
      {
         gxTv_SdtDocumento_Documentoprocessoid_N = 1;
         gxTv_SdtDocumento_Documentoprocessoid = 0;
         SetDirty("Documentoprocessoid");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentoprocessoid_IsNull( )
      {
         return (gxTv_SdtDocumento_Documentoprocessoid_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentoProcessoNome" )]
      [  XmlElement( ElementName = "DocumentoProcessoNome"   )]
      public string gxTpr_Documentoprocessonome
      {
         get {
            return gxTv_SdtDocumento_Documentoprocessonome ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentoprocessonome = value;
            SetDirty("Documentoprocessonome");
         }

      }

      [  SoapElement( ElementName = "DocumentoDataInclusao" )]
      [  XmlElement( ElementName = "DocumentoDataInclusao"  , IsNullable=true )]
      public string gxTpr_Documentodatainclusao_Nullable
      {
         get {
            if ( gxTv_SdtDocumento_Documentodatainclusao == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumento_Documentodatainclusao).value ;
         }

         set {
            gxTv_SdtDocumento_Documentodatainclusao_N = 0;
            gxTv_SdtDocumento_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumento_Documentodatainclusao = DateTime.MinValue;
            else
               gxTv_SdtDocumento_Documentodatainclusao = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Documentodatainclusao
      {
         get {
            return gxTv_SdtDocumento_Documentodatainclusao ;
         }

         set {
            gxTv_SdtDocumento_Documentodatainclusao_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentodatainclusao = value;
            SetDirty("Documentodatainclusao");
         }

      }

      public void gxTv_SdtDocumento_Documentodatainclusao_SetNull( )
      {
         gxTv_SdtDocumento_Documentodatainclusao_N = 1;
         gxTv_SdtDocumento_Documentodatainclusao = (DateTime)(DateTime.MinValue);
         SetDirty("Documentodatainclusao");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentodatainclusao_IsNull( )
      {
         return (gxTv_SdtDocumento_Documentodatainclusao_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentoDataAlteracao" )]
      [  XmlElement( ElementName = "DocumentoDataAlteracao"  , IsNullable=true )]
      public string gxTpr_Documentodataalteracao_Nullable
      {
         get {
            if ( gxTv_SdtDocumento_Documentodataalteracao == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumento_Documentodataalteracao).value ;
         }

         set {
            gxTv_SdtDocumento_Documentodataalteracao_N = 0;
            gxTv_SdtDocumento_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumento_Documentodataalteracao = DateTime.MinValue;
            else
               gxTv_SdtDocumento_Documentodataalteracao = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Documentodataalteracao
      {
         get {
            return gxTv_SdtDocumento_Documentodataalteracao ;
         }

         set {
            gxTv_SdtDocumento_Documentodataalteracao_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentodataalteracao = value;
            SetDirty("Documentodataalteracao");
         }

      }

      public void gxTv_SdtDocumento_Documentodataalteracao_SetNull( )
      {
         gxTv_SdtDocumento_Documentodataalteracao_N = 1;
         gxTv_SdtDocumento_Documentodataalteracao = (DateTime)(DateTime.MinValue);
         SetDirty("Documentodataalteracao");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentodataalteracao_IsNull( )
      {
         return (gxTv_SdtDocumento_Documentodataalteracao_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentoControladorId" )]
      [  XmlElement( ElementName = "DocumentoControladorId"   )]
      public int gxTpr_Documentocontroladorid
      {
         get {
            return gxTv_SdtDocumento_Documentocontroladorid ;
         }

         set {
            gxTv_SdtDocumento_Documentocontroladorid_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentocontroladorid = value;
            SetDirty("Documentocontroladorid");
         }

      }

      public void gxTv_SdtDocumento_Documentocontroladorid_SetNull( )
      {
         gxTv_SdtDocumento_Documentocontroladorid_N = 1;
         gxTv_SdtDocumento_Documentocontroladorid = 0;
         SetDirty("Documentocontroladorid");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentocontroladorid_IsNull( )
      {
         return (gxTv_SdtDocumento_Documentocontroladorid_N==1) ;
      }

      [  SoapElement( ElementName = "AreaResponsavelId" )]
      [  XmlElement( ElementName = "AreaResponsavelId"   )]
      public int gxTpr_Arearesponsavelid
      {
         get {
            return gxTv_SdtDocumento_Arearesponsavelid ;
         }

         set {
            gxTv_SdtDocumento_Arearesponsavelid_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Arearesponsavelid = value;
            SetDirty("Arearesponsavelid");
         }

      }

      public void gxTv_SdtDocumento_Arearesponsavelid_SetNull( )
      {
         gxTv_SdtDocumento_Arearesponsavelid_N = 1;
         gxTv_SdtDocumento_Arearesponsavelid = 0;
         SetDirty("Arearesponsavelid");
         return  ;
      }

      public bool gxTv_SdtDocumento_Arearesponsavelid_IsNull( )
      {
         return (gxTv_SdtDocumento_Arearesponsavelid_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentoUsuarioInclusao" )]
      [  XmlElement( ElementName = "DocumentoUsuarioInclusao"   )]
      public string gxTpr_Documentousuarioinclusao
      {
         get {
            return gxTv_SdtDocumento_Documentousuarioinclusao ;
         }

         set {
            gxTv_SdtDocumento_Documentousuarioinclusao_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentousuarioinclusao = value;
            SetDirty("Documentousuarioinclusao");
         }

      }

      public void gxTv_SdtDocumento_Documentousuarioinclusao_SetNull( )
      {
         gxTv_SdtDocumento_Documentousuarioinclusao_N = 1;
         gxTv_SdtDocumento_Documentousuarioinclusao = "";
         SetDirty("Documentousuarioinclusao");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentousuarioinclusao_IsNull( )
      {
         return (gxTv_SdtDocumento_Documentousuarioinclusao_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentoUsuarioAlteracao" )]
      [  XmlElement( ElementName = "DocumentoUsuarioAlteracao"   )]
      public string gxTpr_Documentousuarioalteracao
      {
         get {
            return gxTv_SdtDocumento_Documentousuarioalteracao ;
         }

         set {
            gxTv_SdtDocumento_Documentousuarioalteracao_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentousuarioalteracao = value;
            SetDirty("Documentousuarioalteracao");
         }

      }

      public void gxTv_SdtDocumento_Documentousuarioalteracao_SetNull( )
      {
         gxTv_SdtDocumento_Documentousuarioalteracao_N = 1;
         gxTv_SdtDocumento_Documentousuarioalteracao = "";
         SetDirty("Documentousuarioalteracao");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentousuarioalteracao_IsNull( )
      {
         return (gxTv_SdtDocumento_Documentousuarioalteracao_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentoIsOperador" )]
      [  XmlElement( ElementName = "DocumentoIsOperador"   )]
      public bool gxTpr_Documentoisoperador
      {
         get {
            return gxTv_SdtDocumento_Documentoisoperador ;
         }

         set {
            gxTv_SdtDocumento_Documentoisoperador_N = 0;
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentoisoperador = value;
            SetDirty("Documentoisoperador");
         }

      }

      public void gxTv_SdtDocumento_Documentoisoperador_SetNull( )
      {
         gxTv_SdtDocumento_Documentoisoperador_N = 1;
         gxTv_SdtDocumento_Documentoisoperador = false;
         SetDirty("Documentoisoperador");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentoisoperador_IsNull( )
      {
         return (gxTv_SdtDocumento_Documentoisoperador_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtDocumento_Mode ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtDocumento_Mode_SetNull( )
      {
         gxTv_SdtDocumento_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtDocumento_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtDocumento_Initialized ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtDocumento_Initialized_SetNull( )
      {
         gxTv_SdtDocumento_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtDocumento_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoId_Z" )]
      [  XmlElement( ElementName = "DocumentoId_Z"   )]
      public int gxTpr_Documentoid_Z
      {
         get {
            return gxTv_SdtDocumento_Documentoid_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentoid_Z = value;
            SetDirty("Documentoid_Z");
         }

      }

      public void gxTv_SdtDocumento_Documentoid_Z_SetNull( )
      {
         gxTv_SdtDocumento_Documentoid_Z = 0;
         SetDirty("Documentoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoNome_Z" )]
      [  XmlElement( ElementName = "DocumentoNome_Z"   )]
      public string gxTpr_Documentonome_Z
      {
         get {
            return gxTv_SdtDocumento_Documentonome_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentonome_Z = value;
            SetDirty("Documentonome_Z");
         }

      }

      public void gxTv_SdtDocumento_Documentonome_Z_SetNull( )
      {
         gxTv_SdtDocumento_Documentonome_Z = "";
         SetDirty("Documentonome_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SubprocessoId_Z" )]
      [  XmlElement( ElementName = "SubprocessoId_Z"   )]
      public int gxTpr_Subprocessoid_Z
      {
         get {
            return gxTv_SdtDocumento_Subprocessoid_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Subprocessoid_Z = value;
            SetDirty("Subprocessoid_Z");
         }

      }

      public void gxTv_SdtDocumento_Subprocessoid_Z_SetNull( )
      {
         gxTv_SdtDocumento_Subprocessoid_Z = 0;
         SetDirty("Subprocessoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Subprocessoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EncarregadoId_Z" )]
      [  XmlElement( ElementName = "EncarregadoId_Z"   )]
      public int gxTpr_Encarregadoid_Z
      {
         get {
            return gxTv_SdtDocumento_Encarregadoid_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Encarregadoid_Z = value;
            SetDirty("Encarregadoid_Z");
         }

      }

      public void gxTv_SdtDocumento_Encarregadoid_Z_SetNull( )
      {
         gxTv_SdtDocumento_Encarregadoid_Z = 0;
         SetDirty("Encarregadoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Encarregadoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PersonaId_Z" )]
      [  XmlElement( ElementName = "PersonaId_Z"   )]
      public int gxTpr_Personaid_Z
      {
         get {
            return gxTv_SdtDocumento_Personaid_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Personaid_Z = value;
            SetDirty("Personaid_Z");
         }

      }

      public void gxTv_SdtDocumento_Personaid_Z_SetNull( )
      {
         gxTv_SdtDocumento_Personaid_Z = 0;
         SetDirty("Personaid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Personaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoFinalidadeTratamento_Z" )]
      [  XmlElement( ElementName = "DocumentoFinalidadeTratamento_Z"   )]
      public string gxTpr_Documentofinalidadetratamento_Z
      {
         get {
            return gxTv_SdtDocumento_Documentofinalidadetratamento_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentofinalidadetratamento_Z = value;
            SetDirty("Documentofinalidadetratamento_Z");
         }

      }

      public void gxTv_SdtDocumento_Documentofinalidadetratamento_Z_SetNull( )
      {
         gxTv_SdtDocumento_Documentofinalidadetratamento_Z = "";
         SetDirty("Documentofinalidadetratamento_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentofinalidadetratamento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoriaId_Z" )]
      [  XmlElement( ElementName = "CategoriaId_Z"   )]
      public int gxTpr_Categoriaid_Z
      {
         get {
            return gxTv_SdtDocumento_Categoriaid_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Categoriaid_Z = value;
            SetDirty("Categoriaid_Z");
         }

      }

      public void gxTv_SdtDocumento_Categoriaid_Z_SetNull( )
      {
         gxTv_SdtDocumento_Categoriaid_Z = 0;
         SetDirty("Categoriaid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Categoriaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoDadoId_Z" )]
      [  XmlElement( ElementName = "TipoDadoId_Z"   )]
      public int gxTpr_Tipodadoid_Z
      {
         get {
            return gxTv_SdtDocumento_Tipodadoid_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Tipodadoid_Z = value;
            SetDirty("Tipodadoid_Z");
         }

      }

      public void gxTv_SdtDocumento_Tipodadoid_Z_SetNull( )
      {
         gxTv_SdtDocumento_Tipodadoid_Z = 0;
         SetDirty("Tipodadoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Tipodadoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FerramentaColetaId_Z" )]
      [  XmlElement( ElementName = "FerramentaColetaId_Z"   )]
      public int gxTpr_Ferramentacoletaid_Z
      {
         get {
            return gxTv_SdtDocumento_Ferramentacoletaid_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Ferramentacoletaid_Z = value;
            SetDirty("Ferramentacoletaid_Z");
         }

      }

      public void gxTv_SdtDocumento_Ferramentacoletaid_Z_SetNull( )
      {
         gxTv_SdtDocumento_Ferramentacoletaid_Z = 0;
         SetDirty("Ferramentacoletaid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Ferramentacoletaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AbrangenciaGeograficaId_Z" )]
      [  XmlElement( ElementName = "AbrangenciaGeograficaId_Z"   )]
      public int gxTpr_Abrangenciageograficaid_Z
      {
         get {
            return gxTv_SdtDocumento_Abrangenciageograficaid_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Abrangenciageograficaid_Z = value;
            SetDirty("Abrangenciageograficaid_Z");
         }

      }

      public void gxTv_SdtDocumento_Abrangenciageograficaid_Z_SetNull( )
      {
         gxTv_SdtDocumento_Abrangenciageograficaid_Z = 0;
         SetDirty("Abrangenciageograficaid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Abrangenciageograficaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FrequenciaTratamentoId_Z" )]
      [  XmlElement( ElementName = "FrequenciaTratamentoId_Z"   )]
      public int gxTpr_Frequenciatratamentoid_Z
      {
         get {
            return gxTv_SdtDocumento_Frequenciatratamentoid_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Frequenciatratamentoid_Z = value;
            SetDirty("Frequenciatratamentoid_Z");
         }

      }

      public void gxTv_SdtDocumento_Frequenciatratamentoid_Z_SetNull( )
      {
         gxTv_SdtDocumento_Frequenciatratamentoid_Z = 0;
         SetDirty("Frequenciatratamentoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Frequenciatratamentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoDescarteId_Z" )]
      [  XmlElement( ElementName = "TipoDescarteId_Z"   )]
      public int gxTpr_Tipodescarteid_Z
      {
         get {
            return gxTv_SdtDocumento_Tipodescarteid_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Tipodescarteid_Z = value;
            SetDirty("Tipodescarteid_Z");
         }

      }

      public void gxTv_SdtDocumento_Tipodescarteid_Z_SetNull( )
      {
         gxTv_SdtDocumento_Tipodescarteid_Z = 0;
         SetDirty("Tipodescarteid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Tipodescarteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TempoRetencaoId_Z" )]
      [  XmlElement( ElementName = "TempoRetencaoId_Z"   )]
      public int gxTpr_Temporetencaoid_Z
      {
         get {
            return gxTv_SdtDocumento_Temporetencaoid_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Temporetencaoid_Z = value;
            SetDirty("Temporetencaoid_Z");
         }

      }

      public void gxTv_SdtDocumento_Temporetencaoid_Z_SetNull( )
      {
         gxTv_SdtDocumento_Temporetencaoid_Z = 0;
         SetDirty("Temporetencaoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Temporetencaoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoPrevColetaDados_Z" )]
      [  XmlElement( ElementName = "DocumentoPrevColetaDados_Z"   )]
      public bool gxTpr_Documentoprevcoletadados_Z
      {
         get {
            return gxTv_SdtDocumento_Documentoprevcoletadados_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentoprevcoletadados_Z = value;
            SetDirty("Documentoprevcoletadados_Z");
         }

      }

      public void gxTv_SdtDocumento_Documentoprevcoletadados_Z_SetNull( )
      {
         gxTv_SdtDocumento_Documentoprevcoletadados_Z = false;
         SetDirty("Documentoprevcoletadados_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentoprevcoletadados_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoBaseLegalNorm_Z" )]
      [  XmlElement( ElementName = "DocumentoBaseLegalNorm_Z"   )]
      public string gxTpr_Documentobaselegalnorm_Z
      {
         get {
            return gxTv_SdtDocumento_Documentobaselegalnorm_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentobaselegalnorm_Z = value;
            SetDirty("Documentobaselegalnorm_Z");
         }

      }

      public void gxTv_SdtDocumento_Documentobaselegalnorm_Z_SetNull( )
      {
         gxTv_SdtDocumento_Documentobaselegalnorm_Z = "";
         SetDirty("Documentobaselegalnorm_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentobaselegalnorm_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoBaseLegalNormIntExt_Z" )]
      [  XmlElement( ElementName = "DocumentoBaseLegalNormIntExt_Z"   )]
      public string gxTpr_Documentobaselegalnormintext_Z
      {
         get {
            return gxTv_SdtDocumento_Documentobaselegalnormintext_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentobaselegalnormintext_Z = value;
            SetDirty("Documentobaselegalnormintext_Z");
         }

      }

      public void gxTv_SdtDocumento_Documentobaselegalnormintext_Z_SetNull( )
      {
         gxTv_SdtDocumento_Documentobaselegalnormintext_Z = "";
         SetDirty("Documentobaselegalnormintext_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentobaselegalnormintext_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoDadosCriancaAdolesc_Z" )]
      [  XmlElement( ElementName = "DocumentoDadosCriancaAdolesc_Z"   )]
      public bool gxTpr_Documentodadoscriancaadolesc_Z
      {
         get {
            return gxTv_SdtDocumento_Documentodadoscriancaadolesc_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentodadoscriancaadolesc_Z = value;
            SetDirty("Documentodadoscriancaadolesc_Z");
         }

      }

      public void gxTv_SdtDocumento_Documentodadoscriancaadolesc_Z_SetNull( )
      {
         gxTv_SdtDocumento_Documentodadoscriancaadolesc_Z = false;
         SetDirty("Documentodadoscriancaadolesc_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentodadoscriancaadolesc_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoDadosGrupoVul_Z" )]
      [  XmlElement( ElementName = "DocumentoDadosGrupoVul_Z"   )]
      public bool gxTpr_Documentodadosgrupovul_Z
      {
         get {
            return gxTv_SdtDocumento_Documentodadosgrupovul_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentodadosgrupovul_Z = value;
            SetDirty("Documentodadosgrupovul_Z");
         }

      }

      public void gxTv_SdtDocumento_Documentodadosgrupovul_Z_SetNull( )
      {
         gxTv_SdtDocumento_Documentodadosgrupovul_Z = false;
         SetDirty("Documentodadosgrupovul_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentodadosgrupovul_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoAtivo_Z" )]
      [  XmlElement( ElementName = "DocumentoAtivo_Z"   )]
      public bool gxTpr_Documentoativo_Z
      {
         get {
            return gxTv_SdtDocumento_Documentoativo_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentoativo_Z = value;
            SetDirty("Documentoativo_Z");
         }

      }

      public void gxTv_SdtDocumento_Documentoativo_Z_SetNull( )
      {
         gxTv_SdtDocumento_Documentoativo_Z = false;
         SetDirty("Documentoativo_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentoativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoOperador_Z" )]
      [  XmlElement( ElementName = "DocumentoOperador_Z"   )]
      public bool gxTpr_Documentooperador_Z
      {
         get {
            return gxTv_SdtDocumento_Documentooperador_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentooperador_Z = value;
            SetDirty("Documentooperador_Z");
         }

      }

      public void gxTv_SdtDocumento_Documentooperador_Z_SetNull( )
      {
         gxTv_SdtDocumento_Documentooperador_Z = false;
         SetDirty("Documentooperador_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentooperador_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoProcessoId_Z" )]
      [  XmlElement( ElementName = "DocumentoProcessoId_Z"   )]
      public int gxTpr_Documentoprocessoid_Z
      {
         get {
            return gxTv_SdtDocumento_Documentoprocessoid_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentoprocessoid_Z = value;
            SetDirty("Documentoprocessoid_Z");
         }

      }

      public void gxTv_SdtDocumento_Documentoprocessoid_Z_SetNull( )
      {
         gxTv_SdtDocumento_Documentoprocessoid_Z = 0;
         SetDirty("Documentoprocessoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentoprocessoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoProcessoNome_Z" )]
      [  XmlElement( ElementName = "DocumentoProcessoNome_Z"   )]
      public string gxTpr_Documentoprocessonome_Z
      {
         get {
            return gxTv_SdtDocumento_Documentoprocessonome_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentoprocessonome_Z = value;
            SetDirty("Documentoprocessonome_Z");
         }

      }

      public void gxTv_SdtDocumento_Documentoprocessonome_Z_SetNull( )
      {
         gxTv_SdtDocumento_Documentoprocessonome_Z = "";
         SetDirty("Documentoprocessonome_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentoprocessonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoDataInclusao_Z" )]
      [  XmlElement( ElementName = "DocumentoDataInclusao_Z"  , IsNullable=true )]
      public string gxTpr_Documentodatainclusao_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumento_Documentodatainclusao_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumento_Documentodatainclusao_Z).value ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumento_Documentodatainclusao_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumento_Documentodatainclusao_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Documentodatainclusao_Z
      {
         get {
            return gxTv_SdtDocumento_Documentodatainclusao_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentodatainclusao_Z = value;
            SetDirty("Documentodatainclusao_Z");
         }

      }

      public void gxTv_SdtDocumento_Documentodatainclusao_Z_SetNull( )
      {
         gxTv_SdtDocumento_Documentodatainclusao_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Documentodatainclusao_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentodatainclusao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoDataAlteracao_Z" )]
      [  XmlElement( ElementName = "DocumentoDataAlteracao_Z"  , IsNullable=true )]
      public string gxTpr_Documentodataalteracao_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocumento_Documentodataalteracao_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtDocumento_Documentodataalteracao_Z).value ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtDocumento_Documentodataalteracao_Z = DateTime.MinValue;
            else
               gxTv_SdtDocumento_Documentodataalteracao_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Documentodataalteracao_Z
      {
         get {
            return gxTv_SdtDocumento_Documentodataalteracao_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentodataalteracao_Z = value;
            SetDirty("Documentodataalteracao_Z");
         }

      }

      public void gxTv_SdtDocumento_Documentodataalteracao_Z_SetNull( )
      {
         gxTv_SdtDocumento_Documentodataalteracao_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Documentodataalteracao_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentodataalteracao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoControladorId_Z" )]
      [  XmlElement( ElementName = "DocumentoControladorId_Z"   )]
      public int gxTpr_Documentocontroladorid_Z
      {
         get {
            return gxTv_SdtDocumento_Documentocontroladorid_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentocontroladorid_Z = value;
            SetDirty("Documentocontroladorid_Z");
         }

      }

      public void gxTv_SdtDocumento_Documentocontroladorid_Z_SetNull( )
      {
         gxTv_SdtDocumento_Documentocontroladorid_Z = 0;
         SetDirty("Documentocontroladorid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentocontroladorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AreaResponsavelId_Z" )]
      [  XmlElement( ElementName = "AreaResponsavelId_Z"   )]
      public int gxTpr_Arearesponsavelid_Z
      {
         get {
            return gxTv_SdtDocumento_Arearesponsavelid_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Arearesponsavelid_Z = value;
            SetDirty("Arearesponsavelid_Z");
         }

      }

      public void gxTv_SdtDocumento_Arearesponsavelid_Z_SetNull( )
      {
         gxTv_SdtDocumento_Arearesponsavelid_Z = 0;
         SetDirty("Arearesponsavelid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Arearesponsavelid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoUsuarioInclusao_Z" )]
      [  XmlElement( ElementName = "DocumentoUsuarioInclusao_Z"   )]
      public string gxTpr_Documentousuarioinclusao_Z
      {
         get {
            return gxTv_SdtDocumento_Documentousuarioinclusao_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentousuarioinclusao_Z = value;
            SetDirty("Documentousuarioinclusao_Z");
         }

      }

      public void gxTv_SdtDocumento_Documentousuarioinclusao_Z_SetNull( )
      {
         gxTv_SdtDocumento_Documentousuarioinclusao_Z = "";
         SetDirty("Documentousuarioinclusao_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentousuarioinclusao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoUsuarioAlteracao_Z" )]
      [  XmlElement( ElementName = "DocumentoUsuarioAlteracao_Z"   )]
      public string gxTpr_Documentousuarioalteracao_Z
      {
         get {
            return gxTv_SdtDocumento_Documentousuarioalteracao_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentousuarioalteracao_Z = value;
            SetDirty("Documentousuarioalteracao_Z");
         }

      }

      public void gxTv_SdtDocumento_Documentousuarioalteracao_Z_SetNull( )
      {
         gxTv_SdtDocumento_Documentousuarioalteracao_Z = "";
         SetDirty("Documentousuarioalteracao_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentousuarioalteracao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoIsOperador_Z" )]
      [  XmlElement( ElementName = "DocumentoIsOperador_Z"   )]
      public bool gxTpr_Documentoisoperador_Z
      {
         get {
            return gxTv_SdtDocumento_Documentoisoperador_Z ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentoisoperador_Z = value;
            SetDirty("Documentoisoperador_Z");
         }

      }

      public void gxTv_SdtDocumento_Documentoisoperador_Z_SetNull( )
      {
         gxTv_SdtDocumento_Documentoisoperador_Z = false;
         SetDirty("Documentoisoperador_Z");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentoisoperador_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoNome_N" )]
      [  XmlElement( ElementName = "DocumentoNome_N"   )]
      public short gxTpr_Documentonome_N
      {
         get {
            return gxTv_SdtDocumento_Documentonome_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentonome_N = value;
            SetDirty("Documentonome_N");
         }

      }

      public void gxTv_SdtDocumento_Documentonome_N_SetNull( )
      {
         gxTv_SdtDocumento_Documentonome_N = 0;
         SetDirty("Documentonome_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentonome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SubprocessoId_N" )]
      [  XmlElement( ElementName = "SubprocessoId_N"   )]
      public short gxTpr_Subprocessoid_N
      {
         get {
            return gxTv_SdtDocumento_Subprocessoid_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Subprocessoid_N = value;
            SetDirty("Subprocessoid_N");
         }

      }

      public void gxTv_SdtDocumento_Subprocessoid_N_SetNull( )
      {
         gxTv_SdtDocumento_Subprocessoid_N = 0;
         SetDirty("Subprocessoid_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Subprocessoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EncarregadoId_N" )]
      [  XmlElement( ElementName = "EncarregadoId_N"   )]
      public short gxTpr_Encarregadoid_N
      {
         get {
            return gxTv_SdtDocumento_Encarregadoid_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Encarregadoid_N = value;
            SetDirty("Encarregadoid_N");
         }

      }

      public void gxTv_SdtDocumento_Encarregadoid_N_SetNull( )
      {
         gxTv_SdtDocumento_Encarregadoid_N = 0;
         SetDirty("Encarregadoid_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Encarregadoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PersonaId_N" )]
      [  XmlElement( ElementName = "PersonaId_N"   )]
      public short gxTpr_Personaid_N
      {
         get {
            return gxTv_SdtDocumento_Personaid_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Personaid_N = value;
            SetDirty("Personaid_N");
         }

      }

      public void gxTv_SdtDocumento_Personaid_N_SetNull( )
      {
         gxTv_SdtDocumento_Personaid_N = 0;
         SetDirty("Personaid_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Personaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoFinalidadeTratamento_N" )]
      [  XmlElement( ElementName = "DocumentoFinalidadeTratamento_N"   )]
      public short gxTpr_Documentofinalidadetratamento_N
      {
         get {
            return gxTv_SdtDocumento_Documentofinalidadetratamento_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentofinalidadetratamento_N = value;
            SetDirty("Documentofinalidadetratamento_N");
         }

      }

      public void gxTv_SdtDocumento_Documentofinalidadetratamento_N_SetNull( )
      {
         gxTv_SdtDocumento_Documentofinalidadetratamento_N = 0;
         SetDirty("Documentofinalidadetratamento_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentofinalidadetratamento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoriaId_N" )]
      [  XmlElement( ElementName = "CategoriaId_N"   )]
      public short gxTpr_Categoriaid_N
      {
         get {
            return gxTv_SdtDocumento_Categoriaid_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Categoriaid_N = value;
            SetDirty("Categoriaid_N");
         }

      }

      public void gxTv_SdtDocumento_Categoriaid_N_SetNull( )
      {
         gxTv_SdtDocumento_Categoriaid_N = 0;
         SetDirty("Categoriaid_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Categoriaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoDadoId_N" )]
      [  XmlElement( ElementName = "TipoDadoId_N"   )]
      public short gxTpr_Tipodadoid_N
      {
         get {
            return gxTv_SdtDocumento_Tipodadoid_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Tipodadoid_N = value;
            SetDirty("Tipodadoid_N");
         }

      }

      public void gxTv_SdtDocumento_Tipodadoid_N_SetNull( )
      {
         gxTv_SdtDocumento_Tipodadoid_N = 0;
         SetDirty("Tipodadoid_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Tipodadoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FerramentaColetaId_N" )]
      [  XmlElement( ElementName = "FerramentaColetaId_N"   )]
      public short gxTpr_Ferramentacoletaid_N
      {
         get {
            return gxTv_SdtDocumento_Ferramentacoletaid_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Ferramentacoletaid_N = value;
            SetDirty("Ferramentacoletaid_N");
         }

      }

      public void gxTv_SdtDocumento_Ferramentacoletaid_N_SetNull( )
      {
         gxTv_SdtDocumento_Ferramentacoletaid_N = 0;
         SetDirty("Ferramentacoletaid_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Ferramentacoletaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AbrangenciaGeograficaId_N" )]
      [  XmlElement( ElementName = "AbrangenciaGeograficaId_N"   )]
      public short gxTpr_Abrangenciageograficaid_N
      {
         get {
            return gxTv_SdtDocumento_Abrangenciageograficaid_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Abrangenciageograficaid_N = value;
            SetDirty("Abrangenciageograficaid_N");
         }

      }

      public void gxTv_SdtDocumento_Abrangenciageograficaid_N_SetNull( )
      {
         gxTv_SdtDocumento_Abrangenciageograficaid_N = 0;
         SetDirty("Abrangenciageograficaid_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Abrangenciageograficaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FrequenciaTratamentoId_N" )]
      [  XmlElement( ElementName = "FrequenciaTratamentoId_N"   )]
      public short gxTpr_Frequenciatratamentoid_N
      {
         get {
            return gxTv_SdtDocumento_Frequenciatratamentoid_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Frequenciatratamentoid_N = value;
            SetDirty("Frequenciatratamentoid_N");
         }

      }

      public void gxTv_SdtDocumento_Frequenciatratamentoid_N_SetNull( )
      {
         gxTv_SdtDocumento_Frequenciatratamentoid_N = 0;
         SetDirty("Frequenciatratamentoid_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Frequenciatratamentoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoDescarteId_N" )]
      [  XmlElement( ElementName = "TipoDescarteId_N"   )]
      public short gxTpr_Tipodescarteid_N
      {
         get {
            return gxTv_SdtDocumento_Tipodescarteid_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Tipodescarteid_N = value;
            SetDirty("Tipodescarteid_N");
         }

      }

      public void gxTv_SdtDocumento_Tipodescarteid_N_SetNull( )
      {
         gxTv_SdtDocumento_Tipodescarteid_N = 0;
         SetDirty("Tipodescarteid_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Tipodescarteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TempoRetencaoId_N" )]
      [  XmlElement( ElementName = "TempoRetencaoId_N"   )]
      public short gxTpr_Temporetencaoid_N
      {
         get {
            return gxTv_SdtDocumento_Temporetencaoid_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Temporetencaoid_N = value;
            SetDirty("Temporetencaoid_N");
         }

      }

      public void gxTv_SdtDocumento_Temporetencaoid_N_SetNull( )
      {
         gxTv_SdtDocumento_Temporetencaoid_N = 0;
         SetDirty("Temporetencaoid_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Temporetencaoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoPrevColetaDados_N" )]
      [  XmlElement( ElementName = "DocumentoPrevColetaDados_N"   )]
      public short gxTpr_Documentoprevcoletadados_N
      {
         get {
            return gxTv_SdtDocumento_Documentoprevcoletadados_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentoprevcoletadados_N = value;
            SetDirty("Documentoprevcoletadados_N");
         }

      }

      public void gxTv_SdtDocumento_Documentoprevcoletadados_N_SetNull( )
      {
         gxTv_SdtDocumento_Documentoprevcoletadados_N = 0;
         SetDirty("Documentoprevcoletadados_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentoprevcoletadados_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoBaseLegalNorm_N" )]
      [  XmlElement( ElementName = "DocumentoBaseLegalNorm_N"   )]
      public short gxTpr_Documentobaselegalnorm_N
      {
         get {
            return gxTv_SdtDocumento_Documentobaselegalnorm_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentobaselegalnorm_N = value;
            SetDirty("Documentobaselegalnorm_N");
         }

      }

      public void gxTv_SdtDocumento_Documentobaselegalnorm_N_SetNull( )
      {
         gxTv_SdtDocumento_Documentobaselegalnorm_N = 0;
         SetDirty("Documentobaselegalnorm_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentobaselegalnorm_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoBaseLegalNormIntExt_N" )]
      [  XmlElement( ElementName = "DocumentoBaseLegalNormIntExt_N"   )]
      public short gxTpr_Documentobaselegalnormintext_N
      {
         get {
            return gxTv_SdtDocumento_Documentobaselegalnormintext_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentobaselegalnormintext_N = value;
            SetDirty("Documentobaselegalnormintext_N");
         }

      }

      public void gxTv_SdtDocumento_Documentobaselegalnormintext_N_SetNull( )
      {
         gxTv_SdtDocumento_Documentobaselegalnormintext_N = 0;
         SetDirty("Documentobaselegalnormintext_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentobaselegalnormintext_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoDadosCriancaAdolesc_N" )]
      [  XmlElement( ElementName = "DocumentoDadosCriancaAdolesc_N"   )]
      public short gxTpr_Documentodadoscriancaadolesc_N
      {
         get {
            return gxTv_SdtDocumento_Documentodadoscriancaadolesc_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentodadoscriancaadolesc_N = value;
            SetDirty("Documentodadoscriancaadolesc_N");
         }

      }

      public void gxTv_SdtDocumento_Documentodadoscriancaadolesc_N_SetNull( )
      {
         gxTv_SdtDocumento_Documentodadoscriancaadolesc_N = 0;
         SetDirty("Documentodadoscriancaadolesc_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentodadoscriancaadolesc_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoDadosGrupoVul_N" )]
      [  XmlElement( ElementName = "DocumentoDadosGrupoVul_N"   )]
      public short gxTpr_Documentodadosgrupovul_N
      {
         get {
            return gxTv_SdtDocumento_Documentodadosgrupovul_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentodadosgrupovul_N = value;
            SetDirty("Documentodadosgrupovul_N");
         }

      }

      public void gxTv_SdtDocumento_Documentodadosgrupovul_N_SetNull( )
      {
         gxTv_SdtDocumento_Documentodadosgrupovul_N = 0;
         SetDirty("Documentodadosgrupovul_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentodadosgrupovul_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoMedidaSegurancaDesc_N" )]
      [  XmlElement( ElementName = "DocumentoMedidaSegurancaDesc_N"   )]
      public short gxTpr_Documentomedidasegurancadesc_N
      {
         get {
            return gxTv_SdtDocumento_Documentomedidasegurancadesc_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentomedidasegurancadesc_N = value;
            SetDirty("Documentomedidasegurancadesc_N");
         }

      }

      public void gxTv_SdtDocumento_Documentomedidasegurancadesc_N_SetNull( )
      {
         gxTv_SdtDocumento_Documentomedidasegurancadesc_N = 0;
         SetDirty("Documentomedidasegurancadesc_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentomedidasegurancadesc_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoFluxoTratDadosDesc_N" )]
      [  XmlElement( ElementName = "DocumentoFluxoTratDadosDesc_N"   )]
      public short gxTpr_Documentofluxotratdadosdesc_N
      {
         get {
            return gxTv_SdtDocumento_Documentofluxotratdadosdesc_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentofluxotratdadosdesc_N = value;
            SetDirty("Documentofluxotratdadosdesc_N");
         }

      }

      public void gxTv_SdtDocumento_Documentofluxotratdadosdesc_N_SetNull( )
      {
         gxTv_SdtDocumento_Documentofluxotratdadosdesc_N = 0;
         SetDirty("Documentofluxotratdadosdesc_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentofluxotratdadosdesc_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoAtivo_N" )]
      [  XmlElement( ElementName = "DocumentoAtivo_N"   )]
      public short gxTpr_Documentoativo_N
      {
         get {
            return gxTv_SdtDocumento_Documentoativo_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentoativo_N = value;
            SetDirty("Documentoativo_N");
         }

      }

      public void gxTv_SdtDocumento_Documentoativo_N_SetNull( )
      {
         gxTv_SdtDocumento_Documentoativo_N = 0;
         SetDirty("Documentoativo_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentoativo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoOperador_N" )]
      [  XmlElement( ElementName = "DocumentoOperador_N"   )]
      public short gxTpr_Documentooperador_N
      {
         get {
            return gxTv_SdtDocumento_Documentooperador_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentooperador_N = value;
            SetDirty("Documentooperador_N");
         }

      }

      public void gxTv_SdtDocumento_Documentooperador_N_SetNull( )
      {
         gxTv_SdtDocumento_Documentooperador_N = 0;
         SetDirty("Documentooperador_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentooperador_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoProcessoId_N" )]
      [  XmlElement( ElementName = "DocumentoProcessoId_N"   )]
      public short gxTpr_Documentoprocessoid_N
      {
         get {
            return gxTv_SdtDocumento_Documentoprocessoid_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentoprocessoid_N = value;
            SetDirty("Documentoprocessoid_N");
         }

      }

      public void gxTv_SdtDocumento_Documentoprocessoid_N_SetNull( )
      {
         gxTv_SdtDocumento_Documentoprocessoid_N = 0;
         SetDirty("Documentoprocessoid_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentoprocessoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoDataInclusao_N" )]
      [  XmlElement( ElementName = "DocumentoDataInclusao_N"   )]
      public short gxTpr_Documentodatainclusao_N
      {
         get {
            return gxTv_SdtDocumento_Documentodatainclusao_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentodatainclusao_N = value;
            SetDirty("Documentodatainclusao_N");
         }

      }

      public void gxTv_SdtDocumento_Documentodatainclusao_N_SetNull( )
      {
         gxTv_SdtDocumento_Documentodatainclusao_N = 0;
         SetDirty("Documentodatainclusao_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentodatainclusao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoDataAlteracao_N" )]
      [  XmlElement( ElementName = "DocumentoDataAlteracao_N"   )]
      public short gxTpr_Documentodataalteracao_N
      {
         get {
            return gxTv_SdtDocumento_Documentodataalteracao_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentodataalteracao_N = value;
            SetDirty("Documentodataalteracao_N");
         }

      }

      public void gxTv_SdtDocumento_Documentodataalteracao_N_SetNull( )
      {
         gxTv_SdtDocumento_Documentodataalteracao_N = 0;
         SetDirty("Documentodataalteracao_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentodataalteracao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoControladorId_N" )]
      [  XmlElement( ElementName = "DocumentoControladorId_N"   )]
      public short gxTpr_Documentocontroladorid_N
      {
         get {
            return gxTv_SdtDocumento_Documentocontroladorid_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentocontroladorid_N = value;
            SetDirty("Documentocontroladorid_N");
         }

      }

      public void gxTv_SdtDocumento_Documentocontroladorid_N_SetNull( )
      {
         gxTv_SdtDocumento_Documentocontroladorid_N = 0;
         SetDirty("Documentocontroladorid_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentocontroladorid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AreaResponsavelId_N" )]
      [  XmlElement( ElementName = "AreaResponsavelId_N"   )]
      public short gxTpr_Arearesponsavelid_N
      {
         get {
            return gxTv_SdtDocumento_Arearesponsavelid_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Arearesponsavelid_N = value;
            SetDirty("Arearesponsavelid_N");
         }

      }

      public void gxTv_SdtDocumento_Arearesponsavelid_N_SetNull( )
      {
         gxTv_SdtDocumento_Arearesponsavelid_N = 0;
         SetDirty("Arearesponsavelid_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Arearesponsavelid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoUsuarioInclusao_N" )]
      [  XmlElement( ElementName = "DocumentoUsuarioInclusao_N"   )]
      public short gxTpr_Documentousuarioinclusao_N
      {
         get {
            return gxTv_SdtDocumento_Documentousuarioinclusao_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentousuarioinclusao_N = value;
            SetDirty("Documentousuarioinclusao_N");
         }

      }

      public void gxTv_SdtDocumento_Documentousuarioinclusao_N_SetNull( )
      {
         gxTv_SdtDocumento_Documentousuarioinclusao_N = 0;
         SetDirty("Documentousuarioinclusao_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentousuarioinclusao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoUsuarioAlteracao_N" )]
      [  XmlElement( ElementName = "DocumentoUsuarioAlteracao_N"   )]
      public short gxTpr_Documentousuarioalteracao_N
      {
         get {
            return gxTv_SdtDocumento_Documentousuarioalteracao_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentousuarioalteracao_N = value;
            SetDirty("Documentousuarioalteracao_N");
         }

      }

      public void gxTv_SdtDocumento_Documentousuarioalteracao_N_SetNull( )
      {
         gxTv_SdtDocumento_Documentousuarioalteracao_N = 0;
         SetDirty("Documentousuarioalteracao_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentousuarioalteracao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoIsOperador_N" )]
      [  XmlElement( ElementName = "DocumentoIsOperador_N"   )]
      public short gxTpr_Documentoisoperador_N
      {
         get {
            return gxTv_SdtDocumento_Documentoisoperador_N ;
         }

         set {
            gxTv_SdtDocumento_N = 0;
            gxTv_SdtDocumento_Documentoisoperador_N = value;
            SetDirty("Documentoisoperador_N");
         }

      }

      public void gxTv_SdtDocumento_Documentoisoperador_N_SetNull( )
      {
         gxTv_SdtDocumento_Documentoisoperador_N = 0;
         SetDirty("Documentoisoperador_N");
         return  ;
      }

      public bool gxTv_SdtDocumento_Documentoisoperador_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtDocumento_N = 1;
         gxTv_SdtDocumento_Documentonome = "";
         gxTv_SdtDocumento_Documentofinalidadetratamento = "";
         gxTv_SdtDocumento_Documentobaselegalnorm = "";
         gxTv_SdtDocumento_Documentobaselegalnormintext = "";
         gxTv_SdtDocumento_Documentomedidasegurancadesc = "";
         gxTv_SdtDocumento_Documentofluxotratdadosdesc = "";
         gxTv_SdtDocumento_Documentoprocessonome = "";
         gxTv_SdtDocumento_Documentodatainclusao = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumento_Documentodataalteracao = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumento_Documentousuarioinclusao = "";
         gxTv_SdtDocumento_Documentousuarioalteracao = "";
         gxTv_SdtDocumento_Mode = "";
         gxTv_SdtDocumento_Documentonome_Z = "";
         gxTv_SdtDocumento_Documentofinalidadetratamento_Z = "";
         gxTv_SdtDocumento_Documentobaselegalnorm_Z = "";
         gxTv_SdtDocumento_Documentobaselegalnormintext_Z = "";
         gxTv_SdtDocumento_Documentoprocessonome_Z = "";
         gxTv_SdtDocumento_Documentodatainclusao_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumento_Documentodataalteracao_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtDocumento_Documentousuarioinclusao_Z = "";
         gxTv_SdtDocumento_Documentousuarioalteracao_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "documento", "GeneXus.Programs.documento_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtDocumento_N ;
      }

      private short gxTv_SdtDocumento_N ;
      private short gxTv_SdtDocumento_Initialized ;
      private short gxTv_SdtDocumento_Documentonome_N ;
      private short gxTv_SdtDocumento_Subprocessoid_N ;
      private short gxTv_SdtDocumento_Encarregadoid_N ;
      private short gxTv_SdtDocumento_Personaid_N ;
      private short gxTv_SdtDocumento_Documentofinalidadetratamento_N ;
      private short gxTv_SdtDocumento_Categoriaid_N ;
      private short gxTv_SdtDocumento_Tipodadoid_N ;
      private short gxTv_SdtDocumento_Ferramentacoletaid_N ;
      private short gxTv_SdtDocumento_Abrangenciageograficaid_N ;
      private short gxTv_SdtDocumento_Frequenciatratamentoid_N ;
      private short gxTv_SdtDocumento_Tipodescarteid_N ;
      private short gxTv_SdtDocumento_Temporetencaoid_N ;
      private short gxTv_SdtDocumento_Documentoprevcoletadados_N ;
      private short gxTv_SdtDocumento_Documentobaselegalnorm_N ;
      private short gxTv_SdtDocumento_Documentobaselegalnormintext_N ;
      private short gxTv_SdtDocumento_Documentodadoscriancaadolesc_N ;
      private short gxTv_SdtDocumento_Documentodadosgrupovul_N ;
      private short gxTv_SdtDocumento_Documentomedidasegurancadesc_N ;
      private short gxTv_SdtDocumento_Documentofluxotratdadosdesc_N ;
      private short gxTv_SdtDocumento_Documentoativo_N ;
      private short gxTv_SdtDocumento_Documentooperador_N ;
      private short gxTv_SdtDocumento_Documentoprocessoid_N ;
      private short gxTv_SdtDocumento_Documentodatainclusao_N ;
      private short gxTv_SdtDocumento_Documentodataalteracao_N ;
      private short gxTv_SdtDocumento_Documentocontroladorid_N ;
      private short gxTv_SdtDocumento_Arearesponsavelid_N ;
      private short gxTv_SdtDocumento_Documentousuarioinclusao_N ;
      private short gxTv_SdtDocumento_Documentousuarioalteracao_N ;
      private short gxTv_SdtDocumento_Documentoisoperador_N ;
      private int gxTv_SdtDocumento_Documentoid ;
      private int gxTv_SdtDocumento_Subprocessoid ;
      private int gxTv_SdtDocumento_Encarregadoid ;
      private int gxTv_SdtDocumento_Personaid ;
      private int gxTv_SdtDocumento_Categoriaid ;
      private int gxTv_SdtDocumento_Tipodadoid ;
      private int gxTv_SdtDocumento_Ferramentacoletaid ;
      private int gxTv_SdtDocumento_Abrangenciageograficaid ;
      private int gxTv_SdtDocumento_Frequenciatratamentoid ;
      private int gxTv_SdtDocumento_Tipodescarteid ;
      private int gxTv_SdtDocumento_Temporetencaoid ;
      private int gxTv_SdtDocumento_Documentoprocessoid ;
      private int gxTv_SdtDocumento_Documentocontroladorid ;
      private int gxTv_SdtDocumento_Arearesponsavelid ;
      private int gxTv_SdtDocumento_Documentoid_Z ;
      private int gxTv_SdtDocumento_Subprocessoid_Z ;
      private int gxTv_SdtDocumento_Encarregadoid_Z ;
      private int gxTv_SdtDocumento_Personaid_Z ;
      private int gxTv_SdtDocumento_Categoriaid_Z ;
      private int gxTv_SdtDocumento_Tipodadoid_Z ;
      private int gxTv_SdtDocumento_Ferramentacoletaid_Z ;
      private int gxTv_SdtDocumento_Abrangenciageograficaid_Z ;
      private int gxTv_SdtDocumento_Frequenciatratamentoid_Z ;
      private int gxTv_SdtDocumento_Tipodescarteid_Z ;
      private int gxTv_SdtDocumento_Temporetencaoid_Z ;
      private int gxTv_SdtDocumento_Documentoprocessoid_Z ;
      private int gxTv_SdtDocumento_Documentocontroladorid_Z ;
      private int gxTv_SdtDocumento_Arearesponsavelid_Z ;
      private string gxTv_SdtDocumento_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtDocumento_Documentodatainclusao ;
      private DateTime gxTv_SdtDocumento_Documentodataalteracao ;
      private DateTime gxTv_SdtDocumento_Documentodatainclusao_Z ;
      private DateTime gxTv_SdtDocumento_Documentodataalteracao_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtDocumento_Documentoprevcoletadados ;
      private bool gxTv_SdtDocumento_Documentodadoscriancaadolesc ;
      private bool gxTv_SdtDocumento_Documentodadosgrupovul ;
      private bool gxTv_SdtDocumento_Documentoativo ;
      private bool gxTv_SdtDocumento_Documentooperador ;
      private bool gxTv_SdtDocumento_Documentoisoperador ;
      private bool gxTv_SdtDocumento_Documentoprevcoletadados_Z ;
      private bool gxTv_SdtDocumento_Documentodadoscriancaadolesc_Z ;
      private bool gxTv_SdtDocumento_Documentodadosgrupovul_Z ;
      private bool gxTv_SdtDocumento_Documentoativo_Z ;
      private bool gxTv_SdtDocumento_Documentooperador_Z ;
      private bool gxTv_SdtDocumento_Documentoisoperador_Z ;
      private string gxTv_SdtDocumento_Documentomedidasegurancadesc ;
      private string gxTv_SdtDocumento_Documentofluxotratdadosdesc ;
      private string gxTv_SdtDocumento_Documentonome ;
      private string gxTv_SdtDocumento_Documentofinalidadetratamento ;
      private string gxTv_SdtDocumento_Documentobaselegalnorm ;
      private string gxTv_SdtDocumento_Documentobaselegalnormintext ;
      private string gxTv_SdtDocumento_Documentoprocessonome ;
      private string gxTv_SdtDocumento_Documentousuarioinclusao ;
      private string gxTv_SdtDocumento_Documentousuarioalteracao ;
      private string gxTv_SdtDocumento_Documentonome_Z ;
      private string gxTv_SdtDocumento_Documentofinalidadetratamento_Z ;
      private string gxTv_SdtDocumento_Documentobaselegalnorm_Z ;
      private string gxTv_SdtDocumento_Documentobaselegalnormintext_Z ;
      private string gxTv_SdtDocumento_Documentoprocessonome_Z ;
      private string gxTv_SdtDocumento_Documentousuarioinclusao_Z ;
      private string gxTv_SdtDocumento_Documentousuarioalteracao_Z ;
   }

   [DataContract(Name = @"Documento", Namespace = "LGPD_Novo")]
   public class SdtDocumento_RESTInterface : GxGenericCollectionItem<SdtDocumento>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocumento_RESTInterface( ) : base()
      {
      }

      public SdtDocumento_RESTInterface( SdtDocumento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DocumentoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Documentoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Documentoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Documentoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "DocumentoNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Documentonome
      {
         get {
            return sdt.gxTpr_Documentonome ;
         }

         set {
            sdt.gxTpr_Documentonome = value;
         }

      }

      [DataMember( Name = "SubprocessoId" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Subprocessoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Subprocessoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Subprocessoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "EncarregadoId" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Encarregadoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Encarregadoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Encarregadoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "PersonaId" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Personaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Personaid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Personaid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "DocumentoFinalidadeTratamento" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Documentofinalidadetratamento
      {
         get {
            return sdt.gxTpr_Documentofinalidadetratamento ;
         }

         set {
            sdt.gxTpr_Documentofinalidadetratamento = value;
         }

      }

      [DataMember( Name = "CategoriaId" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Categoriaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Categoriaid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Categoriaid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "TipoDadoId" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Tipodadoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Tipodadoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Tipodadoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "FerramentaColetaId" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Ferramentacoletaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Ferramentacoletaid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Ferramentacoletaid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "AbrangenciaGeograficaId" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Abrangenciageograficaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Abrangenciageograficaid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Abrangenciageograficaid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "FrequenciaTratamentoId" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Frequenciatratamentoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Frequenciatratamentoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Frequenciatratamentoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "TipoDescarteId" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Tipodescarteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Tipodescarteid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Tipodescarteid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "TempoRetencaoId" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Temporetencaoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Temporetencaoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Temporetencaoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "DocumentoPrevColetaDados" , Order = 13 )]
      [GxSeudo()]
      public bool gxTpr_Documentoprevcoletadados
      {
         get {
            return sdt.gxTpr_Documentoprevcoletadados ;
         }

         set {
            sdt.gxTpr_Documentoprevcoletadados = value;
         }

      }

      [DataMember( Name = "DocumentoBaseLegalNorm" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Documentobaselegalnorm
      {
         get {
            return sdt.gxTpr_Documentobaselegalnorm ;
         }

         set {
            sdt.gxTpr_Documentobaselegalnorm = value;
         }

      }

      [DataMember( Name = "DocumentoBaseLegalNormIntExt" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Documentobaselegalnormintext
      {
         get {
            return sdt.gxTpr_Documentobaselegalnormintext ;
         }

         set {
            sdt.gxTpr_Documentobaselegalnormintext = value;
         }

      }

      [DataMember( Name = "DocumentoDadosCriancaAdolesc" , Order = 16 )]
      [GxSeudo()]
      public bool gxTpr_Documentodadoscriancaadolesc
      {
         get {
            return sdt.gxTpr_Documentodadoscriancaadolesc ;
         }

         set {
            sdt.gxTpr_Documentodadoscriancaadolesc = value;
         }

      }

      [DataMember( Name = "DocumentoDadosGrupoVul" , Order = 17 )]
      [GxSeudo()]
      public bool gxTpr_Documentodadosgrupovul
      {
         get {
            return sdt.gxTpr_Documentodadosgrupovul ;
         }

         set {
            sdt.gxTpr_Documentodadosgrupovul = value;
         }

      }

      [DataMember( Name = "DocumentoMedidaSegurancaDesc" , Order = 18 )]
      public string gxTpr_Documentomedidasegurancadesc
      {
         get {
            return sdt.gxTpr_Documentomedidasegurancadesc ;
         }

         set {
            sdt.gxTpr_Documentomedidasegurancadesc = value;
         }

      }

      [DataMember( Name = "DocumentoFluxoTratDadosDesc" , Order = 19 )]
      public string gxTpr_Documentofluxotratdadosdesc
      {
         get {
            return sdt.gxTpr_Documentofluxotratdadosdesc ;
         }

         set {
            sdt.gxTpr_Documentofluxotratdadosdesc = value;
         }

      }

      [DataMember( Name = "DocumentoAtivo" , Order = 20 )]
      [GxSeudo()]
      public bool gxTpr_Documentoativo
      {
         get {
            return sdt.gxTpr_Documentoativo ;
         }

         set {
            sdt.gxTpr_Documentoativo = value;
         }

      }

      [DataMember( Name = "DocumentoOperador" , Order = 21 )]
      [GxSeudo()]
      public bool gxTpr_Documentooperador
      {
         get {
            return sdt.gxTpr_Documentooperador ;
         }

         set {
            sdt.gxTpr_Documentooperador = value;
         }

      }

      [DataMember( Name = "DocumentoProcessoId" , Order = 22 )]
      [GxSeudo()]
      public string gxTpr_Documentoprocessoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Documentoprocessoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Documentoprocessoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "DocumentoProcessoNome" , Order = 23 )]
      [GxSeudo()]
      public string gxTpr_Documentoprocessonome
      {
         get {
            return sdt.gxTpr_Documentoprocessonome ;
         }

         set {
            sdt.gxTpr_Documentoprocessonome = value;
         }

      }

      [DataMember( Name = "DocumentoDataInclusao" , Order = 24 )]
      [GxSeudo()]
      public string gxTpr_Documentodatainclusao
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Documentodatainclusao) ;
         }

         set {
            sdt.gxTpr_Documentodatainclusao = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "DocumentoDataAlteracao" , Order = 25 )]
      [GxSeudo()]
      public string gxTpr_Documentodataalteracao
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Documentodataalteracao) ;
         }

         set {
            sdt.gxTpr_Documentodataalteracao = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "DocumentoControladorId" , Order = 26 )]
      [GxSeudo()]
      public string gxTpr_Documentocontroladorid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Documentocontroladorid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Documentocontroladorid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "AreaResponsavelId" , Order = 27 )]
      [GxSeudo()]
      public string gxTpr_Arearesponsavelid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Arearesponsavelid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Arearesponsavelid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "DocumentoUsuarioInclusao" , Order = 28 )]
      [GxSeudo()]
      public string gxTpr_Documentousuarioinclusao
      {
         get {
            return sdt.gxTpr_Documentousuarioinclusao ;
         }

         set {
            sdt.gxTpr_Documentousuarioinclusao = value;
         }

      }

      [DataMember( Name = "DocumentoUsuarioAlteracao" , Order = 29 )]
      [GxSeudo()]
      public string gxTpr_Documentousuarioalteracao
      {
         get {
            return sdt.gxTpr_Documentousuarioalteracao ;
         }

         set {
            sdt.gxTpr_Documentousuarioalteracao = value;
         }

      }

      [DataMember( Name = "DocumentoIsOperador" , Order = 30 )]
      [GxSeudo()]
      public bool gxTpr_Documentoisoperador
      {
         get {
            return sdt.gxTpr_Documentoisoperador ;
         }

         set {
            sdt.gxTpr_Documentoisoperador = value;
         }

      }

      public SdtDocumento sdt
      {
         get {
            return (SdtDocumento)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtDocumento() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 31 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Documento", Namespace = "LGPD_Novo")]
   public class SdtDocumento_RESTLInterface : GxGenericCollectionItem<SdtDocumento>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocumento_RESTLInterface( ) : base()
      {
      }

      public SdtDocumento_RESTLInterface( SdtDocumento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DocumentoNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Documentonome
      {
         get {
            return sdt.gxTpr_Documentonome ;
         }

         set {
            sdt.gxTpr_Documentonome = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtDocumento sdt
      {
         get {
            return (SdtDocumento)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtDocumento() ;
         }
      }

   }

}
