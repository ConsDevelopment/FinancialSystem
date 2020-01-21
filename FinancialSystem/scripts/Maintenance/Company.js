var RoeElem;
function AddCompany(elmnt) {
	var elems = document.querySelectorAll('.modal');
	var instances = M.Modal.init(elems);
	var elems = document.querySelectorAll('select');
	var instances = M.FormSelect.init(elems);
	RoeElem = elmnt;
}
function AddingCompany() {
	alert('test');
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
		alert(result);
	}).fail(function (a, b, c) {
		console.log(a, b, c);
	});
}