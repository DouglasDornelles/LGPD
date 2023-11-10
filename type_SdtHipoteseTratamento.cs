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
   [XmlRoot(ElementName = "HipoteseTratamento" )]
   [XmlType(TypeName =  "HipoteseTratamento" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtHipoteseTratamento : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtHipoteseTratamento( )
      {
      }

      public SdtHipoteseTratamento( IGxContext context )
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

      public void Load( int AV72HipoteseTratamentoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV72HipoteseTratamentoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"HipoteseTratamentoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "HipoteseTratamento");
         metadata.Set("BT", "HipoteseTratamento");
         metadata.Set("PK", "[ \"HipoteseTratamentoId\" ]");
         metadata.Set("PKAssigned", "[ \"HipoteseTratamentoId\" ]");
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
         state.Add("gxTpr_Hipotesetratamentoid_Z");
         state.Add("gxTpr_Hipotesetratamentonome_Z");
         state.Add("gxTpr_Hipotesetratamentoativo_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtHipoteseTratamento sdt;
         sdt = (SdtHipoteseTratamento)(source);
         gxTv_SdtHipoteseTratamento_Hipotesetratamentoid = sdt.gxTv_SdtHipoteseTratamento_Hipotesetratamentoid ;
         gxTv_SdtHipoteseTratamento_Hipotesetratamentonome = sdt.gxTv_SdtHipoteseTratamento_Hipotesetratamentonome ;
         gxTv_SdtHipoteseTratamento_Hipotesetratamentoativo = sdt.gxTv_SdtHipoteseTratamento_Hipotesetratamentoativo ;
         gxTv_SdtHipoteseTratamento_Mode = sdt.gxTv_SdtHipoteseTratamento_Mode ;
         gxTv_SdtHipoteseTratamento_Initialized = sdt.gxTv_SdtHipoteseTratamento_Initialized ;
         gxTv_SdtHipoteseTratamento_Hipotesetratamentoid_Z = sdt.gxTv_SdtHipoteseTratamento_Hipotesetratamentoid_Z ;
         gxTv_SdtHipoteseTratamento_Hipotesetratamentonome_Z = sdt.gxTv_SdtHipoteseTratamento_Hipotesetratamentonome_Z ;
         gxTv_SdtHipoteseTratamento_Hipotesetratamentoativo_Z = sdt.gxTv_SdtHipoteseTratamento_Hipotesetratamentoativo_Z ;
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
         AddObjectProperty("HipoteseTratamentoId", gxTv_SdtHipoteseTratamento_Hipotesetratamentoid, false, includeNonInitialized);
         AddObjectProperty("HipoteseTratamentoNome", gxTv_SdtHipoteseTratamento_Hipotesetratamentonome, false, includeNonInitialized);
         AddObjectProperty("HipoteseTratamentoAtivo", gxTv_SdtHipoteseTratamento_Hipotesetratamentoativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtHipoteseTratamento_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtHipoteseTratamento_Initialized, false, includeNonInitialized);
            AddObjectProperty("HipoteseTratamentoId_Z", gxTv_SdtHipoteseTratamento_Hipotesetratamentoid_Z, false, includeNonInitialized);
            AddObjectProperty("HipoteseTratamentoNome_Z", gxTv_SdtHipoteseTratamento_Hipotesetratamentonome_Z, false, includeNonInitialized);
            AddObjectProperty("HipoteseTratamentoAtivo_Z", gxTv_SdtHipoteseTratamento_Hipotesetratamentoativo_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtHipoteseTratamento sdt )
      {
         if ( sdt.IsDirty("HipoteseTratamentoId") )
         {
            gxTv_SdtHipoteseTratamento_N = 0;
            gxTv_SdtHipoteseTratamento_Hipotesetratamentoid = sdt.gxTv_SdtHipoteseTratamento_Hipotesetratamentoid ;
         }
         if ( sdt.IsDirty("HipoteseTratamentoNome") )
         {
            gxTv_SdtHipoteseTratamento_N = 0;
            gxTv_SdtHipoteseTratamento_Hipotesetratamentonome = sdt.gxTv_SdtHipoteseTratamento_Hipotesetratamentonome ;
         }
         if ( sdt.IsDirty("HipoteseTratamentoAtivo") )
         {
            gxTv_SdtHipoteseTratamento_N = 0;
            gxTv_SdtHipoteseTratamento_Hipotesetratamentoativo = sdt.gxTv_SdtHipoteseTratamento_Hipotesetratamentoativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "HipoteseTratamentoId" )]
      [  XmlElement( ElementName = "HipoteseTratamentoId"   )]
      public int gxTpr_Hipotesetratamentoid
      {
         get {
            return gxTv_SdtHipoteseTratamento_Hipotesetratamentoid ;
         }

         set {
            gxTv_SdtHipoteseTratamento_N = 0;
            if ( gxTv_SdtHipoteseTratamento_Hipotesetratamentoid != value )
            {
               gxTv_SdtHipoteseTratamento_Mode = "INS";
               this.gxTv_SdtHipoteseTratamento_Hipotesetratamentoid_Z_SetNull( );
               this.gxTv_SdtHipoteseTratamento_Hipotesetratamentonome_Z_SetNull( );
               this.gxTv_SdtHipoteseTratamento_Hipotesetratamentoativo_Z_SetNull( );
            }
            gxTv_SdtHipoteseTratamento_Hipotesetratamentoid = value;
            SetDirty("Hipotesetratamentoid");
         }

      }

      [  SoapElement( ElementName = "HipoteseTratamentoNome" )]
      [  XmlElement( ElementName = "HipoteseTratamentoNome"   )]
      public string gxTpr_Hipotesetratamentonome
      {
         get {
            return gxTv_SdtHipoteseTratamento_Hipotesetratamentonome ;
         }

         set {
            gxTv_SdtHipoteseTratamento_N = 0;
            gxTv_SdtHipoteseTratamento_Hipotesetratamentonome = value;
            SetDirty("Hipotesetratamentonome");
         }

      }

      [  SoapElement( ElementName = "HipoteseTratamentoAtivo" )]
      [  XmlElement( ElementName = "HipoteseTratamentoAtivo"   )]
      public bool gxTpr_Hipotesetratamentoativo
      {
         get {
            return gxTv_SdtHipoteseTratamento_Hipotesetratamentoativo ;
         }

         set {
            gxTv_SdtHipoteseTratamento_N = 0;
            gxTv_SdtHipoteseTratamento_Hipotesetratamentoativo = value;
            SetDirty("Hipotesetratamentoativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtHipoteseTratamento_Mode ;
         }

         set {
            gxTv_SdtHipoteseTratamento_N = 0;
            gxTv_SdtHipoteseTratamento_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtHipoteseTratamento_Mode_SetNull( )
      {
         gxTv_SdtHipoteseTratamento_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtHipoteseTratamento_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtHipoteseTratamento_Initialized ;
         }

         set {
            gxTv_SdtHipoteseTratamento_N = 0;
            gxTv_SdtHipoteseTratamento_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtHipoteseTratamento_Initialized_SetNull( )
      {
         gxTv_SdtHipoteseTratamento_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtHipoteseTratamento_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "HipoteseTratamentoId_Z" )]
      [  XmlElement( ElementName = "HipoteseTratamentoId_Z"   )]
      public int gxTpr_Hipotesetratamentoid_Z
      {
         get {
            return gxTv_SdtHipoteseTratamento_Hipotesetratamentoid_Z ;
         }

         set {
            gxTv_SdtHipoteseTratamento_N = 0;
            gxTv_SdtHipoteseTratamento_Hipotesetratamentoid_Z = value;
            SetDirty("Hipotesetratamentoid_Z");
         }

      }

      public void gxTv_SdtHipoteseTratamento_Hipotesetratamentoid_Z_SetNull( )
      {
         gxTv_SdtHipoteseTratamento_Hipotesetratamentoid_Z = 0;
         SetDirty("Hipotesetratamentoid_Z");
         return  ;
      }

      public bool gxTv_SdtHipoteseTratamento_Hipotesetratamentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "HipoteseTratamentoNome_Z" )]
      [  XmlElement( ElementName = "HipoteseTratamentoNome_Z"   )]
      public string gxTpr_Hipotesetratamentonome_Z
      {
         get {
            return gxTv_SdtHipoteseTratamento_Hipotesetratamentonome_Z ;
         }

         set {
            gxTv_SdtHipoteseTratamento_N = 0;
            gxTv_SdtHipoteseTratamento_Hipotesetratamentonome_Z = value;
            SetDirty("Hipotesetratamentonome_Z");
         }

      }

      public void gxTv_SdtHipoteseTratamento_Hipotesetratamentonome_Z_SetNull( )
      {
         gxTv_SdtHipoteseTratamento_Hipotesetratamentonome_Z = "";
         SetDirty("Hipotesetratamentonome_Z");
         return  ;
      }

      public bool gxTv_SdtHipoteseTratamento_Hipotesetratamentonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "HipoteseTratamentoAtivo_Z" )]
      [  XmlElement( ElementName = "HipoteseTratamentoAtivo_Z"   )]
      public bool gxTpr_Hipotesetratamentoativo_Z
      {
         get {
            return gxTv_SdtHipoteseTratamento_Hipotesetratamentoativo_Z ;
         }

         set {
            gxTv_SdtHipoteseTratamento_N = 0;
            gxTv_SdtHipoteseTratamento_Hipotesetratamentoativo_Z = value;
            SetDirty("Hipotesetratamentoativo_Z");
         }

      }

      public void gxTv_SdtHipoteseTratamento_Hipotesetratamentoativo_Z_SetNull( )
      {
         gxTv_SdtHipoteseTratamento_Hipotesetratamentoativo_Z = false;
         SetDirty("Hipotesetratamentoativo_Z");
         return  ;
      }

      public bool gxTv_SdtHipoteseTratamento_Hipotesetratamentoativo_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtHipoteseTratamento_N = 1;
         gxTv_SdtHipoteseTratamento_Hipotesetratamentonome = "";
         gxTv_SdtHipoteseTratamento_Mode = "";
         gxTv_SdtHipoteseTratamento_Hipotesetratamentonome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "hipotesetratamento", "GeneXus.Programs.hipotesetratamento_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtHipoteseTratamento_N ;
      }

      private short gxTv_SdtHipoteseTratamento_N ;
      private short gxTv_SdtHipoteseTratamento_Initialized ;
      private int gxTv_SdtHipoteseTratamento_Hipotesetratamentoid ;
      private int gxTv_SdtHipoteseTratamento_Hipotesetratamentoid_Z ;
      private string gxTv_SdtHipoteseTratamento_Mode ;
      private bool gxTv_SdtHipoteseTratamento_Hipotesetratamentoativo ;
      private bool gxTv_SdtHipoteseTratamento_Hipotesetratamentoativo_Z ;
      private string gxTv_SdtHipoteseTratamento_Hipotesetratamentonome ;
      private string gxTv_SdtHipoteseTratamento_Hipotesetratamentonome_Z ;
   }

   [DataContract(Name = @"HipoteseTratamento", Namespace = "LGPD_Novo")]
   public class SdtHipoteseTratamento_RESTInterface : GxGenericCollectionItem<SdtHipoteseTratamento>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtHipoteseTratamento_RESTInterface( ) : base()
      {
      }

      public SdtHipoteseTratamento_RESTInterface( SdtHipoteseTratamento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "HipoteseTratamentoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Hipotesetratamentoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Hipotesetratamentoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Hipotesetratamentoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "HipoteseTratamentoNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Hipotesetratamentonome
      {
         get {
            return sdt.gxTpr_Hipotesetratamentonome ;
         }

         set {
            sdt.gxTpr_Hipotesetratamentonome = value;
         }

      }

      [DataMember( Name = "HipoteseTratamentoAtivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Hipotesetratamentoativo
      {
         get {
            return sdt.gxTpr_Hipotesetratamentoativo ;
         }

         set {
            sdt.gxTpr_Hipotesetratamentoativo = value;
         }

      }

      public SdtHipoteseTratamento sdt
      {
         get {
            return (SdtHipoteseTratamento)Sdt ;
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
            sdt = new SdtHipoteseTratamento() ;
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

   [DataContract(Name = @"HipoteseTratamento", Namespace = "LGPD_Novo")]
   public class SdtHipoteseTratamento_RESTLInterface : GxGenericCollectionItem<SdtHipoteseTratamento>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtHipoteseTratamento_RESTLInterface( ) : base()
      {
      }

      public SdtHipoteseTratamento_RESTLInterface( SdtHipoteseTratamento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "HipoteseTratamentoNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Hipotesetratamentonome
      {
         get {
            return sdt.gxTpr_Hipotesetratamentonome ;
         }

         set {
            sdt.gxTpr_Hipotesetratamentonome = value;
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

      public SdtHipoteseTratamento sdt
      {
         get {
            return (SdtHipoteseTratamento)Sdt ;
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
            sdt = new SdtHipoteseTratamento() ;
         }
      }

   }

}
