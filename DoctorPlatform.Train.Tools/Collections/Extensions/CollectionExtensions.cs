﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Tools.Collections.Extensions
{
    public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            return source == null || source.Count <= 0;
        }

        public static bool AddIfNotContains<T>(this ICollection<T> source, T item)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (source.Contains(item))
            {
                return false;
            }

            source.Add(item);

            return true;
        }
    }
}
