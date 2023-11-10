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
   public class arearesponsavel_bc : GXHttpHandler, IGxSilentTrn
   {
      public arearesponsavel_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public arearesponsavel_bc( IGxContext context )
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
         ReadRow1C8( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1C8( ) ;
         standaloneModal( ) ;
         AddRow1C8( ) ;
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
            E111C2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z24AreaResponsavelId = A24AreaResponsavelId;
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

      protected void CONFIRM_1C0( )
      {
         BeforeValidate1C8( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1C8( ) ;
            }
            else
            {
               CheckExtendedTable1C8( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1C8( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E121C2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E111C2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV14IsAreaResponsavel = true;
         AV15AreaResponsavelId_Out = A24AreaResponsavelId;
      }

      protected void ZM1C8( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z25AreaResponsavelNome = A25AreaResponsavelNome;
            Z26AreaResponsavelAtivo = A26AreaResponsavelAtivo;
         }
         if ( GX_JID == -6 )
         {
            Z24AreaResponsavelId = A24AreaResponsavelId;
            Z25AreaResponsavelNome = A25AreaResponsavelNome;
            Z26AreaResponsavelAtivo = A26AreaResponsavelAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A26AreaResponsavelAtivo) && ( Gx_BScreen == 0 ) )
         {
            A26AreaResponsavelAtivo = true;
         }
      }

      protected void Load1C8( )
      {
         /* Using cursor BC001C4 */
         pr_default.execute(2, new Object[] {n24AreaResponsavelId, A24AreaResponsavelId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound8 = 1;
            A25AreaResponsavelNome = BC001C4_A25AreaResponsavelNome[0];
            A26AreaResponsavelAtivo = BC001C4_A26AreaResponsavelAtivo[0];
            ZM1C8( -6) ;
         }
         pr_default.close(2);
         OnLoadActions1C8( ) ;
      }

      protected void OnLoadActions1C8( )
      {
         A25AreaResponsavelNome = StringUtil.Upper( A25AreaResponsavelNome);
         GXt_boolean1 = AV13IsOk;
         new validanome(context ).execute(  "AreaResponsavel",  A24AreaResponsavelId,  A25AreaResponsavelNome, out  GXt_boolean1) ;
         AV13IsOk = GXt_boolean1;
      }

      protected void CheckExtendedTable1C8( )
      {
         nIsDirty_8 = 0;
         standaloneModal( ) ;
         nIsDirty_8 = 1;
         A25AreaResponsavelNome = StringUtil.Upper( A25AreaResponsavelNome);
         GXt_boolean1 = AV13IsOk;
         new validanome(context ).execute(  "AreaResponsavel",  A24AreaResponsavelId,  A25AreaResponsavelNome, out  GXt_boolean1) ;
         AV13IsOk = GXt_boolean1;
         if ( ! AV13IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A25AreaResponsavelNome)) )
         {
            GX_msglist.addItem("Informe o nome da área responsável.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1C8( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1C8( )
      {
         /* Using cursor BC001C5 */
         pr_default.execute(3, new Object[] {n24AreaResponsavelId, A24AreaResponsavelId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001C3 */
         pr_default.execute(1, new Object[] {n24AreaResponsavelId, A24AreaResponsavelId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1C8( 6) ;
            RcdFound8 = 1;
            A24AreaResponsavelId = BC001C3_A24AreaResponsavelId[0];
            n24AreaResponsavelId = BC001C3_n24AreaResponsavelId[0];
            A25AreaResponsavelNome = BC001C3_A25AreaResponsavelNome[0];
            A26AreaResponsavelAtivo = BC001C3_A26AreaResponsavelAtivo[0];
            Z24AreaResponsavelId = A24AreaResponsavelId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1C8( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey1C8( ) ;
            }
            Gx_mode = sMode8;
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey1C8( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode8;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1C8( ) ;
         if ( RcdFound8 == 0 )
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
         CONFIRM_1C0( ) ;
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

      protected void CheckOptimisticConcurrency1C8( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001C2 */
            pr_default.execute(0, new Object[] {n24AreaResponsavelId, A24AreaResponsavelId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AreaResponsavel"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z25AreaResponsavelNome, BC001C2_A25AreaResponsavelNome[0]) != 0 ) || ( Z26AreaResponsavelAtivo != BC001C2_A26AreaResponsavelAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AreaResponsavel"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1C8( )
      {
         BeforeValidate1C8( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1C8( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1C8( 0) ;
            CheckOptimisticConcurrency1C8( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1C8( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1C8( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001C6 */
                     pr_default.execute(4, new Object[] {A25AreaResponsavelNome, A26AreaResponsavelAtivo});
                     A24AreaResponsavelId = BC001C6_A24AreaResponsavelId[0];
                     n24AreaResponsavelId = BC001C6_n24AreaResponsavelId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("AreaResponsavel");
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
               Load1C8( ) ;
            }
            EndLevel1C8( ) ;
         }
         CloseExtendedTableCursors1C8( ) ;
      }

      protected void Update1C8( )
      {
         BeforeValidate1C8( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1C8( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1C8( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1C8( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1C8( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001C7 */
                     pr_default.execute(5, new Object[] {A25AreaResponsavelNome, A26AreaResponsavelAtivo, n24AreaResponsavelId, A24AreaResponsavelId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("AreaResponsavel");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AreaResponsavel"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1C8( ) ;
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
            EndLevel1C8( ) ;
         }
         CloseExtendedTableCursors1C8( ) ;
      }

      protected void DeferredUpdate1C8( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1C8( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1C8( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1C8( ) ;
            AfterConfirm1C8( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1C8( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001C8 */
                  pr_default.execute(6, new Object[] {n24AreaResponsavelId, A24AreaResponsavelId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("AreaResponsavel");
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1C8( ) ;
         Gx_mode = sMode8;
      }

      protected void OnDeleteControls1C8( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV13IsOk;
            new validanome(context ).execute(  "AreaResponsavel",  A24AreaResponsavelId,  A25AreaResponsavelNome, out  GXt_boolean1) ;
            AV13IsOk = GXt_boolean1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001C9 */
            pr_default.execute(7, new Object[] {n24AreaResponsavelId, A24AreaResponsavelId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel1C8( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1C8( ) ;
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

      public void ScanKeyStart1C8( )
      {
         /* Scan By routine */
         /* Using cursor BC001C10 */
         pr_default.execute(8, new Object[] {n24AreaResponsavelId, A24AreaResponsavelId});
         RcdFound8 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound8 = 1;
            A24AreaResponsavelId = BC001C10_A24AreaResponsavelId[0];
            n24AreaResponsavelId = BC001C10_n24AreaResponsavelId[0];
            A25AreaResponsavelNome = BC001C10_A25AreaResponsavelNome[0];
            A26AreaResponsavelAtivo = BC001C10_A26AreaResponsavelAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1C8( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound8 = 0;
         ScanKeyLoad1C8( ) ;
      }

      protected void ScanKeyLoad1C8( )
      {
         sMode8 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound8 = 1;
            A24AreaResponsavelId = BC001C10_A24AreaResponsavelId[0];
            n24AreaResponsavelId = BC001C10_n24AreaResponsavelId[0];
            A25AreaResponsavelNome = BC001C10_A25AreaResponsavelNome[0];
            A26AreaResponsavelAtivo = BC001C10_A26AreaResponsavelAtivo[0];
         }
         Gx_mode = sMode8;
      }

      protected void ScanKeyEnd1C8( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1C8( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1C8( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1C8( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1C8( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1C8( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1C8( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1C8( )
      {
      }

      protected void send_integrity_lvl_hashes1C8( )
      {
      }

      protected void AddRow1C8( )
      {
         VarsToRow8( bcAreaResponsavel) ;
      }

      protected void ReadRow1C8( )
      {
         RowToVars8( bcAreaResponsavel, 1) ;
      }

      protected void InitializeNonKey1C8( )
      {
         A25AreaResponsavelNome = "";
         AV13IsOk = false;
         A26AreaResponsavelAtivo = true;
         Z25AreaResponsavelNome = "";
         Z26AreaResponsavelAtivo = false;
      }

      protected void InitAll1C8( )
      {
         A24AreaResponsavelId = 0;
         n24AreaResponsavelId = false;
         InitializeNonKey1C8( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A26AreaResponsavelAtivo = i26AreaResponsavelAtivo;
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

      public void VarsToRow8( SdtAreaResponsavel obj8 )
      {
         obj8.gxTpr_Mode = Gx_mode;
         obj8.gxTpr_Arearesponsavelnome = A25AreaResponsavelNome;
         obj8.gxTpr_Arearesponsavelativo = A26AreaResponsavelAtivo;
         obj8.gxTpr_Arearesponsavelid = A24AreaResponsavelId;
         obj8.gxTpr_Arearesponsavelid_Z = Z24AreaResponsavelId;
         obj8.gxTpr_Arearesponsavelnome_Z = Z25AreaResponsavelNome;
         obj8.gxTpr_Arearesponsavelativo_Z = Z26AreaResponsavelAtivo;
         obj8.gxTpr_Arearesponsavelid_N = (short)(Convert.ToInt16(n24AreaResponsavelId));
         obj8.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow8( SdtAreaResponsavel obj8 )
      {
         obj8.gxTpr_Arearesponsavelid = A24AreaResponsavelId;
         return  ;
      }

      public void RowToVars8( SdtAreaResponsavel obj8 ,
                              int forceLoad )
      {
         Gx_mode = obj8.gxTpr_Mode;
         A25AreaResponsavelNome = obj8.gxTpr_Arearesponsavelnome;
         A26AreaResponsavelAtivo = obj8.gxTpr_Arearesponsavelativo;
         A24AreaResponsavelId = obj8.gxTpr_Arearesponsavelid;
         n24AreaResponsavelId = false;
         Z24AreaResponsavelId = obj8.gxTpr_Arearesponsavelid_Z;
         Z25AreaResponsavelNome = obj8.gxTpr_Arearesponsavelnome_Z;
         Z26AreaResponsavelAtivo = obj8.gxTpr_Arearesponsavelativo_Z;
         n24AreaResponsavelId = (bool)(Convert.ToBoolean(obj8.gxTpr_Arearesponsavelid_N));
         Gx_mode = obj8.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A24AreaResponsavelId = (int)getParm(obj,0);
         n24AreaResponsavelId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1C8( ) ;
         ScanKeyStart1C8( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z24AreaResponsavelId = A24AreaResponsavelId;
         }
         ZM1C8( -6) ;
         OnLoadActions1C8( ) ;
         AddRow1C8( ) ;
         ScanKeyEnd1C8( ) ;
         if ( RcdFound8 == 0 )
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
         RowToVars8( bcAreaResponsavel, 0) ;
         ScanKeyStart1C8( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z24AreaResponsavelId = A24AreaResponsavelId;
         }
         ZM1C8( -6) ;
         OnLoadActions1C8( ) ;
         AddRow1C8( ) ;
         ScanKeyEnd1C8( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey1C8( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1C8( ) ;
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A24AreaResponsavelId != Z24AreaResponsavelId )
               {
                  A24AreaResponsavelId = Z24AreaResponsavelId;
                  n24AreaResponsavelId = false;
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
                  Update1C8( ) ;
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
                  if ( A24AreaResponsavelId != Z24AreaResponsavelId )
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
                        Insert1C8( ) ;
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
                        Insert1C8( ) ;
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
         RowToVars8( bcAreaResponsavel, 1) ;
         SaveImpl( ) ;
         VarsToRow8( bcAreaResponsavel) ;
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
         RowToVars8( bcAreaResponsavel, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1C8( ) ;
         AfterTrn( ) ;
         VarsToRow8( bcAreaResponsavel) ;
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
            SdtAreaResponsavel auxBC = new SdtAreaResponsavel(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A24AreaResponsavelId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcAreaResponsavel);
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
         RowToVars8( bcAreaResponsavel, 1) ;
         UpdateImpl( ) ;
         VarsToRow8( bcAreaResponsavel) ;
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
         RowToVars8( bcAreaResponsavel, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1C8( ) ;
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
         VarsToRow8( bcAreaResponsavel) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars8( bcAreaResponsavel, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey1C8( ) ;
         if ( RcdFound8 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A24AreaResponsavelId != Z24AreaResponsavelId )
            {
               A24AreaResponsavelId = Z24AreaResponsavelId;
               n24AreaResponsavelId = false;
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
            if ( A24AreaResponsavelId != Z24AreaResponsavelId )
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
         context.RollbackDataStores("arearesponsavel_bc",pr_default);
         VarsToRow8( bcAreaResponsavel) ;
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
         Gx_mode = bcAreaResponsavel.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcAreaResponsavel.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcAreaResponsavel )
         {
            bcAreaResponsavel = (SdtAreaResponsavel)(sdt);
            if ( StringUtil.StrCmp(bcAreaResponsavel.gxTpr_Mode, "") == 0 )
            {
               bcAreaResponsavel.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow8( bcAreaResponsavel) ;
            }
            else
            {
               RowToVars8( bcAreaResponsavel, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcAreaResponsavel.gxTpr_Mode, "") == 0 )
            {
               bcAreaResponsavel.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars8( bcAreaResponsavel, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtAreaResponsavel AreaResponsavel_BC
      {
         get {
            return bcAreaResponsavel ;
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
            return "arearesponsavel_Execute" ;
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
         Z25AreaResponsavelNome = "";
         A25AreaResponsavelNome = "";
         BC001C4_A24AreaResponsavelId = new int[1] ;
         BC001C4_n24AreaResponsavelId = new bool[] {false} ;
         BC001C4_A25AreaResponsavelNome = new string[] {""} ;
         BC001C4_A26AreaResponsavelAtivo = new bool[] {false} ;
         BC001C5_A24AreaResponsavelId = new int[1] ;
         BC001C5_n24AreaResponsavelId = new bool[] {false} ;
         BC001C3_A24AreaResponsavelId = new int[1] ;
         BC001C3_n24AreaResponsavelId = new bool[] {false} ;
         BC001C3_A25AreaResponsavelNome = new string[] {""} ;
         BC001C3_A26AreaResponsavelAtivo = new bool[] {false} ;
         sMode8 = "";
         BC001C2_A24AreaResponsavelId = new int[1] ;
         BC001C2_n24AreaResponsavelId = new bool[] {false} ;
         BC001C2_A25AreaResponsavelNome = new string[] {""} ;
         BC001C2_A26AreaResponsavelAtivo = new bool[] {false} ;
         BC001C6_A24AreaResponsavelId = new int[1] ;
         BC001C6_n24AreaResponsavelId = new bool[] {false} ;
         BC001C9_A75DocumentoId = new int[1] ;
         BC001C10_A24AreaResponsavelId = new int[1] ;
         BC001C10_n24AreaResponsavelId = new bool[] {false} ;
         BC001C10_A25AreaResponsavelNome = new string[] {""} ;
         BC001C10_A26AreaResponsavelAtivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.arearesponsavel_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.arearesponsavel_bc__default(),
            new Object[][] {
                new Object[] {
               BC001C2_A24AreaResponsavelId, BC001C2_A25AreaResponsavelNome, BC001C2_A26AreaResponsavelAtivo
               }
               , new Object[] {
               BC001C3_A24AreaResponsavelId, BC001C3_A25AreaResponsavelNome, BC001C3_A26AreaResponsavelAtivo
               }
               , new Object[] {
               BC001C4_A24AreaResponsavelId, BC001C4_A25AreaResponsavelNome, BC001C4_A26AreaResponsavelAtivo
               }
               , new Object[] {
               BC001C5_A24AreaResponsavelId
               }
               , new Object[] {
               BC001C6_A24AreaResponsavelId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001C9_A75DocumentoId
               }
               , new Object[] {
               BC001C10_A24AreaResponsavelId, BC001C10_A25AreaResponsavelNome, BC001C10_A26AreaResponsavelAtivo
               }
            }
         );
         Z26AreaResponsavelAtivo = true;
         A26AreaResponsavelAtivo = true;
         i26AreaResponsavelAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121C2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound8 ;
      private short nIsDirty_8 ;
      private int trnEnded ;
      private int Z24AreaResponsavelId ;
      private int A24AreaResponsavelId ;
      private int AV15AreaResponsavelId_Out ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode8 ;
      private bool returnInSub ;
      private bool AV14IsAreaResponsavel ;
      private bool Z26AreaResponsavelAtivo ;
      private bool A26AreaResponsavelAtivo ;
      private bool n24AreaResponsavelId ;
      private bool AV13IsOk ;
      private bool GXt_boolean1 ;
      private bool i26AreaResponsavelAtivo ;
      private bool mustCommit ;
      private string Z25AreaResponsavelNome ;
      private string A25AreaResponsavelNome ;
      private IGxSession AV12WebSession ;
      private SdtAreaResponsavel bcAreaResponsavel ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC001C4_A24AreaResponsavelId ;
      private bool[] BC001C4_n24AreaResponsavelId ;
      private string[] BC001C4_A25AreaResponsavelNome ;
      private bool[] BC001C4_A26AreaResponsavelAtivo ;
      private int[] BC001C5_A24AreaResponsavelId ;
      private bool[] BC001C5_n24AreaResponsavelId ;
      private int[] BC001C3_A24AreaResponsavelId ;
      private bool[] BC001C3_n24AreaResponsavelId ;
      private string[] BC001C3_A25AreaResponsavelNome ;
      private bool[] BC001C3_A26AreaResponsavelAtivo ;
      private int[] BC001C2_A24AreaResponsavelId ;
      private bool[] BC001C2_n24AreaResponsavelId ;
      private string[] BC001C2_A25AreaResponsavelNome ;
      private bool[] BC001C2_A26AreaResponsavelAtivo ;
      private int[] BC001C6_A24AreaResponsavelId ;
      private bool[] BC001C6_n24AreaResponsavelId ;
      private int[] BC001C9_A75DocumentoId ;
      private int[] BC001C10_A24AreaResponsavelId ;
      private bool[] BC001C10_n24AreaResponsavelId ;
      private string[] BC001C10_A25AreaResponsavelNome ;
      private bool[] BC001C10_A26AreaResponsavelAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class arearesponsavel_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class arearesponsavel_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC001C4;
        prmBC001C4 = new Object[] {
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC001C5;
        prmBC001C5 = new Object[] {
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC001C3;
        prmBC001C3 = new Object[] {
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC001C2;
        prmBC001C2 = new Object[] {
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC001C6;
        prmBC001C6 = new Object[] {
        new ParDef("@AreaResponsavelNome",GXType.NVarChar,100,0) ,
        new ParDef("@AreaResponsavelAtivo",GXType.Boolean,4,0)
        };
        Object[] prmBC001C7;
        prmBC001C7 = new Object[] {
        new ParDef("@AreaResponsavelNome",GXType.NVarChar,100,0) ,
        new ParDef("@AreaResponsavelAtivo",GXType.Boolean,4,0) ,
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC001C8;
        prmBC001C8 = new Object[] {
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC001C9;
        prmBC001C9 = new Object[] {
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC001C10;
        prmBC001C10 = new Object[] {
        new ParDef("@AreaResponsavelId",GXType.Int32,8,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC001C2", "SELECT [AreaResponsavelId], [AreaResponsavelNome], [AreaResponsavelAtivo] FROM [AreaResponsavel] WITH (UPDLOCK) WHERE [AreaResponsavelId] = @AreaResponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001C3", "SELECT [AreaResponsavelId], [AreaResponsavelNome], [AreaResponsavelAtivo] FROM [AreaResponsavel] WHERE [AreaResponsavelId] = @AreaResponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001C4", "SELECT TM1.[AreaResponsavelId], TM1.[AreaResponsavelNome], TM1.[AreaResponsavelAtivo] FROM [AreaResponsavel] TM1 WHERE TM1.[AreaResponsavelId] = @AreaResponsavelId ORDER BY TM1.[AreaResponsavelId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001C5", "SELECT [AreaResponsavelId] FROM [AreaResponsavel] WHERE [AreaResponsavelId] = @AreaResponsavelId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001C6", "INSERT INTO [AreaResponsavel]([AreaResponsavelNome], [AreaResponsavelAtivo]) VALUES(@AreaResponsavelNome, @AreaResponsavelAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001C7", "UPDATE [AreaResponsavel] SET [AreaResponsavelNome]=@AreaResponsavelNome, [AreaResponsavelAtivo]=@AreaResponsavelAtivo  WHERE [AreaResponsavelId] = @AreaResponsavelId", GxErrorMask.GX_NOMASK,prmBC001C7)
           ,new CursorDef("BC001C8", "DELETE FROM [AreaResponsavel]  WHERE [AreaResponsavelId] = @AreaResponsavelId", GxErrorMask.GX_NOMASK,prmBC001C8)
           ,new CursorDef("BC001C9", "SELECT TOP 1 [DocumentoId] FROM [Documento] WHERE [AreaResponsavelId] = @AreaResponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001C10", "SELECT TM1.[AreaResponsavelId], TM1.[AreaResponsavelNome], TM1.[AreaResponsavelAtivo] FROM [AreaResponsavel] TM1 WHERE TM1.[AreaResponsavelId] = @AreaResponsavelId ORDER BY TM1.[AreaResponsavelId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C10,100, GxCacheFrequency.OFF ,true,false )
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
