using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Common
{
    public class DefaultUserContext : IUserContext
    {
        public int UserId { get; set; }
        public int AppCode { get; set; }
    }
}
