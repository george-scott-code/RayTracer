﻿using System;
using TupleLibrary.Extensions;

namespace TupleLibrary;

public class Tuple
{
    public Tuple(double x, double y, double z, double w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public double X { get; init;}
    public double Y { get; init;}
    public double Z { get; init; }
    public double W { get; set;}

    public bool IsPoint => this.W == 1.0;
    public bool IsVector => this.W == 0.0;

    // TMYK: unary minus operator
    public static Tuple operator -(Tuple a) => new Tuple(-a.X, -a.Y, -a.Z, -a.W);
    public static Tuple operator *(Tuple a, double b) => new Tuple(a.X * b, a.Y * b, a.Z * b, a.W * b);
    public static Tuple operator /(Tuple a, double divisor)
    {
        var factor = 1/ divisor;
        return new Tuple(a.X * factor, a.Y * factor, a.Z * factor, a.W * factor);
    }

    public static Tuple Vector(double x, double y, double z)
    {
        return new Tuple(x, y, z, 0.0);
    }

    public static Tuple Point(double x, double y, double z)
    {
        return new Tuple(x, y, z, 1);
    }
    
    public Tuple Add(Tuple t2)
    {
        return new Tuple(
            this.X + t2.X, 
            this.Y + t2.Y, 
            this.Z + t2.Z, 
            this.W + t2.W
        );
    }

    public Tuple Subtract(Tuple t2)
    {
        return new Tuple(
            this.X - t2.X,
            this.Y - t2.Y,
            this.Z - t2.Z,
            this.W - t2.W
        );
    }

    public double Magnitude()
    {
        return Math.Sqrt(
                (this.X * this.X) +
                (this.Y * this.Y) +
                (this.Z * this.Z) +
                (this.W * this.W));
    }

    // TMYK: Normalization is the process of taking an arbitrary vector and converting it into a vector with magnitude 1
    public Tuple Normalize()
    {
        double magnitude = this.Magnitude();
        return new Tuple(this.X/magnitude, this.Y/magnitude, this.Z/magnitude, this.W/magnitude);
    }

    public double Dot(Tuple t2)
    {
        return  (this.X * t2.X) +
                (this.Y * t2.Y) +
                (this.Z * t2.Z) +
                (this.W * t2.W);
    }

    public Tuple Cross(Tuple b)
    {
        return Tuple.Vector(
            (this.Y * b.Z) - (this.Z * b.Y),
            (this.Z * b.X) - (this.X * b.Z),
            (this.X * b.Y) - (this.Y * b.X)
        );
    }

    public Tuple Reflect(Tuple normal)
    {
        return this.Subtract(normal * 2 * this.Dot(normal));
    }

    public double[] ToArray()
    {
        return new double[4] { this.X, this.Y, this.Z, this.W};
    }

    public override bool Equals(object obj)
    {
        if(obj is null != this is null)
        {
            return false;
        }
        if(obj is null && this is null)
        {
            return true;
        }
        return obj is Tuple tuple &&
               this.X.DEquals(tuple.X) &&
               this.Y.DEquals(tuple.Y) &&
               this.Z.DEquals(tuple.Z) &&
               this.W.DEquals(tuple.W);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z, W);
    }
}
