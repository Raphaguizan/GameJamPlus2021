using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Util.Matrix
{
    [Serializable]
    public class Matrix<T>
    {
        public int lines;
        public int colluns;

        [SerializeField]
        private T[,] myMatrix;
        public Matrix(int l, int c)
        {
            lines = l;
            colluns = c;
            myMatrix = new T[lines, colluns];
        }

        public T GetPos(int i, int j)
        {
            return myMatrix[i, j];
        }

        public void SetPos(int i, int j, T value)
        {
            myMatrix[i, j] = value;
        }
    }
}