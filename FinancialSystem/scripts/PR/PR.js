
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
			alert($("#cartCount").html());
			var cartCount = Number($("#cartCount").html()) + 1;
			alert(cartCount);
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
function CreatePR() {
	
	var lines = [];
	$.each($("input[name='itemCheck']"), function () {
		if ($(this).is(':checked')) {
			var element = {
				"Id": Number($(this).attr('id'))
			};
			lines.push(element);
		}

	});

	$.ajax({

		type: "POST",
		url: $("#ApiServer").val() + "/PR/CreatePR",
		//url: '@Url.Action("PR","CreatePR")',
		data: JSON.stringify(lines),
		//data: "1",
		contentType: 'application/json; charset=utf-8',

		//dataType: 'json',

		success: function (data) {
			//$(body).html(data);
			$('#bod').empty();
			$('#bod').html(data);
		},
		//async: false,

		error: function (error) {
			alert(error);
			jsonValue = jQuery.parseJSON(error.responseText);

		}

	});

}

function DeleteLines() {
	
	var lines = [];
	$.each($("input[name='itemCheck']"), function () {		
		if ($(this).is(':checked')) {
			var element = {
				"Id": Number($(this).attr('id'))
			};
			lines.push(element);
		}

	});
	$.ajax({

		type: "POST",
		url: $("#ApiServer").val() + "/api/DeletePRLines",
		data: JSON.stringify(lines),
		//data: "1",
		contentType: 'application/json; charset=utf-8',

		//dataType: 'json',

		success: function (data) {
			location.reload();
			
		},

		error: function (error) {
			alert(error);
			jsonValue = jQuery.parseJSON(error.responseText);

		}

	});

}