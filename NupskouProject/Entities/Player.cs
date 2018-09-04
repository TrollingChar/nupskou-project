﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using NupskouProject.Core;
using NupskouProject.Hitboxes;
using NupskouProject.Math;
using NupskouProject.Rendering;


namespace NupskouProject.Entities {

    public class Player : Entity {

        private XY   _p;
        private bool _hitboxVisible;


        public Player (XY p) {
            _p = p;
        }

        
        public Hitbox PlayerHB => new CircleHitbox (_p, 2);


        public void TakeBulletHit (Entity bullet) {
            _.Assets.Pjiu.Play ();
            Despawn ();
            bullet.Despawn ();
        }


        public override void Update () {
            var keyboard = Keyboard.GetState ();
            bool shift = _hitboxVisible = keyboard.IsKeyDown (Keys.LeftShift);

            int x = (keyboard.IsKeyDown (Keys.Right) ? 1 : 0) -
                    (keyboard.IsKeyDown (Keys.Left)  ? 1 : 0);
            int y = (keyboard.IsKeyDown (Keys.Down)  ? 1 : 0) -
                    (keyboard.IsKeyDown (Keys.Up)    ? 1 : 0);

            _p += new XY (x, y) * (shift ? 2 : 4);
            _p.Clamp (World.PlayerBox);

            // if z pressed, shoot (shift - 2nd mode)
            /* if (keyboard.IsKeyDown (Keys.Z)) {
                if (shift) {
                    ShootShift ();
                }
                else {
                    Shoot ();
                }*/
        }


        public override void Render () {
            _.Renderer.Player.Add (
                new SpriteInstance (_.Assets.Circle) {Position = _p, Color = Color.Red, Scale = new Vector2 (10)}
            );
            if (!_hitboxVisible) return;
            _.Renderer.Hitbox.Add (
                new SpriteInstance (_.Assets.Circle) {Position = _p, Color = Color.Maroon, Scale = new Vector2 (3)}
            );
            _.Renderer.Hitbox.Add (
                new SpriteInstance (_.Assets.Circle) {Position = _p, Color = Color.White, Scale = new Vector2 (2)}
            );
        }

    }

}