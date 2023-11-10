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
   public class parametro_bc : GXHttpHandler, IGxSilentTrn
   {
      public parametro_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public parametro_bc( IGxContext context )
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
         ReadRow1D56( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1D56( ) ;
         standaloneModal( ) ;
         AddRow1D56( ) ;
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
            E111D2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z124ParametroCod = A124ParametroCod;
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

      protected void CONFIRM_1D0( )
      {
         BeforeValidate1D56( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1D56( ) ;
            }
            else
            {
               CheckExtendedTable1D56( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1D56( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E121D2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E111D2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1D56( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z129ParametroDataAlteracao = A129ParametroDataAlteracao;
            Z131ParametroUsuarioAlteracao = A131ParametroUsuarioAlteracao;
            Z125ParametroDescricao = A125ParametroDescricao;
            Z126ParametroValor = A126ParametroValor;
            Z127ParametroComentario = A127ParametroComentario;
            Z128ParametroDataInclusao = A128ParametroDataInclusao;
            Z130ParametroUsuarioInclusao = A130ParametroUsuarioInclusao;
            Z132ParametroAtivo = A132ParametroAtivo;
         }
         if ( GX_JID == -11 )
         {
            Z124ParametroCod = A124ParametroCod;
            Z129ParametroDataAlteracao = A129ParametroDataAlteracao;
            Z131ParametroUsuarioAlteracao = A131ParametroUsuarioAlteracao;
            Z125ParametroDescricao = A125ParametroDescricao;
            Z126ParametroValor = A126ParametroValor;
            Z127ParametroComentario = A127ParametroComentario;
            Z128ParametroDataInclusao = A128ParametroDataInclusao;
            Z130ParametroUsuarioInclusao = A130ParametroUsuarioInclusao;
            Z132ParametroAtivo = A132ParametroAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A132ParametroAtivo) && ( Gx_BScreen == 0 ) )
         {
            A132ParametroAtivo = true;
         }
         if ( IsIns( )  && (DateTime.MinValue==A128ParametroDataInclusao) && ( Gx_BScreen == 0 ) )
         {
            A128ParametroDataInclusao = DateTimeUtil.Today( context);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A130ParametroUsuarioInclusao)) && ( Gx_BScreen == 0 ) )
         {
            A130ParametroUsuarioInclusao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1D56( )
      {
         /* Using cursor BC001D4 */
         pr_default.execute(2, new Object[] {A124ParametroCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound56 = 1;
            A129ParametroDataAlteracao = BC001D4_A129ParametroDataAlteracao[0];
            A131ParametroUsuarioAlteracao = BC001D4_A131ParametroUsuarioAlteracao[0];
            A125ParametroDescricao = BC001D4_A125ParametroDescricao[0];
            A126ParametroValor = BC001D4_A126ParametroValor[0];
            A127ParametroComentario = BC001D4_A127ParametroComentario[0];
            A128ParametroDataInclusao = BC001D4_A128ParametroDataInclusao[0];
            A130ParametroUsuarioInclusao = BC001D4_A130ParametroUsuarioInclusao[0];
            A132ParametroAtivo = BC001D4_A132ParametroAtivo[0];
            ZM1D56( -11) ;
         }
         pr_default.close(2);
         OnLoadActions1D56( ) ;
      }

      protected void OnLoadActions1D56( )
      {
      }

      protected void CheckExtendedTable1D56( )
      {
         nIsDirty_56 = 0;
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A124ParametroCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Parametro Cod", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A125ParametroDescricao)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Parametro Descricao", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A126ParametroValor)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Parametro Valor", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A128ParametroDataInclusao) || ( DateTimeUtil.ResetTime ( A128ParametroDataInclusao ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Parametro Data Inclusao fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A129ParametroDataAlteracao) || ( DateTimeUtil.ResetTime ( A129ParametroDataAlteracao ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Parametro Data Alteracao fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1D56( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1D56( )
      {
         /* Using cursor BC001D5 */
         pr_default.execute(3, new Object[] {A124ParametroCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound56 = 1;
         }
         else
         {
            RcdFound56 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001D3 */
         pr_default.execute(1, new Object[] {A124ParametroCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1D56( 11) ;
            RcdFound56 = 1;
            A124ParametroCod = BC001D3_A124ParametroCod[0];
            A129ParametroDataAlteracao = BC001D3_A129ParametroDataAlteracao[0];
            A131ParametroUsuarioAlteracao = BC001D3_A131ParametroUsuarioAlteracao[0];
            A125ParametroDescricao = BC001D3_A125ParametroDescricao[0];
            A126ParametroValor = BC001D3_A126ParametroValor[0];
            A127ParametroComentario = BC001D3_A127ParametroComentario[0];
            A128ParametroDataInclusao = BC001D3_A128ParametroDataInclusao[0];
            A130ParametroUsuarioInclusao = BC001D3_A130ParametroUsuarioInclusao[0];
            A132ParametroAtivo = BC001D3_A132ParametroAtivo[0];
            Z124ParametroCod = A124ParametroCod;
            sMode56 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1D56( ) ;
            if ( AnyError == 1 )
            {
               RcdFound56 = 0;
               InitializeNonKey1D56( ) ;
            }
            Gx_mode = sMode56;
         }
         else
         {
            RcdFound56 = 0;
            InitializeNonKey1D56( ) ;
            sMode56 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode56;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1D56( ) ;
         if ( RcdFound56 == 0 )
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
         CONFIRM_1D0( ) ;
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

      protected void CheckOptimisticConcurrency1D56( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001D2 */
            pr_default.execute(0, new Object[] {A124ParametroCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Parametro"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z129ParametroDataAlteracao ) != DateTimeUtil.ResetTime ( BC001D2_A129ParametroDataAlteracao[0] ) ) || ( StringUtil.StrCmp(Z131ParametroUsuarioAlteracao, BC001D2_A131ParametroUsuarioAlteracao[0]) != 0 ) || ( StringUtil.StrCmp(Z125ParametroDescricao, BC001D2_A125ParametroDescricao[0]) != 0 ) || ( StringUtil.StrCmp(Z126ParametroValor, BC001D2_A126ParametroValor[0]) != 0 ) || ( StringUtil.StrCmp(Z127ParametroComentario, BC001D2_A127ParametroComentario[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z128ParametroDataInclusao ) != DateTimeUtil.ResetTime ( BC001D2_A128ParametroDataInclusao[0] ) ) || ( StringUtil.StrCmp(Z130ParametroUsuarioInclusao, BC001D2_A130ParametroUsuarioInclusao[0]) != 0 ) || ( Z132ParametroAtivo != BC001D2_A132ParametroAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Parametro"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1D56( )
      {
         BeforeValidate1D56( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1D56( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1D56( 0) ;
            CheckOptimisticConcurrency1D56( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1D56( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1D56( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001D6 */
                     pr_default.execute(4, new Object[] {A124ParametroCod, A129ParametroDataAlteracao, A131ParametroUsuarioAlteracao, A125ParametroDescricao, A126ParametroValor, A127ParametroComentario, A128ParametroDataInclusao, A130ParametroUsuarioInclusao, A132ParametroAtivo});
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("Parametro");
                     if ( (pr_default.getStatus(4) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
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
               Load1D56( ) ;
            }
            EndLevel1D56( ) ;
         }
         CloseExtendedTableCursors1D56( ) ;
      }

      protected void Update1D56( )
      {
         BeforeValidate1D56( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1D56( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1D56( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1D56( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1D56( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001D7 */
                     pr_default.execute(5, new Object[] {A129ParametroDataAlteracao, A131ParametroUsuarioAlteracao, A125ParametroDescricao, A126ParametroValor, A127ParametroComentario, A128ParametroDataInclusao, A130ParametroUsuarioInclusao, A132ParametroAtivo, A124ParametroCod});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("Parametro");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Parametro"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1D56( ) ;
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
            EndLevel1D56( ) ;
         }
         CloseExtendedTableCursors1D56( ) ;
      }

      protected void DeferredUpdate1D56( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1D56( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1D56( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1D56( ) ;
            AfterConfirm1D56( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1D56( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001D8 */
                  pr_default.execute(6, new Object[] {A124ParametroCod});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("Parametro");
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
         sMode56 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1D56( ) ;
         Gx_mode = sMode56;
      }

      protected void OnDeleteControls1D56( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1D56( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1D56( ) ;
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

      public void ScanKeyStart1D56( )
      {
         /* Scan By routine */
         /* Using cursor BC001D9 */
         pr_default.execute(7, new Object[] {A124ParametroCod});
         RcdFound56 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound56 = 1;
            A124ParametroCod = BC001D9_A124ParametroCod[0];
            A129ParametroDataAlteracao = BC001D9_A129ParametroDataAlteracao[0];
            A131ParametroUsuarioAlteracao = BC001D9_A131ParametroUsuarioAlteracao[0];
            A125ParametroDescricao = BC001D9_A125ParametroDescricao[0];
            A126ParametroValor = BC001D9_A126ParametroValor[0];
            A127ParametroComentario = BC001D9_A127ParametroComentario[0];
            A128ParametroDataInclusao = BC001D9_A128ParametroDataInclusao[0];
            A130ParametroUsuarioInclusao = BC001D9_A130ParametroUsuarioInclusao[0];
            A132ParametroAtivo = BC001D9_A132ParametroAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1D56( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound56 = 0;
         ScanKeyLoad1D56( ) ;
      }

      protected void ScanKeyLoad1D56( )
      {
         sMode56 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound56 = 1;
            A124ParametroCod = BC001D9_A124ParametroCod[0];
            A129ParametroDataAlteracao = BC001D9_A129ParametroDataAlteracao[0];
            A131ParametroUsuarioAlteracao = BC001D9_A131ParametroUsuarioAlteracao[0];
            A125ParametroDescricao = BC001D9_A125ParametroDescricao[0];
            A126ParametroValor = BC001D9_A126ParametroValor[0];
            A127ParametroComentario = BC001D9_A127ParametroComentario[0];
            A128ParametroDataInclusao = BC001D9_A128ParametroDataInclusao[0];
            A130ParametroUsuarioInclusao = BC001D9_A130ParametroUsuarioInclusao[0];
            A132ParametroAtivo = BC001D9_A132ParametroAtivo[0];
         }
         Gx_mode = sMode56;
      }

      protected void ScanKeyEnd1D56( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm1D56( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1D56( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1D56( )
      {
         /* Before Update Rules */
         A129ParametroDataAlteracao = DateTimeUtil.Today( context);
         A131ParametroUsuarioAlteracao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
      }

      protected void BeforeDelete1D56( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1D56( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1D56( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1D56( )
      {
      }

      protected void send_integrity_lvl_hashes1D56( )
      {
      }

      protected void AddRow1D56( )
      {
         VarsToRow56( bcParametro) ;
      }

      protected void ReadRow1D56( )
      {
         RowToVars56( bcParametro, 1) ;
      }

      protected void InitializeNonKey1D56( )
      {
         A129ParametroDataAlteracao = DateTime.MinValue;
         A131ParametroUsuarioAlteracao = "";
         A125ParametroDescricao = "";
         A126ParametroValor = "";
         A127ParametroComentario = "";
         A128ParametroDataInclusao = DateTimeUtil.Today( context);
         A130ParametroUsuarioInclusao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         A132ParametroAtivo = true;
         Z129ParametroDataAlteracao = DateTime.MinValue;
         Z131ParametroUsuarioAlteracao = "";
         Z125ParametroDescricao = "";
         Z126ParametroValor = "";
         Z127ParametroComentario = "";
         Z128ParametroDataInclusao = DateTime.MinValue;
         Z130ParametroUsuarioInclusao = "";
         Z132ParametroAtivo = false;
      }

      protected void InitAll1D56( )
      {
         A124ParametroCod = "";
         InitializeNonKey1D56( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A132ParametroAtivo = i132ParametroAtivo;
         A128ParametroDataInclusao = i128ParametroDataInclusao;
         A130ParametroUsuarioInclusao = i130ParametroUsuarioInclusao;
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

      public void VarsToRow56( SdtParametro obj56 )
      {
         obj56.gxTpr_Mode = Gx_mode;
         obj56.gxTpr_Parametrodataalteracao = A129ParametroDataAlteracao;
         obj56.gxTpr_Parametrousuarioalteracao = A131ParametroUsuarioAlteracao;
         obj56.gxTpr_Parametrodescricao = A125ParametroDescricao;
         obj56.gxTpr_Parametrovalor = A126ParametroValor;
         obj56.gxTpr_Parametrocomentario = A127ParametroComentario;
         obj56.gxTpr_Parametrodatainclusao = A128ParametroDataInclusao;
         obj56.gxTpr_Parametrousuarioinclusao = A130ParametroUsuarioInclusao;
         obj56.gxTpr_Parametroativo = A132ParametroAtivo;
         obj56.gxTpr_Parametrocod = A124ParametroCod;
         obj56.gxTpr_Parametrocod_Z = Z124ParametroCod;
         obj56.gxTpr_Parametrodescricao_Z = Z125ParametroDescricao;
         obj56.gxTpr_Parametrovalor_Z = Z126ParametroValor;
         obj56.gxTpr_Parametrocomentario_Z = Z127ParametroComentario;
         obj56.gxTpr_Parametrodatainclusao_Z = Z128ParametroDataInclusao;
         obj56.gxTpr_Parametrodataalteracao_Z = Z129ParametroDataAlteracao;
         obj56.gxTpr_Parametrousuarioinclusao_Z = Z130ParametroUsuarioInclusao;
         obj56.gxTpr_Parametrousuarioalteracao_Z = Z131ParametroUsuarioAlteracao;
         obj56.gxTpr_Parametroativo_Z = Z132ParametroAtivo;
         obj56.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow56( SdtParametro obj56 )
      {
         obj56.gxTpr_Parametrocod = A124ParametroCod;
         return  ;
      }

      public void RowToVars56( SdtParametro obj56 ,
                               int forceLoad )
      {
         Gx_mode = obj56.gxTpr_Mode;
         A129ParametroDataAlteracao = obj56.gxTpr_Parametrodataalteracao;
         A131ParametroUsuarioAlteracao = obj56.gxTpr_Parametrousuarioalteracao;
         A125ParametroDescricao = obj56.gxTpr_Parametrodescricao;
         A126ParametroValor = obj56.gxTpr_Parametrovalor;
         A127ParametroComentario = obj56.gxTpr_Parametrocomentario;
         A128ParametroDataInclusao = obj56.gxTpr_Parametrodatainclusao;
         A130ParametroUsuarioInclusao = obj56.gxTpr_Parametrousuarioinclusao;
         A132ParametroAtivo = obj56.gxTpr_Parametroativo;
         A124ParametroCod = obj56.gxTpr_Parametrocod;
         Z124ParametroCod = obj56.gxTpr_Parametrocod_Z;
         Z125ParametroDescricao = obj56.gxTpr_Parametrodescricao_Z;
         Z126ParametroValor = obj56.gxTpr_Parametrovalor_Z;
         Z127ParametroComentario = obj56.gxTpr_Parametrocomentario_Z;
         Z128ParametroDataInclusao = obj56.gxTpr_Parametrodatainclusao_Z;
         Z129ParametroDataAlteracao = obj56.gxTpr_Parametrodataalteracao_Z;
         Z130ParametroUsuarioInclusao = obj56.gxTpr_Parametrousuarioinclusao_Z;
         Z131ParametroUsuarioAlteracao = obj56.gxTpr_Parametrousuarioalteracao_Z;
         Z132ParametroAtivo = obj56.gxTpr_Parametroativo_Z;
         Gx_mode = obj56.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A124ParametroCod = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1D56( ) ;
         ScanKeyStart1D56( ) ;
         if ( RcdFound56 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z124ParametroCod = A124ParametroCod;
         }
         ZM1D56( -11) ;
         OnLoadActions1D56( ) ;
         AddRow1D56( ) ;
         ScanKeyEnd1D56( ) ;
         if ( RcdFound56 == 0 )
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
         RowToVars56( bcParametro, 0) ;
         ScanKeyStart1D56( ) ;
         if ( RcdFound56 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z124ParametroCod = A124ParametroCod;
         }
         ZM1D56( -11) ;
         OnLoadActions1D56( ) ;
         AddRow1D56( ) ;
         ScanKeyEnd1D56( ) ;
         if ( RcdFound56 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey1D56( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1D56( ) ;
         }
         else
         {
            if ( RcdFound56 == 1 )
            {
               if ( StringUtil.StrCmp(A124ParametroCod, Z124ParametroCod) != 0 )
               {
                  A124ParametroCod = Z124ParametroCod;
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
                  Update1D56( ) ;
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
                  if ( StringUtil.StrCmp(A124ParametroCod, Z124ParametroCod) != 0 )
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
                        Insert1D56( ) ;
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
                        Insert1D56( ) ;
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
         RowToVars56( bcParametro, 1) ;
         SaveImpl( ) ;
         VarsToRow56( bcParametro) ;
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
         RowToVars56( bcParametro, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1D56( ) ;
         AfterTrn( ) ;
         VarsToRow56( bcParametro) ;
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
            SdtParametro auxBC = new SdtParametro(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A124ParametroCod);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcParametro);
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
         RowToVars56( bcParametro, 1) ;
         UpdateImpl( ) ;
         VarsToRow56( bcParametro) ;
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
         RowToVars56( bcParametro, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1D56( ) ;
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
         VarsToRow56( bcParametro) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars56( bcParametro, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey1D56( ) ;
         if ( RcdFound56 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A124ParametroCod, Z124ParametroCod) != 0 )
            {
               A124ParametroCod = Z124ParametroCod;
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
            if ( StringUtil.StrCmp(A124ParametroCod, Z124ParametroCod) != 0 )
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
         context.RollbackDataStores("parametro_bc",pr_default);
         VarsToRow56( bcParametro) ;
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
         Gx_mode = bcParametro.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcParametro.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcParametro )
         {
            bcParametro = (SdtParametro)(sdt);
            if ( StringUtil.StrCmp(bcParametro.gxTpr_Mode, "") == 0 )
            {
               bcParametro.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow56( bcParametro) ;
            }
            else
            {
               RowToVars56( bcParametro, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcParametro.gxTpr_Mode, "") == 0 )
            {
               bcParametro.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars56( bcParametro, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtParametro Parametro_BC
      {
         get {
            return bcParametro ;
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
            return "parametro_Execute" ;
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
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z124ParametroCod = "";
         A124ParametroCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z129ParametroDataAlteracao = DateTime.MinValue;
         A129ParametroDataAlteracao = DateTime.MinValue;
         Z131ParametroUsuarioAlteracao = "";
         A131ParametroUsuarioAlteracao = "";
         Z125ParametroDescricao = "";
         A125ParametroDescricao = "";
         Z126ParametroValor = "";
         A126ParametroValor = "";
         Z127ParametroComentario = "";
         A127ParametroComentario = "";
         Z128ParametroDataInclusao = DateTime.MinValue;
         A128ParametroDataInclusao = DateTime.MinValue;
         Z130ParametroUsuarioInclusao = "";
         A130ParametroUsuarioInclusao = "";
         BC001D4_A124ParametroCod = new string[] {""} ;
         BC001D4_A129ParametroDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         BC001D4_A131ParametroUsuarioAlteracao = new string[] {""} ;
         BC001D4_A125ParametroDescricao = new string[] {""} ;
         BC001D4_A126ParametroValor = new string[] {""} ;
         BC001D4_A127ParametroComentario = new string[] {""} ;
         BC001D4_A128ParametroDataInclusao = new DateTime[] {DateTime.MinValue} ;
         BC001D4_A130ParametroUsuarioInclusao = new string[] {""} ;
         BC001D4_A132ParametroAtivo = new bool[] {false} ;
         BC001D5_A124ParametroCod = new string[] {""} ;
         BC001D3_A124ParametroCod = new string[] {""} ;
         BC001D3_A129ParametroDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         BC001D3_A131ParametroUsuarioAlteracao = new string[] {""} ;
         BC001D3_A125ParametroDescricao = new string[] {""} ;
         BC001D3_A126ParametroValor = new string[] {""} ;
         BC001D3_A127ParametroComentario = new string[] {""} ;
         BC001D3_A128ParametroDataInclusao = new DateTime[] {DateTime.MinValue} ;
         BC001D3_A130ParametroUsuarioInclusao = new string[] {""} ;
         BC001D3_A132ParametroAtivo = new bool[] {false} ;
         sMode56 = "";
         BC001D2_A124ParametroCod = new string[] {""} ;
         BC001D2_A129ParametroDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         BC001D2_A131ParametroUsuarioAlteracao = new string[] {""} ;
         BC001D2_A125ParametroDescricao = new string[] {""} ;
         BC001D2_A126ParametroValor = new string[] {""} ;
         BC001D2_A127ParametroComentario = new string[] {""} ;
         BC001D2_A128ParametroDataInclusao = new DateTime[] {DateTime.MinValue} ;
         BC001D2_A130ParametroUsuarioInclusao = new string[] {""} ;
         BC001D2_A132ParametroAtivo = new bool[] {false} ;
         BC001D9_A124ParametroCod = new string[] {""} ;
         BC001D9_A129ParametroDataAlteracao = new DateTime[] {DateTime.MinValue} ;
         BC001D9_A131ParametroUsuarioAlteracao = new string[] {""} ;
         BC001D9_A125ParametroDescricao = new string[] {""} ;
         BC001D9_A126ParametroValor = new string[] {""} ;
         BC001D9_A127ParametroComentario = new string[] {""} ;
         BC001D9_A128ParametroDataInclusao = new DateTime[] {DateTime.MinValue} ;
         BC001D9_A130ParametroUsuarioInclusao = new string[] {""} ;
         BC001D9_A132ParametroAtivo = new bool[] {false} ;
         i128ParametroDataInclusao = DateTime.MinValue;
         i130ParametroUsuarioInclusao = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.parametro_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.parametro_bc__default(),
            new Object[][] {
                new Object[] {
               BC001D2_A124ParametroCod, BC001D2_A129ParametroDataAlteracao, BC001D2_A131ParametroUsuarioAlteracao, BC001D2_A125ParametroDescricao, BC001D2_A126ParametroValor, BC001D2_A127ParametroComentario, BC001D2_A128ParametroDataInclusao, BC001D2_A130ParametroUsuarioInclusao, BC001D2_A132ParametroAtivo
               }
               , new Object[] {
               BC001D3_A124ParametroCod, BC001D3_A129ParametroDataAlteracao, BC001D3_A131ParametroUsuarioAlteracao, BC001D3_A125ParametroDescricao, BC001D3_A126ParametroValor, BC001D3_A127ParametroComentario, BC001D3_A128ParametroDataInclusao, BC001D3_A130ParametroUsuarioInclusao, BC001D3_A132ParametroAtivo
               }
               , new Object[] {
               BC001D4_A124ParametroCod, BC001D4_A129ParametroDataAlteracao, BC001D4_A131ParametroUsuarioAlteracao, BC001D4_A125ParametroDescricao, BC001D4_A126ParametroValor, BC001D4_A127ParametroComentario, BC001D4_A128ParametroDataInclusao, BC001D4_A130ParametroUsuarioInclusao, BC001D4_A132ParametroAtivo
               }
               , new Object[] {
               BC001D5_A124ParametroCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001D9_A124ParametroCod, BC001D9_A129ParametroDataAlteracao, BC001D9_A131ParametroUsuarioAlteracao, BC001D9_A125ParametroDescricao, BC001D9_A126ParametroValor, BC001D9_A127ParametroComentario, BC001D9_A128ParametroDataInclusao, BC001D9_A130ParametroUsuarioInclusao, BC001D9_A132ParametroAtivo
               }
            }
         );
         Z130ParametroUsuarioInclusao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         A130ParametroUsuarioInclusao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         i130ParametroUsuarioInclusao = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         Z128ParametroDataInclusao = DateTimeUtil.Today( context);
         A128ParametroDataInclusao = DateTimeUtil.Today( context);
         i128ParametroDataInclusao = DateTimeUtil.Today( context);
         Z132ParametroAtivo = true;
         A132ParametroAtivo = true;
         i132ParametroAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121D2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound56 ;
      private short nIsDirty_56 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z124ParametroCod ;
      private string A124ParametroCod ;
      private string Z131ParametroUsuarioAlteracao ;
      private string A131ParametroUsuarioAlteracao ;
      private string Z130ParametroUsuarioInclusao ;
      private string A130ParametroUsuarioInclusao ;
      private string sMode56 ;
      private string i130ParametroUsuarioInclusao ;
      private DateTime Z129ParametroDataAlteracao ;
      private DateTime A129ParametroDataAlteracao ;
      private DateTime Z128ParametroDataInclusao ;
      private DateTime A128ParametroDataInclusao ;
      private DateTime i128ParametroDataInclusao ;
      private bool returnInSub ;
      private bool Z132ParametroAtivo ;
      private bool A132ParametroAtivo ;
      private bool Gx_longc ;
      private bool i132ParametroAtivo ;
      private bool mustCommit ;
      private string Z125ParametroDescricao ;
      private string A125ParametroDescricao ;
      private string Z126ParametroValor ;
      private string A126ParametroValor ;
      private string Z127ParametroComentario ;
      private string A127ParametroComentario ;
      private IGxSession AV12WebSession ;
      private SdtParametro bcParametro ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC001D4_A124ParametroCod ;
      private DateTime[] BC001D4_A129ParametroDataAlteracao ;
      private string[] BC001D4_A131ParametroUsuarioAlteracao ;
      private string[] BC001D4_A125ParametroDescricao ;
      private string[] BC001D4_A126ParametroValor ;
      private string[] BC001D4_A127ParametroComentario ;
      private DateTime[] BC001D4_A128ParametroDataInclusao ;
      private string[] BC001D4_A130ParametroUsuarioInclusao ;
      private bool[] BC001D4_A132ParametroAtivo ;
      private string[] BC001D5_A124ParametroCod ;
      private string[] BC001D3_A124ParametroCod ;
      private DateTime[] BC001D3_A129ParametroDataAlteracao ;
      private string[] BC001D3_A131ParametroUsuarioAlteracao ;
      private string[] BC001D3_A125ParametroDescricao ;
      private string[] BC001D3_A126ParametroValor ;
      private string[] BC001D3_A127ParametroComentario ;
      private DateTime[] BC001D3_A128ParametroDataInclusao ;
      private string[] BC001D3_A130ParametroUsuarioInclusao ;
      private bool[] BC001D3_A132ParametroAtivo ;
      private string[] BC001D2_A124ParametroCod ;
      private DateTime[] BC001D2_A129ParametroDataAlteracao ;
      private string[] BC001D2_A131ParametroUsuarioAlteracao ;
      private string[] BC001D2_A125ParametroDescricao ;
      private string[] BC001D2_A126ParametroValor ;
      private string[] BC001D2_A127ParametroComentario ;
      private DateTime[] BC001D2_A128ParametroDataInclusao ;
      private string[] BC001D2_A130ParametroUsuarioInclusao ;
      private bool[] BC001D2_A132ParametroAtivo ;
      private string[] BC001D9_A124ParametroCod ;
      private DateTime[] BC001D9_A129ParametroDataAlteracao ;
      private string[] BC001D9_A131ParametroUsuarioAlteracao ;
      private string[] BC001D9_A125ParametroDescricao ;
      private string[] BC001D9_A126ParametroValor ;
      private string[] BC001D9_A127ParametroComentario ;
      private DateTime[] BC001D9_A128ParametroDataInclusao ;
      private string[] BC001D9_A130ParametroUsuarioInclusao ;
      private bool[] BC001D9_A132ParametroAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class parametro_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class parametro_bc__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new UpdateCursor(def[4])
       ,new UpdateCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new ForEachCursor(def[7])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC001D4;
        prmBC001D4 = new Object[] {
        new ParDef("@ParametroCod",GXType.NChar,10,0)
        };
        Object[] prmBC001D5;
        prmBC001D5 = new Object[] {
        new ParDef("@ParametroCod",GXType.NChar,10,0)
        };
        Object[] prmBC001D3;
        prmBC001D3 = new Object[] {
        new ParDef("@ParametroCod",GXType.NChar,10,0)
        };
        Object[] prmBC001D2;
        prmBC001D2 = new Object[] {
        new ParDef("@ParametroCod",GXType.NChar,10,0)
        };
        Object[] prmBC001D6;
        prmBC001D6 = new Object[] {
        new ParDef("@ParametroCod",GXType.NChar,10,0) ,
        new ParDef("@ParametroDataAlteracao",GXType.Date,8,0) ,
        new ParDef("@ParametroUsuarioAlteracao",GXType.NChar,20,0) ,
        new ParDef("@ParametroDescricao",GXType.NVarChar,100,0) ,
        new ParDef("@ParametroValor",GXType.NVarChar,100,0) ,
        new ParDef("@ParametroComentario",GXType.NVarChar,500,0) ,
        new ParDef("@ParametroDataInclusao",GXType.Date,8,0) ,
        new ParDef("@ParametroUsuarioInclusao",GXType.NChar,20,0) ,
        new ParDef("@ParametroAtivo",GXType.Boolean,4,0)
        };
        Object[] prmBC001D7;
        prmBC001D7 = new Object[] {
        new ParDef("@ParametroDataAlteracao",GXType.Date,8,0) ,
        new ParDef("@ParametroUsuarioAlteracao",GXType.NChar,20,0) ,
        new ParDef("@ParametroDescricao",GXType.NVarChar,100,0) ,
        new ParDef("@ParametroValor",GXType.NVarChar,100,0) ,
        new ParDef("@ParametroComentario",GXType.NVarChar,500,0) ,
        new ParDef("@ParametroDataInclusao",GXType.Date,8,0) ,
        new ParDef("@ParametroUsuarioInclusao",GXType.NChar,20,0) ,
        new ParDef("@ParametroAtivo",GXType.Boolean,4,0) ,
        new ParDef("@ParametroCod",GXType.NChar,10,0)
        };
        Object[] prmBC001D8;
        prmBC001D8 = new Object[] {
        new ParDef("@ParametroCod",GXType.NChar,10,0)
        };
        Object[] prmBC001D9;
        prmBC001D9 = new Object[] {
        new ParDef("@ParametroCod",GXType.NChar,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC001D2", "SELECT [ParametroCod], [ParametroDataAlteracao], [ParametroUsuarioAlteracao], [ParametroDescricao], [ParametroValor], [ParametroComentario], [ParametroDataInclusao], [ParametroUsuarioInclusao], [ParametroAtivo] FROM [Parametro] WITH (UPDLOCK) WHERE [ParametroCod] = @ParametroCod ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001D2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001D3", "SELECT [ParametroCod], [ParametroDataAlteracao], [ParametroUsuarioAlteracao], [ParametroDescricao], [ParametroValor], [ParametroComentario], [ParametroDataInclusao], [ParametroUsuarioInclusao], [ParametroAtivo] FROM [Parametro] WHERE [ParametroCod] = @ParametroCod ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001D3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001D4", "SELECT TM1.[ParametroCod], TM1.[ParametroDataAlteracao], TM1.[ParametroUsuarioAlteracao], TM1.[ParametroDescricao], TM1.[ParametroValor], TM1.[ParametroComentario], TM1.[ParametroDataInclusao], TM1.[ParametroUsuarioInclusao], TM1.[ParametroAtivo] FROM [Parametro] TM1 WHERE TM1.[ParametroCod] = @ParametroCod ORDER BY TM1.[ParametroCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001D4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001D5", "SELECT [ParametroCod] FROM [Parametro] WHERE [ParametroCod] = @ParametroCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001D5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001D6", "INSERT INTO [Parametro]([ParametroCod], [ParametroDataAlteracao], [ParametroUsuarioAlteracao], [ParametroDescricao], [ParametroValor], [ParametroComentario], [ParametroDataInclusao], [ParametroUsuarioInclusao], [ParametroAtivo]) VALUES(@ParametroCod, @ParametroDataAlteracao, @ParametroUsuarioAlteracao, @ParametroDescricao, @ParametroValor, @ParametroComentario, @ParametroDataInclusao, @ParametroUsuarioInclusao, @ParametroAtivo)", GxErrorMask.GX_NOMASK,prmBC001D6)
           ,new CursorDef("BC001D7", "UPDATE [Parametro] SET [ParametroDataAlteracao]=@ParametroDataAlteracao, [ParametroUsuarioAlteracao]=@ParametroUsuarioAlteracao, [ParametroDescricao]=@ParametroDescricao, [ParametroValor]=@ParametroValor, [ParametroComentario]=@ParametroComentario, [ParametroDataInclusao]=@ParametroDataInclusao, [ParametroUsuarioInclusao]=@ParametroUsuarioInclusao, [ParametroAtivo]=@ParametroAtivo  WHERE [ParametroCod] = @ParametroCod", GxErrorMask.GX_NOMASK,prmBC001D7)
           ,new CursorDef("BC001D8", "DELETE FROM [Parametro]  WHERE [ParametroCod] = @ParametroCod", GxErrorMask.GX_NOMASK,prmBC001D8)
           ,new CursorDef("BC001D9", "SELECT TM1.[ParametroCod], TM1.[ParametroDataAlteracao], TM1.[ParametroUsuarioAlteracao], TM1.[ParametroDescricao], TM1.[ParametroValor], TM1.[ParametroComentario], TM1.[ParametroDataInclusao], TM1.[ParametroUsuarioInclusao], TM1.[ParametroAtivo] FROM [Parametro] TM1 WHERE TM1.[ParametroCod] = @ParametroCod ORDER BY TM1.[ParametroCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001D9,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              return;
     }
  }

}

}
