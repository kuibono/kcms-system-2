// 展开收缩
$(document).ready(function(e) {
	 //初始化收缩显示
	$('.lenText').each(function(){
		$(this).attr("max-height",$(this).outerHeight());		
		if($(this).outerHeight()>70){
		  $(this).css({
			  "overflow":"hidden",
			  "height":"70px"
		  })
		}else{
		  $(this).next('p').find('.viewMore').hide();
		}
	})
	$('.viewMore').click(function(){
		  if($(this).text()=='+ 展开内容'){
		  $(this).parents('li').find('.lenText').animate({height: $(this).parents('li').find('.lenText').attr("max-height")});
		  $(this).text('- 收缩内容');
		  }else{
		  $(this).parents('li').find('.lenText').animate({height: '64px'});
		  $(this).text('+ 展开内容');
		  } 
	})				
		
 });
 /**
* 取消关注
*/
function cancelAttention(companyname,site){
    $.ajax({
        type: "post",
        url:  _hreUrl+"/Fcompany/companyRemove",
        data: 'remark='+companyname,
        dataType : 'json',
        success: function(msg){
            if(msg.status == '1') {
				$("#favcom"+site).slideUp("slow");
            }else {
            	alertOut(msg.message,'',true);                
            }
        }
    });				
}
// 切换myjob选项卡
function changeMyjob(type){
 	 $(".tab-blue > li").each(function () {
        $(this).removeClass("here");
     });	
	if(type == 1){
		$('.radius-tl4').parent().addClass("here");
		url = _hreUrl+'/position/myjob';
		context = '';
		$(".jobs-list-ul").load(_hreUrl+'/mybaijob/home/rmdpositionajax/resumeid/');		
	}else if(type == 2){
		$('.radius-tc4').parent().addClass("here");
		url = _hreUrl+'/mybaijob/collect/company';
		context = '查看所有关注企业';
		$(".jobs-list-ul").load(_hreUrl+'/mybaijob/home/fcompanyajax');
	}else if(type == 3){
		$('.radius-tr4').parent().addClass("here");
		url = _hreUrl+'/mybaijob/collect/position';
		$(".jobs-list-ul").load(_hreUrl+'/mybaijob/home/cpositionAjax');
		context = '查看所有收藏职位';
	}
	$('#jobslistid').attr('href',url);
	$('#jobslistid').text(context);
}    

var __myjob__ ={
	rerush:function(){
		$('#rerush').click(function(){
			$.ajax({
				async:false,
			    type: "post",
			    url:  _hreUrl+"/mybaijob/home/updatetime/",
			    data: '',
			    dataType : 'json',
			    success: function(msg){
			    	if(msg.s == 1){
			    		alertOut('简历刷新至 '+msg.message,'简历更新',true); 
			    		$('#resumetime').text('更新于：'+msg.message);   	
			    	}else{
			    		alertOut(msg.message,'简历更新',true); 
			    	}
			    }	    	     	    
			});				
			
			
		});
	},
	rename:function(){
		$('#rename').click(function(){
		var resumename = $('#renamehtml').text();
		alert('<dl class="clearfix"><dt class="alert-resume-name fl pl-20">简历名称</dt><dd class="fl pl-20 pb-20"><input type="text" id="alertResumeName"  value="'+resumename+'" class="mb-20 inp-154 bor-d7d7d7 radius-4"></br><input type="button" value="确定" class="btn-gray fl" id="renamebtn"></dd></dl>','简历重命名')
		});
	},
	updaterename:function(){
		$('#renamebtn').live('click',function(){
			var resumename = $('#alertResumeName').val();
			resumename = $.trim(resumename);
			if(resumename == '' || resumename == '请输入简历名称'){
				err_tip('#alertResumeName',100,'简历名称不能为空');
				return;
			}
			if(resumename.length>20){
				err_tip('#alertResumeName',100,'简历名称不能超过20个字符');
				return;
			}
			$.ajax({
				async:false,
			    type: "post",
			    url:  _hreUrl+"/mybaijob/home/updateresumename/",
			    data: 'resumeName='+resumename,
			    dataType : 'json',
			    success: function(msg){
			    	if(msg.s == 1){			    		 
			    		$('#renamehtml').text(msg.message);   	
			    	}else{
			    		alertOut(msg.message,'简历更新',true); 
			    	}
			    }	    	     	   
			});							
			$('.alertKill').click(); 
		});
	},	
	uploadPic:function(){
		$('#upLink').click(function(){
			alert('<form id="createTokenLanding" method="post" enctype="multipart/form-data"><input type="file" id="img"  name="file" /><input type="hidden" name="is_resume" value="1" /><input style="width:35px; height:23px;" id="img_upload" type="button" value="上传" /></form>','上传照片')
		})
	}
	//$('.alertKill').click(); 关闭方法
	//err_tip('#alertResumeName',100,'简历名称不能超过20个字')
}

__myjob__.rename();
__myjob__.rerush();
__myjob__.updaterename();
__myjob__.uploadPic();