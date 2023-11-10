/*
				   File: type_SdtFckEditorMenu_FckEditorMenuItem
			Description: FckEditorMenu
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
	[XmlRoot(ElementName="FckEditorMenuItem")]
	[XmlType(TypeName="FckEditorMenuItem" , Namespace="LGPD_Novo" )]
	[Serializable]
	public class SdtFckEditorMenu_FckEditorMenuItem : GxUserType
	{
		public SdtFckEditorMenu_FckEditorMenuItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtFckEditorMenu_FckEditorMenuItem_Id = "";

			gxTv_SdtFckEditorMenu_FckEditorMenuItem_Description = "";

			gxTv_SdtFckEditorMenu_FckEditorMenuItem_Icon = "";

			gxTv_SdtFckEditorMenu_FckEditorMenuItem_Link = "";

		}

		public SdtFckEditorMenu_FckEditorMenuItem(IGxContext context)
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
			AddObjectProperty("Id", gxTpr_Id, false);


			AddObjectProperty("Description", gxTpr_Description, false);


			AddObjectProperty("Icon", gxTpr_Icon, false);


			AddObjectProperty("ObjectInterface", gxTpr_Objectinterface, false);


			AddObjectProperty("Link", gxTpr_Link, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public string gxTpr_Id
		{
			get {
				return gxTv_SdtFckEditorMenu_FckEditorMenuItem_Id; 
			}
			set {
				gxTv_SdtFckEditorMenu_FckEditorMenuItem_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Description")]
		[XmlElement(ElementName="Description")]
		public string gxTpr_Description
		{
			get {
				return gxTv_SdtFckEditorMenu_FckEditorMenuItem_Description; 
			}
			set {
				gxTv_SdtFckEditorMenu_FckEditorMenuItem_Description = value;
				SetDirty("Description");
			}
		}




		[SoapElement(ElementName="Icon")]
		[XmlElement(ElementName="Icon")]
		public string gxTpr_Icon
		{
			get {
				return gxTv_SdtFckEditorMenu_FckEditorMenuItem_Icon; 
			}
			set {
				gxTv_SdtFckEditorMenu_FckEditorMenuItem_Icon = value;
				SetDirty("Icon");
			}
		}




		[SoapElement(ElementName="ObjectInterface")]
		[XmlElement(ElementName="ObjectInterface")]
		public short gxTpr_Objectinterface
		{
			get {
				return gxTv_SdtFckEditorMenu_FckEditorMenuItem_Objectinterface; 
			}
			set {
				gxTv_SdtFckEditorMenu_FckEditorMenuItem_Objectinterface = value;
				SetDirty("Objectinterface");
			}
		}




		[SoapElement(ElementName="Link")]
		[XmlElement(ElementName="Link")]
		public string gxTpr_Link
		{
			get {
				return gxTv_SdtFckEditorMenu_FckEditorMenuItem_Link; 
			}
			set {
				gxTv_SdtFckEditorMenu_FckEditorMenuItem_Link = value;
				SetDirty("Link");
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
			gxTv_SdtFckEditorMenu_FckEditorMenuItem_Id = "";
			gxTv_SdtFckEditorMenu_FckEditorMenuItem_Description = "";
			gxTv_SdtFckEditorMenu_FckEditorMenuItem_Icon = "";

			gxTv_SdtFckEditorMenu_FckEditorMenuItem_Link = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtFckEditorMenu_FckEditorMenuItem_Id;
		 

		protected string gxTv_SdtFckEditorMenu_FckEditorMenuItem_Description;
		 

		protected string gxTv_SdtFckEditorMenu_FckEditorMenuItem_Icon;
		 

		protected short gxTv_SdtFckEditorMenu_FckEditorMenuItem_Objectinterface;
		 

		protected string gxTv_SdtFckEditorMenu_FckEditorMenuItem_Link;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"FckEditorMenuItem", Namespace="LGPD_Novo")]
	public class SdtFckEditorMenu_FckEditorMenuItem_RESTInterface : GxGenericCollectionItem<SdtFckEditorMenu_FckEditorMenuItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtFckEditorMenu_FckEditorMenuItem_RESTInterface( ) : base()
		{	
		}

		public SdtFckEditorMenu_FckEditorMenuItem_RESTInterface( SdtFckEditorMenu_FckEditorMenuItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Id);

			}
			set { 
				 sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="Description", Order=1)]
		public  string gxTpr_Description
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Description);

			}
			set { 
				 sdt.gxTpr_Description = value;
			}
		}

		[DataMember(Name="Icon", Order=2)]
		public  string gxTpr_Icon
		{
			get { 
				return sdt.gxTpr_Icon;

			}
			set { 
				 sdt.gxTpr_Icon = value;
			}
		}

		[DataMember(Name="ObjectInterface", Order=3)]
		public short gxTpr_Objectinterface
		{
			get { 
				return sdt.gxTpr_Objectinterface;

			}
			set { 
				sdt.gxTpr_Objectinterface = value;
			}
		}

		[DataMember(Name="Link", Order=4)]
		public  string gxTpr_Link
		{
			get { 
				return sdt.gxTpr_Link;

			}
			set { 
				 sdt.gxTpr_Link = value;
			}
		}


		#endregion

		public SdtFckEditorMenu_FckEditorMenuItem sdt
		{
			get { 
				return (SdtFckEditorMenu_FckEditorMenuItem)Sdt;
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
				sdt = new SdtFckEditorMenu_FckEditorMenuItem() ;
			}
		}
	}
	#endregion
}