using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Util;


namespace NupskouProject.Raden.Airstrike {

    public class Airstrike : StdEntity {

        protected override void Update (int t) {
//            float y = _.Difficulty < Difficulty.Hard ? 
//                Mathf.LerpUnclamped (World.Box.Top, World.Box.Bottom, 0.33f * _.Random.Float ()) :
//                World.Box.Top;
    
            int cooldown = _.Difficulty.Choose (60, 40, 60, 40);

            if (_.Difficulty < Difficulty.Hard) {
                float y = Mathf.LerpUnclamped (World.Box.Top, World.Box.Bottom, 0.3f * _.Random.Float ());
                if      (t % (cooldown * 2) == 0)        _.World.Spawn (Bomber.FromLeft  (y));
                else if (t % (cooldown * 2) == cooldown) _.World.Spawn (Bomber.FromRight (y));
            }
            else {
                float y;
                y = Mathf.LerpUnclamped (World.Box.Top, World.Box.Bottom, 0.1f * _.Random.Float ());
                if      (t % (cooldown * 2) == 0)        _.World.Spawn (Bomber.FromLeft  (y));
                else if (t % (cooldown * 2) == cooldown) _.World.Spawn (Bomber.FromRight (y));
                y = Mathf.LerpUnclamped (World.Box.Top, World.Box.Bottom, 0.1f * _.Random.Float () + 0.2f);
                if      (t % (cooldown * 2) == 0)        _.World.Spawn (Bomber.FromLeft  (y));
                else if (t % (cooldown * 2) == cooldown) _.World.Spawn (Bomber.FromRight (y));
            }
        }

    }

}