gx.evt.autoSkip=!1;gx.define("setorinternoview",!1,function(){var n,t,i;this.ServerClass="setorinternoview";this.PackageName="GeneXus.Programs";this.ServerFullClass="setorinternoview.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV11LoadAllTabs=gx.fn.getControlValue("vLOADALLTABS");this.AV12SelectedTabCode=gx.fn.getControlValue("vSELECTEDTABCODE");this.AV10SetorInternoId=gx.fn.getIntegerValue("vSETORINTERNOID",".");this.AV8TabCode=gx.fn.getControlValue("vTABCODE")};this.e115g2_client=function(){return this.executeServerEvent("TABS.TABCHANGED",!1,null,!0,!0)};this.e145g2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e155g2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,16,17,18,20,21,22,23,24,27,28,30,31,32];this.GXLastCtrlId=32;this.PANEL_GENERALContainer=gx.uc.getNew(this,14,0,"BootstrapPanel","PANEL_GENERALContainer","Panel_general","PANEL_GENERAL");t=this.PANEL_GENERALContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","100%","str");t.setProp("Height","Height","100","str");t.setProp("AutoWidth","Autowidth",!1,"bool");t.setProp("AutoHeight","Autoheight",!0,"bool");t.setProp("Cls","Cls","PanelCard Panel_BaseColor","str");t.setProp("ShowHeader","Showheader",!0,"bool");t.setProp("Title","Title","Informações Gerais","str");t.setProp("Collapsible","Collapsible",!0,"bool");t.setProp("Collapsed","Collapsed",!1,"bool");t.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");t.setProp("IconPosition","Iconposition","Right","str");t.setProp("AutoScroll","Autoscroll",!1,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);this.TABSContainer=gx.uc.getNew(this,25,0,"gx.ui.controls.Tab","TABSContainer","Tabs","TABS");i=this.TABSContainer;i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("ActivePage","Activepage","","int");i.setDynProp("ActivePageControlName","Activepagecontrolname","","char");i.setProp("PageCount","Pagecount",1,"num");i.setProp("Class","Class","ViewTab Tab","str");i.setProp("HistoryManagement","Historymanagement",!0,"bool");i.setProp("Visible","Visible",!0,"bool");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("TabChanged",this.e115g2_client);this.setUserControl(i);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLEVIEWRIGHTITEMS",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"WORKWITHLINK",format:0,grid:0,ctrltype:"textblock"};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"SETORINTERNOGENERAL_CELL",grid:0};n[16]={id:16,fld:"TABLEPANEL_GENERAL",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"UNNAMEDTABLEVIEWCONTAINER",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[27]={id:27,fld:"DOCSETORINTERNO_TITLE",format:0,grid:0,ctrltype:"textblock"};n[28]={id:28,fld:"",grid:0};n[30]={id:30,fld:"UNNAMEDTABLEDOCSETORINTERNO",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};this.AV10SetorInternoId=0;this.AV8TabCode="";this.A60SetorInternoId=0;this.A61SetorInternoNome="";this.AV11LoadAllTabs=!1;this.AV12SelectedTabCode="";this.Events={e115g2_client:["TABS.TABCHANGED",!0],e145g2_client:["ENTER",!0],e155g2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV10SetorInternoId",fld:"vSETORINTERNOID",pic:"ZZZZZZZ9",hsh:!0},{av:"AV8TabCode",fld:"vTABCODE",pic:"",hsh:!0}],[]];this.EvtParms["TABS.TABCHANGED"]=[[{av:"this.TABSContainer.ActivePageControlName",ctrl:"TABS",prop:"ActivePageControlName"},{av:"AV11LoadAllTabs",fld:"vLOADALLTABS",pic:""},{av:"AV12SelectedTabCode",fld:"vSELECTEDTABCODE",pic:""},{av:"AV10SetorInternoId",fld:"vSETORINTERNOID",pic:"ZZZZZZZ9",hsh:!0}],[{av:"AV12SelectedTabCode",fld:"vSELECTEDTABCODE",pic:""},{av:"AV11LoadAllTabs",fld:"vLOADALLTABS",pic:""},{ctrl:"DOCSETORINTERNOWC"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV11LoadAllTabs","vLOADALLTABS",0,"boolean",4,0);this.setVCMap("AV12SelectedTabCode","vSELECTEDTABCODE",0,"char",50,0);this.setVCMap("AV10SetorInternoId","vSETORINTERNOID",0,"int",8,0);this.setVCMap("AV8TabCode","vTABCODE",0,"char",50,0);this.Initialize();this.setComponent({id:"WEBCOMPONENT_GENERAL",GXClass:null,Prefix:"W0019",lvl:1});this.setComponent({id:"DOCSETORINTERNOWC",GXClass:null,Prefix:"W0033",lvl:1})});gx.wi(function(){gx.createParentObj(this.setorinternoview)})