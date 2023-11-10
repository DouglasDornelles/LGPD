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
   [XmlRoot(ElementName = "DocCompartInterno" )]
   [XmlType(TypeName =  "DocCompartInterno" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtDocCompartInterno : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocCompartInterno( )
      {
      }

      public SdtDocCompartInterno( IGxContext context )
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

      public void Load( int AV57CompartInternoId ,
                        int AV75DocumentoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV57CompartInternoId,(int)AV75DocumentoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CompartInternoId", typeof(int)}, new Object[]{"DocumentoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "DocCompartInterno");
         metadata.Set("BT", "DocCompartInterno");
         metadata.Set("PK", "[ \"CompartInternoId\",\"DocumentoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CompartInternoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"DocumentoId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Documentoid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtDocCompartInterno sdt;
         sdt = (SdtDocCompartInterno)(source);
         gxTv_SdtDocCompartInterno_Compartinternoid = sdt.gxTv_SdtDocCompartInterno_Compartinternoid ;
         gxTv_SdtDocCompartInterno_Documentoid = sdt.gxTv_SdtDocCompartInterno_Documentoid ;
         gxTv_SdtDocCompartInterno_Mode = sdt.gxTv_SdtDocCompartInterno_Mode ;
         gxTv_SdtDocCompartInterno_Initialized = sdt.gxTv_SdtDocCompartInterno_Initialized ;
         gxTv_SdtDocCompartInterno_Compartinternoid_Z = sdt.gxTv_SdtDocCompartInterno_Compartinternoid_Z ;
         gxTv_SdtDocCompartInterno_Documentoid_Z = sdt.gxTv_SdtDocCompartInterno_Documentoid_Z ;
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
         AddObjectProperty("CompartInternoId", gxTv_SdtDocCompartInterno_Compartinternoid, false, includeNonInitialized);
         AddObjectProperty("DocumentoId", gxTv_SdtDocCompartInterno_Documentoid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtDocCompartInterno_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtDocCompartInterno_Initialized, false, includeNonInitialized);
            AddObjectProperty("CompartInternoId_Z", gxTv_SdtDocCompartInterno_Compartinternoid_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoId_Z", gxTv_SdtDocCompartInterno_Documentoid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtDocCompartInterno sdt )
      {
         if ( sdt.IsDirty("CompartInternoId") )
         {
            gxTv_SdtDocCompartInterno_N = 0;
            gxTv_SdtDocCompartInterno_Compartinternoid = sdt.gxTv_SdtDocCompartInterno_Compartinternoid ;
         }
         if ( sdt.IsDirty("DocumentoId") )
         {
            gxTv_SdtDocCompartInterno_N = 0;
            gxTv_SdtDocCompartInterno_Documentoid = sdt.gxTv_SdtDocCompartInterno_Documentoid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CompartInternoId" )]
      [  XmlElement( ElementName = "CompartInternoId"   )]
      public int gxTpr_Compartinternoid
      {
         get {
            return gxTv_SdtDocCompartInterno_Compartinternoid ;
         }

         set {
            gxTv_SdtDocCompartInterno_N = 0;
            if ( gxTv_SdtDocCompartInterno_Compartinternoid != value )
            {
               gxTv_SdtDocCompartInterno_Mode = "INS";
               this.gxTv_SdtDocCompartInterno_Compartinternoid_Z_SetNull( );
               this.gxTv_SdtDocCompartInterno_Documentoid_Z_SetNull( );
            }
            gxTv_SdtDocCompartInterno_Compartinternoid = value;
            SetDirty("Compartinternoid");
         }

      }

      [  SoapElement( ElementName = "DocumentoId" )]
      [  XmlElement( ElementName = "DocumentoId"   )]
      public int gxTpr_Documentoid
      {
         get {
            return gxTv_SdtDocCompartInterno_Documentoid ;
         }

         set {
            gxTv_SdtDocCompartInterno_N = 0;
            if ( gxTv_SdtDocCompartInterno_Documentoid != value )
            {
               gxTv_SdtDocCompartInterno_Mode = "INS";
               this.gxTv_SdtDocCompartInterno_Compartinternoid_Z_SetNull( );
               this.gxTv_SdtDocCompartInterno_Documentoid_Z_SetNull( );
            }
            gxTv_SdtDocCompartInterno_Documentoid = value;
            SetDirty("Documentoid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtDocCompartInterno_Mode ;
         }

         set {
            gxTv_SdtDocCompartInterno_N = 0;
            gxTv_SdtDocCompartInterno_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtDocCompartInterno_Mode_SetNull( )
      {
         gxTv_SdtDocCompartInterno_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtDocCompartInterno_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtDocCompartInterno_Initialized ;
         }

         set {
            gxTv_SdtDocCompartInterno_N = 0;
            gxTv_SdtDocCompartInterno_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtDocCompartInterno_Initialized_SetNull( )
      {
         gxTv_SdtDocCompartInterno_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtDocCompartInterno_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CompartInternoId_Z" )]
      [  XmlElement( ElementName = "CompartInternoId_Z"   )]
      public int gxTpr_Compartinternoid_Z
      {
         get {
            return gxTv_SdtDocCompartInterno_Compartinternoid_Z ;
         }

         set {
            gxTv_SdtDocCompartInterno_N = 0;
            gxTv_SdtDocCompartInterno_Compartinternoid_Z = value;
            SetDirty("Compartinternoid_Z");
         }

      }

      public void gxTv_SdtDocCompartInterno_Compartinternoid_Z_SetNull( )
      {
         gxTv_SdtDocCompartInterno_Compartinternoid_Z = 0;
         SetDirty("Compartinternoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocCompartInterno_Compartinternoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoId_Z" )]
      [  XmlElement( ElementName = "DocumentoId_Z"   )]
      public int gxTpr_Documentoid_Z
      {
         get {
            return gxTv_SdtDocCompartInterno_Documentoid_Z ;
         }

         set {
            gxTv_SdtDocCompartInterno_N = 0;
            gxTv_SdtDocCompartInterno_Documentoid_Z = value;
            SetDirty("Documentoid_Z");
         }

      }

      public void gxTv_SdtDocCompartInterno_Documentoid_Z_SetNull( )
      {
         gxTv_SdtDocCompartInterno_Documentoid_Z = 0;
         SetDirty("Documentoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocCompartInterno_Documentoid_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtDocCompartInterno_N = 1;
         gxTv_SdtDocCompartInterno_Mode = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "doccompartinterno", "GeneXus.Programs.doccompartinterno_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtDocCompartInterno_N ;
      }

      private short gxTv_SdtDocCompartInterno_N ;
      private short gxTv_SdtDocCompartInterno_Initialized ;
      private int gxTv_SdtDocCompartInterno_Compartinternoid ;
      private int gxTv_SdtDocCompartInterno_Documentoid ;
      private int gxTv_SdtDocCompartInterno_Compartinternoid_Z ;
      private int gxTv_SdtDocCompartInterno_Documentoid_Z ;
      private string gxTv_SdtDocCompartInterno_Mode ;
   }

   [DataContract(Name = @"DocCompartInterno", Namespace = "LGPD_Novo")]
   public class SdtDocCompartInterno_RESTInterface : GxGenericCollectionItem<SdtDocCompartInterno>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocCompartInterno_RESTInterface( ) : base()
      {
      }

      public SdtDocCompartInterno_RESTInterface( SdtDocCompartInterno psdt ) : base(psdt)
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

      [DataMember( Name = "DocumentoId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Documentoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Documentoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Documentoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      public SdtDocCompartInterno sdt
      {
         get {
            return (SdtDocCompartInterno)Sdt ;
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
            sdt = new SdtDocCompartInterno() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 2 )]
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

   [DataContract(Name = @"DocCompartInterno", Namespace = "LGPD_Novo")]
   public class SdtDocCompartInterno_RESTLInterface : GxGenericCollectionItem<SdtDocCompartInterno>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocCompartInterno_RESTLInterface( ) : base()
      {
      }

      public SdtDocCompartInterno_RESTLInterface( SdtDocCompartInterno psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "uri", Order = 0 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtDocCompartInterno sdt
      {
         get {
            return (SdtDocCompartInterno)Sdt ;
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
            sdt = new SdtDocCompartInterno() ;
         }
      }

   }

}
