
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
				str +="<div class='col s12 m3'>";
				str +="<div class='card-panel'>";
				str +="<div class='itemImg'>";
							<img src="~/content/images/items/shoes-thumb.jpg" alt="" class="responsive-img">
						</div>
						<div class="desc">
							<p>Rubber Shoes</p>
						</div>
						<div class="price">
							<p id="price">&#8369; 1,500.00</p>
						</div>
						<div class="button">
							<a data-target="item1" class="waves-effect waves-light btn-cart modal-trigger">
								Add
								to
								Cart
							</a>
							<!-- Modal Structure -->
							<div id="item1" class="modal bottom-sheet">
								<div class="modal-content">
									<h5>Add Item to cart</h5>
									<ul class="collection">
										<li class="collection-item avatar">
											<img src="~/content/images/items/shoes-thumb.jpg" class="circle">
											<span class="title">
												<p>RUBBER SHOES</p>
											</span>
											<p> Description here </p>
											<p> SKU:0001 </p>
											<a href="#!" class="secondary-content">
												<p id="price1">&#8369; 1,500.00</p>
											</a>
										</li>
										<li class="">
											<div class="input-field inline">
												<input id="" type="text" class="validate">
												<label for="">Quantity</label>
											</div>
											<a class="btn-floating pulse btn-medium waves-effect waves-light green darken-3
																right"><i class="material-icons">add</i>Add Item</a>
										</li>
									</ul>
								</div>
							</div>
						</div>
					</div>
				</div>

				}
				},

					error: function (error) {
				alert(error);
				jsonValue = jQuery.parseJSON(error.responseText);

				}

	});
}