using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Web.Services;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class documentoconversion : GXProcedure
   {
      public documentoconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public documentoconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         documentoconversion objdocumentoconversion;
         objdocumentoconversion = new documentoconversion();
         objdocumentoconversion.context.SetSubmitInitialConfig(context);
         objdocumentoconversion.initialize();
         Submit( executePrivateCatch,objdocumentoconversion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((documentoconversion)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         cmdBuffer=" SET IDENTITY_INSERT [GXA0046] ON "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         /* Using cursor DOCUMENTOC2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A24AreaResponsavelId = DOCUMENTOC2_A24AreaResponsavelId[0];
            n24AreaResponsavelId = DOCUMENTOC2_n24AreaResponsavelId[0];
            A110DocumentoControladorId = DOCUMENTOC2_A110DocumentoControladorId[0];
            n110DocumentoControladorId = DOCUMENTOC2_n110DocumentoControladorId[0];
            A106DocumentoProcessoId = DOCUMENTOC2_A106DocumentoProcessoId[0];
            n106DocumentoProcessoId = DOCUMENTOC2_n106DocumentoProcessoId[0];
            A105DocumentoOperador = DOCUMENTOC2_A105DocumentoOperador[0];
            n105DocumentoOperador = DOCUMENTOC2_n105DocumentoOperador[0];
            A85DocumentoAtivo = DOCUMENTOC2_A85DocumentoAtivo[0];
            n85DocumentoAtivo = DOCUMENTOC2_n85DocumentoAtivo[0];
            A84DocumentoFluxoTratDadosDesc = DOCUMENTOC2_A84DocumentoFluxoTratDadosDesc[0];
            n84DocumentoFluxoTratDadosDesc = DOCUMENTOC2_n84DocumentoFluxoTratDadosDesc[0];
            A83DocumentoMedidaSegurancaDesc = DOCUMENTOC2_A83DocumentoMedidaSegurancaDesc[0];
            n83DocumentoMedidaSegurancaDesc = DOCUMENTOC2_n83DocumentoMedidaSegurancaDesc[0];
            A82DocumentoDadosGrupoVul = DOCUMENTOC2_A82DocumentoDadosGrupoVul[0];
            n82DocumentoDadosGrupoVul = DOCUMENTOC2_n82DocumentoDadosGrupoVul[0];
            A81DocumentoDadosCriancaAdolesc = DOCUMENTOC2_A81DocumentoDadosCriancaAdolesc[0];
            n81DocumentoDadosCriancaAdolesc = DOCUMENTOC2_n81DocumentoDadosCriancaAdolesc[0];
            A80DocumentoBaseLegalNormIntExt = DOCUMENTOC2_A80DocumentoBaseLegalNormIntExt[0];
            n80DocumentoBaseLegalNormIntExt = DOCUMENTOC2_n80DocumentoBaseLegalNormIntExt[0];
            A79DocumentoBaseLegalNorm = DOCUMENTOC2_A79DocumentoBaseLegalNorm[0];
            n79DocumentoBaseLegalNorm = DOCUMENTOC2_n79DocumentoBaseLegalNorm[0];
            A78DocumentoPrevColetaDados = DOCUMENTOC2_A78DocumentoPrevColetaDados[0];
            n78DocumentoPrevColetaDados = DOCUMENTOC2_n78DocumentoPrevColetaDados[0];
            A48TempoRetencaoId = DOCUMENTOC2_A48TempoRetencaoId[0];
            n48TempoRetencaoId = DOCUMENTOC2_n48TempoRetencaoId[0];
            A45TipoDescarteId = DOCUMENTOC2_A45TipoDescarteId[0];
            n45TipoDescarteId = DOCUMENTOC2_n45TipoDescarteId[0];
            A39FrequenciaTratamentoId = DOCUMENTOC2_A39FrequenciaTratamentoId[0];
            n39FrequenciaTratamentoId = DOCUMENTOC2_n39FrequenciaTratamentoId[0];
            A36AbrangenciaGeograficaId = DOCUMENTOC2_A36AbrangenciaGeograficaId[0];
            n36AbrangenciaGeograficaId = DOCUMENTOC2_n36AbrangenciaGeograficaId[0];
            A33FerramentaColetaId = DOCUMENTOC2_A33FerramentaColetaId[0];
            n33FerramentaColetaId = DOCUMENTOC2_n33FerramentaColetaId[0];
            A30TipoDadoId = DOCUMENTOC2_A30TipoDadoId[0];
            n30TipoDadoId = DOCUMENTOC2_n30TipoDadoId[0];
            A27CategoriaId = DOCUMENTOC2_A27CategoriaId[0];
            n27CategoriaId = DOCUMENTOC2_n27CategoriaId[0];
            A77DocumentoFinalidadeTratamento = DOCUMENTOC2_A77DocumentoFinalidadeTratamento[0];
            n77DocumentoFinalidadeTratamento = DOCUMENTOC2_n77DocumentoFinalidadeTratamento[0];
            A13PersonaId = DOCUMENTOC2_A13PersonaId[0];
            n13PersonaId = DOCUMENTOC2_n13PersonaId[0];
            A7EncarregadoId = DOCUMENTOC2_A7EncarregadoId[0];
            n7EncarregadoId = DOCUMENTOC2_n7EncarregadoId[0];
            A20SubprocessoId = DOCUMENTOC2_A20SubprocessoId[0];
            n20SubprocessoId = DOCUMENTOC2_n20SubprocessoId[0];
            A76DocumentoNome = DOCUMENTOC2_A76DocumentoNome[0];
            n76DocumentoNome = DOCUMENTOC2_n76DocumentoNome[0];
            A75DocumentoId = DOCUMENTOC2_A75DocumentoId[0];
            A108DocumentoDataInclusao = DOCUMENTOC2_A108DocumentoDataInclusao[0];
            n108DocumentoDataInclusao = DOCUMENTOC2_n108DocumentoDataInclusao[0];
            A109DocumentoDataAlteracao = DOCUMENTOC2_A109DocumentoDataAlteracao[0];
            n109DocumentoDataAlteracao = DOCUMENTOC2_n109DocumentoDataAlteracao[0];
            A40001GXC2 = ( A109DocumentoDataAlteracao);
            A40000GXC1 = ( A108DocumentoDataInclusao);
            /*
               INSERT RECORD ON TABLE GXA0046

            */
            AV2DocumentoId = A75DocumentoId;
            if ( DOCUMENTOC2_n76DocumentoNome[0] )
            {
               AV3DocumentoNome = "";
               nV3DocumentoNome = false;
               nV3DocumentoNome = true;
            }
            else
            {
               AV3DocumentoNome = A76DocumentoNome;
               nV3DocumentoNome = false;
            }
            if ( DOCUMENTOC2_n20SubprocessoId[0] )
            {
               AV4SubprocessoId = 0;
               nV4SubprocessoId = false;
               nV4SubprocessoId = true;
            }
            else
            {
               AV4SubprocessoId = A20SubprocessoId;
               nV4SubprocessoId = false;
            }
            if ( DOCUMENTOC2_n7EncarregadoId[0] )
            {
               AV5EncarregadoId = 0;
               nV5EncarregadoId = false;
               nV5EncarregadoId = true;
            }
            else
            {
               AV5EncarregadoId = A7EncarregadoId;
               nV5EncarregadoId = false;
            }
            if ( DOCUMENTOC2_n13PersonaId[0] )
            {
               AV6PersonaId = 0;
               nV6PersonaId = false;
               nV6PersonaId = true;
            }
            else
            {
               AV6PersonaId = A13PersonaId;
               nV6PersonaId = false;
            }
            if ( DOCUMENTOC2_n77DocumentoFinalidadeTratamento[0] )
            {
               AV7DocumentoFinalidadeTratamento = "";
               nV7DocumentoFinalidadeTratamento = false;
               nV7DocumentoFinalidadeTratamento = true;
            }
            else
            {
               AV7DocumentoFinalidadeTratamento = A77DocumentoFinalidadeTratamento;
               nV7DocumentoFinalidadeTratamento = false;
            }
            if ( DOCUMENTOC2_n27CategoriaId[0] )
            {
               AV8CategoriaId = 0;
               nV8CategoriaId = false;
               nV8CategoriaId = true;
            }
            else
            {
               AV8CategoriaId = A27CategoriaId;
               nV8CategoriaId = false;
            }
            if ( DOCUMENTOC2_n30TipoDadoId[0] )
            {
               AV9TipoDadoId = 0;
               nV9TipoDadoId = false;
               nV9TipoDadoId = true;
            }
            else
            {
               AV9TipoDadoId = A30TipoDadoId;
               nV9TipoDadoId = false;
            }
            if ( DOCUMENTOC2_n33FerramentaColetaId[0] )
            {
               AV10FerramentaColetaId = 0;
               nV10FerramentaColetaId = false;
               nV10FerramentaColetaId = true;
            }
            else
            {
               AV10FerramentaColetaId = A33FerramentaColetaId;
               nV10FerramentaColetaId = false;
            }
            if ( DOCUMENTOC2_n36AbrangenciaGeograficaId[0] )
            {
               AV11AbrangenciaGeograficaId = 0;
               nV11AbrangenciaGeograficaId = false;
               nV11AbrangenciaGeograficaId = true;
            }
            else
            {
               AV11AbrangenciaGeograficaId = A36AbrangenciaGeograficaId;
               nV11AbrangenciaGeograficaId = false;
            }
            if ( DOCUMENTOC2_n39FrequenciaTratamentoId[0] )
            {
               AV12FrequenciaTratamentoId = 0;
               nV12FrequenciaTratamentoId = false;
               nV12FrequenciaTratamentoId = true;
            }
            else
            {
               AV12FrequenciaTratamentoId = A39FrequenciaTratamentoId;
               nV12FrequenciaTratamentoId = false;
            }
            if ( DOCUMENTOC2_n45TipoDescarteId[0] )
            {
               AV13TipoDescarteId = 0;
               nV13TipoDescarteId = false;
               nV13TipoDescarteId = true;
            }
            else
            {
               AV13TipoDescarteId = A45TipoDescarteId;
               nV13TipoDescarteId = false;
            }
            if ( DOCUMENTOC2_n48TempoRetencaoId[0] )
            {
               AV14TempoRetencaoId = 0;
               nV14TempoRetencaoId = false;
               nV14TempoRetencaoId = true;
            }
            else
            {
               AV14TempoRetencaoId = A48TempoRetencaoId;
               nV14TempoRetencaoId = false;
            }
            if ( DOCUMENTOC2_n78DocumentoPrevColetaDados[0] )
            {
               AV15DocumentoPrevColetaDados = false;
               nV15DocumentoPrevColetaDados = false;
               nV15DocumentoPrevColetaDados = true;
            }
            else
            {
               AV15DocumentoPrevColetaDados = A78DocumentoPrevColetaDados;
               nV15DocumentoPrevColetaDados = false;
            }
            if ( DOCUMENTOC2_n79DocumentoBaseLegalNorm[0] )
            {
               AV16DocumentoBaseLegalNorm = "";
               nV16DocumentoBaseLegalNorm = false;
               nV16DocumentoBaseLegalNorm = true;
            }
            else
            {
               AV16DocumentoBaseLegalNorm = A79DocumentoBaseLegalNorm;
               nV16DocumentoBaseLegalNorm = false;
            }
            if ( DOCUMENTOC2_n80DocumentoBaseLegalNormIntExt[0] )
            {
               AV17DocumentoBaseLegalNormIntExt = "";
               nV17DocumentoBaseLegalNormIntExt = false;
               nV17DocumentoBaseLegalNormIntExt = true;
            }
            else
            {
               AV17DocumentoBaseLegalNormIntExt = A80DocumentoBaseLegalNormIntExt;
               nV17DocumentoBaseLegalNormIntExt = false;
            }
            if ( DOCUMENTOC2_n81DocumentoDadosCriancaAdolesc[0] )
            {
               AV18DocumentoDadosCriancaAdolesc = false;
               nV18DocumentoDadosCriancaAdolesc = false;
               nV18DocumentoDadosCriancaAdolesc = true;
            }
            else
            {
               AV18DocumentoDadosCriancaAdolesc = A81DocumentoDadosCriancaAdolesc;
               nV18DocumentoDadosCriancaAdolesc = false;
            }
            if ( DOCUMENTOC2_n82DocumentoDadosGrupoVul[0] )
            {
               AV19DocumentoDadosGrupoVul = false;
               nV19DocumentoDadosGrupoVul = false;
               nV19DocumentoDadosGrupoVul = true;
            }
            else
            {
               AV19DocumentoDadosGrupoVul = A82DocumentoDadosGrupoVul;
               nV19DocumentoDadosGrupoVul = false;
            }
            if ( DOCUMENTOC2_n83DocumentoMedidaSegurancaDesc[0] )
            {
               AV20DocumentoMedidaSegurancaDesc = "";
               nV20DocumentoMedidaSegurancaDesc = false;
               nV20DocumentoMedidaSegurancaDesc = true;
            }
            else
            {
               AV20DocumentoMedidaSegurancaDesc = A83DocumentoMedidaSegurancaDesc;
               nV20DocumentoMedidaSegurancaDesc = false;
            }
            if ( DOCUMENTOC2_n84DocumentoFluxoTratDadosDesc[0] )
            {
               AV21DocumentoFluxoTratDadosDesc = "";
               nV21DocumentoFluxoTratDadosDesc = false;
               nV21DocumentoFluxoTratDadosDesc = true;
            }
            else
            {
               AV21DocumentoFluxoTratDadosDesc = A84DocumentoFluxoTratDadosDesc;
               nV21DocumentoFluxoTratDadosDesc = false;
            }
            if ( DOCUMENTOC2_n85DocumentoAtivo[0] )
            {
               AV22DocumentoAtivo = false;
               nV22DocumentoAtivo = false;
               nV22DocumentoAtivo = true;
            }
            else
            {
               AV22DocumentoAtivo = A85DocumentoAtivo;
               nV22DocumentoAtivo = false;
            }
            if ( DOCUMENTOC2_n105DocumentoOperador[0] )
            {
               AV23DocumentoOperador = false;
               nV23DocumentoOperador = false;
               nV23DocumentoOperador = true;
            }
            else
            {
               AV23DocumentoOperador = A105DocumentoOperador;
               nV23DocumentoOperador = false;
            }
            if ( DOCUMENTOC2_n106DocumentoProcessoId[0] )
            {
               AV24DocumentoProcessoId = 0;
               nV24DocumentoProcessoId = false;
               nV24DocumentoProcessoId = true;
            }
            else
            {
               AV24DocumentoProcessoId = A106DocumentoProcessoId;
               nV24DocumentoProcessoId = false;
            }
            if ( DOCUMENTOC2_n108DocumentoDataInclusao[0] )
            {
               AV25DocumentoDataInclusao = (DateTime)(DateTime.MinValue);
               nV25DocumentoDataInclusao = false;
               nV25DocumentoDataInclusao = true;
            }
            else
            {
               AV25DocumentoDataInclusao = A40000GXC1;
               nV25DocumentoDataInclusao = false;
            }
            if ( DOCUMENTOC2_n109DocumentoDataAlteracao[0] )
            {
               AV26DocumentoDataAlteracao = (DateTime)(DateTime.MinValue);
               nV26DocumentoDataAlteracao = false;
               nV26DocumentoDataAlteracao = true;
            }
            else
            {
               AV26DocumentoDataAlteracao = A40001GXC2;
               nV26DocumentoDataAlteracao = false;
            }
            if ( DOCUMENTOC2_n110DocumentoControladorId[0] )
            {
               AV27DocumentoControladorId = 0;
               nV27DocumentoControladorId = false;
               nV27DocumentoControladorId = true;
            }
            else
            {
               AV27DocumentoControladorId = A110DocumentoControladorId;
               nV27DocumentoControladorId = false;
            }
            if ( DOCUMENTOC2_n24AreaResponsavelId[0] )
            {
               AV28AreaResponsavelId = 0;
               nV28AreaResponsavelId = false;
               nV28AreaResponsavelId = true;
            }
            else
            {
               AV28AreaResponsavelId = A24AreaResponsavelId;
               nV28AreaResponsavelId = false;
            }
            AV29DocumentoUsuarioInclusao = "";
            nV29DocumentoUsuarioInclusao = false;
            nV29DocumentoUsuarioInclusao = true;
            AV30DocumentoUsuarioAlteracao = "";
            nV30DocumentoUsuarioAlteracao = false;
            nV30DocumentoUsuarioAlteracao = true;
            AV31DocumentoIsOperador = false;
            nV31DocumentoIsOperador = false;
            nV31DocumentoIsOperador = true;
            /* Using cursor DOCUMENTOC3 */
            pr_default.execute(1, new Object[] {AV2DocumentoId, nV3DocumentoNome, AV3DocumentoNome, nV4SubprocessoId, AV4SubprocessoId, nV5EncarregadoId, AV5EncarregadoId, nV6PersonaId, AV6PersonaId, nV7DocumentoFinalidadeTratamento, AV7DocumentoFinalidadeTratamento, nV8CategoriaId, AV8CategoriaId, nV9TipoDadoId, AV9TipoDadoId, nV10FerramentaColetaId, AV10FerramentaColetaId, nV11AbrangenciaGeograficaId, AV11AbrangenciaGeograficaId, nV12FrequenciaTratamentoId, AV12FrequenciaTratamentoId, nV13TipoDescarteId, AV13TipoDescarteId, nV14TempoRetencaoId, AV14TempoRetencaoId, nV15DocumentoPrevColetaDados, AV15DocumentoPrevColetaDados, nV16DocumentoBaseLegalNorm, AV16DocumentoBaseLegalNorm, nV17DocumentoBaseLegalNormIntExt, AV17DocumentoBaseLegalNormIntExt, nV18DocumentoDadosCriancaAdolesc, AV18DocumentoDadosCriancaAdolesc, nV19DocumentoDadosGrupoVul, AV19DocumentoDadosGrupoVul, nV20DocumentoMedidaSegurancaDesc, AV20DocumentoMedidaSegurancaDesc, nV21DocumentoFluxoTratDadosDesc, AV21DocumentoFluxoTratDadosDesc, nV22DocumentoAtivo, AV22DocumentoAtivo, nV23DocumentoOperador, AV23DocumentoOperador, nV24DocumentoProcessoId, AV24DocumentoProcessoId, nV25DocumentoDataInclusao, AV25DocumentoDataInclusao, nV26DocumentoDataAlteracao, AV26DocumentoDataAlteracao, nV27DocumentoControladorId, AV27DocumentoControladorId, nV28AreaResponsavelId, AV28AreaResponsavelId, nV29DocumentoUsuarioInclusao, AV29DocumentoUsuarioInclusao, nV30DocumentoUsuarioAlteracao, AV30DocumentoUsuarioAlteracao, nV31DocumentoIsOperador, AV31DocumentoIsOperador});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("GXA0046");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cmdBuffer=" SET IDENTITY_INSERT [GXA0046] OFF "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         cmdBuffer = "";
         scmdbuf = "";
         DOCUMENTOC2_A24AreaResponsavelId = new int[1] ;
         DOCUMENTOC2_n24AreaResponsavelId = new bool[] {false} ;
         DOCUMENTOC2_A110DocumentoControladorId = new int[1] ;
         DOCUMENTOC2_n110DocumentoControladorId = new bool[] {false} ;
         DOCUMENTOC2_A106DocumentoProcessoId = new int[1] ;
         DOCUMENTOC2_n106DocumentoProcessoId = new bool[] {false} ;
         DOCUMENTOC2_A105DocumentoOperador = new bool[] {false} ;
         DOCUMENTOC2_n105DocumentoOperador = new bool[] {false} ;
         DOCUMENTOC2_A85DocumentoAtivo = new bool[] {false} ;
         DOCUMENTOC2_n85DocumentoAtivo = new bool[] {false} ;
         DOCUMENTOC2_A84DocumentoFluxoTratDadosDesc = new string[] {""} ;
         DOCUMENTOC2_n84DocumentoFluxoTratDadosDesc = new bool[] {false} ;
         DOCUMENTOC2_A83DocumentoMedidaSegurancaDesc = new string[] {""} ;
         DOCUMENTOC2_n83DocumentoMedidaSegurancaDesc = new bool[] {false} ;
         DOCUMENTOC2_A82DocumentoDadosGrupoVul = new bool[] {false} ;
         DOCUMENTOC2_n82DocumentoDadosGrupoVul = new bool[] {false} ;
         DOCUMENTOC2_A81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         DOCUMENTOC2_n81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         DOCUMENTOC2_A80DocumentoBaseLegalNormIntExt = new string[] {""} ;
         DOCUMENTOC2_n80DocumentoBaseLegalNormIntExt = new bool[] {false} ;
         DOCUMENTOC2_A79DocumentoBaseLegalNorm = new string[] {""} ;
         DOCUMENTOC2_n79DocumentoBaseLegalNorm = new bool[] {false} ;
         DOCUMENTOC2_A78DocumentoPrevColetaDados = new bool[] {false} ;
         DOCUMENTOC2_n78DocumentoPrevColetaDados = new bool[] {false} ;
         DOCUMENTOC2_A48TempoRetencaoId = new int[1] ;
         DOCUMENTOC2_n48TempoRetencaoId = new bool[] {false} ;
         DOCUMENTOC2_A45TipoDescarteId = new int[1] ;
         DOCUMENTOC2_n45TipoDescarteId = new bool[] {false} ;
         DOCUMENTOC2_A39FrequenciaTratamentoId = new int[1] ;
         DOCUMENTOC2_n39FrequenciaTratamentoId = new bool[] {false} ;
         DOCUMENTOC2_A36AbrangenciaGeograficaId = new int[1] ;
         DOCUMENTOC2_n36AbrangenciaGeograficaId = new bool[] {false} ;
         DOCUMENTOC2_A33FerramentaColetaId = new int[1] ;
         DOCUMENTOC2_n33FerramentaColetaId = new bool[] {false} ;
         DOCUMENTOC2_A30TipoDadoId = new int[1] ;
         DOCUMENTOC2_n30TipoDadoId = new bool[] {false} ;
         DOCUMENTOC2_A27CategoriaId = new int[1] ;
         DOCUMENTOC2_n27CategoriaId = new bool[] {false} ;
         DOCUMENTOC2_A77DocumentoFinalidadeTratamento = new string[] {""} ;
         DOCUMENTOC2_n77DocumentoFinalidadeTratamento = new bool[] {false} ;
         DOCUMENTOC2_A13PersonaId = new int[1] ;
         DOCUMENTOC2_n13PersonaId = new bool[] {false} ;
         DOCUMENTOC2_A7EncarregadoId = new int[1] ;
         DOCUMENTOC2_n7EncarregadoId = new bool[] {false} ;
         DOCUMENTOC2_A20SubprocessoId = new int[1] ;
         DOCUMENTOC2_n20SubprocessoId = new bool[] {false} ;
         DOCUMENTOC2_A76DocumentoNome = new string[] {""} ;
         DOCUMENTOC2_n76DocumentoNome = new bool[] {false} ;
         DOCUMENTOC2_A75DocumentoId = new int[1] ;
         DOCUMENTOC2_A108DocumentoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         DOCUMENTOC2_n108DocumentoDataInclusao = new bool[] {false} ;
         DOCUMENTOC2_A109DocumentoDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         DOCUMENTOC2_n109DocumentoDataAlteracao = new bool[] {false} ;
         A84DocumentoFluxoTratDadosDesc = "";
         A83DocumentoMedidaSegurancaDesc = "";
         A80DocumentoBaseLegalNormIntExt = "";
         A79DocumentoBaseLegalNorm = "";
         A77DocumentoFinalidadeTratamento = "";
         A76DocumentoNome = "";
         A108DocumentoDataInclusao = DateTime.MinValue;
         A109DocumentoDataAlteracao = DateTime.MinValue;
         A40001GXC2 = (DateTime)(DateTime.MinValue);
         A40000GXC1 = (DateTime)(DateTime.MinValue);
         AV3DocumentoNome = "";
         AV7DocumentoFinalidadeTratamento = "";
         AV16DocumentoBaseLegalNorm = "";
         AV17DocumentoBaseLegalNormIntExt = "";
         AV20DocumentoMedidaSegurancaDesc = "";
         AV21DocumentoFluxoTratDadosDesc = "";
         AV25DocumentoDataInclusao = (DateTime)(DateTime.MinValue);
         AV26DocumentoDataAlteracao = (DateTime)(DateTime.MinValue);
         AV29DocumentoUsuarioInclusao = "";
         AV30DocumentoUsuarioAlteracao = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documentoconversion__default(),
            new Object[][] {
                new Object[] {
               DOCUMENTOC2_A24AreaResponsavelId, DOCUMENTOC2_n24AreaResponsavelId, DOCUMENTOC2_A110DocumentoControladorId, DOCUMENTOC2_n110DocumentoControladorId, DOCUMENTOC2_A106DocumentoProcessoId, DOCUMENTOC2_n106DocumentoProcessoId, DOCUMENTOC2_A105DocumentoOperador, DOCUMENTOC2_n105DocumentoOperador, DOCUMENTOC2_A85DocumentoAtivo, DOCUMENTOC2_n85DocumentoAtivo,
               DOCUMENTOC2_A84DocumentoFluxoTratDadosDesc, DOCUMENTOC2_n84DocumentoFluxoTratDadosDesc, DOCUMENTOC2_A83DocumentoMedidaSegurancaDesc, DOCUMENTOC2_n83DocumentoMedidaSegurancaDesc, DOCUMENTOC2_A82DocumentoDadosGrupoVul, DOCUMENTOC2_n82DocumentoDadosGrupoVul, DOCUMENTOC2_A81DocumentoDadosCriancaAdolesc, DOCUMENTOC2_n81DocumentoDadosCriancaAdolesc, DOCUMENTOC2_A80DocumentoBaseLegalNormIntExt, DOCUMENTOC2_n80DocumentoBaseLegalNormIntExt,
               DOCUMENTOC2_A79DocumentoBaseLegalNorm, DOCUMENTOC2_n79DocumentoBaseLegalNorm, DOCUMENTOC2_A78DocumentoPrevColetaDados, DOCUMENTOC2_n78DocumentoPrevColetaDados, DOCUMENTOC2_A48TempoRetencaoId, DOCUMENTOC2_n48TempoRetencaoId, DOCUMENTOC2_A45TipoDescarteId, DOCUMENTOC2_n45TipoDescarteId, DOCUMENTOC2_A39FrequenciaTratamentoId, DOCUMENTOC2_n39FrequenciaTratamentoId,
               DOCUMENTOC2_A36AbrangenciaGeograficaId, DOCUMENTOC2_n36AbrangenciaGeograficaId, DOCUMENTOC2_A33FerramentaColetaId, DOCUMENTOC2_n33FerramentaColetaId, DOCUMENTOC2_A30TipoDadoId, DOCUMENTOC2_n30TipoDadoId, DOCUMENTOC2_A27CategoriaId, DOCUMENTOC2_n27CategoriaId, DOCUMENTOC2_A77DocumentoFinalidadeTratamento, DOCUMENTOC2_n77DocumentoFinalidadeTratamento,
               DOCUMENTOC2_A13PersonaId, DOCUMENTOC2_n13PersonaId, DOCUMENTOC2_A7EncarregadoId, DOCUMENTOC2_n7EncarregadoId, DOCUMENTOC2_A20SubprocessoId, DOCUMENTOC2_n20SubprocessoId, DOCUMENTOC2_A76DocumentoNome, DOCUMENTOC2_n76DocumentoNome, DOCUMENTOC2_A75DocumentoId, DOCUMENTOC2_A108DocumentoDataInclusao,
               DOCUMENTOC2_n108DocumentoDataInclusao, DOCUMENTOC2_A109DocumentoDataAlteracao, DOCUMENTOC2_n109DocumentoDataAlteracao
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A24AreaResponsavelId ;
      private int A110DocumentoControladorId ;
      private int A106DocumentoProcessoId ;
      private int A48TempoRetencaoId ;
      private int A45TipoDescarteId ;
      private int A39FrequenciaTratamentoId ;
      private int A36AbrangenciaGeograficaId ;
      private int A33FerramentaColetaId ;
      private int A30TipoDadoId ;
      private int A27CategoriaId ;
      private int A13PersonaId ;
      private int A7EncarregadoId ;
      private int A20SubprocessoId ;
      private int A75DocumentoId ;
      private int GIGXA0046 ;
      private int AV2DocumentoId ;
      private int AV4SubprocessoId ;
      private int AV5EncarregadoId ;
      private int AV6PersonaId ;
      private int AV8CategoriaId ;
      private int AV9TipoDadoId ;
      private int AV10FerramentaColetaId ;
      private int AV11AbrangenciaGeograficaId ;
      private int AV12FrequenciaTratamentoId ;
      private int AV13TipoDescarteId ;
      private int AV14TempoRetencaoId ;
      private int AV24DocumentoProcessoId ;
      private int AV27DocumentoControladorId ;
      private int AV28AreaResponsavelId ;
      private string cmdBuffer ;
      private string scmdbuf ;
      private string Gx_emsg ;
      private DateTime A40001GXC2 ;
      private DateTime A40000GXC1 ;
      private DateTime AV25DocumentoDataInclusao ;
      private DateTime AV26DocumentoDataAlteracao ;
      private DateTime A108DocumentoDataInclusao ;
      private DateTime A109DocumentoDataAlteracao ;
      private bool n24AreaResponsavelId ;
      private bool n110DocumentoControladorId ;
      private bool n106DocumentoProcessoId ;
      private bool A105DocumentoOperador ;
      private bool n105DocumentoOperador ;
      private bool A85DocumentoAtivo ;
      private bool n85DocumentoAtivo ;
      private bool n84DocumentoFluxoTratDadosDesc ;
      private bool n83DocumentoMedidaSegurancaDesc ;
      private bool A82DocumentoDadosGrupoVul ;
      private bool n82DocumentoDadosGrupoVul ;
      private bool A81DocumentoDadosCriancaAdolesc ;
      private bool n81DocumentoDadosCriancaAdolesc ;
      private bool n80DocumentoBaseLegalNormIntExt ;
      private bool n79DocumentoBaseLegalNorm ;
      private bool A78DocumentoPrevColetaDados ;
      private bool n78DocumentoPrevColetaDados ;
      private bool n48TempoRetencaoId ;
      private bool n45TipoDescarteId ;
      private bool n39FrequenciaTratamentoId ;
      private bool n36AbrangenciaGeograficaId ;
      private bool n33FerramentaColetaId ;
      private bool n30TipoDadoId ;
      private bool n27CategoriaId ;
      private bool n77DocumentoFinalidadeTratamento ;
      private bool n13PersonaId ;
      private bool n7EncarregadoId ;
      private bool n20SubprocessoId ;
      private bool n76DocumentoNome ;
      private bool n108DocumentoDataInclusao ;
      private bool n109DocumentoDataAlteracao ;
      private bool nV3DocumentoNome ;
      private bool nV4SubprocessoId ;
      private bool nV5EncarregadoId ;
      private bool nV6PersonaId ;
      private bool nV7DocumentoFinalidadeTratamento ;
      private bool nV8CategoriaId ;
      private bool nV9TipoDadoId ;
      private bool nV10FerramentaColetaId ;
      private bool nV11AbrangenciaGeograficaId ;
      private bool nV12FrequenciaTratamentoId ;
      private bool nV13TipoDescarteId ;
      private bool nV14TempoRetencaoId ;
      private bool AV15DocumentoPrevColetaDados ;
      private bool nV15DocumentoPrevColetaDados ;
      private bool nV16DocumentoBaseLegalNorm ;
      private bool nV17DocumentoBaseLegalNormIntExt ;
      private bool AV18DocumentoDadosCriancaAdolesc ;
      private bool nV18DocumentoDadosCriancaAdolesc ;
      private bool AV19DocumentoDadosGrupoVul ;
      private bool nV19DocumentoDadosGrupoVul ;
      private bool nV20DocumentoMedidaSegurancaDesc ;
      private bool nV21DocumentoFluxoTratDadosDesc ;
      private bool AV22DocumentoAtivo ;
      private bool nV22DocumentoAtivo ;
      private bool AV23DocumentoOperador ;
      private bool nV23DocumentoOperador ;
      private bool nV24DocumentoProcessoId ;
      private bool nV25DocumentoDataInclusao ;
      private bool nV26DocumentoDataAlteracao ;
      private bool nV27DocumentoControladorId ;
      private bool nV28AreaResponsavelId ;
      private bool nV29DocumentoUsuarioInclusao ;
      private bool nV30DocumentoUsuarioAlteracao ;
      private bool AV31DocumentoIsOperador ;
      private bool nV31DocumentoIsOperador ;
      private string A84DocumentoFluxoTratDadosDesc ;
      private string AV20DocumentoMedidaSegurancaDesc ;
      private string AV21DocumentoFluxoTratDadosDesc ;
      private string A83DocumentoMedidaSegurancaDesc ;
      private string A80DocumentoBaseLegalNormIntExt ;
      private string A79DocumentoBaseLegalNorm ;
      private string A77DocumentoFinalidadeTratamento ;
      private string A76DocumentoNome ;
      private string AV3DocumentoNome ;
      private string AV7DocumentoFinalidadeTratamento ;
      private string AV16DocumentoBaseLegalNorm ;
      private string AV17DocumentoBaseLegalNormIntExt ;
      private string AV29DocumentoUsuarioInclusao ;
      private string AV30DocumentoUsuarioAlteracao ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxCommand RGZ ;
      private IDataStoreProvider pr_default ;
      private int[] DOCUMENTOC2_A24AreaResponsavelId ;
      private bool[] DOCUMENTOC2_n24AreaResponsavelId ;
      private int[] DOCUMENTOC2_A110DocumentoControladorId ;
      private bool[] DOCUMENTOC2_n110DocumentoControladorId ;
      private int[] DOCUMENTOC2_A106DocumentoProcessoId ;
      private bool[] DOCUMENTOC2_n106DocumentoProcessoId ;
      private bool[] DOCUMENTOC2_A105DocumentoOperador ;
      private bool[] DOCUMENTOC2_n105DocumentoOperador ;
      private bool[] DOCUMENTOC2_A85DocumentoAtivo ;
      private bool[] DOCUMENTOC2_n85DocumentoAtivo ;
      private string[] DOCUMENTOC2_A84DocumentoFluxoTratDadosDesc ;
      private bool[] DOCUMENTOC2_n84DocumentoFluxoTratDadosDesc ;
      private string[] DOCUMENTOC2_A83DocumentoMedidaSegurancaDesc ;
      private bool[] DOCUMENTOC2_n83DocumentoMedidaSegurancaDesc ;
      private bool[] DOCUMENTOC2_A82DocumentoDadosGrupoVul ;
      private bool[] DOCUMENTOC2_n82DocumentoDadosGrupoVul ;
      private bool[] DOCUMENTOC2_A81DocumentoDadosCriancaAdolesc ;
      private bool[] DOCUMENTOC2_n81DocumentoDadosCriancaAdolesc ;
      private string[] DOCUMENTOC2_A80DocumentoBaseLegalNormIntExt ;
      private bool[] DOCUMENTOC2_n80DocumentoBaseLegalNormIntExt ;
      private string[] DOCUMENTOC2_A79DocumentoBaseLegalNorm ;
      private bool[] DOCUMENTOC2_n79DocumentoBaseLegalNorm ;
      private bool[] DOCUMENTOC2_A78DocumentoPrevColetaDados ;
      private bool[] DOCUMENTOC2_n78DocumentoPrevColetaDados ;
      private int[] DOCUMENTOC2_A48TempoRetencaoId ;
      private bool[] DOCUMENTOC2_n48TempoRetencaoId ;
      private int[] DOCUMENTOC2_A45TipoDescarteId ;
      private bool[] DOCUMENTOC2_n45TipoDescarteId ;
      private int[] DOCUMENTOC2_A39FrequenciaTratamentoId ;
      private bool[] DOCUMENTOC2_n39FrequenciaTratamentoId ;
      private int[] DOCUMENTOC2_A36AbrangenciaGeograficaId ;
      private bool[] DOCUMENTOC2_n36AbrangenciaGeograficaId ;
      private int[] DOCUMENTOC2_A33FerramentaColetaId ;
      private bool[] DOCUMENTOC2_n33FerramentaColetaId ;
      private int[] DOCUMENTOC2_A30TipoDadoId ;
      private bool[] DOCUMENTOC2_n30TipoDadoId ;
      private int[] DOCUMENTOC2_A27CategoriaId ;
      private bool[] DOCUMENTOC2_n27CategoriaId ;
      private string[] DOCUMENTOC2_A77DocumentoFinalidadeTratamento ;
      private bool[] DOCUMENTOC2_n77DocumentoFinalidadeTratamento ;
      private int[] DOCUMENTOC2_A13PersonaId ;
      private bool[] DOCUMENTOC2_n13PersonaId ;
      private int[] DOCUMENTOC2_A7EncarregadoId ;
      private bool[] DOCUMENTOC2_n7EncarregadoId ;
      private int[] DOCUMENTOC2_A20SubprocessoId ;
      private bool[] DOCUMENTOC2_n20SubprocessoId ;
      private string[] DOCUMENTOC2_A76DocumentoNome ;
      private bool[] DOCUMENTOC2_n76DocumentoNome ;
      private int[] DOCUMENTOC2_A75DocumentoId ;
      private DateTime[] DOCUMENTOC2_A108DocumentoDataInclusao ;
      private bool[] DOCUMENTOC2_n108DocumentoDataInclusao ;
      private DateTime[] DOCUMENTOC2_A109DocumentoDataAlteracao ;
      private bool[] DOCUMENTOC2_n109DocumentoDataAlteracao ;
   }

   public class documentoconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmDOCUMENTOC2;
          prmDOCUMENTOC2 = new Object[] {
          };
          Object[] prmDOCUMENTOC3;
          prmDOCUMENTOC3 = new Object[] {
          new ParDef("@AV2DocumentoId",GXType.Int32,8,0) ,
          new ParDef("@AV3DocumentoNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("@AV4SubprocessoId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("@AV5EncarregadoId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("@AV6PersonaId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("@AV7DocumentoFinalidadeTratamento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("@AV8CategoriaId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("@AV9TipoDadoId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("@AV10FerramentaColetaId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("@AV11AbrangenciaGeograficaId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("@AV12FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("@AV13TipoDescarteId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("@AV14TempoRetencaoId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("@AV15DocumentoPrevColetaDados",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@AV16DocumentoBaseLegalNorm",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("@AV17DocumentoBaseLegalNormIntExt",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("@AV18DocumentoDadosCriancaAdolesc",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@AV19DocumentoDadosGrupoVul",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@AV20DocumentoMedidaSegurancaDesc",GXType.VarChar,10000,0){Nullable=true} ,
          new ParDef("@AV21DocumentoFluxoTratDadosDesc",GXType.VarChar,10000,0){Nullable=true} ,
          new ParDef("@AV22DocumentoAtivo",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@AV23DocumentoOperador",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@AV24DocumentoProcessoId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("@AV25DocumentoDataInclusao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("@AV26DocumentoDataAlteracao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("@AV27DocumentoControladorId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("@AV28AreaResponsavelId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("@AV29DocumentoUsuarioInclusao",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("@AV30DocumentoUsuarioAlteracao",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("@AV31DocumentoIsOperador",GXType.Boolean,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("DOCUMENTOC2", "SELECT [AreaResponsavelId], [DocumentoControladorId], [DocumentoProcessoId], [DocumentoOperador], [DocumentoAtivo], [DocumentoFluxoTratDadosDesc], [DocumentoMedidaSegurancaDesc], [DocumentoDadosGrupoVul], [DocumentoDadosCriancaAdolesc], [DocumentoBaseLegalNormIntExt], [DocumentoBaseLegalNorm], [DocumentoPrevColetaDados], [TempoRetencaoId], [TipoDescarteId], [FrequenciaTratamentoId], [AbrangenciaGeograficaId], [FerramentaColetaId], [TipoDadoId], [CategoriaId], [DocumentoFinalidadeTratamento], [PersonaId], [EncarregadoId], [SubprocessoId], [DocumentoNome], [DocumentoId], [DocumentoDataInclusao], [DocumentoDataAlteracao] FROM [Documento] ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmDOCUMENTOC2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("DOCUMENTOC3", "INSERT INTO [GXA0046]([DocumentoId], [DocumentoNome], [SubprocessoId], [EncarregadoId], [PersonaId], [DocumentoFinalidadeTratamento], [CategoriaId], [TipoDadoId], [FerramentaColetaId], [AbrangenciaGeograficaId], [FrequenciaTratamentoId], [TipoDescarteId], [TempoRetencaoId], [DocumentoPrevColetaDados], [DocumentoBaseLegalNorm], [DocumentoBaseLegalNormIntExt], [DocumentoDadosCriancaAdolesc], [DocumentoDadosGrupoVul], [DocumentoMedidaSegurancaDesc], [DocumentoFluxoTratDadosDesc], [DocumentoAtivo], [DocumentoOperador], [DocumentoProcessoId], [DocumentoDataInclusao], [DocumentoDataAlteracao], [DocumentoControladorId], [AreaResponsavelId], [DocumentoUsuarioInclusao], [DocumentoUsuarioAlteracao], [DocumentoIsOperador]) VALUES(@AV2DocumentoId, @AV3DocumentoNome, @AV4SubprocessoId, @AV5EncarregadoId, @AV6PersonaId, @AV7DocumentoFinalidadeTratamento, @AV8CategoriaId, @AV9TipoDadoId, @AV10FerramentaColetaId, @AV11AbrangenciaGeograficaId, @AV12FrequenciaTratamentoId, @AV13TipoDescarteId, @AV14TempoRetencaoId, @AV15DocumentoPrevColetaDados, @AV16DocumentoBaseLegalNorm, @AV17DocumentoBaseLegalNormIntExt, @AV18DocumentoDadosCriancaAdolesc, @AV19DocumentoDadosGrupoVul, @AV20DocumentoMedidaSegurancaDesc, @AV21DocumentoFluxoTratDadosDesc, @AV22DocumentoAtivo, @AV23DocumentoOperador, @AV24DocumentoProcessoId, @AV25DocumentoDataInclusao, @AV26DocumentoDataAlteracao, @AV27DocumentoControladorId, @AV28AreaResponsavelId, @AV29DocumentoUsuarioInclusao, @AV30DocumentoUsuarioAlteracao, @AV31DocumentoIsOperador)", GxErrorMask.GX_NOMASK,prmDOCUMENTOC3)
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((bool[]) buf[6])[0] = rslt.getBool(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((bool[]) buf[8])[0] = rslt.getBool(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((bool[]) buf[14])[0] = rslt.getBool(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((bool[]) buf[16])[0] = rslt.getBool(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((bool[]) buf[22])[0] = rslt.getBool(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((int[]) buf[24])[0] = rslt.getInt(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((int[]) buf[26])[0] = rslt.getInt(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((int[]) buf[28])[0] = rslt.getInt(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((int[]) buf[30])[0] = rslt.getInt(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((int[]) buf[32])[0] = rslt.getInt(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((int[]) buf[34])[0] = rslt.getInt(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((int[]) buf[36])[0] = rslt.getInt(19);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((string[]) buf[38])[0] = rslt.getVarchar(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((int[]) buf[40])[0] = rslt.getInt(21);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((int[]) buf[42])[0] = rslt.getInt(22);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((int[]) buf[44])[0] = rslt.getInt(23);
                ((bool[]) buf[45])[0] = rslt.wasNull(23);
                ((string[]) buf[46])[0] = rslt.getVarchar(24);
                ((bool[]) buf[47])[0] = rslt.wasNull(24);
                ((int[]) buf[48])[0] = rslt.getInt(25);
                ((DateTime[]) buf[49])[0] = rslt.getGXDate(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((DateTime[]) buf[51])[0] = rslt.getGXDate(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                return;
       }
    }

 }

}
