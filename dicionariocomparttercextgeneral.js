gx.evt.autoSkip=!1;gx.define("dicionariocomparttercextgeneral",!0,function(n){this.ServerClass="dicionariocomparttercextgeneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="dicionariocomparttercextgeneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV12IsAuthorized_Update=gx.fn.getControlValue("vISAUTHORIZED_UPDATE");this.A66CompartTercExternoId=gx.fn.getIntegerValue("COMPARTTERCEXTERNOID",".");this.A98DocDicionarioId=gx.fn.getIntegerValue("DOCDICIONARIOID",".");this.AV13IsAuthorized_Delete=gx.fn.getControlValue("vISAUTHORIZED_DELETE")};this.e137m2_client=function(){return this.executeServerEvent("'DOUPDATE'",!1,null,!1,!1)};this.e147m2_client=function(){return this.executeServerEvent("'DODELETE'",!1,null,!1,!1)};this.e157m2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e167m2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26];this.GXLastCtrlId=26;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TRANSACTIONDETAIL_TABLEATTRIBUTES",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COMPARTTERCEXTERNONOME",fmt:0,gxz:"Z67CompartTercExternoNome",gxold:"O67CompartTercExternoNome",gxvar:"A67CompartTercExternoNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A67CompartTercExternoNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z67CompartTercExternoNome=n)},v2c:function(){gx.fn.setControlValue("COMPARTTERCEXTERNONOME",gx.O.A67CompartTercExternoNome,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A67CompartTercExternoNome=this.val())},val:function(){return gx.fn.getControlValue("COMPARTTERCEXTERNONOME")},nac:gx.falseFn};this.declareDomainHdlr(14,function(){});t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCDICIONARIOSENSIVEL",fmt:0,gxz:"Z99DocDicionarioSensivel",gxold:"O99DocDicionarioSensivel",gxvar:"A99DocDicionarioSensivel",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A99DocDicionarioSensivel=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z99DocDicionarioSensivel=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setControlValue("DOCDICIONARIOSENSIVEL",gx.O.A99DocDicionarioSensivel,0)},c2v:function(){this.val()!==undefined&&(gx.O.A99DocDicionarioSensivel=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("DOCDICIONARIOSENSIVEL")},nac:gx.falseFn};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"",grid:0};t[24]={id:24,fld:"BTNUPDATE",grid:0,evt:"e137m2_client"};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"BTNDELETE",grid:0,evt:"e147m2_client"};this.A67CompartTercExternoNome="";this.Z67CompartTercExternoNome="";this.O67CompartTercExternoNome="";this.A99DocDicionarioSensivel=!1;this.Z99DocDicionarioSensivel=!1;this.O99DocDicionarioSensivel=!1;this.A67CompartTercExternoNome="";this.A99DocDicionarioSensivel=!1;this.A66CompartTercExternoId=0;this.A98DocDicionarioId=0;this.AV12IsAuthorized_Update=!1;this.AV13IsAuthorized_Delete=!1;this.Events={e137m2_client:["'DOUPDATE'",!0],e147m2_client:["'DODELETE'",!0],e157m2_client:["ENTER",!0],e167m2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"A66CompartTercExternoId",fld:"COMPARTTERCEXTERNOID",pic:"ZZZZZZZ9"},{av:"A98DocDicionarioId",fld:"DOCDICIONARIOID",pic:"ZZZZZZZ9"},{av:"AV12IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV13IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0}],[]];this.EvtParms["'DOUPDATE'"]=[[{av:"AV12IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"A66CompartTercExternoId",fld:"COMPARTTERCEXTERNOID",pic:"ZZZZZZZ9"},{av:"A98DocDicionarioId",fld:"DOCDICIONARIOID",pic:"ZZZZZZZ9"}],[{ctrl:"BTNUPDATE",prop:"Visible"}]];this.EvtParms["'DODELETE'"]=[[{av:"AV13IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"A66CompartTercExternoId",fld:"COMPARTTERCEXTERNOID",pic:"ZZZZZZZ9"},{av:"A98DocDicionarioId",fld:"DOCDICIONARIOID",pic:"ZZZZZZZ9"}],[{ctrl:"BTNDELETE",prop:"Visible"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV12IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("A66CompartTercExternoId","COMPARTTERCEXTERNOID",0,"int",8,0);this.setVCMap("A98DocDicionarioId","DOCDICIONARIOID",0,"int",8,0);this.setVCMap("AV13IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.Initialize()})