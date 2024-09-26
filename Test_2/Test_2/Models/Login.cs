using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Test_2.Models
{
    public class Login
    {
        [DisplayName("Ten nguoi dung: ")]
        public string userName { get; set; }
        [DataType(DataType.Password)]

        [DisplayName("Mat Khau: ")]
        public string password { get; set; }
    }
}
