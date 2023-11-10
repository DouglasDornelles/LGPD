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
   [XmlRoot(ElementName = "DicionarioCompartTercExt" )]
   [XmlType(TypeName =  "DicionarioCompartTercExt" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtDicionarioCompartTercExt : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDicionarioCompartTercExt( )
      {
      }

      public SdtDicionarioCompartTercExt( IGxContext context )
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

      public void Load( int AV66CompartTercExternoId ,
                        int AV98DocDicionarioId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV66CompartTercExternoId,(int)AV98DocDicionarioId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CompartTercExternoId", typeof(int)}, new Object[]{"DocDicionarioId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "DicionarioCompartTercExt");
         metadata.Set("BT", "DicionarioCompartTercExt");
         metadata.Set("PK", "[ \"CompartTercExternoId\",\"DocDicionarioId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CompartTercExternoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"DocDicionarioId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Comparttercexternoid_Z");
         state.Add("gxTpr_Docdicionarioid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtDicionarioCompartTercExt sdt;
         sdt = (SdtDicionarioCompartTercExt)(source);
         gxTv_SdtDicionarioCompartTercExt_Comparttercexternoid = sdt.gxTv_SdtDicionarioCompartTercExt_Comparttercexternoid ;
         gxTv_SdtDicionarioCompartTercExt_Docdicionarioid = sdt.gxTv_SdtDicionarioCompartTercExt_Docdicionarioid ;
         gxTv_SdtDicionarioCompartTercExt_Mode = sdt.gxTv_SdtDicionarioCompartTercExt_Mode ;
         gxTv_SdtDicionarioCompartTercExt_Initialized = sdt.gxTv_SdtDicionarioCompartTercExt_Initialized ;
         gxTv_SdtDicionarioCompartTercExt_Comparttercexternoid_Z = sdt.gxTv_SdtDicionarioCompartTercExt_Comparttercexternoid_Z ;
         gxTv_SdtDicionarioCompartTercExt_Docdicionarioid_Z = sdt.gxTv_SdtDicionarioCompartTercExt_Docdicionarioid_Z ;
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
         AddObjectProperty("CompartTercExternoId", gxTv_SdtDicionarioCompartTercExt_Comparttercexternoid, false, includeNonInitialized);
         AddObjectProperty("DocDicionarioId", gxTv_SdtDicionarioCompartTercExt_Docdicionarioid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtDicionarioCompartTercExt_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtDicionarioCompartTercExt_Initialized, false, includeNonInitialized);
            AddObjectProperty("CompartTercExternoId_Z", gxTv_SdtDicionarioCompartTercExt_Comparttercexternoid_Z, false, includeNonInitialized);
            AddObjectProperty("DocDicionarioId_Z", gxTv_SdtDicionarioCompartTercExt_Docdicionarioid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtDicionarioCompartTercExt sdt )
      {
         if ( sdt.IsDirty("CompartTercExternoId") )
         {
            gxTv_SdtDicionarioCompartTercExt_N = 0;
            gxTv_SdtDicionarioCompartTercExt_Comparttercexternoid = sdt.gxTv_SdtDicionarioCompartTercExt_Comparttercexternoid ;
         }
         if ( sdt.IsDirty("DocDicionarioId") )
         {
            gxTv_SdtDicionarioCompartTercExt_N = 0;
            gxTv_SdtDicionarioCompartTercExt_Docdicionarioid = sdt.gxTv_SdtDicionarioCompartTercExt_Docdicionarioid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CompartTercExternoId" )]
      [  XmlElement( ElementName = "CompartTercExternoId"   )]
      public int gxTpr_Comparttercexternoid
      {
         get {
            return gxTv_SdtDicionarioCompartTercExt_Comparttercexternoid ;
         }

         set {
            gxTv_SdtDicionarioCompartTercExt_N = 0;
            if ( gxTv_SdtDicionarioCompartTercExt_Comparttercexternoid != value )
            {
               gxTv_SdtDicionarioCompartTercExt_Mode = "INS";
               this.gxTv_SdtDicionarioCompartTercExt_Comparttercexternoid_Z_SetNull( );
               this.gxTv_SdtDicionarioCompartTercExt_Docdicionarioid_Z_SetNull( );
            }
            gxTv_SdtDicionarioCompartTercExt_Comparttercexternoid = value;
            SetDirty("Comparttercexternoid");
         }

      }

      [  SoapElement( ElementName = "DocDicionarioId" )]
      [  XmlElement( ElementName = "DocDicionarioId"   )]
      public int gxTpr_Docdicionarioid
      {
         get {
            return gxTv_SdtDicionarioCompartTercExt_Docdicionarioid ;
         }

         set {
            gxTv_SdtDicionarioCompartTercExt_N = 0;
            if ( gxTv_SdtDicionarioCompartTercExt_Docdicionarioid != value )
            {
               gxTv_SdtDicionarioCompartTercExt_Mode = "INS";
               this.gxTv_SdtDicionarioCompartTercExt_Comparttercexternoid_Z_SetNull( );
               this.gxTv_SdtDicionarioCompartTercExt_Docdicionarioid_Z_SetNull( );
            }
            gxTv_SdtDicionarioCompartTercExt_Docdicionarioid = value;
            SetDirty("Docdicionarioid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtDicionarioCompartTercExt_Mode ;
         }

         set {
            gxTv_SdtDicionarioCompartTercExt_N = 0;
            gxTv_SdtDicionarioCompartTercExt_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtDicionarioCompartTercExt_Mode_SetNull( )
      {
         gxTv_SdtDicionarioCompartTercExt_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtDicionarioCompartTercExt_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtDicionarioCompartTercExt_Initialized ;
         }

         set {
            gxTv_SdtDicionarioCompartTercExt_N = 0;
            gxTv_SdtDicionarioCompartTercExt_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtDicionarioCompartTercExt_Initialized_SetNull( )
      {
         gxTv_SdtDicionarioCompartTercExt_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtDicionarioCompartTercExt_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CompartTercExternoId_Z" )]
      [  XmlElement( ElementName = "CompartTercExternoId_Z"   )]
      public int gxTpr_Comparttercexternoid_Z
      {
         get {
            return gxTv_SdtDicionarioCompartTercExt_Comparttercexternoid_Z ;
         }

         set {
            gxTv_SdtDicionarioCompartTercExt_N = 0;
            gxTv_SdtDicionarioCompartTercExt_Comparttercexternoid_Z = value;
            SetDirty("Comparttercexternoid_Z");
         }

      }

      public void gxTv_SdtDicionarioCompartTercExt_Comparttercexternoid_Z_SetNull( )
      {
         gxTv_SdtDicionarioCompartTercExt_Comparttercexternoid_Z = 0;
         SetDirty("Comparttercexternoid_Z");
         return  ;
      }

      public bool gxTv_SdtDicionarioCompartTercExt_Comparttercexternoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDicionarioId_Z" )]
      [  XmlElement( ElementName = "DocDicionarioId_Z"   )]
      public int gxTpr_Docdicionarioid_Z
      {
         get {
            return gxTv_SdtDicionarioCompartTercExt_Docdicionarioid_Z ;
         }

         set {
            gxTv_SdtDicionarioCompartTercExt_N = 0;
            gxTv_SdtDicionarioCompartTercExt_Docdicionarioid_Z = value;
            SetDirty("Docdicionarioid_Z");
         }

      }

      public void gxTv_SdtDicionarioCompartTercExt_Docdicionarioid_Z_SetNull( )
      {
         gxTv_SdtDicionarioCompartTercExt_Docdicionarioid_Z = 0;
         SetDirty("Docdicionarioid_Z");
         return  ;
      }

      public bool gxTv_SdtDicionarioCompartTercExt_Docdicionarioid_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtDicionarioCompartTercExt_N = 1;
         gxTv_SdtDicionarioCompartTercExt_Mode = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "dicionariocomparttercext", "GeneXus.Programs.dicionariocomparttercext_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtDicionarioCompartTercExt_N ;
      }

      private short gxTv_SdtDicionarioCompartTercExt_N ;
      private short gxTv_SdtDicionarioCompartTercExt_Initialized ;
      private int gxTv_SdtDicionarioCompartTercExt_Comparttercexternoid ;
      private int gxTv_SdtDicionarioCompartTercExt_Docdicionarioid ;
      private int gxTv_SdtDicionarioCompartTercExt_Comparttercexternoid_Z ;
      private int gxTv_SdtDicionarioCompartTercExt_Docdicionarioid_Z ;
      private string gxTv_SdtDicionarioCompartTercExt_Mode ;
   }

   [DataContract(Name = @"DicionarioCompartTercExt", Namespace = "LGPD_Novo")]
   public class SdtDicionarioCompartTercExt_RESTInterface : GxGenericCollectionItem<SdtDicionarioCompartTercExt>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDicionarioCompartTercExt_RESTInterface( ) : base()
      {
      }

      public SdtDicionarioCompartTercExt_RESTInterface( SdtDicionarioCompartTercExt psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CompartTercExternoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Comparttercexternoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Comparttercexternoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Comparttercexternoid = (int)(NumberUtil.Val( value, "."));
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

      public SdtDicionarioCompartTercExt sdt
      {
         get {
            return (SdtDicionarioCompartTercExt)Sdt ;
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
            sdt = new SdtDicionarioCompartTercExt() ;
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

   [DataContract(Name = @"DicionarioCompartTercExt", Namespace = "LGPD_Novo")]
   public class SdtDicionarioCompartTercExt_RESTLInterface : GxGenericCollectionItem<SdtDicionarioCompartTercExt>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDicionarioCompartTercExt_RESTLInterface( ) : base()
      {
      }

      public SdtDicionarioCompartTercExt_RESTLInterface( SdtDicionarioCompartTercExt psdt ) : base(psdt)
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

      public SdtDicionarioCompartTercExt sdt
      {
         get {
            return (SdtDicionarioCompartTercExt)Sdt ;
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
            sdt = new SdtDicionarioCompartTercExt() ;
         }
      }

   }

}
