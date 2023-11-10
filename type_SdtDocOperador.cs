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
   [XmlRoot(ElementName = "DocOperador" )]
   [XmlType(TypeName =  "DocOperador" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtDocOperador : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocOperador( )
      {
      }

      public SdtDocOperador( IGxContext context )
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

      public void Load( int AV86DocOperadorId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV86DocOperadorId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"DocOperadorId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "DocOperador");
         metadata.Set("BT", "DocOperador");
         metadata.Set("PK", "[ \"DocOperadorId\" ]");
         metadata.Set("PKAssigned", "[ \"DocOperadorId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"DocumentoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"OperadorId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Docoperadorid_Z");
         state.Add("gxTpr_Documentoid_Z");
         state.Add("gxTpr_Operadorid_Z");
         state.Add("gxTpr_Docoperadorcoleta_Z");
         state.Add("gxTpr_Docoperadorretencao_Z");
         state.Add("gxTpr_Docoperadorcompartilhamento_Z");
         state.Add("gxTpr_Docoperadoreliminacao_Z");
         state.Add("gxTpr_Docoperadorprocessamento_Z");
         state.Add("gxTpr_Docoperadordatainclusao_Z_Nullable");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtDocOperador sdt;
         sdt = (SdtDocOperador)(source);
         gxTv_SdtDocOperador_Docoperadorid = sdt.gxTv_SdtDocOperador_Docoperadorid ;
         gxTv_SdtDocOperador_Documentoid = sdt.gxTv_SdtDocOperador_Documentoid ;
         gxTv_SdtDocOperador_Operadorid = sdt.gxTv_SdtDocOperador_Operadorid ;
         gxTv_SdtDocOperador_Docoperadorcoleta = sdt.gxTv_SdtDocOperador_Docoperadorcoleta ;
         gxTv_SdtDocOperador_Docoperadorretencao = sdt.gxTv_SdtDocOperador_Docoperadorretencao ;
         gxTv_SdtDocOperador_Docoperadorcompartilhamento = sdt.gxTv_SdtDocOperador_Docoperadorcompartilhamento ;
         gxTv_SdtDocOperador_Docoperadoreliminacao = sdt.gxTv_SdtDocOperador_Docoperadoreliminacao ;
         gxTv_SdtDocOperador_Docoperadorprocessamento = sdt.gxTv_SdtDocOperador_Docoperadorprocessamento ;
         gxTv_SdtDocOperador_Docoperadordatainclusao = sdt.gxTv_SdtDocOperador_Docoperadordatainclusao ;
         gxTv_SdtDocOperador_Mode = sdt.gxTv_SdtDocOperador_Mode ;
         gxTv_SdtDocOperador_Initialized = sdt.gxTv_SdtDocOperador_Initialized ;
         gxTv_SdtDocOperador_Docoperadorid_Z = sdt.gxTv_SdtDocOperador_Docoperadorid_Z ;
         gxTv_SdtDocOperador_Documentoid_Z = sdt.gxTv_SdtDocOperador_Documentoid_Z ;
         gxTv_SdtDocOperador_Operadorid_Z = sdt.gxTv_SdtDocOperador_Operadorid_Z ;
         gxTv_SdtDocOperador_Docoperadorcoleta_Z = sdt.gxTv_SdtDocOperador_Docoperadorcoleta_Z ;
         gxTv_SdtDocOperador_Docoperadorretencao_Z = sdt.gxTv_SdtDocOperador_Docoperadorretencao_Z ;
         gxTv_SdtDocOperador_Docoperadorcompartilhamento_Z = sdt.gxTv_SdtDocOperador_Docoperadorcompartilhamento_Z ;
         gxTv_SdtDocOperador_Docoperadoreliminacao_Z = sdt.gxTv_SdtDocOperador_Docoperadoreliminacao_Z ;
         gxTv_SdtDocOperador_Docoperadorprocessamento_Z = sdt.gxTv_SdtDocOperador_Docoperadorprocessamento_Z ;
         gxTv_SdtDocOperador_Docoperadordatainclusao_Z = sdt.gxTv_SdtDocOperador_Docoperadordatainclusao_Z ;
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
         AddObjectProperty("DocOperadorId", gxTv_SdtDocOperador_Docoperadorid, false, includeNonInitialized);
         AddObjectProperty("DocumentoId", gxTv_SdtDocOperador_Documentoid, false, includeNonInitialized);
         AddObjectProperty("OperadorId", gxTv_SdtDocOperador_Operadorid, false, includeNonInitialized);
         AddObjectProperty("DocOperadorColeta", gxTv_SdtDocOperador_Docoperadorcoleta, false, includeNonInitialized);
         AddObjectProperty("DocOperadorRetencao", gxTv_SdtDocOperador_Docoperadorretencao, false, includeNonInitialized);
         AddObjectProperty("DocOperadorCompartilhamento", gxTv_SdtDocOperador_Docoperadorcompartilhamento, false, includeNonInitialized);
         AddObjectProperty("DocOperadorEliminacao", gxTv_SdtDocOperador_Docoperadoreliminacao, false, includeNonInitialized);
         AddObjectProperty("DocOperadorProcessamento", gxTv_SdtDocOperador_Docoperadorprocessamento, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocOperador_Docoperadordatainclusao)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocOperador_Docoperadordatainclusao)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocOperador_Docoperadordatainclusao)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("DocOperadorDataInclusao", sDateCnv, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtDocOperador_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtDocOperador_Initialized, false, includeNonInitialized);
            AddObjectProperty("DocOperadorId_Z", gxTv_SdtDocOperador_Docoperadorid_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoId_Z", gxTv_SdtDocOperador_Documentoid_Z, false, includeNonInitialized);
            AddObjectProperty("OperadorId_Z", gxTv_SdtDocOperador_Operadorid_Z, false, includeNonInitialized);
            AddObjectProperty("DocOperadorColeta_Z", gxTv_SdtDocOperador_Docoperadorcoleta_Z, false, includeNonInitialized);
            AddObjectProperty("DocOperadorRetencao_Z", gxTv_SdtDocOperador_Docoperadorretencao_Z, false, includeNonInitialized);
            AddObjectProperty("DocOperadorCompartilhamento_Z", gxTv_SdtDocOperador_Docoperadorcompartilhamento_Z, false, includeNonInitialized);
            AddObjectProperty("DocOperadorEliminacao_Z", gxTv_SdtDocOperador_Docoperadoreliminacao_Z, false, includeNonInitialized);
            AddObjectProperty("DocOperadorProcessamento_Z", gxTv_SdtDocOperador_Docoperadorprocessamento_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocOperador_Docoperadordatainclusao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocOperador_Docoperadordatainclusao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocOperador_Docoperadordatainclusao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("DocOperadorDataInclusao_Z", sDateCnv, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtDocOperador sdt )
      {
         if ( sdt.IsDirty("DocOperadorId") )
         {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Docoperadorid = sdt.gxTv_SdtDocOperador_Docoperadorid ;
         }
         if ( sdt.IsDirty("DocumentoId") )
         {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Documentoid = sdt.gxTv_SdtDocOperador_Documentoid ;
         }
         if ( sdt.IsDirty("OperadorId") )
         {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Operadorid = sdt.gxTv_SdtDocOperador_Operadorid ;
         }
         if ( sdt.IsDirty("DocOperadorColeta") )
         {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Docoperadorcoleta = sdt.gxTv_SdtDocOperador_Docoperadorcoleta ;
         }
         if ( sdt.IsDirty("DocOperadorRetencao") )
         {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Docoperadorretencao = sdt.gxTv_SdtDocOperador_Docoperadorretencao ;
         }
         if ( sdt.IsDirty("DocOperadorCompartilhamento") )
         {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Docoperadorcompartilhamento = sdt.gxTv_SdtDocOperador_Docoperadorcompartilhamento ;
         }
         if ( sdt.IsDirty("DocOperadorEliminacao") )
         {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Docoperadoreliminacao = sdt.gxTv_SdtDocOperador_Docoperadoreliminacao ;
         }
         if ( sdt.IsDirty("DocOperadorProcessamento") )
         {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Docoperadorprocessamento = sdt.gxTv_SdtDocOperador_Docoperadorprocessamento ;
         }
         if ( sdt.IsDirty("DocOperadorDataInclusao") )
         {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Docoperadordatainclusao = sdt.gxTv_SdtDocOperador_Docoperadordatainclusao ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "DocOperadorId" )]
      [  XmlElement( ElementName = "DocOperadorId"   )]
      public int gxTpr_Docoperadorid
      {
         get {
            return gxTv_SdtDocOperador_Docoperadorid ;
         }

         set {
            gxTv_SdtDocOperador_N = 0;
            if ( gxTv_SdtDocOperador_Docoperadorid != value )
            {
               gxTv_SdtDocOperador_Mode = "INS";
               this.gxTv_SdtDocOperador_Docoperadorid_Z_SetNull( );
               this.gxTv_SdtDocOperador_Documentoid_Z_SetNull( );
               this.gxTv_SdtDocOperador_Operadorid_Z_SetNull( );
               this.gxTv_SdtDocOperador_Docoperadorcoleta_Z_SetNull( );
               this.gxTv_SdtDocOperador_Docoperadorretencao_Z_SetNull( );
               this.gxTv_SdtDocOperador_Docoperadorcompartilhamento_Z_SetNull( );
               this.gxTv_SdtDocOperador_Docoperadoreliminacao_Z_SetNull( );
               this.gxTv_SdtDocOperador_Docoperadorprocessamento_Z_SetNull( );
               this.gxTv_SdtDocOperador_Docoperadordatainclusao_Z_SetNull( );
            }
            gxTv_SdtDocOperador_Docoperadorid = value;
            SetDirty("Docoperadorid");
         }

      }

      [  SoapElement( ElementName = "DocumentoId" )]
      [  XmlElement( ElementName = "DocumentoId"   )]
      public int gxTpr_Documentoid
      {
         get {
            return gxTv_SdtDocOperador_Documentoid ;
         }

         set {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Documentoid = value;
            SetDirty("Documentoid");
         }

      }

      [  SoapElement( ElementName = "OperadorId" )]
      [  XmlElement( ElementName = "OperadorId"   )]
      public int gxTpr_Operadorid
      {
         get {
            return gxTv_SdtDocOperador_Operadorid ;
         }

         set {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Operadorid = value;
            SetDirty("Operadorid");
         }

      }

      [  SoapElement( ElementName = "DocOperadorColeta" )]
      [  XmlElement( ElementName = "DocOperadorColeta"   )]
      public bool gxTpr_Docoperadorcoleta
      {
         get {
            return gxTv_SdtDocOperador_Docoperadorcoleta ;
         }

         set {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Docoperadorcoleta = value;
            SetDirty("Docoperadorcoleta");
         }

      }

      [  SoapElement( ElementName = "DocOperadorRetencao" )]
      [  XmlElement( ElementName = "DocOperadorRetencao"   )]
      public bool gxTpr_Docoperadorretencao
      {
         get {
            return gxTv_SdtDocOperador_Docoperadorretencao ;
         }

         set {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Docoperadorretencao = value;
            SetDirty("Docoperadorretencao");
         }

      }

      [  SoapElement( ElementName = "DocOperadorCompartilhamento" )]
      [  XmlElement( ElementName = "DocOperadorCompartilhamento"   )]
      public bool gxTpr_Docoperadorcompartilhamento
      {
         get {
            return gxTv_SdtDocOperador_Docoperadorcompartilhamento ;
         }

         set {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Docoperadorcompartilhamento = value;
            SetDirty("Docoperadorcompartilhamento");
         }

      }

      [  SoapElement( ElementName = "DocOperadorEliminacao" )]
      [  XmlElement( ElementName = "DocOperadorEliminacao"   )]
      public bool gxTpr_Docoperadoreliminacao
      {
         get {
            return gxTv_SdtDocOperador_Docoperadoreliminacao ;
         }

         set {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Docoperadoreliminacao = value;
            SetDirty("Docoperadoreliminacao");
         }

      }

      [  SoapElement( ElementName = "DocOperadorProcessamento" )]
      [  XmlElement( ElementName = "DocOperadorProcessamento"   )]
      public bool gxTpr_Docoperadorprocessamento
      {
         get {
            return gxTv_SdtDocOperador_Docoperadorprocessamento ;
         }

         set {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Docoperadorprocessamento = value;
            SetDirty("Docoperadorprocessamento");
         }

      }

      [  SoapElement( ElementName = "DocOperadorDataInclusao" )]
      [  XmlElement( ElementName = "DocOperadorDataInclusao"  , IsNullable=true )]
      public string gxTpr_Docoperadordatainclusao_Nullable
      {
         get {
            if ( gxTv_SdtDocOperador_Docoperadordatainclusao == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocOperador_Docoperadordatainclusao).value ;
         }

         set {
            gxTv_SdtDocOperador_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocOperador_Docoperadordatainclusao = DateTime.MinValue;
            else
               gxTv_SdtDocOperador_Docoperadordatainclusao = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Docoperadordatainclusao
      {
         get {
            return gxTv_SdtDocOperador_Docoperadordatainclusao ;
         }

         set {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Docoperadordatainclusao = value;
            SetDirty("Docoperadordatainclusao");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtDocOperador_Mode ;
         }

         set {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtDocOperador_Mode_SetNull( )
      {
         gxTv_SdtDocOperador_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtDocOperador_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtDocOperador_Initialized ;
         }

         set {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtDocOperador_Initialized_SetNull( )
      {
         gxTv_SdtDocOperador_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtDocOperador_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocOperadorId_Z" )]
      [  XmlElement( ElementName = "DocOperadorId_Z"   )]
      public int gxTpr_Docoperadorid_Z
      {
         get {
            return gxTv_SdtDocOperador_Docoperadorid_Z ;
         }

         set {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Docoperadorid_Z = value;
            SetDirty("Docoperadorid_Z");
         }

      }

      public void gxTv_SdtDocOperador_Docoperadorid_Z_SetNull( )
      {
         gxTv_SdtDocOperador_Docoperadorid_Z = 0;
         SetDirty("Docoperadorid_Z");
         return  ;
      }

      public bool gxTv_SdtDocOperador_Docoperadorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoId_Z" )]
      [  XmlElement( ElementName = "DocumentoId_Z"   )]
      public int gxTpr_Documentoid_Z
      {
         get {
            return gxTv_SdtDocOperador_Documentoid_Z ;
         }

         set {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Documentoid_Z = value;
            SetDirty("Documentoid_Z");
         }

      }

      public void gxTv_SdtDocOperador_Documentoid_Z_SetNull( )
      {
         gxTv_SdtDocOperador_Documentoid_Z = 0;
         SetDirty("Documentoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocOperador_Documentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperadorId_Z" )]
      [  XmlElement( ElementName = "OperadorId_Z"   )]
      public int gxTpr_Operadorid_Z
      {
         get {
            return gxTv_SdtDocOperador_Operadorid_Z ;
         }

         set {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Operadorid_Z = value;
            SetDirty("Operadorid_Z");
         }

      }

      public void gxTv_SdtDocOperador_Operadorid_Z_SetNull( )
      {
         gxTv_SdtDocOperador_Operadorid_Z = 0;
         SetDirty("Operadorid_Z");
         return  ;
      }

      public bool gxTv_SdtDocOperador_Operadorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocOperadorColeta_Z" )]
      [  XmlElement( ElementName = "DocOperadorColeta_Z"   )]
      public bool gxTpr_Docoperadorcoleta_Z
      {
         get {
            return gxTv_SdtDocOperador_Docoperadorcoleta_Z ;
         }

         set {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Docoperadorcoleta_Z = value;
            SetDirty("Docoperadorcoleta_Z");
         }

      }

      public void gxTv_SdtDocOperador_Docoperadorcoleta_Z_SetNull( )
      {
         gxTv_SdtDocOperador_Docoperadorcoleta_Z = false;
         SetDirty("Docoperadorcoleta_Z");
         return  ;
      }

      public bool gxTv_SdtDocOperador_Docoperadorcoleta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocOperadorRetencao_Z" )]
      [  XmlElement( ElementName = "DocOperadorRetencao_Z"   )]
      public bool gxTpr_Docoperadorretencao_Z
      {
         get {
            return gxTv_SdtDocOperador_Docoperadorretencao_Z ;
         }

         set {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Docoperadorretencao_Z = value;
            SetDirty("Docoperadorretencao_Z");
         }

      }

      public void gxTv_SdtDocOperador_Docoperadorretencao_Z_SetNull( )
      {
         gxTv_SdtDocOperador_Docoperadorretencao_Z = false;
         SetDirty("Docoperadorretencao_Z");
         return  ;
      }

      public bool gxTv_SdtDocOperador_Docoperadorretencao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocOperadorCompartilhamento_Z" )]
      [  XmlElement( ElementName = "DocOperadorCompartilhamento_Z"   )]
      public bool gxTpr_Docoperadorcompartilhamento_Z
      {
         get {
            return gxTv_SdtDocOperador_Docoperadorcompartilhamento_Z ;
         }

         set {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Docoperadorcompartilhamento_Z = value;
            SetDirty("Docoperadorcompartilhamento_Z");
         }

      }

      public void gxTv_SdtDocOperador_Docoperadorcompartilhamento_Z_SetNull( )
      {
         gxTv_SdtDocOperador_Docoperadorcompartilhamento_Z = false;
         SetDirty("Docoperadorcompartilhamento_Z");
         return  ;
      }

      public bool gxTv_SdtDocOperador_Docoperadorcompartilhamento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocOperadorEliminacao_Z" )]
      [  XmlElement( ElementName = "DocOperadorEliminacao_Z"   )]
      public bool gxTpr_Docoperadoreliminacao_Z
      {
         get {
            return gxTv_SdtDocOperador_Docoperadoreliminacao_Z ;
         }

         set {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Docoperadoreliminacao_Z = value;
            SetDirty("Docoperadoreliminacao_Z");
         }

      }

      public void gxTv_SdtDocOperador_Docoperadoreliminacao_Z_SetNull( )
      {
         gxTv_SdtDocOperador_Docoperadoreliminacao_Z = false;
         SetDirty("Docoperadoreliminacao_Z");
         return  ;
      }

      public bool gxTv_SdtDocOperador_Docoperadoreliminacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocOperadorProcessamento_Z" )]
      [  XmlElement( ElementName = "DocOperadorProcessamento_Z"   )]
      public bool gxTpr_Docoperadorprocessamento_Z
      {
         get {
            return gxTv_SdtDocOperador_Docoperadorprocessamento_Z ;
         }

         set {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Docoperadorprocessamento_Z = value;
            SetDirty("Docoperadorprocessamento_Z");
         }

      }

      public void gxTv_SdtDocOperador_Docoperadorprocessamento_Z_SetNull( )
      {
         gxTv_SdtDocOperador_Docoperadorprocessamento_Z = false;
         SetDirty("Docoperadorprocessamento_Z");
         return  ;
      }

      public bool gxTv_SdtDocOperador_Docoperadorprocessamento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocOperadorDataInclusao_Z" )]
      [  XmlElement( ElementName = "DocOperadorDataInclusao_Z"  , IsNullable=true )]
      public string gxTpr_Docoperadordatainclusao_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocOperador_Docoperadordatainclusao_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocOperador_Docoperadordatainclusao_Z).value ;
         }

         set {
            gxTv_SdtDocOperador_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocOperador_Docoperadordatainclusao_Z = DateTime.MinValue;
            else
               gxTv_SdtDocOperador_Docoperadordatainclusao_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Docoperadordatainclusao_Z
      {
         get {
            return gxTv_SdtDocOperador_Docoperadordatainclusao_Z ;
         }

         set {
            gxTv_SdtDocOperador_N = 0;
            gxTv_SdtDocOperador_Docoperadordatainclusao_Z = value;
            SetDirty("Docoperadordatainclusao_Z");
         }

      }

      public void gxTv_SdtDocOperador_Docoperadordatainclusao_Z_SetNull( )
      {
         gxTv_SdtDocOperador_Docoperadordatainclusao_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docoperadordatainclusao_Z");
         return  ;
      }

      public bool gxTv_SdtDocOperador_Docoperadordatainclusao_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtDocOperador_N = 1;
         gxTv_SdtDocOperador_Docoperadordatainclusao = DateTime.MinValue;
         gxTv_SdtDocOperador_Mode = "";
         gxTv_SdtDocOperador_Docoperadordatainclusao_Z = DateTime.MinValue;
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "docoperador", "GeneXus.Programs.docoperador_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtDocOperador_N ;
      }

      private short gxTv_SdtDocOperador_N ;
      private short gxTv_SdtDocOperador_Initialized ;
      private int gxTv_SdtDocOperador_Docoperadorid ;
      private int gxTv_SdtDocOperador_Documentoid ;
      private int gxTv_SdtDocOperador_Operadorid ;
      private int gxTv_SdtDocOperador_Docoperadorid_Z ;
      private int gxTv_SdtDocOperador_Documentoid_Z ;
      private int gxTv_SdtDocOperador_Operadorid_Z ;
      private string gxTv_SdtDocOperador_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtDocOperador_Docoperadordatainclusao ;
      private DateTime gxTv_SdtDocOperador_Docoperadordatainclusao_Z ;
      private bool gxTv_SdtDocOperador_Docoperadorcoleta ;
      private bool gxTv_SdtDocOperador_Docoperadorretencao ;
      private bool gxTv_SdtDocOperador_Docoperadorcompartilhamento ;
      private bool gxTv_SdtDocOperador_Docoperadoreliminacao ;
      private bool gxTv_SdtDocOperador_Docoperadorprocessamento ;
      private bool gxTv_SdtDocOperador_Docoperadorcoleta_Z ;
      private bool gxTv_SdtDocOperador_Docoperadorretencao_Z ;
      private bool gxTv_SdtDocOperador_Docoperadorcompartilhamento_Z ;
      private bool gxTv_SdtDocOperador_Docoperadoreliminacao_Z ;
      private bool gxTv_SdtDocOperador_Docoperadorprocessamento_Z ;
   }

   [DataContract(Name = @"DocOperador", Namespace = "LGPD_Novo")]
   public class SdtDocOperador_RESTInterface : GxGenericCollectionItem<SdtDocOperador>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocOperador_RESTInterface( ) : base()
      {
      }

      public SdtDocOperador_RESTInterface( SdtDocOperador psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DocOperadorId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Docoperadorid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Docoperadorid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Docoperadorid = (int)(NumberUtil.Val( value, "."));
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

      [DataMember( Name = "OperadorId" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Operadorid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Operadorid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Operadorid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "DocOperadorColeta" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Docoperadorcoleta
      {
         get {
            return sdt.gxTpr_Docoperadorcoleta ;
         }

         set {
            sdt.gxTpr_Docoperadorcoleta = value;
         }

      }

      [DataMember( Name = "DocOperadorRetencao" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Docoperadorretencao
      {
         get {
            return sdt.gxTpr_Docoperadorretencao ;
         }

         set {
            sdt.gxTpr_Docoperadorretencao = value;
         }

      }

      [DataMember( Name = "DocOperadorCompartilhamento" , Order = 5 )]
      [GxSeudo()]
      public bool gxTpr_Docoperadorcompartilhamento
      {
         get {
            return sdt.gxTpr_Docoperadorcompartilhamento ;
         }

         set {
            sdt.gxTpr_Docoperadorcompartilhamento = value;
         }

      }

      [DataMember( Name = "DocOperadorEliminacao" , Order = 6 )]
      [GxSeudo()]
      public bool gxTpr_Docoperadoreliminacao
      {
         get {
            return sdt.gxTpr_Docoperadoreliminacao ;
         }

         set {
            sdt.gxTpr_Docoperadoreliminacao = value;
         }

      }

      [DataMember( Name = "DocOperadorProcessamento" , Order = 7 )]
      [GxSeudo()]
      public bool gxTpr_Docoperadorprocessamento
      {
         get {
            return sdt.gxTpr_Docoperadorprocessamento ;
         }

         set {
            sdt.gxTpr_Docoperadorprocessamento = value;
         }

      }

      [DataMember( Name = "DocOperadorDataInclusao" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Docoperadordatainclusao
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Docoperadordatainclusao) ;
         }

         set {
            sdt.gxTpr_Docoperadordatainclusao = DateTimeUtil.CToD2( value);
         }

      }

      public SdtDocOperador sdt
      {
         get {
            return (SdtDocOperador)Sdt ;
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
            sdt = new SdtDocOperador() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 9 )]
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

   [DataContract(Name = @"DocOperador", Namespace = "LGPD_Novo")]
   public class SdtDocOperador_RESTLInterface : GxGenericCollectionItem<SdtDocOperador>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocOperador_RESTLInterface( ) : base()
      {
      }

      public SdtDocOperador_RESTLInterface( SdtDocOperador psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DocOperadorColeta" , Order = 0 )]
      [GxSeudo()]
      public bool gxTpr_Docoperadorcoleta
      {
         get {
            return sdt.gxTpr_Docoperadorcoleta ;
         }

         set {
            sdt.gxTpr_Docoperadorcoleta = value;
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

      public SdtDocOperador sdt
      {
         get {
            return (SdtDocOperador)Sdt ;
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
            sdt = new SdtDocOperador() ;
         }
      }

   }

}
