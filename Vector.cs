using System;

public class Vector
{
    private double[] data;

    public Vector()
    {
        data = new double[3];
    }

    public Vector(int N)
    {
        data = new double[N];
    }

    public Vector(double[] d)
    {
        data = d;
    }

    public Vector Add(Vector o)
    {
        if (data.Length != o.data.Length)
        {
            throw new ArgumentException("Vectors must have the same length");
        }

        Vector result = new Vector(data.Length);
        for (int i = 0; i < data.Length; i++)
        {
            result.data[i] = data[i] + o.data[i];
        }

        return result;
    }

    public Vector Sub(Vector o)
    {
        if (data.Length != o.data.Length)
        {
            throw new ArgumentException("Vectors must have the same length");
        }

        Vector result = new Vector(data.Length);
        for (int i = 0; i < data.Length; i++)
        {
            result.data[i] = data[i] - o.data[i];
        }

        return result;
    }

    public double Scalar(Vector o)
    {
        if (data.Length != o.data.Length)
        {
            throw new ArgumentException("Vectors must have the same length");
        }

        double result = 0;
        for (int i = 0; i < data.Length; i++)
        {
            result += data[i] * o.data[i];
        }

        return result;
    }

    public static Vector operator *(Vector v, double c)
    {
        Vector result = new Vector(v.data.Length);
        for (int i = 0; i < v.data.Length; i++)
        {
            result.data[i] = v.data[i] * c;
        }

        return result;
    }

    public static Vector operator *(double c, Vector v)
    {
        return v * c;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", data)}]";
    }

    public int Length
    {
        get { return data.Length; }
    }

    public double[] GetArrayRef
    {
        get { return data; }
    }

    public double this[int index]
    {
        get { return data[index]; }
        set { data[index] = value; }
    }
}
