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
   public class controlador_bc : GXHttpHandler, IGxSilentTrn
   {
      public controlador_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public controlador_bc( IGxContext context )
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
         ReadRow044( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey044( ) ;
         standaloneModal( ) ;
         AddRow044( ) ;
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
            E11042 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z10ControladorId = A10ControladorId;
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

      protected void CONFIRM_040( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls044( ) ;
            }
            else
            {
               CheckExtendedTable044( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors044( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12042( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11042( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV13IsControlador = true;
         AV14ControladorId_Out = A10ControladorId;
      }

      protected void ZM044( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z11ControladorNome = A11ControladorNome;
            Z12ControladorAtivo = A12ControladorAtivo;
         }
         if ( GX_JID == -6 )
         {
            Z10ControladorId = A10ControladorId;
            Z11ControladorNome = A11ControladorNome;
            Z12ControladorAtivo = A12ControladorAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A12ControladorAtivo) && ( Gx_BScreen == 0 ) )
         {
            A12ControladorAtivo = true;
         }
      }

      protected void Load044( )
      {
         /* Using cursor BC00044 */
         pr_default.execute(2, new Object[] {A10ControladorId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound4 = 1;
            A11ControladorNome = BC00044_A11ControladorNome[0];
            A12ControladorAtivo = BC00044_A12ControladorAtivo[0];
            ZM044( -6) ;
         }
         pr_default.close(2);
         OnLoadActions044( ) ;
      }

      protected void OnLoadActions044( )
      {
         A11ControladorNome = StringUtil.Upper( A11ControladorNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "Controlador",  A10ControladorId,  A11ControladorNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
      }

      protected void CheckExtendedTable044( )
      {
         nIsDirty_4 = 0;
         standaloneModal( ) ;
         nIsDirty_4 = 1;
         A11ControladorNome = StringUtil.Upper( A11ControladorNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "Controlador",  A10ControladorId,  A11ControladorNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
         if ( ! AV15IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A11ControladorNome)) )
         {
            GX_msglist.addItem("Informe o nome do controlador.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors044( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey044( )
      {
         /* Using cursor BC00045 */
         pr_default.execute(3, new Object[] {A10ControladorId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00043 */
         pr_default.execute(1, new Object[] {A10ControladorId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM044( 6) ;
            RcdFound4 = 1;
            A10ControladorId = BC00043_A10ControladorId[0];
            A11ControladorNome = BC00043_A11ControladorNome[0];
            A12ControladorAtivo = BC00043_A12ControladorAtivo[0];
            Z10ControladorId = A10ControladorId;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load044( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey044( ) ;
            }
            Gx_mode = sMode4;
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey044( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode4;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey044( ) ;
         if ( RcdFound4 == 0 )
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
         CONFIRM_040( ) ;
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

      protected void CheckOptimisticConcurrency044( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00042 */
            pr_default.execute(0, new Object[] {A10ControladorId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Controlador"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z11ControladorNome, BC00042_A11ControladorNome[0]) != 0 ) || ( Z12ControladorAtivo != BC00042_A12ControladorAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Controlador"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM044( 0) ;
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00046 */
                     pr_default.execute(4, new Object[] {A11ControladorNome, A12ControladorAtivo});
                     A10ControladorId = BC00046_A10ControladorId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("Controlador");
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
               Load044( ) ;
            }
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void Update044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00047 */
                     pr_default.execute(5, new Object[] {A11ControladorNome, A12ControladorAtivo, A10ControladorId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("Controlador");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Controlador"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate044( ) ;
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
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void DeferredUpdate044( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls044( ) ;
            AfterConfirm044( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete044( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00048 */
                  pr_default.execute(6, new Object[] {A10ControladorId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("Controlador");
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel044( ) ;
         Gx_mode = sMode4;
      }

      protected void OnDeleteControls044( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV15IsOk;
            new validanome(context ).execute(  "Controlador",  A10ControladorId,  A11ControladorNome, out  GXt_boolean1) ;
            AV15IsOk = GXt_boolean1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC00049 */
            pr_default.execute(7, new Object[] {A10ControladorId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel044( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete044( ) ;
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

      public void ScanKeyStart044( )
      {
         /* Scan By routine */
         /* Using cursor BC000410 */
         pr_default.execute(8, new Object[] {A10ControladorId});
         RcdFound4 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound4 = 1;
            A10ControladorId = BC000410_A10ControladorId[0];
            A11ControladorNome = BC000410_A11ControladorNome[0];
            A12ControladorAtivo = BC000410_A12ControladorAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext044( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound4 = 0;
         ScanKeyLoad044( ) ;
      }

      protected void ScanKeyLoad044( )
      {
         sMode4 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound4 = 1;
            A10ControladorId = BC000410_A10ControladorId[0];
            A11ControladorNome = BC000410_A11ControladorNome[0];
            A12ControladorAtivo = BC000410_A12ControladorAtivo[0];
         }
         Gx_mode = sMode4;
      }

      protected void ScanKeyEnd044( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm044( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert044( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate044( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete044( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete044( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate044( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes044( )
      {
      }

      protected void send_integrity_lvl_hashes044( )
      {
      }

      protected void AddRow044( )
      {
         VarsToRow4( bcControlador) ;
      }

      protected void ReadRow044( )
      {
         RowToVars4( bcControlador, 1) ;
      }

      protected void InitializeNonKey044( )
      {
         A11ControladorNome = "";
         AV15IsOk = false;
         A12ControladorAtivo = true;
         Z11ControladorNome = "";
         Z12ControladorAtivo = false;
      }

      protected void InitAll044( )
      {
         A10ControladorId = 0;
         InitializeNonKey044( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A12ControladorAtivo = i12ControladorAtivo;
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

      public void VarsToRow4( SdtControlador obj4 )
      {
         obj4.gxTpr_Mode = Gx_mode;
         obj4.gxTpr_Controladornome = A11ControladorNome;
         obj4.gxTpr_Controladorativo = A12ControladorAtivo;
         obj4.gxTpr_Controladorid = A10ControladorId;
         obj4.gxTpr_Controladorid_Z = Z10ControladorId;
         obj4.gxTpr_Controladornome_Z = Z11ControladorNome;
         obj4.gxTpr_Controladorativo_Z = Z12ControladorAtivo;
         obj4.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow4( SdtControlador obj4 )
      {
         obj4.gxTpr_Controladorid = A10ControladorId;
         return  ;
      }

      public void RowToVars4( SdtControlador obj4 ,
                              int forceLoad )
      {
         Gx_mode = obj4.gxTpr_Mode;
         A11ControladorNome = obj4.gxTpr_Controladornome;
         A12ControladorAtivo = obj4.gxTpr_Controladorativo;
         A10ControladorId = obj4.gxTpr_Controladorid;
         Z10ControladorId = obj4.gxTpr_Controladorid_Z;
         Z11ControladorNome = obj4.gxTpr_Controladornome_Z;
         Z12ControladorAtivo = obj4.gxTpr_Controladorativo_Z;
         Gx_mode = obj4.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A10ControladorId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey044( ) ;
         ScanKeyStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z10ControladorId = A10ControladorId;
         }
         ZM044( -6) ;
         OnLoadActions044( ) ;
         AddRow044( ) ;
         ScanKeyEnd044( ) ;
         if ( RcdFound4 == 0 )
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
         RowToVars4( bcControlador, 0) ;
         ScanKeyStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z10ControladorId = A10ControladorId;
         }
         ZM044( -6) ;
         OnLoadActions044( ) ;
         AddRow044( ) ;
         ScanKeyEnd044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey044( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert044( ) ;
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( A10ControladorId != Z10ControladorId )
               {
                  A10ControladorId = Z10ControladorId;
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
                  Update044( ) ;
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
                  if ( A10ControladorId != Z10ControladorId )
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
                        Insert044( ) ;
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
                        Insert044( ) ;
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
         RowToVars4( bcControlador, 1) ;
         SaveImpl( ) ;
         VarsToRow4( bcControlador) ;
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
         RowToVars4( bcControlador, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert044( ) ;
         AfterTrn( ) ;
         VarsToRow4( bcControlador) ;
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
            SdtControlador auxBC = new SdtControlador(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A10ControladorId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcControlador);
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
         RowToVars4( bcControlador, 1) ;
         UpdateImpl( ) ;
         VarsToRow4( bcControlador) ;
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
         RowToVars4( bcControlador, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert044( ) ;
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
         VarsToRow4( bcControlador) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars4( bcControlador, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey044( ) ;
         if ( RcdFound4 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A10ControladorId != Z10ControladorId )
            {
               A10ControladorId = Z10ControladorId;
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
            if ( A10ControladorId != Z10ControladorId )
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
         context.RollbackDataStores("controlador_bc",pr_default);
         VarsToRow4( bcControlador) ;
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
         Gx_mode = bcControlador.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcControlador.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcControlador )
         {
            bcControlador = (SdtControlador)(sdt);
            if ( StringUtil.StrCmp(bcControlador.gxTpr_Mode, "") == 0 )
            {
               bcControlador.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow4( bcControlador) ;
            }
            else
            {
               RowToVars4( bcControlador, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcControlador.gxTpr_Mode, "") == 0 )
            {
               bcControlador.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars4( bcControlador, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtControlador Controlador_BC
      {
         get {
            return bcControlador ;
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
            return "controlador_Execute" ;
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
         Z11ControladorNome = "";
         A11ControladorNome = "";
         BC00044_A10ControladorId = new int[1] ;
         BC00044_A11ControladorNome = new string[] {""} ;
         BC00044_A12ControladorAtivo = new bool[] {false} ;
         BC00045_A10ControladorId = new int[1] ;
         BC00043_A10ControladorId = new int[1] ;
         BC00043_A11ControladorNome = new string[] {""} ;
         BC00043_A12ControladorAtivo = new bool[] {false} ;
         sMode4 = "";
         BC00042_A10ControladorId = new int[1] ;
         BC00042_A11ControladorNome = new string[] {""} ;
         BC00042_A12ControladorAtivo = new bool[] {false} ;
         BC00046_A10ControladorId = new int[1] ;
         BC00049_A75DocumentoId = new int[1] ;
         BC000410_A10ControladorId = new int[1] ;
         BC000410_A11ControladorNome = new string[] {""} ;
         BC000410_A12ControladorAtivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.controlador_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.controlador_bc__default(),
            new Object[][] {
                new Object[] {
               BC00042_A10ControladorId, BC00042_A11ControladorNome, BC00042_A12ControladorAtivo
               }
               , new Object[] {
               BC00043_A10ControladorId, BC00043_A11ControladorNome, BC00043_A12ControladorAtivo
               }
               , new Object[] {
               BC00044_A10ControladorId, BC00044_A11ControladorNome, BC00044_A12ControladorAtivo
               }
               , new Object[] {
               BC00045_A10ControladorId
               }
               , new Object[] {
               BC00046_A10ControladorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00049_A75DocumentoId
               }
               , new Object[] {
               BC000410_A10ControladorId, BC000410_A11ControladorNome, BC000410_A12ControladorAtivo
               }
            }
         );
         Z12ControladorAtivo = true;
         A12ControladorAtivo = true;
         i12ControladorAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12042 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound4 ;
      private short nIsDirty_4 ;
      private int trnEnded ;
      private int Z10ControladorId ;
      private int A10ControladorId ;
      private int AV14ControladorId_Out ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode4 ;
      private bool returnInSub ;
      private bool AV13IsControlador ;
      private bool Z12ControladorAtivo ;
      private bool A12ControladorAtivo ;
      private bool AV15IsOk ;
      private bool GXt_boolean1 ;
      private bool i12ControladorAtivo ;
      private bool mustCommit ;
      private string Z11ControladorNome ;
      private string A11ControladorNome ;
      private IGxSession AV12WebSession ;
      private SdtControlador bcControlador ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00044_A10ControladorId ;
      private string[] BC00044_A11ControladorNome ;
      private bool[] BC00044_A12ControladorAtivo ;
      private int[] BC00045_A10ControladorId ;
      private int[] BC00043_A10ControladorId ;
      private string[] BC00043_A11ControladorNome ;
      private bool[] BC00043_A12ControladorAtivo ;
      private int[] BC00042_A10ControladorId ;
      private string[] BC00042_A11ControladorNome ;
      private bool[] BC00042_A12ControladorAtivo ;
      private int[] BC00046_A10ControladorId ;
      private int[] BC00049_A75DocumentoId ;
      private int[] BC000410_A10ControladorId ;
      private string[] BC000410_A11ControladorNome ;
      private bool[] BC000410_A12ControladorAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class controlador_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class controlador_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC00044;
        prmBC00044 = new Object[] {
        new ParDef("@ControladorId",GXType.Int32,8,0)
        };
        Object[] prmBC00045;
        prmBC00045 = new Object[] {
        new ParDef("@ControladorId",GXType.Int32,8,0)
        };
        Object[] prmBC00043;
        prmBC00043 = new Object[] {
        new ParDef("@ControladorId",GXType.Int32,8,0)
        };
        Object[] prmBC00042;
        prmBC00042 = new Object[] {
        new ParDef("@ControladorId",GXType.Int32,8,0)
        };
        Object[] prmBC00046;
        prmBC00046 = new Object[] {
        new ParDef("@ControladorNome",GXType.NVarChar,100,0) ,
        new ParDef("@ControladorAtivo",GXType.Boolean,4,0)
        };
        Object[] prmBC00047;
        prmBC00047 = new Object[] {
        new ParDef("@ControladorNome",GXType.NVarChar,100,0) ,
        new ParDef("@ControladorAtivo",GXType.Boolean,4,0) ,
        new ParDef("@ControladorId",GXType.Int32,8,0)
        };
        Object[] prmBC00048;
        prmBC00048 = new Object[] {
        new ParDef("@ControladorId",GXType.Int32,8,0)
        };
        Object[] prmBC00049;
        prmBC00049 = new Object[] {
        new ParDef("@ControladorId",GXType.Int32,8,0)
        };
        Object[] prmBC000410;
        prmBC000410 = new Object[] {
        new ParDef("@ControladorId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00042", "SELECT [ControladorId], [ControladorNome], [ControladorAtivo] FROM [Controlador] WITH (UPDLOCK) WHERE [ControladorId] = @ControladorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00042,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00043", "SELECT [ControladorId], [ControladorNome], [ControladorAtivo] FROM [Controlador] WHERE [ControladorId] = @ControladorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00043,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00044", "SELECT TM1.[ControladorId], TM1.[ControladorNome], TM1.[ControladorAtivo] FROM [Controlador] TM1 WHERE TM1.[ControladorId] = @ControladorId ORDER BY TM1.[ControladorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00044,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00045", "SELECT [ControladorId] FROM [Controlador] WHERE [ControladorId] = @ControladorId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00045,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00046", "INSERT INTO [Controlador]([ControladorNome], [ControladorAtivo]) VALUES(@ControladorNome, @ControladorAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00046,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC00047", "UPDATE [Controlador] SET [ControladorNome]=@ControladorNome, [ControladorAtivo]=@ControladorAtivo  WHERE [ControladorId] = @ControladorId", GxErrorMask.GX_NOMASK,prmBC00047)
           ,new CursorDef("BC00048", "DELETE FROM [Controlador]  WHERE [ControladorId] = @ControladorId", GxErrorMask.GX_NOMASK,prmBC00048)
           ,new CursorDef("BC00049", "SELECT TOP 1 [DocumentoId] FROM [Documento] WHERE [DocumentoControladorId] = @ControladorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00049,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000410", "SELECT TM1.[ControladorId], TM1.[ControladorNome], TM1.[ControladorAtivo] FROM [Controlador] TM1 WHERE TM1.[ControladorId] = @ControladorId ORDER BY TM1.[ControladorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000410,100, GxCacheFrequency.OFF ,true,false )
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
