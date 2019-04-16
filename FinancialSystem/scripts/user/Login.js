
function saveUser() {
    alert("signin");
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
            alert(data.UserName);


        },

        error: function (error) {
            alert(error);
            jsonValue = jQuery.parseJSON(error.responseText);

        }

    });

}