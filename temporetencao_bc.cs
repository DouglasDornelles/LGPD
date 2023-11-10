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
   public class temporetencao_bc : GXHttpHandler, IGxSilentTrn
   {
      public temporetencao_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public temporetencao_bc( IGxContext context )
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
         ReadRow0G16( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0G16( ) ;
         standaloneModal( ) ;
         AddRow0G16( ) ;
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
            E110G2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z48TempoRetencaoId = A48TempoRetencaoId;
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

      protected void CONFIRM_0G0( )
      {
         BeforeValidate0G16( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0G16( ) ;
            }
            else
            {
               CheckExtendedTable0G16( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0G16( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120G2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110G2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV13IsTempoRetencao = true;
         AV14TempoRetencaoId_Out = A48TempoRetencaoId;
      }

      protected void ZM0G16( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z49TempoRetencaoNome = A49TempoRetencaoNome;
            Z50TempoRetencaoAtivo = A50TempoRetencaoAtivo;
         }
         if ( GX_JID == -6 )
         {
            Z48TempoRetencaoId = A48TempoRetencaoId;
            Z49TempoRetencaoNome = A49TempoRetencaoNome;
            Z50TempoRetencaoAtivo = A50TempoRetencaoAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A50TempoRetencaoAtivo) && ( Gx_BScreen == 0 ) )
         {
            A50TempoRetencaoAtivo = true;
         }
      }

      protected void Load0G16( )
      {
         /* Using cursor BC000G4 */
         pr_default.execute(2, new Object[] {n48TempoRetencaoId, A48TempoRetencaoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound16 = 1;
            A49TempoRetencaoNome = BC000G4_A49TempoRetencaoNome[0];
            A50TempoRetencaoAtivo = BC000G4_A50TempoRetencaoAtivo[0];
            ZM0G16( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0G16( ) ;
      }

      protected void OnLoadActions0G16( )
      {
         A49TempoRetencaoNome = StringUtil.Upper( A49TempoRetencaoNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "TempoRetencao",  A48TempoRetencaoId,  A49TempoRetencaoNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
      }

      protected void CheckExtendedTable0G16( )
      {
         nIsDirty_16 = 0;
         standaloneModal( ) ;
         nIsDirty_16 = 1;
         A49TempoRetencaoNome = StringUtil.Upper( A49TempoRetencaoNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "TempoRetencao",  A48TempoRetencaoId,  A49TempoRetencaoNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
         if ( ! AV15IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A49TempoRetencaoNome)) )
         {
            GX_msglist.addItem("Informe o nome do Tempo de Retenção.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0G16( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0G16( )
      {
         /* Using cursor BC000G5 */
         pr_default.execute(3, new Object[] {n48TempoRetencaoId, A48TempoRetencaoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000G3 */
         pr_default.execute(1, new Object[] {n48TempoRetencaoId, A48TempoRetencaoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0G16( 6) ;
            RcdFound16 = 1;
            A48TempoRetencaoId = BC000G3_A48TempoRetencaoId[0];
            n48TempoRetencaoId = BC000G3_n48TempoRetencaoId[0];
            A49TempoRetencaoNome = BC000G3_A49TempoRetencaoNome[0];
            A50TempoRetencaoAtivo = BC000G3_A50TempoRetencaoAtivo[0];
            Z48TempoRetencaoId = A48TempoRetencaoId;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0G16( ) ;
            if ( AnyError == 1 )
            {
               RcdFound16 = 0;
               InitializeNonKey0G16( ) ;
            }
            Gx_mode = sMode16;
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0G16( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode16;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0G16( ) ;
         if ( RcdFound16 == 0 )
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
         CONFIRM_0G0( ) ;
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

      protected void CheckOptimisticConcurrency0G16( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000G2 */
            pr_default.execute(0, new Object[] {n48TempoRetencaoId, A48TempoRetencaoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TempoRetencao"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z49TempoRetencaoNome, BC000G2_A49TempoRetencaoNome[0]) != 0 ) || ( Z50TempoRetencaoAtivo != BC000G2_A50TempoRetencaoAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TempoRetencao"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G16( )
      {
         BeforeValidate0G16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G16( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G16( 0) ;
            CheckOptimisticConcurrency0G16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000G6 */
                     pr_default.execute(4, new Object[] {A49TempoRetencaoNome, A50TempoRetencaoAtivo});
                     A48TempoRetencaoId = BC000G6_A48TempoRetencaoId[0];
                     n48TempoRetencaoId = BC000G6_n48TempoRetencaoId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("TempoRetencao");
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
               Load0G16( ) ;
            }
            EndLevel0G16( ) ;
         }
         CloseExtendedTableCursors0G16( ) ;
      }

      protected void Update0G16( )
      {
         BeforeValidate0G16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G16( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0G16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000G7 */
                     pr_default.execute(5, new Object[] {A49TempoRetencaoNome, A50TempoRetencaoAtivo, n48TempoRetencaoId, A48TempoRetencaoId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("TempoRetencao");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TempoRetencao"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0G16( ) ;
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
            EndLevel0G16( ) ;
         }
         CloseExtendedTableCursors0G16( ) ;
      }

      protected void DeferredUpdate0G16( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0G16( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G16( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G16( ) ;
            AfterConfirm0G16( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G16( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000G8 */
                  pr_default.execute(6, new Object[] {n48TempoRetencaoId, A48TempoRetencaoId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("TempoRetencao");
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
         sMode16 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0G16( ) ;
         Gx_mode = sMode16;
      }

      protected void OnDeleteControls0G16( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV15IsOk;
            new validanome(context ).execute(  "TempoRetencao",  A48TempoRetencaoId,  A49TempoRetencaoNome, out  GXt_boolean1) ;
            AV15IsOk = GXt_boolean1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000G9 */
            pr_default.execute(7, new Object[] {n48TempoRetencaoId, A48TempoRetencaoId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0G16( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0G16( ) ;
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

      public void ScanKeyStart0G16( )
      {
         /* Scan By routine */
         /* Using cursor BC000G10 */
         pr_default.execute(8, new Object[] {n48TempoRetencaoId, A48TempoRetencaoId});
         RcdFound16 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound16 = 1;
            A48TempoRetencaoId = BC000G10_A48TempoRetencaoId[0];
            n48TempoRetencaoId = BC000G10_n48TempoRetencaoId[0];
            A49TempoRetencaoNome = BC000G10_A49TempoRetencaoNome[0];
            A50TempoRetencaoAtivo = BC000G10_A50TempoRetencaoAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0G16( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound16 = 0;
         ScanKeyLoad0G16( ) ;
      }

      protected void ScanKeyLoad0G16( )
      {
         sMode16 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound16 = 1;
            A48TempoRetencaoId = BC000G10_A48TempoRetencaoId[0];
            n48TempoRetencaoId = BC000G10_n48TempoRetencaoId[0];
            A49TempoRetencaoNome = BC000G10_A49TempoRetencaoNome[0];
            A50TempoRetencaoAtivo = BC000G10_A50TempoRetencaoAtivo[0];
         }
         Gx_mode = sMode16;
      }

      protected void ScanKeyEnd0G16( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0G16( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0G16( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0G16( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G16( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G16( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G16( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G16( )
      {
      }

      protected void send_integrity_lvl_hashes0G16( )
      {
      }

      protected void AddRow0G16( )
      {
         VarsToRow16( bcTempoRetencao) ;
      }

      protected void ReadRow0G16( )
      {
         RowToVars16( bcTempoRetencao, 1) ;
      }

      protected void InitializeNonKey0G16( )
      {
         A49TempoRetencaoNome = "";
         AV15IsOk = false;
         A50TempoRetencaoAtivo = true;
         Z49TempoRetencaoNome = "";
         Z50TempoRetencaoAtivo = false;
      }

      protected void InitAll0G16( )
      {
         A48TempoRetencaoId = 0;
         n48TempoRetencaoId = false;
         InitializeNonKey0G16( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A50TempoRetencaoAtivo = i50TempoRetencaoAtivo;
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

      public void VarsToRow16( SdtTempoRetencao obj16 )
      {
         obj16.gxTpr_Mode = Gx_mode;
         obj16.gxTpr_Temporetencaonome = A49TempoRetencaoNome;
         obj16.gxTpr_Temporetencaoativo = A50TempoRetencaoAtivo;
         obj16.gxTpr_Temporetencaoid = A48TempoRetencaoId;
         obj16.gxTpr_Temporetencaoid_Z = Z48TempoRetencaoId;
         obj16.gxTpr_Temporetencaonome_Z = Z49TempoRetencaoNome;
         obj16.gxTpr_Temporetencaoativo_Z = Z50TempoRetencaoAtivo;
         obj16.gxTpr_Temporetencaoid_N = (short)(Convert.ToInt16(n48TempoRetencaoId));
         obj16.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow16( SdtTempoRetencao obj16 )
      {
         obj16.gxTpr_Temporetencaoid = A48TempoRetencaoId;
         return  ;
      }

      public void RowToVars16( SdtTempoRetencao obj16 ,
                               int forceLoad )
      {
         Gx_mode = obj16.gxTpr_Mode;
         A49TempoRetencaoNome = obj16.gxTpr_Temporetencaonome;
         A50TempoRetencaoAtivo = obj16.gxTpr_Temporetencaoativo;
         A48TempoRetencaoId = obj16.gxTpr_Temporetencaoid;
         n48TempoRetencaoId = false;
         Z48TempoRetencaoId = obj16.gxTpr_Temporetencaoid_Z;
         Z49TempoRetencaoNome = obj16.gxTpr_Temporetencaonome_Z;
         Z50TempoRetencaoAtivo = obj16.gxTpr_Temporetencaoativo_Z;
         n48TempoRetencaoId = (bool)(Convert.ToBoolean(obj16.gxTpr_Temporetencaoid_N));
         Gx_mode = obj16.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A48TempoRetencaoId = (int)getParm(obj,0);
         n48TempoRetencaoId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0G16( ) ;
         ScanKeyStart0G16( ) ;
         if ( RcdFound16 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z48TempoRetencaoId = A48TempoRetencaoId;
         }
         ZM0G16( -6) ;
         OnLoadActions0G16( ) ;
         AddRow0G16( ) ;
         ScanKeyEnd0G16( ) ;
         if ( RcdFound16 == 0 )
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
         RowToVars16( bcTempoRetencao, 0) ;
         ScanKeyStart0G16( ) ;
         if ( RcdFound16 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z48TempoRetencaoId = A48TempoRetencaoId;
         }
         ZM0G16( -6) ;
         OnLoadActions0G16( ) ;
         AddRow0G16( ) ;
         ScanKeyEnd0G16( ) ;
         if ( RcdFound16 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0G16( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0G16( ) ;
         }
         else
         {
            if ( RcdFound16 == 1 )
            {
               if ( A48TempoRetencaoId != Z48TempoRetencaoId )
               {
                  A48TempoRetencaoId = Z48TempoRetencaoId;
                  n48TempoRetencaoId = false;
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
                  Update0G16( ) ;
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
                  if ( A48TempoRetencaoId != Z48TempoRetencaoId )
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
                        Insert0G16( ) ;
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
                        Insert0G16( ) ;
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
         RowToVars16( bcTempoRetencao, 1) ;
         SaveImpl( ) ;
         VarsToRow16( bcTempoRetencao) ;
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
         RowToVars16( bcTempoRetencao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0G16( ) ;
         AfterTrn( ) ;
         VarsToRow16( bcTempoRetencao) ;
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
            SdtTempoRetencao auxBC = new SdtTempoRetencao(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A48TempoRetencaoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTempoRetencao);
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
         RowToVars16( bcTempoRetencao, 1) ;
         UpdateImpl( ) ;
         VarsToRow16( bcTempoRetencao) ;
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
         RowToVars16( bcTempoRetencao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0G16( ) ;
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
         VarsToRow16( bcTempoRetencao) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars16( bcTempoRetencao, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0G16( ) ;
         if ( RcdFound16 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A48TempoRetencaoId != Z48TempoRetencaoId )
            {
               A48TempoRetencaoId = Z48TempoRetencaoId;
               n48TempoRetencaoId = false;
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
            if ( A48TempoRetencaoId != Z48TempoRetencaoId )
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
         context.RollbackDataStores("temporetencao_bc",pr_default);
         VarsToRow16( bcTempoRetencao) ;
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
         Gx_mode = bcTempoRetencao.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTempoRetencao.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTempoRetencao )
         {
            bcTempoRetencao = (SdtTempoRetencao)(sdt);
            if ( StringUtil.StrCmp(bcTempoRetencao.gxTpr_Mode, "") == 0 )
            {
               bcTempoRetencao.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow16( bcTempoRetencao) ;
            }
            else
            {
               RowToVars16( bcTempoRetencao, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTempoRetencao.gxTpr_Mode, "") == 0 )
            {
               bcTempoRetencao.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars16( bcTempoRetencao, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtTempoRetencao TempoRetencao_BC
      {
         get {
            return bcTempoRetencao ;
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
            return "temporetencao_Execute" ;
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
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z49TempoRetencaoNome = "";
         A49TempoRetencaoNome = "";
         BC000G4_A48TempoRetencaoId = new int[1] ;
         BC000G4_n48TempoRetencaoId = new bool[] {false} ;
         BC000G4_A49TempoRetencaoNome = new string[] {""} ;
         BC000G4_A50TempoRetencaoAtivo = new bool[] {false} ;
         BC000G5_A48TempoRetencaoId = new int[1] ;
         BC000G5_n48TempoRetencaoId = new bool[] {false} ;
         BC000G3_A48TempoRetencaoId = new int[1] ;
         BC000G3_n48TempoRetencaoId = new bool[] {false} ;
         BC000G3_A49TempoRetencaoNome = new string[] {""} ;
         BC000G3_A50TempoRetencaoAtivo = new bool[] {false} ;
         sMode16 = "";
         BC000G2_A48TempoRetencaoId = new int[1] ;
         BC000G2_n48TempoRetencaoId = new bool[] {false} ;
         BC000G2_A49TempoRetencaoNome = new string[] {""} ;
         BC000G2_A50TempoRetencaoAtivo = new bool[] {false} ;
         BC000G6_A48TempoRetencaoId = new int[1] ;
         BC000G6_n48TempoRetencaoId = new bool[] {false} ;
         BC000G9_A75DocumentoId = new int[1] ;
         BC000G10_A48TempoRetencaoId = new int[1] ;
         BC000G10_n48TempoRetencaoId = new bool[] {false} ;
         BC000G10_A49TempoRetencaoNome = new string[] {""} ;
         BC000G10_A50TempoRetencaoAtivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.temporetencao_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.temporetencao_bc__default(),
            new Object[][] {
                new Object[] {
               BC000G2_A48TempoRetencaoId, BC000G2_A49TempoRetencaoNome, BC000G2_A50TempoRetencaoAtivo
               }
               , new Object[] {
               BC000G3_A48TempoRetencaoId, BC000G3_A49TempoRetencaoNome, BC000G3_A50TempoRetencaoAtivo
               }
               , new Object[] {
               BC000G4_A48TempoRetencaoId, BC000G4_A49TempoRetencaoNome, BC000G4_A50TempoRetencaoAtivo
               }
               , new Object[] {
               BC000G5_A48TempoRetencaoId
               }
               , new Object[] {
               BC000G6_A48TempoRetencaoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000G9_A75DocumentoId
               }
               , new Object[] {
               BC000G10_A48TempoRetencaoId, BC000G10_A49TempoRetencaoNome, BC000G10_A50TempoRetencaoAtivo
               }
            }
         );
         Z50TempoRetencaoAtivo = true;
         A50TempoRetencaoAtivo = true;
         i50TempoRetencaoAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120G2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound16 ;
      private short nIsDirty_16 ;
      private int trnEnded ;
      private int Z48TempoRetencaoId ;
      private int A48TempoRetencaoId ;
      private int AV14TempoRetencaoId_Out ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode16 ;
      private bool returnInSub ;
      private bool AV13IsTempoRetencao ;
      private bool Z50TempoRetencaoAtivo ;
      private bool A50TempoRetencaoAtivo ;
      private bool n48TempoRetencaoId ;
      private bool AV15IsOk ;
      private bool GXt_boolean1 ;
      private bool i50TempoRetencaoAtivo ;
      private bool mustCommit ;
      private string Z49TempoRetencaoNome ;
      private string A49TempoRetencaoNome ;
      private IGxSession AV12WebSession ;
      private SdtTempoRetencao bcTempoRetencao ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000G4_A48TempoRetencaoId ;
      private bool[] BC000G4_n48TempoRetencaoId ;
      private string[] BC000G4_A49TempoRetencaoNome ;
      private bool[] BC000G4_A50TempoRetencaoAtivo ;
      private int[] BC000G5_A48TempoRetencaoId ;
      private bool[] BC000G5_n48TempoRetencaoId ;
      private int[] BC000G3_A48TempoRetencaoId ;
      private bool[] BC000G3_n48TempoRetencaoId ;
      private string[] BC000G3_A49TempoRetencaoNome ;
      private bool[] BC000G3_A50TempoRetencaoAtivo ;
      private int[] BC000G2_A48TempoRetencaoId ;
      private bool[] BC000G2_n48TempoRetencaoId ;
      private string[] BC000G2_A49TempoRetencaoNome ;
      private bool[] BC000G2_A50TempoRetencaoAtivo ;
      private int[] BC000G6_A48TempoRetencaoId ;
      private bool[] BC000G6_n48TempoRetencaoId ;
      private int[] BC000G9_A75DocumentoId ;
      private int[] BC000G10_A48TempoRetencaoId ;
      private bool[] BC000G10_n48TempoRetencaoId ;
      private string[] BC000G10_A49TempoRetencaoNome ;
      private bool[] BC000G10_A50TempoRetencaoAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class temporetencao_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class temporetencao_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000G4;
        prmBC000G4 = new Object[] {
        new ParDef("@TempoRetencaoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000G5;
        prmBC000G5 = new Object[] {
        new ParDef("@TempoRetencaoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000G3;
        prmBC000G3 = new Object[] {
        new ParDef("@TempoRetencaoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000G2;
        prmBC000G2 = new Object[] {
        new ParDef("@TempoRetencaoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000G6;
        prmBC000G6 = new Object[] {
        new ParDef("@TempoRetencaoNome",GXType.NVarChar,100,0) ,
        new ParDef("@TempoRetencaoAtivo",GXType.Boolean,4,0)
        };
        Object[] prmBC000G7;
        prmBC000G7 = new Object[] {
        new ParDef("@TempoRetencaoNome",GXType.NVarChar,100,0) ,
        new ParDef("@TempoRetencaoAtivo",GXType.Boolean,4,0) ,
        new ParDef("@TempoRetencaoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000G8;
        prmBC000G8 = new Object[] {
        new ParDef("@TempoRetencaoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000G9;
        prmBC000G9 = new Object[] {
        new ParDef("@TempoRetencaoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000G10;
        prmBC000G10 = new Object[] {
        new ParDef("@TempoRetencaoId",GXType.Int32,8,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC000G2", "SELECT [TempoRetencaoId], [TempoRetencaoNome], [TempoRetencaoAtivo] FROM [TempoRetencao] WITH (UPDLOCK) WHERE [TempoRetencaoId] = @TempoRetencaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G3", "SELECT [TempoRetencaoId], [TempoRetencaoNome], [TempoRetencaoAtivo] FROM [TempoRetencao] WHERE [TempoRetencaoId] = @TempoRetencaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G4", "SELECT TM1.[TempoRetencaoId], TM1.[TempoRetencaoNome], TM1.[TempoRetencaoAtivo] FROM [TempoRetencao] TM1 WHERE TM1.[TempoRetencaoId] = @TempoRetencaoId ORDER BY TM1.[TempoRetencaoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G5", "SELECT [TempoRetencaoId] FROM [TempoRetencao] WHERE [TempoRetencaoId] = @TempoRetencaoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G6", "INSERT INTO [TempoRetencao]([TempoRetencaoNome], [TempoRetencaoAtivo]) VALUES(@TempoRetencaoNome, @TempoRetencaoAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000G7", "UPDATE [TempoRetencao] SET [TempoRetencaoNome]=@TempoRetencaoNome, [TempoRetencaoAtivo]=@TempoRetencaoAtivo  WHERE [TempoRetencaoId] = @TempoRetencaoId", GxErrorMask.GX_NOMASK,prmBC000G7)
           ,new CursorDef("BC000G8", "DELETE FROM [TempoRetencao]  WHERE [TempoRetencaoId] = @TempoRetencaoId", GxErrorMask.GX_NOMASK,prmBC000G8)
           ,new CursorDef("BC000G9", "SELECT TOP 1 [DocumentoId] FROM [Documento] WHERE [TempoRetencaoId] = @TempoRetencaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000G10", "SELECT TM1.[TempoRetencaoId], TM1.[TempoRetencaoNome], TM1.[TempoRetencaoAtivo] FROM [TempoRetencao] TM1 WHERE TM1.[TempoRetencaoId] = @TempoRetencaoId ORDER BY TM1.[TempoRetencaoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G10,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
     }
  }

}

}
