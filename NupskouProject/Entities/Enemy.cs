using System;
using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Hitboxes;
using NupskouProject.Math;
using NupskouProject.Rendering;


namespace NupskouProject.Entities {

    public class Enemy : StdEntity {

        public int HP;
        public XY P { get; protected set; }


        public override Hitbox EnemyHitbox => new CircleHitbox (P, 10);


        public override void OnStruck (Entity entity) {
            if (--HP == 0) Despawn ();
        }


        public override void Render () { 
            _.Renderer.TestForeground.Add (
                new SpriteInstance (_.Assets.Circle) {Position = P, Color = Color.Lime, Scale = new Vector2 (10)}
            );
        }

    }

}