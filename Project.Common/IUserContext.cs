using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Common
{
    public interface IUserContext
    {
        int UserId { get; set; }
        int AppCode { get; set; }
    }
}
