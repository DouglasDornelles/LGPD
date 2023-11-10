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
   [XmlRoot(ElementName = "Parametro" )]
   [XmlType(TypeName =  "Parametro" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtParametro : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtParametro( )
      {
      }

      public SdtParametro( IGxContext context )
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

      public void Load( string AV124ParametroCod )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(string)AV124ParametroCod});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ParametroCod", typeof(string)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Parametro");
         metadata.Set("BT", "Parametro");
         metadata.Set("PK", "[ \"ParametroCod\" ]");
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
         state.Add("gxTpr_Parametrocod_Z");
         state.Add("gxTpr_Parametrodescricao_Z");
         state.Add("gxTpr_Parametrovalor_Z");
         state.Add("gxTpr_Parametrocomentario_Z");
         state.Add("gxTpr_Parametrodatainclusao_Z_Nullable");
         state.Add("gxTpr_Parametrodataalteracao_Z_Nullable");
         state.Add("gxTpr_Parametrousuarioinclusao_Z");
         state.Add("gxTpr_Parametrousuarioalteracao_Z");
         state.Add("gxTpr_Parametroativo_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtParametro sdt;
         sdt = (SdtParametro)(source);
         gxTv_SdtParametro_Parametrocod = sdt.gxTv_SdtParametro_Parametrocod ;
         gxTv_SdtParametro_Parametrodescricao = sdt.gxTv_SdtParametro_Parametrodescricao ;
         gxTv_SdtParametro_Parametrovalor = sdt.gxTv_SdtParametro_Parametrovalor ;
         gxTv_SdtParametro_Parametrocomentario = sdt.gxTv_SdtParametro_Parametrocomentario ;
         gxTv_SdtParametro_Parametrodatainclusao = sdt.gxTv_SdtParametro_Parametrodatainclusao ;
         gxTv_SdtParametro_Parametrodataalteracao = sdt.gxTv_SdtParametro_Parametrodataalteracao ;
         gxTv_SdtParametro_Parametrousuarioinclusao = sdt.gxTv_SdtParametro_Parametrousuarioinclusao ;
         gxTv_SdtParametro_Parametrousuarioalteracao = sdt.gxTv_SdtParametro_Parametrousuarioalteracao ;
         gxTv_SdtParametro_Parametroativo = sdt.gxTv_SdtParametro_Parametroativo ;
         gxTv_SdtParametro_Mode = sdt.gxTv_SdtParametro_Mode ;
         gxTv_SdtParametro_Initialized = sdt.gxTv_SdtParametro_Initialized ;
         gxTv_SdtParametro_Parametrocod_Z = sdt.gxTv_SdtParametro_Parametrocod_Z ;
         gxTv_SdtParametro_Parametrodescricao_Z = sdt.gxTv_SdtParametro_Parametrodescricao_Z ;
         gxTv_SdtParametro_Parametrovalor_Z = sdt.gxTv_SdtParametro_Parametrovalor_Z ;
         gxTv_SdtParametro_Parametrocomentario_Z = sdt.gxTv_SdtParametro_Parametrocomentario_Z ;
         gxTv_SdtParametro_Parametrodatainclusao_Z = sdt.gxTv_SdtParametro_Parametrodatainclusao_Z ;
         gxTv_SdtParametro_Parametrodataalteracao_Z = sdt.gxTv_SdtParametro_Parametrodataalteracao_Z ;
         gxTv_SdtParametro_Parametrousuarioinclusao_Z = sdt.gxTv_SdtParametro_Parametrousuarioinclusao_Z ;
         gxTv_SdtParametro_Parametrousuarioalteracao_Z = sdt.gxTv_SdtParametro_Parametrousuarioalteracao_Z ;
         gxTv_SdtParametro_Parametroativo_Z = sdt.gxTv_SdtParametro_Parametroativo_Z ;
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
         AddObjectProperty("ParametroCod", gxTv_SdtParametro_Parametrocod, false, includeNonInitialized);
         AddObjectProperty("ParametroDescricao", gxTv_SdtParametro_Parametrodescricao, false, includeNonInitialized);
         AddObjectProperty("ParametroValor", gxTv_SdtParametro_Parametrovalor, false, includeNonInitialized);
         AddObjectProperty("ParametroComentario", gxTv_SdtParametro_Parametrocomentario, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtParametro_Parametrodatainclusao)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtParametro_Parametrodatainclusao)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtParametro_Parametrodatainclusao)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("ParametroDataInclusao", sDateCnv, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtParametro_Parametrodataalteracao)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtParametro_Parametrodataalteracao)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtParametro_Parametrodataalteracao)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("ParametroDataAlteracao", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ParametroUsuarioInclusao", gxTv_SdtParametro_Parametrousuarioinclusao, false, includeNonInitialized);
         AddObjectProperty("ParametroUsuarioAlteracao", gxTv_SdtParametro_Parametrousuarioalteracao, false, includeNonInitialized);
         AddObjectProperty("ParametroAtivo", gxTv_SdtParametro_Parametroativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtParametro_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtParametro_Initialized, false, includeNonInitialized);
            AddObjectProperty("ParametroCod_Z", gxTv_SdtParametro_Parametrocod_Z, false, includeNonInitialized);
            AddObjectProperty("ParametroDescricao_Z", gxTv_SdtParametro_Parametrodescricao_Z, false, includeNonInitialized);
            AddObjectProperty("ParametroValor_Z", gxTv_SdtParametro_Parametrovalor_Z, false, includeNonInitialized);
            AddObjectProperty("ParametroComentario_Z", gxTv_SdtParametro_Parametrocomentario_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtParametro_Parametrodatainclusao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtParametro_Parametrodatainclusao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtParametro_Parametrodatainclusao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("ParametroDataInclusao_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtParametro_Parametrodataalteracao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtParametro_Parametrodataalteracao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtParametro_Parametrodataalteracao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("ParametroDataAlteracao_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ParametroUsuarioInclusao_Z", gxTv_SdtParametro_Parametrousuarioinclusao_Z, false, includeNonInitialized);
            AddObjectProperty("ParametroUsuarioAlteracao_Z", gxTv_SdtParametro_Parametrousuarioalteracao_Z, false, includeNonInitialized);
            AddObjectProperty("ParametroAtivo_Z", gxTv_SdtParametro_Parametroativo_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtParametro sdt )
      {
         if ( sdt.IsDirty("ParametroCod") )
         {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrocod = sdt.gxTv_SdtParametro_Parametrocod ;
         }
         if ( sdt.IsDirty("ParametroDescricao") )
         {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrodescricao = sdt.gxTv_SdtParametro_Parametrodescricao ;
         }
         if ( sdt.IsDirty("ParametroValor") )
         {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrovalor = sdt.gxTv_SdtParametro_Parametrovalor ;
         }
         if ( sdt.IsDirty("ParametroComentario") )
         {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrocomentario = sdt.gxTv_SdtParametro_Parametrocomentario ;
         }
         if ( sdt.IsDirty("ParametroDataInclusao") )
         {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrodatainclusao = sdt.gxTv_SdtParametro_Parametrodatainclusao ;
         }
         if ( sdt.IsDirty("ParametroDataAlteracao") )
         {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrodataalteracao = sdt.gxTv_SdtParametro_Parametrodataalteracao ;
         }
         if ( sdt.IsDirty("ParametroUsuarioInclusao") )
         {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrousuarioinclusao = sdt.gxTv_SdtParametro_Parametrousuarioinclusao ;
         }
         if ( sdt.IsDirty("ParametroUsuarioAlteracao") )
         {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrousuarioalteracao = sdt.gxTv_SdtParametro_Parametrousuarioalteracao ;
         }
         if ( sdt.IsDirty("ParametroAtivo") )
         {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametroativo = sdt.gxTv_SdtParametro_Parametroativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ParametroCod" )]
      [  XmlElement( ElementName = "ParametroCod"   )]
      public string gxTpr_Parametrocod
      {
         get {
            return gxTv_SdtParametro_Parametrocod ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            if ( StringUtil.StrCmp(gxTv_SdtParametro_Parametrocod, value) != 0 )
            {
               gxTv_SdtParametro_Mode = "INS";
               this.gxTv_SdtParametro_Parametrocod_Z_SetNull( );
               this.gxTv_SdtParametro_Parametrodescricao_Z_SetNull( );
               this.gxTv_SdtParametro_Parametrovalor_Z_SetNull( );
               this.gxTv_SdtParametro_Parametrocomentario_Z_SetNull( );
               this.gxTv_SdtParametro_Parametrodatainclusao_Z_SetNull( );
               this.gxTv_SdtParametro_Parametrodataalteracao_Z_SetNull( );
               this.gxTv_SdtParametro_Parametrousuarioinclusao_Z_SetNull( );
               this.gxTv_SdtParametro_Parametrousuarioalteracao_Z_SetNull( );
               this.gxTv_SdtParametro_Parametroativo_Z_SetNull( );
            }
            gxTv_SdtParametro_Parametrocod = value;
            SetDirty("Parametrocod");
         }

      }

      [  SoapElement( ElementName = "ParametroDescricao" )]
      [  XmlElement( ElementName = "ParametroDescricao"   )]
      public string gxTpr_Parametrodescricao
      {
         get {
            return gxTv_SdtParametro_Parametrodescricao ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrodescricao = value;
            SetDirty("Parametrodescricao");
         }

      }

      [  SoapElement( ElementName = "ParametroValor" )]
      [  XmlElement( ElementName = "ParametroValor"   )]
      public string gxTpr_Parametrovalor
      {
         get {
            return gxTv_SdtParametro_Parametrovalor ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrovalor = value;
            SetDirty("Parametrovalor");
         }

      }

      [  SoapElement( ElementName = "ParametroComentario" )]
      [  XmlElement( ElementName = "ParametroComentario"   )]
      public string gxTpr_Parametrocomentario
      {
         get {
            return gxTv_SdtParametro_Parametrocomentario ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrocomentario = value;
            SetDirty("Parametrocomentario");
         }

      }

      [  SoapElement( ElementName = "ParametroDataInclusao" )]
      [  XmlElement( ElementName = "ParametroDataInclusao"  , IsNullable=true )]
      public string gxTpr_Parametrodatainclusao_Nullable
      {
         get {
            if ( gxTv_SdtParametro_Parametrodatainclusao == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtParametro_Parametrodatainclusao).value ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtParametro_Parametrodatainclusao = DateTime.MinValue;
            else
               gxTv_SdtParametro_Parametrodatainclusao = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Parametrodatainclusao
      {
         get {
            return gxTv_SdtParametro_Parametrodatainclusao ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrodatainclusao = value;
            SetDirty("Parametrodatainclusao");
         }

      }

      [  SoapElement( ElementName = "ParametroDataAlteracao" )]
      [  XmlElement( ElementName = "ParametroDataAlteracao"  , IsNullable=true )]
      public string gxTpr_Parametrodataalteracao_Nullable
      {
         get {
            if ( gxTv_SdtParametro_Parametrodataalteracao == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtParametro_Parametrodataalteracao).value ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtParametro_Parametrodataalteracao = DateTime.MinValue;
            else
               gxTv_SdtParametro_Parametrodataalteracao = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Parametrodataalteracao
      {
         get {
            return gxTv_SdtParametro_Parametrodataalteracao ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrodataalteracao = value;
            SetDirty("Parametrodataalteracao");
         }

      }

      [  SoapElement( ElementName = "ParametroUsuarioInclusao" )]
      [  XmlElement( ElementName = "ParametroUsuarioInclusao"   )]
      public string gxTpr_Parametrousuarioinclusao
      {
         get {
            return gxTv_SdtParametro_Parametrousuarioinclusao ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrousuarioinclusao = value;
            SetDirty("Parametrousuarioinclusao");
         }

      }

      [  SoapElement( ElementName = "ParametroUsuarioAlteracao" )]
      [  XmlElement( ElementName = "ParametroUsuarioAlteracao"   )]
      public string gxTpr_Parametrousuarioalteracao
      {
         get {
            return gxTv_SdtParametro_Parametrousuarioalteracao ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrousuarioalteracao = value;
            SetDirty("Parametrousuarioalteracao");
         }

      }

      [  SoapElement( ElementName = "ParametroAtivo" )]
      [  XmlElement( ElementName = "ParametroAtivo"   )]
      public bool gxTpr_Parametroativo
      {
         get {
            return gxTv_SdtParametro_Parametroativo ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametroativo = value;
            SetDirty("Parametroativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtParametro_Mode ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtParametro_Mode_SetNull( )
      {
         gxTv_SdtParametro_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtParametro_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtParametro_Initialized ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtParametro_Initialized_SetNull( )
      {
         gxTv_SdtParametro_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtParametro_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroCod_Z" )]
      [  XmlElement( ElementName = "ParametroCod_Z"   )]
      public string gxTpr_Parametrocod_Z
      {
         get {
            return gxTv_SdtParametro_Parametrocod_Z ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrocod_Z = value;
            SetDirty("Parametrocod_Z");
         }

      }

      public void gxTv_SdtParametro_Parametrocod_Z_SetNull( )
      {
         gxTv_SdtParametro_Parametrocod_Z = "";
         SetDirty("Parametrocod_Z");
         return  ;
      }

      public bool gxTv_SdtParametro_Parametrocod_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroDescricao_Z" )]
      [  XmlElement( ElementName = "ParametroDescricao_Z"   )]
      public string gxTpr_Parametrodescricao_Z
      {
         get {
            return gxTv_SdtParametro_Parametrodescricao_Z ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrodescricao_Z = value;
            SetDirty("Parametrodescricao_Z");
         }

      }

      public void gxTv_SdtParametro_Parametrodescricao_Z_SetNull( )
      {
         gxTv_SdtParametro_Parametrodescricao_Z = "";
         SetDirty("Parametrodescricao_Z");
         return  ;
      }

      public bool gxTv_SdtParametro_Parametrodescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroValor_Z" )]
      [  XmlElement( ElementName = "ParametroValor_Z"   )]
      public string gxTpr_Parametrovalor_Z
      {
         get {
            return gxTv_SdtParametro_Parametrovalor_Z ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrovalor_Z = value;
            SetDirty("Parametrovalor_Z");
         }

      }

      public void gxTv_SdtParametro_Parametrovalor_Z_SetNull( )
      {
         gxTv_SdtParametro_Parametrovalor_Z = "";
         SetDirty("Parametrovalor_Z");
         return  ;
      }

      public bool gxTv_SdtParametro_Parametrovalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroComentario_Z" )]
      [  XmlElement( ElementName = "ParametroComentario_Z"   )]
      public string gxTpr_Parametrocomentario_Z
      {
         get {
            return gxTv_SdtParametro_Parametrocomentario_Z ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrocomentario_Z = value;
            SetDirty("Parametrocomentario_Z");
         }

      }

      public void gxTv_SdtParametro_Parametrocomentario_Z_SetNull( )
      {
         gxTv_SdtParametro_Parametrocomentario_Z = "";
         SetDirty("Parametrocomentario_Z");
         return  ;
      }

      public bool gxTv_SdtParametro_Parametrocomentario_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroDataInclusao_Z" )]
      [  XmlElement( ElementName = "ParametroDataInclusao_Z"  , IsNullable=true )]
      public string gxTpr_Parametrodatainclusao_Z_Nullable
      {
         get {
            if ( gxTv_SdtParametro_Parametrodatainclusao_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtParametro_Parametrodatainclusao_Z).value ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtParametro_Parametrodatainclusao_Z = DateTime.MinValue;
            else
               gxTv_SdtParametro_Parametrodatainclusao_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Parametrodatainclusao_Z
      {
         get {
            return gxTv_SdtParametro_Parametrodatainclusao_Z ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrodatainclusao_Z = value;
            SetDirty("Parametrodatainclusao_Z");
         }

      }

      public void gxTv_SdtParametro_Parametrodatainclusao_Z_SetNull( )
      {
         gxTv_SdtParametro_Parametrodatainclusao_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Parametrodatainclusao_Z");
         return  ;
      }

      public bool gxTv_SdtParametro_Parametrodatainclusao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroDataAlteracao_Z" )]
      [  XmlElement( ElementName = "ParametroDataAlteracao_Z"  , IsNullable=true )]
      public string gxTpr_Parametrodataalteracao_Z_Nullable
      {
         get {
            if ( gxTv_SdtParametro_Parametrodataalteracao_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtParametro_Parametrodataalteracao_Z).value ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtParametro_Parametrodataalteracao_Z = DateTime.MinValue;
            else
               gxTv_SdtParametro_Parametrodataalteracao_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Parametrodataalteracao_Z
      {
         get {
            return gxTv_SdtParametro_Parametrodataalteracao_Z ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrodataalteracao_Z = value;
            SetDirty("Parametrodataalteracao_Z");
         }

      }

      public void gxTv_SdtParametro_Parametrodataalteracao_Z_SetNull( )
      {
         gxTv_SdtParametro_Parametrodataalteracao_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Parametrodataalteracao_Z");
         return  ;
      }

      public bool gxTv_SdtParametro_Parametrodataalteracao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroUsuarioInclusao_Z" )]
      [  XmlElement( ElementName = "ParametroUsuarioInclusao_Z"   )]
      public string gxTpr_Parametrousuarioinclusao_Z
      {
         get {
            return gxTv_SdtParametro_Parametrousuarioinclusao_Z ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrousuarioinclusao_Z = value;
            SetDirty("Parametrousuarioinclusao_Z");
         }

      }

      public void gxTv_SdtParametro_Parametrousuarioinclusao_Z_SetNull( )
      {
         gxTv_SdtParametro_Parametrousuarioinclusao_Z = "";
         SetDirty("Parametrousuarioinclusao_Z");
         return  ;
      }

      public bool gxTv_SdtParametro_Parametrousuarioinclusao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroUsuarioAlteracao_Z" )]
      [  XmlElement( ElementName = "ParametroUsuarioAlteracao_Z"   )]
      public string gxTpr_Parametrousuarioalteracao_Z
      {
         get {
            return gxTv_SdtParametro_Parametrousuarioalteracao_Z ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametrousuarioalteracao_Z = value;
            SetDirty("Parametrousuarioalteracao_Z");
         }

      }

      public void gxTv_SdtParametro_Parametrousuarioalteracao_Z_SetNull( )
      {
         gxTv_SdtParametro_Parametrousuarioalteracao_Z = "";
         SetDirty("Parametrousuarioalteracao_Z");
         return  ;
      }

      public bool gxTv_SdtParametro_Parametrousuarioalteracao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroAtivo_Z" )]
      [  XmlElement( ElementName = "ParametroAtivo_Z"   )]
      public bool gxTpr_Parametroativo_Z
      {
         get {
            return gxTv_SdtParametro_Parametroativo_Z ;
         }

         set {
            gxTv_SdtParametro_N = 0;
            gxTv_SdtParametro_Parametroativo_Z = value;
            SetDirty("Parametroativo_Z");
         }

      }

      public void gxTv_SdtParametro_Parametroativo_Z_SetNull( )
      {
         gxTv_SdtParametro_Parametroativo_Z = false;
         SetDirty("Parametroativo_Z");
         return  ;
      }

      public bool gxTv_SdtParametro_Parametroativo_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtParametro_Parametrocod = "";
         gxTv_SdtParametro_N = 1;
         gxTv_SdtParametro_Parametrodescricao = "";
         gxTv_SdtParametro_Parametrovalor = "";
         gxTv_SdtParametro_Parametrocomentario = "";
         gxTv_SdtParametro_Parametrodatainclusao = DateTime.MinValue;
         gxTv_SdtParametro_Parametrodataalteracao = DateTime.MinValue;
         gxTv_SdtParametro_Parametrousuarioinclusao = "";
         gxTv_SdtParametro_Parametrousuarioalteracao = "";
         gxTv_SdtParametro_Mode = "";
         gxTv_SdtParametro_Parametrocod_Z = "";
         gxTv_SdtParametro_Parametrodescricao_Z = "";
         gxTv_SdtParametro_Parametrovalor_Z = "";
         gxTv_SdtParametro_Parametrocomentario_Z = "";
         gxTv_SdtParametro_Parametrodatainclusao_Z = DateTime.MinValue;
         gxTv_SdtParametro_Parametrodataalteracao_Z = DateTime.MinValue;
         gxTv_SdtParametro_Parametrousuarioinclusao_Z = "";
         gxTv_SdtParametro_Parametrousuarioalteracao_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "parametro", "GeneXus.Programs.parametro_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtParametro_N ;
      }

      private short gxTv_SdtParametro_N ;
      private short gxTv_SdtParametro_Initialized ;
      private string gxTv_SdtParametro_Parametrocod ;
      private string gxTv_SdtParametro_Parametrousuarioinclusao ;
      private string gxTv_SdtParametro_Parametrousuarioalteracao ;
      private string gxTv_SdtParametro_Mode ;
      private string gxTv_SdtParametro_Parametrocod_Z ;
      private string gxTv_SdtParametro_Parametrousuarioinclusao_Z ;
      private string gxTv_SdtParametro_Parametrousuarioalteracao_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtParametro_Parametrodatainclusao ;
      private DateTime gxTv_SdtParametro_Parametrodataalteracao ;
      private DateTime gxTv_SdtParametro_Parametrodatainclusao_Z ;
      private DateTime gxTv_SdtParametro_Parametrodataalteracao_Z ;
      private bool gxTv_SdtParametro_Parametroativo ;
      private bool gxTv_SdtParametro_Parametroativo_Z ;
      private string gxTv_SdtParametro_Parametrodescricao ;
      private string gxTv_SdtParametro_Parametrovalor ;
      private string gxTv_SdtParametro_Parametrocomentario ;
      private string gxTv_SdtParametro_Parametrodescricao_Z ;
      private string gxTv_SdtParametro_Parametrovalor_Z ;
      private string gxTv_SdtParametro_Parametrocomentario_Z ;
   }

   [DataContract(Name = @"Parametro", Namespace = "LGPD_Novo")]
   public class SdtParametro_RESTInterface : GxGenericCollectionItem<SdtParametro>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtParametro_RESTInterface( ) : base()
      {
      }

      public SdtParametro_RESTInterface( SdtParametro psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ParametroCod" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Parametrocod
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Parametrocod) ;
         }

         set {
            sdt.gxTpr_Parametrocod = value;
         }

      }

      [DataMember( Name = "ParametroDescricao" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Parametrodescricao
      {
         get {
            return sdt.gxTpr_Parametrodescricao ;
         }

         set {
            sdt.gxTpr_Parametrodescricao = value;
         }

      }

      [DataMember( Name = "ParametroValor" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Parametrovalor
      {
         get {
            return sdt.gxTpr_Parametrovalor ;
         }

         set {
            sdt.gxTpr_Parametrovalor = value;
         }

      }

      [DataMember( Name = "ParametroComentario" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Parametrocomentario
      {
         get {
            return sdt.gxTpr_Parametrocomentario ;
         }

         set {
            sdt.gxTpr_Parametrocomentario = value;
         }

      }

      [DataMember( Name = "ParametroDataInclusao" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Parametrodatainclusao
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Parametrodatainclusao) ;
         }

         set {
            sdt.gxTpr_Parametrodatainclusao = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "ParametroDataAlteracao" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Parametrodataalteracao
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Parametrodataalteracao) ;
         }

         set {
            sdt.gxTpr_Parametrodataalteracao = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "ParametroUsuarioInclusao" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Parametrousuarioinclusao
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Parametrousuarioinclusao) ;
         }

         set {
            sdt.gxTpr_Parametrousuarioinclusao = value;
         }

      }

      [DataMember( Name = "ParametroUsuarioAlteracao" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Parametrousuarioalteracao
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Parametrousuarioalteracao) ;
         }

         set {
            sdt.gxTpr_Parametrousuarioalteracao = value;
         }

      }

      [DataMember( Name = "ParametroAtivo" , Order = 8 )]
      [GxSeudo()]
      public bool gxTpr_Parametroativo
      {
         get {
            return sdt.gxTpr_Parametroativo ;
         }

         set {
            sdt.gxTpr_Parametroativo = value;
         }

      }

      public SdtParametro sdt
      {
         get {
            return (SdtParametro)Sdt ;
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
            sdt = new SdtParametro() ;
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

   [DataContract(Name = @"Parametro", Namespace = "LGPD_Novo")]
   public class SdtParametro_RESTLInterface : GxGenericCollectionItem<SdtParametro>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtParametro_RESTLInterface( ) : base()
      {
      }

      public SdtParametro_RESTLInterface( SdtParametro psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ParametroDescricao" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Parametrodescricao
      {
         get {
            return sdt.gxTpr_Parametrodescricao ;
         }

         set {
            sdt.gxTpr_Parametrodescricao = value;
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

      public SdtParametro sdt
      {
         get {
            return (SdtParametro)Sdt ;
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
            sdt = new SdtParametro() ;
         }
      }

   }

}
