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
   public class documentoexclui : GXProcedure
   {
      public documentoexclui( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public documentoexclui( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_DocumentoId ,
                           out bool aP1_IsOk )
      {
         this.AV8DocumentoId = aP0_DocumentoId;
         this.AV9IsOk = false ;
         initialize();
         executePrivate();
         aP1_IsOk=this.AV9IsOk;
      }

      public bool executeUdp( int aP0_DocumentoId )
      {
         execute(aP0_DocumentoId, out aP1_IsOk);
         return AV9IsOk ;
      }

      public void executeSubmit( int aP0_DocumentoId ,
                                 out bool aP1_IsOk )
      {
         documentoexclui objdocumentoexclui;
         objdocumentoexclui = new documentoexclui();
         objdocumentoexclui.AV8DocumentoId = aP0_DocumentoId;
         objdocumentoexclui.AV9IsOk = false ;
         objdocumentoexclui.context.SetSubmitInitialConfig(context);
         objdocumentoexclui.initialize();
         Submit( executePrivateCatch,objdocumentoexclui);
         aP1_IsOk=this.AV9IsOk;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((documentoexclui)stateInfo).executePrivate();
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
         AV21Count = 0;
         AV9IsOk = true;
         /* Using cursor P00742 */
         pr_default.execute(0, new Object[] {AV8DocumentoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A75DocumentoId = P00742_A75DocumentoId[0];
            A120RevisaoLogId = P00742_A120RevisaoLogId[0];
            AV10RevisaoLog.Load(A120RevisaoLogId);
            AV10RevisaoLog.Delete();
            if ( AV10RevisaoLog.Success() )
            {
               context.CommitDataStores("documentoexclui",pr_default);
            }
            else
            {
               AV29GXV2 = 1;
               AV28GXV1 = AV10RevisaoLog.GetMessages();
               while ( AV29GXV2 <= AV28GXV1.Count )
               {
                  AV12Message = ((GeneXus.Utils.SdtMessages_Message)AV28GXV1.Item(AV29GXV2));
                  GX_msglist.addItem(AV12Message.gxTpr_Description);
                  AV9IsOk = false;
                  if (true) break;
                  AV29GXV2 = (int)(AV29GXV2+1);
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV9IsOk )
         {
            /* Using cursor P00743 */
            pr_default.execute(1, new Object[] {AV8DocumentoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A75DocumentoId = P00743_A75DocumentoId[0];
               A86DocOperadorId = P00743_A86DocOperadorId[0];
               AV13DocOperador.Load(A86DocOperadorId);
               AV13DocOperador.Delete();
               if ( AV13DocOperador.Success() )
               {
                  context.CommitDataStores("documentoexclui",pr_default);
               }
               else
               {
                  AV32GXV4 = 1;
                  AV31GXV3 = AV13DocOperador.GetMessages();
                  while ( AV32GXV4 <= AV31GXV3.Count )
                  {
                     AV12Message = ((GeneXus.Utils.SdtMessages_Message)AV31GXV3.Item(AV32GXV4));
                     GX_msglist.addItem(AV12Message.gxTpr_Description);
                     AV9IsOk = false;
                     if (true) break;
                     AV32GXV4 = (int)(AV32GXV4+1);
                  }
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         if ( AV9IsOk )
         {
            /* Using cursor P00744 */
            pr_default.execute(2, new Object[] {AV8DocumentoId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A75DocumentoId = P00744_A75DocumentoId[0];
               A54EnvolvidosColetaId = P00744_A54EnvolvidosColetaId[0];
               AV11DocEnvolvidosColeta.Load(A54EnvolvidosColetaId, A75DocumentoId);
               AV11DocEnvolvidosColeta.Delete();
               if ( AV11DocEnvolvidosColeta.Success() )
               {
                  context.CommitDataStores("documentoexclui",pr_default);
               }
               else
               {
                  AV35GXV6 = 1;
                  AV34GXV5 = AV11DocEnvolvidosColeta.GetMessages();
                  while ( AV35GXV6 <= AV34GXV5.Count )
                  {
                     AV12Message = ((GeneXus.Utils.SdtMessages_Message)AV34GXV5.Item(AV35GXV6));
                     GX_msglist.addItem(AV12Message.gxTpr_Description);
                     AV9IsOk = false;
                     if (true) break;
                     AV35GXV6 = (int)(AV35GXV6+1);
                  }
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
         if ( AV9IsOk )
         {
            /* Using cursor P00745 */
            pr_default.execute(3, new Object[] {AV8DocumentoId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A75DocumentoId = P00745_A75DocumentoId[0];
               A51MedidaSegurancaId = P00745_A51MedidaSegurancaId[0];
               AV22DocMedidaSeguranca.Load(A51MedidaSegurancaId, A75DocumentoId);
               AV22DocMedidaSeguranca.Delete();
               if ( AV22DocMedidaSeguranca.Success() )
               {
                  context.CommitDataStores("documentoexclui",pr_default);
               }
               else
               {
                  AV38GXV8 = 1;
                  AV37GXV7 = AV22DocMedidaSeguranca.GetMessages();
                  while ( AV38GXV8 <= AV37GXV7.Count )
                  {
                     AV12Message = ((GeneXus.Utils.SdtMessages_Message)AV37GXV7.Item(AV38GXV8));
                     GX_msglist.addItem(AV12Message.gxTpr_Description);
                     AV9IsOk = false;
                     if (true) break;
                     AV38GXV8 = (int)(AV38GXV8+1);
                  }
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
         }
         if ( AV9IsOk )
         {
            /* Using cursor P00746 */
            pr_default.execute(4, new Object[] {AV8DocumentoId});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A75DocumentoId = P00746_A75DocumentoId[0];
               A57CompartInternoId = P00746_A57CompartInternoId[0];
               AV14DocCompartInterno.Load(A57CompartInternoId, A75DocumentoId);
               AV14DocCompartInterno.Delete();
               if ( AV14DocCompartInterno.Success() )
               {
                  context.CommitDataStores("documentoexclui",pr_default);
               }
               else
               {
                  AV41GXV10 = 1;
                  AV40GXV9 = AV14DocCompartInterno.GetMessages();
                  while ( AV41GXV10 <= AV40GXV9.Count )
                  {
                     AV12Message = ((GeneXus.Utils.SdtMessages_Message)AV40GXV9.Item(AV41GXV10));
                     GX_msglist.addItem(AV12Message.gxTpr_Description);
                     AV9IsOk = false;
                     if (true) break;
                     AV41GXV10 = (int)(AV41GXV10+1);
                  }
               }
               pr_default.readNext(4);
            }
            pr_default.close(4);
         }
         if ( AV9IsOk )
         {
            /* Using cursor P00747 */
            pr_default.execute(5, new Object[] {AV8DocumentoId});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A75DocumentoId = P00747_A75DocumentoId[0];
               A60SetorInternoId = P00747_A60SetorInternoId[0];
               AV15DocSetorInterno.Load(A60SetorInternoId, A75DocumentoId);
               AV15DocSetorInterno.Delete();
               if ( AV15DocSetorInterno.Success() )
               {
                  context.CommitDataStores("documentoexclui",pr_default);
               }
               else
               {
                  AV44GXV12 = 1;
                  AV43GXV11 = AV15DocSetorInterno.GetMessages();
                  while ( AV44GXV12 <= AV43GXV11.Count )
                  {
                     AV12Message = ((GeneXus.Utils.SdtMessages_Message)AV43GXV11.Item(AV44GXV12));
                     GX_msglist.addItem(AV12Message.gxTpr_Description);
                     AV9IsOk = false;
                     if (true) break;
                     AV44GXV12 = (int)(AV44GXV12+1);
                  }
               }
               pr_default.readNext(5);
            }
            pr_default.close(5);
         }
         if ( AV9IsOk )
         {
            /* Using cursor P00748 */
            pr_default.execute(6, new Object[] {AV8DocumentoId});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A75DocumentoId = P00748_A75DocumentoId[0];
               A63FonteRetencaoId = P00748_A63FonteRetencaoId[0];
               AV16DocFonteRetencao.Load(A63FonteRetencaoId, A75DocumentoId);
               AV16DocFonteRetencao.Delete();
               if ( AV16DocFonteRetencao.Success() )
               {
                  context.CommitDataStores("documentoexclui",pr_default);
               }
               else
               {
                  AV47GXV14 = 1;
                  AV46GXV13 = AV16DocFonteRetencao.GetMessages();
                  while ( AV47GXV14 <= AV46GXV13.Count )
                  {
                     AV12Message = ((GeneXus.Utils.SdtMessages_Message)AV46GXV13.Item(AV47GXV14));
                     GX_msglist.addItem(AV12Message.gxTpr_Description);
                     AV9IsOk = false;
                     if (true) break;
                     AV47GXV14 = (int)(AV47GXV14+1);
                  }
               }
               pr_default.readNext(6);
            }
            pr_default.close(6);
         }
         if ( AV9IsOk )
         {
            /* Using cursor P00749 */
            pr_default.execute(7, new Object[] {AV8DocumentoId});
            while ( (pr_default.getStatus(7) != 101) )
            {
               A75DocumentoId = P00749_A75DocumentoId[0];
               A98DocDicionarioId = P00749_A98DocDicionarioId[0];
               A66CompartTercExternoId = P00749_A66CompartTercExternoId[0];
               A75DocumentoId = P00749_A75DocumentoId[0];
               AV20DicionarioCompartTercExt.Load(A66CompartTercExternoId, A98DocDicionarioId);
               AV20DicionarioCompartTercExt.Delete();
               if ( AV20DicionarioCompartTercExt.Success() )
               {
                  context.CommitDataStores("documentoexclui",pr_default);
               }
               else
               {
                  AV50GXV16 = 1;
                  AV49GXV15 = AV20DicionarioCompartTercExt.GetMessages();
                  while ( AV50GXV16 <= AV49GXV15.Count )
                  {
                     AV12Message = ((GeneXus.Utils.SdtMessages_Message)AV49GXV15.Item(AV50GXV16));
                     GX_msglist.addItem(AV12Message.gxTpr_Description);
                     AV9IsOk = false;
                     if (true) break;
                     AV50GXV16 = (int)(AV50GXV16+1);
                  }
               }
               pr_default.readNext(7);
            }
            pr_default.close(7);
         }
         if ( AV9IsOk )
         {
            /* Using cursor P007410 */
            pr_default.execute(8, new Object[] {AV8DocumentoId});
            while ( (pr_default.getStatus(8) != 101) )
            {
               A75DocumentoId = P007410_A75DocumentoId[0];
               A98DocDicionarioId = P007410_A98DocDicionarioId[0];
               A4PaisId = P007410_A4PaisId[0];
               A75DocumentoId = P007410_A75DocumentoId[0];
               AV24DicionarioPais.Load(A4PaisId, A98DocDicionarioId);
               AV24DicionarioPais.Delete();
               if ( AV24DicionarioPais.Success() )
               {
                  context.CommitDataStores("documentoexclui",pr_default);
               }
               else
               {
                  AV53GXV18 = 1;
                  AV52GXV17 = AV24DicionarioPais.GetMessages();
                  while ( AV53GXV18 <= AV52GXV17.Count )
                  {
                     AV12Message = ((GeneXus.Utils.SdtMessages_Message)AV52GXV17.Item(AV53GXV18));
                     GX_msglist.addItem(AV12Message.gxTpr_Description);
                     AV9IsOk = false;
                     if (true) break;
                     AV53GXV18 = (int)(AV53GXV18+1);
                  }
               }
               pr_default.readNext(8);
            }
            pr_default.close(8);
         }
         if ( AV9IsOk )
         {
            /* Using cursor P007411 */
            pr_default.execute(9, new Object[] {AV8DocumentoId});
            while ( (pr_default.getStatus(9) != 101) )
            {
               A75DocumentoId = P007411_A75DocumentoId[0];
               A98DocDicionarioId = P007411_A98DocDicionarioId[0];
               AV17DocDicionario.Load(A98DocDicionarioId);
               AV17DocDicionario.Delete();
               if ( AV17DocDicionario.Success() )
               {
                  context.CommitDataStores("documentoexclui",pr_default);
               }
               else
               {
                  AV56GXV20 = 1;
                  AV55GXV19 = AV17DocDicionario.GetMessages();
                  while ( AV56GXV20 <= AV55GXV19.Count )
                  {
                     AV12Message = ((GeneXus.Utils.SdtMessages_Message)AV55GXV19.Item(AV56GXV20));
                     GX_msglist.addItem(AV12Message.gxTpr_Description);
                     AV9IsOk = false;
                     if (true) break;
                     AV56GXV20 = (int)(AV56GXV20+1);
                  }
               }
               pr_default.readNext(9);
            }
            pr_default.close(9);
         }
         if ( AV9IsOk )
         {
            /* Using cursor P007412 */
            pr_default.execute(10, new Object[] {AV8DocumentoId});
            while ( (pr_default.getStatus(10) != 101) )
            {
               A75DocumentoId = P007412_A75DocumentoId[0];
               A93DocAnexoId = P007412_A93DocAnexoId[0];
               AV18DocAnexo.Load(A93DocAnexoId);
               AV18DocAnexo.Delete();
               if ( AV18DocAnexo.Success() )
               {
                  context.CommitDataStores("documentoexclui",pr_default);
               }
               else
               {
                  AV59GXV22 = 1;
                  AV58GXV21 = AV18DocAnexo.GetMessages();
                  while ( AV59GXV22 <= AV58GXV21.Count )
                  {
                     AV12Message = ((GeneXus.Utils.SdtMessages_Message)AV58GXV21.Item(AV59GXV22));
                     GX_msglist.addItem(AV12Message.gxTpr_Description);
                     AV9IsOk = false;
                     if (true) break;
                     AV59GXV22 = (int)(AV59GXV22+1);
                  }
               }
               pr_default.readNext(10);
            }
            pr_default.close(10);
         }
         if ( AV9IsOk )
         {
            AV19Documento.Load(AV8DocumentoId);
            AV19Documento.Delete();
            if ( AV19Documento.Success() )
            {
               context.CommitDataStores("documentoexclui",pr_default);
            }
            else
            {
               AV61GXV24 = 1;
               AV60GXV23 = AV19Documento.GetMessages();
               while ( AV61GXV24 <= AV60GXV23.Count )
               {
                  AV12Message = ((GeneXus.Utils.SdtMessages_Message)AV60GXV23.Item(AV61GXV24));
                  GX_msglist.addItem(AV12Message.gxTpr_Description);
                  AV61GXV24 = (int)(AV61GXV24+1);
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
         scmdbuf = "";
         P00742_A75DocumentoId = new int[1] ;
         P00742_A120RevisaoLogId = new int[1] ;
         AV10RevisaoLog = new SdtRevisaoLog(context);
         AV28GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV12Message = new GeneXus.Utils.SdtMessages_Message(context);
         P00743_A75DocumentoId = new int[1] ;
         P00743_A86DocOperadorId = new int[1] ;
         AV13DocOperador = new SdtDocOperador(context);
         AV31GXV3 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P00744_A75DocumentoId = new int[1] ;
         P00744_A54EnvolvidosColetaId = new int[1] ;
         AV11DocEnvolvidosColeta = new SdtDocEnvolvidosColeta(context);
         AV34GXV5 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P00745_A75DocumentoId = new int[1] ;
         P00745_A51MedidaSegurancaId = new int[1] ;
         AV22DocMedidaSeguranca = new SdtDocMedidaSeguranca(context);
         AV37GXV7 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P00746_A75DocumentoId = new int[1] ;
         P00746_A57CompartInternoId = new int[1] ;
         AV14DocCompartInterno = new SdtDocCompartInterno(context);
         AV40GXV9 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P00747_A75DocumentoId = new int[1] ;
         P00747_A60SetorInternoId = new int[1] ;
         AV15DocSetorInterno = new SdtDocSetorInterno(context);
         AV43GXV11 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P00748_A75DocumentoId = new int[1] ;
         P00748_A63FonteRetencaoId = new int[1] ;
         AV16DocFonteRetencao = new SdtDocFonteRetencao(context);
         AV46GXV13 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P00749_A75DocumentoId = new int[1] ;
         P00749_A98DocDicionarioId = new int[1] ;
         P00749_A66CompartTercExternoId = new int[1] ;
         AV20DicionarioCompartTercExt = new SdtDicionarioCompartTercExt(context);
         AV49GXV15 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P007410_A75DocumentoId = new int[1] ;
         P007410_A98DocDicionarioId = new int[1] ;
         P007410_A4PaisId = new int[1] ;
         AV24DicionarioPais = new SdtDicionarioPais(context);
         AV52GXV17 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P007411_A75DocumentoId = new int[1] ;
         P007411_A98DocDicionarioId = new int[1] ;
         AV17DocDicionario = new SdtDocDicionario(context);
         AV55GXV19 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P007412_A75DocumentoId = new int[1] ;
         P007412_A93DocAnexoId = new int[1] ;
         AV18DocAnexo = new SdtDocAnexo(context);
         AV58GXV21 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV19Documento = new SdtDocumento(context);
         AV60GXV23 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.documentoexclui__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documentoexclui__default(),
            new Object[][] {
                new Object[] {
               P00742_A75DocumentoId, P00742_A120RevisaoLogId
               }
               , new Object[] {
               P00743_A75DocumentoId, P00743_A86DocOperadorId
               }
               , new Object[] {
               P00744_A75DocumentoId, P00744_A54EnvolvidosColetaId
               }
               , new Object[] {
               P00745_A75DocumentoId, P00745_A51MedidaSegurancaId
               }
               , new Object[] {
               P00746_A75DocumentoId, P00746_A57CompartInternoId
               }
               , new Object[] {
               P00747_A75DocumentoId, P00747_A60SetorInternoId
               }
               , new Object[] {
               P00748_A75DocumentoId, P00748_A63FonteRetencaoId
               }
               , new Object[] {
               P00749_A75DocumentoId, P00749_A98DocDicionarioId, P00749_A66CompartTercExternoId
               }
               , new Object[] {
               P007410_A75DocumentoId, P007410_A98DocDicionarioId, P007410_A4PaisId
               }
               , new Object[] {
               P007411_A75DocumentoId, P007411_A98DocDicionarioId
               }
               , new Object[] {
               P007412_A75DocumentoId, P007412_A93DocAnexoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV21Count ;
      private int AV8DocumentoId ;
      private int A75DocumentoId ;
      private int A120RevisaoLogId ;
      private int AV29GXV2 ;
      private int A86DocOperadorId ;
      private int AV32GXV4 ;
      private int A54EnvolvidosColetaId ;
      private int AV35GXV6 ;
      private int A51MedidaSegurancaId ;
      private int AV38GXV8 ;
      private int A57CompartInternoId ;
      private int AV41GXV10 ;
      private int A60SetorInternoId ;
      private int AV44GXV12 ;
      private int A63FonteRetencaoId ;
      private int AV47GXV14 ;
      private int A98DocDicionarioId ;
      private int A66CompartTercExternoId ;
      private int AV50GXV16 ;
      private int A4PaisId ;
      private int AV53GXV18 ;
      private int AV56GXV20 ;
      private int A93DocAnexoId ;
      private int AV59GXV22 ;
      private int AV61GXV24 ;
      private string scmdbuf ;
      private bool AV9IsOk ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00742_A75DocumentoId ;
      private int[] P00742_A120RevisaoLogId ;
      private int[] P00743_A75DocumentoId ;
      private int[] P00743_A86DocOperadorId ;
      private int[] P00744_A75DocumentoId ;
      private int[] P00744_A54EnvolvidosColetaId ;
      private int[] P00745_A75DocumentoId ;
      private int[] P00745_A51MedidaSegurancaId ;
      private int[] P00746_A75DocumentoId ;
      private int[] P00746_A57CompartInternoId ;
      private int[] P00747_A75DocumentoId ;
      private int[] P00747_A60SetorInternoId ;
      private int[] P00748_A75DocumentoId ;
      private int[] P00748_A63FonteRetencaoId ;
      private int[] P00749_A75DocumentoId ;
      private int[] P00749_A98DocDicionarioId ;
      private int[] P00749_A66CompartTercExternoId ;
      private int[] P007410_A75DocumentoId ;
      private int[] P007410_A98DocDicionarioId ;
      private int[] P007410_A4PaisId ;
      private int[] P007411_A75DocumentoId ;
      private int[] P007411_A98DocDicionarioId ;
      private int[] P007412_A75DocumentoId ;
      private int[] P007412_A93DocAnexoId ;
      private bool aP1_IsOk ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV28GXV1 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV31GXV3 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV34GXV5 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV37GXV7 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV40GXV9 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV43GXV11 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV46GXV13 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV49GXV15 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV52GXV17 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV55GXV19 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV58GXV21 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV60GXV23 ;
      private SdtRevisaoLog AV10RevisaoLog ;
      private GeneXus.Utils.SdtMessages_Message AV12Message ;
      private SdtDocEnvolvidosColeta AV11DocEnvolvidosColeta ;
      private SdtDocOperador AV13DocOperador ;
      private SdtDocCompartInterno AV14DocCompartInterno ;
      private SdtDocSetorInterno AV15DocSetorInterno ;
      private SdtDocFonteRetencao AV16DocFonteRetencao ;
      private SdtDocDicionario AV17DocDicionario ;
      private SdtDocAnexo AV18DocAnexo ;
      private SdtDocumento AV19Documento ;
      private SdtDicionarioCompartTercExt AV20DicionarioCompartTercExt ;
      private SdtDocMedidaSeguranca AV22DocMedidaSeguranca ;
      private SdtDicionarioPais AV24DicionarioPais ;
   }

   public class documentoexclui__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class documentoexclui__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP00742;
        prmP00742 = new Object[] {
        new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmP00743;
        prmP00743 = new Object[] {
        new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmP00744;
        prmP00744 = new Object[] {
        new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmP00745;
        prmP00745 = new Object[] {
        new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmP00746;
        prmP00746 = new Object[] {
        new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmP00747;
        prmP00747 = new Object[] {
        new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmP00748;
        prmP00748 = new Object[] {
        new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmP00749;
        prmP00749 = new Object[] {
        new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmP007410;
        prmP007410 = new Object[] {
        new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmP007411;
        prmP007411 = new Object[] {
        new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmP007412;
        prmP007412 = new Object[] {
        new ParDef("@AV8DocumentoId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00742", "SELECT [DocumentoId], [RevisaoLogId] FROM [RevisaoLog] WHERE [DocumentoId] = @AV8DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00742,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00743", "SELECT [DocumentoId], [DocOperadorId] FROM [DocOperador] WHERE [DocumentoId] = @AV8DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00743,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00744", "SELECT [DocumentoId], [EnvolvidosColetaId] FROM [DocEnvolvidosColeta] WHERE [DocumentoId] = @AV8DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00744,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00745", "SELECT [DocumentoId], [MedidaSegurancaId] FROM [DocMedidaSeguranca] WHERE [DocumentoId] = @AV8DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00745,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00746", "SELECT [DocumentoId], [CompartInternoId] FROM [DocCompartInterno] WHERE [DocumentoId] = @AV8DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00746,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00747", "SELECT [DocumentoId], [SetorInternoId] FROM [DocSetorInterno] WHERE [DocumentoId] = @AV8DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00747,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00748", "SELECT [DocumentoId], [FonteRetencaoId] FROM [DocFonteRetencao] WHERE [DocumentoId] = @AV8DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00748,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00749", "SELECT T2.[DocumentoId], T1.[DocDicionarioId], T1.[CompartTercExternoId] FROM ([DicionarioCompartTercExt] T1 INNER JOIN [DocDicionario] T2 ON T2.[DocDicionarioId] = T1.[DocDicionarioId]) WHERE T2.[DocumentoId] = @AV8DocumentoId ORDER BY T1.[CompartTercExternoId], T1.[DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00749,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P007410", "SELECT T2.[DocumentoId], T1.[DocDicionarioId], T1.[PaisId] FROM ([DicionarioPais] T1 INNER JOIN [DocDicionario] T2 ON T2.[DocDicionarioId] = T1.[DocDicionarioId]) WHERE T2.[DocumentoId] = @AV8DocumentoId ORDER BY T1.[PaisId], T1.[DocDicionarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007410,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P007411", "SELECT [DocumentoId], [DocDicionarioId] FROM [DocDicionario] WHERE [DocumentoId] = @AV8DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007411,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P007412", "SELECT [DocumentoId], [DocAnexoId] FROM [DocAnexo] WHERE [DocumentoId] = @AV8DocumentoId ORDER BY [DocumentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007412,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
     }
  }

}

}
