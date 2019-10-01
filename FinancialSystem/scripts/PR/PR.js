
function AddPrLines(id) {
	source = {
		"Id": id,
		"Quantity": $("#qty" + id).val(),
		"SecurityStamp": $("#SecurityStamp").val(),
		"itemType": $("#itemType").val()
	};

	$.ajax({

		type: "POST",
		url: $("#ApiServer").val() + "/api/AddPRLines",
		data: JSON.stringify(source),
		//data: "1",
		contentType: 'application/json; charset=utf-8',

		//dataType: 'json',

		success: function (data) {
			
			var cartCount = Number($("#cartCount").html()) + 1;
			
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
		var controller;
		if ($("#itemType").val() == "Catalog") {
			controller = "ItemSearch";
		} else {
			controller = "NonCatalogSearch";
		}
		searchItem(controller);
	}
}
function searchItem(controller) {
	alert(controller);
	source = {
		"searchItem": $("#search").val()
	};
	
	$.ajax({

		type: "POST",
		url: $("#ApiServer").val() + "/PR/" + controller,
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
				"Id": Number($(this).attr('id')),
				
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
			var elems = document.querySelectorAll('.datepicker');
			var instances = M.Datepicker.init(elems);
			var elems = document.querySelectorAll('.modal');
			var instances = M.Modal.init(elems);
			
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
				"Id": Number($(this).attr('id')),
				"SecurityStamp": $("#SecurityStamp").val()
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
function DateFormatter(date) {
	var month_names = ["Jan", "Feb", "Mar",
                      "Apr", "May", "Jun",
                      "Jul", "Aug", "Sep",
                      "Oct", "Nov", "Dec"];

	var day = this.getDate();
	var month_index = this.getMonth();
	var year = this.getFullYear();

	return "" + day + "-" + month_names[month_index] + "-" + year;
}

$("#Requestor").on('input', function () {
	
	var val = this.value;
	if ($('#RequestorList option').filter(function () {
        return this.value.toUpperCase() === val.toUpperCase();
	}).length) {
		//send ajax request
		var value = $('#Requestor').val();
		
		$("#RequestorListId").val($('#RequestorList [value="' + value + '"]').data('value'));
		
	}
});
$("#setRequestor").on('click', function () {
	var val = $("#Requestor").val();
	if ($('#RequestorList option').filter(function () {
        return this.value.toUpperCase() === val.toUpperCase();
	}).length) {
		//send ajax request
		var value = $('#Requestor').val();

		$("#RequestorListId").val($('#RequestorList [value="' + value + '"]').data('value'));
		$("#RequestorId").val($('#RequestorList [value="' + value + '"]').data('value'));
		$("#RequestorName").text(val);
	}
});
$("#setDeliveryAddress").on('click', function () {
	
	$("#DeliveryAddress").text($("#delivery").val());
});
$("#submitPR").on('click', function () {
	
	//LocalToUTC($("#datepicker").val());
	var date = new Date($("#datepicker").val());
	
	date.setHours(23);
	date.setMinutes(59);
	var json = [];
	$('#linesTable').find('tbody tr').each(function () {
		var obj = {};
		$td = $(this).find('td');
		val = $td.eq(0).text();
		obj["id"] = val;
		json.push(obj);
	});
	source = {
		"RequestorId": $("#RequestorId").val(),
		"DeliveryAdress": $("#DeliveryAddress").text(),
		"DateNeeded": date,
		"SecurityStamp": $("#SecurityStamp").val(),
		"Lines": json
	};

	$.ajax({

		type: "POST",
		url: "/api/CreatePR",
		data: JSON.stringify(source),
		contentType: 'application/json; charset=utf-8',
		success: function (data) {
			alert('success');
		},

		error: function (error) {
			alert(error);
			jsonValue = jQuery.parseJSON(error.responseText);

		}

	});
});
//function DateListener() {
//	var elems = document.querySelectorAll('.datepicker');
//	var instances = M.Datepicker.init(elems);
//}
//function Modal2() {
//	var elems = document.querySelectorAll('.modal');
//	var instances = M.Modal.init(elems);
//}