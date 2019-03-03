using System;
using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Hitboxes;
using NupskouProject.Math;
using Sprite = NupskouProject.Rendering.SpriteInstance;


namespace NupskouProject.Entities {

    public abstract class PetalBullet : Bullet {

        protected XY    P;
        protected XY    V;
        protected float R;
        protected Color MainColor, BorderColor;


        public override Hitbox PlayerDamagerHitbox => new PetalHitbox (P, V.Angle, R);


        public override void OnStrike (Entity entity) => Despawn ();


        public override void Render () {
            _.Renderer.TestForeground.Add (
                new Sprite (_.Assets.Petal)
                {Position = P, Rotation = V.Angle, Color = BorderColor, Scale = new Vector2 (R + 1)},
                new Sprite (_.Assets.Petal)
                {Position = P, Rotation = V.Angle, Color = MainColor, Scale = new Vector2 (R + 0.5f)},
                new Sprite (_.Assets.Petal)
                {Position = P, Rotation = V.Angle, Color = Color.White, Scale = new Vector2 (R)}
            );
        }

    }

}