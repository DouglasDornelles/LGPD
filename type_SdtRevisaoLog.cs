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
   [XmlRoot(ElementName = "RevisaoLog" )]
   [XmlType(TypeName =  "RevisaoLog" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtRevisaoLog : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtRevisaoLog( )
      {
      }

      public SdtRevisaoLog( IGxContext context )
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

      public void Load( int AV120RevisaoLogId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV120RevisaoLogId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"RevisaoLogId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "RevisaoLog");
         metadata.Set("BT", "RevisaoLog");
         metadata.Set("PK", "[ \"RevisaoLogId\" ]");
         metadata.Set("PKAssigned", "[ \"RevisaoLogId\" ]");
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
         state.Add("gxTpr_Revisaologid_Z");
         state.Add("gxTpr_Revisaologusuarioalteracao_Z");
         state.Add("gxTpr_Revisaologdataalteracao_Z_Nullable");
         state.Add("gxTpr_Documentoid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtRevisaoLog sdt;
         sdt = (SdtRevisaoLog)(source);
         gxTv_SdtRevisaoLog_Revisaologid = sdt.gxTv_SdtRevisaoLog_Revisaologid ;
         gxTv_SdtRevisaoLog_Revisaologusuarioalteracao = sdt.gxTv_SdtRevisaoLog_Revisaologusuarioalteracao ;
         gxTv_SdtRevisaoLog_Revisaologobservacao = sdt.gxTv_SdtRevisaoLog_Revisaologobservacao ;
         gxTv_SdtRevisaoLog_Revisaologdataalteracao = sdt.gxTv_SdtRevisaoLog_Revisaologdataalteracao ;
         gxTv_SdtRevisaoLog_Documentoid = sdt.gxTv_SdtRevisaoLog_Documentoid ;
         gxTv_SdtRevisaoLog_Mode = sdt.gxTv_SdtRevisaoLog_Mode ;
         gxTv_SdtRevisaoLog_Initialized = sdt.gxTv_SdtRevisaoLog_Initialized ;
         gxTv_SdtRevisaoLog_Revisaologid_Z = sdt.gxTv_SdtRevisaoLog_Revisaologid_Z ;
         gxTv_SdtRevisaoLog_Revisaologusuarioalteracao_Z = sdt.gxTv_SdtRevisaoLog_Revisaologusuarioalteracao_Z ;
         gxTv_SdtRevisaoLog_Revisaologdataalteracao_Z = sdt.gxTv_SdtRevisaoLog_Revisaologdataalteracao_Z ;
         gxTv_SdtRevisaoLog_Documentoid_Z = sdt.gxTv_SdtRevisaoLog_Documentoid_Z ;
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
         AddObjectProperty("RevisaoLogId", gxTv_SdtRevisaoLog_Revisaologid, false, includeNonInitialized);
         AddObjectProperty("RevisaoLogUsuarioAlteracao", gxTv_SdtRevisaoLog_Revisaologusuarioalteracao, false, includeNonInitialized);
         AddObjectProperty("RevisaoLogObservacao", gxTv_SdtRevisaoLog_Revisaologobservacao, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtRevisaoLog_Revisaologdataalteracao;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("RevisaoLogDataAlteracao", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocumentoId", gxTv_SdtRevisaoLog_Documentoid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtRevisaoLog_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtRevisaoLog_Initialized, false, includeNonInitialized);
            AddObjectProperty("RevisaoLogId_Z", gxTv_SdtRevisaoLog_Revisaologid_Z, false, includeNonInitialized);
            AddObjectProperty("RevisaoLogUsuarioAlteracao_Z", gxTv_SdtRevisaoLog_Revisaologusuarioalteracao_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtRevisaoLog_Revisaologdataalteracao_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("RevisaoLogDataAlteracao_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("DocumentoId_Z", gxTv_SdtRevisaoLog_Documentoid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtRevisaoLog sdt )
      {
         if ( sdt.IsDirty("RevisaoLogId") )
         {
            gxTv_SdtRevisaoLog_N = 0;
            gxTv_SdtRevisaoLog_Revisaologid = sdt.gxTv_SdtRevisaoLog_Revisaologid ;
         }
         if ( sdt.IsDirty("RevisaoLogUsuarioAlteracao") )
         {
            gxTv_SdtRevisaoLog_N = 0;
            gxTv_SdtRevisaoLog_Revisaologusuarioalteracao = sdt.gxTv_SdtRevisaoLog_Revisaologusuarioalteracao ;
         }
         if ( sdt.IsDirty("RevisaoLogObservacao") )
         {
            gxTv_SdtRevisaoLog_N = 0;
            gxTv_SdtRevisaoLog_Revisaologobservacao = sdt.gxTv_SdtRevisaoLog_Revisaologobservacao ;
         }
         if ( sdt.IsDirty("RevisaoLogDataAlteracao") )
         {
            gxTv_SdtRevisaoLog_N = 0;
            gxTv_SdtRevisaoLog_Revisaologdataalteracao = sdt.gxTv_SdtRevisaoLog_Revisaologdataalteracao ;
         }
         if ( sdt.IsDirty("DocumentoId") )
         {
            gxTv_SdtRevisaoLog_N = 0;
            gxTv_SdtRevisaoLog_Documentoid = sdt.gxTv_SdtRevisaoLog_Documentoid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "RevisaoLogId" )]
      [  XmlElement( ElementName = "RevisaoLogId"   )]
      public int gxTpr_Revisaologid
      {
         get {
            return gxTv_SdtRevisaoLog_Revisaologid ;
         }

         set {
            gxTv_SdtRevisaoLog_N = 0;
            if ( gxTv_SdtRevisaoLog_Revisaologid != value )
            {
               gxTv_SdtRevisaoLog_Mode = "INS";
               this.gxTv_SdtRevisaoLog_Revisaologid_Z_SetNull( );
               this.gxTv_SdtRevisaoLog_Revisaologusuarioalteracao_Z_SetNull( );
               this.gxTv_SdtRevisaoLog_Revisaologdataalteracao_Z_SetNull( );
               this.gxTv_SdtRevisaoLog_Documentoid_Z_SetNull( );
            }
            gxTv_SdtRevisaoLog_Revisaologid = value;
            SetDirty("Revisaologid");
         }

      }

      [  SoapElement( ElementName = "RevisaoLogUsuarioAlteracao" )]
      [  XmlElement( ElementName = "RevisaoLogUsuarioAlteracao"   )]
      public string gxTpr_Revisaologusuarioalteracao
      {
         get {
            return gxTv_SdtRevisaoLog_Revisaologusuarioalteracao ;
         }

         set {
            gxTv_SdtRevisaoLog_N = 0;
            gxTv_SdtRevisaoLog_Revisaologusuarioalteracao = value;
            SetDirty("Revisaologusuarioalteracao");
         }

      }

      [  SoapElement( ElementName = "RevisaoLogObservacao" )]
      [  XmlElement( ElementName = "RevisaoLogObservacao"   )]
      public string gxTpr_Revisaologobservacao
      {
         get {
            return gxTv_SdtRevisaoLog_Revisaologobservacao ;
         }

         set {
            gxTv_SdtRevisaoLog_N = 0;
            gxTv_SdtRevisaoLog_Revisaologobservacao = value;
            SetDirty("Revisaologobservacao");
         }

      }

      [  SoapElement( ElementName = "RevisaoLogDataAlteracao" )]
      [  XmlElement( ElementName = "RevisaoLogDataAlteracao"  , IsNullable=true )]
      public string gxTpr_Revisaologdataalteracao_Nullable
      {
         get {
            if ( gxTv_SdtRevisaoLog_Revisaologdataalteracao == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtRevisaoLog_Revisaologdataalteracao).value ;
         }

         set {
            gxTv_SdtRevisaoLog_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtRevisaoLog_Revisaologdataalteracao = DateTime.MinValue;
            else
               gxTv_SdtRevisaoLog_Revisaologdataalteracao = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Revisaologdataalteracao
      {
         get {
            return gxTv_SdtRevisaoLog_Revisaologdataalteracao ;
         }

         set {
            gxTv_SdtRevisaoLog_N = 0;
            gxTv_SdtRevisaoLog_Revisaologdataalteracao = value;
            SetDirty("Revisaologdataalteracao");
         }

      }

      [  SoapElement( ElementName = "DocumentoId" )]
      [  XmlElement( ElementName = "DocumentoId"   )]
      public int gxTpr_Documentoid
      {
         get {
            return gxTv_SdtRevisaoLog_Documentoid ;
         }

         set {
            gxTv_SdtRevisaoLog_N = 0;
            gxTv_SdtRevisaoLog_Documentoid = value;
            SetDirty("Documentoid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtRevisaoLog_Mode ;
         }

         set {
            gxTv_SdtRevisaoLog_N = 0;
            gxTv_SdtRevisaoLog_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtRevisaoLog_Mode_SetNull( )
      {
         gxTv_SdtRevisaoLog_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtRevisaoLog_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtRevisaoLog_Initialized ;
         }

         set {
            gxTv_SdtRevisaoLog_N = 0;
            gxTv_SdtRevisaoLog_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtRevisaoLog_Initialized_SetNull( )
      {
         gxTv_SdtRevisaoLog_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtRevisaoLog_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RevisaoLogId_Z" )]
      [  XmlElement( ElementName = "RevisaoLogId_Z"   )]
      public int gxTpr_Revisaologid_Z
      {
         get {
            return gxTv_SdtRevisaoLog_Revisaologid_Z ;
         }

         set {
            gxTv_SdtRevisaoLog_N = 0;
            gxTv_SdtRevisaoLog_Revisaologid_Z = value;
            SetDirty("Revisaologid_Z");
         }

      }

      public void gxTv_SdtRevisaoLog_Revisaologid_Z_SetNull( )
      {
         gxTv_SdtRevisaoLog_Revisaologid_Z = 0;
         SetDirty("Revisaologid_Z");
         return  ;
      }

      public bool gxTv_SdtRevisaoLog_Revisaologid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RevisaoLogUsuarioAlteracao_Z" )]
      [  XmlElement( ElementName = "RevisaoLogUsuarioAlteracao_Z"   )]
      public string gxTpr_Revisaologusuarioalteracao_Z
      {
         get {
            return gxTv_SdtRevisaoLog_Revisaologusuarioalteracao_Z ;
         }

         set {
            gxTv_SdtRevisaoLog_N = 0;
            gxTv_SdtRevisaoLog_Revisaologusuarioalteracao_Z = value;
            SetDirty("Revisaologusuarioalteracao_Z");
         }

      }

      public void gxTv_SdtRevisaoLog_Revisaologusuarioalteracao_Z_SetNull( )
      {
         gxTv_SdtRevisaoLog_Revisaologusuarioalteracao_Z = "";
         SetDirty("Revisaologusuarioalteracao_Z");
         return  ;
      }

      public bool gxTv_SdtRevisaoLog_Revisaologusuarioalteracao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RevisaoLogDataAlteracao_Z" )]
      [  XmlElement( ElementName = "RevisaoLogDataAlteracao_Z"  , IsNullable=true )]
      public string gxTpr_Revisaologdataalteracao_Z_Nullable
      {
         get {
            if ( gxTv_SdtRevisaoLog_Revisaologdataalteracao_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtRevisaoLog_Revisaologdataalteracao_Z).value ;
         }

         set {
            gxTv_SdtRevisaoLog_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtRevisaoLog_Revisaologdataalteracao_Z = DateTime.MinValue;
            else
               gxTv_SdtRevisaoLog_Revisaologdataalteracao_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Revisaologdataalteracao_Z
      {
         get {
            return gxTv_SdtRevisaoLog_Revisaologdataalteracao_Z ;
         }

         set {
            gxTv_SdtRevisaoLog_N = 0;
            gxTv_SdtRevisaoLog_Revisaologdataalteracao_Z = value;
            SetDirty("Revisaologdataalteracao_Z");
         }

      }

      public void gxTv_SdtRevisaoLog_Revisaologdataalteracao_Z_SetNull( )
      {
         gxTv_SdtRevisaoLog_Revisaologdataalteracao_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Revisaologdataalteracao_Z");
         return  ;
      }

      public bool gxTv_SdtRevisaoLog_Revisaologdataalteracao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoId_Z" )]
      [  XmlElement( ElementName = "DocumentoId_Z"   )]
      public int gxTpr_Documentoid_Z
      {
         get {
            return gxTv_SdtRevisaoLog_Documentoid_Z ;
         }

         set {
            gxTv_SdtRevisaoLog_N = 0;
            gxTv_SdtRevisaoLog_Documentoid_Z = value;
            SetDirty("Documentoid_Z");
         }

      }

      public void gxTv_SdtRevisaoLog_Documentoid_Z_SetNull( )
      {
         gxTv_SdtRevisaoLog_Documentoid_Z = 0;
         SetDirty("Documentoid_Z");
         return  ;
      }

      public bool gxTv_SdtRevisaoLog_Documentoid_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtRevisaoLog_N = 1;
         gxTv_SdtRevisaoLog_Revisaologusuarioalteracao = "";
         gxTv_SdtRevisaoLog_Revisaologobservacao = "";
         gxTv_SdtRevisaoLog_Revisaologdataalteracao = (DateTime)(DateTime.MinValue);
         gxTv_SdtRevisaoLog_Mode = "";
         gxTv_SdtRevisaoLog_Revisaologusuarioalteracao_Z = "";
         gxTv_SdtRevisaoLog_Revisaologdataalteracao_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "revisaolog", "GeneXus.Programs.revisaolog_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtRevisaoLog_N ;
      }

      private short gxTv_SdtRevisaoLog_N ;
      private short gxTv_SdtRevisaoLog_Initialized ;
      private int gxTv_SdtRevisaoLog_Revisaologid ;
      private int gxTv_SdtRevisaoLog_Documentoid ;
      private int gxTv_SdtRevisaoLog_Revisaologid_Z ;
      private int gxTv_SdtRevisaoLog_Documentoid_Z ;
      private string gxTv_SdtRevisaoLog_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtRevisaoLog_Revisaologdataalteracao ;
      private DateTime gxTv_SdtRevisaoLog_Revisaologdataalteracao_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtRevisaoLog_Revisaologobservacao ;
      private string gxTv_SdtRevisaoLog_Revisaologusuarioalteracao ;
      private string gxTv_SdtRevisaoLog_Revisaologusuarioalteracao_Z ;
   }

   [DataContract(Name = @"RevisaoLog", Namespace = "LGPD_Novo")]
   public class SdtRevisaoLog_RESTInterface : GxGenericCollectionItem<SdtRevisaoLog>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtRevisaoLog_RESTInterface( ) : base()
      {
      }

      public SdtRevisaoLog_RESTInterface( SdtRevisaoLog psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "RevisaoLogId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Revisaologid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Revisaologid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Revisaologid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "RevisaoLogUsuarioAlteracao" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Revisaologusuarioalteracao
      {
         get {
            return sdt.gxTpr_Revisaologusuarioalteracao ;
         }

         set {
            sdt.gxTpr_Revisaologusuarioalteracao = value;
         }

      }

      [DataMember( Name = "RevisaoLogObservacao" , Order = 2 )]
      public string gxTpr_Revisaologobservacao
      {
         get {
            return sdt.gxTpr_Revisaologobservacao ;
         }

         set {
            sdt.gxTpr_Revisaologobservacao = value;
         }

      }

      [DataMember( Name = "RevisaoLogDataAlteracao" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Revisaologdataalteracao
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Revisaologdataalteracao) ;
         }

         set {
            sdt.gxTpr_Revisaologdataalteracao = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "DocumentoId" , Order = 4 )]
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

      public SdtRevisaoLog sdt
      {
         get {
            return (SdtRevisaoLog)Sdt ;
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
            sdt = new SdtRevisaoLog() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 5 )]
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

   [DataContract(Name = @"RevisaoLog", Namespace = "LGPD_Novo")]
   public class SdtRevisaoLog_RESTLInterface : GxGenericCollectionItem<SdtRevisaoLog>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtRevisaoLog_RESTLInterface( ) : base()
      {
      }

      public SdtRevisaoLog_RESTLInterface( SdtRevisaoLog psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "RevisaoLogUsuarioAlteracao" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Revisaologusuarioalteracao
      {
         get {
            return sdt.gxTpr_Revisaologusuarioalteracao ;
         }

         set {
            sdt.gxTpr_Revisaologusuarioalteracao = value;
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

      public SdtRevisaoLog sdt
      {
         get {
            return (SdtRevisaoLog)Sdt ;
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
            sdt = new SdtRevisaoLog() ;
         }
      }

   }

}
