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
   [XmlRoot(ElementName = "Operador" )]
   [XmlType(TypeName =  "Operador" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtOperador : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtOperador( )
      {
      }

      public SdtOperador( IGxContext context )
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

      public void Load( int AV42OperadorId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV42OperadorId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"OperadorId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Operador");
         metadata.Set("BT", "Operador");
         metadata.Set("PK", "[ \"OperadorId\" ]");
         metadata.Set("PKAssigned", "[ \"OperadorId\" ]");
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
         state.Add("gxTpr_Operadorid_Z");
         state.Add("gxTpr_Operadornome_Z");
         state.Add("gxTpr_Operadorativo_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtOperador sdt;
         sdt = (SdtOperador)(source);
         gxTv_SdtOperador_Operadorid = sdt.gxTv_SdtOperador_Operadorid ;
         gxTv_SdtOperador_Operadornome = sdt.gxTv_SdtOperador_Operadornome ;
         gxTv_SdtOperador_Operadorativo = sdt.gxTv_SdtOperador_Operadorativo ;
         gxTv_SdtOperador_Mode = sdt.gxTv_SdtOperador_Mode ;
         gxTv_SdtOperador_Initialized = sdt.gxTv_SdtOperador_Initialized ;
         gxTv_SdtOperador_Operadorid_Z = sdt.gxTv_SdtOperador_Operadorid_Z ;
         gxTv_SdtOperador_Operadornome_Z = sdt.gxTv_SdtOperador_Operadornome_Z ;
         gxTv_SdtOperador_Operadorativo_Z = sdt.gxTv_SdtOperador_Operadorativo_Z ;
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
         AddObjectProperty("OperadorId", gxTv_SdtOperador_Operadorid, false, includeNonInitialized);
         AddObjectProperty("OperadorNome", gxTv_SdtOperador_Operadornome, false, includeNonInitialized);
         AddObjectProperty("OperadorAtivo", gxTv_SdtOperador_Operadorativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtOperador_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtOperador_Initialized, false, includeNonInitialized);
            AddObjectProperty("OperadorId_Z", gxTv_SdtOperador_Operadorid_Z, false, includeNonInitialized);
            AddObjectProperty("OperadorNome_Z", gxTv_SdtOperador_Operadornome_Z, false, includeNonInitialized);
            AddObjectProperty("OperadorAtivo_Z", gxTv_SdtOperador_Operadorativo_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtOperador sdt )
      {
         if ( sdt.IsDirty("OperadorId") )
         {
            gxTv_SdtOperador_N = 0;
            gxTv_SdtOperador_Operadorid = sdt.gxTv_SdtOperador_Operadorid ;
         }
         if ( sdt.IsDirty("OperadorNome") )
         {
            gxTv_SdtOperador_N = 0;
            gxTv_SdtOperador_Operadornome = sdt.gxTv_SdtOperador_Operadornome ;
         }
         if ( sdt.IsDirty("OperadorAtivo") )
         {
            gxTv_SdtOperador_N = 0;
            gxTv_SdtOperador_Operadorativo = sdt.gxTv_SdtOperador_Operadorativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "OperadorId" )]
      [  XmlElement( ElementName = "OperadorId"   )]
      public int gxTpr_Operadorid
      {
         get {
            return gxTv_SdtOperador_Operadorid ;
         }

         set {
            gxTv_SdtOperador_N = 0;
            if ( gxTv_SdtOperador_Operadorid != value )
            {
               gxTv_SdtOperador_Mode = "INS";
               this.gxTv_SdtOperador_Operadorid_Z_SetNull( );
               this.gxTv_SdtOperador_Operadornome_Z_SetNull( );
               this.gxTv_SdtOperador_Operadorativo_Z_SetNull( );
            }
            gxTv_SdtOperador_Operadorid = value;
            SetDirty("Operadorid");
         }

      }

      [  SoapElement( ElementName = "OperadorNome" )]
      [  XmlElement( ElementName = "OperadorNome"   )]
      public string gxTpr_Operadornome
      {
         get {
            return gxTv_SdtOperador_Operadornome ;
         }

         set {
            gxTv_SdtOperador_N = 0;
            gxTv_SdtOperador_Operadornome = value;
            SetDirty("Operadornome");
         }

      }

      [  SoapElement( ElementName = "OperadorAtivo" )]
      [  XmlElement( ElementName = "OperadorAtivo"   )]
      public bool gxTpr_Operadorativo
      {
         get {
            return gxTv_SdtOperador_Operadorativo ;
         }

         set {
            gxTv_SdtOperador_N = 0;
            gxTv_SdtOperador_Operadorativo = value;
            SetDirty("Operadorativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtOperador_Mode ;
         }

         set {
            gxTv_SdtOperador_N = 0;
            gxTv_SdtOperador_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtOperador_Mode_SetNull( )
      {
         gxTv_SdtOperador_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtOperador_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtOperador_Initialized ;
         }

         set {
            gxTv_SdtOperador_N = 0;
            gxTv_SdtOperador_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtOperador_Initialized_SetNull( )
      {
         gxTv_SdtOperador_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtOperador_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperadorId_Z" )]
      [  XmlElement( ElementName = "OperadorId_Z"   )]
      public int gxTpr_Operadorid_Z
      {
         get {
            return gxTv_SdtOperador_Operadorid_Z ;
         }

         set {
            gxTv_SdtOperador_N = 0;
            gxTv_SdtOperador_Operadorid_Z = value;
            SetDirty("Operadorid_Z");
         }

      }

      public void gxTv_SdtOperador_Operadorid_Z_SetNull( )
      {
         gxTv_SdtOperador_Operadorid_Z = 0;
         SetDirty("Operadorid_Z");
         return  ;
      }

      public bool gxTv_SdtOperador_Operadorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperadorNome_Z" )]
      [  XmlElement( ElementName = "OperadorNome_Z"   )]
      public string gxTpr_Operadornome_Z
      {
         get {
            return gxTv_SdtOperador_Operadornome_Z ;
         }

         set {
            gxTv_SdtOperador_N = 0;
            gxTv_SdtOperador_Operadornome_Z = value;
            SetDirty("Operadornome_Z");
         }

      }

      public void gxTv_SdtOperador_Operadornome_Z_SetNull( )
      {
         gxTv_SdtOperador_Operadornome_Z = "";
         SetDirty("Operadornome_Z");
         return  ;
      }

      public bool gxTv_SdtOperador_Operadornome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperadorAtivo_Z" )]
      [  XmlElement( ElementName = "OperadorAtivo_Z"   )]
      public bool gxTpr_Operadorativo_Z
      {
         get {
            return gxTv_SdtOperador_Operadorativo_Z ;
         }

         set {
            gxTv_SdtOperador_N = 0;
            gxTv_SdtOperador_Operadorativo_Z = value;
            SetDirty("Operadorativo_Z");
         }

      }

      public void gxTv_SdtOperador_Operadorativo_Z_SetNull( )
      {
         gxTv_SdtOperador_Operadorativo_Z = false;
         SetDirty("Operadorativo_Z");
         return  ;
      }

      public bool gxTv_SdtOperador_Operadorativo_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtOperador_N = 1;
         gxTv_SdtOperador_Operadornome = "";
         gxTv_SdtOperador_Mode = "";
         gxTv_SdtOperador_Operadornome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "operador", "GeneXus.Programs.operador_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtOperador_N ;
      }

      private short gxTv_SdtOperador_N ;
      private short gxTv_SdtOperador_Initialized ;
      private int gxTv_SdtOperador_Operadorid ;
      private int gxTv_SdtOperador_Operadorid_Z ;
      private string gxTv_SdtOperador_Mode ;
      private bool gxTv_SdtOperador_Operadorativo ;
      private bool gxTv_SdtOperador_Operadorativo_Z ;
      private string gxTv_SdtOperador_Operadornome ;
      private string gxTv_SdtOperador_Operadornome_Z ;
   }

   [DataContract(Name = @"Operador", Namespace = "LGPD_Novo")]
   public class SdtOperador_RESTInterface : GxGenericCollectionItem<SdtOperador>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtOperador_RESTInterface( ) : base()
      {
      }

      public SdtOperador_RESTInterface( SdtOperador psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "OperadorId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Operadorid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Operadorid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Operadorid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "OperadorNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Operadornome
      {
         get {
            return sdt.gxTpr_Operadornome ;
         }

         set {
            sdt.gxTpr_Operadornome = value;
         }

      }

      [DataMember( Name = "OperadorAtivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Operadorativo
      {
         get {
            return sdt.gxTpr_Operadorativo ;
         }

         set {
            sdt.gxTpr_Operadorativo = value;
         }

      }

      public SdtOperador sdt
      {
         get {
            return (SdtOperador)Sdt ;
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
            sdt = new SdtOperador() ;
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

   [DataContract(Name = @"Operador", Namespace = "LGPD_Novo")]
   public class SdtOperador_RESTLInterface : GxGenericCollectionItem<SdtOperador>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtOperador_RESTLInterface( ) : base()
      {
      }

      public SdtOperador_RESTLInterface( SdtOperador psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "OperadorNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Operadornome
      {
         get {
            return sdt.gxTpr_Operadornome ;
         }

         set {
            sdt.gxTpr_Operadornome = value;
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

      public SdtOperador sdt
      {
         get {
            return (SdtOperador)Sdt ;
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
            sdt = new SdtOperador() ;
         }
      }

   }

}
