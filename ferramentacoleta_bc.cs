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
   public class ferramentacoleta_bc : GXHttpHandler, IGxSilentTrn
   {
      public ferramentacoleta_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public ferramentacoleta_bc( IGxContext context )
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
         ReadRow0B11( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0B11( ) ;
         standaloneModal( ) ;
         AddRow0B11( ) ;
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
            E110B2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z33FerramentaColetaId = A33FerramentaColetaId;
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

      protected void CONFIRM_0B0( )
      {
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0B11( ) ;
            }
            else
            {
               CheckExtendedTable0B11( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0B11( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120B2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110B2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV14IsFerramentaColeta = true;
         AV15FerramentaColetaId_Out = A33FerramentaColetaId;
      }

      protected void ZM0B11( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z34FerramentaColetaNome = A34FerramentaColetaNome;
            Z35FerramentaColetaAtivo = A35FerramentaColetaAtivo;
         }
         if ( GX_JID == -6 )
         {
            Z33FerramentaColetaId = A33FerramentaColetaId;
            Z34FerramentaColetaNome = A34FerramentaColetaNome;
            Z35FerramentaColetaAtivo = A35FerramentaColetaAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A35FerramentaColetaAtivo) && ( Gx_BScreen == 0 ) )
         {
            A35FerramentaColetaAtivo = true;
         }
      }

      protected void Load0B11( )
      {
         /* Using cursor BC000B4 */
         pr_default.execute(2, new Object[] {n33FerramentaColetaId, A33FerramentaColetaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound11 = 1;
            A34FerramentaColetaNome = BC000B4_A34FerramentaColetaNome[0];
            A35FerramentaColetaAtivo = BC000B4_A35FerramentaColetaAtivo[0];
            ZM0B11( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0B11( ) ;
      }

      protected void OnLoadActions0B11( )
      {
         A34FerramentaColetaNome = StringUtil.Upper( A34FerramentaColetaNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "FerramentaColeta",  A33FerramentaColetaId,  A34FerramentaColetaNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
      }

      protected void CheckExtendedTable0B11( )
      {
         nIsDirty_11 = 0;
         standaloneModal( ) ;
         nIsDirty_11 = 1;
         A34FerramentaColetaNome = StringUtil.Upper( A34FerramentaColetaNome);
         GXt_boolean1 = AV16IsOk;
         new validanome(context ).execute(  "FerramentaColeta",  A33FerramentaColetaId,  A34FerramentaColetaNome, out  GXt_boolean1) ;
         AV16IsOk = GXt_boolean1;
         if ( ! AV16IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A34FerramentaColetaNome)) )
         {
            GX_msglist.addItem("Informe o nome da Ferramenta de Coleta.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0B11( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0B11( )
      {
         /* Using cursor BC000B5 */
         pr_default.execute(3, new Object[] {n33FerramentaColetaId, A33FerramentaColetaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000B3 */
         pr_default.execute(1, new Object[] {n33FerramentaColetaId, A33FerramentaColetaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0B11( 6) ;
            RcdFound11 = 1;
            A33FerramentaColetaId = BC000B3_A33FerramentaColetaId[0];
            n33FerramentaColetaId = BC000B3_n33FerramentaColetaId[0];
            A34FerramentaColetaNome = BC000B3_A34FerramentaColetaNome[0];
            A35FerramentaColetaAtivo = BC000B3_A35FerramentaColetaAtivo[0];
            Z33FerramentaColetaId = A33FerramentaColetaId;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0B11( ) ;
            if ( AnyError == 1 )
            {
               RcdFound11 = 0;
               InitializeNonKey0B11( ) ;
            }
            Gx_mode = sMode11;
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0B11( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode11;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0B11( ) ;
         if ( RcdFound11 == 0 )
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
         CONFIRM_0B0( ) ;
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

      protected void CheckOptimisticConcurrency0B11( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000B2 */
            pr_default.execute(0, new Object[] {n33FerramentaColetaId, A33FerramentaColetaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FerramentaColeta"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z34FerramentaColetaNome, BC000B2_A34FerramentaColetaNome[0]) != 0 ) || ( Z35FerramentaColetaAtivo != BC000B2_A35FerramentaColetaAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"FerramentaColeta"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B11( )
      {
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B11( 0) ;
            CheckOptimisticConcurrency0B11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B6 */
                     pr_default.execute(4, new Object[] {A34FerramentaColetaNome, A35FerramentaColetaAtivo});
                     A33FerramentaColetaId = BC000B6_A33FerramentaColetaId[0];
                     n33FerramentaColetaId = BC000B6_n33FerramentaColetaId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("FerramentaColeta");
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
               Load0B11( ) ;
            }
            EndLevel0B11( ) ;
         }
         CloseExtendedTableCursors0B11( ) ;
      }

      protected void Update0B11( )
      {
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B7 */
                     pr_default.execute(5, new Object[] {A34FerramentaColetaNome, A35FerramentaColetaAtivo, n33FerramentaColetaId, A33FerramentaColetaId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("FerramentaColeta");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FerramentaColeta"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0B11( ) ;
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
            EndLevel0B11( ) ;
         }
         CloseExtendedTableCursors0B11( ) ;
      }

      protected void DeferredUpdate0B11( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B11( ) ;
            AfterConfirm0B11( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B11( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000B8 */
                  pr_default.execute(6, new Object[] {n33FerramentaColetaId, A33FerramentaColetaId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("FerramentaColeta");
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
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0B11( ) ;
         Gx_mode = sMode11;
      }

      protected void OnDeleteControls0B11( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV16IsOk;
            new validanome(context ).execute(  "FerramentaColeta",  A33FerramentaColetaId,  A34FerramentaColetaNome, out  GXt_boolean1) ;
            AV16IsOk = GXt_boolean1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000B9 */
            pr_default.execute(7, new Object[] {n33FerramentaColetaId, A33FerramentaColetaId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0B11( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0B11( ) ;
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

      public void ScanKeyStart0B11( )
      {
         /* Scan By routine */
         /* Using cursor BC000B10 */
         pr_default.execute(8, new Object[] {n33FerramentaColetaId, A33FerramentaColetaId});
         RcdFound11 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound11 = 1;
            A33FerramentaColetaId = BC000B10_A33FerramentaColetaId[0];
            n33FerramentaColetaId = BC000B10_n33FerramentaColetaId[0];
            A34FerramentaColetaNome = BC000B10_A34FerramentaColetaNome[0];
            A35FerramentaColetaAtivo = BC000B10_A35FerramentaColetaAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0B11( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound11 = 0;
         ScanKeyLoad0B11( ) ;
      }

      protected void ScanKeyLoad0B11( )
      {
         sMode11 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound11 = 1;
            A33FerramentaColetaId = BC000B10_A33FerramentaColetaId[0];
            n33FerramentaColetaId = BC000B10_n33FerramentaColetaId[0];
            A34FerramentaColetaNome = BC000B10_A34FerramentaColetaNome[0];
            A35FerramentaColetaAtivo = BC000B10_A35FerramentaColetaAtivo[0];
         }
         Gx_mode = sMode11;
      }

      protected void ScanKeyEnd0B11( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0B11( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B11( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B11( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B11( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B11( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B11( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B11( )
      {
      }

      protected void send_integrity_lvl_hashes0B11( )
      {
      }

      protected void AddRow0B11( )
      {
         VarsToRow11( bcFerramentaColeta) ;
      }

      protected void ReadRow0B11( )
      {
         RowToVars11( bcFerramentaColeta, 1) ;
      }

      protected void InitializeNonKey0B11( )
      {
         A34FerramentaColetaNome = "";
         AV16IsOk = false;
         A35FerramentaColetaAtivo = true;
         Z34FerramentaColetaNome = "";
         Z35FerramentaColetaAtivo = false;
      }

      protected void InitAll0B11( )
      {
         A33FerramentaColetaId = 0;
         n33FerramentaColetaId = false;
         InitializeNonKey0B11( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A35FerramentaColetaAtivo = i35FerramentaColetaAtivo;
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

      public void VarsToRow11( SdtFerramentaColeta obj11 )
      {
         obj11.gxTpr_Mode = Gx_mode;
         obj11.gxTpr_Ferramentacoletanome = A34FerramentaColetaNome;
         obj11.gxTpr_Ferramentacoletaativo = A35FerramentaColetaAtivo;
         obj11.gxTpr_Ferramentacoletaid = A33FerramentaColetaId;
         obj11.gxTpr_Ferramentacoletaid_Z = Z33FerramentaColetaId;
         obj11.gxTpr_Ferramentacoletanome_Z = Z34FerramentaColetaNome;
         obj11.gxTpr_Ferramentacoletaativo_Z = Z35FerramentaColetaAtivo;
         obj11.gxTpr_Ferramentacoletaid_N = (short)(Convert.ToInt16(n33FerramentaColetaId));
         obj11.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow11( SdtFerramentaColeta obj11 )
      {
         obj11.gxTpr_Ferramentacoletaid = A33FerramentaColetaId;
         return  ;
      }

      public void RowToVars11( SdtFerramentaColeta obj11 ,
                               int forceLoad )
      {
         Gx_mode = obj11.gxTpr_Mode;
         A34FerramentaColetaNome = obj11.gxTpr_Ferramentacoletanome;
         A35FerramentaColetaAtivo = obj11.gxTpr_Ferramentacoletaativo;
         A33FerramentaColetaId = obj11.gxTpr_Ferramentacoletaid;
         n33FerramentaColetaId = false;
         Z33FerramentaColetaId = obj11.gxTpr_Ferramentacoletaid_Z;
         Z34FerramentaColetaNome = obj11.gxTpr_Ferramentacoletanome_Z;
         Z35FerramentaColetaAtivo = obj11.gxTpr_Ferramentacoletaativo_Z;
         n33FerramentaColetaId = (bool)(Convert.ToBoolean(obj11.gxTpr_Ferramentacoletaid_N));
         Gx_mode = obj11.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A33FerramentaColetaId = (int)getParm(obj,0);
         n33FerramentaColetaId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0B11( ) ;
         ScanKeyStart0B11( ) ;
         if ( RcdFound11 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z33FerramentaColetaId = A33FerramentaColetaId;
         }
         ZM0B11( -6) ;
         OnLoadActions0B11( ) ;
         AddRow0B11( ) ;
         ScanKeyEnd0B11( ) ;
         if ( RcdFound11 == 0 )
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
         RowToVars11( bcFerramentaColeta, 0) ;
         ScanKeyStart0B11( ) ;
         if ( RcdFound11 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z33FerramentaColetaId = A33FerramentaColetaId;
         }
         ZM0B11( -6) ;
         OnLoadActions0B11( ) ;
         AddRow0B11( ) ;
         ScanKeyEnd0B11( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0B11( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0B11( ) ;
         }
         else
         {
            if ( RcdFound11 == 1 )
            {
               if ( A33FerramentaColetaId != Z33FerramentaColetaId )
               {
                  A33FerramentaColetaId = Z33FerramentaColetaId;
                  n33FerramentaColetaId = false;
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
                  Update0B11( ) ;
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
                  if ( A33FerramentaColetaId != Z33FerramentaColetaId )
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
                        Insert0B11( ) ;
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
                        Insert0B11( ) ;
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
         RowToVars11( bcFerramentaColeta, 1) ;
         SaveImpl( ) ;
         VarsToRow11( bcFerramentaColeta) ;
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
         RowToVars11( bcFerramentaColeta, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0B11( ) ;
         AfterTrn( ) ;
         VarsToRow11( bcFerramentaColeta) ;
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
            SdtFerramentaColeta auxBC = new SdtFerramentaColeta(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A33FerramentaColetaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcFerramentaColeta);
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
         RowToVars11( bcFerramentaColeta, 1) ;
         UpdateImpl( ) ;
         VarsToRow11( bcFerramentaColeta) ;
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
         RowToVars11( bcFerramentaColeta, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0B11( ) ;
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
         VarsToRow11( bcFerramentaColeta) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars11( bcFerramentaColeta, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0B11( ) ;
         if ( RcdFound11 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A33FerramentaColetaId != Z33FerramentaColetaId )
            {
               A33FerramentaColetaId = Z33FerramentaColetaId;
               n33FerramentaColetaId = false;
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
            if ( A33FerramentaColetaId != Z33FerramentaColetaId )
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
         context.RollbackDataStores("ferramentacoleta_bc",pr_default);
         VarsToRow11( bcFerramentaColeta) ;
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
         Gx_mode = bcFerramentaColeta.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcFerramentaColeta.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcFerramentaColeta )
         {
            bcFerramentaColeta = (SdtFerramentaColeta)(sdt);
            if ( StringUtil.StrCmp(bcFerramentaColeta.gxTpr_Mode, "") == 0 )
            {
               bcFerramentaColeta.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow11( bcFerramentaColeta) ;
            }
            else
            {
               RowToVars11( bcFerramentaColeta, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcFerramentaColeta.gxTpr_Mode, "") == 0 )
            {
               bcFerramentaColeta.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars11( bcFerramentaColeta, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtFerramentaColeta FerramentaColeta_BC
      {
         get {
            return bcFerramentaColeta ;
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
            return "ferramentacoleta_Execute" ;
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
         Z34FerramentaColetaNome = "";
         A34FerramentaColetaNome = "";
         BC000B4_A33FerramentaColetaId = new int[1] ;
         BC000B4_n33FerramentaColetaId = new bool[] {false} ;
         BC000B4_A34FerramentaColetaNome = new string[] {""} ;
         BC000B4_A35FerramentaColetaAtivo = new bool[] {false} ;
         BC000B5_A33FerramentaColetaId = new int[1] ;
         BC000B5_n33FerramentaColetaId = new bool[] {false} ;
         BC000B3_A33FerramentaColetaId = new int[1] ;
         BC000B3_n33FerramentaColetaId = new bool[] {false} ;
         BC000B3_A34FerramentaColetaNome = new string[] {""} ;
         BC000B3_A35FerramentaColetaAtivo = new bool[] {false} ;
         sMode11 = "";
         BC000B2_A33FerramentaColetaId = new int[1] ;
         BC000B2_n33FerramentaColetaId = new bool[] {false} ;
         BC000B2_A34FerramentaColetaNome = new string[] {""} ;
         BC000B2_A35FerramentaColetaAtivo = new bool[] {false} ;
         BC000B6_A33FerramentaColetaId = new int[1] ;
         BC000B6_n33FerramentaColetaId = new bool[] {false} ;
         BC000B9_A75DocumentoId = new int[1] ;
         BC000B10_A33FerramentaColetaId = new int[1] ;
         BC000B10_n33FerramentaColetaId = new bool[] {false} ;
         BC000B10_A34FerramentaColetaNome = new string[] {""} ;
         BC000B10_A35FerramentaColetaAtivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.ferramentacoleta_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ferramentacoleta_bc__default(),
            new Object[][] {
                new Object[] {
               BC000B2_A33FerramentaColetaId, BC000B2_A34FerramentaColetaNome, BC000B2_A35FerramentaColetaAtivo
               }
               , new Object[] {
               BC000B3_A33FerramentaColetaId, BC000B3_A34FerramentaColetaNome, BC000B3_A35FerramentaColetaAtivo
               }
               , new Object[] {
               BC000B4_A33FerramentaColetaId, BC000B4_A34FerramentaColetaNome, BC000B4_A35FerramentaColetaAtivo
               }
               , new Object[] {
               BC000B5_A33FerramentaColetaId
               }
               , new Object[] {
               BC000B6_A33FerramentaColetaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000B9_A75DocumentoId
               }
               , new Object[] {
               BC000B10_A33FerramentaColetaId, BC000B10_A34FerramentaColetaNome, BC000B10_A35FerramentaColetaAtivo
               }
            }
         );
         Z35FerramentaColetaAtivo = true;
         A35FerramentaColetaAtivo = true;
         i35FerramentaColetaAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120B2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound11 ;
      private short nIsDirty_11 ;
      private int trnEnded ;
      private int Z33FerramentaColetaId ;
      private int A33FerramentaColetaId ;
      private int AV15FerramentaColetaId_Out ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode11 ;
      private bool returnInSub ;
      private bool AV14IsFerramentaColeta ;
      private bool Z35FerramentaColetaAtivo ;
      private bool A35FerramentaColetaAtivo ;
      private bool n33FerramentaColetaId ;
      private bool AV16IsOk ;
      private bool GXt_boolean1 ;
      private bool i35FerramentaColetaAtivo ;
      private bool mustCommit ;
      private string Z34FerramentaColetaNome ;
      private string A34FerramentaColetaNome ;
      private IGxSession AV12WebSession ;
      private SdtFerramentaColeta bcFerramentaColeta ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000B4_A33FerramentaColetaId ;
      private bool[] BC000B4_n33FerramentaColetaId ;
      private string[] BC000B4_A34FerramentaColetaNome ;
      private bool[] BC000B4_A35FerramentaColetaAtivo ;
      private int[] BC000B5_A33FerramentaColetaId ;
      private bool[] BC000B5_n33FerramentaColetaId ;
      private int[] BC000B3_A33FerramentaColetaId ;
      private bool[] BC000B3_n33FerramentaColetaId ;
      private string[] BC000B3_A34FerramentaColetaNome ;
      private bool[] BC000B3_A35FerramentaColetaAtivo ;
      private int[] BC000B2_A33FerramentaColetaId ;
      private bool[] BC000B2_n33FerramentaColetaId ;
      private string[] BC000B2_A34FerramentaColetaNome ;
      private bool[] BC000B2_A35FerramentaColetaAtivo ;
      private int[] BC000B6_A33FerramentaColetaId ;
      private bool[] BC000B6_n33FerramentaColetaId ;
      private int[] BC000B9_A75DocumentoId ;
      private int[] BC000B10_A33FerramentaColetaId ;
      private bool[] BC000B10_n33FerramentaColetaId ;
      private string[] BC000B10_A34FerramentaColetaNome ;
      private bool[] BC000B10_A35FerramentaColetaAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class ferramentacoleta_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class ferramentacoleta_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000B4;
        prmBC000B4 = new Object[] {
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000B5;
        prmBC000B5 = new Object[] {
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000B3;
        prmBC000B3 = new Object[] {
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000B2;
        prmBC000B2 = new Object[] {
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000B6;
        prmBC000B6 = new Object[] {
        new ParDef("@FerramentaColetaNome",GXType.NVarChar,100,0) ,
        new ParDef("@FerramentaColetaAtivo",GXType.Boolean,4,0)
        };
        Object[] prmBC000B7;
        prmBC000B7 = new Object[] {
        new ParDef("@FerramentaColetaNome",GXType.NVarChar,100,0) ,
        new ParDef("@FerramentaColetaAtivo",GXType.Boolean,4,0) ,
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000B8;
        prmBC000B8 = new Object[] {
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000B9;
        prmBC000B9 = new Object[] {
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000B10;
        prmBC000B10 = new Object[] {
        new ParDef("@FerramentaColetaId",GXType.Int32,8,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC000B2", "SELECT [FerramentaColetaId], [FerramentaColetaNome], [FerramentaColetaAtivo] FROM [FerramentaColeta] WITH (UPDLOCK) WHERE [FerramentaColetaId] = @FerramentaColetaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B3", "SELECT [FerramentaColetaId], [FerramentaColetaNome], [FerramentaColetaAtivo] FROM [FerramentaColeta] WHERE [FerramentaColetaId] = @FerramentaColetaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B4", "SELECT TM1.[FerramentaColetaId], TM1.[FerramentaColetaNome], TM1.[FerramentaColetaAtivo] FROM [FerramentaColeta] TM1 WHERE TM1.[FerramentaColetaId] = @FerramentaColetaId ORDER BY TM1.[FerramentaColetaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B5", "SELECT [FerramentaColetaId] FROM [FerramentaColeta] WHERE [FerramentaColetaId] = @FerramentaColetaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B6", "INSERT INTO [FerramentaColeta]([FerramentaColetaNome], [FerramentaColetaAtivo]) VALUES(@FerramentaColetaNome, @FerramentaColetaAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000B7", "UPDATE [FerramentaColeta] SET [FerramentaColetaNome]=@FerramentaColetaNome, [FerramentaColetaAtivo]=@FerramentaColetaAtivo  WHERE [FerramentaColetaId] = @FerramentaColetaId", GxErrorMask.GX_NOMASK,prmBC000B7)
           ,new CursorDef("BC000B8", "DELETE FROM [FerramentaColeta]  WHERE [FerramentaColetaId] = @FerramentaColetaId", GxErrorMask.GX_NOMASK,prmBC000B8)
           ,new CursorDef("BC000B9", "SELECT TOP 1 [DocumentoId] FROM [Documento] WHERE [FerramentaColetaId] = @FerramentaColetaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000B10", "SELECT TM1.[FerramentaColetaId], TM1.[FerramentaColetaNome], TM1.[FerramentaColetaAtivo] FROM [FerramentaColeta] TM1 WHERE TM1.[FerramentaColetaId] = @FerramentaColetaId ORDER BY TM1.[FerramentaColetaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B10,100, GxCacheFrequency.OFF ,true,false )
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
