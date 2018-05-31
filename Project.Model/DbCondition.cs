using System;
using System.Linq.Expressions;

namespace Project.Model
{
    public class DbCondition<T>
    {
        public bool IsWhere { get; set; }

        public Expression<Func<T, bool>> Expression { get; set; }
    }
}