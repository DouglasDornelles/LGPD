gx.evt.autoSkip=!1;gx.define("gam_wwapppermissions",!1,function(){var n,t;this.ServerClass="gam_wwapppermissions";this.PackageName="GeneXus.Security.Backend";this.ServerFullClass="gam_wwapppermissions.aspx";this.setObjectType("web");this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV8ApplicationId=gx.fn.getIntegerValue("vAPPLICATIONID",gx.thousandSeparator);this.AV21SearchFilter=gx.fn.getControlValue("vSEARCHFILTER");this.AV8ApplicationId=gx.fn.getIntegerValue("vAPPLICATIONID",gx.thousandSeparator);this.AV21SearchFilter=gx.fn.getControlValue("vSEARCHFILTER");this.AV8ApplicationId=gx.fn.getIntegerValue("vAPPLICATIONID",gx.thousandSeparator)};this.Validv_Permissionaccesstypedefault=function(){return this.validCliEvt("Validv_Permissionaccesstypedefault",0,function(){try{var n=gx.util.balloon.getNew("vPERMISSIONACCESSTYPEDEFAULT");if(this.AnyError=0,!(gx.text.compare(this.AV19PermissionAccessTypeDefault,"A")==0||gx.text.compare(this.AV19PermissionAccessTypeDefault,"R")==0||gx.text.compare("",this.AV19PermissionAccessTypeDefault)==0))try{n.setError(gx.text.format(gx.getMessage("GXSPC_OutOfRange"),gx.getMessage("Permission Access Type Default"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Permissiontypefilter=function(){return this.validCliEvt("Validv_Permissiontypefilter",0,function(){try{var n=gx.util.balloon.getNew("vPERMISSIONTYPEFILTER");if(this.AnyError=0,!(gx.text.compare(this.AV20PermissionTypeFilter,"A")==0||gx.text.compare(this.AV20PermissionTypeFilter,"F")==0||gx.text.compare(this.AV20PermissionTypeFilter,"P")==0||gx.text.compare(this.AV20PermissionTypeFilter,"C")==0))try{n.setError(gx.text.format(gx.getMessage("GXSPC_OutOfRange"),gx.getMessage("Permission Type Filter"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Isautomaticpermission=function(){return this.validCliEvt("Validv_Isautomaticpermission",0,function(){try{var n=gx.util.balloon.getNew("vISAUTOMATICPERMISSION");if(this.AnyError=0,!(gx.text.compare(this.AV16isAutomaticPermission,"A")==0||gx.text.compare(this.AV16isAutomaticPermission,"T")==0||gx.text.compare(this.AV16isAutomaticPermission,"F")==0))try{n.setError(gx.text.format(gx.getMessage("GXSPC_OutOfRange"),gx.getMessage("is Automatic Permission"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Accesstype=function(){var n=gx.fn.currentGridRowImpl(70);return this.validCliEvt("Validv_Accesstype",70,function(){try{var n=gx.util.balloon.getNew("vACCESSTYPE");if(this.AnyError=0,!(gx.text.compare(this.AV5AccessType,"A")==0||gx.text.compare(this.AV5AccessType,"R")==0))try{n.setError(gx.text.format(gx.getMessage("GXSPC_OutOfRange"),gx.getMessage("Default Access"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e111c1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("FILTERSCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("FILTERSCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("HIDE","Caption",gx.getMessage("HIDE FILTERS")),gx.fn.setCtrlProperty("HIDE","Class","HideFiltersButton"),gx.fn.setCtrlProperty("GRIDCELL","Class","WWGridCell")):(gx.fn.setCtrlProperty("FILTERSCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("HIDE","Caption",gx.getMessage("SHOW FILTERS")),gx.fn.setCtrlProperty("HIDE","Class","ShowFiltersButton"),gx.fn.setCtrlProperty("GRIDCELL","Class","WWGridCellExpanded")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("FILTERSCONTAINER","Class")',ctrl:"FILTERSCONTAINER",prop:"Class"},{ctrl:"HIDE",prop:"Caption"},{ctrl:"HIDE",prop:"Class"},{av:'gx.fn.getCtrlProperty("GRIDCELL","Class")',ctrl:"GRIDCELL",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e121c1_client=function(){return this.clearMessages(),this.call("gam_apppermissionentry.aspx",["INS",this.AV8ApplicationId,""],null,["Mode","ApplicationId","GUID"]),this.refreshOutputs([{av:"AV8ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e151c2_client=function(){return this.clearMessages(),this.call("gam_apppermissionentry.aspx",["DSP",this.AV8ApplicationId,this.AV15Id],null,["Mode","ApplicationId","GUID"]),this.refreshOutputs([{av:"AV15Id",fld:"vID",pic:""},{av:"AV8ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e161c2_client=function(){return this.clearMessages(),this.call("gam_apppermissionentry.aspx",["UPD",this.AV8ApplicationId,this.AV15Id],null,["Mode","ApplicationId","GUID"]),this.refreshOutputs([{av:"AV15Id",fld:"vID",pic:""},{av:"AV8ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e171c2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e181c1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,68,69,71,72,73,74,75,76];this.GXLastCtrlId=76;this.GridwwContainer=new gx.grid.grid(this,2,"WbpLvl2",70,"Gridww","Gridww","GridwwContainer",this.CmpContext,this.IsMasterPage,"gam_wwapppermissions",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px",gx.getMessage("GXM_newrow"),!1,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridwwContainer;t.addSingleLineEdit("Name",71,"vNAME",gx.getMessage("Permission name"),"","Name","char",0,"px",120,80,"left","e151c2_client",[],"Name","Name",!0,0,!1,!1,"Attribute TextLikeLink SmallLink",1,"WWColumn");t.addSingleLineEdit("Dsc",72,"vDSC",gx.getMessage("Description"),"","Dsc","char",0,"px",254,80,"left",null,[],"Dsc","Dsc",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addComboBox("Accesstype",73,"vACCESSTYPE",gx.getMessage("Default Access"),"AccessType","char",null,0,!0,!1,0,"px","WWColumn WWSecondaryColumn");t.addCheckBox("Isparent",74,"vISPARENT",gx.getMessage("Is Parent"),"","IsParent","boolean","true","false",null,!0,!1,0,"px","WWColumn WWSecondaryColumn");t.addSingleLineEdit("Btnupd",75,"vBTNUPD","","","BtnUpd","char",0,"px",20,20,"left","e161c2_client",[],"Btnupd","BtnUpd",!0,0,!1,!1,"TextActionAttribute TextLikeLink",1,"WWTextActionColumn");t.addSingleLineEdit("Id",76,"vID",gx.getMessage("GUID"),"","Id","char",0,"px",40,40,"left",null,[],"Id","Id",!1,0,!1,!1,"Attribute",1,"");this.GridwwContainer.emptyText=gx.getMessage("");this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLE2",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLE3",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"HIDE",grid:0,evt:"e111c1_client"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"TABLE1",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"CANCEL",grid:0,evt:"e181c1_client"};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"ADDNEW",grid:0,evt:"e121c1_client"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFILNAME",fmt:0,gxz:"ZV13FilName",gxold:"OV13FilName",gxvar:"AV13FilName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13FilName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13FilName=n)},v2c:function(){gx.fn.setControlValue("vFILNAME",gx.O.AV13FilName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV13FilName=this.val())},val:function(){return gx.fn.getControlValue("vFILNAME")},nac:gx.falseFn};this.declareDomainHdlr(24,function(){});n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"CELLFILTERS",grid:0};n[27]={id:27,fld:"FILTERSCONTAINER",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"TABLE4",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,lvl:0,type:"char",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Permissionaccesstypedefault,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPERMISSIONACCESSTYPEDEFAULT",fmt:0,gxz:"ZV19PermissionAccessTypeDefault",gxold:"OV19PermissionAccessTypeDefault",gxvar:"AV19PermissionAccessTypeDefault",ucs:[],op:[37],ip:[37],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV19PermissionAccessTypeDefault=n)},v2z:function(n){n!==undefined&&(gx.O.ZV19PermissionAccessTypeDefault=n)},v2c:function(){gx.fn.setComboBoxValue("vPERMISSIONACCESSTYPEDEFAULT",gx.O.AV19PermissionAccessTypeDefault);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV19PermissionAccessTypeDefault=this.val())},val:function(){return gx.fn.getControlValue("vPERMISSIONACCESSTYPEDEFAULT")},nac:gx.falseFn};this.declareDomainHdlr(37,function(){});n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"TABLE5",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,lvl:0,type:"char",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Permissiontypefilter,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPERMISSIONTYPEFILTER",fmt:0,gxz:"ZV20PermissionTypeFilter",gxold:"OV20PermissionTypeFilter",gxvar:"AV20PermissionTypeFilter",ucs:[],op:[47],ip:[47],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV20PermissionTypeFilter=n)},v2z:function(n){n!==undefined&&(gx.O.ZV20PermissionTypeFilter=n)},v2c:function(){gx.fn.setComboBoxValue("vPERMISSIONTYPEFILTER",gx.O.AV20PermissionTypeFilter);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV20PermissionTypeFilter=this.val())},val:function(){return gx.fn.getControlValue("vPERMISSIONTYPEFILTER")},nac:gx.falseFn};this.declareDomainHdlr(47,function(){});n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"TABLE6",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,lvl:0,type:"char",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Isautomaticpermission,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vISAUTOMATICPERMISSION",fmt:0,gxz:"ZV16isAutomaticPermission",gxold:"OV16isAutomaticPermission",gxvar:"AV16isAutomaticPermission",ucs:[],op:[57],ip:[57],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV16isAutomaticPermission=n)},v2z:function(n){n!==undefined&&(gx.O.ZV16isAutomaticPermission=n)},v2c:function(){gx.fn.setComboBoxValue("vISAUTOMATICPERMISSION",gx.O.AV16isAutomaticPermission);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV16isAutomaticPermission=this.val())},val:function(){return gx.fn.getControlValue("vISAUTOMATICPERMISSION")},nac:gx.falseFn};this.declareDomainHdlr(57,function(){});n[58]={id:58,fld:"GRIDCELL",grid:0};n[59]={id:59,fld:"GRIDTABLE",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLNAME",fmt:0,gxz:"ZV24GXV1",gxold:"OV24GXV1",gxvar:"GXV1",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.GXV1=n)},v2z:function(n){n!==undefined&&(gx.O.ZV24GXV1=n)},v2c:function(){gx.fn.setControlValue("CTLNAME",gx.O.GXV1,0)},c2v:function(){this.val()!==undefined&&(gx.O.GXV1=this.val())},val:function(){return gx.fn.getControlValue("CTLNAME")},nac:gx.falseFn};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"",grid:0};n[71]={id:71,lvl:2,type:"char",len:120,dec:0,sign:!1,ro:0,isacc:0,grid:70,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",fmt:0,gxz:"ZV18Name",gxold:"OV18Name",gxvar:"AV18Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV18Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV18Name=n)},v2c:function(n){gx.fn.setGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(70),gx.O.AV18Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV18Name=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(70))},nac:gx.falseFn,evt:"e151c2_client"};n[72]={id:72,lvl:2,type:"char",len:254,dec:0,sign:!1,ro:0,isacc:0,grid:70,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDSC",fmt:0,gxz:"ZV11Dsc",gxold:"OV11Dsc",gxvar:"AV11Dsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV11Dsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11Dsc=n)},v2c:function(n){gx.fn.setGridControlValue("vDSC",n||gx.fn.currentGridRowImpl(70),gx.O.AV11Dsc,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV11Dsc=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDSC",n||gx.fn.currentGridRowImpl(70))},nac:gx.falseFn};n[73]={id:73,lvl:2,type:"char",len:1,dec:0,sign:!1,ro:0,isacc:0,grid:70,gxgrid:this.GridwwContainer,fnc:this.Validv_Accesstype,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vACCESSTYPE",fmt:0,gxz:"ZV5AccessType",gxold:"OV5AccessType",gxvar:"AV5AccessType",ucs:[],op:[73],ip:[73],nacdep:[],ctrltype:"combo",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5AccessType=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5AccessType=n)},v2c:function(n){gx.fn.setGridComboBoxValue("vACCESSTYPE",n||gx.fn.currentGridRowImpl(70),gx.O.AV5AccessType);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV5AccessType=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vACCESSTYPE",n||gx.fn.currentGridRowImpl(70))},nac:gx.falseFn};n[74]={id:74,lvl:2,type:"boolean",len:4,dec:0,sign:!1,ro:0,isacc:0,grid:70,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vISPARENT",fmt:0,gxz:"ZV17IsParent",gxold:"OV17IsParent",gxvar:"AV17IsParent",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV17IsParent=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV17IsParent=gx.lang.booleanValue(n))},v2c:function(n){gx.fn.setGridCheckBoxValue("vISPARENT",n||gx.fn.currentGridRowImpl(70),gx.O.AV17IsParent,!0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV17IsParent=gx.lang.booleanValue(this.val(n)))},val:function(n){return gx.fn.getGridControlValue("vISPARENT",n||gx.fn.currentGridRowImpl(70))},nac:gx.falseFn,values:["true","false"]};n[75]={id:75,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:70,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBTNUPD",fmt:0,gxz:"ZV10BtnUpd",gxold:"OV10BtnUpd",gxvar:"AV10BtnUpd",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV10BtnUpd=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10BtnUpd=n)},v2c:function(n){gx.fn.setGridControlValue("vBTNUPD",n||gx.fn.currentGridRowImpl(70),gx.O.AV10BtnUpd,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV10BtnUpd=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBTNUPD",n||gx.fn.currentGridRowImpl(70))},nac:gx.falseFn,evt:"e161c2_client"};n[76]={id:76,lvl:2,type:"char",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:70,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vID",fmt:0,gxz:"ZV15Id",gxold:"OV15Id",gxvar:"AV15Id",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV15Id=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15Id=n)},v2c:function(n){gx.fn.setGridControlValue("vID",n||gx.fn.currentGridRowImpl(70),gx.O.AV15Id,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV15Id=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vID",n||gx.fn.currentGridRowImpl(70))},nac:gx.falseFn};this.AV13FilName="";this.ZV13FilName="";this.OV13FilName="";this.AV19PermissionAccessTypeDefault="";this.ZV19PermissionAccessTypeDefault="";this.OV19PermissionAccessTypeDefault="";this.AV20PermissionTypeFilter="";this.ZV20PermissionTypeFilter="";this.OV20PermissionTypeFilter="";this.AV16isAutomaticPermission="";this.ZV16isAutomaticPermission="";this.OV16isAutomaticPermission="";this.GXV1="";this.ZV24GXV1="";this.OV24GXV1="";this.ZV18Name="";this.OV18Name="";this.ZV11Dsc="";this.OV11Dsc="";this.ZV5AccessType="";this.OV5AccessType="";this.ZV17IsParent=!1;this.OV17IsParent=!1;this.ZV10BtnUpd="";this.OV10BtnUpd="";this.ZV15Id="";this.OV15Id="";this.AV13FilName="";this.AV19PermissionAccessTypeDefault="";this.AV20PermissionTypeFilter="";this.AV16isAutomaticPermission="";this.GXV1="";this.AV8ApplicationId=0;this.AV18Name="";this.AV11Dsc="";this.AV5AccessType="";this.AV17IsParent=!1;this.AV10BtnUpd="";this.AV15Id="";this.AV21SearchFilter="";this.AV7Application={};this.Events={e171c2_client:["ENTER",!0],e181c1_client:["CANCEL",!0],e111c1_client:["'HIDE'",!1],e121c1_client:["'ADDNEW'",!1],e151c2_client:["VNAME.CLICK",!1],e161c2_client:["VBTNUPD.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV8ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV13FilName",fld:"vFILNAME",pic:""},{ctrl:"vPERMISSIONACCESSTYPEDEFAULT"},{av:"AV19PermissionAccessTypeDefault",fld:"vPERMISSIONACCESSTYPEDEFAULT",pic:""},{ctrl:"vPERMISSIONTYPEFILTER"},{av:"AV20PermissionTypeFilter",fld:"vPERMISSIONTYPEFILTER",pic:""},{ctrl:"vISAUTOMATICPERMISSION"},{av:"AV16isAutomaticPermission",fld:"vISAUTOMATICPERMISSION",pic:""},{av:"AV21SearchFilter",fld:"vSEARCHFILTER",pic:"",hsh:!0}],[]];this.EvtParms["GRIDWW.LOAD"]=[[{av:"AV8ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV13FilName",fld:"vFILNAME",pic:""},{av:"AV21SearchFilter",fld:"vSEARCHFILTER",pic:"",hsh:!0},{ctrl:"vPERMISSIONACCESSTYPEDEFAULT"},{av:"AV19PermissionAccessTypeDefault",fld:"vPERMISSIONACCESSTYPEDEFAULT",pic:""},{ctrl:"vPERMISSIONTYPEFILTER"},{av:"AV20PermissionTypeFilter",fld:"vPERMISSIONTYPEFILTER",pic:""},{ctrl:"vISAUTOMATICPERMISSION"},{av:"AV16isAutomaticPermission",fld:"vISAUTOMATICPERMISSION",pic:""}],[{av:"AV10BtnUpd",fld:"vBTNUPD",pic:""},{av:"AV15Id",fld:"vID",pic:""},{av:"AV18Name",fld:"vNAME",pic:""},{av:"AV11Dsc",fld:"vDSC",pic:""},{ctrl:"vACCESSTYPE"},{av:"AV5AccessType",fld:"vACCESSTYPE",pic:""},{av:"AV17IsParent",fld:"vISPARENT",pic:""}]];this.EvtParms["'HIDE'"]=[[{av:'gx.fn.getCtrlProperty("FILTERSCONTAINER","Class")',ctrl:"FILTERSCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("FILTERSCONTAINER","Class")',ctrl:"FILTERSCONTAINER",prop:"Class"},{ctrl:"HIDE",prop:"Caption"},{ctrl:"HIDE",prop:"Class"},{av:'gx.fn.getCtrlProperty("GRIDCELL","Class")',ctrl:"GRIDCELL",prop:"Class"}]];this.EvtParms["'ADDNEW'"]=[[{av:"AV8ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV8ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["VNAME.CLICK"]=[[{av:"AV8ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV15Id",fld:"vID",pic:""}],[{av:"AV15Id",fld:"vID",pic:""},{av:"AV8ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["VBTNUPD.CLICK"]=[[{av:"AV8ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV15Id",fld:"vID",pic:""}],[{av:"AV15Id",fld:"vID",pic:""},{av:"AV8ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALIDV_PERMISSIONACCESSTYPEDEFAULT=[[],[]];this.EvtParms.VALIDV_PERMISSIONTYPEFILTER=[[],[]];this.EvtParms.VALIDV_ISAUTOMATICPERMISSION=[[],[]];this.EvtParms.VALIDV_ACCESSTYPE=[[{ctrl:"vACCESSTYPE"},{av:"AV5AccessType",fld:"vACCESSTYPE",pic:""}],[{ctrl:"vACCESSTYPE"},{av:"AV5AccessType",fld:"vACCESSTYPE",pic:""}]];this.setVCMap("AV8ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV21SearchFilter","vSEARCHFILTER",0,"char",254,0);this.setVCMap("AV8ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV21SearchFilter","vSEARCHFILTER",0,"char",254,0);this.setVCMap("AV8ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV8ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV21SearchFilter","vSEARCHFILTER",0,"char",254,0);t.addRefreshingVar({rfrVar:"AV8ApplicationId"});t.addRefreshingVar(this.GXValidFnc[24]);t.addRefreshingVar({rfrVar:"AV21SearchFilter"});t.addRefreshingVar(this.GXValidFnc[37]);t.addRefreshingVar(this.GXValidFnc[47]);t.addRefreshingVar(this.GXValidFnc[57]);t.addRefreshingParm({rfrVar:"AV8ApplicationId"});t.addRefreshingParm(this.GXValidFnc[24]);t.addRefreshingParm({rfrVar:"AV21SearchFilter"});t.addRefreshingParm(this.GXValidFnc[37]);t.addRefreshingParm(this.GXValidFnc[47]);t.addRefreshingParm(this.GXValidFnc[57]);this.addBCProperty("Application",["Name"],this.GXValidFnc[64],"AV7Application");this.Initialize()});gx.wi(function(){gx.createParentObj(this.gam_wwapppermissions)})