function AddItems() {
       
    source = {
        "Name": $("#Name").val(),
        "ItemCode": $("#Code").val(),
        "Sku": $("#SKU").val(),
        "Description": $("#Description").val(),
        "Qty": $("#Quantity").val(),
        "Price": $("#Price").val()

    };
    $.ajax({

        type: "POST",
        url: $("#ApiServer").val() + "/api/AddItems",
        data: JSON.stringify(source),
        //data: "1",
        contentType: 'application/json',

        //dataType: 'json',

        success: function (data) {
            alert(data);
        },

        error: function (error) {
            alert(error);
            jsonValue = jQuery.parseJSON(error.responseText);
        }

    })

}

$("#BrandName").on('input', function () {

	var val = this.value;
	if ($('#BrandNameList option').filter(function () {
        return this.value.toUpperCase() === val.toUpperCase();
	}).length) {
		//send ajax request
		var value = $('#BrandName').val();

		$("#BrandNameListId").val($('#BrandNameList [value="' + value + '"]').data('value'));

	}
});

$("#SupplierName").on('input', function () {

	var val = this.value;
	if ($('#SupplierNameList option').filer(function () {
		return this.value.toUpperCase() === val.toUpperCase();
	}).length) {
		//send ajax request
		var value = $('#SupplierName').val();

		$("#SupplierNameListId").val($('#SupplierNameList [value="' + value + '"]').data('value'));
	}

})