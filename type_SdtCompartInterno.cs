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
   [XmlRoot(ElementName = "CompartInterno" )]
   [XmlType(TypeName =  "CompartInterno" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtCompartInterno : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtCompartInterno( )
      {
      }

      public SdtCompartInterno( IGxContext context )
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

      public void Load( int AV57CompartInternoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV57CompartInternoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CompartInternoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "CompartInterno");
         metadata.Set("BT", "CompartInterno");
         metadata.Set("PK", "[ \"CompartInternoId\" ]");
         metadata.Set("PKAssigned", "[ \"CompartInternoId\" ]");
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
         state.Add("gxTpr_Compartinternoid_Z");
         state.Add("gxTpr_Compartinternonome_Z");
         state.Add("gxTpr_Compartinternoativo_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCompartInterno sdt;
         sdt = (SdtCompartInterno)(source);
         gxTv_SdtCompartInterno_Compartinternoid = sdt.gxTv_SdtCompartInterno_Compartinternoid ;
         gxTv_SdtCompartInterno_Compartinternonome = sdt.gxTv_SdtCompartInterno_Compartinternonome ;
         gxTv_SdtCompartInterno_Compartinternoativo = sdt.gxTv_SdtCompartInterno_Compartinternoativo ;
         gxTv_SdtCompartInterno_Mode = sdt.gxTv_SdtCompartInterno_Mode ;
         gxTv_SdtCompartInterno_Initialized = sdt.gxTv_SdtCompartInterno_Initialized ;
         gxTv_SdtCompartInterno_Compartinternoid_Z = sdt.gxTv_SdtCompartInterno_Compartinternoid_Z ;
         gxTv_SdtCompartInterno_Compartinternonome_Z = sdt.gxTv_SdtCompartInterno_Compartinternonome_Z ;
         gxTv_SdtCompartInterno_Compartinternoativo_Z = sdt.gxTv_SdtCompartInterno_Compartinternoativo_Z ;
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
         AddObjectProperty("CompartInternoId", gxTv_SdtCompartInterno_Compartinternoid, false, includeNonInitialized);
         AddObjectProperty("CompartInternoNome", gxTv_SdtCompartInterno_Compartinternonome, false, includeNonInitialized);
         AddObjectProperty("CompartInternoAtivo", gxTv_SdtCompartInterno_Compartinternoativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCompartInterno_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCompartInterno_Initialized, false, includeNonInitialized);
            AddObjectProperty("CompartInternoId_Z", gxTv_SdtCompartInterno_Compartinternoid_Z, false, includeNonInitialized);
            AddObjectProperty("CompartInternoNome_Z", gxTv_SdtCompartInterno_Compartinternonome_Z, false, includeNonInitialized);
            AddObjectProperty("CompartInternoAtivo_Z", gxTv_SdtCompartInterno_Compartinternoativo_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCompartInterno sdt )
      {
         if ( sdt.IsDirty("CompartInternoId") )
         {
            gxTv_SdtCompartInterno_N = 0;
            gxTv_SdtCompartInterno_Compartinternoid = sdt.gxTv_SdtCompartInterno_Compartinternoid ;
         }
         if ( sdt.IsDirty("CompartInternoNome") )
         {
            gxTv_SdtCompartInterno_N = 0;
            gxTv_SdtCompartInterno_Compartinternonome = sdt.gxTv_SdtCompartInterno_Compartinternonome ;
         }
         if ( sdt.IsDirty("CompartInternoAtivo") )
         {
            gxTv_SdtCompartInterno_N = 0;
            gxTv_SdtCompartInterno_Compartinternoativo = sdt.gxTv_SdtCompartInterno_Compartinternoativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CompartInternoId" )]
      [  XmlElement( ElementName = "CompartInternoId"   )]
      public int gxTpr_Compartinternoid
      {
         get {
            return gxTv_SdtCompartInterno_Compartinternoid ;
         }

         set {
            gxTv_SdtCompartInterno_N = 0;
            if ( gxTv_SdtCompartInterno_Compartinternoid != value )
            {
               gxTv_SdtCompartInterno_Mode = "INS";
               this.gxTv_SdtCompartInterno_Compartinternoid_Z_SetNull( );
               this.gxTv_SdtCompartInterno_Compartinternonome_Z_SetNull( );
               this.gxTv_SdtCompartInterno_Compartinternoativo_Z_SetNull( );
            }
            gxTv_SdtCompartInterno_Compartinternoid = value;
            SetDirty("Compartinternoid");
         }

      }

      [  SoapElement( ElementName = "CompartInternoNome" )]
      [  XmlElement( ElementName = "CompartInternoNome"   )]
      public string gxTpr_Compartinternonome
      {
         get {
            return gxTv_SdtCompartInterno_Compartinternonome ;
         }

         set {
            gxTv_SdtCompartInterno_N = 0;
            gxTv_SdtCompartInterno_Compartinternonome = value;
            SetDirty("Compartinternonome");
         }

      }

      [  SoapElement( ElementName = "CompartInternoAtivo" )]
      [  XmlElement( ElementName = "CompartInternoAtivo"   )]
      public bool gxTpr_Compartinternoativo
      {
         get {
            return gxTv_SdtCompartInterno_Compartinternoativo ;
         }

         set {
            gxTv_SdtCompartInterno_N = 0;
            gxTv_SdtCompartInterno_Compartinternoativo = value;
            SetDirty("Compartinternoativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCompartInterno_Mode ;
         }

         set {
            gxTv_SdtCompartInterno_N = 0;
            gxTv_SdtCompartInterno_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCompartInterno_Mode_SetNull( )
      {
         gxTv_SdtCompartInterno_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCompartInterno_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCompartInterno_Initialized ;
         }

         set {
            gxTv_SdtCompartInterno_N = 0;
            gxTv_SdtCompartInterno_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCompartInterno_Initialized_SetNull( )
      {
         gxTv_SdtCompartInterno_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCompartInterno_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CompartInternoId_Z" )]
      [  XmlElement( ElementName = "CompartInternoId_Z"   )]
      public int gxTpr_Compartinternoid_Z
      {
         get {
            return gxTv_SdtCompartInterno_Compartinternoid_Z ;
         }

         set {
            gxTv_SdtCompartInterno_N = 0;
            gxTv_SdtCompartInterno_Compartinternoid_Z = value;
            SetDirty("Compartinternoid_Z");
         }

      }

      public void gxTv_SdtCompartInterno_Compartinternoid_Z_SetNull( )
      {
         gxTv_SdtCompartInterno_Compartinternoid_Z = 0;
         SetDirty("Compartinternoid_Z");
         return  ;
      }

      public bool gxTv_SdtCompartInterno_Compartinternoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CompartInternoNome_Z" )]
      [  XmlElement( ElementName = "CompartInternoNome_Z"   )]
      public string gxTpr_Compartinternonome_Z
      {
         get {
            return gxTv_SdtCompartInterno_Compartinternonome_Z ;
         }

         set {
            gxTv_SdtCompartInterno_N = 0;
            gxTv_SdtCompartInterno_Compartinternonome_Z = value;
            SetDirty("Compartinternonome_Z");
         }

      }

      public void gxTv_SdtCompartInterno_Compartinternonome_Z_SetNull( )
      {
         gxTv_SdtCompartInterno_Compartinternonome_Z = "";
         SetDirty("Compartinternonome_Z");
         return  ;
      }

      public bool gxTv_SdtCompartInterno_Compartinternonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CompartInternoAtivo_Z" )]
      [  XmlElement( ElementName = "CompartInternoAtivo_Z"   )]
      public bool gxTpr_Compartinternoativo_Z
      {
         get {
            return gxTv_SdtCompartInterno_Compartinternoativo_Z ;
         }

         set {
            gxTv_SdtCompartInterno_N = 0;
            gxTv_SdtCompartInterno_Compartinternoativo_Z = value;
            SetDirty("Compartinternoativo_Z");
         }

      }

      public void gxTv_SdtCompartInterno_Compartinternoativo_Z_SetNull( )
      {
         gxTv_SdtCompartInterno_Compartinternoativo_Z = false;
         SetDirty("Compartinternoativo_Z");
         return  ;
      }

      public bool gxTv_SdtCompartInterno_Compartinternoativo_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtCompartInterno_N = 1;
         gxTv_SdtCompartInterno_Compartinternonome = "";
         gxTv_SdtCompartInterno_Mode = "";
         gxTv_SdtCompartInterno_Compartinternonome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "compartinterno", "GeneXus.Programs.compartinterno_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtCompartInterno_N ;
      }

      private short gxTv_SdtCompartInterno_N ;
      private short gxTv_SdtCompartInterno_Initialized ;
      private int gxTv_SdtCompartInterno_Compartinternoid ;
      private int gxTv_SdtCompartInterno_Compartinternoid_Z ;
      private string gxTv_SdtCompartInterno_Mode ;
      private bool gxTv_SdtCompartInterno_Compartinternoativo ;
      private bool gxTv_SdtCompartInterno_Compartinternoativo_Z ;
      private string gxTv_SdtCompartInterno_Compartinternonome ;
      private string gxTv_SdtCompartInterno_Compartinternonome_Z ;
   }

   [DataContract(Name = @"CompartInterno", Namespace = "LGPD_Novo")]
   public class SdtCompartInterno_RESTInterface : GxGenericCollectionItem<SdtCompartInterno>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtCompartInterno_RESTInterface( ) : base()
      {
      }

      public SdtCompartInterno_RESTInterface( SdtCompartInterno psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CompartInternoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Compartinternoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Compartinternoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Compartinternoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "CompartInternoNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Compartinternonome
      {
         get {
            return sdt.gxTpr_Compartinternonome ;
         }

         set {
            sdt.gxTpr_Compartinternonome = value;
         }

      }

      [DataMember( Name = "CompartInternoAtivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Compartinternoativo
      {
         get {
            return sdt.gxTpr_Compartinternoativo ;
         }

         set {
            sdt.gxTpr_Compartinternoativo = value;
         }

      }

      public SdtCompartInterno sdt
      {
         get {
            return (SdtCompartInterno)Sdt ;
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
            sdt = new SdtCompartInterno() ;
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

   [DataContract(Name = @"CompartInterno", Namespace = "LGPD_Novo")]
   public class SdtCompartInterno_RESTLInterface : GxGenericCollectionItem<SdtCompartInterno>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtCompartInterno_RESTLInterface( ) : base()
      {
      }

      public SdtCompartInterno_RESTLInterface( SdtCompartInterno psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CompartInternoNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Compartinternonome
      {
         get {
            return sdt.gxTpr_Compartinternonome ;
         }

         set {
            sdt.gxTpr_Compartinternonome = value;
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

      public SdtCompartInterno sdt
      {
         get {
            return (SdtCompartInterno)Sdt ;
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
            sdt = new SdtCompartInterno() ;
         }
      }

   }

}
