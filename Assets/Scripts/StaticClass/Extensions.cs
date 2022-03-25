using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game.Util
{
    public static class Extensions
    {
        public static float Remap(this float s, float a1, float a2, float b1, float b2)
        {
             return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
        }

        public static T GetRandom<T>(this List<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }

        public static T GetRandomExcept<T>(this List<T> list, T unique)
        {
            if (list.Count == 1)
                return unique;

            T result = list[Random.Range(0, list.Count)];
            if (result.Equals(unique))
            {
                result = GetRandomExcept(list, unique);
            }
            return result;
        }
    }
}

