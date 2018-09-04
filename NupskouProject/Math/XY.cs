using System;
using Microsoft.Xna.Framework;


namespace NupskouProject.Math {

    public struct XY {

        public float X, Y;


        public XY (float x, float y) {
            X = x;
            Y = y;
        }


        public XY (float angle) {
            X = Mathf.Cos (angle);
            Y = Mathf.Sin (angle);
        }


        public static XY operator + (XY a)          => new XY (+a.X,      +a.Y);
        public static XY operator - (XY a)          => new XY (-a.X,      -a.Y);
        public static XY operator + (XY a, XY b)    => new XY (a.X + b.X, a.Y + b.Y);
        public static XY operator - (XY a, XY b)    => new XY (a.X - b.X, a.Y - b.Y);
        public static XY operator * (float d, XY a) => new XY (a.X * d,   a.Y * d);
        public static XY operator * (XY a, float d) => new XY (a.X * d,   a.Y * d);
        public static XY operator / (XY a, float d) => new XY (a.X / d,   a.Y / d);
        public static bool operator != (XY a, XY b) => a.X != b.X || a.Y != b.Y;
        public static bool operator == (XY a, XY b) => a.X == b.X && a.Y == b.Y;


        public static implicit operator XY (Vector2 v) => new XY (v.X, v.Y);
        public static implicit operator XY (Point v)   => new XY (v.X, v.Y);
        public static implicit operator Vector2 (XY v) => new Vector2 (v.X, v.Y);


        public static XY Zero  => new XY ( 0f,  0f);
        public static XY One   => new XY ( 1f,  1f);
        public static XY Down  => new XY ( 0f,  1f);
        public static XY Left  => new XY (-1f,  0f);
        public static XY Up    => new XY ( 0f, -1f);
        public static XY Right => new XY ( 1f,  0f);
        public static XY NaN   => new XY (float.NaN, float.NaN);


        public bool IsNaN => float.IsNaN (X); // dont check Y


        public float Length {
            get { return Mathf.Sqrt (X * X + Y * Y); }
            set {
                float l = Length;
                if (l > 0) {
                    l =  value / l;
                    X *= l;
                    Y *= l;
                }
                else Y = l;
            }
        }


        public float SqrLength => X * X + Y * Y;


        public float Angle {
            get { return Mathf.Atan2 (Y, X); }
            set {
                float l = Length;
                X = l * Mathf.Cos (value);
                Y = l * Mathf.Sin (value);
            }
        }


        public XY WithX (float x) => new XY (x, Y);
        public XY WithY (float y) => new XY (X, y);


        public XY WithLength (float l) {
            var v = this;
            v.Length = l;
            return v;
        }


        [Obsolete]
        public void ClampLength (float l) {
            float len = Length;
            if (l >= len) return;
            l /= len;
            X *= l;
            Y *= l;
        }


        [Obsolete]
        public XY WithLengthClamped (float l) {
            var v = this;
            v.ClampLength (l);
            return v;
        }


        [Obsolete]
        public void ReduceLength (float delta) {
            float l = SqrLength;
            if (l > delta * delta) {
                Length -= delta;
            }
            else {
                X = Y = 0;
            }
        }


        [Obsolete]
        public XY WithLengthReduced (float delta) {
            var v = this;
            v.ReduceLength (delta);
            return v;
        }


        public XY WithAngle (float a) {
            var v = this;
            v.Angle = a;
            return v;
        }


        [Obsolete] public static XY Polar (float angle) => new XY (angle);


        public static float Dot (XY a, XY b)                => a.X * b.X + a.Y * b.Y;
        public static float Cross (XY a, XY b)              => a.X * b.Y - a.Y * b.X;
        public static float Distance (XY from, XY to)       => (to - @from).Length;
        public static float SqrDistance (XY from, XY to)    => (to - from).SqrLength;
        public static float DirectionAngle (XY from, XY to) => (to - from).Angle;


        public void Normalize () {
            float l = Length;
            if (l > 0f) {
                X /= l;
                Y /= l;
            }
        }


        public XY Normalized {
            get {
                var v = this;
                v.Normalize ();
                return v;
            }
        }


        public void Rotate (float angle) => this = Rotated (angle);
        public void Rotate90CW ()        => this = Rotated90CW ();
        public void Rotate90CCW ()       => this = Rotated90CCW ();


        public XY Rotated (float angle) {
            float sin = Mathf.Sin (angle);
            float cos = Mathf.Cos (angle);
            return new XY (X * cos - Y * sin, X * sin + Y * cos);
        }


        public XY Rotated90CW ()  => new XY (Y, -X);
        public XY Rotated90CCW () => new XY (-Y, X);


        public void Clamp (Box b) => this = Clamped (b);


        public XY Clamped (Box b) => new XY (
            Mathf.Clamp (X, b.Left, b.Right),
            Mathf.Clamp (Y, b.Top,  b.Bottom)
        );


        public static XY Lerp (XY pos0, XY pos1, float t) => new XY (
            pos0.X + (pos1.X - pos0.X) * t,
            pos0.Y + (pos1.Y - pos0.Y) * t
        );


        public override string ToString ()              => $"({X:F1}, {Y:F1})";
        public          string ToString (string format) => $"({X.ToString (format)}, {Y.ToString (format)})";
        public override bool   Equals (object obj)      => obj is XY && this == (XY) obj;
        public override int    GetHashCode ()           => X.GetHashCode () ^ Y.GetHashCode () << 2;

    }

}