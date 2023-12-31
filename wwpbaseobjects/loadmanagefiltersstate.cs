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
   public class loadmanagefiltersstate : GXProcedure
   {
      public loadmanagefiltersstate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public loadmanagefiltersstate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_UserCustomKey ,
                           out string aP1_UserCustomValue )
      {
         this.AV8UserCustomKey = aP0_UserCustomKey;
         this.AV9UserCustomValue = "" ;
         initialize();
         executePrivate();
         aP1_UserCustomValue=this.AV9UserCustomValue;
      }

      public string executeUdp( string aP0_UserCustomKey )
      {
         execute(aP0_UserCustomKey, out aP1_UserCustomValue);
         return AV9UserCustomValue ;
      }

      public void executeSubmit( string aP0_UserCustomKey ,
                                 out string aP1_UserCustomValue )
      {
         loadmanagefiltersstate objloadmanagefiltersstate;
         objloadmanagefiltersstate = new loadmanagefiltersstate();
         objloadmanagefiltersstate.AV8UserCustomKey = aP0_UserCustomKey;
         objloadmanagefiltersstate.AV9UserCustomValue = "" ;
         objloadmanagefiltersstate.context.SetSubmitInitialConfig(context);
         objloadmanagefiltersstate.initialize();
         Submit( executePrivateCatch,objloadmanagefiltersstate);
         aP1_UserCustomValue=this.AV9UserCustomValue;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadmanagefiltersstate)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.loaduserkeyvalue(context ).execute(  AV8UserCustomKey, out  AV9UserCustomValue) ;
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
         AV9UserCustomValue = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV8UserCustomKey ;
      private string AV9UserCustomValue ;
      private string aP1_UserCustomValue ;
   }

}
