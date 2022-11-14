using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Molnar
{
    internal class Matrix
    {
        internal int Width { get; init; }

        internal int Height { get; init; }

        internal int R { get; private set; }

        internal string[,] NdArray { get; set; }

        public Matrix(int width, int height, int r, string[] matrixValues)
        {
            Width = width;
            Height = height;
            R = r;

            NdArray = new string[height, width];

            FillMatrix(matrixValues);

        }

        public void SetR(int value)
        {
            this.R = value;
        }

        public void DrawMatrix()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(NdArray[i, j]);
                }

                Console.WriteLine();
            }
        }

        public void RotateMatrix()
        {
            throw new NotImplementedException(); 
        }

        private void FillMatrix(string[] matrixValues)
        {
            for (int i = 0; i < matrixValues.Count(); i++)
            {
                var row = matrixValues[0].Split();

                for (int j = 0; j < row.Length; j++)
                {
                    NdArray[i, j] = row[j];
                }
            }
        }
    }
}
