﻿function BootstrapPanel(){this.Collapsible;this.Collapsed;this.ShowCollapseIcon;this.IconPosition;this.ShowHeader;this.Title;this.AutoScroll;this.Width;this.Height;this.AutoWidth;this.AutoHeight;this.Cls;this.show=function(){this.my_panel==undefined?(this.my_panel=new DVelopBootstrapPanel(this),this.my_panel.render()):this.my_panel.refresh()};this.Collapse=function(){this.Collapsed=!0;var n=this.my_panel.containerName;$("#PanelBody_"+n).collapse("hide")};this.Expand=function(){this.Collapsed=!1;var n=this.my_panel.containerName;$("#PanelBody_"+n).collapse("show")}};$(window).one('load',function(){WWP_VV([['GXBootstrap.Panel_AL','14.3001'],['GXBootstrap.Panel','14.0'],['Bootstrap.Panel','1.2']]);});