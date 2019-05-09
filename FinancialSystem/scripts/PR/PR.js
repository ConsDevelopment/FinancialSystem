
function search(event) {
	if (event.keyCode == 13) {
		searchItem();
	}
}
function searchItem() {
	source = {
		"searchItem": $("#search").val()
	};
	
	$.ajax({

		type: "POST",
		url: $("#ApiServer").val() + "/api/SearchItem",
		data: JSON.stringify(source),
		//data: "1",
		contentType: 'application/json; charset=utf-8',

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