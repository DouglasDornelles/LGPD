gx.evt.autoSkip=!1;gx.define("campo",!1,function(){var n,t;this.ServerClass="campo";this.PackageName="GeneXus.Programs";this.ServerFullClass="campo.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV7CampoId=gx.fn.getIntegerValue("vCAMPOID",".");this.AV13Insert_TelaId=gx.fn.getIntegerValue("vINSERT_TELAID",".");this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",".");this.AV16Pgmname=gx.fn.getControlValue("vPGMNAME");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV11TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Campoid=function(){return this.validCliEvt("Valid_Campoid",0,function(){try{var n=gx.util.balloon.getNew("CAMPOID");this.AnyError=0;this.refreshOutputs([{ctrl:"TELAID"},{av:"A133TelaId",fld:"TELAID",pic:"ZZZZZZZ9"}])}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Camponome=function(){return this.validCliEvt("Valid_Camponome",0,function(){try{var n=gx.util.balloon.getNew("CAMPONOME");this.AnyError=0;try{this.A136CampoNome=gx.text.upper(this.A136CampoNome)}catch(t){}this.refreshOutputs([{ctrl:"TELAID"},{av:"A133TelaId",fld:"TELAID",pic:"ZZZZZZZ9"}])}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Telaid=function(){return this.validSrvEvt("Valid_Telaid",0).then(function(n){return n}.closure(this))};this.e121f2_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e131f58_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e141f58_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45];this.GXLastCtrlId=45;this.DVPANEL_TABLEATTRIBUTESContainer=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLEATTRIBUTESContainer","Dvpanel_tableattributes","DVPANEL_TABLEATTRIBUTES");t=this.DVPANEL_TABLEATTRIBUTESContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","100%","str");t.setProp("Height","Height","100","str");t.setProp("AutoWidth","Autowidth",!1,"bool");t.setProp("AutoHeight","Autoheight",!0,"bool");t.setProp("Cls","Cls","PanelCard Panel_BaseColor","str");t.setProp("ShowHeader","Showheader",!0,"bool");t.setProp("Title","Title","CAMPO","str");t.setProp("Collapsible","Collapsible",!1,"bool");t.setProp("Collapsed","Collapsed",!1,"bool");t.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");t.setProp("IconPosition","Iconposition","Right","str");t.setProp("AutoScroll","Autoscroll",!1,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"TABLEATTRIBUTES",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Camponome,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CAMPONOME",fmt:0,gxz:"Z136CampoNome",gxold:"O136CampoNome",gxvar:"A136CampoNome",ucs:[],op:[22],ip:[22],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A136CampoNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z136CampoNome=n)},v2c:function(){gx.fn.setControlValue("CAMPONOME",gx.O.A136CampoNome,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A136CampoNome=this.val())},val:function(){return gx.fn.getControlValue("CAMPONOME")},nac:gx.falseFn};this.declareDomainHdlr(22,function(){});n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,lvl:0,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Telaid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TELAID",fmt:0,gxz:"Z133TelaId",gxold:"O133TelaId",gxvar:"A133TelaId",ucs:[],op:[],ip:[27],nacdep:[],ctrltype:"dyncombo",v2v:function(n){n!==undefined&&(gx.O.A133TelaId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z133TelaId=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("TELAID",gx.O.A133TelaId);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A133TelaId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TELAID",".")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(0==this.AV13Insert_TelaId)}};this.declareDomainHdlr(27,function(){});n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CAMPOATIVO",fmt:0,gxz:"Z138CampoAtivo",gxold:"O138CampoAtivo",gxvar:"A138CampoAtivo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A138CampoAtivo=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z138CampoAtivo=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setComboBoxValue("CAMPOATIVO",gx.O.A138CampoAtivo);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A138CampoAtivo=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("CAMPOATIVO")},nac:gx.falseFn};this.declareDomainHdlr(32,function(){});n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"BTNTRN_ENTER",grid:0,evt:"e131f58_client",std:"ENTER"};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"BTNTRN_CANCEL",grid:0,evt:"e141f58_client"};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"BTNTRN_DELETE",grid:0,evt:"e151f58_client",std:"DELETE"};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[45]={id:45,lvl:0,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Campoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CAMPOID",fmt:0,gxz:"Z135CampoId",gxold:"O135CampoId",gxvar:"A135CampoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A135CampoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z135CampoId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CAMPOID",gx.O.A135CampoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A135CampoId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CAMPOID",".")},nac:gx.falseFn};this.declareDomainHdlr(45,function(){});this.A136CampoNome="";this.Z136CampoNome="";this.O136CampoNome="";this.A133TelaId=0;this.Z133TelaId=0;this.O133TelaId=0;this.A138CampoAtivo=!1;this.Z138CampoAtivo=!1;this.O138CampoAtivo=!1;this.A135CampoId=0;this.Z135CampoId=0;this.O135CampoId=0;this.AV8WWPContext={UserId:0,UserName:""};this.AV11TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV17GXV1=0;this.AV13Insert_TelaId=0;this.AV14TrnContextAtt={AttributeName:"",AttributeValue:""};this.AV7CampoId=0;this.AV12WebSession={};this.A135CampoId=0;this.A133TelaId=0;this.A136CampoNome="";this.AV16Pgmname="";this.Gx_BScreen=0;this.A138CampoAtivo=!1;this.Gx_mode="";this.Events={e121f2_client:["AFTER TRN",!0],e131f58_client:["ENTER",!0],e141f58_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7CampoId",fld:"vCAMPOID",pic:"ZZZZZZZ9",hsh:!0},{ctrl:"TELAID"},{av:"A133TelaId",fld:"TELAID",pic:"ZZZZZZZ9"}],[{ctrl:"TELAID"},{av:"A133TelaId",fld:"TELAID",pic:"ZZZZZZZ9"}]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV11TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7CampoId",fld:"vCAMPOID",pic:"ZZZZZZZ9",hsh:!0},{av:"A135CampoId",fld:"CAMPOID",pic:"ZZZZZZZ9"},{ctrl:"TELAID"},{av:"A133TelaId",fld:"TELAID",pic:"ZZZZZZZ9"}],[{ctrl:"TELAID"},{av:"A133TelaId",fld:"TELAID",pic:"ZZZZZZZ9"}]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV11TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{ctrl:"TELAID"},{av:"A133TelaId",fld:"TELAID",pic:"ZZZZZZZ9"}],[{ctrl:"TELAID"},{av:"A133TelaId",fld:"TELAID",pic:"ZZZZZZZ9"}]];this.EvtParms.VALID_CAMPONOME=[[{av:"A136CampoNome",fld:"CAMPONOME",pic:""},{ctrl:"TELAID"},{av:"A133TelaId",fld:"TELAID",pic:"ZZZZZZZ9"}],[{av:"A136CampoNome",fld:"CAMPONOME",pic:""},{ctrl:"TELAID"},{av:"A133TelaId",fld:"TELAID",pic:"ZZZZZZZ9"}]];this.EvtParms.VALID_TELAID=[[{ctrl:"TELAID"},{av:"A133TelaId",fld:"TELAID",pic:"ZZZZZZZ9"}],[{ctrl:"TELAID"},{av:"A133TelaId",fld:"TELAID",pic:"ZZZZZZZ9"}]];this.EvtParms.VALID_CAMPOID=[[{ctrl:"TELAID"},{av:"A133TelaId",fld:"TELAID",pic:"ZZZZZZZ9"}],[{ctrl:"TELAID"},{av:"A133TelaId",fld:"TELAID",pic:"ZZZZZZZ9"}]];this.EnterCtrl=["BTNTRN_ENTER"];this.setVCMap("AV7CampoId","vCAMPOID",0,"int",8,0);this.setVCMap("AV13Insert_TelaId","vINSERT_TELAID",0,"int",8,0);this.setVCMap("Gx_BScreen","vGXBSCREEN",0,"int",1,0);this.setVCMap("AV16Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV11TrnContext","vTRNCONTEXT",0,"WWPBaseObjectsWWPTransactionContext",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.campo)})