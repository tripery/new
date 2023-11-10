public class Vector
{
    private double[] _elements;

    public Vector()
    {
        _elements = new double[3];
    }

    public Vector(int dimension)
    {
        _elements = new double[dimension];
    }

    public Vector(double[] elements)
    {
        _elements = elements;
    }

    public double this[int index]
    {
        get { return _elements[index]; }
        set { _elements[index] = value; }
    }

    public double[] Elements
    {
        get { return _elements; }
    }

    public int Dimension
    {
        get { return _elements.Length; }
    }

    public Vector Add(Vector other)
    {
        var result = new Vector(Dimension);
        for (int i = 0; i < Dimension; i++)
        {
            result[i] = this[i] + other[i];
        }
        return result;
    }

    public Vector Subtract(Vector other)
    {
        var result = new Vector(Dimension);
        for (int i = 0; i < Dimension; i++)
        {
            result[i] = this[i] - other[i];
        }
        return result;
    }

    public double Dot(Vector other)
    {
        double result = 0;
        for (int i = 0; i < Dimension; i++)
        {
            result += this[i] * other[i];
        }
        return result;
    }

    public override string ToString()
    {
        return string.Join(", ", _elements);
    }

    public static Vector operator +(Vector a, Vector b)
    {
        return a.Add(b);
    }

    public static Vector operator -(Vector a, Vector b)
    {
        return a.Subtract(b);
    }

    public static double operator *(Vector a, Vector b)
    {
        return a.Dot(b);
    }

    public static Vector operator *(double c, Vector a)
    {
        var result = new Vector(a.Dimension);
        for (int i = 0; i < a.Dimension; i++)
        {
            result[i] = c * a[i];
        }
        return result;
    }

    public static Vector operator *(Vector a, double c)
    {
        return c * a;
    }
}
