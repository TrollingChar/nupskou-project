using System;
using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Hitboxes;
using NupskouProject.Math;
using Sprite = NupskouProject.Rendering.SpriteInstance;


namespace NupskouProject.Entities {

    public abstract class PetalBeamBullet : StdEntity {

        protected XY    P;
        protected XY    V;
        protected float R;
        protected Color MainColor, BorderColor;
        protected bool  grazed = false;
        public override void OnGrazed(Entity entity)
        {
            if (grazed == false)
            {
                grazed = true;
                _.Graze++;
                Console.WriteLine("Graze ="+_.Graze);

            }
        }


        public override Hitbox PlayerDamagerHitbox => PetalHitbox.Beam (P, V.Angle, R);


//        public override void OnStrike (Entity entity) => Despawn ();


        public override void Render () {
            float angle = V.Angle;
            _.Renderer.TestForeground.Add (
                new Sprite (_.Assets.PetalBeam) {Position = P, Rotation = angle, Color = BorderColor, Scale = new Vector2 (R + 1f)},
                new Sprite (_.Assets.PetalBeam) {Position = P, Rotation = angle, Color = MainColor,   Scale = new Vector2 (R + 0.5f)},
                new Sprite (_.Assets.PetalBeam) {Position = P, Rotation = angle, Color = Color.White, Scale = new Vector2 (R)}
            );
        }

    }

}