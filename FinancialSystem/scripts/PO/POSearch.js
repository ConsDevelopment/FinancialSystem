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
		url: "../PO/POList",
		data: JSON.stringify(source),
		//data: "1",
		contentType: 'application/json; charset=utf-8',

		//dataType: 'json',

		success: function (data) {
			$("#POContainer").empty();
			$("#POContainer").html(data);
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

function UpdatePO(me) {

	source = {
		"Id": me
	};

	$.ajax({

		type: "POST",
		url: "../PO/UpdatePO",
		//url: '@Url.Action("PR","CreatePR")',
		data: JSON.stringify(source),
		//data: "1",
		contentType: 'application/json; charset=utf-8',

		//dataType: 'json',

		success: function (data) {
			//$(body).html(data);

			$('#searcContainer').empty();
			$('#searcContainer').html(data);
			var elems = document.querySelectorAll('.sidenav');
			var instances = M.Sidenav.init(elems);
			var elems = document.querySelectorAll('.modal');
			var instances = M.Modal.init(elems);
			var elems = document.querySelectorAll('.datepicker');
			var instances = M.Datepicker.init(elems);

		},
		//async: false,

		error: function (error) {
			alert(error);
			jsonValue = jQuery.parseJSON(error.responseText);

		}

	});
}

