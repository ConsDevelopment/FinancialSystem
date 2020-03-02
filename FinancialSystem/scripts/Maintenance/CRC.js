var RoeElem;
function AddCRC(elmnt) {
	var elems = document.querySelectorAll('.modal');
	var instances = M.Modal.init(elems);
	var elems = document.querySelectorAll('select');
	var instances = M.FormSelect.init(elems);
	RoeElem = elmnt;

}
function AddingCRC() {
	var code = $(RoeElem).closest("tr").find("td:eq(0) input[type='text']").val();
	var name = $(RoeElem).closest("tr").find("td:eq(1) input[type='text']").val();
	source = {
		"CRCCode": code,
		"CRCName": name,
		"SecurityStamp": $("#SecurityStamp").val()
	};

	$.ajax({

		type: "POST",
		url: "/api/AddCRC",
		data: JSON.stringify(source),
		//data: "1",
		contentType: 'application/json; charset=utf-8',

		//dataType: 'json',

		success: function (data) {
			M.toast({ html: 'CRC ' + code + ' has been added', classes: 'rounded' });
			var str = "<tr>";
			str += "<td>";
			str += "<input type='text' placeholder='CRC Code'>";
			str += "</td>";
			str += "<td>";
			str += "<input type='text' placeholder='CRC Name'>";
			str += "</td>";
			str += "<td>";
			str += "<a onclick='AddCRC(this)' class='btn-floating pulse btn-small waves-effect waves-light green modal-trigger' href='#modal4'>";
			str += "<i class='material-icons'>add</i>";
			str += "</a>";
			str += "</td>";
			str += "</tr>";
			$("table tbody").append(str);
		},

		error: function (error) {
			alert(error);
			jsonValue = jQuery.parseJSON(error.responseText);

		}

	});
}