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
   [XmlRoot(ElementName = "DocSetorInterno" )]
   [XmlType(TypeName =  "DocSetorInterno" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtDocSetorInterno : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocSetorInterno( )
      {
      }

      public SdtDocSetorInterno( IGxContext context )
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

      public void Load( int AV60SetorInternoId ,
                        int AV75DocumentoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV60SetorInternoId,(int)AV75DocumentoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SetorInternoId", typeof(int)}, new Object[]{"DocumentoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "DocSetorInterno");
         metadata.Set("BT", "DocSetorInterno");
         metadata.Set("PK", "[ \"SetorInternoId\",\"DocumentoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"DocumentoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"SetorInternoId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Documentoid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtDocSetorInterno sdt;
         sdt = (SdtDocSetorInterno)(source);
         gxTv_SdtDocSetorInterno_Setorinternoid = sdt.gxTv_SdtDocSetorInterno_Setorinternoid ;
         gxTv_SdtDocSetorInterno_Documentoid = sdt.gxTv_SdtDocSetorInterno_Documentoid ;
         gxTv_SdtDocSetorInterno_Mode = sdt.gxTv_SdtDocSetorInterno_Mode ;
         gxTv_SdtDocSetorInterno_Initialized = sdt.gxTv_SdtDocSetorInterno_Initialized ;
         gxTv_SdtDocSetorInterno_Setorinternoid_Z = sdt.gxTv_SdtDocSetorInterno_Setorinternoid_Z ;
         gxTv_SdtDocSetorInterno_Documentoid_Z = sdt.gxTv_SdtDocSetorInterno_Documentoid_Z ;
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
         AddObjectProperty("SetorInternoId", gxTv_SdtDocSetorInterno_Setorinternoid, false, includeNonInitialized);
         AddObjectProperty("DocumentoId", gxTv_SdtDocSetorInterno_Documentoid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtDocSetorInterno_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtDocSetorInterno_Initialized, false, includeNonInitialized);
            AddObjectProperty("SetorInternoId_Z", gxTv_SdtDocSetorInterno_Setorinternoid_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoId_Z", gxTv_SdtDocSetorInterno_Documentoid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtDocSetorInterno sdt )
      {
         if ( sdt.IsDirty("SetorInternoId") )
         {
            gxTv_SdtDocSetorInterno_N = 0;
            gxTv_SdtDocSetorInterno_Setorinternoid = sdt.gxTv_SdtDocSetorInterno_Setorinternoid ;
         }
         if ( sdt.IsDirty("DocumentoId") )
         {
            gxTv_SdtDocSetorInterno_N = 0;
            gxTv_SdtDocSetorInterno_Documentoid = sdt.gxTv_SdtDocSetorInterno_Documentoid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SetorInternoId" )]
      [  XmlElement( ElementName = "SetorInternoId"   )]
      public int gxTpr_Setorinternoid
      {
         get {
            return gxTv_SdtDocSetorInterno_Setorinternoid ;
         }

         set {
            gxTv_SdtDocSetorInterno_N = 0;
            if ( gxTv_SdtDocSetorInterno_Setorinternoid != value )
            {
               gxTv_SdtDocSetorInterno_Mode = "INS";
               this.gxTv_SdtDocSetorInterno_Setorinternoid_Z_SetNull( );
               this.gxTv_SdtDocSetorInterno_Documentoid_Z_SetNull( );
            }
            gxTv_SdtDocSetorInterno_Setorinternoid = value;
            SetDirty("Setorinternoid");
         }

      }

      [  SoapElement( ElementName = "DocumentoId" )]
      [  XmlElement( ElementName = "DocumentoId"   )]
      public int gxTpr_Documentoid
      {
         get {
            return gxTv_SdtDocSetorInterno_Documentoid ;
         }

         set {
            gxTv_SdtDocSetorInterno_N = 0;
            if ( gxTv_SdtDocSetorInterno_Documentoid != value )
            {
               gxTv_SdtDocSetorInterno_Mode = "INS";
               this.gxTv_SdtDocSetorInterno_Setorinternoid_Z_SetNull( );
               this.gxTv_SdtDocSetorInterno_Documentoid_Z_SetNull( );
            }
            gxTv_SdtDocSetorInterno_Documentoid = value;
            SetDirty("Documentoid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtDocSetorInterno_Mode ;
         }

         set {
            gxTv_SdtDocSetorInterno_N = 0;
            gxTv_SdtDocSetorInterno_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtDocSetorInterno_Mode_SetNull( )
      {
         gxTv_SdtDocSetorInterno_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtDocSetorInterno_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtDocSetorInterno_Initialized ;
         }

         set {
            gxTv_SdtDocSetorInterno_N = 0;
            gxTv_SdtDocSetorInterno_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtDocSetorInterno_Initialized_SetNull( )
      {
         gxTv_SdtDocSetorInterno_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtDocSetorInterno_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SetorInternoId_Z" )]
      [  XmlElement( ElementName = "SetorInternoId_Z"   )]
      public int gxTpr_Setorinternoid_Z
      {
         get {
            return gxTv_SdtDocSetorInterno_Setorinternoid_Z ;
         }

         set {
            gxTv_SdtDocSetorInterno_N = 0;
            gxTv_SdtDocSetorInterno_Setorinternoid_Z = value;
            SetDirty("Setorinternoid_Z");
         }

      }

      public void gxTv_SdtDocSetorInterno_Setorinternoid_Z_SetNull( )
      {
         gxTv_SdtDocSetorInterno_Setorinternoid_Z = 0;
         SetDirty("Setorinternoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocSetorInterno_Setorinternoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoId_Z" )]
      [  XmlElement( ElementName = "DocumentoId_Z"   )]
      public int gxTpr_Documentoid_Z
      {
         get {
            return gxTv_SdtDocSetorInterno_Documentoid_Z ;
         }

         set {
            gxTv_SdtDocSetorInterno_N = 0;
            gxTv_SdtDocSetorInterno_Documentoid_Z = value;
            SetDirty("Documentoid_Z");
         }

      }

      public void gxTv_SdtDocSetorInterno_Documentoid_Z_SetNull( )
      {
         gxTv_SdtDocSetorInterno_Documentoid_Z = 0;
         SetDirty("Documentoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocSetorInterno_Documentoid_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtDocSetorInterno_N = 1;
         gxTv_SdtDocSetorInterno_Mode = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "docsetorinterno", "GeneXus.Programs.docsetorinterno_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtDocSetorInterno_N ;
      }

      private short gxTv_SdtDocSetorInterno_N ;
      private short gxTv_SdtDocSetorInterno_Initialized ;
      private int gxTv_SdtDocSetorInterno_Setorinternoid ;
      private int gxTv_SdtDocSetorInterno_Documentoid ;
      private int gxTv_SdtDocSetorInterno_Setorinternoid_Z ;
      private int gxTv_SdtDocSetorInterno_Documentoid_Z ;
      private string gxTv_SdtDocSetorInterno_Mode ;
   }

   [DataContract(Name = @"DocSetorInterno", Namespace = "LGPD_Novo")]
   public class SdtDocSetorInterno_RESTInterface : GxGenericCollectionItem<SdtDocSetorInterno>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocSetorInterno_RESTInterface( ) : base()
      {
      }

      public SdtDocSetorInterno_RESTInterface( SdtDocSetorInterno psdt ) : base(psdt)
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

      public SdtDocSetorInterno sdt
      {
         get {
            return (SdtDocSetorInterno)Sdt ;
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
            sdt = new SdtDocSetorInterno() ;
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

   [DataContract(Name = @"DocSetorInterno", Namespace = "LGPD_Novo")]
   public class SdtDocSetorInterno_RESTLInterface : GxGenericCollectionItem<SdtDocSetorInterno>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocSetorInterno_RESTLInterface( ) : base()
      {
      }

      public SdtDocSetorInterno_RESTLInterface( SdtDocSetorInterno psdt ) : base(psdt)
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

      public SdtDocSetorInterno sdt
      {
         get {
            return (SdtDocSetorInterno)Sdt ;
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
            sdt = new SdtDocSetorInterno() ;
         }
      }

   }

}
