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

    }

}