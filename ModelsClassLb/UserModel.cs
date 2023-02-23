using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsClassLb
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public TimeSpan? EasyTime { get; set; }
        public TimeSpan? MediumTime { get; set; }
        public TimeSpan? HardTime { get; set; }
    }
}
