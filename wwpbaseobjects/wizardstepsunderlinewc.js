gx.evt.autoSkip=!1;gx.define("wwpbaseobjects.wizardstepsunderlinewc",!0,function(n){var i,t;this.ServerClass="wwpbaseobjects.wizardstepsunderlinewc";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwpbaseobjects.wizardstepsunderlinewc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.AV19WizardStepsAux=gx.fn.getControlValue("vWIZARDSTEPSAUX");this.AV16StepRealNumber=gx.fn.getIntegerValue("vSTEPREALNUMBER",".");this.AV15StepNumber=gx.fn.getIntegerValue("vSTEPNUMBER",".");this.AV13SelectedStepNumber=gx.fn.getIntegerValue("vSELECTEDSTEPNUMBER",".");this.AV20WizardStepsCount=gx.fn.getIntegerValue("vWIZARDSTEPSCOUNT",".");this.AV7FirstIsDummy=gx.fn.getControlValue("vFIRSTISDUMMY");this.AV8LastIsDummy=gx.fn.getControlValue("vLASTISDUMMY");this.AV18WizardSteps=gx.fn.getControlValue("vWIZARDSTEPS");this.AV11PenultimateIsDummy=gx.fn.getControlValue("vPENULTIMATEISDUMMY");this.AV6CurrentStep=gx.fn.getControlValue("vCURRENTSTEP");this.AV19WizardStepsAux=gx.fn.getControlValue("vWIZARDSTEPSAUX");this.AV16StepRealNumber=gx.fn.getIntegerValue("vSTEPREALNUMBER",".");this.AV15StepNumber=gx.fn.getIntegerValue("vSTEPNUMBER",".");this.AV13SelectedStepNumber=gx.fn.getIntegerValue("vSELECTEDSTEPNUMBER",".");this.AV20WizardStepsCount=gx.fn.getIntegerValue("vWIZARDSTEPSCOUNT",".");this.AV7FirstIsDummy=gx.fn.getControlValue("vFIRSTISDUMMY");this.AV8LastIsDummy=gx.fn.getControlValue("vLASTISDUMMY");this.AV18WizardSteps=gx.fn.getControlValue("vWIZARDSTEPS");this.AV11PenultimateIsDummy=gx.fn.getControlValue("vPENULTIMATEISDUMMY")};this.e13102_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e14102_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];i=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24];this.GXLastCtrlId=24;this.GridwizardstepsContainer=new gx.grid.grid(this,2,"WbpLvl2",9,"Gridwizardsteps","Gridwizardsteps","GridwizardstepsContainer",this.CmpContext,this.IsMasterPage,"wwpbaseobjects.wizardstepsunderlinewc",[],!0,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Novo registro",!1,!1,!1,gx.grid.flexGrid,null,!1,"",!0,[0,0,0,0],!1,0,!1,!1);t=this.GridwizardstepsContainer;t.startDiv(10,"Unnamedtablefsgridwizardsteps","0px","0px");t.startDiv(11,"","0px","0px");t.startDiv(12,"","0px","0px");t.startDiv(13,"Tblcontainerstep","0px","0px");t.startDiv(14,"","0px","0px");t.startDiv(15,"Tablestepitem","0px","0px");t.startDiv(16,"","0px","0px");t.startDiv(17,"","0px","0px");t.addTextBlock("STEPNUMBER",null,18);t.endDiv();t.endDiv();t.endDiv();t.endDiv();t.startDiv(19,"","0px","0px");t.startDiv(20,"","0px","0px");t.addLabel();t.addMultipleLineEdit("Wizardsteptitle",21,"vWIZARDSTEPTITLE","","WizardStepTitle","svchar",80,"chr",3,"row","200",200,"left",null,!0,!1,0,"");t.endDiv();t.endDiv();t.endDiv();t.endDiv();t.endDiv();t.endDiv();this.GridwizardstepsContainer.emptyText="";t.setRenderProp("Class","Class","FreeStyleStepsUnderline","str");t.setRenderProp("Enabled","Enabled",!0,"boolean");t.setRenderProp("FlexDirection","Flexdirection","row","str");t.setRenderProp("FlexWrap","Flexwrap","nowrap","str");t.setRenderProp("JustifyContent","Justifycontent","flex-start","str");t.setRenderProp("AlignItems","Alignitems","stretch","str");t.setRenderProp("AlignContent","Aligncontent","stretch","str");t.setRenderProp("Visible","Visible",!0,"boolean");this.setGrid(t);i[2]={id:2,fld:"",grid:0};i[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};i[4]={id:4,fld:"",grid:0};i[5]={id:5,fld:"",grid:0};i[6]={id:6,fld:"TABLEMAIN",grid:0};i[7]={id:7,fld:"",grid:0};i[8]={id:8,fld:"",grid:0};i[10]={id:10,fld:"UNNAMEDTABLEFSGRIDWIZARDSTEPS",grid:9};i[11]={id:11,fld:"",grid:9};i[12]={id:12,fld:"",grid:9};i[13]={id:13,fld:"TBLCONTAINERSTEP",grid:9};i[14]={id:14,fld:"",grid:9};i[15]={id:15,fld:"TABLESTEPITEM",grid:9};i[16]={id:16,fld:"",grid:9};i[17]={id:17,fld:"",grid:9};i[18]={id:18,fld:"STEPNUMBER",format:0,grid:9,ctrltype:"textblock"};i[19]={id:19,fld:"",grid:9};i[20]={id:20,fld:"",grid:9};i[21]={id:21,lvl:2,type:"svchar",len:200,dec:0,sign:!1,ro:1,isacc:0,multiline:!0,grid:9,gxgrid:this.GridwizardstepsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vWIZARDSTEPTITLE",fmt:0,gxz:"ZV22WizardStepTitle",gxold:"OV22WizardStepTitle",gxvar:"AV22WizardStepTitle",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV22WizardStepTitle=n)},v2z:function(n){n!==undefined&&(gx.O.ZV22WizardStepTitle=n)},v2c:function(n){gx.fn.setGridControlValue("vWIZARDSTEPTITLE",n||gx.fn.currentGridRowImpl(9),gx.O.AV22WizardStepTitle,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV22WizardStepTitle=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vWIZARDSTEPTITLE",n||gx.fn.currentGridRowImpl(9))},nac:gx.falseFn};i[22]={id:22,fld:"",grid:0};i[23]={id:23,fld:"",grid:0};i[24]={id:24,fld:"WIZARDSTEPDESCRIPTION",format:0,grid:0,ctrltype:"textblock"};this.ZV22WizardStepTitle="";this.OV22WizardStepTitle="";this.AV18WizardSteps=[];this.AV6CurrentStep="";this.AV22WizardStepTitle="";this.AV19WizardStepsAux=[];this.AV16StepRealNumber=0;this.AV15StepNumber=0;this.AV13SelectedStepNumber=0;this.AV20WizardStepsCount=0;this.AV7FirstIsDummy=!1;this.AV8LastIsDummy=!1;this.AV11PenultimateIsDummy=!1;this.Events={e13102_client:["ENTER",!0],e14102_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRIDWIZARDSTEPS_nFirstRecordOnPage"},{av:"GRIDWIZARDSTEPS_nEOF"},{av:"AV18WizardSteps",fld:"vWIZARDSTEPS",pic:""},{av:"sPrefix"},{av:"AV19WizardStepsAux",fld:"vWIZARDSTEPSAUX",pic:"",hsh:!0},{av:"AV16StepRealNumber",fld:"vSTEPREALNUMBER",pic:"ZZZ9",hsh:!0},{av:"AV15StepNumber",fld:"vSTEPNUMBER",pic:"ZZZ9",hsh:!0},{av:"AV13SelectedStepNumber",fld:"vSELECTEDSTEPNUMBER",pic:"ZZZ9",hsh:!0},{av:"AV20WizardStepsCount",fld:"vWIZARDSTEPSCOUNT",pic:"ZZZ9",hsh:!0},{av:"AV7FirstIsDummy",fld:"vFIRSTISDUMMY",pic:"",hsh:!0},{av:"AV8LastIsDummy",fld:"vLASTISDUMMY",pic:"",hsh:!0},{av:"AV11PenultimateIsDummy",fld:"vPENULTIMATEISDUMMY",pic:"",hsh:!0}],[]];this.EvtParms["GRIDWIZARDSTEPS.LOAD"]=[[{av:"AV19WizardStepsAux",fld:"vWIZARDSTEPSAUX",pic:"",hsh:!0},{av:"AV16StepRealNumber",fld:"vSTEPREALNUMBER",pic:"ZZZ9",hsh:!0},{av:"AV15StepNumber",fld:"vSTEPNUMBER",pic:"ZZZ9",hsh:!0},{av:"AV13SelectedStepNumber",fld:"vSELECTEDSTEPNUMBER",pic:"ZZZ9",hsh:!0},{av:"AV20WizardStepsCount",fld:"vWIZARDSTEPSCOUNT",pic:"ZZZ9",hsh:!0},{av:"AV7FirstIsDummy",fld:"vFIRSTISDUMMY",pic:"",hsh:!0},{av:"AV8LastIsDummy",fld:"vLASTISDUMMY",pic:"",hsh:!0},{av:"AV18WizardSteps",fld:"vWIZARDSTEPS",pic:""},{av:"AV11PenultimateIsDummy",fld:"vPENULTIMATEISDUMMY",pic:"",hsh:!0}],[{av:"AV22WizardStepTitle",fld:"vWIZARDSTEPTITLE",pic:""},{av:'gx.fn.getCtrlProperty("STEPNUMBER","Caption")',ctrl:"STEPNUMBER",prop:"Caption"},{av:'gx.fn.getCtrlProperty("TBLCONTAINERSTEP","Class")',ctrl:"TBLCONTAINERSTEP",prop:"Class"},{av:'gx.fn.getCtrlProperty("TABLESTEPITEM","Class")',ctrl:"TABLESTEPITEM",prop:"Class"},{av:'gx.fn.getCtrlProperty("TABLESTEPITEM","Visible")',ctrl:"TABLESTEPITEM",prop:"Visible"},{av:'gx.fn.getCtrlProperty("UNNAMEDTABLEFSGRIDWIZARDSTEPS","Class")',ctrl:"UNNAMEDTABLEFSGRIDWIZARDSTEPS",prop:"Class"},{av:'gx.fn.getCtrlProperty("TBLCONTAINERSTEP","Visible")',ctrl:"TBLCONTAINERSTEP",prop:"Visible"},{av:"AV16StepRealNumber",fld:"vSTEPREALNUMBER",pic:"ZZZ9",hsh:!0},{av:"AV15StepNumber",fld:"vSTEPNUMBER",pic:"ZZZ9",hsh:!0},{av:'gx.fn.getCtrlProperty("STEPNUMBER","Visible")',ctrl:"STEPNUMBER",prop:"Visible"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV19WizardStepsAux","vWIZARDSTEPSAUX",0,"CollWWPBaseObjectsWizardSteps.WizardStepsItem",0,0);this.setVCMap("AV16StepRealNumber","vSTEPREALNUMBER",0,"int",4,0);this.setVCMap("AV15StepNumber","STEPNUMBER",0,"int",4,0);this.setVCMap("AV13SelectedStepNumber","vSELECTEDSTEPNUMBER",0,"int",4,0);this.setVCMap("AV20WizardStepsCount","vWIZARDSTEPSCOUNT",0,"int",4,0);this.setVCMap("AV7FirstIsDummy","vFIRSTISDUMMY",0,"boolean",4,0);this.setVCMap("AV8LastIsDummy","vLASTISDUMMY",0,"boolean",4,0);this.setVCMap("AV18WizardSteps","vWIZARDSTEPS",0,"CollWWPBaseObjectsWizardSteps.WizardStepsItem",0,0);this.setVCMap("AV11PenultimateIsDummy","vPENULTIMATEISDUMMY",0,"boolean",4,0);this.setVCMap("AV6CurrentStep","vCURRENTSTEP",0,"svchar",40,0);this.setVCMap("AV19WizardStepsAux","vWIZARDSTEPSAUX",0,"CollWWPBaseObjectsWizardSteps.WizardStepsItem",0,0);this.setVCMap("AV16StepRealNumber","vSTEPREALNUMBER",0,"int",4,0);this.setVCMap("AV15StepNumber","STEPNUMBER",0,"int",4,0);this.setVCMap("AV13SelectedStepNumber","vSELECTEDSTEPNUMBER",0,"int",4,0);this.setVCMap("AV20WizardStepsCount","vWIZARDSTEPSCOUNT",0,"int",4,0);this.setVCMap("AV7FirstIsDummy","vFIRSTISDUMMY",0,"boolean",4,0);this.setVCMap("AV8LastIsDummy","vLASTISDUMMY",0,"boolean",4,0);this.setVCMap("AV18WizardSteps","vWIZARDSTEPS",0,"CollWWPBaseObjectsWizardSteps.WizardStepsItem",0,0);this.setVCMap("AV11PenultimateIsDummy","vPENULTIMATEISDUMMY",0,"boolean",4,0);this.setVCMap("AV19WizardStepsAux","vWIZARDSTEPSAUX",0,"CollWWPBaseObjectsWizardSteps.WizardStepsItem",0,0);this.setVCMap("AV16StepRealNumber","vSTEPREALNUMBER",0,"int",4,0);this.setVCMap("AV15StepNumber","STEPNUMBER",0,"int",4,0);this.setVCMap("AV13SelectedStepNumber","vSELECTEDSTEPNUMBER",0,"int",4,0);this.setVCMap("AV20WizardStepsCount","vWIZARDSTEPSCOUNT",0,"int",4,0);this.setVCMap("AV7FirstIsDummy","vFIRSTISDUMMY",0,"boolean",4,0);this.setVCMap("AV8LastIsDummy","vLASTISDUMMY",0,"boolean",4,0);this.setVCMap("AV18WizardSteps","vWIZARDSTEPS",0,"CollWWPBaseObjectsWizardSteps.WizardStepsItem",0,0);this.setVCMap("AV11PenultimateIsDummy","vPENULTIMATEISDUMMY",0,"boolean",4,0);t.addRefreshingVar({rfrVar:"AV19WizardStepsAux"});t.addRefreshingVar({rfrVar:"AV16StepRealNumber"});t.addRefreshingVar({rfrVar:"AV15StepNumber"});t.addRefreshingVar({rfrVar:"AV13SelectedStepNumber"});t.addRefreshingVar({rfrVar:"AV20WizardStepsCount"});t.addRefreshingVar({rfrVar:"AV7FirstIsDummy"});t.addRefreshingVar({rfrVar:"AV8LastIsDummy"});t.addRefreshingVar({rfrVar:"AV18WizardSteps"});t.addRefreshingVar({rfrVar:"AV11PenultimateIsDummy"});t.addRefreshingParm({rfrVar:"AV19WizardStepsAux"});t.addRefreshingParm({rfrVar:"AV16StepRealNumber"});t.addRefreshingParm({rfrVar:"AV15StepNumber"});t.addRefreshingParm({rfrVar:"AV13SelectedStepNumber"});t.addRefreshingParm({rfrVar:"AV20WizardStepsCount"});t.addRefreshingParm({rfrVar:"AV7FirstIsDummy"});t.addRefreshingParm({rfrVar:"AV8LastIsDummy"});t.addRefreshingParm({rfrVar:"AV18WizardSteps"});t.addRefreshingParm({rfrVar:"AV11PenultimateIsDummy"});this.Initialize()})