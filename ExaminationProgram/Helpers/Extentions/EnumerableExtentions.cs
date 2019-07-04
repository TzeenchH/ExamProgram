using System;
using System.Collections.Generic;

namespace ExaminationProgram.Helpers.Extentions
{
    public static class EnumerableExtentions
    {
        public static IList<T> AddRange<T>(this IList<T> collection, IEnumerable<T> newItems)
        {
            collection.ForEach((t, source) =>
            {
                source.Add(t);
            });

            return collection;
        }

        public static IList<T> ForEach<T>(this IList<T> collection, Action<T, IList<T>> toDo)
        {
            foreach (var item in collection)
                toDo(item, collection);
            return collection;
        }
    }
}
