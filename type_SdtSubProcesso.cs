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
   [XmlRoot(ElementName = "SubProcesso" )]
   [XmlType(TypeName =  "SubProcesso" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtSubProcesso : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtSubProcesso( )
      {
      }

      public SdtSubProcesso( IGxContext context )
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

      public void Load( int AV20SubprocessoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV20SubprocessoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SubprocessoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "SubProcesso");
         metadata.Set("BT", "SubProcesso");
         metadata.Set("PK", "[ \"SubprocessoId\" ]");
         metadata.Set("PKAssigned", "[ \"SubprocessoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ProcessoId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Subprocessoid_Z");
         state.Add("gxTpr_Processoid_Z");
         state.Add("gxTpr_Processonome_Z");
         state.Add("gxTpr_Subprocessonome_Z");
         state.Add("gxTpr_Subprocessoativo_Z");
         state.Add("gxTpr_Subprocessoid_N");
         state.Add("gxTpr_Processoid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtSubProcesso sdt;
         sdt = (SdtSubProcesso)(source);
         gxTv_SdtSubProcesso_Subprocessoid = sdt.gxTv_SdtSubProcesso_Subprocessoid ;
         gxTv_SdtSubProcesso_Processoid = sdt.gxTv_SdtSubProcesso_Processoid ;
         gxTv_SdtSubProcesso_Processonome = sdt.gxTv_SdtSubProcesso_Processonome ;
         gxTv_SdtSubProcesso_Subprocessonome = sdt.gxTv_SdtSubProcesso_Subprocessonome ;
         gxTv_SdtSubProcesso_Subprocessoativo = sdt.gxTv_SdtSubProcesso_Subprocessoativo ;
         gxTv_SdtSubProcesso_Mode = sdt.gxTv_SdtSubProcesso_Mode ;
         gxTv_SdtSubProcesso_Initialized = sdt.gxTv_SdtSubProcesso_Initialized ;
         gxTv_SdtSubProcesso_Subprocessoid_Z = sdt.gxTv_SdtSubProcesso_Subprocessoid_Z ;
         gxTv_SdtSubProcesso_Processoid_Z = sdt.gxTv_SdtSubProcesso_Processoid_Z ;
         gxTv_SdtSubProcesso_Processonome_Z = sdt.gxTv_SdtSubProcesso_Processonome_Z ;
         gxTv_SdtSubProcesso_Subprocessonome_Z = sdt.gxTv_SdtSubProcesso_Subprocessonome_Z ;
         gxTv_SdtSubProcesso_Subprocessoativo_Z = sdt.gxTv_SdtSubProcesso_Subprocessoativo_Z ;
         gxTv_SdtSubProcesso_Subprocessoid_N = sdt.gxTv_SdtSubProcesso_Subprocessoid_N ;
         gxTv_SdtSubProcesso_Processoid_N = sdt.gxTv_SdtSubProcesso_Processoid_N ;
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
         AddObjectProperty("SubprocessoId", gxTv_SdtSubProcesso_Subprocessoid, false, includeNonInitialized);
         AddObjectProperty("SubprocessoId_N", gxTv_SdtSubProcesso_Subprocessoid_N, false, includeNonInitialized);
         AddObjectProperty("ProcessoId", gxTv_SdtSubProcesso_Processoid, false, includeNonInitialized);
         AddObjectProperty("ProcessoId_N", gxTv_SdtSubProcesso_Processoid_N, false, includeNonInitialized);
         AddObjectProperty("ProcessoNome", gxTv_SdtSubProcesso_Processonome, false, includeNonInitialized);
         AddObjectProperty("SubprocessoNome", gxTv_SdtSubProcesso_Subprocessonome, false, includeNonInitialized);
         AddObjectProperty("SubprocessoAtivo", gxTv_SdtSubProcesso_Subprocessoativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSubProcesso_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSubProcesso_Initialized, false, includeNonInitialized);
            AddObjectProperty("SubprocessoId_Z", gxTv_SdtSubProcesso_Subprocessoid_Z, false, includeNonInitialized);
            AddObjectProperty("ProcessoId_Z", gxTv_SdtSubProcesso_Processoid_Z, false, includeNonInitialized);
            AddObjectProperty("ProcessoNome_Z", gxTv_SdtSubProcesso_Processonome_Z, false, includeNonInitialized);
            AddObjectProperty("SubprocessoNome_Z", gxTv_SdtSubProcesso_Subprocessonome_Z, false, includeNonInitialized);
            AddObjectProperty("SubprocessoAtivo_Z", gxTv_SdtSubProcesso_Subprocessoativo_Z, false, includeNonInitialized);
            AddObjectProperty("SubprocessoId_N", gxTv_SdtSubProcesso_Subprocessoid_N, false, includeNonInitialized);
            AddObjectProperty("ProcessoId_N", gxTv_SdtSubProcesso_Processoid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtSubProcesso sdt )
      {
         if ( sdt.IsDirty("SubprocessoId") )
         {
            gxTv_SdtSubProcesso_N = 0;
            gxTv_SdtSubProcesso_Subprocessoid = sdt.gxTv_SdtSubProcesso_Subprocessoid ;
         }
         if ( sdt.IsDirty("ProcessoId") )
         {
            gxTv_SdtSubProcesso_Processoid_N = (short)(sdt.gxTv_SdtSubProcesso_Processoid_N);
            gxTv_SdtSubProcesso_N = 0;
            gxTv_SdtSubProcesso_Processoid = sdt.gxTv_SdtSubProcesso_Processoid ;
         }
         if ( sdt.IsDirty("ProcessoNome") )
         {
            gxTv_SdtSubProcesso_N = 0;
            gxTv_SdtSubProcesso_Processonome = sdt.gxTv_SdtSubProcesso_Processonome ;
         }
         if ( sdt.IsDirty("SubprocessoNome") )
         {
            gxTv_SdtSubProcesso_N = 0;
            gxTv_SdtSubProcesso_Subprocessonome = sdt.gxTv_SdtSubProcesso_Subprocessonome ;
         }
         if ( sdt.IsDirty("SubprocessoAtivo") )
         {
            gxTv_SdtSubProcesso_N = 0;
            gxTv_SdtSubProcesso_Subprocessoativo = sdt.gxTv_SdtSubProcesso_Subprocessoativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SubprocessoId" )]
      [  XmlElement( ElementName = "SubprocessoId"   )]
      public int gxTpr_Subprocessoid
      {
         get {
            return gxTv_SdtSubProcesso_Subprocessoid ;
         }

         set {
            gxTv_SdtSubProcesso_N = 0;
            if ( gxTv_SdtSubProcesso_Subprocessoid != value )
            {
               gxTv_SdtSubProcesso_Mode = "INS";
               this.gxTv_SdtSubProcesso_Subprocessoid_Z_SetNull( );
               this.gxTv_SdtSubProcesso_Processoid_Z_SetNull( );
               this.gxTv_SdtSubProcesso_Processonome_Z_SetNull( );
               this.gxTv_SdtSubProcesso_Subprocessonome_Z_SetNull( );
               this.gxTv_SdtSubProcesso_Subprocessoativo_Z_SetNull( );
            }
            gxTv_SdtSubProcesso_Subprocessoid = value;
            SetDirty("Subprocessoid");
         }

      }

      [  SoapElement( ElementName = "ProcessoId" )]
      [  XmlElement( ElementName = "ProcessoId"   )]
      public int gxTpr_Processoid
      {
         get {
            return gxTv_SdtSubProcesso_Processoid ;
         }

         set {
            gxTv_SdtSubProcesso_Processoid_N = 0;
            gxTv_SdtSubProcesso_N = 0;
            gxTv_SdtSubProcesso_Processoid = value;
            SetDirty("Processoid");
         }

      }

      public void gxTv_SdtSubProcesso_Processoid_SetNull( )
      {
         gxTv_SdtSubProcesso_Processoid_N = 1;
         gxTv_SdtSubProcesso_Processoid = 0;
         SetDirty("Processoid");
         return  ;
      }

      public bool gxTv_SdtSubProcesso_Processoid_IsNull( )
      {
         return (gxTv_SdtSubProcesso_Processoid_N==1) ;
      }

      [  SoapElement( ElementName = "ProcessoNome" )]
      [  XmlElement( ElementName = "ProcessoNome"   )]
      public string gxTpr_Processonome
      {
         get {
            return gxTv_SdtSubProcesso_Processonome ;
         }

         set {
            gxTv_SdtSubProcesso_N = 0;
            gxTv_SdtSubProcesso_Processonome = value;
            SetDirty("Processonome");
         }

      }

      [  SoapElement( ElementName = "SubprocessoNome" )]
      [  XmlElement( ElementName = "SubprocessoNome"   )]
      public string gxTpr_Subprocessonome
      {
         get {
            return gxTv_SdtSubProcesso_Subprocessonome ;
         }

         set {
            gxTv_SdtSubProcesso_N = 0;
            gxTv_SdtSubProcesso_Subprocessonome = value;
            SetDirty("Subprocessonome");
         }

      }

      [  SoapElement( ElementName = "SubprocessoAtivo" )]
      [  XmlElement( ElementName = "SubprocessoAtivo"   )]
      public bool gxTpr_Subprocessoativo
      {
         get {
            return gxTv_SdtSubProcesso_Subprocessoativo ;
         }

         set {
            gxTv_SdtSubProcesso_N = 0;
            gxTv_SdtSubProcesso_Subprocessoativo = value;
            SetDirty("Subprocessoativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSubProcesso_Mode ;
         }

         set {
            gxTv_SdtSubProcesso_N = 0;
            gxTv_SdtSubProcesso_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSubProcesso_Mode_SetNull( )
      {
         gxTv_SdtSubProcesso_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSubProcesso_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSubProcesso_Initialized ;
         }

         set {
            gxTv_SdtSubProcesso_N = 0;
            gxTv_SdtSubProcesso_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSubProcesso_Initialized_SetNull( )
      {
         gxTv_SdtSubProcesso_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSubProcesso_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SubprocessoId_Z" )]
      [  XmlElement( ElementName = "SubprocessoId_Z"   )]
      public int gxTpr_Subprocessoid_Z
      {
         get {
            return gxTv_SdtSubProcesso_Subprocessoid_Z ;
         }

         set {
            gxTv_SdtSubProcesso_N = 0;
            gxTv_SdtSubProcesso_Subprocessoid_Z = value;
            SetDirty("Subprocessoid_Z");
         }

      }

      public void gxTv_SdtSubProcesso_Subprocessoid_Z_SetNull( )
      {
         gxTv_SdtSubProcesso_Subprocessoid_Z = 0;
         SetDirty("Subprocessoid_Z");
         return  ;
      }

      public bool gxTv_SdtSubProcesso_Subprocessoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProcessoId_Z" )]
      [  XmlElement( ElementName = "ProcessoId_Z"   )]
      public int gxTpr_Processoid_Z
      {
         get {
            return gxTv_SdtSubProcesso_Processoid_Z ;
         }

         set {
            gxTv_SdtSubProcesso_N = 0;
            gxTv_SdtSubProcesso_Processoid_Z = value;
            SetDirty("Processoid_Z");
         }

      }

      public void gxTv_SdtSubProcesso_Processoid_Z_SetNull( )
      {
         gxTv_SdtSubProcesso_Processoid_Z = 0;
         SetDirty("Processoid_Z");
         return  ;
      }

      public bool gxTv_SdtSubProcesso_Processoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProcessoNome_Z" )]
      [  XmlElement( ElementName = "ProcessoNome_Z"   )]
      public string gxTpr_Processonome_Z
      {
         get {
            return gxTv_SdtSubProcesso_Processonome_Z ;
         }

         set {
            gxTv_SdtSubProcesso_N = 0;
            gxTv_SdtSubProcesso_Processonome_Z = value;
            SetDirty("Processonome_Z");
         }

      }

      public void gxTv_SdtSubProcesso_Processonome_Z_SetNull( )
      {
         gxTv_SdtSubProcesso_Processonome_Z = "";
         SetDirty("Processonome_Z");
         return  ;
      }

      public bool gxTv_SdtSubProcesso_Processonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SubprocessoNome_Z" )]
      [  XmlElement( ElementName = "SubprocessoNome_Z"   )]
      public string gxTpr_Subprocessonome_Z
      {
         get {
            return gxTv_SdtSubProcesso_Subprocessonome_Z ;
         }

         set {
            gxTv_SdtSubProcesso_N = 0;
            gxTv_SdtSubProcesso_Subprocessonome_Z = value;
            SetDirty("Subprocessonome_Z");
         }

      }

      public void gxTv_SdtSubProcesso_Subprocessonome_Z_SetNull( )
      {
         gxTv_SdtSubProcesso_Subprocessonome_Z = "";
         SetDirty("Subprocessonome_Z");
         return  ;
      }

      public bool gxTv_SdtSubProcesso_Subprocessonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SubprocessoAtivo_Z" )]
      [  XmlElement( ElementName = "SubprocessoAtivo_Z"   )]
      public bool gxTpr_Subprocessoativo_Z
      {
         get {
            return gxTv_SdtSubProcesso_Subprocessoativo_Z ;
         }

         set {
            gxTv_SdtSubProcesso_N = 0;
            gxTv_SdtSubProcesso_Subprocessoativo_Z = value;
            SetDirty("Subprocessoativo_Z");
         }

      }

      public void gxTv_SdtSubProcesso_Subprocessoativo_Z_SetNull( )
      {
         gxTv_SdtSubProcesso_Subprocessoativo_Z = false;
         SetDirty("Subprocessoativo_Z");
         return  ;
      }

      public bool gxTv_SdtSubProcesso_Subprocessoativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SubprocessoId_N" )]
      [  XmlElement( ElementName = "SubprocessoId_N"   )]
      public short gxTpr_Subprocessoid_N
      {
         get {
            return gxTv_SdtSubProcesso_Subprocessoid_N ;
         }

         set {
            gxTv_SdtSubProcesso_N = 0;
            gxTv_SdtSubProcesso_Subprocessoid_N = value;
            SetDirty("Subprocessoid_N");
         }

      }

      public void gxTv_SdtSubProcesso_Subprocessoid_N_SetNull( )
      {
         gxTv_SdtSubProcesso_Subprocessoid_N = 0;
         SetDirty("Subprocessoid_N");
         return  ;
      }

      public bool gxTv_SdtSubProcesso_Subprocessoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProcessoId_N" )]
      [  XmlElement( ElementName = "ProcessoId_N"   )]
      public short gxTpr_Processoid_N
      {
         get {
            return gxTv_SdtSubProcesso_Processoid_N ;
         }

         set {
            gxTv_SdtSubProcesso_N = 0;
            gxTv_SdtSubProcesso_Processoid_N = value;
            SetDirty("Processoid_N");
         }

      }

      public void gxTv_SdtSubProcesso_Processoid_N_SetNull( )
      {
         gxTv_SdtSubProcesso_Processoid_N = 0;
         SetDirty("Processoid_N");
         return  ;
      }

      public bool gxTv_SdtSubProcesso_Processoid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtSubProcesso_N = 1;
         gxTv_SdtSubProcesso_Processonome = "";
         gxTv_SdtSubProcesso_Subprocessonome = "";
         gxTv_SdtSubProcesso_Mode = "";
         gxTv_SdtSubProcesso_Processonome_Z = "";
         gxTv_SdtSubProcesso_Subprocessonome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "subprocesso", "GeneXus.Programs.subprocesso_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtSubProcesso_N ;
      }

      private short gxTv_SdtSubProcesso_N ;
      private short gxTv_SdtSubProcesso_Initialized ;
      private short gxTv_SdtSubProcesso_Subprocessoid_N ;
      private short gxTv_SdtSubProcesso_Processoid_N ;
      private int gxTv_SdtSubProcesso_Subprocessoid ;
      private int gxTv_SdtSubProcesso_Processoid ;
      private int gxTv_SdtSubProcesso_Subprocessoid_Z ;
      private int gxTv_SdtSubProcesso_Processoid_Z ;
      private string gxTv_SdtSubProcesso_Mode ;
      private bool gxTv_SdtSubProcesso_Subprocessoativo ;
      private bool gxTv_SdtSubProcesso_Subprocessoativo_Z ;
      private string gxTv_SdtSubProcesso_Processonome ;
      private string gxTv_SdtSubProcesso_Subprocessonome ;
      private string gxTv_SdtSubProcesso_Processonome_Z ;
      private string gxTv_SdtSubProcesso_Subprocessonome_Z ;
   }

   [DataContract(Name = @"SubProcesso", Namespace = "LGPD_Novo")]
   public class SdtSubProcesso_RESTInterface : GxGenericCollectionItem<SdtSubProcesso>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtSubProcesso_RESTInterface( ) : base()
      {
      }

      public SdtSubProcesso_RESTInterface( SdtSubProcesso psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SubprocessoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Subprocessoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Subprocessoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Subprocessoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "ProcessoId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Processoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Processoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Processoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "ProcessoNome" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Processonome
      {
         get {
            return sdt.gxTpr_Processonome ;
         }

         set {
            sdt.gxTpr_Processonome = value;
         }

      }

      [DataMember( Name = "SubprocessoNome" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Subprocessonome
      {
         get {
            return sdt.gxTpr_Subprocessonome ;
         }

         set {
            sdt.gxTpr_Subprocessonome = value;
         }

      }

      [DataMember( Name = "SubprocessoAtivo" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Subprocessoativo
      {
         get {
            return sdt.gxTpr_Subprocessoativo ;
         }

         set {
            sdt.gxTpr_Subprocessoativo = value;
         }

      }

      public SdtSubProcesso sdt
      {
         get {
            return (SdtSubProcesso)Sdt ;
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
            sdt = new SdtSubProcesso() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 5 )]
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

   [DataContract(Name = @"SubProcesso", Namespace = "LGPD_Novo")]
   public class SdtSubProcesso_RESTLInterface : GxGenericCollectionItem<SdtSubProcesso>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtSubProcesso_RESTLInterface( ) : base()
      {
      }

      public SdtSubProcesso_RESTLInterface( SdtSubProcesso psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SubprocessoNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Subprocessonome
      {
         get {
            return sdt.gxTpr_Subprocessonome ;
         }

         set {
            sdt.gxTpr_Subprocessonome = value;
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

      public SdtSubProcesso sdt
      {
         get {
            return (SdtSubProcesso)Sdt ;
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
            sdt = new SdtSubProcesso() ;
         }
      }

   }

}
