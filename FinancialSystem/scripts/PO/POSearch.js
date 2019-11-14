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
function setDeliveryAddress() {
	alert("test");
	$("#DeliveryAdress").text($("#deliveryaddress").val());
}
function dataList(Id, elem, DPEditable) {
	options = document.querySelectorAll(elem + "_" + Id + " option");
	$(elem + "Input-hidden_" + Id).val("");
	var found = false;
	for (var i = 0; i < options.length; i++) {
		var option = options[i];

		if (option.innerText === $(elem + "Input_" + Id).val()) {
			found = true;
			$(elem + "Input-hidden_" + Id).val(option.getAttribute("data-value"));
			break;
		}
	}
	if (!DPEditable) {
		if (!found) {
			M.toast({ html: $(elem + "Input_" + Id).val() + ' is not a correct input', classes: 'rounded' });
			$(elem + "Input_" + Id).val("");
		}
	}
	//alert($(elem + "Input-hidden_" + Id).val());
}
function SavePO(status) {

	var lines = [];
	$('#table_ tbody tr').each(function () {
		var id = $(this).find("td").eq(0).html();

		lines.push({
			"Id" : id,
			"Name": $(this).find("td").eq(1).html(),
			"Description": $(this).find("td").eq(2).find("textarea").val(),
			"UOM": $("#UOMInput-hidden_" + id).val(),
			"Quantity": Number($(this).find("td").eq(4).find("input").val()),
			"UnitPrice": Number($(this).find("td").eq(5).find("input").val()),
			"PRLineId": Number(id)
		});
	});
	var date = new Date($("#datepicker").val());

	date.setHours(23);
	date.setMinutes(59);
	alert($("input#PoId").val());
	var Head = {
		"Id": $("#PoId").val(),
		"SupplierId": $("#SupplierId").val(),
		"PaymentTerm": $("PaymentTermsInput-hidden_").val(),
		"RequestorId": $("#employeesInput-hidden_").val(),
		"DeliveryAdress": $("#deliveryaddress").val(),
		"RequiredDate": date,
		"SecurityStamp": $("#SecurityStamp").val(),
		"NoteToBuyer": $("#notoTobuyer").val(),
		"Status": status,
		"Amount": $("#grandTotal").text(),
		"Lines": lines
	};

	$.ajax({

		type: "POST",
		url: "/api/SavePO",
		data: JSON.stringify(Head),
		//data: "1",
		contentType: 'application/json; charset=utf-8',

		//dataType: 'json',

		success: function (data) {
			if ($("#po-num").text() != data) {
				$("#po-num").text(data);
				M.toast({ html: 'PO Number ' + data + ' has been created', classes: 'rounded' });
				//$("#submit-button").contents().unwrap();
				$("#submit-button").hide();
			} else {
				M.toast({ html: 'PO Number ' + data + ' has been Updated', classes: 'rounded' });
			}
		},

		error: function (error) {
			alert(error);
			jsonValue = jQuery.parseJSON(error.responseText);

		}

	});

}

