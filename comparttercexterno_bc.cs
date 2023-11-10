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
   public class comparttercexterno_bc : GXHttpHandler, IGxSilentTrn
   {
      public comparttercexterno_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public comparttercexterno_bc( IGxContext context )
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
         ReadRow0M22( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0M22( ) ;
         standaloneModal( ) ;
         AddRow0M22( ) ;
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
            E110M2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z66CompartTercExternoId = A66CompartTercExternoId;
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

      protected void CONFIRM_0M0( )
      {
         BeforeValidate0M22( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0M22( ) ;
            }
            else
            {
               CheckExtendedTable0M22( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0M22( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120M2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110M2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV14IsCompartTercExterno = true;
         AV13CompartTercExternoId_Out = A66CompartTercExternoId;
      }

      protected void ZM0M22( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z67CompartTercExternoNome = A67CompartTercExternoNome;
            Z68CompartTercExternoAtivo = A68CompartTercExternoAtivo;
         }
         if ( GX_JID == -6 )
         {
            Z66CompartTercExternoId = A66CompartTercExternoId;
            Z67CompartTercExternoNome = A67CompartTercExternoNome;
            Z68CompartTercExternoAtivo = A68CompartTercExternoAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A68CompartTercExternoAtivo) && ( Gx_BScreen == 0 ) )
         {
            A68CompartTercExternoAtivo = true;
         }
      }

      protected void Load0M22( )
      {
         /* Using cursor BC000M4 */
         pr_default.execute(2, new Object[] {A66CompartTercExternoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound22 = 1;
            A67CompartTercExternoNome = BC000M4_A67CompartTercExternoNome[0];
            A68CompartTercExternoAtivo = BC000M4_A68CompartTercExternoAtivo[0];
            ZM0M22( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0M22( ) ;
      }

      protected void OnLoadActions0M22( )
      {
         A67CompartTercExternoNome = StringUtil.Upper( A67CompartTercExternoNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "CompartTercExterno",  A66CompartTercExternoId,  A67CompartTercExternoNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
      }

      protected void CheckExtendedTable0M22( )
      {
         nIsDirty_22 = 0;
         standaloneModal( ) ;
         nIsDirty_22 = 1;
         A67CompartTercExternoNome = StringUtil.Upper( A67CompartTercExternoNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "CompartTercExterno",  A66CompartTercExternoId,  A67CompartTercExternoNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
         if ( ! AV15IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A67CompartTercExternoNome)) )
         {
            GX_msglist.addItem("Informe o nome do Compartilhamento de Terceiros Externos.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0M22( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0M22( )
      {
         /* Using cursor BC000M5 */
         pr_default.execute(3, new Object[] {A66CompartTercExternoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound22 = 1;
         }
         else
         {
            RcdFound22 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000M3 */
         pr_default.execute(1, new Object[] {A66CompartTercExternoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0M22( 6) ;
            RcdFound22 = 1;
            A66CompartTercExternoId = BC000M3_A66CompartTercExternoId[0];
            A67CompartTercExternoNome = BC000M3_A67CompartTercExternoNome[0];
            A68CompartTercExternoAtivo = BC000M3_A68CompartTercExternoAtivo[0];
            Z66CompartTercExternoId = A66CompartTercExternoId;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0M22( ) ;
            if ( AnyError == 1 )
            {
               RcdFound22 = 0;
               InitializeNonKey0M22( ) ;
            }
            Gx_mode = sMode22;
         }
         else
         {
            RcdFound22 = 0;
            InitializeNonKey0M22( ) ;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode22;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0M22( ) ;
         if ( RcdFound22 == 0 )
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
         CONFIRM_0M0( ) ;
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

      protected void CheckOptimisticConcurrency0M22( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000M2 */
            pr_default.execute(0, new Object[] {A66CompartTercExternoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CompartTercExterno"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z67CompartTercExternoNome, BC000M2_A67CompartTercExternoNome[0]) != 0 ) || ( Z68CompartTercExternoAtivo != BC000M2_A68CompartTercExternoAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CompartTercExterno"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0M22( )
      {
         BeforeValidate0M22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M22( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0M22( 0) ;
            CheckOptimisticConcurrency0M22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0M22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000M6 */
                     pr_default.execute(4, new Object[] {A67CompartTercExternoNome, A68CompartTercExternoAtivo});
                     A66CompartTercExternoId = BC000M6_A66CompartTercExternoId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("CompartTercExterno");
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
               Load0M22( ) ;
            }
            EndLevel0M22( ) ;
         }
         CloseExtendedTableCursors0M22( ) ;
      }

      protected void Update0M22( )
      {
         BeforeValidate0M22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M22( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0M22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000M7 */
                     pr_default.execute(5, new Object[] {A67CompartTercExternoNome, A68CompartTercExternoAtivo, A66CompartTercExternoId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("CompartTercExterno");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CompartTercExterno"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0M22( ) ;
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
            EndLevel0M22( ) ;
         }
         CloseExtendedTableCursors0M22( ) ;
      }

      protected void DeferredUpdate0M22( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0M22( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M22( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0M22( ) ;
            AfterConfirm0M22( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0M22( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000M8 */
                  pr_default.execute(6, new Object[] {A66CompartTercExternoId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("CompartTercExterno");
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
         sMode22 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0M22( ) ;
         Gx_mode = sMode22;
      }

      protected void OnDeleteControls0M22( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV15IsOk;
            new validanome(context ).execute(  "CompartTercExterno",  A66CompartTercExternoId,  A67CompartTercExternoNome, out  GXt_boolean1) ;
            AV15IsOk = GXt_boolean1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000M9 */
            pr_default.execute(7, new Object[] {A66CompartTercExternoId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"DicionarioCompartTercExt"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0M22( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0M22( ) ;
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

      public void ScanKeyStart0M22( )
      {
         /* Scan By routine */
         /* Using cursor BC000M10 */
         pr_default.execute(8, new Object[] {A66CompartTercExternoId});
         RcdFound22 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound22 = 1;
            A66CompartTercExternoId = BC000M10_A66CompartTercExternoId[0];
            A67CompartTercExternoNome = BC000M10_A67CompartTercExternoNome[0];
            A68CompartTercExternoAtivo = BC000M10_A68CompartTercExternoAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0M22( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound22 = 0;
         ScanKeyLoad0M22( ) ;
      }

      protected void ScanKeyLoad0M22( )
      {
         sMode22 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound22 = 1;
            A66CompartTercExternoId = BC000M10_A66CompartTercExternoId[0];
            A67CompartTercExternoNome = BC000M10_A67CompartTercExternoNome[0];
            A68CompartTercExternoAtivo = BC000M10_A68CompartTercExternoAtivo[0];
         }
         Gx_mode = sMode22;
      }

      protected void ScanKeyEnd0M22( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0M22( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0M22( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0M22( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0M22( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0M22( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0M22( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0M22( )
      {
      }

      protected void send_integrity_lvl_hashes0M22( )
      {
      }

      protected void AddRow0M22( )
      {
         VarsToRow22( bcCompartTercExterno) ;
      }

      protected void ReadRow0M22( )
      {
         RowToVars22( bcCompartTercExterno, 1) ;
      }

      protected void InitializeNonKey0M22( )
      {
         A67CompartTercExternoNome = "";
         AV15IsOk = false;
         A68CompartTercExternoAtivo = true;
         Z67CompartTercExternoNome = "";
         Z68CompartTercExternoAtivo = false;
      }

      protected void InitAll0M22( )
      {
         A66CompartTercExternoId = 0;
         InitializeNonKey0M22( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A68CompartTercExternoAtivo = i68CompartTercExternoAtivo;
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

      public void VarsToRow22( SdtCompartTercExterno obj22 )
      {
         obj22.gxTpr_Mode = Gx_mode;
         obj22.gxTpr_Comparttercexternonome = A67CompartTercExternoNome;
         obj22.gxTpr_Comparttercexternoativo = A68CompartTercExternoAtivo;
         obj22.gxTpr_Comparttercexternoid = A66CompartTercExternoId;
         obj22.gxTpr_Comparttercexternoid_Z = Z66CompartTercExternoId;
         obj22.gxTpr_Comparttercexternonome_Z = Z67CompartTercExternoNome;
         obj22.gxTpr_Comparttercexternoativo_Z = Z68CompartTercExternoAtivo;
         obj22.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow22( SdtCompartTercExterno obj22 )
      {
         obj22.gxTpr_Comparttercexternoid = A66CompartTercExternoId;
         return  ;
      }

      public void RowToVars22( SdtCompartTercExterno obj22 ,
                               int forceLoad )
      {
         Gx_mode = obj22.gxTpr_Mode;
         A67CompartTercExternoNome = obj22.gxTpr_Comparttercexternonome;
         A68CompartTercExternoAtivo = obj22.gxTpr_Comparttercexternoativo;
         A66CompartTercExternoId = obj22.gxTpr_Comparttercexternoid;
         Z66CompartTercExternoId = obj22.gxTpr_Comparttercexternoid_Z;
         Z67CompartTercExternoNome = obj22.gxTpr_Comparttercexternonome_Z;
         Z68CompartTercExternoAtivo = obj22.gxTpr_Comparttercexternoativo_Z;
         Gx_mode = obj22.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A66CompartTercExternoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0M22( ) ;
         ScanKeyStart0M22( ) ;
         if ( RcdFound22 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z66CompartTercExternoId = A66CompartTercExternoId;
         }
         ZM0M22( -6) ;
         OnLoadActions0M22( ) ;
         AddRow0M22( ) ;
         ScanKeyEnd0M22( ) ;
         if ( RcdFound22 == 0 )
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
         RowToVars22( bcCompartTercExterno, 0) ;
         ScanKeyStart0M22( ) ;
         if ( RcdFound22 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z66CompartTercExternoId = A66CompartTercExternoId;
         }
         ZM0M22( -6) ;
         OnLoadActions0M22( ) ;
         AddRow0M22( ) ;
         ScanKeyEnd0M22( ) ;
         if ( RcdFound22 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0M22( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0M22( ) ;
         }
         else
         {
            if ( RcdFound22 == 1 )
            {
               if ( A66CompartTercExternoId != Z66CompartTercExternoId )
               {
                  A66CompartTercExternoId = Z66CompartTercExternoId;
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
                  Update0M22( ) ;
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
                  if ( A66CompartTercExternoId != Z66CompartTercExternoId )
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
                        Insert0M22( ) ;
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
                        Insert0M22( ) ;
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
         RowToVars22( bcCompartTercExterno, 1) ;
         SaveImpl( ) ;
         VarsToRow22( bcCompartTercExterno) ;
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
         RowToVars22( bcCompartTercExterno, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0M22( ) ;
         AfterTrn( ) ;
         VarsToRow22( bcCompartTercExterno) ;
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
            SdtCompartTercExterno auxBC = new SdtCompartTercExterno(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A66CompartTercExternoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcCompartTercExterno);
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
         RowToVars22( bcCompartTercExterno, 1) ;
         UpdateImpl( ) ;
         VarsToRow22( bcCompartTercExterno) ;
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
         RowToVars22( bcCompartTercExterno, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0M22( ) ;
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
         VarsToRow22( bcCompartTercExterno) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars22( bcCompartTercExterno, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0M22( ) ;
         if ( RcdFound22 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A66CompartTercExternoId != Z66CompartTercExternoId )
            {
               A66CompartTercExternoId = Z66CompartTercExternoId;
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
            if ( A66CompartTercExternoId != Z66CompartTercExternoId )
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
         context.RollbackDataStores("comparttercexterno_bc",pr_default);
         VarsToRow22( bcCompartTercExterno) ;
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
         Gx_mode = bcCompartTercExterno.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcCompartTercExterno.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcCompartTercExterno )
         {
            bcCompartTercExterno = (SdtCompartTercExterno)(sdt);
            if ( StringUtil.StrCmp(bcCompartTercExterno.gxTpr_Mode, "") == 0 )
            {
               bcCompartTercExterno.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow22( bcCompartTercExterno) ;
            }
            else
            {
               RowToVars22( bcCompartTercExterno, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcCompartTercExterno.gxTpr_Mode, "") == 0 )
            {
               bcCompartTercExterno.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars22( bcCompartTercExterno, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtCompartTercExterno CompartTercExterno_BC
      {
         get {
            return bcCompartTercExterno ;
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
            return "comparttercexterno_Execute" ;
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
         Z67CompartTercExternoNome = "";
         A67CompartTercExternoNome = "";
         BC000M4_A66CompartTercExternoId = new int[1] ;
         BC000M4_A67CompartTercExternoNome = new string[] {""} ;
         BC000M4_A68CompartTercExternoAtivo = new bool[] {false} ;
         BC000M5_A66CompartTercExternoId = new int[1] ;
         BC000M3_A66CompartTercExternoId = new int[1] ;
         BC000M3_A67CompartTercExternoNome = new string[] {""} ;
         BC000M3_A68CompartTercExternoAtivo = new bool[] {false} ;
         sMode22 = "";
         BC000M2_A66CompartTercExternoId = new int[1] ;
         BC000M2_A67CompartTercExternoNome = new string[] {""} ;
         BC000M2_A68CompartTercExternoAtivo = new bool[] {false} ;
         BC000M6_A66CompartTercExternoId = new int[1] ;
         BC000M9_A66CompartTercExternoId = new int[1] ;
         BC000M9_A98DocDicionarioId = new int[1] ;
         BC000M10_A66CompartTercExternoId = new int[1] ;
         BC000M10_A67CompartTercExternoNome = new string[] {""} ;
         BC000M10_A68CompartTercExternoAtivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.comparttercexterno_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comparttercexterno_bc__default(),
            new Object[][] {
                new Object[] {
               BC000M2_A66CompartTercExternoId, BC000M2_A67CompartTercExternoNome, BC000M2_A68CompartTercExternoAtivo
               }
               , new Object[] {
               BC000M3_A66CompartTercExternoId, BC000M3_A67CompartTercExternoNome, BC000M3_A68CompartTercExternoAtivo
               }
               , new Object[] {
               BC000M4_A66CompartTercExternoId, BC000M4_A67CompartTercExternoNome, BC000M4_A68CompartTercExternoAtivo
               }
               , new Object[] {
               BC000M5_A66CompartTercExternoId
               }
               , new Object[] {
               BC000M6_A66CompartTercExternoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000M9_A66CompartTercExternoId, BC000M9_A98DocDicionarioId
               }
               , new Object[] {
               BC000M10_A66CompartTercExternoId, BC000M10_A67CompartTercExternoNome, BC000M10_A68CompartTercExternoAtivo
               }
            }
         );
         Z68CompartTercExternoAtivo = true;
         A68CompartTercExternoAtivo = true;
         i68CompartTercExternoAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120M2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound22 ;
      private short nIsDirty_22 ;
      private int trnEnded ;
      private int Z66CompartTercExternoId ;
      private int A66CompartTercExternoId ;
      private int AV13CompartTercExternoId_Out ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode22 ;
      private bool returnInSub ;
      private bool AV14IsCompartTercExterno ;
      private bool Z68CompartTercExternoAtivo ;
      private bool A68CompartTercExternoAtivo ;
      private bool AV15IsOk ;
      private bool GXt_boolean1 ;
      private bool i68CompartTercExternoAtivo ;
      private bool mustCommit ;
      private string Z67CompartTercExternoNome ;
      private string A67CompartTercExternoNome ;
      private IGxSession AV12WebSession ;
      private SdtCompartTercExterno bcCompartTercExterno ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000M4_A66CompartTercExternoId ;
      private string[] BC000M4_A67CompartTercExternoNome ;
      private bool[] BC000M4_A68CompartTercExternoAtivo ;
      private int[] BC000M5_A66CompartTercExternoId ;
      private int[] BC000M3_A66CompartTercExternoId ;
      private string[] BC000M3_A67CompartTercExternoNome ;
      private bool[] BC000M3_A68CompartTercExternoAtivo ;
      private int[] BC000M2_A66CompartTercExternoId ;
      private string[] BC000M2_A67CompartTercExternoNome ;
      private bool[] BC000M2_A68CompartTercExternoAtivo ;
      private int[] BC000M6_A66CompartTercExternoId ;
      private int[] BC000M9_A66CompartTercExternoId ;
      private int[] BC000M9_A98DocDicionarioId ;
      private int[] BC000M10_A66CompartTercExternoId ;
      private string[] BC000M10_A67CompartTercExternoNome ;
      private bool[] BC000M10_A68CompartTercExternoAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
   }

   public class comparttercexterno_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class comparttercexterno_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000M4;
        prmBC000M4 = new Object[] {
        new ParDef("@CompartTercExternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000M5;
        prmBC000M5 = new Object[] {
        new ParDef("@CompartTercExternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000M3;
        prmBC000M3 = new Object[] {
        new ParDef("@CompartTercExternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000M2;
        prmBC000M2 = new Object[] {
        new ParDef("@CompartTercExternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000M6;
        prmBC000M6 = new Object[] {
        new ParDef("@CompartTercExternoNome",GXType.NVarChar,100,0) ,
        new ParDef("@CompartTercExternoAtivo",GXType.Boolean,4,0)
        };
        Object[] prmBC000M7;
        prmBC000M7 = new Object[] {
        new ParDef("@CompartTercExternoNome",GXType.NVarChar,100,0) ,
        new ParDef("@CompartTercExternoAtivo",GXType.Boolean,4,0) ,
        new ParDef("@CompartTercExternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000M8;
        prmBC000M8 = new Object[] {
        new ParDef("@CompartTercExternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000M9;
        prmBC000M9 = new Object[] {
        new ParDef("@CompartTercExternoId",GXType.Int32,8,0)
        };
        Object[] prmBC000M10;
        prmBC000M10 = new Object[] {
        new ParDef("@CompartTercExternoId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000M2", "SELECT [CompartTercExternoId], [CompartTercExternoNome], [CompartTercExternoAtivo] FROM [CompartTercExterno] WITH (UPDLOCK) WHERE [CompartTercExternoId] = @CompartTercExternoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000M3", "SELECT [CompartTercExternoId], [CompartTercExternoNome], [CompartTercExternoAtivo] FROM [CompartTercExterno] WHERE [CompartTercExternoId] = @CompartTercExternoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000M4", "SELECT TM1.[CompartTercExternoId], TM1.[CompartTercExternoNome], TM1.[CompartTercExternoAtivo] FROM [CompartTercExterno] TM1 WHERE TM1.[CompartTercExternoId] = @CompartTercExternoId ORDER BY TM1.[CompartTercExternoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000M5", "SELECT [CompartTercExternoId] FROM [CompartTercExterno] WHERE [CompartTercExternoId] = @CompartTercExternoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000M6", "INSERT INTO [CompartTercExterno]([CompartTercExternoNome], [CompartTercExternoAtivo]) VALUES(@CompartTercExternoNome, @CompartTercExternoAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000M7", "UPDATE [CompartTercExterno] SET [CompartTercExternoNome]=@CompartTercExternoNome, [CompartTercExternoAtivo]=@CompartTercExternoAtivo  WHERE [CompartTercExternoId] = @CompartTercExternoId", GxErrorMask.GX_NOMASK,prmBC000M7)
           ,new CursorDef("BC000M8", "DELETE FROM [CompartTercExterno]  WHERE [CompartTercExternoId] = @CompartTercExternoId", GxErrorMask.GX_NOMASK,prmBC000M8)
           ,new CursorDef("BC000M9", "SELECT TOP 1 [CompartTercExternoId], [DocDicionarioId] FROM [DicionarioCompartTercExt] WHERE [CompartTercExternoId] = @CompartTercExternoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000M10", "SELECT TM1.[CompartTercExternoId], TM1.[CompartTercExternoNome], TM1.[CompartTercExternoAtivo] FROM [CompartTercExterno] TM1 WHERE TM1.[CompartTercExternoId] = @CompartTercExternoId ORDER BY TM1.[CompartTercExternoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M10,100, GxCacheFrequency.OFF ,true,false )
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
