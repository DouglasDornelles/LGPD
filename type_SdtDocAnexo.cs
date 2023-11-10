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
   [XmlRoot(ElementName = "DocAnexo" )]
   [XmlType(TypeName =  "DocAnexo" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtDocAnexo : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocAnexo( )
      {
      }

      public SdtDocAnexo( IGxContext context )
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

      public void Load( int AV93DocAnexoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV93DocAnexoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"DocAnexoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "DocAnexo");
         metadata.Set("BT", "DocAnexo");
         metadata.Set("PK", "[ \"DocAnexoId\" ]");
         metadata.Set("PKAssigned", "[ \"DocAnexoId\" ]");
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
         state.Add("gxTpr_Docanexoid_Z");
         state.Add("gxTpr_Documentoid_Z");
         state.Add("gxTpr_Docanexodescricao_Z");
         state.Add("gxTpr_Docanexoarquivo_Z");
         state.Add("gxTpr_Docanexodatainclusao_Z_Nullable");
         state.Add("gxTpr_Documentonome_Z");
         state.Add("gxTpr_Documentonome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtDocAnexo sdt;
         sdt = (SdtDocAnexo)(source);
         gxTv_SdtDocAnexo_Docanexoid = sdt.gxTv_SdtDocAnexo_Docanexoid ;
         gxTv_SdtDocAnexo_Documentoid = sdt.gxTv_SdtDocAnexo_Documentoid ;
         gxTv_SdtDocAnexo_Docanexodescricao = sdt.gxTv_SdtDocAnexo_Docanexodescricao ;
         gxTv_SdtDocAnexo_Docanexoarquivo = sdt.gxTv_SdtDocAnexo_Docanexoarquivo ;
         gxTv_SdtDocAnexo_Docanexodatainclusao = sdt.gxTv_SdtDocAnexo_Docanexodatainclusao ;
         gxTv_SdtDocAnexo_Documentonome = sdt.gxTv_SdtDocAnexo_Documentonome ;
         gxTv_SdtDocAnexo_Mode = sdt.gxTv_SdtDocAnexo_Mode ;
         gxTv_SdtDocAnexo_Initialized = sdt.gxTv_SdtDocAnexo_Initialized ;
         gxTv_SdtDocAnexo_Docanexoid_Z = sdt.gxTv_SdtDocAnexo_Docanexoid_Z ;
         gxTv_SdtDocAnexo_Documentoid_Z = sdt.gxTv_SdtDocAnexo_Documentoid_Z ;
         gxTv_SdtDocAnexo_Docanexodescricao_Z = sdt.gxTv_SdtDocAnexo_Docanexodescricao_Z ;
         gxTv_SdtDocAnexo_Docanexoarquivo_Z = sdt.gxTv_SdtDocAnexo_Docanexoarquivo_Z ;
         gxTv_SdtDocAnexo_Docanexodatainclusao_Z = sdt.gxTv_SdtDocAnexo_Docanexodatainclusao_Z ;
         gxTv_SdtDocAnexo_Documentonome_Z = sdt.gxTv_SdtDocAnexo_Documentonome_Z ;
         gxTv_SdtDocAnexo_Documentonome_N = sdt.gxTv_SdtDocAnexo_Documentonome_N ;
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
         AddObjectProperty("DocAnexoId", gxTv_SdtDocAnexo_Docanexoid, false, includeNonInitialized);
         AddObjectProperty("DocumentoId", gxTv_SdtDocAnexo_Documentoid, false, includeNonInitialized);
         AddObjectProperty("DocAnexoDescricao", gxTv_SdtDocAnexo_Docanexodescricao, false, includeNonInitialized);
         AddObjectProperty("DocAnexoArquivo", gxTv_SdtDocAnexo_Docanexoarquivo, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocAnexo_Docanexodatainclusao)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocAnexo_Docanexodatainclusao)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocAnexo_Docanexodatainclusao)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("DocAnexoDataInclusao", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("DocumentoNome", gxTv_SdtDocAnexo_Documentonome, false, includeNonInitialized);
         AddObjectProperty("DocumentoNome_N", gxTv_SdtDocAnexo_Documentonome_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtDocAnexo_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtDocAnexo_Initialized, false, includeNonInitialized);
            AddObjectProperty("DocAnexoId_Z", gxTv_SdtDocAnexo_Docanexoid_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoId_Z", gxTv_SdtDocAnexo_Documentoid_Z, false, includeNonInitialized);
            AddObjectProperty("DocAnexoDescricao_Z", gxTv_SdtDocAnexo_Docanexodescricao_Z, false, includeNonInitialized);
            AddObjectProperty("DocAnexoArquivo_Z", gxTv_SdtDocAnexo_Docanexoarquivo_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocAnexo_Docanexodatainclusao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocAnexo_Docanexodatainclusao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocAnexo_Docanexodatainclusao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("DocAnexoDataInclusao_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("DocumentoNome_Z", gxTv_SdtDocAnexo_Documentonome_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoNome_N", gxTv_SdtDocAnexo_Documentonome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtDocAnexo sdt )
      {
         if ( sdt.IsDirty("DocAnexoId") )
         {
            gxTv_SdtDocAnexo_N = 0;
            gxTv_SdtDocAnexo_Docanexoid = sdt.gxTv_SdtDocAnexo_Docanexoid ;
         }
         if ( sdt.IsDirty("DocumentoId") )
         {
            gxTv_SdtDocAnexo_N = 0;
            gxTv_SdtDocAnexo_Documentoid = sdt.gxTv_SdtDocAnexo_Documentoid ;
         }
         if ( sdt.IsDirty("DocAnexoDescricao") )
         {
            gxTv_SdtDocAnexo_N = 0;
            gxTv_SdtDocAnexo_Docanexodescricao = sdt.gxTv_SdtDocAnexo_Docanexodescricao ;
         }
         if ( sdt.IsDirty("DocAnexoArquivo") )
         {
            gxTv_SdtDocAnexo_N = 0;
            gxTv_SdtDocAnexo_Docanexoarquivo = sdt.gxTv_SdtDocAnexo_Docanexoarquivo ;
         }
         if ( sdt.IsDirty("DocAnexoDataInclusao") )
         {
            gxTv_SdtDocAnexo_N = 0;
            gxTv_SdtDocAnexo_Docanexodatainclusao = sdt.gxTv_SdtDocAnexo_Docanexodatainclusao ;
         }
         if ( sdt.IsDirty("DocumentoNome") )
         {
            gxTv_SdtDocAnexo_Documentonome_N = (short)(sdt.gxTv_SdtDocAnexo_Documentonome_N);
            gxTv_SdtDocAnexo_N = 0;
            gxTv_SdtDocAnexo_Documentonome = sdt.gxTv_SdtDocAnexo_Documentonome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "DocAnexoId" )]
      [  XmlElement( ElementName = "DocAnexoId"   )]
      public int gxTpr_Docanexoid
      {
         get {
            return gxTv_SdtDocAnexo_Docanexoid ;
         }

         set {
            gxTv_SdtDocAnexo_N = 0;
            if ( gxTv_SdtDocAnexo_Docanexoid != value )
            {
               gxTv_SdtDocAnexo_Mode = "INS";
               this.gxTv_SdtDocAnexo_Docanexoid_Z_SetNull( );
               this.gxTv_SdtDocAnexo_Documentoid_Z_SetNull( );
               this.gxTv_SdtDocAnexo_Docanexodescricao_Z_SetNull( );
               this.gxTv_SdtDocAnexo_Docanexoarquivo_Z_SetNull( );
               this.gxTv_SdtDocAnexo_Docanexodatainclusao_Z_SetNull( );
               this.gxTv_SdtDocAnexo_Documentonome_Z_SetNull( );
            }
            gxTv_SdtDocAnexo_Docanexoid = value;
            SetDirty("Docanexoid");
         }

      }

      [  SoapElement( ElementName = "DocumentoId" )]
      [  XmlElement( ElementName = "DocumentoId"   )]
      public int gxTpr_Documentoid
      {
         get {
            return gxTv_SdtDocAnexo_Documentoid ;
         }

         set {
            gxTv_SdtDocAnexo_N = 0;
            gxTv_SdtDocAnexo_Documentoid = value;
            SetDirty("Documentoid");
         }

      }

      [  SoapElement( ElementName = "DocAnexoDescricao" )]
      [  XmlElement( ElementName = "DocAnexoDescricao"   )]
      public string gxTpr_Docanexodescricao
      {
         get {
            return gxTv_SdtDocAnexo_Docanexodescricao ;
         }

         set {
            gxTv_SdtDocAnexo_N = 0;
            gxTv_SdtDocAnexo_Docanexodescricao = value;
            SetDirty("Docanexodescricao");
         }

      }

      [  SoapElement( ElementName = "DocAnexoArquivo" )]
      [  XmlElement( ElementName = "DocAnexoArquivo"   )]
      public string gxTpr_Docanexoarquivo
      {
         get {
            return gxTv_SdtDocAnexo_Docanexoarquivo ;
         }

         set {
            gxTv_SdtDocAnexo_N = 0;
            gxTv_SdtDocAnexo_Docanexoarquivo = value;
            SetDirty("Docanexoarquivo");
         }

      }

      [  SoapElement( ElementName = "DocAnexoDataInclusao" )]
      [  XmlElement( ElementName = "DocAnexoDataInclusao"  , IsNullable=true )]
      public string gxTpr_Docanexodatainclusao_Nullable
      {
         get {
            if ( gxTv_SdtDocAnexo_Docanexodatainclusao == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocAnexo_Docanexodatainclusao).value ;
         }

         set {
            gxTv_SdtDocAnexo_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocAnexo_Docanexodatainclusao = DateTime.MinValue;
            else
               gxTv_SdtDocAnexo_Docanexodatainclusao = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Docanexodatainclusao
      {
         get {
            return gxTv_SdtDocAnexo_Docanexodatainclusao ;
         }

         set {
            gxTv_SdtDocAnexo_N = 0;
            gxTv_SdtDocAnexo_Docanexodatainclusao = value;
            SetDirty("Docanexodatainclusao");
         }

      }

      [  SoapElement( ElementName = "DocumentoNome" )]
      [  XmlElement( ElementName = "DocumentoNome"   )]
      public string gxTpr_Documentonome
      {
         get {
            return gxTv_SdtDocAnexo_Documentonome ;
         }

         set {
            gxTv_SdtDocAnexo_Documentonome_N = 0;
            gxTv_SdtDocAnexo_N = 0;
            gxTv_SdtDocAnexo_Documentonome = value;
            SetDirty("Documentonome");
         }

      }

      public void gxTv_SdtDocAnexo_Documentonome_SetNull( )
      {
         gxTv_SdtDocAnexo_Documentonome_N = 1;
         gxTv_SdtDocAnexo_Documentonome = "";
         SetDirty("Documentonome");
         return  ;
      }

      public bool gxTv_SdtDocAnexo_Documentonome_IsNull( )
      {
         return (gxTv_SdtDocAnexo_Documentonome_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtDocAnexo_Mode ;
         }

         set {
            gxTv_SdtDocAnexo_N = 0;
            gxTv_SdtDocAnexo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtDocAnexo_Mode_SetNull( )
      {
         gxTv_SdtDocAnexo_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtDocAnexo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtDocAnexo_Initialized ;
         }

         set {
            gxTv_SdtDocAnexo_N = 0;
            gxTv_SdtDocAnexo_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtDocAnexo_Initialized_SetNull( )
      {
         gxTv_SdtDocAnexo_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtDocAnexo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocAnexoId_Z" )]
      [  XmlElement( ElementName = "DocAnexoId_Z"   )]
      public int gxTpr_Docanexoid_Z
      {
         get {
            return gxTv_SdtDocAnexo_Docanexoid_Z ;
         }

         set {
            gxTv_SdtDocAnexo_N = 0;
            gxTv_SdtDocAnexo_Docanexoid_Z = value;
            SetDirty("Docanexoid_Z");
         }

      }

      public void gxTv_SdtDocAnexo_Docanexoid_Z_SetNull( )
      {
         gxTv_SdtDocAnexo_Docanexoid_Z = 0;
         SetDirty("Docanexoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocAnexo_Docanexoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoId_Z" )]
      [  XmlElement( ElementName = "DocumentoId_Z"   )]
      public int gxTpr_Documentoid_Z
      {
         get {
            return gxTv_SdtDocAnexo_Documentoid_Z ;
         }

         set {
            gxTv_SdtDocAnexo_N = 0;
            gxTv_SdtDocAnexo_Documentoid_Z = value;
            SetDirty("Documentoid_Z");
         }

      }

      public void gxTv_SdtDocAnexo_Documentoid_Z_SetNull( )
      {
         gxTv_SdtDocAnexo_Documentoid_Z = 0;
         SetDirty("Documentoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocAnexo_Documentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocAnexoDescricao_Z" )]
      [  XmlElement( ElementName = "DocAnexoDescricao_Z"   )]
      public string gxTpr_Docanexodescricao_Z
      {
         get {
            return gxTv_SdtDocAnexo_Docanexodescricao_Z ;
         }

         set {
            gxTv_SdtDocAnexo_N = 0;
            gxTv_SdtDocAnexo_Docanexodescricao_Z = value;
            SetDirty("Docanexodescricao_Z");
         }

      }

      public void gxTv_SdtDocAnexo_Docanexodescricao_Z_SetNull( )
      {
         gxTv_SdtDocAnexo_Docanexodescricao_Z = "";
         SetDirty("Docanexodescricao_Z");
         return  ;
      }

      public bool gxTv_SdtDocAnexo_Docanexodescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocAnexoArquivo_Z" )]
      [  XmlElement( ElementName = "DocAnexoArquivo_Z"   )]
      public string gxTpr_Docanexoarquivo_Z
      {
         get {
            return gxTv_SdtDocAnexo_Docanexoarquivo_Z ;
         }

         set {
            gxTv_SdtDocAnexo_N = 0;
            gxTv_SdtDocAnexo_Docanexoarquivo_Z = value;
            SetDirty("Docanexoarquivo_Z");
         }

      }

      public void gxTv_SdtDocAnexo_Docanexoarquivo_Z_SetNull( )
      {
         gxTv_SdtDocAnexo_Docanexoarquivo_Z = "";
         SetDirty("Docanexoarquivo_Z");
         return  ;
      }

      public bool gxTv_SdtDocAnexo_Docanexoarquivo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocAnexoDataInclusao_Z" )]
      [  XmlElement( ElementName = "DocAnexoDataInclusao_Z"  , IsNullable=true )]
      public string gxTpr_Docanexodatainclusao_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocAnexo_Docanexodatainclusao_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocAnexo_Docanexodatainclusao_Z).value ;
         }

         set {
            gxTv_SdtDocAnexo_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocAnexo_Docanexodatainclusao_Z = DateTime.MinValue;
            else
               gxTv_SdtDocAnexo_Docanexodatainclusao_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Docanexodatainclusao_Z
      {
         get {
            return gxTv_SdtDocAnexo_Docanexodatainclusao_Z ;
         }

         set {
            gxTv_SdtDocAnexo_N = 0;
            gxTv_SdtDocAnexo_Docanexodatainclusao_Z = value;
            SetDirty("Docanexodatainclusao_Z");
         }

      }

      public void gxTv_SdtDocAnexo_Docanexodatainclusao_Z_SetNull( )
      {
         gxTv_SdtDocAnexo_Docanexodatainclusao_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docanexodatainclusao_Z");
         return  ;
      }

      public bool gxTv_SdtDocAnexo_Docanexodatainclusao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoNome_Z" )]
      [  XmlElement( ElementName = "DocumentoNome_Z"   )]
      public string gxTpr_Documentonome_Z
      {
         get {
            return gxTv_SdtDocAnexo_Documentonome_Z ;
         }

         set {
            gxTv_SdtDocAnexo_N = 0;
            gxTv_SdtDocAnexo_Documentonome_Z = value;
            SetDirty("Documentonome_Z");
         }

      }

      public void gxTv_SdtDocAnexo_Documentonome_Z_SetNull( )
      {
         gxTv_SdtDocAnexo_Documentonome_Z = "";
         SetDirty("Documentonome_Z");
         return  ;
      }

      public bool gxTv_SdtDocAnexo_Documentonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoNome_N" )]
      [  XmlElement( ElementName = "DocumentoNome_N"   )]
      public short gxTpr_Documentonome_N
      {
         get {
            return gxTv_SdtDocAnexo_Documentonome_N ;
         }

         set {
            gxTv_SdtDocAnexo_N = 0;
            gxTv_SdtDocAnexo_Documentonome_N = value;
            SetDirty("Documentonome_N");
         }

      }

      public void gxTv_SdtDocAnexo_Documentonome_N_SetNull( )
      {
         gxTv_SdtDocAnexo_Documentonome_N = 0;
         SetDirty("Documentonome_N");
         return  ;
      }

      public bool gxTv_SdtDocAnexo_Documentonome_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtDocAnexo_N = 1;
         gxTv_SdtDocAnexo_Docanexodescricao = "";
         gxTv_SdtDocAnexo_Docanexoarquivo = "";
         gxTv_SdtDocAnexo_Docanexodatainclusao = DateTime.MinValue;
         gxTv_SdtDocAnexo_Documentonome = "";
         gxTv_SdtDocAnexo_Mode = "";
         gxTv_SdtDocAnexo_Docanexodescricao_Z = "";
         gxTv_SdtDocAnexo_Docanexoarquivo_Z = "";
         gxTv_SdtDocAnexo_Docanexodatainclusao_Z = DateTime.MinValue;
         gxTv_SdtDocAnexo_Documentonome_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "docanexo", "GeneXus.Programs.docanexo_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtDocAnexo_N ;
      }

      private short gxTv_SdtDocAnexo_N ;
      private short gxTv_SdtDocAnexo_Initialized ;
      private short gxTv_SdtDocAnexo_Documentonome_N ;
      private int gxTv_SdtDocAnexo_Docanexoid ;
      private int gxTv_SdtDocAnexo_Documentoid ;
      private int gxTv_SdtDocAnexo_Docanexoid_Z ;
      private int gxTv_SdtDocAnexo_Documentoid_Z ;
      private string gxTv_SdtDocAnexo_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtDocAnexo_Docanexodatainclusao ;
      private DateTime gxTv_SdtDocAnexo_Docanexodatainclusao_Z ;
      private string gxTv_SdtDocAnexo_Docanexodescricao ;
      private string gxTv_SdtDocAnexo_Docanexoarquivo ;
      private string gxTv_SdtDocAnexo_Documentonome ;
      private string gxTv_SdtDocAnexo_Docanexodescricao_Z ;
      private string gxTv_SdtDocAnexo_Docanexoarquivo_Z ;
      private string gxTv_SdtDocAnexo_Documentonome_Z ;
   }

   [DataContract(Name = @"DocAnexo", Namespace = "LGPD_Novo")]
   public class SdtDocAnexo_RESTInterface : GxGenericCollectionItem<SdtDocAnexo>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocAnexo_RESTInterface( ) : base()
      {
      }

      public SdtDocAnexo_RESTInterface( SdtDocAnexo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DocAnexoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Docanexoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Docanexoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Docanexoid = (int)(NumberUtil.Val( value, "."));
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

      [DataMember( Name = "DocAnexoDescricao" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Docanexodescricao
      {
         get {
            return sdt.gxTpr_Docanexodescricao ;
         }

         set {
            sdt.gxTpr_Docanexodescricao = value;
         }

      }

      [DataMember( Name = "DocAnexoArquivo" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Docanexoarquivo
      {
         get {
            return sdt.gxTpr_Docanexoarquivo ;
         }

         set {
            sdt.gxTpr_Docanexoarquivo = value;
         }

      }

      [DataMember( Name = "DocAnexoDataInclusao" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Docanexodatainclusao
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Docanexodatainclusao) ;
         }

         set {
            sdt.gxTpr_Docanexodatainclusao = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "DocumentoNome" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Documentonome
      {
         get {
            return sdt.gxTpr_Documentonome ;
         }

         set {
            sdt.gxTpr_Documentonome = value;
         }

      }

      public SdtDocAnexo sdt
      {
         get {
            return (SdtDocAnexo)Sdt ;
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
            sdt = new SdtDocAnexo() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 6 )]
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

   [DataContract(Name = @"DocAnexo", Namespace = "LGPD_Novo")]
   public class SdtDocAnexo_RESTLInterface : GxGenericCollectionItem<SdtDocAnexo>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocAnexo_RESTLInterface( ) : base()
      {
      }

      public SdtDocAnexo_RESTLInterface( SdtDocAnexo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DocAnexoDescricao" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Docanexodescricao
      {
         get {
            return sdt.gxTpr_Docanexodescricao ;
         }

         set {
            sdt.gxTpr_Docanexodescricao = value;
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

      public SdtDocAnexo sdt
      {
         get {
            return (SdtDocAnexo)Sdt ;
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
            sdt = new SdtDocAnexo() ;
         }
      }

   }

}
