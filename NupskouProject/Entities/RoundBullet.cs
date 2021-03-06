﻿using System;
using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Hitboxes;
using NupskouProject.Math;
using Sprite = NupskouProject.Rendering.SpriteInstance;


namespace NupskouProject.Entities {

    public abstract class RoundBullet : Bullet {

        protected XY    P;
        protected float R;
        protected Color MainColor, BorderColor;
        

        public override Hitbox PlayerDamagerHitbox => new CircleHitbox (P, R);


        public override void OnStrike (Entity entity) => Despawn ();


        public override void Render () {
            _.Renderer.TestForeground.Add (
                new Sprite (_.Assets.Circle) {Position = P, Color = BorderColor, Scale = new Vector2 (R + 1)},
                new Sprite (_.Assets.Circle) {Position = P, Color = MainColor,   Scale = new Vector2 (R + 0.5f)},
                new Sprite (_.Assets.Circle) {Position = P, Color = Color.White, Scale = new Vector2 (R)}
            );
        }

    }

}