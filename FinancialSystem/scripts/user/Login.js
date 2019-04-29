
function logIn() {
    source = {
        "UserName": $("#UserName").val(),
        "Password": $("#Password").val(),
        "RememberMe": $("#RememberMe").is(":checked")
    };
    alert($('#RememberMe').is(':checked'));
    $.ajax({

        type: "POST",
        url: $("#ApiServer").val() + "/api/LoginApi",
        data: JSON.stringify(source),
        //data: "1",
        contentType: 'application/json',

        //dataType: 'json',

        success: function (data) {
        	location.href=data;


        },

        error: function (error) {
            alert(error);
            jsonValue = jQuery.parseJSON(error.responseText);

        }

    });

}