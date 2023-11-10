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
   public class tipodescarte_bc : GXHttpHandler, IGxSilentTrn
   {
      public tipodescarte_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public tipodescarte_bc( IGxContext context )
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
         ReadRow0F15( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0F15( ) ;
         standaloneModal( ) ;
         AddRow0F15( ) ;
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
            E110F2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z45TipoDescarteId = A45TipoDescarteId;
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

      protected void CONFIRM_0F0( )
      {
         BeforeValidate0F15( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0F15( ) ;
            }
            else
            {
               CheckExtendedTable0F15( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0F15( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120F2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110F2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV14IsTipoDescarte = true;
         AV15TipoDescarteId_Out = A45TipoDescarteId;
      }

      protected void ZM0F15( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z46TipoDescarteNome = A46TipoDescarteNome;
            Z47TipoDescarteAtivo = A47TipoDescarteAtivo;
         }
         if ( GX_JID == -6 )
         {
            Z45TipoDescarteId = A45TipoDescarteId;
            Z46TipoDescarteNome = A46TipoDescarteNome;
            Z47TipoDescarteAtivo = A47TipoDescarteAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A47TipoDescarteAtivo) && ( Gx_BScreen == 0 ) )
         {
            A47TipoDescarteAtivo = true;
         }
      }

      protected void Load0F15( )
      {
         /* Using cursor BC000F4 */
         pr_default.execute(2, new Object[] {n45TipoDescarteId, A45TipoDescarteId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound15 = 1;
            A46TipoDescarteNome = BC000F4_A46TipoDescarteNome[0];
            A47TipoDescarteAtivo = BC000F4_A47TipoDescarteAtivo[0];
            ZM0F15( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0F15( ) ;
      }

      protected void OnLoadActions0F15( )
      {
         A46TipoDescarteNome = StringUtil.Upper( A46TipoDescarteNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "TipoDescarte",  A45TipoDescarteId,  A46TipoDescarteNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
      }

      protected void CheckExtendedTable0F15( )
      {
         nIsDirty_15 = 0;
         standaloneModal( ) ;
         nIsDirty_15 = 1;
         A46TipoDescarteNome = StringUtil.Upper( A46TipoDescarteNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "TipoDescarte",  A45TipoDescarteId,  A46TipoDescarteNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
         if ( ! AV16IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A46TipoDescarteNome)) )
         {
            GX_msglist.addItem("Informe o nome do tipo de descarte.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0F15( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0F15( )
      {
         /* Using cursor BC000F5 */
         pr_default.execute(3, new Object[] {n45TipoDescarteId, A45TipoDescarteId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000F3 */
         pr_default.execute(1, new Object[] {n45TipoDescarteId, A45TipoDescarteId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F15( 6) ;
            RcdFound15 = 1;
            A45TipoDescarteId = BC000F3_A45TipoDescarteId[0];
            n45TipoDescarteId = BC000F3_n45TipoDescarteId[0];
            A46TipoDescarteNome = BC000F3_A46TipoDescarteNome[0];
            A47TipoDescarteAtivo = BC000F3_A47TipoDescarteAtivo[0];
            Z45TipoDescarteId = A45TipoDescarteId;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0F15( ) ;
            if ( AnyError == 1 )
            {
               RcdFound15 = 0;
               InitializeNonKey0F15( ) ;
            }
            Gx_mode = sMode15;
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0F15( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode15;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F15( ) ;
         if ( RcdFound15 == 0 )
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
         CONFIRM_0F0( ) ;
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

      protected void CheckOptimisticConcurrency0F15( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000F2 */
            pr_default.execute(0, new Object[] {n45TipoDescarteId, A45TipoDescarteId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TipoDescarte"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z46TipoDescarteNome, BC000F2_A46TipoDescarteNome[0]) != 0 ) || ( Z47TipoDescarteAtivo != BC000F2_A47TipoDescarteAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TipoDescarte"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F15( )
      {
         BeforeValidate0F15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F15( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F15( 0) ;
            CheckOptimisticConcurrency0F15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F6 */
                     pr_default.execute(4, new Object[] {A46TipoDescarteNome, A47TipoDescarteAtivo});
                     A45TipoDescarteId = BC000F6_A45TipoDescarteId[0];
                     n45TipoDescarteId = BC000F6_n45TipoDescarteId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("TipoDescarte");
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
               Load0F15( ) ;
            }
            EndLevel0F15( ) ;
         }
         CloseExtendedTableCursors0F15( ) ;
      }

      protected void Update0F15( )
      {
         BeforeValidate0F15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F15( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F7 */
                     pr_default.execute(5, new Object[] {A46TipoDescarteNome, A47TipoDescarteAtivo, n45TipoDescarteId, A45TipoDescarteId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("TipoDescarte");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TipoDescarte"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F15( ) ;
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
            EndLevel0F15( ) ;
         }
         CloseExtendedTableCursors0F15( ) ;
      }

      protected void DeferredUpdate0F15( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0F15( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F15( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F15( ) ;
            AfterConfirm0F15( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F15( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000F8 */
                  pr_default.execute(6, new Object[] {n45TipoDescarteId, A45TipoDescarteId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("TipoDescarte");
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
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0F15( ) ;
         Gx_mode = sMode15;
      }

      protected void OnDeleteControls0F15( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV16IsOk;
            new validanome(context ).execute(  "TipoDescarte",  A45TipoDescarteId,  A46TipoDescarteNome, out  GXt_boolean1) ;
            AV16IsOk = GXt_boolean1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000F9 */
            pr_default.execute(7, new Object[] {n45TipoDescarteId, A45TipoDescarteId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0F15( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F15( ) ;
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

      public void ScanKeyStart0F15( )
      {
         /* Scan By routine */
         /* Using cursor BC000F10 */
         pr_default.execute(8, new Object[] {n45TipoDescarteId, A45TipoDescarteId});
         RcdFound15 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound15 = 1;
            A45TipoDescarteId = BC000F10_A45TipoDescarteId[0];
            n45TipoDescarteId = BC000F10_n45TipoDescarteId[0];
            A46TipoDescarteNome = BC000F10_A46TipoDescarteNome[0];
            A47TipoDescarteAtivo = BC000F10_A47TipoDescarteAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0F15( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound15 = 0;
         ScanKeyLoad0F15( ) ;
      }

      protected void ScanKeyLoad0F15( )
      {
         sMode15 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound15 = 1;
            A45TipoDescarteId = BC000F10_A45TipoDescarteId[0];
            n45TipoDescarteId = BC000F10_n45TipoDescarteId[0];
            A46TipoDescarteNome = BC000F10_A46TipoDescarteNome[0];
            A47TipoDescarteAtivo = BC000F10_A47TipoDescarteAtivo[0];
         }
         Gx_mode = sMode15;
      }

      protected void ScanKeyEnd0F15( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0F15( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F15( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F15( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F15( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F15( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F15( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F15( )
      {
      }

      protected void send_integrity_lvl_hashes0F15( )
      {
      }

      protected void AddRow0F15( )
      {
         VarsToRow15( bcTipoDescarte) ;
      }

      protected void ReadRow0F15( )
      {
         RowToVars15( bcTipoDescarte, 1) ;
      }

      protected void InitializeNonKey0F15( )
      {
         A46TipoDescarteNome = "";
         AV16IsOk = false;
         A47TipoDescarteAtivo = true;
         Z46TipoDescarteNome = "";
         Z47TipoDescarteAtivo = false;
      }

      protected void InitAll0F15( )
      {
         A45TipoDescarteId = 0;
         n45TipoDescarteId = false;
         InitializeNonKey0F15( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A47TipoDescarteAtivo = i47TipoDescarteAtivo;
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

      public void VarsToRow15( SdtTipoDescarte obj15 )
      {
         obj15.gxTpr_Mode = Gx_mode;
         obj15.gxTpr_Tipodescartenome = A46TipoDescarteNome;
         obj15.gxTpr_Tipodescarteativo = A47TipoDescarteAtivo;
         obj15.gxTpr_Tipodescarteid = A45TipoDescarteId;
         obj15.gxTpr_Tipodescarteid_Z = Z45TipoDescarteId;
         obj15.gxTpr_Tipodescartenome_Z = Z46TipoDescarteNome;
         obj15.gxTpr_Tipodescarteativo_Z = Z47TipoDescarteAtivo;
         obj15.gxTpr_Tipodescarteid_N = (short)(Convert.ToInt16(n45TipoDescarteId));
         obj15.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow15( SdtTipoDescarte obj15 )
      {
         obj15.gxTpr_Tipodescarteid = A45TipoDescarteId;
         return  ;
      }

      public void RowToVars15( SdtTipoDescarte obj15 ,
                               int forceLoad )
      {
         Gx_mode = obj15.gxTpr_Mode;
         A46TipoDescarteNome = obj15.gxTpr_Tipodescartenome;
         A47TipoDescarteAtivo = obj15.gxTpr_Tipodescarteativo;
         A45TipoDescarteId = obj15.gxTpr_Tipodescarteid;
         n45TipoDescarteId = false;
         Z45TipoDescarteId = obj15.gxTpr_Tipodescarteid_Z;
         Z46TipoDescarteNome = obj15.gxTpr_Tipodescartenome_Z;
         Z47TipoDescarteAtivo = obj15.gxTpr_Tipodescarteativo_Z;
         n45TipoDescarteId = (bool)(Convert.ToBoolean(obj15.gxTpr_Tipodescarteid_N));
         Gx_mode = obj15.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A45TipoDescarteId = (int)getParm(obj,0);
         n45TipoDescarteId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0F15( ) ;
         ScanKeyStart0F15( ) ;
         if ( RcdFound15 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z45TipoDescarteId = A45TipoDescarteId;
         }
         ZM0F15( -6) ;
         OnLoadActions0F15( ) ;
         AddRow0F15( ) ;
         ScanKeyEnd0F15( ) ;
         if ( RcdFound15 == 0 )
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
         RowToVars15( bcTipoDescarte, 0) ;
         ScanKeyStart0F15( ) ;
         if ( RcdFound15 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z45TipoDescarteId = A45TipoDescarteId;
         }
         ZM0F15( -6) ;
         OnLoadActions0F15( ) ;
         AddRow0F15( ) ;
         ScanKeyEnd0F15( ) ;
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0F15( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0F15( ) ;
         }
         else
         {
            if ( RcdFound15 == 1 )
            {
               if ( A45TipoDescarteId != Z45TipoDescarteId )
               {
                  A45TipoDescarteId = Z45TipoDescarteId;
                  n45TipoDescarteId = false;
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
                  Update0F15( ) ;
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
                  if ( A45TipoDescarteId != Z45TipoDescarteId )
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
                        Insert0F15( ) ;
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
                        Insert0F15( ) ;
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
         RowToVars15( bcTipoDescarte, 1) ;
         SaveImpl( ) ;
         VarsToRow15( bcTipoDescarte) ;
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
         RowToVars15( bcTipoDescarte, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F15( ) ;
         AfterTrn( ) ;
         VarsToRow15( bcTipoDescarte) ;
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
            SdtTipoDescarte auxBC = new SdtTipoDescarte(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A45TipoDescarteId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTipoDescarte);
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
         RowToVars15( bcTipoDescarte, 1) ;
         UpdateImpl( ) ;
         VarsToRow15( bcTipoDescarte) ;
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
         RowToVars15( bcTipoDescarte, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F15( ) ;
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
         VarsToRow15( bcTipoDescarte) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars15( bcTipoDescarte, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0F15( ) ;
         if ( RcdFound15 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A45TipoDescarteId != Z45TipoDescarteId )
            {
               A45TipoDescarteId = Z45TipoDescarteId;
               n45TipoDescarteId = false;
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
            if ( A45TipoDescarteId != Z45TipoDescarteId )
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
         context.RollbackDataStores("tipodescarte_bc",pr_default);
         VarsToRow15( bcTipoDescarte) ;
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
         Gx_mode = bcTipoDescarte.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTipoDescarte.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTipoDescarte )
         {
            bcTipoDescarte = (SdtTipoDescarte)(sdt);
            if ( StringUtil.StrCmp(bcTipoDescarte.gxTpr_Mode, "") == 0 )
            {
               bcTipoDescarte.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow15( bcTipoDescarte) ;
            }
            else
            {
               RowToVars15( bcTipoDescarte, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTipoDescarte.gxTpr_Mode, "") == 0 )
            {
               bcTipoDescarte.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars15( bcTipoDescarte, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtTipoDescarte TipoDescarte_BC
      {
         get {
            return bcTipoDescarte ;
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
            return "tipodescarte_Execute" ;
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
         Z46TipoDescarteNome = "";
         A46TipoDescarteNome = "";
         BC000F4_A45TipoDescarteId = new int[1] ;
         BC000F4_n45TipoDescarteId = new bool[] {false} ;
         BC000F4_A46TipoDescarteNome = new string[] {""} ;
         BC000F4_A47TipoDescarteAtivo = new bool[] {false} ;
         BC000F5_A45TipoDescarteId = new int[1] ;
         BC000F5_n45TipoDescarteId = new bool[] {false} ;
         BC000F3_A45TipoDescarteId = new int[1] ;
         BC000F3_n45TipoDescarteId = new bool[] {false} ;
         BC000F3_A46TipoDescarteNome = new string[] {""} ;
         BC000F3_A47TipoDescarteAtivo = new bool[] {false} ;
         sMode15 = "";
         BC000F2_A45TipoDescarteId = new int[1] ;
         BC000F2_n45TipoDescarteId = new bool[] {false} ;
         BC000F2_A46TipoDescarteNome = new string[] {""} ;
         BC000F2_A47TipoDescarteAtivo = new bool[] {false} ;
         BC000F6_A45TipoDescarteId = new int[1] ;
         BC000F6_n45TipoDescarteId = new bool[] {false} ;
         BC000F9_A75DocumentoId = new int[1] ;
         BC000F10_A45TipoDescarteId = new int[1] ;
         BC000F10_n45TipoDescarteId = new bool[] {false} ;
         BC000F10_A46TipoDescarteNome = new string[] {""} ;
         BC000F10_A47TipoDescarteAtivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.tipodescarte_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tipodescarte_bc__default(),
            new Object[][] {
                new Object[] {
               BC000F2_A45TipoDescarteId, BC000F2_A46TipoDescarteNome, BC000F2_A47TipoDescarteAtivo
               }
               , new Object[] {
               BC000F3_A45TipoDescarteId, BC000F3_A46TipoDescarteNome, BC000F3_A47TipoDescarteAtivo
               }
               , new Object[] {
               BC000F4_A45TipoDescarteId, BC000F4_A46TipoDescarteNome, BC000F4_A47TipoDescarteAtivo
               }
               , new Object[] {
               BC000F5_A45TipoDescarteId
               }
               , new Object[] {
               BC000F6_A45TipoDescarteId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000F9_A75DocumentoId
               }
               , new Object[] {
               BC000F10_A45TipoDescarteId, BC000F10_A46TipoDescarteNome, BC000F10_A47TipoDescarteAtivo
               }
            }
         );
         Z47TipoDescarteAtivo = true;
         A47TipoDescarteAtivo = true;
         i47TipoDescarteAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120F2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound15 ;
      private short nIsDirty_15 ;
      private int trnEnded ;
      private int Z45TipoDescarteId ;
      private int A45TipoDescarteId ;
      private int AV15TipoDescarteId_Out ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode15 ;
      private bool returnInSub ;
      private bool AV14IsTipoDescarte ;
      private bool Z47TipoDescarteAtivo ;
      private bool A47TipoDescarteAtivo ;
      private bool n45TipoDescarteId ;
      private bool AV16IsOk ;
      private bool GXt_boolean1 ;
      private bool i47TipoDescarteAtivo ;
      private bool mustCommit ;
      private string Z46TipoDescarteNome ;
      private string A46TipoDescarteNome ;
      private IGxSession AV12WebSession ;
      private SdtTipoDescarte bcTipoDescarte ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000F4_A45TipoDescarteId ;
      private bool[] BC000F4_n45TipoDescarteId ;
      private string[] BC000F4_A46TipoDescarteNome ;
      private bool[] BC000F4_A47TipoDescarteAtivo ;
      private int[] BC000F5_A45TipoDescarteId ;
      private bool[] BC000F5_n45TipoDescarteId ;
      private int[] BC000F3_A45TipoDescarteId ;
      private bool[] BC000F3_n45TipoDescarteId ;
      private string[] BC000F3_A46TipoDescarteNome ;
      private bool[] BC000F3_A47TipoDescarteAtivo ;
      private int[] BC000F2_A45TipoDescarteId ;
      private bool[] BC000F2_n45TipoDescarteId ;
      private string[] BC000F2_A46TipoDescarteNome ;
      private bool[] BC000F2_A47TipoDescarteAtivo ;
      private int[] BC000F6_A45TipoDescarteId ;
      private bool[] BC000F6_n45TipoDescarteId ;
      private int[] BC000F9_A75DocumentoId ;
      private int[] BC000F10_A45TipoDescarteId ;
      private bool[] BC000F10_n45TipoDescarteId ;
      private string[] BC000F10_A46TipoDescarteNome ;
      private bool[] BC000F10_A47TipoDescarteAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class tipodescarte_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class tipodescarte_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000F4;
        prmBC000F4 = new Object[] {
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000F5;
        prmBC000F5 = new Object[] {
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000F3;
        prmBC000F3 = new Object[] {
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000F2;
        prmBC000F2 = new Object[] {
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000F6;
        prmBC000F6 = new Object[] {
        new ParDef("@TipoDescarteNome",GXType.NVarChar,100,0) ,
        new ParDef("@TipoDescarteAtivo",GXType.Boolean,4,0)
        };
        Object[] prmBC000F7;
        prmBC000F7 = new Object[] {
        new ParDef("@TipoDescarteNome",GXType.NVarChar,100,0) ,
        new ParDef("@TipoDescarteAtivo",GXType.Boolean,4,0) ,
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000F8;
        prmBC000F8 = new Object[] {
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000F9;
        prmBC000F9 = new Object[] {
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000F10;
        prmBC000F10 = new Object[] {
        new ParDef("@TipoDescarteId",GXType.Int32,8,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC000F2", "SELECT [TipoDescarteId], [TipoDescarteNome], [TipoDescarteAtivo] FROM [TipoDescarte] WITH (UPDLOCK) WHERE [TipoDescarteId] = @TipoDescarteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F3", "SELECT [TipoDescarteId], [TipoDescarteNome], [TipoDescarteAtivo] FROM [TipoDescarte] WHERE [TipoDescarteId] = @TipoDescarteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F4", "SELECT TM1.[TipoDescarteId], TM1.[TipoDescarteNome], TM1.[TipoDescarteAtivo] FROM [TipoDescarte] TM1 WHERE TM1.[TipoDescarteId] = @TipoDescarteId ORDER BY TM1.[TipoDescarteId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F5", "SELECT [TipoDescarteId] FROM [TipoDescarte] WHERE [TipoDescarteId] = @TipoDescarteId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F6", "INSERT INTO [TipoDescarte]([TipoDescarteNome], [TipoDescarteAtivo]) VALUES(@TipoDescarteNome, @TipoDescarteAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000F7", "UPDATE [TipoDescarte] SET [TipoDescarteNome]=@TipoDescarteNome, [TipoDescarteAtivo]=@TipoDescarteAtivo  WHERE [TipoDescarteId] = @TipoDescarteId", GxErrorMask.GX_NOMASK,prmBC000F7)
           ,new CursorDef("BC000F8", "DELETE FROM [TipoDescarte]  WHERE [TipoDescarteId] = @TipoDescarteId", GxErrorMask.GX_NOMASK,prmBC000F8)
           ,new CursorDef("BC000F9", "SELECT TOP 1 [DocumentoId] FROM [Documento] WHERE [TipoDescarteId] = @TipoDescarteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000F10", "SELECT TM1.[TipoDescarteId], TM1.[TipoDescarteNome], TM1.[TipoDescarteAtivo] FROM [TipoDescarte] TM1 WHERE TM1.[TipoDescarteId] = @TipoDescarteId ORDER BY TM1.[TipoDescarteId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F10,100, GxCacheFrequency.OFF ,true,false )
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
