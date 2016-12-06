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
        /// <summary>Returns a read-only wrapper for the specified array.</summary>
        /// <returns>A read-only <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" /> wrapper for the specified array.</returns>
        /// <param name="array">The one-dimensional, zero-based array to wrap in a read-only <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" />  wrapper. </param>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="array" /> is null.</exception>
        public static ReadOnlyCollection<T> AsReadOnly<T>(this T[] array)
        {
            return Array.AsReadOnly(array);
        }

        /// <summary>Searches a range of elements in a one-dimensional sorted <see cref="T:System.Array" /> for a value, using the specified <see cref="T:System.Collections.Generic.IComparer`1" /> generic interface.</summary>
        /// <returns>The index of the specified <paramref name="value" /> in the specified <paramref name="array" />, if <paramref name="value" /> is found. If <paramref name="value" /> is not found and <paramref name="value" /> is less than one or more elements in <paramref name="array" />, a negative number which is the bitwise complement of the index of the first element that is larger than <paramref name="value" />. If <paramref name="value" /> is not found and <paramref name="value" /> is greater than any of the elements in <paramref name="array" />, a negative number which is the bitwise complement of (the index of the last element plus 1).</returns>
        /// <param name="array">The sorted one-dimensional, zero-based <see cref="T:System.Array" /> to search. </param>
        /// <param name="index">The starting index of the range to search.</param>
        /// <param name="length">The length of the range to search.</param>
        /// <param name="value">The object to search for.</param>
        /// <param name="comparison">The <see cref="T:System.Comparison`1" /> to use when comparing elements.</param>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="array" /> is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="index" /> is less than the lower bound of <paramref name="array" />.-or-<paramref name="length" /> is less than zero.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="index" /> and <paramref name="length" /> do not specify a valid range in <paramref name="array" />.-or-<paramref name="comparison" /> is null, and <paramref name="value" /> is of a type that is not compatible with the elements of <paramref name="array" />.</exception>
        public static int BinarySearch<T>(this T[] array, T value, Comparison<T> comparison = null, int? index = null, int? length = null)
        {
            IComparer<T> comparer = null;
            if (comparison != null)
            {
                comparer = new FunctorComparer<T>(comparison);
            }

            if (length.HasValue && index.HasValue)
            {
                if (comparer != null)
                {
                    return Array.BinarySearch(array, index.Value, length.Value, value, comparer);
                }
                else
                {
                    return Array.BinarySearch(array, index.Value, length.Value, value);
                }
            }
            else
            {
                if (comparer != null)
                {
                    return Array.BinarySearch(array, value, comparer);
                }
                else
                {
                    return Array.BinarySearch(array, value);
                }
            }
        }

        /// <summary>Sets a range of elements in the <see cref="T:System.Array" /> to zero, to false, or to null, depending on the element type.</summary>
        /// <param name="array">The <see cref="T:System.Array" /> whose elements need to be cleared.</param>
        /// <param name="index">The starting index of the range of elements to clear.</param>
        /// <param name="length">The number of elements to clear.</param>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="array" /> is null.</exception>
        /// <exception cref="T:System.IndexOutOfRangeException">
        ///   <paramref name="index" /> is less than the lower bound of <paramref name="array" />.-or-<paramref name="length" /> is less than zero.-or-The sum of <paramref name="index" /> and <paramref name="length" /> is greater than the size of the <see cref="T:System.Array" />.</exception>
        /// <filterpriority>1</filterpriority>
        public static void Clear<T>(this T[] array, int index, int length)
        {
            Array.Clear(array, index, length);
        }

        /// <summary>Copies a range of elements from an <see cref="T:System.Array" /> starting at the specified source index and pastes them to another <see cref="T:System.Array" /> starting at the specified destination index.  Guarantees that all changes are undone if the copy does not succeed completely.</summary>
        /// <param name="sourceArray">The <see cref="T:System.Array" /> that contains the data to copy.</param>
        /// <param name="sourceIndex">A 32-bit integer that represents the index in the <paramref name="sourceArray" /> at which copying begins.</param>
        /// <param name="destinationArray">The <see cref="T:System.Array" /> that receives the data.</param>
        /// <param name="destinationIndex">A 32-bit integer that represents the index in the <paramref name="destinationArray" /> at which storing begins.</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to copy.</param>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="sourceArray" /> is null.-or-<paramref name="destinationArray" /> is null.</exception>
        /// <exception cref="T:System.RankException">
        ///   <paramref name="sourceArray" /> and <paramref name="destinationArray" /> have different ranks.</exception>
        /// <exception cref="T:System.ArrayTypeMismatchException">The <paramref name="sourceArray" /> type is neither the same as nor derived from the <paramref name="destinationArray" /> type.</exception>
        /// <exception cref="T:System.InvalidCastException">At least one element in <paramref name="sourceArray" /> cannot be cast to the type of <paramref name="destinationArray" />.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="sourceIndex" /> is less than the lower bound of the first dimension of <paramref name="sourceArray" />.-or-<paramref name="destinationIndex" /> is less than the lower bound of the first dimension of <paramref name="destinationArray" />.-or-<paramref name="length" /> is less than zero.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="length" /> is greater than the number of elements from <paramref name="sourceIndex" /> to the end of <paramref name="sourceArray" />.-or-<paramref name="length" /> is greater than the number of elements from <paramref name="destinationIndex" /> to the end of <paramref name="destinationArray" />.</exception>
        public static void ConstrainedCopy<T>(this T[] sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length)
        {
            Array.ConstrainedCopy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
        }

        /// <summary>Converts an array of one type to an array of another type.</summary>
        /// <returns>An array of the target type containing the converted elements from the source array.</returns>
        /// <param name="array">The one-dimensional, zero-based <see cref="T:System.Array" /> to convert to a target type.</param>
        /// <param name="converter">A <see cref="T:System.Converter`2" /> that converts each element from one type to another type.</param>
        /// <typeparam name="TInput">The type of the elements of the source array.</typeparam>
        /// <typeparam name="TOutput">The type of the elements of the target array.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="array" /> is null.-or-<paramref name="converter" /> is null.</exception>
        public static TOutput[] ConvertAll<TInput, TOutput>(this TInput[] array, Converter<TInput, TOutput> converter)
        {
            return Array.ConvertAll(array, converter);
        }

        /// <summary>Copies a range of elements from an <see cref="T:System.Array" /> starting at the specified source index and pastes them to another <see cref="T:System.Array" /> starting at the specified destination index. The length and the indexes are specified as 64-bit integers.</summary>
        /// <param name="sourceArray">The <see cref="T:System.Array" /> that contains the data to copy.</param>
        /// <param name="sourceIndex">A 64-bit integer that represents the index in the <paramref name="sourceArray" /> at which copying begins.</param>
        /// <param name="destinationArray">The <see cref="T:System.Array" /> that receives the data.</param>
        /// <param name="destinationIndex">A 64-bit integer that represents the index in the <paramref name="destinationArray" /> at which storing begins.</param>
        /// <param name="length">A 64-bit integer that represents the number of elements to copy. The integer must be between zero and <see cref="F:System.Int32.MaxValue" />, inclusive.</param>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="sourceArray" /> is null.-or-<paramref name="destinationArray" /> is null.</exception>
        /// <exception cref="T:System.RankException">
        ///   <paramref name="sourceArray" /> and <paramref name="destinationArray" /> have different ranks.</exception>
        /// <exception cref="T:System.ArrayTypeMismatchException">
        ///   <paramref name="sourceArray" /> and <paramref name="destinationArray" /> are of incompatible types.</exception>
        /// <exception cref="T:System.InvalidCastException">At least one element in <paramref name="sourceArray" /> cannot be cast to the type of <paramref name="destinationArray" />.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="sourceIndex" /> is outside the range of valid indexes for the <paramref name="sourceArray" />.-or-<paramref name="destinationIndex" /> is outside the range of valid indexes for the <paramref name="destinationArray" />.-or-<paramref name="length" /> is less than 0 or greater than <see cref="F:System.Int32.MaxValue" />.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="length" /> is greater than the number of elements from <paramref name="sourceIndex" /> to the end of <paramref name="sourceArray" />.-or-<paramref name="length" /> is greater than the number of elements from <paramref name="destinationIndex" /> to the end of <paramref name="destinationArray" />.</exception>
        /// <filterpriority>1</filterpriority>
        public static void Copy<T>(this T[] sourceArray, Array destinationArray, long length, long sourceIndex = 0, long destinationIndex = 0)
        {
            Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
        }

        /// <summary>Determines whether the specified array contains elements that match the conditions defined by the specified predicate.</summary>
        /// <returns>true if <paramref name="array" /> contains one or more elements that match the conditions defined by the specified predicate; otherwise, false.</returns>
        /// <param name="array">The one-dimensional, zero-based <see cref="T:System.Array" /> to search.</param>
        /// <param name="match">The <see cref="T:System.Predicate`1" /> that defines the conditions of the elements to search for.</param>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="array" /> is null.-or-<paramref name="match" /> is null.</exception>
        public static bool Exists<T>(this T[] array, Predicate<T> match)
        {
            return Array.Exists(array, match);
        }

        /// <summary>Searches for an element that matches the conditions defined by the specified predicate, and returns the first occurrence within the entire <see cref="T:System.Array" />.</summary>
        /// <returns>The first element that matches the conditions defined by the specified predicate, if found; otherwise, the default value for type <typeparam name="T" />.</returns>
        /// <param name="array">The one-dimensional, zero-based <see cref="T:System.Array" /> to search.</param>
        /// <param name="match">The <see cref="T:System.Predicate`1" /> that defines the conditions of the element to search for.</param>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="array" /> is null.-or-<paramref name="match" /> is null.</exception>
        public static T Find<T>(this T[] array, Predicate<T> match)
        {
            return Array.Find(array, match);
        }

        /// <summary>Retrieves all the elements that match the conditions defined by the specified predicate.</summary>
        /// <returns>An <see cref="T:System.Array" /> containing all the elements that match the conditions defined by the specified predicate, if found; otherwise, an empty <see cref="T:System.Array" />.</returns>
        /// <param name="array">The one-dimensional, zero-based <see cref="T:System.Array" /> to search.</param>
        /// <param name="match">The <see cref="T:System.Predicate`1" /> that defines the conditions of the elements to search for.</param>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="array" /> is null.-or-<paramref name="match" /> is null.</exception>
        public static T[] FindAll<T>(this T[] array, Predicate<T> match)
        {
            return Array.FindAll(array, match);
        }

        /// <summary>Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence within the range of elements in the <see cref="T:System.Array" /> that starts at the specified index and contains the specified number of elements.</summary>
        /// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by <paramref name="match" />, if found; otherwise, –1.</returns>
        /// <param name="array">The one-dimensional, zero-based <see cref="T:System.Array" /> to search.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <param name="match">The <see cref="T:System.Predicate`1" /> that defines the conditions of the element to search for.</param>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="array" /> is null.-or-<paramref name="match" /> is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="startIndex" /> is outside the range of valid indexes for <paramref name="array" />.-or-<paramref name="count" /> is less than zero.-or-<paramref name="startIndex" /> and <paramref name="count" /> do not specify a valid section in <paramref name="array" />.</exception>
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

        /// <summary>Searches for an element that matches the conditions defined by the specified predicate, and returns the last occurrence within the entire <see cref="T:System.Array" />.</summary>
        /// <returns>The last element that matches the conditions defined by the specified predicate, if found; otherwise, the default value for type <typeparam name="T" />.</returns>
        /// <param name="array">The one-dimensional, zero-based <see cref="T:System.Array" /> to search.</param>
        /// <param name="match">The <see cref="T:System.Predicate`1" /> that defines the conditions of the element to search for.</param>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="array" /> is null.-or-<paramref name="match" /> is null.</exception>
        public static T FindLast<T>(this T[] array, Predicate<T> match)
        {
            return Array.FindLast(array, match);
        }

        /// <summary>Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the last occurrence within the range of elements in the <see cref="T:System.Array" /> that contains the specified number of elements and ends at the specified index.</summary>
        /// <returns>The zero-based index of the last occurrence of an element that matches the conditions defined by <paramref name="match" />, if found; otherwise, –1.</returns>
        /// <param name="array">The one-dimensional, zero-based <see cref="T:System.Array" /> to search.</param>
        /// <param name="startIndex">The zero-based starting index of the backward search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <param name="match">The <see cref="T:System.Predicate`1" /> that defines the conditions of the element to search for.</param>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="array" /> is null.-or-<paramref name="match" /> is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="startIndex" /> is outside the range of valid indexes for <paramref name="array" />.-or-<paramref name="count" /> is less than zero.-or-<paramref name="startIndex" /> and <paramref name="count" /> do not specify a valid section in <paramref name="array" />.</exception>
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

        /// <summary>Performs the specified action on each element of the specified array.</summary>
        /// <param name="array">The one-dimensional, zero-based <see cref="T:System.Array" /> on whose elements the action is to be performed.</param>
        /// <param name="action">The <see cref="T:System.Action`1" /> to perform on each element of <paramref name="array" />.</param>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="array" /> is null.-or-<paramref name="action" /> is null.</exception>
        public static void ForEach<T>(this T[] array, Action<T> action)
        {
            Array.ForEach(array, action);
        }

        /// <summary>Searches for the specified object and returns the index of the first occurrence within the range of elements in the <see cref="T:System.Array" /> that starts at the specified index and contains the specified number of elements.</summary>
        /// <returns>The zero-based index of the first occurrence of <paramref name="value" /> within the range of elements in <paramref name="array" /> that starts at <paramref name="startIndex" /> and contains the number of elements specified in <paramref name="count" />, if found; otherwise, –1.</returns>
        /// <param name="array">The one-dimensional, zero-based <see cref="T:System.Array" /> to search.</param>
        /// <param name="value">The object to locate in <paramref name="array" />.</param>
        /// <param name="startIndex">The zero-based starting index of the search. 0 (zero) is valid in an empty array.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="array" /> is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="startIndex" /> is outside the range of valid indexes for <paramref name="array" />.-or-<paramref name="count" /> is less than zero.-or-<paramref name="startIndex" /> and <paramref name="count" /> do not specify a valid section in <paramref name="array" />.</exception>
        public static int IndexOf<T>(this T[] array, T value, int startIndex = 0, int? count = null)
        {
            if (count.HasValue)
            {
                return Array.IndexOf(array, value, startIndex, count.Value);
            }
            else
            {
                return Array.IndexOf(array, value, startIndex);
            }
        }

        /// <summary>Searches for the specified object and returns the index of the last occurrence within the range of elements in the <see cref="T:System.Array" /> that contains the specified number of elements and ends at the specified index.</summary>
        /// <returns>The zero-based index of the last occurrence of <paramref name="value" /> within the range of elements in <paramref name="array" /> that contains the number of elements specified in <paramref name="count" /> and ends at <paramref name="startIndex" />, if found; otherwise, –1.</returns>
        /// <param name="array">The one-dimensional, zero-based <see cref="T:System.Array" /> to search.</param>
        /// <param name="value">The object to locate in <paramref name="array" />.</param>
        /// <param name="startIndex">The zero-based starting index of the backward search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="array" /> is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="startIndex" /> is outside the range of valid indexes for <paramref name="array" />.-or-<paramref name="count" /> is less than zero.-or-<paramref name="startIndex" /> and <paramref name="count" /> do not specify a valid section in <paramref name="array" />.</exception>
        public static int LastIndexOf<T>(this T[] array, T value, int startIndex = 0, int? count = null)
        {
            if (count.HasValue)
            {
                return Array.LastIndexOf(array, value, startIndex, count.Value);
            }
            else
            {
                return Array.LastIndexOf(array, value, startIndex);
            }
        }

        ///// <summary>Changes the number of elements of an array to the specified new size.</summary>
        ///// <param name="array">The one-dimensional, zero-based array to resize, or null to create a new array with the specified size.</param>
        ///// <param name="newSize">The size of the new array.</param>
        ///// <typeparam name="T">The type of the elements of the array.</typeparam>
        ///// <exception cref="T:System.ArgumentOutOfRangeException">
        /////   <paramref name="newSize" /> is less than zero.</exception>
        //public static void Resize<T>(this T[] array, int newSize)
        //{
        //    throw new NotSupportedException("The C# extension methods did not support passing this parameters by reference. Use VB.net instead");
        //    Array.Resize(ref array, newSize);
        //}

        /// <summary>Reverses the sequence of the elements in a range of elements in the one-dimensional <see cref="T:System.Array" />.</summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array" /> to reverse.</param>
        /// <param name="index">The starting index of the section to reverse.</param>
        /// <param name="length">The number of elements in the section to reverse.</param>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="array" /> is null.</exception>
        /// <exception cref="T:System.RankException">
        ///   <paramref name="array" /> is multidimensional.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="index" /> is less than the lower bound of <paramref name="array" />.-or-<paramref name="length" /> is less than zero.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="index" /> and <paramref name="length" /> do not specify a valid range in <paramref name="array" />.</exception>
        /// <filterpriority>1</filterpriority>
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

        /// <summary>Sorts the elements in a range of elements in an <see cref="T:System.Array" /> using the specified <see cref="T:System.Collections.Generic.IComparer`1" /> generic interface.</summary>
        /// <param name="array">The one-dimensional, zero-based <see cref="T:System.Array" /> to sort.</param>
        /// <param name="index">The starting index of the range to sort.</param>
        /// <param name="length">The number of elements in the range to sort.</param>
        /// <param name="comparison">The <see cref="T:System.Comparison`1" /> to use when comparing elements.</param>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="array" /> is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="index" /> is less than the lower bound of <paramref name="array" />.-or-<paramref name="length" /> is less than zero.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="index" /> and <paramref name="length" /> do not specify a valid range in <paramref name="array" />. -or-The implementation of <paramref name="comparison" /> caused an error during the sort. For example, <paramref name="comparison" /> might not return 0 when comparing an item with itself.</exception>
        public static void Sort<T>(this T[] array, Comparison<T> comparison = null, int? index = null, int? length = null)
        {
            IComparer<T> comparer = null;
            if (comparison != null)
            {
                comparer = new FunctorComparer<T>(comparison);
            }

            if (length.HasValue && index.HasValue)
            {
                if (comparer != null)
                {
                    Array.Sort(array, index.Value, length.Value, comparer);
                }
                else
                {
                    Array.Sort(array, index.Value, length.Value);
                }
            }
            else
            {
                if (comparer != null)
                {
                    Array.Sort(array, comparer);
                }
                else
                {
                    Array.Sort(array);
                }
            }
        }

        /// <summary>Determines whether every element in the array matches the conditions defined by the specified predicate.</summary>
        /// <returns>true if every element in <paramref name="array" /> matches the conditions defined by the specified predicate; otherwise, false. If there are no elements in the array, the return value is true.</returns>
        /// <param name="array">The one-dimensional, zero-based <see cref="T:System.Array" /> to check against the conditions</param>
        /// <param name="match">The <see cref="T:System.Predicate`1" /> that defines the conditions to check against the elements.</param>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="array" /> is null.-or-<paramref name="match" /> is null.</exception>
        public static bool TrueForAll<T>(this T[] array, Predicate<T> match)
        {
            return Array.TrueForAll(array, match);
        }

        private sealed class FunctorComparer<T> : IComparer<T>
        {
            private readonly Comparison<T> comparison;

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