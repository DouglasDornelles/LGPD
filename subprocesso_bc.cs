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
   public class subprocesso_bc : GXHttpHandler, IGxSilentTrn
   {
      public subprocesso_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public subprocesso_bc( IGxContext context )
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
         ReadRow077( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey077( ) ;
         standaloneModal( ) ;
         AddRow077( ) ;
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
            E11072 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z20SubprocessoId = A20SubprocessoId;
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

      protected void CONFIRM_070( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls077( ) ;
            }
            else
            {
               CheckExtendedTable077( ) ;
               if ( AnyError == 0 )
               {
                  ZM077( 9) ;
               }
               CloseExtendedTableCursors077( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12072( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV33Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV34GXV1 = 1;
            while ( AV34GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV34GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "ProcessoId") == 0 )
               {
                  AV13Insert_ProcessoId = (int)(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               AV34GXV1 = (int)(AV34GXV1+1);
            }
         }
      }

      protected void E11072( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV27IsSubProcesso = true;
         AV28SubProcessoId_Out = A20SubprocessoId;
      }

      protected void ZM077( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z21SubprocessoNome = A21SubprocessoNome;
            Z23SubprocessoAtivo = A23SubprocessoAtivo;
            Z16ProcessoId = A16ProcessoId;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z17ProcessoNome = A17ProcessoNome;
         }
         if ( GX_JID == -8 )
         {
            Z20SubprocessoId = A20SubprocessoId;
            Z21SubprocessoNome = A21SubprocessoNome;
            Z23SubprocessoAtivo = A23SubprocessoAtivo;
            Z16ProcessoId = A16ProcessoId;
            Z17ProcessoNome = A17ProcessoNome;
         }
      }

      protected void standaloneNotModal( )
      {
         AV33Pgmname = "SubProcesso_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A23SubprocessoAtivo) && ( Gx_BScreen == 0 ) )
         {
            A23SubprocessoAtivo = true;
         }
      }

      protected void Load077( )
      {
         /* Using cursor BC00075 */
         pr_default.execute(3, new Object[] {n20SubprocessoId, A20SubprocessoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound7 = 1;
            A21SubprocessoNome = BC00075_A21SubprocessoNome[0];
            A17ProcessoNome = BC00075_A17ProcessoNome[0];
            A23SubprocessoAtivo = BC00075_A23SubprocessoAtivo[0];
            A16ProcessoId = BC00075_A16ProcessoId[0];
            n16ProcessoId = BC00075_n16ProcessoId[0];
            ZM077( -8) ;
         }
         pr_default.close(3);
         OnLoadActions077( ) ;
      }

      protected void OnLoadActions077( )
      {
         A21SubprocessoNome = StringUtil.Upper( A21SubprocessoNome);
         GXt_boolean1 = AV31IsOk;
         new validanome(context ).execute(  "SubProcesso",  A20SubprocessoId,  A21SubprocessoNome, out  GXt_boolean1) ;
         AV31IsOk = GXt_boolean1;
      }

      protected void CheckExtendedTable077( )
      {
         nIsDirty_7 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00074 */
         pr_default.execute(2, new Object[] {n16ProcessoId, A16ProcessoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A16ProcessoId) ) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "PROCESSOID");
               AnyError = 1;
            }
         }
         A17ProcessoNome = BC00074_A17ProcessoNome[0];
         pr_default.close(2);
         nIsDirty_7 = 1;
         A21SubprocessoNome = StringUtil.Upper( A21SubprocessoNome);
         GXt_boolean1 = AV31IsOk;
         new validanome(context ).execute(  "SubProcesso",  A20SubprocessoId,  A21SubprocessoNome, out  GXt_boolean1) ;
         AV31IsOk = GXt_boolean1;
         if ( ! AV31IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A21SubprocessoNome)) )
         {
            GX_msglist.addItem("Informe o nome do subprocesso.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors077( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey077( )
      {
         /* Using cursor BC00076 */
         pr_default.execute(4, new Object[] {n20SubprocessoId, A20SubprocessoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00073 */
         pr_default.execute(1, new Object[] {n20SubprocessoId, A20SubprocessoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM077( 8) ;
            RcdFound7 = 1;
            A20SubprocessoId = BC00073_A20SubprocessoId[0];
            n20SubprocessoId = BC00073_n20SubprocessoId[0];
            A21SubprocessoNome = BC00073_A21SubprocessoNome[0];
            A23SubprocessoAtivo = BC00073_A23SubprocessoAtivo[0];
            A16ProcessoId = BC00073_A16ProcessoId[0];
            n16ProcessoId = BC00073_n16ProcessoId[0];
            Z20SubprocessoId = A20SubprocessoId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load077( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey077( ) ;
            }
            Gx_mode = sMode7;
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey077( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode7;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey077( ) ;
         if ( RcdFound7 == 0 )
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
         CONFIRM_070( ) ;
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

      protected void CheckOptimisticConcurrency077( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00072 */
            pr_default.execute(0, new Object[] {n20SubprocessoId, A20SubprocessoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SubProcesso"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z21SubprocessoNome, BC00072_A21SubprocessoNome[0]) != 0 ) || ( Z23SubprocessoAtivo != BC00072_A23SubprocessoAtivo[0] ) || ( Z16ProcessoId != BC00072_A16ProcessoId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SubProcesso"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert077( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM077( 0) ;
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00077 */
                     pr_default.execute(5, new Object[] {A21SubprocessoNome, A23SubprocessoAtivo, n16ProcessoId, A16ProcessoId});
                     A20SubprocessoId = BC00077_A20SubprocessoId[0];
                     n20SubprocessoId = BC00077_n20SubprocessoId[0];
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("SubProcesso");
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
               Load077( ) ;
            }
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void Update077( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00078 */
                     pr_default.execute(6, new Object[] {A21SubprocessoNome, A23SubprocessoAtivo, n16ProcessoId, A16ProcessoId, n20SubprocessoId, A20SubprocessoId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("SubProcesso");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SubProcesso"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate077( ) ;
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
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void DeferredUpdate077( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls077( ) ;
            AfterConfirm077( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete077( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00079 */
                  pr_default.execute(7, new Object[] {n20SubprocessoId, A20SubprocessoId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("SubProcesso");
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
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel077( ) ;
         Gx_mode = sMode7;
      }

      protected void OnDeleteControls077( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000710 */
            pr_default.execute(8, new Object[] {n16ProcessoId, A16ProcessoId});
            A17ProcessoNome = BC000710_A17ProcessoNome[0];
            pr_default.close(8);
            GXt_boolean1 = AV31IsOk;
            new validanome(context ).execute(  "SubProcesso",  A20SubprocessoId,  A21SubprocessoNome, out  GXt_boolean1) ;
            AV31IsOk = GXt_boolean1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000711 */
            pr_default.execute(9, new Object[] {n20SubprocessoId, A20SubprocessoId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel077( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete077( ) ;
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

      public void ScanKeyStart077( )
      {
         /* Scan By routine */
         /* Using cursor BC000712 */
         pr_default.execute(10, new Object[] {n20SubprocessoId, A20SubprocessoId});
         RcdFound7 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound7 = 1;
            A20SubprocessoId = BC000712_A20SubprocessoId[0];
            n20SubprocessoId = BC000712_n20SubprocessoId[0];
            A21SubprocessoNome = BC000712_A21SubprocessoNome[0];
            A17ProcessoNome = BC000712_A17ProcessoNome[0];
            A23SubprocessoAtivo = BC000712_A23SubprocessoAtivo[0];
            A16ProcessoId = BC000712_A16ProcessoId[0];
            n16ProcessoId = BC000712_n16ProcessoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext077( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound7 = 0;
         ScanKeyLoad077( ) ;
      }

      protected void ScanKeyLoad077( )
      {
         sMode7 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound7 = 1;
            A20SubprocessoId = BC000712_A20SubprocessoId[0];
            n20SubprocessoId = BC000712_n20SubprocessoId[0];
            A21SubprocessoNome = BC000712_A21SubprocessoNome[0];
            A17ProcessoNome = BC000712_A17ProcessoNome[0];
            A23SubprocessoAtivo = BC000712_A23SubprocessoAtivo[0];
            A16ProcessoId = BC000712_A16ProcessoId[0];
            n16ProcessoId = BC000712_n16ProcessoId[0];
         }
         Gx_mode = sMode7;
      }

      protected void ScanKeyEnd077( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm077( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert077( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate077( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete077( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete077( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate077( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes077( )
      {
      }

      protected void send_integrity_lvl_hashes077( )
      {
      }

      protected void AddRow077( )
      {
         VarsToRow7( bcSubProcesso) ;
      }

      protected void ReadRow077( )
      {
         RowToVars7( bcSubProcesso, 1) ;
      }

      protected void InitializeNonKey077( )
      {
         A21SubprocessoNome = "";
         AV31IsOk = false;
         A16ProcessoId = 0;
         n16ProcessoId = false;
         A17ProcessoNome = "";
         A23SubprocessoAtivo = true;
         Z21SubprocessoNome = "";
         Z23SubprocessoAtivo = false;
         Z16ProcessoId = 0;
      }

      protected void InitAll077( )
      {
         A20SubprocessoId = 0;
         n20SubprocessoId = false;
         InitializeNonKey077( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A23SubprocessoAtivo = i23SubprocessoAtivo;
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

      public void VarsToRow7( SdtSubProcesso obj7 )
      {
         obj7.gxTpr_Mode = Gx_mode;
         obj7.gxTpr_Subprocessonome = A21SubprocessoNome;
         obj7.gxTpr_Processoid = A16ProcessoId;
         obj7.gxTpr_Processonome = A17ProcessoNome;
         obj7.gxTpr_Subprocessoativo = A23SubprocessoAtivo;
         obj7.gxTpr_Subprocessoid = A20SubprocessoId;
         obj7.gxTpr_Subprocessoid_Z = Z20SubprocessoId;
         obj7.gxTpr_Processoid_Z = Z16ProcessoId;
         obj7.gxTpr_Processonome_Z = Z17ProcessoNome;
         obj7.gxTpr_Subprocessonome_Z = Z21SubprocessoNome;
         obj7.gxTpr_Subprocessoativo_Z = Z23SubprocessoAtivo;
         obj7.gxTpr_Subprocessoid_N = (short)(Convert.ToInt16(n20SubprocessoId));
         obj7.gxTpr_Processoid_N = (short)(Convert.ToInt16(n16ProcessoId));
         obj7.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow7( SdtSubProcesso obj7 )
      {
         obj7.gxTpr_Subprocessoid = A20SubprocessoId;
         return  ;
      }

      public void RowToVars7( SdtSubProcesso obj7 ,
                              int forceLoad )
      {
         Gx_mode = obj7.gxTpr_Mode;
         A21SubprocessoNome = obj7.gxTpr_Subprocessonome;
         A16ProcessoId = obj7.gxTpr_Processoid;
         n16ProcessoId = false;
         A17ProcessoNome = obj7.gxTpr_Processonome;
         A23SubprocessoAtivo = obj7.gxTpr_Subprocessoativo;
         A20SubprocessoId = obj7.gxTpr_Subprocessoid;
         n20SubprocessoId = false;
         Z20SubprocessoId = obj7.gxTpr_Subprocessoid_Z;
         Z16ProcessoId = obj7.gxTpr_Processoid_Z;
         Z17ProcessoNome = obj7.gxTpr_Processonome_Z;
         Z21SubprocessoNome = obj7.gxTpr_Subprocessonome_Z;
         Z23SubprocessoAtivo = obj7.gxTpr_Subprocessoativo_Z;
         n20SubprocessoId = (bool)(Convert.ToBoolean(obj7.gxTpr_Subprocessoid_N));
         n16ProcessoId = (bool)(Convert.ToBoolean(obj7.gxTpr_Processoid_N));
         Gx_mode = obj7.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A20SubprocessoId = (int)getParm(obj,0);
         n20SubprocessoId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey077( ) ;
         ScanKeyStart077( ) ;
         if ( RcdFound7 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z20SubprocessoId = A20SubprocessoId;
         }
         ZM077( -8) ;
         OnLoadActions077( ) ;
         AddRow077( ) ;
         ScanKeyEnd077( ) ;
         if ( RcdFound7 == 0 )
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
         RowToVars7( bcSubProcesso, 0) ;
         ScanKeyStart077( ) ;
         if ( RcdFound7 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z20SubprocessoId = A20SubprocessoId;
         }
         ZM077( -8) ;
         OnLoadActions077( ) ;
         AddRow077( ) ;
         ScanKeyEnd077( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey077( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert077( ) ;
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( A20SubprocessoId != Z20SubprocessoId )
               {
                  A20SubprocessoId = Z20SubprocessoId;
                  n20SubprocessoId = false;
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
                  Update077( ) ;
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
                  if ( A20SubprocessoId != Z20SubprocessoId )
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
                        Insert077( ) ;
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
                        Insert077( ) ;
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
         RowToVars7( bcSubProcesso, 1) ;
         SaveImpl( ) ;
         VarsToRow7( bcSubProcesso) ;
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
         RowToVars7( bcSubProcesso, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert077( ) ;
         AfterTrn( ) ;
         VarsToRow7( bcSubProcesso) ;
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
            SdtSubProcesso auxBC = new SdtSubProcesso(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A20SubprocessoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcSubProcesso);
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
         RowToVars7( bcSubProcesso, 1) ;
         UpdateImpl( ) ;
         VarsToRow7( bcSubProcesso) ;
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
         RowToVars7( bcSubProcesso, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert077( ) ;
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
         VarsToRow7( bcSubProcesso) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars7( bcSubProcesso, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey077( ) ;
         if ( RcdFound7 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A20SubprocessoId != Z20SubprocessoId )
            {
               A20SubprocessoId = Z20SubprocessoId;
               n20SubprocessoId = false;
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
            if ( A20SubprocessoId != Z20SubprocessoId )
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
         pr_default.close(8);
         context.RollbackDataStores("subprocesso_bc",pr_default);
         VarsToRow7( bcSubProcesso) ;
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
         Gx_mode = bcSubProcesso.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcSubProcesso.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcSubProcesso )
         {
            bcSubProcesso = (SdtSubProcesso)(sdt);
            if ( StringUtil.StrCmp(bcSubProcesso.gxTpr_Mode, "") == 0 )
            {
               bcSubProcesso.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow7( bcSubProcesso) ;
            }
            else
            {
               RowToVars7( bcSubProcesso, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcSubProcesso.gxTpr_Mode, "") == 0 )
            {
               bcSubProcesso.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars7( bcSubProcesso, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtSubProcesso SubProcesso_BC
      {
         get {
            return bcSubProcesso ;
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
            return "subprocesso_Execute" ;
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
         pr_default.close(8);
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
         AV33Pgmname = "";
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z21SubprocessoNome = "";
         A21SubprocessoNome = "";
         Z17ProcessoNome = "";
         A17ProcessoNome = "";
         BC00075_A20SubprocessoId = new int[1] ;
         BC00075_n20SubprocessoId = new bool[] {false} ;
         BC00075_A21SubprocessoNome = new string[] {""} ;
         BC00075_A17ProcessoNome = new string[] {""} ;
         BC00075_A23SubprocessoAtivo = new bool[] {false} ;
         BC00075_A16ProcessoId = new int[1] ;
         BC00075_n16ProcessoId = new bool[] {false} ;
         BC00074_A17ProcessoNome = new string[] {""} ;
         BC00076_A20SubprocessoId = new int[1] ;
         BC00076_n20SubprocessoId = new bool[] {false} ;
         BC00073_A20SubprocessoId = new int[1] ;
         BC00073_n20SubprocessoId = new bool[] {false} ;
         BC00073_A21SubprocessoNome = new string[] {""} ;
         BC00073_A23SubprocessoAtivo = new bool[] {false} ;
         BC00073_A16ProcessoId = new int[1] ;
         BC00073_n16ProcessoId = new bool[] {false} ;
         sMode7 = "";
         BC00072_A20SubprocessoId = new int[1] ;
         BC00072_n20SubprocessoId = new bool[] {false} ;
         BC00072_A21SubprocessoNome = new string[] {""} ;
         BC00072_A23SubprocessoAtivo = new bool[] {false} ;
         BC00072_A16ProcessoId = new int[1] ;
         BC00072_n16ProcessoId = new bool[] {false} ;
         BC00077_A20SubprocessoId = new int[1] ;
         BC00077_n20SubprocessoId = new bool[] {false} ;
         BC000710_A17ProcessoNome = new string[] {""} ;
         BC000711_A75DocumentoId = new int[1] ;
         BC000712_A20SubprocessoId = new int[1] ;
         BC000712_n20SubprocessoId = new bool[] {false} ;
         BC000712_A21SubprocessoNome = new string[] {""} ;
         BC000712_A17ProcessoNome = new string[] {""} ;
         BC000712_A23SubprocessoAtivo = new bool[] {false} ;
         BC000712_A16ProcessoId = new int[1] ;
         BC000712_n16ProcessoId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.subprocesso_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.subprocesso_bc__default(),
            new Object[][] {
                new Object[] {
               BC00072_A20SubprocessoId, BC00072_A21SubprocessoNome, BC00072_A23SubprocessoAtivo, BC00072_A16ProcessoId, BC00072_n16ProcessoId
               }
               , new Object[] {
               BC00073_A20SubprocessoId, BC00073_A21SubprocessoNome, BC00073_A23SubprocessoAtivo, BC00073_A16ProcessoId, BC00073_n16ProcessoId
               }
               , new Object[] {
               BC00074_A17ProcessoNome
               }
               , new Object[] {
               BC00075_A20SubprocessoId, BC00075_A21SubprocessoNome, BC00075_A17ProcessoNome, BC00075_A23SubprocessoAtivo, BC00075_A16ProcessoId, BC00075_n16ProcessoId
               }
               , new Object[] {
               BC00076_A20SubprocessoId
               }
               , new Object[] {
               BC00077_A20SubprocessoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000710_A17ProcessoNome
               }
               , new Object[] {
               BC000711_A75DocumentoId
               }
               , new Object[] {
               BC000712_A20SubprocessoId, BC000712_A21SubprocessoNome, BC000712_A17ProcessoNome, BC000712_A23SubprocessoAtivo, BC000712_A16ProcessoId, BC000712_n16ProcessoId
               }
            }
         );
         AV33Pgmname = "SubProcesso_BC";
         Z23SubprocessoAtivo = true;
         A23SubprocessoAtivo = true;
         i23SubprocessoAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12072 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound7 ;
      private short nIsDirty_7 ;
      private int trnEnded ;
      private int Z20SubprocessoId ;
      private int A20SubprocessoId ;
      private int AV34GXV1 ;
      private int AV13Insert_ProcessoId ;
      private int AV28SubProcessoId_Out ;
      private int Z16ProcessoId ;
      private int A16ProcessoId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV33Pgmname ;
      private string sMode7 ;
      private bool returnInSub ;
      private bool AV27IsSubProcesso ;
      private bool Z23SubprocessoAtivo ;
      private bool A23SubprocessoAtivo ;
      private bool n20SubprocessoId ;
      private bool n16ProcessoId ;
      private bool AV31IsOk ;
      private bool GXt_boolean1 ;
      private bool i23SubprocessoAtivo ;
      private bool mustCommit ;
      private string Z21SubprocessoNome ;
      private string A21SubprocessoNome ;
      private string Z17ProcessoNome ;
      private string A17ProcessoNome ;
      private IGxSession AV12WebSession ;
      private SdtSubProcesso bcSubProcesso ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00075_A20SubprocessoId ;
      private bool[] BC00075_n20SubprocessoId ;
      private string[] BC00075_A21SubprocessoNome ;
      private string[] BC00075_A17ProcessoNome ;
      private bool[] BC00075_A23SubprocessoAtivo ;
      private int[] BC00075_A16ProcessoId ;
      private bool[] BC00075_n16ProcessoId ;
      private string[] BC00074_A17ProcessoNome ;
      private int[] BC00076_A20SubprocessoId ;
      private bool[] BC00076_n20SubprocessoId ;
      private int[] BC00073_A20SubprocessoId ;
      private bool[] BC00073_n20SubprocessoId ;
      private string[] BC00073_A21SubprocessoNome ;
      private bool[] BC00073_A23SubprocessoAtivo ;
      private int[] BC00073_A16ProcessoId ;
      private bool[] BC00073_n16ProcessoId ;
      private int[] BC00072_A20SubprocessoId ;
      private bool[] BC00072_n20SubprocessoId ;
      private string[] BC00072_A21SubprocessoNome ;
      private bool[] BC00072_A23SubprocessoAtivo ;
      private int[] BC00072_A16ProcessoId ;
      private bool[] BC00072_n16ProcessoId ;
      private int[] BC00077_A20SubprocessoId ;
      private bool[] BC00077_n20SubprocessoId ;
      private string[] BC000710_A17ProcessoNome ;
      private int[] BC000711_A75DocumentoId ;
      private int[] BC000712_A20SubprocessoId ;
      private bool[] BC000712_n20SubprocessoId ;
      private string[] BC000712_A21SubprocessoNome ;
      private string[] BC000712_A17ProcessoNome ;
      private bool[] BC000712_A23SubprocessoAtivo ;
      private int[] BC000712_A16ProcessoId ;
      private bool[] BC000712_n16ProcessoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
   }

   public class subprocesso_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class subprocesso_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00075;
        prmBC00075 = new Object[] {
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00074;
        prmBC00074 = new Object[] {
        new ParDef("@ProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00076;
        prmBC00076 = new Object[] {
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00073;
        prmBC00073 = new Object[] {
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00072;
        prmBC00072 = new Object[] {
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00077;
        prmBC00077 = new Object[] {
        new ParDef("@SubprocessoNome",GXType.NVarChar,100,0) ,
        new ParDef("@SubprocessoAtivo",GXType.Boolean,4,0) ,
        new ParDef("@ProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00078;
        prmBC00078 = new Object[] {
        new ParDef("@SubprocessoNome",GXType.NVarChar,100,0) ,
        new ParDef("@SubprocessoAtivo",GXType.Boolean,4,0) ,
        new ParDef("@ProcessoId",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00079;
        prmBC00079 = new Object[] {
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000710;
        prmBC000710 = new Object[] {
        new ParDef("@ProcessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000711;
        prmBC000711 = new Object[] {
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000712;
        prmBC000712 = new Object[] {
        new ParDef("@SubprocessoId",GXType.Int32,8,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC00072", "SELECT [SubprocessoId], [SubprocessoNome], [SubprocessoAtivo], [ProcessoId] FROM [SubProcesso] WITH (UPDLOCK) WHERE [SubprocessoId] = @SubprocessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00072,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00073", "SELECT [SubprocessoId], [SubprocessoNome], [SubprocessoAtivo], [ProcessoId] FROM [SubProcesso] WHERE [SubprocessoId] = @SubprocessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00073,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00074", "SELECT [ProcessoNome] FROM [Processo] WHERE [ProcessoId] = @ProcessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00074,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00075", "SELECT TM1.[SubprocessoId], TM1.[SubprocessoNome], T2.[ProcessoNome], TM1.[SubprocessoAtivo], TM1.[ProcessoId] FROM ([SubProcesso] TM1 LEFT JOIN [Processo] T2 ON T2.[ProcessoId] = TM1.[ProcessoId]) WHERE TM1.[SubprocessoId] = @SubprocessoId ORDER BY TM1.[SubprocessoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00075,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00076", "SELECT [SubprocessoId] FROM [SubProcesso] WHERE [SubprocessoId] = @SubprocessoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00076,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00077", "INSERT INTO [SubProcesso]([SubprocessoNome], [SubprocessoAtivo], [ProcessoId]) VALUES(@SubprocessoNome, @SubprocessoAtivo, @ProcessoId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00077,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC00078", "UPDATE [SubProcesso] SET [SubprocessoNome]=@SubprocessoNome, [SubprocessoAtivo]=@SubprocessoAtivo, [ProcessoId]=@ProcessoId  WHERE [SubprocessoId] = @SubprocessoId", GxErrorMask.GX_NOMASK,prmBC00078)
           ,new CursorDef("BC00079", "DELETE FROM [SubProcesso]  WHERE [SubprocessoId] = @SubprocessoId", GxErrorMask.GX_NOMASK,prmBC00079)
           ,new CursorDef("BC000710", "SELECT [ProcessoNome] FROM [Processo] WHERE [ProcessoId] = @ProcessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000710,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000711", "SELECT TOP 1 [DocumentoId] FROM [Documento] WHERE [SubprocessoId] = @SubprocessoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000711,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000712", "SELECT TM1.[SubprocessoId], TM1.[SubprocessoNome], T2.[ProcessoNome], TM1.[SubprocessoAtivo], TM1.[ProcessoId] FROM ([SubProcesso] TM1 LEFT JOIN [Processo] T2 ON T2.[ProcessoId] = TM1.[ProcessoId]) WHERE TM1.[SubprocessoId] = @SubprocessoId ORDER BY TM1.[SubprocessoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000712,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
     }
  }

}

}
