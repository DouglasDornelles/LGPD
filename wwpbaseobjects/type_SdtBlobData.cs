/*
				   File: type_SdtBlobData
			Description: BlobData
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

using GeneXus.Programs;
namespace GeneXus.Programs.wwpbaseobjects
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="BlobData")]
	[XmlType(TypeName="BlobData" , Namespace="LGPD_Novo" )]
	[Serializable]
	public class SdtBlobData : GxUserType
	{
		public SdtBlobData( )
		{
			/* Constructor for serialization */
			gxTv_SdtBlobData_Path = "";

			gxTv_SdtBlobData_Filename = "";

			gxTv_SdtBlobData_Fileextension = "";

		}

		public SdtBlobData(IGxContext context)
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
			AddObjectProperty("path", gxTpr_Path, false);


			AddObjectProperty("filename", gxTpr_Filename, false);


			AddObjectProperty("fileextension", gxTpr_Fileextension, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="path")]
		[XmlElement(ElementName="path")]
		public string gxTpr_Path
		{
			get {
				return gxTv_SdtBlobData_Path; 
			}
			set {
				gxTv_SdtBlobData_Path = value;
				SetDirty("Path");
			}
		}




		[SoapElement(ElementName="filename")]
		[XmlElement(ElementName="filename")]
		public string gxTpr_Filename
		{
			get {
				return gxTv_SdtBlobData_Filename; 
			}
			set {
				gxTv_SdtBlobData_Filename = value;
				SetDirty("Filename");
			}
		}




		[SoapElement(ElementName="fileextension")]
		[XmlElement(ElementName="fileextension")]
		public string gxTpr_Fileextension
		{
			get {
				return gxTv_SdtBlobData_Fileextension; 
			}
			set {
				gxTv_SdtBlobData_Fileextension = value;
				SetDirty("Fileextension");
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
			gxTv_SdtBlobData_Path = "";
			gxTv_SdtBlobData_Filename = "";
			gxTv_SdtBlobData_Fileextension = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtBlobData_Path;
		 

		protected string gxTv_SdtBlobData_Filename;
		 

		protected string gxTv_SdtBlobData_Fileextension;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"BlobData", Namespace="LGPD_Novo")]
	public class SdtBlobData_RESTInterface : GxGenericCollectionItem<SdtBlobData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtBlobData_RESTInterface( ) : base()
		{	
		}

		public SdtBlobData_RESTInterface( SdtBlobData psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="path", Order=0)]
		public  string gxTpr_Path
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Path);

			}
			set { 
				 sdt.gxTpr_Path = value;
			}
		}

		[DataMember(Name="filename", Order=1)]
		public  string gxTpr_Filename
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Filename);

			}
			set { 
				 sdt.gxTpr_Filename = value;
			}
		}

		[DataMember(Name="fileextension", Order=2)]
		public  string gxTpr_Fileextension
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Fileextension);

			}
			set { 
				 sdt.gxTpr_Fileextension = value;
			}
		}


		#endregion

		public SdtBlobData sdt
		{
			get { 
				return (SdtBlobData)Sdt;
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
				sdt = new SdtBlobData() ;
			}
		}
	}
	#endregion
}