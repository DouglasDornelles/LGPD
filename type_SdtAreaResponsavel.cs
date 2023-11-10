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
   [XmlRoot(ElementName = "AreaResponsavel" )]
   [XmlType(TypeName =  "AreaResponsavel" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtAreaResponsavel : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtAreaResponsavel( )
      {
      }

      public SdtAreaResponsavel( IGxContext context )
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

      public void Load( int AV24AreaResponsavelId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV24AreaResponsavelId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"AreaResponsavelId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "AreaResponsavel");
         metadata.Set("BT", "AreaResponsavel");
         metadata.Set("PK", "[ \"AreaResponsavelId\" ]");
         metadata.Set("PKAssigned", "[ \"AreaResponsavelId\" ]");
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
         state.Add("gxTpr_Arearesponsavelid_Z");
         state.Add("gxTpr_Arearesponsavelnome_Z");
         state.Add("gxTpr_Arearesponsavelativo_Z");
         state.Add("gxTpr_Arearesponsavelid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtAreaResponsavel sdt;
         sdt = (SdtAreaResponsavel)(source);
         gxTv_SdtAreaResponsavel_Arearesponsavelid = sdt.gxTv_SdtAreaResponsavel_Arearesponsavelid ;
         gxTv_SdtAreaResponsavel_Arearesponsavelnome = sdt.gxTv_SdtAreaResponsavel_Arearesponsavelnome ;
         gxTv_SdtAreaResponsavel_Arearesponsavelativo = sdt.gxTv_SdtAreaResponsavel_Arearesponsavelativo ;
         gxTv_SdtAreaResponsavel_Mode = sdt.gxTv_SdtAreaResponsavel_Mode ;
         gxTv_SdtAreaResponsavel_Initialized = sdt.gxTv_SdtAreaResponsavel_Initialized ;
         gxTv_SdtAreaResponsavel_Arearesponsavelid_Z = sdt.gxTv_SdtAreaResponsavel_Arearesponsavelid_Z ;
         gxTv_SdtAreaResponsavel_Arearesponsavelnome_Z = sdt.gxTv_SdtAreaResponsavel_Arearesponsavelnome_Z ;
         gxTv_SdtAreaResponsavel_Arearesponsavelativo_Z = sdt.gxTv_SdtAreaResponsavel_Arearesponsavelativo_Z ;
         gxTv_SdtAreaResponsavel_Arearesponsavelid_N = sdt.gxTv_SdtAreaResponsavel_Arearesponsavelid_N ;
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
         AddObjectProperty("AreaResponsavelId", gxTv_SdtAreaResponsavel_Arearesponsavelid, false, includeNonInitialized);
         AddObjectProperty("AreaResponsavelId_N", gxTv_SdtAreaResponsavel_Arearesponsavelid_N, false, includeNonInitialized);
         AddObjectProperty("AreaResponsavelNome", gxTv_SdtAreaResponsavel_Arearesponsavelnome, false, includeNonInitialized);
         AddObjectProperty("AreaResponsavelAtivo", gxTv_SdtAreaResponsavel_Arearesponsavelativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtAreaResponsavel_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtAreaResponsavel_Initialized, false, includeNonInitialized);
            AddObjectProperty("AreaResponsavelId_Z", gxTv_SdtAreaResponsavel_Arearesponsavelid_Z, false, includeNonInitialized);
            AddObjectProperty("AreaResponsavelNome_Z", gxTv_SdtAreaResponsavel_Arearesponsavelnome_Z, false, includeNonInitialized);
            AddObjectProperty("AreaResponsavelAtivo_Z", gxTv_SdtAreaResponsavel_Arearesponsavelativo_Z, false, includeNonInitialized);
            AddObjectProperty("AreaResponsavelId_N", gxTv_SdtAreaResponsavel_Arearesponsavelid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtAreaResponsavel sdt )
      {
         if ( sdt.IsDirty("AreaResponsavelId") )
         {
            gxTv_SdtAreaResponsavel_N = 0;
            gxTv_SdtAreaResponsavel_Arearesponsavelid = sdt.gxTv_SdtAreaResponsavel_Arearesponsavelid ;
         }
         if ( sdt.IsDirty("AreaResponsavelNome") )
         {
            gxTv_SdtAreaResponsavel_N = 0;
            gxTv_SdtAreaResponsavel_Arearesponsavelnome = sdt.gxTv_SdtAreaResponsavel_Arearesponsavelnome ;
         }
         if ( sdt.IsDirty("AreaResponsavelAtivo") )
         {
            gxTv_SdtAreaResponsavel_N = 0;
            gxTv_SdtAreaResponsavel_Arearesponsavelativo = sdt.gxTv_SdtAreaResponsavel_Arearesponsavelativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "AreaResponsavelId" )]
      [  XmlElement( ElementName = "AreaResponsavelId"   )]
      public int gxTpr_Arearesponsavelid
      {
         get {
            return gxTv_SdtAreaResponsavel_Arearesponsavelid ;
         }

         set {
            gxTv_SdtAreaResponsavel_N = 0;
            if ( gxTv_SdtAreaResponsavel_Arearesponsavelid != value )
            {
               gxTv_SdtAreaResponsavel_Mode = "INS";
               this.gxTv_SdtAreaResponsavel_Arearesponsavelid_Z_SetNull( );
               this.gxTv_SdtAreaResponsavel_Arearesponsavelnome_Z_SetNull( );
               this.gxTv_SdtAreaResponsavel_Arearesponsavelativo_Z_SetNull( );
            }
            gxTv_SdtAreaResponsavel_Arearesponsavelid = value;
            SetDirty("Arearesponsavelid");
         }

      }

      [  SoapElement( ElementName = "AreaResponsavelNome" )]
      [  XmlElement( ElementName = "AreaResponsavelNome"   )]
      public string gxTpr_Arearesponsavelnome
      {
         get {
            return gxTv_SdtAreaResponsavel_Arearesponsavelnome ;
         }

         set {
            gxTv_SdtAreaResponsavel_N = 0;
            gxTv_SdtAreaResponsavel_Arearesponsavelnome = value;
            SetDirty("Arearesponsavelnome");
         }

      }

      [  SoapElement( ElementName = "AreaResponsavelAtivo" )]
      [  XmlElement( ElementName = "AreaResponsavelAtivo"   )]
      public bool gxTpr_Arearesponsavelativo
      {
         get {
            return gxTv_SdtAreaResponsavel_Arearesponsavelativo ;
         }

         set {
            gxTv_SdtAreaResponsavel_N = 0;
            gxTv_SdtAreaResponsavel_Arearesponsavelativo = value;
            SetDirty("Arearesponsavelativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtAreaResponsavel_Mode ;
         }

         set {
            gxTv_SdtAreaResponsavel_N = 0;
            gxTv_SdtAreaResponsavel_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtAreaResponsavel_Mode_SetNull( )
      {
         gxTv_SdtAreaResponsavel_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtAreaResponsavel_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtAreaResponsavel_Initialized ;
         }

         set {
            gxTv_SdtAreaResponsavel_N = 0;
            gxTv_SdtAreaResponsavel_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtAreaResponsavel_Initialized_SetNull( )
      {
         gxTv_SdtAreaResponsavel_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtAreaResponsavel_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AreaResponsavelId_Z" )]
      [  XmlElement( ElementName = "AreaResponsavelId_Z"   )]
      public int gxTpr_Arearesponsavelid_Z
      {
         get {
            return gxTv_SdtAreaResponsavel_Arearesponsavelid_Z ;
         }

         set {
            gxTv_SdtAreaResponsavel_N = 0;
            gxTv_SdtAreaResponsavel_Arearesponsavelid_Z = value;
            SetDirty("Arearesponsavelid_Z");
         }

      }

      public void gxTv_SdtAreaResponsavel_Arearesponsavelid_Z_SetNull( )
      {
         gxTv_SdtAreaResponsavel_Arearesponsavelid_Z = 0;
         SetDirty("Arearesponsavelid_Z");
         return  ;
      }

      public bool gxTv_SdtAreaResponsavel_Arearesponsavelid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AreaResponsavelNome_Z" )]
      [  XmlElement( ElementName = "AreaResponsavelNome_Z"   )]
      public string gxTpr_Arearesponsavelnome_Z
      {
         get {
            return gxTv_SdtAreaResponsavel_Arearesponsavelnome_Z ;
         }

         set {
            gxTv_SdtAreaResponsavel_N = 0;
            gxTv_SdtAreaResponsavel_Arearesponsavelnome_Z = value;
            SetDirty("Arearesponsavelnome_Z");
         }

      }

      public void gxTv_SdtAreaResponsavel_Arearesponsavelnome_Z_SetNull( )
      {
         gxTv_SdtAreaResponsavel_Arearesponsavelnome_Z = "";
         SetDirty("Arearesponsavelnome_Z");
         return  ;
      }

      public bool gxTv_SdtAreaResponsavel_Arearesponsavelnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AreaResponsavelAtivo_Z" )]
      [  XmlElement( ElementName = "AreaResponsavelAtivo_Z"   )]
      public bool gxTpr_Arearesponsavelativo_Z
      {
         get {
            return gxTv_SdtAreaResponsavel_Arearesponsavelativo_Z ;
         }

         set {
            gxTv_SdtAreaResponsavel_N = 0;
            gxTv_SdtAreaResponsavel_Arearesponsavelativo_Z = value;
            SetDirty("Arearesponsavelativo_Z");
         }

      }

      public void gxTv_SdtAreaResponsavel_Arearesponsavelativo_Z_SetNull( )
      {
         gxTv_SdtAreaResponsavel_Arearesponsavelativo_Z = false;
         SetDirty("Arearesponsavelativo_Z");
         return  ;
      }

      public bool gxTv_SdtAreaResponsavel_Arearesponsavelativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AreaResponsavelId_N" )]
      [  XmlElement( ElementName = "AreaResponsavelId_N"   )]
      public short gxTpr_Arearesponsavelid_N
      {
         get {
            return gxTv_SdtAreaResponsavel_Arearesponsavelid_N ;
         }

         set {
            gxTv_SdtAreaResponsavel_N = 0;
            gxTv_SdtAreaResponsavel_Arearesponsavelid_N = value;
            SetDirty("Arearesponsavelid_N");
         }

      }

      public void gxTv_SdtAreaResponsavel_Arearesponsavelid_N_SetNull( )
      {
         gxTv_SdtAreaResponsavel_Arearesponsavelid_N = 0;
         SetDirty("Arearesponsavelid_N");
         return  ;
      }

      public bool gxTv_SdtAreaResponsavel_Arearesponsavelid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtAreaResponsavel_N = 1;
         gxTv_SdtAreaResponsavel_Arearesponsavelnome = "";
         gxTv_SdtAreaResponsavel_Mode = "";
         gxTv_SdtAreaResponsavel_Arearesponsavelnome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "arearesponsavel", "GeneXus.Programs.arearesponsavel_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtAreaResponsavel_N ;
      }

      private short gxTv_SdtAreaResponsavel_N ;
      private short gxTv_SdtAreaResponsavel_Initialized ;
      private short gxTv_SdtAreaResponsavel_Arearesponsavelid_N ;
      private int gxTv_SdtAreaResponsavel_Arearesponsavelid ;
      private int gxTv_SdtAreaResponsavel_Arearesponsavelid_Z ;
      private string gxTv_SdtAreaResponsavel_Mode ;
      private bool gxTv_SdtAreaResponsavel_Arearesponsavelativo ;
      private bool gxTv_SdtAreaResponsavel_Arearesponsavelativo_Z ;
      private string gxTv_SdtAreaResponsavel_Arearesponsavelnome ;
      private string gxTv_SdtAreaResponsavel_Arearesponsavelnome_Z ;
   }

   [DataContract(Name = @"AreaResponsavel", Namespace = "LGPD_Novo")]
   public class SdtAreaResponsavel_RESTInterface : GxGenericCollectionItem<SdtAreaResponsavel>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtAreaResponsavel_RESTInterface( ) : base()
      {
      }

      public SdtAreaResponsavel_RESTInterface( SdtAreaResponsavel psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AreaResponsavelId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Arearesponsavelid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Arearesponsavelid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Arearesponsavelid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "AreaResponsavelNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Arearesponsavelnome
      {
         get {
            return sdt.gxTpr_Arearesponsavelnome ;
         }

         set {
            sdt.gxTpr_Arearesponsavelnome = value;
         }

      }

      [DataMember( Name = "AreaResponsavelAtivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Arearesponsavelativo
      {
         get {
            return sdt.gxTpr_Arearesponsavelativo ;
         }

         set {
            sdt.gxTpr_Arearesponsavelativo = value;
         }

      }

      public SdtAreaResponsavel sdt
      {
         get {
            return (SdtAreaResponsavel)Sdt ;
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
            sdt = new SdtAreaResponsavel() ;
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

   [DataContract(Name = @"AreaResponsavel", Namespace = "LGPD_Novo")]
   public class SdtAreaResponsavel_RESTLInterface : GxGenericCollectionItem<SdtAreaResponsavel>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtAreaResponsavel_RESTLInterface( ) : base()
      {
      }

      public SdtAreaResponsavel_RESTLInterface( SdtAreaResponsavel psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AreaResponsavelNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Arearesponsavelnome
      {
         get {
            return sdt.gxTpr_Arearesponsavelnome ;
         }

         set {
            sdt.gxTpr_Arearesponsavelnome = value;
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

      public SdtAreaResponsavel sdt
      {
         get {
            return (SdtAreaResponsavel)Sdt ;
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
            sdt = new SdtAreaResponsavel() ;
         }
      }

   }

}
