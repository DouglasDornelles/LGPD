gx.evt.autoSkip=!1;gx.define("docdicionarioprompt",!1,function(){var t,r,i,n,u;this.ServerClass="docdicionarioprompt";this.PackageName="GeneXus.Programs";this.ServerFullClass="docdicionarioprompt.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV22Pgmname=gx.fn.getControlValue("vPGMNAME");this.AV11OrderedBy=gx.fn.getIntegerValue("vORDEREDBY",".");this.AV12OrderedDsc=gx.fn.getControlValue("vORDEREDDSC");this.AV8InOutDocDicionarioId=gx.fn.getIntegerValue("vINOUTDOCDICIONARIOID",".");this.AV9InOutDocDicionarioSensivel=gx.fn.getControlValue("vINOUTDOCDICIONARIOSENSIVEL");this.AV22Pgmname=gx.fn.getControlValue("vPGMNAME")};this.Valid_Informacaoid=function(){var n=gx.fn.currentGridRowImpl(26);return this.validCliEvt("Valid_Informacaoid",26,function(){try{if(gx.fn.currentGridRowImpl(26)===0)return!0;var n=gx.util.balloon.getNew("INFORMACAOID",gx.fn.currentGridRowImpl(26));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Hipotesetratamentoid=function(){var n=gx.fn.currentGridRowImpl(26);return this.validCliEvt("Valid_Hipotesetratamentoid",26,function(){try{if(gx.fn.currentGridRowImpl(26)===0)return!0;var n=gx.util.balloon.getNew("HIPOTESETRATAMENTOID",gx.fn.currentGridRowImpl(26));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Paisid=function(){var n=gx.fn.currentGridRowImpl(26);return this.validCliEvt("Valid_Paisid",26,function(){try{if(gx.fn.currentGridRowImpl(26)===0)return!0;var n=gx.util.balloon.getNew("PAISID",gx.fn.currentGridRowImpl(26));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Documentoid=function(){var n=gx.fn.currentGridRowImpl(26);return this.validCliEvt("Valid_Documentoid",26,function(){try{if(gx.fn.currentGridRowImpl(26)===0)return!0;var n=gx.util.balloon.getNew("DOCUMENTOID",gx.fn.currentGridRowImpl(26));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.s112_client=function(){this.DDO_GRIDContainer.SortedStatus=gx.text.trim(gx.num.str(this.AV11OrderedBy,4,0))+":"+(this.AV12OrderedDsc?"DSC":"ASC")};this.s122_client=function(){this.AV13FilterFullText=""};this.e11342_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEPAGE",!1,null,!0,!0)};this.e12342_client=function(){return this.executeServerEvent("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!1,null,!0,!0)};this.e13342_client=function(){return this.executeServerEvent("DDO_GRID.ONOPTIONCLICKED",!1,null,!0,!0)};this.e18342_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e14342_client=function(){return this.executeServerEvent("'DOCLEANFILTERS'",!0,null,!1,!1)};this.e19342_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,17,19,20,21,22,23,24,25,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,46,47,48];this.GXLastCtrlId=48;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",26,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"docdicionarioprompt",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Novo registro",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);r=this.GridContainer;r.addSingleLineEdit("Select",27,"vSELECT","","Selecionar","Select","char",0,"px",20,20,"left","e18342_client",[],"Select","Select",!0,0,!1,!1,"Attribute",0,"WWIconActionColumn");r.addSingleLineEdit(98,28,"DOCDICIONARIOID","Dicionario Id","","DocDicionarioId","int",0,"px",8,8,"right",null,[],98,"DocDicionarioId",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");r.addSingleLineEdit(69,29,"INFORMACAOID","Id da Informação","","InformacaoId","int",0,"px",8,8,"right",null,[],69,"InformacaoId",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");r.addSingleLineEdit(72,30,"HIPOTESETRATAMENTOID","Id da Hipótese de Tratamento","","HipoteseTratamentoId","int",0,"px",8,8,"right",null,[],72,"HipoteseTratamentoId",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");r.addSingleLineEdit(4,31,"PAISID","Id do País","","PaisId","int",0,"px",8,8,"right",null,[],4,"PaisId",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");r.addCheckBox(99,32,"DOCDICIONARIOSENSIVEL","Sensível?","","DocDicionarioSensivel","boolean","true","false",null,!0,!1,0,"px","WWColumn");r.addCheckBox(100,33,"DOCDICIONARIOPODEELIMINAR","Eliminar?","","DocDicionarioPodeEliminar","boolean","true","false",null,!0,!1,0,"px","WWColumn hidden-xs");r.addCheckBox(101,34,"DOCDICIONARIOTRANSFINTER","Internacional","","DocDicionarioTransfInter","boolean","true","false",null,!0,!1,0,"px","WWColumn hidden-xs");r.addSingleLineEdit(102,35,"DOCDICIONARIOFINALIDADE","Finalidade","","DocDicionarioFinalidade","svchar",0,"px",250,80,"left",null,[],102,"DocDicionarioFinalidade",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");r.addSingleLineEdit(103,36,"DOCDICIONARIODATAINCLUSAO","de Inclusão","","DocDicionarioDataInclusao","date",0,"px",8,8,"right",null,[],103,"DocDicionarioDataInclusao",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");r.addSingleLineEdit(70,37,"INFORMACAONOME","Nome","","InformacaoNome","svchar",0,"px",100,80,"left",null,[],70,"InformacaoNome",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");r.addSingleLineEdit(73,38,"HIPOTESETRATAMENTONOME","Nome","","HipoteseTratamentoNome","svchar",0,"px",100,80,"left",null,[],73,"HipoteseTratamentoNome",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");r.addSingleLineEdit(5,39,"PAISNOME","Nome ","","PaisNome","svchar",0,"px",100,80,"left",null,[],5,"PaisNome",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");r.addSingleLineEdit(75,40,"DOCUMENTOID","Id do Documento","","DocumentoId","int",0,"px",8,8,"right",null,[],75,"DocumentoId",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");r.addSingleLineEdit(76,41,"DOCUMENTONOME","Nome","","DocumentoNome","svchar",0,"px",100,80,"left",null,[],76,"DocumentoNome",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");r.addSingleLineEdit(119,42,"DOCDICIONARIOTIPOTRANSFINTERGA","Transferência internacional","","DocDicionarioTipoTransfInterGa","svchar",0,"px",100,80,"left",null,[],119,"DocDicionarioTipoTransfInterGa",!0,0,!1,!1,"Attribute",0,"WWColumn hidden-xs");this.GridContainer.emptyText="";this.setGrid(r);this.GRIDPAGINATIONBARContainer=gx.uc.getNew(this,45,20,"DVelop_DVPaginationBar","GRIDPAGINATIONBARContainer","Gridpaginationbar","GRIDPAGINATIONBAR");i=this.GRIDPAGINATIONBARContainer;i.setProp("Enabled","Enabled",!0,"boolean");i.setProp("Class","Class","PaginationBar","str");i.setProp("ShowFirst","Showfirst",!1,"bool");i.setProp("ShowPrevious","Showprevious",!0,"bool");i.setProp("ShowNext","Shownext",!0,"bool");i.setProp("ShowLast","Showlast",!1,"bool");i.setProp("PagesToShow","Pagestoshow",5,"num");i.setProp("PagingButtonsPosition","Pagingbuttonsposition","Right","str");i.setProp("PagingCaptionPosition","Pagingcaptionposition","Left","str");i.setProp("EmptyGridClass","Emptygridclass","PaginationBarEmptyGrid","str");i.setProp("SelectedPage","Selectedpage","","char");i.setProp("RowsPerPageSelector","Rowsperpageselector",!0,"bool");i.setDynProp("RowsPerPageSelectedValue","Rowsperpageselectedvalue",10,"num");i.setProp("RowsPerPageOptions","Rowsperpageoptions","5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50","str");i.setProp("First","First","First","str");i.setProp("Previous","Previous","WWP_PagingPreviousCaption","str");i.setProp("Next","Next","WWP_PagingNextCaption","str");i.setProp("Last","Last","Last","str");i.setProp("Caption","Caption","Página <CURRENT_PAGE> de <TOTAL_PAGES>","str");i.setProp("EmptyGridCaption","Emptygridcaption","WWP_PagingEmptyGridCaption","str");i.setProp("RowsPerPageCaption","Rowsperpagecaption","WWP_PagingRowsPerPage","str");i.addV2CFunction("AV16GridCurrentPage","vGRIDCURRENTPAGE","SetCurrentPage");i.addC2VFunction(function(n){n.ParentObject.AV16GridCurrentPage=n.GetCurrentPage();gx.fn.setControlValue("vGRIDCURRENTPAGE",n.ParentObject.AV16GridCurrentPage)});i.addV2CFunction("AV17GridPageCount","vGRIDPAGECOUNT","SetPageCount");i.addC2VFunction(function(n){n.ParentObject.AV17GridPageCount=n.GetPageCount();gx.fn.setControlValue("vGRIDPAGECOUNT",n.ParentObject.AV17GridPageCount)});i.setProp("RecordCount","Recordcount","","str");i.setProp("Page","Page","","str");i.addV2CFunction("AV18GridAppliedFilters","vGRIDAPPLIEDFILTERS","SetAppliedFilters");i.addC2VFunction(function(n){n.ParentObject.AV18GridAppliedFilters=n.GetAppliedFilters();gx.fn.setControlValue("vGRIDAPPLIEDFILTERS",n.ParentObject.AV18GridAppliedFilters)});i.setProp("Visible","Visible",!0,"bool");i.setC2ShowFunction(function(n){n.show()});i.addEventHandler("ChangePage",this.e11342_client);i.addEventHandler("ChangeRowsPerPage",this.e12342_client);this.setUserControl(i);this.DDO_GRIDContainer=gx.uc.getNew(this,49,20,"DDOGridTitleSettingsM","DDO_GRIDContainer","Ddo_grid","DDO_GRID");n=this.DDO_GRIDContainer;n.setProp("Class","Class","","char");n.setProp("Enabled","Enabled",!0,"boolean");n.setProp("IconType","Icontype","Image","str");n.setProp("Icon","Icon","","str");n.setProp("Caption","Caption","","str");n.setProp("Tooltip","Tooltip","","str");n.setProp("Cls","Cls","","str");n.setProp("ActiveEventKey","Activeeventkey","","char");n.setProp("FilteredText_set","Filteredtext_set","","char");n.setProp("FilteredText_get","Filteredtext_get","","char");n.setProp("FilteredTextTo_set","Filteredtextto_set","","char");n.setProp("FilteredTextTo_get","Filteredtextto_get","","char");n.setProp("SelectedValue_set","Selectedvalue_set","","char");n.setProp("SelectedValue_get","Selectedvalue_get","","char");n.setProp("SelectedText_set","Selectedtext_set","","char");n.setProp("SelectedText_get","Selectedtext_get","","char");n.setProp("SelectedColumn","Selectedcolumn","","char");n.setProp("SelectedColumnFixedFilter","Selectedcolumnfixedfilter","","char");n.setProp("GAMOAuthToken","Gamoauthtoken","","char");n.setProp("TitleControlAlign","Titlecontrolalign","","str");n.setProp("Visible","Visible","","str");n.setDynProp("GridInternalName","Gridinternalname","","str");n.setProp("ColumnIds","Columnids","1:DocDicionarioId|2:InformacaoId|3:HipoteseTratamentoId|4:PaisId|5:DocDicionarioSensivel|6:DocDicionarioPodeEliminar|7:DocDicionarioTransfInter|8:DocDicionarioFinalidade|9:DocDicionarioDataInclusao|10:InformacaoNome|11:HipoteseTratamentoNome|12:PaisNome|13:DocumentoId|14:DocumentoNome|15:DocDicionarioTipoTransfInterGarantia","str");n.setProp("ColumnsSortValues","Columnssortvalues","2|3|4|5|1|6|7|8|9|10|11|12|13|14|15","str");n.setProp("IncludeSortASC","Includesortasc","T","str");n.setProp("IncludeSortDSC","Includesortdsc","","str");n.setProp("AllowGroup","Allowgroup","","str");n.setProp("Fixable","Fixable","","str");n.setDynProp("SortedStatus","Sortedstatus","","char");n.setProp("IncludeFilter","Includefilter","","str");n.setProp("FilterType","Filtertype","","str");n.setProp("FilterIsRange","Filterisrange","","str");n.setProp("IncludeDataList","Includedatalist","","str");n.setProp("DataListType","Datalisttype","","str");n.setProp("AllowMultipleSelection","Allowmultipleselection","","str");n.setProp("DataListFixedValues","Datalistfixedvalues","","str");n.setProp("DataListProc","Datalistproc","","str");n.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");n.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");n.setProp("FixedFilters","Fixedfilters","","str");n.setProp("Format","Format","","str");n.setProp("SelectedFixedFilter","Selectedfixedfilter","","char");n.setProp("SortASC","Sortasc","","str");n.setProp("SortDSC","Sortdsc","","str");n.setProp("AllowGroupText","Allowgrouptext","","str");n.setProp("LoadingData","Loadingdata","","str");n.setProp("CleanFilter","Cleanfilter","","str");n.setProp("RangeFilterFrom","Rangefilterfrom","","str");n.setProp("RangeFilterTo","Rangefilterto","","str");n.setProp("NoResultsFound","Noresultsfound","","str");n.setProp("SearchButtonText","Searchbuttontext","","str");n.addV2CFunction("AV14DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");n.addC2VFunction(function(n){n.ParentObject.AV14DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV14DDO_TitleSettingsIcons)});n.setC2ShowFunction(function(n){n.show()});n.addEventHandler("OnOptionClicked",this.e13342_client);this.setUserControl(n);this.GRID_EMPOWERERContainer=gx.uc.getNew(this,50,20,"WWP_GridEmpowerer","GRID_EMPOWERERContainer","Grid_empowerer","GRID_EMPOWERER");u=this.GRID_EMPOWERERContainer;u.setProp("Class","Class","","char");u.setProp("Enabled","Enabled",!0,"boolean");u.setDynProp("GridInternalName","Gridinternalname","","char");u.setProp("HasCategories","Hascategories",!1,"bool");u.setProp("InfiniteScrolling","Infinitescrolling","False","str");u.setProp("HasTitleSettings","Hastitlesettings",!0,"bool");u.setProp("HasColumnsSelector","Hascolumnsselector",!1,"bool");u.setProp("HasRowGroups","Hasrowgroups",!1,"bool");u.setProp("FixedColumns","Fixedcolumns","","str");u.setProp("PopoversInGrid","Popoversingrid","","str");u.setProp("Visible","Visible",!0,"bool");u.setC2ShowFunction(function(n){n.show()});this.setUserControl(u);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TABLEHEADER",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"TABLEHEADERCONTENT",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"TABLEFILTERS",grid:0};t[17]={id:17,fld:"CLEANFILTERS",format:1,grid:0,evt:"e14342_client",ctrltype:"textblock"};t[19]={id:19,fld:"",grid:0};t[20]={id:20,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vFILTERFULLTEXT",fmt:0,gxz:"ZV13FilterFullText",gxold:"OV13FilterFullText",gxvar:"AV13FilterFullText",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13FilterFullText=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13FilterFullText=n)},v2c:function(){gx.fn.setControlValue("vFILTERFULLTEXT",gx.O.AV13FilterFullText,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV13FilterFullText=this.val())},val:function(){return gx.fn.getControlValue("vFILTERFULLTEXT")},nac:gx.falseFn};this.declareDomainHdlr(20,function(){});t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"GRIDTABLEWITHPAGINATIONBAR",grid:0};t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};t[27]={id:27,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSELECT",fmt:1,gxz:"ZV19Select",gxold:"OV19Select",gxvar:"AV19Select",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV19Select=n)},v2z:function(n){n!==undefined&&(gx.O.ZV19Select=n)},v2c:function(n){gx.fn.setGridControlValue("vSELECT",n||gx.fn.currentGridRowImpl(26),gx.O.AV19Select,1)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV19Select=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vSELECT",n||gx.fn.currentGridRowImpl(26))},nac:gx.falseFn,evt:"e18342_client",std:"ENTER"};t[28]={id:28,lvl:2,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCDICIONARIOID",fmt:0,gxz:"Z98DocDicionarioId",gxold:"O98DocDicionarioId",gxvar:"A98DocDicionarioId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A98DocDicionarioId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z98DocDicionarioId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("DOCDICIONARIOID",n||gx.fn.currentGridRowImpl(26),gx.O.A98DocDicionarioId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A98DocDicionarioId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("DOCDICIONARIOID",n||gx.fn.currentGridRowImpl(26),".")},nac:gx.falseFn};t[29]={id:29,lvl:2,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:this.Valid_Informacaoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INFORMACAOID",fmt:0,gxz:"Z69InformacaoId",gxold:"O69InformacaoId",gxvar:"A69InformacaoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A69InformacaoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z69InformacaoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("INFORMACAOID",n||gx.fn.currentGridRowImpl(26),gx.O.A69InformacaoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A69InformacaoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("INFORMACAOID",n||gx.fn.currentGridRowImpl(26),".")},nac:gx.falseFn};t[30]={id:30,lvl:2,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:this.Valid_Hipotesetratamentoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"HIPOTESETRATAMENTOID",fmt:0,gxz:"Z72HipoteseTratamentoId",gxold:"O72HipoteseTratamentoId",gxvar:"A72HipoteseTratamentoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A72HipoteseTratamentoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z72HipoteseTratamentoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("HIPOTESETRATAMENTOID",n||gx.fn.currentGridRowImpl(26),gx.O.A72HipoteseTratamentoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A72HipoteseTratamentoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("HIPOTESETRATAMENTOID",n||gx.fn.currentGridRowImpl(26),".")},nac:gx.falseFn};t[31]={id:31,lvl:2,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:this.Valid_Paisid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAISID",fmt:0,gxz:"Z4PaisId",gxold:"O4PaisId",gxvar:"A4PaisId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A4PaisId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z4PaisId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PAISID",n||gx.fn.currentGridRowImpl(26),gx.O.A4PaisId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A4PaisId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PAISID",n||gx.fn.currentGridRowImpl(26),".")},nac:gx.falseFn};t[32]={id:32,lvl:2,type:"boolean",len:4,dec:0,sign:!1,ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCDICIONARIOSENSIVEL",fmt:0,gxz:"Z99DocDicionarioSensivel",gxold:"O99DocDicionarioSensivel",gxvar:"A99DocDicionarioSensivel",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A99DocDicionarioSensivel=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z99DocDicionarioSensivel=gx.lang.booleanValue(n))},v2c:function(n){gx.fn.setGridCheckBoxValue("DOCDICIONARIOSENSIVEL",n||gx.fn.currentGridRowImpl(26),gx.O.A99DocDicionarioSensivel,!0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A99DocDicionarioSensivel=gx.lang.booleanValue(this.val(n)))},val:function(n){return gx.fn.getGridControlValue("DOCDICIONARIOSENSIVEL",n||gx.fn.currentGridRowImpl(26))},nac:gx.falseFn,values:["true","false"]};t[33]={id:33,lvl:2,type:"boolean",len:4,dec:0,sign:!1,ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCDICIONARIOPODEELIMINAR",fmt:0,gxz:"Z100DocDicionarioPodeEliminar",gxold:"O100DocDicionarioPodeEliminar",gxvar:"A100DocDicionarioPodeEliminar",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A100DocDicionarioPodeEliminar=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z100DocDicionarioPodeEliminar=gx.lang.booleanValue(n))},v2c:function(n){gx.fn.setGridCheckBoxValue("DOCDICIONARIOPODEELIMINAR",n||gx.fn.currentGridRowImpl(26),gx.O.A100DocDicionarioPodeEliminar,!0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A100DocDicionarioPodeEliminar=gx.lang.booleanValue(this.val(n)))},val:function(n){return gx.fn.getGridControlValue("DOCDICIONARIOPODEELIMINAR",n||gx.fn.currentGridRowImpl(26))},nac:gx.falseFn,values:["true","false"]};t[34]={id:34,lvl:2,type:"boolean",len:4,dec:0,sign:!1,ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCDICIONARIOTRANSFINTER",fmt:0,gxz:"Z101DocDicionarioTransfInter",gxold:"O101DocDicionarioTransfInter",gxvar:"A101DocDicionarioTransfInter",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A101DocDicionarioTransfInter=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z101DocDicionarioTransfInter=gx.lang.booleanValue(n))},v2c:function(n){gx.fn.setGridCheckBoxValue("DOCDICIONARIOTRANSFINTER",n||gx.fn.currentGridRowImpl(26),gx.O.A101DocDicionarioTransfInter,!0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A101DocDicionarioTransfInter=gx.lang.booleanValue(this.val(n)))},val:function(n){return gx.fn.getGridControlValue("DOCDICIONARIOTRANSFINTER",n||gx.fn.currentGridRowImpl(26))},nac:gx.falseFn,values:["true","false"]};t[35]={id:35,lvl:2,type:"svchar",len:250,dec:0,sign:!1,ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCDICIONARIOFINALIDADE",fmt:0,gxz:"Z102DocDicionarioFinalidade",gxold:"O102DocDicionarioFinalidade",gxvar:"A102DocDicionarioFinalidade",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A102DocDicionarioFinalidade=n)},v2z:function(n){n!==undefined&&(gx.O.Z102DocDicionarioFinalidade=n)},v2c:function(n){gx.fn.setGridControlValue("DOCDICIONARIOFINALIDADE",n||gx.fn.currentGridRowImpl(26),gx.O.A102DocDicionarioFinalidade,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A102DocDicionarioFinalidade=this.val(n))},val:function(n){return gx.fn.getGridControlValue("DOCDICIONARIOFINALIDADE",n||gx.fn.currentGridRowImpl(26))},nac:gx.falseFn};t[36]={id:36,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCDICIONARIODATAINCLUSAO",fmt:0,gxz:"Z103DocDicionarioDataInclusao",gxold:"O103DocDicionarioDataInclusao",gxvar:"A103DocDicionarioDataInclusao",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A103DocDicionarioDataInclusao=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z103DocDicionarioDataInclusao=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("DOCDICIONARIODATAINCLUSAO",n||gx.fn.currentGridRowImpl(26),gx.O.A103DocDicionarioDataInclusao,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A103DocDicionarioDataInclusao=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("DOCDICIONARIODATAINCLUSAO",n||gx.fn.currentGridRowImpl(26))},nac:gx.falseFn};t[37]={id:37,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INFORMACAONOME",fmt:0,gxz:"Z70InformacaoNome",gxold:"O70InformacaoNome",gxvar:"A70InformacaoNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A70InformacaoNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z70InformacaoNome=n)},v2c:function(n){gx.fn.setGridControlValue("INFORMACAONOME",n||gx.fn.currentGridRowImpl(26),gx.O.A70InformacaoNome,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A70InformacaoNome=this.val(n))},val:function(n){return gx.fn.getGridControlValue("INFORMACAONOME",n||gx.fn.currentGridRowImpl(26))},nac:gx.falseFn};t[38]={id:38,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"HIPOTESETRATAMENTONOME",fmt:0,gxz:"Z73HipoteseTratamentoNome",gxold:"O73HipoteseTratamentoNome",gxvar:"A73HipoteseTratamentoNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A73HipoteseTratamentoNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z73HipoteseTratamentoNome=n)},v2c:function(n){gx.fn.setGridControlValue("HIPOTESETRATAMENTONOME",n||gx.fn.currentGridRowImpl(26),gx.O.A73HipoteseTratamentoNome,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A73HipoteseTratamentoNome=this.val(n))},val:function(n){return gx.fn.getGridControlValue("HIPOTESETRATAMENTONOME",n||gx.fn.currentGridRowImpl(26))},nac:gx.falseFn};t[39]={id:39,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAISNOME",fmt:0,gxz:"Z5PaisNome",gxold:"O5PaisNome",gxvar:"A5PaisNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A5PaisNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z5PaisNome=n)},v2c:function(n){gx.fn.setGridControlValue("PAISNOME",n||gx.fn.currentGridRowImpl(26),gx.O.A5PaisNome,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A5PaisNome=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PAISNOME",n||gx.fn.currentGridRowImpl(26))},nac:gx.falseFn};t[40]={id:40,lvl:2,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:this.Valid_Documentoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCUMENTOID",fmt:0,gxz:"Z75DocumentoId",gxold:"O75DocumentoId",gxvar:"A75DocumentoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A75DocumentoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z75DocumentoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("DOCUMENTOID",n||gx.fn.currentGridRowImpl(26),gx.O.A75DocumentoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A75DocumentoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("DOCUMENTOID",n||gx.fn.currentGridRowImpl(26),".")},nac:gx.falseFn};t[41]={id:41,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCUMENTONOME",fmt:0,gxz:"Z76DocumentoNome",gxold:"O76DocumentoNome",gxvar:"A76DocumentoNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A76DocumentoNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z76DocumentoNome=n)},v2c:function(n){gx.fn.setGridControlValue("DOCUMENTONOME",n||gx.fn.currentGridRowImpl(26),gx.O.A76DocumentoNome,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A76DocumentoNome=this.val(n))},val:function(n){return gx.fn.getGridControlValue("DOCUMENTONOME",n||gx.fn.currentGridRowImpl(26))},nac:gx.falseFn};t[42]={id:42,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:1,isacc:0,grid:26,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DOCDICIONARIOTIPOTRANSFINTERGA",fmt:0,gxz:"Z119DocDicionarioTipoTransfInterGa",gxold:"O119DocDicionarioTipoTransfInterGa",gxvar:"A119DocDicionarioTipoTransfInterGa",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A119DocDicionarioTipoTransfInterGa=n)},v2z:function(n){n!==undefined&&(gx.O.Z119DocDicionarioTipoTransfInterGa=n)},v2c:function(n){gx.fn.setGridControlValue("DOCDICIONARIOTIPOTRANSFINTERGA",n||gx.fn.currentGridRowImpl(26),gx.O.A119DocDicionarioTipoTransfInterGa,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A119DocDicionarioTipoTransfInterGa=this.val(n))},val:function(n){return gx.fn.getGridControlValue("DOCDICIONARIOTIPOTRANSFINTERGA",n||gx.fn.currentGridRowImpl(26))},nac:gx.falseFn};t[43]={id:43,fld:"",grid:0};t[44]={id:44,fld:"",grid:0};t[46]={id:46,fld:"",grid:0};t[47]={id:47,fld:"",grid:0};t[48]={id:48,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};this.AV13FilterFullText="";this.ZV13FilterFullText="";this.OV13FilterFullText="";this.ZV19Select="";this.OV19Select="";this.Z98DocDicionarioId=0;this.O98DocDicionarioId=0;this.Z69InformacaoId=0;this.O69InformacaoId=0;this.Z72HipoteseTratamentoId=0;this.O72HipoteseTratamentoId=0;this.Z4PaisId=0;this.O4PaisId=0;this.Z99DocDicionarioSensivel=!1;this.O99DocDicionarioSensivel=!1;this.Z100DocDicionarioPodeEliminar=!1;this.O100DocDicionarioPodeEliminar=!1;this.Z101DocDicionarioTransfInter=!1;this.O101DocDicionarioTransfInter=!1;this.Z102DocDicionarioFinalidade="";this.O102DocDicionarioFinalidade="";this.Z103DocDicionarioDataInclusao=gx.date.nullDate();this.O103DocDicionarioDataInclusao=gx.date.nullDate();this.Z70InformacaoNome="";this.O70InformacaoNome="";this.Z73HipoteseTratamentoNome="";this.O73HipoteseTratamentoNome="";this.Z5PaisNome="";this.O5PaisNome="";this.Z75DocumentoId=0;this.O75DocumentoId=0;this.Z76DocumentoNome="";this.O76DocumentoNome="";this.Z119DocDicionarioTipoTransfInterGa="";this.O119DocDicionarioTipoTransfInterGa="";this.AV13FilterFullText="";this.AV16GridCurrentPage=0;this.AV14DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:"",OptionGroup_fi:""};this.AV8InOutDocDicionarioId=0;this.AV9InOutDocDicionarioSensivel=!1;this.AV19Select="";this.A98DocDicionarioId=0;this.A69InformacaoId=0;this.A72HipoteseTratamentoId=0;this.A4PaisId=0;this.A99DocDicionarioSensivel=!1;this.A100DocDicionarioPodeEliminar=!1;this.A101DocDicionarioTransfInter=!1;this.A102DocDicionarioFinalidade="";this.A103DocDicionarioDataInclusao=gx.date.nullDate();this.A70InformacaoNome="";this.A73HipoteseTratamentoNome="";this.A5PaisNome="";this.A75DocumentoId=0;this.A76DocumentoNome="";this.A119DocDicionarioTipoTransfInterGa="";this.AV22Pgmname="";this.AV11OrderedBy=0;this.AV12OrderedDsc=!1;this.Events={e11342_client:["GRIDPAGINATIONBAR.CHANGEPAGE",!0],e12342_client:["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",!0],e13342_client:["DDO_GRID.ONOPTIONCLICKED",!0],e18342_client:["ENTER",!0],e14342_client:["'DOCLEANFILTERS'",!0],e19342_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV13FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV22Pgmname",fld:"vPGMNAME",pic:"",hsh:!0}],[{av:"AV16GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV17GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV18GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""}]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV13FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV22Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.SelectedPage",ctrl:"GRIDPAGINATIONBAR",prop:"SelectedPage"}],[]];this.EvtParms["GRIDPAGINATIONBAR.CHANGEROWSPERPAGE"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV13FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV22Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"this.GRIDPAGINATIONBARContainer.RowsPerPageSelectedValue",ctrl:"GRIDPAGINATIONBAR",prop:"RowsPerPageSelectedValue"}],[{ctrl:"GRID",prop:"Rows"}]];this.EvtParms["DDO_GRID.ONOPTIONCLICKED"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV13FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV22Pgmname",fld:"vPGMNAME",pic:"",hsh:!0},{av:"this.DDO_GRIDContainer.ActiveEventKey",ctrl:"DDO_GRID",prop:"ActiveEventKey"},{av:"this.DDO_GRIDContainer.SelectedValue_get",ctrl:"DDO_GRID",prop:"SelectedValue_get"},{av:"AV11OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV12OrderedDsc",fld:"vORDEREDDSC",pic:""}],[{av:"AV11OrderedBy",fld:"vORDEREDBY",pic:"ZZZ9"},{av:"AV12OrderedDsc",fld:"vORDEREDDSC",pic:""},{av:"this.DDO_GRIDContainer.SortedStatus",ctrl:"DDO_GRID",prop:"SortedStatus"}]];this.EvtParms["GRID.LOAD"]=[[],[{av:"AV19Select",fld:"vSELECT",pic:""}]];this.EvtParms.ENTER=[[{av:"A98DocDicionarioId",fld:"DOCDICIONARIOID",pic:"ZZZZZZZ9",hsh:!0},{av:"A99DocDicionarioSensivel",fld:"DOCDICIONARIOSENSIVEL",pic:"",hsh:!0}],[{av:"AV8InOutDocDicionarioId",fld:"vINOUTDOCDICIONARIOID",pic:"ZZZZZZZ9"},{av:"AV9InOutDocDicionarioSensivel",fld:"vINOUTDOCDICIONARIOSENSIVEL",pic:""}]];this.EvtParms["'DOCLEANFILTERS'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV13FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV22Pgmname",fld:"vPGMNAME",pic:"",hsh:!0}],[{av:"AV13FilterFullText",fld:"vFILTERFULLTEXT",pic:""},{av:"AV16GridCurrentPage",fld:"vGRIDCURRENTPAGE",pic:"ZZZZZZZZZ9"},{av:"AV17GridPageCount",fld:"vGRIDPAGECOUNT",pic:"ZZZZZZZZZ9"},{av:"AV18GridAppliedFilters",fld:"vGRIDAPPLIEDFILTERS",pic:""}]];this.EvtParms.VALID_INFORMACAOID=[[],[]];this.EvtParms.VALID_HIPOTESETRATAMENTOID=[[],[]];this.EvtParms.VALID_PAISID=[[],[]];this.EvtParms.VALID_DOCUMENTOID=[[],[]];this.EnterCtrl=["vSELECT"];this.setVCMap("AV22Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV11OrderedBy","vORDEREDBY",0,"int",4,0);this.setVCMap("AV12OrderedDsc","vORDEREDDSC",0,"boolean",4,0);this.setVCMap("AV8InOutDocDicionarioId","vINOUTDOCDICIONARIOID",0,"int",8,0);this.setVCMap("AV9InOutDocDicionarioSensivel","vINOUTDOCDICIONARIOSENSIVEL",0,"boolean",4,0);this.setVCMap("AV22Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("AV22Pgmname","vPGMNAME",0,"char",129,0);r.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});r.addRefreshingVar(this.GXValidFnc[20]);r.addRefreshingVar({rfrVar:"AV22Pgmname"});r.addRefreshingParm(this.GXValidFnc[20]);r.addRefreshingParm({rfrVar:"AV22Pgmname"});this.Initialize();this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"},OptionGroup_fi:{extr:"og"}})});gx.wi(function(){gx.createParentObj(this.docdicionarioprompt)})