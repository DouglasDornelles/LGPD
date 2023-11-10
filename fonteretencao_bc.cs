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
   public class fonteretencao_bc : GXHttpHandler, IGxSilentTrn
   {
      public fonteretencao_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public fonteretencao_bc( IGxContext context )
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
         ReadRow0L21( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0L21( ) ;
         standaloneModal( ) ;
         AddRow0L21( ) ;
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
            E110L2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z63FonteRetencaoId = A63FonteRetencaoId;
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

      protected void CONFIRM_0L0( )
      {
         BeforeValidate0L21( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0L21( ) ;
            }
            else
            {
               CheckExtendedTable0L21( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0L21( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120L2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110L2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV13IsFonteRetencao = true;
         AV14FonteRetencaoId_Out = A63FonteRetencaoId;
      }

      protected void ZM0L21( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z64FonteRetencaoNome = A64FonteRetencaoNome;
            Z65FonteRetencaoAtivo = A65FonteRetencaoAtivo;
         }
         if ( GX_JID == -6 )
         {
            Z63FonteRetencaoId = A63FonteRetencaoId;
            Z64FonteRetencaoNome = A64FonteRetencaoNome;
            Z65FonteRetencaoAtivo = A65FonteRetencaoAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A65FonteRetencaoAtivo) && ( Gx_BScreen == 0 ) )
         {
            A65FonteRetencaoAtivo = true;
         }
      }

      protected void Load0L21( )
      {
         /* Using cursor BC000L4 */
         pr_default.execute(2, new Object[] {A63FonteRetencaoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound21 = 1;
            A64FonteRetencaoNome = BC000L4_A64FonteRetencaoNome[0];
            A65FonteRetencaoAtivo = BC000L4_A65FonteRetencaoAtivo[0];
            ZM0L21( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0L21( ) ;
      }

      protected void OnLoadActions0L21( )
      {
         A64FonteRetencaoNome = StringUtil.Upper( A64FonteRetencaoNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "FonteRetencao",  A63FonteRetencaoId,  A64FonteRetencaoNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
      }

      protected void CheckExtendedTable0L21( )
      {
         nIsDirty_21 = 0;
         standaloneModal( ) ;
         nIsDirty_21 = 1;
         A64FonteRetencaoNome = StringUtil.Upper( A64FonteRetencaoNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "FonteRetencao",  A63FonteRetencaoId,  A64FonteRetencaoNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
         if ( ! AV15IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A64FonteRetencaoNome)) )
         {
            GX_msglist.addItem("Informe o Nome da Fonte de Retenção.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0L21( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0L21( )
      {
         /* Using cursor BC000L5 */
         pr_default.execute(3, new Object[] {A63FonteRetencaoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound21 = 1;
         }
         else
         {
            RcdFound21 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000L3 */
         pr_default.execute(1, new Object[] {A63FonteRetencaoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0L21( 6) ;
            RcdFound21 = 1;
            A63FonteRetencaoId = BC000L3_A63FonteRetencaoId[0];
            A64FonteRetencaoNome = BC000L3_A64FonteRetencaoNome[0];
            A65FonteRetencaoAtivo = BC000L3_A65FonteRetencaoAtivo[0];
            Z63FonteRetencaoId = A63FonteRetencaoId;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0L21( ) ;
            if ( AnyError == 1 )
            {
               RcdFound21 = 0;
               InitializeNonKey0L21( ) ;
            }
            Gx_mode = sMode21;
         }
         else
         {
            RcdFound21 = 0;
            InitializeNonKey0L21( ) ;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode21;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0L21( ) ;
         if ( RcdFound21 == 0 )
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
         CONFIRM_0L0( ) ;
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

      protected void CheckOptimisticConcurrency0L21( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000L2 */
            pr_default.execute(0, new Object[] {A63FonteRetencaoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FonteRetencao"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z64FonteRetencaoNome, BC000L2_A64FonteRetencaoNome[0]) != 0 ) || ( Z65FonteRetencaoAtivo != BC000L2_A65FonteRetencaoAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"FonteRetencao"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0L21( )
      {
         BeforeValidate0L21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L21( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0L21( 0) ;
            CheckOptimisticConcurrency0L21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0L21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000L6 */
                     pr_default.execute(4, new Object[] {A64FonteRetencaoNome, A65FonteRetencaoAtivo});
                     A63FonteRetencaoId = BC000L6_A63FonteRetencaoId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("FonteRetencao");
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
               Load0L21( ) ;
            }
            EndLevel0L21( ) ;
         }
         CloseExtendedTableCursors0L21( ) ;
      }

      protected void Update0L21( )
      {
         BeforeValidate0L21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L21( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0L21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000L7 */
                     pr_default.execute(5, new Object[] {A64FonteRetencaoNome, A65FonteRetencaoAtivo, A63FonteRetencaoId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("FonteRetencao");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FonteRetencao"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0L21( ) ;
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
            EndLevel0L21( ) ;
         }
         CloseExtendedTableCursors0L21( ) ;
      }

      protected void DeferredUpdate0L21( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0L21( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L21( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0L21( ) ;
            AfterConfirm0L21( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0L21( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000L8 */
                  pr_default.execute(6, new Object[] {A63FonteRetencaoId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("FonteRetencao");
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
         sMode21 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0L21( ) ;
         Gx_mode = sMode21;
      }

      protected void OnDeleteControls0L21( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV15IsOk;
            new validanome(context ).execute(  "FonteRetencao",  A63FonteRetencaoId,  A64FonteRetencaoNome, out  GXt_boolean1) ;
            AV15IsOk = GXt_boolean1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000L9 */
            pr_default.execute(7, new Object[] {A63FonteRetencaoId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Doc Fonte Retencao"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0L21( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0L21( ) ;
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

      public void ScanKeyStart0L21( )
      {
         /* Scan By routine */
         /* Using cursor BC000L10 */
         pr_default.execute(8, new Object[] {A63FonteRetencaoId});
         RcdFound21 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound21 = 1;
            A63FonteRetencaoId = BC000L10_A63FonteRetencaoId[0];
            A64FonteRetencaoNome = BC000L10_A64FonteRetencaoNome[0];
            A65FonteRetencaoAtivo = BC000L10_A65FonteRetencaoAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0L21( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound21 = 0;
         ScanKeyLoad0L21( ) ;
      }

      protected void ScanKeyLoad0L21( )
      {
         sMode21 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound21 = 1;
            A63FonteRetencaoId = BC000L10_A63FonteRetencaoId[0];
            A64FonteRetencaoNome = BC000L10_A64FonteRetencaoNome[0];
            A65FonteRetencaoAtivo = BC000L10_A65FonteRetencaoAtivo[0];
         }
         Gx_mode = sMode21;
      }

      protected void ScanKeyEnd0L21( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0L21( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0L21( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0L21( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0L21( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0L21( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0L21( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0L21( )
      {
      }

      protected void send_integrity_lvl_hashes0L21( )
      {
      }

      protected void AddRow0L21( )
      {
         VarsToRow21( bcFonteRetencao) ;
      }

      protected void ReadRow0L21( )
      {
         RowToVars21( bcFonteRetencao, 1) ;
      }

      protected void InitializeNonKey0L21( )
      {
         A64FonteRetencaoNome = "";
         AV15IsOk = false;
         A65FonteRetencaoAtivo = true;
         Z64FonteRetencaoNome = "";
         Z65FonteRetencaoAtivo = false;
      }

      protected void InitAll0L21( )
      {
         A63FonteRetencaoId = 0;
         InitializeNonKey0L21( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A65FonteRetencaoAtivo = i65FonteRetencaoAtivo;
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

      public void VarsToRow21( SdtFonteRetencao obj21 )
      {
         obj21.gxTpr_Mode = Gx_mode;
         obj21.gxTpr_Fonteretencaonome = A64FonteRetencaoNome;
         obj21.gxTpr_Fonteretencaoativo = A65FonteRetencaoAtivo;
         obj21.gxTpr_Fonteretencaoid = A63FonteRetencaoId;
         obj21.gxTpr_Fonteretencaoid_Z = Z63FonteRetencaoId;
         obj21.gxTpr_Fonteretencaonome_Z = Z64FonteRetencaoNome;
         obj21.gxTpr_Fonteretencaoativo_Z = Z65FonteRetencaoAtivo;
         obj21.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow21( SdtFonteRetencao obj21 )
      {
         obj21.gxTpr_Fonteretencaoid = A63FonteRetencaoId;
         return  ;
      }

      public void RowToVars21( SdtFonteRetencao obj21 ,
                               int forceLoad )
      {
         Gx_mode = obj21.gxTpr_Mode;
         A64FonteRetencaoNome = obj21.gxTpr_Fonteretencaonome;
         A65FonteRetencaoAtivo = obj21.gxTpr_Fonteretencaoativo;
         A63FonteRetencaoId = obj21.gxTpr_Fonteretencaoid;
         Z63FonteRetencaoId = obj21.gxTpr_Fonteretencaoid_Z;
         Z64FonteRetencaoNome = obj21.gxTpr_Fonteretencaonome_Z;
         Z65FonteRetencaoAtivo = obj21.gxTpr_Fonteretencaoativo_Z;
         Gx_mode = obj21.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A63FonteRetencaoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0L21( ) ;
         ScanKeyStart0L21( ) ;
         if ( RcdFound21 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z63FonteRetencaoId = A63FonteRetencaoId;
         }
         ZM0L21( -6) ;
         OnLoadActions0L21( ) ;
         AddRow0L21( ) ;
         ScanKeyEnd0L21( ) ;
         if ( RcdFound21 == 0 )
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
         RowToVars21( bcFonteRetencao, 0) ;
         ScanKeyStart0L21( ) ;
         if ( RcdFound21 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z63FonteRetencaoId = A63FonteRetencaoId;
         }
         ZM0L21( -6) ;
         OnLoadActions0L21( ) ;
         AddRow0L21( ) ;
         ScanKeyEnd0L21( ) ;
         if ( RcdFound21 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0L21( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0L21( ) ;
         }
         else
         {
            if ( RcdFound21 == 1 )
            {
               if ( A63FonteRetencaoId != Z63FonteRetencaoId )
               {
                  A63FonteRetencaoId = Z63FonteRetencaoId;
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
                  Update0L21( ) ;
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
                  if ( A63FonteRetencaoId != Z63FonteRetencaoId )
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
                        Insert0L21( ) ;
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
                        Insert0L21( ) ;
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
         RowToVars21( bcFonteRetencao, 1) ;
         SaveImpl( ) ;
         VarsToRow21( bcFonteRetencao) ;
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
         RowToVars21( bcFonteRetencao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0L21( ) ;
         AfterTrn( ) ;
         VarsToRow21( bcFonteRetencao) ;
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
            SdtFonteRetencao auxBC = new SdtFonteRetencao(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A63FonteRetencaoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcFonteRetencao);
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
         RowToVars21( bcFonteRetencao, 1) ;
         UpdateImpl( ) ;
         VarsToRow21( bcFonteRetencao) ;
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
         RowToVars21( bcFonteRetencao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0L21( ) ;
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
         VarsToRow21( bcFonteRetencao) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars21( bcFonteRetencao, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0L21( ) ;
         if ( RcdFound21 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A63FonteRetencaoId != Z63FonteRetencaoId )
            {
               A63FonteRetencaoId = Z63FonteRetencaoId;
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
            if ( A63FonteRetencaoId != Z63FonteRetencaoId )
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
         context.RollbackDataStores("fonteretencao_bc",pr_default);
         VarsToRow21( bcFonteRetencao) ;
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
         Gx_mode = bcFonteRetencao.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcFonteRetencao.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcFonteRetencao )
         {
            bcFonteRetencao = (SdtFonteRetencao)(sdt);
            if ( StringUtil.StrCmp(bcFonteRetencao.gxTpr_Mode, "") == 0 )
            {
               bcFonteRetencao.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow21( bcFonteRetencao) ;
            }
            else
            {
               RowToVars21( bcFonteRetencao, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcFonteRetencao.gxTpr_Mode, "") == 0 )
            {
               bcFonteRetencao.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars21( bcFonteRetencao, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtFonteRetencao FonteRetencao_BC
      {
         get {
            return bcFonteRetencao ;
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
            return "fonteretencao_Execute" ;
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
         Z64FonteRetencaoNome = "";
         A64FonteRetencaoNome = "";
         BC000L4_A63FonteRetencaoId = new int[1] ;
         BC000L4_A64FonteRetencaoNome = new string[] {""} ;
         BC000L4_A65FonteRetencaoAtivo = new bool[] {false} ;
         BC000L5_A63FonteRetencaoId = new int[1] ;
         BC000L3_A63FonteRetencaoId = new int[1] ;
         BC000L3_A64FonteRetencaoNome = new string[] {""} ;
         BC000L3_A65FonteRetencaoAtivo = new bool[] {false} ;
         sMode21 = "";
         BC000L2_A63FonteRetencaoId = new int[1] ;
         BC000L2_A64FonteRetencaoNome = new string[] {""} ;
         BC000L2_A65FonteRetencaoAtivo = new bool[] {false} ;
         BC000L6_A63FonteRetencaoId = new int[1] ;
         BC000L9_A63FonteRetencaoId = new int[1] ;
         BC000L9_A75DocumentoId = new int[1] ;
         BC000L10_A63FonteRetencaoId = new int[1] ;
         BC000L10_A64FonteRetencaoNome = new string[] {""} ;
         BC000L10_A65FonteRetencaoAtivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.fonteretencao_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.fonteretencao_bc__default(),
            new Object[][] {
                new Object[] {
               BC000L2_A63FonteRetencaoId, BC000L2_A64FonteRetencaoNome, BC000L2_A65FonteRetencaoAtivo
               }
               , new Object[] {
               BC000L3_A63FonteRetencaoId, BC000L3_A64FonteRetencaoNome, BC000L3_A65FonteRetencaoAtivo
               }
               , new Object[] {
               BC000L4_A63FonteRetencaoId, BC000L4_A64FonteRetencaoNome, BC000L4_A65FonteRetencaoAtivo
               }
               , new Object[] {
               BC000L5_A63FonteRetencaoId
               }
               , new Object[] {
               BC000L6_A63FonteRetencaoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000L9_A63FonteRetencaoId, BC000L9_A75DocumentoId
               }
               , new Object[] {
               BC000L10_A63FonteRetencaoId, BC000L10_A64FonteRetencaoNome, BC000L10_A65FonteRetencaoAtivo
               }
            }
         );
         Z65FonteRetencaoAtivo = true;
         A65FonteRetencaoAtivo = true;
         i65FonteRetencaoAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120L2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound21 ;
      private short nIsDirty_21 ;
      private int trnEnded ;
      private int Z63FonteRetencaoId ;
      private int A63FonteRetencaoId ;
      private int AV14FonteRetencaoId_Out ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode21 ;
      private bool returnInSub ;
      private bool AV13IsFonteRetencao ;
      private bool Z65FonteRetencaoAtivo ;
      private bool A65FonteRetencaoAtivo ;
      private bool AV15IsOk ;
      private bool GXt_boolean1 ;
      private bool i65FonteRetencaoAtivo ;
      private bool mustCommit ;
      private string Z64FonteRetencaoNome ;
      private string A64FonteRetencaoNome ;
      private IGxSession AV12WebSession ;
      private SdtFonteRetencao bcFonteRetencao ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000L4_A63FonteRetencaoId ;
      private string[] BC000L4_A64FonteRetencaoNome ;
      private bool[] BC000L4_A65FonteRetencaoAtivo ;
      private int[] BC000L5_A63FonteRetencaoId ;
      private int[] BC000L3_A63FonteRetencaoId ;
      private string[] BC000L3_A64FonteRetencaoNome ;
      private bool[] BC000L3_A65FonteRetencaoAtivo ;
      private int[] BC000L2_A63FonteRetencaoId ;
      private string[] BC000L2_A64FonteRetencaoNome ;
      private bool[] BC000L2_A65FonteRetencaoAtivo ;
      private int[] BC000L6_A63FonteRetencaoId ;
      private int[] BC000L9_A63FonteRetencaoId ;
      private int[] BC000L9_A75DocumentoId ;
      private int[] BC000L10_A63FonteRetencaoId ;
      private string[] BC000L10_A64FonteRetencaoNome ;
      private bool[] BC000L10_A65FonteRetencaoAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class fonteretencao_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class fonteretencao_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000L4;
        prmBC000L4 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0)
        };
        Object[] prmBC000L5;
        prmBC000L5 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0)
        };
        Object[] prmBC000L3;
        prmBC000L3 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0)
        };
        Object[] prmBC000L2;
        prmBC000L2 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0)
        };
        Object[] prmBC000L6;
        prmBC000L6 = new Object[] {
        new ParDef("@FonteRetencaoNome",GXType.NVarChar,100,0) ,
        new ParDef("@FonteRetencaoAtivo",GXType.Boolean,4,0)
        };
        Object[] prmBC000L7;
        prmBC000L7 = new Object[] {
        new ParDef("@FonteRetencaoNome",GXType.NVarChar,100,0) ,
        new ParDef("@FonteRetencaoAtivo",GXType.Boolean,4,0) ,
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0)
        };
        Object[] prmBC000L8;
        prmBC000L8 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0)
        };
        Object[] prmBC000L9;
        prmBC000L9 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0)
        };
        Object[] prmBC000L10;
        prmBC000L10 = new Object[] {
        new ParDef("@FonteRetencaoId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000L2", "SELECT [FonteRetencaoId], [FonteRetencaoNome], [FonteRetencaoAtivo] FROM [FonteRetencao] WITH (UPDLOCK) WHERE [FonteRetencaoId] = @FonteRetencaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000L3", "SELECT [FonteRetencaoId], [FonteRetencaoNome], [FonteRetencaoAtivo] FROM [FonteRetencao] WHERE [FonteRetencaoId] = @FonteRetencaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000L4", "SELECT TM1.[FonteRetencaoId], TM1.[FonteRetencaoNome], TM1.[FonteRetencaoAtivo] FROM [FonteRetencao] TM1 WHERE TM1.[FonteRetencaoId] = @FonteRetencaoId ORDER BY TM1.[FonteRetencaoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000L5", "SELECT [FonteRetencaoId] FROM [FonteRetencao] WHERE [FonteRetencaoId] = @FonteRetencaoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000L6", "INSERT INTO [FonteRetencao]([FonteRetencaoNome], [FonteRetencaoAtivo]) VALUES(@FonteRetencaoNome, @FonteRetencaoAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000L7", "UPDATE [FonteRetencao] SET [FonteRetencaoNome]=@FonteRetencaoNome, [FonteRetencaoAtivo]=@FonteRetencaoAtivo  WHERE [FonteRetencaoId] = @FonteRetencaoId", GxErrorMask.GX_NOMASK,prmBC000L7)
           ,new CursorDef("BC000L8", "DELETE FROM [FonteRetencao]  WHERE [FonteRetencaoId] = @FonteRetencaoId", GxErrorMask.GX_NOMASK,prmBC000L8)
           ,new CursorDef("BC000L9", "SELECT TOP 1 [FonteRetencaoId], [DocumentoId] FROM [DocFonteRetencao] WHERE [FonteRetencaoId] = @FonteRetencaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000L10", "SELECT TM1.[FonteRetencaoId], TM1.[FonteRetencaoNome], TM1.[FonteRetencaoAtivo] FROM [FonteRetencao] TM1 WHERE TM1.[FonteRetencaoId] = @FonteRetencaoId ORDER BY TM1.[FonteRetencaoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L10,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[1])[0] = rslt.getInt(2);
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
