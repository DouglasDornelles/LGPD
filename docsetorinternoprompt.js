gx.evt.autoSkip=!1;gx.define("docsetorinternoprompt",!1,function(){var i,u,t,n,r;this.ServerClass="docsetorinternoprompt";this.PackageName="GeneXus.Programs";this.ServerFullClass="docsetorinternoprompt.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV22Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV11OrderedBy=gx.fn.getIntegerValue("vORDEREDBY",".");this.AV12OrderedDsc=gx.fn.getControlValue("vORDEREDDSC");this.AV8InSetorInternoId=gx.fn.getIntegerValue("vINSETORINTERNOID",".");this.AV9InOutDocumentoId=gx.fn.getIntegerValue("vINOUTDOCUMENTOID",".");this.AV8InSetorInternoId=gx.fn.getIntegerValue("vINSETORINTERNOID",".");this.AV22Pgmname=gx.fn.getControlValue("vPGMNAME")};this.s112_client=function(){this.DDO_GRIDContainer.SortedStatus=gx.text.trim(gx.num.str(this.AV11OrderedBy,4,0))+":"+(this.AV12OrderedDsc?"DSC":"ASC")};this.s122_client=function(){this.AV13FilterFullText=""};this.e116s2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e126s2_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e136s2_client=function(){return this.executeServerEvent("DDO_GRID.ONOPTIONCLICKED",!1,null,!0,!0)};this.e186s2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e146s2_client=function(){return this.executeServerEvent("'DOCLEANFILTERS'",!0,null,!1,!1)};this.e196s2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];i=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,17,19,20,21,22,23,24,25,27,28,29,30,31,33,34,35];this.GXLastCtrlId=35;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",26,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"docsetorinternoprompt",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Novo registro",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);u=this.GridContainer;u.addSingleLineEdit("Select",27,"vSELECT","","Selecionar","Select","char",0,"px",20,20,"left","e186s2_client",[],"Select","Select",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn");u.addSingleLineEdit(60,28,"SETORINTERNOID","Id do Setor Interno","","SetorInternoId","int",0,"px",8,8,"right",null,[],60,"SetorInternoId",!0,0,!1,!1,"Attribute",0,"WWColumn");u.addSingleLineEdit(75,29,"DOCUMENTOID","Id do Documento","","DocumentoId","int",0,"px",8,8,"right",null,[],75,"DocumentoId",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");this.GridContainer.emptyText="";this.setGrid(u);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,32,20,"DVelop_DVPaginationBar","GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");t=this.GRIDPAGINATIONBARContainer;t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Class","Class","PaginationBar","str");t.setProp("ShowFirst","Showfirst",!1,"bool");t.setProp("ShowPrevious","Showprevious",!0,"bool");t.setProp("ShowNext","Shownext",!0,"bool");t.setProp("ShowLast","Showlast",!1,"bool");t.setProp("PagesToShow","Pagestoshow",5,"num");t.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");t.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");t.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");t.setProp("SelectedPage","Selectedpage","","char");t.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");t.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");t.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");t.setProp("First","First","First","str");t.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");t.setProp("Next","Next","WWP_PagingNextCaption","str");t.setProp("Last","Last","Last","str");t.setProp("Caption","Caption","Página <CURRENT_PAGE> de <TOTAL_PAGES>","str");t.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");t.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");t.addV2CFunction("AV16GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");t.addC2VFunction(function(n){n.ParentObject.AV16GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV16GridCurrentPage)});t.addV2CFunction("AV17GridPageCount","vGRIDPAGECOUNT","SetPageCount");t.addC2VFunction(function(n){n.ParentObject.AV17GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV17GridPageCount)});t.setProp("RecordCount","Recordcount","","str");t.setProp("Page","Page","","str");t.addV2CFunction("AV18GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");t.addC2VFunction(function(n){n.ParentObject.AV18GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV18GridAppliedFilters)});t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("ChangePage",this.e116s2_client);t.addEventHandler("ChangeRowsPerPage",this.e126s2_client);this.setUserControl(t);this.DDO_GRIDContainer=gx.uc.getNew(this,36,20,"DDOGridTitleSettingsM","DDO_GRIDContainer","Ddo_grid","DDO_GRID");n=this.DDO_GRIDContainer;n.setProp("Class","Class","","char");n.setProp("Enabled","Enabled",!0,"boolean");n.setProp("IconType","Icontype","Image","str");n.setProp("Icon","Icon","","str");n.setProp("Caption","Caption","","str");n.setProp("Tooltip","Tooltip","","str");n.setProp("Cls","Cls","","str");n.setProp("ActiveEventKey","Activeeventkey","","char");n.setProp("FilteredText_set","Filteredtext_set","","char");n.setProp("FilteredText_get","Filteredtext_get","","char");n.setProp("FilteredTextTo_set","Filteredtextto_set","","char");n.setProp("FilteredTextTo_get","Filteredtextto_get","","char");n.setProp("SelectedValue_set","Selectedvalue_set","","char");n.setProp("SelectedValue_get","Selectedvalue_get","","char");n.setProp("SelectedText_set","Selectedtext_set","","char");n.setProp("SelectedText_get","Selectedtext_get","","char");n.setProp("SelectedColumn","Selectedcolumn","","char");n.setProp("SelectedColumnFixedFilter","Selectedcolumnfixedfilter","","char");n.setProp("GAMOAuthToken","Gamoauthtoken","","char");n.setProp("TitleControlAlign","Titlecontrolalign","","str");n.setProp("Visible","Visible","","str");n.setDynProp("GridInternalName","Gridinternalname","","str");n.setProp("ColumnIds","Columnids","1:SetorInternoId|2:DocumentoId","str");n.setProp("ColumnsSortValues","Columnssortvalues","1|2","str");n.setProp("IncludeSortASC","Includesortasc","T","str");n.setProp("IncludeSortDSC","Includesortdsc","","str");n.setProp("AllowGroup","Allowgroup","","str");n.setProp("Fixable","Fixable","","str");n.setDynProp("SortedStatus","Sortedstatus","","char");n.setProp("IncludeFilter","Includefilter","","str");n.setProp("FilterType","Filtertype","","str");n.setProp("FilterIsRange","Filterisrange","","str");n.setProp("IncludeDataList","Includedatalist","","str");n.setProp("DataListType","Datalisttype","","str");n.setProp("AllowMultipleSelection","Allowmultipleselection","","str");n.setProp("DataListFixedValues","Datalistfixedvalues","","str");n.setProp("DataListProc","Datalistproc","","str");n.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");n.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");n.setProp("FixedFilters","Fixedfilters","","str");n.setProp("Format","Format","","str");n.setProp("SelectedFixedFilter","Selectedfixedfilter","","char");n.setProp("SortASC","Sortasc","","str");n.setProp("SortDSC","Sortdsc","","str");n.setProp("AllowGroupText","Allowgrouptext","","str");n.setProp("LoadingData","Loadingdata","","str");n.setProp("CleanFilter","Cleanfilter","","str");n.setProp("RangeFilterFrom","Rangefilterfrom","","str");n.setProp("RangeFilterTo","Rangefilterto","","str");n.setProp("NoResultsFound","Noresultsfound","","str");n.setProp("SearchButtonText","Searchbuttontext","","str");n.addV2CFunction("AV14DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");n.addC2VFunction(function(n){n.ParentObject.AV14DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV14DDO_TitleSettingsIcons)});n.setC2ShowFunction(function(n){n.show()});n.addEventHandler("OnOptionClicked",this.e136s2_client);this.setUserControl(n);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,37,20,"WWP_GridEmpowerer","GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");r=this.GRID_EMPOWERERContainer;r.setProp("Class","Class","","char");r.setProp("Enabled","Enabled",!0,"boolean");r.setDynProp("GridInternalName","Gridinternalname","","char");r.setProp("HasCategories","Hascategories",!1,"bool");r.setProp("InfiniteScrolling","Infinitescrolling","False","str");r.setProp("HasTitleSettings","Hastitlesettings",!0,"bool");r.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");r.setProp("HasRowGroups","Hasrowgroups",!1,"bool");r.setProp("FixedColumns","Fixedcolumns","","str");r.setProp("PopoversInGrid","Popoversingrid","","str");r.setProp("Visible","Visible",!0,"bool");r.setC2ShowFunction(function(n){n.show()});this.setUserControl(r);i[2]={id:2,fld:"",grid:0};i[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};i[4]={id:4,fld:"",grid:0};i[5]={id:5,fld:"",grid:0};i[6]={id:6,fld:"TABLEMAIN",grid:0};i[7]={id:7,fld:"",grid:0};i[8]={id:8,fld:"",grid:0};i[9]={id:9,fld:"TABLEHEADER",grid:0};i[10]={id:10,fld:"",grid:0};i[11]={id:11,fld:"TABLEHEADERCONTENT",grid:0};i[12]={id:12,fld:"",grid:0};i[13]={id:13,fld:"",grid:0};i[14]={id:14,fld:"TABLEFILTERS",grid:0};i[17]={id:17,fld:"CLEANFILTERS",format:1,grid:0,evt:"e146s2_client",ctrltype:"textblock"};i[19]={id:19,fld:"",grid:0};i[20]={id:20,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vFILTERFULLTEXT",fmt:0,gxz:"ZV13FilterFullText",gxold:"OV13FilterFullText",gxvar:"AV13FilterFullText",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13FilterFullText=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13FilterFullText=n)},v2c:function(){gx.fn.setControlValue("vFILTERFULLTEXT",gx.O.AV13FilterFullText,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV13FilterFullText=this.val())},val:function(){return gx.fn.getControlValue("vFILTERFULLTEXT")},nac:gx.falseFn};this.declareDomainHdlr(20,function(){});i[21]={id:21,fld:"",grid:0};i[22]={id:22,fld:"",grid:0};i[23]={id:23,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};i[24]={id:24,fld:"",grid:0};i[25]={id:25,fld:"",grid:0};i[27]={id:27,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSELECT",fmt:1,gxz:"ZV19Select",gxold:"OV19Select",gxvar:"AV19Select",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV19Select=n)},v2z:function(n){n!==undefined&&(gx.O.ZV19Select=n)},v2c:function(n){gx.fn.setGridControlValue("vSELECT",n||gx.fn.currentGridRowImpl(26),gx.O.AV19Select,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV19Select=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vSELECT",n||gx.fn.currentGridRowImpl(26))},nac:gx.falseFn,evt:"e186s2_client",std:"ENTER"};i[28]={id:28,lvl:2,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SETORINTERNOID",fmt:0,gxz:"Z60SetorInternoId",gxold:"O60SetorInternoId",gxvar:"A60SetorInternoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A60SetorInternoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z60SetorInternoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("SETORINTERNOID",n||gx.fn.currentGridRowImpl(26),gx.O.A60SetorInternoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A60SetorInternoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("SETORINTERNOID",n||gx.fn.currentGridRowImpl(26),".")},nac:gx.falseFn};i[29]={id:29,lvl:2,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCUMENTOID",fmt:0,gxz:"Z75DocumentoId",gxold:"O75DocumentoId",gxvar:"A75DocumentoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A75DocumentoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z75DocumentoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("DOCUMENTOID",n||gx.fn.currentGridRowImpl(26),gx.O.A75DocumentoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A75DocumentoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("DOCUMENTOID",n||gx.fn.currentGridRowImpl(26),".")},nac:gx.falseFn};i[30]={id:30,fld:"",grid:0};i[31]={id:31,fld:"",grid:0};i[33]={id:33,fld:"",grid:0};i[34]={id:34,fld:"",grid:0};i[35]={id:35,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};this.AV13FilterFullText="";this.ZV13FilterFullText="";this.OV13FilterFullText="";this.ZV19Select="";this.OV19Select="";this.Z60SetorInternoId=0;this.O60SetorInternoId=0;this.Z75DocumentoId=0;this.O75DocumentoId=0;this.AV13FilterFullText="";this.AV16GridCurrentPage=0;this.AV14DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:"",OptionGroup_fi:""};this.AV8InSetorInternoId=0;this.AV9InOutDocumentoId=0;this.AV19Select="";this.A60SetorInternoId=0;this.A75DocumentoId=0;this.AV22Pgmname="";this.AV11OrderedBy=0;this.AV12OrderedDsc=!1;this.Events={e116s2_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e126s2_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e136s2_client:["DDO_GRID.ONOPTIONCLICKED",!0],e186s2_client:["ENTER",!0],e146s2_client:["'DOCLEANFILTERS'",!0],e196s2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV13FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV8InSetorInternoId",fld:"vINSETORINTERNOID",pic:"ZZZZZZZ9"},{av:"AV22Pgmname",fld:"vPGMNAME",pic:"",hsh:!0}],[{av:"AV16GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV17GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV18GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV13FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV8InSetorInternoId",fld:"vINSETORINTERNOID",pic:"ZZZZZZZ9"},{av:"AV22Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV13FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV8InSetorInternoId",fld:"vINSETORINTERNOID",pic:"ZZZZZZZ9"},{av:"AV22Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{ctrl:"GRID",prop:"Rows"}]];this.EvtParms["DDO_GRID.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV13FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV8InSetorInternoId",fld:"vINSETORINTERNOID",pic:"ZZZZZZZ9"},{av:"AV22Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"this.DDO_GRIDContainer.ActiveEventKey",ctrl:"DDO_GRID",prop:"ActiveEventKey"},{av:"this.DDO_GRIDContainer.SelectedValue_get",ctrl:"DDO_GRID",prop:"SelectedValue_get"},{av:"AV11OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV12OrderedDsc",fld:"vORDEREDDSC",pic:""}],[{av:"AV11OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV12OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"}]];this.EvtParms["GRID.LOAD"]=[[],[{av:"AV19Select",fld:"vSELECT",pic:""}]];this.EvtParms.ENTER=[[{av:"A75DocumentoId",fld:"DOCUMENTOID",pic:"ZZZZZZZ9",hsh:!0}],[{av:"AV9InOutDocumentoId",fld:"vINOUTDOCUMENTOID",pic:"ZZZZZZZ9"}]];this.EvtParms["'DOCLEANFILTERS'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV13FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV8InSetorInternoId",fld:"vINSETORINTERNOID",pic:"ZZZZZZZ9"},{av:"AV22Pgmname",fld:"vPGMNAME",pic:"",hsh:!0}],[{av:"AV13FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV16GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV17GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV18GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""}]];this.EnterCtrl=["vSELECT"];this.setVCMap("AV22Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV11OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV12OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV8InSetorInternoId","vINSETORINTERNOID",0,"int",8,0);this.setVCMap("AV9InOutDocumentoId","vINOUTDOCUMENTOID",0,"int",8,0);this.setVCMap("AV8InSetorInternoId","vINSETORINTERNOID",0,"int",8,0);this.setVCMap("AV22Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV8InSetorInternoId","vINSETORINTERNOID",0,"int",8,0);this.setVCMap("AV22Pgmname","vPGMNAME",0,"char",129,0);u.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});u.addRefreshingVar(this.GXValidFnc[20]);u.addRefreshingVar({rfrVar:"AV8InSetorInternoId"});u.addRefreshingVar({rfrVar:"AV22Pgmname"});u.addRefreshingParm(this.GXValidFnc[20]);u.addRefreshingParm({rfrVar:"AV8InSetorInternoId"});u.addRefreshingParm({rfrVar:"AV22Pgmname"});this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"},OptionGroup_fi:{extr:"og"}})});gx.wi(function(){gx.createParentObj(this.docsetorinternoprompt)})