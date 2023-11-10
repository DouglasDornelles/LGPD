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
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class adocumentorelatoriopdf : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
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
            return "documentorelatoriopdf_Execute" ;
         }

      }

      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "adocumentorelatoriopdf.aspx")), "adocumentorelatoriopdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "adocumentorelatoriopdf.aspx")))) ;
            }
            else
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusDescription = 403.ToString();
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
         }
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "DocumentoId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV14DocumentoId = (int)(NumberUtil.Val( gxfirstwebparm, "."));
            }
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public adocumentorelatoriopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public adocumentorelatoriopdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocumentoId )
      {
         this.AV14DocumentoId = aP0_DocumentoId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_DocumentoId )
      {
         adocumentorelatoriopdf objadocumentorelatoriopdf;
         objadocumentorelatoriopdf = new adocumentorelatoriopdf();
         objadocumentorelatoriopdf.AV14DocumentoId = aP0_DocumentoId;
         objadocumentorelatoriopdf.context.SetSubmitInitialConfig(context);
         objadocumentorelatoriopdf.initialize();
         Submit( executePrivateCatch,objadocumentorelatoriopdf);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((adocumentorelatoriopdf)stateInfo).executePrivate();
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
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 14616, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            AV39DicionarioQTD.Clear();
            AV41OperadorQTD.Clear();
            AV18FileName = "Documento_" + StringUtil.Trim( StringUtil.Str( (decimal)(AV14DocumentoId), 8, 0)) + ".pdf";
            AV86GXLvl19 = 0;
            /* Using cursor P006J2 */
            pr_default.execute(0, new Object[] {AV14DocumentoId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A20SubprocessoId = P006J2_A20SubprocessoId[0];
               n20SubprocessoId = P006J2_n20SubprocessoId[0];
               A16ProcessoId = P006J2_A16ProcessoId[0];
               n16ProcessoId = P006J2_n16ProcessoId[0];
               A7EncarregadoId = P006J2_A7EncarregadoId[0];
               n7EncarregadoId = P006J2_n7EncarregadoId[0];
               A13PersonaId = P006J2_A13PersonaId[0];
               n13PersonaId = P006J2_n13PersonaId[0];
               A27CategoriaId = P006J2_A27CategoriaId[0];
               n27CategoriaId = P006J2_n27CategoriaId[0];
               A30TipoDadoId = P006J2_A30TipoDadoId[0];
               n30TipoDadoId = P006J2_n30TipoDadoId[0];
               A33FerramentaColetaId = P006J2_A33FerramentaColetaId[0];
               n33FerramentaColetaId = P006J2_n33FerramentaColetaId[0];
               A36AbrangenciaGeograficaId = P006J2_A36AbrangenciaGeograficaId[0];
               n36AbrangenciaGeograficaId = P006J2_n36AbrangenciaGeograficaId[0];
               A39FrequenciaTratamentoId = P006J2_A39FrequenciaTratamentoId[0];
               n39FrequenciaTratamentoId = P006J2_n39FrequenciaTratamentoId[0];
               A45TipoDescarteId = P006J2_A45TipoDescarteId[0];
               n45TipoDescarteId = P006J2_n45TipoDescarteId[0];
               A48TempoRetencaoId = P006J2_A48TempoRetencaoId[0];
               n48TempoRetencaoId = P006J2_n48TempoRetencaoId[0];
               A24AreaResponsavelId = P006J2_A24AreaResponsavelId[0];
               n24AreaResponsavelId = P006J2_n24AreaResponsavelId[0];
               A110DocumentoControladorId = P006J2_A110DocumentoControladorId[0];
               n110DocumentoControladorId = P006J2_n110DocumentoControladorId[0];
               A75DocumentoId = P006J2_A75DocumentoId[0];
               A76DocumentoNome = P006J2_A76DocumentoNome[0];
               n76DocumentoNome = P006J2_n76DocumentoNome[0];
               A17ProcessoNome = P006J2_A17ProcessoNome[0];
               A21SubprocessoNome = P006J2_A21SubprocessoNome[0];
               A25AreaResponsavelNome = P006J2_A25AreaResponsavelNome[0];
               A11ControladorNome = P006J2_A11ControladorNome[0];
               n11ControladorNome = P006J2_n11ControladorNome[0];
               A14PersonaNome = P006J2_A14PersonaNome[0];
               A8EncarregadoNome = P006J2_A8EncarregadoNome[0];
               A108DocumentoDataInclusao = P006J2_A108DocumentoDataInclusao[0];
               n108DocumentoDataInclusao = P006J2_n108DocumentoDataInclusao[0];
               A141DocumentoUsuarioInclusao = P006J2_A141DocumentoUsuarioInclusao[0];
               n141DocumentoUsuarioInclusao = P006J2_n141DocumentoUsuarioInclusao[0];
               A109DocumentoDataAlteracao = P006J2_A109DocumentoDataAlteracao[0];
               n109DocumentoDataAlteracao = P006J2_n109DocumentoDataAlteracao[0];
               A142DocumentoUsuarioAlteracao = P006J2_A142DocumentoUsuarioAlteracao[0];
               n142DocumentoUsuarioAlteracao = P006J2_n142DocumentoUsuarioAlteracao[0];
               A77DocumentoFinalidadeTratamento = P006J2_A77DocumentoFinalidadeTratamento[0];
               n77DocumentoFinalidadeTratamento = P006J2_n77DocumentoFinalidadeTratamento[0];
               A28CategoriaNome = P006J2_A28CategoriaNome[0];
               A31TipoDadoNome = P006J2_A31TipoDadoNome[0];
               A34FerramentaColetaNome = P006J2_A34FerramentaColetaNome[0];
               A37AbrangenciaGeograficaNome = P006J2_A37AbrangenciaGeograficaNome[0];
               A40FrequenciaTratamentoNome = P006J2_A40FrequenciaTratamentoNome[0];
               A46TipoDescarteNome = P006J2_A46TipoDescarteNome[0];
               A49TempoRetencaoNome = P006J2_A49TempoRetencaoNome[0];
               A79DocumentoBaseLegalNorm = P006J2_A79DocumentoBaseLegalNorm[0];
               n79DocumentoBaseLegalNorm = P006J2_n79DocumentoBaseLegalNorm[0];
               A80DocumentoBaseLegalNormIntExt = P006J2_A80DocumentoBaseLegalNormIntExt[0];
               n80DocumentoBaseLegalNormIntExt = P006J2_n80DocumentoBaseLegalNormIntExt[0];
               A78DocumentoPrevColetaDados = P006J2_A78DocumentoPrevColetaDados[0];
               n78DocumentoPrevColetaDados = P006J2_n78DocumentoPrevColetaDados[0];
               A82DocumentoDadosGrupoVul = P006J2_A82DocumentoDadosGrupoVul[0];
               n82DocumentoDadosGrupoVul = P006J2_n82DocumentoDadosGrupoVul[0];
               A81DocumentoDadosCriancaAdolesc = P006J2_A81DocumentoDadosCriancaAdolesc[0];
               n81DocumentoDadosCriancaAdolesc = P006J2_n81DocumentoDadosCriancaAdolesc[0];
               A83DocumentoMedidaSegurancaDesc = P006J2_A83DocumentoMedidaSegurancaDesc[0];
               n83DocumentoMedidaSegurancaDesc = P006J2_n83DocumentoMedidaSegurancaDesc[0];
               A84DocumentoFluxoTratDadosDesc = P006J2_A84DocumentoFluxoTratDadosDesc[0];
               n84DocumentoFluxoTratDadosDesc = P006J2_n84DocumentoFluxoTratDadosDesc[0];
               A16ProcessoId = P006J2_A16ProcessoId[0];
               n16ProcessoId = P006J2_n16ProcessoId[0];
               A21SubprocessoNome = P006J2_A21SubprocessoNome[0];
               A17ProcessoNome = P006J2_A17ProcessoNome[0];
               A8EncarregadoNome = P006J2_A8EncarregadoNome[0];
               A14PersonaNome = P006J2_A14PersonaNome[0];
               A28CategoriaNome = P006J2_A28CategoriaNome[0];
               A31TipoDadoNome = P006J2_A31TipoDadoNome[0];
               A34FerramentaColetaNome = P006J2_A34FerramentaColetaNome[0];
               A37AbrangenciaGeograficaNome = P006J2_A37AbrangenciaGeograficaNome[0];
               A40FrequenciaTratamentoNome = P006J2_A40FrequenciaTratamentoNome[0];
               A46TipoDescarteNome = P006J2_A46TipoDescarteNome[0];
               A49TempoRetencaoNome = P006J2_A49TempoRetencaoNome[0];
               A25AreaResponsavelNome = P006J2_A25AreaResponsavelNome[0];
               A11ControladorNome = P006J2_A11ControladorNome[0];
               n11ControladorNome = P006J2_n11ControladorNome[0];
               AV86GXLvl19 = 1;
               AV15DocumentoNome = A76DocumentoNome;
               H6J0( false, 1169) ;
               getPrinter().GxAttris("Arial", 16, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("RELATÓRIO DE IMPACTO", 283, Gx_line+500, 549, Gx_line+525, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("À PROTEÇÃO DE DADOS PESSOAIS", 225, Gx_line+533, 608, Gx_line+558, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Arial", 11, true, false, true, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("DOCUMENTO:", 258, Gx_line+633, 377, Gx_line+750, 1, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 11, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15DocumentoNome, "")), 383, Gx_line+633, 758, Gx_line+750, 3+16, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+1169);
               AV22ProcessoNome = StringUtil.Upper( A17ProcessoNome);
               AV24SubProcessoNome = StringUtil.Upper( A21SubprocessoNome);
               AV9AreaResponsavelNome = StringUtil.Upper( A25AreaResponsavelNome);
               AV11ControladorNome = StringUtil.Upper( A11ControladorNome);
               AV21PersonaNome = StringUtil.Upper( A14PersonaNome);
               AV16EncarregadoNome = StringUtil.Upper( A8EncarregadoNome);
               AV44DocumentoDataInclusao = A108DocumentoDataInclusao;
               AV42DocumentoUsuarioInclusao = StringUtil.Upper( A141DocumentoUsuarioInclusao);
               AV45DocumentoDataAlteracao = A109DocumentoDataAlteracao;
               AV43DocumentoUsuarioAlteracao = StringUtil.Upper( A142DocumentoUsuarioAlteracao);
               H6J0( false, 542) ;
               getPrinter().GxAttris("Calibri", 11, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("DOCUMENTO:", 42, Gx_line+17, 142, Gx_line+67, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15DocumentoNome, "")), 150, Gx_line+17, 792, Gx_line+67, 0+16, 0, 0, 1) ;
               getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("PROCESSO:", 42, Gx_line+233, 192, Gx_line+283, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("SUBPROCESSO:", 42, Gx_line+283, 192, Gx_line+333, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("ÁREA RESPONSÁVEL:", 42, Gx_line+333, 192, Gx_line+383, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("CONTROLADOR:", 42, Gx_line+383, 192, Gx_line+433, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("PERSONA:", 42, Gx_line+433, 192, Gx_line+483, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("ENCARREGADO:", 42, Gx_line+483, 192, Gx_line+533, 0+16, 0, 0, 1) ;
               getPrinter().GxAttris("Calibri", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22ProcessoNome, "")), 200, Gx_line+233, 792, Gx_line+283, 3+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24SubProcessoNome, "")), 200, Gx_line+283, 792, Gx_line+333, 3+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9AreaResponsavelNome, "")), 200, Gx_line+333, 792, Gx_line+383, 3+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11ControladorNome, "")), 200, Gx_line+383, 792, Gx_line+433, 3+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21PersonaNome, "")), 200, Gx_line+433, 792, Gx_line+483, 3+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16EncarregadoNome, "")), 200, Gx_line+483, 792, Gx_line+533, 3+16, 0, 0, 1) ;
               getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("CÓDIGO:", 42, Gx_line+83, 192, Gx_line+133, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("DATA:", 633, Gx_line+133, 683, Gx_line+183, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("DATA:", 633, Gx_line+183, 683, Gx_line+233, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("USUÁRIO INCLUSÃO:", 42, Gx_line+133, 192, Gx_line+183, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("USUÁRIO ALTERAÇÃO:", 42, Gx_line+183, 192, Gx_line+233, 0+16, 0, 0, 1) ;
               getPrinter().GxAttris("Calibri", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42DocumentoUsuarioInclusao, "")), 200, Gx_line+133, 625, Gx_line+183, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43DocumentoUsuarioAlteracao, "")), 200, Gx_line+183, 625, Gx_line+233, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV44DocumentoDataInclusao, "99/99/99 99:99"), 683, Gx_line+133, 791, Gx_line+183, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV45DocumentoDataAlteracao, "99/99/99 99:99"), 683, Gx_line+183, 791, Gx_line+233, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV14DocumentoId), "ZZZZZZZ9")), 200, Gx_line+83, 792, Gx_line+133, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawLine(42, Gx_line+283, 792, Gx_line+283, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+333, 792, Gx_line+333, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+383, 792, Gx_line+383, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+433, 792, Gx_line+433, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+483, 792, Gx_line+483, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+533, 792, Gx_line+533, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+233, 792, Gx_line+233, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+183, 792, Gx_line+183, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+133, 792, Gx_line+133, 1, 192, 192, 192, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+542);
               AV13DocumentoFinalidadeTratamento = StringUtil.Upper( A77DocumentoFinalidadeTratamento);
               AV10CategoriaNome = StringUtil.Upper( A28CategoriaNome);
               AV25TipoDadoNome = StringUtil.Upper( A31TipoDadoNome);
               AV17FerramentaColetaNome = StringUtil.Upper( A34FerramentaColetaNome);
               AV8AbrangenciaGeograficaNome = StringUtil.Upper( A37AbrangenciaGeograficaNome);
               AV20FrequenciaTratamentoNome = StringUtil.Upper( A40FrequenciaTratamentoNome);
               AV46TipoDescarte = StringUtil.Upper( A46TipoDescarteNome);
               AV47TempoRetencao = StringUtil.Upper( A49TempoRetencaoNome);
               AV49BaseLegalNorm = StringUtil.Upper( A79DocumentoBaseLegalNorm);
               AV50BaseLegalNormIntExt = StringUtil.Upper( A80DocumentoBaseLegalNormIntExt);
               AV48PrevColetaDados = ((A78DocumentoPrevColetaDados) ? "SIM" : "NÃO");
               AV51DadosGrupoVul = ((A82DocumentoDadosGrupoVul) ? "SIM" : "NÃO");
               AV52DadosCriancaAdolesc = ((A81DocumentoDadosCriancaAdolesc) ? "SIM" : "NÃO");
               /* Using cursor P006J3 */
               pr_default.execute(1, new Object[] {AV14DocumentoId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A63FonteRetencaoId = P006J3_A63FonteRetencaoId[0];
                  A75DocumentoId = P006J3_A75DocumentoId[0];
                  A64FonteRetencaoNome = P006J3_A64FonteRetencaoNome[0];
                  A64FonteRetencaoNome = P006J3_A64FonteRetencaoNome[0];
                  AV19FonteRetencao += (String.IsNullOrEmpty(StringUtil.RTrim( AV19FonteRetencao)) ? StringUtil.Upper( A64FonteRetencaoNome) : ", "+StringUtil.Upper( A64FonteRetencaoNome));
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19FonteRetencao)) )
               {
                  AV19FonteRetencao += ".";
               }
               /* Using cursor P006J4 */
               pr_default.execute(2, new Object[] {AV14DocumentoId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A60SetorInternoId = P006J4_A60SetorInternoId[0];
                  A75DocumentoId = P006J4_A75DocumentoId[0];
                  A61SetorInternoNome = P006J4_A61SetorInternoNome[0];
                  A61SetorInternoNome = P006J4_A61SetorInternoNome[0];
                  AV53SetorInterno += (String.IsNullOrEmpty(StringUtil.RTrim( AV53SetorInterno)) ? StringUtil.Upper( A61SetorInternoNome) : ", "+StringUtil.Upper( A61SetorInternoNome));
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53SetorInterno)) )
               {
                  AV53SetorInterno += ".";
               }
               /* Using cursor P006J5 */
               pr_default.execute(3, new Object[] {AV14DocumentoId});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A57CompartInternoId = P006J5_A57CompartInternoId[0];
                  A75DocumentoId = P006J5_A75DocumentoId[0];
                  A58CompartInternoNome = P006J5_A58CompartInternoNome[0];
                  A58CompartInternoNome = P006J5_A58CompartInternoNome[0];
                  AV54CompartInterno += (String.IsNullOrEmpty(StringUtil.RTrim( AV54CompartInterno)) ? StringUtil.Upper( A58CompartInternoNome) : ", "+StringUtil.Upper( A58CompartInternoNome));
                  pr_default.readNext(3);
               }
               pr_default.close(3);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54CompartInterno)) )
               {
                  AV54CompartInterno += ".";
               }
               /* Using cursor P006J6 */
               pr_default.execute(4, new Object[] {AV14DocumentoId});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A54EnvolvidosColetaId = P006J6_A54EnvolvidosColetaId[0];
                  A75DocumentoId = P006J6_A75DocumentoId[0];
                  A55EnvolvidosColetaNome = P006J6_A55EnvolvidosColetaNome[0];
                  A55EnvolvidosColetaNome = P006J6_A55EnvolvidosColetaNome[0];
                  AV55EnvolvidosColeta += (String.IsNullOrEmpty(StringUtil.RTrim( AV55EnvolvidosColeta)) ? StringUtil.Upper( A55EnvolvidosColetaNome) : ", "+StringUtil.Upper( A55EnvolvidosColetaNome));
                  pr_default.readNext(4);
               }
               pr_default.close(4);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55EnvolvidosColeta)) )
               {
                  AV55EnvolvidosColeta += ".";
               }
               /* Using cursor P006J7 */
               pr_default.execute(5, new Object[] {AV14DocumentoId});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A51MedidaSegurancaId = P006J7_A51MedidaSegurancaId[0];
                  A75DocumentoId = P006J7_A75DocumentoId[0];
                  A52MedidaSegurancaNome = P006J7_A52MedidaSegurancaNome[0];
                  A52MedidaSegurancaNome = P006J7_A52MedidaSegurancaNome[0];
                  AV56MedidaSeguranca += (String.IsNullOrEmpty(StringUtil.RTrim( AV56MedidaSeguranca)) ? StringUtil.Upper( A52MedidaSegurancaNome) : ", "+StringUtil.Upper( A52MedidaSegurancaNome));
                  pr_default.readNext(5);
               }
               pr_default.close(5);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56MedidaSeguranca)) )
               {
                  AV56MedidaSeguranca += ".";
               }
               H6J0( false, 32) ;
               getPrinter().GxDrawLine(25, Gx_line+17, 800, Gx_line+17, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+32);
               H6J0( false, 1001) ;
               getPrinter().GxAttris("Calibri", 18, true, false, true, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("TRATAMENTO", 42, Gx_line+17, 792, Gx_line+47, 1, 0, 0, 1) ;
               getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("FINALIDADE DO TRATAMENTO DE DADOS:", 42, Gx_line+67, 192, Gx_line+117, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("CATEGORIA:", 42, Gx_line+117, 192, Gx_line+167, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("TIPO:", 42, Gx_line+167, 192, Gx_line+217, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("FERRAMENTA DE COLETA DE DADOS:", 42, Gx_line+217, 192, Gx_line+267, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("ABRANGÊNCIA/ÁREA GEOGRÁFICA DO TRATAMENTO:", 42, Gx_line+267, 192, Gx_line+317, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("FREQUÊNCIA DE TRATAMENTO DE DADOS:", 42, Gx_line+383, 192, Gx_line+433, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("FONTE(S) DE RETENÇÃO / ARMAZENAMENTO:", 42, Gx_line+317, 192, Gx_line+384, 0+16, 0, 0, 1) ;
               getPrinter().GxAttris("Calibri", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13DocumentoFinalidadeTratamento, "")), 200, Gx_line+67, 792, Gx_line+117, 3+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10CategoriaNome, "")), 200, Gx_line+117, 792, Gx_line+167, 3+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25TipoDadoNome, "")), 200, Gx_line+167, 792, Gx_line+217, 3+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FerramentaColetaNome, "")), 200, Gx_line+217, 792, Gx_line+267, 3+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8AbrangenciaGeograficaNome, "")), 200, Gx_line+267, 792, Gx_line+317, 3+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FrequenciaTratamentoNome, "")), 200, Gx_line+383, 792, Gx_line+433, 3+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19FonteRetencao, "")), 200, Gx_line+317, 792, Gx_line+384, 0+16, 0, 0, 1) ;
               getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("TIPO DE DESCARTE:", 42, Gx_line+433, 192, Gx_line+483, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("TEMPO DE GUARDA/RETENÇÃO:", 42, Gx_line+483, 192, Gx_line+533, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("PREVISÃO PARA COLETA DE DADOS:", 42, Gx_line+533, 192, Gx_line+583, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("PREVISÃO LEGAL:", 42, Gx_line+583, 192, Gx_line+633, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("PREVISÃO REGULAMENTATÓRIA:", 42, Gx_line+633, 192, Gx_line+683, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("POSSUI DADOS DE GRUPOS VULNERÁVEIS:", 42, Gx_line+683, 192, Gx_line+733, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("POSSUI DADOS DE CRIANÇA/ADOLESCENTE:", 417, Gx_line+683, 567, Gx_line+733, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("SETOR(ES) INTERNO(S) ENVOLVIDO(S):", 42, Gx_line+733, 192, Gx_line+800, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("FORMA(S) DE COMPARTILHAMENTO INTERNO:", 42, Gx_line+800, 192, Gx_line+867, 0+16, 0, 0, 1) ;
               getPrinter().GxAttris("Calibri", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46TipoDescarte, "")), 200, Gx_line+433, 792, Gx_line+483, 3+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TempoRetencao, "")), 200, Gx_line+483, 792, Gx_line+533, 3+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48PrevColetaDados, "")), 200, Gx_line+533, 792, Gx_line+583, 3+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49BaseLegalNorm, "")), 200, Gx_line+583, 792, Gx_line+633, 3+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50BaseLegalNormIntExt, "")), 200, Gx_line+633, 792, Gx_line+683, 3+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51DadosGrupoVul, "")), 200, Gx_line+683, 408, Gx_line+733, 3+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52DadosCriancaAdolesc, "")), 575, Gx_line+683, 792, Gx_line+733, 3+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53SetorInterno, "")), 200, Gx_line+733, 792, Gx_line+800, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54CompartInterno, "")), 200, Gx_line+800, 792, Gx_line+867, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawLine(42, Gx_line+117, 792, Gx_line+117, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+167, 792, Gx_line+167, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+217, 792, Gx_line+217, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+267, 792, Gx_line+267, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+317, 792, Gx_line+317, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+383, 792, Gx_line+383, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+433, 792, Gx_line+433, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+483, 792, Gx_line+483, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+533, 792, Gx_line+533, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+583, 792, Gx_line+583, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+633, 792, Gx_line+633, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+683, 792, Gx_line+683, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+733, 792, Gx_line+733, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+733, 792, Gx_line+733, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+800, 792, Gx_line+800, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+867, 792, Gx_line+867, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+933, 792, Gx_line+933, 1, 192, 192, 192, 0) ;
               getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("ENVOLVIDO(S) NA COLETA:", 42, Gx_line+867, 192, Gx_line+934, 0+16, 0, 0, 1) ;
               getPrinter().GxAttris("Calibri", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55EnvolvidosColeta, "")), 200, Gx_line+867, 792, Gx_line+934, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawLine(42, Gx_line+533, 792, Gx_line+533, 1, 192, 192, 192, 0) ;
               getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("MEDIDA(S) DE SEGURANÇA:", 42, Gx_line+933, 192, Gx_line+1000, 0+16, 0, 0, 1) ;
               getPrinter().GxAttris("Calibri", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56MedidaSeguranca, "")), 200, Gx_line+933, 792, Gx_line+1000, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawLine(42, Gx_line+1000, 792, Gx_line+1000, 1, 192, 192, 192, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+1001);
               AV63Lenght = StringUtil.Len( A83DocumentoMedidaSegurancaDesc);
               AV64y = 1;
               AV66z = 1035;
               while ( AV63Lenght >= AV64y )
               {
                  if ( AV64y == 1 )
                  {
                     AV57DocumentoMedidaSegurancaDesc = A83DocumentoMedidaSegurancaDesc;
                     H6J0( false, 171) ;
                     getPrinter().GxAttris("Calibri", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(AV57DocumentoMedidaSegurancaDesc, 200, Gx_line+0, 792, Gx_line+171, 3+16, 0, 0, 0) ;
                     getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("DESCRIÇÃO DA MEDIDA DE SEGURANÇA:", 42, Gx_line+0, 192, Gx_line+171, 0+16, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+171);
                  }
                  else
                  {
                     AV57DocumentoMedidaSegurancaDesc = StringUtil.Substring( A83DocumentoMedidaSegurancaDesc, (int)(AV64y), (int)(AV66z));
                     H6J0( false, 171) ;
                     getPrinter().GxAttris("Calibri", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(AV57DocumentoMedidaSegurancaDesc, 200, Gx_line+0, 792, Gx_line+171, 3+16, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+171);
                  }
                  AV64y = (long)(AV64y+1035);
                  AV66z = (long)(AV66z+1035);
               }
               AV78TagHtmlColl = (GxSimpleCollection<string>)(GxRegex.Split(A84DocumentoFluxoTratDadosDesc,"</p>"));
               AV77PrimeiroBloco = true;
               AV92GXV1 = 1;
               while ( AV92GXV1 <= AV78TagHtmlColl.Count )
               {
                  AV79TagHtmlItem = ((string)AV78TagHtmlColl.Item(AV92GXV1));
                  if ( StringUtil.StringSearch( StringUtil.Trim( AV79TagHtmlItem), "base64", 1) > 0 )
                  {
                     if ( StringUtil.StringSearch( StringUtil.Trim( AV79TagHtmlItem), "image/jpeg", 1) > 0 )
                     {
                        AV79TagHtmlItem = StringUtil.StringReplace( AV79TagHtmlItem, "<p><img src=\"data:image/jpeg;base64,", "");
                     }
                     else if ( StringUtil.StringSearch( StringUtil.Trim( AV79TagHtmlItem), "image/png", 1) > 0 )
                     {
                        AV79TagHtmlItem = StringUtil.StringReplace( AV79TagHtmlItem, "<p><img src=\"data:image/png;base64,", "");
                     }
                     else if ( StringUtil.StringSearch( StringUtil.Trim( AV79TagHtmlItem), "image/jpg", 1) > 0 )
                     {
                        AV79TagHtmlItem = StringUtil.StringReplace( AV79TagHtmlItem, "<p><img src=\"data:image/jpg;base64,", "");
                     }
                     AV79TagHtmlItem = StringUtil.StringReplace( AV79TagHtmlItem, "\" />", "");
                     AV79TagHtmlItem = StringUtil.Trim( AV79TagHtmlItem);
                     AV71Blob=context.FileFromBase64( AV79TagHtmlItem) ;
                     AV76Image = AV71Blob;
                     AV93Image_GXI = GXDbFile.PathToUrl( AV71Blob);
                     AV80ImageHeight = (decimal)(GxImageUtil.GetImageHeight( AV76Image));
                     AV81ImageWidth = (decimal)(GxImageUtil.GetImageWidth( AV76Image));
                     AV82ImageRatio = (decimal)(GxImageUtil.GetImageWidth( AV76Image)/ (decimal)(GxImageUtil.GetImageHeight( AV76Image)));
                     if ( ( AV82ImageRatio == Convert.ToDecimal( 1 )) )
                     {
                        if ( ( AV80ImageHeight <= Convert.ToDecimal( 300 )) )
                        {
                           if ( AV77PrimeiroBloco )
                           {
                              H6J0( false, 300) ;
                              sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV76Image)) ? AV93Image_GXI : AV76Image);
                              getPrinter().GxDrawBitMap(sImgUrl, 200, Gx_line+0, 500, Gx_line+300) ;
                              getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText("DESCRIÇÃO DO FLUXO DE TRATAMENTO DOS DADOS:", 42, Gx_line+0, 192, Gx_line+171, 0+16, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+300);
                              AV77PrimeiroBloco = false;
                           }
                           else
                           {
                              H6J0( false, 300) ;
                              sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV76Image)) ? AV93Image_GXI : AV76Image);
                              getPrinter().GxDrawBitMap(sImgUrl, 200, Gx_line+0, 500, Gx_line+300) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+300);
                           }
                        }
                        else
                        {
                           if ( AV77PrimeiroBloco )
                           {
                              H6J0( false, 600) ;
                              sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV76Image)) ? AV93Image_GXI : AV76Image);
                              getPrinter().GxDrawBitMap(sImgUrl, 200, Gx_line+0, 800, Gx_line+600) ;
                              getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText("DESCRIÇÃO DO FLUXO DE TRATAMENTO DOS DADOS:", 42, Gx_line+0, 192, Gx_line+171, 0+16, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+600);
                              AV77PrimeiroBloco = false;
                           }
                           else
                           {
                              H6J0( false, 600) ;
                              sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV76Image)) ? AV93Image_GXI : AV76Image);
                              getPrinter().GxDrawBitMap(sImgUrl, 200, Gx_line+0, 800, Gx_line+600) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+600);
                           }
                        }
                     }
                     else if ( ( AV82ImageRatio > Convert.ToDecimal( 1 )) )
                     {
                        if ( ( AV80ImageHeight <= Convert.ToDecimal( 600 )) )
                        {
                           if ( AV77PrimeiroBloco )
                           {
                              H6J0( false, 300) ;
                              getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText("DESCRIÇÃO DO FLUXO DE TRATAMENTO DOS DADOS:", 42, Gx_line+0, 192, Gx_line+171, 0+16, 0, 0, 0) ;
                              sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV76Image)) ? AV93Image_GXI : AV76Image);
                              getPrinter().GxDrawBitMap(sImgUrl, 200, Gx_line+0, 800, Gx_line+300) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+300);
                              AV77PrimeiroBloco = false;
                           }
                           else
                           {
                              H6J0( false, 300) ;
                              sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV76Image)) ? AV93Image_GXI : AV76Image);
                              getPrinter().GxDrawBitMap(sImgUrl, 200, Gx_line+0, 800, Gx_line+300) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+300);
                           }
                        }
                        else
                        {
                           if ( AV77PrimeiroBloco )
                           {
                              H6J0( false, 400) ;
                              sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV76Image)) ? AV93Image_GXI : AV76Image);
                              getPrinter().GxDrawBitMap(sImgUrl, 200, Gx_line+0, 1000, Gx_line+400) ;
                              getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText("DESCRIÇÃO DO FLUXO DE TRATAMENTO DOS DADOS:", 42, Gx_line+0, 192, Gx_line+171, 0+16, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+400);
                              AV77PrimeiroBloco = false;
                           }
                           else
                           {
                              H6J0( false, 400) ;
                              sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV76Image)) ? AV93Image_GXI : AV76Image);
                              getPrinter().GxDrawBitMap(sImgUrl, 200, Gx_line+0, 1000, Gx_line+400) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+400);
                           }
                        }
                     }
                     else if ( ( AV82ImageRatio < Convert.ToDecimal( 1 )) )
                     {
                        if ( ( AV80ImageHeight <= Convert.ToDecimal( 410 )) )
                        {
                           if ( AV77PrimeiroBloco )
                           {
                              H6J0( false, 410) ;
                              sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV76Image)) ? AV93Image_GXI : AV76Image);
                              getPrinter().GxDrawBitMap(sImgUrl, 200, Gx_line+0, 430, Gx_line+410) ;
                              getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText("DESCRIÇÃO DO FLUXO DE TRATAMENTO DOS DADOS:", 42, Gx_line+0, 192, Gx_line+171, 0+16, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+410);
                              AV77PrimeiroBloco = false;
                           }
                           else
                           {
                              H6J0( false, 410) ;
                              sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV76Image)) ? AV93Image_GXI : AV76Image);
                              getPrinter().GxDrawBitMap(sImgUrl, 200, Gx_line+0, 430, Gx_line+410) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+410);
                           }
                        }
                        else
                        {
                           if ( AV77PrimeiroBloco )
                           {
                              H6J0( false, 820) ;
                              getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText("DESCRIÇÃO DO FLUXO DE TRATAMENTO DOS DADOS:", 42, Gx_line+0, 192, Gx_line+171, 0+16, 0, 0, 0) ;
                              sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV76Image)) ? AV93Image_GXI : AV76Image);
                              getPrinter().GxDrawBitMap(sImgUrl, 200, Gx_line+0, 661, Gx_line+820) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+820);
                              AV77PrimeiroBloco = false;
                           }
                           else
                           {
                              H6J0( false, 820) ;
                              sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV76Image)) ? AV93Image_GXI : AV76Image);
                              getPrinter().GxDrawBitMap(sImgUrl, 200, Gx_line+0, 661, Gx_line+820) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+820);
                           }
                        }
                     }
                  }
                  else
                  {
                     AV79TagHtmlItem = StringUtil.StringReplace( AV79TagHtmlItem, "<p>", "");
                     AV74DocumentoFluxoTratDadosDescAux = StringUtil.Trim( AV79TagHtmlItem);
                     AV63Lenght = StringUtil.Len( StringUtil.Trim( AV74DocumentoFluxoTratDadosDescAux));
                     AV64y = 1;
                     AV66z = 513;
                     AV70Boolean = true;
                     while ( AV63Lenght >= AV64y )
                     {
                        AV60DocumentoFluxoTratDadosDesc = StringUtil.Substring( AV74DocumentoFluxoTratDadosDescAux, (int)(AV64y), (int)(AV66z));
                        if ( AV77PrimeiroBloco )
                        {
                           H6J0( false, 171) ;
                           getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText("DESCRIÇÃO DO FLUXO DE TRATAMENTO DOS DADOS:", 42, Gx_line+0, 192, Gx_line+171, 0+16, 0, 0, 0) ;
                           getPrinter().GxAttris("Calibri", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60DocumentoFluxoTratDadosDesc, "")), 200, Gx_line+0, 792, Gx_line+171, 3+16, 1, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+171);
                           AV77PrimeiroBloco = false;
                        }
                        else
                        {
                           H6J0( false, 171) ;
                           getPrinter().GxAttris("Calibri", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60DocumentoFluxoTratDadosDesc, "")), 200, Gx_line+0, 792, Gx_line+171, 3+16, 1, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+171);
                        }
                        AV64y = (long)(AV64y+513);
                        AV66z = (long)(AV66z+513);
                     }
                  }
                  AV76Image = "";
                  AV93Image_GXI = "";
                  AV71Blob = "";
                  AV92GXV1 = (int)(AV92GXV1+1);
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( AV86GXLvl19 == 0 )
            {
               H6J0( false, 56) ;
               getPrinter().GxAttris("Calibri", 14, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("SEM RESULTADOS ENCONTRADOS", 25, Gx_line+17, 800, Gx_line+41, 1, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+56);
            }
            H6J0( false, 32) ;
            getPrinter().GxDrawLine(25, Gx_line+17, 800, Gx_line+17, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+32);
            H6J0( false, 50) ;
            getPrinter().GxAttris("Calibri", 18, true, false, true, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("DICIONÁRIO", 42, Gx_line+17, 817, Gx_line+47, 1, 0, 0, 1) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+50);
            AV94GXLvl267 = 0;
            /* Using cursor P006J8 */
            pr_default.execute(6, new Object[] {AV14DocumentoId});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A69InformacaoId = P006J8_A69InformacaoId[0];
               A72HipoteseTratamentoId = P006J8_A72HipoteseTratamentoId[0];
               A98DocDicionarioId = P006J8_A98DocDicionarioId[0];
               A75DocumentoId = P006J8_A75DocumentoId[0];
               A70InformacaoNome = P006J8_A70InformacaoNome[0];
               A100DocDicionarioPodeEliminar = P006J8_A100DocDicionarioPodeEliminar[0];
               A99DocDicionarioSensivel = P006J8_A99DocDicionarioSensivel[0];
               A73HipoteseTratamentoNome = P006J8_A73HipoteseTratamentoNome[0];
               A119DocDicionarioTipoTransfInterGa = P006J8_A119DocDicionarioTipoTransfInterGa[0];
               A101DocDicionarioTransfInter = P006J8_A101DocDicionarioTransfInter[0];
               A102DocDicionarioFinalidade = P006J8_A102DocDicionarioFinalidade[0];
               A70InformacaoNome = P006J8_A70InformacaoNome[0];
               A73HipoteseTratamentoNome = P006J8_A73HipoteseTratamentoNome[0];
               AV94GXLvl267 = 1;
               AV39DicionarioQTD.Add(A98DocDicionarioId, 0);
               if ( AV39DicionarioQTD.Count > 1 )
               {
                  H6J0( false, 32) ;
                  getPrinter().GxDrawLine(25, Gx_line+17, 800, Gx_line+17, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+32);
               }
               AV26InformacaoNome = StringUtil.Upper( A70InformacaoNome);
               AV27DocDicioPodeEliminar = ((A100DocDicionarioPodeEliminar) ? "SIM" : "NÃO");
               AV28DocDicioDadosSensiveis = ((A99DocDicionarioSensivel) ? "SIM" : "NÃO");
               AV29HipoteseTratamentoNome = StringUtil.Upper( A73HipoteseTratamentoNome);
               AV59DocDicionarioTipoTransfInterGarantia = A119DocDicionarioTipoTransfInterGa;
               AV67DocDicionarioTransfInter = ((A101DocDicionarioTransfInter) ? "SIM" : "NÃO");
               AV30CompartTercExt = "";
               /* Using cursor P006J9 */
               pr_default.execute(7, new Object[] {A98DocDicionarioId, A75DocumentoId, AV14DocumentoId});
               while ( (pr_default.getStatus(7) != 101) )
               {
                  A66CompartTercExternoId = P006J9_A66CompartTercExternoId[0];
                  A67CompartTercExternoNome = P006J9_A67CompartTercExternoNome[0];
                  A67CompartTercExternoNome = P006J9_A67CompartTercExternoNome[0];
                  AV30CompartTercExt += (String.IsNullOrEmpty(StringUtil.RTrim( AV30CompartTercExt)) ? StringUtil.Upper( A67CompartTercExternoNome) : ", "+StringUtil.Upper( A67CompartTercExternoNome));
                  pr_default.readNext(7);
               }
               pr_default.close(7);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30CompartTercExt)) )
               {
                  AV30CompartTercExt += ".";
               }
               H6J0( false, 219) ;
               getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("INFORMAÇÃO:", 50, Gx_line+17, 200, Gx_line+67, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("PODE SER ELIMINADO?", 50, Gx_line+67, 200, Gx_line+117, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("POSSUI DADOS SENSÍVEIS?", 400, Gx_line+67, 558, Gx_line+117, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText("HIPÓTESE DE TRATAMENTO", 50, Gx_line+117, 200, Gx_line+167, 0+16, 0, 0, 1) ;
               getPrinter().GxAttris("Calibri", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26InformacaoNome, "")), 208, Gx_line+17, 800, Gx_line+67, 3+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27DocDicioPodeEliminar, "")), 208, Gx_line+67, 391, Gx_line+117, 3+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28DocDicioDadosSensiveis, "")), 567, Gx_line+67, 800, Gx_line+117, 3+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29HipoteseTratamentoNome, "")), 208, Gx_line+117, 800, Gx_line+167, 3+16, 0, 0, 1) ;
               getPrinter().GxDrawLine(50, Gx_line+67, 800, Gx_line+67, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(50, Gx_line+117, 800, Gx_line+117, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(50, Gx_line+167, 800, Gx_line+167, 1, 192, 192, 192, 0) ;
               getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("TRANSFERÊNCIA INTERNACIONAL:", 50, Gx_line+167, 200, Gx_line+217, 0+16, 0, 0, 1) ;
               getPrinter().GxAttris("Calibri", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67DocDicionarioTransfInter, "")), 208, Gx_line+167, 800, Gx_line+217, 3+16, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+219);
               if ( A101DocDicionarioTransfInter )
               {
                  /* Using cursor P006J10 */
                  pr_default.execute(8, new Object[] {A98DocDicionarioId, A75DocumentoId, AV14DocumentoId});
                  while ( (pr_default.getStatus(8) != 101) )
                  {
                     A4PaisId = P006J10_A4PaisId[0];
                     A5PaisNome = P006J10_A5PaisNome[0];
                     A5PaisNome = P006J10_A5PaisNome[0];
                     AV68Paises += (String.IsNullOrEmpty(StringUtil.RTrim( AV68Paises)) ? StringUtil.Upper( A5PaisNome) : ", "+StringUtil.Upper( A5PaisNome));
                     pr_default.readNext(8);
                  }
                  pr_default.close(8);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Paises)) )
                  {
                     AV68Paises += ".";
                  }
                  H6J0( false, 84) ;
                  getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("PAÍS(ES)", 50, Gx_line+0, 200, Gx_line+83, 0+16, 0, 0, 1) ;
                  getPrinter().GxAttris("Calibri", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68Paises, "")), 208, Gx_line+0, 800, Gx_line+83, 3+16, 0, 0, 1) ;
                  getPrinter().GxDrawLine(50, Gx_line+0, 800, Gx_line+0, 1, 192, 192, 192, 0) ;
                  getPrinter().GxDrawLine(50, Gx_line+83, 800, Gx_line+83, 1, 192, 192, 192, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+84);
                  AV63Lenght = StringUtil.Len( A119DocDicionarioTipoTransfInterGa);
                  AV64y = 1;
                  AV66z = 1035;
                  while ( AV63Lenght >= AV64y )
                  {
                     if ( AV64y == 1 )
                     {
                        AV59DocDicionarioTipoTransfInterGarantia = StringUtil.Substring( A119DocDicionarioTipoTransfInterGa, (int)(AV64y), (int)(AV66z));
                        H6J0( false, 171) ;
                        getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText("TIPO GARANTIA PARA TRANSFERÊNCIA INTERNACIONAL", 50, Gx_line+0, 200, Gx_line+171, 0+16, 0, 0, 0) ;
                        getPrinter().GxAttris("Calibri", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(AV59DocDicionarioTipoTransfInterGarantia, 208, Gx_line+0, 800, Gx_line+171, 3+16, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+171);
                     }
                     else
                     {
                        AV59DocDicionarioTipoTransfInterGarantia = StringUtil.Substring( A119DocDicionarioTipoTransfInterGa, (int)(AV64y), (int)(AV66z));
                        H6J0( false, 171) ;
                        getPrinter().GxAttris("Calibri", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(AV59DocDicionarioTipoTransfInterGarantia, 208, Gx_line+0, 800, Gx_line+171, 3+16, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+171);
                     }
                     AV64y = (long)(AV64y+1035);
                     AV66z = (long)(AV66z+1035);
                  }
               }
               H6J0( false, 85) ;
               getPrinter().GxAttris("Calibri", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30CompartTercExt, "")), 208, Gx_line+0, 800, Gx_line+83, 3+16, 0, 0, 1) ;
               getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("COMPARTILHAMENTO COM TERCEIROS/EXTERNOS", 50, Gx_line+0, 200, Gx_line+83, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawLine(50, Gx_line+0, 800, Gx_line+0, 1, 192, 192, 192, 0) ;
               getPrinter().GxDrawLine(50, Gx_line+83, 800, Gx_line+83, 1, 192, 192, 192, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+85);
               AV63Lenght = StringUtil.Len( A102DocDicionarioFinalidade);
               AV64y = 1;
               AV66z = 1035;
               while ( AV63Lenght >= AV64y )
               {
                  if ( AV64y == 1 )
                  {
                     AV61DocDicionarioFinalidade = StringUtil.Substring( A102DocDicionarioFinalidade, (int)(AV64y), (int)(AV66z));
                     H6J0( false, 171) ;
                     getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("FINALIDADE DO COMPARTILHAMENTO COM EXTERNOS", 50, Gx_line+0, 200, Gx_line+171, 0+16, 0, 0, 0) ;
                     getPrinter().GxAttris("Calibri", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(AV61DocDicionarioFinalidade, 208, Gx_line+0, 800, Gx_line+171, 3+16, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+171);
                  }
                  else
                  {
                     AV61DocDicionarioFinalidade = StringUtil.Substring( A102DocDicionarioFinalidade, (int)(AV64y), (int)(AV66z));
                     H6J0( false, 171) ;
                     getPrinter().GxAttris("Calibri", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(AV61DocDicionarioFinalidade, 208, Gx_line+0, 800, Gx_line+171, 3+16, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+171);
                  }
                  AV64y = (long)(AV64y+1035);
                  AV66z = (long)(AV66z+1035);
               }
               pr_default.readNext(6);
            }
            pr_default.close(6);
            if ( AV94GXLvl267 == 0 )
            {
               H6J0( false, 56) ;
               getPrinter().GxAttris("Calibri", 14, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("SEM RESULTADOS ENCONTRADOS", 25, Gx_line+17, 800, Gx_line+41, 1, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+56);
            }
            H6J0( false, 32) ;
            getPrinter().GxDrawLine(25, Gx_line+17, 800, Gx_line+17, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+32);
            H6J0( false, 49) ;
            getPrinter().GxAttris("Calibri", 18, true, false, true, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("OPERADORES", 42, Gx_line+17, 817, Gx_line+47, 1, 0, 0, 1) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+49);
            AV97GXLvl358 = 0;
            /* Using cursor P006J11 */
            pr_default.execute(9, new Object[] {AV14DocumentoId});
            while ( (pr_default.getStatus(9) != 101) )
            {
               A42OperadorId = P006J11_A42OperadorId[0];
               A75DocumentoId = P006J11_A75DocumentoId[0];
               A43OperadorNome = P006J11_A43OperadorNome[0];
               A87DocOperadorColeta = P006J11_A87DocOperadorColeta[0];
               A88DocOperadorRetencao = P006J11_A88DocOperadorRetencao[0];
               A89DocOperadorCompartilhamento = P006J11_A89DocOperadorCompartilhamento[0];
               A90DocOperadorEliminacao = P006J11_A90DocOperadorEliminacao[0];
               A91DocOperadorProcessamento = P006J11_A91DocOperadorProcessamento[0];
               A86DocOperadorId = P006J11_A86DocOperadorId[0];
               A43OperadorNome = P006J11_A43OperadorNome[0];
               AV97GXLvl358 = 1;
               AV41OperadorQTD.Add(A98DocDicionarioId, 0);
               AV31OperadorNome = StringUtil.Upper( A43OperadorNome);
               AV32OperadorColeta = ((A87DocOperadorColeta) ? "SIM" : "NÃO");
               AV33OperadorRetencao = ((A88DocOperadorRetencao) ? "SIM" : "NÃO");
               AV34OperadorCompartilhamento = ((A89DocOperadorCompartilhamento) ? "SIM" : "NÃO");
               AV35OperadorEliminacao = ((A90DocOperadorEliminacao) ? "SIM" : "NÃO");
               AV36OperadorProcessamento = ((A91DocOperadorProcessamento) ? "SIM" : "NÃO");
               H6J0( false, 135) ;
               getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("NOME:", 50, Gx_line+17, 200, Gx_line+50, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("COLETA", 117, Gx_line+67, 244, Gx_line+100, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("RETENÇÃO", 242, Gx_line+67, 369, Gx_line+100, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("COMPARTILHAMENTO", 367, Gx_line+67, 494, Gx_line+100, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("ELIMINAÇÃO", 492, Gx_line+67, 619, Gx_line+100, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("PROCESSAMENTO", 617, Gx_line+67, 744, Gx_line+100, 1, 0, 0, 1) ;
               getPrinter().GxAttris("Calibri", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31OperadorNome, "")), 200, Gx_line+17, 800, Gx_line+50, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32OperadorColeta, "")), 117, Gx_line+100, 242, Gx_line+133, 1+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33OperadorRetencao, "")), 242, Gx_line+100, 367, Gx_line+133, 1+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34OperadorCompartilhamento, "")), 367, Gx_line+100, 492, Gx_line+133, 1+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35OperadorEliminacao, "")), 492, Gx_line+100, 617, Gx_line+133, 1+16, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36OperadorProcessamento, "")), 617, Gx_line+100, 742, Gx_line+133, 1+16, 0, 0, 1) ;
               getPrinter().GxDrawLine(42, Gx_line+133, 792, Gx_line+133, 1, 192, 192, 192, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+135);
               pr_default.readNext(9);
            }
            pr_default.close(9);
            if ( AV97GXLvl358 == 0 )
            {
               H6J0( false, 56) ;
               getPrinter().GxAttris("Calibri", 14, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("SEM RESULTADOS ENCONTRADOS", 25, Gx_line+17, 800, Gx_line+41, 1, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+56);
            }
            H6J0( false, 32) ;
            getPrinter().GxDrawLine(25, Gx_line+17, 800, Gx_line+17, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+32);
            H6J0( false, 49) ;
            getPrinter().GxAttris("Calibri", 18, true, false, true, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("REVISÕES", 25, Gx_line+17, 800, Gx_line+47, 1, 0, 0, 1) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+49);
            AV98GXLvl379 = 0;
            /* Using cursor P006J12 */
            pr_default.execute(10, new Object[] {AV14DocumentoId});
            while ( (pr_default.getStatus(10) != 101) )
            {
               A75DocumentoId = P006J12_A75DocumentoId[0];
               A123RevisaoLogDataAlteracao = P006J12_A123RevisaoLogDataAlteracao[0];
               A121RevisaoLogUsuarioAlteracao = P006J12_A121RevisaoLogUsuarioAlteracao[0];
               A122RevisaoLogObservacao = P006J12_A122RevisaoLogObservacao[0];
               A120RevisaoLogId = P006J12_A120RevisaoLogId[0];
               AV98GXLvl379 = 1;
               H6J0( false, 50) ;
               getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("DATA/HORA:", 592, Gx_line+17, 675, Gx_line+50, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("USUÁRIO:", 50, Gx_line+17, 200, Gx_line+50, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Calibri", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A121RevisaoLogUsuarioAlteracao, "")), 208, Gx_line+17, 591, Gx_line+50, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawText(context.localUtil.Format( A123RevisaoLogDataAlteracao, "99/99/99 99:99"), 675, Gx_line+17, 800, Gx_line+50, 0+16, 0, 0, 1) ;
               getPrinter().GxDrawLine(50, Gx_line+17, 800, Gx_line+17, 1, 192, 192, 192, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+50);
               AV63Lenght = StringUtil.Len( A122RevisaoLogObservacao);
               AV64y = 1;
               AV66z = 1035;
               while ( AV63Lenght >= AV64y )
               {
                  if ( AV64y == 1 )
                  {
                     AV69RevisaoLogObservacao = StringUtil.Substring( A122RevisaoLogObservacao, (int)(AV64y), (int)(AV66z));
                     H6J0( false, 171) ;
                     getPrinter().GxAttris("Calibri", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("OBSERVAÇÃO:", 50, Gx_line+0, 200, Gx_line+167, 0, 0, 0, 1) ;
                     getPrinter().GxAttris("Calibri", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(AV69RevisaoLogObservacao, 208, Gx_line+0, 800, Gx_line+171, 0+16, 0, 0, 1) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+171);
                  }
                  else
                  {
                     AV69RevisaoLogObservacao = StringUtil.Substring( A122RevisaoLogObservacao, (int)(AV64y), (int)(AV66z));
                     H6J0( false, 171) ;
                     getPrinter().GxAttris("Calibri", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(AV69RevisaoLogObservacao, 208, Gx_line+0, 800, Gx_line+171, 0+16, 0, 0, 1) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+171);
                  }
                  AV64y = (long)(AV64y+1035);
                  AV66z = (long)(AV66z+1035);
               }
               pr_default.readNext(10);
            }
            pr_default.close(10);
            if ( AV98GXLvl379 == 0 )
            {
               H6J0( false, 56) ;
               getPrinter().GxAttris("Calibri", 14, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("SEM RESULTADOS ENCONTRADOS", 25, Gx_line+17, 800, Gx_line+41, 1, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+56);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H6J0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H6J0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  AV23RodapeInfo = StringUtil.Str( (decimal)(DateTimeUtil.Day( Gx_date)), 10, 0) + " de " + DateTimeUtil.CMonth( Gx_date, "por") + " de " + StringUtil.LTrim( StringUtil.Str( (decimal)(DateTimeUtil.Year( Gx_date)), 10, 0));
                  AV37RodapePagina = (short)(AV37RodapePagina+1);
                  getPrinter().GxAttris("Arial", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23RodapeInfo, "")), 308, Gx_line+0, 517, Gx_line+16, 1+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV37RodapePagina), "ZZZ9")), 717, Gx_line+17, 743, Gx_line+33, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+47);
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if ( AV37RodapePagina > 0 )
               {
                  getPrinter().GxAttris("Arial", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("RELATÓRIO DE IMPACTO À PROTEÇÃO DE DADOS PESSOAIS - RIPD", 233, Gx_line+17, 597, Gx_line+32, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+45);
               }
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
         add_metrics2( ) ;
         add_metrics3( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Arial", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Calibri", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics2( )
      {
         getPrinter().setMetrics("Calibri", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics3( )
      {
         getPrinter().setMetrics("Arial", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
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
         GXKey = "";
         GXDecQS = "";
         gxfirstwebparm = "";
         AV39DicionarioQTD = new GxSimpleCollection<short>();
         AV41OperadorQTD = new GxSimpleCollection<short>();
         AV18FileName = "";
         scmdbuf = "";
         P006J2_A20SubprocessoId = new int[1] ;
         P006J2_n20SubprocessoId = new bool[] {false} ;
         P006J2_A16ProcessoId = new int[1] ;
         P006J2_n16ProcessoId = new bool[] {false} ;
         P006J2_A7EncarregadoId = new int[1] ;
         P006J2_n7EncarregadoId = new bool[] {false} ;
         P006J2_A13PersonaId = new int[1] ;
         P006J2_n13PersonaId = new bool[] {false} ;
         P006J2_A27CategoriaId = new int[1] ;
         P006J2_n27CategoriaId = new bool[] {false} ;
         P006J2_A30TipoDadoId = new int[1] ;
         P006J2_n30TipoDadoId = new bool[] {false} ;
         P006J2_A33FerramentaColetaId = new int[1] ;
         P006J2_n33FerramentaColetaId = new bool[] {false} ;
         P006J2_A36AbrangenciaGeograficaId = new int[1] ;
         P006J2_n36AbrangenciaGeograficaId = new bool[] {false} ;
         P006J2_A39FrequenciaTratamentoId = new int[1] ;
         P006J2_n39FrequenciaTratamentoId = new bool[] {false} ;
         P006J2_A45TipoDescarteId = new int[1] ;
         P006J2_n45TipoDescarteId = new bool[] {false} ;
         P006J2_A48TempoRetencaoId = new int[1] ;
         P006J2_n48TempoRetencaoId = new bool[] {false} ;
         P006J2_A24AreaResponsavelId = new int[1] ;
         P006J2_n24AreaResponsavelId = new bool[] {false} ;
         P006J2_A110DocumentoControladorId = new int[1] ;
         P006J2_n110DocumentoControladorId = new bool[] {false} ;
         P006J2_A75DocumentoId = new int[1] ;
         P006J2_A76DocumentoNome = new string[] {""} ;
         P006J2_n76DocumentoNome = new bool[] {false} ;
         P006J2_A17ProcessoNome = new string[] {""} ;
         P006J2_A21SubprocessoNome = new string[] {""} ;
         P006J2_A25AreaResponsavelNome = new string[] {""} ;
         P006J2_A11ControladorNome = new string[] {""} ;
         P006J2_n11ControladorNome = new bool[] {false} ;
         P006J2_A14PersonaNome = new string[] {""} ;
         P006J2_A8EncarregadoNome = new string[] {""} ;
         P006J2_A108DocumentoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         P006J2_n108DocumentoDataInclusao = new bool[] {false} ;
         P006J2_A141DocumentoUsuarioInclusao = new string[] {""} ;
         P006J2_n141DocumentoUsuarioInclusao = new bool[] {false} ;
         P006J2_A109DocumentoDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         P006J2_n109DocumentoDataAlteracao = new bool[] {false} ;
         P006J2_A142DocumentoUsuarioAlteracao = new string[] {""} ;
         P006J2_n142DocumentoUsuarioAlteracao = new bool[] {false} ;
         P006J2_A77DocumentoFinalidadeTratamento = new string[] {""} ;
         P006J2_n77DocumentoFinalidadeTratamento = new bool[] {false} ;
         P006J2_A28CategoriaNome = new string[] {""} ;
         P006J2_A31TipoDadoNome = new string[] {""} ;
         P006J2_A34FerramentaColetaNome = new string[] {""} ;
         P006J2_A37AbrangenciaGeograficaNome = new string[] {""} ;
         P006J2_A40FrequenciaTratamentoNome = new string[] {""} ;
         P006J2_A46TipoDescarteNome = new string[] {""} ;
         P006J2_A49TempoRetencaoNome = new string[] {""} ;
         P006J2_A79DocumentoBaseLegalNorm = new string[] {""} ;
         P006J2_n79DocumentoBaseLegalNorm = new bool[] {false} ;
         P006J2_A80DocumentoBaseLegalNormIntExt = new string[] {""} ;
         P006J2_n80DocumentoBaseLegalNormIntExt = new bool[] {false} ;
         P006J2_A78DocumentoPrevColetaDados = new bool[] {false} ;
         P006J2_n78DocumentoPrevColetaDados = new bool[] {false} ;
         P006J2_A82DocumentoDadosGrupoVul = new bool[] {false} ;
         P006J2_n82DocumentoDadosGrupoVul = new bool[] {false} ;
         P006J2_A81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         P006J2_n81DocumentoDadosCriancaAdolesc = new bool[] {false} ;
         P006J2_A83DocumentoMedidaSegurancaDesc = new string[] {""} ;
         P006J2_n83DocumentoMedidaSegurancaDesc = new bool[] {false} ;
         P006J2_A84DocumentoFluxoTratDadosDesc = new string[] {""} ;
         P006J2_n84DocumentoFluxoTratDadosDesc = new bool[] {false} ;
         A76DocumentoNome = "";
         A17ProcessoNome = "";
         A21SubprocessoNome = "";
         A25AreaResponsavelNome = "";
         A11ControladorNome = "";
         A14PersonaNome = "";
         A8EncarregadoNome = "";
         A108DocumentoDataInclusao = (DateTime)(DateTime.MinValue);
         A141DocumentoUsuarioInclusao = "";
         A109DocumentoDataAlteracao = (DateTime)(DateTime.MinValue);
         A142DocumentoUsuarioAlteracao = "";
         A77DocumentoFinalidadeTratamento = "";
         A28CategoriaNome = "";
         A31TipoDadoNome = "";
         A34FerramentaColetaNome = "";
         A37AbrangenciaGeograficaNome = "";
         A40FrequenciaTratamentoNome = "";
         A46TipoDescarteNome = "";
         A49TempoRetencaoNome = "";
         A79DocumentoBaseLegalNorm = "";
         A80DocumentoBaseLegalNormIntExt = "";
         A83DocumentoMedidaSegurancaDesc = "";
         A84DocumentoFluxoTratDadosDesc = "";
         AV15DocumentoNome = "";
         AV22ProcessoNome = "";
         AV24SubProcessoNome = "";
         AV9AreaResponsavelNome = "";
         AV11ControladorNome = "";
         AV21PersonaNome = "";
         AV16EncarregadoNome = "";
         AV44DocumentoDataInclusao = (DateTime)(DateTime.MinValue);
         AV42DocumentoUsuarioInclusao = "";
         AV45DocumentoDataAlteracao = (DateTime)(DateTime.MinValue);
         AV43DocumentoUsuarioAlteracao = "";
         AV13DocumentoFinalidadeTratamento = "";
         AV10CategoriaNome = "";
         AV25TipoDadoNome = "";
         AV17FerramentaColetaNome = "";
         AV8AbrangenciaGeograficaNome = "";
         AV20FrequenciaTratamentoNome = "";
         AV46TipoDescarte = "";
         AV47TempoRetencao = "";
         AV49BaseLegalNorm = "";
         AV50BaseLegalNormIntExt = "";
         AV48PrevColetaDados = "";
         AV51DadosGrupoVul = "";
         AV52DadosCriancaAdolesc = "";
         P006J3_A63FonteRetencaoId = new int[1] ;
         P006J3_A75DocumentoId = new int[1] ;
         P006J3_A64FonteRetencaoNome = new string[] {""} ;
         A64FonteRetencaoNome = "";
         AV19FonteRetencao = "";
         P006J4_A60SetorInternoId = new int[1] ;
         P006J4_A75DocumentoId = new int[1] ;
         P006J4_A61SetorInternoNome = new string[] {""} ;
         A61SetorInternoNome = "";
         AV53SetorInterno = "";
         P006J5_A57CompartInternoId = new int[1] ;
         P006J5_A75DocumentoId = new int[1] ;
         P006J5_A58CompartInternoNome = new string[] {""} ;
         A58CompartInternoNome = "";
         AV54CompartInterno = "";
         P006J6_A54EnvolvidosColetaId = new int[1] ;
         P006J6_A75DocumentoId = new int[1] ;
         P006J6_A55EnvolvidosColetaNome = new string[] {""} ;
         A55EnvolvidosColetaNome = "";
         AV55EnvolvidosColeta = "";
         P006J7_A51MedidaSegurancaId = new int[1] ;
         P006J7_A75DocumentoId = new int[1] ;
         P006J7_A52MedidaSegurancaNome = new string[] {""} ;
         A52MedidaSegurancaNome = "";
         AV56MedidaSeguranca = "";
         AV57DocumentoMedidaSegurancaDesc = "";
         AV78TagHtmlColl = new GxSimpleCollection<string>();
         AV79TagHtmlItem = "";
         AV71Blob = "";
         AV76Image = "";
         AV93Image_GXI = "";
         AV76Image = "";
         sImgUrl = "";
         AV74DocumentoFluxoTratDadosDescAux = "";
         AV60DocumentoFluxoTratDadosDesc = "";
         P006J8_A69InformacaoId = new int[1] ;
         P006J8_A72HipoteseTratamentoId = new int[1] ;
         P006J8_A98DocDicionarioId = new int[1] ;
         P006J8_A75DocumentoId = new int[1] ;
         P006J8_A70InformacaoNome = new string[] {""} ;
         P006J8_A100DocDicionarioPodeEliminar = new bool[] {false} ;
         P006J8_A99DocDicionarioSensivel = new bool[] {false} ;
         P006J8_A73HipoteseTratamentoNome = new string[] {""} ;
         P006J8_A119DocDicionarioTipoTransfInterGa = new string[] {""} ;
         P006J8_A101DocDicionarioTransfInter = new bool[] {false} ;
         P006J8_A102DocDicionarioFinalidade = new string[] {""} ;
         A70InformacaoNome = "";
         A73HipoteseTratamentoNome = "";
         A119DocDicionarioTipoTransfInterGa = "";
         A102DocDicionarioFinalidade = "";
         AV26InformacaoNome = "";
         AV27DocDicioPodeEliminar = "";
         AV28DocDicioDadosSensiveis = "";
         AV29HipoteseTratamentoNome = "";
         AV59DocDicionarioTipoTransfInterGarantia = "";
         AV67DocDicionarioTransfInter = "";
         AV30CompartTercExt = "";
         P006J9_A66CompartTercExternoId = new int[1] ;
         P006J9_A98DocDicionarioId = new int[1] ;
         P006J9_A67CompartTercExternoNome = new string[] {""} ;
         A67CompartTercExternoNome = "";
         P006J10_A4PaisId = new int[1] ;
         P006J10_A98DocDicionarioId = new int[1] ;
         P006J10_A5PaisNome = new string[] {""} ;
         A5PaisNome = "";
         AV68Paises = "";
         AV61DocDicionarioFinalidade = "";
         P006J11_A42OperadorId = new int[1] ;
         P006J11_A75DocumentoId = new int[1] ;
         P006J11_A43OperadorNome = new string[] {""} ;
         P006J11_A87DocOperadorColeta = new bool[] {false} ;
         P006J11_A88DocOperadorRetencao = new bool[] {false} ;
         P006J11_A89DocOperadorCompartilhamento = new bool[] {false} ;
         P006J11_A90DocOperadorEliminacao = new bool[] {false} ;
         P006J11_A91DocOperadorProcessamento = new bool[] {false} ;
         P006J11_A86DocOperadorId = new int[1] ;
         A43OperadorNome = "";
         AV31OperadorNome = "";
         AV32OperadorColeta = "";
         AV33OperadorRetencao = "";
         AV34OperadorCompartilhamento = "";
         AV35OperadorEliminacao = "";
         AV36OperadorProcessamento = "";
         P006J12_A75DocumentoId = new int[1] ;
         P006J12_A123RevisaoLogDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         P006J12_A121RevisaoLogUsuarioAlteracao = new string[] {""} ;
         P006J12_A122RevisaoLogObservacao = new string[] {""} ;
         P006J12_A120RevisaoLogId = new int[1] ;
         A123RevisaoLogDataAlteracao = (DateTime)(DateTime.MinValue);
         A121RevisaoLogUsuarioAlteracao = "";
         A122RevisaoLogObservacao = "";
         AV69RevisaoLogObservacao = "";
         AV23RodapeInfo = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.adocumentorelatoriopdf__default(),
            new Object[][] {
                new Object[] {
               P006J2_A20SubprocessoId, P006J2_n20SubprocessoId, P006J2_A16ProcessoId, P006J2_n16ProcessoId, P006J2_A7EncarregadoId, P006J2_n7EncarregadoId, P006J2_A13PersonaId, P006J2_n13PersonaId, P006J2_A27CategoriaId, P006J2_n27CategoriaId,
               P006J2_A30TipoDadoId, P006J2_n30TipoDadoId, P006J2_A33FerramentaColetaId, P006J2_n33FerramentaColetaId, P006J2_A36AbrangenciaGeograficaId, P006J2_n36AbrangenciaGeograficaId, P006J2_A39FrequenciaTratamentoId, P006J2_n39FrequenciaTratamentoId, P006J2_A45TipoDescarteId, P006J2_n45TipoDescarteId,
               P006J2_A48TempoRetencaoId, P006J2_n48TempoRetencaoId, P006J2_A24AreaResponsavelId, P006J2_n24AreaResponsavelId, P006J2_A110DocumentoControladorId, P006J2_n110DocumentoControladorId, P006J2_A75DocumentoId, P006J2_A76DocumentoNome, P006J2_n76DocumentoNome, P006J2_A17ProcessoNome,
               P006J2_A21SubprocessoNome, P006J2_A25AreaResponsavelNome, P006J2_A11ControladorNome, P006J2_n11ControladorNome, P006J2_A14PersonaNome, P006J2_A8EncarregadoNome, P006J2_A108DocumentoDataInclusao, P006J2_n108DocumentoDataInclusao, P006J2_A141DocumentoUsuarioInclusao, P006J2_n141DocumentoUsuarioInclusao,
               P006J2_A109DocumentoDataAlteracao, P006J2_n109DocumentoDataAlteracao, P006J2_A142DocumentoUsuarioAlteracao, P006J2_n142DocumentoUsuarioAlteracao, P006J2_A77DocumentoFinalidadeTratamento, P006J2_n77DocumentoFinalidadeTratamento, P006J2_A28CategoriaNome, P006J2_A31TipoDadoNome, P006J2_A34FerramentaColetaNome, P006J2_A37AbrangenciaGeograficaNome,
               P006J2_A40FrequenciaTratamentoNome, P006J2_A46TipoDescarteNome, P006J2_A49TempoRetencaoNome, P006J2_A79DocumentoBaseLegalNorm, P006J2_n79DocumentoBaseLegalNorm, P006J2_A80DocumentoBaseLegalNormIntExt, P006J2_n80DocumentoBaseLegalNormIntExt, P006J2_A78DocumentoPrevColetaDados, P006J2_n78DocumentoPrevColetaDados, P006J2_A82DocumentoDadosGrupoVul,
               P006J2_n82DocumentoDadosGrupoVul, P006J2_A81DocumentoDadosCriancaAdolesc, P006J2_n81DocumentoDadosCriancaAdolesc, P006J2_A83DocumentoMedidaSegurancaDesc, P006J2_n83DocumentoMedidaSegurancaDesc, P006J2_A84DocumentoFluxoTratDadosDesc, P006J2_n84DocumentoFluxoTratDadosDesc
               }
               , new Object[] {
               P006J3_A63FonteRetencaoId, P006J3_A75DocumentoId, P006J3_A64FonteRetencaoNome
               }
               , new Object[] {
               P006J4_A60SetorInternoId, P006J4_A75DocumentoId, P006J4_A61SetorInternoNome
               }
               , new Object[] {
               P006J5_A57CompartInternoId, P006J5_A75DocumentoId, P006J5_A58CompartInternoNome
               }
               , new Object[] {
               P006J6_A54EnvolvidosColetaId, P006J6_A75DocumentoId, P006J6_A55EnvolvidosColetaNome
               }
               , new Object[] {
               P006J7_A51MedidaSegurancaId, P006J7_A75DocumentoId, P006J7_A52MedidaSegurancaNome
               }
               , new Object[] {
               P006J8_A69InformacaoId, P006J8_A72HipoteseTratamentoId, P006J8_A98DocDicionarioId, P006J8_A75DocumentoId, P006J8_A70InformacaoNome, P006J8_A100DocDicionarioPodeEliminar, P006J8_A99DocDicionarioSensivel, P006J8_A73HipoteseTratamentoNome, P006J8_A119DocDicionarioTipoTransfInterGa, P006J8_A101DocDicionarioTransfInter,
               P006J8_A102DocDicionarioFinalidade
               }
               , new Object[] {
               P006J9_A66CompartTercExternoId, P006J9_A98DocDicionarioId, P006J9_A67CompartTercExternoNome
               }
               , new Object[] {
               P006J10_A4PaisId, P006J10_A98DocDicionarioId, P006J10_A5PaisNome
               }
               , new Object[] {
               P006J11_A42OperadorId, P006J11_A75DocumentoId, P006J11_A43OperadorNome, P006J11_A87DocOperadorColeta, P006J11_A88DocOperadorRetencao, P006J11_A89DocOperadorCompartilhamento, P006J11_A90DocOperadorEliminacao, P006J11_A91DocOperadorProcessamento, P006J11_A86DocOperadorId
               }
               , new Object[] {
               P006J12_A75DocumentoId, P006J12_A123RevisaoLogDataAlteracao, P006J12_A121RevisaoLogUsuarioAlteracao, P006J12_A122RevisaoLogObservacao, P006J12_A120RevisaoLogId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV86GXLvl19 ;
      private short AV94GXLvl267 ;
      private short AV97GXLvl358 ;
      private short AV98GXLvl379 ;
      private short AV37RodapePagina ;
      private int AV14DocumentoId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A20SubprocessoId ;
      private int A16ProcessoId ;
      private int A7EncarregadoId ;
      private int A13PersonaId ;
      private int A27CategoriaId ;
      private int A30TipoDadoId ;
      private int A33FerramentaColetaId ;
      private int A36AbrangenciaGeograficaId ;
      private int A39FrequenciaTratamentoId ;
      private int A45TipoDescarteId ;
      private int A48TempoRetencaoId ;
      private int A24AreaResponsavelId ;
      private int A110DocumentoControladorId ;
      private int A75DocumentoId ;
      private int Gx_OldLine ;
      private int A63FonteRetencaoId ;
      private int A60SetorInternoId ;
      private int A57CompartInternoId ;
      private int A54EnvolvidosColetaId ;
      private int A51MedidaSegurancaId ;
      private int AV92GXV1 ;
      private int A69InformacaoId ;
      private int A72HipoteseTratamentoId ;
      private int A98DocDicionarioId ;
      private int A66CompartTercExternoId ;
      private int A4PaisId ;
      private int A42OperadorId ;
      private int A86DocOperadorId ;
      private int A120RevisaoLogId ;
      private long AV63Lenght ;
      private long AV64y ;
      private long AV66z ;
      private decimal AV80ImageHeight ;
      private decimal AV81ImageWidth ;
      private decimal AV82ImageRatio ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string AV48PrevColetaDados ;
      private string AV51DadosGrupoVul ;
      private string AV52DadosCriancaAdolesc ;
      private string sImgUrl ;
      private DateTime A108DocumentoDataInclusao ;
      private DateTime A109DocumentoDataAlteracao ;
      private DateTime AV44DocumentoDataInclusao ;
      private DateTime AV45DocumentoDataAlteracao ;
      private DateTime A123RevisaoLogDataAlteracao ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n20SubprocessoId ;
      private bool n16ProcessoId ;
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
      private bool n110DocumentoControladorId ;
      private bool n76DocumentoNome ;
      private bool n11ControladorNome ;
      private bool n108DocumentoDataInclusao ;
      private bool n141DocumentoUsuarioInclusao ;
      private bool n109DocumentoDataAlteracao ;
      private bool n142DocumentoUsuarioAlteracao ;
      private bool n77DocumentoFinalidadeTratamento ;
      private bool n79DocumentoBaseLegalNorm ;
      private bool n80DocumentoBaseLegalNormIntExt ;
      private bool A78DocumentoPrevColetaDados ;
      private bool n78DocumentoPrevColetaDados ;
      private bool A82DocumentoDadosGrupoVul ;
      private bool n82DocumentoDadosGrupoVul ;
      private bool A81DocumentoDadosCriancaAdolesc ;
      private bool n81DocumentoDadosCriancaAdolesc ;
      private bool n83DocumentoMedidaSegurancaDesc ;
      private bool n84DocumentoFluxoTratDadosDesc ;
      private bool AV77PrimeiroBloco ;
      private bool AV70Boolean ;
      private bool A100DocDicionarioPodeEliminar ;
      private bool A99DocDicionarioSensivel ;
      private bool A101DocDicionarioTransfInter ;
      private bool A87DocOperadorColeta ;
      private bool A88DocOperadorRetencao ;
      private bool A89DocOperadorCompartilhamento ;
      private bool A90DocOperadorEliminacao ;
      private bool A91DocOperadorProcessamento ;
      private string A83DocumentoMedidaSegurancaDesc ;
      private string A84DocumentoFluxoTratDadosDesc ;
      private string AV57DocumentoMedidaSegurancaDesc ;
      private string AV79TagHtmlItem ;
      private string AV74DocumentoFluxoTratDadosDescAux ;
      private string A119DocDicionarioTipoTransfInterGa ;
      private string A102DocDicionarioFinalidade ;
      private string AV59DocDicionarioTipoTransfInterGarantia ;
      private string AV61DocDicionarioFinalidade ;
      private string A122RevisaoLogObservacao ;
      private string AV69RevisaoLogObservacao ;
      private string AV18FileName ;
      private string A76DocumentoNome ;
      private string A17ProcessoNome ;
      private string A21SubprocessoNome ;
      private string A25AreaResponsavelNome ;
      private string A11ControladorNome ;
      private string A14PersonaNome ;
      private string A8EncarregadoNome ;
      private string A141DocumentoUsuarioInclusao ;
      private string A142DocumentoUsuarioAlteracao ;
      private string A77DocumentoFinalidadeTratamento ;
      private string A28CategoriaNome ;
      private string A31TipoDadoNome ;
      private string A34FerramentaColetaNome ;
      private string A37AbrangenciaGeograficaNome ;
      private string A40FrequenciaTratamentoNome ;
      private string A46TipoDescarteNome ;
      private string A49TempoRetencaoNome ;
      private string A79DocumentoBaseLegalNorm ;
      private string A80DocumentoBaseLegalNormIntExt ;
      private string AV15DocumentoNome ;
      private string AV22ProcessoNome ;
      private string AV24SubProcessoNome ;
      private string AV9AreaResponsavelNome ;
      private string AV11ControladorNome ;
      private string AV21PersonaNome ;
      private string AV16EncarregadoNome ;
      private string AV42DocumentoUsuarioInclusao ;
      private string AV43DocumentoUsuarioAlteracao ;
      private string AV13DocumentoFinalidadeTratamento ;
      private string AV10CategoriaNome ;
      private string AV25TipoDadoNome ;
      private string AV17FerramentaColetaNome ;
      private string AV8AbrangenciaGeograficaNome ;
      private string AV20FrequenciaTratamentoNome ;
      private string AV46TipoDescarte ;
      private string AV47TempoRetencao ;
      private string AV49BaseLegalNorm ;
      private string AV50BaseLegalNormIntExt ;
      private string A64FonteRetencaoNome ;
      private string AV19FonteRetencao ;
      private string A61SetorInternoNome ;
      private string AV53SetorInterno ;
      private string A58CompartInternoNome ;
      private string AV54CompartInterno ;
      private string A55EnvolvidosColetaNome ;
      private string AV55EnvolvidosColeta ;
      private string A52MedidaSegurancaNome ;
      private string AV56MedidaSeguranca ;
      private string AV93Image_GXI ;
      private string AV60DocumentoFluxoTratDadosDesc ;
      private string A70InformacaoNome ;
      private string A73HipoteseTratamentoNome ;
      private string AV26InformacaoNome ;
      private string AV27DocDicioPodeEliminar ;
      private string AV28DocDicioDadosSensiveis ;
      private string AV29HipoteseTratamentoNome ;
      private string AV67DocDicionarioTransfInter ;
      private string AV30CompartTercExt ;
      private string A67CompartTercExternoNome ;
      private string A5PaisNome ;
      private string AV68Paises ;
      private string A43OperadorNome ;
      private string AV31OperadorNome ;
      private string AV32OperadorColeta ;
      private string AV33OperadorRetencao ;
      private string AV34OperadorCompartilhamento ;
      private string AV35OperadorEliminacao ;
      private string AV36OperadorProcessamento ;
      private string A121RevisaoLogUsuarioAlteracao ;
      private string AV23RodapeInfo ;
      private string AV76Image ;
      private string Image ;
      private string AV71Blob ;
      private GxSimpleCollection<short> AV39DicionarioQTD ;
      private GxSimpleCollection<short> AV41OperadorQTD ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P006J2_A20SubprocessoId ;
      private bool[] P006J2_n20SubprocessoId ;
      private int[] P006J2_A16ProcessoId ;
      private bool[] P006J2_n16ProcessoId ;
      private int[] P006J2_A7EncarregadoId ;
      private bool[] P006J2_n7EncarregadoId ;
      private int[] P006J2_A13PersonaId ;
      private bool[] P006J2_n13PersonaId ;
      private int[] P006J2_A27CategoriaId ;
      private bool[] P006J2_n27CategoriaId ;
      private int[] P006J2_A30TipoDadoId ;
      private bool[] P006J2_n30TipoDadoId ;
      private int[] P006J2_A33FerramentaColetaId ;
      private bool[] P006J2_n33FerramentaColetaId ;
      private int[] P006J2_A36AbrangenciaGeograficaId ;
      private bool[] P006J2_n36AbrangenciaGeograficaId ;
      private int[] P006J2_A39FrequenciaTratamentoId ;
      private bool[] P006J2_n39FrequenciaTratamentoId ;
      private int[] P006J2_A45TipoDescarteId ;
      private bool[] P006J2_n45TipoDescarteId ;
      private int[] P006J2_A48TempoRetencaoId ;
      private bool[] P006J2_n48TempoRetencaoId ;
      private int[] P006J2_A24AreaResponsavelId ;
      private bool[] P006J2_n24AreaResponsavelId ;
      private int[] P006J2_A110DocumentoControladorId ;
      private bool[] P006J2_n110DocumentoControladorId ;
      private int[] P006J2_A75DocumentoId ;
      private string[] P006J2_A76DocumentoNome ;
      private bool[] P006J2_n76DocumentoNome ;
      private string[] P006J2_A17ProcessoNome ;
      private string[] P006J2_A21SubprocessoNome ;
      private string[] P006J2_A25AreaResponsavelNome ;
      private string[] P006J2_A11ControladorNome ;
      private bool[] P006J2_n11ControladorNome ;
      private string[] P006J2_A14PersonaNome ;
      private string[] P006J2_A8EncarregadoNome ;
      private DateTime[] P006J2_A108DocumentoDataInclusao ;
      private bool[] P006J2_n108DocumentoDataInclusao ;
      private string[] P006J2_A141DocumentoUsuarioInclusao ;
      private bool[] P006J2_n141DocumentoUsuarioInclusao ;
      private DateTime[] P006J2_A109DocumentoDataAlteracao ;
      private bool[] P006J2_n109DocumentoDataAlteracao ;
      private string[] P006J2_A142DocumentoUsuarioAlteracao ;
      private bool[] P006J2_n142DocumentoUsuarioAlteracao ;
      private string[] P006J2_A77DocumentoFinalidadeTratamento ;
      private bool[] P006J2_n77DocumentoFinalidadeTratamento ;
      private string[] P006J2_A28CategoriaNome ;
      private string[] P006J2_A31TipoDadoNome ;
      private string[] P006J2_A34FerramentaColetaNome ;
      private string[] P006J2_A37AbrangenciaGeograficaNome ;
      private string[] P006J2_A40FrequenciaTratamentoNome ;
      private string[] P006J2_A46TipoDescarteNome ;
      private string[] P006J2_A49TempoRetencaoNome ;
      private string[] P006J2_A79DocumentoBaseLegalNorm ;
      private bool[] P006J2_n79DocumentoBaseLegalNorm ;
      private string[] P006J2_A80DocumentoBaseLegalNormIntExt ;
      private bool[] P006J2_n80DocumentoBaseLegalNormIntExt ;
      private bool[] P006J2_A78DocumentoPrevColetaDados ;
      private bool[] P006J2_n78DocumentoPrevColetaDados ;
      private bool[] P006J2_A82DocumentoDadosGrupoVul ;
      private bool[] P006J2_n82DocumentoDadosGrupoVul ;
      private bool[] P006J2_A81DocumentoDadosCriancaAdolesc ;
      private bool[] P006J2_n81DocumentoDadosCriancaAdolesc ;
      private string[] P006J2_A83DocumentoMedidaSegurancaDesc ;
      private bool[] P006J2_n83DocumentoMedidaSegurancaDesc ;
      private string[] P006J2_A84DocumentoFluxoTratDadosDesc ;
      private bool[] P006J2_n84DocumentoFluxoTratDadosDesc ;
      private int[] P006J3_A63FonteRetencaoId ;
      private int[] P006J3_A75DocumentoId ;
      private string[] P006J3_A64FonteRetencaoNome ;
      private int[] P006J4_A60SetorInternoId ;
      private int[] P006J4_A75DocumentoId ;
      private string[] P006J4_A61SetorInternoNome ;
      private int[] P006J5_A57CompartInternoId ;
      private int[] P006J5_A75DocumentoId ;
      private string[] P006J5_A58CompartInternoNome ;
      private int[] P006J6_A54EnvolvidosColetaId ;
      private int[] P006J6_A75DocumentoId ;
      private string[] P006J6_A55EnvolvidosColetaNome ;
      private int[] P006J7_A51MedidaSegurancaId ;
      private int[] P006J7_A75DocumentoId ;
      private string[] P006J7_A52MedidaSegurancaNome ;
      private int[] P006J8_A69InformacaoId ;
      private int[] P006J8_A72HipoteseTratamentoId ;
      private int[] P006J8_A98DocDicionarioId ;
      private int[] P006J8_A75DocumentoId ;
      private string[] P006J8_A70InformacaoNome ;
      private bool[] P006J8_A100DocDicionarioPodeEliminar ;
      private bool[] P006J8_A99DocDicionarioSensivel ;
      private string[] P006J8_A73HipoteseTratamentoNome ;
      private string[] P006J8_A119DocDicionarioTipoTransfInterGa ;
      private bool[] P006J8_A101DocDicionarioTransfInter ;
      private string[] P006J8_A102DocDicionarioFinalidade ;
      private int[] P006J9_A66CompartTercExternoId ;
      private int[] P006J9_A98DocDicionarioId ;
      private string[] P006J9_A67CompartTercExternoNome ;
      private int[] P006J10_A4PaisId ;
      private int[] P006J10_A98DocDicionarioId ;
      private string[] P006J10_A5PaisNome ;
      private int[] P006J11_A42OperadorId ;
      private int[] P006J11_A75DocumentoId ;
      private string[] P006J11_A43OperadorNome ;
      private bool[] P006J11_A87DocOperadorColeta ;
      private bool[] P006J11_A88DocOperadorRetencao ;
      private bool[] P006J11_A89DocOperadorCompartilhamento ;
      private bool[] P006J11_A90DocOperadorEliminacao ;
      private bool[] P006J11_A91DocOperadorProcessamento ;
      private int[] P006J11_A86DocOperadorId ;
      private int[] P006J12_A75DocumentoId ;
      private DateTime[] P006J12_A123RevisaoLogDataAlteracao ;
      private string[] P006J12_A121RevisaoLogUsuarioAlteracao ;
      private string[] P006J12_A122RevisaoLogObservacao ;
      private int[] P006J12_A120RevisaoLogId ;
      private GxSimpleCollection<string> AV78TagHtmlColl ;
   }

   public class adocumentorelatoriopdf__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006J2;
          prmP006J2 = new Object[] {
          new ParDef("@AV14DocumentoId",GXType.Int32,8,0)
          };
          string cmdBufferP006J2;
          cmdBufferP006J2=" SELECT T1.[SubprocessoId], T2.[ProcessoId], T1.[EncarregadoId], T1.[PersonaId], T1.[CategoriaId], T1.[TipoDadoId], T1.[FerramentaColetaId], T1.[AbrangenciaGeograficaId], T1.[FrequenciaTratamentoId], T1.[TipoDescarteId], T1.[TempoRetencaoId], T1.[AreaResponsavelId], T1.[DocumentoControladorId] AS DocumentoControladorId, T1.[DocumentoId], T1.[DocumentoNome], T3.[ProcessoNome], T2.[SubprocessoNome], T13.[AreaResponsavelNome], T14.[ControladorNome], T5.[PersonaNome], T4.[EncarregadoNome], T1.[DocumentoDataInclusao], T1.[DocumentoUsuarioInclusao], T1.[DocumentoDataAlteracao], T1.[DocumentoUsuarioAlteracao], T1.[DocumentoFinalidadeTratamento], T6.[CategoriaNome], T7.[TipoDadoNome], T8.[FerramentaColetaNome], T9.[AbrangenciaGeograficaNome], T10.[FrequenciaTratamentoNome], T11.[TipoDescarteNome], T12.[TempoRetencaoNome], T1.[DocumentoBaseLegalNorm], T1.[DocumentoBaseLegalNormIntExt], T1.[DocumentoPrevColetaDados], T1.[DocumentoDadosGrupoVul], T1.[DocumentoDadosCriancaAdolesc], T1.[DocumentoMedidaSegurancaDesc], T1.[DocumentoFluxoTratDadosDesc] FROM ((((((((((((([Documento] T1 LEFT JOIN [SubProcesso] T2 ON T2.[SubprocessoId] = T1.[SubprocessoId]) LEFT JOIN [Processo] T3 ON T3.[ProcessoId] = T2.[ProcessoId]) LEFT JOIN [Encarregado] T4 ON T4.[EncarregadoId] = T1.[EncarregadoId]) LEFT JOIN [Persona] T5 ON T5.[PersonaId] = T1.[PersonaId]) LEFT JOIN [Categoria] T6 ON T6.[CategoriaId] = T1.[CategoriaId]) LEFT JOIN [TipoDado] T7 ON T7.[TipoDadoId] = T1.[TipoDadoId]) LEFT JOIN [FerramentaColeta] T8 ON T8.[FerramentaColetaId] = T1.[FerramentaColetaId]) LEFT JOIN [AbrangenciaGeografica] T9 ON T9.[AbrangenciaGeograficaId] = T1.[AbrangenciaGeograficaId]) LEFT JOIN [FrequenciaTratamento] T10 ON T10.[FrequenciaTratamentoId] = T1.[FrequenciaTratamentoId]) LEFT JOIN [TipoDescarte] T11 ON T11.[TipoDescarteId] "
          + " = T1.[TipoDescarteId]) LEFT JOIN [TempoRetencao] T12 ON T12.[TempoRetencaoId] = T1.[TempoRetencaoId]) LEFT JOIN [AreaResponsavel] T13 ON T13.[AreaResponsavelId] = T1.[AreaResponsavelId]) LEFT JOIN [Controlador] T14 ON T14.[ControladorId] = T1.[DocumentoControladorId]) WHERE T1.[DocumentoId] = @AV14DocumentoId ORDER BY T1.[DocumentoId]" ;
          Object[] prmP006J3;
          prmP006J3 = new Object[] {
          new ParDef("@AV14DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP006J4;
          prmP006J4 = new Object[] {
          new ParDef("@AV14DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP006J5;
          prmP006J5 = new Object[] {
          new ParDef("@AV14DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP006J6;
          prmP006J6 = new Object[] {
          new ParDef("@AV14DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP006J7;
          prmP006J7 = new Object[] {
          new ParDef("@AV14DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP006J8;
          prmP006J8 = new Object[] {
          new ParDef("@AV14DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP006J9;
          prmP006J9 = new Object[] {
          new ParDef("@DocDicionarioId",GXType.Int32,8,0) ,
          new ParDef("@DocumentoId",GXType.Int32,8,0) ,
          new ParDef("@AV14DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP006J10;
          prmP006J10 = new Object[] {
          new ParDef("@DocDicionarioId",GXType.Int32,8,0) ,
          new ParDef("@DocumentoId",GXType.Int32,8,0) ,
          new ParDef("@AV14DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP006J11;
          prmP006J11 = new Object[] {
          new ParDef("@AV14DocumentoId",GXType.Int32,8,0)
          };
          Object[] prmP006J12;
          prmP006J12 = new Object[] {
          new ParDef("@AV14DocumentoId",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006J2", cmdBufferP006J2,false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P006J3", "SELECT T1.[FonteRetencaoId], T1.[DocumentoId], T2.[FonteRetencaoNome] FROM ([DocFonteRetencao] T1 INNER JOIN [FonteRetencao] T2 ON T2.[FonteRetencaoId] = T1.[FonteRetencaoId]) WHERE T1.[DocumentoId] = @AV14DocumentoId ORDER BY T1.[DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006J4", "SELECT T1.[SetorInternoId], T1.[DocumentoId], T2.[SetorInternoNome] FROM ([DocSetorInterno] T1 INNER JOIN [SetorInterno] T2 ON T2.[SetorInternoId] = T1.[SetorInternoId]) WHERE T1.[DocumentoId] = @AV14DocumentoId ORDER BY T1.[DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006J5", "SELECT T1.[CompartInternoId], T1.[DocumentoId], T2.[CompartInternoNome] FROM ([DocCompartInterno] T1 INNER JOIN [CompartInterno] T2 ON T2.[CompartInternoId] = T1.[CompartInternoId]) WHERE T1.[DocumentoId] = @AV14DocumentoId ORDER BY T1.[DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006J6", "SELECT T1.[EnvolvidosColetaId], T1.[DocumentoId], T2.[EnvolvidosColetaNome] FROM ([DocEnvolvidosColeta] T1 INNER JOIN [EnvolvidosColeta] T2 ON T2.[EnvolvidosColetaId] = T1.[EnvolvidosColetaId]) WHERE T1.[DocumentoId] = @AV14DocumentoId ORDER BY T1.[DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006J7", "SELECT T1.[MedidaSegurancaId], T1.[DocumentoId], T2.[MedidaSegurancaNome] FROM ([DocMedidaSeguranca] T1 INNER JOIN [MedidaSeguranca] T2 ON T2.[MedidaSegurancaId] = T1.[MedidaSegurancaId]) WHERE T1.[DocumentoId] = @AV14DocumentoId ORDER BY T1.[DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006J8", "SELECT T1.[InformacaoId], T1.[HipoteseTratamentoId], T1.[DocDicionarioId], T1.[DocumentoId], T2.[InformacaoNome], T1.[DocDicionarioPodeEliminar], T1.[DocDicionarioSensivel], T3.[HipoteseTratamentoNome], T1.[DocDicionarioTipoTransfInterGa], T1.[DocDicionarioTransfInter], T1.[DocDicionarioFinalidade] FROM (([DocDicionario] T1 INNER JOIN [Informacao] T2 ON T2.[InformacaoId] = T1.[InformacaoId]) INNER JOIN [HipoteseTratamento] T3 ON T3.[HipoteseTratamentoId] = T1.[HipoteseTratamentoId]) WHERE T1.[DocumentoId] = @AV14DocumentoId ORDER BY T1.[DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006J9", "SELECT T1.[CompartTercExternoId], T1.[DocDicionarioId], T2.[CompartTercExternoNome] FROM ([DicionarioCompartTercExt] T1 INNER JOIN [CompartTercExterno] T2 ON T2.[CompartTercExternoId] = T1.[CompartTercExternoId]) WHERE (T1.[DocDicionarioId] = @DocDicionarioId) AND (@DocumentoId = @AV14DocumentoId) ORDER BY T1.[DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J9,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006J10", "SELECT T1.[PaisId], T1.[DocDicionarioId], T2.[PaisNome] FROM ([DicionarioPais] T1 INNER JOIN [Pais] T2 ON T2.[PaisId] = T1.[PaisId]) WHERE (T1.[DocDicionarioId] = @DocDicionarioId) AND (@DocumentoId = @AV14DocumentoId) ORDER BY T1.[DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J10,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006J11", "SELECT T1.[OperadorId], T1.[DocumentoId], T2.[OperadorNome], T1.[DocOperadorColeta], T1.[DocOperadorRetencao], T1.[DocOperadorCompartilhamento], T1.[DocOperadorEliminacao], T1.[DocOperadorProcessamento], T1.[DocOperadorId] FROM ([DocOperador] T1 INNER JOIN [Operador] T2 ON T2.[OperadorId] = T1.[OperadorId]) WHERE T1.[DocumentoId] = @AV14DocumentoId ORDER BY T1.[DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J11,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006J12", "SELECT [DocumentoId], [RevisaoLogDataAlteracao], [RevisaoLogUsuarioAlteracao], [RevisaoLogObservacao], [RevisaoLogId] FROM [RevisaoLog] WHERE [DocumentoId] = @AV14DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J12,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((int[]) buf[20])[0] = rslt.getInt(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((int[]) buf[24])[0] = rslt.getInt(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((int[]) buf[26])[0] = rslt.getInt(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((string[]) buf[30])[0] = rslt.getVarchar(17);
                ((string[]) buf[31])[0] = rslt.getVarchar(18);
                ((string[]) buf[32])[0] = rslt.getVarchar(19);
                ((bool[]) buf[33])[0] = rslt.wasNull(19);
                ((string[]) buf[34])[0] = rslt.getVarchar(20);
                ((string[]) buf[35])[0] = rslt.getVarchar(21);
                ((DateTime[]) buf[36])[0] = rslt.getGXDateTime(22);
                ((bool[]) buf[37])[0] = rslt.wasNull(22);
                ((string[]) buf[38])[0] = rslt.getVarchar(23);
                ((bool[]) buf[39])[0] = rslt.wasNull(23);
                ((DateTime[]) buf[40])[0] = rslt.getGXDateTime(24);
                ((bool[]) buf[41])[0] = rslt.wasNull(24);
                ((string[]) buf[42])[0] = rslt.getVarchar(25);
                ((bool[]) buf[43])[0] = rslt.wasNull(25);
                ((string[]) buf[44])[0] = rslt.getVarchar(26);
                ((bool[]) buf[45])[0] = rslt.wasNull(26);
                ((string[]) buf[46])[0] = rslt.getVarchar(27);
                ((string[]) buf[47])[0] = rslt.getVarchar(28);
                ((string[]) buf[48])[0] = rslt.getVarchar(29);
                ((string[]) buf[49])[0] = rslt.getVarchar(30);
                ((string[]) buf[50])[0] = rslt.getVarchar(31);
                ((string[]) buf[51])[0] = rslt.getVarchar(32);
                ((string[]) buf[52])[0] = rslt.getVarchar(33);
                ((string[]) buf[53])[0] = rslt.getVarchar(34);
                ((bool[]) buf[54])[0] = rslt.wasNull(34);
                ((string[]) buf[55])[0] = rslt.getVarchar(35);
                ((bool[]) buf[56])[0] = rslt.wasNull(35);
                ((bool[]) buf[57])[0] = rslt.getBool(36);
                ((bool[]) buf[58])[0] = rslt.wasNull(36);
                ((bool[]) buf[59])[0] = rslt.getBool(37);
                ((bool[]) buf[60])[0] = rslt.wasNull(37);
                ((bool[]) buf[61])[0] = rslt.getBool(38);
                ((bool[]) buf[62])[0] = rslt.wasNull(38);
                ((string[]) buf[63])[0] = rslt.getLongVarchar(39);
                ((bool[]) buf[64])[0] = rslt.wasNull(39);
                ((string[]) buf[65])[0] = rslt.getLongVarchar(40);
                ((bool[]) buf[66])[0] = rslt.wasNull(40);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((bool[]) buf[6])[0] = rslt.getBool(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[9])[0] = rslt.getBool(10);
                ((string[]) buf[10])[0] = rslt.getLongVarchar(11);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((bool[]) buf[6])[0] = rslt.getBool(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
