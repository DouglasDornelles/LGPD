gx.evt.autoSkip=!1;gx.define("docanexogeneral",!0,function(n){this.ServerClass="docanexogeneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="docanexogeneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV12IsAuthorized_Update=gx.fn.getControlValue("vISAUTHORIZED_UPDATE");this.AV13IsAuthorized_Delete=gx.fn.getControlValue("vISAUTHORIZED_DELETE")};this.Valid_Docanexoid=function(){return this.validCliEvt("Valid_Docanexoid",0,function(){try{var n=gx.util.balloon.getNew("DOCANEXOID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e136e2_client=function(){return this.executeServerEvent("'DOUPDATE'",!1,null,!1,!1)};this.e146e2_client=function(){return this.executeServerEvent("'DODELETE'",!1,null,!1,!1)};this.e156e2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e166e2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44];this.GXLastCtrlId=44;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TRANSACTIONDETAIL_TABLEMAIN",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"TRANSACTIONDETAIL_TABLECONTENT",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,lvl:0,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Docanexoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCANEXOID",fmt:0,gxz:"Z93DocAnexoId",gxold:"O93DocAnexoId",gxvar:"A93DocAnexoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A93DocAnexoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z93DocAnexoId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("DOCANEXOID",gx.O.A93DocAnexoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A93DocAnexoId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("DOCANEXOID",".")},nac:gx.falseFn};this.declareDomainHdlr(17,function(){});t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCUMENTONOME",fmt:0,gxz:"Z76DocumentoNome",gxold:"O76DocumentoNome",gxvar:"A76DocumentoNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A76DocumentoNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z76DocumentoNome=n)},v2c:function(){gx.fn.setControlValue("DOCUMENTONOME",gx.O.A76DocumentoNome,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A76DocumentoNome=this.val())},val:function(){return gx.fn.getControlValue("DOCUMENTONOME")},nac:gx.falseFn};this.declareDomainHdlr(22,function(){});t[23]={id:23,fld:"",grid:0};t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCANEXODESCRICAO",fmt:0,gxz:"Z94DocAnexoDescricao",gxold:"O94DocAnexoDescricao",gxvar:"A94DocAnexoDescricao",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A94DocAnexoDescricao=n)},v2z:function(n){n!==undefined&&(gx.O.Z94DocAnexoDescricao=n)},v2c:function(){gx.fn.setControlValue("DOCANEXODESCRICAO",gx.O.A94DocAnexoDescricao,0)},c2v:function(){this.val()!==undefined&&(gx.O.A94DocAnexoDescricao=this.val())},val:function(){return gx.fn.getControlValue("DOCANEXODESCRICAO")},nac:gx.falseFn};t[28]={id:28,fld:"",grid:0};t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,lvl:0,type:"svchar",len:200,dec:0,sign:!1,ro:1,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCANEXOARQUIVO",fmt:0,gxz:"Z95DocAnexoArquivo",gxold:"O95DocAnexoArquivo",gxvar:"A95DocAnexoArquivo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A95DocAnexoArquivo=n)},v2z:function(n){n!==undefined&&(gx.O.Z95DocAnexoArquivo=n)},v2c:function(){gx.fn.setControlValue("DOCANEXOARQUIVO",gx.O.A95DocAnexoArquivo,0)},c2v:function(){this.val()!==undefined&&(gx.O.A95DocAnexoArquivo=this.val())},val:function(){return gx.fn.getControlValue("DOCANEXOARQUIVO")},nac:gx.falseFn};t[33]={id:33,fld:"",grid:0};t[34]={id:34,fld:"",grid:0};t[35]={id:35,fld:"",grid:0};t[36]={id:36,fld:"",grid:0};t[37]={id:37,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCANEXODATAINCLUSAO",fmt:0,gxz:"Z96DocAnexoDataInclusao",gxold:"O96DocAnexoDataInclusao",gxvar:"A96DocAnexoDataInclusao",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A96DocAnexoDataInclusao=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z96DocAnexoDataInclusao=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("DOCANEXODATAINCLUSAO",gx.O.A96DocAnexoDataInclusao,0)},c2v:function(){this.val()!==undefined&&(gx.O.A96DocAnexoDataInclusao=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("DOCANEXODATAINCLUSAO")},nac:gx.falseFn};t[38]={id:38,fld:"",grid:0};t[39]={id:39,fld:"",grid:0};t[40]={id:40,fld:"",grid:0};t[41]={id:41,fld:"",grid:0};t[42]={id:42,fld:"BTNUPDATE",grid:0,evt:"e136e2_client"};t[43]={id:43,fld:"",grid:0};t[44]={id:44,fld:"BTNDELETE",grid:0,evt:"e146e2_client"};this.A93DocAnexoId=0;this.Z93DocAnexoId=0;this.O93DocAnexoId=0;this.A76DocumentoNome="";this.Z76DocumentoNome="";this.O76DocumentoNome="";this.A94DocAnexoDescricao="";this.Z94DocAnexoDescricao="";this.O94DocAnexoDescricao="";this.A95DocAnexoArquivo="";this.Z95DocAnexoArquivo="";this.O95DocAnexoArquivo="";this.A96DocAnexoDataInclusao=gx.date.nullDate();this.Z96DocAnexoDataInclusao=gx.date.nullDate();this.O96DocAnexoDataInclusao=gx.date.nullDate();this.A93DocAnexoId=0;this.A76DocumentoNome="";this.A94DocAnexoDescricao="";this.A95DocAnexoArquivo="";this.A96DocAnexoDataInclusao=gx.date.nullDate();this.A75DocumentoId=0;this.AV12IsAuthorized_Update=!1;this.AV13IsAuthorized_Delete=!1;this.Events={e136e2_client:["'DOUPDATE'",!0],e146e2_client:["'DODELETE'",!0],e156e2_client:["ENTER",!0],e166e2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"A93DocAnexoId",fld:"DOCANEXOID",pic:"ZZZZZZZ9"},{av:"AV12IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV13IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0}],[]];this.EvtParms["'DOUPDATE'"]=[[{av:"AV12IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"A93DocAnexoId",fld:"DOCANEXOID",pic:"ZZZZZZZ9"}],[{ctrl:"BTNUPDATE",prop:"Visible"}]];this.EvtParms["'DODELETE'"]=[[{av:"AV13IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"A93DocAnexoId",fld:"DOCANEXOID",pic:"ZZZZZZZ9"}],[{ctrl:"BTNDELETE",prop:"Visible"}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_DOCANEXOID=[[],[]];this.setVCMap("AV12IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("AV13IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.Initialize()})