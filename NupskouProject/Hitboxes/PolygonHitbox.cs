using NupskouProject.Math;


namespace NupskouProject.Hitboxes {

    public class PolygonHitbox : Hitbox {

        public ConvexPolygon Polygon;
        public PolygonHitbox (ConvexPolygon polygon) { Polygon = polygon; }

        public override bool Over (Hitbox other)        => other.Over (this);
        public override bool Over (CircleHitbox other)  => Geom.CircleOverConvexPolygon (other.Circle, Polygon);
        public override bool Over (PetalHitbox other)   { throw new System.NotImplementedException (); }
        public override bool Over (PolygonHitbox other) { throw new System.NotImplementedException (); }

    }

}