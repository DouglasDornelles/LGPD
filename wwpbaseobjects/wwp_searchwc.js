gx.evt.autoSkip=!1;gx.define("wwpbaseobjects.wwp_searchwc",!0,function(n){var i,t,u,f,r,e;this.ServerClass="wwpbaseobjects.wwp_searchwc";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwpbaseobjects.wwp_searchwc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV26WWP_SearchResults=gx.fn.getControlValue("vWWP_SEARCHRESULTS");this.AV22SearchText=gx.fn.getControlValue("vSEARCHTEXT");this.AV5AdvFilterEntities=gx.fn.getControlValue("vADVFILTERENTITIES");this.AV26WWP_SearchResults=gx.fn.getControlValue("vWWP_SEARCHRESULTS");this.AV5AdvFilterEntities=gx.fn.getControlValue("vADVFILTERENTITIES")};this.e18131_client=function(){return this.clearMessages(),this.BTNADVANCEDSEARCHContainer.Caption=gx.text.compare(gx.fn.getCtrlProperty("TABLEADVANCEDSEARCHCELL","Class"),"Invisible")==0?"Pesquisa básica":"Pesquisa Avançada",gx.fn.setCtrlProperty("TABLESIMPLESEARCHCELL","Class",gx.text.compare(gx.fn.getCtrlProperty("TABLESIMPLESEARCHCELL","Class"),"Invisible")==0?"col-xs-12":"Invisible"),gx.fn.setCtrlProperty("TABLEADVANCEDSEARCHCELL","Class",gx.text.compare(gx.fn.getCtrlProperty("TABLEADVANCEDSEARCHCELL","Class"),"Invisible")==0?"col-xs-12 TableAdvancedSearchCell":"Invisible"),this.refreshOutputs([{ctrl:this.BTNADVANCEDSEARCHContainer},{av:'gx.fn.getCtrlProperty("TABLESIMPLESEARCHCELL","Class")',ctrl:"TABLESIMPLESEARCHCELL",prop:"Class"},{av:'gx.fn.getCtrlProperty("TABLEADVANCEDSEARCHCELL","Class")',ctrl:"TABLEADVANCEDSEARCHCELL",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e19131_client=function(){return this.clearMessages(),gx.json.SDTFromJson(this.AV5AdvFilterEntities,"undefined",this.COMBO_ADVFILTERENTITIESContainer.SelectedValue_get),this.refreshOutputs([{av:"AV5AdvFilterEntities",fld:"vADVFILTERENTITIES",pic:""}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e11132_client=function(){return this.executeServerEvent("'DOCLOSESEARCH'",!0,null,!1,!1)};this.e12132_client=function(){return this.executeServerEvent("'DOSHOWALL'",!0,null,!1,!1)};this.e13132_client=function(){return this.executeServerEvent("'DOBTNADVSEARCH'",!1,null,!1,!1)};this.e14132_client=function(){return this.executeServerEvent("UNNAMEDTABLEFSFSRESULTS.CLICK",!0,arguments[0],!1,!0)};this.e20132_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e21132_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];i=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,22,23,24,25,26,27,28,30,31,32,35,36,37,38,39,40,41,42,43,44,47,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,73,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,103,104,105,106,107];this.GXLastCtrlId=107;this.FsresultsContainer=new gx.grid.grid(this,3,"WbpLvl3",29,"Fsresults","Fsresults","FsresultsContainer",this.CmpContext,this.IsMasterPage,"wwpbaseobjects.wwp_searchwc",[],!0,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Novo registro",!1,!1,!1,null,null,!1,"",!0,[1,1,1,1],!1,0,!1,!1);t=this.FsresultsContainer;t.startDiv(30,"Unnamedtablefsfsresults","0px","0px");t.startDiv(31,"","0px","0px");t.startTable("Unnamedtablecontentfsfsresults",32,"0px");t.startRow("","","","","","");t.startCell("","","","","","","","","","");t.startDiv(35,"","0px","0px");t.addLabel();t.addSingleLineEdit("Url",36,"vURL","","","Url","svchar",40,"chr",40,40,"left",null,[],"Url","Url",!0,0,!1,!1,"Attribute",0,"");t.endDiv();t.endCell();t.endRow();t.endTable();t.endDiv();t.startDiv(37,"Displaytype1_cell","0px","0px");t.startDiv(38,"Unnamedtable1","0px","0px");t.startDiv(39,"","0px","0px");t.startDiv(40,"","0px","0px");t.startDiv(41,"","0px","0px");t.addLabel();t.addSingleLineEdit("Displaytype1_title",42,"vDISPLAYTYPE1_TITLE","","","DisplayType1_Title","svchar",40,"chr",40,40,"left",null,[],"Displaytype1_title","DisplayType1_Title",!0,0,!1,!1,"AttributeSearchResultTitle",0,"");t.endDiv();t.endDiv();t.endDiv();t.endDiv();t.endDiv();t.startDiv(43,"Displaytype2_cell","0px","0px");t.startTable("Unnamedtable2",44,"0px");t.startRow("","","","","","");t.startCell("","","","","","","","","","");t.addTextBlock("DISPLAYTYPE2_ICON",null,47);t.endCell();t.startCell("","","","","","","","","","");t.startDiv(49,"","0px","0px");t.addLabel();t.addSingleLineEdit("Displaytype2_title",50,"vDISPLAYTYPE2_TITLE","","","DisplayType2_Title","svchar",40,"chr",40,40,"left",null,[],"Displaytype2_title","DisplayType2_Title",!0,0,!1,!1,"AttributeSearchResultTitle",0,"");t.endDiv();t.endCell();t.endRow();t.endTable();t.endDiv();t.startDiv(51,"Displaytype3_cell","0px","0px");t.startDiv(52,"Unnamedtable3","0px","0px");t.startDiv(53,"","0px","0px");t.startDiv(54,"","0px","0px");t.startDiv(55,"","0px","0px");t.addLabel();t.addSingleLineEdit("Displaytype3_title",56,"vDISPLAYTYPE3_TITLE","","","DisplayType3_Title","svchar",40,"chr",40,40,"left",null,[],"Displaytype3_title","DisplayType3_Title",!0,0,!1,!1,"AttributeSearchResultTitle",0,"");t.endDiv();t.endDiv();t.endDiv();t.startDiv(57,"","0px","0px");t.startDiv(58,"","0px","0px");t.startDiv(59,"","0px","0px");t.addLabel();t.addSingleLineEdit("Displaytype3_subtitle",60,"vDISPLAYTYPE3_SUBTITLE","","","DisplayType3_Subtitle","svchar",40,"chr",40,40,"left",null,[],"Displaytype3_subtitle","DisplayType3_Subtitle",!0,0,!1,!1,"AttributeSearchResultSubtitle",0,"");t.endDiv();t.endDiv();t.endDiv();t.endDiv();t.endDiv();t.startDiv(61,"Displaytype4_cell","0px","0px");t.startDiv(62,"Unnamedtable4","0px","0px");t.startDiv(63,"","0px","0px");t.startDiv(64,"","0px","0px");t.addLabel();t.addBitmap("&Displaytype4_image","vDISPLAYTYPE4_IMAGE",65,0,"",0,"",null,"","","AttributeSearchResultImage","");t.endDiv();t.endDiv();t.startDiv(66,"","0px","0px");t.startDiv(67,"","0px","0px");t.addLabel();t.addSingleLineEdit("Displaytype4_title",68,"vDISPLAYTYPE4_TITLE","","","DisplayType4_Title","svchar",40,"chr",40,40,"left",null,[],"Displaytype4_title","DisplayType4_Title",!0,0,!1,!1,"AttributeSearchResultTitle",0,"");t.endDiv();t.endDiv();t.endDiv();t.endDiv();t.startDiv(69,"Displaytype5_cell","0px","0px");t.startTable("Unnamedtable5",70,"0px");t.startRow("","","","","","");t.startCell("","","","","","","","","","");t.addTextBlock("DISPLAYTYPE5_ICON",null,73);t.endCell();t.startCell("","","","","","","","","","");t.startDiv(75,"Unnamedtable6","0px","0px");t.startDiv(76,"","0px","0px");t.startDiv(77,"","0px","0px");t.startDiv(78,"","0px","0px");t.addLabel();t.addSingleLineEdit("Displaytype5_title",79,"vDISPLAYTYPE5_TITLE","","","DisplayType5_Title","svchar",40,"chr",40,40,"left",null,[],"Displaytype5_title","DisplayType5_Title",!0,0,!1,!1,"AttributeSearchResultTitle",0,"");t.endDiv();t.endDiv();t.endDiv();t.startDiv(80,"","0px","0px");t.startDiv(81,"","0px","0px");t.startDiv(82,"","0px","0px");t.addLabel();t.addSingleLineEdit("Displaytype5_subtitle",83,"vDISPLAYTYPE5_SUBTITLE","","","DisplayType5_Subtitle","svchar",40,"chr",40,40,"left",null,[],"Displaytype5_subtitle","DisplayType5_Subtitle",!0,0,!1,!1,"AttributeSearchResultSubtitle",0,"");t.endDiv();t.endDiv();t.endDiv();t.endDiv();t.endCell();t.endRow();t.endTable();t.endDiv();t.endDiv();this.FsresultsContainer.emptyText="";this.FsresultcategoriesContainer=new gx.grid.grid(this,2,"WbpLvl2",21,"Fsresultcategories","Fsresultcategories","FsresultcategoriesContainer",this.CmpContext,this.IsMasterPage,"wwpbaseobjects.wwp_searchwc",[],!0,1,!1,!0,0,!1,!1,!1,"CollWWPBaseObjectsWWP_SearchResults.WWP_SearchResultsItem",0,"px",0,"px","Novo registro",!1,!1,!1,null,null,!1,"AV26WWP_SearchResults",!0,[1,1,1,1],!1,0,!1,!1);u=this.FsresultcategoriesContainer;u.startDiv(22,"Unnamedtablefsfsresultcategories","0px","0px");u.startDiv(23,"","0px","0px");u.startDiv(24,"","0px","0px");u.startDiv(25,"","0px","0px");u.addLabel();u.addSingleLineEdit("GXV2",26,"WWP_SEARCHRESULTS__CATEGORYNAME","","","CategoryName","svchar",40,"chr",40,40,"left",null,[],"GXV2","GXV2",!0,0,!1,!1,"AttributeFL",0,"");u.endDiv();u.endDiv();u.endDiv();u.startDiv(27,"","0px","0px");u.startDiv(28,"","0px","0px");u.addGrid(this.FsresultsContainer);u.endDiv();u.endDiv();u.startDiv(84,"","0px","0px");u.startDiv(85,"Showingonlycell","0px","0px");u.addTextBlock("TXTSHOWINGONLY",null,86);u.endDiv();u.endDiv();u.endDiv();this.FsresultcategoriesContainer.emptyText="";this.setGrid(u);this.BTNSHOWALLContainer=gx.uc.getNew(this,12,0,"WWP_IconButton",this.CmpContext+"BTNSHOWALLContainer","Btnshowall","BTNSHOWALL");f=this.BTNSHOWALLContainer;f.setProp("Enabled","Enabled",!0,"boolean");f.setProp("BeforeIconClass","Beforeiconclass","fas fa-search","str");f.setProp("AfterIconClass","Aftericonclass","","str");f.addEventHandler("Event",this.e12132_client);f.setDynProp("Caption","Caption","Mostrar todos os resultados para '%1'...","str");f.setProp("Class","Class","IconButtonLink IconButtonSearchAll","str");f.setProp("Visible","Visible",!0,"bool");f.setC2ShowFunction(function(n){n.show()});this.setUserControl(f);this.COMBO_ADVFILTERENTITIESContainer=gx.uc.getNew(this,102,94,"BootstrapDropDownOptions",this.CmpContext+"COMBO_ADVFILTERENTITIESContainer","Combo_advfilterentities","COMBO_ADVFILTERENTITIES");r=this.COMBO_ADVFILTERENTITIESContainer;r.setProp("Class","Class","","char");r.setProp("IconType","Icontype","Image","str");r.setProp("Icon","Icon","","str");r.setProp("Caption","Caption","","str");r.setProp("Tooltip","Tooltip","","str");r.setProp("Cls","Cls","ExtendedCombo AttributeFL","str");r.setDynProp("SelectedValue_set","Selectedvalue_set","","char");r.setProp("SelectedValue_get","Selectedvalue_get","","char");r.setProp("SelectedText_set","Selectedtext_set","","char");r.setProp("SelectedText_get","Selectedtext_get","","char");r.setProp("GAMOAuthToken","Gamoauthtoken","","char");r.setProp("DDOInternalName","Ddointernalname","","char");r.setProp("TitleControlAlign","Titlecontrolalign","Automatic","str");r.setProp("DropDownOptionsType","Dropdownoptionstype","ExtendedComboBox","str");r.setProp("Enabled","Enabled",!0,"bool");r.setProp("Visible","Visible",!0,"bool");r.setProp("TitleControlIdToReplace","Titlecontrolidtoreplace","","str");r.setProp("DataListType","Datalisttype","Dynamic","str");r.setProp("AllowMultipleSelection","Allowmultipleselection",!0,"bool");r.setProp("DataListFixedValues","Datalistfixedvalues","","char");r.setProp("IsGridItem","Isgriditem",!1,"bool");r.setProp("HasDescription","Hasdescription",!1,"bool");r.setProp("DataListProc","Datalistproc","","str");r.setProp("DataListProcParametersPrefix","Datalistprocparametersprefix","","str");r.setProp("DataListUpdateMinimumCharacters","Datalistupdateminimumcharacters",0,"num");r.setProp("IncludeOnlySelectedOption","Includeonlyselectedoption",!0,"bool");r.setProp("IncludeSelectAllOption","Includeselectalloption",!0,"bool");r.setProp("EmptyItem","Emptyitem",!1,"bool");r.setProp("IncludeAddNewOption","Includeaddnewoption",!1,"bool");r.setProp("HTMLTemplate","Htmltemplate","","str");r.setProp("MultipleValuesType","Multiplevaluestype","Tags","str");r.setProp("LoadingData","Loadingdata","","char");r.setProp("NoResultsFound","Noresultsfound","","char");r.setProp("EmptyItemText","Emptyitemtext","","char");r.setProp("OnlySelectedValues","Onlyselectedvalues","","str");r.setProp("SelectAllText","Selectalltext","","str");r.setProp("MultipleValuesSeparator","Multiplevaluesseparator",", ","str");r.setProp("AddNewOptionText","Addnewoptiontext","","str");r.addV2CFunction("AV9DDO_TitleSettingsIcons","vDDO_TITLESETTINGSICONS","SetDropDownOptionsTitleSettingsIcons");r.addC2VFunction(function(n){n.ParentObject.AV9DDO_TitleSettingsIcons=n.GetDropDownOptionsTitleSettingsIcons();gx.fn.setControlValue("vDDO_TITLESETTINGSICONS",n.ParentObject.AV9DDO_TitleSettingsIcons)});r.addV2CFunction("AV6AdvFilterEntities_Data","vADVFILTERENTITIES_DATA","SetDropDownOptionsData");r.addC2VFunction(function(n){n.ParentObject.AV6AdvFilterEntities_Data=n.GetDropDownOptionsData();gx.fn.setControlValue("vADVFILTERENTITIES_DATA",n.ParentObject.AV6AdvFilterEntities_Data)});r.setProp("Gx Control Type","Gxcontroltype","","int");r.setC2ShowFunction(function(n){n.show()});r.addEventHandler("OnOptionClicked",this.e19131_client);this.setUserControl(r);this.BTNADVANCEDSEARCHContainer=gx.uc.getNew(this,108,94,"WWP_IconButton",this.CmpContext+"BTNADVANCEDSEARCHContainer","Btnadvancedsearch","BTNADVANCEDSEARCH");e=this.BTNADVANCEDSEARCHContainer;e.setProp("Enabled","Enabled",!0,"boolean");e.setProp("BeforeIconClass","Beforeiconclass","fas fa-filter","str");e.setProp("AfterIconClass","Aftericonclass","","str");e.addEventHandler("Event",this.e18131_client);e.setDynProp("Caption","Caption","Pesquisa Avançada","str");e.setProp("Class","Class","IconButtonLink","str");e.setProp("Visible","Visible",!0,"bool");e.setC2ShowFunction(function(n){n.show()});this.setUserControl(e);i[2]={id:2,fld:"",grid:0};i[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};i[4]={id:4,fld:"",grid:0};i[5]={id:5,fld:"",grid:0};i[6]={id:6,fld:"TABLEMAIN",grid:0};i[7]={id:7,fld:"",grid:0};i[8]={id:8,fld:"",grid:0};i[9]={id:9,fld:"CLOSESEARCH",format:1,grid:0,evt:"e11132_client",ctrltype:"textblock"};i[10]={id:10,fld:"",grid:0};i[11]={id:11,fld:"SHOWALL_CELL",grid:0};i[13]={id:13,fld:"",grid:0};i[14]={id:14,fld:"TXTNORESULTSCELL",grid:0};i[15]={id:15,fld:"TXTNORESULTS",format:0,grid:0,ctrltype:"textblock"};i[16]={id:16,fld:"",grid:0};i[17]={id:17,fld:"TABLESIMPLESEARCHCELL",grid:0};i[18]={id:18,fld:"TABLESIMPLESEARCH",grid:0};i[19]={id:19,fld:"",grid:0};i[20]={id:20,fld:"FSRESULTCATEGORIES_CELL",grid:0};i[22]={id:22,fld:"UNNAMEDTABLEFSFSRESULTCATEGORIES",grid:21};i[23]={id:23,fld:"",grid:21};i[24]={id:24,fld:"",grid:21};i[25]={id:25,fld:"",grid:21};i[26]={id:26,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:21,gxgrid:this.FsresultcategoriesContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WWP_SEARCHRESULTS__CATEGORYNAME",fmt:0,gxz:"ZV33GXV2",gxold:"OV33GXV2",gxvar:"GXV2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV2=n)},v2z:function(n){n!==undefined&&(gx.O.ZV33GXV2=n)},v2c:function(n){gx.fn.setGridControlValue("WWP_SEARCHRESULTS__CATEGORYNAME",n||gx.fn.currentGridRowImpl(21),gx.O.GXV2,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV2=this.val(n))},val:function(n){return gx.fn.getGridControlValue("WWP_SEARCHRESULTS__CATEGORYNAME",n||gx.fn.currentGridRowImpl(21))},nac:gx.falseFn};i[27]={id:27,fld:"",grid:21};i[28]={id:28,fld:"",grid:21};i[30]={id:30,fld:"UNNAMEDTABLEFSFSRESULTS",grid:29,evt:"e14132_client"};i[31]={id:31,fld:"",grid:29};i[32]={id:32,fld:"UNNAMEDTABLECONTENTFSFSRESULTS",grid:29};i[35]={id:35,fld:"",grid:29};i[36]={id:36,lvl:3,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:29,gxgrid:this.FsresultsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vURL",fmt:0,gxz:"ZV24Url",gxold:"OV24Url",gxvar:"AV24Url",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV24Url=n)},v2z:function(n){n!==undefined&&(gx.O.ZV24Url=n)},v2c:function(n){gx.fn.setGridControlValue("vURL",n||gx.fn.currentGridRowImpl(29),gx.O.AV24Url,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV24Url=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vURL",n||gx.fn.currentGridRowImpl(29))},nac:gx.falseFn};i[37]={id:37,fld:"DISPLAYTYPE1_CELL",grid:29};i[38]={id:38,fld:"UNNAMEDTABLE1",grid:29};i[39]={id:39,fld:"",grid:29};i[40]={id:40,fld:"",grid:29};i[41]={id:41,fld:"",grid:29};i[42]={id:42,lvl:3,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:29,gxgrid:this.FsresultsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDISPLAYTYPE1_TITLE",fmt:0,gxz:"ZV10DisplayType1_Title",gxold:"OV10DisplayType1_Title",gxvar:"AV10DisplayType1_Title",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV10DisplayType1_Title=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10DisplayType1_Title=n)},v2c:function(n){gx.fn.setGridControlValue("vDISPLAYTYPE1_TITLE",n||gx.fn.currentGridRowImpl(29),gx.O.AV10DisplayType1_Title,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV10DisplayType1_Title=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDISPLAYTYPE1_TITLE",n||gx.fn.currentGridRowImpl(29))},nac:gx.falseFn};i[43]={id:43,fld:"DISPLAYTYPE2_CELL",grid:29};i[44]={id:44,fld:"UNNAMEDTABLE2",grid:29};i[47]={id:47,fld:"DISPLAYTYPE2_ICON",format:2,grid:29,ctrltype:"textblock"};i[49]={id:49,fld:"",grid:29};i[50]={id:50,lvl:3,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:29,gxgrid:this.FsresultsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDISPLAYTYPE2_TITLE",fmt:0,gxz:"ZV11DisplayType2_Title",gxold:"OV11DisplayType2_Title",gxvar:"AV11DisplayType2_Title",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV11DisplayType2_Title=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11DisplayType2_Title=n)},v2c:function(n){gx.fn.setGridControlValue("vDISPLAYTYPE2_TITLE",n||gx.fn.currentGridRowImpl(29),gx.O.AV11DisplayType2_Title,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV11DisplayType2_Title=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDISPLAYTYPE2_TITLE",n||gx.fn.currentGridRowImpl(29))},nac:gx.falseFn};i[51]={id:51,fld:"DISPLAYTYPE3_CELL",grid:29};i[52]={id:52,fld:"UNNAMEDTABLE3",grid:29};i[53]={id:53,fld:"",grid:29};i[54]={id:54,fld:"",grid:29};i[55]={id:55,fld:"",grid:29};i[56]={id:56,lvl:3,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:29,gxgrid:this.FsresultsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDISPLAYTYPE3_TITLE",fmt:0,gxz:"ZV13DisplayType3_Title",gxold:"OV13DisplayType3_Title",gxvar:"AV13DisplayType3_Title",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13DisplayType3_Title=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13DisplayType3_Title=n)},v2c:function(n){gx.fn.setGridControlValue("vDISPLAYTYPE3_TITLE",n||gx.fn.currentGridRowImpl(29),gx.O.AV13DisplayType3_Title,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13DisplayType3_Title=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDISPLAYTYPE3_TITLE",n||gx.fn.currentGridRowImpl(29))},nac:gx.falseFn};i[57]={id:57,fld:"",grid:29};i[58]={id:58,fld:"",grid:29};i[59]={id:59,fld:"",grid:29};i[60]={id:60,lvl:3,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:29,gxgrid:this.FsresultsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDISPLAYTYPE3_SUBTITLE",fmt:0,gxz:"ZV12DisplayType3_Subtitle",gxold:"OV12DisplayType3_Subtitle",gxvar:"AV12DisplayType3_Subtitle",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12DisplayType3_Subtitle=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12DisplayType3_Subtitle=n)},v2c:function(n){gx.fn.setGridControlValue("vDISPLAYTYPE3_SUBTITLE",n||gx.fn.currentGridRowImpl(29),gx.O.AV12DisplayType3_Subtitle,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12DisplayType3_Subtitle=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDISPLAYTYPE3_SUBTITLE",n||gx.fn.currentGridRowImpl(29))},nac:gx.falseFn};i[61]={id:61,fld:"DISPLAYTYPE4_CELL",grid:29};i[62]={id:62,fld:"UNNAMEDTABLE4",grid:29};i[63]={id:63,fld:"",grid:29};i[64]={id:64,fld:"",grid:29};i[65]={id:65,lvl:3,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:29,gxgrid:this.FsresultsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDISPLAYTYPE4_IMAGE",fmt:0,gxz:"ZV14DisplayType4_Image",gxold:"OV14DisplayType4_Image",gxvar:"AV14DisplayType4_Image",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV14DisplayType4_Image=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14DisplayType4_Image=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vDISPLAYTYPE4_IMAGE",n||gx.fn.currentGridRowImpl(29),gx.O.AV14DisplayType4_Image,gx.O.AV35Displaytype4_image_GXI)},c2v:function(n){gx.O.AV35Displaytype4_image_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV14DisplayType4_Image=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDISPLAYTYPE4_IMAGE",n||gx.fn.currentGridRowImpl(29))},val_GXI:function(n){return gx.fn.getGridControlValue("vDISPLAYTYPE4_IMAGE_GXI",n||gx.fn.currentGridRowImpl(29))},gxvar_GXI:"AV35Displaytype4_image_GXI",nac:gx.falseFn};i[66]={id:66,fld:"",grid:29};i[67]={id:67,fld:"",grid:29};i[68]={id:68,lvl:3,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:29,gxgrid:this.FsresultsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDISPLAYTYPE4_TITLE",fmt:0,gxz:"ZV15DisplayType4_Title",gxold:"OV15DisplayType4_Title",gxvar:"AV15DisplayType4_Title",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV15DisplayType4_Title=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15DisplayType4_Title=n)},v2c:function(n){gx.fn.setGridControlValue("vDISPLAYTYPE4_TITLE",n||gx.fn.currentGridRowImpl(29),gx.O.AV15DisplayType4_Title,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV15DisplayType4_Title=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDISPLAYTYPE4_TITLE",n||gx.fn.currentGridRowImpl(29))},nac:gx.falseFn};i[69]={id:69,fld:"DISPLAYTYPE5_CELL",grid:29};i[70]={id:70,fld:"UNNAMEDTABLE5",grid:29};i[73]={id:73,fld:"DISPLAYTYPE5_ICON",format:2,grid:29,ctrltype:"textblock"};i[75]={id:75,fld:"UNNAMEDTABLE6",grid:29};i[76]={id:76,fld:"",grid:29};i[77]={id:77,fld:"",grid:29};i[78]={id:78,fld:"",grid:29};i[79]={id:79,lvl:3,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:29,gxgrid:this.FsresultsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDISPLAYTYPE5_TITLE",fmt:0,gxz:"ZV17DisplayType5_Title",gxold:"OV17DisplayType5_Title",gxvar:"AV17DisplayType5_Title",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV17DisplayType5_Title=n)},v2z:function(n){n!==undefined&&(gx.O.ZV17DisplayType5_Title=n)},v2c:function(n){gx.fn.setGridControlValue("vDISPLAYTYPE5_TITLE",n||gx.fn.currentGridRowImpl(29),gx.O.AV17DisplayType5_Title,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV17DisplayType5_Title=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDISPLAYTYPE5_TITLE",n||gx.fn.currentGridRowImpl(29))},nac:gx.falseFn};i[80]={id:80,fld:"",grid:29};i[81]={id:81,fld:"",grid:29};i[82]={id:82,fld:"",grid:29};i[83]={id:83,lvl:3,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:29,gxgrid:this.FsresultsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDISPLAYTYPE5_SUBTITLE",fmt:0,gxz:"ZV16DisplayType5_Subtitle",gxold:"OV16DisplayType5_Subtitle",gxvar:"AV16DisplayType5_Subtitle",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV16DisplayType5_Subtitle=n)},v2z:function(n){n!==undefined&&(gx.O.ZV16DisplayType5_Subtitle=n)},v2c:function(n){gx.fn.setGridControlValue("vDISPLAYTYPE5_SUBTITLE",n||gx.fn.currentGridRowImpl(29),gx.O.AV16DisplayType5_Subtitle,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV16DisplayType5_Subtitle=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDISPLAYTYPE5_SUBTITLE",n||gx.fn.currentGridRowImpl(29))},nac:gx.falseFn};i[84]={id:84,fld:"",grid:21};i[85]={id:85,fld:"SHOWINGONLYCELL",grid:21};i[86]={id:86,fld:"TXTSHOWINGONLY",format:0,grid:21,ctrltype:"textblock"};i[87]={id:87,fld:"",grid:0};i[88]={id:88,fld:"TABLEADVANCEDSEARCHCELL",grid:0};i[89]={id:89,fld:"TABLEADVANCEDSEARCH",grid:0};i[90]={id:90,fld:"",grid:0};i[91]={id:91,fld:"",grid:0};i[92]={id:92,fld:"",grid:0};i[93]={id:93,fld:"",grid:0};i[94]={id:94,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vADVFILTERTEXT",fmt:0,gxz:"ZV8AdvFilterText",gxold:"OV8AdvFilterText",gxvar:"AV8AdvFilterText",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8AdvFilterText=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8AdvFilterText=n)},v2c:function(){gx.fn.setControlValue("vADVFILTERTEXT",gx.O.AV8AdvFilterText,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8AdvFilterText=this.val())},val:function(){return gx.fn.getControlValue("vADVFILTERTEXT")},nac:gx.falseFn};i[95]={id:95,fld:"",grid:0};i[96]={id:96,fld:"",grid:0};i[97]={id:97,fld:"TABLESPLITTEDADVFILTERENTITIES",grid:0};i[98]={id:98,fld:"",grid:0};i[99]={id:99,fld:"",grid:0};i[100]={id:100,fld:"TEXTBLOCKCOMBO_ADVFILTERENTITIES",format:0,grid:0,ctrltype:"textblock"};i[101]={id:101,fld:"",grid:0};i[103]={id:103,fld:"",grid:0};i[104]={id:104,fld:"",grid:0};i[105]={id:105,fld:"BTNBTNADVSEARCH",grid:0,evt:"e13132_client"};i[106]={id:106,fld:"",grid:0};i[107]={id:107,fld:"",grid:0};this.ZV33GXV2="";this.OV33GXV2="";this.ZV24Url="";this.OV24Url="";this.ZV10DisplayType1_Title="";this.OV10DisplayType1_Title="";this.ZV11DisplayType2_Title="";this.OV11DisplayType2_Title="";this.ZV13DisplayType3_Title="";this.OV13DisplayType3_Title="";this.ZV12DisplayType3_Subtitle="";this.OV12DisplayType3_Subtitle="";this.ZV14DisplayType4_Image="";this.OV14DisplayType4_Image="";this.ZV15DisplayType4_Title="";this.OV15DisplayType4_Title="";this.ZV17DisplayType5_Title="";this.OV17DisplayType5_Title="";this.ZV16DisplayType5_Subtitle="";this.OV16DisplayType5_Subtitle="";this.AV8AdvFilterText="";this.ZV8AdvFilterText="";this.OV8AdvFilterText="";this.AV8AdvFilterText="";this.AV9DDO_TitleSettingsIcons={Default_fi:"",Filtered_fi:"",SortedASC_fi:"",SortedDSC_fi:"",FilteredSortedASC_fi:"",FilteredSortedDSC_fi:"",OptionSortASC_fi:"",OptionSortDSC_fi:"",OptionApplyFilter_fi:"",OptionFilteringData_fi:"",OptionCleanFilters_fi:"",SelectedOption_fi:"",MultiselOption_fi:"",MultiselSelOption_fi:"",TreeviewCollapse_fi:"",TreeviewExpand_fi:"",FixLeft_fi:"",FixRight_fi:"",OptionGroup_fi:""};this.AV22SearchText="";this.GXV2="";this.AV24Url="";this.AV10DisplayType1_Title="";this.AV11DisplayType2_Title="";this.AV13DisplayType3_Title="";this.AV12DisplayType3_Subtitle="";this.AV14DisplayType4_Image="";this.AV15DisplayType4_Title="";this.AV17DisplayType5_Title="";this.AV16DisplayType5_Subtitle="";this.AV26WWP_SearchResults=[];this.AV5AdvFilterEntities=[];this.Events={e11132_client:["'DOCLOSESEARCH'",!0],e12132_client:["'DOSHOWALL'",!0],e13132_client:["'DOBTNADVSEARCH'",!0],e14132_client:["UNNAMEDTABLEFSFSRESULTS.CLICK",!0],e20132_client:["ENTER",!0],e21132_client:["CANCEL",!0],e18131_client:["'DOADVANCEDSEARCH'",!1],e19131_client:["COMBO_ADVFILTERENTITIES.ONOPTIONCLICKED",!1]};this.EvtParms.REFRESH=[[{av:"FSRESULTCATEGORIES_nFirstRecordOnPage"},{av:"FSRESULTCATEGORIES_nEOF"},{av:"FSRESULTS_nFirstRecordOnPage"},{av:"FSRESULTS_nEOF"},{av:'gx.fn.getCtrlProperty("vURL","Visible")',ctrl:"vURL",prop:"Visible"},{av:"sPrefix"},{av:"AV26WWP_SearchResults",fld:"vWWP_SEARCHRESULTS",grid:21,pic:"",hsh:!0},{av:"nGXsfl_21_idx",ctrl:"GRID",prop:"GridCurrRow",grid:21},{av:"nRC_GXsfl_21",ctrl:"FSRESULTCATEGORIES",prop:"GridRC",grid:21}],[]];this.EvtParms["FSRESULTCATEGORIES.LOAD"]=[[{av:"AV26WWP_SearchResults",fld:"vWWP_SEARCHRESULTS",grid:21,pic:"",hsh:!0},{av:"nGXsfl_21_idx",ctrl:"GRID",prop:"GridCurrRow",grid:21},{av:"FSRESULTCATEGORIES_nFirstRecordOnPage"},{av:"nRC_GXsfl_21",ctrl:"FSRESULTCATEGORIES",prop:"GridRC",grid:21}],[{av:'gx.fn.getCtrlProperty("SHOWINGONLYCELL","Visible")',ctrl:"SHOWINGONLYCELL",prop:"Visible"},{av:'gx.fn.getCtrlProperty("TXTSHOWINGONLY","Caption")',ctrl:"TXTSHOWINGONLY",prop:"Caption"}]];this.EvtParms["FSRESULTS.LOAD"]=[[{av:"AV26WWP_SearchResults",fld:"vWWP_SEARCHRESULTS",grid:21,pic:"",hsh:!0},{av:"nGXsfl_21_idx",ctrl:"GRID",prop:"GridCurrRow",grid:21},{av:"FSRESULTCATEGORIES_nFirstRecordOnPage"},{av:"nRC_GXsfl_21",ctrl:"FSRESULTCATEGORIES",prop:"GridRC",grid:21}],[{av:'gx.fn.getCtrlProperty("DISPLAYTYPE1_CELL","Visible")',ctrl:"DISPLAYTYPE1_CELL",prop:"Visible"},{av:'gx.fn.getCtrlProperty("DISPLAYTYPE2_CELL","Visible")',ctrl:"DISPLAYTYPE2_CELL",prop:"Visible"},{av:'gx.fn.getCtrlProperty("DISPLAYTYPE3_CELL","Visible")',ctrl:"DISPLAYTYPE3_CELL",prop:"Visible"},{av:'gx.fn.getCtrlProperty("DISPLAYTYPE4_CELL","Visible")',ctrl:"DISPLAYTYPE4_CELL",prop:"Visible"},{av:'gx.fn.getCtrlProperty("DISPLAYTYPE5_CELL","Visible")',ctrl:"DISPLAYTYPE5_CELL",prop:"Visible"},{av:"AV10DisplayType1_Title",fld:"vDISPLAYTYPE1_TITLE",pic:""},{av:"AV11DisplayType2_Title",fld:"vDISPLAYTYPE2_TITLE",pic:""},{av:'gx.fn.getCtrlProperty("DISPLAYTYPE2_ICON","Caption")',ctrl:"DISPLAYTYPE2_ICON",prop:"Caption"},{av:"AV13DisplayType3_Title",fld:"vDISPLAYTYPE3_TITLE",pic:""},{av:"AV12DisplayType3_Subtitle",fld:"vDISPLAYTYPE3_SUBTITLE",pic:""},{av:"AV15DisplayType4_Title",fld:"vDISPLAYTYPE4_TITLE",pic:""},{av:"AV14DisplayType4_Image",fld:"vDISPLAYTYPE4_IMAGE",pic:""},{av:'gx.fn.getCtrlProperty("vDISPLAYTYPE4_IMAGE","Visible")',ctrl:"vDISPLAYTYPE4_IMAGE",prop:"Visible"},{av:"AV17DisplayType5_Title",fld:"vDISPLAYTYPE5_TITLE",pic:""},{av:"AV16DisplayType5_Subtitle",fld:"vDISPLAYTYPE5_SUBTITLE",pic:""},{av:'gx.fn.getCtrlProperty("DISPLAYTYPE5_ICON","Caption")',ctrl:"DISPLAYTYPE5_ICON",prop:"Caption"},{av:"AV24Url",fld:"vURL",pic:""}]];this.EvtParms["'DOCLOSESEARCH'"]=[[],[]];this.EvtParms["'DOSHOWALL'"]=[[{av:"AV22SearchText",fld:"vSEARCHTEXT",pic:""}],[]];this.EvtParms["'DOADVANCEDSEARCH'"]=[[{av:'gx.fn.getCtrlProperty("TABLEADVANCEDSEARCHCELL","Class")',ctrl:"TABLEADVANCEDSEARCHCELL",prop:"Class"},{av:'gx.fn.getCtrlProperty("TABLESIMPLESEARCHCELL","Class")',ctrl:"TABLESIMPLESEARCHCELL",prop:"Class"}],[{av:"this.BTNADVANCEDSEARCHContainer.Caption",ctrl:"BTNADVANCEDSEARCH",prop:"Caption"},{av:'gx.fn.getCtrlProperty("TABLESIMPLESEARCHCELL","Class")',ctrl:"TABLESIMPLESEARCHCELL",prop:"Class"},{av:'gx.fn.getCtrlProperty("TABLEADVANCEDSEARCHCELL","Class")',ctrl:"TABLEADVANCEDSEARCHCELL",prop:"Class"}]];this.EvtParms["'DOBTNADVSEARCH'"]=[[{av:"AV8AdvFilterText",fld:"vADVFILTERTEXT",pic:""},{av:"AV5AdvFilterEntities",fld:"vADVFILTERENTITIES",pic:""}],[]];this.EvtParms["COMBO_ADVFILTERENTITIES.ONOPTIONCLICKED"]=[[{av:"this.COMBO_ADVFILTERENTITIESContainer.SelectedValue_get",ctrl:"COMBO_ADVFILTERENTITIES",prop:"SelectedValue_get"}],[{av:"AV5AdvFilterEntities",fld:"vADVFILTERENTITIES",pic:""}]];this.EvtParms["UNNAMEDTABLEFSFSRESULTS.CLICK"]=[[{av:"AV26WWP_SearchResults",fld:"vWWP_SEARCHRESULTS",grid:21,pic:"",hsh:!0},{av:"nGXsfl_21_idx",ctrl:"GRID",prop:"GridCurrRow",grid:21},{av:"FSRESULTCATEGORIES_nFirstRecordOnPage"},{av:"nRC_GXsfl_21",ctrl:"FSRESULTCATEGORIES",prop:"GridRC",grid:21},{av:"AV24Url",fld:"vURL",pic:""}],[]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV26WWP_SearchResults","vWWP_SEARCHRESULTS",0,"CollWWPBaseObjectsWWP_SearchResults.WWP_SearchResultsItem",0,0);this.setVCMap("AV22SearchText","vSEARCHTEXT",0,"svchar",40,0);this.setVCMap("AV5AdvFilterEntities","vADVFILTERENTITIES",0,"Collsvchar",0,0);this.setVCMap("AV26WWP_SearchResults","vWWP_SEARCHRESULTS",0,"CollWWPBaseObjectsWWP_SearchResults.WWP_SearchResultsItem",0,0);this.setVCMap("AV5AdvFilterEntities","vADVFILTERENTITIES",0,"Collsvchar",0,0);this.setVCMap("AV26WWP_SearchResults","vWWP_SEARCHRESULTS",0,"CollWWPBaseObjectsWWP_SearchResults.WWP_SearchResultsItem",0,0);t.addRefreshingVar({rfrVar:"AV24Url",rfrProp:"Visible",gxAttId:"Url"});t.addRefreshingVar({rfrVar:"AV26WWP_SearchResults"});t.addRefreshingParm({rfrVar:"AV24Url",rfrProp:"Visible",gxAttId:"Url"});t.addRefreshingParm({rfrVar:"AV26WWP_SearchResults"});u.addRefreshingVar({rfrVar:"AV26WWP_SearchResults"});u.addRefreshingParm({rfrVar:"AV26WWP_SearchResults"});this.addGridBCProperty("Wwp_searchresults",["CategoryName"],this.GXValidFnc[26],"AV26WWP_SearchResults");this.Initialize();this.setSDTMapping("WWPBaseObjects\\WWP_SearchResults.WWP_SearchResultsItem",{Result:{sdt:"WWPBaseObjects\\WWP_SearchResults.WWP_SearchResultsItem.ResultItem"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTDropDownOptionsTitleSettingsIcons",{Default_fi:{extr:"def"},Filtered_fi:{extr:"fil"},SortedASC_fi:{extr:"asc"},SortedDSC_fi:{extr:"dsc"},FilteredSortedASC_fi:{extr:"fasc"},FilteredSortedDSC_fi:{extr:"fdsc"},OptionSortASC_fi:{extr:"osasc"},OptionSortDSC_fi:{extr:"osdsc"},OptionApplyFilter_fi:{extr:"app"},OptionFilteringData_fi:{extr:"fildata"},OptionCleanFilters_fi:{extr:"cle"},SelectedOption_fi:{extr:"selo"},MultiselOption_fi:{extr:"mul"},MultiselSelOption_fi:{extr:"muls"},TreeviewCollapse_fi:{extr:"tcol"},TreeviewExpand_fi:{extr:"texp"},FixLeft_fi:{extr:"fixl"},FixRight_fi:{extr:"fixr"},OptionGroup_fi:{extr:"og"}});this.setSDTMapping("WWPBaseObjects\\DVB_SDTComboData.Item",{Title:{extr:"T"},Children:{extr:"C"}})})