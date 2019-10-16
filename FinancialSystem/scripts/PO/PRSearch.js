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
		url: "../PO/PRList",
		data: JSON.stringify(source),
		//data: "1",
		contentType: 'application/json; charset=utf-8',

		//dataType: 'json',

		success: function (data) {
			$("#PRContainer").empty();
			$("#PRContainer").html(data);
			var elems = document.querySelectorAll('.sidenav');
			var instances = M.Sidenav.init(elems);
			var elems = document.querySelectorAll('.modal');
			var instances = M.Modal.init(elems);
			var elems = document.querySelectorAll('.collapsible');
			var instances = M.Collapsible.init(elems);
			var elems = document.querySelectorAll('.dropdown-trigger');
			var instances = M.Dropdown.init(elems);
		},

		error: function (error) {
			alert(error);
			jsonValue = jQuery.parseJSON(error.responseText);

		}

	});
}

function CreatePO(me) {
	
	var lines = [];
	$.each($("input[name='itemCheck-" + me.id + "']"), function () {
		
		if ($(this).is(':checked')) {
			var element = {
				"Id": Number($(this).attr('id')),

			};
			lines.push(element);
		}

	});

	$.ajax({

		type: "POST",
		url: "../PO/POCreation",
		//url: '@Url.Action("PR","CreatePR")',
		data: JSON.stringify(lines),
		//data: "1",
		contentType: 'application/json; charset=utf-8',

		//dataType: 'json',

		success: function (data) {
			//$(body).html(data);
			var elems = document.querySelectorAll('.datepicker');
			var instances = M.Datepicker.init(elems);
			$('#searcContainer').empty();
			$('#searcContainer').html(data);
			var elems = document.querySelectorAll('.sidenav');
			var instances = M.Sidenav.init(elems);
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