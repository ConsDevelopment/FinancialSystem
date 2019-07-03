function LocalToUTC(dateStr) {
	var date = new Date(dateStr);
	alert(date.toLocaleString());
	date.setHours(23);
	date.setMinutes(59);
	alert(date.getHours());
	var utcDate = new Date(date.toUTCString());
	alert(utcDate.getHours());
	//var UtcDate = date.U();
	//alert(UtcDate);

}