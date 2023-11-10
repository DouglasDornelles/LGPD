/*
				   File: type_SdtFiltrosDocumento_DocOperador
			Description: DocOperador
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
	[XmlRoot(ElementName="FiltrosDocumento.DocOperador")]
	[XmlType(TypeName="FiltrosDocumento.DocOperador" , Namespace="LGPD_Novo" )]
	[Serializable]
	public class SdtFiltrosDocumento_DocOperador : GxUserType
	{
		public SdtFiltrosDocumento_DocOperador( )
		{
			/* Constructor for serialization */
		}

		public SdtFiltrosDocumento_DocOperador(IGxContext context)
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
			AddObjectProperty("Operador", gxTpr_Operador, false);


			AddObjectProperty("OperadorCadastrado", gxTpr_Operadorcadastrado, false);


			AddObjectProperty("OperadorColeta", gxTpr_Operadorcoleta, false);


			AddObjectProperty("OperadorRetencao", gxTpr_Operadorretencao, false);


			AddObjectProperty("OperadorCompartilhamento", gxTpr_Operadorcompartilhamento, false);


			AddObjectProperty("OperadorEliminacao", gxTpr_Operadoreliminacao, false);


			AddObjectProperty("OperadorProcessamento", gxTpr_Operadorprocessamento, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Operador")]
		[XmlElement(ElementName="Operador")]
		public bool gxTpr_Operador
		{
			get {
				return gxTv_SdtFiltrosDocumento_DocOperador_Operador; 
			}
			set {
				gxTv_SdtFiltrosDocumento_DocOperador_Operador = value;
				SetDirty("Operador");
			}
		}




		[SoapElement(ElementName="OperadorCadastrado")]
		[XmlElement(ElementName="OperadorCadastrado")]
		public int gxTpr_Operadorcadastrado
		{
			get {
				return gxTv_SdtFiltrosDocumento_DocOperador_Operadorcadastrado; 
			}
			set {
				gxTv_SdtFiltrosDocumento_DocOperador_Operadorcadastrado = value;
				SetDirty("Operadorcadastrado");
			}
		}




		[SoapElement(ElementName="OperadorColeta")]
		[XmlElement(ElementName="OperadorColeta")]
		public bool gxTpr_Operadorcoleta
		{
			get {
				return gxTv_SdtFiltrosDocumento_DocOperador_Operadorcoleta; 
			}
			set {
				gxTv_SdtFiltrosDocumento_DocOperador_Operadorcoleta = value;
				SetDirty("Operadorcoleta");
			}
		}




		[SoapElement(ElementName="OperadorRetencao")]
		[XmlElement(ElementName="OperadorRetencao")]
		public bool gxTpr_Operadorretencao
		{
			get {
				return gxTv_SdtFiltrosDocumento_DocOperador_Operadorretencao; 
			}
			set {
				gxTv_SdtFiltrosDocumento_DocOperador_Operadorretencao = value;
				SetDirty("Operadorretencao");
			}
		}




		[SoapElement(ElementName="OperadorCompartilhamento")]
		[XmlElement(ElementName="OperadorCompartilhamento")]
		public bool gxTpr_Operadorcompartilhamento
		{
			get {
				return gxTv_SdtFiltrosDocumento_DocOperador_Operadorcompartilhamento; 
			}
			set {
				gxTv_SdtFiltrosDocumento_DocOperador_Operadorcompartilhamento = value;
				SetDirty("Operadorcompartilhamento");
			}
		}




		[SoapElement(ElementName="OperadorEliminacao")]
		[XmlElement(ElementName="OperadorEliminacao")]
		public bool gxTpr_Operadoreliminacao
		{
			get {
				return gxTv_SdtFiltrosDocumento_DocOperador_Operadoreliminacao; 
			}
			set {
				gxTv_SdtFiltrosDocumento_DocOperador_Operadoreliminacao = value;
				SetDirty("Operadoreliminacao");
			}
		}




		[SoapElement(ElementName="OperadorProcessamento")]
		[XmlElement(ElementName="OperadorProcessamento")]
		public bool gxTpr_Operadorprocessamento
		{
			get {
				return gxTv_SdtFiltrosDocumento_DocOperador_Operadorprocessamento; 
			}
			set {
				gxTv_SdtFiltrosDocumento_DocOperador_Operadorprocessamento = value;
				SetDirty("Operadorprocessamento");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtFiltrosDocumento_DocOperador_Operador;
		 

		protected int gxTv_SdtFiltrosDocumento_DocOperador_Operadorcadastrado;
		 

		protected bool gxTv_SdtFiltrosDocumento_DocOperador_Operadorcoleta;
		 

		protected bool gxTv_SdtFiltrosDocumento_DocOperador_Operadorretencao;
		 

		protected bool gxTv_SdtFiltrosDocumento_DocOperador_Operadorcompartilhamento;
		 

		protected bool gxTv_SdtFiltrosDocumento_DocOperador_Operadoreliminacao;
		 

		protected bool gxTv_SdtFiltrosDocumento_DocOperador_Operadorprocessamento;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"FiltrosDocumento.DocOperador", Namespace="LGPD_Novo")]
	public class SdtFiltrosDocumento_DocOperador_RESTInterface : GxGenericCollectionItem<SdtFiltrosDocumento_DocOperador>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtFiltrosDocumento_DocOperador_RESTInterface( ) : base()
		{	
		}

		public SdtFiltrosDocumento_DocOperador_RESTInterface( SdtFiltrosDocumento_DocOperador psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Operador", Order=0)]
		public bool gxTpr_Operador
		{
			get { 
				return sdt.gxTpr_Operador;

			}
			set { 
				sdt.gxTpr_Operador = value;
			}
		}

		[DataMember(Name="OperadorCadastrado", Order=1)]
		public  string gxTpr_Operadorcadastrado
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Operadorcadastrado, 8, 0));

			}
			set { 
				sdt.gxTpr_Operadorcadastrado = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="OperadorColeta", Order=2)]
		public bool gxTpr_Operadorcoleta
		{
			get { 
				return sdt.gxTpr_Operadorcoleta;

			}
			set { 
				sdt.gxTpr_Operadorcoleta = value;
			}
		}

		[DataMember(Name="OperadorRetencao", Order=3)]
		public bool gxTpr_Operadorretencao
		{
			get { 
				return sdt.gxTpr_Operadorretencao;

			}
			set { 
				sdt.gxTpr_Operadorretencao = value;
			}
		}

		[DataMember(Name="OperadorCompartilhamento", Order=4)]
		public bool gxTpr_Operadorcompartilhamento
		{
			get { 
				return sdt.gxTpr_Operadorcompartilhamento;

			}
			set { 
				sdt.gxTpr_Operadorcompartilhamento = value;
			}
		}

		[DataMember(Name="OperadorEliminacao", Order=5)]
		public bool gxTpr_Operadoreliminacao
		{
			get { 
				return sdt.gxTpr_Operadoreliminacao;

			}
			set { 
				sdt.gxTpr_Operadoreliminacao = value;
			}
		}

		[DataMember(Name="OperadorProcessamento", Order=6)]
		public bool gxTpr_Operadorprocessamento
		{
			get { 
				return sdt.gxTpr_Operadorprocessamento;

			}
			set { 
				sdt.gxTpr_Operadorprocessamento = value;
			}
		}


		#endregion

		public SdtFiltrosDocumento_DocOperador sdt
		{
			get { 
				return (SdtFiltrosDocumento_DocOperador)Sdt;
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
				sdt = new SdtFiltrosDocumento_DocOperador() ;
			}
		}
	}
	#endregion
}