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
   [XmlRoot(ElementName = "TipoDado" )]
   [XmlType(TypeName =  "TipoDado" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtTipoDado : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTipoDado( )
      {
      }

      public SdtTipoDado( IGxContext context )
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

      public void Load( int AV30TipoDadoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV30TipoDadoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TipoDadoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "TipoDado");
         metadata.Set("BT", "TipoDado");
         metadata.Set("PK", "[ \"TipoDadoId\" ]");
         metadata.Set("PKAssigned", "[ \"TipoDadoId\" ]");
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
         state.Add("gxTpr_Tipodadoid_Z");
         state.Add("gxTpr_Tipodadonome_Z");
         state.Add("gxTpr_Tipodadoativo_Z");
         state.Add("gxTpr_Tipodadoid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTipoDado sdt;
         sdt = (SdtTipoDado)(source);
         gxTv_SdtTipoDado_Tipodadoid = sdt.gxTv_SdtTipoDado_Tipodadoid ;
         gxTv_SdtTipoDado_Tipodadonome = sdt.gxTv_SdtTipoDado_Tipodadonome ;
         gxTv_SdtTipoDado_Tipodadoativo = sdt.gxTv_SdtTipoDado_Tipodadoativo ;
         gxTv_SdtTipoDado_Mode = sdt.gxTv_SdtTipoDado_Mode ;
         gxTv_SdtTipoDado_Initialized = sdt.gxTv_SdtTipoDado_Initialized ;
         gxTv_SdtTipoDado_Tipodadoid_Z = sdt.gxTv_SdtTipoDado_Tipodadoid_Z ;
         gxTv_SdtTipoDado_Tipodadonome_Z = sdt.gxTv_SdtTipoDado_Tipodadonome_Z ;
         gxTv_SdtTipoDado_Tipodadoativo_Z = sdt.gxTv_SdtTipoDado_Tipodadoativo_Z ;
         gxTv_SdtTipoDado_Tipodadoid_N = sdt.gxTv_SdtTipoDado_Tipodadoid_N ;
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
         AddObjectProperty("TipoDadoId", gxTv_SdtTipoDado_Tipodadoid, false, includeNonInitialized);
         AddObjectProperty("TipoDadoId_N", gxTv_SdtTipoDado_Tipodadoid_N, false, includeNonInitialized);
         AddObjectProperty("TipoDadoNome", gxTv_SdtTipoDado_Tipodadonome, false, includeNonInitialized);
         AddObjectProperty("TipoDadoAtivo", gxTv_SdtTipoDado_Tipodadoativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTipoDado_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTipoDado_Initialized, false, includeNonInitialized);
            AddObjectProperty("TipoDadoId_Z", gxTv_SdtTipoDado_Tipodadoid_Z, false, includeNonInitialized);
            AddObjectProperty("TipoDadoNome_Z", gxTv_SdtTipoDado_Tipodadonome_Z, false, includeNonInitialized);
            AddObjectProperty("TipoDadoAtivo_Z", gxTv_SdtTipoDado_Tipodadoativo_Z, false, includeNonInitialized);
            AddObjectProperty("TipoDadoId_N", gxTv_SdtTipoDado_Tipodadoid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTipoDado sdt )
      {
         if ( sdt.IsDirty("TipoDadoId") )
         {
            gxTv_SdtTipoDado_N = 0;
            gxTv_SdtTipoDado_Tipodadoid = sdt.gxTv_SdtTipoDado_Tipodadoid ;
         }
         if ( sdt.IsDirty("TipoDadoNome") )
         {
            gxTv_SdtTipoDado_N = 0;
            gxTv_SdtTipoDado_Tipodadonome = sdt.gxTv_SdtTipoDado_Tipodadonome ;
         }
         if ( sdt.IsDirty("TipoDadoAtivo") )
         {
            gxTv_SdtTipoDado_N = 0;
            gxTv_SdtTipoDado_Tipodadoativo = sdt.gxTv_SdtTipoDado_Tipodadoativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TipoDadoId" )]
      [  XmlElement( ElementName = "TipoDadoId"   )]
      public int gxTpr_Tipodadoid
      {
         get {
            return gxTv_SdtTipoDado_Tipodadoid ;
         }

         set {
            gxTv_SdtTipoDado_N = 0;
            if ( gxTv_SdtTipoDado_Tipodadoid != value )
            {
               gxTv_SdtTipoDado_Mode = "INS";
               this.gxTv_SdtTipoDado_Tipodadoid_Z_SetNull( );
               this.gxTv_SdtTipoDado_Tipodadonome_Z_SetNull( );
               this.gxTv_SdtTipoDado_Tipodadoativo_Z_SetNull( );
            }
            gxTv_SdtTipoDado_Tipodadoid = value;
            SetDirty("Tipodadoid");
         }

      }

      [  SoapElement( ElementName = "TipoDadoNome" )]
      [  XmlElement( ElementName = "TipoDadoNome"   )]
      public string gxTpr_Tipodadonome
      {
         get {
            return gxTv_SdtTipoDado_Tipodadonome ;
         }

         set {
            gxTv_SdtTipoDado_N = 0;
            gxTv_SdtTipoDado_Tipodadonome = value;
            SetDirty("Tipodadonome");
         }

      }

      [  SoapElement( ElementName = "TipoDadoAtivo" )]
      [  XmlElement( ElementName = "TipoDadoAtivo"   )]
      public bool gxTpr_Tipodadoativo
      {
         get {
            return gxTv_SdtTipoDado_Tipodadoativo ;
         }

         set {
            gxTv_SdtTipoDado_N = 0;
            gxTv_SdtTipoDado_Tipodadoativo = value;
            SetDirty("Tipodadoativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTipoDado_Mode ;
         }

         set {
            gxTv_SdtTipoDado_N = 0;
            gxTv_SdtTipoDado_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTipoDado_Mode_SetNull( )
      {
         gxTv_SdtTipoDado_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTipoDado_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTipoDado_Initialized ;
         }

         set {
            gxTv_SdtTipoDado_N = 0;
            gxTv_SdtTipoDado_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTipoDado_Initialized_SetNull( )
      {
         gxTv_SdtTipoDado_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTipoDado_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoDadoId_Z" )]
      [  XmlElement( ElementName = "TipoDadoId_Z"   )]
      public int gxTpr_Tipodadoid_Z
      {
         get {
            return gxTv_SdtTipoDado_Tipodadoid_Z ;
         }

         set {
            gxTv_SdtTipoDado_N = 0;
            gxTv_SdtTipoDado_Tipodadoid_Z = value;
            SetDirty("Tipodadoid_Z");
         }

      }

      public void gxTv_SdtTipoDado_Tipodadoid_Z_SetNull( )
      {
         gxTv_SdtTipoDado_Tipodadoid_Z = 0;
         SetDirty("Tipodadoid_Z");
         return  ;
      }

      public bool gxTv_SdtTipoDado_Tipodadoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoDadoNome_Z" )]
      [  XmlElement( ElementName = "TipoDadoNome_Z"   )]
      public string gxTpr_Tipodadonome_Z
      {
         get {
            return gxTv_SdtTipoDado_Tipodadonome_Z ;
         }

         set {
            gxTv_SdtTipoDado_N = 0;
            gxTv_SdtTipoDado_Tipodadonome_Z = value;
            SetDirty("Tipodadonome_Z");
         }

      }

      public void gxTv_SdtTipoDado_Tipodadonome_Z_SetNull( )
      {
         gxTv_SdtTipoDado_Tipodadonome_Z = "";
         SetDirty("Tipodadonome_Z");
         return  ;
      }

      public bool gxTv_SdtTipoDado_Tipodadonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoDadoAtivo_Z" )]
      [  XmlElement( ElementName = "TipoDadoAtivo_Z"   )]
      public bool gxTpr_Tipodadoativo_Z
      {
         get {
            return gxTv_SdtTipoDado_Tipodadoativo_Z ;
         }

         set {
            gxTv_SdtTipoDado_N = 0;
            gxTv_SdtTipoDado_Tipodadoativo_Z = value;
            SetDirty("Tipodadoativo_Z");
         }

      }

      public void gxTv_SdtTipoDado_Tipodadoativo_Z_SetNull( )
      {
         gxTv_SdtTipoDado_Tipodadoativo_Z = false;
         SetDirty("Tipodadoativo_Z");
         return  ;
      }

      public bool gxTv_SdtTipoDado_Tipodadoativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoDadoId_N" )]
      [  XmlElement( ElementName = "TipoDadoId_N"   )]
      public short gxTpr_Tipodadoid_N
      {
         get {
            return gxTv_SdtTipoDado_Tipodadoid_N ;
         }

         set {
            gxTv_SdtTipoDado_N = 0;
            gxTv_SdtTipoDado_Tipodadoid_N = value;
            SetDirty("Tipodadoid_N");
         }

      }

      public void gxTv_SdtTipoDado_Tipodadoid_N_SetNull( )
      {
         gxTv_SdtTipoDado_Tipodadoid_N = 0;
         SetDirty("Tipodadoid_N");
         return  ;
      }

      public bool gxTv_SdtTipoDado_Tipodadoid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtTipoDado_N = 1;
         gxTv_SdtTipoDado_Tipodadonome = "";
         gxTv_SdtTipoDado_Mode = "";
         gxTv_SdtTipoDado_Tipodadonome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "tipodado", "GeneXus.Programs.tipodado_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtTipoDado_N ;
      }

      private short gxTv_SdtTipoDado_N ;
      private short gxTv_SdtTipoDado_Initialized ;
      private short gxTv_SdtTipoDado_Tipodadoid_N ;
      private int gxTv_SdtTipoDado_Tipodadoid ;
      private int gxTv_SdtTipoDado_Tipodadoid_Z ;
      private string gxTv_SdtTipoDado_Mode ;
      private bool gxTv_SdtTipoDado_Tipodadoativo ;
      private bool gxTv_SdtTipoDado_Tipodadoativo_Z ;
      private string gxTv_SdtTipoDado_Tipodadonome ;
      private string gxTv_SdtTipoDado_Tipodadonome_Z ;
   }

   [DataContract(Name = @"TipoDado", Namespace = "LGPD_Novo")]
   public class SdtTipoDado_RESTInterface : GxGenericCollectionItem<SdtTipoDado>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTipoDado_RESTInterface( ) : base()
      {
      }

      public SdtTipoDado_RESTInterface( SdtTipoDado psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TipoDadoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Tipodadoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Tipodadoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Tipodadoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "TipoDadoNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Tipodadonome
      {
         get {
            return sdt.gxTpr_Tipodadonome ;
         }

         set {
            sdt.gxTpr_Tipodadonome = value;
         }

      }

      [DataMember( Name = "TipoDadoAtivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Tipodadoativo
      {
         get {
            return sdt.gxTpr_Tipodadoativo ;
         }

         set {
            sdt.gxTpr_Tipodadoativo = value;
         }

      }

      public SdtTipoDado sdt
      {
         get {
            return (SdtTipoDado)Sdt ;
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
            sdt = new SdtTipoDado() ;
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

   [DataContract(Name = @"TipoDado", Namespace = "LGPD_Novo")]
   public class SdtTipoDado_RESTLInterface : GxGenericCollectionItem<SdtTipoDado>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTipoDado_RESTLInterface( ) : base()
      {
      }

      public SdtTipoDado_RESTLInterface( SdtTipoDado psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TipoDadoNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Tipodadonome
      {
         get {
            return sdt.gxTpr_Tipodadonome ;
         }

         set {
            sdt.gxTpr_Tipodadonome = value;
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

      public SdtTipoDado sdt
      {
         get {
            return (SdtTipoDado)Sdt ;
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
            sdt = new SdtTipoDado() ;
         }
      }

   }

}
