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
   [XmlRoot(ElementName = "TempoRetencao" )]
   [XmlType(TypeName =  "TempoRetencao" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtTempoRetencao : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTempoRetencao( )
      {
      }

      public SdtTempoRetencao( IGxContext context )
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

      public void Load( int AV48TempoRetencaoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV48TempoRetencaoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TempoRetencaoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "TempoRetencao");
         metadata.Set("BT", "TempoRetencao");
         metadata.Set("PK", "[ \"TempoRetencaoId\" ]");
         metadata.Set("PKAssigned", "[ \"TempoRetencaoId\" ]");
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
         state.Add("gxTpr_Temporetencaoid_Z");
         state.Add("gxTpr_Temporetencaonome_Z");
         state.Add("gxTpr_Temporetencaoativo_Z");
         state.Add("gxTpr_Temporetencaoid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTempoRetencao sdt;
         sdt = (SdtTempoRetencao)(source);
         gxTv_SdtTempoRetencao_Temporetencaoid = sdt.gxTv_SdtTempoRetencao_Temporetencaoid ;
         gxTv_SdtTempoRetencao_Temporetencaonome = sdt.gxTv_SdtTempoRetencao_Temporetencaonome ;
         gxTv_SdtTempoRetencao_Temporetencaoativo = sdt.gxTv_SdtTempoRetencao_Temporetencaoativo ;
         gxTv_SdtTempoRetencao_Mode = sdt.gxTv_SdtTempoRetencao_Mode ;
         gxTv_SdtTempoRetencao_Initialized = sdt.gxTv_SdtTempoRetencao_Initialized ;
         gxTv_SdtTempoRetencao_Temporetencaoid_Z = sdt.gxTv_SdtTempoRetencao_Temporetencaoid_Z ;
         gxTv_SdtTempoRetencao_Temporetencaonome_Z = sdt.gxTv_SdtTempoRetencao_Temporetencaonome_Z ;
         gxTv_SdtTempoRetencao_Temporetencaoativo_Z = sdt.gxTv_SdtTempoRetencao_Temporetencaoativo_Z ;
         gxTv_SdtTempoRetencao_Temporetencaoid_N = sdt.gxTv_SdtTempoRetencao_Temporetencaoid_N ;
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
         AddObjectProperty("TempoRetencaoId", gxTv_SdtTempoRetencao_Temporetencaoid, false, includeNonInitialized);
         AddObjectProperty("TempoRetencaoId_N", gxTv_SdtTempoRetencao_Temporetencaoid_N, false, includeNonInitialized);
         AddObjectProperty("TempoRetencaoNome", gxTv_SdtTempoRetencao_Temporetencaonome, false, includeNonInitialized);
         AddObjectProperty("TempoRetencaoAtivo", gxTv_SdtTempoRetencao_Temporetencaoativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTempoRetencao_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTempoRetencao_Initialized, false, includeNonInitialized);
            AddObjectProperty("TempoRetencaoId_Z", gxTv_SdtTempoRetencao_Temporetencaoid_Z, false, includeNonInitialized);
            AddObjectProperty("TempoRetencaoNome_Z", gxTv_SdtTempoRetencao_Temporetencaonome_Z, false, includeNonInitialized);
            AddObjectProperty("TempoRetencaoAtivo_Z", gxTv_SdtTempoRetencao_Temporetencaoativo_Z, false, includeNonInitialized);
            AddObjectProperty("TempoRetencaoId_N", gxTv_SdtTempoRetencao_Temporetencaoid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTempoRetencao sdt )
      {
         if ( sdt.IsDirty("TempoRetencaoId") )
         {
            gxTv_SdtTempoRetencao_N = 0;
            gxTv_SdtTempoRetencao_Temporetencaoid = sdt.gxTv_SdtTempoRetencao_Temporetencaoid ;
         }
         if ( sdt.IsDirty("TempoRetencaoNome") )
         {
            gxTv_SdtTempoRetencao_N = 0;
            gxTv_SdtTempoRetencao_Temporetencaonome = sdt.gxTv_SdtTempoRetencao_Temporetencaonome ;
         }
         if ( sdt.IsDirty("TempoRetencaoAtivo") )
         {
            gxTv_SdtTempoRetencao_N = 0;
            gxTv_SdtTempoRetencao_Temporetencaoativo = sdt.gxTv_SdtTempoRetencao_Temporetencaoativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TempoRetencaoId" )]
      [  XmlElement( ElementName = "TempoRetencaoId"   )]
      public int gxTpr_Temporetencaoid
      {
         get {
            return gxTv_SdtTempoRetencao_Temporetencaoid ;
         }

         set {
            gxTv_SdtTempoRetencao_N = 0;
            if ( gxTv_SdtTempoRetencao_Temporetencaoid != value )
            {
               gxTv_SdtTempoRetencao_Mode = "INS";
               this.gxTv_SdtTempoRetencao_Temporetencaoid_Z_SetNull( );
               this.gxTv_SdtTempoRetencao_Temporetencaonome_Z_SetNull( );
               this.gxTv_SdtTempoRetencao_Temporetencaoativo_Z_SetNull( );
            }
            gxTv_SdtTempoRetencao_Temporetencaoid = value;
            SetDirty("Temporetencaoid");
         }

      }

      [  SoapElement( ElementName = "TempoRetencaoNome" )]
      [  XmlElement( ElementName = "TempoRetencaoNome"   )]
      public string gxTpr_Temporetencaonome
      {
         get {
            return gxTv_SdtTempoRetencao_Temporetencaonome ;
         }

         set {
            gxTv_SdtTempoRetencao_N = 0;
            gxTv_SdtTempoRetencao_Temporetencaonome = value;
            SetDirty("Temporetencaonome");
         }

      }

      [  SoapElement( ElementName = "TempoRetencaoAtivo" )]
      [  XmlElement( ElementName = "TempoRetencaoAtivo"   )]
      public bool gxTpr_Temporetencaoativo
      {
         get {
            return gxTv_SdtTempoRetencao_Temporetencaoativo ;
         }

         set {
            gxTv_SdtTempoRetencao_N = 0;
            gxTv_SdtTempoRetencao_Temporetencaoativo = value;
            SetDirty("Temporetencaoativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTempoRetencao_Mode ;
         }

         set {
            gxTv_SdtTempoRetencao_N = 0;
            gxTv_SdtTempoRetencao_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTempoRetencao_Mode_SetNull( )
      {
         gxTv_SdtTempoRetencao_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTempoRetencao_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTempoRetencao_Initialized ;
         }

         set {
            gxTv_SdtTempoRetencao_N = 0;
            gxTv_SdtTempoRetencao_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTempoRetencao_Initialized_SetNull( )
      {
         gxTv_SdtTempoRetencao_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTempoRetencao_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TempoRetencaoId_Z" )]
      [  XmlElement( ElementName = "TempoRetencaoId_Z"   )]
      public int gxTpr_Temporetencaoid_Z
      {
         get {
            return gxTv_SdtTempoRetencao_Temporetencaoid_Z ;
         }

         set {
            gxTv_SdtTempoRetencao_N = 0;
            gxTv_SdtTempoRetencao_Temporetencaoid_Z = value;
            SetDirty("Temporetencaoid_Z");
         }

      }

      public void gxTv_SdtTempoRetencao_Temporetencaoid_Z_SetNull( )
      {
         gxTv_SdtTempoRetencao_Temporetencaoid_Z = 0;
         SetDirty("Temporetencaoid_Z");
         return  ;
      }

      public bool gxTv_SdtTempoRetencao_Temporetencaoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TempoRetencaoNome_Z" )]
      [  XmlElement( ElementName = "TempoRetencaoNome_Z"   )]
      public string gxTpr_Temporetencaonome_Z
      {
         get {
            return gxTv_SdtTempoRetencao_Temporetencaonome_Z ;
         }

         set {
            gxTv_SdtTempoRetencao_N = 0;
            gxTv_SdtTempoRetencao_Temporetencaonome_Z = value;
            SetDirty("Temporetencaonome_Z");
         }

      }

      public void gxTv_SdtTempoRetencao_Temporetencaonome_Z_SetNull( )
      {
         gxTv_SdtTempoRetencao_Temporetencaonome_Z = "";
         SetDirty("Temporetencaonome_Z");
         return  ;
      }

      public bool gxTv_SdtTempoRetencao_Temporetencaonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TempoRetencaoAtivo_Z" )]
      [  XmlElement( ElementName = "TempoRetencaoAtivo_Z"   )]
      public bool gxTpr_Temporetencaoativo_Z
      {
         get {
            return gxTv_SdtTempoRetencao_Temporetencaoativo_Z ;
         }

         set {
            gxTv_SdtTempoRetencao_N = 0;
            gxTv_SdtTempoRetencao_Temporetencaoativo_Z = value;
            SetDirty("Temporetencaoativo_Z");
         }

      }

      public void gxTv_SdtTempoRetencao_Temporetencaoativo_Z_SetNull( )
      {
         gxTv_SdtTempoRetencao_Temporetencaoativo_Z = false;
         SetDirty("Temporetencaoativo_Z");
         return  ;
      }

      public bool gxTv_SdtTempoRetencao_Temporetencaoativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TempoRetencaoId_N" )]
      [  XmlElement( ElementName = "TempoRetencaoId_N"   )]
      public short gxTpr_Temporetencaoid_N
      {
         get {
            return gxTv_SdtTempoRetencao_Temporetencaoid_N ;
         }

         set {
            gxTv_SdtTempoRetencao_N = 0;
            gxTv_SdtTempoRetencao_Temporetencaoid_N = value;
            SetDirty("Temporetencaoid_N");
         }

      }

      public void gxTv_SdtTempoRetencao_Temporetencaoid_N_SetNull( )
      {
         gxTv_SdtTempoRetencao_Temporetencaoid_N = 0;
         SetDirty("Temporetencaoid_N");
         return  ;
      }

      public bool gxTv_SdtTempoRetencao_Temporetencaoid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtTempoRetencao_N = 1;
         gxTv_SdtTempoRetencao_Temporetencaonome = "";
         gxTv_SdtTempoRetencao_Mode = "";
         gxTv_SdtTempoRetencao_Temporetencaonome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "temporetencao", "GeneXus.Programs.temporetencao_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtTempoRetencao_N ;
      }

      private short gxTv_SdtTempoRetencao_N ;
      private short gxTv_SdtTempoRetencao_Initialized ;
      private short gxTv_SdtTempoRetencao_Temporetencaoid_N ;
      private int gxTv_SdtTempoRetencao_Temporetencaoid ;
      private int gxTv_SdtTempoRetencao_Temporetencaoid_Z ;
      private string gxTv_SdtTempoRetencao_Mode ;
      private bool gxTv_SdtTempoRetencao_Temporetencaoativo ;
      private bool gxTv_SdtTempoRetencao_Temporetencaoativo_Z ;
      private string gxTv_SdtTempoRetencao_Temporetencaonome ;
      private string gxTv_SdtTempoRetencao_Temporetencaonome_Z ;
   }

   [DataContract(Name = @"TempoRetencao", Namespace = "LGPD_Novo")]
   public class SdtTempoRetencao_RESTInterface : GxGenericCollectionItem<SdtTempoRetencao>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTempoRetencao_RESTInterface( ) : base()
      {
      }

      public SdtTempoRetencao_RESTInterface( SdtTempoRetencao psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TempoRetencaoId" , Order = 0 )]
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

      [DataMember( Name = "TempoRetencaoNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Temporetencaonome
      {
         get {
            return sdt.gxTpr_Temporetencaonome ;
         }

         set {
            sdt.gxTpr_Temporetencaonome = value;
         }

      }

      [DataMember( Name = "TempoRetencaoAtivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Temporetencaoativo
      {
         get {
            return sdt.gxTpr_Temporetencaoativo ;
         }

         set {
            sdt.gxTpr_Temporetencaoativo = value;
         }

      }

      public SdtTempoRetencao sdt
      {
         get {
            return (SdtTempoRetencao)Sdt ;
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
            sdt = new SdtTempoRetencao() ;
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

   [DataContract(Name = @"TempoRetencao", Namespace = "LGPD_Novo")]
   public class SdtTempoRetencao_RESTLInterface : GxGenericCollectionItem<SdtTempoRetencao>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTempoRetencao_RESTLInterface( ) : base()
      {
      }

      public SdtTempoRetencao_RESTLInterface( SdtTempoRetencao psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TempoRetencaoNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Temporetencaonome
      {
         get {
            return sdt.gxTpr_Temporetencaonome ;
         }

         set {
            sdt.gxTpr_Temporetencaonome = value;
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

      public SdtTempoRetencao sdt
      {
         get {
            return (SdtTempoRetencao)Sdt ;
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
            sdt = new SdtTempoRetencao() ;
         }
      }

   }

}
