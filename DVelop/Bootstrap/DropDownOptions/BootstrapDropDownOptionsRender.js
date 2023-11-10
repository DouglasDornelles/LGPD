﻿function BootstrapDropDownOptions(){var n=this;Object.defineProperty(this,"Visible",{get:function(){return n.VisibleVal},set:function(t){n.VisibleVal!==t&&(n.VisibleVal=t,n.my_dropDownOptions!=undefined&&n.onaftereventx())},enumerable:!0,configurable:!0});this.DropDownOptionsTitleSettingsIcons_IsFI=!0;this.SetDropDownOptionsData=function(n){var i,t,r,f,h,e,c,u,o,s;this.DropDownOptionsTitleSettingsIcons_IsFI=this.DropDownOptionsTitleSettingsIcons!=null&&this.DropDownOptionsTitleSettingsIcons.def!=null&&this.DropDownOptionsTitleSettingsIcons.def.length>0;this.DropDownOptionsType=="GridTitleSettings"?(this.FilteredText_get=this.FilteredText_set,this.FilteredText=this.FilteredText_get,this.FilteredTextTo_get=this.FilteredTextTo_set,this.FilteredTextTo=this.FilteredTextTo_get,this.SelectedValue_get=this.SelectedValue_set,this.SelectedValue=this.SelectedValue_get,this.SelectedText_get=this.SelectedText_set,this.SelectedText=this.SelectedText_get,this.UseAsGridTitleSetting=!0,n!=undefined&&(this.IncludeSortASC=WWP_FixBooleanProperty(this.IncludeSortASC),this.IncludeSortDSC=WWP_FixBooleanProperty(this.IncludeSortDSC),this.AllowGroup=WWP_FixBooleanProperty(this.AllowGroup),this.Fixable=WWP_FixBooleanProperty(this.Fixable),i=n.length==0,this.AllowGroup&&(i||!this.DataHasEventKey("<#Group#>",n))&&(t={},t.EventKey="<#Group#>",t.FontIcon=this.DropDownOptionsTitleSettingsIcons_IsFI?this.DropDownOptionsTitleSettingsIcons.og:"",this.DropDownOptionsTitleSettingsIcons_IsFI&&(t.FontIcon==null||t.FontIcon=="")&&(t.FontIcon=this.DropDownOptionsTitleSettingsIcons.osasc),t.Icon=this.DropDownOptionsTitleSettingsIcons_IsFI?"":gx.util.resolveUrl(this.DropDownOptionsTitleSettingsIcons.OptionSortASC),t.Icon_GXI="",t.IsDivider=!1,t.JSonclickEvent="",t.Link="",t.Title=gx.getMessage(this.AllowGroupText),t.Tooltip="",n.push(t)),this.IncludeSortASC&&(i||!this.DataHasEventKey("<#OrderASC#>",n))&&(t={},t.EventKey="<#OrderASC#>",t.FontIcon=this.DropDownOptionsTitleSettingsIcons_IsFI?this.DropDownOptionsTitleSettingsIcons.osasc:"",t.Icon=this.DropDownOptionsTitleSettingsIcons_IsFI?"":gx.util.resolveUrl(this.DropDownOptionsTitleSettingsIcons.OptionSortASC),t.Icon_GXI="",t.IsDivider=!1,t.JSonclickEvent="",t.Link="",t.Title=gx.getMessage(this.SortASC),t.Tooltip="",n.push(t)),this.IncludeSortDSC&&(i||!this.DataHasEventKey("<#OrderDSC#>",n))&&(t={},t.EventKey="<#OrderDSC#>",t.FontIcon=this.DropDownOptionsTitleSettingsIcons_IsFI?this.DropDownOptionsTitleSettingsIcons.osdsc:"",t.Icon=this.DropDownOptionsTitleSettingsIcons_IsFI?"":gx.util.resolveUrl(this.DropDownOptionsTitleSettingsIcons.OptionSortDSC),t.Icon_GXI="",t.IsDivider=!1,t.JSonclickEvent="",t.Link="",t.Title=gx.getMessage(this.SortDSC),t.Tooltip="",n.push(t)),this.Fixable&&(t={},t.EventKey="<#FixLeft#>",t.FontIcon=this.DropDownOptionsTitleSettingsIcons_IsFI?this.DropDownOptionsTitleSettingsIcons.fixl:"",t.Icon=this.DropDownOptionsTitleSettingsIcons_IsFI?"":gx.util.resolveUrl(this.DropDownOptionsTitleSettingsIcons.OptionSortASC),t.Icon_GXI="",t.IsDivider=!1,t.JSonclickEvent="",t.Link="",t.Title=gx.getMessage(wwp.labels.FixLeftText),t.Tooltip="",n.push(t),t={},t.EventKey="<#FixRight#>",t.FontIcon=this.DropDownOptionsTitleSettingsIcons_IsFI?this.DropDownOptionsTitleSettingsIcons.fixr:"",t.Icon=this.DropDownOptionsTitleSettingsIcons_IsFI?"":gx.util.resolveUrl(this.DropDownOptionsTitleSettingsIcons.OptionSortDSC),t.Icon_GXI="",t.IsDivider=!1,t.JSonclickEvent="",t.Link="",t.Title=gx.getMessage(wwp.labels.FixRightText),t.Tooltip="",n.push(t)),(this.IncludeFilter||this.IncludeDataList||this.FixedFilters!="")&&(i||!this.DataHasEventKey("<#FilterOptions#>",n))&&((this.IncludeSortASC||this.IncludeSortDSC||this.Fixable)&&(t={},t.EventKey="",t.Icon="",t.Icon_GXI="",t.IsDivider=!0,t.JSonclickEvent="",t.Link="",t.Title="",t.Tooltip="",n.push(t)),t={},t.EventKey="<#FilterOptions#>",t.Icon="",t.Icon_GXI="",t.IsDivider=!1,t.JSonclickEvent="",t.Link="",t.Title=gx.getMessage(this.LoadingData),t.Tooltip="",n.push(t)))):(this.UseAsGridTitleSetting=!1,(this.DropDownOptionsType=="ExtendedComboBox"||this.DropDownOptionsType=="ExtendedSuggest")&&(r=this.extendedCombo_getAttributeInfo(),f=r==null||this.isFirstLoad==null||this.SelectedValue_get=="<#POPUP_CLOSED#>",r!=null?(h=$(r.comboVarSelector).val(),this.lastComboVarValue!=h&&(f=!0),this.lastComboVarValue=h):f&&this.isFirstLoad!=null&&this.DropDownOptionsTitleSettingsIcons!=null&&this.DropDownOptionsTitleSettingsIcons!==""&&this.DropDownOptionsTitleSettingsIcons[this.ControlName+"loaded"]==null&&this.SelectedValue_get!="<#POPUP_CLOSED#>"&&(this.SelectedValue_set=this.SelectedValue_get,this.SelectedText_set=this.SelectedText_get),f&&(this.isFirstLoad=!1,r==null&&this.DropDownOptionsTitleSettingsIcons!=null&&(this.DropDownOptionsTitleSettingsIcons[this.ControlName+"loaded"]=!0),this.SelectedValue_get=this.SelectedValue_set,this.SelectedValue=this.SelectedValue_get,this.DataListProc==null||this.DataListProc==""?(this.SelectedText_get="",this.SelectedText=""):(this.SelectedText_get=this.SelectedText_set,this.SelectedText=this.SelectedText_get)),this.DDOInternalName=this.ContainerName+(this.DropDownOptionsType=="ExtendedComboBox"?"_btnGroupDrop":"_inputSuggest")));e=!0;n!=undefined&&(n.length!=null&&(n.length>0||this.updating)||this.DropDownOptionsType=="ExtendedComboBox"||this.DropDownOptionsType=="ExtendedSuggest"?(delete this.updating,(this.DropDownOptionsData==null||this.my_dropDownOptions==null||this.DropDownOptionsData.length!=n.length||$("#"+this.my_dropDownOptions.containerToDrawName).find(".Errorbtn").length==0||JSON.stringify(this.DropDownOptionsData,null,2)!=JSON.stringify(n,null,2))&&(this.DropDownOptionsData=n,e=!1)):this.DropDownOptionsType=="GridColumnsSelector"&&(n.VisibleColumns!=undefined?n.VisibleColumns.length:0)+(n.InvisibleColumns!=undefined?n.InvisibleColumns.length:0)+(n.Columns!=undefined?n.Columns.length:0)>0&&(this.GridInternalName=="<LISTVIEW>GRID"&&(this.isWPMultiplesView=!0,c=$("#"+WWP_getCurrentWCId(this)+"DATAWC_CELL").find(">.gxwebcomponent").attr("id"),c!=null&&(this.GridInternalName=this.GridInternalName.replace("<LISTVIEW>",c.replace("gxHTMLWrp","")))),this.DropDownOptionsData=n,this.DropDownOptionsData_VisibleColumns=this.DropDownOptionsData.VisibleColumns,this.DropDownOptionsData_InvisibleColumns=this.DropDownOptionsData.InvisibleColumns,this.DropDownOptionsData_Columns=JSON.parse(JSON.stringify(this.DropDownOptionsData.Columns,null,2)),(this.DropDownOptionsData_VisibleColumns!=undefined||this.DropDownOptionsData_VisibleColumns!=undefined)&&(this.DropDownOptionsData_VisibleColumns==undefined&&(this.DropDownOptionsData_VisibleColumns=[]),this.DropDownOptionsData_InvisibleColumns==undefined&&(this.DropDownOptionsData_InvisibleColumns=[])),this.ColSelRestoring?(delete this.ColSelRestoring,WWP_HasGridEmpowerer(this)&&(u=WWP_GetEmpowerer(this),o=WWP_GetGrid(this),u!=null&&u.InfiniteScrolling=="Grid"&&u.ColumnSelectorHelper!=null&&o.hasClass("gx-infinite-scrolling-container")?(s=u.GetGxGrid(),s!=null&&s.fixedColVisibleCount!=null&&(s.fixedColVisibleCount=null,o.removeClass("gx-infinite-scrolling-container"),o.find(">table>tbody").removeClass("gx-infinite-scrolling-element")),this.DropDownOptionsData_Columns=null):WWP_ClearEmpowerReference(this,"WWP.GridColumnSelector"))):WWP_NotifyEmpower(this,"WWP.GridColumnSelector"),e=!1));this.my_dropDownOptions==undefined||e||this.controlRender()};this.destroy=function(){this.onaftereventxHandler!=null&&(gx.fx.obs.deleteObserver("gx.onafterevent",window,this.onaftereventxHandler),gx.fx.obs.deleteObserver("grid.onafterrender",window,this.onaftereventxHandler),gx.fx.obs.deleteObserver("popup.afterclose",this,this.onPopupClose))};this.extendedCombo_getAttributeInfo=function(n){var r=null,t=WWP_getCurrentWCId(this),i,u;if(this.IsGridItem){if(n!=null&&(i=n.substring(4),t!=""&&(i=i.substring(t.length)),$("#"+i).length==1))return{attName:i,wcName:t}}else if(WWP_endsWith(this.ContainerName,"Container")&&WWP_startsWith(this.ContainerName,t+"COMBO_")&&(r=this.ContainerName.substring(t.length+6,this.ContainerName.length-9),u="#"+t+"vCOMBO"+r,$(u).length==1&&$(u).parent().attr("id")==t+"SECTIONATTRIBUTE_"+r))return{attName:r,wcName:t,comboVarSelector:u};return null};this.setGridItemDynamicDescription=function(n){var i=n.getGridItemSelectedValue(),r,t,u;i!=""?n.realSelectedText==null&&(r=n.getAjaxCallRestURL(),t=JSON.stringify([i],null,2),t=WWP_replaceAll(t,"\\","\\\\"),t=WWP_replaceAll(t,'"','\\"'),t=WWP_replaceAll(t,"\n",""),t=WWP_replaceAll(t,"\r",""),u=WWP_replaceAll(WWP_replaceAll(n.getDataListProcParametersPrefix(),'"TrnMode": ""','"TrnMode": "GET_DSC"'),'"TrnMode": "INS"','"TrnMode": "GET_DSC"'),this.ajaxCall=$.ajax({"async":!1,type:"POST",url:r,headers:{Authorization:this.GAMOAuthToken},contentType:"application/json",data:"{"+u+', "SearchTxt'+(wwp.settings.columnsSelector.InfiniteScrolling?"Parms":"")+'": "'+t+'"}',success:function(t){if(t!=null&&t.Combo_DataJson!=null&&t.Combo_DataJson!=""){var r=JSON.parse(t.Combo_DataJson);n.realSelectedText=r.length!=1||r[0]==""&&n.hasHTMLTemplate()?n.hasHTMLTemplate()?JSON.stringify({text:i},null,2):i:r[0]}},error:function(n,t,i){console.log("jqXHR statusCode"+n.statusCode());console.log("textStatus "+t);console.log("errorThrown "+i);n!=null&&n.status==401&&window.location.reload()}})):n.realSelectedText=null};this.controlRender=function(){this.IsM&&WWP_HasGridEmpowerer(this.MControl)?WWP_NotifyEmpower(this,"WWP.TitleSettings"):this.IsGridItem?this.controlRenderGridItem():this.my_dropDownOptions.render()};this.controlRenderGridItem=function(n){var c,e,s,tt,f,u,v,b,k,et,h,ot,r,it,y,rt,d;if(this.AllowMultipleSelection&&this.openedControl!=null){if($("#"+this.openedControl).hasClass("open"))return;delete this.openedControl}var t=[],l=!1,o=this.TitleControlIdToReplace,a=$("#"+(n!=null?n:o+"_0001"));a.length==0&&(o.length>9&&o.indexOf("_EDITABLE")==o.length-9?(a=$("#"+o+"2_0001"),o=o+"2"):this.AllowMultipleSelection&&(a=$("#span_"+(n!=null?n:o+"_0001")),a.length>0&&(o="span_"+o,l=!0,this.MultipleValuesSeparator=this.MultipleValuesSeparator==""?wwp.labels.MultipleValuesSeparator:this.MultipleValuesSeparator)));var p=this,g=this.DataListProc!=null&&this.DataListProc!="",w=g&&this.HasDescription,nt=w&&this.DataListProcParametersPrefix.indexOf("#")>0;if(a.length>0){var ut=a.closest(".gx-grid"),ft=ut.hasClass("gx-freestyle-grid"),i=null;for(l&&!w&&(i=new DVelopBootstrapDropDownOptions(this)),r=1;r<1e3;r++){if(c="000"+r,c=o+"_"+c.substring(c.length-4),e=n!=null?a:ut.find("#"+c),e.length==0)break;if(l?e.data("comboDscLoaded")==null&&(e.data("comboDscLoaded",""),u=e.text(),g&&!this.HasDescription?(v=u!=null&&u!=""?JSON.parse(u):[],e.text(i.GetMultipleSelection_ReadonlyCaption(v))):w?nt||(i=new DVelopBootstrapDropDownOptions(this),i._currentVal=u,i._$controlForText=e,t.push(i)):g||(this.SelectedValue=u,this.SelectedText="",i.loadExtendedComboSelectedText(this.DropDownOptionsData,null,!0),e.text(i.GetMultipleSelection_ReadonlyCaption(this.SelectedText!=null&&this.SelectedText!=""?JSON.parse(this.SelectedText):[])))):(s=e.closest(ft?".gx-attribute":"td"),ft?(s.css("display","none"),s=s.parent(),s.addClass("DVelopComboFSGridCell")):(e.addClass("Attribute"),e.hasClass("Errorform-control")&&e.addClass("ErrorAttribute"),s.addClass("DVelopComboGridCell")),tt=s.find(">#DVC_"+c),tt.length==0?(tt=s.find(">*").last().after('<div id="DVC_'+c+'" ><\/div>').find(">#DVC_"+c),i=new DVelopBootstrapDropDownOptions(this),i.realId=n!=null?n:c,s.data("ddo",i),i.realSelectedText=null):i=s.data("ddo"),nt&&this.setGridItemDynamicDescription(i),t.push(i)),n!=null)break}}if(w&&!nt){for(f=[],r=0;r<t.length;r++)if(u=l?t[r]._currentVal:t[r].getGridItemSelectedValue(),u!="")if(this.AllowMultipleSelection)for(v=u!=null&&u!=""?JSON.parse(u):[],b=0;b<v.length;b++)k=v[b],k!=""&&this.FindDscInAjaxResult(k,f,f)==null&&f.push(k);else this.FindDscInAjaxResult(u,f,f)==null&&f.push(u);f.length>0&&(et=WWP_getAjaxCallRestURL(this.DataListProc),h=JSON.stringify(f,null,2),h=WWP_replaceAll(h,"\\","\\\\"),h=WWP_replaceAll(h,'"','\\"'),h=WWP_replaceAll(h,"\n",""),h=WWP_replaceAll(h,"\r",""),ot=WWP_replaceAll(WWP_replaceAll(this.DataListProcParametersPrefix,'"TrnMode": ""','"TrnMode": "GET_DSC"'),'"TrnMode": "INS"','"TrnMode": "GET_DSC"'),this.ajaxCall=$.ajax({"async":!1,type:"POST",url:et,headers:{Authorization:this.GAMOAuthToken},contentType:"application/json",data:"{"+ot+', "SearchTxt'+(wwp.settings.columnsSelector.InfiniteScrolling?"Parms":"")+'": "'+h+'"}',success:function(n){var e=JSON.parse(n.Combo_DataJson),r,u,o,c,s,h,a;if(e.length==f.length)for(r=0;r<t.length;r++)if(u=l?t[r]._currentVal:t[r].getGridItemSelectedValue(),u!="")if(p.AllowMultipleSelection){for(o=[],c=u!=null&&u!=""?JSON.parse(u):[],s=0;s<c.length;s++)h=c[s],h!=""&&o.push(p.FindDscInAjaxResult(h,f,e,h));l?t[r]._$controlForText.text(t[r].GetMultipleSelection_ReadonlyCaption(o)):t[r].realSelectedText=JSON.stringify(o,null,2)}else t[r].realSelectedText=p.FindDscInAjaxResult(u,f,e,u),t[r].realSelectedText==""&&t[r].hasHTMLTemplate()&&(a=p.FindDscInAjaxResult(u,f,e,u),t[r].realSelectedText=i.hasHTMLTemplate()?JSON.stringify({text:u},null,2):u)},error:function(n,t,i){console.log("jqXHR statusCode"+n.statusCode());console.log("textStatus "+t);console.log("errorThrown "+i);n!=null&&n.status==401&&window.location.reload()}}))}if(!l){for(r=0;r<t.length;r++)it=t[r],it.render(),y=$("#"+it.containerToDrawName),rt=y.parent().find("> input.ErrorAttribute + div"),rt.length==1&&y.find(".Errorbtn").length==0&&y.find(">button").length==1&&(d=rt.text(),d!=null&&d.trim()!=""&&gx.fn.alert(y.find(">button")[0],d));window.setTimeout(function(){for(var i,r,n=0;n<t.length;n++)i=t[n].isEnabled(),r=$("#"+t[n].containerToDrawName).find(">button").length>0,r!=i&&t[n].render()},100)}};this.FindDscInAjaxResult=function(n,t,i,r){for(var u=0;u<t.length;u++)if(t[u]==n)return i[u];return r};this.SetFocus=function(){WWP_FixBooleanProperty(this.Enabled)&&(this.DropDownOptionsType=="ExtendedComboBox"?$("#"+this.ContainerName+"_btnGroupDrop").focus():this.DropDownOptionsType=="ExtendedSuggest"&&$("#"+this.ContainerName+"_inputSuggest").focus())};this.onPopupClose=function(){var r;if(this.isNew&&(this.isNew=!1,this.my_dropDownOptions.SetSelectedValue("<#POPUP_CLOSED#>"),$("#"+this.my_dropDownOptions.containerToDrawName).find("button").focus(),this.my_dropDownOptions.SetSelectedText(""),this.my_dropDownOptions.updatedExtendedComboCaption(null),!this.AllowMultipleSelection)){var i=!1,t=null,n=WWP_getCurrentWCId(this);if(WWP_endsWith(this.ContainerName,"Container")&&WWP_startsWith(this.ContainerName,n+"COMBO_")&&(t=this.ContainerName.substring(n.length+6,this.ContainerName.length-9),$("#"+n+"vCOMBO"+t).length==1&&$("#"+n+"vCOMBO"+t).parent().attr("id")==n+"SECTIONATTRIBUTE_"+t&&(i=!0)),i){r=this;$("#"+n+"vCOMBO"+t).parent().one("DOMSubtreeModified",function(){$("#"+n+t).val($("#"+n+"vCOMBO"+t).val());r.my_dropDownOptions.updatedExtendedComboCaption(null);WWP_GxValidControl(n+t)})}this.OnOptionClicked();i||this.IsGridItem||this.updatedExtendedComboCaptionAfterPopupClose(10)}};this.updatedExtendedComboCaptionAfterPopupClose=function(n){var i=this.Caption,t;this.my_dropDownOptions.updatedExtendedComboCaption(null);i==this.Caption&&n>0&&(n--,t=this,window.setTimeout(function(){t.updatedExtendedComboCaptionAfterPopupClose(n)},n<=1?1e3:100))};this.DataHasEventKey=function(n,t){t=t!=null?t:this.DropDownOptionsData;for(var i=0;i<t.length;i+=1)if(t[i].EventKey==n)return!0;return!1};this.GetDropDownOptionsData=function(){return this.DropDownOptionsData};this.SetDropDownOptionsTitleSettingsIcons=function(n){n!=undefined&&n.Default!=""&&(this.DropDownOptionsTitleSettingsIcons=n)};this.GetDropDownOptionsTitleSettingsIcons=function(){return this.DropDownOptionsTitleSettingsIcons};this.onaftereventx=function(){var t=!0,i,u,f,r,n,e,o;if(this.my_dropDownOptions!=null){if(i=$("#"+this.my_dropDownOptions.containerToDrawName),!(this.IsM&&this.MControl.IsFS)&&(u=i.attr("class"),u!=null&&u!=""))try{if(f=i.children(),f.length==2)for(r=f[1],n=0;n<r.children.length;n++)if(r.children[n].children.length==1&&(e=r.children[n].children[0],o=$._data(e,"events"),o!=null)){t=!1;break}}catch(s){console.log("onaftereventx - error verifying if controlRender is necessary: "+s.message)}t&&i.find(".Errorbtn").length>0&&(t=!1)}t&&this.controlRender()};this.Close=function(){this.my_dropDownOptions!=null&&$(this.my_dropDownOptions.m_triggerButton).parent().hasClass("open")&&(this.closingProgramatically=!0,$(this.my_dropDownOptions.m_triggerButton).click(),delete this.closingProgramatically)};this.Open=function(){this.my_dropDownOptions==null||$(this.my_dropDownOptions.m_triggerButton).parent().hasClass("open")||$(this.my_dropDownOptions.m_triggerButton).click()};this.Update=function(n,t){if(this.IsGridItem||(this.Caption=n,this.Icon=t),this.updating=!0,this.my_dropDownOptions!=undefined)if(this.IsGridItem){var i=this;window.setTimeout(function(){i.controlRender()},100)}else this.controlRender();else this.show()};this.AddedNewToGridItem=function(n){this.my_dropDownOptions=$("#"+this.my_dropDownOptions.containerName).parent().data("ddo");this.my_dropDownOptions.extendedCombo_UpdateGridItemValue(n);this.my_dropDownOptions.realSelectedText=null;this.DataListProc!=null&&this.DataListProc!=""&&this.HasDescription&&(this.setGridItemDynamicDescription(this.my_dropDownOptions),this.my_dropDownOptions.render())};this.show=function(){if(this.my_dropDownOptions==undefined){if(this.IsGridItem)this.my_dropDownOptions="";else if(this.my_dropDownOptions=new DVelopBootstrapDropDownOptions(this),this.my_dropDownOptions.render(),this.my_dropDownOptions.IsDate())$("#"+this.my_dropDownOptions.containerToDrawName).off("hide.bs.dropdown").on("hide.bs.dropdown",function(n){return function(){return n.OnDDOClosing()}}(this.my_dropDownOptions));if(!this.IsM&&!WWP_HasGridEmpowerer(this)){var n=!0;this.onaftereventxHandler==null?(this.onaftereventxHandler=function(){this.onaftereventx()}.closure(this),gx.fx.obs.addObserver("gx.onafterevent",window,this.onaftereventxHandler)):n=!1;(this.DropDownOptionsType=="ExtendedComboBox"||this.DropDownOptionsType=="ExtendedSuggest")&&this.AllowMultipleSelection&&gx.fx.obs.addObserver("gx.onbeforefocus",window,function(n){return function(t){t!=null&&$(t).is("input[type=button]")&&n.my_dropDownOptions!=null&&$("#"+n.my_dropDownOptions.containerToDrawName).hasClass("open")&&$("#"+n.my_dropDownOptions.containerToDrawName).find("button").click()}}(this));gx.fx.obs.addObserver("gx.onload",window,function(n){return function(){var t,i,r;(n.DropDownOptionsType=="ExtendedComboBox"||n.DropDownOptionsType=="ExtendedSuggest")&&WWP_FixBooleanProperty(n.Enabled)&&(t=gx.pO.getUserFocus(),t!="notset"&&(t!=""&&t!=gx.fn.getHidden(gx.pO.CmpContext+"GX_FocusControl")&&t==gx.pO.MasterPage.getUserFocus()&&(t=""),i=n.ContainerName+(n.DropDownOptionsType=="ExtendedComboBox"?"_btnGroupDrop":"_inputSuggest"),r=$("#"+i+":visible"+(t!=null&&t!=""?", #"+t:"")),r.first().attr("id")==i&&(gx.http.viewState[gx.pO.CmpContext+"GX_FocusControl"]=i)));n.onaftereventx()}}(this));this.IsGridItem&&n&&gx.fx.obs.addObserver("grid.onafterrender",window,this.onaftereventxHandler);gx.fx.obs.addObserver("popup.afterclose",this,this.onPopupClose)}}}}function DDOGridTitleSettingsM(){this.SetDropDownOptionsData=function(n){this.InitializeColTitleOptions();for(var t=0;t<this.ColumnIndexesObj.length;t+=1)this.my_dropDownOptions[t].SetDropDownOptionsData(n==null?null:[])};this.SetDropDownOptionsTitleSettingsIcons=function(n){n!=undefined&&n.Default!=""&&(this.DropDownOptionsTitleSettingsIcons=n);this.InitializeColTitleOptions();for(var t=0;t<this.ColumnIndexesObj.length;t+=1)this.my_dropDownOptions[t].SetDropDownOptionsTitleSettingsIcons(n);this.SetDropDownOptionsData(n)};this.GetDropDownOptionsTitleSettingsIcons=function(){return this.DropDownOptionsTitleSettingsIcons};this.onaftereventx=function(){if(this.ColumnIndexesObj!=null){this.LoadColTitleDynProperties();for(var n=0;n<this.ColumnIndexesObj.length;n+=1)this.my_dropDownOptions[n].onaftereventx();typeof SetMinWidthTotalizers=="function"&&SetMinWidthTotalizers()}};this.show=function(){if(WWP_HasGridEmpowerer(this))WWP_NotifyEmpower(this,"WWP.TitleSettings");else if(this.updateGrid(),!this.eventsAttached){this.eventsAttached=!0;var n=this;gx.fx.obs.addObserver("gx.onafterevent",window,function(n){return function(){n.onaftereventx()}}(this));gx.fx.obs.addObserver("gx.onload",window,function(n){return function(){n.onaftereventx()}}(this))}};this.updateGrid=function(){this.InitializeColTitleOptions();for(var n=0;n<this.ColumnIndexesObj.length;n+=1)WWP_HasGridEmpowerer(this)?(this.my_dropDownOptions[n].my_dropDownOptions==null&&(this.my_dropDownOptions[n].my_dropDownOptions=new DVelopBootstrapDropDownOptions(this.my_dropDownOptions[n])),this.my_dropDownOptions[n].my_dropDownOptions.render()):this.my_dropDownOptions[n].show()};this.IncludeDivInGridTitles=function(){var u,t,n,f,i,r;if(this.GridObjId==null&&(this.GridInternalName=="GRID"&&(this.GridObjId="GridContainerDiv",$("#"+this.GridObjId).length==0&&(this.GridObjId=null)),this.GridObjId==null&&(u=this,$(".gx-grid").each(function(){if(this.id!=null&&this.id.toUpperCase()==u.GridInternalName+"CONTAINERDIV")return u.GridObjId=this.id,!1}))),this.GridObjId!=null&&$("#"+this.GridObjId).length==1&&(t=$("#"+this.GridObjId).find(">table>thead>tr").last()[0],t!=null&&$(t).find(".ColumnSettingsContainer").length==0))for(n=0;n<this.ColumnIndexesObj.length;n+=1)f=0,this.ColumnIndexesObj[n].IsInLineEditableWithTags&&!$(t.children[this.ColumnIndexesObj[n].i]).is(":visible")&&$(t.children[this.ColumnIndexesObj[n].i+1]).is(":visible")&&(f=1),i=$(t.children[this.ColumnIndexesObj[n].i+f]),r=i.find("span")[0],r==null&&i.length==1&&i[0].innerHTML=="&nbsp;"&&(i[0].innerHTML="<span><\/span>",r=i.find("span")[0]),r!=null&&(r.innerHTML="<div class='ColumnSettingsContainer'>"+r.outerHTML+"<div id='"+this.my_dropDownOptions[n].TitleControlIdToReplace+"'><\/div>")};this.ColumnIsFreezable=function(n){for(var t=0;t<this.ColumnIndexesObj.length;t+=1)if($("#"+this.my_dropDownOptions[t].my_dropDownOptions.containerToDrawName).closest("th")[0]==n)return this.my_dropDownOptions[t].DataHasEventKey("<#FixLeft#>");return!1};this.InitializeColTitleOptions=function(){var n,t;if(this.ColumnIndexesObj==null){for(this.IsFS=this.ColumnIds[0]==":",this.ColumnIndexesObj=JSON.parse('[{"i":'+(this.IsFS?"-1":"")+WWP_replaceAll(WWP_replaceAll(this.ColumnIds,":",',"n":"'),"|",'"},{"i":'+(this.IsFS?"-1":""))+'"}]'),this.ColumnsSortValues!=null&&this.ColumnsSortValues!=""&&(this.ColumnsSortValuesObj=JSON.parse('["'+WWP_replaceAll(this.ColumnsSortValues,"|",'","')+'"]')),this.my_dropDownOptions=[],n=0;n<this.ColumnIndexesObj.length;n+=1)this.ColumnIndexesObj[n].n.length>2&&this.ColumnIndexesObj[n].n.substring(this.ColumnIndexesObj[n].n.length-2)=="-E"&&(this.ColumnIndexesObj[n].n=this.ColumnIndexesObj[n].n.substring(0,this.ColumnIndexesObj[n].n.length-2),this.ColumnIndexesObj[n].IsInLineEditableWithTags=!0),t=new BootstrapDropDownOptions,t.IsM=!0,t.MName=this.ColumnIndexesObj[n].n,t.TitleControlIdToReplace=this.IsFS?WWP_replaceAll(this.ContainerName,"Container","").toUpperCase()+"_"+t.MName.toUpperCase():this.GridInternalName+"_TF_"+(n+1),t.ContainerName=this.ContainerName+"_TF_"+(n+1),t.ControlName=this.ControlName+"_TF_"+(n+1),t.OnOptionClicked=this.OnOptionClicked,t.MControl=this,t.DropDownOptionsType="GridTitleSettings",this.my_dropDownOptions.push(t);this.LoadColTitleBaseProperties()}this.LoadColTitleDynProperties()};this.LoadColTitleBaseProperties=function(){var t,n;for(this.SetPropValueToDDOs("Icon",!1,!0,""),this.SetPropValueToDDOs("Caption",!1,!0,""),this.SetPropValueToDDOs("Tooltip",!1,!0,"WWP_TSColumnOptions"),this.SetPropValueToDDOs("Cls",!1,!0,"ColumnSettings"),this.SetPropValueToDDOs("TitleControlAlign",!0,!0,"Automatic"),this.SetPropValueToDDOs("IncludeSortASC",!0,!0,!1),(this.IncludeSortDSC==null||this.IncludeSortDSC=="")&&(this.IncludeSortDSC=this.IncludeSortASC),this.SetPropValueToDDOs("IncludeSortDSC",!0,!0,!1),this.SetPropValueToDDOs("AllowGroup",!0,!0,!1),this.SetPropValueToDDOs("IncludeFilter",!0,!0,!1),this.SetPropValueToDDOs("FilterType",!1,!0,"Character"),this.SetPropValueToDDOs("Format",!1,!0,""),this.SetPropValueToDDOs("FilterIsRange",!1,!0,""),n=0;n<this.ColumnIndexesObj.length;n+=1)this.my_dropDownOptions[n].FilterIsRangePicker=this.my_dropDownOptions[n].FilterIsRange=="P",this.my_dropDownOptions[n].FilterIsRange=this.my_dropDownOptions[n].FilterIsRangePicker||this.my_dropDownOptions[n].FilterIsRange=="T";if(this.SetPropValueToDDOs("IncludeDataList",!0,!0,!1),this.SetPropValueToDDOs("DataListType",!1,!0,"Dynamic"),this.SetPropValueToDDOs("DataListProc",!1,!0,""),this.SetPropValueToDDOs("RemoteServicesParameters",!1,!0,""),this.SetPropValueToDDOs("DataListUpdateMinimumCharacters",!1,!0,0),this.SetPropValueToDDOs("AllowMultipleSelection",!0,!0,!1),this.SetPropValueToDDOs("Fixable",!0,!0,!1),this.SetPropValueToDDOsWithoutDecode("GAMOAuthToken"),this.SetPropValueToDDOs("AllowGroupText",!1,!0,"WWP_GroupByOption"),this.SetPropValueToDDOs("SortASC",!1,!0,"WWP_TSSortASC"),this.SetPropValueToDDOs("SortDSC",!1,!0,"WWP_TSSortDSC"),this.SetPropValueToDDOs("LoadingData",!1,!0,"WWP_TSLoading"),this.SetPropValueToDDOs("CleanFilter",!1,!0,"WWP_TSCleanFilter"),this.SetPropValueToDDOs("RangeFilterFrom",!1,!0,"WWP_TSFrom"),this.SetPropValueToDDOs("RangeFilterTo",!1,!0,"WWP_TSTo"),this.SetPropValueToDDOs("NoResultsFound",!1,!0,"WWP_TSNoResults"),this.SearchButtonText==""&&this.ColumnIndexesObj.length>0){for(t="",n=0;n<this.ColumnIndexesObj.length;n+=1)t+="|"+(this.my_dropDownOptions[n].AllowMultipleSelection?wwp.labels.SearchMultipleValuesButtonText:wwp.labels.SearchButtonText);this.SearchButtonText=t.substring(1)}this.SetPropValueToDDOs("SearchButtonText",!1,!0,"WWP_TSSearchButtonCaption")};this.LoadColTitleDynProperties=function(){var t,i,n;if(this.IncludeDivInGridTitles(),this.SetPropValueToDDOs("Visible",!0,!0,!0),this.SetPropValueToDDOs("DataListFixedValues",!1,!0,""),this.SetPropValueToDDOs("FixedFilters",!1,!0,""),this.SetPropValueToDDOs("SelectedFixedFilter",!1,!0,""),this.SetPropValueToDDOs("FilteredText_set",!1,!0,""),this.SetPropValueToDDOs("FilteredTextTo_set",!1,!0,""),this.SetPropValueToDDOs("SelectedValue_set",!1,!0,""),this.SetPropValueToDDOs("SelectedText_set",!1,!0,""),this.SortedStatus!=null&&this.SortedStatus!=""&&this.ColumnsSortValuesObj!=null)for(t=this.SortedStatus.substring(0,this.SortedStatus.indexOf(":")),i=this.SortedStatus.substring(this.SortedStatus.indexOf(":")+1),n=0;n<this.ColumnIndexesObj.length;n+=1)this.my_dropDownOptions[n].SortedStatus=this.ColumnsSortValuesObj[n]==t?i:"",this.my_dropDownOptions[n].MSortValue=this.ColumnsSortValuesObj[n];else this.SetPropValueToDDOs("SortedStatus",!1,!0,"")};this.UpdateColPropValueFromDDOs=function(n){this[n]="";for(var t=0;t<this.my_dropDownOptions.length;t+=1)t>0&&(this[n]+="|"),this[n]+=WWP_replaceAll(WWP_replaceAll(WWP_replaceAll(this.my_dropDownOptions[t][n],"\\","\\\\"),"|","\\|"),"\n","");this[n]+=""};this.SetPropValueToDDOsWithoutDecode=function(n){for(var i=this[n],t=0;t<this.ColumnIndexesObj.length;t+=1)this.my_dropDownOptions[t][n]=i};this.SetPropValueToDDOs=function(n,t,i,r){var f=this[n],o=null,e=null,u;for(i&&f!=null&&WWP_replaceAll(WWP_replaceAll(f,"\\\\",""),"\\|","").indexOf("|")>=0?o=this.decodePropValueCollection(f):f==null||f==""?e=wwp.labels[n]!=null?wwp.labels[n]:r:(e=this.decodePropValue(f),t&&(e=e=="T")),u=0;u<this.ColumnIndexesObj.length;u+=1)o!=null?(this.my_dropDownOptions[u][n]=o[u],t&&(this.my_dropDownOptions[u][n]=this.my_dropDownOptions[u][n]=="T")):this.my_dropDownOptions[u][n]=e};this.decodePropValue=function(n){return n=WWP_replaceAll(n,"\\\\","[\\\\]"),n=WWP_replaceAll(n,"\\|","|"),WWP_replaceAll(n,"[\\\\]","\\")};this.decodePropValueCollection=function(n){var t,i;if(n=WWP_replaceAll(n,"\\\\","[\\\\]"),n=WWP_replaceAll(n,"\\|","[\\\\P]"),n=WWP_replaceAll(n,'"','\\"'),n=WWP_replaceAll(n,"|",'","'),n=WWP_replaceAll(n,"[\\\\P]","|"),n=WWP_replaceAll(n,"[\\\\]","\\\\"),n.indexOf("\t")>=0){for(n=WWP_replaceAll(n,"\t","[#tab#]"),t=JSON.parse('["'+n+'"]'),i=0;i<t.length;i++)t[i]=WWP_replaceAll(t[i],"[#tab#]","\t");return t}return JSON.parse('["'+n+'"]')}};$(window).one('load',function(){WWP_VV([['GXBootstrap.DDOGridTitleSettings','15.0.1'],['GXBootstrap.DDOGridColumnsSelector','15.1.0'],['GXBootstrap.DDOGridTitleSettingsM','15.1.0'],['GXBootstrap.DDOExtendedCombo','15.1.0'],['GXBootstrap.DropDownOptions','14.4'],['GXBootstrap.DDComponent','15.1.0'],['Bootstrap.DropDownOptions','14.0'],['GXBootstrap.DDORegular','15.1.0']]);});