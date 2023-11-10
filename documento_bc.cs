using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class documento_bc : GXHttpHandler, IGxSilentTrn
   {
      public documento_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public documento_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow1346( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1346( ) ;
         standaloneModal( ) ;
         AddRow1346( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E11132 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z75DocumentoId = A75DocumentoId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_130( )
      {
         BeforeValidate1346( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1346( ) ;
            }
            else
            {
               CheckExtendedTable1346( ) ;
               if ( AnyError == 0 )
               {
                  ZM1346( 17) ;
                  ZM1346( 18) ;
                  ZM1346( 19) ;
                  ZM1346( 20) ;
                  ZM1346( 21) ;
                  ZM1346( 22) ;
                  ZM1346( 23) ;
                  ZM1346( 24) ;
                  ZM1346( 25) ;
                  ZM1346( 26) ;
                  ZM1346( 27) ;
                  ZM1346( 28) ;
                  ZM1346( 29) ;
               }
               CloseExtendedTableCursors1346( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12132( )
      {
         /* Start Routine */
         returnInSub = false;
         AV57count = 0;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV61Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV62GXV1 = 1;
            while ( AV62GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV24TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV62GXV1));
               if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "SubprocessoId") == 0 )
               {
                  AV13Insert_SubprocessoId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "EncarregadoId") == 0 )
               {
                  AV14Insert_EncarregadoId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "PersonaId") == 0 )
               {
                  AV15Insert_PersonaId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "CategoriaId") == 0 )
               {
                  AV16Insert_CategoriaId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "TipoDadoId") == 0 )
               {
                  AV17Insert_TipoDadoId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "FerramentaColetaId") == 0 )
               {
                  AV18Insert_FerramentaColetaId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "AbrangenciaGeograficaId") == 0 )
               {
                  AV19Insert_AbrangenciaGeograficaId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "FrequenciaTratamentoId") == 0 )
               {
                  AV20Insert_FrequenciaTratamentoId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "TipoDescarteId") == 0 )
               {
                  AV21Insert_TipoDescarteId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "TempoRetencaoId") == 0 )
               {
                  AV22Insert_TempoRetencaoId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "DocumentoProcessoId") == 0 )
               {
                  AV53Insert_DocumentoProcessoId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "DocumentoControladorId") == 0 )
               {
                  AV58Insert_DocumentoControladorId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               else if ( StringUtil.StrCmp(AV24TrnContextAtt.gxTpr_Attributename, "AreaResponsavelId") == 0 )
               {
                  AV59Insert_AreaResponsavelId = (int)(NumberUtil.Val( AV24TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               AV62GXV1 = (int)(AV62GXV1+1);
            }
         }
      }

      protected void E11132( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1346( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z109DocumentoDataAlteracao = A109DocumentoDataAlteracao;
            Z142DocumentoUsuarioAlteracao = A142DocumentoUsuarioAlteracao;
            Z76DocumentoNome = A76DocumentoNome;
            Z77DocumentoFinalidadeTratamento = A77DocumentoFinalidadeTratamento;
            Z79DocumentoBaseLegalNorm = A79DocumentoBaseLegalNorm;
            Z80DocumentoBaseLegalNormIntExt = A80DocumentoBaseLegalNormIntExt;
            Z78DocumentoPrevColetaDados = A78DocumentoPrevColetaDados;
            Z81DocumentoDadosCriancaAdolesc = A81DocumentoDadosCriancaAdolesc;
            Z82DocumentoDadosGrupoVul = A82DocumentoDadosGrupoVul;
            Z85DocumentoAtivo = A85DocumentoAtivo;
            Z105DocumentoOperador = A105DocumentoOperador;
            Z108DocumentoDataInclusao = A108DocumentoDataInclusao;
            Z141DocumentoUsuarioInclusao = A141DocumentoUsuarioInclusao;
            Z143DocumentoIsOperador = A143DocumentoIsOperador;
            Z20SubprocessoId = A20SubprocessoId;
            Z7EncarregadoId = A7EncarregadoId;
            Z13PersonaId = A13PersonaId;
            Z27CategoriaId = A27CategoriaId;
            Z30TipoDadoId = A30TipoDadoId;
            Z33FerramentaColetaId = A33FerramentaColetaId;
            Z36AbrangenciaGeograficaId = A36AbrangenciaGeograficaId;
            Z39FrequenciaTratamentoId = A39FrequenciaTratamentoId;
            Z45TipoDescarteId = A45TipoDescarteId;
            Z48TempoRetencaoId = A48TempoRetencaoId;
            Z24AreaResponsavelId = A24AreaResponsavelId;
            Z106DocumentoProcessoId = A106DocumentoProcessoId;
            Z110DocumentoControladorId = A110DocumentoControladorId;
         }
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 21 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 22 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 24 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 25 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 26 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 27 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 28 ) || ( GX_JID == 0 ) )
         {
            Z107DocumentoProcessoNome = A107DocumentoProcessoNome;
         }
         if ( ( GX_JID == 29 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -16 )
         {
            Z75DocumentoId = A75DocumentoId;
            Z109DocumentoDataAlteracao = A109DocumentoDataAlteracao;
            Z142DocumentoUsuarioAlteracao = A142DocumentoUsuarioAlteracao;
            Z76DocumentoNome = A76DocumentoNome;
            Z77DocumentoFinalidadeTratamento = A77DocumentoFinalidadeTratamento;
            Z79DocumentoBaseLegalNorm = A79DocumentoBaseLegalNorm;
            Z80DocumentoBaseLegalNormIntExt = A80DocumentoBaseLegalNormIntExt;
            Z83DocumentoMedidaSegurancaDesc = A83DocumentoMedidaSegurancaDesc;
            Z78DocumentoPrevColetaDados = A78DocumentoPrevColetaDados;
            Z81DocumentoDadosCriancaAdolesc = A81DocumentoDadosCriancaAdolesc;
            Z82DocumentoDadosGrupoVul = A82DocumentoDadosGrupoVul;
            Z84DocumentoFluxoTratDadosDesc = A84DocumentoFluxoTratDadosDesc;
            Z85DocumentoAtivo = A85DocumentoAtivo;
            Z105DocumentoOperador = A105DocumentoOperador;
            Z108DocumentoDataInclusao = A108DocumentoDataInclusao;
            Z141DocumentoUsuarioInclusao = A141DocumentoUsuarioInclusao;
            Z143DocumentoIsOperador = A143DocumentoIsOperador;
            Z20SubprocessoId = A20SubprocessoId;
            Z7EncarregadoId = A7EncarregadoId;
            Z13PersonaId = A13PersonaId;
            Z27CategoriaId = A27CategoriaId;
            Z30TipoDadoId = A30TipoDadoId;
            Z33FerramentaColetaId = A33FerramentaColetaId;
            Z36AbrangenciaGeograficaId = A36AbrangenciaGeograficaId;
            Z39FrequenciaTratamentoId = A39FrequenciaTratamentoId;
            Z45TipoDescarteId = A45TipoDescarteId;
            Z48TempoRetencaoId = A48TempoRetencaoId;
            Z24AreaResponsavelId = A24AreaResponsavelId;
            Z106DocumentoProcessoId = A106DocumentoProcessoId;
            Z110DocumentoControladorId = A110DocumentoControladorId;
            Z107DocumentoProcessoNome = A107DocumentoProcessoNome;
         }
      }

      protected void standaloneNotModal( )
      {
         AV61Pgmname = "Documento_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A85DocumentoAtivo) && ( Gx_BScreen == 0 ) )
         {
            A85DocumentoAtivo = true;
            n85DocumentoAtivo = false;
         }
         if ( IsIns( )  && (DateTime.MinValue==A108DocumentoDataInclusao) && ( Gx_BScreen == 0 ) )
         {
            A108DocumentoDataInclusao = DateTimeUtil.ServerNow( context, pr_default);
            n108DocumentoDataInclusao = false;
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A141DocumentoUsuarioInclusao)) && ( Gx_BScreen == 0 ) )
         {
            A141DocumentoUsuarioInclusao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n141DocumentoUsuarioInclusao = false;
         }
         if ( IsIns( )  && (false==A143DocumentoIsOperador) && ( Gx_BScreen == 0 ) )
         {
            A143DocumentoIsOperador = false;
            n143DocumentoIsOperador = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1346( )
      {
         /* Using cursor BC001317 */
         pr_default.execute(15, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound46 = 1;
            A109DocumentoDataAlteracao = BC001317_A109DocumentoDataAlteracao[0];
            n109DocumentoDataAlteracao = BC001317_n109DocumentoDataAlteracao[0];
            A142DocumentoUsuarioAlteracao = BC001317_A142DocumentoUsuarioAlteracao[0];
            n142DocumentoUsuarioAlteracao = BC001317_n142DocumentoUsuarioAlteracao[0];
            A76DocumentoNome = BC001317_A76DocumentoNome[0];
            n76DocumentoNome = BC001317_n76DocumentoNome[0];
            A77DocumentoFinalidadeTratamento = BC001317_A77DocumentoFinalidadeTratamento[0];
            n77DocumentoFinalidadeTratamento = BC001317_n77DocumentoFinalidadeTratamento[0];
            A79DocumentoBaseLegalNorm = BC001317_A79DocumentoBaseLegalNorm[0];
            n79DocumentoBaseLegalNorm = BC001317_n79DocumentoBaseLegalNorm[0];
            A80DocumentoBaseLegalNormIntExt = BC001317_A80DocumentoBaseLegalNormIntExt[0];
            n80DocumentoBaseLegalNormIntExt = BC001317_n80DocumentoBaseLegalNormIntExt[0];
            A83DocumentoMedidaSegurancaDesc = BC001317_A83DocumentoMedidaSegurancaDesc[0];
            n83DocumentoMedidaSegurancaDesc = BC001317_n83DocumentoMedidaSegurancaDesc[0];
            A78DocumentoPrevColetaDados = BC001317_A78DocumentoPrevColetaDados[0];
            n78DocumentoPrevColetaDados = BC001317_n78DocumentoPrevColetaDados[0];
            A81DocumentoDadosCriancaAdolesc = BC001317_A81DocumentoDadosCriancaAdolesc[0];
            n81DocumentoDadosCriancaAdolesc = BC001317_n81DocumentoDadosCriancaAdolesc[0];
            A82DocumentoDadosGrupoVul = BC001317_A82DocumentoDadosGrupoVul[0];
            n82DocumentoDadosGrupoVul = BC001317_n82DocumentoDadosGrupoVul[0];
            A84DocumentoFluxoTratDadosDesc = BC001317_A84DocumentoFluxoTratDadosDesc[0];
            n84DocumentoFluxoTratDadosDesc = BC001317_n84DocumentoFluxoTratDadosDesc[0];
            A85DocumentoAtivo = BC001317_A85DocumentoAtivo[0];
            n85DocumentoAtivo = BC001317_n85DocumentoAtivo[0];
            A105DocumentoOperador = BC001317_A105DocumentoOperador[0];
            n105DocumentoOperador = BC001317_n105DocumentoOperador[0];
            A107DocumentoProcessoNome = BC001317_A107DocumentoProcessoNome[0];
            A108DocumentoDataInclusao = BC001317_A108DocumentoDataInclusao[0];
            n108DocumentoDataInclusao = BC001317_n108DocumentoDataInclusao[0];
            A141DocumentoUsuarioInclusao = BC001317_A141DocumentoUsuarioInclusao[0];
            n141DocumentoUsuarioInclusao = BC001317_n141DocumentoUsuarioInclusao[0];
            A143DocumentoIsOperador = BC001317_A143DocumentoIsOperador[0];
            n143DocumentoIsOperador = BC001317_n143DocumentoIsOperador[0];
            A20SubprocessoId = BC001317_A20SubprocessoId[0];
            n20SubprocessoId = BC001317_n20SubprocessoId[0];
            A7EncarregadoId = BC001317_A7EncarregadoId[0];
            n7EncarregadoId = BC001317_n7EncarregadoId[0];
            A13PersonaId = BC001317_A13PersonaId[0];
            n13PersonaId = BC001317_n13PersonaId[0];
            A27CategoriaId = BC001317_A27CategoriaId[0];
            n27CategoriaId = BC001317_n27CategoriaId[0];
            A30TipoDadoId = BC001317_A30TipoDadoId[0];
            n30TipoDadoId = BC001317_n30TipoDadoId[0];
            A33FerramentaColetaId = BC001317_A33FerramentaColetaId[0];
            n33FerramentaColetaId = BC001317_n33FerramentaColetaId[0];
            A36AbrangenciaGeograficaId = BC001317_A36AbrangenciaGeograficaId[0];
            n36AbrangenciaGeograficaId = BC001317_n36AbrangenciaGeograficaId[0];
            A39FrequenciaTratamentoId = BC001317_A39FrequenciaTratamentoId[0];
            n39FrequenciaTratamentoId = BC001317_n39FrequenciaTratamentoId[0];
            A45TipoDescarteId = BC001317_A45TipoDescarteId[0];
            n45TipoDescarteId = BC001317_n45TipoDescarteId[0];
            A48TempoRetencaoId = BC001317_A48TempoRetencaoId[0];
            n48TempoRetencaoId = BC001317_n48TempoRetencaoId[0];
            A24AreaResponsavelId = BC001317_A24AreaResponsavelId[0];
            n24AreaResponsavelId = BC001317_n24AreaResponsavelId[0];
            A106DocumentoProcessoId = BC001317_A106DocumentoProcessoId[0];
            n106DocumentoProcessoId = BC001317_n106DocumentoProcessoId[0];
            A110DocumentoControladorId = BC001317_A110DocumentoControladorId[0];
            n110DocumentoControladorId = BC001317_n110DocumentoControladorId[0];
            ZM1346( -16) ;
         }
         pr_default.close(15);
         OnLoadActions1346( ) ;
      }

      protected void OnLoadActions1346( )
      {
         A76DocumentoNome = StringUtil.Upper( A76DocumentoNome);
         n76DocumentoNome = false;
         A77DocumentoFinalidadeTratamento = StringUtil.Upper( A77DocumentoFinalidadeTratamento);
         n77DocumentoFinalidadeTratamento = false;
         A79DocumentoBaseLegalNorm = StringUtil.Upper( A79DocumentoBaseLegalNorm);
         n79DocumentoBaseLegalNorm = false;
         A80DocumentoBaseLegalNormIntExt = StringUtil.Upper( A80DocumentoBaseLegalNormIntExt);
         n80DocumentoBaseLegalNormIntExt = false;
         A83DocumentoMedidaSegurancaDesc = StringUtil.Upper( A83DocumentoMedidaSegurancaDesc);
         n83DocumentoMedidaSegurancaDesc = false;
      }

      protected void CheckExtendedTable1346( )
      {
         nIsDirty_46 = 0;
         standaloneModal( ) ;
         nIsDirty_46 = 1;
         A76DocumentoNome = StringUtil.Upper( A76DocumentoNome);
         n76DocumentoNome = false;
         /* Using cursor BC00134 */
         pr_default.execute(2, new Object[] {n20SubprocessoId, A20SubprocessoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A20SubprocessoId) ) )
            {
               GX_msglist.addItem("Não existe 'SubProcesso.'.", "ForeignKeyNotFound", 1, "SUBPROCESSOID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         /* Using cursor BC00135 */
         pr_default.execute(3, new Object[] {n7EncarregadoId, A7EncarregadoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A7EncarregadoId) ) )
            {
               GX_msglist.addItem("Não existe 'Encarregado'.", "ForeignKeyNotFound", 1, "ENCARREGADOID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         /* Using cursor BC00136 */
         pr_default.execute(4, new Object[] {n13PersonaId, A13PersonaId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A13PersonaId) ) )
            {
               GX_msglist.addItem("Não existe 'Persona'.", "ForeignKeyNotFound", 1, "PERSONAID");
               AnyError = 1;
            }
         }
         pr_default.close(4);
         nIsDirty_46 = 1;
         A77DocumentoFinalidadeTratamento = StringUtil.Upper( A77DocumentoFinalidadeTratamento);
         n77DocumentoFinalidadeTratamento = false;
         /* Using cursor BC00137 */
         pr_default.execute(5, new Object[] {n27CategoriaId, A27CategoriaId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A27CategoriaId) ) )
            {
               GX_msglist.addItem("Não existe 'Categoria'.", "ForeignKeyNotFound", 1, "CATEGORIAID");
               AnyError = 1;
            }
         }
         pr_default.close(5);
         /* Using cursor BC00138 */
         pr_default.execute(6, new Object[] {n30TipoDadoId, A30TipoDadoId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A30TipoDadoId) ) )
            {
               GX_msglist.addItem("Não existe 'Tipo Dado'.", "ForeignKeyNotFound", 1, "TIPODADOID");
               AnyError = 1;
            }
         }
         pr_default.close(6);
         /* Using cursor BC00139 */
         pr_default.execute(7, new Object[] {n33FerramentaColetaId, A33FerramentaColetaId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A33FerramentaColetaId) ) )
            {
               GX_msglist.addItem("Não existe 'Ferramenta Coleta'.", "ForeignKeyNotFound", 1, "FERRAMENTACOLETAID");
               AnyError = 1;
            }
         }
         pr_default.close(7);
         /* Using cursor BC001310 */
         pr_default.execute(8, new Object[] {n36AbrangenciaGeograficaId, A36AbrangenciaGeograficaId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A36AbrangenciaGeograficaId) ) )
            {
               GX_msglist.addItem("Não existe 'Abrangencia Geografica'.", "ForeignKeyNotFound", 1, "ABRANGENCIAGEOGRAFICAID");
               AnyError = 1;
            }
         }
         pr_default.close(8);
         /* Using cursor BC001311 */
         pr_default.execute(9, new Object[] {n39FrequenciaTratamentoId, A39FrequenciaTratamentoId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A39FrequenciaTratamentoId) ) )
            {
               GX_msglist.addItem("Não existe 'Frequencia Tratamento'.", "ForeignKeyNotFound", 1, "FREQUENCIATRATAMENTOID");
               AnyError = 1;
            }
         }
         pr_default.close(9);
         /* Using cursor BC001312 */
         pr_default.execute(10, new Object[] {n45TipoDescarteId, A45TipoDescarteId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A45TipoDescarteId) ) )
            {
               GX_msglist.addItem("Não existe 'Tipo Descarte'.", "ForeignKeyNotFound", 1, "TIPODESCARTEID");
               AnyError = 1;
            }
         }
         pr_default.close(10);
         /* Using cursor BC001313 */
         pr_default.execute(11, new Object[] {n48TempoRetencaoId, A48TempoRetencaoId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A48TempoRetencaoId) ) )
            {
               GX_msglist.addItem("Não existe 'TempoRetencao'.", "ForeignKeyNotFound", 1, "TEMPORETENCAOID");
               AnyError = 1;
            }
         }
         pr_default.close(11);
         nIsDirty_46 = 1;
         A79DocumentoBaseLegalNorm = StringUtil.Upper( A79DocumentoBaseLegalNorm);
         n79DocumentoBaseLegalNorm = false;
         nIsDirty_46 = 1;
         A80DocumentoBaseLegalNormIntExt = StringUtil.Upper( A80DocumentoBaseLegalNormIntExt);
         n80DocumentoBaseLegalNormIntExt = false;
         nIsDirty_46 = 1;
         A83DocumentoMedidaSegurancaDesc = StringUtil.Upper( A83DocumentoMedidaSegurancaDesc);
         n83DocumentoMedidaSegurancaDesc = false;
         /* Using cursor BC001315 */
         pr_default.execute(13, new Object[] {n106DocumentoProcessoId, A106DocumentoProcessoId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A106DocumentoProcessoId) ) )
            {
               GX_msglist.addItem("Não existe 'Documento Processo'.", "ForeignKeyNotFound", 1, "DOCUMENTOPROCESSOID");
               AnyError = 1;
            }
         }
         A107DocumentoProcessoNome = BC001315_A107DocumentoProcessoNome[0];
         pr_default.close(13);
         if ( ! ( (DateTime.MinValue==A108DocumentoDataInclusao) || ( A108DocumentoDataInclusao >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Documento Data Inclusao fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A109DocumentoDataAlteracao) || ( A109DocumentoDataAlteracao >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Documento Data Alteracao fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC001316 */
         pr_default.execute(14, new Object[] {n110DocumentoControladorId, A110DocumentoControladorId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A110DocumentoControladorId) ) )
            {
               GX_msglist.addItem("Não existe 'Documento Controlador'.", "ForeignKeyNotFound", 1, "DOCUMENTOCONTROLADORID");
               AnyError = 1;
            }
         }
         pr_default.close(14);
         /* Using cursor BC001314 */
         pr_default.execute(12, new Object[] {n24AreaResponsavelId, A24AreaResponsavelId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A24AreaResponsavelId) ) )
            {
               GX_msglist.addItem("Não existe 'Area Responsavel.'.", "ForeignKeyNotFound", 1, "AREARESPONSAVELID");
               AnyError = 1;
            }
         }
         pr_default.close(12);
      }

      protected void CloseExtendedTableCursors1346( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(8);
         pr_default.close(9);
         pr_default.close(10);
         pr_default.close(11);
         pr_default.close(13);
         pr_default.close(14);
         pr_default.close(12);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1346( )
      {
         /* Using cursor BC001318 */
         pr_default.execute(16, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound46 = 1;
         }
         else
         {
            RcdFound46 = 0;
         }
         pr_default.close(16);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00133 */
         pr_default.execute(1, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1346( 16) ;
            RcdFound46 = 1;
            A75DocumentoId = BC00133_A75DocumentoId[0];
            A109DocumentoDataAlteracao = BC00133_A109DocumentoDataAlteracao[0];
            n109DocumentoDataAlteracao = BC00133_n109DocumentoDataAlteracao[0];
            A142DocumentoUsuarioAlteracao = BC00133_A142DocumentoUsuarioAlteracao[0];
            n142DocumentoUsuarioAlteracao = BC00133_n142DocumentoUsuarioAlteracao[0];
            A76DocumentoNome = BC00133_A76DocumentoNome[0];
            n76DocumentoNome = BC00133_n76DocumentoNome[0];
            A77DocumentoFinalidadeTratamento = BC00133_A77DocumentoFinalidadeTratamento[0];
            n77DocumentoFinalidadeTratamento = BC00133_n77DocumentoFinalidadeTratamento[0];
            A79DocumentoBaseLegalNorm = BC00133_A79DocumentoBaseLegalNorm[0];
            n79DocumentoBaseLegalNorm = BC00133_n79DocumentoBaseLegalNorm[0];
            A80DocumentoBaseLegalNormIntExt = BC00133_A80DocumentoBaseLegalNormIntExt[0];
            n80DocumentoBaseLegalNormIntExt = BC00133_n80DocumentoBaseLegalNormIntExt[0];
            A83DocumentoMedidaSegurancaDesc = BC00133_A83DocumentoMedidaSegurancaDesc[0];
            n83DocumentoMedidaSegurancaDesc = BC00133_n83DocumentoMedidaSegurancaDesc[0];
            A78DocumentoPrevColetaDados = BC00133_A78DocumentoPrevColetaDados[0];
            n78DocumentoPrevColetaDados = BC00133_n78DocumentoPrevColetaDados[0];
            A81DocumentoDadosCriancaAdolesc = BC00133_A81DocumentoDadosCriancaAdolesc[0];
            n81DocumentoDadosCriancaAdolesc = BC00133_n81DocumentoDadosCriancaAdolesc[0];
            A82DocumentoDadosGrupoVul = BC00133_A82DocumentoDadosGrupoVul[0];
            n82DocumentoDadosGrupoVul = BC00133_n82DocumentoDadosGrupoVul[0];
            A84DocumentoFluxoTratDadosDesc = BC00133_A84DocumentoFluxoTratDadosDesc[0];
            n84DocumentoFluxoTratDadosDesc = BC00133_n84DocumentoFluxoTratDadosDesc[0];
            A85DocumentoAtivo = BC00133_A85DocumentoAtivo[0];
            n85DocumentoAtivo = BC00133_n85DocumentoAtivo[0];
            A105DocumentoOperador = BC00133_A105DocumentoOperador[0];
            n105DocumentoOperador = BC00133_n105DocumentoOperador[0];
            A108DocumentoDataInclusao = BC00133_A108DocumentoDataInclusao[0];
            n108DocumentoDataInclusao = BC00133_n108DocumentoDataInclusao[0];
            A141DocumentoUsuarioInclusao = BC00133_A141DocumentoUsuarioInclusao[0];
            n141DocumentoUsuarioInclusao = BC00133_n141DocumentoUsuarioInclusao[0];
            A143DocumentoIsOperador = BC00133_A143DocumentoIsOperador[0];
            n143DocumentoIsOperador = BC00133_n143DocumentoIsOperador[0];
            A20SubprocessoId = BC00133_A20SubprocessoId[0];
            n20SubprocessoId = BC00133_n20SubprocessoId[0];
            A7EncarregadoId = BC00133_A7EncarregadoId[0];
            n7EncarregadoId = BC00133_n7EncarregadoId[0];
            A13PersonaId = BC00133_A13PersonaId[0];
            n13PersonaId = BC00133_n13PersonaId[0];
            A27CategoriaId = BC00133_A27CategoriaId[0];
            n27CategoriaId = BC00133_n27CategoriaId[0];
            A30TipoDadoId = BC00133_A30TipoDadoId[0];
            n30TipoDadoId = BC00133_n30TipoDadoId[0];
            A33FerramentaColetaId = BC00133_A33FerramentaColetaId[0];
            n33FerramentaColetaId = BC00133_n33FerramentaColetaId[0];
            A36AbrangenciaGeograficaId = BC00133_A36AbrangenciaGeograficaId[0];
            n36AbrangenciaGeograficaId = BC00133_n36AbrangenciaGeograficaId[0];
            A39FrequenciaTratamentoId = BC00133_A39FrequenciaTratamentoId[0];
            n39FrequenciaTratamentoId = BC00133_n39FrequenciaTratamentoId[0];
            A45TipoDescarteId = BC00133_A45TipoDescarteId[0];
            n45TipoDescarteId = BC00133_n45TipoDescarteId[0];
            A48TempoRetencaoId = BC00133_A48TempoRetencaoId[0];
            n48TempoRetencaoId = BC00133_n48TempoRetencaoId[0];
            A24AreaResponsavelId = BC00133_A24AreaResponsavelId[0];
            n24AreaResponsavelId = BC00133_n24AreaResponsavelId[0];
            A106DocumentoProcessoId = BC00133_A106DocumentoProcessoId[0];
            n106DocumentoProcessoId = BC00133_n106DocumentoProcessoId[0];
            A110DocumentoControladorId = BC00133_A110DocumentoControladorId[0];
            n110DocumentoControladorId = BC00133_n110DocumentoControladorId[0];
            Z75DocumentoId = A75DocumentoId;
            sMode46 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1346( ) ;
            if ( AnyError == 1 )
            {
               RcdFound46 = 0;
               InitializeNonKey1346( ) ;
            }
            Gx_mode = sMode46;
         }
         else
         {
            RcdFound46 = 0;
            InitializeNonKey1346( ) ;
            sMode46 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode46;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1346( ) ;
         if ( RcdFound46 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_130( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1346( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00132 */
            pr_default.execute(0, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Documento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z109DocumentoDataAlteracao != BC00132_A109DocumentoDataAlteracao[0] ) || ( StringUtil.StrCmp(Z142DocumentoUsuarioAlteracao, BC00132_A142DocumentoUsuarioAlteracao[0]) != 0 ) || ( StringUtil.StrCmp(Z76DocumentoNome, BC00132_A76DocumentoNome[0]) != 0 ) || ( StringUtil.StrCmp(Z77DocumentoFinalidadeTratamento, BC00132_A77DocumentoFinalidadeTratamento[0]) != 0 ) || ( StringUtil.StrCmp(Z79DocumentoBaseLegalNorm, BC00132_A79DocumentoBaseLegalNorm[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z80DocumentoBaseLegalNormIntExt, BC00132_A80DocumentoBaseLegalNormIntExt[0]) != 0 ) || ( Z78DocumentoPrevColetaDados != BC00132_A78DocumentoPrevColetaDados[0] ) || ( Z81DocumentoDadosCriancaAdolesc != BC00132_A81DocumentoDadosCriancaAdolesc[0] ) || ( Z82DocumentoDadosGrupoVul != BC00132_A82DocumentoDadosGrupoVul[0] ) || ( Z85DocumentoAtivo != BC00132_A85DocumentoAtivo[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z105DocumentoOperador != BC00132_A105DocumentoOperador[0] ) || ( Z108DocumentoDataInclusao != BC00132_A108DocumentoDataInclusao[0] ) || ( StringUtil.StrCmp(Z141DocumentoUsuarioInclusao, BC00132_A141DocumentoUsuarioInclusao[0]) != 0 ) || ( Z143DocumentoIsOperador != BC00132_A143DocumentoIsOperador[0] ) || ( Z20SubprocessoId != BC00132_A20SubprocessoId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z7EncarregadoId != BC00132_A7EncarregadoId[0] ) || ( Z13PersonaId != BC00132_A13PersonaId[0] ) || ( Z27CategoriaId != BC00132_A27CategoriaId[0] ) || ( Z30TipoDadoId != BC00132_A30TipoDadoId[0] ) || ( Z33FerramentaColetaId != BC00132_A33FerramentaColetaId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z36AbrangenciaGeograficaId != BC00132_A36AbrangenciaGeograficaId[0] ) || ( Z39FrequenciaTratamentoId != BC00132_A39FrequenciaTratamentoId[0] ) || ( Z45TipoDescarteId != BC00132_A45TipoDescarteId[0] ) || ( Z48TempoRetencaoId != BC00132_A48TempoRetencaoId[0] ) || ( Z24AreaResponsavelId != BC00132_A24AreaResponsavelId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z106DocumentoProcessoId != BC00132_A106DocumentoProcessoId[0] ) || ( Z110DocumentoControladorId != BC00132_A110DocumentoControladorId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Documento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1346( )
      {
         BeforeValidate1346( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1346( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1346( 0) ;
            CheckOptimisticConcurrency1346( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1346( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1346( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001319 */
                     pr_default.execute(17, new Object[] {n109DocumentoDataAlteracao, A109DocumentoDataAlteracao, n142DocumentoUsuarioAlteracao, A142DocumentoUsuarioAlteracao, n76DocumentoNome, A76DocumentoNome, n77DocumentoFinalidadeTratamento, A77DocumentoFinalidadeTratamento, n79DocumentoBaseLegalNorm, A79DocumentoBaseLegalNorm, n80DocumentoBaseLegalNormIntExt, A80DocumentoBaseLegalNormIntExt, n83DocumentoMedidaSegurancaDesc, A83DocumentoMedidaSegurancaDesc, n78DocumentoPrevColetaDados, A78DocumentoPrevColetaDados, n81DocumentoDadosCriancaAdolesc, A81DocumentoDadosCriancaAdolesc, n82DocumentoDadosGrupoVul, A82DocumentoDadosGrupoVul, n84DocumentoFluxoTratDadosDesc, A84DocumentoFluxoTratDadosDesc, n85DocumentoAtivo, A85DocumentoAtivo, n105DocumentoOperador, A105DocumentoOperador, n108DocumentoDataInclusao, A108DocumentoDataInclusao, n141DocumentoUsuarioInclusao, A141DocumentoUsuarioInclusao, n143DocumentoIsOperador, A143DocumentoIsOperador, n20SubprocessoId, A20SubprocessoId, n7EncarregadoId, A7EncarregadoId, n13PersonaId, A13PersonaId, n27CategoriaId, A27CategoriaId, n30TipoDadoId, A30TipoDadoId, n33FerramentaColetaId, A33FerramentaColetaId, n36AbrangenciaGeograficaId, A36AbrangenciaGeograficaId, n39FrequenciaTratamentoId, A39FrequenciaTratamentoId, n45TipoDescarteId, A45TipoDescarteId, n48TempoRetencaoId, A48TempoRetencaoId, n24AreaResponsavelId, A24AreaResponsavelId, n106DocumentoProcessoId, A106DocumentoProcessoId, n110DocumentoControladorId, A110DocumentoControladorId});
                     A75DocumentoId = BC001319_A75DocumentoId[0];
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("Documento");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load1346( ) ;
            }
            EndLevel1346( ) ;
         }
         CloseExtendedTableCursors1346( ) ;
      }

      protected void Update1346( )
      {
         BeforeValidate1346( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1346( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1346( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1346( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1346( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001320 */
                     pr_default.execute(18, new Object[] {n109DocumentoDataAlteracao, A109DocumentoDataAlteracao, n142DocumentoUsuarioAlteracao, A142DocumentoUsuarioAlteracao, n76DocumentoNome, A76DocumentoNome, n77DocumentoFinalidadeTratamento, A77DocumentoFinalidadeTratamento, n79DocumentoBaseLegalNorm, A79DocumentoBaseLegalNorm, n80DocumentoBaseLegalNormIntExt, A80DocumentoBaseLegalNormIntExt, n83DocumentoMedidaSegurancaDesc, A83DocumentoMedidaSegurancaDesc, n78DocumentoPrevColetaDados, A78DocumentoPrevColetaDados, n81DocumentoDadosCriancaAdolesc, A81DocumentoDadosCriancaAdolesc, n82DocumentoDadosGrupoVul, A82DocumentoDadosGrupoVul, n84DocumentoFluxoTratDadosDesc, A84DocumentoFluxoTratDadosDesc, n85DocumentoAtivo, A85DocumentoAtivo, n105DocumentoOperador, A105DocumentoOperador, n108DocumentoDataInclusao, A108DocumentoDataInclusao, n141DocumentoUsuarioInclusao, A141DocumentoUsuarioInclusao, n143DocumentoIsOperador, A143DocumentoIsOperador, n20SubprocessoId, A20SubprocessoId, n7EncarregadoId, A7EncarregadoId, n13PersonaId, A13PersonaId, n27CategoriaId, A27CategoriaId, n30TipoDadoId, A30TipoDadoId, n33FerramentaColetaId, A33FerramentaColetaId, n36AbrangenciaGeograficaId, A36AbrangenciaGeograficaId, n39FrequenciaTratamentoId, A39FrequenciaTratamentoId, n45TipoDescarteId, A45TipoDescarteId, n48TempoRetencaoId, A48TempoRetencaoId, n24AreaResponsavelId, A24AreaResponsavelId, n106DocumentoProcessoId, A106DocumentoProcessoId, n110DocumentoControladorId, A110DocumentoControladorId, A75DocumentoId});
                     pr_default.close(18);
                     dsDefault.SmartCacheProvider.SetUpdated("Documento");
                     if ( (pr_default.getStatus(18) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Documento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1346( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel1346( ) ;
         }
         CloseExtendedTableCursors1346( ) ;
      }

      protected void DeferredUpdate1346( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1346( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1346( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1346( ) ;
            AfterConfirm1346( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1346( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001321 */
                  pr_default.execute(19, new Object[] {A75DocumentoId});
                  pr_default.close(19);
                  dsDefault.SmartCacheProvider.SetUpdated("Documento");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode46 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1346( ) ;
         Gx_mode = sMode46;
      }

      protected void OnDeleteControls1346( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001322 */
            pr_default.execute(20, new Object[] {n106DocumentoProcessoId, A106DocumentoProcessoId});
            A107DocumentoProcessoNome = BC001322_A107DocumentoProcessoNome[0];
            pr_default.close(20);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001323 */
            pr_default.execute(21, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"DocImagem"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor BC001324 */
            pr_default.execute(22, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"RevisaoLog"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor BC001325 */
            pr_default.execute(23, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor BC001326 */
            pr_default.execute(24, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor BC001327 */
            pr_default.execute(25, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor BC001328 */
            pr_default.execute(26, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"DocMedidaSeguranca"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor BC001329 */
            pr_default.execute(27, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Doc Fonte Retencao"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor BC001330 */
            pr_default.execute(28, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Doc Setor Interno"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor BC001331 */
            pr_default.execute(29, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Doc Compart Interno"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor BC001332 */
            pr_default.execute(30, new Object[] {A75DocumentoId});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Doc Envolvidos Coleta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
         }
      }

      protected void EndLevel1346( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1346( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart1346( )
      {
         /* Scan By routine */
         /* Using cursor BC001333 */
         pr_default.execute(31, new Object[] {A75DocumentoId});
         RcdFound46 = 0;
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound46 = 1;
            A75DocumentoId = BC001333_A75DocumentoId[0];
            A109DocumentoDataAlteracao = BC001333_A109DocumentoDataAlteracao[0];
            n109DocumentoDataAlteracao = BC001333_n109DocumentoDataAlteracao[0];
            A142DocumentoUsuarioAlteracao = BC001333_A142DocumentoUsuarioAlteracao[0];
            n142DocumentoUsuarioAlteracao = BC001333_n142DocumentoUsuarioAlteracao[0];
            A76DocumentoNome = BC001333_A76DocumentoNome[0];
            n76DocumentoNome = BC001333_n76DocumentoNome[0];
            A77DocumentoFinalidadeTratamento = BC001333_A77DocumentoFinalidadeTratamento[0];
            n77DocumentoFinalidadeTratamento = BC001333_n77DocumentoFinalidadeTratamento[0];
            A79DocumentoBaseLegalNorm = BC001333_A79DocumentoBaseLegalNorm[0];
            n79DocumentoBaseLegalNorm = BC001333_n79DocumentoBaseLegalNorm[0];
            A80DocumentoBaseLegalNormIntExt = BC001333_A80DocumentoBaseLegalNormIntExt[0];
            n80DocumentoBaseLegalNormIntExt = BC001333_n80DocumentoBaseLegalNormIntExt[0];
            A83DocumentoMedidaSegurancaDesc = BC001333_A83DocumentoMedidaSegurancaDesc[0];
            n83DocumentoMedidaSegurancaDesc = BC001333_n83DocumentoMedidaSegurancaDesc[0];
            A78DocumentoPrevColetaDados = BC001333_A78DocumentoPrevColetaDados[0];
            n78DocumentoPrevColetaDados = BC001333_n78DocumentoPrevColetaDados[0];
            A81DocumentoDadosCriancaAdolesc = BC001333_A81DocumentoDadosCriancaAdolesc[0];
            n81DocumentoDadosCriancaAdolesc = BC001333_n81DocumentoDadosCriancaAdolesc[0];
            A82DocumentoDadosGrupoVul = BC001333_A82DocumentoDadosGrupoVul[0];
            n82DocumentoDadosGrupoVul = BC001333_n82DocumentoDadosGrupoVul[0];
            A84DocumentoFluxoTratDadosDesc = BC001333_A84DocumentoFluxoTratDadosDesc[0];
            n84DocumentoFluxoTratDadosDesc = BC001333_n84DocumentoFluxoTratDadosDesc[0];
            A85DocumentoAtivo = BC001333_A85DocumentoAtivo[0];
            n85DocumentoAtivo = BC001333_n85DocumentoAtivo[0];
            A105DocumentoOperador = BC001333_A105DocumentoOperador[0];
            n105DocumentoOperador = BC001333_n105DocumentoOperador[0];
            A107DocumentoProcessoNome = BC001333_A107DocumentoProcessoNome[0];
            A108DocumentoDataInclusao = BC001333_A108DocumentoDataInclusao[0];
            n108DocumentoDataInclusao = BC001333_n108DocumentoDataInclusao[0];
            A141DocumentoUsuarioInclusao = BC001333_A141DocumentoUsuarioInclusao[0];
            n141DocumentoUsuarioInclusao = BC001333_n141DocumentoUsuarioInclusao[0];
            A143DocumentoIsOperador = BC001333_A143DocumentoIsOperador[0];
            n143DocumentoIsOperador = BC001333_n143DocumentoIsOperador[0];
            A20SubprocessoId = BC001333_A20SubprocessoId[0];
            n20SubprocessoId = BC001333_n20SubprocessoId[0];
            A7EncarregadoId = BC001333_A7EncarregadoId[0];
            n7EncarregadoId = BC001333_n7EncarregadoId[0];
            A13PersonaId = BC001333_A13PersonaId[0];
            n13PersonaId = BC001333_n13PersonaId[0];
            A27CategoriaId = BC001333_A27CategoriaId[0];
            n27CategoriaId = BC001333_n27CategoriaId[0];
            A30TipoDadoId = BC001333_A30TipoDadoId[0];
            n30TipoDadoId = BC001333_n30TipoDadoId[0];
            A33FerramentaColetaId = BC001333_A33FerramentaColetaId[0];
            n33FerramentaColetaId = BC001333_n33FerramentaColetaId[0];
            A36AbrangenciaGeograficaId = BC001333_A36AbrangenciaGeograficaId[0];
            n36AbrangenciaGeograficaId = BC001333_n36AbrangenciaGeograficaId[0];
            A39FrequenciaTratamentoId = BC001333_A39FrequenciaTratamentoId[0];
            n39FrequenciaTratamentoId = BC001333_n39FrequenciaTratamentoId[0];
            A45TipoDescarteId = BC001333_A45TipoDescarteId[0];
            n45TipoDescarteId = BC001333_n45TipoDescarteId[0];
            A48TempoRetencaoId = BC001333_A48TempoRetencaoId[0];
            n48TempoRetencaoId = BC001333_n48TempoRetencaoId[0];
            A24AreaResponsavelId = BC001333_A24AreaResponsavelId[0];
            n24AreaResponsavelId = BC001333_n24AreaResponsavelId[0];
            A106DocumentoProcessoId = BC001333_A106DocumentoProcessoId[0];
            n106DocumentoProcessoId = BC001333_n106DocumentoProcessoId[0];
            A110DocumentoControladorId = BC001333_A110DocumentoControladorId[0];
            n110DocumentoControladorId = BC001333_n110DocumentoControladorId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1346( )
      {
         /* Scan next routine */
         pr_default.readNext(31);
         RcdFound46 = 0;
         ScanKeyLoad1346( ) ;
      }

      protected void ScanKeyLoad1346( )
      {
         sMode46 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound46 = 1;
            A75DocumentoId = BC001333_A75DocumentoId[0];
            A109DocumentoDataAlteracao = BC001333_A109DocumentoDataAlteracao[0];
            n109DocumentoDataAlteracao = BC001333_n109DocumentoDataAlteracao[0];
            A142DocumentoUsuarioAlteracao = BC001333_A142DocumentoUsuarioAlteracao[0];
            n142DocumentoUsuarioAlteracao = BC001333_n142DocumentoUsuarioAlteracao[0];
            A76DocumentoNome = BC001333_A76DocumentoNome[0];
            n76DocumentoNome = BC001333_n76DocumentoNome[0];
            A77DocumentoFinalidadeTratamento = BC001333_A77DocumentoFinalidadeTratamento[0];
            n77DocumentoFinalidadeTratamento = BC001333_n77DocumentoFinalidadeTratamento[0];
            A79DocumentoBaseLegalNorm = BC001333_A79DocumentoBaseLegalNorm[0];
            n79DocumentoBaseLegalNorm = BC001333_n79DocumentoBaseLegalNorm[0];
            A80DocumentoBaseLegalNormIntExt = BC001333_A80DocumentoBaseLegalNormIntExt[0];
            n80DocumentoBaseLegalNormIntExt = BC001333_n80DocumentoBaseLegalNormIntExt[0];
            A83DocumentoMedidaSegurancaDesc = BC001333_A83DocumentoMedidaSegurancaDesc[0];
            n83DocumentoMedidaSegurancaDesc = BC001333_n83DocumentoMedidaSegurancaDesc[0];
            A78DocumentoPrevColetaDados = BC001333_A78DocumentoPrevColetaDados[0];
            n78DocumentoPrevColetaDados = BC001333_n78DocumentoPrevColetaDados[0];
            A81DocumentoDadosCriancaAdolesc = BC001333_A81DocumentoDadosCriancaAdolesc[0];
            n81DocumentoDadosCriancaAdolesc = BC001333_n81DocumentoDadosCriancaAdolesc[0];
            A82DocumentoDadosGrupoVul = BC001333_A82DocumentoDadosGrupoVul[0];
            n82DocumentoDadosGrupoVul = BC001333_n82DocumentoDadosGrupoVul[0];
            A84DocumentoFluxoTratDadosDesc = BC001333_A84DocumentoFluxoTratDadosDesc[0];
            n84DocumentoFluxoTratDadosDesc = BC001333_n84DocumentoFluxoTratDadosDesc[0];
            A85DocumentoAtivo = BC001333_A85DocumentoAtivo[0];
            n85DocumentoAtivo = BC001333_n85DocumentoAtivo[0];
            A105DocumentoOperador = BC001333_A105DocumentoOperador[0];
            n105DocumentoOperador = BC001333_n105DocumentoOperador[0];
            A107DocumentoProcessoNome = BC001333_A107DocumentoProcessoNome[0];
            A108DocumentoDataInclusao = BC001333_A108DocumentoDataInclusao[0];
            n108DocumentoDataInclusao = BC001333_n108DocumentoDataInclusao[0];
            A141DocumentoUsuarioInclusao = BC001333_A141DocumentoUsuarioInclusao[0];
            n141DocumentoUsuarioInclusao = BC001333_n141DocumentoUsuarioInclusao[0];
            A143DocumentoIsOperador = BC001333_A143DocumentoIsOperador[0];
            n143DocumentoIsOperador = BC001333_n143DocumentoIsOperador[0];
            A20SubprocessoId = BC001333_A20SubprocessoId[0];
            n20SubprocessoId = BC001333_n20SubprocessoId[0];
            A7EncarregadoId = BC001333_A7EncarregadoId[0];
            n7EncarregadoId = BC001333_n7EncarregadoId[0];
            A13PersonaId = BC001333_A13PersonaId[0];
            n13PersonaId = BC001333_n13PersonaId[0];
            A27CategoriaId = BC001333_A27CategoriaId[0];
            n27CategoriaId = BC001333_n27CategoriaId[0];
            A30TipoDadoId = BC001333_A30TipoDadoId[0];
            n30TipoDadoId = BC001333_n30TipoDadoId[0];
            A33FerramentaColetaId = BC001333_A33FerramentaColetaId[0];
            n33FerramentaColetaId = BC001333_n33FerramentaColetaId[0];
            A36AbrangenciaGeograficaId = BC001333_A36AbrangenciaGeograficaId[0];
            n36AbrangenciaGeograficaId = BC001333_n36AbrangenciaGeograficaId[0];
            A39FrequenciaTratamentoId = BC001333_A39FrequenciaTratamentoId[0];
            n39FrequenciaTratamentoId = BC001333_n39FrequenciaTratamentoId[0];
            A45TipoDescarteId = BC001333_A45TipoDescarteId[0];
            n45TipoDescarteId = BC001333_n45TipoDescarteId[0];
            A48TempoRetencaoId = BC001333_A48TempoRetencaoId[0];
            n48TempoRetencaoId = BC001333_n48TempoRetencaoId[0];
            A24AreaResponsavelId = BC001333_A24AreaResponsavelId[0];
            n24AreaResponsavelId = BC001333_n24AreaResponsavelId[0];
            A106DocumentoProcessoId = BC001333_A106DocumentoProcessoId[0];
            n106DocumentoProcessoId = BC001333_n106DocumentoProcessoId[0];
            A110DocumentoControladorId = BC001333_A110DocumentoControladorId[0];
            n110DocumentoControladorId = BC001333_n110DocumentoControladorId[0];
         }
         Gx_mode = sMode46;
      }

      protected void ScanKeyEnd1346( )
      {
         pr_default.close(31);
      }

      protected void AfterConfirm1346( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1346( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1346( )
      {
         /* Before Update Rules */
         A109DocumentoDataAlteracao = DateTimeUtil.ServerNow( context, pr_default);
         n109DocumentoDataAlteracao = false;
         A142DocumentoUsuarioAlteracao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         n142DocumentoUsuarioAlteracao = false;
      }

      protected void BeforeDelete1346( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1346( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1346( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1346( )
      {
      }

      protected void send_integrity_lvl_hashes1346( )
      {
      }

      protected void AddRow1346( )
      {
         VarsToRow46( bcDocumento) ;
      }

      protected void ReadRow1346( )
      {
         RowToVars46( bcDocumento, 1) ;
      }

      protected void InitializeNonKey1346( )
      {
         A109DocumentoDataAlteracao = (DateTime)(DateTime.MinValue);
         n109DocumentoDataAlteracao = false;
         A142DocumentoUsuarioAlteracao = "";
         n142DocumentoUsuarioAlteracao = false;
         A76DocumentoNome = "";
         n76DocumentoNome = false;
         A77DocumentoFinalidadeTratamento = "";
         n77DocumentoFinalidadeTratamento = false;
         A79DocumentoBaseLegalNorm = "";
         n79DocumentoBaseLegalNorm = false;
         A80DocumentoBaseLegalNormIntExt = "";
         n80DocumentoBaseLegalNormIntExt = false;
         A83DocumentoMedidaSegurancaDesc = "";
         n83DocumentoMedidaSegurancaDesc = false;
         A20SubprocessoId = 0;
         n20SubprocessoId = false;
         A7EncarregadoId = 0;
         n7EncarregadoId = false;
         A13PersonaId = 0;
         n13PersonaId = false;
         A27CategoriaId = 0;
         n27CategoriaId = false;
         A30TipoDadoId = 0;
         n30TipoDadoId = false;
         A33FerramentaColetaId = 0;
         n33FerramentaColetaId = false;
         A36AbrangenciaGeograficaId = 0;
         n36AbrangenciaGeograficaId = false;
         A39FrequenciaTratamentoId = 0;
         n39FrequenciaTratamentoId = false;
         A45TipoDescarteId = 0;
         n45TipoDescarteId = false;
         A48TempoRetencaoId = 0;
         n48TempoRetencaoId = false;
         A78DocumentoPrevColetaDados = false;
         n78DocumentoPrevColetaDados = false;
         A81DocumentoDadosCriancaAdolesc = false;
         n81DocumentoDadosCriancaAdolesc = false;
         A82DocumentoDadosGrupoVul = false;
         n82DocumentoDadosGrupoVul = false;
         A84DocumentoFluxoTratDadosDesc = "";
         n84DocumentoFluxoTratDadosDesc = false;
         A105DocumentoOperador = false;
         n105DocumentoOperador = false;
         A106DocumentoProcessoId = 0;
         n106DocumentoProcessoId = false;
         A107DocumentoProcessoNome = "";
         A110DocumentoControladorId = 0;
         n110DocumentoControladorId = false;
         A24AreaResponsavelId = 0;
         n24AreaResponsavelId = false;
         A85DocumentoAtivo = true;
         n85DocumentoAtivo = false;
         A108DocumentoDataInclusao = DateTimeUtil.ServerNow( context, pr_default);
         n108DocumentoDataInclusao = false;
         A141DocumentoUsuarioInclusao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         n141DocumentoUsuarioInclusao = false;
         A143DocumentoIsOperador = false;
         n143DocumentoIsOperador = false;
         Z109DocumentoDataAlteracao = (DateTime)(DateTime.MinValue);
         Z142DocumentoUsuarioAlteracao = "";
         Z76DocumentoNome = "";
         Z77DocumentoFinalidadeTratamento = "";
         Z79DocumentoBaseLegalNorm = "";
         Z80DocumentoBaseLegalNormIntExt = "";
         Z78DocumentoPrevColetaDados = false;
         Z81DocumentoDadosCriancaAdolesc = false;
         Z82DocumentoDadosGrupoVul = false;
         Z85DocumentoAtivo = false;
         Z105DocumentoOperador = false;
         Z108DocumentoDataInclusao = (DateTime)(DateTime.MinValue);
         Z141DocumentoUsuarioInclusao = "";
         Z143DocumentoIsOperador = false;
         Z20SubprocessoId = 0;
         Z7EncarregadoId = 0;
         Z13PersonaId = 0;
         Z27CategoriaId = 0;
         Z30TipoDadoId = 0;
         Z33FerramentaColetaId = 0;
         Z36AbrangenciaGeograficaId = 0;
         Z39FrequenciaTratamentoId = 0;
         Z45TipoDescarteId = 0;
         Z48TempoRetencaoId = 0;
         Z24AreaResponsavelId = 0;
         Z106DocumentoProcessoId = 0;
         Z110DocumentoControladorId = 0;
      }

      protected void InitAll1346( )
      {
         A75DocumentoId = 0;
         InitializeNonKey1346( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A85DocumentoAtivo = i85DocumentoAtivo;
         n85DocumentoAtivo = false;
         A108DocumentoDataInclusao = i108DocumentoDataInclusao;
         n108DocumentoDataInclusao = false;
         A141DocumentoUsuarioInclusao = i141DocumentoUsuarioInclusao;
         n141DocumentoUsuarioInclusao = false;
         A143DocumentoIsOperador = i143DocumentoIsOperador;
         n143DocumentoIsOperador = false;
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow46( SdtDocumento obj46 )
      {
         obj46.gxTpr_Mode = Gx_mode;
         obj46.gxTpr_Documentodataalteracao = A109DocumentoDataAlteracao;
         obj46.gxTpr_Documentousuarioalteracao = A142DocumentoUsuarioAlteracao;
         obj46.gxTpr_Documentonome = A76DocumentoNome;
         obj46.gxTpr_Documentofinalidadetratamento = A77DocumentoFinalidadeTratamento;
         obj46.gxTpr_Documentobaselegalnorm = A79DocumentoBaseLegalNorm;
         obj46.gxTpr_Documentobaselegalnormintext = A80DocumentoBaseLegalNormIntExt;
         obj46.gxTpr_Documentomedidasegurancadesc = A83DocumentoMedidaSegurancaDesc;
         obj46.gxTpr_Subprocessoid = A20SubprocessoId;
         obj46.gxTpr_Encarregadoid = A7EncarregadoId;
         obj46.gxTpr_Personaid = A13PersonaId;
         obj46.gxTpr_Categoriaid = A27CategoriaId;
         obj46.gxTpr_Tipodadoid = A30TipoDadoId;
         obj46.gxTpr_Ferramentacoletaid = A33FerramentaColetaId;
         obj46.gxTpr_Abrangenciageograficaid = A36AbrangenciaGeograficaId;
         obj46.gxTpr_Frequenciatratamentoid = A39FrequenciaTratamentoId;
         obj46.gxTpr_Tipodescarteid = A45TipoDescarteId;
         obj46.gxTpr_Temporetencaoid = A48TempoRetencaoId;
         obj46.gxTpr_Documentoprevcoletadados = A78DocumentoPrevColetaDados;
         obj46.gxTpr_Documentodadoscriancaadolesc = A81DocumentoDadosCriancaAdolesc;
         obj46.gxTpr_Documentodadosgrupovul = A82DocumentoDadosGrupoVul;
         obj46.gxTpr_Documentofluxotratdadosdesc = A84DocumentoFluxoTratDadosDesc;
         obj46.gxTpr_Documentooperador = A105DocumentoOperador;
         obj46.gxTpr_Documentoprocessoid = A106DocumentoProcessoId;
         obj46.gxTpr_Documentoprocessonome = A107DocumentoProcessoNome;
         obj46.gxTpr_Documentocontroladorid = A110DocumentoControladorId;
         obj46.gxTpr_Arearesponsavelid = A24AreaResponsavelId;
         obj46.gxTpr_Documentoativo = A85DocumentoAtivo;
         obj46.gxTpr_Documentodatainclusao = A108DocumentoDataInclusao;
         obj46.gxTpr_Documentousuarioinclusao = A141DocumentoUsuarioInclusao;
         obj46.gxTpr_Documentoisoperador = A143DocumentoIsOperador;
         obj46.gxTpr_Documentoid = A75DocumentoId;
         obj46.gxTpr_Documentoid_Z = Z75DocumentoId;
         obj46.gxTpr_Documentonome_Z = Z76DocumentoNome;
         obj46.gxTpr_Subprocessoid_Z = Z20SubprocessoId;
         obj46.gxTpr_Encarregadoid_Z = Z7EncarregadoId;
         obj46.gxTpr_Personaid_Z = Z13PersonaId;
         obj46.gxTpr_Documentofinalidadetratamento_Z = Z77DocumentoFinalidadeTratamento;
         obj46.gxTpr_Categoriaid_Z = Z27CategoriaId;
         obj46.gxTpr_Tipodadoid_Z = Z30TipoDadoId;
         obj46.gxTpr_Ferramentacoletaid_Z = Z33FerramentaColetaId;
         obj46.gxTpr_Abrangenciageograficaid_Z = Z36AbrangenciaGeograficaId;
         obj46.gxTpr_Frequenciatratamentoid_Z = Z39FrequenciaTratamentoId;
         obj46.gxTpr_Tipodescarteid_Z = Z45TipoDescarteId;
         obj46.gxTpr_Temporetencaoid_Z = Z48TempoRetencaoId;
         obj46.gxTpr_Documentoprevcoletadados_Z = Z78DocumentoPrevColetaDados;
         obj46.gxTpr_Documentobaselegalnorm_Z = Z79DocumentoBaseLegalNorm;
         obj46.gxTpr_Documentobaselegalnormintext_Z = Z80DocumentoBaseLegalNormIntExt;
         obj46.gxTpr_Documentodadoscriancaadolesc_Z = Z81DocumentoDadosCriancaAdolesc;
         obj46.gxTpr_Documentodadosgrupovul_Z = Z82DocumentoDadosGrupoVul;
         obj46.gxTpr_Documentoativo_Z = Z85DocumentoAtivo;
         obj46.gxTpr_Documentooperador_Z = Z105DocumentoOperador;
         obj46.gxTpr_Documentoprocessoid_Z = Z106DocumentoProcessoId;
         obj46.gxTpr_Documentoprocessonome_Z = Z107DocumentoProcessoNome;
         obj46.gxTpr_Documentodatainclusao_Z = Z108DocumentoDataInclusao;
         obj46.gxTpr_Documentodataalteracao_Z = Z109DocumentoDataAlteracao;
         obj46.gxTpr_Documentocontroladorid_Z = Z110DocumentoControladorId;
         obj46.gxTpr_Arearesponsavelid_Z = Z24AreaResponsavelId;
         obj46.gxTpr_Documentousuarioinclusao_Z = Z141DocumentoUsuarioInclusao;
         obj46.gxTpr_Documentousuarioalteracao_Z = Z142DocumentoUsuarioAlteracao;
         obj46.gxTpr_Documentoisoperador_Z = Z143DocumentoIsOperador;
         obj46.gxTpr_Documentonome_N = (short)(Convert.ToInt16(n76DocumentoNome));
         obj46.gxTpr_Subprocessoid_N = (short)(Convert.ToInt16(n20SubprocessoId));
         obj46.gxTpr_Encarregadoid_N = (short)(Convert.ToInt16(n7EncarregadoId));
         obj46.gxTpr_Personaid_N = (short)(Convert.ToInt16(n13PersonaId));
         obj46.gxTpr_Documentofinalidadetratamento_N = (short)(Convert.ToInt16(n77DocumentoFinalidadeTratamento));
         obj46.gxTpr_Categoriaid_N = (short)(Convert.ToInt16(n27CategoriaId));
         obj46.gxTpr_Tipodadoid_N = (short)(Convert.ToInt16(n30TipoDadoId));
         obj46.gxTpr_Ferramentacoletaid_N = (short)(Convert.ToInt16(n33FerramentaColetaId));
         obj46.gxTpr_Abrangenciageograficaid_N = (short)(Convert.ToInt16(n36AbrangenciaGeograficaId));
         obj46.gxTpr_Frequenciatratamentoid_N = (short)(Convert.ToInt16(n39FrequenciaTratamentoId));
         obj46.gxTpr_Tipodescarteid_N = (short)(Convert.ToInt16(n45TipoDescarteId));
         obj46.gxTpr_Temporetencaoid_N = (short)(Convert.ToInt16(n48TempoRetencaoId));
         obj46.gxTpr_Documentoprevcoletadados_N = (short)(Convert.ToInt16(n78DocumentoPrevColetaDados));
         obj46.gxTpr_Documentobaselegalnorm_N = (short)(Convert.ToInt16(n79DocumentoBaseLegalNorm));
         obj46.gxTpr_Documentobaselegalnormintext_N = (short)(Convert.ToInt16(n80DocumentoBaseLegalNormIntExt));
         obj46.gxTpr_Documentodadoscriancaadolesc_N = (short)(Convert.ToInt16(n81DocumentoDadosCriancaAdolesc));
         obj46.gxTpr_Documentodadosgrupovul_N = (short)(Convert.ToInt16(n82DocumentoDadosGrupoVul));
         obj46.gxTpr_Documentomedidasegurancadesc_N = (short)(Convert.ToInt16(n83DocumentoMedidaSegurancaDesc));
         obj46.gxTpr_Documentofluxotratdadosdesc_N = (short)(Convert.ToInt16(n84DocumentoFluxoTratDadosDesc));
         obj46.gxTpr_Documentoativo_N = (short)(Convert.ToInt16(n85DocumentoAtivo));
         obj46.gxTpr_Documentooperador_N = (short)(Convert.ToInt16(n105DocumentoOperador));
         obj46.gxTpr_Documentoprocessoid_N = (short)(Convert.ToInt16(n106DocumentoProcessoId));
         obj46.gxTpr_Documentodatainclusao_N = (short)(Convert.ToInt16(n108DocumentoDataInclusao));
         obj46.gxTpr_Documentodataalteracao_N = (short)(Convert.ToInt16(n109DocumentoDataAlteracao));
         obj46.gxTpr_Documentocontroladorid_N = (short)(Convert.ToInt16(n110DocumentoControladorId));
         obj46.gxTpr_Arearesponsavelid_N = (short)(Convert.ToInt16(n24AreaResponsavelId));
         obj46.gxTpr_Documentousuarioinclusao_N = (short)(Convert.ToInt16(n141DocumentoUsuarioInclusao));
         obj46.gxTpr_Documentousuarioalteracao_N = (short)(Convert.ToInt16(n142DocumentoUsuarioAlteracao));
         obj46.gxTpr_Documentoisoperador_N = (short)(Convert.ToInt16(n143DocumentoIsOperador));
         obj46.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow46( SdtDocumento obj46 )
      {
         obj46.gxTpr_Documentoid = A75DocumentoId;
         return  ;
      }

      public void RowToVars46( SdtDocumento obj46 ,
                               int forceLoad )
      {
         Gx_mode = obj46.gxTpr_Mode;
         A109DocumentoDataAlteracao = obj46.gxTpr_Documentodataalteracao;
         n109DocumentoDataAlteracao = false;
         A142DocumentoUsuarioAlteracao = obj46.gxTpr_Documentousuarioalteracao;
         n142DocumentoUsuarioAlteracao = false;
         A76DocumentoNome = obj46.gxTpr_Documentonome;
         n76DocumentoNome = false;
         A77DocumentoFinalidadeTratamento = obj46.gxTpr_Documentofinalidadetratamento;
         n77DocumentoFinalidadeTratamento = false;
         A79DocumentoBaseLegalNorm = obj46.gxTpr_Documentobaselegalnorm;
         n79DocumentoBaseLegalNorm = false;
         A80DocumentoBaseLegalNormIntExt = obj46.gxTpr_Documentobaselegalnormintext;
         n80DocumentoBaseLegalNormIntExt = false;
         A83DocumentoMedidaSegurancaDesc = obj46.gxTpr_Documentomedidasegurancadesc;
         n83DocumentoMedidaSegurancaDesc = false;
         A20SubprocessoId = obj46.gxTpr_Subprocessoid;
         n20SubprocessoId = false;
         A7EncarregadoId = obj46.gxTpr_Encarregadoid;
         n7EncarregadoId = false;
         A13PersonaId = obj46.gxTpr_Personaid;
         n13PersonaId = false;
         A27CategoriaId = obj46.gxTpr_Categoriaid;
         n27CategoriaId = false;
         A30TipoDadoId = obj46.gxTpr_Tipodadoid;
         n30TipoDadoId = false;
         A33FerramentaColetaId = obj46.gxTpr_Ferramentacoletaid;
         n33FerramentaColetaId = false;
         A36AbrangenciaGeograficaId = obj46.gxTpr_Abrangenciageograficaid;
         n36AbrangenciaGeograficaId = false;
         A39FrequenciaTratamentoId = obj46.gxTpr_Frequenciatratamentoid;
         n39FrequenciaTratamentoId = false;
         A45TipoDescarteId = obj46.gxTpr_Tipodescarteid;
         n45TipoDescarteId = false;
         A48TempoRetencaoId = obj46.gxTpr_Temporetencaoid;
         n48TempoRetencaoId = false;
         A78DocumentoPrevColetaDados = obj46.gxTpr_Documentoprevcoletadados;
         n78DocumentoPrevColetaDados = false;
         A81DocumentoDadosCriancaAdolesc = obj46.gxTpr_Documentodadoscriancaadolesc;
         n81DocumentoDadosCriancaAdolesc = false;
         A82DocumentoDadosGrupoVul = obj46.gxTpr_Documentodadosgrupovul;
         n82DocumentoDadosGrupoVul = false;
         A84DocumentoFluxoTratDadosDesc = obj46.gxTpr_Documentofluxotratdadosdesc;
         n84DocumentoFluxoTratDadosDesc = false;
         A105DocumentoOperador = obj46.gxTpr_Documentooperador;
         n105DocumentoOperador = false;
         A106DocumentoProcessoId = obj46.gxTpr_Documentoprocessoid;
         n106DocumentoProcessoId = false;
         A107DocumentoProcessoNome = obj46.gxTpr_Documentoprocessonome;
         A110DocumentoControladorId = obj46.gxTpr_Documentocontroladorid;
         n110DocumentoControladorId = false;
         A24AreaResponsavelId = obj46.gxTpr_Arearesponsavelid;
         n24AreaResponsavelId = false;
         A85DocumentoAtivo = obj46.gxTpr_Documentoativo;
         n85DocumentoAtivo = false;
         A108DocumentoDataInclusao = obj46.gxTpr_Documentodatainclusao;
         n108DocumentoDataInclusao = false;
         A141DocumentoUsuarioInclusao = obj46.gxTpr_Documentousuarioinclusao;
         n141DocumentoUsuarioInclusao = false;
         A143DocumentoIsOperador = obj46.gxTpr_Documentoisoperador;
         n143DocumentoIsOperador = false;
         A75DocumentoId = obj46.gxTpr_Documentoid;
         Z75DocumentoId = obj46.gxTpr_Documentoid_Z;
         Z76DocumentoNome = obj46.gxTpr_Documentonome_Z;
         Z20SubprocessoId = obj46.gxTpr_Subprocessoid_Z;
         Z7EncarregadoId = obj46.gxTpr_Encarregadoid_Z;
         Z13PersonaId = obj46.gxTpr_Personaid_Z;
         Z77DocumentoFinalidadeTratamento = obj46.gxTpr_Documentofinalidadetratamento_Z;
         Z27CategoriaId = obj46.gxTpr_Categoriaid_Z;
         Z30TipoDadoId = obj46.gxTpr_Tipodadoid_Z;
         Z33FerramentaColetaId = obj46.gxTpr_Ferramentacoletaid_Z;
         Z36AbrangenciaGeograficaId = obj46.gxTpr_Abrangenciageograficaid_Z;
         Z39FrequenciaTratamentoId = obj46.gxTpr_Frequenciatratamentoid_Z;
         Z45TipoDescarteId = obj46.gxTpr_Tipodescarteid_Z;
         Z48TempoRetencaoId = obj46.gxTpr_Temporetencaoid_Z;
         Z78DocumentoPrevColetaDados = obj46.gxTpr_Documentoprevcoletadados_Z;
         Z79DocumentoBaseLegalNorm = obj46.gxTpr_Documentobaselegalnorm_Z;
         Z80DocumentoBaseLegalNormIntExt = obj46.gxTpr_Documentobaselegalnormintext_Z;
         Z81DocumentoDadosCriancaAdolesc = obj46.gxTpr_Documentodadoscriancaadolesc_Z;
         Z82DocumentoDadosGrupoVul = obj46.gxTpr_Documentodadosgrupovul_Z;
         Z85DocumentoAtivo = obj46.gxTpr_Documentoativo_Z;
         Z105DocumentoOperador = obj46.gxTpr_Documentooperador_Z;
         Z106DocumentoProcessoId = obj46.gxTpr_Documentoprocessoid_Z;
         Z107DocumentoProcessoNome = obj46.gxTpr_Documentoprocessonome_Z;
         Z108DocumentoDataInclusao = obj46.gxTpr_Documentodatainclusao_Z;
         Z109DocumentoDataAlteracao = obj46.gxTpr_Documentodataalteracao_Z;
         Z110DocumentoControladorId = obj46.gxTpr_Documentocontroladorid_Z;
         Z24AreaResponsavelId = obj46.gxTpr_Arearesponsavelid_Z;
         Z141DocumentoUsuarioInclusao = obj46.gxTpr_Documentousuarioinclusao_Z;
         Z142DocumentoUsuarioAlteracao = obj46.gxTpr_Documentousuarioalteracao_Z;
         Z143DocumentoIsOperador = obj46.gxTpr_Documentoisoperador_Z;
         n76DocumentoNome = (bool)(Convert.ToBoolean(obj46.gxTpr_Documentonome_N));
         n20SubprocessoId = (bool)(Convert.ToBoolean(obj46.gxTpr_Subprocessoid_N));
         n7EncarregadoId = (bool)(Convert.ToBoolean(obj46.gxTpr_Encarregadoid_N));
         n13PersonaId = (bool)(Convert.ToBoolean(obj46.gxTpr_Personaid_N));
         n77DocumentoFinalidadeTratamento = (bool)(Convert.ToBoolean(obj46.gxTpr_Documentofinalidadetratamento_N));
         n27CategoriaId = (bool)(Convert.ToBoolean(obj46.gxTpr_Categoriaid_N));
         n30TipoDadoId = (bool)(Convert.ToBoolean(obj46.gxTpr_Tipodadoid_N));
         n33FerramentaColetaId = (bool)(Convert.ToBoolean(obj46.gxTpr_Ferramentacoletaid_N));
         n36AbrangenciaGeograficaId = (bool)(Convert.ToBoolean(obj46.gxTpr_Abrangenciageograficaid_N));
         n39FrequenciaTratamentoId = (bool)(Convert.ToBoolean(obj46.gxTpr_Frequenciatratamentoid_N));
         n45TipoDescarteId = (bool)(Convert.ToBoolean(obj46.gxTpr_Tipodescarteid_N));
         n48TempoRetencaoId = (bool)(Convert.ToBoolean(obj46.gxTpr_Temporetencaoid_N));
         n78DocumentoPrevColetaDados = (bool)(Convert.ToBoolean(obj46.gxTpr_Documentoprevcoletadados_N));
         n79DocumentoBaseLegalNorm = (bool)(Convert.ToBoolean(obj46.gxTpr_Documentobaselegalnorm_N));
         n80DocumentoBaseLegalNormIntExt = (bool)(Convert.ToBoolean(obj46.gxTpr_Documentobaselegalnormintext_N));
         n81DocumentoDadosCriancaAdolesc = (bool)(Convert.ToBoolean(obj46.gxTpr_Documentodadoscriancaadolesc_N));
         n82DocumentoDadosGrupoVul = (bool)(Convert.ToBoolean(obj46.gxTpr_Documentodadosgrupovul_N));
         n83DocumentoMedidaSegurancaDesc = (bool)(Convert.ToBoolean(obj46.gxTpr_Documentomedidasegurancadesc_N));
         n84DocumentoFluxoTratDadosDesc = (bool)(Convert.ToBoolean(obj46.gxTpr_Documentofluxotratdadosdesc_N));
         n85DocumentoAtivo = (bool)(Convert.ToBoolean(obj46.gxTpr_Documentoativo_N));
         n105DocumentoOperador = (bool)(Convert.ToBoolean(obj46.gxTpr_Documentooperador_N));
         n106DocumentoProcessoId = (bool)(Convert.ToBoolean(obj46.gxTpr_Documentoprocessoid_N));
         n108DocumentoDataInclusao = (bool)(Convert.ToBoolean(obj46.gxTpr_Documentodatainclusao_N));
         n109DocumentoDataAlteracao = (bool)(Convert.ToBoolean(obj46.gxTpr_Documentodataalteracao_N));
         n110DocumentoControladorId = (bool)(Convert.ToBoolean(obj46.gxTpr_Documentocontroladorid_N));
         n24AreaResponsavelId = (bool)(Convert.ToBoolean(obj46.gxTpr_Arearesponsavelid_N));
         n141DocumentoUsuarioInclusao = (bool)(Convert.ToBoolean(obj46.gxTpr_Documentousuarioinclusao_N));
         n142DocumentoUsuarioAlteracao = (bool)(Convert.ToBoolean(obj46.gxTpr_Documentousuarioalteracao_N));
         n143DocumentoIsOperador = (bool)(Convert.ToBoolean(obj46.gxTpr_Documentoisoperador_N));
         Gx_mode = obj46.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A75DocumentoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1346( ) ;
         ScanKeyStart1346( ) ;
         if ( RcdFound46 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z75DocumentoId = A75DocumentoId;
         }
         ZM1346( -16) ;
         OnLoadActions1346( ) ;
         AddRow1346( ) ;
         ScanKeyEnd1346( ) ;
         if ( RcdFound46 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars46( bcDocumento, 0) ;
         ScanKeyStart1346( ) ;
         if ( RcdFound46 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z75DocumentoId = A75DocumentoId;
         }
         ZM1346( -16) ;
         OnLoadActions1346( ) ;
         AddRow1346( ) ;
         ScanKeyEnd1346( ) ;
         if ( RcdFound46 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey1346( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1346( ) ;
         }
         else
         {
            if ( RcdFound46 == 1 )
            {
               if ( A75DocumentoId != Z75DocumentoId )
               {
                  A75DocumentoId = Z75DocumentoId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update1346( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A75DocumentoId != Z75DocumentoId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert1346( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert1346( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars46( bcDocumento, 1) ;
         SaveImpl( ) ;
         VarsToRow46( bcDocumento) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars46( bcDocumento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1346( ) ;
         AfterTrn( ) ;
         VarsToRow46( bcDocumento) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
         }
         else
         {
            SdtDocumento auxBC = new SdtDocumento(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A75DocumentoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcDocumento);
               auxBC.Save();
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars46( bcDocumento, 1) ;
         UpdateImpl( ) ;
         VarsToRow46( bcDocumento) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars46( bcDocumento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1346( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
         }
         else
         {
            AfterTrn( ) ;
         }
         VarsToRow46( bcDocumento) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars46( bcDocumento, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey1346( ) ;
         if ( RcdFound46 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A75DocumentoId != Z75DocumentoId )
            {
               A75DocumentoId = Z75DocumentoId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A75DocumentoId != Z75DocumentoId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         pr_default.close(20);
         context.RollbackDataStores("documento_bc",pr_default);
         VarsToRow46( bcDocumento) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcDocumento.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcDocumento.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcDocumento )
         {
            bcDocumento = (SdtDocumento)(sdt);
            if ( StringUtil.StrCmp(bcDocumento.gxTpr_Mode, "") == 0 )
            {
               bcDocumento.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow46( bcDocumento) ;
            }
            else
            {
               RowToVars46( bcDocumento, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcDocumento.gxTpr_Mode, "") == 0 )
            {
               bcDocumento.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars46( bcDocumento, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtDocumento Documento_BC
      {
         get {
            return bcDocumento ;
         }

      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "documento_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
      }

      protected override void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(20);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV61Pgmname = "";
         AV24TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z109DocumentoDataAlteracao = (DateTime)(DateTime.MinValue);
         A109DocumentoDataAlteracao = (DateTime)(DateTime.MinValue);
         Z142DocumentoUsuarioAlteracao = "";
         A142DocumentoUsuarioAlteracao = "";
         Z76DocumentoNome = "";
         A76DocumentoNome = "";
         Z77DocumentoFinalidadeTratamento = "";
         A77DocumentoFinalidadeTratamento = "";
         Z79DocumentoBaseLegalNorm = "";
         A79DocumentoBaseLegalNorm = "";
         Z80DocumentoBaseLegalNormIntExt = "";
         A80DocumentoBaseLegalNormIntExt = "";
         Z108DocumentoDataInclusao = (DateTime)(DateTime.MinValue);
         A108DocumentoDataInclusao = (DateTime)(DateTime.MinValue);
         Z141DocumentoUsuarioInclusao = "";
         A141DocumentoUsuarioInclusao = "";
         Z107DocumentoProcessoNome = "";
         A107DocumentoProcessoNome = "";
         Z83DocumentoMedidaSegurancaDesc = "";
         A83DocumentoMedidaSegurancaDesc = "";
         Z84DocumentoFluxoTratDadosDesc = "";
         A84DocumentoFluxoTratDadosDesc = "";
         BC001317_A75DocumentoId = new int[1] ;
         BC001317_A109DocumentoDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         BC001317_n109DocumentoDataAlteracao = new bool[] {false} ;
         BC001317_A142DocumentoUsuarioAlteracao = new string[] {""} ;
         BC001317_n142DocumentoUsuarioAlteracao = new bool[] {false} ;
         BC001317_A76DocumentoNome = new string[] {""} ;
         BC001317_n76DocumentoNome = new bool[] {false} ;
         BC001317_A77DocumentoFinalidadeTratamento = new string[] {""} ;
         BC001317_n77DocumentoFinalidadeTratamento = new bool[] {false} ;
         BC001317_A79DocumentoBaseLegalNorm = new string[] {""} ;
         BC001317_n79DocumentoBaseLegalNorm = new bool[] {false} ;
         BC001317_A80DocumentoBaseLegalNormIntExt = new string[] {""} ;
         BC001317_n80DocumentoBaseLegalNormIntExt = new bool[] {false} ;
         BC001317_A83DocumentoMedidaSegurancaDesc = new string[] {""} ;
         BC001317_n83DocumentoMedidaSegurancaDesc = new bool[] {false} ;
         BC001317_A78DocumentoPrevColetaDados = new bool[] {false} ;
         BC001317_n78DocumentoPrevColetaDados = new bool[] {false} ;
         BC001317_A81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         BC001317_n81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         BC001317_A82DocumentoDadosGrupoVul = new bool[] {false} ;
         BC001317_n82DocumentoDadosGrupoVul = new bool[] {false} ;
         BC001317_A84DocumentoFluxoTratDadosDesc = new string[] {""} ;
         BC001317_n84DocumentoFluxoTratDadosDesc = new bool[] {false} ;
         BC001317_A85DocumentoAtivo = new bool[] {false} ;
         BC001317_n85DocumentoAtivo = new bool[] {false} ;
         BC001317_A105DocumentoOperador = new bool[] {false} ;
         BC001317_n105DocumentoOperador = new bool[] {false} ;
         BC001317_A107DocumentoProcessoNome = new string[] {""} ;
         BC001317_A108DocumentoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         BC001317_n108DocumentoDataInclusao = new bool[] {false} ;
         BC001317_A141DocumentoUsuarioInclusao = new string[] {""} ;
         BC001317_n141DocumentoUsuarioInclusao = new bool[] {false} ;
         BC001317_A143DocumentoIsOperador = new bool[] {false} ;
         BC001317_n143DocumentoIsOperador = new bool[] {false} ;
         BC001317_A20SubprocessoId = new int[1] ;
         BC001317_n20SubprocessoId = new bool[] {false} ;
         BC001317_A7EncarregadoId = new int[1] ;
         BC001317_n7EncarregadoId = new bool[] {false} ;
         BC001317_A13PersonaId = new int[1] ;
         BC001317_n13PersonaId = new bool[] {false} ;
         BC001317_A27CategoriaId = new int[1] ;
         BC001317_n27CategoriaId = new bool[] {false} ;
         BC001317_A30TipoDadoId = new int[1] ;
         BC001317_n30TipoDadoId = new bool[] {false} ;
         BC001317_A33FerramentaColetaId = new int[1] ;
         BC001317_n33FerramentaColetaId = new bool[] {false} ;
         BC001317_A36AbrangenciaGeograficaId = new int[1] ;
         BC001317_n36AbrangenciaGeograficaId = new bool[] {false} ;
         BC001317_A39FrequenciaTratamentoId = new int[1] ;
         BC001317_n39FrequenciaTratamentoId = new bool[] {false} ;
         BC001317_A45TipoDescarteId = new int[1] ;
         BC001317_n45TipoDescarteId = new bool[] {false} ;
         BC001317_A48TempoRetencaoId = new int[1] ;
         BC001317_n48TempoRetencaoId = new bool[] {false} ;
         BC001317_A24AreaResponsavelId = new int[1] ;
         BC001317_n24AreaResponsavelId = new bool[] {false} ;
         BC001317_A106DocumentoProcessoId = new int[1] ;
         BC001317_n106DocumentoProcessoId = new bool[] {false} ;
         BC001317_A110DocumentoControladorId = new int[1] ;
         BC001317_n110DocumentoControladorId = new bool[] {false} ;
         BC00134_A20SubprocessoId = new int[1] ;
         BC00134_n20SubprocessoId = new bool[] {false} ;
         BC00135_A7EncarregadoId = new int[1] ;
         BC00135_n7EncarregadoId = new bool[] {false} ;
         BC00136_A13PersonaId = new int[1] ;
         BC00136_n13PersonaId = new bool[] {false} ;
         BC00137_A27CategoriaId = new int[1] ;
         BC00137_n27CategoriaId = new bool[] {false} ;
         BC00138_A30TipoDadoId = new int[1] ;
         BC00138_n30TipoDadoId = new bool[] {false} ;
         BC00139_A33FerramentaColetaId = new int[1] ;
         BC00139_n33FerramentaColetaId = new bool[] {false} ;
         BC001310_A36AbrangenciaGeograficaId = new int[1] ;
         BC001310_n36AbrangenciaGeograficaId = new bool[] {false} ;
         BC001311_A39FrequenciaTratamentoId = new int[1] ;
         BC001311_n39FrequenciaTratamentoId = new bool[] {false} ;
         BC001312_A45TipoDescarteId = new int[1] ;
         BC001312_n45TipoDescarteId = new bool[] {false} ;
         BC001313_A48TempoRetencaoId = new int[1] ;
         BC001313_n48TempoRetencaoId = new bool[] {false} ;
         BC001315_A107DocumentoProcessoNome = new string[] {""} ;
         BC001316_A110DocumentoControladorId = new int[1] ;
         BC001316_n110DocumentoControladorId = new bool[] {false} ;
         BC001314_A24AreaResponsavelId = new int[1] ;
         BC001314_n24AreaResponsavelId = new bool[] {false} ;
         BC001318_A75DocumentoId = new int[1] ;
         BC00133_A75DocumentoId = new int[1] ;
         BC00133_A109DocumentoDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         BC00133_n109DocumentoDataAlteracao = new bool[] {false} ;
         BC00133_A142DocumentoUsuarioAlteracao = new string[] {""} ;
         BC00133_n142DocumentoUsuarioAlteracao = new bool[] {false} ;
         BC00133_A76DocumentoNome = new string[] {""} ;
         BC00133_n76DocumentoNome = new bool[] {false} ;
         BC00133_A77DocumentoFinalidadeTratamento = new string[] {""} ;
         BC00133_n77DocumentoFinalidadeTratamento = new bool[] {false} ;
         BC00133_A79DocumentoBaseLegalNorm = new string[] {""} ;
         BC00133_n79DocumentoBaseLegalNorm = new bool[] {false} ;
         BC00133_A80DocumentoBaseLegalNormIntExt = new string[] {""} ;
         BC00133_n80DocumentoBaseLegalNormIntExt = new bool[] {false} ;
         BC00133_A83DocumentoMedidaSegurancaDesc = new string[] {""} ;
         BC00133_n83DocumentoMedidaSegurancaDesc = new bool[] {false} ;
         BC00133_A78DocumentoPrevColetaDados = new bool[] {false} ;
         BC00133_n78DocumentoPrevColetaDados = new bool[] {false} ;
         BC00133_A81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         BC00133_n81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         BC00133_A82DocumentoDadosGrupoVul = new bool[] {false} ;
         BC00133_n82DocumentoDadosGrupoVul = new bool[] {false} ;
         BC00133_A84DocumentoFluxoTratDadosDesc = new string[] {""} ;
         BC00133_n84DocumentoFluxoTratDadosDesc = new bool[] {false} ;
         BC00133_A85DocumentoAtivo = new bool[] {false} ;
         BC00133_n85DocumentoAtivo = new bool[] {false} ;
         BC00133_A105DocumentoOperador = new bool[] {false} ;
         BC00133_n105DocumentoOperador = new bool[] {false} ;
         BC00133_A108DocumentoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         BC00133_n108DocumentoDataInclusao = new bool[] {false} ;
         BC00133_A141DocumentoUsuarioInclusao = new string[] {""} ;
         BC00133_n141DocumentoUsuarioInclusao = new bool[] {false} ;
         BC00133_A143DocumentoIsOperador = new bool[] {false} ;
         BC00133_n143DocumentoIsOperador = new bool[] {false} ;
         BC00133_A20SubprocessoId = new int[1] ;
         BC00133_n20SubprocessoId = new bool[] {false} ;
         BC00133_A7EncarregadoId = new int[1] ;
         BC00133_n7EncarregadoId = new bool[] {false} ;
         BC00133_A13PersonaId = new int[1] ;
         BC00133_n13PersonaId = new bool[] {false} ;
         BC00133_A27CategoriaId = new int[1] ;
         BC00133_n27CategoriaId = new bool[] {false} ;
         BC00133_A30TipoDadoId = new int[1] ;
         BC00133_n30TipoDadoId = new bool[] {false} ;
         BC00133_A33FerramentaColetaId = new int[1] ;
         BC00133_n33FerramentaColetaId = new bool[] {false} ;
         BC00133_A36AbrangenciaGeograficaId = new int[1] ;
         BC00133_n36AbrangenciaGeograficaId = new bool[] {false} ;
         BC00133_A39FrequenciaTratamentoId = new int[1] ;
         BC00133_n39FrequenciaTratamentoId = new bool[] {false} ;
         BC00133_A45TipoDescarteId = new int[1] ;
         BC00133_n45TipoDescarteId = new bool[] {false} ;
         BC00133_A48TempoRetencaoId = new int[1] ;
         BC00133_n48TempoRetencaoId = new bool[] {false} ;
         BC00133_A24AreaResponsavelId = new int[1] ;
         BC00133_n24AreaResponsavelId = new bool[] {false} ;
         BC00133_A106DocumentoProcessoId = new int[1] ;
         BC00133_n106DocumentoProcessoId = new bool[] {false} ;
         BC00133_A110DocumentoControladorId = new int[1] ;
         BC00133_n110DocumentoControladorId = new bool[] {false} ;
         sMode46 = "";
         BC00132_A75DocumentoId = new int[1] ;
         BC00132_A109DocumentoDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         BC00132_n109DocumentoDataAlteracao = new bool[] {false} ;
         BC00132_A142DocumentoUsuarioAlteracao = new string[] {""} ;
         BC00132_n142DocumentoUsuarioAlteracao = new bool[] {false} ;
         BC00132_A76DocumentoNome = new string[] {""} ;
         BC00132_n76DocumentoNome = new bool[] {false} ;
         BC00132_A77DocumentoFinalidadeTratamento = new string[] {""} ;
         BC00132_n77DocumentoFinalidadeTratamento = new bool[] {false} ;
         BC00132_A79DocumentoBaseLegalNorm = new string[] {""} ;
         BC00132_n79DocumentoBaseLegalNorm = new bool[] {false} ;
         BC00132_A80DocumentoBaseLegalNormIntExt = new string[] {""} ;
         BC00132_n80DocumentoBaseLegalNormIntExt = new bool[] {false} ;
         BC00132_A83DocumentoMedidaSegurancaDesc = new string[] {""} ;
         BC00132_n83DocumentoMedidaSegurancaDesc = new bool[] {false} ;
         BC00132_A78DocumentoPrevColetaDados = new bool[] {false} ;
         BC00132_n78DocumentoPrevColetaDados = new bool[] {false} ;
         BC00132_A81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         BC00132_n81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         BC00132_A82DocumentoDadosGrupoVul = new bool[] {false} ;
         BC00132_n82DocumentoDadosGrupoVul = new bool[] {false} ;
         BC00132_A84DocumentoFluxoTratDadosDesc = new string[] {""} ;
         BC00132_n84DocumentoFluxoTratDadosDesc = new bool[] {false} ;
         BC00132_A85DocumentoAtivo = new bool[] {false} ;
         BC00132_n85DocumentoAtivo = new bool[] {false} ;
         BC00132_A105DocumentoOperador = new bool[] {false} ;
         BC00132_n105DocumentoOperador = new bool[] {false} ;
         BC00132_A108DocumentoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         BC00132_n108DocumentoDataInclusao = new bool[] {false} ;
         BC00132_A141DocumentoUsuarioInclusao = new string[] {""} ;
         BC00132_n141DocumentoUsuarioInclusao = new bool[] {false} ;
         BC00132_A143DocumentoIsOperador = new bool[] {false} ;
         BC00132_n143DocumentoIsOperador = new bool[] {false} ;
         BC00132_A20SubprocessoId = new int[1] ;
         BC00132_n20SubprocessoId = new bool[] {false} ;
         BC00132_A7EncarregadoId = new int[1] ;
         BC00132_n7EncarregadoId = new bool[] {false} ;
         BC00132_A13PersonaId = new int[1] ;
         BC00132_n13PersonaId = new bool[] {false} ;
         BC00132_A27CategoriaId = new int[1] ;
         BC00132_n27CategoriaId = new bool[] {false} ;
         BC00132_A30TipoDadoId = new int[1] ;
         BC00132_n30TipoDadoId = new bool[] {false} ;
         BC00132_A33FerramentaColetaId = new int[1] ;
         BC00132_n33FerramentaColetaId = new bool[] {false} ;
         BC00132_A36AbrangenciaGeograficaId = new int[1] ;
         BC00132_n36AbrangenciaGeograficaId = new bool[] {false} ;
         BC00132_A39FrequenciaTratamentoId = new int[1] ;
         BC00132_n39FrequenciaTratamentoId = new bool[] {false} ;
         BC00132_A45TipoDescarteId = new int[1] ;
         BC00132_n45TipoDescarteId = new bool[] {false} ;
         BC00132_A48TempoRetencaoId = new int[1] ;
         BC00132_n48TempoRetencaoId = new bool[] {false} ;
         BC00132_A24AreaResponsavelId = new int[1] ;
         BC00132_n24AreaResponsavelId = new bool[] {false} ;
         BC00132_A106DocumentoProcessoId = new int[1] ;
         BC00132_n106DocumentoProcessoId = new bool[] {false} ;
         BC00132_A110DocumentoControladorId = new int[1] ;
         BC00132_n110DocumentoControladorId = new bool[] {false} ;
         BC001319_A75DocumentoId = new int[1] ;
         BC001322_A107DocumentoProcessoNome = new string[] {""} ;
         BC001323_A144DocImagemId = new int[1] ;
         BC001324_A120RevisaoLogId = new int[1] ;
         BC001325_A93DocAnexoId = new int[1] ;
         BC001326_A86DocOperadorId = new int[1] ;
         BC001327_A98DocDicionarioId = new int[1] ;
         BC001328_A51MedidaSegurancaId = new int[1] ;
         BC001328_A75DocumentoId = new int[1] ;
         BC001329_A63FonteRetencaoId = new int[1] ;
         BC001329_A75DocumentoId = new int[1] ;
         BC001330_A60SetorInternoId = new int[1] ;
         BC001330_A75DocumentoId = new int[1] ;
         BC001331_A57CompartInternoId = new int[1] ;
         BC001331_A75DocumentoId = new int[1] ;
         BC001332_A54EnvolvidosColetaId = new int[1] ;
         BC001332_A75DocumentoId = new int[1] ;
         BC001333_A75DocumentoId = new int[1] ;
         BC001333_A109DocumentoDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         BC001333_n109DocumentoDataAlteracao = new bool[] {false} ;
         BC001333_A142DocumentoUsuarioAlteracao = new string[] {""} ;
         BC001333_n142DocumentoUsuarioAlteracao = new bool[] {false} ;
         BC001333_A76DocumentoNome = new string[] {""} ;
         BC001333_n76DocumentoNome = new bool[] {false} ;
         BC001333_A77DocumentoFinalidadeTratamento = new string[] {""} ;
         BC001333_n77DocumentoFinalidadeTratamento = new bool[] {false} ;
         BC001333_A79DocumentoBaseLegalNorm = new string[] {""} ;
         BC001333_n79DocumentoBaseLegalNorm = new bool[] {false} ;
         BC001333_A80DocumentoBaseLegalNormIntExt = new string[] {""} ;
         BC001333_n80DocumentoBaseLegalNormIntExt = new bool[] {false} ;
         BC001333_A83DocumentoMedidaSegurancaDesc = new string[] {""} ;
         BC001333_n83DocumentoMedidaSegurancaDesc = new bool[] {false} ;
         BC001333_A78DocumentoPrevColetaDados = new bool[] {false} ;
         BC001333_n78DocumentoPrevColetaDados = new bool[] {false} ;
         BC001333_A81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         BC001333_n81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         BC001333_A82DocumentoDadosGrupoVul = new bool[] {false} ;
         BC001333_n82DocumentoDadosGrupoVul = new bool[] {false} ;
         BC001333_A84DocumentoFluxoTratDadosDesc = new string[] {""} ;
         BC001333_n84DocumentoFluxoTratDadosDesc = new bool[] {false} ;
         BC001333_A85DocumentoAtivo = new bool[] {false} ;
         BC001333_n85DocumentoAtivo = new bool[] {false} ;
         BC001333_A105DocumentoOperador = new bool[] {false} ;
         BC001333_n105DocumentoOperador = new bool[] {false} ;
         BC001333_A107DocumentoProcessoNome = new string[] {""} ;
         BC001333_A108DocumentoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         BC001333_n108DocumentoDataInclusao = new bool[] {false} ;
         BC001333_A141DocumentoUsuarioInclusao = new string[] {""} ;
         BC001333_n141DocumentoUsuarioInclusao = new bool[] {false} ;
         BC001333_A143DocumentoIsOperador = new bool[] {false} ;
         BC001333_n143DocumentoIsOperador = new bool[] {false} ;
         BC001333_A20SubprocessoId = new int[1] ;
         BC001333_n20SubprocessoId = new bool[] {false} ;
         BC001333_A7EncarregadoId = new int[1] ;
         BC001333_n7EncarregadoId = new bool[] {false} ;
         BC001333_A13PersonaId = new int[1] ;
         BC001333_n13PersonaId = new bool[] {false} ;
         BC001333_A27CategoriaId = new int[1] ;
         BC001333_n27CategoriaId = new bool[] {false} ;
         BC001333_A30TipoDadoId = new int[1] ;
         BC001333_n30TipoDadoId = new bool[] {false} ;
         BC001333_A33FerramentaColetaId = new int[1] ;
         BC001333_n33FerramentaColetaId = new bool[] {false} ;
         BC001333_A36AbrangenciaGeograficaId = new int[1] ;
         BC001333_n36AbrangenciaGeograficaId = new bool[] {false} ;
         BC001333_A39FrequenciaTratamentoId = new int[1] ;
         BC001333_n39FrequenciaTratamentoId = new bool[] {false} ;
         BC001333_A45TipoDescarteId = new int[1] ;
         BC001333_n45TipoDescarteId = new bool[] {false} ;
         BC001333_A48TempoRetencaoId = new int[1] ;
         BC001333_n48TempoRetencaoId = new bool[] {false} ;
         BC001333_A24AreaResponsavelId = new int[1] ;
         BC001333_n24AreaResponsavelId = new bool[] {false} ;
         BC001333_A106DocumentoProcessoId = new int[1] ;
         BC001333_n106DocumentoProcessoId = new bool[] {false} ;
         BC001333_A110DocumentoControladorId = new int[1] ;
         BC001333_n110DocumentoControladorId = new bool[] {false} ;
         i108DocumentoDataInclusao = (DateTime)(DateTime.MinValue);
         i141DocumentoUsuarioInclusao = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.documento_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documento_bc__default(),
            new Object[][] {
                new Object[] {
               BC00132_A75DocumentoId, BC00132_A109DocumentoDataAlteracao, BC00132_n109DocumentoDataAlteracao, BC00132_A142DocumentoUsuarioAlteracao, BC00132_n142DocumentoUsuarioAlteracao, BC00132_A76DocumentoNome, BC00132_n76DocumentoNome, BC00132_A77DocumentoFinalidadeTratamento, BC00132_n77DocumentoFinalidadeTratamento, BC00132_A79DocumentoBaseLegalNorm,
               BC00132_n79DocumentoBaseLegalNorm, BC00132_A80DocumentoBaseLegalNormIntExt, BC00132_n80DocumentoBaseLegalNormIntExt, BC00132_A83DocumentoMedidaSegurancaDesc, BC00132_n83DocumentoMedidaSegurancaDesc, BC00132_A78DocumentoPrevColetaDados, BC00132_n78DocumentoPrevColetaDados, BC00132_A81DocumentoDadosCriancaAdolesc, BC00132_n81DocumentoDadosCriancaAdolesc, BC00132_A82DocumentoDadosGrupoVul,
               BC00132_n82DocumentoDadosGrupoVul, BC00132_A84DocumentoFluxoTratDadosDesc, BC00132_n84DocumentoFluxoTratDadosDesc, BC00132_A85DocumentoAtivo, BC00132_n85DocumentoAtivo, BC00132_A105DocumentoOperador, BC00132_n105DocumentoOperador, BC00132_A108DocumentoDataInclusao, BC00132_n108DocumentoDataInclusao, BC00132_A141DocumentoUsuarioInclusao,
               BC00132_n141DocumentoUsuarioInclusao, BC00132_A143DocumentoIsOperador, BC00132_n143DocumentoIsOperador, BC00132_A20SubprocessoId, BC00132_n20SubprocessoId, BC00132_A7EncarregadoId, BC00132_n7EncarregadoId, BC00132_A13PersonaId, BC00132_n13PersonaId, BC00132_A27CategoriaId,
               BC00132_n27CategoriaId, BC00132_A30TipoDadoId, BC00132_n30TipoDadoId, BC00132_A33FerramentaColetaId, BC00132_n33FerramentaColetaId, BC00132_A36AbrangenciaGeograficaId, BC00132_n36AbrangenciaGeograficaId, BC00132_A39FrequenciaTratamentoId, BC00132_n39FrequenciaTratamentoId, BC00132_A45TipoDescarteId,
               BC00132_n45TipoDescarteId, BC00132_A48TempoRetencaoId, BC00132_n48TempoRetencaoId, BC00132_A24AreaResponsavelId, BC00132_n24AreaResponsavelId, BC00132_A106DocumentoProcessoId, BC00132_n106DocumentoProcessoId, BC00132_A110DocumentoControladorId, BC00132_n110DocumentoControladorId
               }
               , new Object[] {
               BC00133_A75DocumentoId, BC00133_A109DocumentoDataAlteracao, BC00133_n109DocumentoDataAlteracao, BC00133_A142DocumentoUsuarioAlteracao, BC00133_n142DocumentoUsuarioAlteracao, BC00133_A76DocumentoNome, BC00133_n76DocumentoNome, BC00133_A77DocumentoFinalidadeTratamento, BC00133_n77DocumentoFinalidadeTratamento, BC00133_A79DocumentoBaseLegalNorm,
               BC00133_n79DocumentoBaseLegalNorm, BC00133_A80DocumentoBaseLegalNormIntExt, BC00133_n80DocumentoBaseLegalNormIntExt, BC00133_A83DocumentoMedidaSegurancaDesc, BC00133_n83DocumentoMedidaSegurancaDesc, BC00133_A78DocumentoPrevColetaDados, BC00133_n78DocumentoPrevColetaDados, BC00133_A81DocumentoDadosCriancaAdolesc, BC00133_n81DocumentoDadosCriancaAdolesc, BC00133_A82DocumentoDadosGrupoVul,
               BC00133_n82DocumentoDadosGrupoVul, BC00133_A84DocumentoFluxoTratDadosDesc, BC00133_n84DocumentoFluxoTratDadosDesc, BC00133_A85DocumentoAtivo, BC00133_n85DocumentoAtivo, BC00133_A105DocumentoOperador, BC00133_n105DocumentoOperador, BC00133_A108DocumentoDataInclusao, BC00133_n108DocumentoDataInclusao, BC00133_A141DocumentoUsuarioInclusao,
               BC00133_n141DocumentoUsuarioInclusao, BC00133_A143DocumentoIsOperador, BC00133_n143DocumentoIsOperador, BC00133_A20SubprocessoId, BC00133_n20SubprocessoId, BC00133_A7EncarregadoId, BC00133_n7EncarregadoId, BC00133_A13PersonaId, BC00133_n13PersonaId, BC00133_A27CategoriaId,
               BC00133_n27CategoriaId, BC00133_A30TipoDadoId, BC00133_n30TipoDadoId, BC00133_A33FerramentaColetaId, BC00133_n33FerramentaColetaId, BC00133_A36AbrangenciaGeograficaId, BC00133_n36AbrangenciaGeograficaId, BC00133_A39FrequenciaTratamentoId, BC00133_n39FrequenciaTratamentoId, BC00133_A45TipoDescarteId,
               BC00133_n45TipoDescarteId, BC00133_A48TempoRetencaoId, BC00133_n48TempoRetencaoId, BC00133_A24AreaResponsavelId, BC00133_n24AreaResponsavelId, BC00133_A106DocumentoProcessoId, BC00133_n106DocumentoProcessoId, BC00133_A110DocumentoControladorId, BC00133_n110DocumentoControladorId
               }
               , new Object[] {
               BC00134_A20SubprocessoId
               }
               , new Object[] {
               BC00135_A7EncarregadoId
               }
               , new Object[] {
               BC00136_A13PersonaId
               }
               , new Object[] {
               BC00137_A27CategoriaId
               }
               , new Object[] {
               BC00138_A30TipoDadoId
               }
               , new Object[] {
               BC00139_A33FerramentaColetaId
               }
               , new Object[] {
               BC001310_A36AbrangenciaGeograficaId
               }
               , new Object[] {
               BC001311_A39FrequenciaTratamentoId
               }
               , new Object[] {
               BC001312_A45TipoDescarteId
               }
               , new Object[] {
               BC001313_A48TempoRetencaoId
               }
               , new Object[] {
               BC001314_A24AreaResponsavelId
               }
               , new Object[] {
               BC001315_A107DocumentoProcessoNome
               }
               , new Object[] {
               BC001316_A110DocumentoControladorId
               }
               , new Object[] {
               BC001317_A75DocumentoId, BC001317_A109DocumentoDataAlteracao, BC001317_n109DocumentoDataAlteracao, BC001317_A142DocumentoUsuarioAlteracao, BC001317_n142DocumentoUsuarioAlteracao, BC001317_A76DocumentoNome, BC001317_n76DocumentoNome, BC001317_A77DocumentoFinalidadeTratamento, BC001317_n77DocumentoFinalidadeTratamento, BC001317_A79DocumentoBaseLegalNorm,
               BC001317_n79DocumentoBaseLegalNorm, BC001317_A80DocumentoBaseLegalNormIntExt, BC001317_n80DocumentoBaseLegalNormIntExt, BC001317_A83DocumentoMedidaSegurancaDesc, BC001317_n83DocumentoMedidaSegurancaDesc, BC001317_A78DocumentoPrevColetaDados, BC001317_n78DocumentoPrevColetaDados, BC001317_A81DocumentoDadosCriancaAdolesc, BC001317_n81DocumentoDadosCriancaAdolesc, BC001317_A82DocumentoDadosGrupoVul,
               BC001317_n82DocumentoDadosGrupoVul, BC001317_A84DocumentoFluxoTratDadosDesc, BC001317_n84DocumentoFluxoTratDadosDesc, BC001317_A85DocumentoAtivo, BC001317_n85DocumentoAtivo, BC001317_A105DocumentoOperador, BC001317_n105DocumentoOperador, BC001317_A107DocumentoProcessoNome, BC001317_A108DocumentoDataInclusao, BC001317_n108DocumentoDataInclusao,
               BC001317_A141DocumentoUsuarioInclusao, BC001317_n141DocumentoUsuarioInclusao, BC001317_A143DocumentoIsOperador, BC001317_n143DocumentoIsOperador, BC001317_A20SubprocessoId, BC001317_n20SubprocessoId, BC001317_A7EncarregadoId, BC001317_n7EncarregadoId, BC001317_A13PersonaId, BC001317_n13PersonaId,
               BC001317_A27CategoriaId, BC001317_n27CategoriaId, BC001317_A30TipoDadoId, BC001317_n30TipoDadoId, BC001317_A33FerramentaColetaId, BC001317_n33FerramentaColetaId, BC001317_A36AbrangenciaGeograficaId, BC001317_n36AbrangenciaGeograficaId, BC001317_A39FrequenciaTratamentoId, BC001317_n39FrequenciaTratamentoId,
               BC001317_A45TipoDescarteId, BC001317_n45TipoDescarteId, BC001317_A48TempoRetencaoId, BC001317_n48TempoRetencaoId, BC001317_A24AreaResponsavelId, BC001317_n24AreaResponsavelId, BC001317_A106DocumentoProcessoId, BC001317_n106DocumentoProcessoId, BC001317_A110DocumentoControladorId, BC001317_n110DocumentoControladorId
               }
               , new Object[] {
               BC001318_A75DocumentoId
               }
               , new Object[] {
               BC001319_A75DocumentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001322_A107DocumentoProcessoNome
               }
               , new Object[] {
               BC001323_A144DocImagemId
               }
               , new Object[] {
               BC001324_A120RevisaoLogId
               }
               , new Object[] {
               BC001325_A93DocAnexoId
               }
               , new Object[] {
               BC001326_A86DocOperadorId
               }
               , new Object[] {
               BC001327_A98DocDicionarioId
               }
               , new Object[] {
               BC001328_A51MedidaSegurancaId, BC001328_A75DocumentoId
               }
               , new Object[] {
               BC001329_A63FonteRetencaoId, BC001329_A75DocumentoId
               }
               , new Object[] {
               BC001330_A60SetorInternoId, BC001330_A75DocumentoId
               }
               , new Object[] {
               BC001331_A57CompartInternoId, BC001331_A75DocumentoId
               }
               , new Object[] {
               BC001332_A54EnvolvidosColetaId, BC001332_A75DocumentoId
               }
               , new Object[] {
               BC001333_A75DocumentoId, BC001333_A109DocumentoDataAlteracao, BC001333_n109DocumentoDataAlteracao, BC001333_A142DocumentoUsuarioAlteracao, BC001333_n142DocumentoUsuarioAlteracao, BC001333_A76DocumentoNome, BC001333_n76DocumentoNome, BC001333_A77DocumentoFinalidadeTratamento, BC001333_n77DocumentoFinalidadeTratamento, BC001333_A79DocumentoBaseLegalNorm,
               BC001333_n79DocumentoBaseLegalNorm, BC001333_A80DocumentoBaseLegalNormIntExt, BC001333_n80DocumentoBaseLegalNormIntExt, BC001333_A83DocumentoMedidaSegurancaDesc, BC001333_n83DocumentoMedidaSegurancaDesc, BC001333_A78DocumentoPrevColetaDados, BC001333_n78DocumentoPrevColetaDados, BC001333_A81DocumentoDadosCriancaAdolesc, BC001333_n81DocumentoDadosCriancaAdolesc, BC001333_A82DocumentoDadosGrupoVul,
               BC001333_n82DocumentoDadosGrupoVul, BC001333_A84DocumentoFluxoTratDadosDesc, BC001333_n84DocumentoFluxoTratDadosDesc, BC001333_A85DocumentoAtivo, BC001333_n85DocumentoAtivo, BC001333_A105DocumentoOperador, BC001333_n105DocumentoOperador, BC001333_A107DocumentoProcessoNome, BC001333_A108DocumentoDataInclusao, BC001333_n108DocumentoDataInclusao,
               BC001333_A141DocumentoUsuarioInclusao, BC001333_n141DocumentoUsuarioInclusao, BC001333_A143DocumentoIsOperador, BC001333_n143DocumentoIsOperador, BC001333_A20SubprocessoId, BC001333_n20SubprocessoId, BC001333_A7EncarregadoId, BC001333_n7EncarregadoId, BC001333_A13PersonaId, BC001333_n13PersonaId,
               BC001333_A27CategoriaId, BC001333_n27CategoriaId, BC001333_A30TipoDadoId, BC001333_n30TipoDadoId, BC001333_A33FerramentaColetaId, BC001333_n33FerramentaColetaId, BC001333_A36AbrangenciaGeograficaId, BC001333_n36AbrangenciaGeograficaId, BC001333_A39FrequenciaTratamentoId, BC001333_n39FrequenciaTratamentoId,
               BC001333_A45TipoDescarteId, BC001333_n45TipoDescarteId, BC001333_A48TempoRetencaoId, BC001333_n48TempoRetencaoId, BC001333_A24AreaResponsavelId, BC001333_n24AreaResponsavelId, BC001333_A106DocumentoProcessoId, BC001333_n106DocumentoProcessoId, BC001333_A110DocumentoControladorId, BC001333_n110DocumentoControladorId
               }
            }
         );
         AV61Pgmname = "Documento_BC";
         Z143DocumentoIsOperador = false;
         n143DocumentoIsOperador = false;
         A143DocumentoIsOperador = false;
         n143DocumentoIsOperador = false;
         i143DocumentoIsOperador = false;
         n143DocumentoIsOperador = false;
         Z141DocumentoUsuarioInclusao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         n141DocumentoUsuarioInclusao = false;
         A141DocumentoUsuarioInclusao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         n141DocumentoUsuarioInclusao = false;
         i141DocumentoUsuarioInclusao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         n141DocumentoUsuarioInclusao = false;
         Z108DocumentoDataInclusao = DateTimeUtil.ServerNow( context, pr_default);
         n108DocumentoDataInclusao = false;
         A108DocumentoDataInclusao = DateTimeUtil.ServerNow( context, pr_default);
         n108DocumentoDataInclusao = false;
         i108DocumentoDataInclusao = DateTimeUtil.ServerNow( context, pr_default);
         n108DocumentoDataInclusao = false;
         Z85DocumentoAtivo = true;
         n85DocumentoAtivo = false;
         A85DocumentoAtivo = true;
         n85DocumentoAtivo = false;
         i85DocumentoAtivo = true;
         n85DocumentoAtivo = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12132 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short AV57count ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound46 ;
      private short nIsDirty_46 ;
      private int trnEnded ;
      private int Z75DocumentoId ;
      private int A75DocumentoId ;
      private int AV62GXV1 ;
      private int AV13Insert_SubprocessoId ;
      private int AV14Insert_EncarregadoId ;
      private int AV15Insert_PersonaId ;
      private int AV16Insert_CategoriaId ;
      private int AV17Insert_TipoDadoId ;
      private int AV18Insert_FerramentaColetaId ;
      private int AV19Insert_AbrangenciaGeograficaId ;
      private int AV20Insert_FrequenciaTratamentoId ;
      private int AV21Insert_TipoDescarteId ;
      private int AV22Insert_TempoRetencaoId ;
      private int AV53Insert_DocumentoProcessoId ;
      private int AV58Insert_DocumentoControladorId ;
      private int AV59Insert_AreaResponsavelId ;
      private int Z20SubprocessoId ;
      private int A20SubprocessoId ;
      private int Z7EncarregadoId ;
      private int A7EncarregadoId ;
      private int Z13PersonaId ;
      private int A13PersonaId ;
      private int Z27CategoriaId ;
      private int A27CategoriaId ;
      private int Z30TipoDadoId ;
      private int A30TipoDadoId ;
      private int Z33FerramentaColetaId ;
      private int A33FerramentaColetaId ;
      private int Z36AbrangenciaGeograficaId ;
      private int A36AbrangenciaGeograficaId ;
      private int Z39FrequenciaTratamentoId ;
      private int A39FrequenciaTratamentoId ;
      private int Z45TipoDescarteId ;
      private int A45TipoDescarteId ;
      private int Z48TempoRetencaoId ;
      private int A48TempoRetencaoId ;
      private int Z24AreaResponsavelId ;
      private int A24AreaResponsavelId ;
      private int Z106DocumentoProcessoId ;
      private int A106DocumentoProcessoId ;
      private int Z110DocumentoControladorId ;
      private int A110DocumentoControladorId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV61Pgmname ;
      private string sMode46 ;
      private DateTime Z109DocumentoDataAlteracao ;
      private DateTime A109DocumentoDataAlteracao ;
      private DateTime Z108DocumentoDataInclusao ;
      private DateTime A108DocumentoDataInclusao ;
      private DateTime i108DocumentoDataInclusao ;
      private bool returnInSub ;
      private bool Z78DocumentoPrevColetaDados ;
      private bool A78DocumentoPrevColetaDados ;
      private bool Z81DocumentoDadosCriancaAdolesc ;
      private bool A81DocumentoDadosCriancaAdolesc ;
      private bool Z82DocumentoDadosGrupoVul ;
      private bool A82DocumentoDadosGrupoVul ;
      private bool Z85DocumentoAtivo ;
      private bool A85DocumentoAtivo ;
      private bool Z105DocumentoOperador ;
      private bool A105DocumentoOperador ;
      private bool Z143DocumentoIsOperador ;
      private bool A143DocumentoIsOperador ;
      private bool n85DocumentoAtivo ;
      private bool n108DocumentoDataInclusao ;
      private bool n141DocumentoUsuarioInclusao ;
      private bool n143DocumentoIsOperador ;
      private bool n109DocumentoDataAlteracao ;
      private bool n142DocumentoUsuarioAlteracao ;
      private bool n76DocumentoNome ;
      private bool n77DocumentoFinalidadeTratamento ;
      private bool n79DocumentoBaseLegalNorm ;
      private bool n80DocumentoBaseLegalNormIntExt ;
      private bool n83DocumentoMedidaSegurancaDesc ;
      private bool n78DocumentoPrevColetaDados ;
      private bool n81DocumentoDadosCriancaAdolesc ;
      private bool n82DocumentoDadosGrupoVul ;
      private bool n84DocumentoFluxoTratDadosDesc ;
      private bool n105DocumentoOperador ;
      private bool n20SubprocessoId ;
      private bool n7EncarregadoId ;
      private bool n13PersonaId ;
      private bool n27CategoriaId ;
      private bool n30TipoDadoId ;
      private bool n33FerramentaColetaId ;
      private bool n36AbrangenciaGeograficaId ;
      private bool n39FrequenciaTratamentoId ;
      private bool n45TipoDescarteId ;
      private bool n48TempoRetencaoId ;
      private bool n24AreaResponsavelId ;
      private bool n106DocumentoProcessoId ;
      private bool n110DocumentoControladorId ;
      private bool Gx_longc ;
      private bool i85DocumentoAtivo ;
      private bool i143DocumentoIsOperador ;
      private bool mustCommit ;
      private string Z83DocumentoMedidaSegurancaDesc ;
      private string A83DocumentoMedidaSegurancaDesc ;
      private string Z84DocumentoFluxoTratDadosDesc ;
      private string A84DocumentoFluxoTratDadosDesc ;
      private string Z142DocumentoUsuarioAlteracao ;
      private string A142DocumentoUsuarioAlteracao ;
      private string Z76DocumentoNome ;
      private string A76DocumentoNome ;
      private string Z77DocumentoFinalidadeTratamento ;
      private string A77DocumentoFinalidadeTratamento ;
      private string Z79DocumentoBaseLegalNorm ;
      private string A79DocumentoBaseLegalNorm ;
      private string Z80DocumentoBaseLegalNormIntExt ;
      private string A80DocumentoBaseLegalNormIntExt ;
      private string Z141DocumentoUsuarioInclusao ;
      private string A141DocumentoUsuarioInclusao ;
      private string Z107DocumentoProcessoNome ;
      private string A107DocumentoProcessoNome ;
      private string i141DocumentoUsuarioInclusao ;
      private IGxSession AV12WebSession ;
      private SdtDocumento bcDocumento ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC001317_A75DocumentoId ;
      private DateTime[] BC001317_A109DocumentoDataAlteracao ;
      private bool[] BC001317_n109DocumentoDataAlteracao ;
      private string[] BC001317_A142DocumentoUsuarioAlteracao ;
      private bool[] BC001317_n142DocumentoUsuarioAlteracao ;
      private string[] BC001317_A76DocumentoNome ;
      private bool[] BC001317_n76DocumentoNome ;
      private string[] BC001317_A77DocumentoFinalidadeTratamento ;
      private bool[] BC001317_n77DocumentoFinalidadeTratamento ;
      private string[] BC001317_A79DocumentoBaseLegalNorm ;
      private bool[] BC001317_n79DocumentoBaseLegalNorm ;
      private string[] BC001317_A80DocumentoBaseLegalNormIntExt ;
      private bool[] BC001317_n80DocumentoBaseLegalNormIntExt ;
      private string[] BC001317_A83DocumentoMedidaSegurancaDesc ;
      private bool[] BC001317_n83DocumentoMedidaSegurancaDesc ;
      private bool[] BC001317_A78DocumentoPrevColetaDados ;
      private bool[] BC001317_n78DocumentoPrevColetaDados ;
      private bool[] BC001317_A81DocumentoDadosCriancaAdolesc ;
      private bool[] BC001317_n81DocumentoDadosCriancaAdolesc ;
      private bool[] BC001317_A82DocumentoDadosGrupoVul ;
      private bool[] BC001317_n82DocumentoDadosGrupoVul ;
      private string[] BC001317_A84DocumentoFluxoTratDadosDesc ;
      private bool[] BC001317_n84DocumentoFluxoTratDadosDesc ;
      private bool[] BC001317_A85DocumentoAtivo ;
      private bool[] BC001317_n85DocumentoAtivo ;
      private bool[] BC001317_A105DocumentoOperador ;
      private bool[] BC001317_n105DocumentoOperador ;
      private string[] BC001317_A107DocumentoProcessoNome ;
      private DateTime[] BC001317_A108DocumentoDataInclusao ;
      private bool[] BC001317_n108DocumentoDataInclusao ;
      private string[] BC001317_A141DocumentoUsuarioInclusao ;
      private bool[] BC001317_n141DocumentoUsuarioInclusao ;
      private bool[] BC001317_A143DocumentoIsOperador ;
      private bool[] BC001317_n143DocumentoIsOperador ;
      private int[] BC001317_A20SubprocessoId ;
      private bool[] BC001317_n20SubprocessoId ;
      private int[] BC001317_A7EncarregadoId ;
      private bool[] BC001317_n7EncarregadoId ;
      private int[] BC001317_A13PersonaId ;
      private bool[] BC001317_n13PersonaId ;
      private int[] BC001317_A27CategoriaId ;
      private bool[] BC001317_n27CategoriaId ;
      private int[] BC001317_A30TipoDadoId ;
      private bool[] BC001317_n30TipoDadoId ;
      private int[] BC001317_A33FerramentaColetaId ;
      private bool[] BC001317_n33FerramentaColetaId ;
      private int[] BC001317_A36AbrangenciaGeograficaId ;
      private bool[] BC001317_n36AbrangenciaGeograficaId ;
      private int[] BC001317_A39FrequenciaTratamentoId ;
      private bool[] BC001317_n39FrequenciaTratamentoId ;
      private int[] BC001317_A45TipoDescarteId ;
      private bool[] BC001317_n45TipoDescarteId ;
      private int[] BC001317_A48TempoRetencaoId ;
      private bool[] BC001317_n48TempoRetencaoId ;
      private int[] BC001317_A24AreaResponsavelId ;
      private bool[] BC001317_n24AreaResponsavelId ;
      private int[] BC001317_A106DocumentoProcessoId ;
      private bool[] BC001317_n106DocumentoProcessoId ;
      private int[] BC001317_A110DocumentoControladorId ;
      private bool[] BC001317_n110DocumentoControladorId ;
      private int[] BC00134_A20SubprocessoId ;
      private bool[] BC00134_n20SubprocessoId ;
      private int[] BC00135_A7EncarregadoId ;
      private bool[] BC00135_n7EncarregadoId ;
      private int[] BC00136_A13PersonaId ;
      private bool[] BC00136_n13PersonaId ;
      private int[] BC00137_A27CategoriaId ;
      private bool[] BC00137_n27CategoriaId ;
      private int[] BC00138_A30TipoDadoId ;
      private bool[] BC00138_n30TipoDadoId ;
      private int[] BC00139_A33FerramentaColetaId ;
      private bool[] BC00139_n33FerramentaColetaId ;
      private int[] BC001310_A36AbrangenciaGeograficaId ;
      private bool[] BC001310_n36AbrangenciaGeograficaId ;
      private int[] BC001311_A39FrequenciaTratamentoId ;
      private bool[] BC001311_n39FrequenciaTratamentoId ;
      private int[] BC001312_A45TipoDescarteId ;
      private bool[] BC001312_n45TipoDescarteId ;
      private int[] BC001313_A48TempoRetencaoId ;
      private bool[] BC001313_n48TempoRetencaoId ;
      private string[] BC001315_A107DocumentoProcessoNome ;
      private int[] BC001316_A110DocumentoControladorId ;
      private bool[] BC001316_n110DocumentoControladorId ;
      private int[] BC001314_A24AreaResponsavelId ;
      private bool[] BC001314_n24AreaResponsavelId ;
      private int[] BC001318_A75DocumentoId ;
      private int[] BC00133_A75DocumentoId ;
      private DateTime[] BC00133_A109DocumentoDataAlteracao ;
      private bool[] BC00133_n109DocumentoDataAlteracao ;
      private string[] BC00133_A142DocumentoUsuarioAlteracao ;
      private bool[] BC00133_n142DocumentoUsuarioAlteracao ;
      private string[] BC00133_A76DocumentoNome ;
      private bool[] BC00133_n76DocumentoNome ;
      private string[] BC00133_A77DocumentoFinalidadeTratamento ;
      private bool[] BC00133_n77DocumentoFinalidadeTratamento ;
      private string[] BC00133_A79DocumentoBaseLegalNorm ;
      private bool[] BC00133_n79DocumentoBaseLegalNorm ;
      private string[] BC00133_A80DocumentoBaseLegalNormIntExt ;
      private bool[] BC00133_n80DocumentoBaseLegalNormIntExt ;
      private string[] BC00133_A83DocumentoMedidaSegurancaDesc ;
      private bool[] BC00133_n83DocumentoMedidaSegurancaDesc ;
      private bool[] BC00133_A78DocumentoPrevColetaDados ;
      private bool[] BC00133_n78DocumentoPrevColetaDados ;
      private bool[] BC00133_A81DocumentoDadosCriancaAdolesc ;
      private bool[] BC00133_n81DocumentoDadosCriancaAdolesc ;
      private bool[] BC00133_A82DocumentoDadosGrupoVul ;
      private bool[] BC00133_n82DocumentoDadosGrupoVul ;
      private string[] BC00133_A84DocumentoFluxoTratDadosDesc ;
      private bool[] BC00133_n84DocumentoFluxoTratDadosDesc ;
      private bool[] BC00133_A85DocumentoAtivo ;
      private bool[] BC00133_n85DocumentoAtivo ;
      private bool[] BC00133_A105DocumentoOperador ;
      private bool[] BC00133_n105DocumentoOperador ;
      private DateTime[] BC00133_A108DocumentoDataInclusao ;
      private bool[] BC00133_n108DocumentoDataInclusao ;
      private string[] BC00133_A141DocumentoUsuarioInclusao ;
      private bool[] BC00133_n141DocumentoUsuarioInclusao ;
      private bool[] BC00133_A143DocumentoIsOperador ;
      private bool[] BC00133_n143DocumentoIsOperador ;
      private int[] BC00133_A20SubprocessoId ;
      private bool[] BC00133_n20SubprocessoId ;
      private int[] BC00133_A7EncarregadoId ;
      private bool[] BC00133_n7EncarregadoId ;
      private int[] BC00133_A13PersonaId ;
      private bool[] BC00133_n13PersonaId ;
      private int[] BC00133_A27CategoriaId ;
      private bool[] BC00133_n27CategoriaId ;
      private int[] BC00133_A30TipoDadoId ;
      private bool[] BC00133_n30TipoDadoId ;
      private int[] BC00133_A33FerramentaColetaId ;
      private bool[] BC00133_n33FerramentaColetaId ;
      private int[] BC00133_A36AbrangenciaGeograficaId ;
      private bool[] BC00133_n36AbrangenciaGeograficaId ;
      private int[] BC00133_A39FrequenciaTratamentoId ;
      private bool[] BC00133_n39FrequenciaTratamentoId ;
      private int[] BC00133_A45TipoDescarteId ;
      private bool[] BC00133_n45TipoDescarteId ;
      private int[] BC00133_A48TempoRetencaoId ;
      private bool[] BC00133_n48TempoRetencaoId ;
      private int[] BC00133_A24AreaResponsavelId ;
      private bool[] BC00133_n24AreaResponsavelId ;
      private int[] BC00133_A106DocumentoProcessoId ;
      private bool[] BC00133_n106DocumentoProcessoId ;
      private int[] BC00133_A110DocumentoControladorId ;
      private bool[] BC00133_n110DocumentoControladorId ;
      private int[] BC00132_A75DocumentoId ;
      private DateTime[] BC00132_A109DocumentoDataAlteracao ;
      private bool[] BC00132_n109DocumentoDataAlteracao ;
      private string[] BC00132_A142DocumentoUsuarioAlteracao ;
      private bool[] BC00132_n142DocumentoUsuarioAlteracao ;
      private string[] BC00132_A76DocumentoNome ;
      private bool[] BC00132_n76DocumentoNome ;
      private string[] BC00132_A77DocumentoFinalidadeTratamento ;
      private bool[] BC00132_n77DocumentoFinalidadeTratamento ;
      private string[] BC00132_A79DocumentoBaseLegalNorm ;
      private bool[] BC00132_n79DocumentoBaseLegalNorm ;
      private string[] BC00132_A80DocumentoBaseLegalNormIntExt ;
      private bool[] BC00132_n80DocumentoBaseLegalNormIntExt ;
      private string[] BC00132_A83DocumentoMedidaSegurancaDesc ;
      private bool[] BC00132_n83DocumentoMedidaSegurancaDesc ;
      private bool[] BC00132_A78DocumentoPrevColetaDados ;
      private bool[] BC00132_n78DocumentoPrevColetaDados ;
      private bool[] BC00132_A81DocumentoDadosCriancaAdolesc ;
      private bool[] BC00132_n81DocumentoDadosCriancaAdolesc ;
      private bool[] BC00132_A82DocumentoDadosGrupoVul ;
      private bool[] BC00132_n82DocumentoDadosGrupoVul ;
      private string[] BC00132_A84DocumentoFluxoTratDadosDesc ;
      private bool[] BC00132_n84DocumentoFluxoTratDadosDesc ;
      private bool[] BC00132_A85DocumentoAtivo ;
      private bool[] BC00132_n85DocumentoAtivo ;
      private bool[] BC00132_A105DocumentoOperador ;
      private bool[] BC00132_n105DocumentoOperador ;
      private DateTime[] BC00132_A108DocumentoDataInclusao ;
      private bool[] BC00132_n108DocumentoDataInclusao ;
      private string[] BC00132_A141DocumentoUsuarioInclusao ;
      private bool[] BC00132_n141DocumentoUsuarioInclusao ;
      private bool[] BC00132_A143DocumentoIsOperador ;
      private bool[] BC00132_n143DocumentoIsOperador ;
      private int[] BC00132_A20SubprocessoId ;
      private bool[] BC00132_n20SubprocessoId ;
      private int[] BC00132_A7EncarregadoId ;
      private bool[] BC00132_n7EncarregadoId ;
      private int[] BC00132_A13PersonaId ;
      private bool[] BC00132_n13PersonaId ;
      private int[] BC00132_A27CategoriaId ;
      private bool[] BC00132_n27CategoriaId ;
      private int[] BC00132_A30TipoDadoId ;
      private bool[] BC00132_n30TipoDadoId ;
      private int[] BC00132_A33FerramentaColetaId ;
      private bool[] BC00132_n33FerramentaColetaId ;
      private int[] BC00132_A36AbrangenciaGeograficaId ;
      private bool[] BC00132_n36AbrangenciaGeograficaId ;
      private int[] BC00132_A39FrequenciaTratamentoId ;
      private bool[] BC00132_n39FrequenciaTratamentoId ;
      private int[] BC00132_A45TipoDescarteId ;
      private bool[] BC00132_n45TipoDescarteId ;
      private int[] BC00132_A48TempoRetencaoId ;
      private bool[] BC00132_n48TempoRetencaoId ;
      private int[] BC00132_A24AreaResponsavelId ;
      private bool[] BC00132_n24AreaResponsavelId ;
      private int[] BC00132_A106DocumentoProcessoId ;
      private bool[] BC00132_n106DocumentoProcessoId ;
      private int[] BC00132_A110DocumentoControladorId ;
      private bool[] BC00132_n110DocumentoControladorId ;
      private int[] BC001319_A75DocumentoId ;
      private string[] BC001322_A107DocumentoProcessoNome ;
      private int[] BC001323_A144DocImagemId ;
      private int[] BC001324_A120RevisaoLogId ;
      private int[] BC001325_A93DocAnexoId ;
      private int[] BC001326_A86DocOperadorId ;
      private int[] BC001327_A98DocDicionarioId ;
      private int[] BC001328_A51MedidaSegurancaId ;
      private int[] BC001328_A75DocumentoId ;
      private int[] BC001329_A63FonteRetencaoId ;
      private int[] BC001329_A75DocumentoId ;
      private int[] BC001330_A60SetorInternoId ;
      private int[] BC001330_A75DocumentoId ;
      private int[] BC001331_A57CompartInternoId ;
      private int[] BC001331_A75DocumentoId ;
      private int[] BC001332_A54EnvolvidosColetaId ;
      private int[] BC001332_A75DocumentoId ;
      private int[] BC001333_A75DocumentoId ;
      private DateTime[] BC001333_A109DocumentoDataAlteracao ;
      private bool[] BC001333_n109DocumentoDataAlteracao ;
      private string[] BC001333_A142DocumentoUsuarioAlteracao ;
      private bool[] BC001333_n142DocumentoUsuarioAlteracao ;
      private string[] BC001333_A76DocumentoNome ;
      private bool[] BC001333_n76DocumentoNome ;
      private string[] BC001333_A77DocumentoFinalidadeTratamento ;
      private bool[] BC001333_n77DocumentoFinalidadeTratamento ;
      private string[] BC001333_A79DocumentoBaseLegalNorm ;
      private bool[] BC001333_n79DocumentoBaseLegalNorm ;
      private string[] BC001333_A80DocumentoBaseLegalNormIntExt ;
      private bool[] BC001333_n80DocumentoBaseLegalNormIntExt ;
      private string[] BC001333_A83DocumentoMedidaSegurancaDesc ;
      private bool[] BC001333_n83DocumentoMedidaSegurancaDesc ;
      private bool[] BC001333_A78DocumentoPrevColetaDados ;
      private bool[] BC001333_n78DocumentoPrevColetaDados ;
      private bool[] BC001333_A81DocumentoDadosCriancaAdolesc ;
      private bool[] BC001333_n81DocumentoDadosCriancaAdolesc ;
      private bool[] BC001333_A82DocumentoDadosGrupoVul ;
      private bool[] BC001333_n82DocumentoDadosGrupoVul ;
      private string[] BC001333_A84DocumentoFluxoTratDadosDesc ;
      private bool[] BC001333_n84DocumentoFluxoTratDadosDesc ;
      private bool[] BC001333_A85DocumentoAtivo ;
      private bool[] BC001333_n85DocumentoAtivo ;
      private bool[] BC001333_A105DocumentoOperador ;
      private bool[] BC001333_n105DocumentoOperador ;
      private string[] BC001333_A107DocumentoProcessoNome ;
      private DateTime[] BC001333_A108DocumentoDataInclusao ;
      private bool[] BC001333_n108DocumentoDataInclusao ;
      private string[] BC001333_A141DocumentoUsuarioInclusao ;
      private bool[] BC001333_n141DocumentoUsuarioInclusao ;
      private bool[] BC001333_A143DocumentoIsOperador ;
      private bool[] BC001333_n143DocumentoIsOperador ;
      private int[] BC001333_A20SubprocessoId ;
      private bool[] BC001333_n20SubprocessoId ;
      private int[] BC001333_A7EncarregadoId ;
      private bool[] BC001333_n7EncarregadoId ;
      private int[] BC001333_A13PersonaId ;
      private bool[] BC001333_n13PersonaId ;
      private int[] BC001333_A27CategoriaId ;
      private bool[] BC001333_n27CategoriaId ;
      private int[] BC001333_A30TipoDadoId ;
      private bool[] BC001333_n30TipoDadoId ;
      private int[] BC001333_A33FerramentaColetaId ;
      private bool[] BC001333_n33FerramentaColetaId ;
      private int[] BC001333_A36AbrangenciaGeograficaId ;
      private bool[] BC001333_n36AbrangenciaGeograficaId ;
      private int[] BC001333_A39FrequenciaTratamentoId ;
      private bool[] BC001333_n39FrequenciaTratamentoId ;
      private int[] BC001333_A45TipoDescarteId ;
      private bool[] BC001333_n45TipoDescarteId ;
      private int[] BC001333_A48TempoRetencaoId ;
      private bool[] BC001333_n48TempoRetencaoId ;
      private int[] BC001333_A24AreaResponsavelId ;
      private bool[] BC001333_n24AreaResponsavelId ;
      private int[] BC001333_A106DocumentoProcessoId ;
      private bool[] BC001333_n106DocumentoProcessoId ;
      private int[] BC001333_A110DocumentoControladorId ;
      private bool[] BC001333_n110DocumentoControladorId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV24TrnContextAtt ;
   }

   public class documento_bc__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class documento_bc__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC001317;
        prmBC001317 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00134;
        prmBC00134 = new Object[] {
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00135;
        prmBC00135 = new Object[] {
        new ParDef("@EncarregadoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00136;
        prmBC00136 = new Object[] {
        new ParDef("@PersonaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00137;
        prmBC00137 = new Object[] {
        new ParDef("@CategoriaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00138;
        prmBC00138 = new Object[] {
        new ParDef("@TipoDadoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00139;
        prmBC00139 = new Object[] {
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC001310;
        prmBC001310 = new Object[] {
        new ParDef("@AbrangenciaGeograficaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC001311;
        prmBC001311 = new Object[] {
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC001312;
        prmBC001312 = new Object[] {
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC001313;
        prmBC001313 = new Object[] {
        new ParDef("@TempoRetencaoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC001315;
        prmBC001315 = new Object[] {
        new ParDef("@DocumentoProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC001316;
        prmBC001316 = new Object[] {
        new ParDef("@DocumentoControladorId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC001314;
        prmBC001314 = new Object[] {
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC001318;
        prmBC001318 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00133;
        prmBC00133 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00132;
        prmBC00132 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001319;
        prmBC001319 = new Object[] {
        new ParDef("@DocumentoDataAlteracao",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@DocumentoUsuarioAlteracao",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoNome",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoFinalidadeTratamento",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoBaseLegalNorm",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoBaseLegalNormIntExt",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoMedidaSegurancaDesc",GXType.NVarChar,10000,0){Nullable=true} ,
        new ParDef("@DocumentoPrevColetaDados",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@DocumentoDadosCriancaAdolesc",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@DocumentoDadosGrupoVul",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@DocumentoFluxoTratDadosDesc",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@DocumentoAtivo",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@DocumentoOperador",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@DocumentoDataInclusao",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@DocumentoUsuarioInclusao",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoIsOperador",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@EncarregadoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@PersonaId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@CategoriaId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@TipoDadoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@AbrangenciaGeograficaId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@TempoRetencaoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@DocumentoProcessoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@DocumentoControladorId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC001320;
        prmBC001320 = new Object[] {
        new ParDef("@DocumentoDataAlteracao",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@DocumentoUsuarioAlteracao",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoNome",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoFinalidadeTratamento",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoBaseLegalNorm",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoBaseLegalNormIntExt",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoMedidaSegurancaDesc",GXType.NVarChar,10000,0){Nullable=true} ,
        new ParDef("@DocumentoPrevColetaDados",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@DocumentoDadosCriancaAdolesc",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@DocumentoDadosGrupoVul",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@DocumentoFluxoTratDadosDesc",GXType.NVarChar,2097152,0){Nullable=true} ,
        new ParDef("@DocumentoAtivo",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@DocumentoOperador",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@DocumentoDataInclusao",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@DocumentoUsuarioInclusao",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DocumentoIsOperador",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@EncarregadoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@PersonaId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@CategoriaId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@TipoDadoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@AbrangenciaGeograficaId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@TempoRetencaoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@DocumentoProcessoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@DocumentoControladorId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001321;
        prmBC001321 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001322;
        prmBC001322 = new Object[] {
        new ParDef("@DocumentoProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC001323;
        prmBC001323 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001324;
        prmBC001324 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001325;
        prmBC001325 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001326;
        prmBC001326 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001327;
        prmBC001327 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001328;
        prmBC001328 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001329;
        prmBC001329 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001330;
        prmBC001330 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001331;
        prmBC001331 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001332;
        prmBC001332 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001333;
        prmBC001333 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00132", "SELECT [DocumentoId], [DocumentoDataAlteracao], [DocumentoUsuarioAlteracao], [DocumentoNome], [DocumentoFinalidadeTratamento], [DocumentoBaseLegalNorm], [DocumentoBaseLegalNormIntExt], [DocumentoMedidaSegurancaDesc], [DocumentoPrevColetaDados], [DocumentoDadosCriancaAdolesc], [DocumentoDadosGrupoVul], [DocumentoFluxoTratDadosDesc], [DocumentoAtivo], [DocumentoOperador], [DocumentoDataInclusao], [DocumentoUsuarioInclusao], [DocumentoIsOperador], [SubprocessoId], [EncarregadoId], [PersonaId], [CategoriaId], [TipoDadoId], [FerramentaColetaId], [AbrangenciaGeograficaId], [FrequenciaTratamentoId], [TipoDescarteId], [TempoRetencaoId], [AreaResponsavelId], [DocumentoProcessoId] AS DocumentoProcessoId, [DocumentoControladorId] AS DocumentoControladorId FROM [Documento] WITH (UPDLOCK) WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00132,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00133", "SELECT [DocumentoId], [DocumentoDataAlteracao], [DocumentoUsuarioAlteracao], [DocumentoNome], [DocumentoFinalidadeTratamento], [DocumentoBaseLegalNorm], [DocumentoBaseLegalNormIntExt], [DocumentoMedidaSegurancaDesc], [DocumentoPrevColetaDados], [DocumentoDadosCriancaAdolesc], [DocumentoDadosGrupoVul], [DocumentoFluxoTratDadosDesc], [DocumentoAtivo], [DocumentoOperador], [DocumentoDataInclusao], [DocumentoUsuarioInclusao], [DocumentoIsOperador], [SubprocessoId], [EncarregadoId], [PersonaId], [CategoriaId], [TipoDadoId], [FerramentaColetaId], [AbrangenciaGeograficaId], [FrequenciaTratamentoId], [TipoDescarteId], [TempoRetencaoId], [AreaResponsavelId], [DocumentoProcessoId] AS DocumentoProcessoId, [DocumentoControladorId] AS DocumentoControladorId FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00133,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00134", "SELECT [SubprocessoId] FROM [SubProcesso] WHERE [SubprocessoId] = @SubprocessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00134,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00135", "SELECT [EncarregadoId] FROM [Encarregado] WHERE [EncarregadoId] = @EncarregadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00135,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00136", "SELECT [PersonaId] FROM [Persona] WHERE [PersonaId] = @PersonaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00136,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00137", "SELECT [CategoriaId] FROM [Categoria] WHERE [CategoriaId] = @CategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00137,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00138", "SELECT [TipoDadoId] FROM [TipoDado] WHERE [TipoDadoId] = @TipoDadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00138,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00139", "SELECT [FerramentaColetaId] FROM [FerramentaColeta] WHERE [FerramentaColetaId] = @FerramentaColetaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00139,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001310", "SELECT [AbrangenciaGeograficaId] FROM [AbrangenciaGeografica] WHERE [AbrangenciaGeograficaId] = @AbrangenciaGeograficaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001310,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001311", "SELECT [FrequenciaTratamentoId] FROM [FrequenciaTratamento] WHERE [FrequenciaTratamentoId] = @FrequenciaTratamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001311,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001312", "SELECT [TipoDescarteId] FROM [TipoDescarte] WHERE [TipoDescarteId] = @TipoDescarteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001312,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001313", "SELECT [TempoRetencaoId] FROM [TempoRetencao] WHERE [TempoRetencaoId] = @TempoRetencaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001313,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001314", "SELECT [AreaResponsavelId] FROM [AreaResponsavel] WHERE [AreaResponsavelId] = @AreaResponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001314,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001315", "SELECT [ProcessoNome] AS DocumentoProcessoNome FROM [Processo] WHERE [ProcessoId] = @DocumentoProcessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001315,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001316", "SELECT [ControladorId] AS DocumentoControladorId FROM [Controlador] WHERE [ControladorId] = @DocumentoControladorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001316,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001317", "SELECT TM1.[DocumentoId], TM1.[DocumentoDataAlteracao], TM1.[DocumentoUsuarioAlteracao], TM1.[DocumentoNome], TM1.[DocumentoFinalidadeTratamento], TM1.[DocumentoBaseLegalNorm], TM1.[DocumentoBaseLegalNormIntExt], TM1.[DocumentoMedidaSegurancaDesc], TM1.[DocumentoPrevColetaDados], TM1.[DocumentoDadosCriancaAdolesc], TM1.[DocumentoDadosGrupoVul], TM1.[DocumentoFluxoTratDadosDesc], TM1.[DocumentoAtivo], TM1.[DocumentoOperador], T2.[ProcessoNome] AS DocumentoProcessoNome, TM1.[DocumentoDataInclusao], TM1.[DocumentoUsuarioInclusao], TM1.[DocumentoIsOperador], TM1.[SubprocessoId], TM1.[EncarregadoId], TM1.[PersonaId], TM1.[CategoriaId], TM1.[TipoDadoId], TM1.[FerramentaColetaId], TM1.[AbrangenciaGeograficaId], TM1.[FrequenciaTratamentoId], TM1.[TipoDescarteId], TM1.[TempoRetencaoId], TM1.[AreaResponsavelId], TM1.[DocumentoProcessoId] AS DocumentoProcessoId, TM1.[DocumentoControladorId] AS DocumentoControladorId FROM ([Documento] TM1 LEFT JOIN [Processo] T2 ON T2.[ProcessoId] = TM1.[DocumentoProcessoId]) WHERE TM1.[DocumentoId] = @DocumentoId ORDER BY TM1.[DocumentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001317,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001318", "SELECT [DocumentoId] FROM [Documento] WHERE [DocumentoId] = @DocumentoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001318,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001319", "INSERT INTO [Documento]([DocumentoDataAlteracao], [DocumentoUsuarioAlteracao], [DocumentoNome], [DocumentoFinalidadeTratamento], [DocumentoBaseLegalNorm], [DocumentoBaseLegalNormIntExt], [DocumentoMedidaSegurancaDesc], [DocumentoPrevColetaDados], [DocumentoDadosCriancaAdolesc], [DocumentoDadosGrupoVul], [DocumentoFluxoTratDadosDesc], [DocumentoAtivo], [DocumentoOperador], [DocumentoDataInclusao], [DocumentoUsuarioInclusao], [DocumentoIsOperador], [SubprocessoId], [EncarregadoId], [PersonaId], [CategoriaId], [TipoDadoId], [FerramentaColetaId], [AbrangenciaGeograficaId], [FrequenciaTratamentoId], [TipoDescarteId], [TempoRetencaoId], [AreaResponsavelId], [DocumentoProcessoId], [DocumentoControladorId]) VALUES(@DocumentoDataAlteracao, @DocumentoUsuarioAlteracao, @DocumentoNome, @DocumentoFinalidadeTratamento, @DocumentoBaseLegalNorm, @DocumentoBaseLegalNormIntExt, @DocumentoMedidaSegurancaDesc, @DocumentoPrevColetaDados, @DocumentoDadosCriancaAdolesc, @DocumentoDadosGrupoVul, @DocumentoFluxoTratDadosDesc, @DocumentoAtivo, @DocumentoOperador, @DocumentoDataInclusao, @DocumentoUsuarioInclusao, @DocumentoIsOperador, @SubprocessoId, @EncarregadoId, @PersonaId, @CategoriaId, @TipoDadoId, @FerramentaColetaId, @AbrangenciaGeograficaId, @FrequenciaTratamentoId, @TipoDescarteId, @TempoRetencaoId, @AreaResponsavelId, @DocumentoProcessoId, @DocumentoControladorId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC001319,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001320", "UPDATE [Documento] SET [DocumentoDataAlteracao]=@DocumentoDataAlteracao, [DocumentoUsuarioAlteracao]=@DocumentoUsuarioAlteracao, [DocumentoNome]=@DocumentoNome, [DocumentoFinalidadeTratamento]=@DocumentoFinalidadeTratamento, [DocumentoBaseLegalNorm]=@DocumentoBaseLegalNorm, [DocumentoBaseLegalNormIntExt]=@DocumentoBaseLegalNormIntExt, [DocumentoMedidaSegurancaDesc]=@DocumentoMedidaSegurancaDesc, [DocumentoPrevColetaDados]=@DocumentoPrevColetaDados, [DocumentoDadosCriancaAdolesc]=@DocumentoDadosCriancaAdolesc, [DocumentoDadosGrupoVul]=@DocumentoDadosGrupoVul, [DocumentoFluxoTratDadosDesc]=@DocumentoFluxoTratDadosDesc, [DocumentoAtivo]=@DocumentoAtivo, [DocumentoOperador]=@DocumentoOperador, [DocumentoDataInclusao]=@DocumentoDataInclusao, [DocumentoUsuarioInclusao]=@DocumentoUsuarioInclusao, [DocumentoIsOperador]=@DocumentoIsOperador, [SubprocessoId]=@SubprocessoId, [EncarregadoId]=@EncarregadoId, [PersonaId]=@PersonaId, [CategoriaId]=@CategoriaId, [TipoDadoId]=@TipoDadoId, [FerramentaColetaId]=@FerramentaColetaId, [AbrangenciaGeograficaId]=@AbrangenciaGeograficaId, [FrequenciaTratamentoId]=@FrequenciaTratamentoId, [TipoDescarteId]=@TipoDescarteId, [TempoRetencaoId]=@TempoRetencaoId, [AreaResponsavelId]=@AreaResponsavelId, [DocumentoProcessoId]=@DocumentoProcessoId, [DocumentoControladorId]=@DocumentoControladorId  WHERE [DocumentoId] = @DocumentoId", GxErrorMask.GX_NOMASK,prmBC001320)
           ,new CursorDef("BC001321", "DELETE FROM [Documento]  WHERE [DocumentoId] = @DocumentoId", GxErrorMask.GX_NOMASK,prmBC001321)
           ,new CursorDef("BC001322", "SELECT [ProcessoNome] AS DocumentoProcessoNome FROM [Processo] WHERE [ProcessoId] = @DocumentoProcessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001322,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001323", "SELECT TOP 1 [DocImagemId] FROM [DocImagem] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001323,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001324", "SELECT TOP 1 [RevisaoLogId] FROM [RevisaoLog] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001324,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001325", "SELECT TOP 1 [DocAnexoId] FROM [DocAnexo] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001325,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001326", "SELECT TOP 1 [DocOperadorId] FROM [DocOperador] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001326,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001327", "SELECT TOP 1 [DocDicionarioId] FROM [DocDicionario] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001327,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001328", "SELECT TOP 1 [MedidaSegurancaId], [DocumentoId] FROM [DocMedidaSeguranca] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001328,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001329", "SELECT TOP 1 [FonteRetencaoId], [DocumentoId] FROM [DocFonteRetencao] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001329,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001330", "SELECT TOP 1 [SetorInternoId], [DocumentoId] FROM [DocSetorInterno] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001330,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001331", "SELECT TOP 1 [CompartInternoId], [DocumentoId] FROM [DocCompartInterno] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001331,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001332", "SELECT TOP 1 [EnvolvidosColetaId], [DocumentoId] FROM [DocEnvolvidosColeta] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001332,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001333", "SELECT TM1.[DocumentoId], TM1.[DocumentoDataAlteracao], TM1.[DocumentoUsuarioAlteracao], TM1.[DocumentoNome], TM1.[DocumentoFinalidadeTratamento], TM1.[DocumentoBaseLegalNorm], TM1.[DocumentoBaseLegalNormIntExt], TM1.[DocumentoMedidaSegurancaDesc], TM1.[DocumentoPrevColetaDados], TM1.[DocumentoDadosCriancaAdolesc], TM1.[DocumentoDadosGrupoVul], TM1.[DocumentoFluxoTratDadosDesc], TM1.[DocumentoAtivo], TM1.[DocumentoOperador], T2.[ProcessoNome] AS DocumentoProcessoNome, TM1.[DocumentoDataInclusao], TM1.[DocumentoUsuarioInclusao], TM1.[DocumentoIsOperador], TM1.[SubprocessoId], TM1.[EncarregadoId], TM1.[PersonaId], TM1.[CategoriaId], TM1.[TipoDadoId], TM1.[FerramentaColetaId], TM1.[AbrangenciaGeograficaId], TM1.[FrequenciaTratamentoId], TM1.[TipoDescarteId], TM1.[TempoRetencaoId], TM1.[AreaResponsavelId], TM1.[DocumentoProcessoId] AS DocumentoProcessoId, TM1.[DocumentoControladorId] AS DocumentoControladorId FROM ([Documento] TM1 LEFT JOIN [Processo] T2 ON T2.[ProcessoId] = TM1.[DocumentoProcessoId]) WHERE TM1.[DocumentoId] = @DocumentoId ORDER BY TM1.[DocumentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001333,100, GxCacheFrequency.OFF ,true,false )
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
     switch ( cursor )
     {
           case 0 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getVarchar(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((bool[]) buf[15])[0] = rslt.getBool(9);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((bool[]) buf[17])[0] = rslt.getBool(10);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((bool[]) buf[19])[0] = rslt.getBool(11);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((string[]) buf[21])[0] = rslt.getLongVarchar(12);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              ((bool[]) buf[23])[0] = rslt.getBool(13);
              ((bool[]) buf[24])[0] = rslt.wasNull(13);
              ((bool[]) buf[25])[0] = rslt.getBool(14);
              ((bool[]) buf[26])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(15);
              ((bool[]) buf[28])[0] = rslt.wasNull(15);
              ((string[]) buf[29])[0] = rslt.getVarchar(16);
              ((bool[]) buf[30])[0] = rslt.wasNull(16);
              ((bool[]) buf[31])[0] = rslt.getBool(17);
              ((bool[]) buf[32])[0] = rslt.wasNull(17);
              ((int[]) buf[33])[0] = rslt.getInt(18);
              ((bool[]) buf[34])[0] = rslt.wasNull(18);
              ((int[]) buf[35])[0] = rslt.getInt(19);
              ((bool[]) buf[36])[0] = rslt.wasNull(19);
              ((int[]) buf[37])[0] = rslt.getInt(20);
              ((bool[]) buf[38])[0] = rslt.wasNull(20);
              ((int[]) buf[39])[0] = rslt.getInt(21);
              ((bool[]) buf[40])[0] = rslt.wasNull(21);
              ((int[]) buf[41])[0] = rslt.getInt(22);
              ((bool[]) buf[42])[0] = rslt.wasNull(22);
              ((int[]) buf[43])[0] = rslt.getInt(23);
              ((bool[]) buf[44])[0] = rslt.wasNull(23);
              ((int[]) buf[45])[0] = rslt.getInt(24);
              ((bool[]) buf[46])[0] = rslt.wasNull(24);
              ((int[]) buf[47])[0] = rslt.getInt(25);
              ((bool[]) buf[48])[0] = rslt.wasNull(25);
              ((int[]) buf[49])[0] = rslt.getInt(26);
              ((bool[]) buf[50])[0] = rslt.wasNull(26);
              ((int[]) buf[51])[0] = rslt.getInt(27);
              ((bool[]) buf[52])[0] = rslt.wasNull(27);
              ((int[]) buf[53])[0] = rslt.getInt(28);
              ((bool[]) buf[54])[0] = rslt.wasNull(28);
              ((int[]) buf[55])[0] = rslt.getInt(29);
              ((bool[]) buf[56])[0] = rslt.wasNull(29);
              ((int[]) buf[57])[0] = rslt.getInt(30);
              ((bool[]) buf[58])[0] = rslt.wasNull(30);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getVarchar(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((bool[]) buf[15])[0] = rslt.getBool(9);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((bool[]) buf[17])[0] = rslt.getBool(10);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((bool[]) buf[19])[0] = rslt.getBool(11);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((string[]) buf[21])[0] = rslt.getLongVarchar(12);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              ((bool[]) buf[23])[0] = rslt.getBool(13);
              ((bool[]) buf[24])[0] = rslt.wasNull(13);
              ((bool[]) buf[25])[0] = rslt.getBool(14);
              ((bool[]) buf[26])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(15);
              ((bool[]) buf[28])[0] = rslt.wasNull(15);
              ((string[]) buf[29])[0] = rslt.getVarchar(16);
              ((bool[]) buf[30])[0] = rslt.wasNull(16);
              ((bool[]) buf[31])[0] = rslt.getBool(17);
              ((bool[]) buf[32])[0] = rslt.wasNull(17);
              ((int[]) buf[33])[0] = rslt.getInt(18);
              ((bool[]) buf[34])[0] = rslt.wasNull(18);
              ((int[]) buf[35])[0] = rslt.getInt(19);
              ((bool[]) buf[36])[0] = rslt.wasNull(19);
              ((int[]) buf[37])[0] = rslt.getInt(20);
              ((bool[]) buf[38])[0] = rslt.wasNull(20);
              ((int[]) buf[39])[0] = rslt.getInt(21);
              ((bool[]) buf[40])[0] = rslt.wasNull(21);
              ((int[]) buf[41])[0] = rslt.getInt(22);
              ((bool[]) buf[42])[0] = rslt.wasNull(22);
              ((int[]) buf[43])[0] = rslt.getInt(23);
              ((bool[]) buf[44])[0] = rslt.wasNull(23);
              ((int[]) buf[45])[0] = rslt.getInt(24);
              ((bool[]) buf[46])[0] = rslt.wasNull(24);
              ((int[]) buf[47])[0] = rslt.getInt(25);
              ((bool[]) buf[48])[0] = rslt.wasNull(25);
              ((int[]) buf[49])[0] = rslt.getInt(26);
              ((bool[]) buf[50])[0] = rslt.wasNull(26);
              ((int[]) buf[51])[0] = rslt.getInt(27);
              ((bool[]) buf[52])[0] = rslt.wasNull(27);
              ((int[]) buf[53])[0] = rslt.getInt(28);
              ((bool[]) buf[54])[0] = rslt.wasNull(28);
              ((int[]) buf[55])[0] = rslt.getInt(29);
              ((bool[]) buf[56])[0] = rslt.wasNull(29);
              ((int[]) buf[57])[0] = rslt.getInt(30);
              ((bool[]) buf[58])[0] = rslt.wasNull(30);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getVarchar(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((bool[]) buf[15])[0] = rslt.getBool(9);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((bool[]) buf[17])[0] = rslt.getBool(10);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((bool[]) buf[19])[0] = rslt.getBool(11);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((string[]) buf[21])[0] = rslt.getLongVarchar(12);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              ((bool[]) buf[23])[0] = rslt.getBool(13);
              ((bool[]) buf[24])[0] = rslt.wasNull(13);
              ((bool[]) buf[25])[0] = rslt.getBool(14);
              ((bool[]) buf[26])[0] = rslt.wasNull(14);
              ((string[]) buf[27])[0] = rslt.getVarchar(15);
              ((DateTime[]) buf[28])[0] = rslt.getGXDateTime(16);
              ((bool[]) buf[29])[0] = rslt.wasNull(16);
              ((string[]) buf[30])[0] = rslt.getVarchar(17);
              ((bool[]) buf[31])[0] = rslt.wasNull(17);
              ((bool[]) buf[32])[0] = rslt.getBool(18);
              ((bool[]) buf[33])[0] = rslt.wasNull(18);
              ((int[]) buf[34])[0] = rslt.getInt(19);
              ((bool[]) buf[35])[0] = rslt.wasNull(19);
              ((int[]) buf[36])[0] = rslt.getInt(20);
              ((bool[]) buf[37])[0] = rslt.wasNull(20);
              ((int[]) buf[38])[0] = rslt.getInt(21);
              ((bool[]) buf[39])[0] = rslt.wasNull(21);
              ((int[]) buf[40])[0] = rslt.getInt(22);
              ((bool[]) buf[41])[0] = rslt.wasNull(22);
              ((int[]) buf[42])[0] = rslt.getInt(23);
              ((bool[]) buf[43])[0] = rslt.wasNull(23);
              ((int[]) buf[44])[0] = rslt.getInt(24);
              ((bool[]) buf[45])[0] = rslt.wasNull(24);
              ((int[]) buf[46])[0] = rslt.getInt(25);
              ((bool[]) buf[47])[0] = rslt.wasNull(25);
              ((int[]) buf[48])[0] = rslt.getInt(26);
              ((bool[]) buf[49])[0] = rslt.wasNull(26);
              ((int[]) buf[50])[0] = rslt.getInt(27);
              ((bool[]) buf[51])[0] = rslt.wasNull(27);
              ((int[]) buf[52])[0] = rslt.getInt(28);
              ((bool[]) buf[53])[0] = rslt.wasNull(28);
              ((int[]) buf[54])[0] = rslt.getInt(29);
              ((bool[]) buf[55])[0] = rslt.wasNull(29);
              ((int[]) buf[56])[0] = rslt.getInt(30);
              ((bool[]) buf[57])[0] = rslt.wasNull(30);
              ((int[]) buf[58])[0] = rslt.getInt(31);
              ((bool[]) buf[59])[0] = rslt.wasNull(31);
              return;
           case 16 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 17 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 21 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 22 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 23 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 24 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 25 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 26 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 27 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 28 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 29 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
     }
     getresults30( cursor, rslt, buf) ;
  }

  public void getresults30( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 30 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 31 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getVarchar(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((bool[]) buf[15])[0] = rslt.getBool(9);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((bool[]) buf[17])[0] = rslt.getBool(10);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((bool[]) buf[19])[0] = rslt.getBool(11);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((string[]) buf[21])[0] = rslt.getLongVarchar(12);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              ((bool[]) buf[23])[0] = rslt.getBool(13);
              ((bool[]) buf[24])[0] = rslt.wasNull(13);
              ((bool[]) buf[25])[0] = rslt.getBool(14);
              ((bool[]) buf[26])[0] = rslt.wasNull(14);
              ((string[]) buf[27])[0] = rslt.getVarchar(15);
              ((DateTime[]) buf[28])[0] = rslt.getGXDateTime(16);
              ((bool[]) buf[29])[0] = rslt.wasNull(16);
              ((string[]) buf[30])[0] = rslt.getVarchar(17);
              ((bool[]) buf[31])[0] = rslt.wasNull(17);
              ((bool[]) buf[32])[0] = rslt.getBool(18);
              ((bool[]) buf[33])[0] = rslt.wasNull(18);
              ((int[]) buf[34])[0] = rslt.getInt(19);
              ((bool[]) buf[35])[0] = rslt.wasNull(19);
              ((int[]) buf[36])[0] = rslt.getInt(20);
              ((bool[]) buf[37])[0] = rslt.wasNull(20);
              ((int[]) buf[38])[0] = rslt.getInt(21);
              ((bool[]) buf[39])[0] = rslt.wasNull(21);
              ((int[]) buf[40])[0] = rslt.getInt(22);
              ((bool[]) buf[41])[0] = rslt.wasNull(22);
              ((int[]) buf[42])[0] = rslt.getInt(23);
              ((bool[]) buf[43])[0] = rslt.wasNull(23);
              ((int[]) buf[44])[0] = rslt.getInt(24);
              ((bool[]) buf[45])[0] = rslt.wasNull(24);
              ((int[]) buf[46])[0] = rslt.getInt(25);
              ((bool[]) buf[47])[0] = rslt.wasNull(25);
              ((int[]) buf[48])[0] = rslt.getInt(26);
              ((bool[]) buf[49])[0] = rslt.wasNull(26);
              ((int[]) buf[50])[0] = rslt.getInt(27);
              ((bool[]) buf[51])[0] = rslt.wasNull(27);
              ((int[]) buf[52])[0] = rslt.getInt(28);
              ((bool[]) buf[53])[0] = rslt.wasNull(28);
              ((int[]) buf[54])[0] = rslt.getInt(29);
              ((bool[]) buf[55])[0] = rslt.wasNull(29);
              ((int[]) buf[56])[0] = rslt.getInt(30);
              ((bool[]) buf[57])[0] = rslt.wasNull(30);
              ((int[]) buf[58])[0] = rslt.getInt(31);
              ((bool[]) buf[59])[0] = rslt.wasNull(31);
              return;
     }
  }

}

}
