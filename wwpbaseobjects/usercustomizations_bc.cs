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
namespace GeneXus.Programs.wwpbaseobjects {
   public class usercustomizations_bc : GXHttpHandler, IGxSilentTrn
   {
      public usercustomizations_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public usercustomizations_bc( IGxContext context )
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
         ReadRow011( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey011( ) ;
         standaloneModal( ) ;
         AddRow011( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z1UserCustomizationsId = A1UserCustomizationsId;
               Z2UserCustomizationsKey = A2UserCustomizationsKey;
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

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -1 )
         {
            Z1UserCustomizationsId = A1UserCustomizationsId;
            Z2UserCustomizationsKey = A2UserCustomizationsKey;
            Z3UserCustomizationsValue = A3UserCustomizationsValue;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load011( )
      {
         /* Using cursor BC00014 */
         pr_default.execute(2, new Object[] {A1UserCustomizationsId, A2UserCustomizationsKey});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound1 = 1;
            A3UserCustomizationsValue = BC00014_A3UserCustomizationsValue[0];
            ZM011( -1) ;
         }
         pr_default.close(2);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
      }

      protected void CheckExtendedTable011( )
      {
         nIsDirty_1 = 0;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors011( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor BC00015 */
         pr_default.execute(3, new Object[] {A1UserCustomizationsId, A2UserCustomizationsKey});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00013 */
         pr_default.execute(1, new Object[] {A1UserCustomizationsId, A2UserCustomizationsKey});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 1) ;
            RcdFound1 = 1;
            A1UserCustomizationsId = BC00013_A1UserCustomizationsId[0];
            A2UserCustomizationsKey = BC00013_A2UserCustomizationsKey[0];
            A3UserCustomizationsValue = BC00013_A3UserCustomizationsValue[0];
            Z1UserCustomizationsId = A1UserCustomizationsId;
            Z2UserCustomizationsKey = A2UserCustomizationsKey;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode1;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
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
         CONFIRM_010( ) ;
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

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00012 */
            pr_default.execute(0, new Object[] {A1UserCustomizationsId, A2UserCustomizationsKey});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UserCustomizations"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"UserCustomizations"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00016 */
                     pr_default.execute(4, new Object[] {A1UserCustomizationsId, A2UserCustomizationsKey, A3UserCustomizationsValue});
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("UserCustomizations");
                     if ( (pr_default.getStatus(4) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
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
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00017 */
                     pr_default.execute(5, new Object[] {A3UserCustomizationsValue, A1UserCustomizationsId, A2UserCustomizationsKey});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("UserCustomizations");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UserCustomizations"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
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
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00018 */
                  pr_default.execute(6, new Object[] {A1UserCustomizationsId, A2UserCustomizationsKey});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("UserCustomizations");
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
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel011( ) ;
         Gx_mode = sMode1;
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
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

      public void ScanKeyStart011( )
      {
         /* Using cursor BC00019 */
         pr_default.execute(7, new Object[] {A1UserCustomizationsId, A2UserCustomizationsKey});
         RcdFound1 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound1 = 1;
            A1UserCustomizationsId = BC00019_A1UserCustomizationsId[0];
            A2UserCustomizationsKey = BC00019_A2UserCustomizationsKey[0];
            A3UserCustomizationsValue = BC00019_A3UserCustomizationsValue[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound1 = 0;
         ScanKeyLoad011( ) ;
      }

      protected void ScanKeyLoad011( )
      {
         sMode1 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound1 = 1;
            A1UserCustomizationsId = BC00019_A1UserCustomizationsId[0];
            A2UserCustomizationsKey = BC00019_A2UserCustomizationsKey[0];
            A3UserCustomizationsValue = BC00019_A3UserCustomizationsValue[0];
         }
         Gx_mode = sMode1;
      }

      protected void ScanKeyEnd011( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void AddRow011( )
      {
         VarsToRow1( bcwwpbaseobjects_UserCustomizations) ;
      }

      protected void ReadRow011( )
      {
         RowToVars1( bcwwpbaseobjects_UserCustomizations, 1) ;
      }

      protected void InitializeNonKey011( )
      {
         A3UserCustomizationsValue = "";
      }

      protected void InitAll011( )
      {
         A1UserCustomizationsId = "";
         A2UserCustomizationsKey = "";
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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

      public void VarsToRow1( GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations obj1 )
      {
         obj1.gxTpr_Mode = Gx_mode;
         obj1.gxTpr_Usercustomizationsvalue = A3UserCustomizationsValue;
         obj1.gxTpr_Usercustomizationsid = A1UserCustomizationsId;
         obj1.gxTpr_Usercustomizationskey = A2UserCustomizationsKey;
         obj1.gxTpr_Usercustomizationsid_Z = Z1UserCustomizationsId;
         obj1.gxTpr_Usercustomizationskey_Z = Z2UserCustomizationsKey;
         obj1.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow1( GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations obj1 )
      {
         obj1.gxTpr_Usercustomizationsid = A1UserCustomizationsId;
         obj1.gxTpr_Usercustomizationskey = A2UserCustomizationsKey;
         return  ;
      }

      public void RowToVars1( GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations obj1 ,
                              int forceLoad )
      {
         Gx_mode = obj1.gxTpr_Mode;
         A3UserCustomizationsValue = obj1.gxTpr_Usercustomizationsvalue;
         A1UserCustomizationsId = obj1.gxTpr_Usercustomizationsid;
         A2UserCustomizationsKey = obj1.gxTpr_Usercustomizationskey;
         Z1UserCustomizationsId = obj1.gxTpr_Usercustomizationsid_Z;
         Z2UserCustomizationsKey = obj1.gxTpr_Usercustomizationskey_Z;
         Gx_mode = obj1.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1UserCustomizationsId = (string)getParm(obj,0);
         A2UserCustomizationsKey = (string)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey011( ) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1UserCustomizationsId = A1UserCustomizationsId;
            Z2UserCustomizationsKey = A2UserCustomizationsKey;
         }
         ZM011( -1) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
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
         RowToVars1( bcwwpbaseobjects_UserCustomizations, 0) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1UserCustomizationsId = A1UserCustomizationsId;
            Z2UserCustomizationsKey = A2UserCustomizationsKey;
         }
         ZM011( -1) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert011( ) ;
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( ( StringUtil.StrCmp(A1UserCustomizationsId, Z1UserCustomizationsId) != 0 ) || ( StringUtil.StrCmp(A2UserCustomizationsKey, Z2UserCustomizationsKey) != 0 ) )
               {
                  A1UserCustomizationsId = Z1UserCustomizationsId;
                  A2UserCustomizationsKey = Z2UserCustomizationsKey;
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
                  Update011( ) ;
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
                  if ( ( StringUtil.StrCmp(A1UserCustomizationsId, Z1UserCustomizationsId) != 0 ) || ( StringUtil.StrCmp(A2UserCustomizationsKey, Z2UserCustomizationsKey) != 0 ) )
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
                        Insert011( ) ;
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
                        Insert011( ) ;
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
         RowToVars1( bcwwpbaseobjects_UserCustomizations, 1) ;
         SaveImpl( ) ;
         VarsToRow1( bcwwpbaseobjects_UserCustomizations) ;
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
         RowToVars1( bcwwpbaseobjects_UserCustomizations, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
         AfterTrn( ) ;
         VarsToRow1( bcwwpbaseobjects_UserCustomizations) ;
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
            GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations auxBC = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A1UserCustomizationsId, A2UserCustomizationsKey);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_UserCustomizations);
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
         RowToVars1( bcwwpbaseobjects_UserCustomizations, 1) ;
         UpdateImpl( ) ;
         VarsToRow1( bcwwpbaseobjects_UserCustomizations) ;
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
         RowToVars1( bcwwpbaseobjects_UserCustomizations, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
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
         VarsToRow1( bcwwpbaseobjects_UserCustomizations) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bcwwpbaseobjects_UserCustomizations, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey011( ) ;
         if ( RcdFound1 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( StringUtil.StrCmp(A1UserCustomizationsId, Z1UserCustomizationsId) != 0 ) || ( StringUtil.StrCmp(A2UserCustomizationsKey, Z2UserCustomizationsKey) != 0 ) )
            {
               A1UserCustomizationsId = Z1UserCustomizationsId;
               A2UserCustomizationsKey = Z2UserCustomizationsKey;
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
            if ( ( StringUtil.StrCmp(A1UserCustomizationsId, Z1UserCustomizationsId) != 0 ) || ( StringUtil.StrCmp(A2UserCustomizationsKey, Z2UserCustomizationsKey) != 0 ) )
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
         context.RollbackDataStores("wwpbaseobjects.usercustomizations_bc",pr_default);
         VarsToRow1( bcwwpbaseobjects_UserCustomizations) ;
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
         Gx_mode = bcwwpbaseobjects_UserCustomizations.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_UserCustomizations.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_UserCustomizations )
         {
            bcwwpbaseobjects_UserCustomizations = (GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_UserCustomizations.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_UserCustomizations.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow1( bcwwpbaseobjects_UserCustomizations) ;
            }
            else
            {
               RowToVars1( bcwwpbaseobjects_UserCustomizations, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_UserCustomizations.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_UserCustomizations.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars1( bcwwpbaseobjects_UserCustomizations, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtUserCustomizations UserCustomizations_BC
      {
         get {
            return bcwwpbaseobjects_UserCustomizations ;
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
            return "usercustomizations_Execute" ;
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
         Z1UserCustomizationsId = "";
         A1UserCustomizationsId = "";
         Z2UserCustomizationsKey = "";
         A2UserCustomizationsKey = "";
         Z3UserCustomizationsValue = "";
         A3UserCustomizationsValue = "";
         BC00014_A1UserCustomizationsId = new string[] {""} ;
         BC00014_A2UserCustomizationsKey = new string[] {""} ;
         BC00014_A3UserCustomizationsValue = new string[] {""} ;
         BC00015_A1UserCustomizationsId = new string[] {""} ;
         BC00015_A2UserCustomizationsKey = new string[] {""} ;
         BC00013_A1UserCustomizationsId = new string[] {""} ;
         BC00013_A2UserCustomizationsKey = new string[] {""} ;
         BC00013_A3UserCustomizationsValue = new string[] {""} ;
         sMode1 = "";
         BC00012_A1UserCustomizationsId = new string[] {""} ;
         BC00012_A2UserCustomizationsKey = new string[] {""} ;
         BC00012_A3UserCustomizationsValue = new string[] {""} ;
         BC00019_A1UserCustomizationsId = new string[] {""} ;
         BC00019_A2UserCustomizationsKey = new string[] {""} ;
         BC00019_A3UserCustomizationsValue = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.usercustomizations_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.usercustomizations_bc__default(),
            new Object[][] {
                new Object[] {
               BC00012_A1UserCustomizationsId, BC00012_A2UserCustomizationsKey, BC00012_A3UserCustomizationsValue
               }
               , new Object[] {
               BC00013_A1UserCustomizationsId, BC00013_A2UserCustomizationsKey, BC00013_A3UserCustomizationsValue
               }
               , new Object[] {
               BC00014_A1UserCustomizationsId, BC00014_A2UserCustomizationsKey, BC00014_A3UserCustomizationsValue
               }
               , new Object[] {
               BC00015_A1UserCustomizationsId, BC00015_A2UserCustomizationsKey
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00019_A1UserCustomizationsId, BC00019_A2UserCustomizationsKey, BC00019_A3UserCustomizationsValue
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound1 ;
      private short nIsDirty_1 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z1UserCustomizationsId ;
      private string A1UserCustomizationsId ;
      private string sMode1 ;
      private bool mustCommit ;
      private string Z3UserCustomizationsValue ;
      private string A3UserCustomizationsValue ;
      private string Z2UserCustomizationsKey ;
      private string A2UserCustomizationsKey ;
      private GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations bcwwpbaseobjects_UserCustomizations ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC00014_A1UserCustomizationsId ;
      private string[] BC00014_A2UserCustomizationsKey ;
      private string[] BC00014_A3UserCustomizationsValue ;
      private string[] BC00015_A1UserCustomizationsId ;
      private string[] BC00015_A2UserCustomizationsKey ;
      private string[] BC00013_A1UserCustomizationsId ;
      private string[] BC00013_A2UserCustomizationsKey ;
      private string[] BC00013_A3UserCustomizationsValue ;
      private string[] BC00012_A1UserCustomizationsId ;
      private string[] BC00012_A2UserCustomizationsKey ;
      private string[] BC00012_A3UserCustomizationsValue ;
      private string[] BC00019_A1UserCustomizationsId ;
      private string[] BC00019_A2UserCustomizationsKey ;
      private string[] BC00019_A3UserCustomizationsValue ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class usercustomizations_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class usercustomizations_bc__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new UpdateCursor(def[4])
       ,new UpdateCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new ForEachCursor(def[7])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00014;
        prmBC00014 = new Object[] {
        new ParDef("@UserCustomizationsId",GXType.NChar,40,0) ,
        new ParDef("@UserCustomizationsKey",GXType.NVarChar,200,0)
        };
        Object[] prmBC00015;
        prmBC00015 = new Object[] {
        new ParDef("@UserCustomizationsId",GXType.NChar,40,0) ,
        new ParDef("@UserCustomizationsKey",GXType.NVarChar,200,0)
        };
        Object[] prmBC00013;
        prmBC00013 = new Object[] {
        new ParDef("@UserCustomizationsId",GXType.NChar,40,0) ,
        new ParDef("@UserCustomizationsKey",GXType.NVarChar,200,0)
        };
        Object[] prmBC00012;
        prmBC00012 = new Object[] {
        new ParDef("@UserCustomizationsId",GXType.NChar,40,0) ,
        new ParDef("@UserCustomizationsKey",GXType.NVarChar,200,0)
        };
        Object[] prmBC00016;
        prmBC00016 = new Object[] {
        new ParDef("@UserCustomizationsId",GXType.NChar,40,0) ,
        new ParDef("@UserCustomizationsKey",GXType.NVarChar,200,0) ,
        new ParDef("@UserCustomizationsValue",GXType.NVarChar,2097152,0)
        };
        Object[] prmBC00017;
        prmBC00017 = new Object[] {
        new ParDef("@UserCustomizationsValue",GXType.NVarChar,2097152,0) ,
        new ParDef("@UserCustomizationsId",GXType.NChar,40,0) ,
        new ParDef("@UserCustomizationsKey",GXType.NVarChar,200,0)
        };
        Object[] prmBC00018;
        prmBC00018 = new Object[] {
        new ParDef("@UserCustomizationsId",GXType.NChar,40,0) ,
        new ParDef("@UserCustomizationsKey",GXType.NVarChar,200,0)
        };
        Object[] prmBC00019;
        prmBC00019 = new Object[] {
        new ParDef("@UserCustomizationsId",GXType.NChar,40,0) ,
        new ParDef("@UserCustomizationsKey",GXType.NVarChar,200,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00012", "SELECT [UserCustomizationsId], [UserCustomizationsKey], [UserCustomizationsValue] FROM [UserCustomizations] WITH (UPDLOCK) WHERE [UserCustomizationsId] = @UserCustomizationsId AND [UserCustomizationsKey] = @UserCustomizationsKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00012,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00013", "SELECT [UserCustomizationsId], [UserCustomizationsKey], [UserCustomizationsValue] FROM [UserCustomizations] WHERE [UserCustomizationsId] = @UserCustomizationsId AND [UserCustomizationsKey] = @UserCustomizationsKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00013,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00014", "SELECT TM1.[UserCustomizationsId], TM1.[UserCustomizationsKey], TM1.[UserCustomizationsValue] FROM [UserCustomizations] TM1 WHERE TM1.[UserCustomizationsId] = @UserCustomizationsId and TM1.[UserCustomizationsKey] = @UserCustomizationsKey ORDER BY TM1.[UserCustomizationsId], TM1.[UserCustomizationsKey]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00014,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00015", "SELECT [UserCustomizationsId], [UserCustomizationsKey] FROM [UserCustomizations] WHERE [UserCustomizationsId] = @UserCustomizationsId AND [UserCustomizationsKey] = @UserCustomizationsKey  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00015,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00016", "INSERT INTO [UserCustomizations]([UserCustomizationsId], [UserCustomizationsKey], [UserCustomizationsValue]) VALUES(@UserCustomizationsId, @UserCustomizationsKey, @UserCustomizationsValue)", GxErrorMask.GX_NOMASK,prmBC00016)
           ,new CursorDef("BC00017", "UPDATE [UserCustomizations] SET [UserCustomizationsValue]=@UserCustomizationsValue  WHERE [UserCustomizationsId] = @UserCustomizationsId AND [UserCustomizationsKey] = @UserCustomizationsKey", GxErrorMask.GX_NOMASK,prmBC00017)
           ,new CursorDef("BC00018", "DELETE FROM [UserCustomizations]  WHERE [UserCustomizationsId] = @UserCustomizationsId AND [UserCustomizationsKey] = @UserCustomizationsKey", GxErrorMask.GX_NOMASK,prmBC00018)
           ,new CursorDef("BC00019", "SELECT TM1.[UserCustomizationsId], TM1.[UserCustomizationsKey], TM1.[UserCustomizationsValue] FROM [UserCustomizations] TM1 WHERE TM1.[UserCustomizationsId] = @UserCustomizationsId and TM1.[UserCustomizationsKey] = @UserCustomizationsKey ORDER BY TM1.[UserCustomizationsId], TM1.[UserCustomizationsKey]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00019,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
     }
  }

}

}
