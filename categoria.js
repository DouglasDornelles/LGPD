gx.evt.autoSkip=!1;gx.define("categoria",!1,function(){var n,t;this.ServerClass="categoria";this.PackageName="GeneXus.Programs";this.ServerFullClass="categoria.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV7CategoriaId=gx.fn.getIntegerValue("vCATEGORIAID",".");this.AV16IsOk=gx.fn.getControlValue("vISOK");this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",".");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV11TrnContext=gx.fn.getControlValue("vTRNCONTEXT");this.AV15IsCategoria=gx.fn.getControlValue("vISCATEGORIA");this.AV14CategoriaId_Out=gx.fn.getIntegerValue("vCATEGORIAID_OUT",".")};this.Valid_Categoriaid=function(){return this.validCliEvt("Valid_Categoriaid",0,function(){try{var n=gx.util.balloon.getNew("CATEGORIAID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Categorianome=function(){return this.validSrvEvt("Valid_Categorianome",0).then(function(n){return n}.closure(this))};this.e12092_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e13099_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e14099_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40];this.GXLastCtrlId=40;this.DVPANEL_TABLEATTRIBUTESContainer=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLEATTRIBUTESContainer","Dvpanel_tableattributes","DVPANEL_TABLEATTRIBUTES");t=this.DVPANEL_TABLEATTRIBUTESContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","100%","str");t.setProp("Height","Height","100","str");t.setProp("AutoWidth","Autowidth",!1,"bool");t.setProp("AutoHeight","Autoheight",!0,"bool");t.setProp("Cls","Cls","PanelCard Panel_BaseColor","str");t.setProp("ShowHeader","Showheader",!0,"bool");t.setProp("Title","Title","CATEGORIA","str");t.setProp("Collapsible","Collapsible",!1,"bool");t.setProp("Collapsed","Collapsed",!1,"bool");t.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");t.setProp("IconPosition","Iconposition","Right","str");t.setProp("AutoScroll","Autoscroll",!1,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"TABLEATTRIBUTES",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Categorianome,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CATEGORIANOME",fmt:0,gxz:"Z28CategoriaNome",gxold:"O28CategoriaNome",gxvar:"A28CategoriaNome",ucs:[],op:[22],ip:[40,22],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A28CategoriaNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z28CategoriaNome=n)},v2c:function(){gx.fn.setControlValue("CATEGORIANOME",gx.O.A28CategoriaNome,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A28CategoriaNome=this.val())},val:function(){return gx.fn.getControlValue("CATEGORIANOME")},nac:gx.falseFn};this.declareDomainHdlr(22,function(){});n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CATEGORIAATIVO",fmt:0,gxz:"Z29CategoriaAtivo",gxold:"O29CategoriaAtivo",gxvar:"A29CategoriaAtivo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A29CategoriaAtivo=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z29CategoriaAtivo=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setComboBoxValue("CATEGORIAATIVO",gx.O.A29CategoriaAtivo);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A29CategoriaAtivo=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("CATEGORIAATIVO")},nac:gx.falseFn};this.declareDomainHdlr(27,function(){});n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"BTNTRN_ENTER",grid:0,evt:"e13099_client",std:"ENTER"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"BTNTRN_CANCEL",grid:0,evt:"e14099_client"};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"BTNTRN_DELETE",grid:0,evt:"e15099_client",std:"DELETE"};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[40]={id:40,lvl:0,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Categoriaid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CATEGORIAID",fmt:0,gxz:"Z27CategoriaId",gxold:"O27CategoriaId",gxvar:"A27CategoriaId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A27CategoriaId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z27CategoriaId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CATEGORIAID",gx.O.A27CategoriaId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A27CategoriaId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CATEGORIAID",".")},nac:gx.falseFn};this.declareDomainHdlr(40,function(){});this.A28CategoriaNome="";this.Z28CategoriaNome="";this.O28CategoriaNome="";this.A29CategoriaAtivo=!1;this.Z29CategoriaAtivo=!1;this.O29CategoriaAtivo=!1;this.A27CategoriaId=0;this.Z27CategoriaId=0;this.O27CategoriaId=0;this.AV8WWPContext={UserId:0,UserName:""};this.AV11TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV7CategoriaId=0;this.AV15IsCategoria=!1;this.AV14CategoriaId_Out=0;this.AV12WebSession={};this.A27CategoriaId=0;this.A28CategoriaNome="";this.AV16IsOk=!1;this.Gx_BScreen=0;this.A29CategoriaAtivo=!1;this.Gx_mode="";this.Events={e12092_client:["AFTER TRN",!0],e13099_client:["ENTER",!0],e14099_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7CategoriaId",fld:"vCATEGORIAID",pic:"ZZZZZZZ9",hsh:!0},{av:"AV15IsCategoria",fld:"vISCATEGORIA",pic:""},{av:"AV14CategoriaId_Out",fld:"vCATEGORIAID_OUT",pic:"ZZZZZZZ9"}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV11TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7CategoriaId",fld:"vCATEGORIAID",pic:"ZZZZZZZ9",hsh:!0},{av:"A27CategoriaId",fld:"CATEGORIAID",pic:"ZZZZZZZ9"}],[]];this.EvtParms["AFTER TRN"]=[[{av:"A27CategoriaId",fld:"CATEGORIAID",pic:"ZZZZZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV11TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[{av:"AV14CategoriaId_Out",fld:"vCATEGORIAID_OUT",pic:"ZZZZZZZ9"},{av:"AV15IsCategoria",fld:"vISCATEGORIA",pic:""}]];this.EvtParms.VALID_CATEGORIANOME=[[{av:"A28CategoriaNome",fld:"CATEGORIANOME",pic:""},{av:"A27CategoriaId",fld:"CATEGORIAID",pic:"ZZZZZZZ9"},{av:"AV16IsOk",fld:"vISOK",pic:""}],[{av:"A28CategoriaNome",fld:"CATEGORIANOME",pic:""},{av:"AV16IsOk",fld:"vISOK",pic:""}]];this.EvtParms.VALID_CATEGORIAID=[[],[]];this.EnterCtrl=["BTNTRN_ENTER"];this.setVCMap("AV7CategoriaId","vCATEGORIAID",0,"int",8,0);this.setVCMap("AV16IsOk","vISOK",0,"boolean",4,0);this.setVCMap("Gx_BScreen","vGXBSCREEN",0,"int",1,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV11TrnContext","vTRNCONTEXT",0,"WWPBaseObjectsWWPTransactionContext",0,0);this.setVCMap("AV15IsCategoria","vISCATEGORIA",0,"boolean",4,0);this.setVCMap("AV14CategoriaId_Out","vCATEGORIAID_OUT",0,"int",8,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.categoria)})