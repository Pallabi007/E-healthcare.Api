using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTest_Project
{
    public static class ObjectExtensionMethods
    {
        public static IQueryable<T> ToQueryable<T>(this T instance)
        {
            return new[] { instance }.AsQueryable();
        }
    }
}
