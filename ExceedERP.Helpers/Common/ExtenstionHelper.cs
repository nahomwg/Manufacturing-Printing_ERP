using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceedERP.Helpers.Common
{
    public static class ExtenstionHelper
    {


        //public static bool IsNotNull<T>(this T Obj)
        //{

        //    if (Obj == null)
        //        return true;

        //    return false;
        //}
        public static IEnumerable<TSource> DistinctByField<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static Task<List<T>> ToListAsync<T>(this IQueryable<T> list)
        {
            return Task.Run(() => list.ToList());
        }

        public static Task<T> FirstOrDefaultAsync<T>(this IQueryable<T> list)
        {
            return Task.Run(() => list.FirstOrDefault());
        }

        public static decimal DivideByZeroHelper(this decimal Value)
        {
            if (Value == decimal.Zero)
            {
                return decimal.One;
            }
            return Value;
        }
    }
}
