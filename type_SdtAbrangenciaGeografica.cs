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
   [XmlRoot(ElementName = "AbrangenciaGeografica" )]
   [XmlType(TypeName =  "AbrangenciaGeografica" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtAbrangenciaGeografica : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtAbrangenciaGeografica( )
      {
      }

      public SdtAbrangenciaGeografica( IGxContext context )
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

      public void Load( int AV36AbrangenciaGeograficaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV36AbrangenciaGeograficaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"AbrangenciaGeograficaId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "AbrangenciaGeografica");
         metadata.Set("BT", "AbrangenciaGeografica");
         metadata.Set("PK", "[ \"AbrangenciaGeograficaId\" ]");
         metadata.Set("PKAssigned", "[ \"AbrangenciaGeograficaId\" ]");
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
         state.Add("gxTpr_Abrangenciageograficaid_Z");
         state.Add("gxTpr_Abrangenciageograficanome_Z");
         state.Add("gxTpr_Abrangenciageograficaativo_Z");
         state.Add("gxTpr_Abrangenciageograficaid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtAbrangenciaGeografica sdt;
         sdt = (SdtAbrangenciaGeografica)(source);
         gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid = sdt.gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid ;
         gxTv_SdtAbrangenciaGeografica_Abrangenciageograficanome = sdt.gxTv_SdtAbrangenciaGeografica_Abrangenciageograficanome ;
         gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaativo = sdt.gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaativo ;
         gxTv_SdtAbrangenciaGeografica_Mode = sdt.gxTv_SdtAbrangenciaGeografica_Mode ;
         gxTv_SdtAbrangenciaGeografica_Initialized = sdt.gxTv_SdtAbrangenciaGeografica_Initialized ;
         gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid_Z = sdt.gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid_Z ;
         gxTv_SdtAbrangenciaGeografica_Abrangenciageograficanome_Z = sdt.gxTv_SdtAbrangenciaGeografica_Abrangenciageograficanome_Z ;
         gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaativo_Z = sdt.gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaativo_Z ;
         gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid_N = sdt.gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid_N ;
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
         AddObjectProperty("AbrangenciaGeograficaId", gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid, false, includeNonInitialized);
         AddObjectProperty("AbrangenciaGeograficaId_N", gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid_N, false, includeNonInitialized);
         AddObjectProperty("AbrangenciaGeograficaNome", gxTv_SdtAbrangenciaGeografica_Abrangenciageograficanome, false, includeNonInitialized);
         AddObjectProperty("AbrangenciaGeograficaAtivo", gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtAbrangenciaGeografica_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtAbrangenciaGeografica_Initialized, false, includeNonInitialized);
            AddObjectProperty("AbrangenciaGeograficaId_Z", gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid_Z, false, includeNonInitialized);
            AddObjectProperty("AbrangenciaGeograficaNome_Z", gxTv_SdtAbrangenciaGeografica_Abrangenciageograficanome_Z, false, includeNonInitialized);
            AddObjectProperty("AbrangenciaGeograficaAtivo_Z", gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaativo_Z, false, includeNonInitialized);
            AddObjectProperty("AbrangenciaGeograficaId_N", gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtAbrangenciaGeografica sdt )
      {
         if ( sdt.IsDirty("AbrangenciaGeograficaId") )
         {
            gxTv_SdtAbrangenciaGeografica_N = 0;
            gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid = sdt.gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid ;
         }
         if ( sdt.IsDirty("AbrangenciaGeograficaNome") )
         {
            gxTv_SdtAbrangenciaGeografica_N = 0;
            gxTv_SdtAbrangenciaGeografica_Abrangenciageograficanome = sdt.gxTv_SdtAbrangenciaGeografica_Abrangenciageograficanome ;
         }
         if ( sdt.IsDirty("AbrangenciaGeograficaAtivo") )
         {
            gxTv_SdtAbrangenciaGeografica_N = 0;
            gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaativo = sdt.gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "AbrangenciaGeograficaId" )]
      [  XmlElement( ElementName = "AbrangenciaGeograficaId"   )]
      public int gxTpr_Abrangenciageograficaid
      {
         get {
            return gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid ;
         }

         set {
            gxTv_SdtAbrangenciaGeografica_N = 0;
            if ( gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid != value )
            {
               gxTv_SdtAbrangenciaGeografica_Mode = "INS";
               this.gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid_Z_SetNull( );
               this.gxTv_SdtAbrangenciaGeografica_Abrangenciageograficanome_Z_SetNull( );
               this.gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaativo_Z_SetNull( );
            }
            gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid = value;
            SetDirty("Abrangenciageograficaid");
         }

      }

      [  SoapElement( ElementName = "AbrangenciaGeograficaNome" )]
      [  XmlElement( ElementName = "AbrangenciaGeograficaNome"   )]
      public string gxTpr_Abrangenciageograficanome
      {
         get {
            return gxTv_SdtAbrangenciaGeografica_Abrangenciageograficanome ;
         }

         set {
            gxTv_SdtAbrangenciaGeografica_N = 0;
            gxTv_SdtAbrangenciaGeografica_Abrangenciageograficanome = value;
            SetDirty("Abrangenciageograficanome");
         }

      }

      [  SoapElement( ElementName = "AbrangenciaGeograficaAtivo" )]
      [  XmlElement( ElementName = "AbrangenciaGeograficaAtivo"   )]
      public bool gxTpr_Abrangenciageograficaativo
      {
         get {
            return gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaativo ;
         }

         set {
            gxTv_SdtAbrangenciaGeografica_N = 0;
            gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaativo = value;
            SetDirty("Abrangenciageograficaativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtAbrangenciaGeografica_Mode ;
         }

         set {
            gxTv_SdtAbrangenciaGeografica_N = 0;
            gxTv_SdtAbrangenciaGeografica_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtAbrangenciaGeografica_Mode_SetNull( )
      {
         gxTv_SdtAbrangenciaGeografica_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtAbrangenciaGeografica_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtAbrangenciaGeografica_Initialized ;
         }

         set {
            gxTv_SdtAbrangenciaGeografica_N = 0;
            gxTv_SdtAbrangenciaGeografica_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtAbrangenciaGeografica_Initialized_SetNull( )
      {
         gxTv_SdtAbrangenciaGeografica_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtAbrangenciaGeografica_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AbrangenciaGeograficaId_Z" )]
      [  XmlElement( ElementName = "AbrangenciaGeograficaId_Z"   )]
      public int gxTpr_Abrangenciageograficaid_Z
      {
         get {
            return gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid_Z ;
         }

         set {
            gxTv_SdtAbrangenciaGeografica_N = 0;
            gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid_Z = value;
            SetDirty("Abrangenciageograficaid_Z");
         }

      }

      public void gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid_Z_SetNull( )
      {
         gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid_Z = 0;
         SetDirty("Abrangenciageograficaid_Z");
         return  ;
      }

      public bool gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AbrangenciaGeograficaNome_Z" )]
      [  XmlElement( ElementName = "AbrangenciaGeograficaNome_Z"   )]
      public string gxTpr_Abrangenciageograficanome_Z
      {
         get {
            return gxTv_SdtAbrangenciaGeografica_Abrangenciageograficanome_Z ;
         }

         set {
            gxTv_SdtAbrangenciaGeografica_N = 0;
            gxTv_SdtAbrangenciaGeografica_Abrangenciageograficanome_Z = value;
            SetDirty("Abrangenciageograficanome_Z");
         }

      }

      public void gxTv_SdtAbrangenciaGeografica_Abrangenciageograficanome_Z_SetNull( )
      {
         gxTv_SdtAbrangenciaGeografica_Abrangenciageograficanome_Z = "";
         SetDirty("Abrangenciageograficanome_Z");
         return  ;
      }

      public bool gxTv_SdtAbrangenciaGeografica_Abrangenciageograficanome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AbrangenciaGeograficaAtivo_Z" )]
      [  XmlElement( ElementName = "AbrangenciaGeograficaAtivo_Z"   )]
      public bool gxTpr_Abrangenciageograficaativo_Z
      {
         get {
            return gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaativo_Z ;
         }

         set {
            gxTv_SdtAbrangenciaGeografica_N = 0;
            gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaativo_Z = value;
            SetDirty("Abrangenciageograficaativo_Z");
         }

      }

      public void gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaativo_Z_SetNull( )
      {
         gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaativo_Z = false;
         SetDirty("Abrangenciageograficaativo_Z");
         return  ;
      }

      public bool gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AbrangenciaGeograficaId_N" )]
      [  XmlElement( ElementName = "AbrangenciaGeograficaId_N"   )]
      public short gxTpr_Abrangenciageograficaid_N
      {
         get {
            return gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid_N ;
         }

         set {
            gxTv_SdtAbrangenciaGeografica_N = 0;
            gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid_N = value;
            SetDirty("Abrangenciageograficaid_N");
         }

      }

      public void gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid_N_SetNull( )
      {
         gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid_N = 0;
         SetDirty("Abrangenciageograficaid_N");
         return  ;
      }

      public bool gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtAbrangenciaGeografica_N = 1;
         gxTv_SdtAbrangenciaGeografica_Abrangenciageograficanome = "";
         gxTv_SdtAbrangenciaGeografica_Mode = "";
         gxTv_SdtAbrangenciaGeografica_Abrangenciageograficanome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "abrangenciageografica", "GeneXus.Programs.abrangenciageografica_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtAbrangenciaGeografica_N ;
      }

      private short gxTv_SdtAbrangenciaGeografica_N ;
      private short gxTv_SdtAbrangenciaGeografica_Initialized ;
      private short gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid_N ;
      private int gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid ;
      private int gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaid_Z ;
      private string gxTv_SdtAbrangenciaGeografica_Mode ;
      private bool gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaativo ;
      private bool gxTv_SdtAbrangenciaGeografica_Abrangenciageograficaativo_Z ;
      private string gxTv_SdtAbrangenciaGeografica_Abrangenciageograficanome ;
      private string gxTv_SdtAbrangenciaGeografica_Abrangenciageograficanome_Z ;
   }

   [DataContract(Name = @"AbrangenciaGeografica", Namespace = "LGPD_Novo")]
   public class SdtAbrangenciaGeografica_RESTInterface : GxGenericCollectionItem<SdtAbrangenciaGeografica>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtAbrangenciaGeografica_RESTInterface( ) : base()
      {
      }

      public SdtAbrangenciaGeografica_RESTInterface( SdtAbrangenciaGeografica psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AbrangenciaGeograficaId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Abrangenciageograficaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Abrangenciageograficaid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Abrangenciageograficaid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "AbrangenciaGeograficaNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Abrangenciageograficanome
      {
         get {
            return sdt.gxTpr_Abrangenciageograficanome ;
         }

         set {
            sdt.gxTpr_Abrangenciageograficanome = value;
         }

      }

      [DataMember( Name = "AbrangenciaGeograficaAtivo" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Abrangenciageograficaativo
      {
         get {
            return sdt.gxTpr_Abrangenciageograficaativo ;
         }

         set {
            sdt.gxTpr_Abrangenciageograficaativo = value;
         }

      }

      public SdtAbrangenciaGeografica sdt
      {
         get {
            return (SdtAbrangenciaGeografica)Sdt ;
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
            sdt = new SdtAbrangenciaGeografica() ;
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

   [DataContract(Name = @"AbrangenciaGeografica", Namespace = "LGPD_Novo")]
   public class SdtAbrangenciaGeografica_RESTLInterface : GxGenericCollectionItem<SdtAbrangenciaGeografica>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtAbrangenciaGeografica_RESTLInterface( ) : base()
      {
      }

      public SdtAbrangenciaGeografica_RESTLInterface( SdtAbrangenciaGeografica psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AbrangenciaGeograficaNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Abrangenciageograficanome
      {
         get {
            return sdt.gxTpr_Abrangenciageograficanome ;
         }

         set {
            sdt.gxTpr_Abrangenciageograficanome = value;
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

      public SdtAbrangenciaGeografica sdt
      {
         get {
            return (SdtAbrangenciaGeografica)Sdt ;
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
            sdt = new SdtAbrangenciaGeografica() ;
         }
      }

   }

}
