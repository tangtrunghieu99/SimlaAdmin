// JavaScript Document
function Check()
{
	var name = window.document.frmRegis.txtName.value;
	var th = /^(\w{3,180})$/; 
	if(th.test(name) == false)
		{
			alert("Độ dài của tên phải từ 3 đến 180 ký tự , Không có dấu và không được có kí tự đặc biệt");
			return false;
		}
	var email = window.document.frmRegis.email.value;
	var em = /[\w_]+@[a-z0-9]+\.{1}([a-z0-9]{2,9})$/;
	if(em.test(email) == false)
		{
			alert("Sai định dạng Email, Định dạng chuẩn: abc@xyz.hhh");
			return false;
		}
	
	var NameDn = window.document.frmRegis.txtAcc.value;
	var ndn = /^\w{3,18}$/;
	if(ndn.test(NameDn) == false)
		{
			alert("Độ dài của tên đăng nhập phải từ 3 tới 18 kí tự và không có kí tự đặc biệt!");
			return false;
		}
	
	var pass = window.document.frmRegis.txtPass.value;
	var p1= /^[a-zA-Z0-9_@&]{6,28}$/;
	if(p1.test(pass) == false)
		{
			alert("Độ dài của mật khẩu phải từ 6 đến 28 kí tự!");
			return false;
		}
	var nhaplaipass = window.document.frmRegis.txtNhapLai.value;
	if(pass != nhaplaipass)
		{
			alert("Hai mật khẩu không trùng khớp!");
			return false;
		}
	
	
	alert("Đăng ký thành công, Chào mừng bạn đến với công ty chúng tôi !");
}
