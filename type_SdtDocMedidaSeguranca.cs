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
   [XmlRoot(ElementName = "DocMedidaSeguranca" )]
   [XmlType(TypeName =  "DocMedidaSeguranca" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtDocMedidaSeguranca : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocMedidaSeguranca( )
      {
      }

      public SdtDocMedidaSeguranca( IGxContext context )
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

      public void Load( int AV51MedidaSegurancaId ,
                        int AV75DocumentoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV51MedidaSegurancaId,(int)AV75DocumentoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"MedidaSegurancaId", typeof(int)}, new Object[]{"DocumentoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "DocMedidaSeguranca");
         metadata.Set("BT", "DocMedidaSeguranca");
         metadata.Set("PK", "[ \"MedidaSegurancaId\",\"DocumentoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"DocumentoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"MedidaSegurancaId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Documentoid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtDocMedidaSeguranca sdt;
         sdt = (SdtDocMedidaSeguranca)(source);
         gxTv_SdtDocMedidaSeguranca_Medidasegurancaid = sdt.gxTv_SdtDocMedidaSeguranca_Medidasegurancaid ;
         gxTv_SdtDocMedidaSeguranca_Documentoid = sdt.gxTv_SdtDocMedidaSeguranca_Documentoid ;
         gxTv_SdtDocMedidaSeguranca_Mode = sdt.gxTv_SdtDocMedidaSeguranca_Mode ;
         gxTv_SdtDocMedidaSeguranca_Initialized = sdt.gxTv_SdtDocMedidaSeguranca_Initialized ;
         gxTv_SdtDocMedidaSeguranca_Medidasegurancaid_Z = sdt.gxTv_SdtDocMedidaSeguranca_Medidasegurancaid_Z ;
         gxTv_SdtDocMedidaSeguranca_Documentoid_Z = sdt.gxTv_SdtDocMedidaSeguranca_Documentoid_Z ;
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
         AddObjectProperty("MedidaSegurancaId", gxTv_SdtDocMedidaSeguranca_Medidasegurancaid, false, includeNonInitialized);
         AddObjectProperty("DocumentoId", gxTv_SdtDocMedidaSeguranca_Documentoid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtDocMedidaSeguranca_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtDocMedidaSeguranca_Initialized, false, includeNonInitialized);
            AddObjectProperty("MedidaSegurancaId_Z", gxTv_SdtDocMedidaSeguranca_Medidasegurancaid_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoId_Z", gxTv_SdtDocMedidaSeguranca_Documentoid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtDocMedidaSeguranca sdt )
      {
         if ( sdt.IsDirty("MedidaSegurancaId") )
         {
            gxTv_SdtDocMedidaSeguranca_N = 0;
            gxTv_SdtDocMedidaSeguranca_Medidasegurancaid = sdt.gxTv_SdtDocMedidaSeguranca_Medidasegurancaid ;
         }
         if ( sdt.IsDirty("DocumentoId") )
         {
            gxTv_SdtDocMedidaSeguranca_N = 0;
            gxTv_SdtDocMedidaSeguranca_Documentoid = sdt.gxTv_SdtDocMedidaSeguranca_Documentoid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "MedidaSegurancaId" )]
      [  XmlElement( ElementName = "MedidaSegurancaId"   )]
      public int gxTpr_Medidasegurancaid
      {
         get {
            return gxTv_SdtDocMedidaSeguranca_Medidasegurancaid ;
         }

         set {
            gxTv_SdtDocMedidaSeguranca_N = 0;
            if ( gxTv_SdtDocMedidaSeguranca_Medidasegurancaid != value )
            {
               gxTv_SdtDocMedidaSeguranca_Mode = "INS";
               this.gxTv_SdtDocMedidaSeguranca_Medidasegurancaid_Z_SetNull( );
               this.gxTv_SdtDocMedidaSeguranca_Documentoid_Z_SetNull( );
            }
            gxTv_SdtDocMedidaSeguranca_Medidasegurancaid = value;
            SetDirty("Medidasegurancaid");
         }

      }

      [  SoapElement( ElementName = "DocumentoId" )]
      [  XmlElement( ElementName = "DocumentoId"   )]
      public int gxTpr_Documentoid
      {
         get {
            return gxTv_SdtDocMedidaSeguranca_Documentoid ;
         }

         set {
            gxTv_SdtDocMedidaSeguranca_N = 0;
            if ( gxTv_SdtDocMedidaSeguranca_Documentoid != value )
            {
               gxTv_SdtDocMedidaSeguranca_Mode = "INS";
               this.gxTv_SdtDocMedidaSeguranca_Medidasegurancaid_Z_SetNull( );
               this.gxTv_SdtDocMedidaSeguranca_Documentoid_Z_SetNull( );
            }
            gxTv_SdtDocMedidaSeguranca_Documentoid = value;
            SetDirty("Documentoid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtDocMedidaSeguranca_Mode ;
         }

         set {
            gxTv_SdtDocMedidaSeguranca_N = 0;
            gxTv_SdtDocMedidaSeguranca_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtDocMedidaSeguranca_Mode_SetNull( )
      {
         gxTv_SdtDocMedidaSeguranca_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtDocMedidaSeguranca_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtDocMedidaSeguranca_Initialized ;
         }

         set {
            gxTv_SdtDocMedidaSeguranca_N = 0;
            gxTv_SdtDocMedidaSeguranca_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtDocMedidaSeguranca_Initialized_SetNull( )
      {
         gxTv_SdtDocMedidaSeguranca_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtDocMedidaSeguranca_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidaSegurancaId_Z" )]
      [  XmlElement( ElementName = "MedidaSegurancaId_Z"   )]
      public int gxTpr_Medidasegurancaid_Z
      {
         get {
            return gxTv_SdtDocMedidaSeguranca_Medidasegurancaid_Z ;
         }

         set {
            gxTv_SdtDocMedidaSeguranca_N = 0;
            gxTv_SdtDocMedidaSeguranca_Medidasegurancaid_Z = value;
            SetDirty("Medidasegurancaid_Z");
         }

      }

      public void gxTv_SdtDocMedidaSeguranca_Medidasegurancaid_Z_SetNull( )
      {
         gxTv_SdtDocMedidaSeguranca_Medidasegurancaid_Z = 0;
         SetDirty("Medidasegurancaid_Z");
         return  ;
      }

      public bool gxTv_SdtDocMedidaSeguranca_Medidasegurancaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoId_Z" )]
      [  XmlElement( ElementName = "DocumentoId_Z"   )]
      public int gxTpr_Documentoid_Z
      {
         get {
            return gxTv_SdtDocMedidaSeguranca_Documentoid_Z ;
         }

         set {
            gxTv_SdtDocMedidaSeguranca_N = 0;
            gxTv_SdtDocMedidaSeguranca_Documentoid_Z = value;
            SetDirty("Documentoid_Z");
         }

      }

      public void gxTv_SdtDocMedidaSeguranca_Documentoid_Z_SetNull( )
      {
         gxTv_SdtDocMedidaSeguranca_Documentoid_Z = 0;
         SetDirty("Documentoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocMedidaSeguranca_Documentoid_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtDocMedidaSeguranca_N = 1;
         gxTv_SdtDocMedidaSeguranca_Mode = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "docmedidaseguranca", "GeneXus.Programs.docmedidaseguranca_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtDocMedidaSeguranca_N ;
      }

      private short gxTv_SdtDocMedidaSeguranca_N ;
      private short gxTv_SdtDocMedidaSeguranca_Initialized ;
      private int gxTv_SdtDocMedidaSeguranca_Medidasegurancaid ;
      private int gxTv_SdtDocMedidaSeguranca_Documentoid ;
      private int gxTv_SdtDocMedidaSeguranca_Medidasegurancaid_Z ;
      private int gxTv_SdtDocMedidaSeguranca_Documentoid_Z ;
      private string gxTv_SdtDocMedidaSeguranca_Mode ;
   }

   [DataContract(Name = @"DocMedidaSeguranca", Namespace = "LGPD_Novo")]
   public class SdtDocMedidaSeguranca_RESTInterface : GxGenericCollectionItem<SdtDocMedidaSeguranca>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocMedidaSeguranca_RESTInterface( ) : base()
      {
      }

      public SdtDocMedidaSeguranca_RESTInterface( SdtDocMedidaSeguranca psdt ) : base(psdt)
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

      [DataMember( Name = "DocumentoId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Documentoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Documentoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Documentoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      public SdtDocMedidaSeguranca sdt
      {
         get {
            return (SdtDocMedidaSeguranca)Sdt ;
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
            sdt = new SdtDocMedidaSeguranca() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 2 )]
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

   [DataContract(Name = @"DocMedidaSeguranca", Namespace = "LGPD_Novo")]
   public class SdtDocMedidaSeguranca_RESTLInterface : GxGenericCollectionItem<SdtDocMedidaSeguranca>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocMedidaSeguranca_RESTLInterface( ) : base()
      {
      }

      public SdtDocMedidaSeguranca_RESTLInterface( SdtDocMedidaSeguranca psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "uri", Order = 0 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtDocMedidaSeguranca sdt
      {
         get {
            return (SdtDocMedidaSeguranca)Sdt ;
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
            sdt = new SdtDocMedidaSeguranca() ;
         }
      }

   }

}
