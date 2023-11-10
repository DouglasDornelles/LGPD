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
   public class informacao_bc : GXHttpHandler, IGxSilentTrn
   {
      public informacao_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public informacao_bc( IGxContext context )
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
         ReadRow0N23( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0N23( ) ;
         standaloneModal( ) ;
         AddRow0N23( ) ;
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
            E110N2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z69InformacaoId = A69InformacaoId;
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

      protected void CONFIRM_0N0( )
      {
         BeforeValidate0N23( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0N23( ) ;
            }
            else
            {
               CheckExtendedTable0N23( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0N23( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120N2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110N2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV14IsInformacao = true;
         AV13InformacaoId_Out = A69InformacaoId;
      }

      protected void ZM0N23( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z70InformacaoNome = A70InformacaoNome;
            Z71InformacaoAtivo = A71InformacaoAtivo;
         }
         if ( GX_JID == -6 )
         {
            Z69InformacaoId = A69InformacaoId;
            Z70InformacaoNome = A70InformacaoNome;
            Z71InformacaoAtivo = A71InformacaoAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A71InformacaoAtivo) && ( Gx_BScreen == 0 ) )
         {
            A71InformacaoAtivo = true;
         }
      }

      protected void Load0N23( )
      {
         /* Using cursor BC000N4 */
         pr_default.execute(2, new Object[] {A69InformacaoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound23 = 1;
            A70InformacaoNome = BC000N4_A70InformacaoNome[0];
            A71InformacaoAtivo = BC000N4_A71InformacaoAtivo[0];
            ZM0N23( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0N23( ) ;
      }

      protected void OnLoadActions0N23( )
      {
         A70InformacaoNome = StringUtil.Upper( A70InformacaoNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "Informacao",  A69InformacaoId,  A70InformacaoNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
      }

      protected void CheckExtendedTable0N23( )
      {
         nIsDirty_23 = 0;
         standaloneModal( ) ;
         nIsDirty_23 = 1;
         A70InformacaoNome = StringUtil.Upper( A70InformacaoNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "Informacao",  A69InformacaoId,  A70InformacaoNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
         if ( ! AV15IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A70InformacaoNome)) )
         {
            GX_msglist.addItem("Informe o nome da Informação.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0N23( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0N23( )
      {
         /* Using cursor BC000N5 */
         pr_default.execute(3, new Object[] {A69InformacaoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound23 = 1;
         }
         else
         {
            RcdFound23 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000N3 */
         pr_default.execute(1, new Object[] {A69InformacaoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0N23( 6) ;
            RcdFound23 = 1;
            A69InformacaoId = BC000N3_A69InformacaoId[0];
            A70InformacaoNome = BC000N3_A70InformacaoNome[0];
            A71InformacaoAtivo = BC000N3_A71InformacaoAtivo[0];
            Z69InformacaoId = A69InformacaoId;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0N23( ) ;
            if ( AnyError == 1 )
            {
               RcdFound23 = 0;
               InitializeNonKey0N23( ) ;
            }
            Gx_mode = sMode23;
         }
         else
         {
            RcdFound23 = 0;
            InitializeNonKey0N23( ) ;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode23;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0N23( ) ;
         if ( RcdFound23 == 0 )
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
         CONFIRM_0N0( ) ;
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

      protected void CheckOptimisticConcurrency0N23( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000N2 */
            pr_default.execute(0, new Object[] {A69InformacaoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Informacao"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z70InformacaoNome, BC000N2_A70InformacaoNome[0]) != 0 ) || ( Z71InformacaoAtivo != BC000N2_A71InformacaoAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Informacao"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0N23( )
      {
         BeforeValidate0N23( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N23( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0N23( 0) ;
            CheckOptimisticConcurrency0N23( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N23( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0N23( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000N6 */
                     pr_default.execute(4, new Object[] {A70InformacaoNome, A71InformacaoAtivo});
                     A69InformacaoId = BC000N6_A69InformacaoId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("Informacao");
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
               Load0N23( ) ;
            }
            EndLevel0N23( ) ;
         }
         CloseExtendedTableCursors0N23( ) ;
      }

      protected void Update0N23( )
      {
         BeforeValidate0N23( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N23( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N23( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N23( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0N23( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000N7 */
                     pr_default.execute(5, new Object[] {A70InformacaoNome, A71InformacaoAtivo, A69InformacaoId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("Informacao");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Informacao"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0N23( ) ;
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
            EndLevel0N23( ) ;
         }
         CloseExtendedTableCursors0N23( ) ;
      }

      protected void DeferredUpdate0N23( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0N23( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N23( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0N23( ) ;
            AfterConfirm0N23( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0N23( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000N8 */
                  pr_default.execute(6, new Object[] {A69InformacaoId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("Informacao");
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
         sMode23 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0N23( ) ;
         Gx_mode = sMode23;
      }

      protected void OnDeleteControls0N23( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV15IsOk;
            new validanome(context ).execute(  "Informacao",  A69InformacaoId,  A70InformacaoNome, out  GXt_boolean1) ;
            AV15IsOk = GXt_boolean1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000N9 */
            pr_default.execute(7, new Object[] {A69InformacaoId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0N23( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0N23( ) ;
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

      public void ScanKeyStart0N23( )
      {
         /* Scan By routine */
         /* Using cursor BC000N10 */
         pr_default.execute(8, new Object[] {A69InformacaoId});
         RcdFound23 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound23 = 1;
            A69InformacaoId = BC000N10_A69InformacaoId[0];
            A70InformacaoNome = BC000N10_A70InformacaoNome[0];
            A71InformacaoAtivo = BC000N10_A71InformacaoAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0N23( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound23 = 0;
         ScanKeyLoad0N23( ) ;
      }

      protected void ScanKeyLoad0N23( )
      {
         sMode23 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound23 = 1;
            A69InformacaoId = BC000N10_A69InformacaoId[0];
            A70InformacaoNome = BC000N10_A70InformacaoNome[0];
            A71InformacaoAtivo = BC000N10_A71InformacaoAtivo[0];
         }
         Gx_mode = sMode23;
      }

      protected void ScanKeyEnd0N23( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0N23( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0N23( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0N23( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0N23( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0N23( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0N23( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0N23( )
      {
      }

      protected void send_integrity_lvl_hashes0N23( )
      {
      }

      protected void AddRow0N23( )
      {
         VarsToRow23( bcInformacao) ;
      }

      protected void ReadRow0N23( )
      {
         RowToVars23( bcInformacao, 1) ;
      }

      protected void InitializeNonKey0N23( )
      {
         A70InformacaoNome = "";
         AV15IsOk = false;
         A71InformacaoAtivo = true;
         Z70InformacaoNome = "";
         Z71InformacaoAtivo = false;
      }

      protected void InitAll0N23( )
      {
         A69InformacaoId = 0;
         InitializeNonKey0N23( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A71InformacaoAtivo = i71InformacaoAtivo;
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

      public void VarsToRow23( SdtInformacao obj23 )
      {
         obj23.gxTpr_Mode = Gx_mode;
         obj23.gxTpr_Informacaonome = A70InformacaoNome;
         obj23.gxTpr_Informacaoativo = A71InformacaoAtivo;
         obj23.gxTpr_Informacaoid = A69InformacaoId;
         obj23.gxTpr_Informacaoid_Z = Z69InformacaoId;
         obj23.gxTpr_Informacaonome_Z = Z70InformacaoNome;
         obj23.gxTpr_Informacaoativo_Z = Z71InformacaoAtivo;
         obj23.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow23( SdtInformacao obj23 )
      {
         obj23.gxTpr_Informacaoid = A69InformacaoId;
         return  ;
      }

      public void RowToVars23( SdtInformacao obj23 ,
                               int forceLoad )
      {
         Gx_mode = obj23.gxTpr_Mode;
         A70InformacaoNome = obj23.gxTpr_Informacaonome;
         A71InformacaoAtivo = obj23.gxTpr_Informacaoativo;
         A69InformacaoId = obj23.gxTpr_Informacaoid;
         Z69InformacaoId = obj23.gxTpr_Informacaoid_Z;
         Z70InformacaoNome = obj23.gxTpr_Informacaonome_Z;
         Z71InformacaoAtivo = obj23.gxTpr_Informacaoativo_Z;
         Gx_mode = obj23.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A69InformacaoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0N23( ) ;
         ScanKeyStart0N23( ) ;
         if ( RcdFound23 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z69InformacaoId = A69InformacaoId;
         }
         ZM0N23( -6) ;
         OnLoadActions0N23( ) ;
         AddRow0N23( ) ;
         ScanKeyEnd0N23( ) ;
         if ( RcdFound23 == 0 )
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
         RowToVars23( bcInformacao, 0) ;
         ScanKeyStart0N23( ) ;
         if ( RcdFound23 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z69InformacaoId = A69InformacaoId;
         }
         ZM0N23( -6) ;
         OnLoadActions0N23( ) ;
         AddRow0N23( ) ;
         ScanKeyEnd0N23( ) ;
         if ( RcdFound23 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0N23( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0N23( ) ;
         }
         else
         {
            if ( RcdFound23 == 1 )
            {
               if ( A69InformacaoId != Z69InformacaoId )
               {
                  A69InformacaoId = Z69InformacaoId;
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
                  Update0N23( ) ;
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
                  if ( A69InformacaoId != Z69InformacaoId )
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
                        Insert0N23( ) ;
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
                        Insert0N23( ) ;
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
         RowToVars23( bcInformacao, 1) ;
         SaveImpl( ) ;
         VarsToRow23( bcInformacao) ;
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
         RowToVars23( bcInformacao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0N23( ) ;
         AfterTrn( ) ;
         VarsToRow23( bcInformacao) ;
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
            SdtInformacao auxBC = new SdtInformacao(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A69InformacaoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcInformacao);
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
         RowToVars23( bcInformacao, 1) ;
         UpdateImpl( ) ;
         VarsToRow23( bcInformacao) ;
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
         RowToVars23( bcInformacao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0N23( ) ;
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
         VarsToRow23( bcInformacao) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars23( bcInformacao, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0N23( ) ;
         if ( RcdFound23 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A69InformacaoId != Z69InformacaoId )
            {
               A69InformacaoId = Z69InformacaoId;
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
            if ( A69InformacaoId != Z69InformacaoId )
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
         context.RollbackDataStores("informacao_bc",pr_default);
         VarsToRow23( bcInformacao) ;
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
         Gx_mode = bcInformacao.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcInformacao.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcInformacao )
         {
            bcInformacao = (SdtInformacao)(sdt);
            if ( StringUtil.StrCmp(bcInformacao.gxTpr_Mode, "") == 0 )
            {
               bcInformacao.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow23( bcInformacao) ;
            }
            else
            {
               RowToVars23( bcInformacao, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcInformacao.gxTpr_Mode, "") == 0 )
            {
               bcInformacao.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars23( bcInformacao, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtInformacao Informacao_BC
      {
         get {
            return bcInformacao ;
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
            return "informacao_Execute" ;
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
         Z70InformacaoNome = "";
         A70InformacaoNome = "";
         BC000N4_A69InformacaoId = new int[1] ;
         BC000N4_A70InformacaoNome = new string[] {""} ;
         BC000N4_A71InformacaoAtivo = new bool[] {false} ;
         BC000N5_A69InformacaoId = new int[1] ;
         BC000N3_A69InformacaoId = new int[1] ;
         BC000N3_A70InformacaoNome = new string[] {""} ;
         BC000N3_A71InformacaoAtivo = new bool[] {false} ;
         sMode23 = "";
         BC000N2_A69InformacaoId = new int[1] ;
         BC000N2_A70InformacaoNome = new string[] {""} ;
         BC000N2_A71InformacaoAtivo = new bool[] {false} ;
         BC000N6_A69InformacaoId = new int[1] ;
         BC000N9_A98DocDicionarioId = new int[1] ;
         BC000N10_A69InformacaoId = new int[1] ;
         BC000N10_A70InformacaoNome = new string[] {""} ;
         BC000N10_A71InformacaoAtivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.informacao_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.informacao_bc__default(),
            new Object[][] {
                new Object[] {
               BC000N2_A69InformacaoId, BC000N2_A70InformacaoNome, BC000N2_A71InformacaoAtivo
               }
               , new Object[] {
               BC000N3_A69InformacaoId, BC000N3_A70InformacaoNome, BC000N3_A71InformacaoAtivo
               }
               , new Object[] {
               BC000N4_A69InformacaoId, BC000N4_A70InformacaoNome, BC000N4_A71InformacaoAtivo
               }
               , new Object[] {
               BC000N5_A69InformacaoId
               }
               , new Object[] {
               BC000N6_A69InformacaoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000N9_A98DocDicionarioId
               }
               , new Object[] {
               BC000N10_A69InformacaoId, BC000N10_A70InformacaoNome, BC000N10_A71InformacaoAtivo
               }
            }
         );
         Z71InformacaoAtivo = true;
         A71InformacaoAtivo = true;
         i71InformacaoAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120N2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound23 ;
      private short nIsDirty_23 ;
      private int trnEnded ;
      private int Z69InformacaoId ;
      private int A69InformacaoId ;
      private int AV13InformacaoId_Out ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode23 ;
      private bool returnInSub ;
      private bool AV14IsInformacao ;
      private bool Z71InformacaoAtivo ;
      private bool A71InformacaoAtivo ;
      private bool AV15IsOk ;
      private bool GXt_boolean1 ;
      private bool i71InformacaoAtivo ;
      private bool mustCommit ;
      private string Z70InformacaoNome ;
      private string A70InformacaoNome ;
      private IGxSession AV12WebSession ;
      private SdtInformacao bcInformacao ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000N4_A69InformacaoId ;
      private string[] BC000N4_A70InformacaoNome ;
      private bool[] BC000N4_A71InformacaoAtivo ;
      private int[] BC000N5_A69InformacaoId ;
      private int[] BC000N3_A69InformacaoId ;
      private string[] BC000N3_A70InformacaoNome ;
      private bool[] BC000N3_A71InformacaoAtivo ;
      private int[] BC000N2_A69InformacaoId ;
      private string[] BC000N2_A70InformacaoNome ;
      private bool[] BC000N2_A71InformacaoAtivo ;
      private int[] BC000N6_A69InformacaoId ;
      private int[] BC000N9_A98DocDicionarioId ;
      private int[] BC000N10_A69InformacaoId ;
      private string[] BC000N10_A70InformacaoNome ;
      private bool[] BC000N10_A71InformacaoAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
   }

   public class informacao_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class informacao_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000N4;
        prmBC000N4 = new Object[] {
        new ParDef("@InformacaoId",GXType.Int32,8,0)
        };
        Object[] prmBC000N5;
        prmBC000N5 = new Object[] {
        new ParDef("@InformacaoId",GXType.Int32,8,0)
        };
        Object[] prmBC000N3;
        prmBC000N3 = new Object[] {
        new ParDef("@InformacaoId",GXType.Int32,8,0)
        };
        Object[] prmBC000N2;
        prmBC000N2 = new Object[] {
        new ParDef("@InformacaoId",GXType.Int32,8,0)
        };
        Object[] prmBC000N6;
        prmBC000N6 = new Object[] {
        new ParDef("@InformacaoNome",GXType.NVarChar,100,0) ,
        new ParDef("@InformacaoAtivo",GXType.Boolean,4,0)
        };
        Object[] prmBC000N7;
        prmBC000N7 = new Object[] {
        new ParDef("@InformacaoNome",GXType.NVarChar,100,0) ,
        new ParDef("@InformacaoAtivo",GXType.Boolean,4,0) ,
        new ParDef("@InformacaoId",GXType.Int32,8,0)
        };
        Object[] prmBC000N8;
        prmBC000N8 = new Object[] {
        new ParDef("@InformacaoId",GXType.Int32,8,0)
        };
        Object[] prmBC000N9;
        prmBC000N9 = new Object[] {
        new ParDef("@InformacaoId",GXType.Int32,8,0)
        };
        Object[] prmBC000N10;
        prmBC000N10 = new Object[] {
        new ParDef("@InformacaoId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000N2", "SELECT [InformacaoId], [InformacaoNome], [InformacaoAtivo] FROM [Informacao] WITH (UPDLOCK) WHERE [InformacaoId] = @InformacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N3", "SELECT [InformacaoId], [InformacaoNome], [InformacaoAtivo] FROM [Informacao] WHERE [InformacaoId] = @InformacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N4", "SELECT TM1.[InformacaoId], TM1.[InformacaoNome], TM1.[InformacaoAtivo] FROM [Informacao] TM1 WHERE TM1.[InformacaoId] = @InformacaoId ORDER BY TM1.[InformacaoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N5", "SELECT [InformacaoId] FROM [Informacao] WHERE [InformacaoId] = @InformacaoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N6", "INSERT INTO [Informacao]([InformacaoNome], [InformacaoAtivo]) VALUES(@InformacaoNome, @InformacaoAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000N7", "UPDATE [Informacao] SET [InformacaoNome]=@InformacaoNome, [InformacaoAtivo]=@InformacaoAtivo  WHERE [InformacaoId] = @InformacaoId", GxErrorMask.GX_NOMASK,prmBC000N7)
           ,new CursorDef("BC000N8", "DELETE FROM [Informacao]  WHERE [InformacaoId] = @InformacaoId", GxErrorMask.GX_NOMASK,prmBC000N8)
           ,new CursorDef("BC000N9", "SELECT TOP 1 [DocDicionarioId] FROM [DocDicionario] WHERE [InformacaoId] = @InformacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000N10", "SELECT TM1.[InformacaoId], TM1.[InformacaoNome], TM1.[InformacaoAtivo] FROM [Informacao] TM1 WHERE TM1.[InformacaoId] = @InformacaoId ORDER BY TM1.[InformacaoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N10,100, GxCacheFrequency.OFF ,true,false )
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
