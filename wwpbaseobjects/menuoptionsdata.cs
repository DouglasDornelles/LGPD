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
   public class menuoptionsdata : GXProcedure
   {
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

      public menuoptionsdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public menuoptionsdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "LGPD_Novo") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_Gxm2rootcol )
      {
         menuoptionsdata objmenuoptionsdata;
         objmenuoptionsdata = new menuoptionsdata();
         objmenuoptionsdata.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "LGPD_Novo") ;
         objmenuoptionsdata.context.SetSubmitInitialConfig(context);
         objmenuoptionsdata.initialize();
         Submit( executePrivateCatch,objmenuoptionsdata);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((menuoptionsdata)stateInfo).executePrivate();
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
         AV5id = 0;
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("home.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-home";
         Gxm1dvelop_menu.gxTpr_Caption = "Inicio";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = "";
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-edit";
         Gxm1dvelop_menu.gxTpr_Caption = "Documentos";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("documentoww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Lista de Documentos";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = "";
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-edit";
         Gxm1dvelop_menu.gxTpr_Caption = "Cadastros";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("processoww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Processo";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("subprocessoww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Subprocesso";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("arearesponsavelww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "�rea Respons�vel";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("controladorww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Controlador";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("personaww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Persona";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("encarregadoww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Encarregado";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("categoriaww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Categoria";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("tipodadoww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Tipo de Dado";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("ferramentacoletaww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Ferramenta de Coleta";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("abrangenciageograficaww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Abrang�ncia Geogr�fica";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("frequenciatratamentoww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Frequ�ncia de Tratamento";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("fonteretencaoww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Fonte de Reten��o";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("tipodescarteww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Tipo de Descarte";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("temporetencaoww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Tempo de Reten��o";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("setorinternoww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Setor Interno";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("compartinternoww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Compartilhamento Interno";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("envolvidoscoletaww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Envolvidos na Coleta";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("medidasegurancaww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Medida de Seguran�a";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("informacaoww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Informa��o";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("hipotesetratamentoww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Hip�tese de Tratamento";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("paisww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Pa�s";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("comparttercexternoww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Compartilhamento com Terceiros/Externos";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("operadorww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Operador";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("tooltipww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Tooltip";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = "";
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-briefcase";
         Gxm1dvelop_menu.gxTpr_Caption = "Developer";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("parametroww.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Par�metros";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "Seguran�a de aplicativo";
         Gxm1dvelop_menu.gxTpr_Link = "";
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-key";
         Gxm1dvelop_menu.gxTpr_Caption = "GAM";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "Usu�rios";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("gamwwusers.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Usu�rios";
         Gxm3dvelop_menu_subitems.gxTpr_Authorizationkey = "";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "Perfis";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("gamwwroles.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Perfis";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Authorizationkey = "";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = "";
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Reposit�rio";
         AV9IsRepoAdministrator = AV7Repository.isgamadministrator(out  AV8Errors);
         if ( AV9IsRepoAdministrator )
         {
            Gxm4dvelop_menu_subitems_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
            Gxm3dvelop_menu_subitems.gxTpr_Subitems.Add(Gxm4dvelop_menu_subitems_subitems, 0);
            AV5id = (short)(AV5id+1);
            Gxm4dvelop_menu_subitems_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
            Gxm4dvelop_menu_subitems_subitems.gxTpr_Tooltip = "";
            Gxm4dvelop_menu_subitems_subitems.gxTpr_Link = formatLink("gamwwrepositories.aspx") ;
            Gxm4dvelop_menu_subitems_subitems.gxTpr_Linktarget = "";
            Gxm4dvelop_menu_subitems_subitems.gxTpr_Caption = "Reposit�rios";
            Gxm4dvelop_menu_subitems_subitems.gxTpr_Authorizationkey = "";
         }
         Gxm4dvelop_menu_subitems_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm3dvelop_menu_subitems.gxTpr_Subitems.Add(Gxm4dvelop_menu_subitems_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Tooltip = "Repository Configuration";
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "gamrepositoryconfiguration.aspx"+GXUtil.UrlEncode(StringUtil.LTrimStr(0,1,0));
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Link = formatLink("gamrepositoryconfiguration.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Linktarget = "";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Caption = "Configura��o";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Authorizationkey = "";
         Gxm4dvelop_menu_subitems_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm3dvelop_menu_subitems.gxTpr_Subitems.Add(Gxm4dvelop_menu_subitems_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Tooltip = "Repository Connections";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Link = formatLink("gamwwconnections.aspx") ;
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Linktarget = "";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Caption = "Conex�es";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Authorizationkey = "";
         Gxm4dvelop_menu_subitems_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm3dvelop_menu_subitems.gxTpr_Subitems.Add(Gxm4dvelop_menu_subitems_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Tooltip = "Change Working Repository";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Link = formatLink("gamchangerepository.aspx") ;
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Linktarget = "";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Caption = "Reposit�rio de trabalho";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Authorizationkey = "";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "Outras configura��es";
         Gxm3dvelop_menu_subitems.gxTpr_Link = "";
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Outras configura��es";
         Gxm4dvelop_menu_subitems_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm3dvelop_menu_subitems.gxTpr_Subitems.Add(Gxm4dvelop_menu_subitems_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Tooltip = "Pol�ticas de seguran�a";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Link = formatLink("gamwwsecuritypolicy.aspx") ;
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Linktarget = "";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Caption = "Pol�ticas de seguran�a";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Authorizationkey = "";
         Gxm4dvelop_menu_subitems_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm3dvelop_menu_subitems.gxTpr_Subitems.Add(Gxm4dvelop_menu_subitems_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Tooltip = "Tipos de autentica��o";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Link = formatLink("gamwwauthtypes.aspx") ;
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Linktarget = "";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Caption = "Tipos de autentica��o";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Authorizationkey = "";
         Gxm4dvelop_menu_subitems_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm3dvelop_menu_subitems.gxTpr_Subitems.Add(Gxm4dvelop_menu_subitems_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Tooltip = "Subscri��es a eventos";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Link = formatLink("gamwweventsubscriptions.aspx") ;
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Linktarget = "";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Caption = "Subscri��es a eventos";
         Gxm4dvelop_menu_subitems_subitems.gxTpr_Authorizationkey = "";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("gamchangeyourpassword.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Alterar sua senha";
         Gxm3dvelop_menu_subitems.gxTpr_Authorizationkey = "";
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm3dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm3dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm3dvelop_menu_subitems.gxTpr_Tooltip = "Aplica��es";
         Gxm3dvelop_menu_subitems.gxTpr_Link = formatLink("gamwwapplications.aspx") ;
         Gxm3dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm3dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm3dvelop_menu_subitems.gxTpr_Caption = "Aplica��es";
         Gxm3dvelop_menu_subitems.gxTpr_Authorizationkey = "";
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
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm3dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         AV8Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV7Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         Gxm4dvelop_menu_subitems_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         GXKey = "";
         GXEncryptionTmp = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV5id ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private bool AV9IsRepoAdministrator ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV7Repository ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_Gxm2rootcol ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV8Errors ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> Gxm2rootcol ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item Gxm1dvelop_menu ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item Gxm3dvelop_menu_subitems ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item Gxm4dvelop_menu_subitems_subitems ;
   }

}
