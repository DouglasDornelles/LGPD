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
   public class setorinterno_bc : GXHttpHandler, IGxSilentTrn
   {
      public setorinterno_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public setorinterno_bc( IGxContext context )
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
         ReadRow0K20( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0K20( ) ;
         standaloneModal( ) ;
         AddRow0K20( ) ;
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
            E110K2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z60SetorInternoId = A60SetorInternoId;
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

      protected void CONFIRM_0K0( )
      {
         BeforeValidate0K20( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0K20( ) ;
            }
            else
            {
               CheckExtendedTable0K20( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0K20( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120K2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110K2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV14IsSetorInterno = true;
         AV15SetorInternoId_Out = A60SetorInternoId;
      }

      protected void ZM0K20( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z61SetorInternoNome = A61SetorInternoNome;
            Z62SetorInternoAtivo = A62SetorInternoAtivo;
         }
         if ( GX_JID == -6 )
         {
            Z60SetorInternoId = A60SetorInternoId;
            Z61SetorInternoNome = A61SetorInternoNome;
            Z62SetorInternoAtivo = A62SetorInternoAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A62SetorInternoAtivo) && ( Gx_BScreen == 0 ) )
         {
            A62SetorInternoAtivo = true;
         }
      }

      protected void Load0K20( )
      {
         /* Using cursor BC000K4 */
         pr_default.execute(2, new Object[] {A60SetorInternoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound20 = 1;
            A61SetorInternoNome = BC000K4_A61SetorInternoNome[0];
            A62SetorInternoAtivo = BC000K4_A62SetorInternoAtivo[0];
            ZM0K20( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0K20( ) ;
      }

      protected void OnLoadActions0K20( )
      {
         A61SetorInternoNome = StringUtil.Upper( A61SetorInternoNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "SetorInterno",  A60SetorInternoId,  A61SetorInternoNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
      }

      protected void CheckExtendedTable0K20( )
      {
         nIsDirty_20 = 0;
         standaloneModal( ) ;
         nIsDirty_20 = 1;
         A61SetorInternoNome = StringUtil.Upper( A61SetorInternoNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "SetorInterno",  A60SetorInternoId,  A61SetorInternoNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
         if ( ! AV16IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A61SetorInternoNome)) )
         {
            GX_msglist.addItem("Informe o Nome do Setor Interno.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0K20( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0K20( )
      {
         /* Using cursor BC000K5 */
         pr_default.execute(3, new Object[] {A60SetorInternoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound20 = 1;
         }
         else
         {
            RcdFound20 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000K3 */
         pr_default.execute(1, new Object[] {A60SetorInternoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0K20( 6) ;
            RcdFound20 = 1;
            A60SetorInternoId = BC000K3_A60SetorInternoId[0];
            A61SetorInternoNome = BC000K3_A61SetorInternoNome[0];
            A62SetorInternoAtivo = BC000K3_A62SetorInternoAtivo[0];
            Z60SetorInternoId = A60SetorInternoId;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0K20( ) ;
            if ( AnyError == 1 )
            {
               RcdFound20 = 0;
               InitializeNonKey0K20( ) ;
            }
            Gx_mode = sMode20;
         }
         else
         {
            RcdFound20 = 0;
            InitializeNonKey0K20( ) ;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode20;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0K20( ) ;
         if ( RcdFound20 == 0 )
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
         CONFIRM_0K0( ) ;
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

      protected void CheckOptimisticConcurrency0K20( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000K2 */
            pr_default.execute(0, new Object[] {A60SetorInternoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SetorInterno"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z61SetorInternoNome, BC000K2_A61SetorInternoNome[0]) != 0 ) || ( Z62SetorInternoAtivo != BC000K2_A62SetorInternoAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SetorInterno"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0K20( )
      {
         BeforeValidate0K20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0K20( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0K20( 0) ;
            CheckOptimisticConcurrency0K20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0K20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0K20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000K6 */
                     pr_default.execute(4, new Object[] {A61SetorInternoNome, A62SetorInternoAtivo});
                     A60SetorInternoId = BC000K6_A60SetorInternoId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("SetorInterno");
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
               Load0K20( ) ;
            }
            EndLevel0K20( ) ;
         }
         CloseExtendedTableCursors0K20( ) ;
      }

      protected void Update0K20( )
      {
         BeforeValidate0K20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0K20( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0K20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0K20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0K20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000K7 */
                     pr_default.execute(5, new Object[] {A61SetorInternoNome, A62SetorInternoAtivo, A60SetorInternoId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("SetorInterno");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SetorInterno"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0K20( ) ;
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
            EndLevel0K20( ) ;
         }
         CloseExtendedTableCursors0K20( ) ;
      }

      protected void DeferredUpdate0K20( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0K20( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0K20( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0K20( ) ;
            AfterConfirm0K20( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0K20( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000K8 */
                  pr_default.execute(6, new Object[] {A60SetorInternoId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("SetorInterno");
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
         sMode20 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0K20( ) ;
         Gx_mode = sMode20;
      }

      protected void OnDeleteControls0K20( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV16IsOk;
            new validanome(context ).execute(  "SetorInterno",  A60SetorInternoId,  A61SetorInternoNome, out  GXt_boolean1) ;
            AV16IsOk = GXt_boolean1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000K9 */
            pr_default.execute(7, new Object[] {A60SetorInternoId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Doc Setor Interno"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0K20( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0K20( ) ;
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

      public void ScanKeyStart0K20( )
      {
         /* Scan By routine */
         /* Using cursor BC000K10 */
         pr_default.execute(8, new Object[] {A60SetorInternoId});
         RcdFound20 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound20 = 1;
            A60SetorInternoId = BC000K10_A60SetorInternoId[0];
            A61SetorInternoNome = BC000K10_A61SetorInternoNome[0];
            A62SetorInternoAtivo = BC000K10_A62SetorInternoAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0K20( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound20 = 0;
         ScanKeyLoad0K20( ) ;
      }

      protected void ScanKeyLoad0K20( )
      {
         sMode20 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound20 = 1;
            A60SetorInternoId = BC000K10_A60SetorInternoId[0];
            A61SetorInternoNome = BC000K10_A61SetorInternoNome[0];
            A62SetorInternoAtivo = BC000K10_A62SetorInternoAtivo[0];
         }
         Gx_mode = sMode20;
      }

      protected void ScanKeyEnd0K20( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0K20( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0K20( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0K20( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0K20( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0K20( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0K20( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0K20( )
      {
      }

      protected void send_integrity_lvl_hashes0K20( )
      {
      }

      protected void AddRow0K20( )
      {
         VarsToRow20( bcSetorInterno) ;
      }

      protected void ReadRow0K20( )
      {
         RowToVars20( bcSetorInterno, 1) ;
      }

      protected void InitializeNonKey0K20( )
      {
         A61SetorInternoNome = "";
         AV16IsOk = false;
         A62SetorInternoAtivo = true;
         Z61SetorInternoNome = "";
         Z62SetorInternoAtivo = false;
      }

      protected void InitAll0K20( )
      {
         A60SetorInternoId = 0;
         InitializeNonKey0K20( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A62SetorInternoAtivo = i62SetorInternoAtivo;
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

      public void VarsToRow20( SdtSetorInterno obj20 )
      {
         obj20.gxTpr_Mode = Gx_mode;
         obj20.gxTpr_Setorinternonome = A61SetorInternoNome;
         obj20.gxTpr_Setorinternoativo = A62SetorInternoAtivo;
         obj20.gxTpr_Setorinternoid = A60SetorInternoId;
         obj20.gxTpr_Setorinternoid_Z = Z60SetorInternoId;
         obj20.gxTpr_Setorinternonome_Z = Z61SetorInternoNome;
         obj20.gxTpr_Setorinternoativo_Z = Z62SetorInternoAtivo;
         obj20.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow20( SdtSetorInterno obj20 )
      {
         obj20.gxTpr_Setorinternoid = A60SetorInternoId;
         return  ;
      }

      public void RowToVars20( SdtSetorInterno obj20 ,
                               int forceLoad )
      {
         Gx_mode = obj20.gxTpr_Mode;
         A61SetorInternoNome = obj20.gxTpr_Setorinternonome;
         A62SetorInternoAtivo = obj20.gxTpr_Setorinternoativo;
         A60SetorInternoId = obj20.gxTpr_Setorinternoid;
         Z60SetorInternoId = obj20.gxTpr_Setorinternoid_Z;
         Z61SetorInternoNome = obj20.gxTpr_Setorinternonome_Z;
         Z62SetorInternoAtivo = obj20.gxTpr_Setorinternoativo_Z;
         Gx_mode = obj20.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A60SetorInternoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0K20( ) ;
         ScanKeyStart0K20( ) ;
         if ( RcdFound20 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z60SetorInternoId = A60SetorInternoId;
         }
         ZM0K20( -6) ;
         OnLoadActions0K20( ) ;
         AddRow0K20( ) ;
         ScanKeyEnd0K20( ) ;
         if ( RcdFound20 == 0 )
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
         RowToVars20( bcSetorInterno, 0) ;
         ScanKeyStart0K20( ) ;
         if ( RcdFound20 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z60SetorInternoId = A60SetorInternoId;
         }
         ZM0K20( -6) ;
         OnLoadActions0K20( ) ;
         AddRow0K20( ) ;
         ScanKeyEnd0K20( ) ;
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0K20( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0K20( ) ;
         }
         else
         {
            if ( RcdFound20 == 1 )
            {
               if ( A60SetorInternoId != Z60SetorInternoId )
               {
                  A60SetorInternoId = Z60SetorInternoId;
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
                  Update0K20( ) ;
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
                  if ( A60SetorInternoId != Z60SetorInternoId )
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
                        Insert0K20( ) ;
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
                        Insert0K20( ) ;
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
         RowToVars20( bcSetorInterno, 1) ;
         SaveImpl( ) ;
         VarsToRow20( bcSetorInterno) ;
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
         RowToVars20( bcSetorInterno, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0K20( ) ;
         AfterTrn( ) ;
         VarsToRow20( bcSetorInterno) ;
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
            SdtSetorInterno auxBC = new SdtSetorInterno(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A60SetorInternoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcSetorInterno);
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
         RowToVars20( bcSetorInterno, 1) ;
         UpdateImpl( ) ;
         VarsToRow20( bcSetorInterno) ;
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
         RowToVars20( bcSetorInterno, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0K20( ) ;
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
         VarsToRow20( bcSetorInterno) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars20( bcSetorInterno, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0K20( ) ;
         if ( RcdFound20 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A60SetorInternoId != Z60SetorInternoId )
            {
               A60SetorInternoId = Z60SetorInternoId;
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
            if ( A60SetorInternoId != Z60SetorInternoId )
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
         context.RollbackDataStores("setorinterno_bc",pr_default);
         VarsToRow20( bcSetorInterno) ;
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
         Gx_mode = bcSetorInterno.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcSetorInterno.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcSetorInterno )
         {
            bcSetorInterno = (SdtSetorInterno)(sdt);
            if ( StringUtil.StrCmp(bcSetorInterno.gxTpr_Mode, "") == 0 )
            {
               bcSetorInterno.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow20( bcSetorInterno) ;
            }
            else
            {
               RowToVars20( bcSetorInterno, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcSetorInterno.gxTpr_Mode, "") == 0 )
            {
               bcSetorInterno.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars20( bcSetorInterno, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtSetorInterno SetorInterno_BC
      {
         get {
            return bcSetorInterno ;
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
            return "setorinterno_Execute" ;
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
         Z61SetorInternoNome = "";
         A61SetorInternoNome = "";
         BC000K4_A60SetorInternoId = new int[1] ;
         BC000K4_A61SetorInternoNome = new string[] {""} ;
         BC000K4_A62SetorInternoAtivo = new bool[] {false} ;
         BC000K5_A60SetorInternoId = new int[1] ;
         BC000K3_A60SetorInternoId = new int[1] ;
         BC000K3_A61SetorInternoNome = new string[] {""} ;
         BC000K3_A62SetorInternoAtivo = new bool[] {false} ;
         sMode20 = "";
         BC000K2_A60SetorInternoId = new int[1] ;
         BC000K2_A61SetorInternoNome = new string[] {""} ;
         BC000K2_A62SetorInternoAtivo = new bool[] {false} ;
         BC000K6_A60SetorInternoId = new int[1] ;
         BC000K9_A60SetorInternoId = new int[1] ;
         BC000K9_A75DocumentoId = new int[1] ;
         BC000K10_A60SetorInternoId = new int[1] ;
         BC000K10_A61SetorInternoNome = new string[] {""} ;
         BC000K10_A62SetorInternoAtivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.setorinterno_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.setorinterno_bc__default(),
            new Object[][] {
                new Object[] {
               BC000K2_A60SetorInternoId, BC000K2_A61SetorInternoNome, BC000K2_A62SetorInternoAtivo
               }
               , new Object[] {
               BC000K3_A60SetorInternoId, BC000K3_A61SetorInternoNome, BC000K3_A62SetorInternoAtivo
               }
               , new Object[] {
               BC000K4_A60SetorInternoId, BC000K4_A61SetorInternoNome, BC000K4_A62SetorInternoAtivo
               }
               , new Object[] {
               BC000K5_A60SetorInternoId
               }
               , new Object[] {
               BC000K6_A60SetorInternoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000K9_A60SetorInternoId, BC000K9_A75DocumentoId
               }
               , new Object[] {
               BC000K10_A60SetorInternoId, BC000K10_A61SetorInternoNome, BC000K10_A62SetorInternoAtivo
               }
            }
         );
         Z62SetorInternoAtivo = true;
         A62SetorInternoAtivo = true;
         i62SetorInternoAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120K2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound20 ;
      private short nIsDirty_20 ;
      private int trnEnded ;
      private int Z60SetorInternoId ;
      private int A60SetorInternoId ;
      private int AV15SetorInternoId_Out ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode20 ;
      private bool returnInSub ;
      private bool AV14IsSetorInterno ;
      private bool Z62SetorInternoAtivo ;
      private bool A62SetorInternoAtivo ;
      private bool AV16IsOk ;
      private bool GXt_boolean1 ;
      private bool i62SetorInternoAtivo ;
      private bool mustCommit ;
      private string Z61SetorInternoNome ;
      private string A61SetorInternoNome ;
      private IGxSession AV12WebSession ;
      private SdtSetorInterno bcSetorInterno ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000K4_A60SetorInternoId ;
      private string[] BC000K4_A61SetorInternoNome ;
      private bool[] BC000K4_A62SetorInternoAtivo ;
      private int[] BC000K5_A60SetorInternoId ;
      private int[] BC000K3_A60SetorInternoId ;
      private string[] BC000K3_A61SetorInternoNome ;
      private bool[] BC000K3_A62SetorInternoAtivo ;
      private int[] BC000K2_A60SetorInternoId ;
      private string[] BC000K2_A61SetorInternoNome ;
      private bool[] BC000K2_A62SetorInternoAtivo ;
      private int[] BC000K6_A60SetorInternoId ;
      private int[] BC000K9_A60SetorInternoId ;
      private int[] BC000K9_A75DocumentoId ;
      private int[] BC000K10_A60SetorInternoId ;
      private string[] BC000K10_A61SetorInternoNome ;
      private bool[] BC000K10_A62SetorInternoAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class setorinterno_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class setorinterno_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000K4;
        prmBC000K4 = new Object[] {
        new ParDef("@SetorInternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000K5;
        prmBC000K5 = new Object[] {
        new ParDef("@SetorInternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000K3;
        prmBC000K3 = new Object[] {
        new ParDef("@SetorInternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000K2;
        prmBC000K2 = new Object[] {
        new ParDef("@SetorInternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000K6;
        prmBC000K6 = new Object[] {
        new ParDef("@SetorInternoNome",GXType.NVarChar,100,0) ,
        new ParDef("@SetorInternoAtivo",GXType.Boolean,4,0)
        };
        Object[] prmBC000K7;
        prmBC000K7 = new Object[] {
        new ParDef("@SetorInternoNome",GXType.NVarChar,100,0) ,
        new ParDef("@SetorInternoAtivo",GXType.Boolean,4,0) ,
        new ParDef("@SetorInternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000K8;
        prmBC000K8 = new Object[] {
        new ParDef("@SetorInternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000K9;
        prmBC000K9 = new Object[] {
        new ParDef("@SetorInternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000K10;
        prmBC000K10 = new Object[] {
        new ParDef("@SetorInternoId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000K2", "SELECT [SetorInternoId], [SetorInternoNome], [SetorInternoAtivo] FROM [SetorInterno] WITH (UPDLOCK) WHERE [SetorInternoId] = @SetorInternoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000K3", "SELECT [SetorInternoId], [SetorInternoNome], [SetorInternoAtivo] FROM [SetorInterno] WHERE [SetorInternoId] = @SetorInternoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000K4", "SELECT TM1.[SetorInternoId], TM1.[SetorInternoNome], TM1.[SetorInternoAtivo] FROM [SetorInterno] TM1 WHERE TM1.[SetorInternoId] = @SetorInternoId ORDER BY TM1.[SetorInternoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000K5", "SELECT [SetorInternoId] FROM [SetorInterno] WHERE [SetorInternoId] = @SetorInternoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000K6", "INSERT INTO [SetorInterno]([SetorInternoNome], [SetorInternoAtivo]) VALUES(@SetorInternoNome, @SetorInternoAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000K7", "UPDATE [SetorInterno] SET [SetorInternoNome]=@SetorInternoNome, [SetorInternoAtivo]=@SetorInternoAtivo  WHERE [SetorInternoId] = @SetorInternoId", GxErrorMask.GX_NOMASK,prmBC000K7)
           ,new CursorDef("BC000K8", "DELETE FROM [SetorInterno]  WHERE [SetorInternoId] = @SetorInternoId", GxErrorMask.GX_NOMASK,prmBC000K8)
           ,new CursorDef("BC000K9", "SELECT TOP 1 [SetorInternoId], [DocumentoId] FROM [DocSetorInterno] WHERE [SetorInternoId] = @SetorInternoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000K10", "SELECT TM1.[SetorInternoId], TM1.[SetorInternoNome], TM1.[SetorInternoAtivo] FROM [SetorInterno] TM1 WHERE TM1.[SetorInternoId] = @SetorInternoId ORDER BY TM1.[SetorInternoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K10,100, GxCacheFrequency.OFF ,true,false )
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
