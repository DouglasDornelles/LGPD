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
   public class envolvidoscoleta_bc : GXHttpHandler, IGxSilentTrn
   {
      public envolvidoscoleta_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public envolvidoscoleta_bc( IGxContext context )
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
         ReadRow0I18( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0I18( ) ;
         standaloneModal( ) ;
         AddRow0I18( ) ;
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
            E110I2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z54EnvolvidosColetaId = A54EnvolvidosColetaId;
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

      protected void CONFIRM_0I0( )
      {
         BeforeValidate0I18( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0I18( ) ;
            }
            else
            {
               CheckExtendedTable0I18( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0I18( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120I2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110I2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV14IsEnvolvidosColeta = true;
         AV16EnvolvidosColetaId_Out = A54EnvolvidosColetaId;
      }

      protected void ZM0I18( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z55EnvolvidosColetaNome = A55EnvolvidosColetaNome;
            Z56EnvolvidosColetaAtivo = A56EnvolvidosColetaAtivo;
         }
         if ( GX_JID == -6 )
         {
            Z54EnvolvidosColetaId = A54EnvolvidosColetaId;
            Z55EnvolvidosColetaNome = A55EnvolvidosColetaNome;
            Z56EnvolvidosColetaAtivo = A56EnvolvidosColetaAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A56EnvolvidosColetaAtivo) && ( Gx_BScreen == 0 ) )
         {
            A56EnvolvidosColetaAtivo = true;
         }
      }

      protected void Load0I18( )
      {
         /* Using cursor BC000I4 */
         pr_default.execute(2, new Object[] {A54EnvolvidosColetaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound18 = 1;
            A55EnvolvidosColetaNome = BC000I4_A55EnvolvidosColetaNome[0];
            A56EnvolvidosColetaAtivo = BC000I4_A56EnvolvidosColetaAtivo[0];
            ZM0I18( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0I18( ) ;
      }

      protected void OnLoadActions0I18( )
      {
         A55EnvolvidosColetaNome = StringUtil.Upper( A55EnvolvidosColetaNome);
         GXt_boolean1 = AV17IsOk;
         new validanome(context ).execute(  "EnvolvidosColeta",  A54EnvolvidosColetaId,  A55EnvolvidosColetaNome, out  GXt_boolean1) ;
         AV17IsOk = GXt_boolean1;
      }

      protected void CheckExtendedTable0I18( )
      {
         nIsDirty_18 = 0;
         standaloneModal( ) ;
         nIsDirty_18 = 1;
         A55EnvolvidosColetaNome = StringUtil.Upper( A55EnvolvidosColetaNome);
         GXt_boolean1 = AV17IsOk;
         new validanome(context ).execute(  "EnvolvidosColeta",  A54EnvolvidosColetaId,  A55EnvolvidosColetaNome, out  GXt_boolean1) ;
         AV17IsOk = GXt_boolean1;
         if ( ! AV17IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A55EnvolvidosColetaNome)) )
         {
            GX_msglist.addItem("Informe o Nome do Envolvidos Coleta.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0I18( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0I18( )
      {
         /* Using cursor BC000I5 */
         pr_default.execute(3, new Object[] {A54EnvolvidosColetaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound18 = 1;
         }
         else
         {
            RcdFound18 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000I3 */
         pr_default.execute(1, new Object[] {A54EnvolvidosColetaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0I18( 6) ;
            RcdFound18 = 1;
            A54EnvolvidosColetaId = BC000I3_A54EnvolvidosColetaId[0];
            A55EnvolvidosColetaNome = BC000I3_A55EnvolvidosColetaNome[0];
            A56EnvolvidosColetaAtivo = BC000I3_A56EnvolvidosColetaAtivo[0];
            Z54EnvolvidosColetaId = A54EnvolvidosColetaId;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0I18( ) ;
            if ( AnyError == 1 )
            {
               RcdFound18 = 0;
               InitializeNonKey0I18( ) ;
            }
            Gx_mode = sMode18;
         }
         else
         {
            RcdFound18 = 0;
            InitializeNonKey0I18( ) ;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode18;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0I18( ) ;
         if ( RcdFound18 == 0 )
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
         CONFIRM_0I0( ) ;
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

      protected void CheckOptimisticConcurrency0I18( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000I2 */
            pr_default.execute(0, new Object[] {A54EnvolvidosColetaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EnvolvidosColeta"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z55EnvolvidosColetaNome, BC000I2_A55EnvolvidosColetaNome[0]) != 0 ) || ( Z56EnvolvidosColetaAtivo != BC000I2_A56EnvolvidosColetaAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"EnvolvidosColeta"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0I18( )
      {
         BeforeValidate0I18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I18( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0I18( 0) ;
            CheckOptimisticConcurrency0I18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0I18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000I6 */
                     pr_default.execute(4, new Object[] {A55EnvolvidosColetaNome, A56EnvolvidosColetaAtivo});
                     A54EnvolvidosColetaId = BC000I6_A54EnvolvidosColetaId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("EnvolvidosColeta");
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
               Load0I18( ) ;
            }
            EndLevel0I18( ) ;
         }
         CloseExtendedTableCursors0I18( ) ;
      }

      protected void Update0I18( )
      {
         BeforeValidate0I18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I18( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0I18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000I7 */
                     pr_default.execute(5, new Object[] {A55EnvolvidosColetaNome, A56EnvolvidosColetaAtivo, A54EnvolvidosColetaId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("EnvolvidosColeta");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EnvolvidosColeta"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0I18( ) ;
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
            EndLevel0I18( ) ;
         }
         CloseExtendedTableCursors0I18( ) ;
      }

      protected void DeferredUpdate0I18( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0I18( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I18( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0I18( ) ;
            AfterConfirm0I18( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0I18( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000I8 */
                  pr_default.execute(6, new Object[] {A54EnvolvidosColetaId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("EnvolvidosColeta");
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
         sMode18 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0I18( ) ;
         Gx_mode = sMode18;
      }

      protected void OnDeleteControls0I18( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV17IsOk;
            new validanome(context ).execute(  "EnvolvidosColeta",  A54EnvolvidosColetaId,  A55EnvolvidosColetaNome, out  GXt_boolean1) ;
            AV17IsOk = GXt_boolean1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000I9 */
            pr_default.execute(7, new Object[] {A54EnvolvidosColetaId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Doc Envolvidos Coleta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0I18( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0I18( ) ;
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

      public void ScanKeyStart0I18( )
      {
         /* Scan By routine */
         /* Using cursor BC000I10 */
         pr_default.execute(8, new Object[] {A54EnvolvidosColetaId});
         RcdFound18 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound18 = 1;
            A54EnvolvidosColetaId = BC000I10_A54EnvolvidosColetaId[0];
            A55EnvolvidosColetaNome = BC000I10_A55EnvolvidosColetaNome[0];
            A56EnvolvidosColetaAtivo = BC000I10_A56EnvolvidosColetaAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0I18( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound18 = 0;
         ScanKeyLoad0I18( ) ;
      }

      protected void ScanKeyLoad0I18( )
      {
         sMode18 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound18 = 1;
            A54EnvolvidosColetaId = BC000I10_A54EnvolvidosColetaId[0];
            A55EnvolvidosColetaNome = BC000I10_A55EnvolvidosColetaNome[0];
            A56EnvolvidosColetaAtivo = BC000I10_A56EnvolvidosColetaAtivo[0];
         }
         Gx_mode = sMode18;
      }

      protected void ScanKeyEnd0I18( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0I18( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0I18( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0I18( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0I18( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0I18( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0I18( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0I18( )
      {
      }

      protected void send_integrity_lvl_hashes0I18( )
      {
      }

      protected void AddRow0I18( )
      {
         VarsToRow18( bcEnvolvidosColeta) ;
      }

      protected void ReadRow0I18( )
      {
         RowToVars18( bcEnvolvidosColeta, 1) ;
      }

      protected void InitializeNonKey0I18( )
      {
         A55EnvolvidosColetaNome = "";
         AV17IsOk = false;
         A56EnvolvidosColetaAtivo = true;
         Z55EnvolvidosColetaNome = "";
         Z56EnvolvidosColetaAtivo = false;
      }

      protected void InitAll0I18( )
      {
         A54EnvolvidosColetaId = 0;
         InitializeNonKey0I18( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A56EnvolvidosColetaAtivo = i56EnvolvidosColetaAtivo;
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

      public void VarsToRow18( SdtEnvolvidosColeta obj18 )
      {
         obj18.gxTpr_Mode = Gx_mode;
         obj18.gxTpr_Envolvidoscoletanome = A55EnvolvidosColetaNome;
         obj18.gxTpr_Envolvidoscoletaativo = A56EnvolvidosColetaAtivo;
         obj18.gxTpr_Envolvidoscoletaid = A54EnvolvidosColetaId;
         obj18.gxTpr_Envolvidoscoletaid_Z = Z54EnvolvidosColetaId;
         obj18.gxTpr_Envolvidoscoletanome_Z = Z55EnvolvidosColetaNome;
         obj18.gxTpr_Envolvidoscoletaativo_Z = Z56EnvolvidosColetaAtivo;
         obj18.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow18( SdtEnvolvidosColeta obj18 )
      {
         obj18.gxTpr_Envolvidoscoletaid = A54EnvolvidosColetaId;
         return  ;
      }

      public void RowToVars18( SdtEnvolvidosColeta obj18 ,
                               int forceLoad )
      {
         Gx_mode = obj18.gxTpr_Mode;
         A55EnvolvidosColetaNome = obj18.gxTpr_Envolvidoscoletanome;
         A56EnvolvidosColetaAtivo = obj18.gxTpr_Envolvidoscoletaativo;
         A54EnvolvidosColetaId = obj18.gxTpr_Envolvidoscoletaid;
         Z54EnvolvidosColetaId = obj18.gxTpr_Envolvidoscoletaid_Z;
         Z55EnvolvidosColetaNome = obj18.gxTpr_Envolvidoscoletanome_Z;
         Z56EnvolvidosColetaAtivo = obj18.gxTpr_Envolvidoscoletaativo_Z;
         Gx_mode = obj18.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A54EnvolvidosColetaId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0I18( ) ;
         ScanKeyStart0I18( ) ;
         if ( RcdFound18 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z54EnvolvidosColetaId = A54EnvolvidosColetaId;
         }
         ZM0I18( -6) ;
         OnLoadActions0I18( ) ;
         AddRow0I18( ) ;
         ScanKeyEnd0I18( ) ;
         if ( RcdFound18 == 0 )
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
         RowToVars18( bcEnvolvidosColeta, 0) ;
         ScanKeyStart0I18( ) ;
         if ( RcdFound18 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z54EnvolvidosColetaId = A54EnvolvidosColetaId;
         }
         ZM0I18( -6) ;
         OnLoadActions0I18( ) ;
         AddRow0I18( ) ;
         ScanKeyEnd0I18( ) ;
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0I18( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0I18( ) ;
         }
         else
         {
            if ( RcdFound18 == 1 )
            {
               if ( A54EnvolvidosColetaId != Z54EnvolvidosColetaId )
               {
                  A54EnvolvidosColetaId = Z54EnvolvidosColetaId;
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
                  Update0I18( ) ;
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
                  if ( A54EnvolvidosColetaId != Z54EnvolvidosColetaId )
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
                        Insert0I18( ) ;
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
                        Insert0I18( ) ;
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
         RowToVars18( bcEnvolvidosColeta, 1) ;
         SaveImpl( ) ;
         VarsToRow18( bcEnvolvidosColeta) ;
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
         RowToVars18( bcEnvolvidosColeta, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0I18( ) ;
         AfterTrn( ) ;
         VarsToRow18( bcEnvolvidosColeta) ;
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
            SdtEnvolvidosColeta auxBC = new SdtEnvolvidosColeta(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A54EnvolvidosColetaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcEnvolvidosColeta);
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
         RowToVars18( bcEnvolvidosColeta, 1) ;
         UpdateImpl( ) ;
         VarsToRow18( bcEnvolvidosColeta) ;
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
         RowToVars18( bcEnvolvidosColeta, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0I18( ) ;
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
         VarsToRow18( bcEnvolvidosColeta) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars18( bcEnvolvidosColeta, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0I18( ) ;
         if ( RcdFound18 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A54EnvolvidosColetaId != Z54EnvolvidosColetaId )
            {
               A54EnvolvidosColetaId = Z54EnvolvidosColetaId;
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
            if ( A54EnvolvidosColetaId != Z54EnvolvidosColetaId )
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
         context.RollbackDataStores("envolvidoscoleta_bc",pr_default);
         VarsToRow18( bcEnvolvidosColeta) ;
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
         Gx_mode = bcEnvolvidosColeta.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcEnvolvidosColeta.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcEnvolvidosColeta )
         {
            bcEnvolvidosColeta = (SdtEnvolvidosColeta)(sdt);
            if ( StringUtil.StrCmp(bcEnvolvidosColeta.gxTpr_Mode, "") == 0 )
            {
               bcEnvolvidosColeta.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow18( bcEnvolvidosColeta) ;
            }
            else
            {
               RowToVars18( bcEnvolvidosColeta, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcEnvolvidosColeta.gxTpr_Mode, "") == 0 )
            {
               bcEnvolvidosColeta.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars18( bcEnvolvidosColeta, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtEnvolvidosColeta EnvolvidosColeta_BC
      {
         get {
            return bcEnvolvidosColeta ;
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
            return "envolvidoscoleta_Execute" ;
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
         Z55EnvolvidosColetaNome = "";
         A55EnvolvidosColetaNome = "";
         BC000I4_A54EnvolvidosColetaId = new int[1] ;
         BC000I4_A55EnvolvidosColetaNome = new string[] {""} ;
         BC000I4_A56EnvolvidosColetaAtivo = new bool[] {false} ;
         BC000I5_A54EnvolvidosColetaId = new int[1] ;
         BC000I3_A54EnvolvidosColetaId = new int[1] ;
         BC000I3_A55EnvolvidosColetaNome = new string[] {""} ;
         BC000I3_A56EnvolvidosColetaAtivo = new bool[] {false} ;
         sMode18 = "";
         BC000I2_A54EnvolvidosColetaId = new int[1] ;
         BC000I2_A55EnvolvidosColetaNome = new string[] {""} ;
         BC000I2_A56EnvolvidosColetaAtivo = new bool[] {false} ;
         BC000I6_A54EnvolvidosColetaId = new int[1] ;
         BC000I9_A54EnvolvidosColetaId = new int[1] ;
         BC000I9_A75DocumentoId = new int[1] ;
         BC000I10_A54EnvolvidosColetaId = new int[1] ;
         BC000I10_A55EnvolvidosColetaNome = new string[] {""} ;
         BC000I10_A56EnvolvidosColetaAtivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.envolvidoscoleta_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.envolvidoscoleta_bc__default(),
            new Object[][] {
                new Object[] {
               BC000I2_A54EnvolvidosColetaId, BC000I2_A55EnvolvidosColetaNome, BC000I2_A56EnvolvidosColetaAtivo
               }
               , new Object[] {
               BC000I3_A54EnvolvidosColetaId, BC000I3_A55EnvolvidosColetaNome, BC000I3_A56EnvolvidosColetaAtivo
               }
               , new Object[] {
               BC000I4_A54EnvolvidosColetaId, BC000I4_A55EnvolvidosColetaNome, BC000I4_A56EnvolvidosColetaAtivo
               }
               , new Object[] {
               BC000I5_A54EnvolvidosColetaId
               }
               , new Object[] {
               BC000I6_A54EnvolvidosColetaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000I9_A54EnvolvidosColetaId, BC000I9_A75DocumentoId
               }
               , new Object[] {
               BC000I10_A54EnvolvidosColetaId, BC000I10_A55EnvolvidosColetaNome, BC000I10_A56EnvolvidosColetaAtivo
               }
            }
         );
         Z56EnvolvidosColetaAtivo = true;
         A56EnvolvidosColetaAtivo = true;
         i56EnvolvidosColetaAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120I2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound18 ;
      private short nIsDirty_18 ;
      private int trnEnded ;
      private int Z54EnvolvidosColetaId ;
      private int A54EnvolvidosColetaId ;
      private int AV16EnvolvidosColetaId_Out ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode18 ;
      private bool returnInSub ;
      private bool AV14IsEnvolvidosColeta ;
      private bool Z56EnvolvidosColetaAtivo ;
      private bool A56EnvolvidosColetaAtivo ;
      private bool AV17IsOk ;
      private bool GXt_boolean1 ;
      private bool i56EnvolvidosColetaAtivo ;
      private bool mustCommit ;
      private string Z55EnvolvidosColetaNome ;
      private string A55EnvolvidosColetaNome ;
      private IGxSession AV12WebSession ;
      private SdtEnvolvidosColeta bcEnvolvidosColeta ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000I4_A54EnvolvidosColetaId ;
      private string[] BC000I4_A55EnvolvidosColetaNome ;
      private bool[] BC000I4_A56EnvolvidosColetaAtivo ;
      private int[] BC000I5_A54EnvolvidosColetaId ;
      private int[] BC000I3_A54EnvolvidosColetaId ;
      private string[] BC000I3_A55EnvolvidosColetaNome ;
      private bool[] BC000I3_A56EnvolvidosColetaAtivo ;
      private int[] BC000I2_A54EnvolvidosColetaId ;
      private string[] BC000I2_A55EnvolvidosColetaNome ;
      private bool[] BC000I2_A56EnvolvidosColetaAtivo ;
      private int[] BC000I6_A54EnvolvidosColetaId ;
      private int[] BC000I9_A54EnvolvidosColetaId ;
      private int[] BC000I9_A75DocumentoId ;
      private int[] BC000I10_A54EnvolvidosColetaId ;
      private string[] BC000I10_A55EnvolvidosColetaNome ;
      private bool[] BC000I10_A56EnvolvidosColetaAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class envolvidoscoleta_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class envolvidoscoleta_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000I4;
        prmBC000I4 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0)
        };
        Object[] prmBC000I5;
        prmBC000I5 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0)
        };
        Object[] prmBC000I3;
        prmBC000I3 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0)
        };
        Object[] prmBC000I2;
        prmBC000I2 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0)
        };
        Object[] prmBC000I6;
        prmBC000I6 = new Object[] {
        new ParDef("@EnvolvidosColetaNome",GXType.NVarChar,100,0) ,
        new ParDef("@EnvolvidosColetaAtivo",GXType.Boolean,4,0)
        };
        Object[] prmBC000I7;
        prmBC000I7 = new Object[] {
        new ParDef("@EnvolvidosColetaNome",GXType.NVarChar,100,0) ,
        new ParDef("@EnvolvidosColetaAtivo",GXType.Boolean,4,0) ,
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0)
        };
        Object[] prmBC000I8;
        prmBC000I8 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0)
        };
        Object[] prmBC000I9;
        prmBC000I9 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0)
        };
        Object[] prmBC000I10;
        prmBC000I10 = new Object[] {
        new ParDef("@EnvolvidosColetaId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000I2", "SELECT [EnvolvidosColetaId], [EnvolvidosColetaNome], [EnvolvidosColetaAtivo] FROM [EnvolvidosColeta] WITH (UPDLOCK) WHERE [EnvolvidosColetaId] = @EnvolvidosColetaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I3", "SELECT [EnvolvidosColetaId], [EnvolvidosColetaNome], [EnvolvidosColetaAtivo] FROM [EnvolvidosColeta] WHERE [EnvolvidosColetaId] = @EnvolvidosColetaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I4", "SELECT TM1.[EnvolvidosColetaId], TM1.[EnvolvidosColetaNome], TM1.[EnvolvidosColetaAtivo] FROM [EnvolvidosColeta] TM1 WHERE TM1.[EnvolvidosColetaId] = @EnvolvidosColetaId ORDER BY TM1.[EnvolvidosColetaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I5", "SELECT [EnvolvidosColetaId] FROM [EnvolvidosColeta] WHERE [EnvolvidosColetaId] = @EnvolvidosColetaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I6", "INSERT INTO [EnvolvidosColeta]([EnvolvidosColetaNome], [EnvolvidosColetaAtivo]) VALUES(@EnvolvidosColetaNome, @EnvolvidosColetaAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000I7", "UPDATE [EnvolvidosColeta] SET [EnvolvidosColetaNome]=@EnvolvidosColetaNome, [EnvolvidosColetaAtivo]=@EnvolvidosColetaAtivo  WHERE [EnvolvidosColetaId] = @EnvolvidosColetaId", GxErrorMask.GX_NOMASK,prmBC000I7)
           ,new CursorDef("BC000I8", "DELETE FROM [EnvolvidosColeta]  WHERE [EnvolvidosColetaId] = @EnvolvidosColetaId", GxErrorMask.GX_NOMASK,prmBC000I8)
           ,new CursorDef("BC000I9", "SELECT TOP 1 [EnvolvidosColetaId], [DocumentoId] FROM [DocEnvolvidosColeta] WHERE [EnvolvidosColetaId] = @EnvolvidosColetaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000I10", "SELECT TM1.[EnvolvidosColetaId], TM1.[EnvolvidosColetaNome], TM1.[EnvolvidosColetaAtivo] FROM [EnvolvidosColeta] TM1 WHERE TM1.[EnvolvidosColetaId] = @EnvolvidosColetaId ORDER BY TM1.[EnvolvidosColetaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I10,100, GxCacheFrequency.OFF ,true,false )
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
