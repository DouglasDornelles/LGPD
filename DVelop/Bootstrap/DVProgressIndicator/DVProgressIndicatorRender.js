﻿function DVProgressIndicator(){this.Type;this.CircleCaptionType;this.Caption;this.Subtitle;this.RawHTML;this.Cls;this.Percentage;this.BarWidth;this.CircleWidth;this.CircleProgressWidth;this.AnimateOnStart;this.show=function(){if(this.my_progressIndicator==undefined){var n=this.ContainerName+"_DVProgressIndicator";this.setHtml('<div id="'+n+'" class="'+this.Cls+'" ><\/div>');this.my_progressIndicator=new DVProgressIndicator2(this);this.my_progressIndicator.render()}else this.my_progressIndicator.updateValue()}}function DVProgressIndicator2(n){this.control=n;this.render=function(){var r=this.control.ContainerName+"_DVProgressIndicator",i=$("#"+r),t,n;i.html("");this.control.Type=="Bar"?(i.html('<div class="progress" '+(this.control.BarWidth!=""?'style="width: '+this.control.BarWidth+';"':"")+'><div id="'+this.control.ContainerName+'_DVPIBar" class="progress-bar" style="width: 0%;">'+this.control.Caption+"<\/div><\/div>"),this.control.AnimateOnStart&&setTimeout(this.bar_setWidth.bind(this),1)):((this.control.CircleCaptionType==null||this.control.CircleCaptionType=="")&&(this.control.CircleCaptionType="Caption"),i.css("position","relative"),t=(this.control.CircleWidth-this.control.CircleProgressWidth)/2,n=this.control.CircleProgressWidth/2+t,this.lineLength=2*t*Math.PI,this.control.CircleCaptionType=="Caption"?i.html('<svg class="ProgressIndicatorCircle" height="'+this.control.CircleWidth+'" width="'+this.control.CircleWidth+'"><circle id="'+this.control.ContainerName+'_DVPICircleB" class="BackCircle" cx="'+n+'" cy="'+n+'" r="'+t+'" style="stroke-width: '+this.control.CircleProgressWidth+'px;"><\/circle><circle id="'+this.control.ContainerName+'_DVPICircle"  cx="'+n+'" cy="'+n+'" r="'+t+'" style="stroke-dashoffset: '+this.lineLength+";stroke-dasharray: "+this.lineLength+";stroke-width: "+this.control.CircleProgressWidth+'px;" class="ProgressCircle"><\/circle><\/svg><div class="ProgressIndicatorCircle" style="position: absolute;top: 0;left: 0;width: '+this.control.CircleWidth+"px;height: "+this.control.CircleWidth+'px;"><div style="left: 50%;position: absolute;"><span class="CircleCaption" style="position: relative; left: -50%; line-height: '+this.control.CircleWidth+'px;">'+this.control.Caption+"<\/span><\/div><\/div>"):this.control.CircleCaptionType=="CaptionAndSubtitle"?i.html('<svg class="ProgressIndicatorCircle" height="'+this.control.CircleWidth+'" width="'+this.control.CircleWidth+'"><circle id="'+this.control.ContainerName+'_DVPICircleB" class="BackCircle" cx="'+n+'" cy="'+n+'" r="'+t+'" style="stroke-width: '+this.control.CircleProgressWidth+'px;"><\/circle><circle id="'+this.control.ContainerName+'_DVPICircle"  cx="'+n+'" cy="'+n+'" r="'+t+'" style="stroke-dashoffset: '+this.lineLength+";stroke-dasharray: "+this.lineLength+";stroke-width: "+this.control.CircleProgressWidth+'px;" class="ProgressCircle"><\/circle><\/svg><div class="ProgressIndicatorCircle" style="position: absolute;top: 0;left: 0;width: '+this.control.CircleWidth+"px;height: "+this.control.CircleWidth+'px;"><div style="left: 50%;position: absolute;" class="CircleCaptionContainer"><span class="CircleCaption" style="left: -50%;position: relative;">'+this.control.Caption+'<\/span><\/div><div style="left: 50%;position: absolute;" class="CircleSubtitleContainer"><span class="CircleSubtitle" style="left: -50%;position: relative;">'+this.control.Subtitle+"<\/span><\/div><\/div>"):i.html('<svg class="ProgressIndicatorCircle" height="'+this.control.CircleWidth+'" width="'+this.control.CircleWidth+'"><circle id="'+this.control.ContainerName+'_DVPICircleB" class="BackCircle" cx="'+n+'" cy="'+n+'" r="'+t+'" style="stroke-width: '+this.control.CircleProgressWidth+'px;"><\/circle><circle id="'+this.control.ContainerName+'_DVPICircle"  cx="'+n+'" cy="'+n+'" r="'+t+'" style="stroke-dashoffset: '+this.lineLength+";stroke-dasharray: "+this.lineLength+";stroke-width: "+this.control.CircleProgressWidth+'px;" class="ProgressCircle"><\/circle><\/svg><div class="ProgressIndicatorCircle" style="position: absolute;top: 0;left: 0;width: '+this.control.CircleWidth+"px;height: "+this.control.CircleWidth+'px;">'+this.control.RawHTML+"<\/div>"),this.control.AnimateOnStart&&setTimeout(this.circle_setStrokeDashoffset.bind(this),1))};this.updateValue=function(){var n=$("#"+this.control.ContainerName+"_DVProgressIndicator");$(n).removeClass();this.control.Cls!=""&&$(n).addClass(this.control.Cls);this.control.Type=="Bar"?($("#"+this.control.ContainerName+"_DVPIBar").get(0).innerHTML=this.control.Caption,this.control.BarWidth!=""&&($(n).get(0).childNodes[0].style.width=this.control.BarWidth),this.bar_setWidth()):($("#"+this.control.ContainerName+"_DVPICircleB").get(0).style.cssText="stroke-width: "+this.control.CircleProgressWidth+"px;",$("#"+this.control.ContainerName+"_DVPIText").get(0).textContent=this.control.Caption,this.circle_setStrokeDashoffset())};this.circle_setStrokeDashoffset=function(){var n=this.control.Percentage,t,i;n>100&&(n=100);/MSIE \d|Trident.*rv:/.test(navigator.userAgent)?(t=n>=25?(n-25)*this.lineLength/100+" "+(100-n)*this.lineLength/100+" "+this.lineLength/4:"0 "+75*this.lineLength/100+" "+n*this.lineLength/100+" "+(25-n)*this.lineLength/100,$("#"+this.control.ContainerName+"_DVPICircle").get(0).style.cssText="stroke-dasharray: "+t+";stroke-width: "+this.control.CircleProgressWidth+"px;"):(i=(100-n)*this.lineLength/100,$("#"+this.control.ContainerName+"_DVPICircle").get(0).style.cssText="stroke-dasharray: "+this.lineLength+";stroke-dashoffset: "+i+";stroke-width: "+this.control.CircleProgressWidth+"px;")};this.bar_setWidth=function(){var n=this.control.Percentage;n>100&&(n=100);$("#"+this.control.ContainerName+"_DVPIBar").get(0).style.width=n+"%"}};$(window).one('load',function(){WWP_VV([['Bootstrap.DVProgressIndicator','1.1'],['GXBootstrap.DVProgressIndicator','1.0']]);});