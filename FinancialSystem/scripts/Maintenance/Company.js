var RoeElem;
function AddCompany(elmnt) {
	var elems = document.querySelectorAll('.modal');
	var instances = M.Modal.init(elems);
	var elems = document.querySelectorAll('select');
	var instances = M.FormSelect.init(elems);
	RoeElem = elmnt;
}
function AddingCompany() {
	
	var data = new FormData();
	var logo = $(RoeElem).closest("tr").find("td:eq(1) input[type='file']")[0].files[0];
	data.append('file', logo);
	$.ajax({
		url: '/api/AddLog',
		processData: false,
		contentType: false,
		data: data,
		type: 'POST'
	}).done(function (result) {
		
		addingSmallLogo(result);
	}).fail(function (a, b, c) {
		console.log(a, b, c);
	});
}
function addingSmallLogo(logo) {
	var data = new FormData();
	var smallLogo = $(RoeElem).closest("tr").find("td:eq(2) input[type='file']")[0].files[0];
	data.append('file', smallLogo);
	$.ajax({
		url: '/api/AddLog',
		processData: false,
		contentType: false,
		data: data,
		type: 'POST'
	}).done(function (result) {
		addingDetails(logo, result);
	}).fail(function (a, b, c) {
		console.log(a, b, c);
	});

}
function addingDetails(logo, smallLogo) {
	source = {
		"CompanyName": $(RoeElem).closest("tr").find("td:eq(0) input[type='text']").val(),
		"CompanyCode": $(RoeElem).closest("tr").find("td:eq(3) input[type='text']").val(),
		"Phone": $(RoeElem).closest("tr").find("td:eq(4) input[type='text']").val(),
		"Address": $(RoeElem).closest("tr").find("textarea").eq(5).val(),
		"Email": $(RoeElem).closest("tr").find("td:eq(6) input[type='text']").val(),
		"Logo": logo,
		"SmallLogo": smallLogo,
		"Tin": $(RoeElem).closest("tr").find("td:eq(7) input[type='text']").val(),
		"SecurityStamp": $("#SecurityStamp").val()

	};
	$.ajax({

		type: "POST",
		url: "/api/AddingCompany",
		data: JSON.stringify(source),
		//data: "1",
		contentType: 'application/json',

		//dataType: 'json',

		success: function (data) {
			M.toast({ html: 'Company has been save', classes: 'rounded' });
		},

		error: function (error) {
			alert(error);
			jsonValue = jQuery.parseJSON(error.responseText);
		}

	})
}