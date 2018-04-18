$(document).ready(function(){
    $("#cat-make-order").click(function() {
        $("#myModalBox").modal('show');
    });
    $("#main-cb").click(function(){
        if($("#main-cb").attr("checked") != 'checked') { 
            $(':checkbox').attr('checked',true);
        }
        else{
            $(':checkbox').attr('checked',false);
        }
    });
});