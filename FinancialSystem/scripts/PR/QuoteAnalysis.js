function InputDetail(Id) {
	var str="<tr>";
		str+="<td>";
		str+="<label>";
		str+="<input name='group1' type='radio' />";
		str+="<span></span>";
		str+="</label>";
		str+="</td>";
		str+="<td style='display:none;'>" + $("#supplierInput-hidden_" + Id).val() + "</td>"	;
		str+="<td>" + $("#supplierInput_" + Id).val() + "</td>";
		str += "<td>" + $("#desc_" + Id).val() + "</td>";
		str += "<td>" + $("#price_" + Id).val() + "</td>";
		str += "<td>" + $("#uomInput-hidden_" + Id).val() + "</td>";
		str += "<td>" + $("#quantity_" + Id).val() + "</td>";
		str += "<td>" + $("#discount_" + Id).val() + "</td>";
		str += "<td>" + $("#TotalAnount_" + Id).val() + "</td>";
		str += "<td>" + $("#availabilityInput-hidden_" + Id).val() + "</td>";
		str += "<td>" + $("#termsInput-hidden_" + Id).val() + "</td>";
		str += "<td style='display:none;'>" + $("#brands_" + Id + " option:selected").val() + "</td>";
		str += "<td >" + $("#brands_" + Id + " option:selected").html() + "</td>";
		str += "<td style='display:none;'></td>";
		str+="<td>";
		str += "<a class='waves-effect waves-light btn red' onclick='DeleteRow(this)'>Delete</a>";
		str+="</td>";
		str += "</tr>";
		$("#table_" + Id + " tbody").append(str);
	M.toast({ html: 'Item has been added', classes: 'rounded' });

}
function SaveQA(Id) {
	
	var lines = [];
	$('#table_' + Id + ' tbody tr').each(function () {

		lines.push({
			"Selected": $("input[type=radio]", this).prop("checked"),
			"SupplierId": $(this).find("td").eq(1).html(),
			"TempSupplier": $(this).find("td").eq(1).html(),
			"Price": $(this).find("td").eq(4).html(),
			"Description": $(this).find("td").eq(3).html(),
			"Quantity": $(this).find("td").eq(6).html(),
			"UOM": $(this).find("td").eq(5).html(),
			"Discount": $(this).find("td").eq(7).html(),
			"TotalAnount": $(this).find("td").eq(8).html(),
			"Availability": $(this).find("td").eq(9).html(),
			"Terms": $(this).find("td").eq(10).html(),
			"BrandId": $(this).find("td").eq(11).html(),
			"Id": $(this).find("td").eq(12).html()
		});
	});
	var Head = {

		"Name": $("#ItemName_" + Id).val(),
		"SubCategoryId": $("#SubCategory_" + Id + " option:selected").val(),
		"Analysis": $("textarea#analysis_" + Id).val(),
		"RequestorId": $("#employeesInput-hidden_" + Id).val(),
		"SecurityStamp": $("#SecurityStamp").val(),
		"Id": Id,
		"Lines": lines
	};

	$.ajax({

		type: "POST",
		url: "/api/AddNonCatalog",
		data: JSON.stringify(Head),
		//data: "1",
		contentType: 'application/json; charset=utf-8',

		//dataType: 'json',

		success: function (data) {
			if ($("#QaNumber_" + Id).text() != data) {
				$("#QaNumber_" + Id).text(data);
				M.toast({ html: 'Q.A Number ' + data + ' has been created', classes: 'rounded' });
				//$("#submit-button").contents().unwrap();
				$("#submit-button").hide();
			} else {
				M.toast({ html: 'Q.A Number ' + data + ' has been Updated', classes: 'rounded' });
			}
		},

		error: function (error) {
			alert(error);
			jsonValue = jQuery.parseJSON(error.responseText);

		}

	});
	
}
function DeleteRow(tr) {
	tr.closest("tr").remove();
}

