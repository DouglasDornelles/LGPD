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
   [XmlRoot(ElementName = "DocEnvolvidosColeta" )]
   [XmlType(TypeName =  "DocEnvolvidosColeta" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtDocEnvolvidosColeta : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocEnvolvidosColeta( )
      {
      }

      public SdtDocEnvolvidosColeta( IGxContext context )
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

      public void Load( int AV54EnvolvidosColetaId ,
                        int AV75DocumentoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV54EnvolvidosColetaId,(int)AV75DocumentoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"EnvolvidosColetaId", typeof(int)}, new Object[]{"DocumentoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "DocEnvolvidosColeta");
         metadata.Set("BT", "DocEnvolvidosColeta");
         metadata.Set("PK", "[ \"EnvolvidosColetaId\",\"DocumentoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"DocumentoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"EnvolvidosColetaId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Documentoid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtDocEnvolvidosColeta sdt;
         sdt = (SdtDocEnvolvidosColeta)(source);
         gxTv_SdtDocEnvolvidosColeta_Envolvidoscoletaid = sdt.gxTv_SdtDocEnvolvidosColeta_Envolvidoscoletaid ;
         gxTv_SdtDocEnvolvidosColeta_Documentoid = sdt.gxTv_SdtDocEnvolvidosColeta_Documentoid ;
         gxTv_SdtDocEnvolvidosColeta_Mode = sdt.gxTv_SdtDocEnvolvidosColeta_Mode ;
         gxTv_SdtDocEnvolvidosColeta_Initialized = sdt.gxTv_SdtDocEnvolvidosColeta_Initialized ;
         gxTv_SdtDocEnvolvidosColeta_Envolvidoscoletaid_Z = sdt.gxTv_SdtDocEnvolvidosColeta_Envolvidoscoletaid_Z ;
         gxTv_SdtDocEnvolvidosColeta_Documentoid_Z = sdt.gxTv_SdtDocEnvolvidosColeta_Documentoid_Z ;
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
         AddObjectProperty("EnvolvidosColetaId", gxTv_SdtDocEnvolvidosColeta_Envolvidoscoletaid, false, includeNonInitialized);
         AddObjectProperty("DocumentoId", gxTv_SdtDocEnvolvidosColeta_Documentoid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtDocEnvolvidosColeta_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtDocEnvolvidosColeta_Initialized, false, includeNonInitialized);
            AddObjectProperty("EnvolvidosColetaId_Z", gxTv_SdtDocEnvolvidosColeta_Envolvidoscoletaid_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoId_Z", gxTv_SdtDocEnvolvidosColeta_Documentoid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtDocEnvolvidosColeta sdt )
      {
         if ( sdt.IsDirty("EnvolvidosColetaId") )
         {
            gxTv_SdtDocEnvolvidosColeta_N = 0;
            gxTv_SdtDocEnvolvidosColeta_Envolvidoscoletaid = sdt.gxTv_SdtDocEnvolvidosColeta_Envolvidoscoletaid ;
         }
         if ( sdt.IsDirty("DocumentoId") )
         {
            gxTv_SdtDocEnvolvidosColeta_N = 0;
            gxTv_SdtDocEnvolvidosColeta_Documentoid = sdt.gxTv_SdtDocEnvolvidosColeta_Documentoid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "EnvolvidosColetaId" )]
      [  XmlElement( ElementName = "EnvolvidosColetaId"   )]
      public int gxTpr_Envolvidoscoletaid
      {
         get {
            return gxTv_SdtDocEnvolvidosColeta_Envolvidoscoletaid ;
         }

         set {
            gxTv_SdtDocEnvolvidosColeta_N = 0;
            if ( gxTv_SdtDocEnvolvidosColeta_Envolvidoscoletaid != value )
            {
               gxTv_SdtDocEnvolvidosColeta_Mode = "INS";
               this.gxTv_SdtDocEnvolvidosColeta_Envolvidoscoletaid_Z_SetNull( );
               this.gxTv_SdtDocEnvolvidosColeta_Documentoid_Z_SetNull( );
            }
            gxTv_SdtDocEnvolvidosColeta_Envolvidoscoletaid = value;
            SetDirty("Envolvidoscoletaid");
         }

      }

      [  SoapElement( ElementName = "DocumentoId" )]
      [  XmlElement( ElementName = "DocumentoId"   )]
      public int gxTpr_Documentoid
      {
         get {
            return gxTv_SdtDocEnvolvidosColeta_Documentoid ;
         }

         set {
            gxTv_SdtDocEnvolvidosColeta_N = 0;
            if ( gxTv_SdtDocEnvolvidosColeta_Documentoid != value )
            {
               gxTv_SdtDocEnvolvidosColeta_Mode = "INS";
               this.gxTv_SdtDocEnvolvidosColeta_Envolvidoscoletaid_Z_SetNull( );
               this.gxTv_SdtDocEnvolvidosColeta_Documentoid_Z_SetNull( );
            }
            gxTv_SdtDocEnvolvidosColeta_Documentoid = value;
            SetDirty("Documentoid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtDocEnvolvidosColeta_Mode ;
         }

         set {
            gxTv_SdtDocEnvolvidosColeta_N = 0;
            gxTv_SdtDocEnvolvidosColeta_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtDocEnvolvidosColeta_Mode_SetNull( )
      {
         gxTv_SdtDocEnvolvidosColeta_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtDocEnvolvidosColeta_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtDocEnvolvidosColeta_Initialized ;
         }

         set {
            gxTv_SdtDocEnvolvidosColeta_N = 0;
            gxTv_SdtDocEnvolvidosColeta_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtDocEnvolvidosColeta_Initialized_SetNull( )
      {
         gxTv_SdtDocEnvolvidosColeta_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtDocEnvolvidosColeta_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EnvolvidosColetaId_Z" )]
      [  XmlElement( ElementName = "EnvolvidosColetaId_Z"   )]
      public int gxTpr_Envolvidoscoletaid_Z
      {
         get {
            return gxTv_SdtDocEnvolvidosColeta_Envolvidoscoletaid_Z ;
         }

         set {
            gxTv_SdtDocEnvolvidosColeta_N = 0;
            gxTv_SdtDocEnvolvidosColeta_Envolvidoscoletaid_Z = value;
            SetDirty("Envolvidoscoletaid_Z");
         }

      }

      public void gxTv_SdtDocEnvolvidosColeta_Envolvidoscoletaid_Z_SetNull( )
      {
         gxTv_SdtDocEnvolvidosColeta_Envolvidoscoletaid_Z = 0;
         SetDirty("Envolvidoscoletaid_Z");
         return  ;
      }

      public bool gxTv_SdtDocEnvolvidosColeta_Envolvidoscoletaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoId_Z" )]
      [  XmlElement( ElementName = "DocumentoId_Z"   )]
      public int gxTpr_Documentoid_Z
      {
         get {
            return gxTv_SdtDocEnvolvidosColeta_Documentoid_Z ;
         }

         set {
            gxTv_SdtDocEnvolvidosColeta_N = 0;
            gxTv_SdtDocEnvolvidosColeta_Documentoid_Z = value;
            SetDirty("Documentoid_Z");
         }

      }

      public void gxTv_SdtDocEnvolvidosColeta_Documentoid_Z_SetNull( )
      {
         gxTv_SdtDocEnvolvidosColeta_Documentoid_Z = 0;
         SetDirty("Documentoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocEnvolvidosColeta_Documentoid_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtDocEnvolvidosColeta_N = 1;
         gxTv_SdtDocEnvolvidosColeta_Mode = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "docenvolvidoscoleta", "GeneXus.Programs.docenvolvidoscoleta_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtDocEnvolvidosColeta_N ;
      }

      private short gxTv_SdtDocEnvolvidosColeta_N ;
      private short gxTv_SdtDocEnvolvidosColeta_Initialized ;
      private int gxTv_SdtDocEnvolvidosColeta_Envolvidoscoletaid ;
      private int gxTv_SdtDocEnvolvidosColeta_Documentoid ;
      private int gxTv_SdtDocEnvolvidosColeta_Envolvidoscoletaid_Z ;
      private int gxTv_SdtDocEnvolvidosColeta_Documentoid_Z ;
      private string gxTv_SdtDocEnvolvidosColeta_Mode ;
   }

   [DataContract(Name = @"DocEnvolvidosColeta", Namespace = "LGPD_Novo")]
   public class SdtDocEnvolvidosColeta_RESTInterface : GxGenericCollectionItem<SdtDocEnvolvidosColeta>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocEnvolvidosColeta_RESTInterface( ) : base()
      {
      }

      public SdtDocEnvolvidosColeta_RESTInterface( SdtDocEnvolvidosColeta psdt ) : base(psdt)
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

      public SdtDocEnvolvidosColeta sdt
      {
         get {
            return (SdtDocEnvolvidosColeta)Sdt ;
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
            sdt = new SdtDocEnvolvidosColeta() ;
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

   [DataContract(Name = @"DocEnvolvidosColeta", Namespace = "LGPD_Novo")]
   public class SdtDocEnvolvidosColeta_RESTLInterface : GxGenericCollectionItem<SdtDocEnvolvidosColeta>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocEnvolvidosColeta_RESTLInterface( ) : base()
      {
      }

      public SdtDocEnvolvidosColeta_RESTLInterface( SdtDocEnvolvidosColeta psdt ) : base(psdt)
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

      public SdtDocEnvolvidosColeta sdt
      {
         get {
            return (SdtDocEnvolvidosColeta)Sdt ;
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
            sdt = new SdtDocEnvolvidosColeta() ;
         }
      }

   }

}
