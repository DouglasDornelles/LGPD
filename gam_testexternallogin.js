gx.evt.autoSkip=!1;gx.define("gam_testexternallogin",!1,function(){this.ServerClass="gam_testexternallogin";this.PackageName="GeneXus.Security.Backend";this.ServerFullClass="gam_testexternallogin.aspx";this.setObjectType("web");this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV9Name=gx.fn.getControlValue("vNAME");this.AV10TypeId=gx.fn.getControlValue("vTYPEID")};this.e111s2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e131s1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29];this.GXLastCtrlId=29;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLE2",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLE1",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"CANCEL",grid:0,evt:"e131s1_client"};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERNAME",fmt:0,gxz:"ZV11UserName",gxold:"OV11UserName",gxvar:"AV11UserName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11UserName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11UserName=n)},v2c:function(){gx.fn.setControlValue("vUSERNAME",gx.O.AV11UserName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV11UserName=this.val())},val:function(){return gx.fn.getControlValue("vUSERNAME")},nac:gx.falseFn};this.declareDomainHdlr(22,function(){});n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"char",len:254,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORD",fmt:0,gxz:"ZV12UserPassword",gxold:"OV12UserPassword",gxvar:"AV12UserPassword",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12UserPassword=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12UserPassword=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORD",gx.O.AV12UserPassword,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV12UserPassword=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORD")},nac:gx.falseFn};this.declareDomainHdlr(26,function(){});n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"ENTER",grid:0,evt:"e111s2_client",std:"ENTER"};this.AV11UserName="";this.ZV11UserName="";this.OV11UserName="";this.AV12UserPassword="";this.ZV12UserPassword="";this.OV12UserPassword="";this.AV11UserName="";this.AV12UserPassword="";this.AV9Name="";this.AV10TypeId="";this.Events={e111s2_client:["ENTER",!0],e131s1_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV9Name",fld:"vNAME",pic:"",hsh:!0}],[]];this.EvtParms.ENTER=[[{av:"AV9Name",fld:"vNAME",pic:"",hsh:!0},{av:"AV11UserName",fld:"vUSERNAME",pic:""},{av:"AV12UserPassword",fld:"vUSERPASSWORD",pic:""}],[]];this.EnterCtrl=["ENTER"];this.setVCMap("AV9Name","vNAME",0,"char",60,0);this.setVCMap("AV10TypeId","vTYPEID",0,"char",30,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gam_testexternallogin)})