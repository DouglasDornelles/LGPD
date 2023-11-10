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
   [XmlRoot(ElementName = "MedidaSeguranca" )]
   [XmlType(TypeName =  "MedidaSeguranca" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtMedidaSeguranca : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtMedidaSeguranca( )
      {
      }

      public SdtMedidaSeguranca( IGxContext context )
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

      public void Load( int AV51MedidaSegurancaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV51MedidaSegurancaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"MedidaSegurancaId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "MedidaSeguranca");
         metadata.Set("BT", "MedidaSeguranca");
         metadata.Set("PK", "[ \"MedidaSegurancaId\" ]");
         metadata.Set("PKAssigned", "[ \"MedidaSegurancaId\" ]");
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
         state.Add("gxTpr_Medidasegurancaid_Z");
         state.Add("gxTpr_Medidasegurancanome_Z");
         state.Add("gxTpr_Medidasegurancaativo_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtMedidaSeguranca sdt;
         sdt = (SdtMedidaSeguranca)(source);
         gxTv_SdtMedidaSeguranca_Medidasegurancaid = sdt.gxTv_SdtMedidaSeguranca_Medidasegurancaid ;
         gxTv_SdtMedidaSeguranca_Medidasegurancanome = sdt.gxTv_SdtMedidaSeguranca_Medidasegurancanome ;
         gxTv_SdtMedidaSeguranca_Medidasegurancaativo = sdt.gxTv_SdtMedidaSeguranca_Medidasegurancaativo ;
         gxTv_SdtMedidaSeguranca_Mode = sdt.gxTv_SdtMedidaSeguranca_Mode ;
         gxTv_SdtMedidaSeguranca_Initialized = sdt.gxTv_SdtMedidaSeguranca_Initialized ;
         gxTv_SdtMedidaSeguranca_Medidasegurancaid_Z = sdt.gxTv_SdtMedidaSeguranca_Medidasegurancaid_Z ;
         gxTv_SdtMedidaSeguranca_Medidasegurancanome_Z = sdt.gxTv_SdtMedidaSeguranca_Medidasegurancanome_Z ;
         gxTv_SdtMedidaSeguranca_Medidasegurancaativo_Z = sdt.gxTv_SdtMedidaSeguranca_Medidasegurancaativo_Z ;
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
         AddObjectProperty("MedidaSegurancaId", gxTv_SdtMedidaSeguranca_Medidasegurancaid, false, includeNonInitialized);
         AddObjectProperty("MedidaSegurancaNome", gxTv_SdtMedidaSeguranca_Medidasegurancanome, false, includeNonInitialized);
         AddObjectProperty("MedidaSegurancaAtivo", gxTv_SdtMedidaSeguranca_Medidasegurancaativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtMedidaSeguranca_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtMedidaSeguranca_Initialized, false, includeNonInitialized);
            AddObjectProperty("MedidaSegurancaId_Z", gxTv_SdtMedidaSeguranca_Medidasegurancaid_Z, false, includeNonInitialized);
            AddObjectProperty("MedidaSegurancaNome_Z", gxTv_SdtMedidaSeguranca_Medidasegurancanome_Z, false, includeNonInitialized);
            AddObjectProperty("MedidaSegurancaAtivo_Z", gxTv_SdtMedidaSeguranca_Medidasegurancaativo_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtMedidaSeguranca sdt )
      {
         if ( sdt.IsDirty("MedidaSegurancaId") )
         {
            gxTv_SdtMedidaSeguranca_N = 0;
            gxTv_SdtMedidaSeguranca_Medidasegurancaid = sdt.gxTv_SdtMedidaSeguranca_Medidasegurancaid ;
         }
         if ( sdt.IsDirty("MedidaSegurancaNome") )
         {
            gxTv_SdtMedidaSeguranca_N = 0;
            gxTv_SdtMedidaSeguranca_Medidasegurancanome = sdt.gxTv_SdtMedidaSeguranca_Medidasegurancanome ;
         }
         if ( sdt.IsDirty("MedidaSegurancaAtivo") )
         {
            gxTv_SdtMedidaSeguranca_N = 0;
            gxTv_SdtMedidaSeguranca_Medidasegurancaativo = sdt.gxTv_SdtMedidaSeguranca_Medidasegurancaativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "MedidaSegurancaId" )]
      [  XmlElement( ElementName = "MedidaSegurancaId"   )]
      public int gxTpr_Medidasegurancaid
      {
         get {
            return gxTv_SdtMedidaSeguranca_Medidasegurancaid ;
         }

         set {
            gxTv_SdtMedidaSeguranca_N = 0;
            if ( gxTv_SdtMedidaSeguranca_Medidasegurancaid != value )
            {
               gxTv_SdtMedidaSeguranca_Mode = "INS";
               this.gxTv_SdtMedidaSeguranca_Medidasegurancaid_Z_SetNull( );
               this.gxTv_SdtMedidaSeguranca_Medidasegurancanome_Z_SetNull( );
               this.gxTv_SdtMedidaSeguranca_Medidasegurancaativo_Z_SetNull( );
            }
            gxTv_SdtMedidaSeguranca_Medidasegurancaid = value;
            SetDirty("Medidasegurancaid");
         }

      }

      [  SoapElement( ElementName = "MedidaSegurancaNome" )]
      [  XmlElement( ElementName = "MedidaSegurancaNome"   )]
      public string gxTpr_Medidasegurancanome
      {
         get {
            return gxTv_SdtMedidaSeguranca_Medidasegurancanome ;
         }

         set {
            gxTv_SdtMedidaSeguranca_N = 0;
            gxTv_SdtMedidaSeguranca_Medidasegurancanome = value;
            SetDirty("Medidasegurancanome");
         }

      }

      [  SoapElement( ElementName = "MedidaSegurancaAtivo" )]
      [  XmlElement( ElementName = "MedidaSegurancaAtivo"   )]
      public bool gxTpr_Medidasegurancaativo
      {
         get {
            return gxTv_SdtMedidaSeguranca_Medidasegurancaativo ;
         }

         set {
            gxTv_SdtMedidaSeguranca_N = 0;
            gxTv_SdtMedidaSeguranca_Medidasegurancaativo = value;
            SetDirty("Medidasegurancaativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtMedidaSeguranca_Mode ;
         }

         set {
            gxTv_SdtMedidaSeguranca_N = 0;
            gxTv_SdtMedidaSeguranca_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtMedidaSeguranca_Mode_SetNull( )
      {
         gxTv_SdtMedidaSeguranca_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtMedidaSeguranca_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtMedidaSeguranca_Initialized ;
         }

         set {
            gxTv_SdtMedidaSeguranca_N = 0;
            gxTv_SdtMedidaSeguranca_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtMedidaSeguranca_Initialized_SetNull( )
      {
         gxTv_SdtMedidaSeguranca_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtMedidaSeguranca_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidaSegurancaId_Z" )]
      [  XmlElement( ElementName = "MedidaSegurancaId_Z"   )]
      public int gxTpr_Medidasegurancaid_Z
      {
         get {
            return gxTv_SdtMedidaSeguranca_Medidasegurancaid_Z ;
         }

         set {
            gxTv_SdtMedidaSeguranca_N = 0;
            gxTv_SdtMedidaSeguranca_Medidasegurancaid_Z = value;
            SetDirty("Medidasegurancaid_Z");
         }

      }

      public void gxTv_SdtMedidaSeguranca_Medidasegurancaid_Z_SetNull( )
      {
         gxTv_SdtMedidaSeguranca_Medidasegurancaid_Z = 0;
         SetDirty("Medidasegurancaid_Z");
         return  ;
      }

      public bool gxTv_SdtMedidaSeguranca_Medidasegurancaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidaSegurancaNome_Z" )]
      [  XmlElement( ElementName = "MedidaSegurancaNome_Z"   )]
      public string gxTpr_Medidasegurancanome_Z
      {
         get {
            return gxTv_SdtMedidaSeguranca_Medidasegurancanome_Z ;
         }

         set {
            gxTv_SdtMedidaSeguranca_N = 0;
            gxTv_SdtMedidaSeguranca_Medidasegurancanome_Z = value;
            SetDirty("Medidasegurancanome_Z");
         }

      }

      public void gxTv_SdtMedidaSeguranca_Medidasegurancanome_Z_SetNull( )
      {
         gxTv_SdtMedidaSeguranca_Medidasegurancanome_Z = "";
         SetDirty("Medidasegurancanome_Z");
         return  ;
      }

      public bool gxTv_SdtMedidaSeguranca_Medidasegurancanome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidaSegurancaAtivo_Z" )]
      [  XmlElement( ElementName = "MedidaSegurancaAtivo_Z"   )]
      public bool gxTpr_Medidasegurancaativo_Z
      {
         get {
            return gxTv_SdtMedidaSeguranca_Medidasegurancaativo_Z ;
         }

         set {
            gxTv_SdtMedidaSeguranca_N = 0;
            gxTv_SdtMedidaSeguranca_Medidasegurancaativo_Z = value;
            SetDirty("Medidasegurancaativo_Z");
         }

      }

      public void gxTv_SdtMedidaSeguranca_Medidasegurancaativo_Z_SetNull( )
      {
         gxTv_SdtMedidaSeguranca_Medidasegurancaativo_Z = false;
         SetDirty("Medidasegurancaativo_Z");
         return  ;
      }

      public bool gxTv_SdtMedidaSeguranca_Medidasegurancaativo_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtMedidaSeguranca_N = 1;
         gxTv_SdtMedidaSeguranca_Medidasegurancanome = "";
         gxTv_SdtMedidaSeguranca_Mode = "";
         gxTv_SdtMedidaSeguranca_Medidasegurancanome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "medidaseguranca", "GeneXus.Programs.medidaseguranca_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtMedidaSeguranca_N ;
      }

      private short gxTv_SdtMedidaSeguranca_N ;
      private short gxTv_SdtMedidaSeguranca_Initialized ;
      private int gxTv_SdtMedidaSeguranca_Medidasegurancaid ;
      private int gxTv_SdtMedidaSeguranca_Medidasegurancaid_Z ;
      private string gxTv_SdtMedidaSeguranca_Mode ;
      private bool gxTv_SdtMedidaSeguranca_Medidasegurancaativo ;
      private bool gxTv_SdtMedidaSeguranca_Medidasegurancaativo_Z ;
      private string gxTv_SdtMedidaSeguranca_Medidasegurancanome ;
      private string gxTv_SdtMedidaSeguranca_Medidasegurancanome_Z ;
   }

   [DataContract(Name = @"MedidaSeguranca", Namespace = "LGPD_Novo")]
   public class SdtMedidaSeguranca_RESTInterface : GxGenericCollectionItem<SdtMedidaSeguranca>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtMedidaSeguranca_RESTInterface( ) : base()
      {
      }

      public SdtMedidaSeguranca_RESTInterface( SdtMedidaSeguranca psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MedidaSegurancaId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Medidasegurancaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Medidasegurancaid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Medidasegurancaid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "MedidaSegurancaNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Medidasegurancanome
      {
         get {
            return sdt.gxTpr_Medidasegurancanome ;
         }

         set {
            sdt.gxTpr_Medidasegurancanome = value;
         }

      }

      [DataMember( Name = "MedidaSegurancaAtivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Medidasegurancaativo
      {
         get {
            return sdt.gxTpr_Medidasegurancaativo ;
         }

         set {
            sdt.gxTpr_Medidasegurancaativo = value;
         }

      }

      public SdtMedidaSeguranca sdt
      {
         get {
            return (SdtMedidaSeguranca)Sdt ;
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
            sdt = new SdtMedidaSeguranca() ;
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

   [DataContract(Name = @"MedidaSeguranca", Namespace = "LGPD_Novo")]
   public class SdtMedidaSeguranca_RESTLInterface : GxGenericCollectionItem<SdtMedidaSeguranca>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtMedidaSeguranca_RESTLInterface( ) : base()
      {
      }

      public SdtMedidaSeguranca_RESTLInterface( SdtMedidaSeguranca psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MedidaSegurancaNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Medidasegurancanome
      {
         get {
            return sdt.gxTpr_Medidasegurancanome ;
         }

         set {
            sdt.gxTpr_Medidasegurancanome = value;
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

      public SdtMedidaSeguranca sdt
      {
         get {
            return (SdtMedidaSeguranca)Sdt ;
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
            sdt = new SdtMedidaSeguranca() ;
         }
      }

   }

}
