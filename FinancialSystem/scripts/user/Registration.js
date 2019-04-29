function Registration() {
	source = {
		"FirstName": $("#FirstName").val(),
		"LastName": $("#LastName").val(),
		"Email": $("#Email").val(),
		"Contact": $("#Contact").val(),
		"EmpNo": $("#EmpNo").val(),
		"password": $("#password").val()
	};
	$.ajax({

		type: "POST",
		url: $("#ApiServer").val() + "/api/Register",
		data: JSON.stringify(source),
		//data: "1",
		contentType: 'application/json',

		//dataType: 'json',

		success: function (data) {
			location.href = data;


		},

		error: function (error) {
			alert(error);
			jsonValue = jQuery.parseJSON(error.responseText);

		}

	});

}