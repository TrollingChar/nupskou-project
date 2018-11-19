using System;
using NupskouProject.Math;


namespace NupskouProject.Hitboxes {

    public class PetalHitbox : Hitbox {


        public XY    Center1, Center2;
        public float Radius;


        public PetalHitbox (XY o1, XY o2, float r) {
            Center1 = o1;
            Center2 = o2;
            Radius  = r;
        }


        public PetalHitbox (XY o, float a, float size) {
            var offset = 3 * size * new XY (a).Rotated90CW ();
            Center1 = o + offset;
            Center2 = o - offset;
            Radius  = 4 * size;
        }


        public static PetalHitbox Beam (XY o, float a, float size) {
            var offset = 63 * size * new XY (a).Rotated90CW ();
            var o1 = o + offset;
            var o2 = o - offset;
            float r = 64 * size;
            return new PetalHitbox (o1, o2, r);
        }


        public override bool Over (Hitbox other) => other.Over (this);


        public override bool Over (CircleHitbox other) {
            bool result = Geom.Overlap (
                new Circle (Center1, Radius),
                new Circle (Center2, Radius),
                other.Circle
            );
 /*           if (result) {
                Console.WriteLine (new Circle (Center1, Radius));
                Console.WriteLine (new Circle (Center2, Radius));
                Console.WriteLine (other.Circle);
                Console.WriteLine ();
            }*/
            return result;
        }


        public override bool Over (PetalHitbox   other) { throw new NotImplementedException (); }
        public override bool Over (PolygonHitbox other) { throw new NotImplementedException (); }


    }

}