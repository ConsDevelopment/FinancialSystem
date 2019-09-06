function InputDetail() {

	M.toast({ html: 'Item has been added', classes: 'rounded' });

}
function Category() {
	var selectedVal = $("#CategorySelect option:selected").val();
	alert(selectedVal);

	$.ajax({

		type: "Get",
		url: "/api/GetSubCategory/" + selectedVal,
		//data: JSON.stringify(source),
		contentType: 'application/json; charset=utf-8',
		success: function (data) {
			alert(data.length);
			//var $el = $("#SubCategory");
			//$el.empty(); // remove old options
			//$el.append($("<option selected='selected'></option>")
			//	.attr("value", "").text("Select SubCategories"));
			$newoptions = "<option selected='selected'>Select SubCategories</option>";
			for (var i = 0; i < data.length; i++) {
				alert('for');
				//$el.append($("<option></option>")
				//.attr("value", data[i].Id).text(data[i].Name));
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