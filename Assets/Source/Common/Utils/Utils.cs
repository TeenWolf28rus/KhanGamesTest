using System.Collections.Generic;
using Source.Common.Utils.Data;
using UnityEngine;

namespace Source.Common.Utils
{
    public static class Utils
    {
        public static T GetRandomIndexBy<T>(List<WeightedData<T>> data)
        {
            var totalWeight = 0;
            foreach (var d in data)
            {
                totalWeight += d.Weight;
            }

            var rndWeightValue = Random.Range(1, totalWeight + 1);

            var processedWeight = 0;
            for (var i = 0; i < data.Count; i++)
            {
                var weight = data[i].Weight;
                processedWeight += weight;
                if (rndWeightValue <= processedWeight)
                {
                    return data[i].Value;
                }
            }

            return default;
        }

        public static bool CheckOutOfBounds<T>(T[,] mat, int row, int col)
        {
            var rows = mat.GetLength(0);
            var columns = mat.GetLength(1);
            return row < 0 || row >= rows || col < 0 || col >= columns;
        }
    }
}