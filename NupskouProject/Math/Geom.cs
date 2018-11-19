using System.Security.Cryptography;


namespace NupskouProject.Math {

    public static class Geom {

        public static bool CircleOverCircle (Circle c1, Circle c2) {
            float d2 = XY.SqrDistance (c1.Center, c2.Center);
            float rr = c1.Radius + c2.Radius;
            return d2 <= rr * rr;
        }

        public static bool CircleInCircle (Circle c1, Circle c2) {
            // какой круг в каком, это надо сравнить радиусы, здесь мы это не считаем
            float d2 = XY.SqrDistance (c1.Center, c2.Center);
            float rr = c1.Radius - c2.Radius;
            return d2 <= rr * rr;
        }


        public static bool CircleOverBox (Circle c, Box b) {
            var p = c.Center.Clamped (b);
            return XY.SqrDistance (p, c.Center) <= c.Radius * c.Radius;
        }


        public static bool CircleInBox (Circle c, Box b) {
            float r = c.Radius;
            return c.Center.X >= b.Left + r && c.Center.X <= b.Right  - r
                && c.Center.Y >= b.Top  + r && c.Center.Y <= b.Bottom - r;
        }


        public static float DistancePointToLine (XY p, XY a, XY b) {
            float s = XY.Cross (p - a, p - b);
            return System.Math.Abs (s / p.Length);
        }


        public static bool Overlap (Circle c1, Circle c2, Circle c3) {
            if (!CircleOverCircle (c1, c2)) return false;
            if (CircleInCircle    (c1, c2)) return CircleOverCircle (c1.Radius < c2.Radius ? c1 : c2, c3);

            float r1 = c1.Radius, r2 = c2.Radius, r3 = c3.Radius;
            XY    o1 = c1.Center, o2 = c2.Center, o3 = c3.Center;
            float rr1 = r1 * r1;
            float dist = XY.Distance (o1, o2);
            float a = 0.5f * ((rr1 - r2*r2) / dist + dist);
            float h = Mathf.Sqrt (rr1 - a*a);
            var i = (o2 - o1) / dist;
            var o = o1 + i * a;
            i.Rotate90CCW ();
            var i1 = o + i * h;
            var i2 = o - i * h;

            if (XY.Cross (i1 - o1, o3 - o1) >= 0 && XY.Cross (o3 - o2, i1 - o2) >= 0) {
                return XY.SqrDistance (o3, i1) <= r3 * r3;
            }
            if (XY.Cross (i2 - o2, o3 - o2) >= 0 && XY.Cross (o3 - o1, i2 - o1) >= 0) {
                return XY.SqrDistance (o3, i2) <= r3 * r3;
            }
            return CircleOverCircle (c1, c3) && CircleOverCircle (c2, c3);
        }


        public static bool CircleOverConvexPolygon (Circle c, ConvexPolygon p) {
            if (p.ContainsPoint (c.Center)) return true;
            float r2 = c.Radius * c.Radius;
            for (int i = 0, j = p.Vertices.Length - 1; i < p.Vertices.Length; j = i++) {
                if (XY.SqrDistance (c.Center, p.Vertices [i]) < r2) return true;
                if (
                    XY.Dot (c.Center - p.Vertices [i], p.Vertices [j] - p.Vertices [i]) >= 0 &&
                    XY.Dot (c.Center - p.Vertices [j], p.Vertices [i] - p.Vertices [j]) >= 0 &&
                    DistancePointToLine (c.Center, p.Vertices [i], p.Vertices [j]) < c.Radius
                ) return true;
            }
            return false;
        }

    }

}