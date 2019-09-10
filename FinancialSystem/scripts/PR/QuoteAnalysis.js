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
	$('#mytable tr').each(function () {
		if (IsNotHeader) {

			var itemno = $(this).find("td").eq(1).html();
			var remarks = $("#remarks" + itemno).val();;
			var IsCorrect = $("#radio" + itemno).prop("checked");
			if (firsRow) {
				source = [{
					"Id": $(this).find("td").eq(0).html(),
					"Remarks": remarks,
					"IsCorrect": IsCorrect,
					"AlreadyReview": true
				}];
				firsRow = false;
			} else {
				source.push({
					"Id": $(this).find("td").eq(0).html(),
					"Remarks": remarks,
					"IsCorrect": IsCorrect,
					"AlreadyReview": true
				});
			}
		} else {
			IsNotHeader = true;
		}


	});

	M.toast({ html: 'Q.A Number 001 has been created', classes: 'rounded' });
}
function DeleteRow(tr) {
	tr.closest("tr").remove();
}

function supplier() {
	options = document.querySelectorAll("#supplier option");
	$("#supplierInput-hidden").val("");
	for (var i=0; i < options.length; i++) {
		var option = options[i];
		if (option.innerText === $("#supplierInput").val()) {
			$("#supplierInput-hidden").val(option.getAttribute("data-value"));
			break;
		}
	}
	//alert($("#supplierInput-hidden").val());
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
