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
   public class validanome : GXProcedure
   {
      public validanome( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public validanome( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Transacao ,
                           int aP1_Id ,
                           string aP2_Nome ,
                           out bool aP3_IsOk )
      {
         this.AV8Transacao = aP0_Transacao;
         this.AV11Id = aP1_Id;
         this.AV9Nome = aP2_Nome;
         this.AV10IsOk = false ;
         initialize();
         executePrivate();
         aP3_IsOk=this.AV10IsOk;
      }

      public bool executeUdp( string aP0_Transacao ,
                              int aP1_Id ,
                              string aP2_Nome )
      {
         execute(aP0_Transacao, aP1_Id, aP2_Nome, out aP3_IsOk);
         return AV10IsOk ;
      }

      public void executeSubmit( string aP0_Transacao ,
                                 int aP1_Id ,
                                 string aP2_Nome ,
                                 out bool aP3_IsOk )
      {
         validanome objvalidanome;
         objvalidanome = new validanome();
         objvalidanome.AV8Transacao = aP0_Transacao;
         objvalidanome.AV11Id = aP1_Id;
         objvalidanome.AV9Nome = aP2_Nome;
         objvalidanome.AV10IsOk = false ;
         objvalidanome.context.SetSubmitInitialConfig(context);
         objvalidanome.initialize();
         Submit( executePrivateCatch,objvalidanome);
         aP3_IsOk=this.AV10IsOk;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((validanome)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV8Transacao, "AbrangenciaGeografica") == 0 )
         {
            AV15GXLvl4 = 0;
            /* Using cursor P00692 */
            pr_default.execute(0, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A37AbrangenciaGeograficaNome = P00692_A37AbrangenciaGeograficaNome[0];
               A36AbrangenciaGeograficaId = P00692_A36AbrangenciaGeograficaId[0];
               AV15GXLvl4 = 1;
               if ( (0==AV11Id) || ! ( A36AbrangenciaGeograficaId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV15GXLvl4 == 0 )
            {
               AV10IsOk = true;
            }
         }
         else if ( StringUtil.StrCmp(AV8Transacao, "AreaResponsavel") == 0 )
         {
            AV16GXLvl19 = 0;
            /* Using cursor P00693 */
            pr_default.execute(1, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A25AreaResponsavelNome = P00693_A25AreaResponsavelNome[0];
               A24AreaResponsavelId = P00693_A24AreaResponsavelId[0];
               AV16GXLvl19 = 1;
               if ( (0==AV11Id) || ! ( A24AreaResponsavelId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( AV16GXLvl19 == 0 )
            {
               AV10IsOk = true;
            }
         }
         else if ( StringUtil.StrCmp(AV8Transacao, "Categoria") == 0 )
         {
            AV17GXLvl34 = 0;
            /* Using cursor P00694 */
            pr_default.execute(2, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A28CategoriaNome = P00694_A28CategoriaNome[0];
               A27CategoriaId = P00694_A27CategoriaId[0];
               AV17GXLvl34 = 1;
               if ( (0==AV11Id) || ! ( A27CategoriaId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(2);
            }
            pr_default.close(2);
            if ( AV17GXLvl34 == 0 )
            {
               AV10IsOk = true;
            }
         }
         else if ( StringUtil.StrCmp(AV8Transacao, "CompartInterno") == 0 )
         {
            AV18GXLvl49 = 0;
            /* Using cursor P00695 */
            pr_default.execute(3, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A58CompartInternoNome = P00695_A58CompartInternoNome[0];
               A57CompartInternoId = P00695_A57CompartInternoId[0];
               AV18GXLvl49 = 1;
               if ( (0==AV11Id) || ! ( A57CompartInternoId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( AV18GXLvl49 == 0 )
            {
               AV10IsOk = true;
            }
         }
         else if ( StringUtil.StrCmp(AV8Transacao, "CompartTercExterno") == 0 )
         {
            AV19GXLvl64 = 0;
            /* Using cursor P00696 */
            pr_default.execute(4, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A67CompartTercExternoNome = P00696_A67CompartTercExternoNome[0];
               A66CompartTercExternoId = P00696_A66CompartTercExternoId[0];
               AV19GXLvl64 = 1;
               if ( (0==AV11Id) || ! ( A66CompartTercExternoId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(4);
            }
            pr_default.close(4);
            if ( AV19GXLvl64 == 0 )
            {
               AV10IsOk = true;
            }
         }
         else if ( StringUtil.StrCmp(AV8Transacao, "Controlador") == 0 )
         {
            AV20GXLvl79 = 0;
            /* Using cursor P00697 */
            pr_default.execute(5, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A11ControladorNome = P00697_A11ControladorNome[0];
               A10ControladorId = P00697_A10ControladorId[0];
               AV20GXLvl79 = 1;
               if ( (0==AV11Id) || ! ( A10ControladorId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(5);
            }
            pr_default.close(5);
            if ( AV20GXLvl79 == 0 )
            {
               AV10IsOk = true;
            }
         }
         else if ( StringUtil.StrCmp(AV8Transacao, "Encarregado") == 0 )
         {
            AV21GXLvl94 = 0;
            /* Using cursor P00698 */
            pr_default.execute(6, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A8EncarregadoNome = P00698_A8EncarregadoNome[0];
               A7EncarregadoId = P00698_A7EncarregadoId[0];
               AV21GXLvl94 = 1;
               if ( (0==AV11Id) || ! ( A7EncarregadoId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(6);
            }
            pr_default.close(6);
            if ( AV21GXLvl94 == 0 )
            {
               AV10IsOk = true;
            }
         }
         else if ( StringUtil.StrCmp(AV8Transacao, "EnvolvidosColeta") == 0 )
         {
            AV22GXLvl109 = 0;
            /* Using cursor P00699 */
            pr_default.execute(7, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(7) != 101) )
            {
               A55EnvolvidosColetaNome = P00699_A55EnvolvidosColetaNome[0];
               A54EnvolvidosColetaId = P00699_A54EnvolvidosColetaId[0];
               AV22GXLvl109 = 1;
               if ( (0==AV11Id) || ! ( A54EnvolvidosColetaId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(7);
            }
            pr_default.close(7);
            if ( AV22GXLvl109 == 0 )
            {
               AV10IsOk = true;
            }
         }
         else if ( StringUtil.StrCmp(AV8Transacao, "FerramentaColeta") == 0 )
         {
            AV23GXLvl124 = 0;
            /* Using cursor P006910 */
            pr_default.execute(8, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(8) != 101) )
            {
               A34FerramentaColetaNome = P006910_A34FerramentaColetaNome[0];
               A33FerramentaColetaId = P006910_A33FerramentaColetaId[0];
               AV23GXLvl124 = 1;
               if ( (0==AV11Id) || ! ( A33FerramentaColetaId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(8);
            }
            pr_default.close(8);
            if ( AV23GXLvl124 == 0 )
            {
               AV10IsOk = true;
            }
         }
         else if ( StringUtil.StrCmp(AV8Transacao, "FonteRetencao") == 0 )
         {
            AV24GXLvl139 = 0;
            /* Using cursor P006911 */
            pr_default.execute(9, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(9) != 101) )
            {
               A64FonteRetencaoNome = P006911_A64FonteRetencaoNome[0];
               A63FonteRetencaoId = P006911_A63FonteRetencaoId[0];
               AV24GXLvl139 = 1;
               if ( (0==AV11Id) || ! ( A63FonteRetencaoId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(9);
            }
            pr_default.close(9);
            if ( AV24GXLvl139 == 0 )
            {
               AV10IsOk = true;
            }
         }
         else if ( StringUtil.StrCmp(AV8Transacao, "FrequenciaTratamento") == 0 )
         {
            AV25GXLvl154 = 0;
            /* Using cursor P006912 */
            pr_default.execute(10, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(10) != 101) )
            {
               A40FrequenciaTratamentoNome = P006912_A40FrequenciaTratamentoNome[0];
               A39FrequenciaTratamentoId = P006912_A39FrequenciaTratamentoId[0];
               AV25GXLvl154 = 1;
               if ( (0==AV11Id) || ! ( A39FrequenciaTratamentoId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(10);
            }
            pr_default.close(10);
            if ( AV25GXLvl154 == 0 )
            {
               AV10IsOk = true;
            }
         }
         else if ( StringUtil.StrCmp(AV8Transacao, "HipoteseTratamento") == 0 )
         {
            AV26GXLvl169 = 0;
            /* Using cursor P006913 */
            pr_default.execute(11, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(11) != 101) )
            {
               A73HipoteseTratamentoNome = P006913_A73HipoteseTratamentoNome[0];
               A72HipoteseTratamentoId = P006913_A72HipoteseTratamentoId[0];
               AV26GXLvl169 = 1;
               if ( (0==AV11Id) || ! ( A72HipoteseTratamentoId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(11);
            }
            pr_default.close(11);
            if ( AV26GXLvl169 == 0 )
            {
               AV10IsOk = true;
            }
         }
         else if ( StringUtil.StrCmp(AV8Transacao, "Informacao") == 0 )
         {
            AV27GXLvl184 = 0;
            /* Using cursor P006914 */
            pr_default.execute(12, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(12) != 101) )
            {
               A70InformacaoNome = P006914_A70InformacaoNome[0];
               A69InformacaoId = P006914_A69InformacaoId[0];
               AV27GXLvl184 = 1;
               if ( (0==AV11Id) || ! ( A69InformacaoId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(12);
            }
            pr_default.close(12);
            if ( AV27GXLvl184 == 0 )
            {
               AV10IsOk = true;
            }
         }
         else if ( StringUtil.StrCmp(AV8Transacao, "MedidaSeguranca") == 0 )
         {
            AV28GXLvl199 = 0;
            /* Using cursor P006915 */
            pr_default.execute(13, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(13) != 101) )
            {
               A52MedidaSegurancaNome = P006915_A52MedidaSegurancaNome[0];
               A51MedidaSegurancaId = P006915_A51MedidaSegurancaId[0];
               AV28GXLvl199 = 1;
               if ( (0==AV11Id) || ! ( A51MedidaSegurancaId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(13);
            }
            pr_default.close(13);
            if ( AV28GXLvl199 == 0 )
            {
               AV10IsOk = true;
            }
         }
         else if ( StringUtil.StrCmp(AV8Transacao, "Operador") == 0 )
         {
            AV29GXLvl214 = 0;
            /* Using cursor P006916 */
            pr_default.execute(14, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(14) != 101) )
            {
               A43OperadorNome = P006916_A43OperadorNome[0];
               A42OperadorId = P006916_A42OperadorId[0];
               AV29GXLvl214 = 1;
               if ( (0==AV11Id) || ! ( A42OperadorId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(14);
            }
            pr_default.close(14);
            if ( AV29GXLvl214 == 0 )
            {
               AV10IsOk = true;
            }
         }
         else if ( StringUtil.StrCmp(AV8Transacao, "Pais") == 0 )
         {
            AV30GXLvl229 = 0;
            /* Using cursor P006917 */
            pr_default.execute(15, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(15) != 101) )
            {
               A5PaisNome = P006917_A5PaisNome[0];
               A4PaisId = P006917_A4PaisId[0];
               AV30GXLvl229 = 1;
               if ( (0==AV11Id) || ! ( A4PaisId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(15);
            }
            pr_default.close(15);
            if ( AV30GXLvl229 == 0 )
            {
               AV10IsOk = true;
            }
         }
         else if ( StringUtil.StrCmp(AV8Transacao, "Persona") == 0 )
         {
            AV31GXLvl244 = 0;
            /* Using cursor P006918 */
            pr_default.execute(16, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(16) != 101) )
            {
               A14PersonaNome = P006918_A14PersonaNome[0];
               A13PersonaId = P006918_A13PersonaId[0];
               AV31GXLvl244 = 1;
               if ( (0==AV11Id) || ! ( A13PersonaId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(16);
            }
            pr_default.close(16);
            if ( AV31GXLvl244 == 0 )
            {
               AV10IsOk = true;
            }
         }
         else if ( StringUtil.StrCmp(AV8Transacao, "Processo") == 0 )
         {
            AV32GXLvl259 = 0;
            /* Using cursor P006919 */
            pr_default.execute(17, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(17) != 101) )
            {
               A17ProcessoNome = P006919_A17ProcessoNome[0];
               A16ProcessoId = P006919_A16ProcessoId[0];
               AV32GXLvl259 = 1;
               if ( (0==AV11Id) || ! ( A16ProcessoId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(17);
            }
            pr_default.close(17);
            if ( AV32GXLvl259 == 0 )
            {
               AV10IsOk = true;
            }
         }
         else if ( StringUtil.StrCmp(AV8Transacao, "SetorInterno") == 0 )
         {
            AV33GXLvl274 = 0;
            /* Using cursor P006920 */
            pr_default.execute(18, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(18) != 101) )
            {
               A61SetorInternoNome = P006920_A61SetorInternoNome[0];
               A60SetorInternoId = P006920_A60SetorInternoId[0];
               AV33GXLvl274 = 1;
               if ( (0==AV11Id) || ! ( A60SetorInternoId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(18);
            }
            pr_default.close(18);
            if ( AV33GXLvl274 == 0 )
            {
               AV10IsOk = true;
            }
         }
         else if ( StringUtil.StrCmp(AV8Transacao, "SubProcesso") == 0 )
         {
            AV34GXLvl289 = 0;
            /* Using cursor P006921 */
            pr_default.execute(19, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(19) != 101) )
            {
               A21SubprocessoNome = P006921_A21SubprocessoNome[0];
               A20SubprocessoId = P006921_A20SubprocessoId[0];
               AV34GXLvl289 = 1;
               if ( (0==AV11Id) || ! ( A20SubprocessoId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(19);
            }
            pr_default.close(19);
            if ( AV34GXLvl289 == 0 )
            {
               AV10IsOk = true;
            }
         }
         else if ( StringUtil.StrCmp(AV8Transacao, "TempoRetencao") == 0 )
         {
            AV35GXLvl304 = 0;
            /* Using cursor P006922 */
            pr_default.execute(20, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(20) != 101) )
            {
               A49TempoRetencaoNome = P006922_A49TempoRetencaoNome[0];
               A48TempoRetencaoId = P006922_A48TempoRetencaoId[0];
               AV35GXLvl304 = 1;
               if ( (0==AV11Id) || ! ( A48TempoRetencaoId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(20);
            }
            pr_default.close(20);
            if ( AV35GXLvl304 == 0 )
            {
               AV10IsOk = true;
            }
         }
         else if ( StringUtil.StrCmp(AV8Transacao, "TipoDado") == 0 )
         {
            AV36GXLvl319 = 0;
            /* Using cursor P006923 */
            pr_default.execute(21, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(21) != 101) )
            {
               A31TipoDadoNome = P006923_A31TipoDadoNome[0];
               A30TipoDadoId = P006923_A30TipoDadoId[0];
               AV36GXLvl319 = 1;
               if ( (0==AV11Id) || ! ( A30TipoDadoId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(21);
            }
            pr_default.close(21);
            if ( AV36GXLvl319 == 0 )
            {
               AV10IsOk = true;
            }
         }
         else if ( StringUtil.StrCmp(AV8Transacao, "TipoDescarte") == 0 )
         {
            AV37GXLvl334 = 0;
            /* Using cursor P006924 */
            pr_default.execute(22, new Object[] {AV9Nome});
            while ( (pr_default.getStatus(22) != 101) )
            {
               A46TipoDescarteNome = P006924_A46TipoDescarteNome[0];
               A45TipoDescarteId = P006924_A45TipoDescarteId[0];
               AV37GXLvl334 = 1;
               if ( (0==AV11Id) || ! ( A45TipoDescarteId == AV11Id ) )
               {
                  AV10IsOk = false;
               }
               else
               {
                  AV10IsOk = true;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(22);
            }
            pr_default.close(22);
            if ( AV37GXLvl334 == 0 )
            {
               AV10IsOk = true;
            }
         }
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
         scmdbuf = "";
         P00692_A37AbrangenciaGeograficaNome = new string[] {""} ;
         P00692_A36AbrangenciaGeograficaId = new int[1] ;
         A37AbrangenciaGeograficaNome = "";
         P00693_A25AreaResponsavelNome = new string[] {""} ;
         P00693_A24AreaResponsavelId = new int[1] ;
         A25AreaResponsavelNome = "";
         P00694_A28CategoriaNome = new string[] {""} ;
         P00694_A27CategoriaId = new int[1] ;
         A28CategoriaNome = "";
         P00695_A58CompartInternoNome = new string[] {""} ;
         P00695_A57CompartInternoId = new int[1] ;
         A58CompartInternoNome = "";
         P00696_A67CompartTercExternoNome = new string[] {""} ;
         P00696_A66CompartTercExternoId = new int[1] ;
         A67CompartTercExternoNome = "";
         P00697_A11ControladorNome = new string[] {""} ;
         P00697_A10ControladorId = new int[1] ;
         A11ControladorNome = "";
         P00698_A8EncarregadoNome = new string[] {""} ;
         P00698_A7EncarregadoId = new int[1] ;
         A8EncarregadoNome = "";
         P00699_A55EnvolvidosColetaNome = new string[] {""} ;
         P00699_A54EnvolvidosColetaId = new int[1] ;
         A55EnvolvidosColetaNome = "";
         P006910_A34FerramentaColetaNome = new string[] {""} ;
         P006910_A33FerramentaColetaId = new int[1] ;
         A34FerramentaColetaNome = "";
         P006911_A64FonteRetencaoNome = new string[] {""} ;
         P006911_A63FonteRetencaoId = new int[1] ;
         A64FonteRetencaoNome = "";
         P006912_A40FrequenciaTratamentoNome = new string[] {""} ;
         P006912_A39FrequenciaTratamentoId = new int[1] ;
         A40FrequenciaTratamentoNome = "";
         P006913_A73HipoteseTratamentoNome = new string[] {""} ;
         P006913_A72HipoteseTratamentoId = new int[1] ;
         A73HipoteseTratamentoNome = "";
         P006914_A70InformacaoNome = new string[] {""} ;
         P006914_A69InformacaoId = new int[1] ;
         A70InformacaoNome = "";
         P006915_A52MedidaSegurancaNome = new string[] {""} ;
         P006915_A51MedidaSegurancaId = new int[1] ;
         A52MedidaSegurancaNome = "";
         P006916_A43OperadorNome = new string[] {""} ;
         P006916_A42OperadorId = new int[1] ;
         A43OperadorNome = "";
         P006917_A5PaisNome = new string[] {""} ;
         P006917_A4PaisId = new int[1] ;
         A5PaisNome = "";
         P006918_A14PersonaNome = new string[] {""} ;
         P006918_A13PersonaId = new int[1] ;
         A14PersonaNome = "";
         P006919_A17ProcessoNome = new string[] {""} ;
         P006919_A16ProcessoId = new int[1] ;
         A17ProcessoNome = "";
         P006920_A61SetorInternoNome = new string[] {""} ;
         P006920_A60SetorInternoId = new int[1] ;
         A61SetorInternoNome = "";
         P006921_A21SubprocessoNome = new string[] {""} ;
         P006921_A20SubprocessoId = new int[1] ;
         A21SubprocessoNome = "";
         P006922_A49TempoRetencaoNome = new string[] {""} ;
         P006922_A48TempoRetencaoId = new int[1] ;
         A49TempoRetencaoNome = "";
         P006923_A31TipoDadoNome = new string[] {""} ;
         P006923_A30TipoDadoId = new int[1] ;
         A31TipoDadoNome = "";
         P006924_A46TipoDescarteNome = new string[] {""} ;
         P006924_A45TipoDescarteId = new int[1] ;
         A46TipoDescarteNome = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.validanome__default(),
            new Object[][] {
                new Object[] {
               P00692_A37AbrangenciaGeograficaNome, P00692_A36AbrangenciaGeograficaId
               }
               , new Object[] {
               P00693_A25AreaResponsavelNome, P00693_A24AreaResponsavelId
               }
               , new Object[] {
               P00694_A28CategoriaNome, P00694_A27CategoriaId
               }
               , new Object[] {
               P00695_A58CompartInternoNome, P00695_A57CompartInternoId
               }
               , new Object[] {
               P00696_A67CompartTercExternoNome, P00696_A66CompartTercExternoId
               }
               , new Object[] {
               P00697_A11ControladorNome, P00697_A10ControladorId
               }
               , new Object[] {
               P00698_A8EncarregadoNome, P00698_A7EncarregadoId
               }
               , new Object[] {
               P00699_A55EnvolvidosColetaNome, P00699_A54EnvolvidosColetaId
               }
               , new Object[] {
               P006910_A34FerramentaColetaNome, P006910_A33FerramentaColetaId
               }
               , new Object[] {
               P006911_A64FonteRetencaoNome, P006911_A63FonteRetencaoId
               }
               , new Object[] {
               P006912_A40FrequenciaTratamentoNome, P006912_A39FrequenciaTratamentoId
               }
               , new Object[] {
               P006913_A73HipoteseTratamentoNome, P006913_A72HipoteseTratamentoId
               }
               , new Object[] {
               P006914_A70InformacaoNome, P006914_A69InformacaoId
               }
               , new Object[] {
               P006915_A52MedidaSegurancaNome, P006915_A51MedidaSegurancaId
               }
               , new Object[] {
               P006916_A43OperadorNome, P006916_A42OperadorId
               }
               , new Object[] {
               P006917_A5PaisNome, P006917_A4PaisId
               }
               , new Object[] {
               P006918_A14PersonaNome, P006918_A13PersonaId
               }
               , new Object[] {
               P006919_A17ProcessoNome, P006919_A16ProcessoId
               }
               , new Object[] {
               P006920_A61SetorInternoNome, P006920_A60SetorInternoId
               }
               , new Object[] {
               P006921_A21SubprocessoNome, P006921_A20SubprocessoId
               }
               , new Object[] {
               P006922_A49TempoRetencaoNome, P006922_A48TempoRetencaoId
               }
               , new Object[] {
               P006923_A31TipoDadoNome, P006923_A30TipoDadoId
               }
               , new Object[] {
               P006924_A46TipoDescarteNome, P006924_A45TipoDescarteId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV15GXLvl4 ;
      private short AV16GXLvl19 ;
      private short AV17GXLvl34 ;
      private short AV18GXLvl49 ;
      private short AV19GXLvl64 ;
      private short AV20GXLvl79 ;
      private short AV21GXLvl94 ;
      private short AV22GXLvl109 ;
      private short AV23GXLvl124 ;
      private short AV24GXLvl139 ;
      private short AV25GXLvl154 ;
      private short AV26GXLvl169 ;
      private short AV27GXLvl184 ;
      private short AV28GXLvl199 ;
      private short AV29GXLvl214 ;
      private short AV30GXLvl229 ;
      private short AV31GXLvl244 ;
      private short AV32GXLvl259 ;
      private short AV33GXLvl274 ;
      private short AV34GXLvl289 ;
      private short AV35GXLvl304 ;
      private short AV36GXLvl319 ;
      private short AV37GXLvl334 ;
      private int AV11Id ;
      private int A36AbrangenciaGeograficaId ;
      private int A24AreaResponsavelId ;
      private int A27CategoriaId ;
      private int A57CompartInternoId ;
      private int A66CompartTercExternoId ;
      private int A10ControladorId ;
      private int A7EncarregadoId ;
      private int A54EnvolvidosColetaId ;
      private int A33FerramentaColetaId ;
      private int A63FonteRetencaoId ;
      private int A39FrequenciaTratamentoId ;
      private int A72HipoteseTratamentoId ;
      private int A69InformacaoId ;
      private int A51MedidaSegurancaId ;
      private int A42OperadorId ;
      private int A4PaisId ;
      private int A13PersonaId ;
      private int A16ProcessoId ;
      private int A60SetorInternoId ;
      private int A20SubprocessoId ;
      private int A48TempoRetencaoId ;
      private int A30TipoDadoId ;
      private int A45TipoDescarteId ;
      private string scmdbuf ;
      private bool AV10IsOk ;
      private string AV8Transacao ;
      private string AV9Nome ;
      private string A37AbrangenciaGeograficaNome ;
      private string A25AreaResponsavelNome ;
      private string A28CategoriaNome ;
      private string A58CompartInternoNome ;
      private string A67CompartTercExternoNome ;
      private string A11ControladorNome ;
      private string A8EncarregadoNome ;
      private string A55EnvolvidosColetaNome ;
      private string A34FerramentaColetaNome ;
      private string A64FonteRetencaoNome ;
      private string A40FrequenciaTratamentoNome ;
      private string A73HipoteseTratamentoNome ;
      private string A70InformacaoNome ;
      private string A52MedidaSegurancaNome ;
      private string A43OperadorNome ;
      private string A5PaisNome ;
      private string A14PersonaNome ;
      private string A17ProcessoNome ;
      private string A61SetorInternoNome ;
      private string A21SubprocessoNome ;
      private string A49TempoRetencaoNome ;
      private string A31TipoDadoNome ;
      private string A46TipoDescarteNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00692_A37AbrangenciaGeograficaNome ;
      private int[] P00692_A36AbrangenciaGeograficaId ;
      private string[] P00693_A25AreaResponsavelNome ;
      private int[] P00693_A24AreaResponsavelId ;
      private string[] P00694_A28CategoriaNome ;
      private int[] P00694_A27CategoriaId ;
      private string[] P00695_A58CompartInternoNome ;
      private int[] P00695_A57CompartInternoId ;
      private string[] P00696_A67CompartTercExternoNome ;
      private int[] P00696_A66CompartTercExternoId ;
      private string[] P00697_A11ControladorNome ;
      private int[] P00697_A10ControladorId ;
      private string[] P00698_A8EncarregadoNome ;
      private int[] P00698_A7EncarregadoId ;
      private string[] P00699_A55EnvolvidosColetaNome ;
      private int[] P00699_A54EnvolvidosColetaId ;
      private string[] P006910_A34FerramentaColetaNome ;
      private int[] P006910_A33FerramentaColetaId ;
      private string[] P006911_A64FonteRetencaoNome ;
      private int[] P006911_A63FonteRetencaoId ;
      private string[] P006912_A40FrequenciaTratamentoNome ;
      private int[] P006912_A39FrequenciaTratamentoId ;
      private string[] P006913_A73HipoteseTratamentoNome ;
      private int[] P006913_A72HipoteseTratamentoId ;
      private string[] P006914_A70InformacaoNome ;
      private int[] P006914_A69InformacaoId ;
      private string[] P006915_A52MedidaSegurancaNome ;
      private int[] P006915_A51MedidaSegurancaId ;
      private string[] P006916_A43OperadorNome ;
      private int[] P006916_A42OperadorId ;
      private string[] P006917_A5PaisNome ;
      private int[] P006917_A4PaisId ;
      private string[] P006918_A14PersonaNome ;
      private int[] P006918_A13PersonaId ;
      private string[] P006919_A17ProcessoNome ;
      private int[] P006919_A16ProcessoId ;
      private string[] P006920_A61SetorInternoNome ;
      private int[] P006920_A60SetorInternoId ;
      private string[] P006921_A21SubprocessoNome ;
      private int[] P006921_A20SubprocessoId ;
      private string[] P006922_A49TempoRetencaoNome ;
      private int[] P006922_A48TempoRetencaoId ;
      private string[] P006923_A31TipoDadoNome ;
      private int[] P006923_A30TipoDadoId ;
      private string[] P006924_A46TipoDescarteNome ;
      private int[] P006924_A45TipoDescarteId ;
      private bool aP3_IsOk ;
   }

   public class validanome__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00692;
          prmP00692 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          Object[] prmP00693;
          prmP00693 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          Object[] prmP00694;
          prmP00694 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          Object[] prmP00695;
          prmP00695 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          Object[] prmP00696;
          prmP00696 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          Object[] prmP00697;
          prmP00697 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          Object[] prmP00698;
          prmP00698 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          Object[] prmP00699;
          prmP00699 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          Object[] prmP006910;
          prmP006910 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          Object[] prmP006911;
          prmP006911 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          Object[] prmP006912;
          prmP006912 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          Object[] prmP006913;
          prmP006913 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          Object[] prmP006914;
          prmP006914 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          Object[] prmP006915;
          prmP006915 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          Object[] prmP006916;
          prmP006916 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          Object[] prmP006917;
          prmP006917 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          Object[] prmP006918;
          prmP006918 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          Object[] prmP006919;
          prmP006919 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          Object[] prmP006920;
          prmP006920 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          Object[] prmP006921;
          prmP006921 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          Object[] prmP006922;
          prmP006922 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          Object[] prmP006923;
          prmP006923 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          Object[] prmP006924;
          prmP006924 = new Object[] {
          new ParDef("@AV9Nome",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00692", "SELECT TOP 1 [AbrangenciaGeograficaNome], [AbrangenciaGeograficaId] FROM [AbrangenciaGeografica] WHERE [AbrangenciaGeograficaNome] = @AV9Nome ORDER BY [AbrangenciaGeograficaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00692,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00693", "SELECT TOP 1 [AreaResponsavelNome], [AreaResponsavelId] FROM [AreaResponsavel] WHERE [AreaResponsavelNome] = @AV9Nome ORDER BY [AreaResponsavelNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00693,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00694", "SELECT TOP 1 [CategoriaNome], [CategoriaId] FROM [Categoria] WHERE [CategoriaNome] = @AV9Nome ORDER BY [CategoriaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00694,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00695", "SELECT TOP 1 [CompartInternoNome], [CompartInternoId] FROM [CompartInterno] WHERE [CompartInternoNome] = @AV9Nome ORDER BY [CompartInternoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00695,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00696", "SELECT TOP 1 [CompartTercExternoNome], [CompartTercExternoId] FROM [CompartTercExterno] WHERE [CompartTercExternoNome] = @AV9Nome ORDER BY [CompartTercExternoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00696,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00697", "SELECT TOP 1 [ControladorNome], [ControladorId] FROM [Controlador] WHERE [ControladorNome] = @AV9Nome ORDER BY [ControladorNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00697,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00698", "SELECT TOP 1 [EncarregadoNome], [EncarregadoId] FROM [Encarregado] WHERE [EncarregadoNome] = @AV9Nome ORDER BY [EncarregadoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00698,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00699", "SELECT TOP 1 [EnvolvidosColetaNome], [EnvolvidosColetaId] FROM [EnvolvidosColeta] WHERE [EnvolvidosColetaNome] = @AV9Nome ORDER BY [EnvolvidosColetaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00699,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006910", "SELECT TOP 1 [FerramentaColetaNome], [FerramentaColetaId] FROM [FerramentaColeta] WHERE [FerramentaColetaNome] = @AV9Nome ORDER BY [FerramentaColetaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006910,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006911", "SELECT TOP 1 [FonteRetencaoNome], [FonteRetencaoId] FROM [FonteRetencao] WHERE [FonteRetencaoNome] = @AV9Nome ORDER BY [FonteRetencaoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006911,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006912", "SELECT TOP 1 [FrequenciaTratamentoNome], [FrequenciaTratamentoId] FROM [FrequenciaTratamento] WHERE [FrequenciaTratamentoNome] = @AV9Nome ORDER BY [FrequenciaTratamentoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006912,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006913", "SELECT TOP 1 [HipoteseTratamentoNome], [HipoteseTratamentoId] FROM [HipoteseTratamento] WHERE [HipoteseTratamentoNome] = @AV9Nome ORDER BY [HipoteseTratamentoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006913,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006914", "SELECT TOP 1 [InformacaoNome], [InformacaoId] FROM [Informacao] WHERE [InformacaoNome] = @AV9Nome ORDER BY [InformacaoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006914,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006915", "SELECT TOP 1 [MedidaSegurancaNome], [MedidaSegurancaId] FROM [MedidaSeguranca] WHERE [MedidaSegurancaNome] = @AV9Nome ORDER BY [MedidaSegurancaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006915,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006916", "SELECT TOP 1 [OperadorNome], [OperadorId] FROM [Operador] WHERE [OperadorNome] = @AV9Nome ORDER BY [OperadorNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006916,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006917", "SELECT TOP 1 [PaisNome], [PaisId] FROM [Pais] WHERE [PaisNome] = @AV9Nome ORDER BY [PaisNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006917,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006918", "SELECT TOP 1 [PersonaNome], [PersonaId] FROM [Persona] WHERE [PersonaNome] = @AV9Nome ORDER BY [PersonaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006918,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006919", "SELECT TOP 1 [ProcessoNome], [ProcessoId] FROM [Processo] WHERE [ProcessoNome] = @AV9Nome ORDER BY [ProcessoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006919,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006920", "SELECT TOP 1 [SetorInternoNome], [SetorInternoId] FROM [SetorInterno] WHERE [SetorInternoNome] = @AV9Nome ORDER BY [SetorInternoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006920,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006921", "SELECT TOP 1 [SubprocessoNome], [SubprocessoId] FROM [SubProcesso] WHERE [SubprocessoNome] = @AV9Nome ORDER BY [SubprocessoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006921,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006922", "SELECT TOP 1 [TempoRetencaoNome], [TempoRetencaoId] FROM [TempoRetencao] WHERE [TempoRetencaoNome] = @AV9Nome ORDER BY [TempoRetencaoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006922,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006923", "SELECT TOP 1 [TipoDadoNome], [TipoDadoId] FROM [TipoDado] WHERE [TipoDadoNome] = @AV9Nome ORDER BY [TipoDadoNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006923,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006924", "SELECT TOP 1 [TipoDescarteNome], [TipoDescarteId] FROM [TipoDescarte] WHERE [TipoDescarteNome] = @AV9Nome ORDER BY [TipoDescarteNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006924,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
