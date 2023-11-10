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
   [XmlRoot(ElementName = "Tooltip" )]
   [XmlType(TypeName =  "Tooltip" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtTooltip : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTooltip( )
      {
      }

      public SdtTooltip( IGxContext context )
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

      public void Load( int AV112TooltipId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV112TooltipId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TooltipId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Tooltip");
         metadata.Set("BT", "Tooltip");
         metadata.Set("PK", "[ \"TooltipId\" ]");
         metadata.Set("PKAssigned", "[ \"TooltipId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CampoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"TelaId\" ],\"FKMap\":[ \"TooltipTelaId-TelaId\" ] } ]");
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
         state.Add("gxTpr_Tooltipid_Z");
         state.Add("gxTpr_Tooltipativo_Z");
         state.Add("gxTpr_Campoid_Z");
         state.Add("gxTpr_Camponome_Z");
         state.Add("gxTpr_Tooltiptelaid_Z");
         state.Add("gxTpr_Tooltiptelanome_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTooltip sdt;
         sdt = (SdtTooltip)(source);
         gxTv_SdtTooltip_Tooltipid = sdt.gxTv_SdtTooltip_Tooltipid ;
         gxTv_SdtTooltip_Tooltipdescricao = sdt.gxTv_SdtTooltip_Tooltipdescricao ;
         gxTv_SdtTooltip_Tooltipativo = sdt.gxTv_SdtTooltip_Tooltipativo ;
         gxTv_SdtTooltip_Campoid = sdt.gxTv_SdtTooltip_Campoid ;
         gxTv_SdtTooltip_Camponome = sdt.gxTv_SdtTooltip_Camponome ;
         gxTv_SdtTooltip_Tooltiptelaid = sdt.gxTv_SdtTooltip_Tooltiptelaid ;
         gxTv_SdtTooltip_Tooltiptelanome = sdt.gxTv_SdtTooltip_Tooltiptelanome ;
         gxTv_SdtTooltip_Mode = sdt.gxTv_SdtTooltip_Mode ;
         gxTv_SdtTooltip_Initialized = sdt.gxTv_SdtTooltip_Initialized ;
         gxTv_SdtTooltip_Tooltipid_Z = sdt.gxTv_SdtTooltip_Tooltipid_Z ;
         gxTv_SdtTooltip_Tooltipativo_Z = sdt.gxTv_SdtTooltip_Tooltipativo_Z ;
         gxTv_SdtTooltip_Campoid_Z = sdt.gxTv_SdtTooltip_Campoid_Z ;
         gxTv_SdtTooltip_Camponome_Z = sdt.gxTv_SdtTooltip_Camponome_Z ;
         gxTv_SdtTooltip_Tooltiptelaid_Z = sdt.gxTv_SdtTooltip_Tooltiptelaid_Z ;
         gxTv_SdtTooltip_Tooltiptelanome_Z = sdt.gxTv_SdtTooltip_Tooltiptelanome_Z ;
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
         AddObjectProperty("TooltipId", gxTv_SdtTooltip_Tooltipid, false, includeNonInitialized);
         AddObjectProperty("TooltipDescricao", gxTv_SdtTooltip_Tooltipdescricao, false, includeNonInitialized);
         AddObjectProperty("TooltipAtivo", gxTv_SdtTooltip_Tooltipativo, false, includeNonInitialized);
         AddObjectProperty("CampoId", gxTv_SdtTooltip_Campoid, false, includeNonInitialized);
         AddObjectProperty("CampoNome", gxTv_SdtTooltip_Camponome, false, includeNonInitialized);
         AddObjectProperty("TooltipTelaId", gxTv_SdtTooltip_Tooltiptelaid, false, includeNonInitialized);
         AddObjectProperty("TooltipTelaNome", gxTv_SdtTooltip_Tooltiptelanome, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTooltip_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTooltip_Initialized, false, includeNonInitialized);
            AddObjectProperty("TooltipId_Z", gxTv_SdtTooltip_Tooltipid_Z, false, includeNonInitialized);
            AddObjectProperty("TooltipAtivo_Z", gxTv_SdtTooltip_Tooltipativo_Z, false, includeNonInitialized);
            AddObjectProperty("CampoId_Z", gxTv_SdtTooltip_Campoid_Z, false, includeNonInitialized);
            AddObjectProperty("CampoNome_Z", gxTv_SdtTooltip_Camponome_Z, false, includeNonInitialized);
            AddObjectProperty("TooltipTelaId_Z", gxTv_SdtTooltip_Tooltiptelaid_Z, false, includeNonInitialized);
            AddObjectProperty("TooltipTelaNome_Z", gxTv_SdtTooltip_Tooltiptelanome_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTooltip sdt )
      {
         if ( sdt.IsDirty("TooltipId") )
         {
            gxTv_SdtTooltip_N = 0;
            gxTv_SdtTooltip_Tooltipid = sdt.gxTv_SdtTooltip_Tooltipid ;
         }
         if ( sdt.IsDirty("TooltipDescricao") )
         {
            gxTv_SdtTooltip_N = 0;
            gxTv_SdtTooltip_Tooltipdescricao = sdt.gxTv_SdtTooltip_Tooltipdescricao ;
         }
         if ( sdt.IsDirty("TooltipAtivo") )
         {
            gxTv_SdtTooltip_N = 0;
            gxTv_SdtTooltip_Tooltipativo = sdt.gxTv_SdtTooltip_Tooltipativo ;
         }
         if ( sdt.IsDirty("CampoId") )
         {
            gxTv_SdtTooltip_N = 0;
            gxTv_SdtTooltip_Campoid = sdt.gxTv_SdtTooltip_Campoid ;
         }
         if ( sdt.IsDirty("CampoNome") )
         {
            gxTv_SdtTooltip_N = 0;
            gxTv_SdtTooltip_Camponome = sdt.gxTv_SdtTooltip_Camponome ;
         }
         if ( sdt.IsDirty("TooltipTelaId") )
         {
            gxTv_SdtTooltip_N = 0;
            gxTv_SdtTooltip_Tooltiptelaid = sdt.gxTv_SdtTooltip_Tooltiptelaid ;
         }
         if ( sdt.IsDirty("TooltipTelaNome") )
         {
            gxTv_SdtTooltip_N = 0;
            gxTv_SdtTooltip_Tooltiptelanome = sdt.gxTv_SdtTooltip_Tooltiptelanome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TooltipId" )]
      [  XmlElement( ElementName = "TooltipId"   )]
      public int gxTpr_Tooltipid
      {
         get {
            return gxTv_SdtTooltip_Tooltipid ;
         }

         set {
            gxTv_SdtTooltip_N = 0;
            if ( gxTv_SdtTooltip_Tooltipid != value )
            {
               gxTv_SdtTooltip_Mode = "INS";
               this.gxTv_SdtTooltip_Tooltipid_Z_SetNull( );
               this.gxTv_SdtTooltip_Tooltipativo_Z_SetNull( );
               this.gxTv_SdtTooltip_Campoid_Z_SetNull( );
               this.gxTv_SdtTooltip_Camponome_Z_SetNull( );
               this.gxTv_SdtTooltip_Tooltiptelaid_Z_SetNull( );
               this.gxTv_SdtTooltip_Tooltiptelanome_Z_SetNull( );
            }
            gxTv_SdtTooltip_Tooltipid = value;
            SetDirty("Tooltipid");
         }

      }

      [  SoapElement( ElementName = "TooltipDescricao" )]
      [  XmlElement( ElementName = "TooltipDescricao"   )]
      public string gxTpr_Tooltipdescricao
      {
         get {
            return gxTv_SdtTooltip_Tooltipdescricao ;
         }

         set {
            gxTv_SdtTooltip_N = 0;
            gxTv_SdtTooltip_Tooltipdescricao = value;
            SetDirty("Tooltipdescricao");
         }

      }

      [  SoapElement( ElementName = "TooltipAtivo" )]
      [  XmlElement( ElementName = "TooltipAtivo"   )]
      public bool gxTpr_Tooltipativo
      {
         get {
            return gxTv_SdtTooltip_Tooltipativo ;
         }

         set {
            gxTv_SdtTooltip_N = 0;
            gxTv_SdtTooltip_Tooltipativo = value;
            SetDirty("Tooltipativo");
         }

      }

      [  SoapElement( ElementName = "CampoId" )]
      [  XmlElement( ElementName = "CampoId"   )]
      public int gxTpr_Campoid
      {
         get {
            return gxTv_SdtTooltip_Campoid ;
         }

         set {
            gxTv_SdtTooltip_N = 0;
            gxTv_SdtTooltip_Campoid = value;
            SetDirty("Campoid");
         }

      }

      [  SoapElement( ElementName = "CampoNome" )]
      [  XmlElement( ElementName = "CampoNome"   )]
      public string gxTpr_Camponome
      {
         get {
            return gxTv_SdtTooltip_Camponome ;
         }

         set {
            gxTv_SdtTooltip_N = 0;
            gxTv_SdtTooltip_Camponome = value;
            SetDirty("Camponome");
         }

      }

      [  SoapElement( ElementName = "TooltipTelaId" )]
      [  XmlElement( ElementName = "TooltipTelaId"   )]
      public int gxTpr_Tooltiptelaid
      {
         get {
            return gxTv_SdtTooltip_Tooltiptelaid ;
         }

         set {
            gxTv_SdtTooltip_N = 0;
            gxTv_SdtTooltip_Tooltiptelaid = value;
            SetDirty("Tooltiptelaid");
         }

      }

      [  SoapElement( ElementName = "TooltipTelaNome" )]
      [  XmlElement( ElementName = "TooltipTelaNome"   )]
      public string gxTpr_Tooltiptelanome
      {
         get {
            return gxTv_SdtTooltip_Tooltiptelanome ;
         }

         set {
            gxTv_SdtTooltip_N = 0;
            gxTv_SdtTooltip_Tooltiptelanome = value;
            SetDirty("Tooltiptelanome");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTooltip_Mode ;
         }

         set {
            gxTv_SdtTooltip_N = 0;
            gxTv_SdtTooltip_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTooltip_Mode_SetNull( )
      {
         gxTv_SdtTooltip_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTooltip_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTooltip_Initialized ;
         }

         set {
            gxTv_SdtTooltip_N = 0;
            gxTv_SdtTooltip_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTooltip_Initialized_SetNull( )
      {
         gxTv_SdtTooltip_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTooltip_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TooltipId_Z" )]
      [  XmlElement( ElementName = "TooltipId_Z"   )]
      public int gxTpr_Tooltipid_Z
      {
         get {
            return gxTv_SdtTooltip_Tooltipid_Z ;
         }

         set {
            gxTv_SdtTooltip_N = 0;
            gxTv_SdtTooltip_Tooltipid_Z = value;
            SetDirty("Tooltipid_Z");
         }

      }

      public void gxTv_SdtTooltip_Tooltipid_Z_SetNull( )
      {
         gxTv_SdtTooltip_Tooltipid_Z = 0;
         SetDirty("Tooltipid_Z");
         return  ;
      }

      public bool gxTv_SdtTooltip_Tooltipid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TooltipAtivo_Z" )]
      [  XmlElement( ElementName = "TooltipAtivo_Z"   )]
      public bool gxTpr_Tooltipativo_Z
      {
         get {
            return gxTv_SdtTooltip_Tooltipativo_Z ;
         }

         set {
            gxTv_SdtTooltip_N = 0;
            gxTv_SdtTooltip_Tooltipativo_Z = value;
            SetDirty("Tooltipativo_Z");
         }

      }

      public void gxTv_SdtTooltip_Tooltipativo_Z_SetNull( )
      {
         gxTv_SdtTooltip_Tooltipativo_Z = false;
         SetDirty("Tooltipativo_Z");
         return  ;
      }

      public bool gxTv_SdtTooltip_Tooltipativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CampoId_Z" )]
      [  XmlElement( ElementName = "CampoId_Z"   )]
      public int gxTpr_Campoid_Z
      {
         get {
            return gxTv_SdtTooltip_Campoid_Z ;
         }

         set {
            gxTv_SdtTooltip_N = 0;
            gxTv_SdtTooltip_Campoid_Z = value;
            SetDirty("Campoid_Z");
         }

      }

      public void gxTv_SdtTooltip_Campoid_Z_SetNull( )
      {
         gxTv_SdtTooltip_Campoid_Z = 0;
         SetDirty("Campoid_Z");
         return  ;
      }

      public bool gxTv_SdtTooltip_Campoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CampoNome_Z" )]
      [  XmlElement( ElementName = "CampoNome_Z"   )]
      public string gxTpr_Camponome_Z
      {
         get {
            return gxTv_SdtTooltip_Camponome_Z ;
         }

         set {
            gxTv_SdtTooltip_N = 0;
            gxTv_SdtTooltip_Camponome_Z = value;
            SetDirty("Camponome_Z");
         }

      }

      public void gxTv_SdtTooltip_Camponome_Z_SetNull( )
      {
         gxTv_SdtTooltip_Camponome_Z = "";
         SetDirty("Camponome_Z");
         return  ;
      }

      public bool gxTv_SdtTooltip_Camponome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TooltipTelaId_Z" )]
      [  XmlElement( ElementName = "TooltipTelaId_Z"   )]
      public int gxTpr_Tooltiptelaid_Z
      {
         get {
            return gxTv_SdtTooltip_Tooltiptelaid_Z ;
         }

         set {
            gxTv_SdtTooltip_N = 0;
            gxTv_SdtTooltip_Tooltiptelaid_Z = value;
            SetDirty("Tooltiptelaid_Z");
         }

      }

      public void gxTv_SdtTooltip_Tooltiptelaid_Z_SetNull( )
      {
         gxTv_SdtTooltip_Tooltiptelaid_Z = 0;
         SetDirty("Tooltiptelaid_Z");
         return  ;
      }

      public bool gxTv_SdtTooltip_Tooltiptelaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TooltipTelaNome_Z" )]
      [  XmlElement( ElementName = "TooltipTelaNome_Z"   )]
      public string gxTpr_Tooltiptelanome_Z
      {
         get {
            return gxTv_SdtTooltip_Tooltiptelanome_Z ;
         }

         set {
            gxTv_SdtTooltip_N = 0;
            gxTv_SdtTooltip_Tooltiptelanome_Z = value;
            SetDirty("Tooltiptelanome_Z");
         }

      }

      public void gxTv_SdtTooltip_Tooltiptelanome_Z_SetNull( )
      {
         gxTv_SdtTooltip_Tooltiptelanome_Z = "";
         SetDirty("Tooltiptelanome_Z");
         return  ;
      }

      public bool gxTv_SdtTooltip_Tooltiptelanome_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtTooltip_N = 1;
         gxTv_SdtTooltip_Tooltipdescricao = "";
         gxTv_SdtTooltip_Camponome = "";
         gxTv_SdtTooltip_Tooltiptelanome = "";
         gxTv_SdtTooltip_Mode = "";
         gxTv_SdtTooltip_Camponome_Z = "";
         gxTv_SdtTooltip_Tooltiptelanome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "tooltip", "GeneXus.Programs.tooltip_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtTooltip_N ;
      }

      private short gxTv_SdtTooltip_N ;
      private short gxTv_SdtTooltip_Initialized ;
      private int gxTv_SdtTooltip_Tooltipid ;
      private int gxTv_SdtTooltip_Campoid ;
      private int gxTv_SdtTooltip_Tooltiptelaid ;
      private int gxTv_SdtTooltip_Tooltipid_Z ;
      private int gxTv_SdtTooltip_Campoid_Z ;
      private int gxTv_SdtTooltip_Tooltiptelaid_Z ;
      private string gxTv_SdtTooltip_Mode ;
      private bool gxTv_SdtTooltip_Tooltipativo ;
      private bool gxTv_SdtTooltip_Tooltipativo_Z ;
      private string gxTv_SdtTooltip_Tooltipdescricao ;
      private string gxTv_SdtTooltip_Camponome ;
      private string gxTv_SdtTooltip_Tooltiptelanome ;
      private string gxTv_SdtTooltip_Camponome_Z ;
      private string gxTv_SdtTooltip_Tooltiptelanome_Z ;
   }

   [DataContract(Name = @"Tooltip", Namespace = "LGPD_Novo")]
   public class SdtTooltip_RESTInterface : GxGenericCollectionItem<SdtTooltip>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTooltip_RESTInterface( ) : base()
      {
      }

      public SdtTooltip_RESTInterface( SdtTooltip psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TooltipId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Tooltipid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Tooltipid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Tooltipid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "TooltipDescricao" , Order = 1 )]
      public string gxTpr_Tooltipdescricao
      {
         get {
            return sdt.gxTpr_Tooltipdescricao ;
         }

         set {
            sdt.gxTpr_Tooltipdescricao = value;
         }

      }

      [DataMember( Name = "TooltipAtivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Tooltipativo
      {
         get {
            return sdt.gxTpr_Tooltipativo ;
         }

         set {
            sdt.gxTpr_Tooltipativo = value;
         }

      }

      [DataMember( Name = "CampoId" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Campoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Campoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Campoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "CampoNome" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Camponome
      {
         get {
            return sdt.gxTpr_Camponome ;
         }

         set {
            sdt.gxTpr_Camponome = value;
         }

      }

      [DataMember( Name = "TooltipTelaId" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Tooltiptelaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Tooltiptelaid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Tooltiptelaid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "TooltipTelaNome" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Tooltiptelanome
      {
         get {
            return sdt.gxTpr_Tooltiptelanome ;
         }

         set {
            sdt.gxTpr_Tooltiptelanome = value;
         }

      }

      public SdtTooltip sdt
      {
         get {
            return (SdtTooltip)Sdt ;
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
            sdt = new SdtTooltip() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 7 )]
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

   [DataContract(Name = @"Tooltip", Namespace = "LGPD_Novo")]
   public class SdtTooltip_RESTLInterface : GxGenericCollectionItem<SdtTooltip>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTooltip_RESTLInterface( ) : base()
      {
      }

      public SdtTooltip_RESTLInterface( SdtTooltip psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TooltipAtivo" , Order = 0 )]
      [GxSeudo()]
      public bool gxTpr_Tooltipativo
      {
         get {
            return sdt.gxTpr_Tooltipativo ;
         }

         set {
            sdt.gxTpr_Tooltipativo = value;
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

      public SdtTooltip sdt
      {
         get {
            return (SdtTooltip)Sdt ;
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
            sdt = new SdtTooltip() ;
         }
      }

   }

}
