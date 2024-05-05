using System;
using System.Data.Common;

namespace Task2.Library
{
    public class FoxMatrix
    {
        private readonly int _linesCount;
        private readonly int _columnCount;
        private int[,] _matrix;
        private readonly Random _rnd = new();

        public FoxMatrix(int line, int column)
        {
            if ((line < 1) || (column < 1))
            {
                throw new Exception("Wrong matrix parameters");
            }
            this._linesCount = line;
            this._columnCount = column;
            _matrix = new int[line, column];
            this.FillRandom();
        }

        public FoxMatrix(int linesCount, int columnCount, int[,] matrix) : this(linesCount, columnCount)
        {
            _matrix = matrix;
        }

        public int LinesCount
        {
            get
            {
                return _linesCount;
            }
        }

        public int ColumnCount
        {
            get
            {
                return _columnCount;
            }
        }


        public int this[int i, int j]
        {
            get
            {
                return _matrix[i, j];
            }
        }

        private void FillRandom()
        {
            for (int i = 0; i < _linesCount; i++)
            {
                for (int j = 0; j < _columnCount; j++)
                {
                    _matrix[i, j] = _rnd.Next(101);
                }
            }
        }

        public int GetMatrixTrace()
        {
            int result = 0;
            int minD = _columnCount > _linesCount ? _linesCount : _columnCount;
            for (int i = 0; i < minD; i++)
            {
                result += _matrix[i, i];
            }

            return result;
        }

        public int[] GetSnailShells()
        {
            int iMin = 0, iMax = _linesCount - 1;
            int jMin = 0, jMax = _columnCount - 1, k = 0;
            int[] snailShells = new int[_linesCount * _columnCount];

            while (iMin <= iMax && jMin <= jMax)
            {
                for (int i = jMin; i <= jMax; i++)
                {
                    snailShells[k] = this[iMin, i];
                    k++;
                }
                iMin++;

                for (int i = iMin; i <= iMax; i++)
                {
                    snailShells[k] = this[i, jMax];
                    k++;
                }
                jMax--;

                if (iMin <= iMax)
                {
                    for (int i = jMax; i >= jMin; i--)
                    {
                        snailShells[k] = this[iMax, i];
                        k++;
                    }
                    iMax--;
                }
                if (jMin <= jMax)
                {
                    for (int i = iMax; i >= iMin; i--)
                    {
                        snailShells[k] = this[i, jMin];
                        k++;
                    }
                    jMin++;
                }
            }

            return snailShells;
        }
    }
}