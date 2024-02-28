using System;

namespace Source.Common.Utils.Data
{
    [Serializable]
    public struct WeightedData<T>
    {
        public T Value;
        public int Weight;
    }
}