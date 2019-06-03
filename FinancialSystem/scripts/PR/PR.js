
function AddPrLines(id) {
	source = {
		"Id": id,
		"Quantity": $("#qty" + id).val()
	};

	$.ajax({

		type: "POST",
		url: $("#ApiServer").val() + "/api/AddPRLines",
		data: JSON.stringify(source),
		//data: "1",
		contentType: 'application/json; charset=utf-8',

		//dataType: 'json',

		success: function (data) {
			var cartCount=Number($("#cartCount").html()) +1;
			$("#cartCount").html(cartCount);
		},

		error: function (error) {
			alert(error);
			jsonValue = jQuery.parseJSON(error.responseText);

		}

	});
}
function modal(id) {
	
		var elems = document.querySelectorAll('.modal');
		var instances = M.Modal.init(elems);
	
}
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
		url: $("#ApiServer").val() + "/PR/ItemSearch",
		data: JSON.stringify(source),
		//data: "1",
		contentType: 'application/json; charset=utf-8',

		//dataType: 'json',

		success: function (data) {
			$("#ItemContainer").empty();
			$("#ItemContainer").html(data);
			},

			error: function (error) {
				alert(error);
				jsonValue = jQuery.parseJSON(error.responseText);

			}

	});
}