using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace DanhoLibrary
{
    /// <summary>
    /// List of specified type
    /// </summary>
    /// <typeparam name="T">Type of items to store</typeparam>
    public class MyList<T> : IEnumerable
    {
        #region Construction

        #region OptionType
        /// <summary> What is prioritized in terms of time or space </summary>
        public int OptionType { get => optionType; set => optionType = value; }
        private static int optionType;
        #endregion

        #region Capacity
        /// <summary> Capacity list can have </summary>
        public int Capacity { get => InternCapacity; }
        private static int ValueOfInternCapacity;

        /// <summary> The 100% incase of <see cref="optionType"/> = 3 </summary>
        private static int Whole = 50;
        private static int InternCapacity { get => GetCapacity(ref ValueOfInternCapacity); }
        private static int GetCapacity(ref int ValueOfInternCapacity)
        {
            if (ValueOfInternCapacity is 0) 
                return (optionType != 2) ? 50 : 10;
            else if (ValueOfInternCapacity == CountItems())
                return ValueOfInternCapacity = optionType is 1 ? + 50 : optionType is 2 ? + 10 : Whole--;
            return ValueOfInternCapacity;
        }
        #endregion

        #region NewArray()
        /// <summary> Main array </summary>
        private static T[] List = NewArray(false);

        /// <summary> New Array </summary>
        /// <param name="ContainsItems"></param>
        /// <returns>true if same items, else no items</returns>
        private static T[] NewArray(bool ContainsItems)
        {
            if (!ContainsItems) 
                return new T[InternCapacity];

            T[] TempArr = new T[InternCapacity];
            for (int x = 0; x < List.Length; x++)
                TempArr[x] = List[x];

            return TempArr;
        }
        
        /// <summary> New array not including RemovedItem </summary>
        /// <param name="RemovedItem">Item not to include in new array</param>
        /// <returns>New array without RemovedItem</returns>
        private T[] NewArray(T RemovedItem)
        {
            var TempArr = new T[InternCapacity];
            for (int x = 0; x < CountItems(); x++)
                if (!List[x].Equals(RemovedItem))
                    TempArr[x] = List[x];
            return TempArr;
        }
        #endregion

        /// <summary> Get an item from index </summary>
        /// <param name="index">Index of item</param>
        /// <returns>Item</returns>
        public T this[int index] { get => List[index]; set => List[index] = value; }

        /// <summary> Resets list to completely empty with default capacity </summary>
        public void Reset() => List = new T[InternCapacity];
        #endregion

        #region Constructer with body
        /// <summary> Very cool list from DanhoLibrary </summary>
        /// <param name="optionType">1: Space > time | 2: Space + 10  | 3: Time > Space</param>
        public MyList(int optionType) => OptionType = optionType;
        public MyList(int optionType, IEnumerable<T> collection) : this(optionType)
        {
            foreach (var item in collection)
                Add(item);
        }
        public IEnumerator GetEnumerator() => List.GetEnumerator(); 
        #endregion

        #region Add/Remove
        /// <summary> Adds specified item to list </summary>
        /// <param name="item">Item to add</param>
        public void Add(T item)
        {
            try
            {
                for (int x = 0; x < List.Length; x++)
                    if (List[x] == null) 
                    { 
                        List[x] = item; 
                        return; 
                    }
                throw new IndexOutOfRangeException();
            }
            catch (IndexOutOfRangeException) 
            { 
                List = NewArray(true); 
                Add(item); 
            }
            catch (Exception err) { ConsoleItems.Error(err); }
        }
        /// <summary> Removes specified item </summary>
        /// <param name="item">Item to remove</param>
        public void Remove(T item)
        {
            if (!Contains(item, out int Index))
                throw new Exception($"{nameof(item)} is not in the list.");
            List = NewArray(List[Index]);
        }
        public void Remove(int Index)
        {
            if (Index > CountItems())
                throw new Exception($"Index {Index} is invalid due to .Count returning {CountItems()}");
            List = NewArray(List[Index]);
        }
        #endregion

        #region Next/Previous
        /// <summary> Item to remember using .Next() and .Previous() </summary>
        public T ImportantItem { get; set; }
        /// <summary> Get the next item of ImportantItem </summary>
        /// <returns>The next item from ImportantItem's position</returns>
        public T Next()
        {
            try { return PositionHelper(List[0], true); }
            catch (ArgumentOutOfRangeException) { throw new Exception("You cannot call index +1!"); }
        }
        /// <summary> Get the previous item of ImportantItem </summary>
        /// <returns>The previous item from ImportantItem's position</returns>
        public T Previous()
        {
            try { return PositionHelper(List[CountItems()], false); }
            catch (ArgumentOutOfRangeException) { throw new Exception("You cannot call index -1!"); }
        }
        /// <summary> Main code used for Next() and Previous() </summary>
        /// <param name="StartItem">Definition of <see cref="ImportantItem"/> if not defined</param>
        /// <param name="IsPositive">Determines if Index++ or Index--</param>
        private T PositionHelper(T StartItem, bool IsPositive)
        {
            if (!Contains(ImportantItem, out int index) || ImportantItem == null)
                ImportantItem = StartItem;
            if (IsPositive)
                return List[index + 1];
            return List[index - 1];
        }
        #endregion

        #region ToArray(), Sort(), Count(), IndexOf(), Contains()
        /// <summary> Returns List in Array </summary>
        public T[] ToArray() => List;
        /// <summary> Amount of items in list </summary>
        public int Count { get => CountItems(); }
        /// <summary> Value of .Count </summary>
        /// <returns>Count of items inside <see cref="List"/></returns>
        private static int CountItems()
        {
            for (int x = 0; x < List.Length; x++)
                if (List[x] == null)
                    return x;
            return ValueOfInternCapacity;
        }
        /// <summary> Finds the Index of Item and returns Index </summary>
        /// <param name="item">Item to look for</param>
        /// <returns>Index of specified Item</returns>
        public int IndexOf(T item)
        {
            for (int x = 0; x < List.Length; x++)
                if (List[x].Equals(item))
                    return x;
            return -1;
        }

        #region Contains
        /// <summary> Returns true if list has item stored, else returns false </summary>
        /// <param name="item"></param>
        /// <returns>true if item is contained, else false</returns>
        public bool Contains(T item)
        {
            for (int x = 0; x < List.Length; x++)
                if (List[x].Equals(item))
                    return true;
            return false;
        }
        /// <summary> Same as Contains(T item), except it outs the Index of the item it looked for </summary>
        /// <param name="item">Item to look for</param>
        /// <param name="Index">Index item is placed in</param>
        private bool Contains(T item, out int Index)
        {
            for (int x = 0; x < List.Length; x++)
                if (List[x].Equals(item))
                {
                    Index = x;
                    return true;
                }
            Index = -1;
            return false;
        }
        #endregion

        #endregion
    }
}

// 1: Space > Time
// 2: Space + 10
// 3: Time > Space