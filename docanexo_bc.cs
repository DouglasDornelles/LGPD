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
   public class docanexo_bc : GXHttpHandler, IGxSilentTrn
   {
      public docanexo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public docanexo_bc( IGxContext context )
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
         ReadRow1952( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1952( ) ;
         standaloneModal( ) ;
         AddRow1952( ) ;
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
            E11192 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z93DocAnexoId = A93DocAnexoId;
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

      protected void CONFIRM_190( )
      {
         BeforeValidate1952( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1952( ) ;
            }
            else
            {
               CheckExtendedTable1952( ) ;
               if ( AnyError == 0 )
               {
                  ZM1952( 8) ;
               }
               CloseExtendedTableCursors1952( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12192( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV24Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV25GXV1 = 1;
            while ( AV25GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV25GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "DocumentoId") == 0 )
               {
                  AV13Insert_DocumentoId = (int)(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               AV25GXV1 = (int)(AV25GXV1+1);
            }
         }
      }

      protected void E11192( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1952( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z94DocAnexoDescricao = A94DocAnexoDescricao;
            Z95DocAnexoArquivo = A95DocAnexoArquivo;
            Z96DocAnexoDataInclusao = A96DocAnexoDataInclusao;
            Z75DocumentoId = A75DocumentoId;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z76DocumentoNome = A76DocumentoNome;
         }
         if ( GX_JID == -7 )
         {
            Z93DocAnexoId = A93DocAnexoId;
            Z94DocAnexoDescricao = A94DocAnexoDescricao;
            Z95DocAnexoArquivo = A95DocAnexoArquivo;
            Z96DocAnexoDataInclusao = A96DocAnexoDataInclusao;
            Z75DocumentoId = A75DocumentoId;
            Z76DocumentoNome = A76DocumentoNome;
         }
      }

      protected void standaloneNotModal( )
      {
         AV24Pgmname = "DocAnexo_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A96DocAnexoDataInclusao) && ( Gx_BScreen == 0 ) )
         {
            A96DocAnexoDataInclusao = DateTimeUtil.Today( context);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1952( )
      {
         /* Using cursor BC00195 */
         pr_default.execute(3, new Object[] {A93DocAnexoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound52 = 1;
            A94DocAnexoDescricao = BC00195_A94DocAnexoDescricao[0];
            A95DocAnexoArquivo = BC00195_A95DocAnexoArquivo[0];
            A96DocAnexoDataInclusao = BC00195_A96DocAnexoDataInclusao[0];
            A76DocumentoNome = BC00195_A76DocumentoNome[0];
            n76DocumentoNome = BC00195_n76DocumentoNome[0];
            A75DocumentoId = BC00195_A75DocumentoId[0];
            ZM1952( -7) ;
         }
         pr_default.close(3);
         OnLoadActions1952( ) ;
      }

      protected void OnLoadActions1952( )
      {
         A94DocAnexoDescricao = StringUtil.Upper( A94DocAnexoDescricao);
         A95DocAnexoArquivo = StringUtil.Upper( A95DocAnexoArquivo);
      }

      protected void CheckExtendedTable1952( )
      {
         nIsDirty_52 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00194 */
         pr_default.execute(2, new Object[] {A75DocumentoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCUMENTOID");
            AnyError = 1;
         }
         A76DocumentoNome = BC00194_A76DocumentoNome[0];
         n76DocumentoNome = BC00194_n76DocumentoNome[0];
         pr_default.close(2);
         nIsDirty_52 = 1;
         A94DocAnexoDescricao = StringUtil.Upper( A94DocAnexoDescricao);
         nIsDirty_52 = 1;
         A95DocAnexoArquivo = StringUtil.Upper( A95DocAnexoArquivo);
         if ( ! ( (DateTime.MinValue==A96DocAnexoDataInclusao) || ( DateTimeUtil.ResetTime ( A96DocAnexoDataInclusao ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Data de Inclusão fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1952( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1952( )
      {
         /* Using cursor BC00196 */
         pr_default.execute(4, new Object[] {A93DocAnexoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound52 = 1;
         }
         else
         {
            RcdFound52 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00193 */
         pr_default.execute(1, new Object[] {A93DocAnexoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1952( 7) ;
            RcdFound52 = 1;
            A93DocAnexoId = BC00193_A93DocAnexoId[0];
            A94DocAnexoDescricao = BC00193_A94DocAnexoDescricao[0];
            A95DocAnexoArquivo = BC00193_A95DocAnexoArquivo[0];
            A96DocAnexoDataInclusao = BC00193_A96DocAnexoDataInclusao[0];
            A75DocumentoId = BC00193_A75DocumentoId[0];
            Z93DocAnexoId = A93DocAnexoId;
            sMode52 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1952( ) ;
            if ( AnyError == 1 )
            {
               RcdFound52 = 0;
               InitializeNonKey1952( ) ;
            }
            Gx_mode = sMode52;
         }
         else
         {
            RcdFound52 = 0;
            InitializeNonKey1952( ) ;
            sMode52 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode52;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1952( ) ;
         if ( RcdFound52 == 0 )
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
         CONFIRM_190( ) ;
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

      protected void CheckOptimisticConcurrency1952( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00192 */
            pr_default.execute(0, new Object[] {A93DocAnexoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DocAnexo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z94DocAnexoDescricao, BC00192_A94DocAnexoDescricao[0]) != 0 ) || ( StringUtil.StrCmp(Z95DocAnexoArquivo, BC00192_A95DocAnexoArquivo[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z96DocAnexoDataInclusao ) != DateTimeUtil.ResetTime ( BC00192_A96DocAnexoDataInclusao[0] ) ) || ( Z75DocumentoId != BC00192_A75DocumentoId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DocAnexo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1952( )
      {
         BeforeValidate1952( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1952( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1952( 0) ;
            CheckOptimisticConcurrency1952( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1952( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1952( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00197 */
                     pr_default.execute(5, new Object[] {A94DocAnexoDescricao, A95DocAnexoArquivo, A96DocAnexoDataInclusao, A75DocumentoId});
                     A93DocAnexoId = BC00197_A93DocAnexoId[0];
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("DocAnexo");
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
               Load1952( ) ;
            }
            EndLevel1952( ) ;
         }
         CloseExtendedTableCursors1952( ) ;
      }

      protected void Update1952( )
      {
         BeforeValidate1952( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1952( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1952( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1952( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1952( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00198 */
                     pr_default.execute(6, new Object[] {A94DocAnexoDescricao, A95DocAnexoArquivo, A96DocAnexoDataInclusao, A75DocumentoId, A93DocAnexoId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("DocAnexo");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DocAnexo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1952( ) ;
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
            EndLevel1952( ) ;
         }
         CloseExtendedTableCursors1952( ) ;
      }

      protected void DeferredUpdate1952( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1952( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1952( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1952( ) ;
            AfterConfirm1952( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1952( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00199 */
                  pr_default.execute(7, new Object[] {A93DocAnexoId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("DocAnexo");
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
         sMode52 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1952( ) ;
         Gx_mode = sMode52;
      }

      protected void OnDeleteControls1952( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001910 */
            pr_default.execute(8, new Object[] {A75DocumentoId});
            A76DocumentoNome = BC001910_A76DocumentoNome[0];
            n76DocumentoNome = BC001910_n76DocumentoNome[0];
            pr_default.close(8);
         }
      }

      protected void EndLevel1952( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1952( ) ;
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

      public void ScanKeyStart1952( )
      {
         /* Scan By routine */
         /* Using cursor BC001911 */
         pr_default.execute(9, new Object[] {A93DocAnexoId});
         RcdFound52 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound52 = 1;
            A93DocAnexoId = BC001911_A93DocAnexoId[0];
            A94DocAnexoDescricao = BC001911_A94DocAnexoDescricao[0];
            A95DocAnexoArquivo = BC001911_A95DocAnexoArquivo[0];
            A96DocAnexoDataInclusao = BC001911_A96DocAnexoDataInclusao[0];
            A76DocumentoNome = BC001911_A76DocumentoNome[0];
            n76DocumentoNome = BC001911_n76DocumentoNome[0];
            A75DocumentoId = BC001911_A75DocumentoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1952( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound52 = 0;
         ScanKeyLoad1952( ) ;
      }

      protected void ScanKeyLoad1952( )
      {
         sMode52 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound52 = 1;
            A93DocAnexoId = BC001911_A93DocAnexoId[0];
            A94DocAnexoDescricao = BC001911_A94DocAnexoDescricao[0];
            A95DocAnexoArquivo = BC001911_A95DocAnexoArquivo[0];
            A96DocAnexoDataInclusao = BC001911_A96DocAnexoDataInclusao[0];
            A76DocumentoNome = BC001911_A76DocumentoNome[0];
            n76DocumentoNome = BC001911_n76DocumentoNome[0];
            A75DocumentoId = BC001911_A75DocumentoId[0];
         }
         Gx_mode = sMode52;
      }

      protected void ScanKeyEnd1952( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1952( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1952( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1952( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1952( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1952( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1952( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1952( )
      {
      }

      protected void send_integrity_lvl_hashes1952( )
      {
      }

      protected void AddRow1952( )
      {
         VarsToRow52( bcDocAnexo) ;
      }

      protected void ReadRow1952( )
      {
         RowToVars52( bcDocAnexo, 1) ;
      }

      protected void InitializeNonKey1952( )
      {
         A94DocAnexoDescricao = "";
         A95DocAnexoArquivo = "";
         A75DocumentoId = 0;
         A76DocumentoNome = "";
         n76DocumentoNome = false;
         A96DocAnexoDataInclusao = DateTimeUtil.Today( context);
         Z94DocAnexoDescricao = "";
         Z95DocAnexoArquivo = "";
         Z96DocAnexoDataInclusao = DateTime.MinValue;
         Z75DocumentoId = 0;
      }

      protected void InitAll1952( )
      {
         A93DocAnexoId = 0;
         InitializeNonKey1952( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A96DocAnexoDataInclusao = i96DocAnexoDataInclusao;
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

      public void VarsToRow52( SdtDocAnexo obj52 )
      {
         obj52.gxTpr_Mode = Gx_mode;
         obj52.gxTpr_Docanexodescricao = A94DocAnexoDescricao;
         obj52.gxTpr_Docanexoarquivo = A95DocAnexoArquivo;
         obj52.gxTpr_Documentoid = A75DocumentoId;
         obj52.gxTpr_Documentonome = A76DocumentoNome;
         obj52.gxTpr_Docanexodatainclusao = A96DocAnexoDataInclusao;
         obj52.gxTpr_Docanexoid = A93DocAnexoId;
         obj52.gxTpr_Docanexoid_Z = Z93DocAnexoId;
         obj52.gxTpr_Documentoid_Z = Z75DocumentoId;
         obj52.gxTpr_Docanexodescricao_Z = Z94DocAnexoDescricao;
         obj52.gxTpr_Docanexoarquivo_Z = Z95DocAnexoArquivo;
         obj52.gxTpr_Docanexodatainclusao_Z = Z96DocAnexoDataInclusao;
         obj52.gxTpr_Documentonome_Z = Z76DocumentoNome;
         obj52.gxTpr_Documentonome_N = (short)(Convert.ToInt16(n76DocumentoNome));
         obj52.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow52( SdtDocAnexo obj52 )
      {
         obj52.gxTpr_Docanexoid = A93DocAnexoId;
         return  ;
      }

      public void RowToVars52( SdtDocAnexo obj52 ,
                               int forceLoad )
      {
         Gx_mode = obj52.gxTpr_Mode;
         A94DocAnexoDescricao = obj52.gxTpr_Docanexodescricao;
         A95DocAnexoArquivo = obj52.gxTpr_Docanexoarquivo;
         A75DocumentoId = obj52.gxTpr_Documentoid;
         A76DocumentoNome = obj52.gxTpr_Documentonome;
         n76DocumentoNome = false;
         A96DocAnexoDataInclusao = obj52.gxTpr_Docanexodatainclusao;
         A93DocAnexoId = obj52.gxTpr_Docanexoid;
         Z93DocAnexoId = obj52.gxTpr_Docanexoid_Z;
         Z75DocumentoId = obj52.gxTpr_Documentoid_Z;
         Z94DocAnexoDescricao = obj52.gxTpr_Docanexodescricao_Z;
         Z95DocAnexoArquivo = obj52.gxTpr_Docanexoarquivo_Z;
         Z96DocAnexoDataInclusao = obj52.gxTpr_Docanexodatainclusao_Z;
         Z76DocumentoNome = obj52.gxTpr_Documentonome_Z;
         n76DocumentoNome = (bool)(Convert.ToBoolean(obj52.gxTpr_Documentonome_N));
         Gx_mode = obj52.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A93DocAnexoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1952( ) ;
         ScanKeyStart1952( ) ;
         if ( RcdFound52 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z93DocAnexoId = A93DocAnexoId;
         }
         ZM1952( -7) ;
         OnLoadActions1952( ) ;
         AddRow1952( ) ;
         ScanKeyEnd1952( ) ;
         if ( RcdFound52 == 0 )
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
         RowToVars52( bcDocAnexo, 0) ;
         ScanKeyStart1952( ) ;
         if ( RcdFound52 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z93DocAnexoId = A93DocAnexoId;
         }
         ZM1952( -7) ;
         OnLoadActions1952( ) ;
         AddRow1952( ) ;
         ScanKeyEnd1952( ) ;
         if ( RcdFound52 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey1952( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1952( ) ;
         }
         else
         {
            if ( RcdFound52 == 1 )
            {
               if ( A93DocAnexoId != Z93DocAnexoId )
               {
                  A93DocAnexoId = Z93DocAnexoId;
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
                  Update1952( ) ;
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
                  if ( A93DocAnexoId != Z93DocAnexoId )
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
                        Insert1952( ) ;
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
                        Insert1952( ) ;
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
         RowToVars52( bcDocAnexo, 1) ;
         SaveImpl( ) ;
         VarsToRow52( bcDocAnexo) ;
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
         RowToVars52( bcDocAnexo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1952( ) ;
         AfterTrn( ) ;
         VarsToRow52( bcDocAnexo) ;
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
            SdtDocAnexo auxBC = new SdtDocAnexo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A93DocAnexoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcDocAnexo);
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
         RowToVars52( bcDocAnexo, 1) ;
         UpdateImpl( ) ;
         VarsToRow52( bcDocAnexo) ;
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
         RowToVars52( bcDocAnexo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1952( ) ;
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
         VarsToRow52( bcDocAnexo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars52( bcDocAnexo, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey1952( ) ;
         if ( RcdFound52 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A93DocAnexoId != Z93DocAnexoId )
            {
               A93DocAnexoId = Z93DocAnexoId;
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
            if ( A93DocAnexoId != Z93DocAnexoId )
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
         context.RollbackDataStores("docanexo_bc",pr_default);
         VarsToRow52( bcDocAnexo) ;
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
         Gx_mode = bcDocAnexo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcDocAnexo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcDocAnexo )
         {
            bcDocAnexo = (SdtDocAnexo)(sdt);
            if ( StringUtil.StrCmp(bcDocAnexo.gxTpr_Mode, "") == 0 )
            {
               bcDocAnexo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow52( bcDocAnexo) ;
            }
            else
            {
               RowToVars52( bcDocAnexo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcDocAnexo.gxTpr_Mode, "") == 0 )
            {
               bcDocAnexo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars52( bcDocAnexo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtDocAnexo DocAnexo_BC
      {
         get {
            return bcDocAnexo ;
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
            return "docanexo_Execute" ;
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
         AV24Pgmname = "";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z94DocAnexoDescricao = "";
         A94DocAnexoDescricao = "";
         Z95DocAnexoArquivo = "";
         A95DocAnexoArquivo = "";
         Z96DocAnexoDataInclusao = DateTime.MinValue;
         A96DocAnexoDataInclusao = DateTime.MinValue;
         Z76DocumentoNome = "";
         A76DocumentoNome = "";
         BC00195_A93DocAnexoId = new int[1] ;
         BC00195_A94DocAnexoDescricao = new string[] {""} ;
         BC00195_A95DocAnexoArquivo = new string[] {""} ;
         BC00195_A96DocAnexoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         BC00195_A76DocumentoNome = new string[] {""} ;
         BC00195_n76DocumentoNome = new bool[] {false} ;
         BC00195_A75DocumentoId = new int[1] ;
         BC00194_A76DocumentoNome = new string[] {""} ;
         BC00194_n76DocumentoNome = new bool[] {false} ;
         BC00196_A93DocAnexoId = new int[1] ;
         BC00193_A93DocAnexoId = new int[1] ;
         BC00193_A94DocAnexoDescricao = new string[] {""} ;
         BC00193_A95DocAnexoArquivo = new string[] {""} ;
         BC00193_A96DocAnexoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         BC00193_A75DocumentoId = new int[1] ;
         sMode52 = "";
         BC00192_A93DocAnexoId = new int[1] ;
         BC00192_A94DocAnexoDescricao = new string[] {""} ;
         BC00192_A95DocAnexoArquivo = new string[] {""} ;
         BC00192_A96DocAnexoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         BC00192_A75DocumentoId = new int[1] ;
         BC00197_A93DocAnexoId = new int[1] ;
         BC001910_A76DocumentoNome = new string[] {""} ;
         BC001910_n76DocumentoNome = new bool[] {false} ;
         BC001911_A93DocAnexoId = new int[1] ;
         BC001911_A94DocAnexoDescricao = new string[] {""} ;
         BC001911_A95DocAnexoArquivo = new string[] {""} ;
         BC001911_A96DocAnexoDataInclusao = new DateTime[] {DateTime.MinValue} ;
         BC001911_A76DocumentoNome = new string[] {""} ;
         BC001911_n76DocumentoNome = new bool[] {false} ;
         BC001911_A75DocumentoId = new int[1] ;
         i96DocAnexoDataInclusao = DateTime.MinValue;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.docanexo_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.docanexo_bc__default(),
            new Object[][] {
                new Object[] {
               BC00192_A93DocAnexoId, BC00192_A94DocAnexoDescricao, BC00192_A95DocAnexoArquivo, BC00192_A96DocAnexoDataInclusao, BC00192_A75DocumentoId
               }
               , new Object[] {
               BC00193_A93DocAnexoId, BC00193_A94DocAnexoDescricao, BC00193_A95DocAnexoArquivo, BC00193_A96DocAnexoDataInclusao, BC00193_A75DocumentoId
               }
               , new Object[] {
               BC00194_A76DocumentoNome, BC00194_n76DocumentoNome
               }
               , new Object[] {
               BC00195_A93DocAnexoId, BC00195_A94DocAnexoDescricao, BC00195_A95DocAnexoArquivo, BC00195_A96DocAnexoDataInclusao, BC00195_A76DocumentoNome, BC00195_n76DocumentoNome, BC00195_A75DocumentoId
               }
               , new Object[] {
               BC00196_A93DocAnexoId
               }
               , new Object[] {
               BC00197_A93DocAnexoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001910_A76DocumentoNome, BC001910_n76DocumentoNome
               }
               , new Object[] {
               BC001911_A93DocAnexoId, BC001911_A94DocAnexoDescricao, BC001911_A95DocAnexoArquivo, BC001911_A96DocAnexoDataInclusao, BC001911_A76DocumentoNome, BC001911_n76DocumentoNome, BC001911_A75DocumentoId
               }
            }
         );
         AV24Pgmname = "DocAnexo_BC";
         Z96DocAnexoDataInclusao = DateTimeUtil.Today( context);
         A96DocAnexoDataInclusao = DateTimeUtil.Today( context);
         i96DocAnexoDataInclusao = DateTimeUtil.Today( context);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12192 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound52 ;
      private short nIsDirty_52 ;
      private int trnEnded ;
      private int Z93DocAnexoId ;
      private int A93DocAnexoId ;
      private int AV25GXV1 ;
      private int AV13Insert_DocumentoId ;
      private int Z75DocumentoId ;
      private int A75DocumentoId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV24Pgmname ;
      private string sMode52 ;
      private DateTime Z96DocAnexoDataInclusao ;
      private DateTime A96DocAnexoDataInclusao ;
      private DateTime i96DocAnexoDataInclusao ;
      private bool returnInSub ;
      private bool n76DocumentoNome ;
      private bool mustCommit ;
      private string Z94DocAnexoDescricao ;
      private string A94DocAnexoDescricao ;
      private string Z95DocAnexoArquivo ;
      private string A95DocAnexoArquivo ;
      private string Z76DocumentoNome ;
      private string A76DocumentoNome ;
      private IGxSession AV12WebSession ;
      private SdtDocAnexo bcDocAnexo ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00195_A93DocAnexoId ;
      private string[] BC00195_A94DocAnexoDescricao ;
      private string[] BC00195_A95DocAnexoArquivo ;
      private DateTime[] BC00195_A96DocAnexoDataInclusao ;
      private string[] BC00195_A76DocumentoNome ;
      private bool[] BC00195_n76DocumentoNome ;
      private int[] BC00195_A75DocumentoId ;
      private string[] BC00194_A76DocumentoNome ;
      private bool[] BC00194_n76DocumentoNome ;
      private int[] BC00196_A93DocAnexoId ;
      private int[] BC00193_A93DocAnexoId ;
      private string[] BC00193_A94DocAnexoDescricao ;
      private string[] BC00193_A95DocAnexoArquivo ;
      private DateTime[] BC00193_A96DocAnexoDataInclusao ;
      private int[] BC00193_A75DocumentoId ;
      private int[] BC00192_A93DocAnexoId ;
      private string[] BC00192_A94DocAnexoDescricao ;
      private string[] BC00192_A95DocAnexoArquivo ;
      private DateTime[] BC00192_A96DocAnexoDataInclusao ;
      private int[] BC00192_A75DocumentoId ;
      private int[] BC00197_A93DocAnexoId ;
      private string[] BC001910_A76DocumentoNome ;
      private bool[] BC001910_n76DocumentoNome ;
      private int[] BC001911_A93DocAnexoId ;
      private string[] BC001911_A94DocAnexoDescricao ;
      private string[] BC001911_A95DocAnexoArquivo ;
      private DateTime[] BC001911_A96DocAnexoDataInclusao ;
      private string[] BC001911_A76DocumentoNome ;
      private bool[] BC001911_n76DocumentoNome ;
      private int[] BC001911_A75DocumentoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
   }

   public class docanexo_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class docanexo_bc__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00195;
        prmBC00195 = new Object[] {
        new ParDef("@DocAnexoId",GXType.Int32,8,0)
        };
        Object[] prmBC00194;
        prmBC00194 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00196;
        prmBC00196 = new Object[] {
        new ParDef("@DocAnexoId",GXType.Int32,8,0)
        };
        Object[] prmBC00193;
        prmBC00193 = new Object[] {
        new ParDef("@DocAnexoId",GXType.Int32,8,0)
        };
        Object[] prmBC00192;
        prmBC00192 = new Object[] {
        new ParDef("@DocAnexoId",GXType.Int32,8,0)
        };
        Object[] prmBC00197;
        prmBC00197 = new Object[] {
        new ParDef("@DocAnexoDescricao",GXType.NVarChar,100,0) ,
        new ParDef("@DocAnexoArquivo",GXType.NVarChar,200,0) ,
        new ParDef("@DocAnexoDataInclusao",GXType.Date,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC00198;
        prmBC00198 = new Object[] {
        new ParDef("@DocAnexoDescricao",GXType.NVarChar,100,0) ,
        new ParDef("@DocAnexoArquivo",GXType.NVarChar,200,0) ,
        new ParDef("@DocAnexoDataInclusao",GXType.Date,8,0) ,
        new ParDef("@DocumentoId",GXType.Int32,8,0) ,
        new ParDef("@DocAnexoId",GXType.Int32,8,0)
        };
        Object[] prmBC00199;
        prmBC00199 = new Object[] {
        new ParDef("@DocAnexoId",GXType.Int32,8,0)
        };
        Object[] prmBC001910;
        prmBC001910 = new Object[] {
        new ParDef("@DocumentoId",GXType.Int32,8,0)
        };
        Object[] prmBC001911;
        prmBC001911 = new Object[] {
        new ParDef("@DocAnexoId",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00192", "SELECT [DocAnexoId], [DocAnexoDescricao], [DocAnexoArquivo], [DocAnexoDataInclusao], [DocumentoId] FROM [DocAnexo] WITH (UPDLOCK) WHERE [DocAnexoId] = @DocAnexoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00192,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00193", "SELECT [DocAnexoId], [DocAnexoDescricao], [DocAnexoArquivo], [DocAnexoDataInclusao], [DocumentoId] FROM [DocAnexo] WHERE [DocAnexoId] = @DocAnexoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00193,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00194", "SELECT [DocumentoNome] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00194,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00195", "SELECT TM1.[DocAnexoId], TM1.[DocAnexoDescricao], TM1.[DocAnexoArquivo], TM1.[DocAnexoDataInclusao], T2.[DocumentoNome], TM1.[DocumentoId] FROM ([DocAnexo] TM1 INNER JOIN [Documento] T2 ON T2.[DocumentoId] = TM1.[DocumentoId]) WHERE TM1.[DocAnexoId] = @DocAnexoId ORDER BY TM1.[DocAnexoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00195,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00196", "SELECT [DocAnexoId] FROM [DocAnexo] WHERE [DocAnexoId] = @DocAnexoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00196,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00197", "INSERT INTO [DocAnexo]([DocAnexoDescricao], [DocAnexoArquivo], [DocAnexoDataInclusao], [DocumentoId]) VALUES(@DocAnexoDescricao, @DocAnexoArquivo, @DocAnexoDataInclusao, @DocumentoId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00197,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC00198", "UPDATE [DocAnexo] SET [DocAnexoDescricao]=@DocAnexoDescricao, [DocAnexoArquivo]=@DocAnexoArquivo, [DocAnexoDataInclusao]=@DocAnexoDataInclusao, [DocumentoId]=@DocumentoId  WHERE [DocAnexoId] = @DocAnexoId", GxErrorMask.GX_NOMASK,prmBC00198)
           ,new CursorDef("BC00199", "DELETE FROM [DocAnexo]  WHERE [DocAnexoId] = @DocAnexoId", GxErrorMask.GX_NOMASK,prmBC00199)
           ,new CursorDef("BC001910", "SELECT [DocumentoNome] FROM [Documento] WHERE [DocumentoId] = @DocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001910,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001911", "SELECT TM1.[DocAnexoId], TM1.[DocAnexoDescricao], TM1.[DocAnexoArquivo], TM1.[DocAnexoDataInclusao], T2.[DocumentoNome], TM1.[DocumentoId] FROM ([DocAnexo] TM1 INNER JOIN [Documento] T2 ON T2.[DocumentoId] = TM1.[DocumentoId]) WHERE TM1.[DocAnexoId] = @DocAnexoId ORDER BY TM1.[DocAnexoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001911,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((int[]) buf[6])[0] = rslt.getInt(6);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((int[]) buf[6])[0] = rslt.getInt(6);
              return;
     }
  }

}

}
