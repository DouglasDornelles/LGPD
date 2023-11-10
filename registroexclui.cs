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
   public class registroexclui : GXProcedure
   {
      public registroexclui( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public registroexclui( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Transacao ,
                           int aP1_Id )
      {
         this.AV9Transacao = aP0_Transacao;
         this.AV8Id = aP1_Id;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_Transacao ,
                                 int aP1_Id )
      {
         registroexclui objregistroexclui;
         objregistroexclui = new registroexclui();
         objregistroexclui.AV9Transacao = aP0_Transacao;
         objregistroexclui.AV8Id = aP1_Id;
         objregistroexclui.context.SetSubmitInitialConfig(context);
         objregistroexclui.initialize();
         Submit( executePrivateCatch,objregistroexclui);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((registroexclui)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV9Transacao, "AbrangenciaGeografica") == 0 )
         {
            AV12AbrangenciaGeografica.Load(AV8Id);
            AV12AbrangenciaGeografica.Delete();
            if ( AV12AbrangenciaGeografica.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV38GXV2 = 1;
               AV37GXV1 = AV12AbrangenciaGeografica.GetMessages();
               while ( AV38GXV2 <= AV37GXV1.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV37GXV1.Item(AV38GXV2));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV38GXV2 = (int)(AV38GXV2+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "AreaResponsavel") == 0 )
         {
            AV13AreaResponsavel.Load(AV8Id);
            AV13AreaResponsavel.Delete();
            if ( AV13AreaResponsavel.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV40GXV4 = 1;
               AV39GXV3 = AV13AreaResponsavel.GetMessages();
               while ( AV40GXV4 <= AV39GXV3.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV39GXV3.Item(AV40GXV4));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV40GXV4 = (int)(AV40GXV4+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "Categoria") == 0 )
         {
            AV14Categoria.Load(AV8Id);
            AV14Categoria.Delete();
            if ( AV14Categoria.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV42GXV6 = 1;
               AV41GXV5 = AV14Categoria.GetMessages();
               while ( AV42GXV6 <= AV41GXV5.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV41GXV5.Item(AV42GXV6));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV42GXV6 = (int)(AV42GXV6+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "CompartInterno") == 0 )
         {
            AV15CompartInterno.Load(AV8Id);
            AV15CompartInterno.Delete();
            if ( AV15CompartInterno.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV44GXV8 = 1;
               AV43GXV7 = AV15CompartInterno.GetMessages();
               while ( AV44GXV8 <= AV43GXV7.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV43GXV7.Item(AV44GXV8));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV44GXV8 = (int)(AV44GXV8+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "CompartTercExterno") == 0 )
         {
            AV16CompartTercExterno.Load(AV8Id);
            AV16CompartTercExterno.Delete();
            if ( AV16CompartTercExterno.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV46GXV10 = 1;
               AV45GXV9 = AV16CompartTercExterno.GetMessages();
               while ( AV46GXV10 <= AV45GXV9.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV45GXV9.Item(AV46GXV10));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV46GXV10 = (int)(AV46GXV10+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "Controlador") == 0 )
         {
            AV17Controlador.Load(AV8Id);
            AV17Controlador.Delete();
            if ( AV17Controlador.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV48GXV12 = 1;
               AV47GXV11 = AV17Controlador.GetMessages();
               while ( AV48GXV12 <= AV47GXV11.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV47GXV11.Item(AV48GXV12));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV48GXV12 = (int)(AV48GXV12+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "Encarregado") == 0 )
         {
            AV18Encarregado.Load(AV8Id);
            AV18Encarregado.Delete();
            if ( AV18Encarregado.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV50GXV14 = 1;
               AV49GXV13 = AV18Encarregado.GetMessages();
               while ( AV50GXV14 <= AV49GXV13.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV49GXV13.Item(AV50GXV14));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV50GXV14 = (int)(AV50GXV14+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "EnvolvidosColeta") == 0 )
         {
            AV19EnvolvidosColeta.Load(AV8Id);
            AV19EnvolvidosColeta.Delete();
            if ( AV19EnvolvidosColeta.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV52GXV16 = 1;
               AV51GXV15 = AV19EnvolvidosColeta.GetMessages();
               while ( AV52GXV16 <= AV51GXV15.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV51GXV15.Item(AV52GXV16));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV52GXV16 = (int)(AV52GXV16+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "FerramentaColeta") == 0 )
         {
            AV20FerramentaColeta.Load(AV8Id);
            AV20FerramentaColeta.Delete();
            if ( AV20FerramentaColeta.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV54GXV18 = 1;
               AV53GXV17 = AV20FerramentaColeta.GetMessages();
               while ( AV54GXV18 <= AV53GXV17.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV53GXV17.Item(AV54GXV18));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV54GXV18 = (int)(AV54GXV18+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "FonteRetencao") == 0 )
         {
            AV21FonteRetencao.Load(AV8Id);
            AV21FonteRetencao.Delete();
            if ( AV21FonteRetencao.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV56GXV20 = 1;
               AV55GXV19 = AV21FonteRetencao.GetMessages();
               while ( AV56GXV20 <= AV55GXV19.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV55GXV19.Item(AV56GXV20));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV56GXV20 = (int)(AV56GXV20+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "FrequenciaTratamento") == 0 )
         {
            AV22FrequenciaTratamento.Load(AV8Id);
            AV22FrequenciaTratamento.Delete();
            if ( AV22FrequenciaTratamento.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV58GXV22 = 1;
               AV57GXV21 = AV22FrequenciaTratamento.GetMessages();
               while ( AV58GXV22 <= AV57GXV21.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV57GXV21.Item(AV58GXV22));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV58GXV22 = (int)(AV58GXV22+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "HipoteseTratamento") == 0 )
         {
            AV23HipoteseTratamento.Load(AV8Id);
            if ( AV23HipoteseTratamento.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV60GXV24 = 1;
               AV59GXV23 = AV23HipoteseTratamento.GetMessages();
               while ( AV60GXV24 <= AV59GXV23.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV59GXV23.Item(AV60GXV24));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV60GXV24 = (int)(AV60GXV24+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "Informacao") == 0 )
         {
            AV24Informacao.Load(AV8Id);
            if ( AV24Informacao.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV62GXV26 = 1;
               AV61GXV25 = AV24Informacao.GetMessages();
               while ( AV62GXV26 <= AV61GXV25.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV61GXV25.Item(AV62GXV26));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV62GXV26 = (int)(AV62GXV26+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "MedidaSeguranca") == 0 )
         {
            AV25MedidaSeguranca.Load(AV8Id);
            AV25MedidaSeguranca.Delete();
            if ( AV25MedidaSeguranca.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV64GXV28 = 1;
               AV63GXV27 = AV25MedidaSeguranca.GetMessages();
               while ( AV64GXV28 <= AV63GXV27.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV63GXV27.Item(AV64GXV28));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV64GXV28 = (int)(AV64GXV28+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "Operador") == 0 )
         {
            AV26Operador.Load(AV8Id);
            AV26Operador.Delete();
            if ( AV26Operador.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV66GXV30 = 1;
               AV65GXV29 = AV26Operador.GetMessages();
               while ( AV66GXV30 <= AV65GXV29.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV65GXV29.Item(AV66GXV30));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV66GXV30 = (int)(AV66GXV30+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "Pais") == 0 )
         {
            AV10Pais.Load(AV8Id);
            AV10Pais.Delete();
            if ( AV10Pais.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV68GXV32 = 1;
               AV67GXV31 = AV10Pais.GetMessages();
               while ( AV68GXV32 <= AV67GXV31.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV67GXV31.Item(AV68GXV32));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV68GXV32 = (int)(AV68GXV32+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "Persona") == 0 )
         {
            AV27Persona.Load(AV8Id);
            AV27Persona.Delete();
            if ( AV27Persona.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV70GXV34 = 1;
               AV69GXV33 = AV27Persona.GetMessages();
               while ( AV70GXV34 <= AV69GXV33.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV69GXV33.Item(AV70GXV34));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV70GXV34 = (int)(AV70GXV34+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "Processo") == 0 )
         {
            AV28Processo.Load(AV8Id);
            AV28Processo.Delete();
            if ( AV28Processo.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV72GXV36 = 1;
               AV71GXV35 = AV28Processo.GetMessages();
               while ( AV72GXV36 <= AV71GXV35.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV71GXV35.Item(AV72GXV36));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV72GXV36 = (int)(AV72GXV36+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "SetorInterno") == 0 )
         {
            AV29SetorInterno.Load(AV8Id);
            AV29SetorInterno.Delete();
            if ( AV29SetorInterno.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV74GXV38 = 1;
               AV73GXV37 = AV29SetorInterno.GetMessages();
               while ( AV74GXV38 <= AV73GXV37.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV73GXV37.Item(AV74GXV38));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV74GXV38 = (int)(AV74GXV38+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "SubProcesso") == 0 )
         {
            AV30SubProcesso.Load(AV8Id);
            if ( AV30SubProcesso.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV76GXV40 = 1;
               AV75GXV39 = AV30SubProcesso.GetMessages();
               while ( AV76GXV40 <= AV75GXV39.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV75GXV39.Item(AV76GXV40));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV76GXV40 = (int)(AV76GXV40+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "TempoRetencao") == 0 )
         {
            AV31TempoRetencao.Load(AV8Id);
            AV31TempoRetencao.Delete();
            if ( AV31TempoRetencao.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV78GXV42 = 1;
               AV77GXV41 = AV31TempoRetencao.GetMessages();
               while ( AV78GXV42 <= AV77GXV41.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV77GXV41.Item(AV78GXV42));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV78GXV42 = (int)(AV78GXV42+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "TipoDado") == 0 )
         {
            AV32TipoDado.Load(AV8Id);
            AV32TipoDado.Delete();
            if ( AV32TipoDado.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV80GXV44 = 1;
               AV79GXV43 = AV32TipoDado.GetMessages();
               while ( AV80GXV44 <= AV79GXV43.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV79GXV43.Item(AV80GXV44));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV80GXV44 = (int)(AV80GXV44+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "TipoDescarte") == 0 )
         {
            AV33tipoDescarte.Load(AV8Id);
            AV33tipoDescarte.Delete();
            if ( AV33tipoDescarte.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV82GXV46 = 1;
               AV81GXV45 = AV33tipoDescarte.GetMessages();
               while ( AV82GXV46 <= AV81GXV45.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV81GXV45.Item(AV82GXV46));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV82GXV46 = (int)(AV82GXV46+1);
               }
            }
         }
         else if ( StringUtil.StrCmp(AV9Transacao, "Tooltip") == 0 )
         {
            AV34Tooltip.Load(AV8Id);
            AV34Tooltip.Delete();
            if ( AV34Tooltip.Success() )
            {
               context.CommitDataStores("registroexclui",pr_default);
            }
            else
            {
               AV84GXV48 = 1;
               AV83GXV47 = AV34Tooltip.GetMessages();
               while ( AV84GXV48 <= AV83GXV47.Count )
               {
                  AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV83GXV47.Item(AV84GXV48));
                  if ( StringUtil.Contains( AV11Message.gxTpr_Description, "existe informação em") )
                  {
                     GX_msglist.addItem("Eliminação inválida, existe informações associadas a ele.");
                  }
                  else
                  {
                     GX_msglist.addItem(AV11Message.gxTpr_Description);
                  }
                  AV84GXV48 = (int)(AV84GXV48+1);
               }
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
         AV12AbrangenciaGeografica = new SdtAbrangenciaGeografica(context);
         AV37GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV11Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV13AreaResponsavel = new SdtAreaResponsavel(context);
         AV39GXV3 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV14Categoria = new SdtCategoria(context);
         AV41GXV5 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV15CompartInterno = new SdtCompartInterno(context);
         AV43GXV7 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV16CompartTercExterno = new SdtCompartTercExterno(context);
         AV45GXV9 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV17Controlador = new SdtControlador(context);
         AV47GXV11 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV18Encarregado = new SdtEncarregado(context);
         AV49GXV13 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV19EnvolvidosColeta = new SdtEnvolvidosColeta(context);
         AV51GXV15 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV20FerramentaColeta = new SdtFerramentaColeta(context);
         AV53GXV17 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV21FonteRetencao = new SdtFonteRetencao(context);
         AV55GXV19 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV22FrequenciaTratamento = new SdtFrequenciaTratamento(context);
         AV57GXV21 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV23HipoteseTratamento = new SdtHipoteseTratamento(context);
         AV59GXV23 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV24Informacao = new SdtInformacao(context);
         AV61GXV25 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV25MedidaSeguranca = new SdtMedidaSeguranca(context);
         AV63GXV27 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV26Operador = new SdtOperador(context);
         AV65GXV29 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV10Pais = new SdtPais(context);
         AV67GXV31 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV27Persona = new SdtPersona(context);
         AV69GXV33 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV28Processo = new SdtProcesso(context);
         AV71GXV35 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV29SetorInterno = new SdtSetorInterno(context);
         AV73GXV37 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV30SubProcesso = new SdtSubProcesso(context);
         AV75GXV39 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV31TempoRetencao = new SdtTempoRetencao(context);
         AV77GXV41 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV32TipoDado = new SdtTipoDado(context);
         AV79GXV43 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV33tipoDescarte = new SdtTipoDescarte(context);
         AV81GXV45 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV34Tooltip = new SdtTooltip(context);
         AV83GXV47 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.registroexclui__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.registroexclui__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8Id ;
      private int AV38GXV2 ;
      private int AV40GXV4 ;
      private int AV42GXV6 ;
      private int AV44GXV8 ;
      private int AV46GXV10 ;
      private int AV48GXV12 ;
      private int AV50GXV14 ;
      private int AV52GXV16 ;
      private int AV54GXV18 ;
      private int AV56GXV20 ;
      private int AV58GXV22 ;
      private int AV60GXV24 ;
      private int AV62GXV26 ;
      private int AV64GXV28 ;
      private int AV66GXV30 ;
      private int AV68GXV32 ;
      private int AV70GXV34 ;
      private int AV72GXV36 ;
      private int AV74GXV38 ;
      private int AV76GXV40 ;
      private int AV78GXV42 ;
      private int AV80GXV44 ;
      private int AV82GXV46 ;
      private int AV84GXV48 ;
      private string AV9Transacao ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV37GXV1 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV39GXV3 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV41GXV5 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV43GXV7 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV45GXV9 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV47GXV11 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV49GXV13 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV51GXV15 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV53GXV17 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV55GXV19 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV57GXV21 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV59GXV23 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV61GXV25 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV63GXV27 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV65GXV29 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV67GXV31 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV69GXV33 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV71GXV35 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV73GXV37 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV75GXV39 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV77GXV41 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV79GXV43 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV81GXV45 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV83GXV47 ;
      private SdtPais AV10Pais ;
      private GeneXus.Utils.SdtMessages_Message AV11Message ;
      private SdtAbrangenciaGeografica AV12AbrangenciaGeografica ;
      private SdtAreaResponsavel AV13AreaResponsavel ;
      private SdtCategoria AV14Categoria ;
      private SdtCompartInterno AV15CompartInterno ;
      private SdtCompartTercExterno AV16CompartTercExterno ;
      private SdtControlador AV17Controlador ;
      private SdtEncarregado AV18Encarregado ;
      private SdtEnvolvidosColeta AV19EnvolvidosColeta ;
      private SdtFerramentaColeta AV20FerramentaColeta ;
      private SdtFonteRetencao AV21FonteRetencao ;
      private SdtFrequenciaTratamento AV22FrequenciaTratamento ;
      private SdtHipoteseTratamento AV23HipoteseTratamento ;
      private SdtInformacao AV24Informacao ;
      private SdtMedidaSeguranca AV25MedidaSeguranca ;
      private SdtOperador AV26Operador ;
      private SdtPersona AV27Persona ;
      private SdtProcesso AV28Processo ;
      private SdtSetorInterno AV29SetorInterno ;
      private SdtSubProcesso AV30SubProcesso ;
      private SdtTempoRetencao AV31TempoRetencao ;
      private SdtTipoDado AV32TipoDado ;
      private SdtTipoDescarte AV33tipoDescarte ;
      private SdtTooltip AV34Tooltip ;
   }

   public class registroexclui__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class registroexclui__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
