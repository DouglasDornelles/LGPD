gx.evt.autoSkip=!1;gx.define("gam_wwsecuritypolicies",!1,function(){var n,t;this.ServerClass="gam_wwsecuritypolicies";this.PackageName="GeneXus.Security.Backend";this.ServerFullClass="gam_wwsecuritypolicies.aspx";this.setObjectType("web");this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.e15082_client=function(){return this.clearMessages(),this.call("gam_securitypolicyentry.aspx",["DSP",this.AV10Id],null,["Mode","Id"]),this.refreshOutputs([{av:"AV10Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e11082_client=function(){return this.executeServerEvent("'ADDNEW'",!1,null,!1,!1)};this.e13082_client=function(){return this.executeServerEvent("VBTNUPD.CLICK",!0,arguments[0],!1,!1)};this.e14082_client=function(){return this.executeServerEvent("VBTNSAVEAS.CLICK",!0,arguments[0],!1,!1)};this.e16082_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e17082_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,21,22,24,25,26,27];this.GXLastCtrlId=27;this.GridwwContainer=new gx.grid.grid(this,2,"WbpLvl2",23,"Gridww","Gridww","GridwwContainer",this.CmpContext,this.IsMasterPage,"gam_wwsecuritypolicies",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px",gx.getMessage("GXM_newrow"),!1,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridwwContainer;t.addSingleLineEdit("Name",24,"vNAME",gx.getMessage("Name"),"","Name","char",0,"px",254,80,"left","e15082_client",[],"Name","Name",!0,0,!1,!1,"Attribute TextLikeLink SmallLink",1,"WWColumn");t.addSingleLineEdit("Btnupd",25,"vBTNUPD","","","BtnUpd","char",0,"px",20,20,"left","e13082_client",[],"Btnupd","BtnUpd",!0,0,!1,!1,"TextActionAttribute TextLikeLink",1,"WWTextActionColumn");t.addSingleLineEdit("Btnsaveas",26,"vBTNSAVEAS","","","BtnSaveAs","char",0,"px",20,20,"left","e14082_client",[],"Btnsaveas","BtnSaveAs",!0,0,!1,!1,"TextActionAttribute TextLikeLink",1,"WWTextActionColumn");t.addSingleLineEdit("Id",27,"vID",gx.getMessage("Key Numeric Long"),"","Id","int",0,"px",12,12,"right",null,[],"Id","Id",!1,0,!1,!1,"Attribute",1,"");this.GridwwContainer.emptyText=gx.getMessage("");this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLETOP",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"ADDNEW1",grid:0,evt:"e11082_client"};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSEARCH",fmt:0,gxz:"ZV14Search",gxold:"OV14Search",gxvar:"AV14Search",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV14Search=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14Search=n)},v2c:function(){gx.fn.setControlValue("vSEARCH",gx.O.AV14Search,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV14Search=this.val())},val:function(){return gx.fn.getControlValue("vSEARCH")},nac:gx.falseFn};this.declareDomainHdlr(14,function(){});n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TABLE1",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[24]={id:24,lvl:2,type:"char",len:254,dec:0,sign:!1,ro:0,isacc:0,grid:23,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",fmt:0,gxz:"ZV12Name",gxold:"OV12Name",gxvar:"AV12Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Name=n)},v2c:function(n){gx.fn.setGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(23),gx.O.AV12Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12Name=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(23))},nac:gx.falseFn,evt:"e15082_client"};n[25]={id:25,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:23,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBTNUPD",fmt:0,gxz:"ZV6BtnUpd",gxold:"OV6BtnUpd",gxvar:"AV6BtnUpd",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV6BtnUpd=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6BtnUpd=n)},v2c:function(n){gx.fn.setGridControlValue("vBTNUPD",n||gx.fn.currentGridRowImpl(23),gx.O.AV6BtnUpd,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV6BtnUpd=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBTNUPD",n||gx.fn.currentGridRowImpl(23))},nac:gx.falseFn,evt:"e13082_client"};n[26]={id:26,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:23,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBTNSAVEAS",fmt:0,gxz:"ZV5BtnSaveAs",gxold:"OV5BtnSaveAs",gxvar:"AV5BtnSaveAs",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV5BtnSaveAs=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5BtnSaveAs=n)},v2c:function(n){gx.fn.setGridControlValue("vBTNSAVEAS",n||gx.fn.currentGridRowImpl(23),gx.O.AV5BtnSaveAs,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV5BtnSaveAs=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBTNSAVEAS",n||gx.fn.currentGridRowImpl(23))},nac:gx.falseFn,evt:"e14082_client"};n[27]={id:27,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,isacc:0,grid:23,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vID",fmt:0,gxz:"ZV10Id",gxold:"OV10Id",gxvar:"AV10Id",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV10Id=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV10Id=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vID",n||gx.fn.currentGridRowImpl(23),gx.O.AV10Id,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV10Id=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vID",n||gx.fn.currentGridRowImpl(23),gx.thousandSeparator)},nac:gx.falseFn};this.AV14Search="";this.ZV14Search="";this.OV14Search="";this.ZV12Name="";this.OV12Name="";this.ZV6BtnUpd="";this.OV6BtnUpd="";this.ZV5BtnSaveAs="";this.OV5BtnSaveAs="";this.ZV10Id=0;this.OV10Id=0;this.AV14Search="";this.AV12Name="";this.AV6BtnUpd="";this.AV5BtnSaveAs="";this.AV10Id=0;this.Events={e11082_client:["'ADDNEW'",!0],e13082_client:["VBTNUPD.CLICK",!0],e14082_client:["VBTNSAVEAS.CLICK",!0],e16082_client:["ENTER",!0],e17082_client:["CANCEL",!0],e15082_client:["VNAME.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV14Search",fld:"vSEARCH",pic:""}],[]];this.EvtParms["GRIDWW.LOAD"]=[[{av:"AV14Search",fld:"vSEARCH",pic:""}],[{av:"AV6BtnUpd",fld:"vBTNUPD",pic:""},{av:"AV5BtnSaveAs",fld:"vBTNSAVEAS",pic:""},{av:"AV10Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV12Name",fld:"vNAME",pic:""}]];this.EvtParms["'ADDNEW'"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV14Search",fld:"vSEARCH",pic:""}],[]];this.EvtParms["VNAME.CLICK"]=[[{av:"AV10Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV10Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["VBTNUPD.CLICK"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV14Search",fld:"vSEARCH",pic:""},{av:"AV10Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV10Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["VBTNSAVEAS.CLICK"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV14Search",fld:"vSEARCH",pic:""},{av:"AV10Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms.ENTER=[[],[]];t.addRefreshingVar(this.GXValidFnc[14]);t.addRefreshingParm(this.GXValidFnc[14]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gam_wwsecuritypolicies)})