// JavaScript Document
function Check()
{
	var name=window.document.frmLogin.txtTaiKhoan.value;
	var pass=window.document.frmLogin.txtMatKhau.value;
	if(name=="tangtrunghieu99" && pass=="0373212213")
		document.frmLogin.action="../PageAd/Home-Admin.html";
	else if(name=="nguyenvanhoang99" && pass=="0373212213")
		document.frmLogin.action="../PageAd/Home-Admin.html";
	else if(name=="nguyenvana123" && pass=="conheo")
		document.frmLogin.action="../PageClient/Home-Member.html";
	else if(name=="nguyenvanb"&&pass=="vanlaconheo")
		document.frmLogin.action="../PageClient/Home-Member.html";
	else 
		document.frmLogin.action="HomePage.html";
}