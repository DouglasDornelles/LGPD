gx.evt.autoSkip=!1;gx.define("docsetorinternogeneral",!0,function(n){this.ServerClass="docsetorinternogeneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="docsetorinternogeneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV12IsAuthorized_Update=gx.fn.getControlValue("vISAUTHORIZED_UPDATE");this.A60SetorInternoId=gx.fn.getIntegerValue("SETORINTERNOID",".");this.A75DocumentoId=gx.fn.getIntegerValue("DOCUMENTOID",".");this.AV13IsAuthorized_Delete=gx.fn.getControlValue("vISAUTHORIZED_DELETE")};this.e136t2_client=function(){return this.executeServerEvent("'DOUPDATE'",!1,null,!1,!1)};this.e146t2_client=function(){return this.executeServerEvent("'DODELETE'",!1,null,!1,!1)};this.e156t2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e166t2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26];this.GXLastCtrlId=26;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TRANSACTIONDETAIL_TABLEATTRIBUTES",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SETORINTERNONOME",fmt:0,gxz:"Z61SetorInternoNome",gxold:"O61SetorInternoNome",gxvar:"A61SetorInternoNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A61SetorInternoNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z61SetorInternoNome=n)},v2c:function(){gx.fn.setControlValue("SETORINTERNONOME",gx.O.A61SetorInternoNome,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A61SetorInternoNome=this.val())},val:function(){return gx.fn.getControlValue("SETORINTERNONOME")},nac:gx.falseFn};this.declareDomainHdlr(14,function(){});t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCUMENTONOME",fmt:0,gxz:"Z76DocumentoNome",gxold:"O76DocumentoNome",gxvar:"A76DocumentoNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A76DocumentoNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z76DocumentoNome=n)},v2c:function(){gx.fn.setControlValue("DOCUMENTONOME",gx.O.A76DocumentoNome,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A76DocumentoNome=this.val())},val:function(){return gx.fn.getControlValue("DOCUMENTONOME")},nac:gx.falseFn};this.declareDomainHdlr(19,function(){});t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"",grid:0};t[24]={id:24,fld:"BTNUPDATE",grid:0,evt:"e136t2_client"};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"BTNDELETE",grid:0,evt:"e146t2_client"};this.A61SetorInternoNome="";this.Z61SetorInternoNome="";this.O61SetorInternoNome="";this.A76DocumentoNome="";this.Z76DocumentoNome="";this.O76DocumentoNome="";this.A61SetorInternoNome="";this.A76DocumentoNome="";this.A60SetorInternoId=0;this.A75DocumentoId=0;this.AV12IsAuthorized_Update=!1;this.AV13IsAuthorized_Delete=!1;this.Events={e136t2_client:["'DOUPDATE'",!0],e146t2_client:["'DODELETE'",!0],e156t2_client:["ENTER",!0],e166t2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"A60SetorInternoId",fld:"SETORINTERNOID",pic:"ZZZZZZZ9"},{av:"A75DocumentoId",fld:"DOCUMENTOID",pic:"ZZZZZZZ9"},{av:"AV12IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV13IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0}],[]];this.EvtParms["'DOUPDATE'"]=[[{av:"AV12IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"A60SetorInternoId",fld:"SETORINTERNOID",pic:"ZZZZZZZ9"},{av:"A75DocumentoId",fld:"DOCUMENTOID",pic:"ZZZZZZZ9"}],[{ctrl:"BTNUPDATE",prop:"Visible"}]];this.EvtParms["'DODELETE'"]=[[{av:"AV13IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"A60SetorInternoId",fld:"SETORINTERNOID",pic:"ZZZZZZZ9"},{av:"A75DocumentoId",fld:"DOCUMENTOID",pic:"ZZZZZZZ9"}],[{ctrl:"BTNDELETE",prop:"Visible"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV12IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("A60SetorInternoId","SETORINTERNOID",0,"int",8,0);this.setVCMap("A75DocumentoId","DOCUMENTOID",0,"int",8,0);this.setVCMap("AV13IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.Initialize()})