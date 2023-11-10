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
   [XmlRoot(ElementName = "Processo" )]
   [XmlType(TypeName =  "Processo" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtProcesso : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtProcesso( )
      {
      }

      public SdtProcesso( IGxContext context )
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

      public void Load( int AV16ProcessoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV16ProcessoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ProcessoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Processo");
         metadata.Set("BT", "Processo");
         metadata.Set("PK", "[ \"ProcessoId\" ]");
         metadata.Set("PKAssigned", "[ \"ProcessoId\" ]");
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
         state.Add("gxTpr_Processoid_Z");
         state.Add("gxTpr_Processonome_Z");
         state.Add("gxTpr_Processoativo_Z");
         state.Add("gxTpr_Processoid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtProcesso sdt;
         sdt = (SdtProcesso)(source);
         gxTv_SdtProcesso_Processoid = sdt.gxTv_SdtProcesso_Processoid ;
         gxTv_SdtProcesso_Processonome = sdt.gxTv_SdtProcesso_Processonome ;
         gxTv_SdtProcesso_Processoativo = sdt.gxTv_SdtProcesso_Processoativo ;
         gxTv_SdtProcesso_Mode = sdt.gxTv_SdtProcesso_Mode ;
         gxTv_SdtProcesso_Initialized = sdt.gxTv_SdtProcesso_Initialized ;
         gxTv_SdtProcesso_Processoid_Z = sdt.gxTv_SdtProcesso_Processoid_Z ;
         gxTv_SdtProcesso_Processonome_Z = sdt.gxTv_SdtProcesso_Processonome_Z ;
         gxTv_SdtProcesso_Processoativo_Z = sdt.gxTv_SdtProcesso_Processoativo_Z ;
         gxTv_SdtProcesso_Processoid_N = sdt.gxTv_SdtProcesso_Processoid_N ;
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
         AddObjectProperty("ProcessoId", gxTv_SdtProcesso_Processoid, false, includeNonInitialized);
         AddObjectProperty("ProcessoId_N", gxTv_SdtProcesso_Processoid_N, false, includeNonInitialized);
         AddObjectProperty("ProcessoNome", gxTv_SdtProcesso_Processonome, false, includeNonInitialized);
         AddObjectProperty("ProcessoAtivo", gxTv_SdtProcesso_Processoativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtProcesso_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtProcesso_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProcessoId_Z", gxTv_SdtProcesso_Processoid_Z, false, includeNonInitialized);
            AddObjectProperty("ProcessoNome_Z", gxTv_SdtProcesso_Processonome_Z, false, includeNonInitialized);
            AddObjectProperty("ProcessoAtivo_Z", gxTv_SdtProcesso_Processoativo_Z, false, includeNonInitialized);
            AddObjectProperty("ProcessoId_N", gxTv_SdtProcesso_Processoid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtProcesso sdt )
      {
         if ( sdt.IsDirty("ProcessoId") )
         {
            gxTv_SdtProcesso_N = 0;
            gxTv_SdtProcesso_Processoid = sdt.gxTv_SdtProcesso_Processoid ;
         }
         if ( sdt.IsDirty("ProcessoNome") )
         {
            gxTv_SdtProcesso_N = 0;
            gxTv_SdtProcesso_Processonome = sdt.gxTv_SdtProcesso_Processonome ;
         }
         if ( sdt.IsDirty("ProcessoAtivo") )
         {
            gxTv_SdtProcesso_N = 0;
            gxTv_SdtProcesso_Processoativo = sdt.gxTv_SdtProcesso_Processoativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProcessoId" )]
      [  XmlElement( ElementName = "ProcessoId"   )]
      public int gxTpr_Processoid
      {
         get {
            return gxTv_SdtProcesso_Processoid ;
         }

         set {
            gxTv_SdtProcesso_N = 0;
            if ( gxTv_SdtProcesso_Processoid != value )
            {
               gxTv_SdtProcesso_Mode = "INS";
               this.gxTv_SdtProcesso_Processoid_Z_SetNull( );
               this.gxTv_SdtProcesso_Processonome_Z_SetNull( );
               this.gxTv_SdtProcesso_Processoativo_Z_SetNull( );
            }
            gxTv_SdtProcesso_Processoid = value;
            SetDirty("Processoid");
         }

      }

      [  SoapElement( ElementName = "ProcessoNome" )]
      [  XmlElement( ElementName = "ProcessoNome"   )]
      public string gxTpr_Processonome
      {
         get {
            return gxTv_SdtProcesso_Processonome ;
         }

         set {
            gxTv_SdtProcesso_N = 0;
            gxTv_SdtProcesso_Processonome = value;
            SetDirty("Processonome");
         }

      }

      [  SoapElement( ElementName = "ProcessoAtivo" )]
      [  XmlElement( ElementName = "ProcessoAtivo"   )]
      public bool gxTpr_Processoativo
      {
         get {
            return gxTv_SdtProcesso_Processoativo ;
         }

         set {
            gxTv_SdtProcesso_N = 0;
            gxTv_SdtProcesso_Processoativo = value;
            SetDirty("Processoativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtProcesso_Mode ;
         }

         set {
            gxTv_SdtProcesso_N = 0;
            gxTv_SdtProcesso_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtProcesso_Mode_SetNull( )
      {
         gxTv_SdtProcesso_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtProcesso_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtProcesso_Initialized ;
         }

         set {
            gxTv_SdtProcesso_N = 0;
            gxTv_SdtProcesso_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtProcesso_Initialized_SetNull( )
      {
         gxTv_SdtProcesso_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtProcesso_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProcessoId_Z" )]
      [  XmlElement( ElementName = "ProcessoId_Z"   )]
      public int gxTpr_Processoid_Z
      {
         get {
            return gxTv_SdtProcesso_Processoid_Z ;
         }

         set {
            gxTv_SdtProcesso_N = 0;
            gxTv_SdtProcesso_Processoid_Z = value;
            SetDirty("Processoid_Z");
         }

      }

      public void gxTv_SdtProcesso_Processoid_Z_SetNull( )
      {
         gxTv_SdtProcesso_Processoid_Z = 0;
         SetDirty("Processoid_Z");
         return  ;
      }

      public bool gxTv_SdtProcesso_Processoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProcessoNome_Z" )]
      [  XmlElement( ElementName = "ProcessoNome_Z"   )]
      public string gxTpr_Processonome_Z
      {
         get {
            return gxTv_SdtProcesso_Processonome_Z ;
         }

         set {
            gxTv_SdtProcesso_N = 0;
            gxTv_SdtProcesso_Processonome_Z = value;
            SetDirty("Processonome_Z");
         }

      }

      public void gxTv_SdtProcesso_Processonome_Z_SetNull( )
      {
         gxTv_SdtProcesso_Processonome_Z = "";
         SetDirty("Processonome_Z");
         return  ;
      }

      public bool gxTv_SdtProcesso_Processonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProcessoAtivo_Z" )]
      [  XmlElement( ElementName = "ProcessoAtivo_Z"   )]
      public bool gxTpr_Processoativo_Z
      {
         get {
            return gxTv_SdtProcesso_Processoativo_Z ;
         }

         set {
            gxTv_SdtProcesso_N = 0;
            gxTv_SdtProcesso_Processoativo_Z = value;
            SetDirty("Processoativo_Z");
         }

      }

      public void gxTv_SdtProcesso_Processoativo_Z_SetNull( )
      {
         gxTv_SdtProcesso_Processoativo_Z = false;
         SetDirty("Processoativo_Z");
         return  ;
      }

      public bool gxTv_SdtProcesso_Processoativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProcessoId_N" )]
      [  XmlElement( ElementName = "ProcessoId_N"   )]
      public short gxTpr_Processoid_N
      {
         get {
            return gxTv_SdtProcesso_Processoid_N ;
         }

         set {
            gxTv_SdtProcesso_N = 0;
            gxTv_SdtProcesso_Processoid_N = value;
            SetDirty("Processoid_N");
         }

      }

      public void gxTv_SdtProcesso_Processoid_N_SetNull( )
      {
         gxTv_SdtProcesso_Processoid_N = 0;
         SetDirty("Processoid_N");
         return  ;
      }

      public bool gxTv_SdtProcesso_Processoid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtProcesso_N = 1;
         gxTv_SdtProcesso_Processonome = "";
         gxTv_SdtProcesso_Mode = "";
         gxTv_SdtProcesso_Processonome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "processo", "GeneXus.Programs.processo_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtProcesso_N ;
      }

      private short gxTv_SdtProcesso_N ;
      private short gxTv_SdtProcesso_Initialized ;
      private short gxTv_SdtProcesso_Processoid_N ;
      private int gxTv_SdtProcesso_Processoid ;
      private int gxTv_SdtProcesso_Processoid_Z ;
      private string gxTv_SdtProcesso_Mode ;
      private bool gxTv_SdtProcesso_Processoativo ;
      private bool gxTv_SdtProcesso_Processoativo_Z ;
      private string gxTv_SdtProcesso_Processonome ;
      private string gxTv_SdtProcesso_Processonome_Z ;
   }

   [DataContract(Name = @"Processo", Namespace = "LGPD_Novo")]
   public class SdtProcesso_RESTInterface : GxGenericCollectionItem<SdtProcesso>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtProcesso_RESTInterface( ) : base()
      {
      }

      public SdtProcesso_RESTInterface( SdtProcesso psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProcessoId" , Order = 0 )]
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

      [DataMember( Name = "ProcessoNome" , Order = 1 )]
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

      [DataMember( Name = "ProcessoAtivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Processoativo
      {
         get {
            return sdt.gxTpr_Processoativo ;
         }

         set {
            sdt.gxTpr_Processoativo = value;
         }

      }

      public SdtProcesso sdt
      {
         get {
            return (SdtProcesso)Sdt ;
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
            sdt = new SdtProcesso() ;
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

   [DataContract(Name = @"Processo", Namespace = "LGPD_Novo")]
   public class SdtProcesso_RESTLInterface : GxGenericCollectionItem<SdtProcesso>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtProcesso_RESTLInterface( ) : base()
      {
      }

      public SdtProcesso_RESTLInterface( SdtProcesso psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProcessoNome" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtProcesso sdt
      {
         get {
            return (SdtProcesso)Sdt ;
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
            sdt = new SdtProcesso() ;
         }
      }

   }

}
