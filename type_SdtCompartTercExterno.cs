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
   [XmlRoot(ElementName = "CompartTercExterno" )]
   [XmlType(TypeName =  "CompartTercExterno" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtCompartTercExterno : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtCompartTercExterno( )
      {
      }

      public SdtCompartTercExterno( IGxContext context )
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

      public void Load( int AV66CompartTercExternoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV66CompartTercExternoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CompartTercExternoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "CompartTercExterno");
         metadata.Set("BT", "CompartTercExterno");
         metadata.Set("PK", "[ \"CompartTercExternoId\" ]");
         metadata.Set("PKAssigned", "[ \"CompartTercExternoId\" ]");
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
         state.Add("gxTpr_Comparttercexternoid_Z");
         state.Add("gxTpr_Comparttercexternonome_Z");
         state.Add("gxTpr_Comparttercexternoativo_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCompartTercExterno sdt;
         sdt = (SdtCompartTercExterno)(source);
         gxTv_SdtCompartTercExterno_Comparttercexternoid = sdt.gxTv_SdtCompartTercExterno_Comparttercexternoid ;
         gxTv_SdtCompartTercExterno_Comparttercexternonome = sdt.gxTv_SdtCompartTercExterno_Comparttercexternonome ;
         gxTv_SdtCompartTercExterno_Comparttercexternoativo = sdt.gxTv_SdtCompartTercExterno_Comparttercexternoativo ;
         gxTv_SdtCompartTercExterno_Mode = sdt.gxTv_SdtCompartTercExterno_Mode ;
         gxTv_SdtCompartTercExterno_Initialized = sdt.gxTv_SdtCompartTercExterno_Initialized ;
         gxTv_SdtCompartTercExterno_Comparttercexternoid_Z = sdt.gxTv_SdtCompartTercExterno_Comparttercexternoid_Z ;
         gxTv_SdtCompartTercExterno_Comparttercexternonome_Z = sdt.gxTv_SdtCompartTercExterno_Comparttercexternonome_Z ;
         gxTv_SdtCompartTercExterno_Comparttercexternoativo_Z = sdt.gxTv_SdtCompartTercExterno_Comparttercexternoativo_Z ;
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
         AddObjectProperty("CompartTercExternoId", gxTv_SdtCompartTercExterno_Comparttercexternoid, false, includeNonInitialized);
         AddObjectProperty("CompartTercExternoNome", gxTv_SdtCompartTercExterno_Comparttercexternonome, false, includeNonInitialized);
         AddObjectProperty("CompartTercExternoAtivo", gxTv_SdtCompartTercExterno_Comparttercexternoativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCompartTercExterno_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCompartTercExterno_Initialized, false, includeNonInitialized);
            AddObjectProperty("CompartTercExternoId_Z", gxTv_SdtCompartTercExterno_Comparttercexternoid_Z, false, includeNonInitialized);
            AddObjectProperty("CompartTercExternoNome_Z", gxTv_SdtCompartTercExterno_Comparttercexternonome_Z, false, includeNonInitialized);
            AddObjectProperty("CompartTercExternoAtivo_Z", gxTv_SdtCompartTercExterno_Comparttercexternoativo_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCompartTercExterno sdt )
      {
         if ( sdt.IsDirty("CompartTercExternoId") )
         {
            gxTv_SdtCompartTercExterno_N = 0;
            gxTv_SdtCompartTercExterno_Comparttercexternoid = sdt.gxTv_SdtCompartTercExterno_Comparttercexternoid ;
         }
         if ( sdt.IsDirty("CompartTercExternoNome") )
         {
            gxTv_SdtCompartTercExterno_N = 0;
            gxTv_SdtCompartTercExterno_Comparttercexternonome = sdt.gxTv_SdtCompartTercExterno_Comparttercexternonome ;
         }
         if ( sdt.IsDirty("CompartTercExternoAtivo") )
         {
            gxTv_SdtCompartTercExterno_N = 0;
            gxTv_SdtCompartTercExterno_Comparttercexternoativo = sdt.gxTv_SdtCompartTercExterno_Comparttercexternoativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CompartTercExternoId" )]
      [  XmlElement( ElementName = "CompartTercExternoId"   )]
      public int gxTpr_Comparttercexternoid
      {
         get {
            return gxTv_SdtCompartTercExterno_Comparttercexternoid ;
         }

         set {
            gxTv_SdtCompartTercExterno_N = 0;
            if ( gxTv_SdtCompartTercExterno_Comparttercexternoid != value )
            {
               gxTv_SdtCompartTercExterno_Mode = "INS";
               this.gxTv_SdtCompartTercExterno_Comparttercexternoid_Z_SetNull( );
               this.gxTv_SdtCompartTercExterno_Comparttercexternonome_Z_SetNull( );
               this.gxTv_SdtCompartTercExterno_Comparttercexternoativo_Z_SetNull( );
            }
            gxTv_SdtCompartTercExterno_Comparttercexternoid = value;
            SetDirty("Comparttercexternoid");
         }

      }

      [  SoapElement( ElementName = "CompartTercExternoNome" )]
      [  XmlElement( ElementName = "CompartTercExternoNome"   )]
      public string gxTpr_Comparttercexternonome
      {
         get {
            return gxTv_SdtCompartTercExterno_Comparttercexternonome ;
         }

         set {
            gxTv_SdtCompartTercExterno_N = 0;
            gxTv_SdtCompartTercExterno_Comparttercexternonome = value;
            SetDirty("Comparttercexternonome");
         }

      }

      [  SoapElement( ElementName = "CompartTercExternoAtivo" )]
      [  XmlElement( ElementName = "CompartTercExternoAtivo"   )]
      public bool gxTpr_Comparttercexternoativo
      {
         get {
            return gxTv_SdtCompartTercExterno_Comparttercexternoativo ;
         }

         set {
            gxTv_SdtCompartTercExterno_N = 0;
            gxTv_SdtCompartTercExterno_Comparttercexternoativo = value;
            SetDirty("Comparttercexternoativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCompartTercExterno_Mode ;
         }

         set {
            gxTv_SdtCompartTercExterno_N = 0;
            gxTv_SdtCompartTercExterno_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCompartTercExterno_Mode_SetNull( )
      {
         gxTv_SdtCompartTercExterno_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCompartTercExterno_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCompartTercExterno_Initialized ;
         }

         set {
            gxTv_SdtCompartTercExterno_N = 0;
            gxTv_SdtCompartTercExterno_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCompartTercExterno_Initialized_SetNull( )
      {
         gxTv_SdtCompartTercExterno_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCompartTercExterno_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CompartTercExternoId_Z" )]
      [  XmlElement( ElementName = "CompartTercExternoId_Z"   )]
      public int gxTpr_Comparttercexternoid_Z
      {
         get {
            return gxTv_SdtCompartTercExterno_Comparttercexternoid_Z ;
         }

         set {
            gxTv_SdtCompartTercExterno_N = 0;
            gxTv_SdtCompartTercExterno_Comparttercexternoid_Z = value;
            SetDirty("Comparttercexternoid_Z");
         }

      }

      public void gxTv_SdtCompartTercExterno_Comparttercexternoid_Z_SetNull( )
      {
         gxTv_SdtCompartTercExterno_Comparttercexternoid_Z = 0;
         SetDirty("Comparttercexternoid_Z");
         return  ;
      }

      public bool gxTv_SdtCompartTercExterno_Comparttercexternoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CompartTercExternoNome_Z" )]
      [  XmlElement( ElementName = "CompartTercExternoNome_Z"   )]
      public string gxTpr_Comparttercexternonome_Z
      {
         get {
            return gxTv_SdtCompartTercExterno_Comparttercexternonome_Z ;
         }

         set {
            gxTv_SdtCompartTercExterno_N = 0;
            gxTv_SdtCompartTercExterno_Comparttercexternonome_Z = value;
            SetDirty("Comparttercexternonome_Z");
         }

      }

      public void gxTv_SdtCompartTercExterno_Comparttercexternonome_Z_SetNull( )
      {
         gxTv_SdtCompartTercExterno_Comparttercexternonome_Z = "";
         SetDirty("Comparttercexternonome_Z");
         return  ;
      }

      public bool gxTv_SdtCompartTercExterno_Comparttercexternonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CompartTercExternoAtivo_Z" )]
      [  XmlElement( ElementName = "CompartTercExternoAtivo_Z"   )]
      public bool gxTpr_Comparttercexternoativo_Z
      {
         get {
            return gxTv_SdtCompartTercExterno_Comparttercexternoativo_Z ;
         }

         set {
            gxTv_SdtCompartTercExterno_N = 0;
            gxTv_SdtCompartTercExterno_Comparttercexternoativo_Z = value;
            SetDirty("Comparttercexternoativo_Z");
         }

      }

      public void gxTv_SdtCompartTercExterno_Comparttercexternoativo_Z_SetNull( )
      {
         gxTv_SdtCompartTercExterno_Comparttercexternoativo_Z = false;
         SetDirty("Comparttercexternoativo_Z");
         return  ;
      }

      public bool gxTv_SdtCompartTercExterno_Comparttercexternoativo_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtCompartTercExterno_N = 1;
         gxTv_SdtCompartTercExterno_Comparttercexternonome = "";
         gxTv_SdtCompartTercExterno_Mode = "";
         gxTv_SdtCompartTercExterno_Comparttercexternonome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "comparttercexterno", "GeneXus.Programs.comparttercexterno_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtCompartTercExterno_N ;
      }

      private short gxTv_SdtCompartTercExterno_N ;
      private short gxTv_SdtCompartTercExterno_Initialized ;
      private int gxTv_SdtCompartTercExterno_Comparttercexternoid ;
      private int gxTv_SdtCompartTercExterno_Comparttercexternoid_Z ;
      private string gxTv_SdtCompartTercExterno_Mode ;
      private bool gxTv_SdtCompartTercExterno_Comparttercexternoativo ;
      private bool gxTv_SdtCompartTercExterno_Comparttercexternoativo_Z ;
      private string gxTv_SdtCompartTercExterno_Comparttercexternonome ;
      private string gxTv_SdtCompartTercExterno_Comparttercexternonome_Z ;
   }

   [DataContract(Name = @"CompartTercExterno", Namespace = "LGPD_Novo")]
   public class SdtCompartTercExterno_RESTInterface : GxGenericCollectionItem<SdtCompartTercExterno>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtCompartTercExterno_RESTInterface( ) : base()
      {
      }

      public SdtCompartTercExterno_RESTInterface( SdtCompartTercExterno psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CompartTercExternoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Comparttercexternoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Comparttercexternoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Comparttercexternoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "CompartTercExternoNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Comparttercexternonome
      {
         get {
            return sdt.gxTpr_Comparttercexternonome ;
         }

         set {
            sdt.gxTpr_Comparttercexternonome = value;
         }

      }

      [DataMember( Name = "CompartTercExternoAtivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Comparttercexternoativo
      {
         get {
            return sdt.gxTpr_Comparttercexternoativo ;
         }

         set {
            sdt.gxTpr_Comparttercexternoativo = value;
         }

      }

      public SdtCompartTercExterno sdt
      {
         get {
            return (SdtCompartTercExterno)Sdt ;
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
            sdt = new SdtCompartTercExterno() ;
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

   [DataContract(Name = @"CompartTercExterno", Namespace = "LGPD_Novo")]
   public class SdtCompartTercExterno_RESTLInterface : GxGenericCollectionItem<SdtCompartTercExterno>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtCompartTercExterno_RESTLInterface( ) : base()
      {
      }

      public SdtCompartTercExterno_RESTLInterface( SdtCompartTercExterno psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CompartTercExternoNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Comparttercexternonome
      {
         get {
            return sdt.gxTpr_Comparttercexternonome ;
         }

         set {
            sdt.gxTpr_Comparttercexternonome = value;
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

      public SdtCompartTercExterno sdt
      {
         get {
            return (SdtCompartTercExterno)Sdt ;
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
            sdt = new SdtCompartTercExterno() ;
         }
      }

   }

}
