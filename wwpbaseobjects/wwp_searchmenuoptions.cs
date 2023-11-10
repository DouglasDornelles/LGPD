using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_searchmenuoptions : GXProcedure
   {
      public wwp_searchmenuoptions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public wwp_searchmenuoptions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_SearchText ,
                           GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP1_MenuData ,
                           GxSimpleCollection<string> aP2_CurrentMenuOptionPath ,
                           ref GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP3_MenuOptions ,
                           ref GxSimpleCollection<string> aP4_MenuOptionsPaths )
      {
         this.AV8SearchText = aP0_SearchText;
         this.AV9MenuData = aP1_MenuData;
         this.AV14CurrentMenuOptionPath = aP2_CurrentMenuOptionPath;
         this.AV10MenuOptions = aP3_MenuOptions;
         this.AV11MenuOptionsPaths = aP4_MenuOptionsPaths;
         initialize();
         executePrivate();
         aP3_MenuOptions=this.AV10MenuOptions;
         aP4_MenuOptionsPaths=this.AV11MenuOptionsPaths;
      }

      public GxSimpleCollection<string> executeUdp( string aP0_SearchText ,
                                                    GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP1_MenuData ,
                                                    GxSimpleCollection<string> aP2_CurrentMenuOptionPath ,
                                                    ref GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP3_MenuOptions )
      {
         execute(aP0_SearchText, aP1_MenuData, aP2_CurrentMenuOptionPath, ref aP3_MenuOptions, ref aP4_MenuOptionsPaths);
         return AV11MenuOptionsPaths ;
      }

      public void executeSubmit( string aP0_SearchText ,
                                 GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP1_MenuData ,
                                 GxSimpleCollection<string> aP2_CurrentMenuOptionPath ,
                                 ref GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP3_MenuOptions ,
                                 ref GxSimpleCollection<string> aP4_MenuOptionsPaths )
      {
         wwp_searchmenuoptions objwwp_searchmenuoptions;
         objwwp_searchmenuoptions = new wwp_searchmenuoptions();
         objwwp_searchmenuoptions.AV8SearchText = aP0_SearchText;
         objwwp_searchmenuoptions.AV9MenuData = aP1_MenuData;
         objwwp_searchmenuoptions.AV14CurrentMenuOptionPath = aP2_CurrentMenuOptionPath;
         objwwp_searchmenuoptions.AV10MenuOptions = aP3_MenuOptions;
         objwwp_searchmenuoptions.AV11MenuOptionsPaths = aP4_MenuOptionsPaths;
         objwwp_searchmenuoptions.context.SetSubmitInitialConfig(context);
         objwwp_searchmenuoptions.initialize();
         Submit( executePrivateCatch,objwwp_searchmenuoptions);
         aP3_MenuOptions=this.AV10MenuOptions;
         aP4_MenuOptionsPaths=this.AV11MenuOptionsPaths;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_searchmenuoptions)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV18GXV1 = 1;
         while ( AV18GXV1 <= AV9MenuData.Count )
         {
            AV13MenuDataItem = ((GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item)AV9MenuData.Item(AV18GXV1));
            AV12MenuOptionsPath = AV14CurrentMenuOptionPath.ToJSonString(false);
            if ( ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13MenuDataItem.gxTpr_Link)) ) && ( StringUtil.Contains( StringUtil.Lower( AV13MenuDataItem.gxTpr_Caption), StringUtil.Lower( StringUtil.Trim( AV8SearchText))) || StringUtil.Contains( StringUtil.Lower( AV12MenuOptionsPath), StringUtil.Lower( StringUtil.Trim( AV8SearchText))) ) )
            {
               AV10MenuOptions.Add(AV13MenuDataItem, 0);
               AV11MenuOptionsPaths.Add(AV12MenuOptionsPath, 0);
            }
            if ( AV13MenuDataItem.gxTpr_Subitems.Count > 0 )
            {
               AV15NewMenuOptionPath.FromJSonString(AV12MenuOptionsPath, null);
               AV15NewMenuOptionPath.Add(AV13MenuDataItem.gxTpr_Caption, 0);
               new GeneXus.Programs.wwpbaseobjects.wwp_searchmenuoptions(context ).execute(  AV8SearchText,  AV13MenuDataItem.gxTpr_Subitems,  AV15NewMenuOptionPath, ref  AV10MenuOptions, ref  AV11MenuOptionsPaths) ;
            }
            AV18GXV1 = (int)(AV18GXV1+1);
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV13MenuDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         AV12MenuOptionsPath = "";
         AV15NewMenuOptionPath = new GxSimpleCollection<string>();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV18GXV1 ;
      private string AV8SearchText ;
      private string AV12MenuOptionsPath ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP3_MenuOptions ;
      private GxSimpleCollection<string> aP4_MenuOptionsPaths ;
      private GxSimpleCollection<string> AV14CurrentMenuOptionPath ;
      private GxSimpleCollection<string> AV11MenuOptionsPaths ;
      private GxSimpleCollection<string> AV15NewMenuOptionPath ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> AV9MenuData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> AV10MenuOptions ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item AV13MenuDataItem ;
   }

}
