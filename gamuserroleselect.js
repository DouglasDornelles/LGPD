gx.evt.autoSkip=!1;gx.define("gamuserroleselect",!1,function(){var n,r,i,t,f,u;this.ServerClass="gamuserroleselect";this.PackageName="GeneXus.Programs";this.ServerFullClass="gamuserroleselect.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV40ManageFiltersExecutionStep=gx.fn.getIntegerValue("vMANAGEFILTERSEXECUTIONSTEP",".");this.AV50Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV22UserId=gx.fn.getControlValue("vUSERID");this.AV11FilExternalId=gx.fn.getControlValue("vFILEXTERNALID");this.AV37GridState=gx.fn.getControlValue("vGRIDSTATE");this.AV17isOK=gx.fn.getControlValue("vISOK");this.AV40ManageFiltersExecutionStep=gx.fn.getIntegerValue("vMANAGEFILTERSEXECUTIONSTEP",".");this.AV50Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV22UserId=gx.fn.getControlValue("vUSERID");this.AV11FilExternalId=gx.fn.getControlValue("vFILEXTERNALID")};this.s142_client=function(){this.AV12FilName="";this.AV28GAMDescriptionLong=""};this.e121v2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e131v2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e111v2_client=function(){return this.executeServerEvent("DDO_MANAGEFILTERS.ONOPTIONCLICKED",!1,null,!0,!0)};this.e141v2_client=function(){return this.executeServerEvent("'DOADDSELECTED'",!1,null,!1,!1)};this.e181v2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e191v1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,11,12,13,14,15,16,21,24,25,26,29,30,31,32,33,35,36,37,38,39,41,42,43,44,45,47,48,49,50,51,52,53,54,55,56];this.GXLastCtrlId=56;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",40,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"gamuserroleselect",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Novo registro",!0,!1,!0,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);r=this.GridContainer;r.addCheckBox("Select",41,"vSELECT","","","Select","boolean","true","false",null,!0,!1,50,"px","WWColumn");r.addSingleLineEdit("Name",42,"vNAME","Perfil","","Name","char",0,"px",120,80,"left",null,[],"Name","Name",!0,0,!1,!1,"Attribute",0,"WWColumn");r.addSingleLineEdit("Id",43,"vID","Key Numeric Long","","Id","int",0,"px",12,12,"right",null,[],"Id","Id",!1,0,!1,!1,"Attribute",0,"WWColumn");this.GridContainer.emptyText="";this.setGrid(r);this.DVPANEL_TABLEHEADERContainer=gx.uc.getNew(this,9,0,"BootstrapPanel","DVPANEL_TABLEHEADERContainer","Dvpanel_tableheader","DVPANEL_TABLEHEADER");i=this.DVPANEL_TABLEHEADERContainer;i.setProp("Class","Class","","char");i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Width","Width","100%","str");i.setProp("Height","Height","100","str");i.setProp("AutoWidth","Autowidth",!1,"bool");i.setProp("AutoHeight","Autoheight",!0,"bool");i.setProp("Cls","Cls","PanelNoHeader","str");i.setProp("ShowHeader","Showheader",!0,"bool");i.setProp("Title","Title","Opções","str");i.setProp("Collapsible","Collapsible",!0,"bool");i.setProp("Collapsed","Collapsed",!1,"bool");i.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");i.setProp("IconPosition","Iconposition","Right","str");i.setProp("AutoScroll","Autoscroll",!1,"bool");i.setProp("Visible","Visible",!0,"bool");i.setProp("Gx Control Type","Gxcontroltype","","int");i.setC2ShowFunction(function(n){n.show()});this.setUserControl(i);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,46,26,"DVelop_DVPaginationBar","GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");t=this.GRIDPAGINATIONBARContainer;t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Class","Class","PaginationBar","str");t.setProp("ShowFirst","Showfirst",!1,"bool");t.setProp("ShowPrevious","Showprevious",!0,"bool");t.setProp("ShowNext","Shownext",!0,"bool");t.setProp("ShowLast","Showlast",!1,"bool");t.setProp("PagesToShow","Pagestoshow",5,"num");t.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");t.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");t.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");t.setProp("SelectedPage","Selectedpage","","char");t.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");t.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");t.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");t.setProp("First","First","First","str");t.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");t.setProp("Next","Next","WWP_PagingNextCaption","str");t.setProp("Last","Last","Last","str");t.setProp("Caption","Caption","Página <CURRENT_PAGE> de <TOTAL_PAGES>","str");t.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");t.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");t.addV2CFunction("AV46GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");t.addC2VFunction(function(n){n.ParentObject.AV46GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV46GridCurrentPage)});t.addV2CFunction("AV26GridPageCount","vGRIDPAGECOUNT","SetPageCount");t.addC2VFunction(function(n){n.ParentObject.AV26GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV26GridPageCount)});t.setProp("RecordCount","Recordcount","","str");t.setProp("Page","Page","","str");t.addV2CFunction("AV47GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");t.addC2VFunction(function(n){n.ParentObject.AV47GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV47GridAppliedFilters)});t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("ChangePage",this.e121v2_client);t.addEventHandler("ChangeRowsPerPage",this.e131v2_client);this.setUserControl(t);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,57,26,"WWP_GridEmpowerer","GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");f=this.GRID_EMPOWERERContainer;f.setProp("Class","Class","","char");f.setProp("Enabled","Enabled",!0,"boolean");f.setDynProp("GridInternalName","Gridinternalname","","char");f.setProp("HasCategories","Hascategories",!1,"bool");f.setProp("InfiniteScrolling","Infinitescrolling","False","str");f.setProp("HasTitleSettings","Hastitlesettings",!1,"bool");f.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");f.setProp("HasRowGroups","Hasrowgroups",!1,"bool");f.setProp("FixedColumns","Fixedcolumns","","str");f.setProp("PopoversInGrid","Popoversingrid","","str");f.setProp("Visible","Visible",!0,"bool");f.setC2ShowFunction(function(n){n.show()});this.setUserControl(f);this.DDO_MANAGEFILTERSContainer=gx.uc.getNew(this,19,0,"BootstrapDropDownOptions","DDO_MANAGEFILTERSContainer","Ddo_managefilters","DDO_MANAGEFILTERS");u=this.DDO_MANAGEFILTERSContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setProp("IconType","Icontype","FontIcon","str");u.setProp("Icon","Icon","fas fa-filter","str");u.setProp("Caption","Caption","","str");u.setProp("Tooltip","Tooltip","WWP_ManageFiltersTooltip","str");u.setProp("Cls","Cls","ManageFilters","str");u.setProp("ActiveEventKey","Activeeventkey","","char");u.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");u.setProp("DropDownOptionsType","Dropdownoptionstype","Regular","str");u.setProp("Visible","Visible",!0,"bool");u.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");u.addV2CFunction("AV44ManageFiltersData","vMANAGEFILTERSDATA","SetDropDownOptionsData");u.addC2VFunction(function(n){n.ParentObject.AV44ManageFiltersData=n.GetDropDownOptionsData();gx.fn.setControlValue("vMANAGEFILTERSDATA",n.ParentObject.AV44ManageFiltersData)});u.setC2ShowFunction(function(n){n.show()});u.addEventHandler("OnOptionClicked",this.e111v2_client);this.setUserControl(u);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[11]={id:11,fld:"TABLEHEADER",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"TABLEACTIONS",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"TABLERIGHTHEADER",grid:0};n[21]={id:21,fld:"TABLEFILTERS",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFILNAME",fmt:0,gxz:"ZV12FilName",gxold:"OV12FilName",gxvar:"AV12FilName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12FilName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12FilName=n)},v2c:function(){gx.fn.setControlValue("vFILNAME",gx.O.AV12FilName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV12FilName=this.val())},val:function(){return gx.fn.getControlValue("vFILNAME")},nac:gx.falseFn};this.declareDomainHdlr(26,function(){});n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGAMDESCRIPTIONLONG",fmt:0,gxz:"ZV28GAMDescriptionLong",gxold:"OV28GAMDescriptionLong",gxvar:"AV28GAMDescriptionLong",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV28GAMDescriptionLong=n)},v2z:function(n){n!==undefined&&(gx.O.ZV28GAMDescriptionLong=n)},v2c:function(){gx.fn.setControlValue("vGAMDESCRIPTIONLONG",gx.O.AV28GAMDescriptionLong,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV28GAMDescriptionLong=this.val())},val:function(){return gx.fn.getControlValue("vGAMDESCRIPTIONLONG")},nac:gx.falseFn};this.declareDomainHdlr(31,function(){});n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[41]={id:41,lvl:2,type:"boolean",len:4,dec:0,sign:!1,ro:0,isacc:0,grid:40,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSELECT",fmt:0,gxz:"ZV21Select",gxold:"OV21Select",gxvar:"AV21Select",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV21Select=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV21Select=gx.lang.booleanValue(n))},v2c:function(n){gx.fn.setGridCheckBoxValue("vSELECT",n||gx.fn.currentGridRowImpl(40),gx.O.AV21Select,!0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV21Select=gx.lang.booleanValue(this.val(n)))},val:function(n){return gx.fn.getGridControlValue("vSELECT",n||gx.fn.currentGridRowImpl(40))},nac:gx.falseFn,values:["true","false"]};n[42]={id:42,lvl:2,type:"char",len:120,dec:0,sign:!1,ro:0,isacc:0,grid:40,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",fmt:0,gxz:"ZV18Name",gxold:"OV18Name",gxvar:"AV18Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV18Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV18Name=n)},v2c:function(n){gx.fn.setGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(40),gx.O.AV18Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV18Name=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(40))},nac:gx.falseFn};n[43]={id:43,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,isacc:0,grid:40,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vID",fmt:0,gxz:"ZV16Id",gxold:"OV16Id",gxvar:"AV16Id",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV16Id=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV16Id=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vID",n||gx.fn.currentGridRowImpl(40),gx.O.AV16Id,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV16Id=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vID",n||gx.fn.currentGridRowImpl(40),".")},nac:gx.falseFn};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"BTNADDSELECTED",grid:0,evt:"e141v2_client"};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"BTNCANCEL",grid:0,evt:"e191v1_client"};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};this.AV12FilName="";this.ZV12FilName="";this.OV12FilName="";this.AV28GAMDescriptionLong="";this.ZV28GAMDescriptionLong="";this.OV28GAMDescriptionLong="";this.ZV21Select=!1;this.OV21Select=!1;this.ZV18Name="";this.OV18Name="";this.ZV16Id=0;this.OV16Id=0;this.AV44ManageFiltersData=[];this.AV12FilName="";this.AV28GAMDescriptionLong="";this.AV46GridCurrentPage=0;this.AV22UserId="";this.AV21Select=!1;this.AV18Name="";this.AV16Id=0;this.AV40ManageFiltersExecutionStep=0;this.AV50Pgmname="";this.AV11FilExternalId="";this.AV37GridState={CurrentPage:0,OrderedBy:0,OrderedDsc:!1,HidingSearch:0,PageSize:"",CollapsedRecords:"",GroupBy:"",FilterValues:[],DynamicFilters:[]};this.AV17isOK=!1;this.Events={e121v2_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e131v2_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e111v2_client:["DDO_MANAGEFILTERS.ONOPTIONCLICKED",!0],e141v2_client:["'DOADDSELECTED'",!0],e181v2_client:["ENTER",!0],e191v1_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{ctrl:"GRID",prop:"Rows"},{av:"AV50Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV12FilName",fld:"vFILNAME",pic:""},{av:"AV28GAMDescriptionLong",fld:"vGAMDESCRIPTIONLONG",pic:""},{av:"AV22UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV11FilExternalId",fld:"vFILEXTERNALID",pic:"",hsh:!0}],[{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV46GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV47GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV44ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV50Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV12FilName",fld:"vFILNAME",pic:""},{av:"AV28GAMDescriptionLong",fld:"vGAMDESCRIPTIONLONG",pic:""},{av:"AV22UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV11FilExternalId",fld:"vFILEXTERNALID",pic:"",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV50Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV12FilName",fld:"vFILNAME",pic:""},{av:"AV28GAMDescriptionLong",fld:"vGAMDESCRIPTIONLONG",pic:""},{av:"AV22UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV11FilExternalId",fld:"vFILEXTERNALID",pic:"",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{ctrl:"GRID",prop:"Rows"}]];this.EvtParms["GRID.LOAD"]=[[{ctrl:"GRID",prop:"Rows"},{av:"AV22UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV12FilName",fld:"vFILNAME",pic:""},{av:"AV11FilExternalId",fld:"vFILEXTERNALID",pic:"",hsh:!0}],[{av:"AV26GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV21Select",fld:"vSELECT",pic:""},{av:"AV16Id",fld:"vID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV18Name",fld:"vNAME",pic:""}]];this.EvtParms["DDO_MANAGEFILTERS.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV50Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"AV12FilName",fld:"vFILNAME",pic:""},{av:"AV28GAMDescriptionLong",fld:"vGAMDESCRIPTIONLONG",pic:""},{av:"AV22UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV11FilExternalId",fld:"vFILEXTERNALID",pic:"",hsh:!0},{av:"this.DDO_MANAGEFILTERSContainer.ActiveEventKey",ctrl:"DDO_MANAGEFILTERS",prop:"ActiveEventKey"},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""}],[{av:"AV40ManageFiltersExecutionStep",fld:"vMANAGEFILTERSEXECUTIONSTEP",pic:"9"},{av:"AV37GridState",fld:"vGRIDSTATE",pic:""},{av:"AV12FilName",fld:"vFILNAME",pic:""},{av:"AV28GAMDescriptionLong",fld:"vGAMDESCRIPTIONLONG",pic:""},{av:"AV46GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV47GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""},{av:"AV44ManageFiltersData",fld:"vMANAGEFILTERSDATA",pic:""}]];this.EvtParms["'DOADDSELECTED'"]=[[{av:"AV22UserId",fld:"vUSERID",pic:"",hsh:!0},{av:"AV21Select",fld:"vSELECT",grid:40,pic:""},{av:"GRID_nFirstRecordOnPage"},{av:"nRC_GXsfl_40",ctrl:"GRID",grid:40,prop:"GridRC",grid:40},{av:"AV16Id",fld:"vID",grid:40,pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV17isOK",fld:"vISOK",pic:""}],[{av:"AV17isOK",fld:"vISOK",pic:""}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV40ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV50Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV22UserId","vUSERID",0,"char",40,0);this.setVCMap("AV11FilExternalId","vFILEXTERNALID",0,"char",254,0);this.setVCMap("AV37GridState","vGRIDSTATE",0,"WWPBaseObjectsWWPGridState",0,0);this.setVCMap("AV17isOK","vISOK",0,"boolean",4,0);this.setVCMap("AV40ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV50Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV22UserId","vUSERID",0,"char",40,0);this.setVCMap("AV11FilExternalId","vFILEXTERNALID",0,"char",254,0);this.setVCMap("AV40ManageFiltersExecutionStep","vMANAGEFILTERSEXECUTIONSTEP",0,"int",1,0);this.setVCMap("AV50Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV22UserId","vUSERID",0,"char",40,0);this.setVCMap("AV11FilExternalId","vFILEXTERNALID",0,"char",254,0);r.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});r.addRefreshingVar({rfrVar:"AV40ManageFiltersExecutionStep"});r.addRefreshingVar({rfrVar:"AV50Pgmname"});r.addRefreshingVar(this.GXValidFnc[26]);r.addRefreshingVar(this.GXValidFnc[31]);r.addRefreshingVar({rfrVar:"AV22UserId"});r.addRefreshingVar({rfrVar:"AV11FilExternalId"});r.addRefreshingParm({rfrVar:"AV40ManageFiltersExecutionStep"});r.addRefreshingParm({rfrVar:"AV50Pgmname"});r.addRefreshingParm(this.GXValidFnc[26]);r.addRefreshingParm(this.GXValidFnc[31]);r.addRefreshingParm({rfrVar:"AV22UserId"});r.addRefreshingParm({rfrVar:"AV11FilExternalId"});this.Initialize();this.setSDTMapping("WWPBaseObjects\\WWPTransactionContext",{Attributes:{sdt:"WWPBaseObjects\\WWPTransactionContext.Attribute"}});this.setSDTMapping("WWPBaseObjects\\WWPGridState",{FilterValues:{sdt:"WWPBaseObjects\\WWPGridState.FilterValue"}});this.setSDTMapping("GeneXusSecurity\\GAMSession",{User:{sdt:"GeneXusSecurity\\GAMUser"}});this.setSDTMapping("GeneXusSecurity\\GAMApplication",{Environment:{sdt:"GeneXusSecurity\\GAMApplicationEnvironment"}});this.setSDTMapping("GeneXusSecurity\\GAMApplicationFilter",{Environment:{sdt:"GeneXusSecurity\\GAMApplicationEnvironment"}})});gx.wi(function(){gx.createParentObj(this.gamuserroleselect)})