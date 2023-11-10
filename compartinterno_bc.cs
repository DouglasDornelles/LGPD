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
   public class compartinterno_bc : GXHttpHandler, IGxSilentTrn
   {
      public compartinterno_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public compartinterno_bc( IGxContext context )
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
         ReadRow0J19( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0J19( ) ;
         standaloneModal( ) ;
         AddRow0J19( ) ;
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
            E110J2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z57CompartInternoId = A57CompartInternoId;
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

      protected void CONFIRM_0J0( )
      {
         BeforeValidate0J19( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0J19( ) ;
            }
            else
            {
               CheckExtendedTable0J19( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0J19( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120J2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110J2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0J19( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z58CompartInternoNome = A58CompartInternoNome;
            Z59CompartInternoAtivo = A59CompartInternoAtivo;
         }
         if ( GX_JID == -6 )
         {
            Z57CompartInternoId = A57CompartInternoId;
            Z58CompartInternoNome = A58CompartInternoNome;
            Z59CompartInternoAtivo = A59CompartInternoAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A59CompartInternoAtivo) && ( Gx_BScreen == 0 ) )
         {
            A59CompartInternoAtivo = true;
         }
      }

      protected void Load0J19( )
      {
         /* Using cursor BC000J4 */
         pr_default.execute(2, new Object[] {A57CompartInternoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound19 = 1;
            A58CompartInternoNome = BC000J4_A58CompartInternoNome[0];
            A59CompartInternoAtivo = BC000J4_A59CompartInternoAtivo[0];
            ZM0J19( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0J19( ) ;
      }

      protected void OnLoadActions0J19( )
      {
         A58CompartInternoNome = StringUtil.Upper( A58CompartInternoNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "CompartInterno",  A57CompartInternoId,  A58CompartInternoNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
      }

      protected void CheckExtendedTable0J19( )
      {
         nIsDirty_19 = 0;
         standaloneModal( ) ;
         nIsDirty_19 = 1;
         A58CompartInternoNome = StringUtil.Upper( A58CompartInternoNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "CompartInterno",  A57CompartInternoId,  A58CompartInternoNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
         if ( ! AV16IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A58CompartInternoNome)) )
         {
            GX_msglist.addItem("Informe o Nome do Compartilhamento Interno.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0J19( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0J19( )
      {
         /* Using cursor BC000J5 */
         pr_default.execute(3, new Object[] {A57CompartInternoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound19 = 1;
         }
         else
         {
            RcdFound19 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000J3 */
         pr_default.execute(1, new Object[] {A57CompartInternoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0J19( 6) ;
            RcdFound19 = 1;
            A57CompartInternoId = BC000J3_A57CompartInternoId[0];
            A58CompartInternoNome = BC000J3_A58CompartInternoNome[0];
            A59CompartInternoAtivo = BC000J3_A59CompartInternoAtivo[0];
            Z57CompartInternoId = A57CompartInternoId;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0J19( ) ;
            if ( AnyError == 1 )
            {
               RcdFound19 = 0;
               InitializeNonKey0J19( ) ;
            }
            Gx_mode = sMode19;
         }
         else
         {
            RcdFound19 = 0;
            InitializeNonKey0J19( ) ;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode19;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0J19( ) ;
         if ( RcdFound19 == 0 )
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
         CONFIRM_0J0( ) ;
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

      protected void CheckOptimisticConcurrency0J19( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000J2 */
            pr_default.execute(0, new Object[] {A57CompartInternoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CompartInterno"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z58CompartInternoNome, BC000J2_A58CompartInternoNome[0]) != 0 ) || ( Z59CompartInternoAtivo != BC000J2_A59CompartInternoAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CompartInterno"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0J19( )
      {
         BeforeValidate0J19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J19( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0J19( 0) ;
            CheckOptimisticConcurrency0J19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0J19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000J6 */
                     pr_default.execute(4, new Object[] {A58CompartInternoNome, A59CompartInternoAtivo});
                     A57CompartInternoId = BC000J6_A57CompartInternoId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("CompartInterno");
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
               Load0J19( ) ;
            }
            EndLevel0J19( ) ;
         }
         CloseExtendedTableCursors0J19( ) ;
      }

      protected void Update0J19( )
      {
         BeforeValidate0J19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J19( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0J19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000J7 */
                     pr_default.execute(5, new Object[] {A58CompartInternoNome, A59CompartInternoAtivo, A57CompartInternoId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("CompartInterno");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CompartInterno"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0J19( ) ;
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
            EndLevel0J19( ) ;
         }
         CloseExtendedTableCursors0J19( ) ;
      }

      protected void DeferredUpdate0J19( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0J19( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J19( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0J19( ) ;
            AfterConfirm0J19( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0J19( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000J8 */
                  pr_default.execute(6, new Object[] {A57CompartInternoId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("CompartInterno");
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
         sMode19 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0J19( ) ;
         Gx_mode = sMode19;
      }

      protected void OnDeleteControls0J19( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV16IsOk;
            new validanome(context ).execute(  "CompartInterno",  A57CompartInternoId,  A58CompartInternoNome, out  GXt_boolean1) ;
            AV16IsOk = GXt_boolean1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000J9 */
            pr_default.execute(7, new Object[] {A57CompartInternoId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Doc Compart Interno"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0J19( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0J19( ) ;
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

      public void ScanKeyStart0J19( )
      {
         /* Scan By routine */
         /* Using cursor BC000J10 */
         pr_default.execute(8, new Object[] {A57CompartInternoId});
         RcdFound19 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound19 = 1;
            A57CompartInternoId = BC000J10_A57CompartInternoId[0];
            A58CompartInternoNome = BC000J10_A58CompartInternoNome[0];
            A59CompartInternoAtivo = BC000J10_A59CompartInternoAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0J19( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound19 = 0;
         ScanKeyLoad0J19( ) ;
      }

      protected void ScanKeyLoad0J19( )
      {
         sMode19 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound19 = 1;
            A57CompartInternoId = BC000J10_A57CompartInternoId[0];
            A58CompartInternoNome = BC000J10_A58CompartInternoNome[0];
            A59CompartInternoAtivo = BC000J10_A59CompartInternoAtivo[0];
         }
         Gx_mode = sMode19;
      }

      protected void ScanKeyEnd0J19( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0J19( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0J19( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0J19( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0J19( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0J19( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0J19( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0J19( )
      {
      }

      protected void send_integrity_lvl_hashes0J19( )
      {
      }

      protected void AddRow0J19( )
      {
         VarsToRow19( bcCompartInterno) ;
      }

      protected void ReadRow0J19( )
      {
         RowToVars19( bcCompartInterno, 1) ;
      }

      protected void InitializeNonKey0J19( )
      {
         A58CompartInternoNome = "";
         AV16IsOk = false;
         A59CompartInternoAtivo = true;
         Z58CompartInternoNome = "";
         Z59CompartInternoAtivo = false;
      }

      protected void InitAll0J19( )
      {
         A57CompartInternoId = 0;
         InitializeNonKey0J19( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A59CompartInternoAtivo = i59CompartInternoAtivo;
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

      public void VarsToRow19( SdtCompartInterno obj19 )
      {
         obj19.gxTpr_Mode = Gx_mode;
         obj19.gxTpr_Compartinternonome = A58CompartInternoNome;
         obj19.gxTpr_Compartinternoativo = A59CompartInternoAtivo;
         obj19.gxTpr_Compartinternoid = A57CompartInternoId;
         obj19.gxTpr_Compartinternoid_Z = Z57CompartInternoId;
         obj19.gxTpr_Compartinternonome_Z = Z58CompartInternoNome;
         obj19.gxTpr_Compartinternoativo_Z = Z59CompartInternoAtivo;
         obj19.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow19( SdtCompartInterno obj19 )
      {
         obj19.gxTpr_Compartinternoid = A57CompartInternoId;
         return  ;
      }

      public void RowToVars19( SdtCompartInterno obj19 ,
                               int forceLoad )
      {
         Gx_mode = obj19.gxTpr_Mode;
         A58CompartInternoNome = obj19.gxTpr_Compartinternonome;
         A59CompartInternoAtivo = obj19.gxTpr_Compartinternoativo;
         A57CompartInternoId = obj19.gxTpr_Compartinternoid;
         Z57CompartInternoId = obj19.gxTpr_Compartinternoid_Z;
         Z58CompartInternoNome = obj19.gxTpr_Compartinternonome_Z;
         Z59CompartInternoAtivo = obj19.gxTpr_Compartinternoativo_Z;
         Gx_mode = obj19.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A57CompartInternoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0J19( ) ;
         ScanKeyStart0J19( ) ;
         if ( RcdFound19 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z57CompartInternoId = A57CompartInternoId;
         }
         ZM0J19( -6) ;
         OnLoadActions0J19( ) ;
         AddRow0J19( ) ;
         ScanKeyEnd0J19( ) ;
         if ( RcdFound19 == 0 )
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
         RowToVars19( bcCompartInterno, 0) ;
         ScanKeyStart0J19( ) ;
         if ( RcdFound19 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z57CompartInternoId = A57CompartInternoId;
         }
         ZM0J19( -6) ;
         OnLoadActions0J19( ) ;
         AddRow0J19( ) ;
         ScanKeyEnd0J19( ) ;
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0J19( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0J19( ) ;
         }
         else
         {
            if ( RcdFound19 == 1 )
            {
               if ( A57CompartInternoId != Z57CompartInternoId )
               {
                  A57CompartInternoId = Z57CompartInternoId;
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
                  Update0J19( ) ;
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
                  if ( A57CompartInternoId != Z57CompartInternoId )
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
                        Insert0J19( ) ;
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
                        Insert0J19( ) ;
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
         RowToVars19( bcCompartInterno, 1) ;
         SaveImpl( ) ;
         VarsToRow19( bcCompartInterno) ;
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
         RowToVars19( bcCompartInterno, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0J19( ) ;
         AfterTrn( ) ;
         VarsToRow19( bcCompartInterno) ;
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
            SdtCompartInterno auxBC = new SdtCompartInterno(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A57CompartInternoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcCompartInterno);
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
         RowToVars19( bcCompartInterno, 1) ;
         UpdateImpl( ) ;
         VarsToRow19( bcCompartInterno) ;
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
         RowToVars19( bcCompartInterno, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0J19( ) ;
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
         VarsToRow19( bcCompartInterno) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars19( bcCompartInterno, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0J19( ) ;
         if ( RcdFound19 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A57CompartInternoId != Z57CompartInternoId )
            {
               A57CompartInternoId = Z57CompartInternoId;
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
            if ( A57CompartInternoId != Z57CompartInternoId )
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
         context.RollbackDataStores("compartinterno_bc",pr_default);
         VarsToRow19( bcCompartInterno) ;
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
         Gx_mode = bcCompartInterno.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcCompartInterno.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcCompartInterno )
         {
            bcCompartInterno = (SdtCompartInterno)(sdt);
            if ( StringUtil.StrCmp(bcCompartInterno.gxTpr_Mode, "") == 0 )
            {
               bcCompartInterno.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow19( bcCompartInterno) ;
            }
            else
            {
               RowToVars19( bcCompartInterno, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcCompartInterno.gxTpr_Mode, "") == 0 )
            {
               bcCompartInterno.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars19( bcCompartInterno, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtCompartInterno CompartInterno_BC
      {
         get {
            return bcCompartInterno ;
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
            return "compartinterno_Execute" ;
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
         Z58CompartInternoNome = "";
         A58CompartInternoNome = "";
         BC000J4_A57CompartInternoId = new int[1] ;
         BC000J4_A58CompartInternoNome = new string[] {""} ;
         BC000J4_A59CompartInternoAtivo = new bool[] {false} ;
         BC000J5_A57CompartInternoId = new int[1] ;
         BC000J3_A57CompartInternoId = new int[1] ;
         BC000J3_A58CompartInternoNome = new string[] {""} ;
         BC000J3_A59CompartInternoAtivo = new bool[] {false} ;
         sMode19 = "";
         BC000J2_A57CompartInternoId = new int[1] ;
         BC000J2_A58CompartInternoNome = new string[] {""} ;
         BC000J2_A59CompartInternoAtivo = new bool[] {false} ;
         BC000J6_A57CompartInternoId = new int[1] ;
         BC000J9_A57CompartInternoId = new int[1] ;
         BC000J9_A75DocumentoId = new int[1] ;
         BC000J10_A57CompartInternoId = new int[1] ;
         BC000J10_A58CompartInternoNome = new string[] {""} ;
         BC000J10_A59CompartInternoAtivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.compartinterno_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compartinterno_bc__default(),
            new Object[][] {
                new Object[] {
               BC000J2_A57CompartInternoId, BC000J2_A58CompartInternoNome, BC000J2_A59CompartInternoAtivo
               }
               , new Object[] {
               BC000J3_A57CompartInternoId, BC000J3_A58CompartInternoNome, BC000J3_A59CompartInternoAtivo
               }
               , new Object[] {
               BC000J4_A57CompartInternoId, BC000J4_A58CompartInternoNome, BC000J4_A59CompartInternoAtivo
               }
               , new Object[] {
               BC000J5_A57CompartInternoId
               }
               , new Object[] {
               BC000J6_A57CompartInternoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000J9_A57CompartInternoId, BC000J9_A75DocumentoId
               }
               , new Object[] {
               BC000J10_A57CompartInternoId, BC000J10_A58CompartInternoNome, BC000J10_A59CompartInternoAtivo
               }
            }
         );
         Z59CompartInternoAtivo = true;
         A59CompartInternoAtivo = true;
         i59CompartInternoAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120J2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound19 ;
      private short nIsDirty_19 ;
      private int trnEnded ;
      private int Z57CompartInternoId ;
      private int A57CompartInternoId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode19 ;
      private bool returnInSub ;
      private bool Z59CompartInternoAtivo ;
      private bool A59CompartInternoAtivo ;
      private bool AV16IsOk ;
      private bool GXt_boolean1 ;
      private bool i59CompartInternoAtivo ;
      private bool mustCommit ;
      private string Z58CompartInternoNome ;
      private string A58CompartInternoNome ;
      private IGxSession AV12WebSession ;
      private SdtCompartInterno bcCompartInterno ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000J4_A57CompartInternoId ;
      private string[] BC000J4_A58CompartInternoNome ;
      private bool[] BC000J4_A59CompartInternoAtivo ;
      private int[] BC000J5_A57CompartInternoId ;
      private int[] BC000J3_A57CompartInternoId ;
      private string[] BC000J3_A58CompartInternoNome ;
      private bool[] BC000J3_A59CompartInternoAtivo ;
      private int[] BC000J2_A57CompartInternoId ;
      private string[] BC000J2_A58CompartInternoNome ;
      private bool[] BC000J2_A59CompartInternoAtivo ;
      private int[] BC000J6_A57CompartInternoId ;
      private int[] BC000J9_A57CompartInternoId ;
      private int[] BC000J9_A75DocumentoId ;
      private int[] BC000J10_A57CompartInternoId ;
      private string[] BC000J10_A58CompartInternoNome ;
      private bool[] BC000J10_A59CompartInternoAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class compartinterno_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class compartinterno_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000J4;
        prmBC000J4 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000J5;
        prmBC000J5 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000J3;
        prmBC000J3 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000J2;
        prmBC000J2 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000J6;
        prmBC000J6 = new Object[] {
        new ParDef("@CompartInternoNome",GXType.NVarChar,100,0) ,
        new ParDef("@CompartInternoAtivo",GXType.Boolean,4,0)
        };
        Object[] prmBC000J7;
        prmBC000J7 = new Object[] {
        new ParDef("@CompartInternoNome",GXType.NVarChar,100,0) ,
        new ParDef("@CompartInternoAtivo",GXType.Boolean,4,0) ,
        new ParDef("@CompartInternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000J8;
        prmBC000J8 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000J9;
        prmBC000J9 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000J10;
        prmBC000J10 = new Object[] {
        new ParDef("@CompartInternoId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000J2", "SELECT [CompartInternoId], [CompartInternoNome], [CompartInternoAtivo] FROM [CompartInterno] WITH (UPDLOCK) WHERE [CompartInternoId] = @CompartInternoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000J3", "SELECT [CompartInternoId], [CompartInternoNome], [CompartInternoAtivo] FROM [CompartInterno] WHERE [CompartInternoId] = @CompartInternoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000J4", "SELECT TM1.[CompartInternoId], TM1.[CompartInternoNome], TM1.[CompartInternoAtivo] FROM [CompartInterno] TM1 WHERE TM1.[CompartInternoId] = @CompartInternoId ORDER BY TM1.[CompartInternoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000J5", "SELECT [CompartInternoId] FROM [CompartInterno] WHERE [CompartInternoId] = @CompartInternoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000J6", "INSERT INTO [CompartInterno]([CompartInternoNome], [CompartInternoAtivo]) VALUES(@CompartInternoNome, @CompartInternoAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000J7", "UPDATE [CompartInterno] SET [CompartInternoNome]=@CompartInternoNome, [CompartInternoAtivo]=@CompartInternoAtivo  WHERE [CompartInternoId] = @CompartInternoId", GxErrorMask.GX_NOMASK,prmBC000J7)
           ,new CursorDef("BC000J8", "DELETE FROM [CompartInterno]  WHERE [CompartInternoId] = @CompartInternoId", GxErrorMask.GX_NOMASK,prmBC000J8)
           ,new CursorDef("BC000J9", "SELECT TOP 1 [CompartInternoId], [DocumentoId] FROM [DocCompartInterno] WHERE [CompartInternoId] = @CompartInternoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000J10", "SELECT TM1.[CompartInternoId], TM1.[CompartInternoNome], TM1.[CompartInternoAtivo] FROM [CompartInterno] TM1 WHERE TM1.[CompartInternoId] = @CompartInternoId ORDER BY TM1.[CompartInternoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J10,100, GxCacheFrequency.OFF ,true,false )
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
