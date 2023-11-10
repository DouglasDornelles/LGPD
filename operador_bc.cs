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
   public class operador_bc : GXHttpHandler, IGxSilentTrn
   {
      public operador_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public operador_bc( IGxContext context )
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
         ReadRow0E14( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0E14( ) ;
         standaloneModal( ) ;
         AddRow0E14( ) ;
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
            E110E2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z42OperadorId = A42OperadorId;
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

      protected void CONFIRM_0E0( )
      {
         BeforeValidate0E14( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0E14( ) ;
            }
            else
            {
               CheckExtendedTable0E14( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0E14( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120E2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110E2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV15IsOperador = true;
         AV16OperadorId_Out = A42OperadorId;
      }

      protected void ZM0E14( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z43OperadorNome = A43OperadorNome;
            Z44OperadorAtivo = A44OperadorAtivo;
         }
         if ( GX_JID == -6 )
         {
            Z42OperadorId = A42OperadorId;
            Z43OperadorNome = A43OperadorNome;
            Z44OperadorAtivo = A44OperadorAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A44OperadorAtivo) && ( Gx_BScreen == 0 ) )
         {
            A44OperadorAtivo = true;
         }
      }

      protected void Load0E14( )
      {
         /* Using cursor BC000E4 */
         pr_default.execute(2, new Object[] {A42OperadorId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound14 = 1;
            A43OperadorNome = BC000E4_A43OperadorNome[0];
            A44OperadorAtivo = BC000E4_A44OperadorAtivo[0];
            ZM0E14( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0E14( ) ;
      }

      protected void OnLoadActions0E14( )
      {
         A43OperadorNome = StringUtil.Upper( A43OperadorNome);
         GXt_boolean1 = AV14IsOk;
         new validanome(context ).execute(  "Operador",  A42OperadorId,  A43OperadorNome, out  GXt_boolean1) ;
         AV14IsOk = GXt_boolean1;
      }

      protected void CheckExtendedTable0E14( )
      {
         nIsDirty_14 = 0;
         standaloneModal( ) ;
         nIsDirty_14 = 1;
         A43OperadorNome = StringUtil.Upper( A43OperadorNome);
         GXt_boolean1 = AV14IsOk;
         new validanome(context ).execute(  "Operador",  A42OperadorId,  A43OperadorNome, out  GXt_boolean1) ;
         AV14IsOk = GXt_boolean1;
         if ( ! AV14IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A43OperadorNome)) )
         {
            GX_msglist.addItem("Informe o nome do Operador.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0E14( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0E14( )
      {
         /* Using cursor BC000E5 */
         pr_default.execute(3, new Object[] {A42OperadorId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound14 = 1;
         }
         else
         {
            RcdFound14 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000E3 */
         pr_default.execute(1, new Object[] {A42OperadorId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0E14( 6) ;
            RcdFound14 = 1;
            A42OperadorId = BC000E3_A42OperadorId[0];
            A43OperadorNome = BC000E3_A43OperadorNome[0];
            A44OperadorAtivo = BC000E3_A44OperadorAtivo[0];
            Z42OperadorId = A42OperadorId;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0E14( ) ;
            if ( AnyError == 1 )
            {
               RcdFound14 = 0;
               InitializeNonKey0E14( ) ;
            }
            Gx_mode = sMode14;
         }
         else
         {
            RcdFound14 = 0;
            InitializeNonKey0E14( ) ;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode14;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0E14( ) ;
         if ( RcdFound14 == 0 )
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
         CONFIRM_0E0( ) ;
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

      protected void CheckOptimisticConcurrency0E14( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000E2 */
            pr_default.execute(0, new Object[] {A42OperadorId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Operador"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z43OperadorNome, BC000E2_A43OperadorNome[0]) != 0 ) || ( Z44OperadorAtivo != BC000E2_A44OperadorAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Operador"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0E14( )
      {
         BeforeValidate0E14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E14( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0E14( 0) ;
            CheckOptimisticConcurrency0E14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0E14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000E6 */
                     pr_default.execute(4, new Object[] {A43OperadorNome, A44OperadorAtivo});
                     A42OperadorId = BC000E6_A42OperadorId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("Operador");
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
               Load0E14( ) ;
            }
            EndLevel0E14( ) ;
         }
         CloseExtendedTableCursors0E14( ) ;
      }

      protected void Update0E14( )
      {
         BeforeValidate0E14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E14( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0E14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000E7 */
                     pr_default.execute(5, new Object[] {A43OperadorNome, A44OperadorAtivo, A42OperadorId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("Operador");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Operador"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0E14( ) ;
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
            EndLevel0E14( ) ;
         }
         CloseExtendedTableCursors0E14( ) ;
      }

      protected void DeferredUpdate0E14( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0E14( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E14( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0E14( ) ;
            AfterConfirm0E14( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0E14( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000E8 */
                  pr_default.execute(6, new Object[] {A42OperadorId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("Operador");
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
         sMode14 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0E14( ) ;
         Gx_mode = sMode14;
      }

      protected void OnDeleteControls0E14( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV14IsOk;
            new validanome(context ).execute(  "Operador",  A42OperadorId,  A43OperadorNome, out  GXt_boolean1) ;
            AV14IsOk = GXt_boolean1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000E9 */
            pr_default.execute(7, new Object[] {A42OperadorId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0E14( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0E14( ) ;
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

      public void ScanKeyStart0E14( )
      {
         /* Scan By routine */
         /* Using cursor BC000E10 */
         pr_default.execute(8, new Object[] {A42OperadorId});
         RcdFound14 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound14 = 1;
            A42OperadorId = BC000E10_A42OperadorId[0];
            A43OperadorNome = BC000E10_A43OperadorNome[0];
            A44OperadorAtivo = BC000E10_A44OperadorAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0E14( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound14 = 0;
         ScanKeyLoad0E14( ) ;
      }

      protected void ScanKeyLoad0E14( )
      {
         sMode14 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound14 = 1;
            A42OperadorId = BC000E10_A42OperadorId[0];
            A43OperadorNome = BC000E10_A43OperadorNome[0];
            A44OperadorAtivo = BC000E10_A44OperadorAtivo[0];
         }
         Gx_mode = sMode14;
      }

      protected void ScanKeyEnd0E14( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0E14( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0E14( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0E14( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0E14( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0E14( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0E14( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0E14( )
      {
      }

      protected void send_integrity_lvl_hashes0E14( )
      {
      }

      protected void AddRow0E14( )
      {
         VarsToRow14( bcOperador) ;
      }

      protected void ReadRow0E14( )
      {
         RowToVars14( bcOperador, 1) ;
      }

      protected void InitializeNonKey0E14( )
      {
         A43OperadorNome = "";
         AV14IsOk = false;
         A44OperadorAtivo = true;
         Z43OperadorNome = "";
         Z44OperadorAtivo = false;
      }

      protected void InitAll0E14( )
      {
         A42OperadorId = 0;
         InitializeNonKey0E14( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A44OperadorAtivo = i44OperadorAtivo;
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

      public void VarsToRow14( SdtOperador obj14 )
      {
         obj14.gxTpr_Mode = Gx_mode;
         obj14.gxTpr_Operadornome = A43OperadorNome;
         obj14.gxTpr_Operadorativo = A44OperadorAtivo;
         obj14.gxTpr_Operadorid = A42OperadorId;
         obj14.gxTpr_Operadorid_Z = Z42OperadorId;
         obj14.gxTpr_Operadornome_Z = Z43OperadorNome;
         obj14.gxTpr_Operadorativo_Z = Z44OperadorAtivo;
         obj14.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow14( SdtOperador obj14 )
      {
         obj14.gxTpr_Operadorid = A42OperadorId;
         return  ;
      }

      public void RowToVars14( SdtOperador obj14 ,
                               int forceLoad )
      {
         Gx_mode = obj14.gxTpr_Mode;
         A43OperadorNome = obj14.gxTpr_Operadornome;
         A44OperadorAtivo = obj14.gxTpr_Operadorativo;
         A42OperadorId = obj14.gxTpr_Operadorid;
         Z42OperadorId = obj14.gxTpr_Operadorid_Z;
         Z43OperadorNome = obj14.gxTpr_Operadornome_Z;
         Z44OperadorAtivo = obj14.gxTpr_Operadorativo_Z;
         Gx_mode = obj14.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A42OperadorId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0E14( ) ;
         ScanKeyStart0E14( ) ;
         if ( RcdFound14 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z42OperadorId = A42OperadorId;
         }
         ZM0E14( -6) ;
         OnLoadActions0E14( ) ;
         AddRow0E14( ) ;
         ScanKeyEnd0E14( ) ;
         if ( RcdFound14 == 0 )
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
         RowToVars14( bcOperador, 0) ;
         ScanKeyStart0E14( ) ;
         if ( RcdFound14 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z42OperadorId = A42OperadorId;
         }
         ZM0E14( -6) ;
         OnLoadActions0E14( ) ;
         AddRow0E14( ) ;
         ScanKeyEnd0E14( ) ;
         if ( RcdFound14 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0E14( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0E14( ) ;
         }
         else
         {
            if ( RcdFound14 == 1 )
            {
               if ( A42OperadorId != Z42OperadorId )
               {
                  A42OperadorId = Z42OperadorId;
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
                  Update0E14( ) ;
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
                  if ( A42OperadorId != Z42OperadorId )
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
                        Insert0E14( ) ;
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
                        Insert0E14( ) ;
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
         RowToVars14( bcOperador, 1) ;
         SaveImpl( ) ;
         VarsToRow14( bcOperador) ;
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
         RowToVars14( bcOperador, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0E14( ) ;
         AfterTrn( ) ;
         VarsToRow14( bcOperador) ;
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
            SdtOperador auxBC = new SdtOperador(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A42OperadorId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcOperador);
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
         RowToVars14( bcOperador, 1) ;
         UpdateImpl( ) ;
         VarsToRow14( bcOperador) ;
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
         RowToVars14( bcOperador, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0E14( ) ;
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
         VarsToRow14( bcOperador) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars14( bcOperador, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0E14( ) ;
         if ( RcdFound14 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A42OperadorId != Z42OperadorId )
            {
               A42OperadorId = Z42OperadorId;
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
            if ( A42OperadorId != Z42OperadorId )
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
         context.RollbackDataStores("operador_bc",pr_default);
         VarsToRow14( bcOperador) ;
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
         Gx_mode = bcOperador.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcOperador.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcOperador )
         {
            bcOperador = (SdtOperador)(sdt);
            if ( StringUtil.StrCmp(bcOperador.gxTpr_Mode, "") == 0 )
            {
               bcOperador.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow14( bcOperador) ;
            }
            else
            {
               RowToVars14( bcOperador, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcOperador.gxTpr_Mode, "") == 0 )
            {
               bcOperador.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars14( bcOperador, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtOperador Operador_BC
      {
         get {
            return bcOperador ;
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
            return "operador_Execute" ;
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
         Z43OperadorNome = "";
         A43OperadorNome = "";
         BC000E4_A42OperadorId = new int[1] ;
         BC000E4_A43OperadorNome = new string[] {""} ;
         BC000E4_A44OperadorAtivo = new bool[] {false} ;
         BC000E5_A42OperadorId = new int[1] ;
         BC000E3_A42OperadorId = new int[1] ;
         BC000E3_A43OperadorNome = new string[] {""} ;
         BC000E3_A44OperadorAtivo = new bool[] {false} ;
         sMode14 = "";
         BC000E2_A42OperadorId = new int[1] ;
         BC000E2_A43OperadorNome = new string[] {""} ;
         BC000E2_A44OperadorAtivo = new bool[] {false} ;
         BC000E6_A42OperadorId = new int[1] ;
         BC000E9_A86DocOperadorId = new int[1] ;
         BC000E10_A42OperadorId = new int[1] ;
         BC000E10_A43OperadorNome = new string[] {""} ;
         BC000E10_A44OperadorAtivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.operador_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.operador_bc__default(),
            new Object[][] {
                new Object[] {
               BC000E2_A42OperadorId, BC000E2_A43OperadorNome, BC000E2_A44OperadorAtivo
               }
               , new Object[] {
               BC000E3_A42OperadorId, BC000E3_A43OperadorNome, BC000E3_A44OperadorAtivo
               }
               , new Object[] {
               BC000E4_A42OperadorId, BC000E4_A43OperadorNome, BC000E4_A44OperadorAtivo
               }
               , new Object[] {
               BC000E5_A42OperadorId
               }
               , new Object[] {
               BC000E6_A42OperadorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000E9_A86DocOperadorId
               }
               , new Object[] {
               BC000E10_A42OperadorId, BC000E10_A43OperadorNome, BC000E10_A44OperadorAtivo
               }
            }
         );
         Z44OperadorAtivo = true;
         A44OperadorAtivo = true;
         i44OperadorAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120E2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound14 ;
      private short nIsDirty_14 ;
      private int trnEnded ;
      private int Z42OperadorId ;
      private int A42OperadorId ;
      private int AV16OperadorId_Out ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode14 ;
      private bool returnInSub ;
      private bool AV15IsOperador ;
      private bool Z44OperadorAtivo ;
      private bool A44OperadorAtivo ;
      private bool AV14IsOk ;
      private bool GXt_boolean1 ;
      private bool i44OperadorAtivo ;
      private bool mustCommit ;
      private string Z43OperadorNome ;
      private string A43OperadorNome ;
      private IGxSession AV12WebSession ;
      private SdtOperador bcOperador ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000E4_A42OperadorId ;
      private string[] BC000E4_A43OperadorNome ;
      private bool[] BC000E4_A44OperadorAtivo ;
      private int[] BC000E5_A42OperadorId ;
      private int[] BC000E3_A42OperadorId ;
      private string[] BC000E3_A43OperadorNome ;
      private bool[] BC000E3_A44OperadorAtivo ;
      private int[] BC000E2_A42OperadorId ;
      private string[] BC000E2_A43OperadorNome ;
      private bool[] BC000E2_A44OperadorAtivo ;
      private int[] BC000E6_A42OperadorId ;
      private int[] BC000E9_A86DocOperadorId ;
      private int[] BC000E10_A42OperadorId ;
      private string[] BC000E10_A43OperadorNome ;
      private bool[] BC000E10_A44OperadorAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class operador_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class operador_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000E4;
        prmBC000E4 = new Object[] {
        new ParDef("@OperadorId",GXType.Int32,8,0)
        };
        Object[] prmBC000E5;
        prmBC000E5 = new Object[] {
        new ParDef("@OperadorId",GXType.Int32,8,0)
        };
        Object[] prmBC000E3;
        prmBC000E3 = new Object[] {
        new ParDef("@OperadorId",GXType.Int32,8,0)
        };
        Object[] prmBC000E2;
        prmBC000E2 = new Object[] {
        new ParDef("@OperadorId",GXType.Int32,8,0)
        };
        Object[] prmBC000E6;
        prmBC000E6 = new Object[] {
        new ParDef("@OperadorNome",GXType.NVarChar,100,0) ,
        new ParDef("@OperadorAtivo",GXType.Boolean,4,0)
        };
        Object[] prmBC000E7;
        prmBC000E7 = new Object[] {
        new ParDef("@OperadorNome",GXType.NVarChar,100,0) ,
        new ParDef("@OperadorAtivo",GXType.Boolean,4,0) ,
        new ParDef("@OperadorId",GXType.Int32,8,0)
        };
        Object[] prmBC000E8;
        prmBC000E8 = new Object[] {
        new ParDef("@OperadorId",GXType.Int32,8,0)
        };
        Object[] prmBC000E9;
        prmBC000E9 = new Object[] {
        new ParDef("@OperadorId",GXType.Int32,8,0)
        };
        Object[] prmBC000E10;
        prmBC000E10 = new Object[] {
        new ParDef("@OperadorId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000E2", "SELECT [OperadorId], [OperadorNome], [OperadorAtivo] FROM [Operador] WITH (UPDLOCK) WHERE [OperadorId] = @OperadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E3", "SELECT [OperadorId], [OperadorNome], [OperadorAtivo] FROM [Operador] WHERE [OperadorId] = @OperadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E4", "SELECT TM1.[OperadorId], TM1.[OperadorNome], TM1.[OperadorAtivo] FROM [Operador] TM1 WHERE TM1.[OperadorId] = @OperadorId ORDER BY TM1.[OperadorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E5", "SELECT [OperadorId] FROM [Operador] WHERE [OperadorId] = @OperadorId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E6", "INSERT INTO [Operador]([OperadorNome], [OperadorAtivo]) VALUES(@OperadorNome, @OperadorAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000E7", "UPDATE [Operador] SET [OperadorNome]=@OperadorNome, [OperadorAtivo]=@OperadorAtivo  WHERE [OperadorId] = @OperadorId", GxErrorMask.GX_NOMASK,prmBC000E7)
           ,new CursorDef("BC000E8", "DELETE FROM [Operador]  WHERE [OperadorId] = @OperadorId", GxErrorMask.GX_NOMASK,prmBC000E8)
           ,new CursorDef("BC000E9", "SELECT TOP 1 [DocOperadorId] FROM [DocOperador] WHERE [OperadorId] = @OperadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000E10", "SELECT TM1.[OperadorId], TM1.[OperadorNome], TM1.[OperadorAtivo] FROM [Operador] TM1 WHERE TM1.[OperadorId] = @OperadorId ORDER BY TM1.[OperadorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E10,100, GxCacheFrequency.OFF ,true,false )
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
