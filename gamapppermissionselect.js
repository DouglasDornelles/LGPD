gx.evt.autoSkip=!1;gx.define("gamapppermissionselect",!1,function(){var n,i,r,t,f,u;this.ServerClass="gamapppermissionselect";this.PackageName="GeneXus.Programs";this.ServerFullClass="gamapppermissionselect.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV36ManageFiltersExecutionStep=gx.fn.getIntegerValue("vMANAGEFILTERSEXECUTIONSTEP",".");this.AV48Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV9ApplicationId=gx.fn.getIntegerValue("vAPPLICATIONID",".");this.AV23PermissionId=gx.fn.getControlValue("vPERMISSIONID");this.AV19IsAuthorized_Name=gx.fn.getControlValue("vISAUTHORIZED_NAME");this.AV33GridState=gx.fn.getControlValue("vGRIDSTATE");this.AV20isOK=gx.fn.getControlValue("vISOK");this.AV36ManageFiltersExecutionStep=gx.fn.getIntegerValue("vMANAGEFILTERSEXECUTIONSTEP",".");this.AV48Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV9ApplicationId=gx.fn.getIntegerValue("vAPPLICATIONID",".");this.AV23PermissionId=gx.fn.getControlValue("vPERMISSIONID");this.AV19IsAuthorized_Name=gx.fn.getControlValue("vISAUTHORIZED_NAME")};this.s142_client=function(){this.AV15FilName=""};this.e121a2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e131a2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e111a2_client=function(){return this.executeServerEvent("DDO_MANAGEFILTERS.ONOPTIONCLICKED",!1,null,!0,!0)};this.e141a2_client=function(){return this.executeServerEvent("'DOADD'",!1,null,!1,!1)};this.e181a2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e191a1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,11,12,13,14,15,16,21,24,25,26,27,28,30,31,32,33,34,36,37,38,39,40,41,42,44,45,46,47,48,49,50,51,52,53];this.GXLastCtrlId=53;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",35,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"gamapppermissionselect",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Novo registro",!0,!1,!0,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addCheckBox("Select",36,"vSELECT","","","Select","boolean","true","false",null,!0,!1,50,"px","WWColumn");i.addSingleLineEdit("Name",37,"vNAME","Nome da permissão","","Name","char",570,"px",254,80,"left",null,[],"Name","Name",!0,0,!1,!1,"Attribute",0,"WWColumn");i.addSingleLineEdit("Dsc",38,"vDSC","Descrição","","Dsc","char",570,"px",254,80,"left",null,[],"Dsc","Dsc",!0,0,!1,!1,"Attribute",0,"WWColumn");i.addSingleLineEdit("Id",39,"vID","Guid","","ID","char",0,"px",40,40,"left",null,[],"Id","ID",!1,0,!1,!1,"Attribute",0,"WWColumn");i.addSingleLineEdit("Appid",40,"vAPPID","Key Numeric Long","","AppId","int",0,"px",12,12,"right",null,[],"Appid","AppId",!1,0,!1,!1,"Attribute",0,"WWColumn");this.GridContainer.emptyText="";this.setGrid(i);this.DVPANEL_TABLEHEADERContainer=gx.uc.getNew(this,9,0,"BootstrapPanel","DVPANEL_TABLEHEADERContainer","Dvpanel_tableheader","DVPANEL_TABLEHEADER");r=this.DVPANEL_TABLEHEADERContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setProp("Width","Width","100%","str");r.setProp("Height","Height","100","str");r.setProp("AutoWidth","Autowidth",!1,"bool");r.setProp("AutoHeight","Autoheight",!0,"bool");r.setProp("Cls","Cls","PanelNoHeader","str");r.setProp("ShowHeader","Showheader",!0,"bool");r.setProp("Title","Title","Opções","str");r.setProp("Collapsible","Collapsible",!0,"bool");r.setProp("Collapsed","Collapsed",!1,"bool");r.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");r.setProp("IconPosition","Iconposition","Right","str");r.setProp("AutoScroll","Autoscroll",!1,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,43,26,"DVelop_DVPaginationBar","GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");t=this.GRIDPAGINATIONBARContainer;t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Class","Class","PaginationBar","str");t.setProp("ShowFirst","Showfirst",!1,"bool");t.setProp("ShowPrevious","Showprevious",!0,"bool");t.setProp("ShowNext","Shownext",!0,"bool");t.setProp("ShowLast","Showlast",!1,"bool");t.setProp("PagesToShow","Pagestoshow",5,"num");t.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");t.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");t.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");t.setProp("SelectedPage","Selectedpage","","char");t.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");t.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");t.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");t.setProp("First","First","First","str");t.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");t.setProp("Next","Next","WWP_PagingNextCaption","str");t.setProp("Last","Last","Last","str");t.setProp("Caption","Caption","Página <CURRENT_PAGE> de <TOTAL_PAGES>","str");t.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");t.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");t.addV2CFunction("AV42GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");t.addC2VFunction(function(n){n.ParentObject.AV42GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV42GridCurrentPage)});t.addV2CFunction("AV17GridPageCount","vGRIDPAGECOUNT","SetPageCount");t.addC2VFunction(function(n){n.ParentObject.AV17GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV17GridPageCount)});t.setProp("RecordCount","Recordcount","","str");t.setProp("Page","Page","","str");t.addV2CFunction("AV43GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");t.addC2VFunction(function(n){n.ParentObject.AV43GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV43GridAppliedFilters)});t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("ChangePage",this.e121a2_client);t.addEventHandler("ChangeRowsPerPage",this.e131a2_client);this.setUserControl(t);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,54,26,"WWP_GridEmpowerer","GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");f=this.GRID_EMPOWERERContainer;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setDynProp("GridInternalName","Gridinternalname","","char");f.setProp("HasCategories","Hascategories",!1,"bool");f.setProp("InfiniteScrolling","Infinitescrolling","False","str");f.setProp("HasTitleSettings","Hastitlesettings",!1,"bool");f.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");f.setProp("HasRowGroups","Hasrowgroups",!1,"bool");f.setProp("FixedColumns","Fixedcolumns","","str");f.setProp("PopoversInGrid","Popoversingrid","","str");f.setProp("Visible","Visible",!0,"bool");f.setC2ShowFunction(function(n){n.show()});this.setUserControl(f);this.DDO_MANAGEFILTERSContainer=gx.uc.getNew(this,19,0,"BootstrapDropDownOptions","DDO_MANAGEFILTERSContainer","Ddo_managefilters","DDO_MANAGEFILTERS");u=this.DDO_MANAGEFILTERSContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("IconType","Icontype","FontIcon","str");u.setProp("Icon","Icon","fas fa-filter","str");u.setProp("Caption","Caption","","str");u.setProp("Tooltip","Tooltip","WWP_ManageFiltersTooltip","str");u.setProp("Cls","Cls","ManageFilters","str");u.setProp("ActiveEventKey","Activeeventkey","","char");u.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");u.setProp("DropDownOptionsType","Dropdownoptionstype","Regular","str");u.setProp("Visible","Visible",!0,"bool");u.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");u.addV2CFunction("AV40ManageFiltersData","vMANAGEFILTERSDATA","SetDropDownOptionsData");u.addC2VFunction(function(n){n.ParentObject.AV40ManageFiltersData=n.GetDropDownOptionsData();gx.fn.setControlValue("vMANAGEFILTERSDATA",n.ParentObject.AV40ManageFiltersData)});u.setC2ShowFunction(function(n){n.show()});u.addEventHandler("OnOptionClicked",this.e111a2_client);this.setUserControl(u);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[11]={id:11,fld:"TABLEHEADER",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"TABLEACTIONS",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"TABLERIGHTHEADER",grid:0};n[21]={id:21,fld:"TABLEFILTERS",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFILNAME",fmt:0,gxz:"ZV15FilName",gxold:"OV15FilName",gxvar:"AV15FilName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15FilName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15FilName=n)},v2c:function(){gx.fn.setControlValue("vFILNAME",gx.O.AV15FilName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV15FilName=this.val())},val:function(){return gx.fn.getControlValue("vFILNAME")},nac:gx.falseFn};this.declareDomainHdlr(26,function(){});n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[36]={id:36,lvl:2,type:"boolean",len:4,dec:0,sign:!1,ro:0,isacc:0,grid:35,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSELECT",fmt:0,gxz:"ZV24Select",gxold:"OV24Select",gxvar:"AV24Select",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV24Select=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV24Select=gx.lang.booleanValue(n))},v2c:function(n){gx.fn.setGridCheckBoxValue("vSELECT",n||gx.fn.currentGridRowImpl(35),gx.O.AV24Select,!0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV24Select=gx.lang.booleanValue(this.val(n)))},val:function(n){return gx.fn.getGridControlValue("vSELECT",n||gx.fn.currentGridRowImpl(35))},nac:gx.falseFn,values:["true","false"]};n[37]={id:37,lvl:2,type:"char",len:254,dec:0,sign:!1,ro:0,isacc:0,grid:35,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",fmt:0,gxz:"ZV21Name",gxold:"OV21Name",gxvar:"AV21Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV21Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV21Name=n)},v2c:function(n){gx.fn.setGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(35),gx.O.AV21Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV21Name=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(35))},nac:gx.falseFn};n[38]={id:38,lvl:2,type:"char",len:254,dec:0,sign:!1,ro:0,isacc:0,grid:35,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDSC",fmt:0,gxz:"ZV12Dsc",gxold:"OV12Dsc",gxvar:"AV12Dsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12Dsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Dsc=n)},v2c:function(n){gx.fn.setGridControlValue("vDSC",n||gx.fn.currentGridRowImpl(35),gx.O.AV12Dsc,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12Dsc=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDSC",n||gx.fn.currentGridRowImpl(35))},nac:gx.falseFn};n[39]={id:39,lvl:2,type:"char",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:35,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vID",fmt:0,gxz:"ZV18ID",gxold:"OV18ID",gxvar:"AV18ID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV18ID=n)},v2z:function(n){n!==undefined&&(gx.O.ZV18ID=n)},v2c:function(n){gx.fn.setGridControlValue("vID",n||gx.fn.currentGridRowImpl(35),gx.O.AV18ID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV18ID=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vID",n||gx.fn.currentGridRowImpl(35))},nac:gx.falseFn};n[40]={id:40,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,isacc:0,grid:35,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vAPPID",fmt:0,gxz:"ZV8AppId",gxold:"OV8AppId",gxvar:"AV8AppId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV8AppId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8AppId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vAPPID",n||gx.fn.currentGridRowImpl(35),gx.O.AV8AppId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV8AppId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vAPPID",n||gx.fn.currentGridRowImpl(35),".")},nac:gx.falseFn};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"BTNADD",grid:0,evt:"e141a2_client"};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"BTNCANCEL",grid:0,evt:"e191a1_client"};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};this.AV15FilName="";this.ZV15FilName="";this.OV15FilName="";this.ZV24Select=!1;this.OV24Select=!1;this.ZV21Name="";this.OV21Name="";this.ZV12Dsc="";this.OV12Dsc="";this.ZV18ID="";this.OV18ID="";this.ZV8AppId=0;this.OV8AppId=0;this.AV40ManageFiltersData=[];this.AV15FilName="";this.AV42GridCurrentPage=0;this.AV9ApplicationId=0;this.AV23PermissionId="";this.AV24Select=!1;this.AV21Name="";this.AV12Dsc="";this.AV18ID="";this.AV8AppId=0;this.AV36ManageFiltersExecutionStep=0;this.AV48Pgmname="";this.AV19IsAuthorized_Name=!1;this.AV33GridState={CurrentPage:0,OrderedBy:0,OrderedDsc:!1,HidingSearch:0,PageSize:"",CollapsedRecords:"",GroupBy:"",FilterValues:[],DynamicFilters:[]};this.AV20isOK=!1;this.Events={e121a2_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e131a2_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e111a2_client:["DDO_MANAGEFILTERS.ONOPTIONCLICKED",!0],e141a2_client:["'DOADD'",!0],e181a2_client:["ENTER",!0],e191a1_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV36ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{ctrl:"GRID",prop:"Rows"},{av:"AV48Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV15FilName",fld:"vFILNAME",pic:""},{av:"AV9ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV23PermissionId",fld:"vPERMISSIONID",pic:"",hsh:!0},{av:"AV19IsAuthorized_Name",fld:"vISAUTHORIZED_NAME",pic:"",hsh:!0}],[{av:"AV36ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV42GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV43GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV40ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV33GridState",fld:"vGRIDSTATE",pic:""}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV36ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV48Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV15FilName",fld:"vFILNAME",pic:""},{av:"AV9ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV23PermissionId",fld:"vPERMISSIONID",pic:"",hsh:!0},{av:"AV19IsAuthorized_Name",fld:"vISAUTHORIZED_NAME",pic:"",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV36ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV48Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV15FilName",fld:"vFILNAME",pic:""},{av:"AV9ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV23PermissionId",fld:"vPERMISSIONID",pic:"",hsh:!0},{av:"AV19IsAuthorized_Name",fld:"vISAUTHORIZED_NAME",pic:"",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{ctrl:"GRID",prop:"Rows"}]];this.EvtParms["GRID.LOAD"]=[[{av:"AV9ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV15FilName",fld:"vFILNAME",pic:""},{av:"AV23PermissionId",fld:"vPERMISSIONID",pic:"",hsh:!0},{av:"AV19IsAuthorized_Name",fld:"vISAUTHORIZED_NAME",pic:"",hsh:!0}],[{av:"AV8AppId",fld:"vAPPID",pic:"ZZZZZZZZZZZ9"},{av:"AV17GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV24Select",fld:"vSELECT",pic:""},{av:"AV18ID",fld:"vID",pic:"",hsh:!0},{av:"AV21Name",fld:"vNAME",pic:""},{av:"AV12Dsc",fld:"vDSC",pic:""},{av:'gx.fn.getCtrlProperty("vNAME","Link")',ctrl:"vNAME",prop:"Link"}]];this.EvtParms["DDO_MANAGEFILTERS.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV36ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV48Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV15FilName",fld:"vFILNAME",pic:""},{av:"AV9ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV23PermissionId",fld:"vPERMISSIONID",pic:"",hsh:!0},{av:"AV19IsAuthorized_Name",fld:"vISAUTHORIZED_NAME",pic:"",hsh:!0},{av:"this.DDO_MANAGEFILTERSContainer.ActiveEventKey",ctrl:"DDO_MANAGEFILTERS",prop:"ActiveEventKey"},{av:"AV33GridState",fld:"vGRIDSTATE",pic:""}],[{av:"AV36ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV33GridState",fld:"vGRIDSTATE",pic:""},{av:"AV15FilName",fld:"vFILNAME",pic:""},{av:"AV42GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV43GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV40ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""}]];this.EvtParms["'DOADD'"]=[[{av:"AV9ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV24Select",fld:"vSELECT",grid:35,pic:""},{av:"GRID_nFirstRecordOnPage"},{av:"nRC_GXsfl_35",ctrl:"GRID",grid:35,prop:"GridRC",grid:35},{av:"AV23PermissionId",fld:"vPERMISSIONID",pic:"",hsh:!0},{av:"AV18ID",fld:"vID",grid:35,pic:"",hsh:!0},{av:"AV20isOK",fld:"vISOK",pic:""}],[{av:"AV20isOK",fld:"vISOK",pic:""}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV36ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV48Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV9ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV23PermissionId","vPERMISSIONID",0,"char",40,0);this.setVCMap("AV19IsAuthorized_Name","vISAUTHORIZED_NAME",0,"boolean",4,0);this.setVCMap("AV33GridState","vGRIDSTATE",0,"WWPBaseObjectsWWPGridState",0,0);this.setVCMap("AV20isOK","vISOK",0,"boolean",4,0);this.setVCMap("AV36ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV48Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV9ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV23PermissionId","vPERMISSIONID",0,"char",40,0);this.setVCMap("AV19IsAuthorized_Name","vISAUTHORIZED_NAME",0,"boolean",4,0);this.setVCMap("AV36ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV48Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV9ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV23PermissionId","vPERMISSIONID",0,"char",40,0);this.setVCMap("AV19IsAuthorized_Name","vISAUTHORIZED_NAME",0,"boolean",4,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV36ManageFiltersExecutionStep"});i.addRefreshingVar({rfrVar:"AV48Pgmname"});i.addRefreshingVar(this.GXValidFnc[26]);i.addRefreshingVar({rfrVar:"AV9ApplicationId"});i.addRefreshingVar({rfrVar:"AV23PermissionId"});i.addRefreshingVar({rfrVar:"AV19IsAuthorized_Name"});i.addRefreshingParm({rfrVar:"AV36ManageFiltersExecutionStep"});i.addRefreshingParm({rfrVar:"AV48Pgmname"});i.addRefreshingParm(this.GXValidFnc[26]);i.addRefreshingParm({rfrVar:"AV9ApplicationId"});i.addRefreshingParm({rfrVar:"AV23PermissionId"});i.addRefreshingParm({rfrVar:"AV19IsAuthorized_Name"});this.Initialize();this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState",{FilterValues:{sdt:"WWPBaseObjects\\WWPGridState.FilterValue"},DynamicFilters:{sdt:"WWPBaseObjects\\WWPGridState.DynamicFilter"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState.DynamicFilter",{Dsc:{extr:"d"}})});gx.wi(function(){gx.createParentObj(this.gamapppermissionselect)})