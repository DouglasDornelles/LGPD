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
   [XmlRoot(ElementName = "EnvolvidosColeta" )]
   [XmlType(TypeName =  "EnvolvidosColeta" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtEnvolvidosColeta : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtEnvolvidosColeta( )
      {
      }

      public SdtEnvolvidosColeta( IGxContext context )
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

      public void Load( int AV54EnvolvidosColetaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV54EnvolvidosColetaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"EnvolvidosColetaId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "EnvolvidosColeta");
         metadata.Set("BT", "EnvolvidosColeta");
         metadata.Set("PK", "[ \"EnvolvidosColetaId\" ]");
         metadata.Set("PKAssigned", "[ \"EnvolvidosColetaId\" ]");
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
         state.Add("gxTpr_Envolvidoscoletaid_Z");
         state.Add("gxTpr_Envolvidoscoletanome_Z");
         state.Add("gxTpr_Envolvidoscoletaativo_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtEnvolvidosColeta sdt;
         sdt = (SdtEnvolvidosColeta)(source);
         gxTv_SdtEnvolvidosColeta_Envolvidoscoletaid = sdt.gxTv_SdtEnvolvidosColeta_Envolvidoscoletaid ;
         gxTv_SdtEnvolvidosColeta_Envolvidoscoletanome = sdt.gxTv_SdtEnvolvidosColeta_Envolvidoscoletanome ;
         gxTv_SdtEnvolvidosColeta_Envolvidoscoletaativo = sdt.gxTv_SdtEnvolvidosColeta_Envolvidoscoletaativo ;
         gxTv_SdtEnvolvidosColeta_Mode = sdt.gxTv_SdtEnvolvidosColeta_Mode ;
         gxTv_SdtEnvolvidosColeta_Initialized = sdt.gxTv_SdtEnvolvidosColeta_Initialized ;
         gxTv_SdtEnvolvidosColeta_Envolvidoscoletaid_Z = sdt.gxTv_SdtEnvolvidosColeta_Envolvidoscoletaid_Z ;
         gxTv_SdtEnvolvidosColeta_Envolvidoscoletanome_Z = sdt.gxTv_SdtEnvolvidosColeta_Envolvidoscoletanome_Z ;
         gxTv_SdtEnvolvidosColeta_Envolvidoscoletaativo_Z = sdt.gxTv_SdtEnvolvidosColeta_Envolvidoscoletaativo_Z ;
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
         AddObjectProperty("EnvolvidosColetaId", gxTv_SdtEnvolvidosColeta_Envolvidoscoletaid, false, includeNonInitialized);
         AddObjectProperty("EnvolvidosColetaNome", gxTv_SdtEnvolvidosColeta_Envolvidoscoletanome, false, includeNonInitialized);
         AddObjectProperty("EnvolvidosColetaAtivo", gxTv_SdtEnvolvidosColeta_Envolvidoscoletaativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtEnvolvidosColeta_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtEnvolvidosColeta_Initialized, false, includeNonInitialized);
            AddObjectProperty("EnvolvidosColetaId_Z", gxTv_SdtEnvolvidosColeta_Envolvidoscoletaid_Z, false, includeNonInitialized);
            AddObjectProperty("EnvolvidosColetaNome_Z", gxTv_SdtEnvolvidosColeta_Envolvidoscoletanome_Z, false, includeNonInitialized);
            AddObjectProperty("EnvolvidosColetaAtivo_Z", gxTv_SdtEnvolvidosColeta_Envolvidoscoletaativo_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtEnvolvidosColeta sdt )
      {
         if ( sdt.IsDirty("EnvolvidosColetaId") )
         {
            gxTv_SdtEnvolvidosColeta_N = 0;
            gxTv_SdtEnvolvidosColeta_Envolvidoscoletaid = sdt.gxTv_SdtEnvolvidosColeta_Envolvidoscoletaid ;
         }
         if ( sdt.IsDirty("EnvolvidosColetaNome") )
         {
            gxTv_SdtEnvolvidosColeta_N = 0;
            gxTv_SdtEnvolvidosColeta_Envolvidoscoletanome = sdt.gxTv_SdtEnvolvidosColeta_Envolvidoscoletanome ;
         }
         if ( sdt.IsDirty("EnvolvidosColetaAtivo") )
         {
            gxTv_SdtEnvolvidosColeta_N = 0;
            gxTv_SdtEnvolvidosColeta_Envolvidoscoletaativo = sdt.gxTv_SdtEnvolvidosColeta_Envolvidoscoletaativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "EnvolvidosColetaId" )]
      [  XmlElement( ElementName = "EnvolvidosColetaId"   )]
      public int gxTpr_Envolvidoscoletaid
      {
         get {
            return gxTv_SdtEnvolvidosColeta_Envolvidoscoletaid ;
         }

         set {
            gxTv_SdtEnvolvidosColeta_N = 0;
            if ( gxTv_SdtEnvolvidosColeta_Envolvidoscoletaid != value )
            {
               gxTv_SdtEnvolvidosColeta_Mode = "INS";
               this.gxTv_SdtEnvolvidosColeta_Envolvidoscoletaid_Z_SetNull( );
               this.gxTv_SdtEnvolvidosColeta_Envolvidoscoletanome_Z_SetNull( );
               this.gxTv_SdtEnvolvidosColeta_Envolvidoscoletaativo_Z_SetNull( );
            }
            gxTv_SdtEnvolvidosColeta_Envolvidoscoletaid = value;
            SetDirty("Envolvidoscoletaid");
         }

      }

      [  SoapElement( ElementName = "EnvolvidosColetaNome" )]
      [  XmlElement( ElementName = "EnvolvidosColetaNome"   )]
      public string gxTpr_Envolvidoscoletanome
      {
         get {
            return gxTv_SdtEnvolvidosColeta_Envolvidoscoletanome ;
         }

         set {
            gxTv_SdtEnvolvidosColeta_N = 0;
            gxTv_SdtEnvolvidosColeta_Envolvidoscoletanome = value;
            SetDirty("Envolvidoscoletanome");
         }

      }

      [  SoapElement( ElementName = "EnvolvidosColetaAtivo" )]
      [  XmlElement( ElementName = "EnvolvidosColetaAtivo"   )]
      public bool gxTpr_Envolvidoscoletaativo
      {
         get {
            return gxTv_SdtEnvolvidosColeta_Envolvidoscoletaativo ;
         }

         set {
            gxTv_SdtEnvolvidosColeta_N = 0;
            gxTv_SdtEnvolvidosColeta_Envolvidoscoletaativo = value;
            SetDirty("Envolvidoscoletaativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtEnvolvidosColeta_Mode ;
         }

         set {
            gxTv_SdtEnvolvidosColeta_N = 0;
            gxTv_SdtEnvolvidosColeta_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtEnvolvidosColeta_Mode_SetNull( )
      {
         gxTv_SdtEnvolvidosColeta_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtEnvolvidosColeta_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtEnvolvidosColeta_Initialized ;
         }

         set {
            gxTv_SdtEnvolvidosColeta_N = 0;
            gxTv_SdtEnvolvidosColeta_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtEnvolvidosColeta_Initialized_SetNull( )
      {
         gxTv_SdtEnvolvidosColeta_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtEnvolvidosColeta_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EnvolvidosColetaId_Z" )]
      [  XmlElement( ElementName = "EnvolvidosColetaId_Z"   )]
      public int gxTpr_Envolvidoscoletaid_Z
      {
         get {
            return gxTv_SdtEnvolvidosColeta_Envolvidoscoletaid_Z ;
         }

         set {
            gxTv_SdtEnvolvidosColeta_N = 0;
            gxTv_SdtEnvolvidosColeta_Envolvidoscoletaid_Z = value;
            SetDirty("Envolvidoscoletaid_Z");
         }

      }

      public void gxTv_SdtEnvolvidosColeta_Envolvidoscoletaid_Z_SetNull( )
      {
         gxTv_SdtEnvolvidosColeta_Envolvidoscoletaid_Z = 0;
         SetDirty("Envolvidoscoletaid_Z");
         return  ;
      }

      public bool gxTv_SdtEnvolvidosColeta_Envolvidoscoletaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EnvolvidosColetaNome_Z" )]
      [  XmlElement( ElementName = "EnvolvidosColetaNome_Z"   )]
      public string gxTpr_Envolvidoscoletanome_Z
      {
         get {
            return gxTv_SdtEnvolvidosColeta_Envolvidoscoletanome_Z ;
         }

         set {
            gxTv_SdtEnvolvidosColeta_N = 0;
            gxTv_SdtEnvolvidosColeta_Envolvidoscoletanome_Z = value;
            SetDirty("Envolvidoscoletanome_Z");
         }

      }

      public void gxTv_SdtEnvolvidosColeta_Envolvidoscoletanome_Z_SetNull( )
      {
         gxTv_SdtEnvolvidosColeta_Envolvidoscoletanome_Z = "";
         SetDirty("Envolvidoscoletanome_Z");
         return  ;
      }

      public bool gxTv_SdtEnvolvidosColeta_Envolvidoscoletanome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EnvolvidosColetaAtivo_Z" )]
      [  XmlElement( ElementName = "EnvolvidosColetaAtivo_Z"   )]
      public bool gxTpr_Envolvidoscoletaativo_Z
      {
         get {
            return gxTv_SdtEnvolvidosColeta_Envolvidoscoletaativo_Z ;
         }

         set {
            gxTv_SdtEnvolvidosColeta_N = 0;
            gxTv_SdtEnvolvidosColeta_Envolvidoscoletaativo_Z = value;
            SetDirty("Envolvidoscoletaativo_Z");
         }

      }

      public void gxTv_SdtEnvolvidosColeta_Envolvidoscoletaativo_Z_SetNull( )
      {
         gxTv_SdtEnvolvidosColeta_Envolvidoscoletaativo_Z = false;
         SetDirty("Envolvidoscoletaativo_Z");
         return  ;
      }

      public bool gxTv_SdtEnvolvidosColeta_Envolvidoscoletaativo_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtEnvolvidosColeta_N = 1;
         gxTv_SdtEnvolvidosColeta_Envolvidoscoletanome = "";
         gxTv_SdtEnvolvidosColeta_Mode = "";
         gxTv_SdtEnvolvidosColeta_Envolvidoscoletanome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "envolvidoscoleta", "GeneXus.Programs.envolvidoscoleta_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtEnvolvidosColeta_N ;
      }

      private short gxTv_SdtEnvolvidosColeta_N ;
      private short gxTv_SdtEnvolvidosColeta_Initialized ;
      private int gxTv_SdtEnvolvidosColeta_Envolvidoscoletaid ;
      private int gxTv_SdtEnvolvidosColeta_Envolvidoscoletaid_Z ;
      private string gxTv_SdtEnvolvidosColeta_Mode ;
      private bool gxTv_SdtEnvolvidosColeta_Envolvidoscoletaativo ;
      private bool gxTv_SdtEnvolvidosColeta_Envolvidoscoletaativo_Z ;
      private string gxTv_SdtEnvolvidosColeta_Envolvidoscoletanome ;
      private string gxTv_SdtEnvolvidosColeta_Envolvidoscoletanome_Z ;
   }

   [DataContract(Name = @"EnvolvidosColeta", Namespace = "LGPD_Novo")]
   public class SdtEnvolvidosColeta_RESTInterface : GxGenericCollectionItem<SdtEnvolvidosColeta>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtEnvolvidosColeta_RESTInterface( ) : base()
      {
      }

      public SdtEnvolvidosColeta_RESTInterface( SdtEnvolvidosColeta psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EnvolvidosColetaId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Envolvidoscoletaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Envolvidoscoletaid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Envolvidoscoletaid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "EnvolvidosColetaNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Envolvidoscoletanome
      {
         get {
            return sdt.gxTpr_Envolvidoscoletanome ;
         }

         set {
            sdt.gxTpr_Envolvidoscoletanome = value;
         }

      }

      [DataMember( Name = "EnvolvidosColetaAtivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Envolvidoscoletaativo
      {
         get {
            return sdt.gxTpr_Envolvidoscoletaativo ;
         }

         set {
            sdt.gxTpr_Envolvidoscoletaativo = value;
         }

      }

      public SdtEnvolvidosColeta sdt
      {
         get {
            return (SdtEnvolvidosColeta)Sdt ;
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
            sdt = new SdtEnvolvidosColeta() ;
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

   [DataContract(Name = @"EnvolvidosColeta", Namespace = "LGPD_Novo")]
   public class SdtEnvolvidosColeta_RESTLInterface : GxGenericCollectionItem<SdtEnvolvidosColeta>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtEnvolvidosColeta_RESTLInterface( ) : base()
      {
      }

      public SdtEnvolvidosColeta_RESTLInterface( SdtEnvolvidosColeta psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EnvolvidosColetaNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Envolvidoscoletanome
      {
         get {
            return sdt.gxTpr_Envolvidoscoletanome ;
         }

         set {
            sdt.gxTpr_Envolvidoscoletanome = value;
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

      public SdtEnvolvidosColeta sdt
      {
         get {
            return (SdtEnvolvidosColeta)Sdt ;
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
            sdt = new SdtEnvolvidosColeta() ;
         }
      }

   }

}
