gx.evt.autoSkip=!1;gx.define("doccompartinterno",!1,function(){var n,t,i,r;this.ServerClass="doccompartinterno";this.PackageName="GeneXus.Programs";this.ServerFullClass="doccompartinterno.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV7CompartInternoId=gx.fn.getIntegerValue("vCOMPARTINTERNOID",".");this.AV8DocumentoId=gx.fn.getIntegerValue("vDOCUMENTOID",".");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV12TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Compartinternoid=function(){return this.validSrvEvt("Valid_Compartinternoid",0).then(function(n){return n}.closure(this))};this.Valid_Documentoid=function(){return this.validSrvEvt("Valid_Documentoid",0).then(function(n){return n}.closure(this))};this.Validv_Combocompartinternoid=function(){return this.validCliEvt("Validv_Combocompartinternoid",0,function(){try{var n=gx.util.balloon.getNew("vCOMBOCOMPARTINTERNOID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Combodocumentoid=function(){return this.validCliEvt("Validv_Combodocumentoid",0,function(){try{var n=gx.util.balloon.getNew("vCOMBODOCUMENTOID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e131649_client=function(){return this.clearMessages(),this.AV23ComboDocumentoId=gx.num.trunc(gx.num.val(this.COMBO_DOCUMENTOIDContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV23ComboDocumentoId",fld:"vCOMBODOCUMENTOID",pic:"ZZZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e141649_client=function(){return this.clearMessages(),this.AV19ComboCompartInternoId=gx.num.trunc(gx.num.val(this.COMBO_COMPARTINTERNOIDContainer.SelectedValue_get),0),this.refreshOutputs([{av:"AV19ComboCompartInternoId",fld:"vCOMBOCOMPARTINTERNOID",pic:"ZZZZZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e12162_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e151649_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e161649_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,26,27,28,29,30,31,32,33,34,35,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55];this.GXLastCtrlId=55;this.COMBO_COMPARTINTERNOIDContainer=gx.uc.getNew(this,25,0,"BootstrapDropDownOptions","COMBO_COMPARTINTERNOIDContainer","Combo_compartinternoid","COMBO_COMPARTINTERNOID");t=this.COMBO_COMPARTINTERNOIDContainer;t.setProp("Class","Class","","char");t.setProp("IconType","Icontype","Image","str");t.setProp("Icon","Icon","","str");t.setProp("Caption","Caption","","str");t.setProp("Tooltip","Tooltip","","str");t.setProp("Cls","Cls","ExtendedCombo AttributeFL","str");t.setDynProp("SelectedValue_set","Selectedvalue_set","","char");t.setProp("SelectedValue_get","Selectedvalue_get","","char");t.setDynProp("SelectedText_set","Selectedtext_set","","char");t.setProp("SelectedText_get","Selectedtext_get","","char");t.setDynProp("GAMOAuthToken","Gamoauthtoken","","char");t.setProp("DDOInternalName","Ddointernalname","","char");t.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");t.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");t.setDynProp("Enabled","Enabled",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");t.setProp("DataListType","Datalisttype","Dynamic","str");t.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");t.setProp("DataListFixedValues","Datalistfixedvalues","","char");t.setProp("IsGridItem","Isgriditem",!1,"bool");t.setProp("HasDescription","Hasdescription",!1,"bool");t.setProp("DataListProc","Datalistproc","DocCompartInternoLoadDVCombo","str");t.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix",' "ComboName": "CompartInternoId", "TrnMode": "INS", "IsDynamicCall": true, "CompartInternoId": 0, "DocumentoId": 0',"str");t.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");t.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");t.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");t.setProp("EmptyItem","Emptyitem",!1,"bool");t.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");t.setProp("HTMLTemplate","Htmltemplate","","str");t.setProp("MultipleValuesType","Multiplevaluestype","Text","str");t.setProp("LoadingData","Loadingdata","","str");t.setProp("NoResultsFound","Noresultsfound","","str");t.setProp("EmptyItemText","Emptyitemtext","","char");t.setProp("OnlySelectedValues","Onlyselectedvalues","","char");t.setProp("SelectAllText","Selectalltext","","char");t.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");t.setProp("AddNewOptionText","Addnewoptiontext","","str");t.addV2CFunction("AV15DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");t.addC2VFunction(function(n){n.ParentObject.AV15DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV15DDO_TitleSettingsIcons)});t.addV2CFunction("AV14CompartInternoId_Data","vCOMPARTINTERNOID_DATA","SetDropDownOptionsData");t.addC2VFunction(function(n){n.ParentObject.AV14CompartInternoId_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vCOMPARTINTERNOID_DATA",n.ParentObject.AV14CompartInternoId_Data)});t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("OnOptionClicked",this.e141649_client);this.setUserControl(t);this.COMBO_DOCUMENTOIDContainer=gx.uc.getNew(this,36,28,"BootstrapDropDownOptions","COMBO_DOCUMENTOIDContainer","Combo_documentoid","COMBO_DOCUMENTOID");i=this.COMBO_DOCUMENTOIDContainer;i.setProp("Class","Class","","char");i.setProp("IconType","Icontype","Image","str");i.setProp("Icon","Icon","","str");i.setProp("Caption","Caption","","str");i.setProp("Tooltip","Tooltip","","str");i.setProp("Cls","Cls","ExtendedCombo AttributeFL","str");i.setDynProp("SelectedValue_set","Selectedvalue_set","","char");i.setProp("SelectedValue_get","Selectedvalue_get","","char");i.setDynProp("SelectedText_set","Selectedtext_set","","char");i.setProp("SelectedText_get","Selectedtext_get","","char");i.setDynProp("GAMOAuthToken","Gamoauthtoken","","char");i.setProp("DDOInternalName","Ddointernalname","","char");i.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");i.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");i.setDynProp("Enabled","Enabled",!0,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");i.setProp("DataListType","Datalisttype","Dynamic","str");i.setProp("AllowMultipleSelection","Allowmultipleselection",!1,"bool");i.setProp("DataListFixedValues","Datalistfixedvalues","","char");i.setProp("IsGridItem","Isgriditem",!1,"bool");i.setProp("HasDescription","Hasdescription",!1,"bool");i.setProp("DataListProc","Datalistproc","DocCompartInternoLoadDVCombo","str");i.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix",' "ComboName": "DocumentoId", "TrnMode": "INS", "IsDynamicCall": true, "CompartInternoId": 0, "DocumentoId": 0',"str");i.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");i.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!1,"boolean");i.setProp("IncludeSelectAllOption","Includeselectalloption",!1,"boolean");i.setProp("EmptyItem","Emptyitem",!1,"bool");i.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");i.setProp("HTMLTemplate","Htmltemplate","","str");i.setProp("MultipleValuesType","Multiplevaluestype","Text","str");i.setProp("LoadingData","Loadingdata","","str");i.setProp("NoResultsFound","Noresultsfound","","str");i.setProp("EmptyItemText","Emptyitemtext","","char");i.setProp("OnlySelectedValues","Onlyselectedvalues","","char");i.setProp("SelectAllText","Selectalltext","","char");i.setProp("MultipleValuesSeparator","Multiplevaluesseparator","","char");i.setProp("AddNewOptionText","Addnewoptiontext","","str");i.addV2CFunction("AV15DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");i.addC2VFunction(function(n){n.ParentObject.AV15DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV15DDO_TitleSettingsIcons)});i.addV2CFunction("AV22DocumentoId_Data","vDOCUMENTOID_DATA","SetDropDownOptionsData");i.addC2VFunction(function(n){n.ParentObject.AV22DocumentoId_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vDOCUMENTOID_DATA",n.ParentObject.AV22DocumentoId_Data)});i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("OnOptionClicked",this.e131649_client);this.setUserControl(i);this.DVPANEL_TABLEATTRIBUTESContainer=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLEATTRIBUTESContainer","Dvpanel_tableattributes","DVPANEL_TABLEATTRIBUTES");r=this.DVPANEL_TABLEATTRIBUTESContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("Width","Width","100%","str");r.setProp("Height","Height","100","str");r.setProp("AutoWidth","Autowidth",!1,"bool");r.setProp("AutoHeight","Autoheight",!0,"bool");r.setProp("Cls","Cls","PanelCard Panel_BaseColor","str");r.setProp("ShowHeader","Showheader",!0,"bool");r.setProp("Title","Title","Informações Gerais","str");r.setProp("Collapsible","Collapsible",!1,"bool");r.setProp("Collapsed","Collapsed",!1,"bool");r.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");r.setProp("IconPosition","Iconposition","Right","str");r.setProp("AutoScroll","Autoscroll",!1,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"TABLEATTRIBUTES",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"TABLESPLITTEDCOMPARTINTERNOID",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TEXTBLOCKCOMPARTINTERNOID",format:0,grid:0,ctrltype:"textblock"};n[24]={id:24,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,lvl:0,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Compartinternoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COMPARTINTERNOID",fmt:0,gxz:"Z57CompartInternoId",gxold:"O57CompartInternoId",gxvar:"A57CompartInternoId",ucs:[],op:[],ip:[28],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A57CompartInternoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z57CompartInternoId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("COMPARTINTERNOID",gx.O.A57CompartInternoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A57CompartInternoId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("COMPARTINTERNOID",".")},nac:function(){return!(0==this.AV7CompartInternoId)}};this.declareDomainHdlr(28,function(){});n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"TABLESPLITTEDDOCUMENTOID",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"TEXTBLOCKDOCUMENTOID",format:0,grid:0,ctrltype:"textblock"};n[35]={id:35,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Documentoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCUMENTOID",fmt:0,gxz:"Z75DocumentoId",gxold:"O75DocumentoId",gxvar:"A75DocumentoId",ucs:[],op:[],ip:[39],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A75DocumentoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z75DocumentoId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("DOCUMENTOID",gx.O.A75DocumentoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A75DocumentoId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("DOCUMENTOID",".")},nac:function(){return!(0==this.AV8DocumentoId)}};this.declareDomainHdlr(39,function(){});n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"BTNTRN_ENTER",grid:0,evt:"e151649_client",std:"ENTER"};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"BTNTRN_CANCEL",grid:0,evt:"e161649_client"};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"BTNTRN_DELETE",grid:0,evt:"e171649_client",std:"DELETE"};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[52]={id:52,fld:"SECTIONATTRIBUTE_COMPARTINTERNOID",grid:0};n[53]={id:53,lvl:0,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Validv_Combocompartinternoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCOMBOCOMPARTINTERNOID",fmt:0,gxz:"ZV19ComboCompartInternoId",gxold:"OV19ComboCompartInternoId",gxvar:"AV19ComboCompartInternoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV19ComboCompartInternoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV19ComboCompartInternoId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCOMBOCOMPARTINTERNOID",gx.O.AV19ComboCompartInternoId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV19ComboCompartInternoId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCOMBOCOMPARTINTERNOID",".")},nac:gx.falseFn};n[54]={id:54,fld:"SECTIONATTRIBUTE_DOCUMENTOID",grid:0};n[55]={id:55,lvl:0,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Validv_Combodocumentoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCOMBODOCUMENTOID",fmt:0,gxz:"ZV23ComboDocumentoId",gxold:"OV23ComboDocumentoId",gxvar:"AV23ComboDocumentoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV23ComboDocumentoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV23ComboDocumentoId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCOMBODOCUMENTOID",gx.O.AV23ComboDocumentoId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV23ComboDocumentoId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCOMBODOCUMENTOID",".")},nac:gx.falseFn};this.A57CompartInternoId=0;this.Z57CompartInternoId=0;this.O57CompartInternoId=0;this.A75DocumentoId=0;this.Z75DocumentoId=0;this.O75DocumentoId=0;this.AV19ComboCompartInternoId=0;this.ZV19ComboCompartInternoId=0;this.OV19ComboCompartInternoId=0;this.AV23ComboDocumentoId=0;this.ZV23ComboDocumentoId=0;this.OV23ComboDocumentoId=0;this.AV9WWPContext={UserId:0,UserName:""};this.AV20GAMSession={};this.AV23ComboDocumentoId=0;this.AV19ComboCompartInternoId=0;this.AV12TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV7CompartInternoId=0;this.AV8DocumentoId=0;this.AV13WebSession={};this.A57CompartInternoId=0;this.A75DocumentoId=0;this.AV15DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:"",OptionGroup_fi:""};this.AV14CompartInternoId_Data=[];this.AV22DocumentoId_Data=[];this.Gx_mode="";this.Events={e12162_client:["AFTER TRN",!0],e151649_client:["ENTER",!0],e161649_client:["CANCEL",!0],e131649_client:["COMBO_DOCUMENTOID.ONOPTIONCLICKED",!1],e141649_client:["COMBO_COMPARTINTERNOID.ONOPTIONCLICKED",!1]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7CompartInternoId",fld:"vCOMPARTINTERNOID",pic:"ZZZZZZZ9",hsh:!0},{av:"AV8DocumentoId",fld:"vDOCUMENTOID",pic:"ZZZZZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV12TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7CompartInternoId",fld:"vCOMPARTINTERNOID",pic:"ZZZZZZZ9",hsh:!0},{av:"AV8DocumentoId",fld:"vDOCUMENTOID",pic:"ZZZZZZZ9",hsh:!0}],[]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV12TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EvtParms["COMBO_DOCUMENTOID.ONOPTIONCLICKED"]=[[{av:"this.COMBO_DOCUMENTOIDContainer.SelectedValue_get",ctrl:"COMBO_DOCUMENTOID",prop:"SelectedValue_get"}],[{av:"AV23ComboDocumentoId",fld:"vCOMBODOCUMENTOID",pic:"ZZZZZZZ9"}]];this.EvtParms["COMBO_COMPARTINTERNOID.ONOPTIONCLICKED"]=[[{av:"this.COMBO_COMPARTINTERNOIDContainer.SelectedValue_get",ctrl:"COMBO_COMPARTINTERNOID",prop:"SelectedValue_get"}],[{av:"AV19ComboCompartInternoId",fld:"vCOMBOCOMPARTINTERNOID",pic:"ZZZZZZZ9"}]];this.EvtParms.VALID_COMPARTINTERNOID=[[{av:"A57CompartInternoId",fld:"COMPARTINTERNOID",pic:"ZZZZZZZ9"}],[]];this.EvtParms.VALID_DOCUMENTOID=[[{av:"A75DocumentoId",fld:"DOCUMENTOID",pic:"ZZZZZZZ9"}],[]];this.EvtParms.VALIDV_COMBOCOMPARTINTERNOID=[[],[]];this.EvtParms.VALIDV_COMBODOCUMENTOID=[[],[]];this.EnterCtrl=["BTNTRN_ENTER"];this.setVCMap("AV7CompartInternoId","vCOMPARTINTERNOID",0,"int",8,0);this.setVCMap("AV8DocumentoId","vDOCUMENTOID",0,"int",8,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV12TrnContext","vTRNCONTEXT",0,"WWPBaseObjectsWWPTransactionContext",0,0);this.Initialize();this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"},OptionGroup_fi:{extr:"og"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})});gx.wi(function(){gx.createParentObj(this.doccompartinterno)})