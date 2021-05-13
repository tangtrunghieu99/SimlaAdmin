// JavaScript Document
function Check()
{
	var name = window.document.frmCareer.txtName.value;
	var th = /^(\w{3,180})$/; 
	if(th.test(name) == false)
		{
			alert("Độ dài của tên phải từ 3 đến 180 ký tự , Không có dấu và không được có kí tự đặc biệt");
			return false;
		}
	var email = window.document.frmCareer.email.value;
	var em = /[\w_]+@[a-z0-9]+\.{1}([a-z0-9]{2,9})$/;
	if(em.test(email) == false)
		{
			alert("Sai định dạng Email, Định dạng chuẩn: abc@xyz.hhh");
			return false;
		}
	
	
	
	var cmnd = window.document.frmCareer.txtCMND.value;
	var p1= /^([0-9]{9})+$/;
	if(p1.test(cmnd) == false)
		{
			alert("Độ dài CMND phải 9 kí tự bằng số!");
			return false;
		}
	alert("Nộp đơn thành công ,Hãy chờ tin từ nhà tuyển dụng !");
}
