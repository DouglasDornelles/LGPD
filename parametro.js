gx.evt.autoSkip=!1;gx.define("parametro",!1,function(){var n,t;this.ServerClass="parametro";this.PackageName="GeneXus.Programs";this.ServerFullClass="parametro.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV7ParametroCod=gx.fn.getControlValue("vPARAMETROCOD");this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",".");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV11TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Parametrocod=function(){return this.validCliEvt("Valid_Parametrocod",0,function(){try{var n=gx.util.balloon.getNew("PARAMETROCOD");if(this.AnyError=0,gx.text.compare("",this.A124ParametroCod)==0)try{n.setError(gx.text.format("%1 é obrigatório.","Parametro Cod","","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Parametrodescricao=function(){return this.validCliEvt("Valid_Parametrodescricao",0,function(){try{var n=gx.util.balloon.getNew("PARAMETRODESCRICAO");if(this.AnyError=0,gx.text.compare("",this.A125ParametroDescricao)==0)try{n.setError(gx.text.format("%1 é obrigatório.","Parametro Descricao","","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Parametrovalor=function(){return this.validCliEvt("Valid_Parametrovalor",0,function(){try{var n=gx.util.balloon.getNew("PARAMETROVALOR");if(this.AnyError=0,gx.text.compare("",this.A126ParametroValor)==0)try{n.setError(gx.text.format("%1 é obrigatório.","Parametro Valor","","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Parametrodatainclusao=function(){return this.validCliEvt("Valid_Parametrodatainclusao",0,function(){try{var n=gx.util.balloon.getNew("PARAMETRODATAINCLUSAO");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A128ParametroDataInclusao)==0||new gx.date.gxdate(this.A128ParametroDataInclusao).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Parametro Data Inclusao fora do intervalo");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Parametrodataalteracao=function(){return this.validCliEvt("Valid_Parametrodataalteracao",0,function(){try{var n=gx.util.balloon.getNew("PARAMETRODATAALTERACAO");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A129ParametroDataAlteracao)==0||new gx.date.gxdate(this.A129ParametroDataAlteracao).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Parametro Data Alteracao fora do intervalo");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e121d2_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e131d56_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e141d56_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58];this.GXLastCtrlId=58;this.DVPANEL_TABLEATTRIBUTESContainer=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLEATTRIBUTESContainer","Dvpanel_tableattributes","DVPANEL_TABLEATTRIBUTES");t=this.DVPANEL_TABLEATTRIBUTESContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","100%","str");t.setProp("Height","Height","100","str");t.setProp("AutoWidth","Autowidth",!1,"bool");t.setProp("AutoHeight","Autoheight",!0,"bool");t.setProp("Cls","Cls","PanelCard Panel_BaseColor","str");t.setProp("ShowHeader","Showheader",!0,"bool");t.setProp("Title","Title","PARÂMETRO","str");t.setProp("Collapsible","Collapsible",!1,"bool");t.setProp("Collapsed","Collapsed",!1,"bool");t.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");t.setProp("IconPosition","Iconposition","Right","str");t.setProp("AutoScroll","Autoscroll",!1,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"TABLEATTRIBUTES",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"char",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Parametrocod,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROCOD",fmt:0,gxz:"Z124ParametroCod",gxold:"O124ParametroCod",gxvar:"A124ParametroCod",ucs:[],op:[22],ip:[22],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A124ParametroCod=n)},v2z:function(n){n!==undefined&&(gx.O.Z124ParametroCod=n)},v2c:function(){gx.fn.setControlValue("PARAMETROCOD",gx.O.A124ParametroCod,0)},c2v:function(){this.val()!==undefined&&(gx.O.A124ParametroCod=this.val())},val:function(){return gx.fn.getControlValue("PARAMETROCOD")},nac:function(){return!(gx.text.compare("",this.AV7ParametroCod)==0)}};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Parametrodescricao,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETRODESCRICAO",fmt:0,gxz:"Z125ParametroDescricao",gxold:"O125ParametroDescricao",gxvar:"A125ParametroDescricao",ucs:[],op:[27],ip:[27],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A125ParametroDescricao=n)},v2z:function(n){n!==undefined&&(gx.O.Z125ParametroDescricao=n)},v2c:function(){gx.fn.setControlValue("PARAMETRODESCRICAO",gx.O.A125ParametroDescricao,0)},c2v:function(){this.val()!==undefined&&(gx.O.A125ParametroDescricao=this.val())},val:function(){return gx.fn.getControlValue("PARAMETRODESCRICAO")},nac:gx.falseFn};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Parametrovalor,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROVALOR",fmt:0,gxz:"Z126ParametroValor",gxold:"O126ParametroValor",gxvar:"A126ParametroValor",ucs:[],op:[32],ip:[32],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A126ParametroValor=n)},v2z:function(n){n!==undefined&&(gx.O.Z126ParametroValor=n)},v2c:function(){gx.fn.setControlValue("PARAMETROVALOR",gx.O.A126ParametroValor,0)},c2v:function(){this.val()!==undefined&&(gx.O.A126ParametroValor=this.val())},val:function(){return gx.fn.getControlValue("PARAMETROVALOR")},nac:gx.falseFn};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,lvl:0,type:"svchar",len:500,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROCOMENTARIO",fmt:0,gxz:"Z127ParametroComentario",gxold:"O127ParametroComentario",gxvar:"A127ParametroComentario",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A127ParametroComentario=n)},v2z:function(n){n!==undefined&&(gx.O.Z127ParametroComentario=n)},v2c:function(){gx.fn.setControlValue("PARAMETROCOMENTARIO",gx.O.A127ParametroComentario,0)},c2v:function(){this.val()!==undefined&&(gx.O.A127ParametroComentario=this.val())},val:function(){return gx.fn.getControlValue("PARAMETROCOMENTARIO")},nac:gx.falseFn};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROATIVO",fmt:0,gxz:"Z132ParametroAtivo",gxold:"O132ParametroAtivo",gxvar:"A132ParametroAtivo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A132ParametroAtivo=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z132ParametroAtivo=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setComboBoxValue("PARAMETROATIVO",gx.O.A132ParametroAtivo);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A132ParametroAtivo=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("PARAMETROATIVO")},nac:gx.falseFn};this.declareDomainHdlr(42,function(){});n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"BTNTRN_ENTER",grid:0,evt:"e131d56_client",std:"ENTER"};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"BTNTRN_CANCEL",grid:0,evt:"e141d56_client"};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"BTNTRN_DELETE",grid:0,evt:"e151d56_client",std:"DELETE"};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[55]={id:55,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Parametrodatainclusao,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETRODATAINCLUSAO",fmt:0,gxz:"Z128ParametroDataInclusao",gxold:"O128ParametroDataInclusao",gxvar:"A128ParametroDataInclusao",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[55],ip:[55],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A128ParametroDataInclusao=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z128ParametroDataInclusao=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("PARAMETRODATAINCLUSAO",gx.O.A128ParametroDataInclusao,0)},c2v:function(){this.val()!==undefined&&(gx.O.A128ParametroDataInclusao=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("PARAMETRODATAINCLUSAO")},nac:gx.falseFn};n[56]={id:56,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Parametrodataalteracao,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETRODATAALTERACAO",fmt:0,gxz:"Z129ParametroDataAlteracao",gxold:"O129ParametroDataAlteracao",gxvar:"A129ParametroDataAlteracao",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[56],ip:[56],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A129ParametroDataAlteracao=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z129ParametroDataAlteracao=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("PARAMETRODATAALTERACAO",gx.O.A129ParametroDataAlteracao,0)},c2v:function(){this.val()!==undefined&&(gx.O.A129ParametroDataAlteracao=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("PARAMETRODATAALTERACAO")},nac:gx.falseFn};n[57]={id:57,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROUSUARIOINCLUSAO",fmt:0,gxz:"Z130ParametroUsuarioInclusao",gxold:"O130ParametroUsuarioInclusao",gxvar:"A130ParametroUsuarioInclusao",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A130ParametroUsuarioInclusao=n)},v2z:function(n){n!==undefined&&(gx.O.Z130ParametroUsuarioInclusao=n)},v2c:function(){gx.fn.setControlValue("PARAMETROUSUARIOINCLUSAO",gx.O.A130ParametroUsuarioInclusao,0)},c2v:function(){this.val()!==undefined&&(gx.O.A130ParametroUsuarioInclusao=this.val())},val:function(){return gx.fn.getControlValue("PARAMETROUSUARIOINCLUSAO")},nac:gx.falseFn};n[58]={id:58,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETROUSUARIOALTERACAO",fmt:0,gxz:"Z131ParametroUsuarioAlteracao",gxold:"O131ParametroUsuarioAlteracao",gxvar:"A131ParametroUsuarioAlteracao",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A131ParametroUsuarioAlteracao=n)},v2z:function(n){n!==undefined&&(gx.O.Z131ParametroUsuarioAlteracao=n)},v2c:function(){gx.fn.setControlValue("PARAMETROUSUARIOALTERACAO",gx.O.A131ParametroUsuarioAlteracao,0)},c2v:function(){this.val()!==undefined&&(gx.O.A131ParametroUsuarioAlteracao=this.val())},val:function(){return gx.fn.getControlValue("PARAMETROUSUARIOALTERACAO")},nac:gx.falseFn};this.A124ParametroCod="";this.Z124ParametroCod="";this.O124ParametroCod="";this.A125ParametroDescricao="";this.Z125ParametroDescricao="";this.O125ParametroDescricao="";this.A126ParametroValor="";this.Z126ParametroValor="";this.O126ParametroValor="";this.A127ParametroComentario="";this.Z127ParametroComentario="";this.O127ParametroComentario="";this.A132ParametroAtivo=!1;this.Z132ParametroAtivo=!1;this.O132ParametroAtivo=!1;this.A128ParametroDataInclusao=gx.date.nullDate();this.Z128ParametroDataInclusao=gx.date.nullDate();this.O128ParametroDataInclusao=gx.date.nullDate();this.A129ParametroDataAlteracao=gx.date.nullDate();this.Z129ParametroDataAlteracao=gx.date.nullDate();this.O129ParametroDataAlteracao=gx.date.nullDate();this.A130ParametroUsuarioInclusao="";this.Z130ParametroUsuarioInclusao="";this.O130ParametroUsuarioInclusao="";this.A131ParametroUsuarioAlteracao="";this.Z131ParametroUsuarioAlteracao="";this.O131ParametroUsuarioAlteracao="";this.AV8WWPContext={UserId:0,UserName:""};this.AV11TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV7ParametroCod="";this.AV12WebSession={};this.A124ParametroCod="";this.A129ParametroDataAlteracao=gx.date.nullDate();this.A131ParametroUsuarioAlteracao="";this.Gx_BScreen=0;this.A125ParametroDescricao="";this.A126ParametroValor="";this.A127ParametroComentario="";this.A128ParametroDataInclusao=gx.date.nullDate();this.A130ParametroUsuarioInclusao="";this.A132ParametroAtivo=!1;this.Gx_mode="";this.Events={e121d2_client:["AFTER TRN",!0],e131d56_client:["ENTER",!0],e141d56_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7ParametroCod",fld:"vPARAMETROCOD",pic:"",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV11TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7ParametroCod",fld:"vPARAMETROCOD",pic:"",hsh:!0}],[]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV11TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EvtParms.VALID_PARAMETROCOD=[[{av:"A124ParametroCod",fld:"PARAMETROCOD",pic:""}],[{av:"A124ParametroCod",fld:"PARAMETROCOD",pic:""}]];this.EvtParms.VALID_PARAMETRODESCRICAO=[[{av:"A125ParametroDescricao",fld:"PARAMETRODESCRICAO",pic:""}],[{av:"A125ParametroDescricao",fld:"PARAMETRODESCRICAO",pic:""}]];this.EvtParms.VALID_PARAMETROVALOR=[[{av:"A126ParametroValor",fld:"PARAMETROVALOR",pic:""}],[{av:"A126ParametroValor",fld:"PARAMETROVALOR",pic:""}]];this.EvtParms.VALID_PARAMETRODATAINCLUSAO=[[{av:"A128ParametroDataInclusao",fld:"PARAMETRODATAINCLUSAO",pic:""}],[{av:"A128ParametroDataInclusao",fld:"PARAMETRODATAINCLUSAO",pic:""}]];this.EvtParms.VALID_PARAMETRODATAALTERACAO=[[{av:"A129ParametroDataAlteracao",fld:"PARAMETRODATAALTERACAO",pic:""}],[{av:"A129ParametroDataAlteracao",fld:"PARAMETRODATAALTERACAO",pic:""}]];this.EnterCtrl=["BTNTRN_ENTER"];this.setVCMap("AV7ParametroCod","vPARAMETROCOD",0,"char",10,0);this.setVCMap("Gx_BScreen","vGXBSCREEN",0,"int",1,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV11TrnContext","vTRNCONTEXT",0,"WWPBaseObjectsWWPTransactionContext",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.parametro)})