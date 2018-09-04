namespace NupskouProject.Math {

    public static class Geom {

        public static bool CircleOverCircle (Circle c1, Circle c2) {
            float d2 = XY.SqrDistance (c1.Center, c2.Center);
            float rr = c1.Radius + c2.Radius;
            return d2 <= rr;
        }


        public static bool CircleOverBox (Circle c, Box b) {
            var p = c.Center.Clamped (b);
            return XY.SqrDistance (p, c.Center) <= c.Radius * c.Radius;
        }


        public static bool CircleInBox (Circle c, Box b) {
            float r = c.Radius;
            return c.Center.X >= b.Left + r && c.Center.X <= b.Right - r
                && c.Center.Y >= b.Top + r && c.Center.Y <= b.Bottom - r;
        }

        public static bool CircleInVerticalBorders(Circle c, Box b)
        {
            float r = c.Radius;
            return c.Center.X >= b.Left + r && c.Center.X <= b.Right - r;
        }


    }

}