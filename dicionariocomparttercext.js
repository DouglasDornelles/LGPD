gx.evt.autoSkip=!1;gx.define("dicionariocomparttercext",!1,function(){var n,t,i,r;this.ServerClass="dicionariocomparttercext";this.PackageName="GeneXus.Programs";this.ServerFullClass="dicionariocomparttercext.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV8CompartTercExternoId=gx.fn.getIntegerValue("vCOMPARTTERCEXTERNOID",".");this.AV9DocDicionarioId=gx.fn.getIntegerValue("vDOCDICIONARIOID",".");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV13TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Comparttercexternoid=function(){return this.validSrvEvt("Valid_Comparttercexternoid",0).then(function(n){return n}.closure(this))};this.Valid_Docdicionarioid=function(){return this.validSrvEvt("Valid_Docdicionarioid",0).then(function(n){return n}.closure(this))};this.Validv_Combocomparttercexternoid=function(){return this.validCliEvt("Validv_Combocomparttercexternoid",0,function(){try{var n=gx.util.balloon.getNew("vCOMBOCOMPARTTERCEXTERNOID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Combodocdicionarioid=function(){return this.validCliEvt("Validv_Combodocdicionarioid",0,function(){try{var n=gx.util.balloon.getNew("vCOMBODOCDICIONARIOID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e130x54_client=function(){return this.clearMessages(),this.AV24ComboDocDicionarioId=gx.num.trunc(gx.num.val(this.COMBO_DOCDICIONARIOIDContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV24ComboDocDicionarioId",fld:"vCOMBODOCDICIONARIOID",pic:"ZZZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e140x54_client=function(){return this.clearMessages(),this.AV20ComboCompartTercExternoId=gx.num.trunc(gx.num.val(this.COMBO_COMPARTTERCEXTERNOIDContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV20ComboCompartTercExternoId",fld:"vCOMBOCOMPARTTERCEXTERNOID",pic:"ZZZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e120x2_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e150x54_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e160x54_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,26,27,28,29,30,31,32,33,34,35,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55];this.GXLastCtrlId=55;this.COMBO_COMPARTTERCEXTERNOIDContainer=gx.uc.getNew(this,25,0,"BootstrapDropDownOptions","COMBO_COMPARTTERCEXTERNOIDContainer","Combo_comparttercexternoid","COMBO_COMPARTTERCEXTERNOID");t=this.COMBO_COMPARTTERCEXTERNOIDContainer;t.setProp("Class","Class","","char");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","ExtendedCombo AttributeFL","str");t.setDynProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setDynProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setDynProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("DDOInternalName","Ddointernalname","","char");t.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");t.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");t.setDynProp("Enabled","Enabled",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");t.setProp("DataListType","Datalisttype","Dynamic","str");t.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");t.setProp("DataListFixedValues","Datalistfixedvalues","","char");t.setProp("IsGridItem","Isgriditem",!1,"bool");t.setProp("HasDescription","Hasdescription",!1,"bool");t.setProp("DataListProc","Datalistproc","DicionarioCompartTercExtLoadDVCombo","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix",' "ComboName": "CompartTercExternoId", "TrnMode": "INS", "IsDynamicCall": true, "CompartTercExternoId": 0, "DocDicionarioId": 0',"str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");t.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");t.setProp("EmptyItem","Emptyitem",!1,"bool");t.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");t.setProp("HTMLTemplate","Htmltemplate","","str");t.setProp("MultipleValuesType","Multiplevaluestype","Text","str");t.setProp("LoadingData","Loadingdata","","str");t.setProp("NoResultsFound","Noresultsfound","","str");t.setProp("EmptyItemText","Emptyitemtext","","char");t.setProp("OnlySelectedValues","Onlyselectedvalues","","char");t.setProp("SelectAllText","Selectalltext","","char");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");t.setProp("AddNewOptionText","Addnewoptiontext","","str");t.addV2CFunction("AV16DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");t.addC2VFunction(function(n){n.ParentObject.AV16DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV16DDO_TitleSettingsIcons)});t.addV2CFunction("AV15CompartTercExternoId_Data","vCOMPARTTERCEXTERNOID_DATA","SetDropDownOptionsData");t.addC2VFunction(function(n){n.ParentObject.AV15CompartTercExternoId_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vCOMPARTTERCEXTERNOID_DATA",n.ParentObject.AV15CompartTercExternoId_Data)});t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e140x54_client);this.setUserControl(t);this.COMBO_DOCDICIONARIOIDContainer=gx.uc.getNew(this,36,28,"BootstrapDropDownOptions","COMBO_DOCDICIONARIOIDContainer","Combo_docdicionarioid","COMBO_DOCDICIONARIOID");i=this.COMBO_DOCDICIONARIOIDContainer;i.setProp("Class","Class","","char");i.setProp("IconType","Icontype","Image","str");i.setProp("Icon","Icon","","str");i.setProp("Caption","Caption","","str");i.setProp("Tooltip","Tooltip","","str");i.setProp("Cls","Cls","ExtendedCombo AttributeFL","str");i.setDynProp("SelectedValue_set","Selectedvalue_set","","char");i.setProp("SelectedValue_get","Selectedvalue_get","","char");i.setDynProp("SelectedText_set","Selectedtext_set","","char");i.setProp("SelectedText_get","Selectedtext_get","","char");i.setDynProp("GAMOAuthToken","Gamoauthtoken","","char");i.setProp("DDOInternalName","Ddointernalname","","char");i.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");i.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");i.setDynProp("Enabled","Enabled",!0,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");i.setProp("DataListType","Datalisttype","Dynamic","str");i.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");i.setProp("DataListFixedValues","Datalistfixedvalues","","char");i.setProp("IsGridItem","Isgriditem",!1,"bool");i.setProp("HasDescription","Hasdescription",!1,"bool");i.setProp("DataListProc","Datalistproc","DicionarioCompartTercExtLoadDVCombo","str");i.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix",' "ComboName": "DocDicionarioId", "TrnMode": "INS", "IsDynamicCall": true, "CompartTercExternoId": 0, "DocDicionarioId": 0',"str");i.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");i.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");i.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");i.setProp("EmptyItem","Emptyitem",!1,"bool");i.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");i.setProp("HTMLTemplate","Htmltemplate","","str");i.setProp("MultipleValuesType","Multiplevaluestype","Text","str");i.setProp("LoadingData","Loadingdata","","str");i.setProp("NoResultsFound","Noresultsfound","","str");i.setProp("EmptyItemText","Emptyitemtext","","char");i.setProp("OnlySelectedValues","Onlyselectedvalues","","char");i.setProp("SelectAllText","Selectalltext","","char");i.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");i.setProp("AddNewOptionText","Addnewoptiontext","","str");i.addV2CFunction("AV16DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");i.addC2VFunction(function(n){n.ParentObject.AV16DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV16DDO_TitleSettingsIcons)});i.addV2CFunction("AV23DocDicionarioId_Data","vDOCDICIONARIOID_DATA","SetDropDownOptionsData");i.addC2VFunction(function(n){n.ParentObject.AV23DocDicionarioId_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vDOCDICIONARIOID_DATA",n.ParentObject.AV23DocDicionarioId_Data)});i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("OnOptionClicked",this.e130x54_client);this.setUserControl(i);this.DVPANEL_TABLEATTRIBUTESContainer=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLEATTRIBUTESContainer","Dvpanel_tableattributes","DVPANEL_TABLEATTRIBUTES");r=this.DVPANEL_TABLEATTRIBUTESContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("Width","Width","100%","str");r.setProp("Height","Height","100","str");r.setProp("AutoWidth","Autowidth",!1,"bool");r.setProp("AutoHeight","Autoheight",!0,"bool");r.setProp("Cls","Cls","PanelCard Panel_BaseColor","str");r.setProp("ShowHeader","Showheader",!0,"bool");r.setProp("Title","Title","Informações Gerais","str");r.setProp("Collapsible","Collapsible",!1,"bool");r.setProp("Collapsed","Collapsed",!1,"bool");r.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");r.setProp("IconPosition","Iconposition","Right","str");r.setProp("AutoScroll","Autoscroll",!1,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"TABLEATTRIBUTES",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"TABLESPLITTEDCOMPARTTERCEXTERNOID",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TEXTBLOCKCOMPARTTERCEXTERNOID",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,lvl:0,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Comparttercexternoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COMPARTTERCEXTERNOID",fmt:0,gxz:"Z66CompartTercExternoId",gxold:"O66CompartTercExternoId",gxvar:"A66CompartTercExternoId",ucs:[],op:[],ip:[28],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A66CompartTercExternoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z66CompartTercExternoId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("COMPARTTERCEXTERNOID",gx.O.A66CompartTercExternoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A66CompartTercExternoId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("COMPARTTERCEXTERNOID",".")},nac:function(){return!(0==this.AV8CompartTercExternoId)}};this.declareDomainHdlr(28,function(){});n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"TABLESPLITTEDDOCDICIONARIOID",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"TEXTBLOCKDOCDICIONARIOID",format:0,grid:0,ctrltype:"textblock"};n[35]={id:35,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Docdicionarioid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCDICIONARIOID",fmt:0,gxz:"Z98DocDicionarioId",gxold:"O98DocDicionarioId",gxvar:"A98DocDicionarioId",ucs:[],op:[],ip:[39],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A98DocDicionarioId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z98DocDicionarioId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("DOCDICIONARIOID",gx.O.A98DocDicionarioId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A98DocDicionarioId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("DOCDICIONARIOID",".")},nac:function(){return!(0==this.AV9DocDicionarioId)}};this.declareDomainHdlr(39,function(){});n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"BTNTRN_ENTER",grid:0,evt:"e150x54_client",std:"ENTER"};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"BTNTRN_CANCEL",grid:0,evt:"e160x54_client"};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"BTNTRN_DELETE",grid:0,evt:"e170x54_client",std:"DELETE"};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[52]={id:52,fld:"SECTIONATTRIBUTE_COMPARTTERCEXTERNOID",grid:0};n[53]={id:53,lvl:0,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Validv_Combocomparttercexternoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCOMBOCOMPARTTERCEXTERNOID",fmt:0,gxz:"ZV20ComboCompartTercExternoId",gxold:"OV20ComboCompartTercExternoId",gxvar:"AV20ComboCompartTercExternoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV20ComboCompartTercExternoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV20ComboCompartTercExternoId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCOMBOCOMPARTTERCEXTERNOID",gx.O.AV20ComboCompartTercExternoId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV20ComboCompartTercExternoId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCOMBOCOMPARTTERCEXTERNOID",".")},nac:gx.falseFn};n[54]={id:54,fld:"SECTIONATTRIBUTE_DOCDICIONARIOID",grid:0};n[55]={id:55,lvl:0,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Validv_Combodocdicionarioid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCOMBODOCDICIONARIOID",fmt:0,gxz:"ZV24ComboDocDicionarioId",gxold:"OV24ComboDocDicionarioId",gxvar:"AV24ComboDocDicionarioId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV24ComboDocDicionarioId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV24ComboDocDicionarioId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCOMBODOCDICIONARIOID",gx.O.AV24ComboDocDicionarioId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV24ComboDocDicionarioId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCOMBODOCDICIONARIOID",".")},nac:gx.falseFn};this.A66CompartTercExternoId=0;this.Z66CompartTercExternoId=0;this.O66CompartTercExternoId=0;this.A98DocDicionarioId=0;this.Z98DocDicionarioId=0;this.O98DocDicionarioId=0;this.AV20ComboCompartTercExternoId=0;this.ZV20ComboCompartTercExternoId=0;this.OV20ComboCompartTercExternoId=0;this.AV24ComboDocDicionarioId=0;this.ZV24ComboDocDicionarioId=0;this.OV24ComboDocDicionarioId=0;this.AV10WWPContext={UserId:0,UserName:""};this.AV21GAMSession={};this.AV24ComboDocDicionarioId=0;this.AV20ComboCompartTercExternoId=0;this.AV13TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV8CompartTercExternoId=0;this.AV9DocDicionarioId=0;this.AV14WebSession={};this.A66CompartTercExternoId=0;this.A98DocDicionarioId=0;this.AV16DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:"",OptionGroup_fi:""};this.AV15CompartTercExternoId_Data=[];this.AV23DocDicionarioId_Data=[];this.Gx_mode="";this.Events={e120x2_client:["AFTER TRN",!0],e150x54_client:["ENTER",!0],e160x54_client:["CANCEL",!0],e130x54_client:["COMBO_DOCDICIONARIOID.ONOPTIONCLICKED",!1],e140x54_client:["COMBO_COMPARTTERCEXTERNOID.ONOPTIONCLICKED",!1]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV8CompartTercExternoId",fld:"vCOMPARTTERCEXTERNOID",pic:"ZZZZZZZ9",hsh:!0},{av:"AV9DocDicionarioId",fld:"vDOCDICIONARIOID",pic:"ZZZZZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV13TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV8CompartTercExternoId",fld:"vCOMPARTTERCEXTERNOID",pic:"ZZZZZZZ9",hsh:!0},{av:"AV9DocDicionarioId",fld:"vDOCDICIONARIOID",pic:"ZZZZZZZ9",hsh:!0}],[]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV13TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EvtParms["COMBO_DOCDICIONARIOID.ONOPTIONCLICKED"]=[[{av:"this.COMBO_DOCDICIONARIOIDContainer.SelectedValue_get",ctrl:"COMBO_DOCDICIONARIOID",prop:"SelectedValue_get"}],[{av:"AV24ComboDocDicionarioId",fld:"vCOMBODOCDICIONARIOID",pic:"ZZZZZZZ9"}]];this.EvtParms["COMBO_COMPARTTERCEXTERNOID.ONOPTIONCLICKED"]=[[{av:"this.COMBO_COMPARTTERCEXTERNOIDContainer.SelectedValue_get",ctrl:"COMBO_COMPARTTERCEXTERNOID",prop:"SelectedValue_get"}],[{av:"AV20ComboCompartTercExternoId",fld:"vCOMBOCOMPARTTERCEXTERNOID",pic:"ZZZZZZZ9"}]];this.EvtParms.VALID_COMPARTTERCEXTERNOID=[[{av:"A66CompartTercExternoId",fld:"COMPARTTERCEXTERNOID",pic:"ZZZZZZZ9"}],[]];this.EvtParms.VALID_DOCDICIONARIOID=[[{av:"A98DocDicionarioId",fld:"DOCDICIONARIOID",pic:"ZZZZZZZ9"}],[]];this.EvtParms.VALIDV_COMBOCOMPARTTERCEXTERNOID=[[],[]];this.EvtParms.VALIDV_COMBODOCDICIONARIOID=[[],[]];this.EnterCtrl=["BTNTRN_ENTER"];this.setVCMap("AV8CompartTercExternoId","vCOMPARTTERCEXTERNOID",0,"int",8,0);this.setVCMap("AV9DocDicionarioId","vDOCDICIONARIOID",0,"int",8,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV13TrnContext","vTRNCONTEXT",0,"WWPBaseObjectsWWPTransactionContext",0,0);this.Initialize();this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"},OptionGroup_fi:{extr:"og"}});this.setSDTMapping("GeneXusSecurity\\GAMSession",{User:{sdt:"GeneXusSecurity\\GAMUser"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})});gx.wi(function(){gx.createParentObj(this.dicionariocomparttercext)})