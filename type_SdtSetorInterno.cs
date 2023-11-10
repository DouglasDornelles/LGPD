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
   [XmlRoot(ElementName = "SetorInterno" )]
   [XmlType(TypeName =  "SetorInterno" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtSetorInterno : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtSetorInterno( )
      {
      }

      public SdtSetorInterno( IGxContext context )
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

      public void Load( int AV60SetorInternoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV60SetorInternoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SetorInternoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "SetorInterno");
         metadata.Set("BT", "SetorInterno");
         metadata.Set("PK", "[ \"SetorInternoId\" ]");
         metadata.Set("PKAssigned", "[ \"SetorInternoId\" ]");
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
         state.Add("gxTpr_Setorinternoid_Z");
         state.Add("gxTpr_Setorinternonome_Z");
         state.Add("gxTpr_Setorinternoativo_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtSetorInterno sdt;
         sdt = (SdtSetorInterno)(source);
         gxTv_SdtSetorInterno_Setorinternoid = sdt.gxTv_SdtSetorInterno_Setorinternoid ;
         gxTv_SdtSetorInterno_Setorinternonome = sdt.gxTv_SdtSetorInterno_Setorinternonome ;
         gxTv_SdtSetorInterno_Setorinternoativo = sdt.gxTv_SdtSetorInterno_Setorinternoativo ;
         gxTv_SdtSetorInterno_Mode = sdt.gxTv_SdtSetorInterno_Mode ;
         gxTv_SdtSetorInterno_Initialized = sdt.gxTv_SdtSetorInterno_Initialized ;
         gxTv_SdtSetorInterno_Setorinternoid_Z = sdt.gxTv_SdtSetorInterno_Setorinternoid_Z ;
         gxTv_SdtSetorInterno_Setorinternonome_Z = sdt.gxTv_SdtSetorInterno_Setorinternonome_Z ;
         gxTv_SdtSetorInterno_Setorinternoativo_Z = sdt.gxTv_SdtSetorInterno_Setorinternoativo_Z ;
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
         AddObjectProperty("SetorInternoId", gxTv_SdtSetorInterno_Setorinternoid, false, includeNonInitialized);
         AddObjectProperty("SetorInternoNome", gxTv_SdtSetorInterno_Setorinternonome, false, includeNonInitialized);
         AddObjectProperty("SetorInternoAtivo", gxTv_SdtSetorInterno_Setorinternoativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSetorInterno_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSetorInterno_Initialized, false, includeNonInitialized);
            AddObjectProperty("SetorInternoId_Z", gxTv_SdtSetorInterno_Setorinternoid_Z, false, includeNonInitialized);
            AddObjectProperty("SetorInternoNome_Z", gxTv_SdtSetorInterno_Setorinternonome_Z, false, includeNonInitialized);
            AddObjectProperty("SetorInternoAtivo_Z", gxTv_SdtSetorInterno_Setorinternoativo_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtSetorInterno sdt )
      {
         if ( sdt.IsDirty("SetorInternoId") )
         {
            gxTv_SdtSetorInterno_N = 0;
            gxTv_SdtSetorInterno_Setorinternoid = sdt.gxTv_SdtSetorInterno_Setorinternoid ;
         }
         if ( sdt.IsDirty("SetorInternoNome") )
         {
            gxTv_SdtSetorInterno_N = 0;
            gxTv_SdtSetorInterno_Setorinternonome = sdt.gxTv_SdtSetorInterno_Setorinternonome ;
         }
         if ( sdt.IsDirty("SetorInternoAtivo") )
         {
            gxTv_SdtSetorInterno_N = 0;
            gxTv_SdtSetorInterno_Setorinternoativo = sdt.gxTv_SdtSetorInterno_Setorinternoativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SetorInternoId" )]
      [  XmlElement( ElementName = "SetorInternoId"   )]
      public int gxTpr_Setorinternoid
      {
         get {
            return gxTv_SdtSetorInterno_Setorinternoid ;
         }

         set {
            gxTv_SdtSetorInterno_N = 0;
            if ( gxTv_SdtSetorInterno_Setorinternoid != value )
            {
               gxTv_SdtSetorInterno_Mode = "INS";
               this.gxTv_SdtSetorInterno_Setorinternoid_Z_SetNull( );
               this.gxTv_SdtSetorInterno_Setorinternonome_Z_SetNull( );
               this.gxTv_SdtSetorInterno_Setorinternoativo_Z_SetNull( );
            }
            gxTv_SdtSetorInterno_Setorinternoid = value;
            SetDirty("Setorinternoid");
         }

      }

      [  SoapElement( ElementName = "SetorInternoNome" )]
      [  XmlElement( ElementName = "SetorInternoNome"   )]
      public string gxTpr_Setorinternonome
      {
         get {
            return gxTv_SdtSetorInterno_Setorinternonome ;
         }

         set {
            gxTv_SdtSetorInterno_N = 0;
            gxTv_SdtSetorInterno_Setorinternonome = value;
            SetDirty("Setorinternonome");
         }

      }

      [  SoapElement( ElementName = "SetorInternoAtivo" )]
      [  XmlElement( ElementName = "SetorInternoAtivo"   )]
      public bool gxTpr_Setorinternoativo
      {
         get {
            return gxTv_SdtSetorInterno_Setorinternoativo ;
         }

         set {
            gxTv_SdtSetorInterno_N = 0;
            gxTv_SdtSetorInterno_Setorinternoativo = value;
            SetDirty("Setorinternoativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSetorInterno_Mode ;
         }

         set {
            gxTv_SdtSetorInterno_N = 0;
            gxTv_SdtSetorInterno_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSetorInterno_Mode_SetNull( )
      {
         gxTv_SdtSetorInterno_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSetorInterno_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSetorInterno_Initialized ;
         }

         set {
            gxTv_SdtSetorInterno_N = 0;
            gxTv_SdtSetorInterno_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSetorInterno_Initialized_SetNull( )
      {
         gxTv_SdtSetorInterno_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSetorInterno_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SetorInternoId_Z" )]
      [  XmlElement( ElementName = "SetorInternoId_Z"   )]
      public int gxTpr_Setorinternoid_Z
      {
         get {
            return gxTv_SdtSetorInterno_Setorinternoid_Z ;
         }

         set {
            gxTv_SdtSetorInterno_N = 0;
            gxTv_SdtSetorInterno_Setorinternoid_Z = value;
            SetDirty("Setorinternoid_Z");
         }

      }

      public void gxTv_SdtSetorInterno_Setorinternoid_Z_SetNull( )
      {
         gxTv_SdtSetorInterno_Setorinternoid_Z = 0;
         SetDirty("Setorinternoid_Z");
         return  ;
      }

      public bool gxTv_SdtSetorInterno_Setorinternoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SetorInternoNome_Z" )]
      [  XmlElement( ElementName = "SetorInternoNome_Z"   )]
      public string gxTpr_Setorinternonome_Z
      {
         get {
            return gxTv_SdtSetorInterno_Setorinternonome_Z ;
         }

         set {
            gxTv_SdtSetorInterno_N = 0;
            gxTv_SdtSetorInterno_Setorinternonome_Z = value;
            SetDirty("Setorinternonome_Z");
         }

      }

      public void gxTv_SdtSetorInterno_Setorinternonome_Z_SetNull( )
      {
         gxTv_SdtSetorInterno_Setorinternonome_Z = "";
         SetDirty("Setorinternonome_Z");
         return  ;
      }

      public bool gxTv_SdtSetorInterno_Setorinternonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SetorInternoAtivo_Z" )]
      [  XmlElement( ElementName = "SetorInternoAtivo_Z"   )]
      public bool gxTpr_Setorinternoativo_Z
      {
         get {
            return gxTv_SdtSetorInterno_Setorinternoativo_Z ;
         }

         set {
            gxTv_SdtSetorInterno_N = 0;
            gxTv_SdtSetorInterno_Setorinternoativo_Z = value;
            SetDirty("Setorinternoativo_Z");
         }

      }

      public void gxTv_SdtSetorInterno_Setorinternoativo_Z_SetNull( )
      {
         gxTv_SdtSetorInterno_Setorinternoativo_Z = false;
         SetDirty("Setorinternoativo_Z");
         return  ;
      }

      public bool gxTv_SdtSetorInterno_Setorinternoativo_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtSetorInterno_N = 1;
         gxTv_SdtSetorInterno_Setorinternonome = "";
         gxTv_SdtSetorInterno_Mode = "";
         gxTv_SdtSetorInterno_Setorinternonome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "setorinterno", "GeneXus.Programs.setorinterno_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtSetorInterno_N ;
      }

      private short gxTv_SdtSetorInterno_N ;
      private short gxTv_SdtSetorInterno_Initialized ;
      private int gxTv_SdtSetorInterno_Setorinternoid ;
      private int gxTv_SdtSetorInterno_Setorinternoid_Z ;
      private string gxTv_SdtSetorInterno_Mode ;
      private bool gxTv_SdtSetorInterno_Setorinternoativo ;
      private bool gxTv_SdtSetorInterno_Setorinternoativo_Z ;
      private string gxTv_SdtSetorInterno_Setorinternonome ;
      private string gxTv_SdtSetorInterno_Setorinternonome_Z ;
   }

   [DataContract(Name = @"SetorInterno", Namespace = "LGPD_Novo")]
   public class SdtSetorInterno_RESTInterface : GxGenericCollectionItem<SdtSetorInterno>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtSetorInterno_RESTInterface( ) : base()
      {
      }

      public SdtSetorInterno_RESTInterface( SdtSetorInterno psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SetorInternoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Setorinternoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Setorinternoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Setorinternoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "SetorInternoNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Setorinternonome
      {
         get {
            return sdt.gxTpr_Setorinternonome ;
         }

         set {
            sdt.gxTpr_Setorinternonome = value;
         }

      }

      [DataMember( Name = "SetorInternoAtivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Setorinternoativo
      {
         get {
            return sdt.gxTpr_Setorinternoativo ;
         }

         set {
            sdt.gxTpr_Setorinternoativo = value;
         }

      }

      public SdtSetorInterno sdt
      {
         get {
            return (SdtSetorInterno)Sdt ;
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
            sdt = new SdtSetorInterno() ;
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

   [DataContract(Name = @"SetorInterno", Namespace = "LGPD_Novo")]
   public class SdtSetorInterno_RESTLInterface : GxGenericCollectionItem<SdtSetorInterno>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtSetorInterno_RESTLInterface( ) : base()
      {
      }

      public SdtSetorInterno_RESTLInterface( SdtSetorInterno psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SetorInternoNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Setorinternonome
      {
         get {
            return sdt.gxTpr_Setorinternonome ;
         }

         set {
            sdt.gxTpr_Setorinternonome = value;
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

      public SdtSetorInterno sdt
      {
         get {
            return (SdtSetorInterno)Sdt ;
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
            sdt = new SdtSetorInterno() ;
         }
      }

   }

}
