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
   [XmlRoot(ElementName = "DocDicionario" )]
   [XmlType(TypeName =  "DocDicionario" , Namespace = "LGPD_Novo" )]
   [Serializable]
   public class SdtDocDicionario : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocDicionario( )
      {
      }

      public SdtDocDicionario( IGxContext context )
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

      public void Load( int AV98DocDicionarioId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV98DocDicionarioId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"DocDicionarioId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "DocDicionario");
         metadata.Set("BT", "DocDicionario");
         metadata.Set("PK", "[ \"DocDicionarioId\" ]");
         metadata.Set("PKAssigned", "[ \"DocDicionarioId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"DocumentoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"HipoteseTratamentoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"InformacaoId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Docdicionarioid_Z");
         state.Add("gxTpr_Informacaoid_Z");
         state.Add("gxTpr_Hipotesetratamentoid_Z");
         state.Add("gxTpr_Docdicionariosensivel_Z");
         state.Add("gxTpr_Docdicionariopodeeliminar_Z");
         state.Add("gxTpr_Docdicionariotransfinter_Z");
         state.Add("gxTpr_Docdicionariodatainclusao_Z_Nullable");
         state.Add("gxTpr_Informacaonome_Z");
         state.Add("gxTpr_Hipotesetratamentonome_Z");
         state.Add("gxTpr_Documentoid_Z");
         state.Add("gxTpr_Documentonome_Z");
         state.Add("gxTpr_Documentonome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtDocDicionario sdt;
         sdt = (SdtDocDicionario)(source);
         gxTv_SdtDocDicionario_Docdicionarioid = sdt.gxTv_SdtDocDicionario_Docdicionarioid ;
         gxTv_SdtDocDicionario_Informacaoid = sdt.gxTv_SdtDocDicionario_Informacaoid ;
         gxTv_SdtDocDicionario_Hipotesetratamentoid = sdt.gxTv_SdtDocDicionario_Hipotesetratamentoid ;
         gxTv_SdtDocDicionario_Docdicionariosensivel = sdt.gxTv_SdtDocDicionario_Docdicionariosensivel ;
         gxTv_SdtDocDicionario_Docdicionariopodeeliminar = sdt.gxTv_SdtDocDicionario_Docdicionariopodeeliminar ;
         gxTv_SdtDocDicionario_Docdicionariotransfinter = sdt.gxTv_SdtDocDicionario_Docdicionariotransfinter ;
         gxTv_SdtDocDicionario_Docdicionariofinalidade = sdt.gxTv_SdtDocDicionario_Docdicionariofinalidade ;
         gxTv_SdtDocDicionario_Docdicionariodatainclusao = sdt.gxTv_SdtDocDicionario_Docdicionariodatainclusao ;
         gxTv_SdtDocDicionario_Informacaonome = sdt.gxTv_SdtDocDicionario_Informacaonome ;
         gxTv_SdtDocDicionario_Hipotesetratamentonome = sdt.gxTv_SdtDocDicionario_Hipotesetratamentonome ;
         gxTv_SdtDocDicionario_Documentoid = sdt.gxTv_SdtDocDicionario_Documentoid ;
         gxTv_SdtDocDicionario_Documentonome = sdt.gxTv_SdtDocDicionario_Documentonome ;
         gxTv_SdtDocDicionario_Docdicionariotipotransfintergarantia = sdt.gxTv_SdtDocDicionario_Docdicionariotipotransfintergarantia ;
         gxTv_SdtDocDicionario_Mode = sdt.gxTv_SdtDocDicionario_Mode ;
         gxTv_SdtDocDicionario_Initialized = sdt.gxTv_SdtDocDicionario_Initialized ;
         gxTv_SdtDocDicionario_Docdicionarioid_Z = sdt.gxTv_SdtDocDicionario_Docdicionarioid_Z ;
         gxTv_SdtDocDicionario_Informacaoid_Z = sdt.gxTv_SdtDocDicionario_Informacaoid_Z ;
         gxTv_SdtDocDicionario_Hipotesetratamentoid_Z = sdt.gxTv_SdtDocDicionario_Hipotesetratamentoid_Z ;
         gxTv_SdtDocDicionario_Docdicionariosensivel_Z = sdt.gxTv_SdtDocDicionario_Docdicionariosensivel_Z ;
         gxTv_SdtDocDicionario_Docdicionariopodeeliminar_Z = sdt.gxTv_SdtDocDicionario_Docdicionariopodeeliminar_Z ;
         gxTv_SdtDocDicionario_Docdicionariotransfinter_Z = sdt.gxTv_SdtDocDicionario_Docdicionariotransfinter_Z ;
         gxTv_SdtDocDicionario_Docdicionariodatainclusao_Z = sdt.gxTv_SdtDocDicionario_Docdicionariodatainclusao_Z ;
         gxTv_SdtDocDicionario_Informacaonome_Z = sdt.gxTv_SdtDocDicionario_Informacaonome_Z ;
         gxTv_SdtDocDicionario_Hipotesetratamentonome_Z = sdt.gxTv_SdtDocDicionario_Hipotesetratamentonome_Z ;
         gxTv_SdtDocDicionario_Documentoid_Z = sdt.gxTv_SdtDocDicionario_Documentoid_Z ;
         gxTv_SdtDocDicionario_Documentonome_Z = sdt.gxTv_SdtDocDicionario_Documentonome_Z ;
         gxTv_SdtDocDicionario_Documentonome_N = sdt.gxTv_SdtDocDicionario_Documentonome_N ;
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
         AddObjectProperty("DocDicionarioId", gxTv_SdtDocDicionario_Docdicionarioid, false, includeNonInitialized);
         AddObjectProperty("InformacaoId", gxTv_SdtDocDicionario_Informacaoid, false, includeNonInitialized);
         AddObjectProperty("HipoteseTratamentoId", gxTv_SdtDocDicionario_Hipotesetratamentoid, false, includeNonInitialized);
         AddObjectProperty("DocDicionarioSensivel", gxTv_SdtDocDicionario_Docdicionariosensivel, false, includeNonInitialized);
         AddObjectProperty("DocDicionarioPodeEliminar", gxTv_SdtDocDicionario_Docdicionariopodeeliminar, false, includeNonInitialized);
         AddObjectProperty("DocDicionarioTransfInter", gxTv_SdtDocDicionario_Docdicionariotransfinter, false, includeNonInitialized);
         AddObjectProperty("DocDicionarioFinalidade", gxTv_SdtDocDicionario_Docdicionariofinalidade, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocDicionario_Docdicionariodatainclusao)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocDicionario_Docdicionariodatainclusao)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocDicionario_Docdicionariodatainclusao)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("DocDicionarioDataInclusao", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("InformacaoNome", gxTv_SdtDocDicionario_Informacaonome, false, includeNonInitialized);
         AddObjectProperty("HipoteseTratamentoNome", gxTv_SdtDocDicionario_Hipotesetratamentonome, false, includeNonInitialized);
         AddObjectProperty("DocumentoId", gxTv_SdtDocDicionario_Documentoid, false, includeNonInitialized);
         AddObjectProperty("DocumentoNome", gxTv_SdtDocDicionario_Documentonome, false, includeNonInitialized);
         AddObjectProperty("DocumentoNome_N", gxTv_SdtDocDicionario_Documentonome_N, false, includeNonInitialized);
         AddObjectProperty("DocDicionarioTipoTransfInterGarantia", gxTv_SdtDocDicionario_Docdicionariotipotransfintergarantia, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtDocDicionario_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtDocDicionario_Initialized, false, includeNonInitialized);
            AddObjectProperty("DocDicionarioId_Z", gxTv_SdtDocDicionario_Docdicionarioid_Z, false, includeNonInitialized);
            AddObjectProperty("InformacaoId_Z", gxTv_SdtDocDicionario_Informacaoid_Z, false, includeNonInitialized);
            AddObjectProperty("HipoteseTratamentoId_Z", gxTv_SdtDocDicionario_Hipotesetratamentoid_Z, false, includeNonInitialized);
            AddObjectProperty("DocDicionarioSensivel_Z", gxTv_SdtDocDicionario_Docdicionariosensivel_Z, false, includeNonInitialized);
            AddObjectProperty("DocDicionarioPodeEliminar_Z", gxTv_SdtDocDicionario_Docdicionariopodeeliminar_Z, false, includeNonInitialized);
            AddObjectProperty("DocDicionarioTransfInter_Z", gxTv_SdtDocDicionario_Docdicionariotransfinter_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtDocDicionario_Docdicionariodatainclusao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtDocDicionario_Docdicionariodatainclusao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtDocDicionario_Docdicionariodatainclusao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("DocDicionarioDataInclusao_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("InformacaoNome_Z", gxTv_SdtDocDicionario_Informacaonome_Z, false, includeNonInitialized);
            AddObjectProperty("HipoteseTratamentoNome_Z", gxTv_SdtDocDicionario_Hipotesetratamentonome_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoId_Z", gxTv_SdtDocDicionario_Documentoid_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoNome_Z", gxTv_SdtDocDicionario_Documentonome_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoNome_N", gxTv_SdtDocDicionario_Documentonome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtDocDicionario sdt )
      {
         if ( sdt.IsDirty("DocDicionarioId") )
         {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Docdicionarioid = sdt.gxTv_SdtDocDicionario_Docdicionarioid ;
         }
         if ( sdt.IsDirty("InformacaoId") )
         {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Informacaoid = sdt.gxTv_SdtDocDicionario_Informacaoid ;
         }
         if ( sdt.IsDirty("HipoteseTratamentoId") )
         {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Hipotesetratamentoid = sdt.gxTv_SdtDocDicionario_Hipotesetratamentoid ;
         }
         if ( sdt.IsDirty("DocDicionarioSensivel") )
         {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Docdicionariosensivel = sdt.gxTv_SdtDocDicionario_Docdicionariosensivel ;
         }
         if ( sdt.IsDirty("DocDicionarioPodeEliminar") )
         {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Docdicionariopodeeliminar = sdt.gxTv_SdtDocDicionario_Docdicionariopodeeliminar ;
         }
         if ( sdt.IsDirty("DocDicionarioTransfInter") )
         {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Docdicionariotransfinter = sdt.gxTv_SdtDocDicionario_Docdicionariotransfinter ;
         }
         if ( sdt.IsDirty("DocDicionarioFinalidade") )
         {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Docdicionariofinalidade = sdt.gxTv_SdtDocDicionario_Docdicionariofinalidade ;
         }
         if ( sdt.IsDirty("DocDicionarioDataInclusao") )
         {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Docdicionariodatainclusao = sdt.gxTv_SdtDocDicionario_Docdicionariodatainclusao ;
         }
         if ( sdt.IsDirty("InformacaoNome") )
         {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Informacaonome = sdt.gxTv_SdtDocDicionario_Informacaonome ;
         }
         if ( sdt.IsDirty("HipoteseTratamentoNome") )
         {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Hipotesetratamentonome = sdt.gxTv_SdtDocDicionario_Hipotesetratamentonome ;
         }
         if ( sdt.IsDirty("DocumentoId") )
         {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Documentoid = sdt.gxTv_SdtDocDicionario_Documentoid ;
         }
         if ( sdt.IsDirty("DocumentoNome") )
         {
            gxTv_SdtDocDicionario_Documentonome_N = (short)(sdt.gxTv_SdtDocDicionario_Documentonome_N);
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Documentonome = sdt.gxTv_SdtDocDicionario_Documentonome ;
         }
         if ( sdt.IsDirty("DocDicionarioTipoTransfInterGarantia") )
         {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Docdicionariotipotransfintergarantia = sdt.gxTv_SdtDocDicionario_Docdicionariotipotransfintergarantia ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "DocDicionarioId" )]
      [  XmlElement( ElementName = "DocDicionarioId"   )]
      public int gxTpr_Docdicionarioid
      {
         get {
            return gxTv_SdtDocDicionario_Docdicionarioid ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            if ( gxTv_SdtDocDicionario_Docdicionarioid != value )
            {
               gxTv_SdtDocDicionario_Mode = "INS";
               this.gxTv_SdtDocDicionario_Docdicionarioid_Z_SetNull( );
               this.gxTv_SdtDocDicionario_Informacaoid_Z_SetNull( );
               this.gxTv_SdtDocDicionario_Hipotesetratamentoid_Z_SetNull( );
               this.gxTv_SdtDocDicionario_Docdicionariosensivel_Z_SetNull( );
               this.gxTv_SdtDocDicionario_Docdicionariopodeeliminar_Z_SetNull( );
               this.gxTv_SdtDocDicionario_Docdicionariotransfinter_Z_SetNull( );
               this.gxTv_SdtDocDicionario_Docdicionariodatainclusao_Z_SetNull( );
               this.gxTv_SdtDocDicionario_Informacaonome_Z_SetNull( );
               this.gxTv_SdtDocDicionario_Hipotesetratamentonome_Z_SetNull( );
               this.gxTv_SdtDocDicionario_Documentoid_Z_SetNull( );
               this.gxTv_SdtDocDicionario_Documentonome_Z_SetNull( );
            }
            gxTv_SdtDocDicionario_Docdicionarioid = value;
            SetDirty("Docdicionarioid");
         }

      }

      [  SoapElement( ElementName = "InformacaoId" )]
      [  XmlElement( ElementName = "InformacaoId"   )]
      public int gxTpr_Informacaoid
      {
         get {
            return gxTv_SdtDocDicionario_Informacaoid ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Informacaoid = value;
            SetDirty("Informacaoid");
         }

      }

      [  SoapElement( ElementName = "HipoteseTratamentoId" )]
      [  XmlElement( ElementName = "HipoteseTratamentoId"   )]
      public int gxTpr_Hipotesetratamentoid
      {
         get {
            return gxTv_SdtDocDicionario_Hipotesetratamentoid ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Hipotesetratamentoid = value;
            SetDirty("Hipotesetratamentoid");
         }

      }

      [  SoapElement( ElementName = "DocDicionarioSensivel" )]
      [  XmlElement( ElementName = "DocDicionarioSensivel"   )]
      public bool gxTpr_Docdicionariosensivel
      {
         get {
            return gxTv_SdtDocDicionario_Docdicionariosensivel ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Docdicionariosensivel = value;
            SetDirty("Docdicionariosensivel");
         }

      }

      [  SoapElement( ElementName = "DocDicionarioPodeEliminar" )]
      [  XmlElement( ElementName = "DocDicionarioPodeEliminar"   )]
      public bool gxTpr_Docdicionariopodeeliminar
      {
         get {
            return gxTv_SdtDocDicionario_Docdicionariopodeeliminar ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Docdicionariopodeeliminar = value;
            SetDirty("Docdicionariopodeeliminar");
         }

      }

      [  SoapElement( ElementName = "DocDicionarioTransfInter" )]
      [  XmlElement( ElementName = "DocDicionarioTransfInter"   )]
      public bool gxTpr_Docdicionariotransfinter
      {
         get {
            return gxTv_SdtDocDicionario_Docdicionariotransfinter ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Docdicionariotransfinter = value;
            SetDirty("Docdicionariotransfinter");
         }

      }

      [  SoapElement( ElementName = "DocDicionarioFinalidade" )]
      [  XmlElement( ElementName = "DocDicionarioFinalidade"   )]
      public string gxTpr_Docdicionariofinalidade
      {
         get {
            return gxTv_SdtDocDicionario_Docdicionariofinalidade ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Docdicionariofinalidade = value;
            SetDirty("Docdicionariofinalidade");
         }

      }

      [  SoapElement( ElementName = "DocDicionarioDataInclusao" )]
      [  XmlElement( ElementName = "DocDicionarioDataInclusao"  , IsNullable=true )]
      public string gxTpr_Docdicionariodatainclusao_Nullable
      {
         get {
            if ( gxTv_SdtDocDicionario_Docdicionariodatainclusao == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocDicionario_Docdicionariodatainclusao).value ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocDicionario_Docdicionariodatainclusao = DateTime.MinValue;
            else
               gxTv_SdtDocDicionario_Docdicionariodatainclusao = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Docdicionariodatainclusao
      {
         get {
            return gxTv_SdtDocDicionario_Docdicionariodatainclusao ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Docdicionariodatainclusao = value;
            SetDirty("Docdicionariodatainclusao");
         }

      }

      [  SoapElement( ElementName = "InformacaoNome" )]
      [  XmlElement( ElementName = "InformacaoNome"   )]
      public string gxTpr_Informacaonome
      {
         get {
            return gxTv_SdtDocDicionario_Informacaonome ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Informacaonome = value;
            SetDirty("Informacaonome");
         }

      }

      [  SoapElement( ElementName = "HipoteseTratamentoNome" )]
      [  XmlElement( ElementName = "HipoteseTratamentoNome"   )]
      public string gxTpr_Hipotesetratamentonome
      {
         get {
            return gxTv_SdtDocDicionario_Hipotesetratamentonome ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Hipotesetratamentonome = value;
            SetDirty("Hipotesetratamentonome");
         }

      }

      [  SoapElement( ElementName = "DocumentoId" )]
      [  XmlElement( ElementName = "DocumentoId"   )]
      public int gxTpr_Documentoid
      {
         get {
            return gxTv_SdtDocDicionario_Documentoid ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Documentoid = value;
            SetDirty("Documentoid");
         }

      }

      [  SoapElement( ElementName = "DocumentoNome" )]
      [  XmlElement( ElementName = "DocumentoNome"   )]
      public string gxTpr_Documentonome
      {
         get {
            return gxTv_SdtDocDicionario_Documentonome ;
         }

         set {
            gxTv_SdtDocDicionario_Documentonome_N = 0;
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Documentonome = value;
            SetDirty("Documentonome");
         }

      }

      public void gxTv_SdtDocDicionario_Documentonome_SetNull( )
      {
         gxTv_SdtDocDicionario_Documentonome_N = 1;
         gxTv_SdtDocDicionario_Documentonome = "";
         SetDirty("Documentonome");
         return  ;
      }

      public bool gxTv_SdtDocDicionario_Documentonome_IsNull( )
      {
         return (gxTv_SdtDocDicionario_Documentonome_N==1) ;
      }

      [  SoapElement( ElementName = "DocDicionarioTipoTransfInterGarantia" )]
      [  XmlElement( ElementName = "DocDicionarioTipoTransfInterGarantia"   )]
      public string gxTpr_Docdicionariotipotransfintergarantia
      {
         get {
            return gxTv_SdtDocDicionario_Docdicionariotipotransfintergarantia ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Docdicionariotipotransfintergarantia = value;
            SetDirty("Docdicionariotipotransfintergarantia");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtDocDicionario_Mode ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtDocDicionario_Mode_SetNull( )
      {
         gxTv_SdtDocDicionario_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtDocDicionario_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtDocDicionario_Initialized ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtDocDicionario_Initialized_SetNull( )
      {
         gxTv_SdtDocDicionario_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtDocDicionario_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDicionarioId_Z" )]
      [  XmlElement( ElementName = "DocDicionarioId_Z"   )]
      public int gxTpr_Docdicionarioid_Z
      {
         get {
            return gxTv_SdtDocDicionario_Docdicionarioid_Z ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Docdicionarioid_Z = value;
            SetDirty("Docdicionarioid_Z");
         }

      }

      public void gxTv_SdtDocDicionario_Docdicionarioid_Z_SetNull( )
      {
         gxTv_SdtDocDicionario_Docdicionarioid_Z = 0;
         SetDirty("Docdicionarioid_Z");
         return  ;
      }

      public bool gxTv_SdtDocDicionario_Docdicionarioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InformacaoId_Z" )]
      [  XmlElement( ElementName = "InformacaoId_Z"   )]
      public int gxTpr_Informacaoid_Z
      {
         get {
            return gxTv_SdtDocDicionario_Informacaoid_Z ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Informacaoid_Z = value;
            SetDirty("Informacaoid_Z");
         }

      }

      public void gxTv_SdtDocDicionario_Informacaoid_Z_SetNull( )
      {
         gxTv_SdtDocDicionario_Informacaoid_Z = 0;
         SetDirty("Informacaoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocDicionario_Informacaoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "HipoteseTratamentoId_Z" )]
      [  XmlElement( ElementName = "HipoteseTratamentoId_Z"   )]
      public int gxTpr_Hipotesetratamentoid_Z
      {
         get {
            return gxTv_SdtDocDicionario_Hipotesetratamentoid_Z ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Hipotesetratamentoid_Z = value;
            SetDirty("Hipotesetratamentoid_Z");
         }

      }

      public void gxTv_SdtDocDicionario_Hipotesetratamentoid_Z_SetNull( )
      {
         gxTv_SdtDocDicionario_Hipotesetratamentoid_Z = 0;
         SetDirty("Hipotesetratamentoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocDicionario_Hipotesetratamentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDicionarioSensivel_Z" )]
      [  XmlElement( ElementName = "DocDicionarioSensivel_Z"   )]
      public bool gxTpr_Docdicionariosensivel_Z
      {
         get {
            return gxTv_SdtDocDicionario_Docdicionariosensivel_Z ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Docdicionariosensivel_Z = value;
            SetDirty("Docdicionariosensivel_Z");
         }

      }

      public void gxTv_SdtDocDicionario_Docdicionariosensivel_Z_SetNull( )
      {
         gxTv_SdtDocDicionario_Docdicionariosensivel_Z = false;
         SetDirty("Docdicionariosensivel_Z");
         return  ;
      }

      public bool gxTv_SdtDocDicionario_Docdicionariosensivel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDicionarioPodeEliminar_Z" )]
      [  XmlElement( ElementName = "DocDicionarioPodeEliminar_Z"   )]
      public bool gxTpr_Docdicionariopodeeliminar_Z
      {
         get {
            return gxTv_SdtDocDicionario_Docdicionariopodeeliminar_Z ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Docdicionariopodeeliminar_Z = value;
            SetDirty("Docdicionariopodeeliminar_Z");
         }

      }

      public void gxTv_SdtDocDicionario_Docdicionariopodeeliminar_Z_SetNull( )
      {
         gxTv_SdtDocDicionario_Docdicionariopodeeliminar_Z = false;
         SetDirty("Docdicionariopodeeliminar_Z");
         return  ;
      }

      public bool gxTv_SdtDocDicionario_Docdicionariopodeeliminar_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDicionarioTransfInter_Z" )]
      [  XmlElement( ElementName = "DocDicionarioTransfInter_Z"   )]
      public bool gxTpr_Docdicionariotransfinter_Z
      {
         get {
            return gxTv_SdtDocDicionario_Docdicionariotransfinter_Z ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Docdicionariotransfinter_Z = value;
            SetDirty("Docdicionariotransfinter_Z");
         }

      }

      public void gxTv_SdtDocDicionario_Docdicionariotransfinter_Z_SetNull( )
      {
         gxTv_SdtDocDicionario_Docdicionariotransfinter_Z = false;
         SetDirty("Docdicionariotransfinter_Z");
         return  ;
      }

      public bool gxTv_SdtDocDicionario_Docdicionariotransfinter_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocDicionarioDataInclusao_Z" )]
      [  XmlElement( ElementName = "DocDicionarioDataInclusao_Z"  , IsNullable=true )]
      public string gxTpr_Docdicionariodatainclusao_Z_Nullable
      {
         get {
            if ( gxTv_SdtDocDicionario_Docdicionariodatainclusao_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtDocDicionario_Docdicionariodatainclusao_Z).value ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtDocDicionario_Docdicionariodatainclusao_Z = DateTime.MinValue;
            else
               gxTv_SdtDocDicionario_Docdicionariodatainclusao_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Docdicionariodatainclusao_Z
      {
         get {
            return gxTv_SdtDocDicionario_Docdicionariodatainclusao_Z ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Docdicionariodatainclusao_Z = value;
            SetDirty("Docdicionariodatainclusao_Z");
         }

      }

      public void gxTv_SdtDocDicionario_Docdicionariodatainclusao_Z_SetNull( )
      {
         gxTv_SdtDocDicionario_Docdicionariodatainclusao_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Docdicionariodatainclusao_Z");
         return  ;
      }

      public bool gxTv_SdtDocDicionario_Docdicionariodatainclusao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InformacaoNome_Z" )]
      [  XmlElement( ElementName = "InformacaoNome_Z"   )]
      public string gxTpr_Informacaonome_Z
      {
         get {
            return gxTv_SdtDocDicionario_Informacaonome_Z ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Informacaonome_Z = value;
            SetDirty("Informacaonome_Z");
         }

      }

      public void gxTv_SdtDocDicionario_Informacaonome_Z_SetNull( )
      {
         gxTv_SdtDocDicionario_Informacaonome_Z = "";
         SetDirty("Informacaonome_Z");
         return  ;
      }

      public bool gxTv_SdtDocDicionario_Informacaonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "HipoteseTratamentoNome_Z" )]
      [  XmlElement( ElementName = "HipoteseTratamentoNome_Z"   )]
      public string gxTpr_Hipotesetratamentonome_Z
      {
         get {
            return gxTv_SdtDocDicionario_Hipotesetratamentonome_Z ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Hipotesetratamentonome_Z = value;
            SetDirty("Hipotesetratamentonome_Z");
         }

      }

      public void gxTv_SdtDocDicionario_Hipotesetratamentonome_Z_SetNull( )
      {
         gxTv_SdtDocDicionario_Hipotesetratamentonome_Z = "";
         SetDirty("Hipotesetratamentonome_Z");
         return  ;
      }

      public bool gxTv_SdtDocDicionario_Hipotesetratamentonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoId_Z" )]
      [  XmlElement( ElementName = "DocumentoId_Z"   )]
      public int gxTpr_Documentoid_Z
      {
         get {
            return gxTv_SdtDocDicionario_Documentoid_Z ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Documentoid_Z = value;
            SetDirty("Documentoid_Z");
         }

      }

      public void gxTv_SdtDocDicionario_Documentoid_Z_SetNull( )
      {
         gxTv_SdtDocDicionario_Documentoid_Z = 0;
         SetDirty("Documentoid_Z");
         return  ;
      }

      public bool gxTv_SdtDocDicionario_Documentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoNome_Z" )]
      [  XmlElement( ElementName = "DocumentoNome_Z"   )]
      public string gxTpr_Documentonome_Z
      {
         get {
            return gxTv_SdtDocDicionario_Documentonome_Z ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Documentonome_Z = value;
            SetDirty("Documentonome_Z");
         }

      }

      public void gxTv_SdtDocDicionario_Documentonome_Z_SetNull( )
      {
         gxTv_SdtDocDicionario_Documentonome_Z = "";
         SetDirty("Documentonome_Z");
         return  ;
      }

      public bool gxTv_SdtDocDicionario_Documentonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoNome_N" )]
      [  XmlElement( ElementName = "DocumentoNome_N"   )]
      public short gxTpr_Documentonome_N
      {
         get {
            return gxTv_SdtDocDicionario_Documentonome_N ;
         }

         set {
            gxTv_SdtDocDicionario_N = 0;
            gxTv_SdtDocDicionario_Documentonome_N = value;
            SetDirty("Documentonome_N");
         }

      }

      public void gxTv_SdtDocDicionario_Documentonome_N_SetNull( )
      {
         gxTv_SdtDocDicionario_Documentonome_N = 0;
         SetDirty("Documentonome_N");
         return  ;
      }

      public bool gxTv_SdtDocDicionario_Documentonome_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtDocDicionario_N = 1;
         gxTv_SdtDocDicionario_Docdicionariofinalidade = "";
         gxTv_SdtDocDicionario_Docdicionariodatainclusao = DateTime.MinValue;
         gxTv_SdtDocDicionario_Informacaonome = "";
         gxTv_SdtDocDicionario_Hipotesetratamentonome = "";
         gxTv_SdtDocDicionario_Documentonome = "";
         gxTv_SdtDocDicionario_Docdicionariotipotransfintergarantia = "";
         gxTv_SdtDocDicionario_Mode = "";
         gxTv_SdtDocDicionario_Docdicionariodatainclusao_Z = DateTime.MinValue;
         gxTv_SdtDocDicionario_Informacaonome_Z = "";
         gxTv_SdtDocDicionario_Hipotesetratamentonome_Z = "";
         gxTv_SdtDocDicionario_Documentonome_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "docdicionario", "GeneXus.Programs.docdicionario_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtDocDicionario_N ;
      }

      private short gxTv_SdtDocDicionario_N ;
      private short gxTv_SdtDocDicionario_Initialized ;
      private short gxTv_SdtDocDicionario_Documentonome_N ;
      private int gxTv_SdtDocDicionario_Docdicionarioid ;
      private int gxTv_SdtDocDicionario_Informacaoid ;
      private int gxTv_SdtDocDicionario_Hipotesetratamentoid ;
      private int gxTv_SdtDocDicionario_Documentoid ;
      private int gxTv_SdtDocDicionario_Docdicionarioid_Z ;
      private int gxTv_SdtDocDicionario_Informacaoid_Z ;
      private int gxTv_SdtDocDicionario_Hipotesetratamentoid_Z ;
      private int gxTv_SdtDocDicionario_Documentoid_Z ;
      private string gxTv_SdtDocDicionario_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtDocDicionario_Docdicionariodatainclusao ;
      private DateTime gxTv_SdtDocDicionario_Docdicionariodatainclusao_Z ;
      private bool gxTv_SdtDocDicionario_Docdicionariosensivel ;
      private bool gxTv_SdtDocDicionario_Docdicionariopodeeliminar ;
      private bool gxTv_SdtDocDicionario_Docdicionariotransfinter ;
      private bool gxTv_SdtDocDicionario_Docdicionariosensivel_Z ;
      private bool gxTv_SdtDocDicionario_Docdicionariopodeeliminar_Z ;
      private bool gxTv_SdtDocDicionario_Docdicionariotransfinter_Z ;
      private string gxTv_SdtDocDicionario_Docdicionariofinalidade ;
      private string gxTv_SdtDocDicionario_Docdicionariotipotransfintergarantia ;
      private string gxTv_SdtDocDicionario_Informacaonome ;
      private string gxTv_SdtDocDicionario_Hipotesetratamentonome ;
      private string gxTv_SdtDocDicionario_Documentonome ;
      private string gxTv_SdtDocDicionario_Informacaonome_Z ;
      private string gxTv_SdtDocDicionario_Hipotesetratamentonome_Z ;
      private string gxTv_SdtDocDicionario_Documentonome_Z ;
   }

   [DataContract(Name = @"DocDicionario", Namespace = "LGPD_Novo")]
   public class SdtDocDicionario_RESTInterface : GxGenericCollectionItem<SdtDocDicionario>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocDicionario_RESTInterface( ) : base()
      {
      }

      public SdtDocDicionario_RESTInterface( SdtDocDicionario psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DocDicionarioId" , Order = 0 )]
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

      [DataMember( Name = "InformacaoId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Informacaoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Informacaoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Informacaoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "HipoteseTratamentoId" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Hipotesetratamentoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Hipotesetratamentoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Hipotesetratamentoid = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "DocDicionarioSensivel" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Docdicionariosensivel
      {
         get {
            return sdt.gxTpr_Docdicionariosensivel ;
         }

         set {
            sdt.gxTpr_Docdicionariosensivel = value;
         }

      }

      [DataMember( Name = "DocDicionarioPodeEliminar" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Docdicionariopodeeliminar
      {
         get {
            return sdt.gxTpr_Docdicionariopodeeliminar ;
         }

         set {
            sdt.gxTpr_Docdicionariopodeeliminar = value;
         }

      }

      [DataMember( Name = "DocDicionarioTransfInter" , Order = 5 )]
      [GxSeudo()]
      public bool gxTpr_Docdicionariotransfinter
      {
         get {
            return sdt.gxTpr_Docdicionariotransfinter ;
         }

         set {
            sdt.gxTpr_Docdicionariotransfinter = value;
         }

      }

      [DataMember( Name = "DocDicionarioFinalidade" , Order = 6 )]
      public string gxTpr_Docdicionariofinalidade
      {
         get {
            return sdt.gxTpr_Docdicionariofinalidade ;
         }

         set {
            sdt.gxTpr_Docdicionariofinalidade = value;
         }

      }

      [DataMember( Name = "DocDicionarioDataInclusao" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Docdicionariodatainclusao
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Docdicionariodatainclusao) ;
         }

         set {
            sdt.gxTpr_Docdicionariodatainclusao = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "InformacaoNome" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Informacaonome
      {
         get {
            return sdt.gxTpr_Informacaonome ;
         }

         set {
            sdt.gxTpr_Informacaonome = value;
         }

      }

      [DataMember( Name = "HipoteseTratamentoNome" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Hipotesetratamentonome
      {
         get {
            return sdt.gxTpr_Hipotesetratamentonome ;
         }

         set {
            sdt.gxTpr_Hipotesetratamentonome = value;
         }

      }

      [DataMember( Name = "DocumentoId" , Order = 10 )]
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

      [DataMember( Name = "DocumentoNome" , Order = 11 )]
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

      [DataMember( Name = "DocDicionarioTipoTransfInterGarantia" , Order = 12 )]
      public string gxTpr_Docdicionariotipotransfintergarantia
      {
         get {
            return sdt.gxTpr_Docdicionariotipotransfintergarantia ;
         }

         set {
            sdt.gxTpr_Docdicionariotipotransfintergarantia = value;
         }

      }

      public SdtDocDicionario sdt
      {
         get {
            return (SdtDocDicionario)Sdt ;
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
            sdt = new SdtDocDicionario() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 13 )]
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

   [DataContract(Name = @"DocDicionario", Namespace = "LGPD_Novo")]
   public class SdtDocDicionario_RESTLInterface : GxGenericCollectionItem<SdtDocDicionario>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtDocDicionario_RESTLInterface( ) : base()
      {
      }

      public SdtDocDicionario_RESTLInterface( SdtDocDicionario psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DocDicionarioSensivel" , Order = 0 )]
      [GxSeudo()]
      public bool gxTpr_Docdicionariosensivel
      {
         get {
            return sdt.gxTpr_Docdicionariosensivel ;
         }

         set {
            sdt.gxTpr_Docdicionariosensivel = value;
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

      public SdtDocDicionario sdt
      {
         get {
            return (SdtDocDicionario)Sdt ;
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
            sdt = new SdtDocDicionario() ;
         }
      }

   }

}
