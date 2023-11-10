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
   [XmlRoot(ElementName = "TipoDescarte" )]
   [XmlType(TypeName =  "TipoDescarte" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtTipoDescarte : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTipoDescarte( )
      {
      }

      public SdtTipoDescarte( IGxContext context )
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

      public void Load( int AV45TipoDescarteId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV45TipoDescarteId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TipoDescarteId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "TipoDescarte");
         metadata.Set("BT", "TipoDescarte");
         metadata.Set("PK", "[ \"TipoDescarteId\" ]");
         metadata.Set("PKAssigned", "[ \"TipoDescarteId\" ]");
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
         state.Add("gxTpr_Tipodescarteid_Z");
         state.Add("gxTpr_Tipodescartenome_Z");
         state.Add("gxTpr_Tipodescarteativo_Z");
         state.Add("gxTpr_Tipodescarteid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTipoDescarte sdt;
         sdt = (SdtTipoDescarte)(source);
         gxTv_SdtTipoDescarte_Tipodescarteid = sdt.gxTv_SdtTipoDescarte_Tipodescarteid ;
         gxTv_SdtTipoDescarte_Tipodescartenome = sdt.gxTv_SdtTipoDescarte_Tipodescartenome ;
         gxTv_SdtTipoDescarte_Tipodescarteativo = sdt.gxTv_SdtTipoDescarte_Tipodescarteativo ;
         gxTv_SdtTipoDescarte_Mode = sdt.gxTv_SdtTipoDescarte_Mode ;
         gxTv_SdtTipoDescarte_Initialized = sdt.gxTv_SdtTipoDescarte_Initialized ;
         gxTv_SdtTipoDescarte_Tipodescarteid_Z = sdt.gxTv_SdtTipoDescarte_Tipodescarteid_Z ;
         gxTv_SdtTipoDescarte_Tipodescartenome_Z = sdt.gxTv_SdtTipoDescarte_Tipodescartenome_Z ;
         gxTv_SdtTipoDescarte_Tipodescarteativo_Z = sdt.gxTv_SdtTipoDescarte_Tipodescarteativo_Z ;
         gxTv_SdtTipoDescarte_Tipodescarteid_N = sdt.gxTv_SdtTipoDescarte_Tipodescarteid_N ;
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
         AddObjectProperty("TipoDescarteId", gxTv_SdtTipoDescarte_Tipodescarteid, false, includeNonInitialized);
         AddObjectProperty("TipoDescarteId_N", gxTv_SdtTipoDescarte_Tipodescarteid_N, false, includeNonInitialized);
         AddObjectProperty("TipoDescarteNome", gxTv_SdtTipoDescarte_Tipodescartenome, false, includeNonInitialized);
         AddObjectProperty("TipoDescarteAtivo", gxTv_SdtTipoDescarte_Tipodescarteativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTipoDescarte_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTipoDescarte_Initialized, false, includeNonInitialized);
            AddObjectProperty("TipoDescarteId_Z", gxTv_SdtTipoDescarte_Tipodescarteid_Z, false, includeNonInitialized);
            AddObjectProperty("TipoDescarteNome_Z", gxTv_SdtTipoDescarte_Tipodescartenome_Z, false, includeNonInitialized);
            AddObjectProperty("TipoDescarteAtivo_Z", gxTv_SdtTipoDescarte_Tipodescarteativo_Z, false, includeNonInitialized);
            AddObjectProperty("TipoDescarteId_N", gxTv_SdtTipoDescarte_Tipodescarteid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTipoDescarte sdt )
      {
         if ( sdt.IsDirty("TipoDescarteId") )
         {
            gxTv_SdtTipoDescarte_N = 0;
            gxTv_SdtTipoDescarte_Tipodescarteid = sdt.gxTv_SdtTipoDescarte_Tipodescarteid ;
         }
         if ( sdt.IsDirty("TipoDescarteNome") )
         {
            gxTv_SdtTipoDescarte_N = 0;
            gxTv_SdtTipoDescarte_Tipodescartenome = sdt.gxTv_SdtTipoDescarte_Tipodescartenome ;
         }
         if ( sdt.IsDirty("TipoDescarteAtivo") )
         {
            gxTv_SdtTipoDescarte_N = 0;
            gxTv_SdtTipoDescarte_Tipodescarteativo = sdt.gxTv_SdtTipoDescarte_Tipodescarteativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TipoDescarteId" )]
      [  XmlElement( ElementName = "TipoDescarteId"   )]
      public int gxTpr_Tipodescarteid
      {
         get {
            return gxTv_SdtTipoDescarte_Tipodescarteid ;
         }

         set {
            gxTv_SdtTipoDescarte_N = 0;
            if ( gxTv_SdtTipoDescarte_Tipodescarteid != value )
            {
               gxTv_SdtTipoDescarte_Mode = "INS";
               this.gxTv_SdtTipoDescarte_Tipodescarteid_Z_SetNull( );
               this.gxTv_SdtTipoDescarte_Tipodescartenome_Z_SetNull( );
               this.gxTv_SdtTipoDescarte_Tipodescarteativo_Z_SetNull( );
            }
            gxTv_SdtTipoDescarte_Tipodescarteid = value;
            SetDirty("Tipodescarteid");
         }

      }

      [  SoapElement( ElementName = "TipoDescarteNome" )]
      [  XmlElement( ElementName = "TipoDescarteNome"   )]
      public string gxTpr_Tipodescartenome
      {
         get {
            return gxTv_SdtTipoDescarte_Tipodescartenome ;
         }

         set {
            gxTv_SdtTipoDescarte_N = 0;
            gxTv_SdtTipoDescarte_Tipodescartenome = value;
            SetDirty("Tipodescartenome");
         }

      }

      [  SoapElement( ElementName = "TipoDescarteAtivo" )]
      [  XmlElement( ElementName = "TipoDescarteAtivo"   )]
      public bool gxTpr_Tipodescarteativo
      {
         get {
            return gxTv_SdtTipoDescarte_Tipodescarteativo ;
         }

         set {
            gxTv_SdtTipoDescarte_N = 0;
            gxTv_SdtTipoDescarte_Tipodescarteativo = value;
            SetDirty("Tipodescarteativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTipoDescarte_Mode ;
         }

         set {
            gxTv_SdtTipoDescarte_N = 0;
            gxTv_SdtTipoDescarte_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTipoDescarte_Mode_SetNull( )
      {
         gxTv_SdtTipoDescarte_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTipoDescarte_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTipoDescarte_Initialized ;
         }

         set {
            gxTv_SdtTipoDescarte_N = 0;
            gxTv_SdtTipoDescarte_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTipoDescarte_Initialized_SetNull( )
      {
         gxTv_SdtTipoDescarte_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTipoDescarte_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoDescarteId_Z" )]
      [  XmlElement( ElementName = "TipoDescarteId_Z"   )]
      public int gxTpr_Tipodescarteid_Z
      {
         get {
            return gxTv_SdtTipoDescarte_Tipodescarteid_Z ;
         }

         set {
            gxTv_SdtTipoDescarte_N = 0;
            gxTv_SdtTipoDescarte_Tipodescarteid_Z = value;
            SetDirty("Tipodescarteid_Z");
         }

      }

      public void gxTv_SdtTipoDescarte_Tipodescarteid_Z_SetNull( )
      {
         gxTv_SdtTipoDescarte_Tipodescarteid_Z = 0;
         SetDirty("Tipodescarteid_Z");
         return  ;
      }

      public bool gxTv_SdtTipoDescarte_Tipodescarteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoDescarteNome_Z" )]
      [  XmlElement( ElementName = "TipoDescarteNome_Z"   )]
      public string gxTpr_Tipodescartenome_Z
      {
         get {
            return gxTv_SdtTipoDescarte_Tipodescartenome_Z ;
         }

         set {
            gxTv_SdtTipoDescarte_N = 0;
            gxTv_SdtTipoDescarte_Tipodescartenome_Z = value;
            SetDirty("Tipodescartenome_Z");
         }

      }

      public void gxTv_SdtTipoDescarte_Tipodescartenome_Z_SetNull( )
      {
         gxTv_SdtTipoDescarte_Tipodescartenome_Z = "";
         SetDirty("Tipodescartenome_Z");
         return  ;
      }

      public bool gxTv_SdtTipoDescarte_Tipodescartenome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoDescarteAtivo_Z" )]
      [  XmlElement( ElementName = "TipoDescarteAtivo_Z"   )]
      public bool gxTpr_Tipodescarteativo_Z
      {
         get {
            return gxTv_SdtTipoDescarte_Tipodescarteativo_Z ;
         }

         set {
            gxTv_SdtTipoDescarte_N = 0;
            gxTv_SdtTipoDescarte_Tipodescarteativo_Z = value;
            SetDirty("Tipodescarteativo_Z");
         }

      }

      public void gxTv_SdtTipoDescarte_Tipodescarteativo_Z_SetNull( )
      {
         gxTv_SdtTipoDescarte_Tipodescarteativo_Z = false;
         SetDirty("Tipodescarteativo_Z");
         return  ;
      }

      public bool gxTv_SdtTipoDescarte_Tipodescarteativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoDescarteId_N" )]
      [  XmlElement( ElementName = "TipoDescarteId_N"   )]
      public short gxTpr_Tipodescarteid_N
      {
         get {
            return gxTv_SdtTipoDescarte_Tipodescarteid_N ;
         }

         set {
            gxTv_SdtTipoDescarte_N = 0;
            gxTv_SdtTipoDescarte_Tipodescarteid_N = value;
            SetDirty("Tipodescarteid_N");
         }

      }

      public void gxTv_SdtTipoDescarte_Tipodescarteid_N_SetNull( )
      {
         gxTv_SdtTipoDescarte_Tipodescarteid_N = 0;
         SetDirty("Tipodescarteid_N");
         return  ;
      }

      public bool gxTv_SdtTipoDescarte_Tipodescarteid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtTipoDescarte_N = 1;
         gxTv_SdtTipoDescarte_Tipodescartenome = "";
         gxTv_SdtTipoDescarte_Mode = "";
         gxTv_SdtTipoDescarte_Tipodescartenome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "tipodescarte", "GeneXus.Programs.tipodescarte_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtTipoDescarte_N ;
      }

      private short gxTv_SdtTipoDescarte_N ;
      private short gxTv_SdtTipoDescarte_Initialized ;
      private short gxTv_SdtTipoDescarte_Tipodescarteid_N ;
      private int gxTv_SdtTipoDescarte_Tipodescarteid ;
      private int gxTv_SdtTipoDescarte_Tipodescarteid_Z ;
      private string gxTv_SdtTipoDescarte_Mode ;
      private bool gxTv_SdtTipoDescarte_Tipodescarteativo ;
      private bool gxTv_SdtTipoDescarte_Tipodescarteativo_Z ;
      private string gxTv_SdtTipoDescarte_Tipodescartenome ;
      private string gxTv_SdtTipoDescarte_Tipodescartenome_Z ;
   }

   [DataContract(Name = @"TipoDescarte", Namespace = "LGPD_Novo")]
   public class SdtTipoDescarte_RESTInterface : GxGenericCollectionItem<SdtTipoDescarte>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTipoDescarte_RESTInterface( ) : base()
      {
      }

      public SdtTipoDescarte_RESTInterface( SdtTipoDescarte psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TipoDescarteId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Tipodescarteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Tipodescarteid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Tipodescarteid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "TipoDescarteNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Tipodescartenome
      {
         get {
            return sdt.gxTpr_Tipodescartenome ;
         }

         set {
            sdt.gxTpr_Tipodescartenome = value;
         }

      }

      [DataMember( Name = "TipoDescarteAtivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Tipodescarteativo
      {
         get {
            return sdt.gxTpr_Tipodescarteativo ;
         }

         set {
            sdt.gxTpr_Tipodescarteativo = value;
         }

      }

      public SdtTipoDescarte sdt
      {
         get {
            return (SdtTipoDescarte)Sdt ;
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
            sdt = new SdtTipoDescarte() ;
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

   [DataContract(Name = @"TipoDescarte", Namespace = "LGPD_Novo")]
   public class SdtTipoDescarte_RESTLInterface : GxGenericCollectionItem<SdtTipoDescarte>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTipoDescarte_RESTLInterface( ) : base()
      {
      }

      public SdtTipoDescarte_RESTLInterface( SdtTipoDescarte psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TipoDescarteNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Tipodescartenome
      {
         get {
            return sdt.gxTpr_Tipodescartenome ;
         }

         set {
            sdt.gxTpr_Tipodescartenome = value;
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

      public SdtTipoDescarte sdt
      {
         get {
            return (SdtTipoDescarte)Sdt ;
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
            sdt = new SdtTipoDescarte() ;
         }
      }

   }

}
