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
   [XmlRoot(ElementName = "Pais" )]
   [XmlType(TypeName =  "Pais" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtPais : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPais( )
      {
      }

      public SdtPais( IGxContext context )
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

      public void Load( int AV4PaisId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV4PaisId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PaisId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Pais");
         metadata.Set("BT", "Pais");
         metadata.Set("PK", "[ \"PaisId\" ]");
         metadata.Set("PKAssigned", "[ \"PaisId\" ]");
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
         state.Add("gxTpr_Paisid_Z");
         state.Add("gxTpr_Paisnome_Z");
         state.Add("gxTpr_Paisativo_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPais sdt;
         sdt = (SdtPais)(source);
         gxTv_SdtPais_Paisid = sdt.gxTv_SdtPais_Paisid ;
         gxTv_SdtPais_Paisnome = sdt.gxTv_SdtPais_Paisnome ;
         gxTv_SdtPais_Paisativo = sdt.gxTv_SdtPais_Paisativo ;
         gxTv_SdtPais_Mode = sdt.gxTv_SdtPais_Mode ;
         gxTv_SdtPais_Initialized = sdt.gxTv_SdtPais_Initialized ;
         gxTv_SdtPais_Paisid_Z = sdt.gxTv_SdtPais_Paisid_Z ;
         gxTv_SdtPais_Paisnome_Z = sdt.gxTv_SdtPais_Paisnome_Z ;
         gxTv_SdtPais_Paisativo_Z = sdt.gxTv_SdtPais_Paisativo_Z ;
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
         AddObjectProperty("PaisId", gxTv_SdtPais_Paisid, false, includeNonInitialized);
         AddObjectProperty("PaisNome", gxTv_SdtPais_Paisnome, false, includeNonInitialized);
         AddObjectProperty("PaisAtivo", gxTv_SdtPais_Paisativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPais_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPais_Initialized, false, includeNonInitialized);
            AddObjectProperty("PaisId_Z", gxTv_SdtPais_Paisid_Z, false, includeNonInitialized);
            AddObjectProperty("PaisNome_Z", gxTv_SdtPais_Paisnome_Z, false, includeNonInitialized);
            AddObjectProperty("PaisAtivo_Z", gxTv_SdtPais_Paisativo_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPais sdt )
      {
         if ( sdt.IsDirty("PaisId") )
         {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisid = sdt.gxTv_SdtPais_Paisid ;
         }
         if ( sdt.IsDirty("PaisNome") )
         {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisnome = sdt.gxTv_SdtPais_Paisnome ;
         }
         if ( sdt.IsDirty("PaisAtivo") )
         {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisativo = sdt.gxTv_SdtPais_Paisativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PaisId" )]
      [  XmlElement( ElementName = "PaisId"   )]
      public int gxTpr_Paisid
      {
         get {
            return gxTv_SdtPais_Paisid ;
         }

         set {
            gxTv_SdtPais_N = 0;
            if ( gxTv_SdtPais_Paisid != value )
            {
               gxTv_SdtPais_Mode = "INS";
               this.gxTv_SdtPais_Paisid_Z_SetNull( );
               this.gxTv_SdtPais_Paisnome_Z_SetNull( );
               this.gxTv_SdtPais_Paisativo_Z_SetNull( );
            }
            gxTv_SdtPais_Paisid = value;
            SetDirty("Paisid");
         }

      }

      [  SoapElement( ElementName = "PaisNome" )]
      [  XmlElement( ElementName = "PaisNome"   )]
      public string gxTpr_Paisnome
      {
         get {
            return gxTv_SdtPais_Paisnome ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisnome = value;
            SetDirty("Paisnome");
         }

      }

      [  SoapElement( ElementName = "PaisAtivo" )]
      [  XmlElement( ElementName = "PaisAtivo"   )]
      public bool gxTpr_Paisativo
      {
         get {
            return gxTv_SdtPais_Paisativo ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisativo = value;
            SetDirty("Paisativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPais_Mode ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPais_Mode_SetNull( )
      {
         gxTv_SdtPais_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPais_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPais_Initialized ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPais_Initialized_SetNull( )
      {
         gxTv_SdtPais_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPais_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisId_Z" )]
      [  XmlElement( ElementName = "PaisId_Z"   )]
      public int gxTpr_Paisid_Z
      {
         get {
            return gxTv_SdtPais_Paisid_Z ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisid_Z = value;
            SetDirty("Paisid_Z");
         }

      }

      public void gxTv_SdtPais_Paisid_Z_SetNull( )
      {
         gxTv_SdtPais_Paisid_Z = 0;
         SetDirty("Paisid_Z");
         return  ;
      }

      public bool gxTv_SdtPais_Paisid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisNome_Z" )]
      [  XmlElement( ElementName = "PaisNome_Z"   )]
      public string gxTpr_Paisnome_Z
      {
         get {
            return gxTv_SdtPais_Paisnome_Z ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisnome_Z = value;
            SetDirty("Paisnome_Z");
         }

      }

      public void gxTv_SdtPais_Paisnome_Z_SetNull( )
      {
         gxTv_SdtPais_Paisnome_Z = "";
         SetDirty("Paisnome_Z");
         return  ;
      }

      public bool gxTv_SdtPais_Paisnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisAtivo_Z" )]
      [  XmlElement( ElementName = "PaisAtivo_Z"   )]
      public bool gxTpr_Paisativo_Z
      {
         get {
            return gxTv_SdtPais_Paisativo_Z ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisativo_Z = value;
            SetDirty("Paisativo_Z");
         }

      }

      public void gxTv_SdtPais_Paisativo_Z_SetNull( )
      {
         gxTv_SdtPais_Paisativo_Z = false;
         SetDirty("Paisativo_Z");
         return  ;
      }

      public bool gxTv_SdtPais_Paisativo_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtPais_N = 1;
         gxTv_SdtPais_Paisnome = "";
         gxTv_SdtPais_Mode = "";
         gxTv_SdtPais_Paisnome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "pais", "GeneXus.Programs.pais_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtPais_N ;
      }

      private short gxTv_SdtPais_N ;
      private short gxTv_SdtPais_Initialized ;
      private int gxTv_SdtPais_Paisid ;
      private int gxTv_SdtPais_Paisid_Z ;
      private string gxTv_SdtPais_Mode ;
      private bool gxTv_SdtPais_Paisativo ;
      private bool gxTv_SdtPais_Paisativo_Z ;
      private string gxTv_SdtPais_Paisnome ;
      private string gxTv_SdtPais_Paisnome_Z ;
   }

   [DataContract(Name = @"Pais", Namespace = "LGPD_Novo")]
   public class SdtPais_RESTInterface : GxGenericCollectionItem<SdtPais>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPais_RESTInterface( ) : base()
      {
      }

      public SdtPais_RESTInterface( SdtPais psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PaisId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Paisid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Paisid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Paisid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "PaisNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Paisnome
      {
         get {
            return sdt.gxTpr_Paisnome ;
         }

         set {
            sdt.gxTpr_Paisnome = value;
         }

      }

      [DataMember( Name = "PaisAtivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Paisativo
      {
         get {
            return sdt.gxTpr_Paisativo ;
         }

         set {
            sdt.gxTpr_Paisativo = value;
         }

      }

      public SdtPais sdt
      {
         get {
            return (SdtPais)Sdt ;
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
            sdt = new SdtPais() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 3 )]
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

   [DataContract(Name = @"Pais", Namespace = "LGPD_Novo")]
   public class SdtPais_RESTLInterface : GxGenericCollectionItem<SdtPais>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPais_RESTLInterface( ) : base()
      {
      }

      public SdtPais_RESTLInterface( SdtPais psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PaisNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Paisnome
      {
         get {
            return sdt.gxTpr_Paisnome ;
         }

         set {
            sdt.gxTpr_Paisnome = value;
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

      public SdtPais sdt
      {
         get {
            return (SdtPais)Sdt ;
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
            sdt = new SdtPais() ;
         }
      }

   }

}
