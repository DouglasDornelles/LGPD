gx.evt.autoSkip=!1;gx.define("gamrecoverpasswordstep2",!1,function(){var t,i,r,n;this.ServerClass="gamrecoverpasswordstep2";this.PackageName="GeneXus.Programs";this.ServerFullClass="gamrecoverpasswordstep2.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV13UserAuthTypeName=gx.fn.getControlValue("vUSERAUTHTYPENAME");this.AV9KeyToChangePassword=gx.fn.getControlValue("vKEYTOCHANGEPASSWORD");this.AV17UserRememberMe=gx.fn.getIntegerValue("vUSERREMEMBERME",".");this.AV18IDP_State=gx.fn.getControlValue("vIDP_STATE")};this.e120g2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e130g2_client=function(){return this.executeServerEvent("BACKTOLOGIN.CLICK",!0,null,!1,!0)};this.e150g2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,17,18,19,20,21,22,23,26,27,30,31,34,35,38,39,40,41,42,43,44,47,48,49,51,52];this.GXLastCtrlId=52;this.DVPANEL_TABLELOGINContainer=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLELOGINContainer","Dvpanel_tablelogin","DVPANEL_TABLELOGIN");i=this.DVPANEL_TABLELOGINContainer;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Width","Width","100%","str");i.setProp("Height","Height","100","str");i.setProp("AutoWidth","Autowidth",!1,"bool");i.setProp("AutoHeight","Autoheight",!0,"bool");i.setProp("Cls","Cls","PanelNoHeader CellMax400","str");i.setProp("ShowHeader","Showheader",!0,"bool");i.setProp("Title","Title","","str");i.setProp("Collapsible","Collapsible",!1,"bool");i.setProp("Collapsed","Collapsed",!1,"bool");i.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");i.setProp("IconPosition","Iconposition","Right","str");i.setProp("AutoScroll","Autoscroll",!1,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);this.DVPANEL_TABLEERRORCONTENTContainer=gx.uc.getNew(this,45,27,"BootstrapPanel","DVPANEL_TABLEERRORCONTENTContainer","Dvpanel_tableerrorcontent","DVPANEL_TABLEERRORCONTENT");r=this.DVPANEL_TABLEERRORCONTENTContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("Width","Width","100%","str");r.setProp("Height","Height","100","str");r.setProp("AutoWidth","Autowidth",!1,"bool");r.setProp("AutoHeight","Autoheight",!0,"bool");r.setProp("Cls","Cls","PanelNoHeader CellMax400","str");r.setProp("ShowHeader","Showheader",!0,"bool");r.setProp("Title","Title","","str");r.setProp("Collapsible","Collapsible",!1,"bool");r.setProp("Collapsed","Collapsed",!1,"bool");r.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");r.setProp("IconPosition","Iconposition","Right","str");r.setProp("AutoScroll","Autoscroll",!1,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);this.WWPUTILITESContainer=gx.uc.getNew(this,53,27,"DVelop_WorkWithPlusUtilities","WWPUTILITESContainer","Wwputilites","WWPUTILITES");n=this.WWPUTILITESContainer;n.setProp("Class","Class","","char");n.setProp("Enabled","Enabled",!0,"boolean");n.setProp("EnableAutoUpdateFromDocumentTitle","Enableautoupdatefromdocumenttitle",!1,"bool");n.setProp("EnableFixObjectFitCover","Enablefixobjectfitcover",!1,"bool");n.setProp("EnableFloatingLabels","Enablefloatinglabels",!0,"bool");n.setProp("EmpowerTabs","Empowertabs",!1,"bool");n.setProp("EnableUpdateRowSelectionStatus","Enableupdaterowselectionstatus",!1,"bool");n.setProp("CurrentTab_ReturnUrl","Currenttab_returnurl","","char");n.setProp("EnableConvertComboToBootstrapSelect","Enableconvertcombotobootstrapselect",!1,"bool");n.setProp("AllowColumnResizing","Allowcolumnresizing",!0,"bool");n.setProp("AllowColumnReordering","Allowcolumnreordering",!0,"bool");n.setProp("AllowColumnDragging","Allowcolumndragging",!1,"bool");n.setProp("AllowColumnsRestore","Allowcolumnsrestore",!0,"bool");n.setProp("RestoreColumnsIconClass","Restorecolumnsiconclass","fas fa-undo","str");n.setProp("PagBarIncludeGoTo","Pagbarincludegoto",!1,"bool");n.setProp("ComboLoadType","Comboloadtype","InfiniteScrolling","str");n.setProp("InfiniteScrollingPage","Infinitescrollingpage",10,"num");n.setProp("UpdateButtonText","Updatebuttontext","WWP_ColumnsSelectorButton","str");n.setProp("AddNewOption","Addnewoption","WWP_AddNewOption","str");n.setProp("OnlySelectedValues","Onlyselectedvalues","WWP_OnlySelectedValues","str");n.setProp("MultipleValuesSeparator","Multiplevaluesseparator",", ","str");n.setProp("SelectAll","Selectall","WWP_SelectAll","str");n.setProp("SortASC","Sortasc","WWP_TSSortASC","str");n.setProp("SortDSC","Sortdsc","WWP_TSSortDSC","str");n.setProp("AllowGroupText","Allowgrouptext","WWP_GroupByOption","str");n.setProp("FixLeftText","Fixlefttext","WWP_TSFixLeft","str");n.setProp("FixRightText","Fixrighttext","WWP_TSFixRight","str");n.setProp("LoadingData","Loadingdata","WWP_TSLoading","str");n.setProp("CleanFilter","Cleanfilter","WWP_TSCleanFilter","str");n.setProp("RangeFilterFrom","Rangefilterfrom","WWP_TSFrom","str");n.setProp("RangeFilterTo","Rangefilterto","WWP_TSTo","str");n.setProp("RangePickerInviteMessage","Rangepickerinvitemessage","WWP_TSRangePickerInviteMessage","str");n.setProp("NoResultsFound","Noresultsfound","WWP_TSNoResults","str");n.setProp("SearchButtonText","Searchbuttontext","WWP_TSSearchButtonCaption","str");n.setProp("SearchMultipleValuesButtonText","Searchmultiplevaluesbuttontext","WWP_FilterSelected","str");n.setProp("ColumnSelectorFixedLeftCategory","Columnselectorfixedleftcategory","WWP_ColumnSelectorFixedLeftCategory","str");n.setProp("ColumnSelectorFixedRightCategory","Columnselectorfixedrightcategory","WWP_ColumnSelectorFixedRightCategory","str");n.setProp("ColumnSelectorNotFixedCategory","Columnselectornotfixedcategory","WWP_ColumnSelectorNotFixedCategory","str");n.setProp("ColumnSelectorNoCategoryText","Columnselectornocategorytext","WWP_ColumnSelectorNoCategoryText","str");n.setProp("ColumnSelectorFixedEmpty","Columnselectorfixedempty","WWP_ColumnSelectorFixedEmpty","str");n.setProp("ColumnSelectorRestoreTooltip","Columnselectorrestoretooltip","WWP_SelectColumns_RestoreDefault","str");n.setProp("PagBarGoToCaption","Pagbargotocaption","WWP_PaginationBarGoToCaption","str");n.setProp("PagBarGoToIconClass","Pagbargotoiconclass","fas fa-redo","str");n.setProp("PagBarGoToTooltip","Pagbargototooltip","WWP_PaginationBarGoToTooltip","str");n.setProp("PagBarEmptyFilteredGridCaption","Pagbaremptyfilteredgridcaption","WWP_PaginationBarEmptyFilteredGridCaption","str");n.setProp("Visible","Visible",!0,"bool");n.setC2ShowFunction(function(n){n.show()});this.setUserControl(n);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TABLECONTENT",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"HEADERORIGINAL",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};t[17]={id:17,fld:"TABLELOGIN",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"SIGNIN",format:0,grid:0,ctrltype:"textblock"};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"UNNAMEDTABLE1",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERNAME",fmt:0,gxz:"ZV14UserName",gxold:"OV14UserName",gxvar:"AV14UserName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV14UserName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14UserName=n)},v2c:function(){gx.fn.setControlValue("vUSERNAME",gx.O.AV14UserName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV14UserName=this.val())},val:function(){return gx.fn.getControlValue("vUSERNAME")},nac:gx.falseFn};this.declareDomainHdlr(27,function(){});t[30]={id:30,fld:"",grid:0};t[31]={id:31,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORDNEW",fmt:0,gxz:"ZV15UserPasswordNew",gxold:"OV15UserPasswordNew",gxvar:"AV15UserPasswordNew",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15UserPasswordNew=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15UserPasswordNew=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORDNEW",gx.O.AV15UserPasswordNew,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV15UserPasswordNew=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORDNEW")},nac:gx.falseFn};this.declareDomainHdlr(31,function(){});t[34]={id:34,fld:"",grid:0};t[35]={id:35,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORDNEWCONF",fmt:0,gxz:"ZV16UserPasswordNewConf",gxold:"OV16UserPasswordNewConf",gxvar:"AV16UserPasswordNewConf",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV16UserPasswordNewConf=n)},v2z:function(n){n!==undefined&&(gx.O.ZV16UserPasswordNewConf=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORDNEWCONF",gx.O.AV16UserPasswordNewConf,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV16UserPasswordNewConf=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORDNEWCONF")},nac:gx.falseFn};this.declareDomainHdlr(35,function(){});t[38]={id:38,fld:"ACTIONS",grid:0};t[39]={id:39,fld:"",grid:0};t[40]={id:40,fld:"BTNENTER",grid:0,evt:"e120g2_client",std:"ENTER"};t[41]={id:41,fld:"",grid:0};t[42]={id:42,fld:"BACKTOLOGIN",format:0,grid:0,evt:"e130g2_client",ctrltype:"textblock"};t[43]={id:43,fld:"",grid:0};t[44]={id:44,fld:"TABLEERROR",grid:0};t[47]={id:47,fld:"TABLEERRORCONTENT",grid:0};t[48]={id:48,fld:"",grid:0};t[49]={id:49,fld:"",grid:0};t[51]={id:51,fld:"",grid:0};t[52]={id:52,fld:"",grid:0};this.AV14UserName="";this.ZV14UserName="";this.OV14UserName="";this.AV15UserPasswordNew="";this.ZV15UserPasswordNew="";this.OV15UserPasswordNew="";this.AV16UserPasswordNewConf="";this.ZV16UserPasswordNewConf="";this.OV16UserPasswordNewConf="";this.AV14UserName="";this.AV15UserPasswordNew="";this.AV16UserPasswordNewConf="";this.AV18IDP_State="";this.AV9KeyToChangePassword="";this.AV13UserAuthTypeName="";this.AV17UserRememberMe=0;this.Events={e120g2_client:["ENTER",!0],e130g2_client:["BACKTOLOGIN.CLICK",!0],e150g2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV13UserAuthTypeName",fld:"vUSERAUTHTYPENAME",pic:"",hsh:!0},{av:"AV17UserRememberMe",fld:"vUSERREMEMBERME",pic:"Z9",hsh:!0},{av:"AV9KeyToChangePassword",fld:"vKEYTOCHANGEPASSWORD",pic:"",hsh:!0}],[]];this.EvtParms.ENTER=[[{av:"AV15UserPasswordNew",fld:"vUSERPASSWORDNEW",pic:""},{av:"AV16UserPasswordNewConf",fld:"vUSERPASSWORDNEWCONF",pic:""},{av:"AV13UserAuthTypeName",fld:"vUSERAUTHTYPENAME",pic:"",hsh:!0},{av:"AV14UserName",fld:"vUSERNAME",pic:""},{av:"AV9KeyToChangePassword",fld:"vKEYTOCHANGEPASSWORD",pic:"",hsh:!0},{av:"AV17UserRememberMe",fld:"vUSERREMEMBERME",pic:"Z9",hsh:!0},{av:"AV18IDP_State",fld:"vIDP_STATE",pic:""}],[{av:'gx.fn.getCtrlProperty("TABLEERROR","Visible")',ctrl:"TABLEERROR",prop:"Visible"}]];this.EvtParms["BACKTOLOGIN.CLICK"]=[[{av:"AV18IDP_State",fld:"vIDP_STATE",pic:""}],[{av:"AV18IDP_State",fld:"vIDP_STATE",pic:""}]];this.EnterCtrl=["BTNENTER"];this.setVCMap("AV13UserAuthTypeName","vUSERAUTHTYPENAME",0,"char",60,0);this.setVCMap("AV9KeyToChangePassword","vKEYTOCHANGEPASSWORD",0,"char",120,0);this.setVCMap("AV17UserRememberMe","vUSERREMEMBERME",0,"int",2,0);this.setVCMap("AV18IDP_State","vIDP_STATE",0,"char",60,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gamrecoverpasswordstep2)})