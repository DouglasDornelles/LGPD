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
   [XmlRoot(ElementName = "FerramentaColeta" )]
   [XmlType(TypeName =  "FerramentaColeta" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtFerramentaColeta : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtFerramentaColeta( )
      {
      }

      public SdtFerramentaColeta( IGxContext context )
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

      public void Load( int AV33FerramentaColetaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV33FerramentaColetaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"FerramentaColetaId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "FerramentaColeta");
         metadata.Set("BT", "FerramentaColeta");
         metadata.Set("PK", "[ \"FerramentaColetaId\" ]");
         metadata.Set("PKAssigned", "[ \"FerramentaColetaId\" ]");
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
         state.Add("gxTpr_Ferramentacoletaid_Z");
         state.Add("gxTpr_Ferramentacoletanome_Z");
         state.Add("gxTpr_Ferramentacoletaativo_Z");
         state.Add("gxTpr_Ferramentacoletaid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtFerramentaColeta sdt;
         sdt = (SdtFerramentaColeta)(source);
         gxTv_SdtFerramentaColeta_Ferramentacoletaid = sdt.gxTv_SdtFerramentaColeta_Ferramentacoletaid ;
         gxTv_SdtFerramentaColeta_Ferramentacoletanome = sdt.gxTv_SdtFerramentaColeta_Ferramentacoletanome ;
         gxTv_SdtFerramentaColeta_Ferramentacoletaativo = sdt.gxTv_SdtFerramentaColeta_Ferramentacoletaativo ;
         gxTv_SdtFerramentaColeta_Mode = sdt.gxTv_SdtFerramentaColeta_Mode ;
         gxTv_SdtFerramentaColeta_Initialized = sdt.gxTv_SdtFerramentaColeta_Initialized ;
         gxTv_SdtFerramentaColeta_Ferramentacoletaid_Z = sdt.gxTv_SdtFerramentaColeta_Ferramentacoletaid_Z ;
         gxTv_SdtFerramentaColeta_Ferramentacoletanome_Z = sdt.gxTv_SdtFerramentaColeta_Ferramentacoletanome_Z ;
         gxTv_SdtFerramentaColeta_Ferramentacoletaativo_Z = sdt.gxTv_SdtFerramentaColeta_Ferramentacoletaativo_Z ;
         gxTv_SdtFerramentaColeta_Ferramentacoletaid_N = sdt.gxTv_SdtFerramentaColeta_Ferramentacoletaid_N ;
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
         AddObjectProperty("FerramentaColetaId", gxTv_SdtFerramentaColeta_Ferramentacoletaid, false, includeNonInitialized);
         AddObjectProperty("FerramentaColetaId_N", gxTv_SdtFerramentaColeta_Ferramentacoletaid_N, false, includeNonInitialized);
         AddObjectProperty("FerramentaColetaNome", gxTv_SdtFerramentaColeta_Ferramentacoletanome, false, includeNonInitialized);
         AddObjectProperty("FerramentaColetaAtivo", gxTv_SdtFerramentaColeta_Ferramentacoletaativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtFerramentaColeta_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtFerramentaColeta_Initialized, false, includeNonInitialized);
            AddObjectProperty("FerramentaColetaId_Z", gxTv_SdtFerramentaColeta_Ferramentacoletaid_Z, false, includeNonInitialized);
            AddObjectProperty("FerramentaColetaNome_Z", gxTv_SdtFerramentaColeta_Ferramentacoletanome_Z, false, includeNonInitialized);
            AddObjectProperty("FerramentaColetaAtivo_Z", gxTv_SdtFerramentaColeta_Ferramentacoletaativo_Z, false, includeNonInitialized);
            AddObjectProperty("FerramentaColetaId_N", gxTv_SdtFerramentaColeta_Ferramentacoletaid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtFerramentaColeta sdt )
      {
         if ( sdt.IsDirty("FerramentaColetaId") )
         {
            gxTv_SdtFerramentaColeta_N = 0;
            gxTv_SdtFerramentaColeta_Ferramentacoletaid = sdt.gxTv_SdtFerramentaColeta_Ferramentacoletaid ;
         }
         if ( sdt.IsDirty("FerramentaColetaNome") )
         {
            gxTv_SdtFerramentaColeta_N = 0;
            gxTv_SdtFerramentaColeta_Ferramentacoletanome = sdt.gxTv_SdtFerramentaColeta_Ferramentacoletanome ;
         }
         if ( sdt.IsDirty("FerramentaColetaAtivo") )
         {
            gxTv_SdtFerramentaColeta_N = 0;
            gxTv_SdtFerramentaColeta_Ferramentacoletaativo = sdt.gxTv_SdtFerramentaColeta_Ferramentacoletaativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "FerramentaColetaId" )]
      [  XmlElement( ElementName = "FerramentaColetaId"   )]
      public int gxTpr_Ferramentacoletaid
      {
         get {
            return gxTv_SdtFerramentaColeta_Ferramentacoletaid ;
         }

         set {
            gxTv_SdtFerramentaColeta_N = 0;
            if ( gxTv_SdtFerramentaColeta_Ferramentacoletaid != value )
            {
               gxTv_SdtFerramentaColeta_Mode = "INS";
               this.gxTv_SdtFerramentaColeta_Ferramentacoletaid_Z_SetNull( );
               this.gxTv_SdtFerramentaColeta_Ferramentacoletanome_Z_SetNull( );
               this.gxTv_SdtFerramentaColeta_Ferramentacoletaativo_Z_SetNull( );
            }
            gxTv_SdtFerramentaColeta_Ferramentacoletaid = value;
            SetDirty("Ferramentacoletaid");
         }

      }

      [  SoapElement( ElementName = "FerramentaColetaNome" )]
      [  XmlElement( ElementName = "FerramentaColetaNome"   )]
      public string gxTpr_Ferramentacoletanome
      {
         get {
            return gxTv_SdtFerramentaColeta_Ferramentacoletanome ;
         }

         set {
            gxTv_SdtFerramentaColeta_N = 0;
            gxTv_SdtFerramentaColeta_Ferramentacoletanome = value;
            SetDirty("Ferramentacoletanome");
         }

      }

      [  SoapElement( ElementName = "FerramentaColetaAtivo" )]
      [  XmlElement( ElementName = "FerramentaColetaAtivo"   )]
      public bool gxTpr_Ferramentacoletaativo
      {
         get {
            return gxTv_SdtFerramentaColeta_Ferramentacoletaativo ;
         }

         set {
            gxTv_SdtFerramentaColeta_N = 0;
            gxTv_SdtFerramentaColeta_Ferramentacoletaativo = value;
            SetDirty("Ferramentacoletaativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtFerramentaColeta_Mode ;
         }

         set {
            gxTv_SdtFerramentaColeta_N = 0;
            gxTv_SdtFerramentaColeta_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtFerramentaColeta_Mode_SetNull( )
      {
         gxTv_SdtFerramentaColeta_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtFerramentaColeta_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtFerramentaColeta_Initialized ;
         }

         set {
            gxTv_SdtFerramentaColeta_N = 0;
            gxTv_SdtFerramentaColeta_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtFerramentaColeta_Initialized_SetNull( )
      {
         gxTv_SdtFerramentaColeta_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtFerramentaColeta_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FerramentaColetaId_Z" )]
      [  XmlElement( ElementName = "FerramentaColetaId_Z"   )]
      public int gxTpr_Ferramentacoletaid_Z
      {
         get {
            return gxTv_SdtFerramentaColeta_Ferramentacoletaid_Z ;
         }

         set {
            gxTv_SdtFerramentaColeta_N = 0;
            gxTv_SdtFerramentaColeta_Ferramentacoletaid_Z = value;
            SetDirty("Ferramentacoletaid_Z");
         }

      }

      public void gxTv_SdtFerramentaColeta_Ferramentacoletaid_Z_SetNull( )
      {
         gxTv_SdtFerramentaColeta_Ferramentacoletaid_Z = 0;
         SetDirty("Ferramentacoletaid_Z");
         return  ;
      }

      public bool gxTv_SdtFerramentaColeta_Ferramentacoletaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FerramentaColetaNome_Z" )]
      [  XmlElement( ElementName = "FerramentaColetaNome_Z"   )]
      public string gxTpr_Ferramentacoletanome_Z
      {
         get {
            return gxTv_SdtFerramentaColeta_Ferramentacoletanome_Z ;
         }

         set {
            gxTv_SdtFerramentaColeta_N = 0;
            gxTv_SdtFerramentaColeta_Ferramentacoletanome_Z = value;
            SetDirty("Ferramentacoletanome_Z");
         }

      }

      public void gxTv_SdtFerramentaColeta_Ferramentacoletanome_Z_SetNull( )
      {
         gxTv_SdtFerramentaColeta_Ferramentacoletanome_Z = "";
         SetDirty("Ferramentacoletanome_Z");
         return  ;
      }

      public bool gxTv_SdtFerramentaColeta_Ferramentacoletanome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FerramentaColetaAtivo_Z" )]
      [  XmlElement( ElementName = "FerramentaColetaAtivo_Z"   )]
      public bool gxTpr_Ferramentacoletaativo_Z
      {
         get {
            return gxTv_SdtFerramentaColeta_Ferramentacoletaativo_Z ;
         }

         set {
            gxTv_SdtFerramentaColeta_N = 0;
            gxTv_SdtFerramentaColeta_Ferramentacoletaativo_Z = value;
            SetDirty("Ferramentacoletaativo_Z");
         }

      }

      public void gxTv_SdtFerramentaColeta_Ferramentacoletaativo_Z_SetNull( )
      {
         gxTv_SdtFerramentaColeta_Ferramentacoletaativo_Z = false;
         SetDirty("Ferramentacoletaativo_Z");
         return  ;
      }

      public bool gxTv_SdtFerramentaColeta_Ferramentacoletaativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FerramentaColetaId_N" )]
      [  XmlElement( ElementName = "FerramentaColetaId_N"   )]
      public short gxTpr_Ferramentacoletaid_N
      {
         get {
            return gxTv_SdtFerramentaColeta_Ferramentacoletaid_N ;
         }

         set {
            gxTv_SdtFerramentaColeta_N = 0;
            gxTv_SdtFerramentaColeta_Ferramentacoletaid_N = value;
            SetDirty("Ferramentacoletaid_N");
         }

      }

      public void gxTv_SdtFerramentaColeta_Ferramentacoletaid_N_SetNull( )
      {
         gxTv_SdtFerramentaColeta_Ferramentacoletaid_N = 0;
         SetDirty("Ferramentacoletaid_N");
         return  ;
      }

      public bool gxTv_SdtFerramentaColeta_Ferramentacoletaid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtFerramentaColeta_N = 1;
         gxTv_SdtFerramentaColeta_Ferramentacoletanome = "";
         gxTv_SdtFerramentaColeta_Mode = "";
         gxTv_SdtFerramentaColeta_Ferramentacoletanome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "ferramentacoleta", "GeneXus.Programs.ferramentacoleta_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtFerramentaColeta_N ;
      }

      private short gxTv_SdtFerramentaColeta_N ;
      private short gxTv_SdtFerramentaColeta_Initialized ;
      private short gxTv_SdtFerramentaColeta_Ferramentacoletaid_N ;
      private int gxTv_SdtFerramentaColeta_Ferramentacoletaid ;
      private int gxTv_SdtFerramentaColeta_Ferramentacoletaid_Z ;
      private string gxTv_SdtFerramentaColeta_Mode ;
      private bool gxTv_SdtFerramentaColeta_Ferramentacoletaativo ;
      private bool gxTv_SdtFerramentaColeta_Ferramentacoletaativo_Z ;
      private string gxTv_SdtFerramentaColeta_Ferramentacoletanome ;
      private string gxTv_SdtFerramentaColeta_Ferramentacoletanome_Z ;
   }

   [DataContract(Name = @"FerramentaColeta", Namespace = "LGPD_Novo")]
   public class SdtFerramentaColeta_RESTInterface : GxGenericCollectionItem<SdtFerramentaColeta>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtFerramentaColeta_RESTInterface( ) : base()
      {
      }

      public SdtFerramentaColeta_RESTInterface( SdtFerramentaColeta psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "FerramentaColetaId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Ferramentacoletaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Ferramentacoletaid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Ferramentacoletaid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "FerramentaColetaNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Ferramentacoletanome
      {
         get {
            return sdt.gxTpr_Ferramentacoletanome ;
         }

         set {
            sdt.gxTpr_Ferramentacoletanome = value;
         }

      }

      [DataMember( Name = "FerramentaColetaAtivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Ferramentacoletaativo
      {
         get {
            return sdt.gxTpr_Ferramentacoletaativo ;
         }

         set {
            sdt.gxTpr_Ferramentacoletaativo = value;
         }

      }

      public SdtFerramentaColeta sdt
      {
         get {
            return (SdtFerramentaColeta)Sdt ;
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
            sdt = new SdtFerramentaColeta() ;
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

   [DataContract(Name = @"FerramentaColeta", Namespace = "LGPD_Novo")]
   public class SdtFerramentaColeta_RESTLInterface : GxGenericCollectionItem<SdtFerramentaColeta>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtFerramentaColeta_RESTLInterface( ) : base()
      {
      }

      public SdtFerramentaColeta_RESTLInterface( SdtFerramentaColeta psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "FerramentaColetaNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Ferramentacoletanome
      {
         get {
            return sdt.gxTpr_Ferramentacoletanome ;
         }

         set {
            sdt.gxTpr_Ferramentacoletanome = value;
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

      public SdtFerramentaColeta sdt
      {
         get {
            return (SdtFerramentaColeta)Sdt ;
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
            sdt = new SdtFerramentaColeta() ;
         }
      }

   }

}
