
function search(event) {
	if (event.keyCode == 13) {
		searchItem();
	}
}
function searchItem() {
	//source = {
	//	"UserName": $("#UserName").val(),
	//	"Password": $("#Password").val(),
	//	"RememberMe": $("#RememberMe").is(":checked")
	//};
	alert($("#search").val());
	$.ajax({

		type: "POST",
		url: $("#ApiServer").val() + "/api/SearchItem",
		data: { "value:" + $("#search").val() },
		//data: "1",
		contentType: 'text',

		//dataType: 'json',

		success: function (data) {
			location.href = data;


		},

		error: function (error) {
			alert(error);
			jsonValue = jQuery.parseJSON(error.responseText);

		}

	});
}