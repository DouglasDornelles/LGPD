gx.evt.autoSkip=!1;gx.define("gamsetpassword",!1,function(){var n,t;this.ServerClass="gamsetpassword";this.PackageName="GeneXus.Programs";this.ServerFullClass="gamsetpassword.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV8UserId=gx.fn.getControlValue("vUSERID")};this.e121r2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e141r1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39];this.GXLastCtrlId=39;this.DVPANEL_TABLEATTRIBUTESContainer=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLEATTRIBUTESContainer","Dvpanel_tableattributes","DVPANEL_TABLEATTRIBUTES");t=this.DVPANEL_TABLEATTRIBUTESContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","100%","str");t.setProp("Height","Height","100","str");t.setProp("AutoWidth","Autowidth",!1,"bool");t.setProp("AutoHeight","Autoheight",!0,"bool");t.setProp("Cls","Cls","PanelCard Panel_BaseColor","str");t.setProp("ShowHeader","Showheader",!0,"bool");t.setProp("Title","Title","Configurar a chave","str");t.setProp("Collapsible","Collapsible",!1,"bool");t.setProp("Collapsed","Collapsed",!1,"bool");t.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");t.setProp("IconPosition","Iconposition","Right","str");t.setProp("AutoScroll","Autoscroll",!1,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"DVPANEL_TABLEATTRIBUTES_CELL",grid:0};n[17]={id:17,fld:"TABLEATTRIBUTES",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERNAME",fmt:0,gxz:"ZV9UserName",gxold:"OV9UserName",gxvar:"AV9UserName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9UserName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9UserName=n)},v2c:function(){gx.fn.setControlValue("vUSERNAME",gx.O.AV9UserName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV9UserName=this.val())},val:function(){return gx.fn.getControlValue("vUSERNAME")},nac:gx.falseFn};this.declareDomainHdlr(22,function(){});n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORDNEW",fmt:0,gxz:"ZV10UserPasswordNew",gxold:"OV10UserPasswordNew",gxvar:"AV10UserPasswordNew",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10UserPasswordNew=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10UserPasswordNew=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORDNEW",gx.O.AV10UserPasswordNew,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV10UserPasswordNew=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORDNEW")},nac:gx.falseFn};this.declareDomainHdlr(27,function(){});n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORDNEWCONF",fmt:0,gxz:"ZV11UserPasswordNewConf",gxold:"OV11UserPasswordNewConf",gxvar:"AV11UserPasswordNewConf",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11UserPasswordNewConf=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11UserPasswordNewConf=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORDNEWCONF",gx.O.AV11UserPasswordNewConf,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV11UserPasswordNewConf=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORDNEWCONF")},nac:gx.falseFn};this.declareDomainHdlr(32,function(){});n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"BTNENTER",grid:0,evt:"e121r2_client",std:"ENTER"};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"BTNCANCEL",grid:0,evt:"e141r1_client"};this.AV9UserName="";this.ZV9UserName="";this.OV9UserName="";this.AV10UserPasswordNew="";this.ZV10UserPasswordNew="";this.OV10UserPasswordNew="";this.AV11UserPasswordNewConf="";this.ZV11UserPasswordNewConf="";this.OV11UserPasswordNewConf="";this.AV9UserName="";this.AV10UserPasswordNew="";this.AV11UserPasswordNewConf="";this.AV8UserId="";this.Events={e121r2_client:["ENTER",!0],e141r1_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV8UserId",fld:"vUSERID",pic:"",hsh:!0}],[]];this.EvtParms.ENTER=[[{av:"AV8UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV10UserPasswordNew",fld:"vUSERPASSWORDNEW",pic:""},{av:"AV11UserPasswordNewConf",fld:"vUSERPASSWORDNEWCONF",pic:""}],[{av:'gx.fn.getCtrlProperty("vUSERPASSWORDNEW","Enabled")',ctrl:"vUSERPASSWORDNEW",prop:"Enabled"},{av:'gx.fn.getCtrlProperty("vUSERPASSWORDNEWCONF","Enabled")',ctrl:"vUSERPASSWORDNEWCONF",prop:"Enabled"},{ctrl:"BTNENTER",prop:"Visible"},{ctrl:"BTNCANCEL",prop:"Caption"}]];this.EnterCtrl=["BTNENTER"];this.setVCMap("AV8UserId","vUSERID",0,"char",40,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gamsetpassword)})