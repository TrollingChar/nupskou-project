using NupskouProject.Math;


namespace NupskouProject.Hitboxes {

    public class PetalHitbox : Hitbox {


        public XY    Center1, Center2;
        public float Radius;


        public PetalHitbox (XY o1, XY o2, float r) {
            Center1 = o1;
            Center2 = o2;
            Radius = r;
        }


        public PetalHitbox (XY o, float a, float size) {
            var offset = 3 * size * new XY(a).Rotated90CW ();
            Center1 = o + offset;
            Center2 = o - offset;
            Radius  = 4 * size;
        }



        public override bool Over (Hitbox other) => other.Over (this);
        public override bool Over (PetalHitbox other)
        {
            {
                throw new System.NotImplementedException();
            }        
        }
        public override bool Over (CircleHitbox other) =>
        Geom.Overlap (
            new Circle (Center1, Radius),
            new Circle (Center2, Radius),
            other.Circle
        );



    }

}