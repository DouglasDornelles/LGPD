gx.evt.autoSkip=!1;gx.define("arearesponsavelgeneral",!0,function(n){this.ServerClass="arearesponsavelgeneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="arearesponsavelgeneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV12IsAuthorized_Update=gx.fn.getControlValue("vISAUTHORIZED_UPDATE");this.AV13IsAuthorized_Delete=gx.fn.getControlValue("vISAUTHORIZED_DELETE")};this.Valid_Arearesponsavelid=function(){return this.validCliEvt("Valid_Arearesponsavelid",0,function(){try{var n=gx.util.balloon.getNew("AREARESPONSAVELID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e137s2_client=function(){return this.executeServerEvent("'DOUPDATE'",!1,null,!1,!1)};this.e147s2_client=function(){return this.executeServerEvent("'DODELETE'",!1,null,!1,!1)};this.e157s2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e167s2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30];this.GXLastCtrlId=30;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TRANSACTIONDETAIL_TABLEATTRIBUTES",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AREARESPONSAVELNOME",fmt:0,gxz:"Z25AreaResponsavelNome",gxold:"O25AreaResponsavelNome",gxvar:"A25AreaResponsavelNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A25AreaResponsavelNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z25AreaResponsavelNome=n)},v2c:function(){gx.fn.setControlValue("AREARESPONSAVELNOME",gx.O.A25AreaResponsavelNome,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A25AreaResponsavelNome=this.val())},val:function(){return gx.fn.getControlValue("AREARESPONSAVELNOME")},nac:gx.falseFn};this.declareDomainHdlr(14,function(){});t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AREARESPONSAVELATIVO",fmt:0,gxz:"Z26AreaResponsavelAtivo",gxold:"O26AreaResponsavelAtivo",gxvar:"A26AreaResponsavelAtivo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A26AreaResponsavelAtivo=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z26AreaResponsavelAtivo=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setComboBoxValue("AREARESPONSAVELATIVO",gx.O.A26AreaResponsavelAtivo);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A26AreaResponsavelAtivo=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("AREARESPONSAVELATIVO")},nac:gx.falseFn};this.declareDomainHdlr(19,function(){});t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"",grid:0};t[24]={id:24,fld:"BTNUPDATE",grid:0,evt:"e137s2_client"};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"BTNDELETE",grid:0,evt:"e147s2_client"};t[27]={id:27,fld:"",grid:0};t[28]={id:28,fld:"",grid:0};t[29]={id:29,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};t[30]={id:30,lvl:0,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Arearesponsavelid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AREARESPONSAVELID",fmt:0,gxz:"Z24AreaResponsavelId",gxold:"O24AreaResponsavelId",gxvar:"A24AreaResponsavelId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A24AreaResponsavelId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z24AreaResponsavelId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("AREARESPONSAVELID",gx.O.A24AreaResponsavelId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A24AreaResponsavelId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("AREARESPONSAVELID",".")},nac:gx.falseFn};this.declareDomainHdlr(30,function(){});this.A25AreaResponsavelNome="";this.Z25AreaResponsavelNome="";this.O25AreaResponsavelNome="";this.A26AreaResponsavelAtivo=!1;this.Z26AreaResponsavelAtivo=!1;this.O26AreaResponsavelAtivo=!1;this.A24AreaResponsavelId=0;this.Z24AreaResponsavelId=0;this.O24AreaResponsavelId=0;this.A25AreaResponsavelNome="";this.A26AreaResponsavelAtivo=!1;this.A24AreaResponsavelId=0;this.AV12IsAuthorized_Update=!1;this.AV13IsAuthorized_Delete=!1;this.Events={e137s2_client:["'DOUPDATE'",!0],e147s2_client:["'DODELETE'",!0],e157s2_client:["ENTER",!0],e167s2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"A24AreaResponsavelId",fld:"AREARESPONSAVELID",pic:"ZZZZZZZ9"},{av:"AV12IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV13IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0}],[]];this.EvtParms["'DOUPDATE'"]=[[{av:"AV12IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"A24AreaResponsavelId",fld:"AREARESPONSAVELID",pic:"ZZZZZZZ9"}],[{ctrl:"BTNUPDATE",prop:"Visible"}]];this.EvtParms["'DODELETE'"]=[[{av:"AV13IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"A24AreaResponsavelId",fld:"AREARESPONSAVELID",pic:"ZZZZZZZ9"}],[{ctrl:"BTNDELETE",prop:"Visible"}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_AREARESPONSAVELID=[[],[]];this.setVCMap("AV12IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("AV13IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.Initialize()})