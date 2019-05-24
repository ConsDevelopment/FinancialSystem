
function search(event) {
	alert("test");
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
		url: $("#ApiServer").val() + "/api/SearchItem",
		data: JSON.stringify(source),
		//data: "1",
		contentType: 'application/json; charset=utf-8',

		//dataType: 'json',

		success: function (data) {
			alert(data[0].Name);
			$("#ItemContainer").empty();
			var strElement="";
			for(i=0;i<data.length;i++){
				strElement += "<div class='col s12 m3'>";
				strElement += "<div class='card-panel'>";
				strElement += "<div class='itemImg'>";
				strElement += "<img src='" + $("#ItemImagePath").val() + data[i].image + "' alt=' ' class='responsive-img'>";
				strElement += "</div>";
				strElement += "<div class='desc'>";
				strElement += "<p>" + data[i].Name + "</p>";
				strElement += "</div>";
				strElement += "<div class='price'>";
				strElement += "<p id='price'>&#8369; " + data[i].Price + "</p>";
				strElement += "</div>";
				strElement += "<div class='button'>";
				strElement += "<a data-target='item" + data[i].Id + "' class='waves-effect waves-light btn-cart modal-trigger'>";
				strElement += "Add to Cart";
				strElement += "</a>";
				strElement += "<!-- Modal Structure -->";
				strElement += "<div id='item" + data[i].Id + "' class='modal bottom-sheet'>";
				strElement += "<div class='modal-content'>";
				strElement += "<h5>Add Item to cart</h5>";
				strElement += "<ul class='collection'>";
				strElement += "<li class='collection-item avatar'>";
				strElement += "<img src='" + $("#ItemImagePath").val() + data[i].image + "' class='circle'>";
				strElement += "<span class='title'>";
				strElement += "<p>" + data[i].Name + "</p>";
				strElement += "</span>"
				strElement += "<p> " + data[i].Description + " </p>";
				strElement += "<p> " + data[i].SKU + " </p>";
				strElement += "<a href='#!' class='secondary-content'>";
				strElement += "<p id='price1'>&#8369;" + data[i].Price + "</p>";
				strElement += "</a>";
				strElement += "</li>";
				strElement += "<li class=''>";
				strElement += "<div class='input-field inline'>";
				strElement += "<input id='' type='text' class='validate'>";
				strElement += "<label for=''>" + data[i].Quantity + "</label>";
				strElement += "</div>";
				strElement += "<a class='btn-floating pulse btn-medium waves-effect waves-light green darken-3";
				strElement += "right'><i class='material-icons'>add</i>Add Item</a>";
				strElement += "</li>";
				strElement += "</ul>";
				strElement += "</div>";
				strElement += "</div>";
				strElement += "</div>";
				strElement += "</div>";
				strElement += "</div>";

			}
			//$("#ItemContainer").append(strElement);
			},

			error: function (error) {
				alert(error);
				jsonValue = jQuery.parseJSON(error.responseText);

			}

	});
}