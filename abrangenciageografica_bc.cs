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
   public class abrangenciageografica_bc : GXHttpHandler, IGxSilentTrn
   {
      public abrangenciageografica_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public abrangenciageografica_bc( IGxContext context )
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
         ReadRow0C12( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0C12( ) ;
         standaloneModal( ) ;
         AddRow0C12( ) ;
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
            E110C2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z36AbrangenciaGeograficaId = A36AbrangenciaGeograficaId;
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

      protected void CONFIRM_0C0( )
      {
         BeforeValidate0C12( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0C12( ) ;
            }
            else
            {
               CheckExtendedTable0C12( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0C12( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120C2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110C2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0C12( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z37AbrangenciaGeograficaNome = A37AbrangenciaGeograficaNome;
            Z38AbrangenciaGeograficaAtivo = A38AbrangenciaGeograficaAtivo;
         }
         if ( GX_JID == -6 )
         {
            Z36AbrangenciaGeograficaId = A36AbrangenciaGeograficaId;
            Z37AbrangenciaGeograficaNome = A37AbrangenciaGeograficaNome;
            Z38AbrangenciaGeograficaAtivo = A38AbrangenciaGeograficaAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A38AbrangenciaGeograficaAtivo) && ( Gx_BScreen == 0 ) )
         {
            A38AbrangenciaGeograficaAtivo = true;
         }
      }

      protected void Load0C12( )
      {
         /* Using cursor BC000C4 */
         pr_default.execute(2, new Object[] {n36AbrangenciaGeograficaId, A36AbrangenciaGeograficaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound12 = 1;
            A37AbrangenciaGeograficaNome = BC000C4_A37AbrangenciaGeograficaNome[0];
            A38AbrangenciaGeograficaAtivo = BC000C4_A38AbrangenciaGeograficaAtivo[0];
            ZM0C12( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0C12( ) ;
      }

      protected void OnLoadActions0C12( )
      {
         A37AbrangenciaGeograficaNome = StringUtil.Upper( A37AbrangenciaGeograficaNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "AbrangenciaGeografica",  A36AbrangenciaGeograficaId,  A37AbrangenciaGeograficaNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
      }

      protected void CheckExtendedTable0C12( )
      {
         nIsDirty_12 = 0;
         standaloneModal( ) ;
         nIsDirty_12 = 1;
         A37AbrangenciaGeograficaNome = StringUtil.Upper( A37AbrangenciaGeograficaNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "AbrangenciaGeografica",  A36AbrangenciaGeograficaId,  A37AbrangenciaGeograficaNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
         if ( ! AV15IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A37AbrangenciaGeograficaNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Nome", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0C12( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0C12( )
      {
         /* Using cursor BC000C5 */
         pr_default.execute(3, new Object[] {n36AbrangenciaGeograficaId, A36AbrangenciaGeograficaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound12 = 1;
         }
         else
         {
            RcdFound12 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000C3 */
         pr_default.execute(1, new Object[] {n36AbrangenciaGeograficaId, A36AbrangenciaGeograficaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C12( 6) ;
            RcdFound12 = 1;
            A36AbrangenciaGeograficaId = BC000C3_A36AbrangenciaGeograficaId[0];
            n36AbrangenciaGeograficaId = BC000C3_n36AbrangenciaGeograficaId[0];
            A37AbrangenciaGeograficaNome = BC000C3_A37AbrangenciaGeograficaNome[0];
            A38AbrangenciaGeograficaAtivo = BC000C3_A38AbrangenciaGeograficaAtivo[0];
            Z36AbrangenciaGeograficaId = A36AbrangenciaGeograficaId;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0C12( ) ;
            if ( AnyError == 1 )
            {
               RcdFound12 = 0;
               InitializeNonKey0C12( ) ;
            }
            Gx_mode = sMode12;
         }
         else
         {
            RcdFound12 = 0;
            InitializeNonKey0C12( ) ;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode12;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C12( ) ;
         if ( RcdFound12 == 0 )
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
         CONFIRM_0C0( ) ;
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

      protected void CheckOptimisticConcurrency0C12( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000C2 */
            pr_default.execute(0, new Object[] {n36AbrangenciaGeograficaId, A36AbrangenciaGeograficaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AbrangenciaGeografica"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z37AbrangenciaGeograficaNome, BC000C2_A37AbrangenciaGeograficaNome[0]) != 0 ) || ( Z38AbrangenciaGeograficaAtivo != BC000C2_A38AbrangenciaGeograficaAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AbrangenciaGeografica"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C12( )
      {
         BeforeValidate0C12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C12( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C12( 0) ;
            CheckOptimisticConcurrency0C12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C6 */
                     pr_default.execute(4, new Object[] {A37AbrangenciaGeograficaNome, A38AbrangenciaGeograficaAtivo});
                     A36AbrangenciaGeograficaId = BC000C6_A36AbrangenciaGeograficaId[0];
                     n36AbrangenciaGeograficaId = BC000C6_n36AbrangenciaGeograficaId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("AbrangenciaGeografica");
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
               Load0C12( ) ;
            }
            EndLevel0C12( ) ;
         }
         CloseExtendedTableCursors0C12( ) ;
      }

      protected void Update0C12( )
      {
         BeforeValidate0C12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C12( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C7 */
                     pr_default.execute(5, new Object[] {A37AbrangenciaGeograficaNome, A38AbrangenciaGeograficaAtivo, n36AbrangenciaGeograficaId, A36AbrangenciaGeograficaId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("AbrangenciaGeografica");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AbrangenciaGeografica"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C12( ) ;
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
            EndLevel0C12( ) ;
         }
         CloseExtendedTableCursors0C12( ) ;
      }

      protected void DeferredUpdate0C12( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0C12( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C12( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C12( ) ;
            AfterConfirm0C12( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C12( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000C8 */
                  pr_default.execute(6, new Object[] {n36AbrangenciaGeograficaId, A36AbrangenciaGeograficaId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("AbrangenciaGeografica");
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
         sMode12 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0C12( ) ;
         Gx_mode = sMode12;
      }

      protected void OnDeleteControls0C12( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV15IsOk;
            new validanome(context ).execute(  "AbrangenciaGeografica",  A36AbrangenciaGeograficaId,  A37AbrangenciaGeograficaNome, out  GXt_boolean1) ;
            AV15IsOk = GXt_boolean1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000C9 */
            pr_default.execute(7, new Object[] {n36AbrangenciaGeograficaId, A36AbrangenciaGeograficaId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0C12( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C12( ) ;
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

      public void ScanKeyStart0C12( )
      {
         /* Scan By routine */
         /* Using cursor BC000C10 */
         pr_default.execute(8, new Object[] {n36AbrangenciaGeograficaId, A36AbrangenciaGeograficaId});
         RcdFound12 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound12 = 1;
            A36AbrangenciaGeograficaId = BC000C10_A36AbrangenciaGeograficaId[0];
            n36AbrangenciaGeograficaId = BC000C10_n36AbrangenciaGeograficaId[0];
            A37AbrangenciaGeograficaNome = BC000C10_A37AbrangenciaGeograficaNome[0];
            A38AbrangenciaGeograficaAtivo = BC000C10_A38AbrangenciaGeograficaAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0C12( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound12 = 0;
         ScanKeyLoad0C12( ) ;
      }

      protected void ScanKeyLoad0C12( )
      {
         sMode12 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound12 = 1;
            A36AbrangenciaGeograficaId = BC000C10_A36AbrangenciaGeograficaId[0];
            n36AbrangenciaGeograficaId = BC000C10_n36AbrangenciaGeograficaId[0];
            A37AbrangenciaGeograficaNome = BC000C10_A37AbrangenciaGeograficaNome[0];
            A38AbrangenciaGeograficaAtivo = BC000C10_A38AbrangenciaGeograficaAtivo[0];
         }
         Gx_mode = sMode12;
      }

      protected void ScanKeyEnd0C12( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0C12( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C12( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C12( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C12( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C12( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C12( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C12( )
      {
      }

      protected void send_integrity_lvl_hashes0C12( )
      {
      }

      protected void AddRow0C12( )
      {
         VarsToRow12( bcAbrangenciaGeografica) ;
      }

      protected void ReadRow0C12( )
      {
         RowToVars12( bcAbrangenciaGeografica, 1) ;
      }

      protected void InitializeNonKey0C12( )
      {
         A37AbrangenciaGeograficaNome = "";
         AV15IsOk = false;
         A38AbrangenciaGeograficaAtivo = true;
         Z37AbrangenciaGeograficaNome = "";
         Z38AbrangenciaGeograficaAtivo = false;
      }

      protected void InitAll0C12( )
      {
         A36AbrangenciaGeograficaId = 0;
         n36AbrangenciaGeograficaId = false;
         InitializeNonKey0C12( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A38AbrangenciaGeograficaAtivo = i38AbrangenciaGeograficaAtivo;
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

      public void VarsToRow12( SdtAbrangenciaGeografica obj12 )
      {
         obj12.gxTpr_Mode = Gx_mode;
         obj12.gxTpr_Abrangenciageograficanome = A37AbrangenciaGeograficaNome;
         obj12.gxTpr_Abrangenciageograficaativo = A38AbrangenciaGeograficaAtivo;
         obj12.gxTpr_Abrangenciageograficaid = A36AbrangenciaGeograficaId;
         obj12.gxTpr_Abrangenciageograficaid_Z = Z36AbrangenciaGeograficaId;
         obj12.gxTpr_Abrangenciageograficanome_Z = Z37AbrangenciaGeograficaNome;
         obj12.gxTpr_Abrangenciageograficaativo_Z = Z38AbrangenciaGeograficaAtivo;
         obj12.gxTpr_Abrangenciageograficaid_N = (short)(Convert.ToInt16(n36AbrangenciaGeograficaId));
         obj12.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow12( SdtAbrangenciaGeografica obj12 )
      {
         obj12.gxTpr_Abrangenciageograficaid = A36AbrangenciaGeograficaId;
         return  ;
      }

      public void RowToVars12( SdtAbrangenciaGeografica obj12 ,
                               int forceLoad )
      {
         Gx_mode = obj12.gxTpr_Mode;
         A37AbrangenciaGeograficaNome = obj12.gxTpr_Abrangenciageograficanome;
         A38AbrangenciaGeograficaAtivo = obj12.gxTpr_Abrangenciageograficaativo;
         A36AbrangenciaGeograficaId = obj12.gxTpr_Abrangenciageograficaid;
         n36AbrangenciaGeograficaId = false;
         Z36AbrangenciaGeograficaId = obj12.gxTpr_Abrangenciageograficaid_Z;
         Z37AbrangenciaGeograficaNome = obj12.gxTpr_Abrangenciageograficanome_Z;
         Z38AbrangenciaGeograficaAtivo = obj12.gxTpr_Abrangenciageograficaativo_Z;
         n36AbrangenciaGeograficaId = (bool)(Convert.ToBoolean(obj12.gxTpr_Abrangenciageograficaid_N));
         Gx_mode = obj12.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A36AbrangenciaGeograficaId = (int)getParm(obj,0);
         n36AbrangenciaGeograficaId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0C12( ) ;
         ScanKeyStart0C12( ) ;
         if ( RcdFound12 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z36AbrangenciaGeograficaId = A36AbrangenciaGeograficaId;
         }
         ZM0C12( -6) ;
         OnLoadActions0C12( ) ;
         AddRow0C12( ) ;
         ScanKeyEnd0C12( ) ;
         if ( RcdFound12 == 0 )
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
         RowToVars12( bcAbrangenciaGeografica, 0) ;
         ScanKeyStart0C12( ) ;
         if ( RcdFound12 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z36AbrangenciaGeograficaId = A36AbrangenciaGeograficaId;
         }
         ZM0C12( -6) ;
         OnLoadActions0C12( ) ;
         AddRow0C12( ) ;
         ScanKeyEnd0C12( ) ;
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0C12( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0C12( ) ;
         }
         else
         {
            if ( RcdFound12 == 1 )
            {
               if ( A36AbrangenciaGeograficaId != Z36AbrangenciaGeograficaId )
               {
                  A36AbrangenciaGeograficaId = Z36AbrangenciaGeograficaId;
                  n36AbrangenciaGeograficaId = false;
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
                  Update0C12( ) ;
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
                  if ( A36AbrangenciaGeograficaId != Z36AbrangenciaGeograficaId )
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
                        Insert0C12( ) ;
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
                        Insert0C12( ) ;
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
         RowToVars12( bcAbrangenciaGeografica, 1) ;
         SaveImpl( ) ;
         VarsToRow12( bcAbrangenciaGeografica) ;
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
         RowToVars12( bcAbrangenciaGeografica, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0C12( ) ;
         AfterTrn( ) ;
         VarsToRow12( bcAbrangenciaGeografica) ;
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
            SdtAbrangenciaGeografica auxBC = new SdtAbrangenciaGeografica(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A36AbrangenciaGeograficaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcAbrangenciaGeografica);
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
         RowToVars12( bcAbrangenciaGeografica, 1) ;
         UpdateImpl( ) ;
         VarsToRow12( bcAbrangenciaGeografica) ;
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
         RowToVars12( bcAbrangenciaGeografica, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0C12( ) ;
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
         VarsToRow12( bcAbrangenciaGeografica) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars12( bcAbrangenciaGeografica, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0C12( ) ;
         if ( RcdFound12 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A36AbrangenciaGeograficaId != Z36AbrangenciaGeograficaId )
            {
               A36AbrangenciaGeograficaId = Z36AbrangenciaGeograficaId;
               n36AbrangenciaGeograficaId = false;
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
            if ( A36AbrangenciaGeograficaId != Z36AbrangenciaGeograficaId )
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
         context.RollbackDataStores("abrangenciageografica_bc",pr_default);
         VarsToRow12( bcAbrangenciaGeografica) ;
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
         Gx_mode = bcAbrangenciaGeografica.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcAbrangenciaGeografica.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcAbrangenciaGeografica )
         {
            bcAbrangenciaGeografica = (SdtAbrangenciaGeografica)(sdt);
            if ( StringUtil.StrCmp(bcAbrangenciaGeografica.gxTpr_Mode, "") == 0 )
            {
               bcAbrangenciaGeografica.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow12( bcAbrangenciaGeografica) ;
            }
            else
            {
               RowToVars12( bcAbrangenciaGeografica, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcAbrangenciaGeografica.gxTpr_Mode, "") == 0 )
            {
               bcAbrangenciaGeografica.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars12( bcAbrangenciaGeografica, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtAbrangenciaGeografica AbrangenciaGeografica_BC
      {
         get {
            return bcAbrangenciaGeografica ;
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
         Z37AbrangenciaGeograficaNome = "";
         A37AbrangenciaGeograficaNome = "";
         BC000C4_A36AbrangenciaGeograficaId = new int[1] ;
         BC000C4_n36AbrangenciaGeograficaId = new bool[] {false} ;
         BC000C4_A37AbrangenciaGeograficaNome = new string[] {""} ;
         BC000C4_A38AbrangenciaGeograficaAtivo = new bool[] {false} ;
         BC000C5_A36AbrangenciaGeograficaId = new int[1] ;
         BC000C5_n36AbrangenciaGeograficaId = new bool[] {false} ;
         BC000C3_A36AbrangenciaGeograficaId = new int[1] ;
         BC000C3_n36AbrangenciaGeograficaId = new bool[] {false} ;
         BC000C3_A37AbrangenciaGeograficaNome = new string[] {""} ;
         BC000C3_A38AbrangenciaGeograficaAtivo = new bool[] {false} ;
         sMode12 = "";
         BC000C2_A36AbrangenciaGeograficaId = new int[1] ;
         BC000C2_n36AbrangenciaGeograficaId = new bool[] {false} ;
         BC000C2_A37AbrangenciaGeograficaNome = new string[] {""} ;
         BC000C2_A38AbrangenciaGeograficaAtivo = new bool[] {false} ;
         BC000C6_A36AbrangenciaGeograficaId = new int[1] ;
         BC000C6_n36AbrangenciaGeograficaId = new bool[] {false} ;
         BC000C9_A75DocumentoId = new int[1] ;
         BC000C10_A36AbrangenciaGeograficaId = new int[1] ;
         BC000C10_n36AbrangenciaGeograficaId = new bool[] {false} ;
         BC000C10_A37AbrangenciaGeograficaNome = new string[] {""} ;
         BC000C10_A38AbrangenciaGeograficaAtivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.abrangenciageografica_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.abrangenciageografica_bc__default(),
            new Object[][] {
                new Object[] {
               BC000C2_A36AbrangenciaGeograficaId, BC000C2_A37AbrangenciaGeograficaNome, BC000C2_A38AbrangenciaGeograficaAtivo
               }
               , new Object[] {
               BC000C3_A36AbrangenciaGeograficaId, BC000C3_A37AbrangenciaGeograficaNome, BC000C3_A38AbrangenciaGeograficaAtivo
               }
               , new Object[] {
               BC000C4_A36AbrangenciaGeograficaId, BC000C4_A37AbrangenciaGeograficaNome, BC000C4_A38AbrangenciaGeograficaAtivo
               }
               , new Object[] {
               BC000C5_A36AbrangenciaGeograficaId
               }
               , new Object[] {
               BC000C6_A36AbrangenciaGeograficaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000C9_A75DocumentoId
               }
               , new Object[] {
               BC000C10_A36AbrangenciaGeograficaId, BC000C10_A37AbrangenciaGeograficaNome, BC000C10_A38AbrangenciaGeograficaAtivo
               }
            }
         );
         Z38AbrangenciaGeograficaAtivo = true;
         A38AbrangenciaGeograficaAtivo = true;
         i38AbrangenciaGeograficaAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120C2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound12 ;
      private short nIsDirty_12 ;
      private int trnEnded ;
      private int Z36AbrangenciaGeograficaId ;
      private int A36AbrangenciaGeograficaId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode12 ;
      private bool returnInSub ;
      private bool Z38AbrangenciaGeograficaAtivo ;
      private bool A38AbrangenciaGeograficaAtivo ;
      private bool n36AbrangenciaGeograficaId ;
      private bool AV15IsOk ;
      private bool GXt_boolean1 ;
      private bool i38AbrangenciaGeograficaAtivo ;
      private bool mustCommit ;
      private string Z37AbrangenciaGeograficaNome ;
      private string A37AbrangenciaGeograficaNome ;
      private IGxSession AV12WebSession ;
      private SdtAbrangenciaGeografica bcAbrangenciaGeografica ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000C4_A36AbrangenciaGeograficaId ;
      private bool[] BC000C4_n36AbrangenciaGeograficaId ;
      private string[] BC000C4_A37AbrangenciaGeograficaNome ;
      private bool[] BC000C4_A38AbrangenciaGeograficaAtivo ;
      private int[] BC000C5_A36AbrangenciaGeograficaId ;
      private bool[] BC000C5_n36AbrangenciaGeograficaId ;
      private int[] BC000C3_A36AbrangenciaGeograficaId ;
      private bool[] BC000C3_n36AbrangenciaGeograficaId ;
      private string[] BC000C3_A37AbrangenciaGeograficaNome ;
      private bool[] BC000C3_A38AbrangenciaGeograficaAtivo ;
      private int[] BC000C2_A36AbrangenciaGeograficaId ;
      private bool[] BC000C2_n36AbrangenciaGeograficaId ;
      private string[] BC000C2_A37AbrangenciaGeograficaNome ;
      private bool[] BC000C2_A38AbrangenciaGeograficaAtivo ;
      private int[] BC000C6_A36AbrangenciaGeograficaId ;
      private bool[] BC000C6_n36AbrangenciaGeograficaId ;
      private int[] BC000C9_A75DocumentoId ;
      private int[] BC000C10_A36AbrangenciaGeograficaId ;
      private bool[] BC000C10_n36AbrangenciaGeograficaId ;
      private string[] BC000C10_A37AbrangenciaGeograficaNome ;
      private bool[] BC000C10_A38AbrangenciaGeograficaAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
   }

   public class abrangenciageografica_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class abrangenciageografica_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000C4;
        prmBC000C4 = new Object[] {
        new ParDef("@AbrangenciaGeograficaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000C5;
        prmBC000C5 = new Object[] {
        new ParDef("@AbrangenciaGeograficaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000C3;
        prmBC000C3 = new Object[] {
        new ParDef("@AbrangenciaGeograficaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000C2;
        prmBC000C2 = new Object[] {
        new ParDef("@AbrangenciaGeograficaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000C6;
        prmBC000C6 = new Object[] {
        new ParDef("@AbrangenciaGeograficaNome",GXType.NVarChar,100,0) ,
        new ParDef("@AbrangenciaGeograficaAtivo",GXType.Boolean,4,0)
        };
        Object[] prmBC000C7;
        prmBC000C7 = new Object[] {
        new ParDef("@AbrangenciaGeograficaNome",GXType.NVarChar,100,0) ,
        new ParDef("@AbrangenciaGeograficaAtivo",GXType.Boolean,4,0) ,
        new ParDef("@AbrangenciaGeograficaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000C8;
        prmBC000C8 = new Object[] {
        new ParDef("@AbrangenciaGeograficaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000C9;
        prmBC000C9 = new Object[] {
        new ParDef("@AbrangenciaGeograficaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000C10;
        prmBC000C10 = new Object[] {
        new ParDef("@AbrangenciaGeograficaId",GXType.Int32,8,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC000C2", "SELECT [AbrangenciaGeograficaId], [AbrangenciaGeograficaNome], [AbrangenciaGeograficaAtivo] FROM [AbrangenciaGeografica] WITH (UPDLOCK) WHERE [AbrangenciaGeograficaId] = @AbrangenciaGeograficaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C3", "SELECT [AbrangenciaGeograficaId], [AbrangenciaGeograficaNome], [AbrangenciaGeograficaAtivo] FROM [AbrangenciaGeografica] WHERE [AbrangenciaGeograficaId] = @AbrangenciaGeograficaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C4", "SELECT TM1.[AbrangenciaGeograficaId], TM1.[AbrangenciaGeograficaNome], TM1.[AbrangenciaGeograficaAtivo] FROM [AbrangenciaGeografica] TM1 WHERE TM1.[AbrangenciaGeograficaId] = @AbrangenciaGeograficaId ORDER BY TM1.[AbrangenciaGeograficaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C5", "SELECT [AbrangenciaGeograficaId] FROM [AbrangenciaGeografica] WHERE [AbrangenciaGeograficaId] = @AbrangenciaGeograficaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C6", "INSERT INTO [AbrangenciaGeografica]([AbrangenciaGeograficaNome], [AbrangenciaGeograficaAtivo]) VALUES(@AbrangenciaGeograficaNome, @AbrangenciaGeograficaAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000C7", "UPDATE [AbrangenciaGeografica] SET [AbrangenciaGeograficaNome]=@AbrangenciaGeograficaNome, [AbrangenciaGeograficaAtivo]=@AbrangenciaGeograficaAtivo  WHERE [AbrangenciaGeograficaId] = @AbrangenciaGeograficaId", GxErrorMask.GX_NOMASK,prmBC000C7)
           ,new CursorDef("BC000C8", "DELETE FROM [AbrangenciaGeografica]  WHERE [AbrangenciaGeograficaId] = @AbrangenciaGeograficaId", GxErrorMask.GX_NOMASK,prmBC000C8)
           ,new CursorDef("BC000C9", "SELECT TOP 1 [DocumentoId] FROM [Documento] WHERE [AbrangenciaGeograficaId] = @AbrangenciaGeograficaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000C10", "SELECT TM1.[AbrangenciaGeograficaId], TM1.[AbrangenciaGeograficaNome], TM1.[AbrangenciaGeograficaAtivo] FROM [AbrangenciaGeografica] TM1 WHERE TM1.[AbrangenciaGeograficaId] = @AbrangenciaGeograficaId ORDER BY TM1.[AbrangenciaGeograficaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C10,100, GxCacheFrequency.OFF ,true,false )
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
