var RoeElem;
function AddCompany(elmnt) {
	var elems = document.querySelectorAll('.modal');
	var instances = M.Modal.init(elems);
	var elems = document.querySelectorAll('select');
	var instances = M.FormSelect.init(elems);
	RoeElem = elmnt;
}
function AddingCompany() {

}