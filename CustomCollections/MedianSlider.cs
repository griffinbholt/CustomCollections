namespace CustomCollections
{
    /// <summary>
    /// A data structure designed to continuously track the median of a small subset of elements,
    /// as that subset changes to include different elements of its superset. 
    /// </summary>
    public class MedianSlider
    {
        
        /// <summary>
        /// The size of the MedianSlider, assigned at construction (readonly)
        /// </summary>
        public readonly int SliderSize;
        
        private readonly int medianIndex;
        private readonly EnhancedArrayList slider = new EnhancedArrayList();

        /// <summary>
        /// Creates a new MedianSlider object of the input size
        /// </summary>
        /// <param name="size">The size of the MedianSlider object</param>
        public MedianSlider(int size)
        {
            SliderSize = size;
            medianIndex = size / 2;
        }
        
        /// <summary>
        /// The number of elements in the MedianSlider
        /// </summary>
        public int Count => slider.Count;
        
        /// <summary>
        /// True, if the number of elements in the MedianSlider is equal to the size
        /// set at the MedianSlider's construction; otherwise, false.
        /// </summary>
        public bool SliderFilled => slider.Count == SliderSize;

        /// <summary>
        /// Inserts a new value into the MedianSlider.
        /// If the number of elements already inserted is equal to the size of the slider,
        /// then the value in the slider that was inserted first chronologically will be popped.
        /// Otherwise, the value is just inserted into the MedianSlider.
        /// </summary>
        /// 
        /// <param name="value">The value being inserted into the MedianSlider</param>
        public void Insert(float value)
        {
            if (SliderFilled)
            {
                slider.PopFirst();
            }

            slider.Add(value);
        }

        /// <summary>
        /// Gets the median value of the elements in the MedianSlider.
        /// </summary>
        /// 
        /// <returns>
        /// The median value of the elements in the MedianSlider,
        /// if the number of elements in the MedianSlider is equal to the slider size.
        /// Otherwise,the last element in the MedianSlider.
        /// </returns>
        public float GetMedianValue()
        {
            if (!SliderFilled)
            {
                return (float) slider.GetLast();
            }
            
            var sortedSlider = slider.GetSorted();
            return (float) sortedSlider[medianIndex];
        }

        /// <summary>
        /// Clears the elements in the MedianSlider, but leaves the slider size the same.
        /// </summary>
        public void Clear()
        {
            slider.Clear();
        }
    }
}