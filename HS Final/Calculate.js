function Calculate() {

var sum=0;
var itemnum, check;
for (i=0; i<6; i++) {
	itemnum = 'item'+i;
	check = document.getElementById(itemnum);
	if (check.checked==true) {sum += Number(check.value); }
}
document.getElementById('totalcost').innerHTML = sum.toFixed(2);
}