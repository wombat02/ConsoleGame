using System;
namespace ConsoleSurfer
{
    public class Vector2
    {
        public int x, y;

        public Vector2 ()
        {
            x = 0;
            y = 0;
        }

        public Vector2(int X, int Y)
        {
            x = X;
            y = Y;
        }

        static public Vector2 Zero () 
        {
            return new Vector2(0, 0);
        }

        public float Magnitude ()
        {
            return (float)Math.Sqrt(Math.Pow(x, 2f) + Math.Pow(y, 2));
        }

        //opperator overloads
        static public Vector2 operator + (Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }

        static public Vector2 operator - (Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }

        static public Vector2 operator * (Vector2 a, Vector2 b)
        {
            return new Vector2(a.x * b.x, a.y * b.y);
        }

        static public Vector2 operator * (float f, Vector2 v)
        {
            return new Vector2((int)(v.x * f), (int)(v.y * f));
        }

        public override string ToString()
        {
            return ("[" + x + ", " + y + "]");
        }
    }
}
