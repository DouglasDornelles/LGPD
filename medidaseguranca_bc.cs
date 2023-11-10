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
   public class medidaseguranca_bc : GXHttpHandler, IGxSilentTrn
   {
      public medidaseguranca_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public medidaseguranca_bc( IGxContext context )
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
         ReadRow0H17( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0H17( ) ;
         standaloneModal( ) ;
         AddRow0H17( ) ;
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
            E110H2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z51MedidaSegurancaId = A51MedidaSegurancaId;
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

      protected void CONFIRM_0H0( )
      {
         BeforeValidate0H17( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0H17( ) ;
            }
            else
            {
               CheckExtendedTable0H17( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0H17( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120H2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110H2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV13IsMedidaSeguranca = true;
         AV14MedidaSegurancaId_Out = A51MedidaSegurancaId;
      }

      protected void ZM0H17( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z52MedidaSegurancaNome = A52MedidaSegurancaNome;
            Z53MedidaSegurancaAtivo = A53MedidaSegurancaAtivo;
         }
         if ( GX_JID == -6 )
         {
            Z51MedidaSegurancaId = A51MedidaSegurancaId;
            Z52MedidaSegurancaNome = A52MedidaSegurancaNome;
            Z53MedidaSegurancaAtivo = A53MedidaSegurancaAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A53MedidaSegurancaAtivo) && ( Gx_BScreen == 0 ) )
         {
            A53MedidaSegurancaAtivo = true;
         }
      }

      protected void Load0H17( )
      {
         /* Using cursor BC000H4 */
         pr_default.execute(2, new Object[] {A51MedidaSegurancaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound17 = 1;
            A52MedidaSegurancaNome = BC000H4_A52MedidaSegurancaNome[0];
            A53MedidaSegurancaAtivo = BC000H4_A53MedidaSegurancaAtivo[0];
            ZM0H17( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0H17( ) ;
      }

      protected void OnLoadActions0H17( )
      {
         A52MedidaSegurancaNome = StringUtil.Upper( A52MedidaSegurancaNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "MedidaSeguranca",  A51MedidaSegurancaId,  A52MedidaSegurancaNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
      }

      protected void CheckExtendedTable0H17( )
      {
         nIsDirty_17 = 0;
         standaloneModal( ) ;
         nIsDirty_17 = 1;
         A52MedidaSegurancaNome = StringUtil.Upper( A52MedidaSegurancaNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "MedidaSeguranca",  A51MedidaSegurancaId,  A52MedidaSegurancaNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
         if ( ! AV15IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A52MedidaSegurancaNome)) )
         {
            GX_msglist.addItem("Informe o Nome da Medida de Segurança.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0H17( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0H17( )
      {
         /* Using cursor BC000H5 */
         pr_default.execute(3, new Object[] {A51MedidaSegurancaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound17 = 1;
         }
         else
         {
            RcdFound17 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000H3 */
         pr_default.execute(1, new Object[] {A51MedidaSegurancaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0H17( 6) ;
            RcdFound17 = 1;
            A51MedidaSegurancaId = BC000H3_A51MedidaSegurancaId[0];
            A52MedidaSegurancaNome = BC000H3_A52MedidaSegurancaNome[0];
            A53MedidaSegurancaAtivo = BC000H3_A53MedidaSegurancaAtivo[0];
            Z51MedidaSegurancaId = A51MedidaSegurancaId;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0H17( ) ;
            if ( AnyError == 1 )
            {
               RcdFound17 = 0;
               InitializeNonKey0H17( ) ;
            }
            Gx_mode = sMode17;
         }
         else
         {
            RcdFound17 = 0;
            InitializeNonKey0H17( ) ;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode17;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0H17( ) ;
         if ( RcdFound17 == 0 )
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
         CONFIRM_0H0( ) ;
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

      protected void CheckOptimisticConcurrency0H17( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000H2 */
            pr_default.execute(0, new Object[] {A51MedidaSegurancaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MedidaSeguranca"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z52MedidaSegurancaNome, BC000H2_A52MedidaSegurancaNome[0]) != 0 ) || ( Z53MedidaSegurancaAtivo != BC000H2_A53MedidaSegurancaAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"MedidaSeguranca"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0H17( )
      {
         BeforeValidate0H17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H17( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0H17( 0) ;
            CheckOptimisticConcurrency0H17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0H17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000H6 */
                     pr_default.execute(4, new Object[] {A52MedidaSegurancaNome, A53MedidaSegurancaAtivo});
                     A51MedidaSegurancaId = BC000H6_A51MedidaSegurancaId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("MedidaSeguranca");
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
               Load0H17( ) ;
            }
            EndLevel0H17( ) ;
         }
         CloseExtendedTableCursors0H17( ) ;
      }

      protected void Update0H17( )
      {
         BeforeValidate0H17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H17( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0H17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000H7 */
                     pr_default.execute(5, new Object[] {A52MedidaSegurancaNome, A53MedidaSegurancaAtivo, A51MedidaSegurancaId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("MedidaSeguranca");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"MedidaSeguranca"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0H17( ) ;
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
            EndLevel0H17( ) ;
         }
         CloseExtendedTableCursors0H17( ) ;
      }

      protected void DeferredUpdate0H17( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0H17( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H17( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0H17( ) ;
            AfterConfirm0H17( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0H17( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000H8 */
                  pr_default.execute(6, new Object[] {A51MedidaSegurancaId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("MedidaSeguranca");
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
         sMode17 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0H17( ) ;
         Gx_mode = sMode17;
      }

      protected void OnDeleteControls0H17( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV15IsOk;
            new validanome(context ).execute(  "MedidaSeguranca",  A51MedidaSegurancaId,  A52MedidaSegurancaNome, out  GXt_boolean1) ;
            AV15IsOk = GXt_boolean1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000H9 */
            pr_default.execute(7, new Object[] {A51MedidaSegurancaId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"DocMedidaSeguranca"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0H17( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0H17( ) ;
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

      public void ScanKeyStart0H17( )
      {
         /* Scan By routine */
         /* Using cursor BC000H10 */
         pr_default.execute(8, new Object[] {A51MedidaSegurancaId});
         RcdFound17 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound17 = 1;
            A51MedidaSegurancaId = BC000H10_A51MedidaSegurancaId[0];
            A52MedidaSegurancaNome = BC000H10_A52MedidaSegurancaNome[0];
            A53MedidaSegurancaAtivo = BC000H10_A53MedidaSegurancaAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0H17( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound17 = 0;
         ScanKeyLoad0H17( ) ;
      }

      protected void ScanKeyLoad0H17( )
      {
         sMode17 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound17 = 1;
            A51MedidaSegurancaId = BC000H10_A51MedidaSegurancaId[0];
            A52MedidaSegurancaNome = BC000H10_A52MedidaSegurancaNome[0];
            A53MedidaSegurancaAtivo = BC000H10_A53MedidaSegurancaAtivo[0];
         }
         Gx_mode = sMode17;
      }

      protected void ScanKeyEnd0H17( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0H17( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0H17( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0H17( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0H17( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0H17( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0H17( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0H17( )
      {
      }

      protected void send_integrity_lvl_hashes0H17( )
      {
      }

      protected void AddRow0H17( )
      {
         VarsToRow17( bcMedidaSeguranca) ;
      }

      protected void ReadRow0H17( )
      {
         RowToVars17( bcMedidaSeguranca, 1) ;
      }

      protected void InitializeNonKey0H17( )
      {
         A52MedidaSegurancaNome = "";
         AV15IsOk = false;
         A53MedidaSegurancaAtivo = true;
         Z52MedidaSegurancaNome = "";
         Z53MedidaSegurancaAtivo = false;
      }

      protected void InitAll0H17( )
      {
         A51MedidaSegurancaId = 0;
         InitializeNonKey0H17( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A53MedidaSegurancaAtivo = i53MedidaSegurancaAtivo;
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

      public void VarsToRow17( SdtMedidaSeguranca obj17 )
      {
         obj17.gxTpr_Mode = Gx_mode;
         obj17.gxTpr_Medidasegurancanome = A52MedidaSegurancaNome;
         obj17.gxTpr_Medidasegurancaativo = A53MedidaSegurancaAtivo;
         obj17.gxTpr_Medidasegurancaid = A51MedidaSegurancaId;
         obj17.gxTpr_Medidasegurancaid_Z = Z51MedidaSegurancaId;
         obj17.gxTpr_Medidasegurancanome_Z = Z52MedidaSegurancaNome;
         obj17.gxTpr_Medidasegurancaativo_Z = Z53MedidaSegurancaAtivo;
         obj17.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow17( SdtMedidaSeguranca obj17 )
      {
         obj17.gxTpr_Medidasegurancaid = A51MedidaSegurancaId;
         return  ;
      }

      public void RowToVars17( SdtMedidaSeguranca obj17 ,
                               int forceLoad )
      {
         Gx_mode = obj17.gxTpr_Mode;
         A52MedidaSegurancaNome = obj17.gxTpr_Medidasegurancanome;
         A53MedidaSegurancaAtivo = obj17.gxTpr_Medidasegurancaativo;
         A51MedidaSegurancaId = obj17.gxTpr_Medidasegurancaid;
         Z51MedidaSegurancaId = obj17.gxTpr_Medidasegurancaid_Z;
         Z52MedidaSegurancaNome = obj17.gxTpr_Medidasegurancanome_Z;
         Z53MedidaSegurancaAtivo = obj17.gxTpr_Medidasegurancaativo_Z;
         Gx_mode = obj17.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A51MedidaSegurancaId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0H17( ) ;
         ScanKeyStart0H17( ) ;
         if ( RcdFound17 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z51MedidaSegurancaId = A51MedidaSegurancaId;
         }
         ZM0H17( -6) ;
         OnLoadActions0H17( ) ;
         AddRow0H17( ) ;
         ScanKeyEnd0H17( ) ;
         if ( RcdFound17 == 0 )
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
         RowToVars17( bcMedidaSeguranca, 0) ;
         ScanKeyStart0H17( ) ;
         if ( RcdFound17 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z51MedidaSegurancaId = A51MedidaSegurancaId;
         }
         ZM0H17( -6) ;
         OnLoadActions0H17( ) ;
         AddRow0H17( ) ;
         ScanKeyEnd0H17( ) ;
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0H17( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0H17( ) ;
         }
         else
         {
            if ( RcdFound17 == 1 )
            {
               if ( A51MedidaSegurancaId != Z51MedidaSegurancaId )
               {
                  A51MedidaSegurancaId = Z51MedidaSegurancaId;
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
                  Update0H17( ) ;
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
                  if ( A51MedidaSegurancaId != Z51MedidaSegurancaId )
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
                        Insert0H17( ) ;
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
                        Insert0H17( ) ;
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
         RowToVars17( bcMedidaSeguranca, 1) ;
         SaveImpl( ) ;
         VarsToRow17( bcMedidaSeguranca) ;
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
         RowToVars17( bcMedidaSeguranca, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0H17( ) ;
         AfterTrn( ) ;
         VarsToRow17( bcMedidaSeguranca) ;
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
            SdtMedidaSeguranca auxBC = new SdtMedidaSeguranca(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A51MedidaSegurancaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcMedidaSeguranca);
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
         RowToVars17( bcMedidaSeguranca, 1) ;
         UpdateImpl( ) ;
         VarsToRow17( bcMedidaSeguranca) ;
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
         RowToVars17( bcMedidaSeguranca, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0H17( ) ;
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
         VarsToRow17( bcMedidaSeguranca) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars17( bcMedidaSeguranca, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0H17( ) ;
         if ( RcdFound17 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A51MedidaSegurancaId != Z51MedidaSegurancaId )
            {
               A51MedidaSegurancaId = Z51MedidaSegurancaId;
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
            if ( A51MedidaSegurancaId != Z51MedidaSegurancaId )
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
         context.RollbackDataStores("medidaseguranca_bc",pr_default);
         VarsToRow17( bcMedidaSeguranca) ;
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
         Gx_mode = bcMedidaSeguranca.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcMedidaSeguranca.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcMedidaSeguranca )
         {
            bcMedidaSeguranca = (SdtMedidaSeguranca)(sdt);
            if ( StringUtil.StrCmp(bcMedidaSeguranca.gxTpr_Mode, "") == 0 )
            {
               bcMedidaSeguranca.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow17( bcMedidaSeguranca) ;
            }
            else
            {
               RowToVars17( bcMedidaSeguranca, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcMedidaSeguranca.gxTpr_Mode, "") == 0 )
            {
               bcMedidaSeguranca.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars17( bcMedidaSeguranca, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtMedidaSeguranca MedidaSeguranca_BC
      {
         get {
            return bcMedidaSeguranca ;
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
            return "medidaseguranca_Execute" ;
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
         Z52MedidaSegurancaNome = "";
         A52MedidaSegurancaNome = "";
         BC000H4_A51MedidaSegurancaId = new int[1] ;
         BC000H4_A52MedidaSegurancaNome = new string[] {""} ;
         BC000H4_A53MedidaSegurancaAtivo = new bool[] {false} ;
         BC000H5_A51MedidaSegurancaId = new int[1] ;
         BC000H3_A51MedidaSegurancaId = new int[1] ;
         BC000H3_A52MedidaSegurancaNome = new string[] {""} ;
         BC000H3_A53MedidaSegurancaAtivo = new bool[] {false} ;
         sMode17 = "";
         BC000H2_A51MedidaSegurancaId = new int[1] ;
         BC000H2_A52MedidaSegurancaNome = new string[] {""} ;
         BC000H2_A53MedidaSegurancaAtivo = new bool[] {false} ;
         BC000H6_A51MedidaSegurancaId = new int[1] ;
         BC000H9_A51MedidaSegurancaId = new int[1] ;
         BC000H9_A75DocumentoId = new int[1] ;
         BC000H10_A51MedidaSegurancaId = new int[1] ;
         BC000H10_A52MedidaSegurancaNome = new string[] {""} ;
         BC000H10_A53MedidaSegurancaAtivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.medidaseguranca_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.medidaseguranca_bc__default(),
            new Object[][] {
                new Object[] {
               BC000H2_A51MedidaSegurancaId, BC000H2_A52MedidaSegurancaNome, BC000H2_A53MedidaSegurancaAtivo
               }
               , new Object[] {
               BC000H3_A51MedidaSegurancaId, BC000H3_A52MedidaSegurancaNome, BC000H3_A53MedidaSegurancaAtivo
               }
               , new Object[] {
               BC000H4_A51MedidaSegurancaId, BC000H4_A52MedidaSegurancaNome, BC000H4_A53MedidaSegurancaAtivo
               }
               , new Object[] {
               BC000H5_A51MedidaSegurancaId
               }
               , new Object[] {
               BC000H6_A51MedidaSegurancaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000H9_A51MedidaSegurancaId, BC000H9_A75DocumentoId
               }
               , new Object[] {
               BC000H10_A51MedidaSegurancaId, BC000H10_A52MedidaSegurancaNome, BC000H10_A53MedidaSegurancaAtivo
               }
            }
         );
         Z53MedidaSegurancaAtivo = true;
         A53MedidaSegurancaAtivo = true;
         i53MedidaSegurancaAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120H2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound17 ;
      private short nIsDirty_17 ;
      private int trnEnded ;
      private int Z51MedidaSegurancaId ;
      private int A51MedidaSegurancaId ;
      private int AV14MedidaSegurancaId_Out ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode17 ;
      private bool returnInSub ;
      private bool AV13IsMedidaSeguranca ;
      private bool Z53MedidaSegurancaAtivo ;
      private bool A53MedidaSegurancaAtivo ;
      private bool AV15IsOk ;
      private bool GXt_boolean1 ;
      private bool i53MedidaSegurancaAtivo ;
      private bool mustCommit ;
      private string Z52MedidaSegurancaNome ;
      private string A52MedidaSegurancaNome ;
      private IGxSession AV12WebSession ;
      private SdtMedidaSeguranca bcMedidaSeguranca ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000H4_A51MedidaSegurancaId ;
      private string[] BC000H4_A52MedidaSegurancaNome ;
      private bool[] BC000H4_A53MedidaSegurancaAtivo ;
      private int[] BC000H5_A51MedidaSegurancaId ;
      private int[] BC000H3_A51MedidaSegurancaId ;
      private string[] BC000H3_A52MedidaSegurancaNome ;
      private bool[] BC000H3_A53MedidaSegurancaAtivo ;
      private int[] BC000H2_A51MedidaSegurancaId ;
      private string[] BC000H2_A52MedidaSegurancaNome ;
      private bool[] BC000H2_A53MedidaSegurancaAtivo ;
      private int[] BC000H6_A51MedidaSegurancaId ;
      private int[] BC000H9_A51MedidaSegurancaId ;
      private int[] BC000H9_A75DocumentoId ;
      private int[] BC000H10_A51MedidaSegurancaId ;
      private string[] BC000H10_A52MedidaSegurancaNome ;
      private bool[] BC000H10_A53MedidaSegurancaAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class medidaseguranca_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class medidaseguranca_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000H4;
        prmBC000H4 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0)
        };
        Object[] prmBC000H5;
        prmBC000H5 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0)
        };
        Object[] prmBC000H3;
        prmBC000H3 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0)
        };
        Object[] prmBC000H2;
        prmBC000H2 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0)
        };
        Object[] prmBC000H6;
        prmBC000H6 = new Object[] {
        new ParDef("@MedidaSegurancaNome",GXType.NVarChar,100,0) ,
        new ParDef("@MedidaSegurancaAtivo",GXType.Boolean,4,0)
        };
        Object[] prmBC000H7;
        prmBC000H7 = new Object[] {
        new ParDef("@MedidaSegurancaNome",GXType.NVarChar,100,0) ,
        new ParDef("@MedidaSegurancaAtivo",GXType.Boolean,4,0) ,
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0)
        };
        Object[] prmBC000H8;
        prmBC000H8 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0)
        };
        Object[] prmBC000H9;
        prmBC000H9 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0)
        };
        Object[] prmBC000H10;
        prmBC000H10 = new Object[] {
        new ParDef("@MedidaSegurancaId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000H2", "SELECT [MedidaSegurancaId], [MedidaSegurancaNome], [MedidaSegurancaAtivo] FROM [MedidaSeguranca] WITH (UPDLOCK) WHERE [MedidaSegurancaId] = @MedidaSegurancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H3", "SELECT [MedidaSegurancaId], [MedidaSegurancaNome], [MedidaSegurancaAtivo] FROM [MedidaSeguranca] WHERE [MedidaSegurancaId] = @MedidaSegurancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H4", "SELECT TM1.[MedidaSegurancaId], TM1.[MedidaSegurancaNome], TM1.[MedidaSegurancaAtivo] FROM [MedidaSeguranca] TM1 WHERE TM1.[MedidaSegurancaId] = @MedidaSegurancaId ORDER BY TM1.[MedidaSegurancaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H5", "SELECT [MedidaSegurancaId] FROM [MedidaSeguranca] WHERE [MedidaSegurancaId] = @MedidaSegurancaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H6", "INSERT INTO [MedidaSeguranca]([MedidaSegurancaNome], [MedidaSegurancaAtivo]) VALUES(@MedidaSegurancaNome, @MedidaSegurancaAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000H7", "UPDATE [MedidaSeguranca] SET [MedidaSegurancaNome]=@MedidaSegurancaNome, [MedidaSegurancaAtivo]=@MedidaSegurancaAtivo  WHERE [MedidaSegurancaId] = @MedidaSegurancaId", GxErrorMask.GX_NOMASK,prmBC000H7)
           ,new CursorDef("BC000H8", "DELETE FROM [MedidaSeguranca]  WHERE [MedidaSegurancaId] = @MedidaSegurancaId", GxErrorMask.GX_NOMASK,prmBC000H8)
           ,new CursorDef("BC000H9", "SELECT TOP 1 [MedidaSegurancaId], [DocumentoId] FROM [DocMedidaSeguranca] WHERE [MedidaSegurancaId] = @MedidaSegurancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000H10", "SELECT TM1.[MedidaSegurancaId], TM1.[MedidaSegurancaNome], TM1.[MedidaSegurancaAtivo] FROM [MedidaSeguranca] TM1 WHERE TM1.[MedidaSegurancaId] = @MedidaSegurancaId ORDER BY TM1.[MedidaSegurancaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H10,100, GxCacheFrequency.OFF ,true,false )
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
