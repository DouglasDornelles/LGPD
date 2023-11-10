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
   [XmlRoot(ElementName = "Informacao" )]
   [XmlType(TypeName =  "Informacao" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtInformacao : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtInformacao( )
      {
      }

      public SdtInformacao( IGxContext context )
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

      public void Load( int AV69InformacaoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV69InformacaoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"InformacaoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Informacao");
         metadata.Set("BT", "Informacao");
         metadata.Set("PK", "[ \"InformacaoId\" ]");
         metadata.Set("PKAssigned", "[ \"InformacaoId\" ]");
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
         state.Add("gxTpr_Informacaoid_Z");
         state.Add("gxTpr_Informacaonome_Z");
         state.Add("gxTpr_Informacaoativo_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtInformacao sdt;
         sdt = (SdtInformacao)(source);
         gxTv_SdtInformacao_Informacaoid = sdt.gxTv_SdtInformacao_Informacaoid ;
         gxTv_SdtInformacao_Informacaonome = sdt.gxTv_SdtInformacao_Informacaonome ;
         gxTv_SdtInformacao_Informacaoativo = sdt.gxTv_SdtInformacao_Informacaoativo ;
         gxTv_SdtInformacao_Mode = sdt.gxTv_SdtInformacao_Mode ;
         gxTv_SdtInformacao_Initialized = sdt.gxTv_SdtInformacao_Initialized ;
         gxTv_SdtInformacao_Informacaoid_Z = sdt.gxTv_SdtInformacao_Informacaoid_Z ;
         gxTv_SdtInformacao_Informacaonome_Z = sdt.gxTv_SdtInformacao_Informacaonome_Z ;
         gxTv_SdtInformacao_Informacaoativo_Z = sdt.gxTv_SdtInformacao_Informacaoativo_Z ;
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
         AddObjectProperty("InformacaoId", gxTv_SdtInformacao_Informacaoid, false, includeNonInitialized);
         AddObjectProperty("InformacaoNome", gxTv_SdtInformacao_Informacaonome, false, includeNonInitialized);
         AddObjectProperty("InformacaoAtivo", gxTv_SdtInformacao_Informacaoativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtInformacao_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtInformacao_Initialized, false, includeNonInitialized);
            AddObjectProperty("InformacaoId_Z", gxTv_SdtInformacao_Informacaoid_Z, false, includeNonInitialized);
            AddObjectProperty("InformacaoNome_Z", gxTv_SdtInformacao_Informacaonome_Z, false, includeNonInitialized);
            AddObjectProperty("InformacaoAtivo_Z", gxTv_SdtInformacao_Informacaoativo_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtInformacao sdt )
      {
         if ( sdt.IsDirty("InformacaoId") )
         {
            gxTv_SdtInformacao_N = 0;
            gxTv_SdtInformacao_Informacaoid = sdt.gxTv_SdtInformacao_Informacaoid ;
         }
         if ( sdt.IsDirty("InformacaoNome") )
         {
            gxTv_SdtInformacao_N = 0;
            gxTv_SdtInformacao_Informacaonome = sdt.gxTv_SdtInformacao_Informacaonome ;
         }
         if ( sdt.IsDirty("InformacaoAtivo") )
         {
            gxTv_SdtInformacao_N = 0;
            gxTv_SdtInformacao_Informacaoativo = sdt.gxTv_SdtInformacao_Informacaoativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "InformacaoId" )]
      [  XmlElement( ElementName = "InformacaoId"   )]
      public int gxTpr_Informacaoid
      {
         get {
            return gxTv_SdtInformacao_Informacaoid ;
         }

         set {
            gxTv_SdtInformacao_N = 0;
            if ( gxTv_SdtInformacao_Informacaoid != value )
            {
               gxTv_SdtInformacao_Mode = "INS";
               this.gxTv_SdtInformacao_Informacaoid_Z_SetNull( );
               this.gxTv_SdtInformacao_Informacaonome_Z_SetNull( );
               this.gxTv_SdtInformacao_Informacaoativo_Z_SetNull( );
            }
            gxTv_SdtInformacao_Informacaoid = value;
            SetDirty("Informacaoid");
         }

      }

      [  SoapElement( ElementName = "InformacaoNome" )]
      [  XmlElement( ElementName = "InformacaoNome"   )]
      public string gxTpr_Informacaonome
      {
         get {
            return gxTv_SdtInformacao_Informacaonome ;
         }

         set {
            gxTv_SdtInformacao_N = 0;
            gxTv_SdtInformacao_Informacaonome = value;
            SetDirty("Informacaonome");
         }

      }

      [  SoapElement( ElementName = "InformacaoAtivo" )]
      [  XmlElement( ElementName = "InformacaoAtivo"   )]
      public bool gxTpr_Informacaoativo
      {
         get {
            return gxTv_SdtInformacao_Informacaoativo ;
         }

         set {
            gxTv_SdtInformacao_N = 0;
            gxTv_SdtInformacao_Informacaoativo = value;
            SetDirty("Informacaoativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtInformacao_Mode ;
         }

         set {
            gxTv_SdtInformacao_N = 0;
            gxTv_SdtInformacao_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtInformacao_Mode_SetNull( )
      {
         gxTv_SdtInformacao_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtInformacao_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtInformacao_Initialized ;
         }

         set {
            gxTv_SdtInformacao_N = 0;
            gxTv_SdtInformacao_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtInformacao_Initialized_SetNull( )
      {
         gxTv_SdtInformacao_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtInformacao_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InformacaoId_Z" )]
      [  XmlElement( ElementName = "InformacaoId_Z"   )]
      public int gxTpr_Informacaoid_Z
      {
         get {
            return gxTv_SdtInformacao_Informacaoid_Z ;
         }

         set {
            gxTv_SdtInformacao_N = 0;
            gxTv_SdtInformacao_Informacaoid_Z = value;
            SetDirty("Informacaoid_Z");
         }

      }

      public void gxTv_SdtInformacao_Informacaoid_Z_SetNull( )
      {
         gxTv_SdtInformacao_Informacaoid_Z = 0;
         SetDirty("Informacaoid_Z");
         return  ;
      }

      public bool gxTv_SdtInformacao_Informacaoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InformacaoNome_Z" )]
      [  XmlElement( ElementName = "InformacaoNome_Z"   )]
      public string gxTpr_Informacaonome_Z
      {
         get {
            return gxTv_SdtInformacao_Informacaonome_Z ;
         }

         set {
            gxTv_SdtInformacao_N = 0;
            gxTv_SdtInformacao_Informacaonome_Z = value;
            SetDirty("Informacaonome_Z");
         }

      }

      public void gxTv_SdtInformacao_Informacaonome_Z_SetNull( )
      {
         gxTv_SdtInformacao_Informacaonome_Z = "";
         SetDirty("Informacaonome_Z");
         return  ;
      }

      public bool gxTv_SdtInformacao_Informacaonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InformacaoAtivo_Z" )]
      [  XmlElement( ElementName = "InformacaoAtivo_Z"   )]
      public bool gxTpr_Informacaoativo_Z
      {
         get {
            return gxTv_SdtInformacao_Informacaoativo_Z ;
         }

         set {
            gxTv_SdtInformacao_N = 0;
            gxTv_SdtInformacao_Informacaoativo_Z = value;
            SetDirty("Informacaoativo_Z");
         }

      }

      public void gxTv_SdtInformacao_Informacaoativo_Z_SetNull( )
      {
         gxTv_SdtInformacao_Informacaoativo_Z = false;
         SetDirty("Informacaoativo_Z");
         return  ;
      }

      public bool gxTv_SdtInformacao_Informacaoativo_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtInformacao_N = 1;
         gxTv_SdtInformacao_Informacaonome = "";
         gxTv_SdtInformacao_Mode = "";
         gxTv_SdtInformacao_Informacaonome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "informacao", "GeneXus.Programs.informacao_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtInformacao_N ;
      }

      private short gxTv_SdtInformacao_N ;
      private short gxTv_SdtInformacao_Initialized ;
      private int gxTv_SdtInformacao_Informacaoid ;
      private int gxTv_SdtInformacao_Informacaoid_Z ;
      private string gxTv_SdtInformacao_Mode ;
      private bool gxTv_SdtInformacao_Informacaoativo ;
      private bool gxTv_SdtInformacao_Informacaoativo_Z ;
      private string gxTv_SdtInformacao_Informacaonome ;
      private string gxTv_SdtInformacao_Informacaonome_Z ;
   }

   [DataContract(Name = @"Informacao", Namespace = "LGPD_Novo")]
   public class SdtInformacao_RESTInterface : GxGenericCollectionItem<SdtInformacao>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtInformacao_RESTInterface( ) : base()
      {
      }

      public SdtInformacao_RESTInterface( SdtInformacao psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "InformacaoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Informacaoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Informacaoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Informacaoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "InformacaoNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Informacaonome
      {
         get {
            return sdt.gxTpr_Informacaonome ;
         }

         set {
            sdt.gxTpr_Informacaonome = value;
         }

      }

      [DataMember( Name = "InformacaoAtivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Informacaoativo
      {
         get {
            return sdt.gxTpr_Informacaoativo ;
         }

         set {
            sdt.gxTpr_Informacaoativo = value;
         }

      }

      public SdtInformacao sdt
      {
         get {
            return (SdtInformacao)Sdt ;
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
            sdt = new SdtInformacao() ;
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

   [DataContract(Name = @"Informacao", Namespace = "LGPD_Novo")]
   public class SdtInformacao_RESTLInterface : GxGenericCollectionItem<SdtInformacao>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtInformacao_RESTLInterface( ) : base()
      {
      }

      public SdtInformacao_RESTLInterface( SdtInformacao psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "InformacaoNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Informacaonome
      {
         get {
            return sdt.gxTpr_Informacaonome ;
         }

         set {
            sdt.gxTpr_Informacaonome = value;
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

      public SdtInformacao sdt
      {
         get {
            return (SdtInformacao)Sdt ;
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
            sdt = new SdtInformacao() ;
         }
      }

   }

}
