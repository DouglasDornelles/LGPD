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
   public class tipodado_bc : GXHttpHandler, IGxSilentTrn
   {
      public tipodado_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public tipodado_bc( IGxContext context )
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
         ReadRow0A10( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0A10( ) ;
         standaloneModal( ) ;
         AddRow0A10( ) ;
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
            E110A2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z30TipoDadoId = A30TipoDadoId;
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

      protected void CONFIRM_0A0( )
      {
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0A10( ) ;
            }
            else
            {
               CheckExtendedTable0A10( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0A10( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120A2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110A2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV14TipoDadoId_Out = A30TipoDadoId;
         AV13IsTipoDado = true;
      }

      protected void ZM0A10( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z31TipoDadoNome = A31TipoDadoNome;
            Z32TipoDadoAtivo = A32TipoDadoAtivo;
         }
         if ( GX_JID == -6 )
         {
            Z30TipoDadoId = A30TipoDadoId;
            Z31TipoDadoNome = A31TipoDadoNome;
            Z32TipoDadoAtivo = A32TipoDadoAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A32TipoDadoAtivo) && ( Gx_BScreen == 0 ) )
         {
            A32TipoDadoAtivo = true;
         }
      }

      protected void Load0A10( )
      {
         /* Using cursor BC000A4 */
         pr_default.execute(2, new Object[] {n30TipoDadoId, A30TipoDadoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound10 = 1;
            A31TipoDadoNome = BC000A4_A31TipoDadoNome[0];
            A32TipoDadoAtivo = BC000A4_A32TipoDadoAtivo[0];
            ZM0A10( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0A10( ) ;
      }

      protected void OnLoadActions0A10( )
      {
         A31TipoDadoNome = StringUtil.Upper( A31TipoDadoNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "TipoDado",  A30TipoDadoId,  A31TipoDadoNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
      }

      protected void CheckExtendedTable0A10( )
      {
         nIsDirty_10 = 0;
         standaloneModal( ) ;
         nIsDirty_10 = 1;
         A31TipoDadoNome = StringUtil.Upper( A31TipoDadoNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "TipoDado",  A30TipoDadoId,  A31TipoDadoNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
         if ( ! AV15IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A31TipoDadoNome)) )
         {
            GX_msglist.addItem("Informe o Nome do Tipo de Dado.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0A10( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0A10( )
      {
         /* Using cursor BC000A5 */
         pr_default.execute(3, new Object[] {n30TipoDadoId, A30TipoDadoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000A3 */
         pr_default.execute(1, new Object[] {n30TipoDadoId, A30TipoDadoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A10( 6) ;
            RcdFound10 = 1;
            A30TipoDadoId = BC000A3_A30TipoDadoId[0];
            n30TipoDadoId = BC000A3_n30TipoDadoId[0];
            A31TipoDadoNome = BC000A3_A31TipoDadoNome[0];
            A32TipoDadoAtivo = BC000A3_A32TipoDadoAtivo[0];
            Z30TipoDadoId = A30TipoDadoId;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0A10( ) ;
            if ( AnyError == 1 )
            {
               RcdFound10 = 0;
               InitializeNonKey0A10( ) ;
            }
            Gx_mode = sMode10;
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0A10( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode10;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A10( ) ;
         if ( RcdFound10 == 0 )
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
         CONFIRM_0A0( ) ;
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

      protected void CheckOptimisticConcurrency0A10( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000A2 */
            pr_default.execute(0, new Object[] {n30TipoDadoId, A30TipoDadoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TipoDado"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z31TipoDadoNome, BC000A2_A31TipoDadoNome[0]) != 0 ) || ( Z32TipoDadoAtivo != BC000A2_A32TipoDadoAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TipoDado"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A10( )
      {
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A10( 0) ;
            CheckOptimisticConcurrency0A10( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A10( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A10( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A6 */
                     pr_default.execute(4, new Object[] {A31TipoDadoNome, A32TipoDadoAtivo});
                     A30TipoDadoId = BC000A6_A30TipoDadoId[0];
                     n30TipoDadoId = BC000A6_n30TipoDadoId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("TipoDado");
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
               Load0A10( ) ;
            }
            EndLevel0A10( ) ;
         }
         CloseExtendedTableCursors0A10( ) ;
      }

      protected void Update0A10( )
      {
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A10( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A10( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A10( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A7 */
                     pr_default.execute(5, new Object[] {A31TipoDadoNome, A32TipoDadoAtivo, n30TipoDadoId, A30TipoDadoId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("TipoDado");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TipoDado"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A10( ) ;
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
            EndLevel0A10( ) ;
         }
         CloseExtendedTableCursors0A10( ) ;
      }

      protected void DeferredUpdate0A10( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A10( ) ;
            AfterConfirm0A10( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A10( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000A8 */
                  pr_default.execute(6, new Object[] {n30TipoDadoId, A30TipoDadoId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("TipoDado");
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
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0A10( ) ;
         Gx_mode = sMode10;
      }

      protected void OnDeleteControls0A10( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV15IsOk;
            new validanome(context ).execute(  "TipoDado",  A30TipoDadoId,  A31TipoDadoNome, out  GXt_boolean1) ;
            AV15IsOk = GXt_boolean1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000A9 */
            pr_default.execute(7, new Object[] {n30TipoDadoId, A30TipoDadoId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0A10( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A10( ) ;
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

      public void ScanKeyStart0A10( )
      {
         /* Scan By routine */
         /* Using cursor BC000A10 */
         pr_default.execute(8, new Object[] {n30TipoDadoId, A30TipoDadoId});
         RcdFound10 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound10 = 1;
            A30TipoDadoId = BC000A10_A30TipoDadoId[0];
            n30TipoDadoId = BC000A10_n30TipoDadoId[0];
            A31TipoDadoNome = BC000A10_A31TipoDadoNome[0];
            A32TipoDadoAtivo = BC000A10_A32TipoDadoAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0A10( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound10 = 0;
         ScanKeyLoad0A10( ) ;
      }

      protected void ScanKeyLoad0A10( )
      {
         sMode10 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound10 = 1;
            A30TipoDadoId = BC000A10_A30TipoDadoId[0];
            n30TipoDadoId = BC000A10_n30TipoDadoId[0];
            A31TipoDadoNome = BC000A10_A31TipoDadoNome[0];
            A32TipoDadoAtivo = BC000A10_A32TipoDadoAtivo[0];
         }
         Gx_mode = sMode10;
      }

      protected void ScanKeyEnd0A10( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0A10( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A10( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A10( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A10( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A10( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A10( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A10( )
      {
      }

      protected void send_integrity_lvl_hashes0A10( )
      {
      }

      protected void AddRow0A10( )
      {
         VarsToRow10( bcTipoDado) ;
      }

      protected void ReadRow0A10( )
      {
         RowToVars10( bcTipoDado, 1) ;
      }

      protected void InitializeNonKey0A10( )
      {
         A31TipoDadoNome = "";
         AV15IsOk = false;
         A32TipoDadoAtivo = true;
         Z31TipoDadoNome = "";
         Z32TipoDadoAtivo = false;
      }

      protected void InitAll0A10( )
      {
         A30TipoDadoId = 0;
         n30TipoDadoId = false;
         InitializeNonKey0A10( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A32TipoDadoAtivo = i32TipoDadoAtivo;
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

      public void VarsToRow10( SdtTipoDado obj10 )
      {
         obj10.gxTpr_Mode = Gx_mode;
         obj10.gxTpr_Tipodadonome = A31TipoDadoNome;
         obj10.gxTpr_Tipodadoativo = A32TipoDadoAtivo;
         obj10.gxTpr_Tipodadoid = A30TipoDadoId;
         obj10.gxTpr_Tipodadoid_Z = Z30TipoDadoId;
         obj10.gxTpr_Tipodadonome_Z = Z31TipoDadoNome;
         obj10.gxTpr_Tipodadoativo_Z = Z32TipoDadoAtivo;
         obj10.gxTpr_Tipodadoid_N = (short)(Convert.ToInt16(n30TipoDadoId));
         obj10.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow10( SdtTipoDado obj10 )
      {
         obj10.gxTpr_Tipodadoid = A30TipoDadoId;
         return  ;
      }

      public void RowToVars10( SdtTipoDado obj10 ,
                               int forceLoad )
      {
         Gx_mode = obj10.gxTpr_Mode;
         A31TipoDadoNome = obj10.gxTpr_Tipodadonome;
         A32TipoDadoAtivo = obj10.gxTpr_Tipodadoativo;
         A30TipoDadoId = obj10.gxTpr_Tipodadoid;
         n30TipoDadoId = false;
         Z30TipoDadoId = obj10.gxTpr_Tipodadoid_Z;
         Z31TipoDadoNome = obj10.gxTpr_Tipodadonome_Z;
         Z32TipoDadoAtivo = obj10.gxTpr_Tipodadoativo_Z;
         n30TipoDadoId = (bool)(Convert.ToBoolean(obj10.gxTpr_Tipodadoid_N));
         Gx_mode = obj10.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A30TipoDadoId = (int)getParm(obj,0);
         n30TipoDadoId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0A10( ) ;
         ScanKeyStart0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z30TipoDadoId = A30TipoDadoId;
         }
         ZM0A10( -6) ;
         OnLoadActions0A10( ) ;
         AddRow0A10( ) ;
         ScanKeyEnd0A10( ) ;
         if ( RcdFound10 == 0 )
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
         RowToVars10( bcTipoDado, 0) ;
         ScanKeyStart0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z30TipoDadoId = A30TipoDadoId;
         }
         ZM0A10( -6) ;
         OnLoadActions0A10( ) ;
         AddRow0A10( ) ;
         ScanKeyEnd0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0A10( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0A10( ) ;
         }
         else
         {
            if ( RcdFound10 == 1 )
            {
               if ( A30TipoDadoId != Z30TipoDadoId )
               {
                  A30TipoDadoId = Z30TipoDadoId;
                  n30TipoDadoId = false;
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
                  Update0A10( ) ;
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
                  if ( A30TipoDadoId != Z30TipoDadoId )
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
                        Insert0A10( ) ;
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
                        Insert0A10( ) ;
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
         RowToVars10( bcTipoDado, 1) ;
         SaveImpl( ) ;
         VarsToRow10( bcTipoDado) ;
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
         RowToVars10( bcTipoDado, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0A10( ) ;
         AfterTrn( ) ;
         VarsToRow10( bcTipoDado) ;
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
            SdtTipoDado auxBC = new SdtTipoDado(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A30TipoDadoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTipoDado);
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
         RowToVars10( bcTipoDado, 1) ;
         UpdateImpl( ) ;
         VarsToRow10( bcTipoDado) ;
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
         RowToVars10( bcTipoDado, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0A10( ) ;
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
         VarsToRow10( bcTipoDado) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars10( bcTipoDado, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0A10( ) ;
         if ( RcdFound10 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A30TipoDadoId != Z30TipoDadoId )
            {
               A30TipoDadoId = Z30TipoDadoId;
               n30TipoDadoId = false;
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
            if ( A30TipoDadoId != Z30TipoDadoId )
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
         context.RollbackDataStores("tipodado_bc",pr_default);
         VarsToRow10( bcTipoDado) ;
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
         Gx_mode = bcTipoDado.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTipoDado.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTipoDado )
         {
            bcTipoDado = (SdtTipoDado)(sdt);
            if ( StringUtil.StrCmp(bcTipoDado.gxTpr_Mode, "") == 0 )
            {
               bcTipoDado.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow10( bcTipoDado) ;
            }
            else
            {
               RowToVars10( bcTipoDado, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTipoDado.gxTpr_Mode, "") == 0 )
            {
               bcTipoDado.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars10( bcTipoDado, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtTipoDado TipoDado_BC
      {
         get {
            return bcTipoDado ;
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
            return "tipodado_Execute" ;
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
         Z31TipoDadoNome = "";
         A31TipoDadoNome = "";
         BC000A4_A30TipoDadoId = new int[1] ;
         BC000A4_n30TipoDadoId = new bool[] {false} ;
         BC000A4_A31TipoDadoNome = new string[] {""} ;
         BC000A4_A32TipoDadoAtivo = new bool[] {false} ;
         BC000A5_A30TipoDadoId = new int[1] ;
         BC000A5_n30TipoDadoId = new bool[] {false} ;
         BC000A3_A30TipoDadoId = new int[1] ;
         BC000A3_n30TipoDadoId = new bool[] {false} ;
         BC000A3_A31TipoDadoNome = new string[] {""} ;
         BC000A3_A32TipoDadoAtivo = new bool[] {false} ;
         sMode10 = "";
         BC000A2_A30TipoDadoId = new int[1] ;
         BC000A2_n30TipoDadoId = new bool[] {false} ;
         BC000A2_A31TipoDadoNome = new string[] {""} ;
         BC000A2_A32TipoDadoAtivo = new bool[] {false} ;
         BC000A6_A30TipoDadoId = new int[1] ;
         BC000A6_n30TipoDadoId = new bool[] {false} ;
         BC000A9_A75DocumentoId = new int[1] ;
         BC000A10_A30TipoDadoId = new int[1] ;
         BC000A10_n30TipoDadoId = new bool[] {false} ;
         BC000A10_A31TipoDadoNome = new string[] {""} ;
         BC000A10_A32TipoDadoAtivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.tipodado_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tipodado_bc__default(),
            new Object[][] {
                new Object[] {
               BC000A2_A30TipoDadoId, BC000A2_A31TipoDadoNome, BC000A2_A32TipoDadoAtivo
               }
               , new Object[] {
               BC000A3_A30TipoDadoId, BC000A3_A31TipoDadoNome, BC000A3_A32TipoDadoAtivo
               }
               , new Object[] {
               BC000A4_A30TipoDadoId, BC000A4_A31TipoDadoNome, BC000A4_A32TipoDadoAtivo
               }
               , new Object[] {
               BC000A5_A30TipoDadoId
               }
               , new Object[] {
               BC000A6_A30TipoDadoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000A9_A75DocumentoId
               }
               , new Object[] {
               BC000A10_A30TipoDadoId, BC000A10_A31TipoDadoNome, BC000A10_A32TipoDadoAtivo
               }
            }
         );
         Z32TipoDadoAtivo = true;
         A32TipoDadoAtivo = true;
         i32TipoDadoAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120A2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound10 ;
      private short nIsDirty_10 ;
      private int trnEnded ;
      private int Z30TipoDadoId ;
      private int A30TipoDadoId ;
      private int AV14TipoDadoId_Out ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode10 ;
      private bool returnInSub ;
      private bool AV13IsTipoDado ;
      private bool Z32TipoDadoAtivo ;
      private bool A32TipoDadoAtivo ;
      private bool n30TipoDadoId ;
      private bool AV15IsOk ;
      private bool GXt_boolean1 ;
      private bool i32TipoDadoAtivo ;
      private bool mustCommit ;
      private string Z31TipoDadoNome ;
      private string A31TipoDadoNome ;
      private IGxSession AV12WebSession ;
      private SdtTipoDado bcTipoDado ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000A4_A30TipoDadoId ;
      private bool[] BC000A4_n30TipoDadoId ;
      private string[] BC000A4_A31TipoDadoNome ;
      private bool[] BC000A4_A32TipoDadoAtivo ;
      private int[] BC000A5_A30TipoDadoId ;
      private bool[] BC000A5_n30TipoDadoId ;
      private int[] BC000A3_A30TipoDadoId ;
      private bool[] BC000A3_n30TipoDadoId ;
      private string[] BC000A3_A31TipoDadoNome ;
      private bool[] BC000A3_A32TipoDadoAtivo ;
      private int[] BC000A2_A30TipoDadoId ;
      private bool[] BC000A2_n30TipoDadoId ;
      private string[] BC000A2_A31TipoDadoNome ;
      private bool[] BC000A2_A32TipoDadoAtivo ;
      private int[] BC000A6_A30TipoDadoId ;
      private bool[] BC000A6_n30TipoDadoId ;
      private int[] BC000A9_A75DocumentoId ;
      private int[] BC000A10_A30TipoDadoId ;
      private bool[] BC000A10_n30TipoDadoId ;
      private string[] BC000A10_A31TipoDadoNome ;
      private bool[] BC000A10_A32TipoDadoAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class tipodado_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class tipodado_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000A4;
        prmBC000A4 = new Object[] {
        new ParDef("@TipoDadoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000A5;
        prmBC000A5 = new Object[] {
        new ParDef("@TipoDadoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000A3;
        prmBC000A3 = new Object[] {
        new ParDef("@TipoDadoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000A2;
        prmBC000A2 = new Object[] {
        new ParDef("@TipoDadoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000A6;
        prmBC000A6 = new Object[] {
        new ParDef("@TipoDadoNome",GXType.NVarChar,100,0) ,
        new ParDef("@TipoDadoAtivo",GXType.Boolean,4,0)
        };
        Object[] prmBC000A7;
        prmBC000A7 = new Object[] {
        new ParDef("@TipoDadoNome",GXType.NVarChar,100,0) ,
        new ParDef("@TipoDadoAtivo",GXType.Boolean,4,0) ,
        new ParDef("@TipoDadoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000A8;
        prmBC000A8 = new Object[] {
        new ParDef("@TipoDadoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000A9;
        prmBC000A9 = new Object[] {
        new ParDef("@TipoDadoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000A10;
        prmBC000A10 = new Object[] {
        new ParDef("@TipoDadoId",GXType.Int32,8,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC000A2", "SELECT [TipoDadoId], [TipoDadoNome], [TipoDadoAtivo] FROM [TipoDado] WITH (UPDLOCK) WHERE [TipoDadoId] = @TipoDadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A3", "SELECT [TipoDadoId], [TipoDadoNome], [TipoDadoAtivo] FROM [TipoDado] WHERE [TipoDadoId] = @TipoDadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A4", "SELECT TM1.[TipoDadoId], TM1.[TipoDadoNome], TM1.[TipoDadoAtivo] FROM [TipoDado] TM1 WHERE TM1.[TipoDadoId] = @TipoDadoId ORDER BY TM1.[TipoDadoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A5", "SELECT [TipoDadoId] FROM [TipoDado] WHERE [TipoDadoId] = @TipoDadoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A6", "INSERT INTO [TipoDado]([TipoDadoNome], [TipoDadoAtivo]) VALUES(@TipoDadoNome, @TipoDadoAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000A7", "UPDATE [TipoDado] SET [TipoDadoNome]=@TipoDadoNome, [TipoDadoAtivo]=@TipoDadoAtivo  WHERE [TipoDadoId] = @TipoDadoId", GxErrorMask.GX_NOMASK,prmBC000A7)
           ,new CursorDef("BC000A8", "DELETE FROM [TipoDado]  WHERE [TipoDadoId] = @TipoDadoId", GxErrorMask.GX_NOMASK,prmBC000A8)
           ,new CursorDef("BC000A9", "SELECT TOP 1 [DocumentoId] FROM [Documento] WHERE [TipoDadoId] = @TipoDadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000A10", "SELECT TM1.[TipoDadoId], TM1.[TipoDadoNome], TM1.[TipoDadoAtivo] FROM [TipoDado] TM1 WHERE TM1.[TipoDadoId] = @TipoDadoId ORDER BY TM1.[TipoDadoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A10,100, GxCacheFrequency.OFF ,true,false )
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
