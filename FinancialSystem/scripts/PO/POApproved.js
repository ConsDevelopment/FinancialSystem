//$("#Approved").on('click', function () {
	
//	alert('test');
//});

function Approved(status) {

	

	var PRs = [];
	$.each($("input[name='POApprovedChk']"), function () {
		if ($(this).is(':checked')) {
			
			var element = {
				"Id": Number($(this).attr('id')),
				"Status": status,
				"SecurityStamp": $("#SecurityStamp").val()
			};
			PRs.push(element);
		}

	});

	$.ajax({

		type: "POST",
		url: "/api/POApproval",
		data: JSON.stringify(PRs),
		//data: "1",
		contentType: 'application/json; charset=utf-8',

		//dataType: 'json',

		success: function (data) {
			for (var i = 0; i < data.length; i++) {
				M.toast({ html: 'PO ' + data[i].RequisitionNo + ' has been ' + status, classes: 'rounded' });
			}
			
			location.reload();

		},
		error: function (error) {
			alert(error);
			jsonValue = jQuery.parseJSON(error.responseText);

		}

	});


	
}