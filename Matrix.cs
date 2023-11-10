using System;
using System.Data;
using System.Text;
using VectorDemo;

namespace MatrixDemo
{
    public class Matrix
    {
        private double[,] data;

        public Matrix()
        {
            data = new double[3, 3];
        }

        public Matrix(int r, int c)
        {
            data = new double[r, c];
        }

        public Matrix(double[,] data)
        {
            this.data = data;
        }

        public double[,] GetArrayRef
        {
            get { return data; }
        }

        public int Row
        {
            get { return data.GetLength(0); }
        }

        public int Col
        {
            get { return data.GetLength(1); }
        }

        public static Matrix operator *(Matrix m1, double c)
        {
            Matrix result = new Matrix(m1.Row, m1.Col);
            for (int i = 0; i < m1.Row; i++)
            {
                for (int j = 0; j < m1.Col; j++)
                {
                    result.data[i, j] = c * m1.data[i, j];
                }
            }

            return result;
        }

        public static Matrix operator *(double c, Matrix m1)
        {
            return m1 * c;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.Col != m2.Row)
            {
                throw new ArgumentException("The number of columns in the first matrix must equal the number of rows in the second matrix");
            }

            Matrix result = new Matrix(m1.Row, m2.Col);
            for (int i = 0; i < m1.Row; i++)
            {
                for (int j = 0; j < m2.Col; j++)
                {
                    for (int k = 0; k < m1.Col; k++)
                    {
                        result.data[i, j] += m1.data[i, k] * m2.data[k, j];
                    }
                }
            }

            return result;
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.Row != m2.Row || m1.Col != m2.Col)
            {
                throw new ArgumentException("The two matrices must have the same dimensions");
            }

            Matrix result = new Matrix(m1.Row, m1.Col);
            for (int i = 0; i < m1.Row; i++)
            {
                for (int j = 0; j < m1.Col; j++)
                {
                    result.data[i, j] = m1.data[i, j] + m2.data[i, j];
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.Row != m2.Row || m1.Col != m2.Col)
            {
                throw new ArgumentException("The two matrices must have the same dimensions");
            }

            Matrix result = new Matrix(m1.Row, m1.Col);
            for (int i = 0; i < m1.Row; i++)
            {
                for (int j = 0; j < m1.Col; j++)
                {
                    result.data[i, j] = m1.data[i, j] - m2.data[i, j];
                }
            }

            return result;
        }

        public static Vector operator *(Matrix m1, Vector v1)
        {
            if (m1.Col != v1.Length)
            {
                throw new ArgumentException("The number of columns in the matrix must equal the length of the vector");
            }

            Vector result = new Vector(m1.Row);
            for (int i = 0; i <
