/*
				   File: type_SdtFiltrosDocumento
			Description: FiltrosDocumento
				 Author: Nemo 🐠 for C# version 17.0.11.163677
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Services.Protocols;


namespace GeneXus.Programs
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="FiltrosDocumento")]
	[XmlType(TypeName="FiltrosDocumento" , Namespace="LGPD_Novo" )]
	[Serializable]
	public class SdtFiltrosDocumento : GxUserType
	{
		public SdtFiltrosDocumento( )
		{
			/* Constructor for serialization */
			gxTv_SdtFiltrosDocumento_Nome = "";

			gxTv_SdtFiltrosDocumento_Finalidadetratamento = "";

			gxTv_SdtFiltrosDocumento_Baselegal = "";

			gxTv_SdtFiltrosDocumento_Baselegalextint = "";

		}

		public SdtFiltrosDocumento(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("Nome", gxTpr_Nome, false);


			AddObjectProperty("Processo", gxTpr_Processo, false);


			AddObjectProperty("SubProcesso", gxTpr_Subprocesso, false);


			AddObjectProperty("AreaResponsavel", gxTpr_Arearesponsavel, false);


			AddObjectProperty("Controlador", gxTpr_Controlador, false);


			AddObjectProperty("Encarregado", gxTpr_Encarregado, false);


			AddObjectProperty("Persona", gxTpr_Persona, false);


			AddObjectProperty("Situacao", gxTpr_Situacao, false);


			AddObjectProperty("FinalidadeTratamento", gxTpr_Finalidadetratamento, false);


			AddObjectProperty("Categoria", gxTpr_Categoria, false);


			AddObjectProperty("TipoDado", gxTpr_Tipodado, false);


			AddObjectProperty("FerramentaColeta", gxTpr_Ferramentacoleta, false);


			AddObjectProperty("AbrangenciaGeografica", gxTpr_Abrangenciageografica, false);


			AddObjectProperty("FrequenciaTratamento", gxTpr_Frequenciatratamento, false);


			AddObjectProperty("TipoDescarte", gxTpr_Tipodescarte, false);


			AddObjectProperty("TempoRetencao", gxTpr_Temporetencao, false);


			AddObjectProperty("PrevColetaDados", gxTpr_Prevcoletadados, false);


			AddObjectProperty("BaseLegal", gxTpr_Baselegal, false);


			AddObjectProperty("BaseLegalExtInt", gxTpr_Baselegalextint, false);


			AddObjectProperty("DadosGrupoVulneravel", gxTpr_Dadosgrupovulneravel, false);


			AddObjectProperty("DadosCriancaAdolescente", gxTpr_Dadoscriancaadolescente, false);


			AddObjectProperty("MedidaSeguranca", gxTpr_Medidaseguranca, false);


			AddObjectProperty("IsDocumento", gxTpr_Isdocumento, false);


			AddObjectProperty("IsTratamento", gxTpr_Istratamento, false);


			AddObjectProperty("IsDicionario", gxTpr_Isdicionario, false);


			AddObjectProperty("IsOperador", gxTpr_Isoperador, false);

			if (gxTv_SdtFiltrosDocumento_Docdicionario != null)
			{
				AddObjectProperty("DocDicionario", gxTv_SdtFiltrosDocumento_Docdicionario, false);
			}
			if (gxTv_SdtFiltrosDocumento_Docoperador != null)
			{
				AddObjectProperty("DocOperador", gxTv_SdtFiltrosDocumento_Docoperador, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Nome")]
		[XmlElement(ElementName="Nome")]
		public string gxTpr_Nome
		{
			get {
				return gxTv_SdtFiltrosDocumento_Nome; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Nome = value;
				SetDirty("Nome");
			}
		}




		[SoapElement(ElementName="Processo")]
		[XmlElement(ElementName="Processo")]
		public int gxTpr_Processo
		{
			get {
				return gxTv_SdtFiltrosDocumento_Processo; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Processo = value;
				SetDirty("Processo");
			}
		}




		[SoapElement(ElementName="SubProcesso")]
		[XmlElement(ElementName="SubProcesso")]
		public int gxTpr_Subprocesso
		{
			get {
				return gxTv_SdtFiltrosDocumento_Subprocesso; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Subprocesso = value;
				SetDirty("Subprocesso");
			}
		}




		[SoapElement(ElementName="AreaResponsavel")]
		[XmlElement(ElementName="AreaResponsavel")]
		public int gxTpr_Arearesponsavel
		{
			get {
				return gxTv_SdtFiltrosDocumento_Arearesponsavel; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Arearesponsavel = value;
				SetDirty("Arearesponsavel");
			}
		}




		[SoapElement(ElementName="Controlador")]
		[XmlElement(ElementName="Controlador")]
		public int gxTpr_Controlador
		{
			get {
				return gxTv_SdtFiltrosDocumento_Controlador; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Controlador = value;
				SetDirty("Controlador");
			}
		}




		[SoapElement(ElementName="Encarregado")]
		[XmlElement(ElementName="Encarregado")]
		public int gxTpr_Encarregado
		{
			get {
				return gxTv_SdtFiltrosDocumento_Encarregado; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Encarregado = value;
				SetDirty("Encarregado");
			}
		}




		[SoapElement(ElementName="Persona")]
		[XmlElement(ElementName="Persona")]
		public int gxTpr_Persona
		{
			get {
				return gxTv_SdtFiltrosDocumento_Persona; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Persona = value;
				SetDirty("Persona");
			}
		}




		[SoapElement(ElementName="Situacao")]
		[XmlElement(ElementName="Situacao")]
		public short gxTpr_Situacao
		{
			get {
				return gxTv_SdtFiltrosDocumento_Situacao; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Situacao = value;
				SetDirty("Situacao");
			}
		}




		[SoapElement(ElementName="FinalidadeTratamento")]
		[XmlElement(ElementName="FinalidadeTratamento")]
		public string gxTpr_Finalidadetratamento
		{
			get {
				return gxTv_SdtFiltrosDocumento_Finalidadetratamento; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Finalidadetratamento = value;
				SetDirty("Finalidadetratamento");
			}
		}




		[SoapElement(ElementName="Categoria")]
		[XmlElement(ElementName="Categoria")]
		public int gxTpr_Categoria
		{
			get {
				return gxTv_SdtFiltrosDocumento_Categoria; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Categoria = value;
				SetDirty("Categoria");
			}
		}




		[SoapElement(ElementName="TipoDado")]
		[XmlElement(ElementName="TipoDado")]
		public int gxTpr_Tipodado
		{
			get {
				return gxTv_SdtFiltrosDocumento_Tipodado; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Tipodado = value;
				SetDirty("Tipodado");
			}
		}




		[SoapElement(ElementName="FerramentaColeta")]
		[XmlElement(ElementName="FerramentaColeta")]
		public int gxTpr_Ferramentacoleta
		{
			get {
				return gxTv_SdtFiltrosDocumento_Ferramentacoleta; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Ferramentacoleta = value;
				SetDirty("Ferramentacoleta");
			}
		}




		[SoapElement(ElementName="AbrangenciaGeografica")]
		[XmlElement(ElementName="AbrangenciaGeografica")]
		public int gxTpr_Abrangenciageografica
		{
			get {
				return gxTv_SdtFiltrosDocumento_Abrangenciageografica; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Abrangenciageografica = value;
				SetDirty("Abrangenciageografica");
			}
		}




		[SoapElement(ElementName="FrequenciaTratamento")]
		[XmlElement(ElementName="FrequenciaTratamento")]
		public int gxTpr_Frequenciatratamento
		{
			get {
				return gxTv_SdtFiltrosDocumento_Frequenciatratamento; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Frequenciatratamento = value;
				SetDirty("Frequenciatratamento");
			}
		}




		[SoapElement(ElementName="TipoDescarte")]
		[XmlElement(ElementName="TipoDescarte")]
		public int gxTpr_Tipodescarte
		{
			get {
				return gxTv_SdtFiltrosDocumento_Tipodescarte; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Tipodescarte = value;
				SetDirty("Tipodescarte");
			}
		}




		[SoapElement(ElementName="TempoRetencao")]
		[XmlElement(ElementName="TempoRetencao")]
		public int gxTpr_Temporetencao
		{
			get {
				return gxTv_SdtFiltrosDocumento_Temporetencao; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Temporetencao = value;
				SetDirty("Temporetencao");
			}
		}




		[SoapElement(ElementName="PrevColetaDados")]
		[XmlElement(ElementName="PrevColetaDados")]
		public bool gxTpr_Prevcoletadados
		{
			get {
				return gxTv_SdtFiltrosDocumento_Prevcoletadados; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Prevcoletadados = value;
				SetDirty("Prevcoletadados");
			}
		}




		[SoapElement(ElementName="BaseLegal")]
		[XmlElement(ElementName="BaseLegal")]
		public string gxTpr_Baselegal
		{
			get {
				return gxTv_SdtFiltrosDocumento_Baselegal; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Baselegal = value;
				SetDirty("Baselegal");
			}
		}




		[SoapElement(ElementName="BaseLegalExtInt")]
		[XmlElement(ElementName="BaseLegalExtInt")]
		public string gxTpr_Baselegalextint
		{
			get {
				return gxTv_SdtFiltrosDocumento_Baselegalextint; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Baselegalextint = value;
				SetDirty("Baselegalextint");
			}
		}




		[SoapElement(ElementName="DadosGrupoVulneravel")]
		[XmlElement(ElementName="DadosGrupoVulneravel")]
		public bool gxTpr_Dadosgrupovulneravel
		{
			get {
				return gxTv_SdtFiltrosDocumento_Dadosgrupovulneravel; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Dadosgrupovulneravel = value;
				SetDirty("Dadosgrupovulneravel");
			}
		}




		[SoapElement(ElementName="DadosCriancaAdolescente")]
		[XmlElement(ElementName="DadosCriancaAdolescente")]
		public bool gxTpr_Dadoscriancaadolescente
		{
			get {
				return gxTv_SdtFiltrosDocumento_Dadoscriancaadolescente; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Dadoscriancaadolescente = value;
				SetDirty("Dadoscriancaadolescente");
			}
		}




		[SoapElement(ElementName="MedidaSeguranca")]
		[XmlElement(ElementName="MedidaSeguranca")]
		public int gxTpr_Medidaseguranca
		{
			get {
				return gxTv_SdtFiltrosDocumento_Medidaseguranca; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Medidaseguranca = value;
				SetDirty("Medidaseguranca");
			}
		}




		[SoapElement(ElementName="IsDocumento")]
		[XmlElement(ElementName="IsDocumento")]
		public bool gxTpr_Isdocumento
		{
			get {
				return gxTv_SdtFiltrosDocumento_Isdocumento; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Isdocumento = value;
				SetDirty("Isdocumento");
			}
		}




		[SoapElement(ElementName="IsTratamento")]
		[XmlElement(ElementName="IsTratamento")]
		public bool gxTpr_Istratamento
		{
			get {
				return gxTv_SdtFiltrosDocumento_Istratamento; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Istratamento = value;
				SetDirty("Istratamento");
			}
		}




		[SoapElement(ElementName="IsDicionario")]
		[XmlElement(ElementName="IsDicionario")]
		public bool gxTpr_Isdicionario
		{
			get {
				return gxTv_SdtFiltrosDocumento_Isdicionario; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Isdicionario = value;
				SetDirty("Isdicionario");
			}
		}




		[SoapElement(ElementName="IsOperador")]
		[XmlElement(ElementName="IsOperador")]
		public bool gxTpr_Isoperador
		{
			get {
				return gxTv_SdtFiltrosDocumento_Isoperador; 
			}
			set {
				gxTv_SdtFiltrosDocumento_Isoperador = value;
				SetDirty("Isoperador");
			}
		}



		[SoapElement(ElementName="DocDicionario" )]
		[XmlElement(ElementName="DocDicionario" )]
		public SdtFiltrosDocumento_DocDicionario gxTpr_Docdicionario
		{
			get {
				if ( gxTv_SdtFiltrosDocumento_Docdicionario == null )
				{
					gxTv_SdtFiltrosDocumento_Docdicionario = new SdtFiltrosDocumento_DocDicionario(context);
				}
				gxTv_SdtFiltrosDocumento_Docdicionario_N = false;
				return gxTv_SdtFiltrosDocumento_Docdicionario;
			}
			set {
				gxTv_SdtFiltrosDocumento_Docdicionario_N = false;
				gxTv_SdtFiltrosDocumento_Docdicionario = value;
				SetDirty("Docdicionario");
			}

		}

		public void gxTv_SdtFiltrosDocumento_Docdicionario_SetNull()
		{
			gxTv_SdtFiltrosDocumento_Docdicionario_N = true;
			gxTv_SdtFiltrosDocumento_Docdicionario = null;
		}

		public bool gxTv_SdtFiltrosDocumento_Docdicionario_IsNull()
		{
			return gxTv_SdtFiltrosDocumento_Docdicionario == null;
		}
		public bool ShouldSerializegxTpr_Docdicionario_Json()
		{
				return (gxTv_SdtFiltrosDocumento_Docdicionario != null && gxTv_SdtFiltrosDocumento_Docdicionario.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="DocOperador" )]
		[XmlElement(ElementName="DocOperador" )]
		public SdtFiltrosDocumento_DocOperador gxTpr_Docoperador
		{
			get {
				if ( gxTv_SdtFiltrosDocumento_Docoperador == null )
				{
					gxTv_SdtFiltrosDocumento_Docoperador = new SdtFiltrosDocumento_DocOperador(context);
				}
				gxTv_SdtFiltrosDocumento_Docoperador_N = false;
				return gxTv_SdtFiltrosDocumento_Docoperador;
			}
			set {
				gxTv_SdtFiltrosDocumento_Docoperador_N = false;
				gxTv_SdtFiltrosDocumento_Docoperador = value;
				SetDirty("Docoperador");
			}

		}

		public void gxTv_SdtFiltrosDocumento_Docoperador_SetNull()
		{
			gxTv_SdtFiltrosDocumento_Docoperador_N = true;
			gxTv_SdtFiltrosDocumento_Docoperador = null;
		}

		public bool gxTv_SdtFiltrosDocumento_Docoperador_IsNull()
		{
			return gxTv_SdtFiltrosDocumento_Docoperador == null;
		}
		public bool ShouldSerializegxTpr_Docoperador_Json()
		{
				return (gxTv_SdtFiltrosDocumento_Docoperador != null && gxTv_SdtFiltrosDocumento_Docoperador.ShouldSerializeSdtJson());

		}


		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtFiltrosDocumento_Nome = "";







			gxTv_SdtFiltrosDocumento_Finalidadetratamento = "";








			gxTv_SdtFiltrosDocumento_Baselegal = "";
			gxTv_SdtFiltrosDocumento_Baselegalextint = "";








			gxTv_SdtFiltrosDocumento_Docdicionario_N = true;


			gxTv_SdtFiltrosDocumento_Docoperador_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtFiltrosDocumento_Nome;
		 

		protected int gxTv_SdtFiltrosDocumento_Processo;
		 

		protected int gxTv_SdtFiltrosDocumento_Subprocesso;
		 

		protected int gxTv_SdtFiltrosDocumento_Arearesponsavel;
		 

		protected int gxTv_SdtFiltrosDocumento_Controlador;
		 

		protected int gxTv_SdtFiltrosDocumento_Encarregado;
		 

		protected int gxTv_SdtFiltrosDocumento_Persona;
		 

		protected short gxTv_SdtFiltrosDocumento_Situacao;
		 

		protected string gxTv_SdtFiltrosDocumento_Finalidadetratamento;
		 

		protected int gxTv_SdtFiltrosDocumento_Categoria;
		 

		protected int gxTv_SdtFiltrosDocumento_Tipodado;
		 

		protected int gxTv_SdtFiltrosDocumento_Ferramentacoleta;
		 

		protected int gxTv_SdtFiltrosDocumento_Abrangenciageografica;
		 

		protected int gxTv_SdtFiltrosDocumento_Frequenciatratamento;
		 

		protected int gxTv_SdtFiltrosDocumento_Tipodescarte;
		 

		protected int gxTv_SdtFiltrosDocumento_Temporetencao;
		 

		protected bool gxTv_SdtFiltrosDocumento_Prevcoletadados;
		 

		protected string gxTv_SdtFiltrosDocumento_Baselegal;
		 

		protected string gxTv_SdtFiltrosDocumento_Baselegalextint;
		 

		protected bool gxTv_SdtFiltrosDocumento_Dadosgrupovulneravel;
		 

		protected bool gxTv_SdtFiltrosDocumento_Dadoscriancaadolescente;
		 

		protected int gxTv_SdtFiltrosDocumento_Medidaseguranca;
		 

		protected bool gxTv_SdtFiltrosDocumento_Isdocumento;
		 

		protected bool gxTv_SdtFiltrosDocumento_Istratamento;
		 

		protected bool gxTv_SdtFiltrosDocumento_Isdicionario;
		 

		protected bool gxTv_SdtFiltrosDocumento_Isoperador;
		 
		protected bool gxTv_SdtFiltrosDocumento_Docdicionario_N;
		protected SdtFiltrosDocumento_DocDicionario gxTv_SdtFiltrosDocumento_Docdicionario = null; 

		protected bool gxTv_SdtFiltrosDocumento_Docoperador_N;
		protected SdtFiltrosDocumento_DocOperador gxTv_SdtFiltrosDocumento_Docoperador = null; 



		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"FiltrosDocumento", Namespace="LGPD_Novo")]
	public class SdtFiltrosDocumento_RESTInterface : GxGenericCollectionItem<SdtFiltrosDocumento>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtFiltrosDocumento_RESTInterface( ) : base()
		{	
		}

		public SdtFiltrosDocumento_RESTInterface( SdtFiltrosDocumento psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Nome", Order=0)]
		public  string gxTpr_Nome
		{
			get { 
				return sdt.gxTpr_Nome;

			}
			set { 
				 sdt.gxTpr_Nome = value;
			}
		}

		[DataMember(Name="Processo", Order=1)]
		public  string gxTpr_Processo
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Processo, 8, 0));

			}
			set { 
				sdt.gxTpr_Processo = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SubProcesso", Order=2)]
		public  string gxTpr_Subprocesso
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Subprocesso, 8, 0));

			}
			set { 
				sdt.gxTpr_Subprocesso = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="AreaResponsavel", Order=3)]
		public  string gxTpr_Arearesponsavel
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Arearesponsavel, 8, 0));

			}
			set { 
				sdt.gxTpr_Arearesponsavel = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Controlador", Order=4)]
		public  string gxTpr_Controlador
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Controlador, 8, 0));

			}
			set { 
				sdt.gxTpr_Controlador = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Encarregado", Order=5)]
		public  string gxTpr_Encarregado
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Encarregado, 8, 0));

			}
			set { 
				sdt.gxTpr_Encarregado = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Persona", Order=6)]
		public  string gxTpr_Persona
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Persona, 8, 0));

			}
			set { 
				sdt.gxTpr_Persona = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Situacao", Order=7)]
		public short gxTpr_Situacao
		{
			get { 
				return sdt.gxTpr_Situacao;

			}
			set { 
				sdt.gxTpr_Situacao = value;
			}
		}

		[DataMember(Name="FinalidadeTratamento", Order=8)]
		public  string gxTpr_Finalidadetratamento
		{
			get { 
				return sdt.gxTpr_Finalidadetratamento;

			}
			set { 
				 sdt.gxTpr_Finalidadetratamento = value;
			}
		}

		[DataMember(Name="Categoria", Order=9)]
		public  string gxTpr_Categoria
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Categoria, 8, 0));

			}
			set { 
				sdt.gxTpr_Categoria = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TipoDado", Order=10)]
		public  string gxTpr_Tipodado
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Tipodado, 8, 0));

			}
			set { 
				sdt.gxTpr_Tipodado = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FerramentaColeta", Order=11)]
		public  string gxTpr_Ferramentacoleta
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Ferramentacoleta, 8, 0));

			}
			set { 
				sdt.gxTpr_Ferramentacoleta = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="AbrangenciaGeografica", Order=12)]
		public  string gxTpr_Abrangenciageografica
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Abrangenciageografica, 8, 0));

			}
			set { 
				sdt.gxTpr_Abrangenciageografica = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FrequenciaTratamento", Order=13)]
		public  string gxTpr_Frequenciatratamento
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Frequenciatratamento, 8, 0));

			}
			set { 
				sdt.gxTpr_Frequenciatratamento = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TipoDescarte", Order=14)]
		public  string gxTpr_Tipodescarte
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Tipodescarte, 8, 0));

			}
			set { 
				sdt.gxTpr_Tipodescarte = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TempoRetencao", Order=15)]
		public  string gxTpr_Temporetencao
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Temporetencao, 8, 0));

			}
			set { 
				sdt.gxTpr_Temporetencao = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="PrevColetaDados", Order=16)]
		public bool gxTpr_Prevcoletadados
		{
			get { 
				return sdt.gxTpr_Prevcoletadados;

			}
			set { 
				sdt.gxTpr_Prevcoletadados = value;
			}
		}

		[DataMember(Name="BaseLegal", Order=17)]
		public  string gxTpr_Baselegal
		{
			get { 
				return sdt.gxTpr_Baselegal;

			}
			set { 
				 sdt.gxTpr_Baselegal = value;
			}
		}

		[DataMember(Name="BaseLegalExtInt", Order=18)]
		public  string gxTpr_Baselegalextint
		{
			get { 
				return sdt.gxTpr_Baselegalextint;

			}
			set { 
				 sdt.gxTpr_Baselegalextint = value;
			}
		}

		[DataMember(Name="DadosGrupoVulneravel", Order=19)]
		public bool gxTpr_Dadosgrupovulneravel
		{
			get { 
				return sdt.gxTpr_Dadosgrupovulneravel;

			}
			set { 
				sdt.gxTpr_Dadosgrupovulneravel = value;
			}
		}

		[DataMember(Name="DadosCriancaAdolescente", Order=20)]
		public bool gxTpr_Dadoscriancaadolescente
		{
			get { 
				return sdt.gxTpr_Dadoscriancaadolescente;

			}
			set { 
				sdt.gxTpr_Dadoscriancaadolescente = value;
			}
		}

		[DataMember(Name="MedidaSeguranca", Order=21)]
		public  string gxTpr_Medidaseguranca
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Medidaseguranca, 8, 0));

			}
			set { 
				sdt.gxTpr_Medidaseguranca = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="IsDocumento", Order=22)]
		public bool gxTpr_Isdocumento
		{
			get { 
				return sdt.gxTpr_Isdocumento;

			}
			set { 
				sdt.gxTpr_Isdocumento = value;
			}
		}

		[DataMember(Name="IsTratamento", Order=23)]
		public bool gxTpr_Istratamento
		{
			get { 
				return sdt.gxTpr_Istratamento;

			}
			set { 
				sdt.gxTpr_Istratamento = value;
			}
		}

		[DataMember(Name="IsDicionario", Order=24)]
		public bool gxTpr_Isdicionario
		{
			get { 
				return sdt.gxTpr_Isdicionario;

			}
			set { 
				sdt.gxTpr_Isdicionario = value;
			}
		}

		[DataMember(Name="IsOperador", Order=25)]
		public bool gxTpr_Isoperador
		{
			get { 
				return sdt.gxTpr_Isoperador;

			}
			set { 
				sdt.gxTpr_Isoperador = value;
			}
		}

		[DataMember(Name="DocDicionario", Order=26, EmitDefaultValue=false)]
		public SdtFiltrosDocumento_DocDicionario_RESTInterface gxTpr_Docdicionario
		{
			get {
				if (sdt.ShouldSerializegxTpr_Docdicionario_Json())
					return new SdtFiltrosDocumento_DocDicionario_RESTInterface(sdt.gxTpr_Docdicionario);
				else
					return null;

			}

			set {
				sdt.gxTpr_Docdicionario = value.sdt;
			}

		}

		[DataMember(Name="DocOperador", Order=27, EmitDefaultValue=false)]
		public SdtFiltrosDocumento_DocOperador_RESTInterface gxTpr_Docoperador
		{
			get {
				if (sdt.ShouldSerializegxTpr_Docoperador_Json())
					return new SdtFiltrosDocumento_DocOperador_RESTInterface(sdt.gxTpr_Docoperador);
				else
					return null;

			}

			set {
				sdt.gxTpr_Docoperador = value.sdt;
			}

		}


		#endregion

		public SdtFiltrosDocumento sdt
		{
			get { 
				return (SdtFiltrosDocumento)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtFiltrosDocumento() ;
			}
		}
	}
	#endregion
}