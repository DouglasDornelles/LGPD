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
   [XmlRoot(ElementName = "Controlador" )]
   [XmlType(TypeName =  "Controlador" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtControlador : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtControlador( )
      {
      }

      public SdtControlador( IGxContext context )
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

      public void Load( int AV10ControladorId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV10ControladorId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ControladorId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Controlador");
         metadata.Set("BT", "Controlador");
         metadata.Set("PK", "[ \"ControladorId\" ]");
         metadata.Set("PKAssigned", "[ \"ControladorId\" ]");
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
         state.Add("gxTpr_Controladorid_Z");
         state.Add("gxTpr_Controladornome_Z");
         state.Add("gxTpr_Controladorativo_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtControlador sdt;
         sdt = (SdtControlador)(source);
         gxTv_SdtControlador_Controladorid = sdt.gxTv_SdtControlador_Controladorid ;
         gxTv_SdtControlador_Controladornome = sdt.gxTv_SdtControlador_Controladornome ;
         gxTv_SdtControlador_Controladorativo = sdt.gxTv_SdtControlador_Controladorativo ;
         gxTv_SdtControlador_Mode = sdt.gxTv_SdtControlador_Mode ;
         gxTv_SdtControlador_Initialized = sdt.gxTv_SdtControlador_Initialized ;
         gxTv_SdtControlador_Controladorid_Z = sdt.gxTv_SdtControlador_Controladorid_Z ;
         gxTv_SdtControlador_Controladornome_Z = sdt.gxTv_SdtControlador_Controladornome_Z ;
         gxTv_SdtControlador_Controladorativo_Z = sdt.gxTv_SdtControlador_Controladorativo_Z ;
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
         AddObjectProperty("ControladorId", gxTv_SdtControlador_Controladorid, false, includeNonInitialized);
         AddObjectProperty("ControladorNome", gxTv_SdtControlador_Controladornome, false, includeNonInitialized);
         AddObjectProperty("ControladorAtivo", gxTv_SdtControlador_Controladorativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtControlador_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtControlador_Initialized, false, includeNonInitialized);
            AddObjectProperty("ControladorId_Z", gxTv_SdtControlador_Controladorid_Z, false, includeNonInitialized);
            AddObjectProperty("ControladorNome_Z", gxTv_SdtControlador_Controladornome_Z, false, includeNonInitialized);
            AddObjectProperty("ControladorAtivo_Z", gxTv_SdtControlador_Controladorativo_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtControlador sdt )
      {
         if ( sdt.IsDirty("ControladorId") )
         {
            gxTv_SdtControlador_N = 0;
            gxTv_SdtControlador_Controladorid = sdt.gxTv_SdtControlador_Controladorid ;
         }
         if ( sdt.IsDirty("ControladorNome") )
         {
            gxTv_SdtControlador_N = 0;
            gxTv_SdtControlador_Controladornome = sdt.gxTv_SdtControlador_Controladornome ;
         }
         if ( sdt.IsDirty("ControladorAtivo") )
         {
            gxTv_SdtControlador_N = 0;
            gxTv_SdtControlador_Controladorativo = sdt.gxTv_SdtControlador_Controladorativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ControladorId" )]
      [  XmlElement( ElementName = "ControladorId"   )]
      public int gxTpr_Controladorid
      {
         get {
            return gxTv_SdtControlador_Controladorid ;
         }

         set {
            gxTv_SdtControlador_N = 0;
            if ( gxTv_SdtControlador_Controladorid != value )
            {
               gxTv_SdtControlador_Mode = "INS";
               this.gxTv_SdtControlador_Controladorid_Z_SetNull( );
               this.gxTv_SdtControlador_Controladornome_Z_SetNull( );
               this.gxTv_SdtControlador_Controladorativo_Z_SetNull( );
            }
            gxTv_SdtControlador_Controladorid = value;
            SetDirty("Controladorid");
         }

      }

      [  SoapElement( ElementName = "ControladorNome" )]
      [  XmlElement( ElementName = "ControladorNome"   )]
      public string gxTpr_Controladornome
      {
         get {
            return gxTv_SdtControlador_Controladornome ;
         }

         set {
            gxTv_SdtControlador_N = 0;
            gxTv_SdtControlador_Controladornome = value;
            SetDirty("Controladornome");
         }

      }

      [  SoapElement( ElementName = "ControladorAtivo" )]
      [  XmlElement( ElementName = "ControladorAtivo"   )]
      public bool gxTpr_Controladorativo
      {
         get {
            return gxTv_SdtControlador_Controladorativo ;
         }

         set {
            gxTv_SdtControlador_N = 0;
            gxTv_SdtControlador_Controladorativo = value;
            SetDirty("Controladorativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtControlador_Mode ;
         }

         set {
            gxTv_SdtControlador_N = 0;
            gxTv_SdtControlador_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtControlador_Mode_SetNull( )
      {
         gxTv_SdtControlador_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtControlador_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtControlador_Initialized ;
         }

         set {
            gxTv_SdtControlador_N = 0;
            gxTv_SdtControlador_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtControlador_Initialized_SetNull( )
      {
         gxTv_SdtControlador_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtControlador_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ControladorId_Z" )]
      [  XmlElement( ElementName = "ControladorId_Z"   )]
      public int gxTpr_Controladorid_Z
      {
         get {
            return gxTv_SdtControlador_Controladorid_Z ;
         }

         set {
            gxTv_SdtControlador_N = 0;
            gxTv_SdtControlador_Controladorid_Z = value;
            SetDirty("Controladorid_Z");
         }

      }

      public void gxTv_SdtControlador_Controladorid_Z_SetNull( )
      {
         gxTv_SdtControlador_Controladorid_Z = 0;
         SetDirty("Controladorid_Z");
         return  ;
      }

      public bool gxTv_SdtControlador_Controladorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ControladorNome_Z" )]
      [  XmlElement( ElementName = "ControladorNome_Z"   )]
      public string gxTpr_Controladornome_Z
      {
         get {
            return gxTv_SdtControlador_Controladornome_Z ;
         }

         set {
            gxTv_SdtControlador_N = 0;
            gxTv_SdtControlador_Controladornome_Z = value;
            SetDirty("Controladornome_Z");
         }

      }

      public void gxTv_SdtControlador_Controladornome_Z_SetNull( )
      {
         gxTv_SdtControlador_Controladornome_Z = "";
         SetDirty("Controladornome_Z");
         return  ;
      }

      public bool gxTv_SdtControlador_Controladornome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ControladorAtivo_Z" )]
      [  XmlElement( ElementName = "ControladorAtivo_Z"   )]
      public bool gxTpr_Controladorativo_Z
      {
         get {
            return gxTv_SdtControlador_Controladorativo_Z ;
         }

         set {
            gxTv_SdtControlador_N = 0;
            gxTv_SdtControlador_Controladorativo_Z = value;
            SetDirty("Controladorativo_Z");
         }

      }

      public void gxTv_SdtControlador_Controladorativo_Z_SetNull( )
      {
         gxTv_SdtControlador_Controladorativo_Z = false;
         SetDirty("Controladorativo_Z");
         return  ;
      }

      public bool gxTv_SdtControlador_Controladorativo_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtControlador_N = 1;
         gxTv_SdtControlador_Controladornome = "";
         gxTv_SdtControlador_Mode = "";
         gxTv_SdtControlador_Controladornome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "controlador", "GeneXus.Programs.controlador_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtControlador_N ;
      }

      private short gxTv_SdtControlador_N ;
      private short gxTv_SdtControlador_Initialized ;
      private int gxTv_SdtControlador_Controladorid ;
      private int gxTv_SdtControlador_Controladorid_Z ;
      private string gxTv_SdtControlador_Mode ;
      private bool gxTv_SdtControlador_Controladorativo ;
      private bool gxTv_SdtControlador_Controladorativo_Z ;
      private string gxTv_SdtControlador_Controladornome ;
      private string gxTv_SdtControlador_Controladornome_Z ;
   }

   [DataContract(Name = @"Controlador", Namespace = "LGPD_Novo")]
   public class SdtControlador_RESTInterface : GxGenericCollectionItem<SdtControlador>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtControlador_RESTInterface( ) : base()
      {
      }

      public SdtControlador_RESTInterface( SdtControlador psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ControladorId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Controladorid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Controladorid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Controladorid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "ControladorNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Controladornome
      {
         get {
            return sdt.gxTpr_Controladornome ;
         }

         set {
            sdt.gxTpr_Controladornome = value;
         }

      }

      [DataMember( Name = "ControladorAtivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Controladorativo
      {
         get {
            return sdt.gxTpr_Controladorativo ;
         }

         set {
            sdt.gxTpr_Controladorativo = value;
         }

      }

      public SdtControlador sdt
      {
         get {
            return (SdtControlador)Sdt ;
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
            sdt = new SdtControlador() ;
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

   [DataContract(Name = @"Controlador", Namespace = "LGPD_Novo")]
   public class SdtControlador_RESTLInterface : GxGenericCollectionItem<SdtControlador>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtControlador_RESTLInterface( ) : base()
      {
      }

      public SdtControlador_RESTLInterface( SdtControlador psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ControladorNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Controladornome
      {
         get {
            return sdt.gxTpr_Controladornome ;
         }

         set {
            sdt.gxTpr_Controladornome = value;
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

      public SdtControlador sdt
      {
         get {
            return (SdtControlador)Sdt ;
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
            sdt = new SdtControlador() ;
         }
      }

   }

}
