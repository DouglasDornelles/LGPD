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
   public class frequenciatratamento_bc : GXHttpHandler, IGxSilentTrn
   {
      public frequenciatratamento_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public frequenciatratamento_bc( IGxContext context )
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
         ReadRow0D13( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0D13( ) ;
         standaloneModal( ) ;
         AddRow0D13( ) ;
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
            E110D2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z39FrequenciaTratamentoId = A39FrequenciaTratamentoId;
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

      protected void CONFIRM_0D0( )
      {
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0D13( ) ;
            }
            else
            {
               CheckExtendedTable0D13( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0D13( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120D2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110D2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV13IsFrequenciaTratamento = true;
         AV14FrequenciaTratamentoId_Out = A39FrequenciaTratamentoId;
      }

      protected void ZM0D13( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z40FrequenciaTratamentoNome = A40FrequenciaTratamentoNome;
            Z41FrequenciaTratamentoAtivo = A41FrequenciaTratamentoAtivo;
         }
         if ( GX_JID == -6 )
         {
            Z39FrequenciaTratamentoId = A39FrequenciaTratamentoId;
            Z40FrequenciaTratamentoNome = A40FrequenciaTratamentoNome;
            Z41FrequenciaTratamentoAtivo = A41FrequenciaTratamentoAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A41FrequenciaTratamentoAtivo) && ( Gx_BScreen == 0 ) )
         {
            A41FrequenciaTratamentoAtivo = true;
         }
      }

      protected void Load0D13( )
      {
         /* Using cursor BC000D4 */
         pr_default.execute(2, new Object[] {n39FrequenciaTratamentoId, A39FrequenciaTratamentoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound13 = 1;
            A40FrequenciaTratamentoNome = BC000D4_A40FrequenciaTratamentoNome[0];
            A41FrequenciaTratamentoAtivo = BC000D4_A41FrequenciaTratamentoAtivo[0];
            ZM0D13( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0D13( ) ;
      }

      protected void OnLoadActions0D13( )
      {
         A40FrequenciaTratamentoNome = StringUtil.Upper( A40FrequenciaTratamentoNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "FrequenciaTratamento",  A39FrequenciaTratamentoId,  A40FrequenciaTratamentoNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
      }

      protected void CheckExtendedTable0D13( )
      {
         nIsDirty_13 = 0;
         standaloneModal( ) ;
         nIsDirty_13 = 1;
         A40FrequenciaTratamentoNome = StringUtil.Upper( A40FrequenciaTratamentoNome);
         GXt_boolean1 = AV15IsOk;
         new validanome(context ).execute(  "FrequenciaTratamento",  A39FrequenciaTratamentoId,  A40FrequenciaTratamentoNome, out  GXt_boolean1) ;
         AV15IsOk = GXt_boolean1;
         if ( ! AV15IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A40FrequenciaTratamentoNome)) )
         {
            GX_msglist.addItem("Informe o nome da Frequência de Tratamento.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0D13( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0D13( )
      {
         /* Using cursor BC000D5 */
         pr_default.execute(3, new Object[] {n39FrequenciaTratamentoId, A39FrequenciaTratamentoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000D3 */
         pr_default.execute(1, new Object[] {n39FrequenciaTratamentoId, A39FrequenciaTratamentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0D13( 6) ;
            RcdFound13 = 1;
            A39FrequenciaTratamentoId = BC000D3_A39FrequenciaTratamentoId[0];
            n39FrequenciaTratamentoId = BC000D3_n39FrequenciaTratamentoId[0];
            A40FrequenciaTratamentoNome = BC000D3_A40FrequenciaTratamentoNome[0];
            A41FrequenciaTratamentoAtivo = BC000D3_A41FrequenciaTratamentoAtivo[0];
            Z39FrequenciaTratamentoId = A39FrequenciaTratamentoId;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0D13( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0D13( ) ;
            }
            Gx_mode = sMode13;
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0D13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode13;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0D13( ) ;
         if ( RcdFound13 == 0 )
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
         CONFIRM_0D0( ) ;
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

      protected void CheckOptimisticConcurrency0D13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000D2 */
            pr_default.execute(0, new Object[] {n39FrequenciaTratamentoId, A39FrequenciaTratamentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FrequenciaTratamento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z40FrequenciaTratamentoNome, BC000D2_A40FrequenciaTratamentoNome[0]) != 0 ) || ( Z41FrequenciaTratamentoAtivo != BC000D2_A41FrequenciaTratamentoAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"FrequenciaTratamento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D13( )
      {
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D13( 0) ;
            CheckOptimisticConcurrency0D13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D6 */
                     pr_default.execute(4, new Object[] {A40FrequenciaTratamentoNome, A41FrequenciaTratamentoAtivo});
                     A39FrequenciaTratamentoId = BC000D6_A39FrequenciaTratamentoId[0];
                     n39FrequenciaTratamentoId = BC000D6_n39FrequenciaTratamentoId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("FrequenciaTratamento");
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
               Load0D13( ) ;
            }
            EndLevel0D13( ) ;
         }
         CloseExtendedTableCursors0D13( ) ;
      }

      protected void Update0D13( )
      {
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0D13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D7 */
                     pr_default.execute(5, new Object[] {A40FrequenciaTratamentoNome, A41FrequenciaTratamentoAtivo, n39FrequenciaTratamentoId, A39FrequenciaTratamentoId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("FrequenciaTratamento");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FrequenciaTratamento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0D13( ) ;
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
            EndLevel0D13( ) ;
         }
         CloseExtendedTableCursors0D13( ) ;
      }

      protected void DeferredUpdate0D13( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D13( ) ;
            AfterConfirm0D13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D13( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000D8 */
                  pr_default.execute(6, new Object[] {n39FrequenciaTratamentoId, A39FrequenciaTratamentoId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("FrequenciaTratamento");
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
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0D13( ) ;
         Gx_mode = sMode13;
      }

      protected void OnDeleteControls0D13( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV15IsOk;
            new validanome(context ).execute(  "FrequenciaTratamento",  A39FrequenciaTratamentoId,  A40FrequenciaTratamentoNome, out  GXt_boolean1) ;
            AV15IsOk = GXt_boolean1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000D9 */
            pr_default.execute(7, new Object[] {n39FrequenciaTratamentoId, A39FrequenciaTratamentoId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0D13( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0D13( ) ;
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

      public void ScanKeyStart0D13( )
      {
         /* Scan By routine */
         /* Using cursor BC000D10 */
         pr_default.execute(8, new Object[] {n39FrequenciaTratamentoId, A39FrequenciaTratamentoId});
         RcdFound13 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound13 = 1;
            A39FrequenciaTratamentoId = BC000D10_A39FrequenciaTratamentoId[0];
            n39FrequenciaTratamentoId = BC000D10_n39FrequenciaTratamentoId[0];
            A40FrequenciaTratamentoNome = BC000D10_A40FrequenciaTratamentoNome[0];
            A41FrequenciaTratamentoAtivo = BC000D10_A41FrequenciaTratamentoAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0D13( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound13 = 0;
         ScanKeyLoad0D13( ) ;
      }

      protected void ScanKeyLoad0D13( )
      {
         sMode13 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound13 = 1;
            A39FrequenciaTratamentoId = BC000D10_A39FrequenciaTratamentoId[0];
            n39FrequenciaTratamentoId = BC000D10_n39FrequenciaTratamentoId[0];
            A40FrequenciaTratamentoNome = BC000D10_A40FrequenciaTratamentoNome[0];
            A41FrequenciaTratamentoAtivo = BC000D10_A41FrequenciaTratamentoAtivo[0];
         }
         Gx_mode = sMode13;
      }

      protected void ScanKeyEnd0D13( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0D13( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0D13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D13( )
      {
      }

      protected void send_integrity_lvl_hashes0D13( )
      {
      }

      protected void AddRow0D13( )
      {
         VarsToRow13( bcFrequenciaTratamento) ;
      }

      protected void ReadRow0D13( )
      {
         RowToVars13( bcFrequenciaTratamento, 1) ;
      }

      protected void InitializeNonKey0D13( )
      {
         A40FrequenciaTratamentoNome = "";
         AV15IsOk = false;
         A41FrequenciaTratamentoAtivo = true;
         Z40FrequenciaTratamentoNome = "";
         Z41FrequenciaTratamentoAtivo = false;
      }

      protected void InitAll0D13( )
      {
         A39FrequenciaTratamentoId = 0;
         n39FrequenciaTratamentoId = false;
         InitializeNonKey0D13( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A41FrequenciaTratamentoAtivo = i41FrequenciaTratamentoAtivo;
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

      public void VarsToRow13( SdtFrequenciaTratamento obj13 )
      {
         obj13.gxTpr_Mode = Gx_mode;
         obj13.gxTpr_Frequenciatratamentonome = A40FrequenciaTratamentoNome;
         obj13.gxTpr_Frequenciatratamentoativo = A41FrequenciaTratamentoAtivo;
         obj13.gxTpr_Frequenciatratamentoid = A39FrequenciaTratamentoId;
         obj13.gxTpr_Frequenciatratamentoid_Z = Z39FrequenciaTratamentoId;
         obj13.gxTpr_Frequenciatratamentonome_Z = Z40FrequenciaTratamentoNome;
         obj13.gxTpr_Frequenciatratamentoativo_Z = Z41FrequenciaTratamentoAtivo;
         obj13.gxTpr_Frequenciatratamentoid_N = (short)(Convert.ToInt16(n39FrequenciaTratamentoId));
         obj13.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow13( SdtFrequenciaTratamento obj13 )
      {
         obj13.gxTpr_Frequenciatratamentoid = A39FrequenciaTratamentoId;
         return  ;
      }

      public void RowToVars13( SdtFrequenciaTratamento obj13 ,
                               int forceLoad )
      {
         Gx_mode = obj13.gxTpr_Mode;
         A40FrequenciaTratamentoNome = obj13.gxTpr_Frequenciatratamentonome;
         A41FrequenciaTratamentoAtivo = obj13.gxTpr_Frequenciatratamentoativo;
         A39FrequenciaTratamentoId = obj13.gxTpr_Frequenciatratamentoid;
         n39FrequenciaTratamentoId = false;
         Z39FrequenciaTratamentoId = obj13.gxTpr_Frequenciatratamentoid_Z;
         Z40FrequenciaTratamentoNome = obj13.gxTpr_Frequenciatratamentonome_Z;
         Z41FrequenciaTratamentoAtivo = obj13.gxTpr_Frequenciatratamentoativo_Z;
         n39FrequenciaTratamentoId = (bool)(Convert.ToBoolean(obj13.gxTpr_Frequenciatratamentoid_N));
         Gx_mode = obj13.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A39FrequenciaTratamentoId = (int)getParm(obj,0);
         n39FrequenciaTratamentoId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0D13( ) ;
         ScanKeyStart0D13( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z39FrequenciaTratamentoId = A39FrequenciaTratamentoId;
         }
         ZM0D13( -6) ;
         OnLoadActions0D13( ) ;
         AddRow0D13( ) ;
         ScanKeyEnd0D13( ) ;
         if ( RcdFound13 == 0 )
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
         RowToVars13( bcFrequenciaTratamento, 0) ;
         ScanKeyStart0D13( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z39FrequenciaTratamentoId = A39FrequenciaTratamentoId;
         }
         ZM0D13( -6) ;
         OnLoadActions0D13( ) ;
         AddRow0D13( ) ;
         ScanKeyEnd0D13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0D13( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0D13( ) ;
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( A39FrequenciaTratamentoId != Z39FrequenciaTratamentoId )
               {
                  A39FrequenciaTratamentoId = Z39FrequenciaTratamentoId;
                  n39FrequenciaTratamentoId = false;
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
                  Update0D13( ) ;
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
                  if ( A39FrequenciaTratamentoId != Z39FrequenciaTratamentoId )
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
                        Insert0D13( ) ;
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
                        Insert0D13( ) ;
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
         RowToVars13( bcFrequenciaTratamento, 1) ;
         SaveImpl( ) ;
         VarsToRow13( bcFrequenciaTratamento) ;
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
         RowToVars13( bcFrequenciaTratamento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0D13( ) ;
         AfterTrn( ) ;
         VarsToRow13( bcFrequenciaTratamento) ;
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
            SdtFrequenciaTratamento auxBC = new SdtFrequenciaTratamento(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A39FrequenciaTratamentoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcFrequenciaTratamento);
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
         RowToVars13( bcFrequenciaTratamento, 1) ;
         UpdateImpl( ) ;
         VarsToRow13( bcFrequenciaTratamento) ;
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
         RowToVars13( bcFrequenciaTratamento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0D13( ) ;
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
         VarsToRow13( bcFrequenciaTratamento) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars13( bcFrequenciaTratamento, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0D13( ) ;
         if ( RcdFound13 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A39FrequenciaTratamentoId != Z39FrequenciaTratamentoId )
            {
               A39FrequenciaTratamentoId = Z39FrequenciaTratamentoId;
               n39FrequenciaTratamentoId = false;
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
            if ( A39FrequenciaTratamentoId != Z39FrequenciaTratamentoId )
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
         context.RollbackDataStores("frequenciatratamento_bc",pr_default);
         VarsToRow13( bcFrequenciaTratamento) ;
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
         Gx_mode = bcFrequenciaTratamento.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcFrequenciaTratamento.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcFrequenciaTratamento )
         {
            bcFrequenciaTratamento = (SdtFrequenciaTratamento)(sdt);
            if ( StringUtil.StrCmp(bcFrequenciaTratamento.gxTpr_Mode, "") == 0 )
            {
               bcFrequenciaTratamento.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow13( bcFrequenciaTratamento) ;
            }
            else
            {
               RowToVars13( bcFrequenciaTratamento, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcFrequenciaTratamento.gxTpr_Mode, "") == 0 )
            {
               bcFrequenciaTratamento.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars13( bcFrequenciaTratamento, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtFrequenciaTratamento FrequenciaTratamento_BC
      {
         get {
            return bcFrequenciaTratamento ;
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
            return "frequenciatratamento_Execute" ;
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
         Z40FrequenciaTratamentoNome = "";
         A40FrequenciaTratamentoNome = "";
         BC000D4_A39FrequenciaTratamentoId = new int[1] ;
         BC000D4_n39FrequenciaTratamentoId = new bool[] {false} ;
         BC000D4_A40FrequenciaTratamentoNome = new string[] {""} ;
         BC000D4_A41FrequenciaTratamentoAtivo = new bool[] {false} ;
         BC000D5_A39FrequenciaTratamentoId = new int[1] ;
         BC000D5_n39FrequenciaTratamentoId = new bool[] {false} ;
         BC000D3_A39FrequenciaTratamentoId = new int[1] ;
         BC000D3_n39FrequenciaTratamentoId = new bool[] {false} ;
         BC000D3_A40FrequenciaTratamentoNome = new string[] {""} ;
         BC000D3_A41FrequenciaTratamentoAtivo = new bool[] {false} ;
         sMode13 = "";
         BC000D2_A39FrequenciaTratamentoId = new int[1] ;
         BC000D2_n39FrequenciaTratamentoId = new bool[] {false} ;
         BC000D2_A40FrequenciaTratamentoNome = new string[] {""} ;
         BC000D2_A41FrequenciaTratamentoAtivo = new bool[] {false} ;
         BC000D6_A39FrequenciaTratamentoId = new int[1] ;
         BC000D6_n39FrequenciaTratamentoId = new bool[] {false} ;
         BC000D9_A75DocumentoId = new int[1] ;
         BC000D10_A39FrequenciaTratamentoId = new int[1] ;
         BC000D10_n39FrequenciaTratamentoId = new bool[] {false} ;
         BC000D10_A40FrequenciaTratamentoNome = new string[] {""} ;
         BC000D10_A41FrequenciaTratamentoAtivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.frequenciatratamento_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.frequenciatratamento_bc__default(),
            new Object[][] {
                new Object[] {
               BC000D2_A39FrequenciaTratamentoId, BC000D2_A40FrequenciaTratamentoNome, BC000D2_A41FrequenciaTratamentoAtivo
               }
               , new Object[] {
               BC000D3_A39FrequenciaTratamentoId, BC000D3_A40FrequenciaTratamentoNome, BC000D3_A41FrequenciaTratamentoAtivo
               }
               , new Object[] {
               BC000D4_A39FrequenciaTratamentoId, BC000D4_A40FrequenciaTratamentoNome, BC000D4_A41FrequenciaTratamentoAtivo
               }
               , new Object[] {
               BC000D5_A39FrequenciaTratamentoId
               }
               , new Object[] {
               BC000D6_A39FrequenciaTratamentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000D9_A75DocumentoId
               }
               , new Object[] {
               BC000D10_A39FrequenciaTratamentoId, BC000D10_A40FrequenciaTratamentoNome, BC000D10_A41FrequenciaTratamentoAtivo
               }
            }
         );
         Z41FrequenciaTratamentoAtivo = true;
         A41FrequenciaTratamentoAtivo = true;
         i41FrequenciaTratamentoAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120D2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound13 ;
      private short nIsDirty_13 ;
      private int trnEnded ;
      private int Z39FrequenciaTratamentoId ;
      private int A39FrequenciaTratamentoId ;
      private int AV14FrequenciaTratamentoId_Out ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode13 ;
      private bool returnInSub ;
      private bool AV13IsFrequenciaTratamento ;
      private bool Z41FrequenciaTratamentoAtivo ;
      private bool A41FrequenciaTratamentoAtivo ;
      private bool n39FrequenciaTratamentoId ;
      private bool AV15IsOk ;
      private bool GXt_boolean1 ;
      private bool i41FrequenciaTratamentoAtivo ;
      private bool mustCommit ;
      private string Z40FrequenciaTratamentoNome ;
      private string A40FrequenciaTratamentoNome ;
      private IGxSession AV12WebSession ;
      private SdtFrequenciaTratamento bcFrequenciaTratamento ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000D4_A39FrequenciaTratamentoId ;
      private bool[] BC000D4_n39FrequenciaTratamentoId ;
      private string[] BC000D4_A40FrequenciaTratamentoNome ;
      private bool[] BC000D4_A41FrequenciaTratamentoAtivo ;
      private int[] BC000D5_A39FrequenciaTratamentoId ;
      private bool[] BC000D5_n39FrequenciaTratamentoId ;
      private int[] BC000D3_A39FrequenciaTratamentoId ;
      private bool[] BC000D3_n39FrequenciaTratamentoId ;
      private string[] BC000D3_A40FrequenciaTratamentoNome ;
      private bool[] BC000D3_A41FrequenciaTratamentoAtivo ;
      private int[] BC000D2_A39FrequenciaTratamentoId ;
      private bool[] BC000D2_n39FrequenciaTratamentoId ;
      private string[] BC000D2_A40FrequenciaTratamentoNome ;
      private bool[] BC000D2_A41FrequenciaTratamentoAtivo ;
      private int[] BC000D6_A39FrequenciaTratamentoId ;
      private bool[] BC000D6_n39FrequenciaTratamentoId ;
      private int[] BC000D9_A75DocumentoId ;
      private int[] BC000D10_A39FrequenciaTratamentoId ;
      private bool[] BC000D10_n39FrequenciaTratamentoId ;
      private string[] BC000D10_A40FrequenciaTratamentoNome ;
      private bool[] BC000D10_A41FrequenciaTratamentoAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class frequenciatratamento_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class frequenciatratamento_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000D4;
        prmBC000D4 = new Object[] {
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000D5;
        prmBC000D5 = new Object[] {
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000D3;
        prmBC000D3 = new Object[] {
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000D2;
        prmBC000D2 = new Object[] {
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000D6;
        prmBC000D6 = new Object[] {
        new ParDef("@FrequenciaTratamentoNome",GXType.NVarChar,100,0) ,
        new ParDef("@FrequenciaTratamentoAtivo",GXType.Boolean,4,0)
        };
        Object[] prmBC000D7;
        prmBC000D7 = new Object[] {
        new ParDef("@FrequenciaTratamentoNome",GXType.NVarChar,100,0) ,
        new ParDef("@FrequenciaTratamentoAtivo",GXType.Boolean,4,0) ,
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000D8;
        prmBC000D8 = new Object[] {
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000D9;
        prmBC000D9 = new Object[] {
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000D10;
        prmBC000D10 = new Object[] {
        new ParDef("@FrequenciaTratamentoId",GXType.Int32,8,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC000D2", "SELECT [FrequenciaTratamentoId], [FrequenciaTratamentoNome], [FrequenciaTratamentoAtivo] FROM [FrequenciaTratamento] WITH (UPDLOCK) WHERE [FrequenciaTratamentoId] = @FrequenciaTratamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D3", "SELECT [FrequenciaTratamentoId], [FrequenciaTratamentoNome], [FrequenciaTratamentoAtivo] FROM [FrequenciaTratamento] WHERE [FrequenciaTratamentoId] = @FrequenciaTratamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D4", "SELECT TM1.[FrequenciaTratamentoId], TM1.[FrequenciaTratamentoNome], TM1.[FrequenciaTratamentoAtivo] FROM [FrequenciaTratamento] TM1 WHERE TM1.[FrequenciaTratamentoId] = @FrequenciaTratamentoId ORDER BY TM1.[FrequenciaTratamentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D5", "SELECT [FrequenciaTratamentoId] FROM [FrequenciaTratamento] WHERE [FrequenciaTratamentoId] = @FrequenciaTratamentoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D6", "INSERT INTO [FrequenciaTratamento]([FrequenciaTratamentoNome], [FrequenciaTratamentoAtivo]) VALUES(@FrequenciaTratamentoNome, @FrequenciaTratamentoAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000D7", "UPDATE [FrequenciaTratamento] SET [FrequenciaTratamentoNome]=@FrequenciaTratamentoNome, [FrequenciaTratamentoAtivo]=@FrequenciaTratamentoAtivo  WHERE [FrequenciaTratamentoId] = @FrequenciaTratamentoId", GxErrorMask.GX_NOMASK,prmBC000D7)
           ,new CursorDef("BC000D8", "DELETE FROM [FrequenciaTratamento]  WHERE [FrequenciaTratamentoId] = @FrequenciaTratamentoId", GxErrorMask.GX_NOMASK,prmBC000D8)
           ,new CursorDef("BC000D9", "SELECT TOP 1 [DocumentoId] FROM [Documento] WHERE [FrequenciaTratamentoId] = @FrequenciaTratamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000D10", "SELECT TM1.[FrequenciaTratamentoId], TM1.[FrequenciaTratamentoNome], TM1.[FrequenciaTratamentoAtivo] FROM [FrequenciaTratamento] TM1 WHERE TM1.[FrequenciaTratamentoId] = @FrequenciaTratamentoId ORDER BY TM1.[FrequenciaTratamentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D10,100, GxCacheFrequency.OFF ,true,false )
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
