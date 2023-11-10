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
   public class persona_bc : GXHttpHandler, IGxSilentTrn
   {
      public persona_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public persona_bc( IGxContext context )
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
         ReadRow055( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey055( ) ;
         standaloneModal( ) ;
         AddRow055( ) ;
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
            E11052 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z13PersonaId = A13PersonaId;
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

      protected void CONFIRM_050( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls055( ) ;
            }
            else
            {
               CheckExtendedTable055( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors055( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12052( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV30Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV31GXV1 = 1;
            while ( AV31GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV31GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ControladorId") == 0 )
               {
                  AV13Insert_ControladorId = (int)(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               AV31GXV1 = (int)(AV31GXV1+1);
            }
         }
      }

      protected void E11052( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV25IsPersona = true;
         AV26PersonaId_Out = A13PersonaId;
      }

      protected void ZM055( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z14PersonaNome = A14PersonaNome;
            Z15PersonaAtivo = A15PersonaAtivo;
         }
         if ( GX_JID == -8 )
         {
            Z13PersonaId = A13PersonaId;
            Z14PersonaNome = A14PersonaNome;
            Z15PersonaAtivo = A15PersonaAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         AV30Pgmname = "Persona_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A15PersonaAtivo) && ( Gx_BScreen == 0 ) )
         {
            A15PersonaAtivo = true;
         }
      }

      protected void Load055( )
      {
         /* Using cursor BC00054 */
         pr_default.execute(2, new Object[] {n13PersonaId, A13PersonaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound5 = 1;
            A14PersonaNome = BC00054_A14PersonaNome[0];
            A15PersonaAtivo = BC00054_A15PersonaAtivo[0];
            ZM055( -8) ;
         }
         pr_default.close(2);
         OnLoadActions055( ) ;
      }

      protected void OnLoadActions055( )
      {
         A14PersonaNome = StringUtil.Upper( A14PersonaNome);
         GXt_boolean1 = AV28IsOk;
         new validanome(context ).execute(  "Persona",  A13PersonaId,  A14PersonaNome, out  GXt_boolean1) ;
         AV28IsOk = GXt_boolean1;
      }

      protected void CheckExtendedTable055( )
      {
         nIsDirty_5 = 0;
         standaloneModal( ) ;
         nIsDirty_5 = 1;
         A14PersonaNome = StringUtil.Upper( A14PersonaNome);
         GXt_boolean1 = AV28IsOk;
         new validanome(context ).execute(  "Persona",  A13PersonaId,  A14PersonaNome, out  GXt_boolean1) ;
         AV28IsOk = GXt_boolean1;
         if ( ! AV28IsOk )
         {
            GX_msglist.addItem("O nome inserido já existe.", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A14PersonaNome)) )
         {
            GX_msglist.addItem("Informe o nome da Persona.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors055( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey055( )
      {
         /* Using cursor BC00055 */
         pr_default.execute(3, new Object[] {n13PersonaId, A13PersonaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00053 */
         pr_default.execute(1, new Object[] {n13PersonaId, A13PersonaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM055( 8) ;
            RcdFound5 = 1;
            A13PersonaId = BC00053_A13PersonaId[0];
            n13PersonaId = BC00053_n13PersonaId[0];
            A14PersonaNome = BC00053_A14PersonaNome[0];
            A15PersonaAtivo = BC00053_A15PersonaAtivo[0];
            Z13PersonaId = A13PersonaId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load055( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey055( ) ;
            }
            Gx_mode = sMode5;
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey055( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode5;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey055( ) ;
         if ( RcdFound5 == 0 )
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
         CONFIRM_050( ) ;
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

      protected void CheckOptimisticConcurrency055( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00052 */
            pr_default.execute(0, new Object[] {n13PersonaId, A13PersonaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Persona"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z14PersonaNome, BC00052_A14PersonaNome[0]) != 0 ) || ( Z15PersonaAtivo != BC00052_A15PersonaAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Persona"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM055( 0) ;
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00056 */
                     pr_default.execute(4, new Object[] {A14PersonaNome, A15PersonaAtivo});
                     A13PersonaId = BC00056_A13PersonaId[0];
                     n13PersonaId = BC00056_n13PersonaId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("Persona");
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
               Load055( ) ;
            }
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void Update055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00057 */
                     pr_default.execute(5, new Object[] {A14PersonaNome, A15PersonaAtivo, n13PersonaId, A13PersonaId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("Persona");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Persona"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate055( ) ;
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
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void DeferredUpdate055( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls055( ) ;
            AfterConfirm055( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete055( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00058 */
                  pr_default.execute(6, new Object[] {n13PersonaId, A13PersonaId});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("Persona");
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
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel055( ) ;
         Gx_mode = sMode5;
      }

      protected void OnDeleteControls055( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_boolean1 = AV28IsOk;
            new validanome(context ).execute(  "Persona",  A13PersonaId,  A14PersonaNome, out  GXt_boolean1) ;
            AV28IsOk = GXt_boolean1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC00059 */
            pr_default.execute(7, new Object[] {n13PersonaId, A13PersonaId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel055( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete055( ) ;
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

      public void ScanKeyStart055( )
      {
         /* Scan By routine */
         /* Using cursor BC000510 */
         pr_default.execute(8, new Object[] {n13PersonaId, A13PersonaId});
         RcdFound5 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound5 = 1;
            A13PersonaId = BC000510_A13PersonaId[0];
            n13PersonaId = BC000510_n13PersonaId[0];
            A14PersonaNome = BC000510_A14PersonaNome[0];
            A15PersonaAtivo = BC000510_A15PersonaAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext055( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound5 = 0;
         ScanKeyLoad055( ) ;
      }

      protected void ScanKeyLoad055( )
      {
         sMode5 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound5 = 1;
            A13PersonaId = BC000510_A13PersonaId[0];
            n13PersonaId = BC000510_n13PersonaId[0];
            A14PersonaNome = BC000510_A14PersonaNome[0];
            A15PersonaAtivo = BC000510_A15PersonaAtivo[0];
         }
         Gx_mode = sMode5;
      }

      protected void ScanKeyEnd055( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm055( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert055( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate055( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete055( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete055( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate055( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes055( )
      {
      }

      protected void send_integrity_lvl_hashes055( )
      {
      }

      protected void AddRow055( )
      {
         VarsToRow5( bcPersona) ;
      }

      protected void ReadRow055( )
      {
         RowToVars5( bcPersona, 1) ;
      }

      protected void InitializeNonKey055( )
      {
         A14PersonaNome = "";
         AV28IsOk = false;
         A15PersonaAtivo = true;
         Z14PersonaNome = "";
         Z15PersonaAtivo = false;
      }

      protected void InitAll055( )
      {
         A13PersonaId = 0;
         n13PersonaId = false;
         InitializeNonKey055( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A15PersonaAtivo = i15PersonaAtivo;
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

      public void VarsToRow5( SdtPersona obj5 )
      {
         obj5.gxTpr_Mode = Gx_mode;
         obj5.gxTpr_Personanome = A14PersonaNome;
         obj5.gxTpr_Personaativo = A15PersonaAtivo;
         obj5.gxTpr_Personaid = A13PersonaId;
         obj5.gxTpr_Personaid_Z = Z13PersonaId;
         obj5.gxTpr_Personanome_Z = Z14PersonaNome;
         obj5.gxTpr_Personaativo_Z = Z15PersonaAtivo;
         obj5.gxTpr_Personaid_N = (short)(Convert.ToInt16(n13PersonaId));
         obj5.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow5( SdtPersona obj5 )
      {
         obj5.gxTpr_Personaid = A13PersonaId;
         return  ;
      }

      public void RowToVars5( SdtPersona obj5 ,
                              int forceLoad )
      {
         Gx_mode = obj5.gxTpr_Mode;
         A14PersonaNome = obj5.gxTpr_Personanome;
         A15PersonaAtivo = obj5.gxTpr_Personaativo;
         A13PersonaId = obj5.gxTpr_Personaid;
         n13PersonaId = false;
         Z13PersonaId = obj5.gxTpr_Personaid_Z;
         Z14PersonaNome = obj5.gxTpr_Personanome_Z;
         Z15PersonaAtivo = obj5.gxTpr_Personaativo_Z;
         n13PersonaId = (bool)(Convert.ToBoolean(obj5.gxTpr_Personaid_N));
         Gx_mode = obj5.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A13PersonaId = (int)getParm(obj,0);
         n13PersonaId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey055( ) ;
         ScanKeyStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z13PersonaId = A13PersonaId;
         }
         ZM055( -8) ;
         OnLoadActions055( ) ;
         AddRow055( ) ;
         ScanKeyEnd055( ) ;
         if ( RcdFound5 == 0 )
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
         RowToVars5( bcPersona, 0) ;
         ScanKeyStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z13PersonaId = A13PersonaId;
         }
         ZM055( -8) ;
         OnLoadActions055( ) ;
         AddRow055( ) ;
         ScanKeyEnd055( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey055( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert055( ) ;
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A13PersonaId != Z13PersonaId )
               {
                  A13PersonaId = Z13PersonaId;
                  n13PersonaId = false;
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
                  Update055( ) ;
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
                  if ( A13PersonaId != Z13PersonaId )
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
                        Insert055( ) ;
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
                        Insert055( ) ;
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
         RowToVars5( bcPersona, 1) ;
         SaveImpl( ) ;
         VarsToRow5( bcPersona) ;
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
         RowToVars5( bcPersona, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert055( ) ;
         AfterTrn( ) ;
         VarsToRow5( bcPersona) ;
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
            SdtPersona auxBC = new SdtPersona(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A13PersonaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPersona);
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
         RowToVars5( bcPersona, 1) ;
         UpdateImpl( ) ;
         VarsToRow5( bcPersona) ;
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
         RowToVars5( bcPersona, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert055( ) ;
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
         VarsToRow5( bcPersona) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars5( bcPersona, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey055( ) ;
         if ( RcdFound5 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A13PersonaId != Z13PersonaId )
            {
               A13PersonaId = Z13PersonaId;
               n13PersonaId = false;
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
            if ( A13PersonaId != Z13PersonaId )
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
         context.RollbackDataStores("persona_bc",pr_default);
         VarsToRow5( bcPersona) ;
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
         Gx_mode = bcPersona.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPersona.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPersona )
         {
            bcPersona = (SdtPersona)(sdt);
            if ( StringUtil.StrCmp(bcPersona.gxTpr_Mode, "") == 0 )
            {
               bcPersona.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow5( bcPersona) ;
            }
            else
            {
               RowToVars5( bcPersona, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPersona.gxTpr_Mode, "") == 0 )
            {
               bcPersona.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars5( bcPersona, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtPersona Persona_BC
      {
         get {
            return bcPersona ;
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
            return "persona_Execute" ;
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
         AV30Pgmname = "";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z14PersonaNome = "";
         A14PersonaNome = "";
         BC00054_A13PersonaId = new int[1] ;
         BC00054_n13PersonaId = new bool[] {false} ;
         BC00054_A14PersonaNome = new string[] {""} ;
         BC00054_A15PersonaAtivo = new bool[] {false} ;
         BC00055_A13PersonaId = new int[1] ;
         BC00055_n13PersonaId = new bool[] {false} ;
         BC00053_A13PersonaId = new int[1] ;
         BC00053_n13PersonaId = new bool[] {false} ;
         BC00053_A14PersonaNome = new string[] {""} ;
         BC00053_A15PersonaAtivo = new bool[] {false} ;
         sMode5 = "";
         BC00052_A13PersonaId = new int[1] ;
         BC00052_n13PersonaId = new bool[] {false} ;
         BC00052_A14PersonaNome = new string[] {""} ;
         BC00052_A15PersonaAtivo = new bool[] {false} ;
         BC00056_A13PersonaId = new int[1] ;
         BC00056_n13PersonaId = new bool[] {false} ;
         BC00059_A75DocumentoId = new int[1] ;
         BC000510_A13PersonaId = new int[1] ;
         BC000510_n13PersonaId = new bool[] {false} ;
         BC000510_A14PersonaNome = new string[] {""} ;
         BC000510_A15PersonaAtivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.persona_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.persona_bc__default(),
            new Object[][] {
                new Object[] {
               BC00052_A13PersonaId, BC00052_A14PersonaNome, BC00052_A15PersonaAtivo
               }
               , new Object[] {
               BC00053_A13PersonaId, BC00053_A14PersonaNome, BC00053_A15PersonaAtivo
               }
               , new Object[] {
               BC00054_A13PersonaId, BC00054_A14PersonaNome, BC00054_A15PersonaAtivo
               }
               , new Object[] {
               BC00055_A13PersonaId
               }
               , new Object[] {
               BC00056_A13PersonaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00059_A75DocumentoId
               }
               , new Object[] {
               BC000510_A13PersonaId, BC000510_A14PersonaNome, BC000510_A15PersonaAtivo
               }
            }
         );
         AV30Pgmname = "Persona_BC";
         Z15PersonaAtivo = true;
         A15PersonaAtivo = true;
         i15PersonaAtivo = true;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12052 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound5 ;
      private short nIsDirty_5 ;
      private int trnEnded ;
      private int Z13PersonaId ;
      private int A13PersonaId ;
      private int AV31GXV1 ;
      private int AV13Insert_ControladorId ;
      private int AV26PersonaId_Out ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV30Pgmname ;
      private string sMode5 ;
      private bool returnInSub ;
      private bool AV25IsPersona ;
      private bool Z15PersonaAtivo ;
      private bool A15PersonaAtivo ;
      private bool n13PersonaId ;
      private bool AV28IsOk ;
      private bool GXt_boolean1 ;
      private bool i15PersonaAtivo ;
      private bool mustCommit ;
      private string Z14PersonaNome ;
      private string A14PersonaNome ;
      private IGxSession AV12WebSession ;
      private SdtPersona bcPersona ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00054_A13PersonaId ;
      private bool[] BC00054_n13PersonaId ;
      private string[] BC00054_A14PersonaNome ;
      private bool[] BC00054_A15PersonaAtivo ;
      private int[] BC00055_A13PersonaId ;
      private bool[] BC00055_n13PersonaId ;
      private int[] BC00053_A13PersonaId ;
      private bool[] BC00053_n13PersonaId ;
      private string[] BC00053_A14PersonaNome ;
      private bool[] BC00053_A15PersonaAtivo ;
      private int[] BC00052_A13PersonaId ;
      private bool[] BC00052_n13PersonaId ;
      private string[] BC00052_A14PersonaNome ;
      private bool[] BC00052_A15PersonaAtivo ;
      private int[] BC00056_A13PersonaId ;
      private bool[] BC00056_n13PersonaId ;
      private int[] BC00059_A75DocumentoId ;
      private int[] BC000510_A13PersonaId ;
      private bool[] BC000510_n13PersonaId ;
      private string[] BC000510_A14PersonaNome ;
      private bool[] BC000510_A15PersonaAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
   }

   public class persona_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class persona_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC00054;
        prmBC00054 = new Object[] {
        new ParDef("@PersonaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00055;
        prmBC00055 = new Object[] {
        new ParDef("@PersonaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00053;
        prmBC00053 = new Object[] {
        new ParDef("@PersonaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00052;
        prmBC00052 = new Object[] {
        new ParDef("@PersonaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00056;
        prmBC00056 = new Object[] {
        new ParDef("@PersonaNome",GXType.NVarChar,100,0) ,
        new ParDef("@PersonaAtivo",GXType.Boolean,4,0)
        };
        Object[] prmBC00057;
        prmBC00057 = new Object[] {
        new ParDef("@PersonaNome",GXType.NVarChar,100,0) ,
        new ParDef("@PersonaAtivo",GXType.Boolean,4,0) ,
        new ParDef("@PersonaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00058;
        prmBC00058 = new Object[] {
        new ParDef("@PersonaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC00059;
        prmBC00059 = new Object[] {
        new ParDef("@PersonaId",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC000510;
        prmBC000510 = new Object[] {
        new ParDef("@PersonaId",GXType.Int32,8,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC00052", "SELECT [PersonaId], [PersonaNome], [PersonaAtivo] FROM [Persona] WITH (UPDLOCK) WHERE [PersonaId] = @PersonaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00052,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00053", "SELECT [PersonaId], [PersonaNome], [PersonaAtivo] FROM [Persona] WHERE [PersonaId] = @PersonaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00053,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00054", "SELECT TM1.[PersonaId], TM1.[PersonaNome], TM1.[PersonaAtivo] FROM [Persona] TM1 WHERE TM1.[PersonaId] = @PersonaId ORDER BY TM1.[PersonaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00054,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00055", "SELECT [PersonaId] FROM [Persona] WHERE [PersonaId] = @PersonaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00055,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00056", "INSERT INTO [Persona]([PersonaNome], [PersonaAtivo]) VALUES(@PersonaNome, @PersonaAtivo); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00056,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC00057", "UPDATE [Persona] SET [PersonaNome]=@PersonaNome, [PersonaAtivo]=@PersonaAtivo  WHERE [PersonaId] = @PersonaId", GxErrorMask.GX_NOMASK,prmBC00057)
           ,new CursorDef("BC00058", "DELETE FROM [Persona]  WHERE [PersonaId] = @PersonaId", GxErrorMask.GX_NOMASK,prmBC00058)
           ,new CursorDef("BC00059", "SELECT TOP 1 [DocumentoId] FROM [Documento] WHERE [PersonaId] = @PersonaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00059,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000510", "SELECT TM1.[PersonaId], TM1.[PersonaNome], TM1.[PersonaAtivo] FROM [Persona] TM1 WHERE TM1.[PersonaId] = @PersonaId ORDER BY TM1.[PersonaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000510,100, GxCacheFrequency.OFF ,true,false )
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
