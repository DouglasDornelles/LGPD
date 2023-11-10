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
   public class processo_bc : GXHttpHandler, IGxSilentTrn
   {
      public processo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public processo_bc( IGxContext context )
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
         ReadRow066( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey066( ) ;
         standaloneModal( ) ;
         AddRow066( ) ;
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
            E11062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z16ProcessoId = A16ProcessoId;
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

      protected void CONFIRM_060( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls066( ) ;
            }
            else
            {
               CheckExtendedTable066( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors066( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12062( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11062( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV23IsProcesso = true;
         AV24ProcessoId_Out = A16ProcessoId;
      }

      protected void ZM066( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z17ProcessoNome = A17ProcessoNome;
            Z19ProcessoAtivo = A19ProcessoAtivo;
         }
         if ( GX_JID == -6 )
         {
            Z16ProcessoId = A16ProcessoId;
            Z17ProcessoNome = A17ProcessoNome;
            Z19ProcessoAtivo = A19ProcessoAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A19ProcessoAtivo) && ( Gx_BScreen == 0 ) )
         {
            A19ProcessoAtivo = true;
         }
      }

      protected void Load066( )
      {
         /* Using cursor BC00064 */
         pr_default.execute(2, new Object[] {n16ProcessoId, A16ProcessoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound6 = 1;
            A17ProcessoNome = BC00064_A17ProcessoNome[0];
            A19ProcessoAtivo = BC00064_A19ProcessoAtivo[0];
            ZM066( -6) ;
         }
         pr_default.close(2);
         OnLoadActions066( ) ;
      }

      protected void OnLoadActions066( )
      {
         A17ProcessoNome = StringUtil.Upper( A17ProcessoNome);
         GXt_boolean1 = AV26IsOk;
         new validanome(context ).execute(  "Processo",  A16ProcessoId,  A17ProcessoNome, out  GXt_boolean1) ;
         AV26IsOk = GXt_boolean1;
      }

      protected void CheckExtendedTable066( )
      {
         nIsDirty_6 = 0;
         standaloneModal( ) ;
         nIsDirty_6 = 1;
         A17ProcessoNome = StringUtil.Upper( A17ProcessoNome);
         GXt_boolean1 = AV26IsOk;
         new validanome(context ).execute(  "Processo",  A16ProcessoId,  A17ProcessoNome, out  GXt_boolean1) ;
         AV26IsOk = GXt_boolean1;
         if ( ! AV26IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A17ProcessoNome)) )
         {
            GX_msglist.addItem("Informe o nome do processo.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors066( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey066( )
      {
         /* Using cursor BC00065 */
         pr_default.execute(3, new Object[] {n16ProcessoId, A16ProcessoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00063 */
         pr_default.execute(1, new Object[] {n16ProcessoId, A16ProcessoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM066( 6) ;
            RcdFound6 = 1;
            A16ProcessoId = BC00063_A16ProcessoId[0];
            n16ProcessoId = BC00063_n16ProcessoId[0];
            A17ProcessoNome = BC00063_A17ProcessoNome[0];
            A19ProcessoAtivo = BC00063_A19ProcessoAtivo[0];
            Z16ProcessoId = A16ProcessoId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load066( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey066( ) ;
            }
            Gx_mode = sMode6;
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey066( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode6;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey066( ) ;
         if ( RcdFound6 == 0 )
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
         CONFIRM_060( ) ;
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

      protected void CheckOptimisticConcurrency066( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00062 */
            pr_default.execute(0, new Object[] {n16ProcessoId, A16ProcessoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Processo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z17ProcessoNome, BC00062_A17ProcessoNome[0]) != 0 ) || ( Z19ProcessoAtivo != BC00062_A19ProcessoAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Processo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert066( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM066( 0) ;
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00066 */
                     pr_default.execute(4, new Object[] {A17ProcessoNome, A19ProcessoAtivo});
                     A16ProcessoId = BC00066_A16ProcessoId[0];
                     n16ProcessoId = BC00066_n16ProcessoId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("Processo");
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
               Load066( ) ;
            }
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void Update066( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00067 */
                     pr_default.execute(5, new Object[] {A17ProcessoNome, A19ProcessoAtivo, n16ProcessoId, A16ProcessoId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("Processo");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Processo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate066( ) ;
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
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void DeferredUpdate066( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls066( ) ;
            AfterConfirm066( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete066( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00068 */
                  pr_default.execute(6, new Object[] {n16ProcessoId, A16ProcessoId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("Processo");
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel066( ) ;
         Gx_mode = sMode6;
      }

      protected void OnDeleteControls066( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV26IsOk;
            new validanome(context ).execute(  "Processo",  A16ProcessoId,  A17ProcessoNome, out  GXt_boolean1) ;
            AV26IsOk = GXt_boolean1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC00069 */
            pr_default.execute(7, new Object[] {n16ProcessoId, A16ProcessoId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
            /* Using cursor BC000610 */
            pr_default.execute(8, new Object[] {n16ProcessoId, A16ProcessoId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SubProcesso."}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
         }
      }

      protected void EndLevel066( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete066( ) ;
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

      public void ScanKeyStart066( )
      {
         /* Scan By routine */
         /* Using cursor BC000611 */
         pr_default.execute(9, new Object[] {n16ProcessoId, A16ProcessoId});
         RcdFound6 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound6 = 1;
            A16ProcessoId = BC000611_A16ProcessoId[0];
            n16ProcessoId = BC000611_n16ProcessoId[0];
            A17ProcessoNome = BC000611_A17ProcessoNome[0];
            A19ProcessoAtivo = BC000611_A19ProcessoAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext066( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound6 = 0;
         ScanKeyLoad066( ) ;
      }

      protected void ScanKeyLoad066( )
      {
         sMode6 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound6 = 1;
            A16ProcessoId = BC000611_A16ProcessoId[0];
            n16ProcessoId = BC000611_n16ProcessoId[0];
            A17ProcessoNome = BC000611_A17ProcessoNome[0];
            A19ProcessoAtivo = BC000611_A19ProcessoAtivo[0];
         }
         Gx_mode = sMode6;
      }

      protected void ScanKeyEnd066( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm066( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert066( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate066( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete066( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete066( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate066( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes066( )
      {
      }

      protected void send_integrity_lvl_hashes066( )
      {
      }

      protected void AddRow066( )
      {
         VarsToRow6( bcProcesso) ;
      }

      protected void ReadRow066( )
      {
         RowToVars6( bcProcesso, 1) ;
      }

      protected void InitializeNonKey066( )
      {
         A17ProcessoNome = "";
         AV26IsOk = false;
         A19ProcessoAtivo = true;
         Z17ProcessoNome = "";
         Z19ProcessoAtivo = false;
      }

      protected void InitAll066( )
      {
         A16ProcessoId = 0;
         n16ProcessoId = false;
         InitializeNonKey066( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A19ProcessoAtivo = i19ProcessoAtivo;
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

      public void VarsToRow6( SdtProcesso obj6 )
      {
         obj6.gxTpr_Mode = Gx_mode;
         obj6.gxTpr_Processonome = A17ProcessoNome;
         obj6.gxTpr_Processoativo = A19ProcessoAtivo;
         obj6.gxTpr_Processoid = A16ProcessoId;
         obj6.gxTpr_Processoid_Z = Z16ProcessoId;
         obj6.gxTpr_Processonome_Z = Z17ProcessoNome;
         obj6.gxTpr_Processoativo_Z = Z19ProcessoAtivo;
         obj6.gxTpr_Processoid_N = (short)(Convert.ToInt16(n16ProcessoId));
         obj6.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow6( SdtProcesso obj6 )
      {
         obj6.gxTpr_Processoid = A16ProcessoId;
         return  ;
      }

      public void RowToVars6( SdtProcesso obj6 ,
                              int forceLoad )
      {
         Gx_mode = obj6.gxTpr_Mode;
         A17ProcessoNome = obj6.gxTpr_Processonome;
         A19ProcessoAtivo = obj6.gxTpr_Processoativo;
         A16ProcessoId = obj6.gxTpr_Processoid;
         n16ProcessoId = false;
         Z16ProcessoId = obj6.gxTpr_Processoid_Z;
         Z17ProcessoNome = obj6.gxTpr_Processonome_Z;
         Z19ProcessoAtivo = obj6.gxTpr_Processoativo_Z;
         n16ProcessoId = (bool)(Convert.ToBoolean(obj6.gxTpr_Processoid_N));
         Gx_mode = obj6.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A16ProcessoId = (int)getParm(obj,0);
         n16ProcessoId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey066( ) ;
         ScanKeyStart066( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z16ProcessoId = A16ProcessoId;
         }
         ZM066( -6) ;
         OnLoadActions066( ) ;
         AddRow066( ) ;
         ScanKeyEnd066( ) ;
         if ( RcdFound6 == 0 )
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
         RowToVars6( bcProcesso, 0) ;
         ScanKeyStart066( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z16ProcessoId = A16ProcessoId;
         }
         ZM066( -6) ;
         OnLoadActions066( ) ;
         AddRow066( ) ;
         ScanKeyEnd066( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey066( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert066( ) ;
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( A16ProcessoId != Z16ProcessoId )
               {
                  A16ProcessoId = Z16ProcessoId;
                  n16ProcessoId = false;
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
                  Update066( ) ;
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
                  if ( A16ProcessoId != Z16ProcessoId )
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
                        Insert066( ) ;
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
                        Insert066( ) ;
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
         RowToVars6( bcProcesso, 1) ;
         SaveImpl( ) ;
         VarsToRow6( bcProcesso) ;
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
         RowToVars6( bcProcesso, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert066( ) ;
         AfterTrn( ) ;
         VarsToRow6( bcProcesso) ;
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
            SdtProcesso auxBC = new SdtProcesso(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A16ProcessoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcProcesso);
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
         RowToVars6( bcProcesso, 1) ;
         UpdateImpl( ) ;
         VarsToRow6( bcProcesso) ;
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
         RowToVars6( bcProcesso, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert066( ) ;
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
         VarsToRow6( bcProcesso) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars6( bcProcesso, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey066( ) ;
         if ( RcdFound6 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A16ProcessoId != Z16ProcessoId )
            {
               A16ProcessoId = Z16ProcessoId;
               n16ProcessoId = false;
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
            if ( A16ProcessoId != Z16ProcessoId )
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
         context.RollbackDataStores("processo_bc",pr_default);
         VarsToRow6( bcProcesso) ;
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
         Gx_mode = bcProcesso.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcProcesso.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcProcesso )
         {
            bcProcesso = (SdtProcesso)(sdt);
            if ( StringUtil.StrCmp(bcProcesso.gxTpr_Mode, "") == 0 )
            {
               bcProcesso.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow6( bcProcesso) ;
            }
            else
            {
               RowToVars6( bcProcesso, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcProcesso.gxTpr_Mode, "") == 0 )
            {
               bcProcesso.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars6( bcProcesso, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtProcesso Processo_BC
      {
         get {
            return bcProcesso ;
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
            return "processo_Execute" ;
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
         Z17ProcessoNome = "";
         A17ProcessoNome = "";
         BC00064_A16ProcessoId = new int[1] ;
         BC00064_n16ProcessoId = new bool[] {false} ;
         BC00064_A17ProcessoNome = new string[] {""} ;
         BC00064_A19ProcessoAtivo = new bool[] {false} ;
         BC00065_A16ProcessoId = new int[1] ;
         BC00065_n16ProcessoId = new bool[] {false} ;
         BC00063_A16ProcessoId = new int[1] ;
         BC00063_n16ProcessoId = new bool[] {false} ;
         BC00063_A17ProcessoNome = new string[] {""} ;
         BC00063_A19ProcessoAtivo = new bool[] {false} ;
         sMode6 = "";
         BC00062_A16ProcessoId = new int[1] ;
         BC00062_n16ProcessoId = new bool[] {false} ;
         BC00062_A17ProcessoNome = new string[] {""} ;
         BC00062_A19ProcessoAtivo = new bool[] {false} ;
         BC00066_A16ProcessoId = new int[1] ;
         BC00066_n16ProcessoId = new bool[] {false} ;
         BC00069_A75DocumentoId = new int[1] ;
         BC000610_A20SubprocessoId = new int[1] ;
         BC000611_A16ProcessoId = new int[1] ;
         BC000611_n16ProcessoId = new bool[] {false} ;
         BC000611_A17ProcessoNome = new string[] {""} ;
         BC000611_A19ProcessoAtivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.processo_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.processo_bc__default(),
            new Object[][] {
                new Object[] {
               BC00062_A16ProcessoId, BC00062_A17ProcessoNome, BC00062_A19ProcessoAtivo
               }
               , new Object[] {
               BC00063_A16ProcessoId, BC00063_A17ProcessoNome, BC00063_A19ProcessoAtivo
               }
               , new Object[] {
               BC00064_A16ProcessoId, BC00064_A17ProcessoNome, BC00064_A19ProcessoAtivo
               }
               , new Object[] {
               BC00065_A16ProcessoId
               }
               , new Object[] {
               BC00066_A16ProcessoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00069_A75DocumentoId
               }
               , new Object[] {
               BC000610_A20SubprocessoId
               }
               , new Object[] {
               BC000611_A16ProcessoId, BC000611_A17ProcessoNome, BC000611_A19ProcessoAtivo
               }
            }
         );
         Z19ProcessoAtivo = true;
         A19ProcessoAtivo = true;
         i19ProcessoAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12062 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound6 ;
      private short nIsDirty_6 ;
      private int trnEnded ;
      private int Z16ProcessoId ;
      private int A16ProcessoId ;
      private int AV24ProcessoId_Out ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode6 ;
      private bool returnInSub ;
      private bool AV23IsProcesso ;
      private bool Z19ProcessoAtivo ;
      private bool A19ProcessoAtivo ;
      private bool n16ProcessoId ;
      private bool AV26IsOk ;
      private bool GXt_boolean1 ;
      private bool i19ProcessoAtivo ;
      private bool mustCommit ;
      private string Z17ProcessoNome ;
      private string A17ProcessoNome ;
      private IGxSession AV12WebSession ;
      private SdtProcesso bcProcesso ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00064_A16ProcessoId ;
      private bool[] BC00064_n16ProcessoId ;
      private string[] BC00064_A17ProcessoNome ;
      private bool[] BC00064_A19ProcessoAtivo ;
      private int[] BC00065_A16ProcessoId ;
      private bool[] BC00065_n16ProcessoId ;
      private int[] BC00063_A16ProcessoId ;
      private bool[] BC00063_n16ProcessoId ;
      private string[] BC00063_A17ProcessoNome ;
      private bool[] BC00063_A19ProcessoAtivo ;
      private int[] BC00062_A16ProcessoId ;
      private bool[] BC00062_n16ProcessoId ;
      private string[] BC00062_A17ProcessoNome ;
      private bool[] BC00062_A19ProcessoAtivo ;
      private int[] BC00066_A16ProcessoId ;
      private bool[] BC00066_n16ProcessoId ;
      private int[] BC00069_A75DocumentoId ;
      private int[] BC000610_A20SubprocessoId ;
      private int[] BC000611_A16ProcessoId ;
      private bool[] BC000611_n16ProcessoId ;
      private string[] BC000611_A17ProcessoNome ;
      private bool[] BC000611_A19ProcessoAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class processo_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class processo_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00064;
        prmBC00064 = new Object[] {
        new ParDef("@ProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00065;
        prmBC00065 = new Object[] {
        new ParDef("@ProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00063;
        prmBC00063 = new Object[] {
        new ParDef("@ProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00062;
        prmBC00062 = new Object[] {
        new ParDef("@ProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00066;
        prmBC00066 = new Object[] {
        new ParDef("@ProcessoNome",GXType.NVarChar,100,0) ,
        new ParDef("@ProcessoAtivo",GXType.Boolean,4,0)
        };
        Object[] prmBC00067;
        prmBC00067 = new Object[] {
        new ParDef("@ProcessoNome",GXType.NVarChar,100,0) ,
        new ParDef("@ProcessoAtivo",GXType.Boolean,4,0) ,
        new ParDef("@ProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00068;
        prmBC00068 = new Object[] {
        new ParDef("@ProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00069;
        prmBC00069 = new Object[] {
        new ParDef("@ProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000610;
        prmBC000610 = new Object[] {
        new ParDef("@ProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000611;
        prmBC000611 = new Object[] {
        new ParDef("@ProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC00062", "SELECT [ProcessoId], [ProcessoNome], [ProcessoAtivo] FROM [Processo] WITH (UPDLOCK) WHERE [ProcessoId] = @ProcessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00062,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00063", "SELECT [ProcessoId], [ProcessoNome], [ProcessoAtivo] FROM [Processo] WHERE [ProcessoId] = @ProcessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00063,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00064", "SELECT TM1.[ProcessoId], TM1.[ProcessoNome], TM1.[ProcessoAtivo] FROM [Processo] TM1 WHERE TM1.[ProcessoId] = @ProcessoId ORDER BY TM1.[ProcessoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00064,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00065", "SELECT [ProcessoId] FROM [Processo] WHERE [ProcessoId] = @ProcessoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00065,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00066", "INSERT INTO [Processo]([ProcessoNome], [ProcessoAtivo]) VALUES(@ProcessoNome, @ProcessoAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00066,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC00067", "UPDATE [Processo] SET [ProcessoNome]=@ProcessoNome, [ProcessoAtivo]=@ProcessoAtivo  WHERE [ProcessoId] = @ProcessoId", GxErrorMask.GX_NOMASK,prmBC00067)
           ,new CursorDef("BC00068", "DELETE FROM [Processo]  WHERE [ProcessoId] = @ProcessoId", GxErrorMask.GX_NOMASK,prmBC00068)
           ,new CursorDef("BC00069", "SELECT TOP 1 [DocumentoId] FROM [Documento] WHERE [DocumentoProcessoId] = @ProcessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00069,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000610", "SELECT TOP 1 [SubprocessoId] FROM [SubProcesso] WHERE [ProcessoId] = @ProcessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000610,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000611", "SELECT TM1.[ProcessoId], TM1.[ProcessoNome], TM1.[ProcessoAtivo] FROM [Processo] TM1 WHERE TM1.[ProcessoId] = @ProcessoId ORDER BY TM1.[ProcessoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000611,100, GxCacheFrequency.OFF ,true,false )
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
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
     }
  }

}

}
