/*
				   File: type_SdtFiltrosDocumento_DocDicionario
			Description: DocDicionario
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
	[XmlRoot(ElementName="FiltrosDocumento.DocDicionario")]
	[XmlType(TypeName="FiltrosDocumento.DocDicionario" , Namespace="LGPD_Novo" )]
	[Serializable]
	public class SdtFiltrosDocumento_DocDicionario : GxUserType
	{
		public SdtFiltrosDocumento_DocDicionario( )
		{
			/* Constructor for serialization */
			gxTv_SdtFiltrosDocumento_DocDicionario_Tipotransfint = "";

			gxTv_SdtFiltrosDocumento_DocDicionario_Finalidadedicio = "";

		}

		public SdtFiltrosDocumento_DocDicionario(IGxContext context)
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
			AddObjectProperty("Informacao", gxTpr_Informacao, false);


			AddObjectProperty("DadoSensivel", gxTpr_Dadosensivel, false);


			AddObjectProperty("EliminarDado", gxTpr_Eliminardado, false);


			AddObjectProperty("HipoteseTratamento", gxTpr_Hipotesetratamento, false);


			AddObjectProperty("TransfInt", gxTpr_Transfint, false);


			AddObjectProperty("Pais", gxTpr_Pais, false);


			AddObjectProperty("TipoTransfInt", gxTpr_Tipotransfint, false);


			AddObjectProperty("FinalidadeDicio", gxTpr_Finalidadedicio, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Informacao")]
		[XmlElement(ElementName="Informacao")]
		public int gxTpr_Informacao
		{
			get {
				return gxTv_SdtFiltrosDocumento_DocDicionario_Informacao; 
			}
			set {
				gxTv_SdtFiltrosDocumento_DocDicionario_Informacao = value;
				SetDirty("Informacao");
			}
		}




		[SoapElement(ElementName="DadoSensivel")]
		[XmlElement(ElementName="DadoSensivel")]
		public bool gxTpr_Dadosensivel
		{
			get {
				return gxTv_SdtFiltrosDocumento_DocDicionario_Dadosensivel; 
			}
			set {
				gxTv_SdtFiltrosDocumento_DocDicionario_Dadosensivel = value;
				SetDirty("Dadosensivel");
			}
		}




		[SoapElement(ElementName="EliminarDado")]
		[XmlElement(ElementName="EliminarDado")]
		public bool gxTpr_Eliminardado
		{
			get {
				return gxTv_SdtFiltrosDocumento_DocDicionario_Eliminardado; 
			}
			set {
				gxTv_SdtFiltrosDocumento_DocDicionario_Eliminardado = value;
				SetDirty("Eliminardado");
			}
		}




		[SoapElement(ElementName="HipoteseTratamento")]
		[XmlElement(ElementName="HipoteseTratamento")]
		public int gxTpr_Hipotesetratamento
		{
			get {
				return gxTv_SdtFiltrosDocumento_DocDicionario_Hipotesetratamento; 
			}
			set {
				gxTv_SdtFiltrosDocumento_DocDicionario_Hipotesetratamento = value;
				SetDirty("Hipotesetratamento");
			}
		}




		[SoapElement(ElementName="TransfInt")]
		[XmlElement(ElementName="TransfInt")]
		public bool gxTpr_Transfint
		{
			get {
				return gxTv_SdtFiltrosDocumento_DocDicionario_Transfint; 
			}
			set {
				gxTv_SdtFiltrosDocumento_DocDicionario_Transfint = value;
				SetDirty("Transfint");
			}
		}




		[SoapElement(ElementName="Pais")]
		[XmlElement(ElementName="Pais")]
		public int gxTpr_Pais
		{
			get {
				return gxTv_SdtFiltrosDocumento_DocDicionario_Pais; 
			}
			set {
				gxTv_SdtFiltrosDocumento_DocDicionario_Pais = value;
				SetDirty("Pais");
			}
		}




		[SoapElement(ElementName="TipoTransfInt")]
		[XmlElement(ElementName="TipoTransfInt")]
		public string gxTpr_Tipotransfint
		{
			get {
				return gxTv_SdtFiltrosDocumento_DocDicionario_Tipotransfint; 
			}
			set {
				gxTv_SdtFiltrosDocumento_DocDicionario_Tipotransfint = value;
				SetDirty("Tipotransfint");
			}
		}




		[SoapElement(ElementName="FinalidadeDicio")]
		[XmlElement(ElementName="FinalidadeDicio")]
		public string gxTpr_Finalidadedicio
		{
			get {
				return gxTv_SdtFiltrosDocumento_DocDicionario_Finalidadedicio; 
			}
			set {
				gxTv_SdtFiltrosDocumento_DocDicionario_Finalidadedicio = value;
				SetDirty("Finalidadedicio");
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
			gxTv_SdtFiltrosDocumento_DocDicionario_Tipotransfint = "";
			gxTv_SdtFiltrosDocumento_DocDicionario_Finalidadedicio = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtFiltrosDocumento_DocDicionario_Informacao;
		 

		protected bool gxTv_SdtFiltrosDocumento_DocDicionario_Dadosensivel;
		 

		protected bool gxTv_SdtFiltrosDocumento_DocDicionario_Eliminardado;
		 

		protected int gxTv_SdtFiltrosDocumento_DocDicionario_Hipotesetratamento;
		 

		protected bool gxTv_SdtFiltrosDocumento_DocDicionario_Transfint;
		 

		protected int gxTv_SdtFiltrosDocumento_DocDicionario_Pais;
		 

		protected string gxTv_SdtFiltrosDocumento_DocDicionario_Tipotransfint;
		 

		protected string gxTv_SdtFiltrosDocumento_DocDicionario_Finalidadedicio;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"FiltrosDocumento.DocDicionario", Namespace="LGPD_Novo")]
	public class SdtFiltrosDocumento_DocDicionario_RESTInterface : GxGenericCollectionItem<SdtFiltrosDocumento_DocDicionario>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtFiltrosDocumento_DocDicionario_RESTInterface( ) : base()
		{	
		}

		public SdtFiltrosDocumento_DocDicionario_RESTInterface( SdtFiltrosDocumento_DocDicionario psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Informacao", Order=0)]
		public  string gxTpr_Informacao
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Informacao, 8, 0));

			}
			set { 
				sdt.gxTpr_Informacao = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="DadoSensivel", Order=1)]
		public bool gxTpr_Dadosensivel
		{
			get { 
				return sdt.gxTpr_Dadosensivel;

			}
			set { 
				sdt.gxTpr_Dadosensivel = value;
			}
		}

		[DataMember(Name="EliminarDado", Order=2)]
		public bool gxTpr_Eliminardado
		{
			get { 
				return sdt.gxTpr_Eliminardado;

			}
			set { 
				sdt.gxTpr_Eliminardado = value;
			}
		}

		[DataMember(Name="HipoteseTratamento", Order=3)]
		public  string gxTpr_Hipotesetratamento
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Hipotesetratamento, 8, 0));

			}
			set { 
				sdt.gxTpr_Hipotesetratamento = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TransfInt", Order=4)]
		public bool gxTpr_Transfint
		{
			get { 
				return sdt.gxTpr_Transfint;

			}
			set { 
				sdt.gxTpr_Transfint = value;
			}
		}

		[DataMember(Name="Pais", Order=5)]
		public  string gxTpr_Pais
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Pais, 8, 0));

			}
			set { 
				sdt.gxTpr_Pais = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TipoTransfInt", Order=6)]
		public  string gxTpr_Tipotransfint
		{
			get { 
				return sdt.gxTpr_Tipotransfint;

			}
			set { 
				 sdt.gxTpr_Tipotransfint = value;
			}
		}

		[DataMember(Name="FinalidadeDicio", Order=7)]
		public  string gxTpr_Finalidadedicio
		{
			get { 
				return sdt.gxTpr_Finalidadedicio;

			}
			set { 
				 sdt.gxTpr_Finalidadedicio = value;
			}
		}


		#endregion

		public SdtFiltrosDocumento_DocDicionario sdt
		{
			get { 
				return (SdtFiltrosDocumento_DocDicionario)Sdt;
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
				sdt = new SdtFiltrosDocumento_DocDicionario() ;
			}
		}
	}
	#endregion
}