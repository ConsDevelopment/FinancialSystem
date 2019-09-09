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
		str+="<td></td>";
		str+="<td></td>";
		str += "<td></td>";
		str += "<td></td>";
		str+="<td>";
		str+="<a class='waves-effect waves-light btn red'>Delete</a>";
		str+="</td>";
		str += "</tr>";
		jQuery("#table tbody").append(str);
	M.toast({ html: 'Item has been added', classes: 'rounded' });

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
