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
   [XmlRoot(ElementName = "FrequenciaTratamento" )]
   [XmlType(TypeName =  "FrequenciaTratamento" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtFrequenciaTratamento : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtFrequenciaTratamento( )
      {
      }

      public SdtFrequenciaTratamento( IGxContext context )
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

      public void Load( int AV39FrequenciaTratamentoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV39FrequenciaTratamentoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"FrequenciaTratamentoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "FrequenciaTratamento");
         metadata.Set("BT", "FrequenciaTratamento");
         metadata.Set("PK", "[ \"FrequenciaTratamentoId\" ]");
         metadata.Set("PKAssigned", "[ \"FrequenciaTratamentoId\" ]");
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
         state.Add("gxTpr_Frequenciatratamentoid_Z");
         state.Add("gxTpr_Frequenciatratamentonome_Z");
         state.Add("gxTpr_Frequenciatratamentoativo_Z");
         state.Add("gxTpr_Frequenciatratamentoid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtFrequenciaTratamento sdt;
         sdt = (SdtFrequenciaTratamento)(source);
         gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid = sdt.gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid ;
         gxTv_SdtFrequenciaTratamento_Frequenciatratamentonome = sdt.gxTv_SdtFrequenciaTratamento_Frequenciatratamentonome ;
         gxTv_SdtFrequenciaTratamento_Frequenciatratamentoativo = sdt.gxTv_SdtFrequenciaTratamento_Frequenciatratamentoativo ;
         gxTv_SdtFrequenciaTratamento_Mode = sdt.gxTv_SdtFrequenciaTratamento_Mode ;
         gxTv_SdtFrequenciaTratamento_Initialized = sdt.gxTv_SdtFrequenciaTratamento_Initialized ;
         gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid_Z = sdt.gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid_Z ;
         gxTv_SdtFrequenciaTratamento_Frequenciatratamentonome_Z = sdt.gxTv_SdtFrequenciaTratamento_Frequenciatratamentonome_Z ;
         gxTv_SdtFrequenciaTratamento_Frequenciatratamentoativo_Z = sdt.gxTv_SdtFrequenciaTratamento_Frequenciatratamentoativo_Z ;
         gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid_N = sdt.gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid_N ;
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
         AddObjectProperty("FrequenciaTratamentoId", gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid, false, includeNonInitialized);
         AddObjectProperty("FrequenciaTratamentoId_N", gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid_N, false, includeNonInitialized);
         AddObjectProperty("FrequenciaTratamentoNome", gxTv_SdtFrequenciaTratamento_Frequenciatratamentonome, false, includeNonInitialized);
         AddObjectProperty("FrequenciaTratamentoAtivo", gxTv_SdtFrequenciaTratamento_Frequenciatratamentoativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtFrequenciaTratamento_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtFrequenciaTratamento_Initialized, false, includeNonInitialized);
            AddObjectProperty("FrequenciaTratamentoId_Z", gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid_Z, false, includeNonInitialized);
            AddObjectProperty("FrequenciaTratamentoNome_Z", gxTv_SdtFrequenciaTratamento_Frequenciatratamentonome_Z, false, includeNonInitialized);
            AddObjectProperty("FrequenciaTratamentoAtivo_Z", gxTv_SdtFrequenciaTratamento_Frequenciatratamentoativo_Z, false, includeNonInitialized);
            AddObjectProperty("FrequenciaTratamentoId_N", gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtFrequenciaTratamento sdt )
      {
         if ( sdt.IsDirty("FrequenciaTratamentoId") )
         {
            gxTv_SdtFrequenciaTratamento_N = 0;
            gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid = sdt.gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid ;
         }
         if ( sdt.IsDirty("FrequenciaTratamentoNome") )
         {
            gxTv_SdtFrequenciaTratamento_N = 0;
            gxTv_SdtFrequenciaTratamento_Frequenciatratamentonome = sdt.gxTv_SdtFrequenciaTratamento_Frequenciatratamentonome ;
         }
         if ( sdt.IsDirty("FrequenciaTratamentoAtivo") )
         {
            gxTv_SdtFrequenciaTratamento_N = 0;
            gxTv_SdtFrequenciaTratamento_Frequenciatratamentoativo = sdt.gxTv_SdtFrequenciaTratamento_Frequenciatratamentoativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "FrequenciaTratamentoId" )]
      [  XmlElement( ElementName = "FrequenciaTratamentoId"   )]
      public int gxTpr_Frequenciatratamentoid
      {
         get {
            return gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid ;
         }

         set {
            gxTv_SdtFrequenciaTratamento_N = 0;
            if ( gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid != value )
            {
               gxTv_SdtFrequenciaTratamento_Mode = "INS";
               this.gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid_Z_SetNull( );
               this.gxTv_SdtFrequenciaTratamento_Frequenciatratamentonome_Z_SetNull( );
               this.gxTv_SdtFrequenciaTratamento_Frequenciatratamentoativo_Z_SetNull( );
            }
            gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid = value;
            SetDirty("Frequenciatratamentoid");
         }

      }

      [  SoapElement( ElementName = "FrequenciaTratamentoNome" )]
      [  XmlElement( ElementName = "FrequenciaTratamentoNome"   )]
      public string gxTpr_Frequenciatratamentonome
      {
         get {
            return gxTv_SdtFrequenciaTratamento_Frequenciatratamentonome ;
         }

         set {
            gxTv_SdtFrequenciaTratamento_N = 0;
            gxTv_SdtFrequenciaTratamento_Frequenciatratamentonome = value;
            SetDirty("Frequenciatratamentonome");
         }

      }

      [  SoapElement( ElementName = "FrequenciaTratamentoAtivo" )]
      [  XmlElement( ElementName = "FrequenciaTratamentoAtivo"   )]
      public bool gxTpr_Frequenciatratamentoativo
      {
         get {
            return gxTv_SdtFrequenciaTratamento_Frequenciatratamentoativo ;
         }

         set {
            gxTv_SdtFrequenciaTratamento_N = 0;
            gxTv_SdtFrequenciaTratamento_Frequenciatratamentoativo = value;
            SetDirty("Frequenciatratamentoativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtFrequenciaTratamento_Mode ;
         }

         set {
            gxTv_SdtFrequenciaTratamento_N = 0;
            gxTv_SdtFrequenciaTratamento_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtFrequenciaTratamento_Mode_SetNull( )
      {
         gxTv_SdtFrequenciaTratamento_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtFrequenciaTratamento_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtFrequenciaTratamento_Initialized ;
         }

         set {
            gxTv_SdtFrequenciaTratamento_N = 0;
            gxTv_SdtFrequenciaTratamento_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtFrequenciaTratamento_Initialized_SetNull( )
      {
         gxTv_SdtFrequenciaTratamento_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtFrequenciaTratamento_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FrequenciaTratamentoId_Z" )]
      [  XmlElement( ElementName = "FrequenciaTratamentoId_Z"   )]
      public int gxTpr_Frequenciatratamentoid_Z
      {
         get {
            return gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid_Z ;
         }

         set {
            gxTv_SdtFrequenciaTratamento_N = 0;
            gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid_Z = value;
            SetDirty("Frequenciatratamentoid_Z");
         }

      }

      public void gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid_Z_SetNull( )
      {
         gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid_Z = 0;
         SetDirty("Frequenciatratamentoid_Z");
         return  ;
      }

      public bool gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FrequenciaTratamentoNome_Z" )]
      [  XmlElement( ElementName = "FrequenciaTratamentoNome_Z"   )]
      public string gxTpr_Frequenciatratamentonome_Z
      {
         get {
            return gxTv_SdtFrequenciaTratamento_Frequenciatratamentonome_Z ;
         }

         set {
            gxTv_SdtFrequenciaTratamento_N = 0;
            gxTv_SdtFrequenciaTratamento_Frequenciatratamentonome_Z = value;
            SetDirty("Frequenciatratamentonome_Z");
         }

      }

      public void gxTv_SdtFrequenciaTratamento_Frequenciatratamentonome_Z_SetNull( )
      {
         gxTv_SdtFrequenciaTratamento_Frequenciatratamentonome_Z = "";
         SetDirty("Frequenciatratamentonome_Z");
         return  ;
      }

      public bool gxTv_SdtFrequenciaTratamento_Frequenciatratamentonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FrequenciaTratamentoAtivo_Z" )]
      [  XmlElement( ElementName = "FrequenciaTratamentoAtivo_Z"   )]
      public bool gxTpr_Frequenciatratamentoativo_Z
      {
         get {
            return gxTv_SdtFrequenciaTratamento_Frequenciatratamentoativo_Z ;
         }

         set {
            gxTv_SdtFrequenciaTratamento_N = 0;
            gxTv_SdtFrequenciaTratamento_Frequenciatratamentoativo_Z = value;
            SetDirty("Frequenciatratamentoativo_Z");
         }

      }

      public void gxTv_SdtFrequenciaTratamento_Frequenciatratamentoativo_Z_SetNull( )
      {
         gxTv_SdtFrequenciaTratamento_Frequenciatratamentoativo_Z = false;
         SetDirty("Frequenciatratamentoativo_Z");
         return  ;
      }

      public bool gxTv_SdtFrequenciaTratamento_Frequenciatratamentoativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FrequenciaTratamentoId_N" )]
      [  XmlElement( ElementName = "FrequenciaTratamentoId_N"   )]
      public short gxTpr_Frequenciatratamentoid_N
      {
         get {
            return gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid_N ;
         }

         set {
            gxTv_SdtFrequenciaTratamento_N = 0;
            gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid_N = value;
            SetDirty("Frequenciatratamentoid_N");
         }

      }

      public void gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid_N_SetNull( )
      {
         gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid_N = 0;
         SetDirty("Frequenciatratamentoid_N");
         return  ;
      }

      public bool gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtFrequenciaTratamento_N = 1;
         gxTv_SdtFrequenciaTratamento_Frequenciatratamentonome = "";
         gxTv_SdtFrequenciaTratamento_Mode = "";
         gxTv_SdtFrequenciaTratamento_Frequenciatratamentonome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "frequenciatratamento", "GeneXus.Programs.frequenciatratamento_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtFrequenciaTratamento_N ;
      }

      private short gxTv_SdtFrequenciaTratamento_N ;
      private short gxTv_SdtFrequenciaTratamento_Initialized ;
      private short gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid_N ;
      private int gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid ;
      private int gxTv_SdtFrequenciaTratamento_Frequenciatratamentoid_Z ;
      private string gxTv_SdtFrequenciaTratamento_Mode ;
      private bool gxTv_SdtFrequenciaTratamento_Frequenciatratamentoativo ;
      private bool gxTv_SdtFrequenciaTratamento_Frequenciatratamentoativo_Z ;
      private string gxTv_SdtFrequenciaTratamento_Frequenciatratamentonome ;
      private string gxTv_SdtFrequenciaTratamento_Frequenciatratamentonome_Z ;
   }

   [DataContract(Name = @"FrequenciaTratamento", Namespace = "LGPD_Novo")]
   public class SdtFrequenciaTratamento_RESTInterface : GxGenericCollectionItem<SdtFrequenciaTratamento>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtFrequenciaTratamento_RESTInterface( ) : base()
      {
      }

      public SdtFrequenciaTratamento_RESTInterface( SdtFrequenciaTratamento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "FrequenciaTratamentoId" , Order = 0 )]
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

      [DataMember( Name = "FrequenciaTratamentoNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Frequenciatratamentonome
      {
         get {
            return sdt.gxTpr_Frequenciatratamentonome ;
         }

         set {
            sdt.gxTpr_Frequenciatratamentonome = value;
         }

      }

      [DataMember( Name = "FrequenciaTratamentoAtivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Frequenciatratamentoativo
      {
         get {
            return sdt.gxTpr_Frequenciatratamentoativo ;
         }

         set {
            sdt.gxTpr_Frequenciatratamentoativo = value;
         }

      }

      public SdtFrequenciaTratamento sdt
      {
         get {
            return (SdtFrequenciaTratamento)Sdt ;
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
            sdt = new SdtFrequenciaTratamento() ;
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

   [DataContract(Name = @"FrequenciaTratamento", Namespace = "LGPD_Novo")]
   public class SdtFrequenciaTratamento_RESTLInterface : GxGenericCollectionItem<SdtFrequenciaTratamento>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtFrequenciaTratamento_RESTLInterface( ) : base()
      {
      }

      public SdtFrequenciaTratamento_RESTLInterface( SdtFrequenciaTratamento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "FrequenciaTratamentoNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Frequenciatratamentonome
      {
         get {
            return sdt.gxTpr_Frequenciatratamentonome ;
         }

         set {
            sdt.gxTpr_Frequenciatratamentonome = value;
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

      public SdtFrequenciaTratamento sdt
      {
         get {
            return (SdtFrequenciaTratamento)Sdt ;
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
            sdt = new SdtFrequenciaTratamento() ;
         }
      }

   }

}
