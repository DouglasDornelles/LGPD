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
   [XmlRoot(ElementName = "DicionarioPais" )]
   [XmlType(TypeName =  "DicionarioPais" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtDicionarioPais : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDicionarioPais( )
      {
      }

      public SdtDicionarioPais( IGxContext context )
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

      public void Load( int AV4PaisId ,
                        int AV98DocDicionarioId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV4PaisId,(int)AV98DocDicionarioId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PaisId", typeof(int)}, new Object[]{"DocDicionarioId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "DicionarioPais");
         metadata.Set("BT", "DicionarioPais");
         metadata.Set("PK", "[ \"PaisId\",\"DocDicionarioId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"DocDicionarioId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"PaisId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Paisid_Z");
         state.Add("gxTpr_Docdicionarioid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtDicionarioPais sdt;
         sdt = (SdtDicionarioPais)(source);
         gxTv_SdtDicionarioPais_Paisid = sdt.gxTv_SdtDicionarioPais_Paisid ;
         gxTv_SdtDicionarioPais_Docdicionarioid = sdt.gxTv_SdtDicionarioPais_Docdicionarioid ;
         gxTv_SdtDicionarioPais_Mode = sdt.gxTv_SdtDicionarioPais_Mode ;
         gxTv_SdtDicionarioPais_Initialized = sdt.gxTv_SdtDicionarioPais_Initialized ;
         gxTv_SdtDicionarioPais_Paisid_Z = sdt.gxTv_SdtDicionarioPais_Paisid_Z ;
         gxTv_SdtDicionarioPais_Docdicionarioid_Z = sdt.gxTv_SdtDicionarioPais_Docdicionarioid_Z ;
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
         AddObjectProperty("PaisId", gxTv_SdtDicionarioPais_Paisid, false, includeNonInitialized);
         AddObjectProperty("DocDicionarioId", gxTv_SdtDicionarioPais_Docdicionarioid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtDicionarioPais_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtDicionarioPais_Initialized, false, includeNonInitialized);
            AddObjectProperty("PaisId_Z", gxTv_SdtDicionarioPais_Paisid_Z, false, includeNonInitialized);
            AddObjectProperty("DocDicionarioId_Z", gxTv_SdtDicionarioPais_Docdicionarioid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtDicionarioPais sdt )
      {
         if ( sdt.IsDirty("PaisId") )
         {
            gxTv_SdtDicionarioPais_N = 0;
            gxTv_SdtDicionarioPais_Paisid = sdt.gxTv_SdtDicionarioPais_Paisid ;
         }
         if ( sdt.IsDirty("DocDicionarioId") )
         {
            gxTv_SdtDicionarioPais_N = 0;
            gxTv_SdtDicionarioPais_Docdicionarioid = sdt.gxTv_SdtDicionarioPais_Docdicionarioid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PaisId" )]
      [  XmlElement( ElementName = "PaisId"   )]
      public int gxTpr_Paisid
      {
         get {
            return gxTv_SdtDicionarioPais_Paisid ;
         }

         set {
            gxTv_SdtDicionarioPais_N = 0;
            if ( gxTv_SdtDicionarioPais_Paisid != value )
            {
               gxTv_SdtDicionarioPais_Mode = "INS";
               this.gxTv_SdtDicionarioPais_Paisid_Z_SetNull( );
               this.gxTv_SdtDicionarioPais_Docdicionarioid_Z_SetNull( );
            }
            gxTv_SdtDicionarioPais_Paisid = value;
            SetDirty("Paisid");
         }

      }

      [  SoapElement( ElementName = "DocDicionarioId" )]
      [  XmlElement( ElementName = "DocDicionarioId"   )]
      public int gxTpr_Docdicionarioid
      {
         get {
            return gxTv_SdtDicionarioPais_Docdicionarioid ;
         }

         set {
            gxTv_SdtDicionarioPais_N = 0;
            if ( gxTv_SdtDicionarioPais_Docdicionarioid != value )
            {
               gxTv_SdtDicionarioPais_Mode = "INS";
               this.gxTv_SdtDicionarioPais_Paisid_Z_SetNull( );
               this.gxTv_SdtDicionarioPais_Docdicionarioid_Z_SetNull( );
            }
            gxTv_SdtDicionarioPais_Docdicionarioid = value;
            SetDirty("Docdicionarioid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtDicionarioPais_Mode ;
         }

         set {
            gxTv_SdtDicionarioPais_N = 0;
            gxTv_SdtDicionarioPais_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtDicionarioPais_Mode_SetNull( )
      {
         gxTv_SdtDicionarioPais_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtDicionarioPais_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtDicionarioPais_Initialized ;
         }

         set {
            gxTv_SdtDicionarioPais_N = 0;
            gxTv_SdtDicionarioPais_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtDicionarioPais_Initialized_SetNull( )
      {
         gxTv_SdtDicionarioPais_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtDicionarioPais_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisId_Z" )]
      [  XmlElement( ElementName = "PaisId_Z"   )]
      public int gxTpr_Paisid_Z
      {
         get {
            return gxTv_SdtDicionarioPais_Paisid_Z ;
         }

         set {
            gxTv_SdtDicionarioPais_N = 0;
            gxTv_SdtDicionarioPais_Paisid_Z = value;
            SetDirty("Paisid_Z");
         }

      }

      public void gxTv_SdtDicionarioPais_Paisid_Z_SetNull( )
      {
         gxTv_SdtDicionarioPais_Paisid_Z = 0;
         SetDirty("Paisid_Z");
         return  ;
      }

      public bool gxTv_SdtDicionarioPais_Paisid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDicionarioId_Z" )]
      [  XmlElement( ElementName = "DocDicionarioId_Z"   )]
      public int gxTpr_Docdicionarioid_Z
      {
         get {
            return gxTv_SdtDicionarioPais_Docdicionarioid_Z ;
         }

         set {
            gxTv_SdtDicionarioPais_N = 0;
            gxTv_SdtDicionarioPais_Docdicionarioid_Z = value;
            SetDirty("Docdicionarioid_Z");
         }

      }

      public void gxTv_SdtDicionarioPais_Docdicionarioid_Z_SetNull( )
      {
         gxTv_SdtDicionarioPais_Docdicionarioid_Z = 0;
         SetDirty("Docdicionarioid_Z");
         return  ;
      }

      public bool gxTv_SdtDicionarioPais_Docdicionarioid_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtDicionarioPais_N = 1;
         gxTv_SdtDicionarioPais_Mode = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "dicionariopais", "GeneXus.Programs.dicionariopais_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtDicionarioPais_N ;
      }

      private short gxTv_SdtDicionarioPais_N ;
      private short gxTv_SdtDicionarioPais_Initialized ;
      private int gxTv_SdtDicionarioPais_Paisid ;
      private int gxTv_SdtDicionarioPais_Docdicionarioid ;
      private int gxTv_SdtDicionarioPais_Paisid_Z ;
      private int gxTv_SdtDicionarioPais_Docdicionarioid_Z ;
      private string gxTv_SdtDicionarioPais_Mode ;
   }

   [DataContract(Name = @"DicionarioPais", Namespace = "LGPD_Novo")]
   public class SdtDicionarioPais_RESTInterface : GxGenericCollectionItem<SdtDicionarioPais>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDicionarioPais_RESTInterface( ) : base()
      {
      }

      public SdtDicionarioPais_RESTInterface( SdtDicionarioPais psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PaisId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Paisid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Paisid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Paisid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "DocDicionarioId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Docdicionarioid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Docdicionarioid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Docdicionarioid = (int)(NumberUtil.Val( value, "."));
         }

      }

      public SdtDicionarioPais sdt
      {
         get {
            return (SdtDicionarioPais)Sdt ;
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
            sdt = new SdtDicionarioPais() ;
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

   [DataContract(Name = @"DicionarioPais", Namespace = "LGPD_Novo")]
   public class SdtDicionarioPais_RESTLInterface : GxGenericCollectionItem<SdtDicionarioPais>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDicionarioPais_RESTLInterface( ) : base()
      {
      }

      public SdtDicionarioPais_RESTLInterface( SdtDicionarioPais psdt ) : base(psdt)
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

      public SdtDicionarioPais sdt
      {
         get {
            return (SdtDicionarioPais)Sdt ;
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
            sdt = new SdtDicionarioPais() ;
         }
      }

   }

}
