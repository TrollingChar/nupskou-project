using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Util;


namespace NupskouProject.Raden.Airstrike {

    public class Airstrike : StdEntity {

        protected override void Update (int t) {
            float y = Mathf.LerpUnclamped (World.Box.Top, World.Box.Bottom, 0.33f * _.Random.Float ());
            switch (t % 60) {
                case 0:
                    _.World.Spawn (Bomber.FromLeft (y));
                    break;
                case 30:
                    _.World.Spawn (Bomber.FromRight (y));
                    break;
            }
        }

    }

}