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
   [XmlRoot(ElementName = "FonteRetencao" )]
   [XmlType(TypeName =  "FonteRetencao" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtFonteRetencao : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtFonteRetencao( )
      {
      }

      public SdtFonteRetencao( IGxContext context )
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

      public void Load( int AV63FonteRetencaoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV63FonteRetencaoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"FonteRetencaoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "FonteRetencao");
         metadata.Set("BT", "FonteRetencao");
         metadata.Set("PK", "[ \"FonteRetencaoId\" ]");
         metadata.Set("PKAssigned", "[ \"FonteRetencaoId\" ]");
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
         state.Add("gxTpr_Fonteretencaonome_Z");
         state.Add("gxTpr_Fonteretencaoativo_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtFonteRetencao sdt;
         sdt = (SdtFonteRetencao)(source);
         gxTv_SdtFonteRetencao_Fonteretencaoid = sdt.gxTv_SdtFonteRetencao_Fonteretencaoid ;
         gxTv_SdtFonteRetencao_Fonteretencaonome = sdt.gxTv_SdtFonteRetencao_Fonteretencaonome ;
         gxTv_SdtFonteRetencao_Fonteretencaoativo = sdt.gxTv_SdtFonteRetencao_Fonteretencaoativo ;
         gxTv_SdtFonteRetencao_Mode = sdt.gxTv_SdtFonteRetencao_Mode ;
         gxTv_SdtFonteRetencao_Initialized = sdt.gxTv_SdtFonteRetencao_Initialized ;
         gxTv_SdtFonteRetencao_Fonteretencaoid_Z = sdt.gxTv_SdtFonteRetencao_Fonteretencaoid_Z ;
         gxTv_SdtFonteRetencao_Fonteretencaonome_Z = sdt.gxTv_SdtFonteRetencao_Fonteretencaonome_Z ;
         gxTv_SdtFonteRetencao_Fonteretencaoativo_Z = sdt.gxTv_SdtFonteRetencao_Fonteretencaoativo_Z ;
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
         AddObjectProperty("FonteRetencaoId", gxTv_SdtFonteRetencao_Fonteretencaoid, false, includeNonInitialized);
         AddObjectProperty("FonteRetencaoNome", gxTv_SdtFonteRetencao_Fonteretencaonome, false, includeNonInitialized);
         AddObjectProperty("FonteRetencaoAtivo", gxTv_SdtFonteRetencao_Fonteretencaoativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtFonteRetencao_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtFonteRetencao_Initialized, false, includeNonInitialized);
            AddObjectProperty("FonteRetencaoId_Z", gxTv_SdtFonteRetencao_Fonteretencaoid_Z, false, includeNonInitialized);
            AddObjectProperty("FonteRetencaoNome_Z", gxTv_SdtFonteRetencao_Fonteretencaonome_Z, false, includeNonInitialized);
            AddObjectProperty("FonteRetencaoAtivo_Z", gxTv_SdtFonteRetencao_Fonteretencaoativo_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtFonteRetencao sdt )
      {
         if ( sdt.IsDirty("FonteRetencaoId") )
         {
            gxTv_SdtFonteRetencao_N = 0;
            gxTv_SdtFonteRetencao_Fonteretencaoid = sdt.gxTv_SdtFonteRetencao_Fonteretencaoid ;
         }
         if ( sdt.IsDirty("FonteRetencaoNome") )
         {
            gxTv_SdtFonteRetencao_N = 0;
            gxTv_SdtFonteRetencao_Fonteretencaonome = sdt.gxTv_SdtFonteRetencao_Fonteretencaonome ;
         }
         if ( sdt.IsDirty("FonteRetencaoAtivo") )
         {
            gxTv_SdtFonteRetencao_N = 0;
            gxTv_SdtFonteRetencao_Fonteretencaoativo = sdt.gxTv_SdtFonteRetencao_Fonteretencaoativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "FonteRetencaoId" )]
      [  XmlElement( ElementName = "FonteRetencaoId"   )]
      public int gxTpr_Fonteretencaoid
      {
         get {
            return gxTv_SdtFonteRetencao_Fonteretencaoid ;
         }

         set {
            gxTv_SdtFonteRetencao_N = 0;
            if ( gxTv_SdtFonteRetencao_Fonteretencaoid != value )
            {
               gxTv_SdtFonteRetencao_Mode = "INS";
               this.gxTv_SdtFonteRetencao_Fonteretencaoid_Z_SetNull( );
               this.gxTv_SdtFonteRetencao_Fonteretencaonome_Z_SetNull( );
               this.gxTv_SdtFonteRetencao_Fonteretencaoativo_Z_SetNull( );
            }
            gxTv_SdtFonteRetencao_Fonteretencaoid = value;
            SetDirty("Fonteretencaoid");
         }

      }

      [  SoapElement( ElementName = "FonteRetencaoNome" )]
      [  XmlElement( ElementName = "FonteRetencaoNome"   )]
      public string gxTpr_Fonteretencaonome
      {
         get {
            return gxTv_SdtFonteRetencao_Fonteretencaonome ;
         }

         set {
            gxTv_SdtFonteRetencao_N = 0;
            gxTv_SdtFonteRetencao_Fonteretencaonome = value;
            SetDirty("Fonteretencaonome");
         }

      }

      [  SoapElement( ElementName = "FonteRetencaoAtivo" )]
      [  XmlElement( ElementName = "FonteRetencaoAtivo"   )]
      public bool gxTpr_Fonteretencaoativo
      {
         get {
            return gxTv_SdtFonteRetencao_Fonteretencaoativo ;
         }

         set {
            gxTv_SdtFonteRetencao_N = 0;
            gxTv_SdtFonteRetencao_Fonteretencaoativo = value;
            SetDirty("Fonteretencaoativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtFonteRetencao_Mode ;
         }

         set {
            gxTv_SdtFonteRetencao_N = 0;
            gxTv_SdtFonteRetencao_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtFonteRetencao_Mode_SetNull( )
      {
         gxTv_SdtFonteRetencao_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtFonteRetencao_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtFonteRetencao_Initialized ;
         }

         set {
            gxTv_SdtFonteRetencao_N = 0;
            gxTv_SdtFonteRetencao_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtFonteRetencao_Initialized_SetNull( )
      {
         gxTv_SdtFonteRetencao_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtFonteRetencao_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FonteRetencaoId_Z" )]
      [  XmlElement( ElementName = "FonteRetencaoId_Z"   )]
      public int gxTpr_Fonteretencaoid_Z
      {
         get {
            return gxTv_SdtFonteRetencao_Fonteretencaoid_Z ;
         }

         set {
            gxTv_SdtFonteRetencao_N = 0;
            gxTv_SdtFonteRetencao_Fonteretencaoid_Z = value;
            SetDirty("Fonteretencaoid_Z");
         }

      }

      public void gxTv_SdtFonteRetencao_Fonteretencaoid_Z_SetNull( )
      {
         gxTv_SdtFonteRetencao_Fonteretencaoid_Z = 0;
         SetDirty("Fonteretencaoid_Z");
         return  ;
      }

      public bool gxTv_SdtFonteRetencao_Fonteretencaoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FonteRetencaoNome_Z" )]
      [  XmlElement( ElementName = "FonteRetencaoNome_Z"   )]
      public string gxTpr_Fonteretencaonome_Z
      {
         get {
            return gxTv_SdtFonteRetencao_Fonteretencaonome_Z ;
         }

         set {
            gxTv_SdtFonteRetencao_N = 0;
            gxTv_SdtFonteRetencao_Fonteretencaonome_Z = value;
            SetDirty("Fonteretencaonome_Z");
         }

      }

      public void gxTv_SdtFonteRetencao_Fonteretencaonome_Z_SetNull( )
      {
         gxTv_SdtFonteRetencao_Fonteretencaonome_Z = "";
         SetDirty("Fonteretencaonome_Z");
         return  ;
      }

      public bool gxTv_SdtFonteRetencao_Fonteretencaonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FonteRetencaoAtivo_Z" )]
      [  XmlElement( ElementName = "FonteRetencaoAtivo_Z"   )]
      public bool gxTpr_Fonteretencaoativo_Z
      {
         get {
            return gxTv_SdtFonteRetencao_Fonteretencaoativo_Z ;
         }

         set {
            gxTv_SdtFonteRetencao_N = 0;
            gxTv_SdtFonteRetencao_Fonteretencaoativo_Z = value;
            SetDirty("Fonteretencaoativo_Z");
         }

      }

      public void gxTv_SdtFonteRetencao_Fonteretencaoativo_Z_SetNull( )
      {
         gxTv_SdtFonteRetencao_Fonteretencaoativo_Z = false;
         SetDirty("Fonteretencaoativo_Z");
         return  ;
      }

      public bool gxTv_SdtFonteRetencao_Fonteretencaoativo_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtFonteRetencao_N = 1;
         gxTv_SdtFonteRetencao_Fonteretencaonome = "";
         gxTv_SdtFonteRetencao_Mode = "";
         gxTv_SdtFonteRetencao_Fonteretencaonome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "fonteretencao", "GeneXus.Programs.fonteretencao_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtFonteRetencao_N ;
      }

      private short gxTv_SdtFonteRetencao_N ;
      private short gxTv_SdtFonteRetencao_Initialized ;
      private int gxTv_SdtFonteRetencao_Fonteretencaoid ;
      private int gxTv_SdtFonteRetencao_Fonteretencaoid_Z ;
      private string gxTv_SdtFonteRetencao_Mode ;
      private bool gxTv_SdtFonteRetencao_Fonteretencaoativo ;
      private bool gxTv_SdtFonteRetencao_Fonteretencaoativo_Z ;
      private string gxTv_SdtFonteRetencao_Fonteretencaonome ;
      private string gxTv_SdtFonteRetencao_Fonteretencaonome_Z ;
   }

   [DataContract(Name = @"FonteRetencao", Namespace = "LGPD_Novo")]
   public class SdtFonteRetencao_RESTInterface : GxGenericCollectionItem<SdtFonteRetencao>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtFonteRetencao_RESTInterface( ) : base()
      {
      }

      public SdtFonteRetencao_RESTInterface( SdtFonteRetencao psdt ) : base(psdt)
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

      [DataMember( Name = "FonteRetencaoNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Fonteretencaonome
      {
         get {
            return sdt.gxTpr_Fonteretencaonome ;
         }

         set {
            sdt.gxTpr_Fonteretencaonome = value;
         }

      }

      [DataMember( Name = "FonteRetencaoAtivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Fonteretencaoativo
      {
         get {
            return sdt.gxTpr_Fonteretencaoativo ;
         }

         set {
            sdt.gxTpr_Fonteretencaoativo = value;
         }

      }

      public SdtFonteRetencao sdt
      {
         get {
            return (SdtFonteRetencao)Sdt ;
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
            sdt = new SdtFonteRetencao() ;
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

   [DataContract(Name = @"FonteRetencao", Namespace = "LGPD_Novo")]
   public class SdtFonteRetencao_RESTLInterface : GxGenericCollectionItem<SdtFonteRetencao>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtFonteRetencao_RESTLInterface( ) : base()
      {
      }

      public SdtFonteRetencao_RESTLInterface( SdtFonteRetencao psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "FonteRetencaoNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Fonteretencaonome
      {
         get {
            return sdt.gxTpr_Fonteretencaonome ;
         }

         set {
            sdt.gxTpr_Fonteretencaonome = value;
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

      public SdtFonteRetencao sdt
      {
         get {
            return (SdtFonteRetencao)Sdt ;
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
            sdt = new SdtFonteRetencao() ;
         }
      }

   }

}
