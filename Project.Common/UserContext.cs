﻿using System;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using ServiceStack;
using Project.Common.Classes;

namespace Project.Common
{
    public class UserContext : IUserContext
    {
        public int UserId { get; set; }
        public int AppCode { get; set; }

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            var headers = httpContextAccessor?.HttpContext.Request.Headers;
            if (headers == null || headers.Count == 0) return;
            if (!headers.TryGetValue("Custom", out StringValues arr)) return;

            if (arr.Count == 0) return;
            var bytes = Convert.FromBase64String(arr[0]);
            var header = Encoding.UTF8.GetString(bytes).FromJson<UserHeader>();

            if (header != null)
            {
                UserId = header.UserID;
                AppCode = header.AppCode;
            }
        }
    }
}