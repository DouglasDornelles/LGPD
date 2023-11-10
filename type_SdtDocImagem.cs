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
   [XmlRoot(ElementName = "DocImagem" )]
   [XmlType(TypeName =  "DocImagem" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtDocImagem : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocImagem( )
      {
      }

      public SdtDocImagem( IGxContext context )
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

      public void Load( int AV144DocImagemId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV144DocImagemId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"DocImagemId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "DocImagem");
         metadata.Set("BT", "DocImagem");
         metadata.Set("PK", "[ \"DocImagemId\" ]");
         metadata.Set("PKAssigned", "[ \"DocImagemId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"DocumentoId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Docimagemid_Z");
         state.Add("gxTpr_Documentoid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtDocImagem sdt;
         sdt = (SdtDocImagem)(source);
         gxTv_SdtDocImagem_Docimagemid = sdt.gxTv_SdtDocImagem_Docimagemid ;
         gxTv_SdtDocImagem_Documentoid = sdt.gxTv_SdtDocImagem_Documentoid ;
         gxTv_SdtDocImagem_Docimagemarquivo = sdt.gxTv_SdtDocImagem_Docimagemarquivo ;
         gxTv_SdtDocImagem_Mode = sdt.gxTv_SdtDocImagem_Mode ;
         gxTv_SdtDocImagem_Initialized = sdt.gxTv_SdtDocImagem_Initialized ;
         gxTv_SdtDocImagem_Docimagemid_Z = sdt.gxTv_SdtDocImagem_Docimagemid_Z ;
         gxTv_SdtDocImagem_Documentoid_Z = sdt.gxTv_SdtDocImagem_Documentoid_Z ;
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
         AddObjectProperty("DocImagemId", gxTv_SdtDocImagem_Docimagemid, false, includeNonInitialized);
         AddObjectProperty("DocumentoId", gxTv_SdtDocImagem_Documentoid, false, includeNonInitialized);
         AddObjectProperty("DocImagemArquivo", gxTv_SdtDocImagem_Docimagemarquivo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtDocImagem_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtDocImagem_Initialized, false, includeNonInitialized);
            AddObjectProperty("DocImagemId_Z", gxTv_SdtDocImagem_Docimagemid_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoId_Z", gxTv_SdtDocImagem_Documentoid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtDocImagem sdt )
      {
         if ( sdt.IsDirty("DocImagemId") )
         {
            gxTv_SdtDocImagem_N = 0;
            gxTv_SdtDocImagem_Docimagemid = sdt.gxTv_SdtDocImagem_Docimagemid ;
         }
         if ( sdt.IsDirty("DocumentoId") )
         {
            gxTv_SdtDocImagem_N = 0;
            gxTv_SdtDocImagem_Documentoid = sdt.gxTv_SdtDocImagem_Documentoid ;
         }
         if ( sdt.IsDirty("DocImagemArquivo") )
         {
            gxTv_SdtDocImagem_N = 0;
            gxTv_SdtDocImagem_Docimagemarquivo = sdt.gxTv_SdtDocImagem_Docimagemarquivo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "DocImagemId" )]
      [  XmlElement( ElementName = "DocImagemId"   )]
      public int gxTpr_Docimagemid
      {
         get {
            return gxTv_SdtDocImagem_Docimagemid ;
         }

         set {
            gxTv_SdtDocImagem_N = 0;
            if ( gxTv_SdtDocImagem_Docimagemid != value )
            {
               gxTv_SdtDocImagem_Mode = "INS";
               this.gxTv_SdtDocImagem_Docimagemid_Z_SetNull( );
               this.gxTv_SdtDocImagem_Documentoid_Z_SetNull( );
            }
            gxTv_SdtDocImagem_Docimagemid = value;
            SetDirty("Docimagemid");
         }

      }

      [  SoapElement( ElementName = "DocumentoId" )]
      [  XmlElement( ElementName = "DocumentoId"   )]
      public int gxTpr_Documentoid
      {
         get {
            return gxTv_SdtDocImagem_Documentoid ;
         }

         set {
            gxTv_SdtDocImagem_N = 0;
            gxTv_SdtDocImagem_Documentoid = value;
            SetDirty("Documentoid");
         }

      }

      [  SoapElement( ElementName = "DocImagemArquivo" )]
      [  XmlElement( ElementName = "DocImagemArquivo"   )]
      public string gxTpr_Docimagemarquivo
      {
         get {
            return gxTv_SdtDocImagem_Docimagemarquivo ;
         }

         set {
            gxTv_SdtDocImagem_N = 0;
            gxTv_SdtDocImagem_Docimagemarquivo = value;
            SetDirty("Docimagemarquivo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtDocImagem_Mode ;
         }

         set {
            gxTv_SdtDocImagem_N = 0;
            gxTv_SdtDocImagem_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtDocImagem_Mode_SetNull( )
      {
         gxTv_SdtDocImagem_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtDocImagem_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtDocImagem_Initialized ;
         }

         set {
            gxTv_SdtDocImagem_N = 0;
            gxTv_SdtDocImagem_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtDocImagem_Initialized_SetNull( )
      {
         gxTv_SdtDocImagem_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtDocImagem_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocImagemId_Z" )]
      [  XmlElement( ElementName = "DocImagemId_Z"   )]
      public int gxTpr_Docimagemid_Z
      {
         get {
            return gxTv_SdtDocImagem_Docimagemid_Z ;
         }

         set {
            gxTv_SdtDocImagem_N = 0;
            gxTv_SdtDocImagem_Docimagemid_Z = value;
            SetDirty("Docimagemid_Z");
         }

      }

      public void gxTv_SdtDocImagem_Docimagemid_Z_SetNull( )
      {
         gxTv_SdtDocImagem_Docimagemid_Z = 0;
         SetDirty("Docimagemid_Z");
         return  ;
      }

      public bool gxTv_SdtDocImagem_Docimagemid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoId_Z" )]
      [  XmlElement( ElementName = "DocumentoId_Z"   )]
      public int gxTpr_Documentoid_Z
      {
         get {
            return gxTv_SdtDocImagem_Documentoid_Z ;
         }

         set {
            gxTv_SdtDocImagem_N = 0;
            gxTv_SdtDocImagem_Documentoid_Z = value;
            SetDirty("Documentoid_Z");
         }

      }

      public void gxTv_SdtDocImagem_Documentoid_Z_SetNull( )
      {
         gxTv_SdtDocImagem_Documentoid_Z = 0;
         SetDirty("Documentoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocImagem_Documentoid_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtDocImagem_N = 1;
         gxTv_SdtDocImagem_Docimagemarquivo = "";
         gxTv_SdtDocImagem_Mode = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "docimagem", "GeneXus.Programs.docimagem_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtDocImagem_N ;
      }

      private short gxTv_SdtDocImagem_N ;
      private short gxTv_SdtDocImagem_Initialized ;
      private int gxTv_SdtDocImagem_Docimagemid ;
      private int gxTv_SdtDocImagem_Documentoid ;
      private int gxTv_SdtDocImagem_Docimagemid_Z ;
      private int gxTv_SdtDocImagem_Documentoid_Z ;
      private string gxTv_SdtDocImagem_Mode ;
      private string gxTv_SdtDocImagem_Docimagemarquivo ;
   }

   [DataContract(Name = @"DocImagem", Namespace = "LGPD_Novo")]
   public class SdtDocImagem_RESTInterface : GxGenericCollectionItem<SdtDocImagem>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocImagem_RESTInterface( ) : base()
      {
      }

      public SdtDocImagem_RESTInterface( SdtDocImagem psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DocImagemId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Docimagemid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Docimagemid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Docimagemid = (int)(NumberUtil.Val( value, "."));
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

      [DataMember( Name = "DocImagemArquivo" , Order = 2 )]
      public string gxTpr_Docimagemarquivo
      {
         get {
            return sdt.gxTpr_Docimagemarquivo ;
         }

         set {
            sdt.gxTpr_Docimagemarquivo = value;
         }

      }

      public SdtDocImagem sdt
      {
         get {
            return (SdtDocImagem)Sdt ;
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
            sdt = new SdtDocImagem() ;
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

   [DataContract(Name = @"DocImagem", Namespace = "LGPD_Novo")]
   public class SdtDocImagem_RESTLInterface : GxGenericCollectionItem<SdtDocImagem>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocImagem_RESTLInterface( ) : base()
      {
      }

      public SdtDocImagem_RESTLInterface( SdtDocImagem psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DocImagemId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Docimagemid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Docimagemid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Docimagemid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            string gxuri = "/rest/DocImagem/{0}";
            gxuri = String.Format(gxuri,gxTpr_Docimagemid) ;
            return gxuri ;
         }

         set {
         }

      }

      public SdtDocImagem sdt
      {
         get {
            return (SdtDocImagem)Sdt ;
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
            sdt = new SdtDocImagem() ;
         }
      }

      private string gxuri ;
   }

}
