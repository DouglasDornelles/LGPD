gx.evt.autoSkip=!1;gx.define("campoview",!1,function(){var t,n;this.ServerClass="campoview";this.PackageName="GeneXus.Programs";this.ServerFullClass="campoview.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV10CampoId=gx.fn.getIntegerValue("vCAMPOID",".");this.AV8TabCode=gx.fn.getControlValue("vTABCODE")};this.e138e2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e148e2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,16,17,18];this.GXLastCtrlId=18;this.PANEL_GENERALContainer=gx.uc.getNew(this,14,0,"BootstrapPanel","PANEL_GENERALContainer","Panel_general","PANEL_GENERAL");n=this.PANEL_GENERALContainer;n.setProp("Class","Class","","char");n.setProp("Enabled","Enabled",!0,"boolean");n.setProp("Width","Width","100%","str");n.setProp("Height","Height","100","str");n.setProp("AutoWidth","Autowidth",!1,"bool");n.setProp("AutoHeight","Autoheight",!0,"bool");n.setProp("Cls","Cls","PanelCard Panel_BaseColor","str");n.setProp("ShowHeader","Showheader",!0,"bool");n.setProp("Title","Title","Informações Gerais","str");n.setProp("Collapsible","Collapsible",!0,"bool");n.setProp("Collapsed","Collapsed",!1,"bool");n.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");n.setProp("IconPosition","Iconposition","Right","str");n.setProp("AutoScroll","Autoscroll",!1,"bool");n.setProp("Visible","Visible",!0,"bool");n.setProp("Gx Control Type","Gxcontroltype","","int");n.setC2ShowFunction(function(n){n.show()});this.setUserControl(n);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TABLEVIEWRIGHTITEMS",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"WORKWITHLINK",format:0,grid:0,ctrltype:"textblock"};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"CAMPOGENERAL_CELL",grid:0};t[16]={id:16,fld:"TABLEPANEL_GENERAL",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};this.AV10CampoId=0;this.AV8TabCode="";this.A135CampoId=0;this.A136CampoNome="";this.Events={e138e2_client:["ENTER",!0],e148e2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV10CampoId",fld:"vCAMPOID",pic:"ZZZZZZZ9",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV10CampoId","vCAMPOID",0,"int",8,0);this.setVCMap("AV8TabCode","vTABCODE",0,"char",50,0);this.Initialize();this.setComponent({id:"WEBCOMPONENT_GENERAL",GXClass:null,Prefix:"W0019",lvl:1})});gx.wi(function(){gx.createParentObj(this.campoview)})