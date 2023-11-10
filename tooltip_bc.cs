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
   public class tooltip_bc : GXHttpHandler, IGxSilentTrn
   {
      public tooltip_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public tooltip_bc( IGxContext context )
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
         ReadRow1A53( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1A53( ) ;
         standaloneModal( ) ;
         AddRow1A53( ) ;
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
            E111A2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z112TooltipId = A112TooltipId;
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

      protected void CONFIRM_1A0( )
      {
         BeforeValidate1A53( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1A53( ) ;
            }
            else
            {
               CheckExtendedTable1A53( ) ;
               if ( AnyError == 0 )
               {
                  ZM1A53( 8) ;
                  ZM1A53( 9) ;
               }
               CloseExtendedTableCursors1A53( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E121A2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV30Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV31GXV1 = 1;
            while ( AV31GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV27TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV31GXV1));
               if ( StringUtil.StrCmp(AV27TrnContextAtt.gxTpr_Attributename, "CampoId") == 0 )
               {
                  AV26Insert_CampoId = (int)(NumberUtil.Val( AV27TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               else if ( StringUtil.StrCmp(AV27TrnContextAtt.gxTpr_Attributename, "TooltipTelaId") == 0 )
               {
                  AV28Insert_TooltipTelaId = (int)(NumberUtil.Val( AV27TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               AV31GXV1 = (int)(AV31GXV1+1);
            }
         }
      }

      protected void E111A2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1A53( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z118TooltipAtivo = A118TooltipAtivo;
            Z135CampoId = A135CampoId;
            Z139TooltipTelaId = A139TooltipTelaId;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z136CampoNome = A136CampoNome;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z140TooltipTelaNome = A140TooltipTelaNome;
         }
         if ( GX_JID == -7 )
         {
            Z112TooltipId = A112TooltipId;
            Z115TooltipDescricao = A115TooltipDescricao;
            Z118TooltipAtivo = A118TooltipAtivo;
            Z135CampoId = A135CampoId;
            Z139TooltipTelaId = A139TooltipTelaId;
            Z136CampoNome = A136CampoNome;
            Z140TooltipTelaNome = A140TooltipTelaNome;
         }
      }

      protected void standaloneNotModal( )
      {
         AV30Pgmname = "Tooltip_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A118TooltipAtivo) && ( Gx_BScreen == 0 ) )
         {
            A118TooltipAtivo = true;
         }
      }

      protected void Load1A53( )
      {
         /* Using cursor BC001A6 */
         pr_default.execute(4, new Object[] {A112TooltipId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound53 = 1;
            A115TooltipDescricao = BC001A6_A115TooltipDescricao[0];
            A118TooltipAtivo = BC001A6_A118TooltipAtivo[0];
            A136CampoNome = BC001A6_A136CampoNome[0];
            A140TooltipTelaNome = BC001A6_A140TooltipTelaNome[0];
            A135CampoId = BC001A6_A135CampoId[0];
            A139TooltipTelaId = BC001A6_A139TooltipTelaId[0];
            ZM1A53( -7) ;
         }
         pr_default.close(4);
         OnLoadActions1A53( ) ;
      }

      protected void OnLoadActions1A53( )
      {
         GXt_int1 = 0;
         new validatooltip(context ).execute(  A112TooltipId,  A139TooltipTelaId,  A135CampoId, out  GXt_int1) ;
         AV17tooltipexiste = (bool)(Convert.ToBoolean(GXt_int1));
         A115TooltipDescricao = StringUtil.Upper( A115TooltipDescricao);
      }

      protected void CheckExtendedTable1A53( )
      {
         nIsDirty_53 = 0;
         standaloneModal( ) ;
         GXt_int1 = 0;
         new validatooltip(context ).execute(  A112TooltipId,  A139TooltipTelaId,  A135CampoId, out  GXt_int1) ;
         AV17tooltipexiste = (bool)(Convert.ToBoolean(GXt_int1));
         if ( AV17tooltipexiste )
         {
            GX_msglist.addItem("Nome da tela e nome do campo já cadastrados, revise o cadastro.", 1, "");
            AnyError = 1;
         }
         nIsDirty_53 = 1;
         A115TooltipDescricao = StringUtil.Upper( A115TooltipDescricao);
         /* Using cursor BC001A4 */
         pr_default.execute(2, new Object[] {A135CampoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Campo'.", "ForeignKeyNotFound", 1, "CAMPOID");
            AnyError = 1;
         }
         A136CampoNome = BC001A4_A136CampoNome[0];
         pr_default.close(2);
         /* Using cursor BC001A5 */
         pr_default.execute(3, new Object[] {A139TooltipTelaId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Tooltip Tela'.", "ForeignKeyNotFound", 1, "TOOLTIPTELAID");
            AnyError = 1;
         }
         A140TooltipTelaNome = BC001A5_A140TooltipTelaNome[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1A53( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1A53( )
      {
         /* Using cursor BC001A7 */
         pr_default.execute(5, new Object[] {A112TooltipId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound53 = 1;
         }
         else
         {
            RcdFound53 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001A3 */
         pr_default.execute(1, new Object[] {A112TooltipId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1A53( 7) ;
            RcdFound53 = 1;
            A112TooltipId = BC001A3_A112TooltipId[0];
            A115TooltipDescricao = BC001A3_A115TooltipDescricao[0];
            A118TooltipAtivo = BC001A3_A118TooltipAtivo[0];
            A135CampoId = BC001A3_A135CampoId[0];
            A139TooltipTelaId = BC001A3_A139TooltipTelaId[0];
            Z112TooltipId = A112TooltipId;
            sMode53 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1A53( ) ;
            if ( AnyError == 1 )
            {
               RcdFound53 = 0;
               InitializeNonKey1A53( ) ;
            }
            Gx_mode = sMode53;
         }
         else
         {
            RcdFound53 = 0;
            InitializeNonKey1A53( ) ;
            sMode53 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode53;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1A53( ) ;
         if ( RcdFound53 == 0 )
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
         CONFIRM_1A0( ) ;
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

      protected void CheckOptimisticConcurrency1A53( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001A2 */
            pr_default.execute(0, new Object[] {A112TooltipId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Tooltip"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z118TooltipAtivo != BC001A2_A118TooltipAtivo[0] ) || ( Z135CampoId != BC001A2_A135CampoId[0] ) || ( Z139TooltipTelaId != BC001A2_A139TooltipTelaId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Tooltip"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1A53( )
      {
         BeforeValidate1A53( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1A53( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1A53( 0) ;
            CheckOptimisticConcurrency1A53( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1A53( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1A53( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001A8 */
                     pr_default.execute(6, new Object[] {A115TooltipDescricao, A118TooltipAtivo, A135CampoId, A139TooltipTelaId});
                     A112TooltipId = BC001A8_A112TooltipId[0];
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Tooltip");
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
               Load1A53( ) ;
            }
            EndLevel1A53( ) ;
         }
         CloseExtendedTableCursors1A53( ) ;
      }

      protected void Update1A53( )
      {
         BeforeValidate1A53( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1A53( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1A53( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1A53( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1A53( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001A9 */
                     pr_default.execute(7, new Object[] {A115TooltipDescricao, A118TooltipAtivo, A135CampoId, A139TooltipTelaId, A112TooltipId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Tooltip");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Tooltip"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1A53( ) ;
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
            EndLevel1A53( ) ;
         }
         CloseExtendedTableCursors1A53( ) ;
      }

      protected void DeferredUpdate1A53( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1A53( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1A53( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1A53( ) ;
            AfterConfirm1A53( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1A53( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001A10 */
                  pr_default.execute(8, new Object[] {A112TooltipId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("Tooltip");
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
         sMode53 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1A53( ) ;
         Gx_mode = sMode53;
      }

      protected void OnDeleteControls1A53( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001A11 */
            pr_default.execute(9, new Object[] {A135CampoId});
            A136CampoNome = BC001A11_A136CampoNome[0];
            pr_default.close(9);
            /* Using cursor BC001A12 */
            pr_default.execute(10, new Object[] {A139TooltipTelaId});
            A140TooltipTelaNome = BC001A12_A140TooltipTelaNome[0];
            pr_default.close(10);
            GXt_int1 = 0;
            new validatooltip(context ).execute(  A112TooltipId,  A139TooltipTelaId,  A135CampoId, out  GXt_int1) ;
            AV17tooltipexiste = (bool)(Convert.ToBoolean(GXt_int1));
         }
      }

      protected void EndLevel1A53( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1A53( ) ;
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

      public void ScanKeyStart1A53( )
      {
         /* Scan By routine */
         /* Using cursor BC001A13 */
         pr_default.execute(11, new Object[] {A112TooltipId});
         RcdFound53 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound53 = 1;
            A112TooltipId = BC001A13_A112TooltipId[0];
            A115TooltipDescricao = BC001A13_A115TooltipDescricao[0];
            A118TooltipAtivo = BC001A13_A118TooltipAtivo[0];
            A136CampoNome = BC001A13_A136CampoNome[0];
            A140TooltipTelaNome = BC001A13_A140TooltipTelaNome[0];
            A135CampoId = BC001A13_A135CampoId[0];
            A139TooltipTelaId = BC001A13_A139TooltipTelaId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1A53( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound53 = 0;
         ScanKeyLoad1A53( ) ;
      }

      protected void ScanKeyLoad1A53( )
      {
         sMode53 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound53 = 1;
            A112TooltipId = BC001A13_A112TooltipId[0];
            A115TooltipDescricao = BC001A13_A115TooltipDescricao[0];
            A118TooltipAtivo = BC001A13_A118TooltipAtivo[0];
            A136CampoNome = BC001A13_A136CampoNome[0];
            A140TooltipTelaNome = BC001A13_A140TooltipTelaNome[0];
            A135CampoId = BC001A13_A135CampoId[0];
            A139TooltipTelaId = BC001A13_A139TooltipTelaId[0];
         }
         Gx_mode = sMode53;
      }

      protected void ScanKeyEnd1A53( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm1A53( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1A53( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1A53( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1A53( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1A53( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1A53( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1A53( )
      {
      }

      protected void send_integrity_lvl_hashes1A53( )
      {
      }

      protected void AddRow1A53( )
      {
         VarsToRow53( bcTooltip) ;
      }

      protected void ReadRow1A53( )
      {
         RowToVars53( bcTooltip, 1) ;
      }

      protected void InitializeNonKey1A53( )
      {
         A115TooltipDescricao = "";
         AV17tooltipexiste = false;
         A135CampoId = 0;
         A136CampoNome = "";
         A139TooltipTelaId = 0;
         A140TooltipTelaNome = "";
         A118TooltipAtivo = true;
         Z118TooltipAtivo = false;
         Z135CampoId = 0;
         Z139TooltipTelaId = 0;
      }

      protected void InitAll1A53( )
      {
         A112TooltipId = 0;
         InitializeNonKey1A53( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A118TooltipAtivo = i118TooltipAtivo;
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

      public void VarsToRow53( SdtTooltip obj53 )
      {
         obj53.gxTpr_Mode = Gx_mode;
         obj53.gxTpr_Tooltipdescricao = A115TooltipDescricao;
         obj53.gxTpr_Campoid = A135CampoId;
         obj53.gxTpr_Camponome = A136CampoNome;
         obj53.gxTpr_Tooltiptelaid = A139TooltipTelaId;
         obj53.gxTpr_Tooltiptelanome = A140TooltipTelaNome;
         obj53.gxTpr_Tooltipativo = A118TooltipAtivo;
         obj53.gxTpr_Tooltipid = A112TooltipId;
         obj53.gxTpr_Tooltipid_Z = Z112TooltipId;
         obj53.gxTpr_Tooltipativo_Z = Z118TooltipAtivo;
         obj53.gxTpr_Campoid_Z = Z135CampoId;
         obj53.gxTpr_Camponome_Z = Z136CampoNome;
         obj53.gxTpr_Tooltiptelaid_Z = Z139TooltipTelaId;
         obj53.gxTpr_Tooltiptelanome_Z = Z140TooltipTelaNome;
         obj53.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow53( SdtTooltip obj53 )
      {
         obj53.gxTpr_Tooltipid = A112TooltipId;
         return  ;
      }

      public void RowToVars53( SdtTooltip obj53 ,
                               int forceLoad )
      {
         Gx_mode = obj53.gxTpr_Mode;
         A115TooltipDescricao = obj53.gxTpr_Tooltipdescricao;
         A135CampoId = obj53.gxTpr_Campoid;
         A136CampoNome = obj53.gxTpr_Camponome;
         A139TooltipTelaId = obj53.gxTpr_Tooltiptelaid;
         A140TooltipTelaNome = obj53.gxTpr_Tooltiptelanome;
         A118TooltipAtivo = obj53.gxTpr_Tooltipativo;
         A112TooltipId = obj53.gxTpr_Tooltipid;
         Z112TooltipId = obj53.gxTpr_Tooltipid_Z;
         Z118TooltipAtivo = obj53.gxTpr_Tooltipativo_Z;
         Z135CampoId = obj53.gxTpr_Campoid_Z;
         Z136CampoNome = obj53.gxTpr_Camponome_Z;
         Z139TooltipTelaId = obj53.gxTpr_Tooltiptelaid_Z;
         Z140TooltipTelaNome = obj53.gxTpr_Tooltiptelanome_Z;
         Gx_mode = obj53.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A112TooltipId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1A53( ) ;
         ScanKeyStart1A53( ) ;
         if ( RcdFound53 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z112TooltipId = A112TooltipId;
         }
         ZM1A53( -7) ;
         OnLoadActions1A53( ) ;
         AddRow1A53( ) ;
         ScanKeyEnd1A53( ) ;
         if ( RcdFound53 == 0 )
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
         RowToVars53( bcTooltip, 0) ;
         ScanKeyStart1A53( ) ;
         if ( RcdFound53 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z112TooltipId = A112TooltipId;
         }
         ZM1A53( -7) ;
         OnLoadActions1A53( ) ;
         AddRow1A53( ) ;
         ScanKeyEnd1A53( ) ;
         if ( RcdFound53 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey1A53( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1A53( ) ;
         }
         else
         {
            if ( RcdFound53 == 1 )
            {
               if ( A112TooltipId != Z112TooltipId )
               {
                  A112TooltipId = Z112TooltipId;
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
                  Update1A53( ) ;
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
                  if ( A112TooltipId != Z112TooltipId )
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
                        Insert1A53( ) ;
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
                        Insert1A53( ) ;
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
         RowToVars53( bcTooltip, 1) ;
         SaveImpl( ) ;
         VarsToRow53( bcTooltip) ;
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
         RowToVars53( bcTooltip, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1A53( ) ;
         AfterTrn( ) ;
         VarsToRow53( bcTooltip) ;
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
            SdtTooltip auxBC = new SdtTooltip(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A112TooltipId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTooltip);
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
         RowToVars53( bcTooltip, 1) ;
         UpdateImpl( ) ;
         VarsToRow53( bcTooltip) ;
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
         RowToVars53( bcTooltip, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1A53( ) ;
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
         VarsToRow53( bcTooltip) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars53( bcTooltip, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey1A53( ) ;
         if ( RcdFound53 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A112TooltipId != Z112TooltipId )
            {
               A112TooltipId = Z112TooltipId;
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
            if ( A112TooltipId != Z112TooltipId )
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
         pr_default.close(9);
         pr_default.close(10);
         context.RollbackDataStores("tooltip_bc",pr_default);
         VarsToRow53( bcTooltip) ;
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
         Gx_mode = bcTooltip.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTooltip.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTooltip )
         {
            bcTooltip = (SdtTooltip)(sdt);
            if ( StringUtil.StrCmp(bcTooltip.gxTpr_Mode, "") == 0 )
            {
               bcTooltip.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow53( bcTooltip) ;
            }
            else
            {
               RowToVars53( bcTooltip, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTooltip.gxTpr_Mode, "") == 0 )
            {
               bcTooltip.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars53( bcTooltip, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtTooltip Tooltip_BC
      {
         get {
            return bcTooltip ;
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
            return "tooltip_Execute" ;
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
         pr_default.close(9);
         pr_default.close(10);
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
         AV30Pgmname = "";
         AV27TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z136CampoNome = "";
         A136CampoNome = "";
         Z140TooltipTelaNome = "";
         A140TooltipTelaNome = "";
         Z115TooltipDescricao = "";
         A115TooltipDescricao = "";
         BC001A6_A112TooltipId = new int[1] ;
         BC001A6_A115TooltipDescricao = new string[] {""} ;
         BC001A6_A118TooltipAtivo = new bool[] {false} ;
         BC001A6_A136CampoNome = new string[] {""} ;
         BC001A6_A140TooltipTelaNome = new string[] {""} ;
         BC001A6_A135CampoId = new int[1] ;
         BC001A6_A139TooltipTelaId = new int[1] ;
         BC001A4_A136CampoNome = new string[] {""} ;
         BC001A5_A140TooltipTelaNome = new string[] {""} ;
         BC001A7_A112TooltipId = new int[1] ;
         BC001A3_A112TooltipId = new int[1] ;
         BC001A3_A115TooltipDescricao = new string[] {""} ;
         BC001A3_A118TooltipAtivo = new bool[] {false} ;
         BC001A3_A135CampoId = new int[1] ;
         BC001A3_A139TooltipTelaId = new int[1] ;
         sMode53 = "";
         BC001A2_A112TooltipId = new int[1] ;
         BC001A2_A115TooltipDescricao = new string[] {""} ;
         BC001A2_A118TooltipAtivo = new bool[] {false} ;
         BC001A2_A135CampoId = new int[1] ;
         BC001A2_A139TooltipTelaId = new int[1] ;
         BC001A8_A112TooltipId = new int[1] ;
         BC001A11_A136CampoNome = new string[] {""} ;
         BC001A12_A140TooltipTelaNome = new string[] {""} ;
         BC001A13_A112TooltipId = new int[1] ;
         BC001A13_A115TooltipDescricao = new string[] {""} ;
         BC001A13_A118TooltipAtivo = new bool[] {false} ;
         BC001A13_A136CampoNome = new string[] {""} ;
         BC001A13_A140TooltipTelaNome = new string[] {""} ;
         BC001A13_A135CampoId = new int[1] ;
         BC001A13_A139TooltipTelaId = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.tooltip_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tooltip_bc__default(),
            new Object[][] {
                new Object[] {
               BC001A2_A112TooltipId, BC001A2_A115TooltipDescricao, BC001A2_A118TooltipAtivo, BC001A2_A135CampoId, BC001A2_A139TooltipTelaId
               }
               , new Object[] {
               BC001A3_A112TooltipId, BC001A3_A115TooltipDescricao, BC001A3_A118TooltipAtivo, BC001A3_A135CampoId, BC001A3_A139TooltipTelaId
               }
               , new Object[] {
               BC001A4_A136CampoNome
               }
               , new Object[] {
               BC001A5_A140TooltipTelaNome
               }
               , new Object[] {
               BC001A6_A112TooltipId, BC001A6_A115TooltipDescricao, BC001A6_A118TooltipAtivo, BC001A6_A136CampoNome, BC001A6_A140TooltipTelaNome, BC001A6_A135CampoId, BC001A6_A139TooltipTelaId
               }
               , new Object[] {
               BC001A7_A112TooltipId
               }
               , new Object[] {
               BC001A8_A112TooltipId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001A11_A136CampoNome
               }
               , new Object[] {
               BC001A12_A140TooltipTelaNome
               }
               , new Object[] {
               BC001A13_A112TooltipId, BC001A13_A115TooltipDescricao, BC001A13_A118TooltipAtivo, BC001A13_A136CampoNome, BC001A13_A140TooltipTelaNome, BC001A13_A135CampoId, BC001A13_A139TooltipTelaId
               }
            }
         );
         AV30Pgmname = "Tooltip_BC";
         Z118TooltipAtivo = true;
         A118TooltipAtivo = true;
         i118TooltipAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121A2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound53 ;
      private short nIsDirty_53 ;
      private short GXt_int1 ;
      private int trnEnded ;
      private int Z112TooltipId ;
      private int A112TooltipId ;
      private int AV31GXV1 ;
      private int AV26Insert_CampoId ;
      private int AV28Insert_TooltipTelaId ;
      private int Z135CampoId ;
      private int A135CampoId ;
      private int Z139TooltipTelaId ;
      private int A139TooltipTelaId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV30Pgmname ;
      private string sMode53 ;
      private bool returnInSub ;
      private bool Z118TooltipAtivo ;
      private bool A118TooltipAtivo ;
      private bool AV17tooltipexiste ;
      private bool i118TooltipAtivo ;
      private bool mustCommit ;
      private string Z115TooltipDescricao ;
      private string A115TooltipDescricao ;
      private string Z136CampoNome ;
      private string A136CampoNome ;
      private string Z140TooltipTelaNome ;
      private string A140TooltipTelaNome ;
      private IGxSession AV12WebSession ;
      private SdtTooltip bcTooltip ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC001A6_A112TooltipId ;
      private string[] BC001A6_A115TooltipDescricao ;
      private bool[] BC001A6_A118TooltipAtivo ;
      private string[] BC001A6_A136CampoNome ;
      private string[] BC001A6_A140TooltipTelaNome ;
      private int[] BC001A6_A135CampoId ;
      private int[] BC001A6_A139TooltipTelaId ;
      private string[] BC001A4_A136CampoNome ;
      private string[] BC001A5_A140TooltipTelaNome ;
      private int[] BC001A7_A112TooltipId ;
      private int[] BC001A3_A112TooltipId ;
      private string[] BC001A3_A115TooltipDescricao ;
      private bool[] BC001A3_A118TooltipAtivo ;
      private int[] BC001A3_A135CampoId ;
      private int[] BC001A3_A139TooltipTelaId ;
      private int[] BC001A2_A112TooltipId ;
      private string[] BC001A2_A115TooltipDescricao ;
      private bool[] BC001A2_A118TooltipAtivo ;
      private int[] BC001A2_A135CampoId ;
      private int[] BC001A2_A139TooltipTelaId ;
      private int[] BC001A8_A112TooltipId ;
      private string[] BC001A11_A136CampoNome ;
      private string[] BC001A12_A140TooltipTelaNome ;
      private int[] BC001A13_A112TooltipId ;
      private string[] BC001A13_A115TooltipDescricao ;
      private bool[] BC001A13_A118TooltipAtivo ;
      private string[] BC001A13_A136CampoNome ;
      private string[] BC001A13_A140TooltipTelaNome ;
      private int[] BC001A13_A135CampoId ;
      private int[] BC001A13_A139TooltipTelaId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV27TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
   }

   public class tooltip_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class tooltip_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC001A6;
        prmBC001A6 = new Object[] {
        new ParDef("@TooltipId",GXType.Int32,8,0)
        };
        Object[] prmBC001A4;
        prmBC001A4 = new Object[] {
        new ParDef("@CampoId",GXType.Int32,8,0)
        };
        Object[] prmBC001A5;
        prmBC001A5 = new Object[] {
        new ParDef("@TooltipTelaId",GXType.Int32,8,0)
        };
        Object[] prmBC001A7;
        prmBC001A7 = new Object[] {
        new ParDef("@TooltipId",GXType.Int32,8,0)
        };
        Object[] prmBC001A3;
        prmBC001A3 = new Object[] {
        new ParDef("@TooltipId",GXType.Int32,8,0)
        };
        Object[] prmBC001A2;
        prmBC001A2 = new Object[] {
        new ParDef("@TooltipId",GXType.Int32,8,0)
        };
        Object[] prmBC001A8;
        prmBC001A8 = new Object[] {
        new ParDef("@TooltipDescricao",GXType.NVarChar,2097152,0) ,
        new ParDef("@TooltipAtivo",GXType.Boolean,4,0) ,
        new ParDef("@CampoId",GXType.Int32,8,0) ,
        new ParDef("@TooltipTelaId",GXType.Int32,8,0)
        };
        Object[] prmBC001A9;
        prmBC001A9 = new Object[] {
        new ParDef("@TooltipDescricao",GXType.NVarChar,2097152,0) ,
        new ParDef("@TooltipAtivo",GXType.Boolean,4,0) ,
        new ParDef("@CampoId",GXType.Int32,8,0) ,
        new ParDef("@TooltipTelaId",GXType.Int32,8,0) ,
        new ParDef("@TooltipId",GXType.Int32,8,0)
        };
        Object[] prmBC001A10;
        prmBC001A10 = new Object[] {
        new ParDef("@TooltipId",GXType.Int32,8,0)
        };
        Object[] prmBC001A11;
        prmBC001A11 = new Object[] {
        new ParDef("@CampoId",GXType.Int32,8,0)
        };
        Object[] prmBC001A12;
        prmBC001A12 = new Object[] {
        new ParDef("@TooltipTelaId",GXType.Int32,8,0)
        };
        Object[] prmBC001A13;
        prmBC001A13 = new Object[] {
        new ParDef("@TooltipId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC001A2", "SELECT [TooltipId], [TooltipDescricao], [TooltipAtivo], [CampoId], [TooltipTelaId] AS TooltipTelaId FROM [Tooltip] WITH (UPDLOCK) WHERE [TooltipId] = @TooltipId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001A3", "SELECT [TooltipId], [TooltipDescricao], [TooltipAtivo], [CampoId], [TooltipTelaId] AS TooltipTelaId FROM [Tooltip] WHERE [TooltipId] = @TooltipId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001A4", "SELECT [CampoNome] FROM [Campo] WHERE [CampoId] = @CampoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001A5", "SELECT [TelaNome] AS TooltipTelaNome FROM [Tela] WHERE [TelaId] = @TooltipTelaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001A6", "SELECT TM1.[TooltipId], TM1.[TooltipDescricao], TM1.[TooltipAtivo], T2.[CampoNome], T3.[TelaNome] AS TooltipTelaNome, TM1.[CampoId], TM1.[TooltipTelaId] AS TooltipTelaId FROM (([Tooltip] TM1 INNER JOIN [Campo] T2 ON T2.[CampoId] = TM1.[CampoId]) INNER JOIN [Tela] T3 ON T3.[TelaId] = TM1.[TooltipTelaId]) WHERE TM1.[TooltipId] = @TooltipId ORDER BY TM1.[TooltipId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001A7", "SELECT [TooltipId] FROM [Tooltip] WHERE [TooltipId] = @TooltipId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001A8", "INSERT INTO [Tooltip]([TooltipDescricao], [TooltipAtivo], [CampoId], [TooltipTelaId]) VALUES(@TooltipDescricao, @TooltipAtivo, @CampoId, @TooltipTelaId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001A9", "UPDATE [Tooltip] SET [TooltipDescricao]=@TooltipDescricao, [TooltipAtivo]=@TooltipAtivo, [CampoId]=@CampoId, [TooltipTelaId]=@TooltipTelaId  WHERE [TooltipId] = @TooltipId", GxErrorMask.GX_NOMASK,prmBC001A9)
           ,new CursorDef("BC001A10", "DELETE FROM [Tooltip]  WHERE [TooltipId] = @TooltipId", GxErrorMask.GX_NOMASK,prmBC001A10)
           ,new CursorDef("BC001A11", "SELECT [CampoNome] FROM [Campo] WHERE [CampoId] = @CampoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001A12", "SELECT [TelaNome] AS TooltipTelaNome FROM [Tela] WHERE [TelaId] = @TooltipTelaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001A13", "SELECT TM1.[TooltipId], TM1.[TooltipDescricao], TM1.[TooltipAtivo], T2.[CampoNome], T3.[TelaNome] AS TooltipTelaNome, TM1.[CampoId], TM1.[TooltipTelaId] AS TooltipTelaId FROM (([Tooltip] TM1 INNER JOIN [Campo] T2 ON T2.[CampoId] = TM1.[CampoId]) INNER JOIN [Tela] T3 ON T3.[TelaId] = TM1.[TooltipTelaId]) WHERE TM1.[TooltipId] = @TooltipId ORDER BY TM1.[TooltipId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A13,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
     }
  }

}

}
