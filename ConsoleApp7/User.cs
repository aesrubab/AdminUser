using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public abstract class UserInfo
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    internal class User : UserInfo
    {
        public required string Name {  get; set; }
        public string SurName {  get; set; }
        public string Surname { get; internal set; }
        public int Age { get; set; }
    }
}