function supplier(Id) {
	options = document.querySelectorAll("#supplier_" + Id + " option");
	$("#supplierInput-hidden_" + Id).val("");
	var found = false;
	for (var i=0; i < options.length; i++) {
		var option = options[i];
		
		if (option.innerText === $("#supplierInput_" + Id).val()) {
			found = true;
			$("#supplierInput-hidden_" + Id).val(option.getAttribute("data-value"));
			break;
		}
	}
	if (!found) {
		M.toast({ html: 'Supplier ' + $("#supplierInput_" + Id).val() + 'is not Registered', classes: 'rounded' });
		$("#supplierInput_" + Id).val("");
	}
	//alert($("#supplierInput-hidden").val());
}
function uom(Id) {
	options = document.querySelectorAll("#uom_" + Id + " option");
	$("#uomInput-hidden_" + Id).val("");
	var found = false;
	for (var i = 0; i < options.length; i++) {
		var option = options[i];

		if (option.innerText === $("#uomInput_" + Id).val()) {
			found = true;
			$("#uomInput-hidden_" + Id).val(option.getAttribute("data-value"));
			break;
		}
	}
	if (!found) {
		M.toast({ html: 'Unit of Measurement ' + $("#uomInput_" + Id).val() + 'is not Registered', classes: 'rounded' });
		$("#uomInput_" + Id).val("");
	}
	
}
function availability(Id) {
	options = document.querySelectorAll("#availability_" + Id + " option");
	$("#availabilityInput-hidden_" + Id).val("");
	var found = false;
	for (var i = 0; i < options.length; i++) {
		var option = options[i];

		if (option.innerText === $("#availabilityInput_" + Id).val()) {
			found = true;
			$("#availabilityInput-hidden_" + Id).val(option.getAttribute("data-value"));
			break;
		}
	}
	if (!found) {
		M.toast({ html: 'Availability ' + $("#uomInput_" + Id).val() + 'is not Registered', classes: 'rounded' });
		$("#availabilityInput_" + Id).val("");
	}

}
function Employees(Id) {
	options = document.querySelectorAll("#employees_" + Id + " option");
	$("#employeesInput-hidden_" + Id).val("");
	var found = false;
	for (var i = 0; i < options.length; i++) {
		var option = options[i];

		if (option.innerText === $("#employeesInput_" + Id).val()) {
			found = true;
			$("#employeesInput-hidden_" + Id).val(option.getAttribute("data-value"));
			break;
		}
	}
	if (!found) {
		M.toast({ html: $("#employeesInput").val() + ' is not an Employee', classes: 'rounded' });
		$("#employeesInput").val("");
	}
}
function dataList(Id,elem) {
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
	if (!found) {
		M.toast({ html: $(elem + "Input_" + Id).val() + ' is not a correct input', classes: 'rounded' });
		$(elem + "Input_" + Id).val("");
	}
	alert($(elem + "Input_" + Id).val());
}
function Category(Id) {
	var selectedVal = $("#CategorySelect_" + Id +" option:selected").val();
	

	$.ajax({

		type: "Get",
		url: "/api/GetSubCategory/" + selectedVal,
		contentType: 'application/json; charset=utf-8',
		success: function (data) {
			$newoptions = "<option selected='selected'>Select SubCategories</option>";
			for (var i = 0; i < data.length; i++) {
				$newoptions += "<option value='" + data[i].Id + "'>" + data[i].Name + "</option>";
			}
			$('select#SubCategory_' +Id).html($newoptions);

		},

		error: function (error) {
			alert(error);
			jsonValue = jQuery.parseJSON(error.responseText);

		}

	});
}
function search(event) {
	
	if (event.keyCode == 13) {
		searchQA();
		
	}
}
function searchQA() {
	var search = $("#search").val();
	
	if (!search.trim()) {
		window.location = "UpdateViewQA";
	} else {
		window.location = "UpdateViewQA?search=" + search;
	}
}
