function Registration(){ 
	alert($("#company").children("option:selected").val());
	source = {
		"FirstName": $("#FirstName").val(),
		"LastName": $("#LastName").val(),
		"Email": $("#Email").val(),
		"Contact": $("#Contact").val(),
		"EmpNo": $("#EmpNo").val(),
		"password": $("#password").val(),
		"Gender": $("#gender").children("option:selected").val(),
		"CompanyId": $("#company").children("option:selected").val(),
		"Job_Id": $("#position").children("option:selected").val(),
		"Dept_Id": $("#department").children("option:selected").val()

	};
	$.ajax({

		type: "POST",
		url: $("#ApiServer").val() + "/api/Register",
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

	});

}