using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.DTO
{
    public enum EnumGender
    {
        Male,FeMale
    }
    public class UserLoginDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PassWord { get; set; }
    }
    public class UserDTO : UserLoginDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        [Required]
        public EnumGender Gender { get; set; }
        public string Address { get; set; }
    }
}
