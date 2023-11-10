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
   [XmlRoot(ElementName = "DocFonteRetencao" )]
   [XmlType(TypeName =  "DocFonteRetencao" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtDocFonteRetencao : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocFonteRetencao( )
      {
      }

      public SdtDocFonteRetencao( IGxContext context )
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

      public void Load( int AV63FonteRetencaoId ,
                        int AV75DocumentoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV63FonteRetencaoId,(int)AV75DocumentoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"FonteRetencaoId", typeof(int)}, new Object[]{"DocumentoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "DocFonteRetencao");
         metadata.Set("BT", "DocFonteRetencao");
         metadata.Set("PK", "[ \"FonteRetencaoId\",\"DocumentoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"DocumentoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"FonteRetencaoId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Fonteretencaoid_Z");
         state.Add("gxTpr_Documentoid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtDocFonteRetencao sdt;
         sdt = (SdtDocFonteRetencao)(source);
         gxTv_SdtDocFonteRetencao_Fonteretencaoid = sdt.gxTv_SdtDocFonteRetencao_Fonteretencaoid ;
         gxTv_SdtDocFonteRetencao_Documentoid = sdt.gxTv_SdtDocFonteRetencao_Documentoid ;
         gxTv_SdtDocFonteRetencao_Mode = sdt.gxTv_SdtDocFonteRetencao_Mode ;
         gxTv_SdtDocFonteRetencao_Initialized = sdt.gxTv_SdtDocFonteRetencao_Initialized ;
         gxTv_SdtDocFonteRetencao_Fonteretencaoid_Z = sdt.gxTv_SdtDocFonteRetencao_Fonteretencaoid_Z ;
         gxTv_SdtDocFonteRetencao_Documentoid_Z = sdt.gxTv_SdtDocFonteRetencao_Documentoid_Z ;
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
         AddObjectProperty("FonteRetencaoId", gxTv_SdtDocFonteRetencao_Fonteretencaoid, false, includeNonInitialized);
         AddObjectProperty("DocumentoId", gxTv_SdtDocFonteRetencao_Documentoid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtDocFonteRetencao_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtDocFonteRetencao_Initialized, false, includeNonInitialized);
            AddObjectProperty("FonteRetencaoId_Z", gxTv_SdtDocFonteRetencao_Fonteretencaoid_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoId_Z", gxTv_SdtDocFonteRetencao_Documentoid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtDocFonteRetencao sdt )
      {
         if ( sdt.IsDirty("FonteRetencaoId") )
         {
            gxTv_SdtDocFonteRetencao_N = 0;
            gxTv_SdtDocFonteRetencao_Fonteretencaoid = sdt.gxTv_SdtDocFonteRetencao_Fonteretencaoid ;
         }
         if ( sdt.IsDirty("DocumentoId") )
         {
            gxTv_SdtDocFonteRetencao_N = 0;
            gxTv_SdtDocFonteRetencao_Documentoid = sdt.gxTv_SdtDocFonteRetencao_Documentoid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "FonteRetencaoId" )]
      [  XmlElement( ElementName = "FonteRetencaoId"   )]
      public int gxTpr_Fonteretencaoid
      {
         get {
            return gxTv_SdtDocFonteRetencao_Fonteretencaoid ;
         }

         set {
            gxTv_SdtDocFonteRetencao_N = 0;
            if ( gxTv_SdtDocFonteRetencao_Fonteretencaoid != value )
            {
               gxTv_SdtDocFonteRetencao_Mode = "INS";
               this.gxTv_SdtDocFonteRetencao_Fonteretencaoid_Z_SetNull( );
               this.gxTv_SdtDocFonteRetencao_Documentoid_Z_SetNull( );
            }
            gxTv_SdtDocFonteRetencao_Fonteretencaoid = value;
            SetDirty("Fonteretencaoid");
         }

      }

      [  SoapElement( ElementName = "DocumentoId" )]
      [  XmlElement( ElementName = "DocumentoId"   )]
      public int gxTpr_Documentoid
      {
         get {
            return gxTv_SdtDocFonteRetencao_Documentoid ;
         }

         set {
            gxTv_SdtDocFonteRetencao_N = 0;
            if ( gxTv_SdtDocFonteRetencao_Documentoid != value )
            {
               gxTv_SdtDocFonteRetencao_Mode = "INS";
               this.gxTv_SdtDocFonteRetencao_Fonteretencaoid_Z_SetNull( );
               this.gxTv_SdtDocFonteRetencao_Documentoid_Z_SetNull( );
            }
            gxTv_SdtDocFonteRetencao_Documentoid = value;
            SetDirty("Documentoid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtDocFonteRetencao_Mode ;
         }

         set {
            gxTv_SdtDocFonteRetencao_N = 0;
            gxTv_SdtDocFonteRetencao_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtDocFonteRetencao_Mode_SetNull( )
      {
         gxTv_SdtDocFonteRetencao_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtDocFonteRetencao_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtDocFonteRetencao_Initialized ;
         }

         set {
            gxTv_SdtDocFonteRetencao_N = 0;
            gxTv_SdtDocFonteRetencao_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtDocFonteRetencao_Initialized_SetNull( )
      {
         gxTv_SdtDocFonteRetencao_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtDocFonteRetencao_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FonteRetencaoId_Z" )]
      [  XmlElement( ElementName = "FonteRetencaoId_Z"   )]
      public int gxTpr_Fonteretencaoid_Z
      {
         get {
            return gxTv_SdtDocFonteRetencao_Fonteretencaoid_Z ;
         }

         set {
            gxTv_SdtDocFonteRetencao_N = 0;
            gxTv_SdtDocFonteRetencao_Fonteretencaoid_Z = value;
            SetDirty("Fonteretencaoid_Z");
         }

      }

      public void gxTv_SdtDocFonteRetencao_Fonteretencaoid_Z_SetNull( )
      {
         gxTv_SdtDocFonteRetencao_Fonteretencaoid_Z = 0;
         SetDirty("Fonteretencaoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocFonteRetencao_Fonteretencaoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoId_Z" )]
      [  XmlElement( ElementName = "DocumentoId_Z"   )]
      public int gxTpr_Documentoid_Z
      {
         get {
            return gxTv_SdtDocFonteRetencao_Documentoid_Z ;
         }

         set {
            gxTv_SdtDocFonteRetencao_N = 0;
            gxTv_SdtDocFonteRetencao_Documentoid_Z = value;
            SetDirty("Documentoid_Z");
         }

      }

      public void gxTv_SdtDocFonteRetencao_Documentoid_Z_SetNull( )
      {
         gxTv_SdtDocFonteRetencao_Documentoid_Z = 0;
         SetDirty("Documentoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocFonteRetencao_Documentoid_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtDocFonteRetencao_N = 1;
         gxTv_SdtDocFonteRetencao_Mode = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "docfonteretencao", "GeneXus.Programs.docfonteretencao_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtDocFonteRetencao_N ;
      }

      private short gxTv_SdtDocFonteRetencao_N ;
      private short gxTv_SdtDocFonteRetencao_Initialized ;
      private int gxTv_SdtDocFonteRetencao_Fonteretencaoid ;
      private int gxTv_SdtDocFonteRetencao_Documentoid ;
      private int gxTv_SdtDocFonteRetencao_Fonteretencaoid_Z ;
      private int gxTv_SdtDocFonteRetencao_Documentoid_Z ;
      private string gxTv_SdtDocFonteRetencao_Mode ;
   }

   [DataContract(Name = @"DocFonteRetencao", Namespace = "LGPD_Novo")]
   public class SdtDocFonteRetencao_RESTInterface : GxGenericCollectionItem<SdtDocFonteRetencao>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocFonteRetencao_RESTInterface( ) : base()
      {
      }

      public SdtDocFonteRetencao_RESTInterface( SdtDocFonteRetencao psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "FonteRetencaoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Fonteretencaoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Fonteretencaoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Fonteretencaoid = (int)(NumberUtil.Val( value, "."));
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

      public SdtDocFonteRetencao sdt
      {
         get {
            return (SdtDocFonteRetencao)Sdt ;
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
            sdt = new SdtDocFonteRetencao() ;
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

   [DataContract(Name = @"DocFonteRetencao", Namespace = "LGPD_Novo")]
   public class SdtDocFonteRetencao_RESTLInterface : GxGenericCollectionItem<SdtDocFonteRetencao>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocFonteRetencao_RESTLInterface( ) : base()
      {
      }

      public SdtDocFonteRetencao_RESTLInterface( SdtDocFonteRetencao psdt ) : base(psdt)
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

      public SdtDocFonteRetencao sdt
      {
         get {
            return (SdtDocFonteRetencao)Sdt ;
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
            sdt = new SdtDocFonteRetencao() ;
         }
      }

   }

}
