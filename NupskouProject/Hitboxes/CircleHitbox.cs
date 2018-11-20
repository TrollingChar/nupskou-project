using NupskouProject.Math;


namespace NupskouProject.Hitboxes {

    public class CircleHitbox : Hitbox {

        public Circle Circle;


        public CircleHitbox (float x, float y, float r) {
            Circle = new Circle (x, y, r);
        }


        public CircleHitbox (XY o, float r) {
            Circle = new Circle (o, r);
        }


        public override bool Over (Hitbox other)       => other.Over (this);
        public override bool Over (CircleHitbox other) => Geom.CircleOverCircle (Circle, other.Circle);


        public override bool Over (PetalHitbox other) => Geom.Overlap (
            new Circle (other.Center1, other.Radius),
            new Circle (other.Center2, other.Radius),
            Circle
        );


        public override bool Over (PolygonHitbox other) => Geom.CircleOverConvexPolygon (Circle, other.Polygon);

    }

}