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
   public class hipotesetratamento_bc : GXHttpHandler, IGxSilentTrn
   {
      public hipotesetratamento_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public hipotesetratamento_bc( IGxContext context )
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
         ReadRow0O24( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0O24( ) ;
         standaloneModal( ) ;
         AddRow0O24( ) ;
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
            E110O2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z72HipoteseTratamentoId = A72HipoteseTratamentoId;
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

      protected void CONFIRM_0O0( )
      {
         BeforeValidate0O24( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0O24( ) ;
            }
            else
            {
               CheckExtendedTable0O24( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0O24( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120O2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110O2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV13IsHipotese = true;
         AV14HipoteseTratamentoId_Out = A72HipoteseTratamentoId;
      }

      protected void ZM0O24( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z73HipoteseTratamentoNome = A73HipoteseTratamentoNome;
            Z74HipoteseTratamentoAtivo = A74HipoteseTratamentoAtivo;
         }
         if ( GX_JID == -6 )
         {
            Z72HipoteseTratamentoId = A72HipoteseTratamentoId;
            Z73HipoteseTratamentoNome = A73HipoteseTratamentoNome;
            Z74HipoteseTratamentoAtivo = A74HipoteseTratamentoAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A74HipoteseTratamentoAtivo) && ( Gx_BScreen == 0 ) )
         {
            A74HipoteseTratamentoAtivo = true;
         }
      }

      protected void Load0O24( )
      {
         /* Using cursor BC000O4 */
         pr_default.execute(2, new Object[] {A72HipoteseTratamentoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound24 = 1;
            A73HipoteseTratamentoNome = BC000O4_A73HipoteseTratamentoNome[0];
            A74HipoteseTratamentoAtivo = BC000O4_A74HipoteseTratamentoAtivo[0];
            ZM0O24( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0O24( ) ;
      }

      protected void OnLoadActions0O24( )
      {
         A73HipoteseTratamentoNome = StringUtil.Upper( A73HipoteseTratamentoNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "HipoteseTratamento",  A72HipoteseTratamentoId,  A73HipoteseTratamentoNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
      }

      protected void CheckExtendedTable0O24( )
      {
         nIsDirty_24 = 0;
         standaloneModal( ) ;
         nIsDirty_24 = 1;
         A73HipoteseTratamentoNome = StringUtil.Upper( A73HipoteseTratamentoNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "HipoteseTratamento",  A72HipoteseTratamentoId,  A73HipoteseTratamentoNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
         if ( ! AV16IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A73HipoteseTratamentoNome)) )
         {
            GX_msglist.addItem("Informe o nome da Hipótese de Tratamento.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0O24( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0O24( )
      {
         /* Using cursor BC000O5 */
         pr_default.execute(3, new Object[] {A72HipoteseTratamentoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound24 = 1;
         }
         else
         {
            RcdFound24 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000O3 */
         pr_default.execute(1, new Object[] {A72HipoteseTratamentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0O24( 6) ;
            RcdFound24 = 1;
            A72HipoteseTratamentoId = BC000O3_A72HipoteseTratamentoId[0];
            A73HipoteseTratamentoNome = BC000O3_A73HipoteseTratamentoNome[0];
            A74HipoteseTratamentoAtivo = BC000O3_A74HipoteseTratamentoAtivo[0];
            Z72HipoteseTratamentoId = A72HipoteseTratamentoId;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0O24( ) ;
            if ( AnyError == 1 )
            {
               RcdFound24 = 0;
               InitializeNonKey0O24( ) ;
            }
            Gx_mode = sMode24;
         }
         else
         {
            RcdFound24 = 0;
            InitializeNonKey0O24( ) ;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode24;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0O24( ) ;
         if ( RcdFound24 == 0 )
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
         CONFIRM_0O0( ) ;
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

      protected void CheckOptimisticConcurrency0O24( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000O2 */
            pr_default.execute(0, new Object[] {A72HipoteseTratamentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"HipoteseTratamento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z73HipoteseTratamentoNome, BC000O2_A73HipoteseTratamentoNome[0]) != 0 ) || ( Z74HipoteseTratamentoAtivo != BC000O2_A74HipoteseTratamentoAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"HipoteseTratamento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0O24( )
      {
         BeforeValidate0O24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0O24( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0O24( 0) ;
            CheckOptimisticConcurrency0O24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0O24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0O24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000O6 */
                     pr_default.execute(4, new Object[] {A73HipoteseTratamentoNome, A74HipoteseTratamentoAtivo});
                     A72HipoteseTratamentoId = BC000O6_A72HipoteseTratamentoId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("HipoteseTratamento");
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
               Load0O24( ) ;
            }
            EndLevel0O24( ) ;
         }
         CloseExtendedTableCursors0O24( ) ;
      }

      protected void Update0O24( )
      {
         BeforeValidate0O24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0O24( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0O24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0O24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0O24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000O7 */
                     pr_default.execute(5, new Object[] {A73HipoteseTratamentoNome, A74HipoteseTratamentoAtivo, A72HipoteseTratamentoId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("HipoteseTratamento");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"HipoteseTratamento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0O24( ) ;
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
            EndLevel0O24( ) ;
         }
         CloseExtendedTableCursors0O24( ) ;
      }

      protected void DeferredUpdate0O24( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0O24( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0O24( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0O24( ) ;
            AfterConfirm0O24( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0O24( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000O8 */
                  pr_default.execute(6, new Object[] {A72HipoteseTratamentoId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("HipoteseTratamento");
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
         sMode24 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0O24( ) ;
         Gx_mode = sMode24;
      }

      protected void OnDeleteControls0O24( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV16IsOk;
            new validanome(context ).execute(  "HipoteseTratamento",  A72HipoteseTratamentoId,  A73HipoteseTratamentoNome, out  GXt_boolean1) ;
            AV16IsOk = GXt_boolean1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000O9 */
            pr_default.execute(7, new Object[] {A72HipoteseTratamentoId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0O24( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0O24( ) ;
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

      public void ScanKeyStart0O24( )
      {
         /* Scan By routine */
         /* Using cursor BC000O10 */
         pr_default.execute(8, new Object[] {A72HipoteseTratamentoId});
         RcdFound24 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound24 = 1;
            A72HipoteseTratamentoId = BC000O10_A72HipoteseTratamentoId[0];
            A73HipoteseTratamentoNome = BC000O10_A73HipoteseTratamentoNome[0];
            A74HipoteseTratamentoAtivo = BC000O10_A74HipoteseTratamentoAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0O24( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound24 = 0;
         ScanKeyLoad0O24( ) ;
      }

      protected void ScanKeyLoad0O24( )
      {
         sMode24 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound24 = 1;
            A72HipoteseTratamentoId = BC000O10_A72HipoteseTratamentoId[0];
            A73HipoteseTratamentoNome = BC000O10_A73HipoteseTratamentoNome[0];
            A74HipoteseTratamentoAtivo = BC000O10_A74HipoteseTratamentoAtivo[0];
         }
         Gx_mode = sMode24;
      }

      protected void ScanKeyEnd0O24( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0O24( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0O24( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0O24( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0O24( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0O24( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0O24( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0O24( )
      {
      }

      protected void send_integrity_lvl_hashes0O24( )
      {
      }

      protected void AddRow0O24( )
      {
         VarsToRow24( bcHipoteseTratamento) ;
      }

      protected void ReadRow0O24( )
      {
         RowToVars24( bcHipoteseTratamento, 1) ;
      }

      protected void InitializeNonKey0O24( )
      {
         A73HipoteseTratamentoNome = "";
         AV16IsOk = false;
         A74HipoteseTratamentoAtivo = true;
         Z73HipoteseTratamentoNome = "";
         Z74HipoteseTratamentoAtivo = false;
      }

      protected void InitAll0O24( )
      {
         A72HipoteseTratamentoId = 0;
         InitializeNonKey0O24( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A74HipoteseTratamentoAtivo = i74HipoteseTratamentoAtivo;
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

      public void VarsToRow24( SdtHipoteseTratamento obj24 )
      {
         obj24.gxTpr_Mode = Gx_mode;
         obj24.gxTpr_Hipotesetratamentonome = A73HipoteseTratamentoNome;
         obj24.gxTpr_Hipotesetratamentoativo = A74HipoteseTratamentoAtivo;
         obj24.gxTpr_Hipotesetratamentoid = A72HipoteseTratamentoId;
         obj24.gxTpr_Hipotesetratamentoid_Z = Z72HipoteseTratamentoId;
         obj24.gxTpr_Hipotesetratamentonome_Z = Z73HipoteseTratamentoNome;
         obj24.gxTpr_Hipotesetratamentoativo_Z = Z74HipoteseTratamentoAtivo;
         obj24.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow24( SdtHipoteseTratamento obj24 )
      {
         obj24.gxTpr_Hipotesetratamentoid = A72HipoteseTratamentoId;
         return  ;
      }

      public void RowToVars24( SdtHipoteseTratamento obj24 ,
                               int forceLoad )
      {
         Gx_mode = obj24.gxTpr_Mode;
         A73HipoteseTratamentoNome = obj24.gxTpr_Hipotesetratamentonome;
         A74HipoteseTratamentoAtivo = obj24.gxTpr_Hipotesetratamentoativo;
         A72HipoteseTratamentoId = obj24.gxTpr_Hipotesetratamentoid;
         Z72HipoteseTratamentoId = obj24.gxTpr_Hipotesetratamentoid_Z;
         Z73HipoteseTratamentoNome = obj24.gxTpr_Hipotesetratamentonome_Z;
         Z74HipoteseTratamentoAtivo = obj24.gxTpr_Hipotesetratamentoativo_Z;
         Gx_mode = obj24.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A72HipoteseTratamentoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0O24( ) ;
         ScanKeyStart0O24( ) ;
         if ( RcdFound24 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z72HipoteseTratamentoId = A72HipoteseTratamentoId;
         }
         ZM0O24( -6) ;
         OnLoadActions0O24( ) ;
         AddRow0O24( ) ;
         ScanKeyEnd0O24( ) ;
         if ( RcdFound24 == 0 )
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
         RowToVars24( bcHipoteseTratamento, 0) ;
         ScanKeyStart0O24( ) ;
         if ( RcdFound24 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z72HipoteseTratamentoId = A72HipoteseTratamentoId;
         }
         ZM0O24( -6) ;
         OnLoadActions0O24( ) ;
         AddRow0O24( ) ;
         ScanKeyEnd0O24( ) ;
         if ( RcdFound24 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0O24( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0O24( ) ;
         }
         else
         {
            if ( RcdFound24 == 1 )
            {
               if ( A72HipoteseTratamentoId != Z72HipoteseTratamentoId )
               {
                  A72HipoteseTratamentoId = Z72HipoteseTratamentoId;
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
                  Update0O24( ) ;
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
                  if ( A72HipoteseTratamentoId != Z72HipoteseTratamentoId )
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
                        Insert0O24( ) ;
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
                        Insert0O24( ) ;
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
         RowToVars24( bcHipoteseTratamento, 1) ;
         SaveImpl( ) ;
         VarsToRow24( bcHipoteseTratamento) ;
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
         RowToVars24( bcHipoteseTratamento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0O24( ) ;
         AfterTrn( ) ;
         VarsToRow24( bcHipoteseTratamento) ;
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
            SdtHipoteseTratamento auxBC = new SdtHipoteseTratamento(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A72HipoteseTratamentoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcHipoteseTratamento);
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
         RowToVars24( bcHipoteseTratamento, 1) ;
         UpdateImpl( ) ;
         VarsToRow24( bcHipoteseTratamento) ;
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
         RowToVars24( bcHipoteseTratamento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0O24( ) ;
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
         VarsToRow24( bcHipoteseTratamento) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars24( bcHipoteseTratamento, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0O24( ) ;
         if ( RcdFound24 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A72HipoteseTratamentoId != Z72HipoteseTratamentoId )
            {
               A72HipoteseTratamentoId = Z72HipoteseTratamentoId;
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
            if ( A72HipoteseTratamentoId != Z72HipoteseTratamentoId )
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
         context.RollbackDataStores("hipotesetratamento_bc",pr_default);
         VarsToRow24( bcHipoteseTratamento) ;
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
         Gx_mode = bcHipoteseTratamento.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcHipoteseTratamento.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcHipoteseTratamento )
         {
            bcHipoteseTratamento = (SdtHipoteseTratamento)(sdt);
            if ( StringUtil.StrCmp(bcHipoteseTratamento.gxTpr_Mode, "") == 0 )
            {
               bcHipoteseTratamento.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow24( bcHipoteseTratamento) ;
            }
            else
            {
               RowToVars24( bcHipoteseTratamento, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcHipoteseTratamento.gxTpr_Mode, "") == 0 )
            {
               bcHipoteseTratamento.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars24( bcHipoteseTratamento, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtHipoteseTratamento HipoteseTratamento_BC
      {
         get {
            return bcHipoteseTratamento ;
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
            return "hipotesetratamento_Execute" ;
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
         Z73HipoteseTratamentoNome = "";
         A73HipoteseTratamentoNome = "";
         BC000O4_A72HipoteseTratamentoId = new int[1] ;
         BC000O4_A73HipoteseTratamentoNome = new string[] {""} ;
         BC000O4_A74HipoteseTratamentoAtivo = new bool[] {false} ;
         BC000O5_A72HipoteseTratamentoId = new int[1] ;
         BC000O3_A72HipoteseTratamentoId = new int[1] ;
         BC000O3_A73HipoteseTratamentoNome = new string[] {""} ;
         BC000O3_A74HipoteseTratamentoAtivo = new bool[] {false} ;
         sMode24 = "";
         BC000O2_A72HipoteseTratamentoId = new int[1] ;
         BC000O2_A73HipoteseTratamentoNome = new string[] {""} ;
         BC000O2_A74HipoteseTratamentoAtivo = new bool[] {false} ;
         BC000O6_A72HipoteseTratamentoId = new int[1] ;
         BC000O9_A98DocDicionarioId = new int[1] ;
         BC000O10_A72HipoteseTratamentoId = new int[1] ;
         BC000O10_A73HipoteseTratamentoNome = new string[] {""} ;
         BC000O10_A74HipoteseTratamentoAtivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.hipotesetratamento_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.hipotesetratamento_bc__default(),
            new Object[][] {
                new Object[] {
               BC000O2_A72HipoteseTratamentoId, BC000O2_A73HipoteseTratamentoNome, BC000O2_A74HipoteseTratamentoAtivo
               }
               , new Object[] {
               BC000O3_A72HipoteseTratamentoId, BC000O3_A73HipoteseTratamentoNome, BC000O3_A74HipoteseTratamentoAtivo
               }
               , new Object[] {
               BC000O4_A72HipoteseTratamentoId, BC000O4_A73HipoteseTratamentoNome, BC000O4_A74HipoteseTratamentoAtivo
               }
               , new Object[] {
               BC000O5_A72HipoteseTratamentoId
               }
               , new Object[] {
               BC000O6_A72HipoteseTratamentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000O9_A98DocDicionarioId
               }
               , new Object[] {
               BC000O10_A72HipoteseTratamentoId, BC000O10_A73HipoteseTratamentoNome, BC000O10_A74HipoteseTratamentoAtivo
               }
            }
         );
         Z74HipoteseTratamentoAtivo = true;
         A74HipoteseTratamentoAtivo = true;
         i74HipoteseTratamentoAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120O2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound24 ;
      private short nIsDirty_24 ;
      private int trnEnded ;
      private int Z72HipoteseTratamentoId ;
      private int A72HipoteseTratamentoId ;
      private int AV14HipoteseTratamentoId_Out ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode24 ;
      private bool returnInSub ;
      private bool AV13IsHipotese ;
      private bool Z74HipoteseTratamentoAtivo ;
      private bool A74HipoteseTratamentoAtivo ;
      private bool AV16IsOk ;
      private bool GXt_boolean1 ;
      private bool i74HipoteseTratamentoAtivo ;
      private bool mustCommit ;
      private string Z73HipoteseTratamentoNome ;
      private string A73HipoteseTratamentoNome ;
      private IGxSession AV12WebSession ;
      private SdtHipoteseTratamento bcHipoteseTratamento ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000O4_A72HipoteseTratamentoId ;
      private string[] BC000O4_A73HipoteseTratamentoNome ;
      private bool[] BC000O4_A74HipoteseTratamentoAtivo ;
      private int[] BC000O5_A72HipoteseTratamentoId ;
      private int[] BC000O3_A72HipoteseTratamentoId ;
      private string[] BC000O3_A73HipoteseTratamentoNome ;
      private bool[] BC000O3_A74HipoteseTratamentoAtivo ;
      private int[] BC000O2_A72HipoteseTratamentoId ;
      private string[] BC000O2_A73HipoteseTratamentoNome ;
      private bool[] BC000O2_A74HipoteseTratamentoAtivo ;
      private int[] BC000O6_A72HipoteseTratamentoId ;
      private int[] BC000O9_A98DocDicionarioId ;
      private int[] BC000O10_A72HipoteseTratamentoId ;
      private string[] BC000O10_A73HipoteseTratamentoNome ;
      private bool[] BC000O10_A74HipoteseTratamentoAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class hipotesetratamento_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class hipotesetratamento_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000O4;
        prmBC000O4 = new Object[] {
        new ParDef("@HipoteseTratamentoId",GXType.Int32,8,0)
        };
        Object[] prmBC000O5;
        prmBC000O5 = new Object[] {
        new ParDef("@HipoteseTratamentoId",GXType.Int32,8,0)
        };
        Object[] prmBC000O3;
        prmBC000O3 = new Object[] {
        new ParDef("@HipoteseTratamentoId",GXType.Int32,8,0)
        };
        Object[] prmBC000O2;
        prmBC000O2 = new Object[] {
        new ParDef("@HipoteseTratamentoId",GXType.Int32,8,0)
        };
        Object[] prmBC000O6;
        prmBC000O6 = new Object[] {
        new ParDef("@HipoteseTratamentoNome",GXType.NVarChar,100,0) ,
        new ParDef("@HipoteseTratamentoAtivo",GXType.Boolean,4,0)
        };
        Object[] prmBC000O7;
        prmBC000O7 = new Object[] {
        new ParDef("@HipoteseTratamentoNome",GXType.NVarChar,100,0) ,
        new ParDef("@HipoteseTratamentoAtivo",GXType.Boolean,4,0) ,
        new ParDef("@HipoteseTratamentoId",GXType.Int32,8,0)
        };
        Object[] prmBC000O8;
        prmBC000O8 = new Object[] {
        new ParDef("@HipoteseTratamentoId",GXType.Int32,8,0)
        };
        Object[] prmBC000O9;
        prmBC000O9 = new Object[] {
        new ParDef("@HipoteseTratamentoId",GXType.Int32,8,0)
        };
        Object[] prmBC000O10;
        prmBC000O10 = new Object[] {
        new ParDef("@HipoteseTratamentoId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000O2", "SELECT [HipoteseTratamentoId], [HipoteseTratamentoNome], [HipoteseTratamentoAtivo] FROM [HipoteseTratamento] WITH (UPDLOCK) WHERE [HipoteseTratamentoId] = @HipoteseTratamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O3", "SELECT [HipoteseTratamentoId], [HipoteseTratamentoNome], [HipoteseTratamentoAtivo] FROM [HipoteseTratamento] WHERE [HipoteseTratamentoId] = @HipoteseTratamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O4", "SELECT TM1.[HipoteseTratamentoId], TM1.[HipoteseTratamentoNome], TM1.[HipoteseTratamentoAtivo] FROM [HipoteseTratamento] TM1 WHERE TM1.[HipoteseTratamentoId] = @HipoteseTratamentoId ORDER BY TM1.[HipoteseTratamentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O5", "SELECT [HipoteseTratamentoId] FROM [HipoteseTratamento] WHERE [HipoteseTratamentoId] = @HipoteseTratamentoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000O6", "INSERT INTO [HipoteseTratamento]([HipoteseTratamentoNome], [HipoteseTratamentoAtivo]) VALUES(@HipoteseTratamentoNome, @HipoteseTratamentoAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000O7", "UPDATE [HipoteseTratamento] SET [HipoteseTratamentoNome]=@HipoteseTratamentoNome, [HipoteseTratamentoAtivo]=@HipoteseTratamentoAtivo  WHERE [HipoteseTratamentoId] = @HipoteseTratamentoId", GxErrorMask.GX_NOMASK,prmBC000O7)
           ,new CursorDef("BC000O8", "DELETE FROM [HipoteseTratamento]  WHERE [HipoteseTratamentoId] = @HipoteseTratamentoId", GxErrorMask.GX_NOMASK,prmBC000O8)
           ,new CursorDef("BC000O9", "SELECT TOP 1 [DocDicionarioId] FROM [DocDicionario] WHERE [HipoteseTratamentoId] = @HipoteseTratamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000O10", "SELECT TM1.[HipoteseTratamentoId], TM1.[HipoteseTratamentoNome], TM1.[HipoteseTratamentoAtivo] FROM [HipoteseTratamento] TM1 WHERE TM1.[HipoteseTratamentoId] = @HipoteseTratamentoId ORDER BY TM1.[HipoteseTratamentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O10,100, GxCacheFrequency.OFF ,true,false )
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
