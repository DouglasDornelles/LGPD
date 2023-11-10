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
   [XmlRoot(ElementName = "Encarregado" )]
   [XmlType(TypeName =  "Encarregado" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtEncarregado : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtEncarregado( )
      {
      }

      public SdtEncarregado( IGxContext context )
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

      public void Load( int AV7EncarregadoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV7EncarregadoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"EncarregadoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Encarregado");
         metadata.Set("BT", "Encarregado");
         metadata.Set("PK", "[ \"EncarregadoId\" ]");
         metadata.Set("PKAssigned", "[ \"EncarregadoId\" ]");
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
         state.Add("gxTpr_Encarregadoid_Z");
         state.Add("gxTpr_Encarregadonome_Z");
         state.Add("gxTpr_Encarregadoativo_Z");
         state.Add("gxTpr_Encarregadoid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtEncarregado sdt;
         sdt = (SdtEncarregado)(source);
         gxTv_SdtEncarregado_Encarregadoid = sdt.gxTv_SdtEncarregado_Encarregadoid ;
         gxTv_SdtEncarregado_Encarregadonome = sdt.gxTv_SdtEncarregado_Encarregadonome ;
         gxTv_SdtEncarregado_Encarregadoativo = sdt.gxTv_SdtEncarregado_Encarregadoativo ;
         gxTv_SdtEncarregado_Mode = sdt.gxTv_SdtEncarregado_Mode ;
         gxTv_SdtEncarregado_Initialized = sdt.gxTv_SdtEncarregado_Initialized ;
         gxTv_SdtEncarregado_Encarregadoid_Z = sdt.gxTv_SdtEncarregado_Encarregadoid_Z ;
         gxTv_SdtEncarregado_Encarregadonome_Z = sdt.gxTv_SdtEncarregado_Encarregadonome_Z ;
         gxTv_SdtEncarregado_Encarregadoativo_Z = sdt.gxTv_SdtEncarregado_Encarregadoativo_Z ;
         gxTv_SdtEncarregado_Encarregadoid_N = sdt.gxTv_SdtEncarregado_Encarregadoid_N ;
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
         AddObjectProperty("EncarregadoId", gxTv_SdtEncarregado_Encarregadoid, false, includeNonInitialized);
         AddObjectProperty("EncarregadoId_N", gxTv_SdtEncarregado_Encarregadoid_N, false, includeNonInitialized);
         AddObjectProperty("EncarregadoNome", gxTv_SdtEncarregado_Encarregadonome, false, includeNonInitialized);
         AddObjectProperty("EncarregadoAtivo", gxTv_SdtEncarregado_Encarregadoativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtEncarregado_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtEncarregado_Initialized, false, includeNonInitialized);
            AddObjectProperty("EncarregadoId_Z", gxTv_SdtEncarregado_Encarregadoid_Z, false, includeNonInitialized);
            AddObjectProperty("EncarregadoNome_Z", gxTv_SdtEncarregado_Encarregadonome_Z, false, includeNonInitialized);
            AddObjectProperty("EncarregadoAtivo_Z", gxTv_SdtEncarregado_Encarregadoativo_Z, false, includeNonInitialized);
            AddObjectProperty("EncarregadoId_N", gxTv_SdtEncarregado_Encarregadoid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtEncarregado sdt )
      {
         if ( sdt.IsDirty("EncarregadoId") )
         {
            gxTv_SdtEncarregado_N = 0;
            gxTv_SdtEncarregado_Encarregadoid = sdt.gxTv_SdtEncarregado_Encarregadoid ;
         }
         if ( sdt.IsDirty("EncarregadoNome") )
         {
            gxTv_SdtEncarregado_N = 0;
            gxTv_SdtEncarregado_Encarregadonome = sdt.gxTv_SdtEncarregado_Encarregadonome ;
         }
         if ( sdt.IsDirty("EncarregadoAtivo") )
         {
            gxTv_SdtEncarregado_N = 0;
            gxTv_SdtEncarregado_Encarregadoativo = sdt.gxTv_SdtEncarregado_Encarregadoativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "EncarregadoId" )]
      [  XmlElement( ElementName = "EncarregadoId"   )]
      public int gxTpr_Encarregadoid
      {
         get {
            return gxTv_SdtEncarregado_Encarregadoid ;
         }

         set {
            gxTv_SdtEncarregado_N = 0;
            if ( gxTv_SdtEncarregado_Encarregadoid != value )
            {
               gxTv_SdtEncarregado_Mode = "INS";
               this.gxTv_SdtEncarregado_Encarregadoid_Z_SetNull( );
               this.gxTv_SdtEncarregado_Encarregadonome_Z_SetNull( );
               this.gxTv_SdtEncarregado_Encarregadoativo_Z_SetNull( );
            }
            gxTv_SdtEncarregado_Encarregadoid = value;
            SetDirty("Encarregadoid");
         }

      }

      [  SoapElement( ElementName = "EncarregadoNome" )]
      [  XmlElement( ElementName = "EncarregadoNome"   )]
      public string gxTpr_Encarregadonome
      {
         get {
            return gxTv_SdtEncarregado_Encarregadonome ;
         }

         set {
            gxTv_SdtEncarregado_N = 0;
            gxTv_SdtEncarregado_Encarregadonome = value;
            SetDirty("Encarregadonome");
         }

      }

      [  SoapElement( ElementName = "EncarregadoAtivo" )]
      [  XmlElement( ElementName = "EncarregadoAtivo"   )]
      public bool gxTpr_Encarregadoativo
      {
         get {
            return gxTv_SdtEncarregado_Encarregadoativo ;
         }

         set {
            gxTv_SdtEncarregado_N = 0;
            gxTv_SdtEncarregado_Encarregadoativo = value;
            SetDirty("Encarregadoativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtEncarregado_Mode ;
         }

         set {
            gxTv_SdtEncarregado_N = 0;
            gxTv_SdtEncarregado_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtEncarregado_Mode_SetNull( )
      {
         gxTv_SdtEncarregado_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtEncarregado_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtEncarregado_Initialized ;
         }

         set {
            gxTv_SdtEncarregado_N = 0;
            gxTv_SdtEncarregado_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtEncarregado_Initialized_SetNull( )
      {
         gxTv_SdtEncarregado_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtEncarregado_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EncarregadoId_Z" )]
      [  XmlElement( ElementName = "EncarregadoId_Z"   )]
      public int gxTpr_Encarregadoid_Z
      {
         get {
            return gxTv_SdtEncarregado_Encarregadoid_Z ;
         }

         set {
            gxTv_SdtEncarregado_N = 0;
            gxTv_SdtEncarregado_Encarregadoid_Z = value;
            SetDirty("Encarregadoid_Z");
         }

      }

      public void gxTv_SdtEncarregado_Encarregadoid_Z_SetNull( )
      {
         gxTv_SdtEncarregado_Encarregadoid_Z = 0;
         SetDirty("Encarregadoid_Z");
         return  ;
      }

      public bool gxTv_SdtEncarregado_Encarregadoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EncarregadoNome_Z" )]
      [  XmlElement( ElementName = "EncarregadoNome_Z"   )]
      public string gxTpr_Encarregadonome_Z
      {
         get {
            return gxTv_SdtEncarregado_Encarregadonome_Z ;
         }

         set {
            gxTv_SdtEncarregado_N = 0;
            gxTv_SdtEncarregado_Encarregadonome_Z = value;
            SetDirty("Encarregadonome_Z");
         }

      }

      public void gxTv_SdtEncarregado_Encarregadonome_Z_SetNull( )
      {
         gxTv_SdtEncarregado_Encarregadonome_Z = "";
         SetDirty("Encarregadonome_Z");
         return  ;
      }

      public bool gxTv_SdtEncarregado_Encarregadonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EncarregadoAtivo_Z" )]
      [  XmlElement( ElementName = "EncarregadoAtivo_Z"   )]
      public bool gxTpr_Encarregadoativo_Z
      {
         get {
            return gxTv_SdtEncarregado_Encarregadoativo_Z ;
         }

         set {
            gxTv_SdtEncarregado_N = 0;
            gxTv_SdtEncarregado_Encarregadoativo_Z = value;
            SetDirty("Encarregadoativo_Z");
         }

      }

      public void gxTv_SdtEncarregado_Encarregadoativo_Z_SetNull( )
      {
         gxTv_SdtEncarregado_Encarregadoativo_Z = false;
         SetDirty("Encarregadoativo_Z");
         return  ;
      }

      public bool gxTv_SdtEncarregado_Encarregadoativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EncarregadoId_N" )]
      [  XmlElement( ElementName = "EncarregadoId_N"   )]
      public short gxTpr_Encarregadoid_N
      {
         get {
            return gxTv_SdtEncarregado_Encarregadoid_N ;
         }

         set {
            gxTv_SdtEncarregado_N = 0;
            gxTv_SdtEncarregado_Encarregadoid_N = value;
            SetDirty("Encarregadoid_N");
         }

      }

      public void gxTv_SdtEncarregado_Encarregadoid_N_SetNull( )
      {
         gxTv_SdtEncarregado_Encarregadoid_N = 0;
         SetDirty("Encarregadoid_N");
         return  ;
      }

      public bool gxTv_SdtEncarregado_Encarregadoid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtEncarregado_N = 1;
         gxTv_SdtEncarregado_Encarregadonome = "";
         gxTv_SdtEncarregado_Mode = "";
         gxTv_SdtEncarregado_Encarregadonome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "encarregado", "GeneXus.Programs.encarregado_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtEncarregado_N ;
      }

      private short gxTv_SdtEncarregado_N ;
      private short gxTv_SdtEncarregado_Initialized ;
      private short gxTv_SdtEncarregado_Encarregadoid_N ;
      private int gxTv_SdtEncarregado_Encarregadoid ;
      private int gxTv_SdtEncarregado_Encarregadoid_Z ;
      private string gxTv_SdtEncarregado_Mode ;
      private bool gxTv_SdtEncarregado_Encarregadoativo ;
      private bool gxTv_SdtEncarregado_Encarregadoativo_Z ;
      private string gxTv_SdtEncarregado_Encarregadonome ;
      private string gxTv_SdtEncarregado_Encarregadonome_Z ;
   }

   [DataContract(Name = @"Encarregado", Namespace = "LGPD_Novo")]
   public class SdtEncarregado_RESTInterface : GxGenericCollectionItem<SdtEncarregado>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtEncarregado_RESTInterface( ) : base()
      {
      }

      public SdtEncarregado_RESTInterface( SdtEncarregado psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EncarregadoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Encarregadoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Encarregadoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Encarregadoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "EncarregadoNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Encarregadonome
      {
         get {
            return sdt.gxTpr_Encarregadonome ;
         }

         set {
            sdt.gxTpr_Encarregadonome = value;
         }

      }

      [DataMember( Name = "EncarregadoAtivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Encarregadoativo
      {
         get {
            return sdt.gxTpr_Encarregadoativo ;
         }

         set {
            sdt.gxTpr_Encarregadoativo = value;
         }

      }

      public SdtEncarregado sdt
      {
         get {
            return (SdtEncarregado)Sdt ;
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
            sdt = new SdtEncarregado() ;
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

   [DataContract(Name = @"Encarregado", Namespace = "LGPD_Novo")]
   public class SdtEncarregado_RESTLInterface : GxGenericCollectionItem<SdtEncarregado>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtEncarregado_RESTLInterface( ) : base()
      {
      }

      public SdtEncarregado_RESTLInterface( SdtEncarregado psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EncarregadoNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Encarregadonome
      {
         get {
            return sdt.gxTpr_Encarregadonome ;
         }

         set {
            sdt.gxTpr_Encarregadonome = value;
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

      public SdtEncarregado sdt
      {
         get {
            return (SdtEncarregado)Sdt ;
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
            sdt = new SdtEncarregado() ;
         }
      }

   }

}
