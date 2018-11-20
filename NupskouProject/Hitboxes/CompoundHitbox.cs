using System.Linq;


namespace NupskouProject.Hitboxes {

    public class CompoundHitbox : Hitbox {

        public Hitbox [] Hitboxes;


        public CompoundHitbox (params Hitbox[] hitboxes) {
            Hitboxes = hitboxes;
        }

        
        public override bool Over (Hitbox        other) => Hitboxes.Any (other.Over);
        public override bool Over (CircleHitbox  other) => Hitboxes.Any (other.Over);
        public override bool Over (PetalHitbox   other) => Hitboxes.Any (other.Over);
        public override bool Over (PolygonHitbox other) => Hitboxes.Any (other.Over);

    }

}