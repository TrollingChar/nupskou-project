namespace NupskouProject.Hitboxes {

    public abstract class Hitbox {

        public abstract bool Over (Hitbox other);
        public abstract bool Over (CircleHitbox other);
        public abstract bool Over (PetalHitbox other);

    }


}