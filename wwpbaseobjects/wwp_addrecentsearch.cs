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
   public class wwp_addrecentsearch : GXProcedure
   {
      public wwp_addrecentsearch( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public wwp_addrecentsearch( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem> aP0_WWP_SearchResults ,
                           string aP1_Url ,
                           short aP2_MaxCategories ,
                           short aP3_MaxItemsPerCategory )
      {
         this.AV20WWP_SearchResults = aP0_WWP_SearchResults;
         this.AV18Url = aP1_Url;
         this.AV11MaxCategories = aP2_MaxCategories;
         this.AV12MaxItemsPerCategory = aP3_MaxItemsPerCategory;
         initialize();
         executePrivate();
      }

      public void executeSubmit( GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem> aP0_WWP_SearchResults ,
                                 string aP1_Url ,
                                 short aP2_MaxCategories ,
                                 short aP3_MaxItemsPerCategory )
      {
         wwp_addrecentsearch objwwp_addrecentsearch;
         objwwp_addrecentsearch = new wwp_addrecentsearch();
         objwwp_addrecentsearch.AV20WWP_SearchResults = aP0_WWP_SearchResults;
         objwwp_addrecentsearch.AV18Url = aP1_Url;
         objwwp_addrecentsearch.AV11MaxCategories = aP2_MaxCategories;
         objwwp_addrecentsearch.AV12MaxItemsPerCategory = aP3_MaxItemsPerCategory;
         objwwp_addrecentsearch.context.SetSubmitInitialConfig(context);
         objwwp_addrecentsearch.initialize();
         Submit( executePrivateCatch,objwwp_addrecentsearch);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_addrecentsearch)stateInfo).executePrivate();
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
         GXt_char1 = AV17RecentSearchResultsJson;
         new GeneXus.Programs.wwpbaseobjects.loaduserkeyvalue(context ).execute(  "WWPRecentSearch", out  GXt_char1) ;
         AV17RecentSearchResultsJson = GXt_char1;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17RecentSearchResultsJson)) )
         {
            AV14RecentSearches = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem>( context, "WWP_SearchResultsItem", "LGPD_Novo");
         }
         else
         {
            AV14RecentSearches.FromJSonString(AV17RecentSearchResultsJson, null);
         }
         AV10Found = false;
         AV24GXV1 = 1;
         while ( AV24GXV1 <= AV20WWP_SearchResults.Count )
         {
            AV21WWP_SearchResultsItem = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)AV20WWP_SearchResults.Item(AV24GXV1));
            AV25GXV2 = 1;
            while ( AV25GXV2 <= AV21WWP_SearchResultsItem.gxTpr_Result.Count )
            {
               AV19WWP_SearchResultItem = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)AV21WWP_SearchResultsItem.gxTpr_Result.Item(AV25GXV2));
               if ( StringUtil.StrCmp(AV19WWP_SearchResultItem.gxTpr_Url, AV18Url) == 0 )
               {
                  AV8CategoryFound = false;
                  AV26GXV3 = 1;
                  while ( AV26GXV3 <= AV14RecentSearches.Count )
                  {
                     AV16RecentSearchResults = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem)AV14RecentSearches.Item(AV26GXV3));
                     if ( StringUtil.StrCmp(AV16RecentSearchResults.gxTpr_Categoryname, AV21WWP_SearchResultsItem.gxTpr_Categoryname) == 0 )
                     {
                        AV8CategoryFound = true;
                        AV9CurrentRecentSearchResults = AV16RecentSearchResults;
                        if (true) break;
                     }
                     AV26GXV3 = (int)(AV26GXV3+1);
                  }
                  AV13RecentAlreadyAdded = false;
                  if ( ! AV8CategoryFound )
                  {
                     AV9CurrentRecentSearchResults = new GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem(context);
                     AV9CurrentRecentSearchResults.gxTpr_Categoryname = AV21WWP_SearchResultsItem.gxTpr_Categoryname;
                     AV9CurrentRecentSearchResults.gxTpr_Categoryicon = AV21WWP_SearchResultsItem.gxTpr_Categoryicon;
                     AV9CurrentRecentSearchResults.gxTpr_Orderindex = AV21WWP_SearchResultsItem.gxTpr_Orderindex;
                     AV9CurrentRecentSearchResults.gxTpr_Showingallresults = true;
                     AV14RecentSearches.Add(AV9CurrentRecentSearchResults, 0);
                     if ( AV14RecentSearches.Count > AV11MaxCategories )
                     {
                        AV14RecentSearches.RemoveItem(1);
                     }
                  }
                  else
                  {
                     AV27GXV4 = 1;
                     while ( AV27GXV4 <= AV9CurrentRecentSearchResults.gxTpr_Result.Count )
                     {
                        AV15RecentSearchResultItem = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)AV9CurrentRecentSearchResults.gxTpr_Result.Item(AV27GXV4));
                        if ( StringUtil.StrCmp(AV15RecentSearchResultItem.gxTpr_Url, AV18Url) == 0 )
                        {
                           AV13RecentAlreadyAdded = true;
                           if (true) break;
                        }
                        AV27GXV4 = (int)(AV27GXV4+1);
                     }
                  }
                  if ( ! AV13RecentAlreadyAdded )
                  {
                     AV9CurrentRecentSearchResults.gxTpr_Result.Add((GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem)(AV19WWP_SearchResultItem.Clone()), 1);
                     if ( AV9CurrentRecentSearchResults.gxTpr_Result.Count > AV12MaxItemsPerCategory )
                     {
                        AV9CurrentRecentSearchResults.gxTpr_Result.RemoveItem(AV9CurrentRecentSearchResults.gxTpr_Result.Count);
                     }
                     new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  "WWPRecentSearch",  AV14RecentSearches.ToJSonString(false)) ;
                  }
                  AV10Found = true;
                  if (true) break;
               }
               AV25GXV2 = (int)(AV25GXV2+1);
            }
            if ( AV10Found )
            {
               if (true) break;
            }
            AV24GXV1 = (int)(AV24GXV1+1);
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
         AV17RecentSearchResultsJson = "";
         GXt_char1 = "";
         AV14RecentSearches = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem>( context, "WWP_SearchResultsItem", "LGPD_Novo");
         AV21WWP_SearchResultsItem = new GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem(context);
         AV19WWP_SearchResultItem = new GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem(context);
         AV16RecentSearchResults = new GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem(context);
         AV9CurrentRecentSearchResults = new GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem(context);
         AV15RecentSearchResultItem = new GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV11MaxCategories ;
      private short AV12MaxItemsPerCategory ;
      private int AV24GXV1 ;
      private int AV25GXV2 ;
      private int AV26GXV3 ;
      private int AV27GXV4 ;
      private string GXt_char1 ;
      private bool AV10Found ;
      private bool AV8CategoryFound ;
      private bool AV13RecentAlreadyAdded ;
      private string AV18Url ;
      private string AV17RecentSearchResultsJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem> AV20WWP_SearchResults ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem> AV14RecentSearches ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem AV21WWP_SearchResultsItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem AV16RecentSearchResults ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem AV9CurrentRecentSearchResults ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem AV19WWP_SearchResultItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_SearchResults_WWP_SearchResultsItem_ResultItem AV15RecentSearchResultItem ;
   }

}
