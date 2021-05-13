using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimlaAdmin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="Mời nhập tài khoản")]
        public string userName { set; get; }
        [Required(ErrorMessage="Mời nhập mật khẩu")]
        public string passWord { set; get; }
        public bool rememberMe { set; get; }
    }
}