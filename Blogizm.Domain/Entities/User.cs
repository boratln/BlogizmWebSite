﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId {  get; set; }
        public Role Role { get; set; }
        public bool isConfirmed { get; set; }
    }
}
