using System.Collections;

namespace CustomCollections
{
    /// <summary>
    /// A subclass of <see cref="ArrayList"/> that adds functionality needed for the
    /// <see cref="MedianSlider"/> class.
    /// </summary>
    public class EnhancedArrayList : ArrayList
    {
        private int LastIndex => Count - 1;

        /// <summary>
        /// Pops the first element off the list.
        /// </summary>
        public void PopFirst() => RemoveAt(0);

        /// <summary>
        /// Returns the last element in the list.
        /// </summary>
        /// <returns>The last element in the list</returns>
        public object GetLast()
        {
            return this[LastIndex];
        }

        /// <summary>
        /// Returns a sorted copy of the <see cref="EnhancedArrayList"/>
        /// without performing internal sorting
        /// </summary>
        /// <returns>A sorted copy of the <see cref="EnhancedArrayList"/></returns>
        public EnhancedArrayList GetSorted()
        {
            var copy = (EnhancedArrayList) Clone();
            
            copy.Sort();
            
            return copy;
        }

        /// <summary>
        /// Returns a shallow copy of the <see cref="EnhancedArrayList"/>
        /// </summary>
        /// <returns>A shallow copy of the <see cref="EnhancedArrayList"/></returns>
        public override object Clone()
        {
            var copy = new EnhancedArrayList();

            foreach (var element in this)
            {
                copy.Add(element);
            }

            return copy;
        }
    }
}