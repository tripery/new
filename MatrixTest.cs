using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MatrixDemo.Tests
{
    public class MatrixTests
    {
        [Test]
        public void DefaultConstructor_ShouldCreate3x3Matrix()
        {
            Matrix m = new Matrix();
            Assert.AreEqual(3, m.Rows);
            Assert.AreEqual(3, m.Columns);
        }

        [Test]
        public void ConstructorWithIntParameters_ShouldCreateMatrixWithSpecifiedDimensions()
        {
            Matrix m = new Matrix(2, 2);
            Assert.AreEqual(2, m.Rows);
            Assert.AreEqual(2, m.Columns);
        }

        [Test]
        public void ConstructorWithArrayParameter_ShouldCreateMatrixFromArray()
        {
            double[,] data = new double[2, 2] { { 1.0, 2.0 }, { 3.0, 4.0 } };
            Matrix m = new Matrix(data);
            Assert.AreEqual(2, m.Rows);
            Assert.AreEqual(2, m.Columns);
            Assert.AreEqual(1.0, m[0, 0]);
            Assert.AreEqual(2.0, m[0, 1]);
            Assert.AreEqual(3.0, m[1, 0]);
            Assert.AreEqual(4.0, m[1, 1]);
        }

        [Test]
        public void Add_ShouldAddTwoMatricesWithTheSameDimensions()
        {
            double[,] data1 = new double[2, 2] { { 1.0, 2.0 }, { 3.0, 4.0 } };
            double[,] data2 = new double[2, 2] { { 5.0, 6.0 }, { 7.0, 8.0 } };
            Matrix m1 = new Matrix(data1);
            Matrix m2 = new Matrix(data2);
            Matrix result = m1.Add(m2);

            double[,] expectedData = new double[2, 2] { { 6.0, 8.0 }, { 10.0, 12.0 } };
            Matrix expected = new Matrix(expectedData);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Add_ShouldThrowExceptionForMatricesWithDifferentDimensions()
        {
            double[,] data1 = new double[2, 2] { { 1.0, 2.0 }, { 3.0, 4.0 } };
            double[,] data2 = new double[3, 3] { { 5.0, 6.0 }, { 7.0, 8.0 }, { 9.0, 10.0 } };
            Matrix m1 = new Matrix(data1);
            Matrix m2 = new Matrix(data2);
            m1.Add(m2);
        }

        [Test]
        public void Subtract_ShouldSubtractTwoMatricesWithTheSameDimensions()
        {
            double[,] data1 = new double[2, 2] { { 1.0, 2.0 }, { 3.0, 4.0 } };
            double[,] data2 = new double[2, 2] { { 5.0, 6.0 }, { 7.0, 8.0 } };
            Matrix m1 = new Matrix(data1);
            Matrix m2 = new Matrix(data2);
            Matrix result = m1.Subtract(m2);

            double[,] expectedData = new double[2, 2] { { -4.0, -4.0 }, { -4.0, -4.0 } };
            Matrix expected = new Matrix(expectedData);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Subtract_ShouldThrowExceptionForMatricesWithDifferentDimensions()
        {
            double[,] data1 = new double[2, 2] { { 1.0, 2.