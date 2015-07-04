using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExtension
{
    public static class Extender
    {
        public static ReadOnlyCollection<T> AsReadOnly<T>(this T[] array)
        {
            return Array.AsReadOnly(array);
        }

        public static int BinarySearch<T>(this T[] array, T value)
        {
            return Array.BinarySearch(array, value);
        }

        public static int BinarySearch<T>(this T[] array, int index, int length, T value)
        {
            return Array.BinarySearch(array, index, length, value);
        }

        public static void Clear<T>(this T[] array, int index, int length)
        {
            Array.Clear(array, index, length);
        }

        public static void ConstrainedCopy<T>(this T[] sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length)
        {
            Array.ConstrainedCopy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
        }

        public static TOutput[] ConvertAll<TInput, TOutput>(this TInput[] array, Converter<TInput, TOutput> converter)
        {
            return Array.ConvertAll(array, converter);
        }

        public static void Copy<T>(this T[] sourceArray, Array destinationArray, long length, long sourceIndex = 0, long destinationIndex = 0)
        {
            Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
        }

        public static bool Exists<T>(this T[] array, Predicate<T> match)
        {
            return Array.Exists(array, match);
        }

        public static T Find<T>(this T[] array, Predicate<T> match)
        {
            return Array.Find(array, match);
        }

        public static T[] FindAll<T>(this T[] array, Predicate<T> match)
        {
            return Array.FindAll(array, match);
        }

        public static int FindIndex<T>(this T[] array, Predicate<T> match, int startIndex = 0, int? count = null)
        {
            if (count.HasValue)
            {
                return Array.FindIndex(array, startIndex, count.Value, match);
            }
            else
            {
                return Array.FindIndex(array, startIndex, match);
            }
        }

        public static T FindLast<T>(this T[] array, Predicate<T> match)
        {
            return Array.FindLast(array, match);
        }

        public static int FindLastIndex<T>(this T[] array, Predicate<T> match, int startIndex = 0, int? count = null)
        {
            if (count.HasValue)
            {
                return Array.FindLastIndex(array, startIndex, count.Value, match);
            }
            else
            {
                return Array.FindLastIndex(array, startIndex, match);
            }
        }

        public static void ForEach<T>(this T[] array, Action<T> action)
        {
            Array.ForEach(array, action);
        }

        public static int IndexOf<T>(this T[] array, T value, int startIndex = 0, int? count = null)
        {
            if (count.HasValue)
            {
                return Array.IndexOf(array, value, startIndex);
            }
            else
            {
                return Array.IndexOf(array, value, startIndex, count.Value);
            }
        }

        public static int LastIndexOf<T>(this T[] array, T value, int startIndex = 0, int? count = null)
        {
            if (count.HasValue)
            {
                return Array.LastIndexOf<T>(array, value, startIndex);
            }
            else
            {
                return Array.LastIndexOf(array, value, startIndex, count.Value);
            }
        }

        //public static void Resize<T>(this T[] array, int newSize)
        //{
        //    throw new NotSupportedException("The C# extension methods did not support passing this parameters by reference. Use VB.net instead");
        //    Array.Resize(ref array, newSize);
        //}

        public static void Reverse<T>(this T[] array, int? index = null, int? length = null)
        {
            if (length.HasValue && index.HasValue)
            {
                Array.Reverse(array, index.Value, length.Value);
            }
            else
            {
                Array.Reverse(array);
            }
        }

        public static void Sort<T>(this T[] array, Comparison<T> comparison = null, int? index = null, int? length = null)
        {
            IComparer<T> comparer = null;
            if (comparison != null)
            {
                comparer = new FunctorComparer<T>(comparison);
            }

            if (length.HasValue && index.HasValue)
            {
                Array.Sort(array, index.Value, length.Value, comparer);
            }
            else
            {
                Array.Sort(array, comparer);
            }
        }

        public static bool TrueForAll<T>(this T[] array, Predicate<T> match)
        {
            return Array.TrueForAll(array, match);
        }

        private sealed class FunctorComparer<T> : IComparer<T>
        {
            private Comparison<T> comparison;

            public FunctorComparer(Comparison<T> comparison)
            {
                this.comparison = comparison;
            }

            public int Compare(T x, T y)
            {
                return comparison(x, y);
            }
        }
    }
}