function InputDetail() {
	var str="<tr>";
		str+="<td>";
		str+="<label>";
		str+="<input name='group1' type='radio' />";
		str+="<span></span>";
		str+="</label>";
		str+="</td>";
		str+="<td style='display:none;'>" + $("#supplierInput-hidden").val() + "</td>";
		str+="<td>" + $("#supplierInput").val() + "</td>";
		str += "<td>" + $("#desc").val() + "</td>";
		str += "<td>" + $("#price").val() + "</td>";
		str += "<td>" + $("#uom option:selected").val() + "</td>";
		str += "<td>" + $("#quantity").val() + "</td>";
		str += "<td>" + $("#discount").val() + "</td>";
		str += "<td>" + $("#TotalAnount").val() + "</td>";
		str += "<td>" + $("#availability option:selected").val() + "</td>";
		str += "<td>" + $("#terms option:selected").val() + "</td>";
		str += "<td style='display:none;'>" + $("#brands option:selected").val() + "</td>";
		str += "<td >" + $("#brands option:selected").html() + "</td>";
		str+="<td>";
		str += "<a class='waves-effect waves-light btn red' onclick='DeleteRow(this)'>Delete</a>";
		str+="</td>";
		str += "</tr>";
		jQuery("#table tbody").append(str);
	M.toast({ html: 'Item has been added', classes: 'rounded' });

}
function SaveQA() {
	var lines = [];
	$('#table tbody tr').each(function () {

		lines.push({
			"Selected": $("input[type=radio]", this).prop("checked"),
			"SupplierId": $(this).find("td").eq(1).html(),
			"Price": $(this).find("td").eq(4).html(),
			"Description": $(this).find("td").eq(3).html(),
			"Quantity": $(this).find("td").eq(6).html(),
			"UOM": $(this).find("td").eq(5).html(),
			"Discount": $(this).find("td").eq(7).html(),
			"TotalAnount": $(this).find("td").eq(8).html(),
			"Availability": $(this).find("td").eq(9).html(),
			"Terms": $(this).find("td").eq(10).html(),
			"BrandId": $(this).find("td").eq(11).html()
		});
	});
	var Head = {
		"Name": $("#ItemName").val(),
		"SubCategoryId": $("#SubCategory option:selected").val(),
		"Analysis": $("textarea#analysis").val(),
		"RequestorId": $("#employeesInput-hidden").val(),
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
			alert(data);
			$("#QaNumber").text(data);
			M.toast({ html: 'Q.A Number 001 has been created', classes: 'rounded' });
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

function supplier() {
	options = document.querySelectorAll("#supplier option");
	$("#supplierInput-hidden").val("");
	var found = false;
	for (var i=0; i < options.length; i++) {
		var option = options[i];
		
		if (option.innerText === $("#supplierInput").val()) {
			found = true;
			$("#supplierInput-hidden").val(option.getAttribute("data-value"));
			break;
		}
	}
	if (!found) {
		M.toast({ html: 'Supplier is not Registered', classes: 'rounded' });
		$("#supplierInput").val("");
	}
	//alert($("#supplierInput-hidden").val());
}
function Employees() {
	options = document.querySelectorAll("#employees option");
	$("#employeesInput-hidden").val("");
	var found = false;
	for (var i = 0; i < options.length; i++) {
		var option = options[i];

		if (option.innerText === $("#employeesInput").val()) {
			found = true;
			$("#employeesInput-hidden").val(option.getAttribute("data-value"));
			break;
		}
	}
	if (!found) {
		M.toast({ html: $("#employeesInput").val("") + ' is not an Employee', classes: 'rounded' });
		$("#employeesInput").val("");
	}
}
function Category() {
	var selectedVal = $("#CategorySelect option:selected").val();
	

	$.ajax({

		type: "Get",
		url: "/api/GetSubCategory/" + selectedVal,
		contentType: 'application/json; charset=utf-8',
		success: function (data) {
			$newoptions = "<option selected='selected'>Select SubCategories</option>";
			for (var i = 0; i < data.length; i++) {
				$newoptions += "<option value='" + data[i].Id + "'>" + data[i].Name + "</option>";
			}
			$('select#SubCategory').html($newoptions);

		},

		error: function (error) {
			alert(error);
			jsonValue = jQuery.parseJSON(error.responseText);

		}

	});
}
