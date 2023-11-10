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
   [XmlRoot(ElementName = "Persona" )]
   [XmlType(TypeName =  "Persona" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtPersona : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPersona( )
      {
      }

      public SdtPersona( IGxContext context )
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

      public void Load( int AV13PersonaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV13PersonaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PersonaId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Persona");
         metadata.Set("BT", "Persona");
         metadata.Set("PK", "[ \"PersonaId\" ]");
         metadata.Set("PKAssigned", "[ \"PersonaId\" ]");
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
         state.Add("gxTpr_Personaid_Z");
         state.Add("gxTpr_Personanome_Z");
         state.Add("gxTpr_Personaativo_Z");
         state.Add("gxTpr_Personaid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPersona sdt;
         sdt = (SdtPersona)(source);
         gxTv_SdtPersona_Personaid = sdt.gxTv_SdtPersona_Personaid ;
         gxTv_SdtPersona_Personanome = sdt.gxTv_SdtPersona_Personanome ;
         gxTv_SdtPersona_Personaativo = sdt.gxTv_SdtPersona_Personaativo ;
         gxTv_SdtPersona_Mode = sdt.gxTv_SdtPersona_Mode ;
         gxTv_SdtPersona_Initialized = sdt.gxTv_SdtPersona_Initialized ;
         gxTv_SdtPersona_Personaid_Z = sdt.gxTv_SdtPersona_Personaid_Z ;
         gxTv_SdtPersona_Personanome_Z = sdt.gxTv_SdtPersona_Personanome_Z ;
         gxTv_SdtPersona_Personaativo_Z = sdt.gxTv_SdtPersona_Personaativo_Z ;
         gxTv_SdtPersona_Personaid_N = sdt.gxTv_SdtPersona_Personaid_N ;
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
         AddObjectProperty("PersonaId", gxTv_SdtPersona_Personaid, false, includeNonInitialized);
         AddObjectProperty("PersonaId_N", gxTv_SdtPersona_Personaid_N, false, includeNonInitialized);
         AddObjectProperty("PersonaNome", gxTv_SdtPersona_Personanome, false, includeNonInitialized);
         AddObjectProperty("PersonaAtivo", gxTv_SdtPersona_Personaativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPersona_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPersona_Initialized, false, includeNonInitialized);
            AddObjectProperty("PersonaId_Z", gxTv_SdtPersona_Personaid_Z, false, includeNonInitialized);
            AddObjectProperty("PersonaNome_Z", gxTv_SdtPersona_Personanome_Z, false, includeNonInitialized);
            AddObjectProperty("PersonaAtivo_Z", gxTv_SdtPersona_Personaativo_Z, false, includeNonInitialized);
            AddObjectProperty("PersonaId_N", gxTv_SdtPersona_Personaid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPersona sdt )
      {
         if ( sdt.IsDirty("PersonaId") )
         {
            gxTv_SdtPersona_N = 0;
            gxTv_SdtPersona_Personaid = sdt.gxTv_SdtPersona_Personaid ;
         }
         if ( sdt.IsDirty("PersonaNome") )
         {
            gxTv_SdtPersona_N = 0;
            gxTv_SdtPersona_Personanome = sdt.gxTv_SdtPersona_Personanome ;
         }
         if ( sdt.IsDirty("PersonaAtivo") )
         {
            gxTv_SdtPersona_N = 0;
            gxTv_SdtPersona_Personaativo = sdt.gxTv_SdtPersona_Personaativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PersonaId" )]
      [  XmlElement( ElementName = "PersonaId"   )]
      public int gxTpr_Personaid
      {
         get {
            return gxTv_SdtPersona_Personaid ;
         }

         set {
            gxTv_SdtPersona_N = 0;
            if ( gxTv_SdtPersona_Personaid != value )
            {
               gxTv_SdtPersona_Mode = "INS";
               this.gxTv_SdtPersona_Personaid_Z_SetNull( );
               this.gxTv_SdtPersona_Personanome_Z_SetNull( );
               this.gxTv_SdtPersona_Personaativo_Z_SetNull( );
            }
            gxTv_SdtPersona_Personaid = value;
            SetDirty("Personaid");
         }

      }

      [  SoapElement( ElementName = "PersonaNome" )]
      [  XmlElement( ElementName = "PersonaNome"   )]
      public string gxTpr_Personanome
      {
         get {
            return gxTv_SdtPersona_Personanome ;
         }

         set {
            gxTv_SdtPersona_N = 0;
            gxTv_SdtPersona_Personanome = value;
            SetDirty("Personanome");
         }

      }

      [  SoapElement( ElementName = "PersonaAtivo" )]
      [  XmlElement( ElementName = "PersonaAtivo"   )]
      public bool gxTpr_Personaativo
      {
         get {
            return gxTv_SdtPersona_Personaativo ;
         }

         set {
            gxTv_SdtPersona_N = 0;
            gxTv_SdtPersona_Personaativo = value;
            SetDirty("Personaativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPersona_Mode ;
         }

         set {
            gxTv_SdtPersona_N = 0;
            gxTv_SdtPersona_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPersona_Mode_SetNull( )
      {
         gxTv_SdtPersona_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPersona_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPersona_Initialized ;
         }

         set {
            gxTv_SdtPersona_N = 0;
            gxTv_SdtPersona_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPersona_Initialized_SetNull( )
      {
         gxTv_SdtPersona_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPersona_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PersonaId_Z" )]
      [  XmlElement( ElementName = "PersonaId_Z"   )]
      public int gxTpr_Personaid_Z
      {
         get {
            return gxTv_SdtPersona_Personaid_Z ;
         }

         set {
            gxTv_SdtPersona_N = 0;
            gxTv_SdtPersona_Personaid_Z = value;
            SetDirty("Personaid_Z");
         }

      }

      public void gxTv_SdtPersona_Personaid_Z_SetNull( )
      {
         gxTv_SdtPersona_Personaid_Z = 0;
         SetDirty("Personaid_Z");
         return  ;
      }

      public bool gxTv_SdtPersona_Personaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PersonaNome_Z" )]
      [  XmlElement( ElementName = "PersonaNome_Z"   )]
      public string gxTpr_Personanome_Z
      {
         get {
            return gxTv_SdtPersona_Personanome_Z ;
         }

         set {
            gxTv_SdtPersona_N = 0;
            gxTv_SdtPersona_Personanome_Z = value;
            SetDirty("Personanome_Z");
         }

      }

      public void gxTv_SdtPersona_Personanome_Z_SetNull( )
      {
         gxTv_SdtPersona_Personanome_Z = "";
         SetDirty("Personanome_Z");
         return  ;
      }

      public bool gxTv_SdtPersona_Personanome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PersonaAtivo_Z" )]
      [  XmlElement( ElementName = "PersonaAtivo_Z"   )]
      public bool gxTpr_Personaativo_Z
      {
         get {
            return gxTv_SdtPersona_Personaativo_Z ;
         }

         set {
            gxTv_SdtPersona_N = 0;
            gxTv_SdtPersona_Personaativo_Z = value;
            SetDirty("Personaativo_Z");
         }

      }

      public void gxTv_SdtPersona_Personaativo_Z_SetNull( )
      {
         gxTv_SdtPersona_Personaativo_Z = false;
         SetDirty("Personaativo_Z");
         return  ;
      }

      public bool gxTv_SdtPersona_Personaativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PersonaId_N" )]
      [  XmlElement( ElementName = "PersonaId_N"   )]
      public short gxTpr_Personaid_N
      {
         get {
            return gxTv_SdtPersona_Personaid_N ;
         }

         set {
            gxTv_SdtPersona_N = 0;
            gxTv_SdtPersona_Personaid_N = value;
            SetDirty("Personaid_N");
         }

      }

      public void gxTv_SdtPersona_Personaid_N_SetNull( )
      {
         gxTv_SdtPersona_Personaid_N = 0;
         SetDirty("Personaid_N");
         return  ;
      }

      public bool gxTv_SdtPersona_Personaid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtPersona_N = 1;
         gxTv_SdtPersona_Personanome = "";
         gxTv_SdtPersona_Mode = "";
         gxTv_SdtPersona_Personanome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "persona", "GeneXus.Programs.persona_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtPersona_N ;
      }

      private short gxTv_SdtPersona_N ;
      private short gxTv_SdtPersona_Initialized ;
      private short gxTv_SdtPersona_Personaid_N ;
      private int gxTv_SdtPersona_Personaid ;
      private int gxTv_SdtPersona_Personaid_Z ;
      private string gxTv_SdtPersona_Mode ;
      private bool gxTv_SdtPersona_Personaativo ;
      private bool gxTv_SdtPersona_Personaativo_Z ;
      private string gxTv_SdtPersona_Personanome ;
      private string gxTv_SdtPersona_Personanome_Z ;
   }

   [DataContract(Name = @"Persona", Namespace = "LGPD_Novo")]
   public class SdtPersona_RESTInterface : GxGenericCollectionItem<SdtPersona>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPersona_RESTInterface( ) : base()
      {
      }

      public SdtPersona_RESTInterface( SdtPersona psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PersonaId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Personaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Personaid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Personaid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "PersonaNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Personanome
      {
         get {
            return sdt.gxTpr_Personanome ;
         }

         set {
            sdt.gxTpr_Personanome = value;
         }

      }

      [DataMember( Name = "PersonaAtivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Personaativo
      {
         get {
            return sdt.gxTpr_Personaativo ;
         }

         set {
            sdt.gxTpr_Personaativo = value;
         }

      }

      public SdtPersona sdt
      {
         get {
            return (SdtPersona)Sdt ;
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
            sdt = new SdtPersona() ;
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

   [DataContract(Name = @"Persona", Namespace = "LGPD_Novo")]
   public class SdtPersona_RESTLInterface : GxGenericCollectionItem<SdtPersona>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPersona_RESTLInterface( ) : base()
      {
      }

      public SdtPersona_RESTLInterface( SdtPersona psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PersonaNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Personanome
      {
         get {
            return sdt.gxTpr_Personanome ;
         }

         set {
            sdt.gxTpr_Personanome = value;
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

      public SdtPersona sdt
      {
         get {
            return (SdtPersona)Sdt ;
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
            sdt = new SdtPersona() ;
         }
      }

   }

}
