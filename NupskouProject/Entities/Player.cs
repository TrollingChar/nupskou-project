using System;
using System.Data.SqlClient;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using NupskouProject.Core;
using NupskouProject.Entities.Bomb;
using NupskouProject.Hitboxes;
using NupskouProject.Math;
using NupskouProject.Rendering;


namespace NupskouProject.Entities {

    public class Player : StdEntity {

        private XY   _p;
        private bool _hitboxVisible;
        private bool _xpressed;
        private bool _invulnerable;
        private bool _death;
        private int _deathWindow;
        private int _invulnerableWindow;
        
        public          XY     P            => _p;
        public override Hitbox PlayerHitbox => new CircleHitbox (_p, 2);
        public override Hitbox GrazeHitbox => new CircleHitbox (_p, 10);

        public XY Position => _p;


        public Player (XY p) {
            _p = p;
        }


        public override void OnStruck (Entity entity) {
            if (_invulnerable == false ){
                if(_death == false) 
                {
                _.Assets.Pjiu.Play(0.25f);
                _death = true;
                _deathWindow = 15;
                    
                }
            }
        }


        protected override void Update (int t) {
            var keyboard = Keyboard.GetState ();
            bool shift = _hitboxVisible = keyboard.IsKeyDown (Keys.LeftShift);

            int x = (keyboard.IsKeyDown (Keys.Right) ? 1 : 0) -
                    (keyboard.IsKeyDown (Keys.Left)  ? 1 : 0);
            int y = (keyboard.IsKeyDown (Keys.Down)  ? 1 : 0) -
                    (keyboard.IsKeyDown (Keys.Up)    ? 1 : 0);

            _p += new XY (x, y) * (shift ? 2 : 4);
            _p.Clamp (World.PlayerBox);

            if (keyboard.IsKeyDown (Keys.Z)) {
                if (shift) ShootShift (t);
                else       Shoot (t);
            }

            if (keyboard.IsKeyDown (Keys.X) && _xpressed == false && _invulnerable == false)
            {
                _xpressed = true;
                if (_.PlayerCharacter == PlayerCharacter.Rashka) _.World.Spawn(new DelayedExplosin());
                _.BombCount--;
                _invulnerable = true;
                _invulnerableWindow = 240;
                Console.WriteLine("Bombs ="+_.BombCount);

            }
            if (keyboard.IsKeyUp (Keys.X) && _xpressed)_xpressed = false;
            if (_death && _deathWindow > 0) _deathWindow--;
            if (_death && _deathWindow == 0) Death();
            if (_invulnerable && _invulnerableWindow > 0) _invulnerableWindow--;
            if (_invulnerable && _invulnerableWindow == 0) _invulnerable = false;


        }


        private void Shoot (int t) {
            if (t % 5 != 0) return;
            foreach (var p in Danmaku.Spray (new XY (0,  30), Mathf.PI / 3, 2))
            foreach (var q in Danmaku.Spray (new XY (0, -30), Mathf.PI / 3, 2)) {
                _.World.Spawn (new PlayerBullet (_p + p, (q - p).WithLength (10)));
            }
        }


        private void ShootShift (int t) {
            Shoot (t);
        }

        private void Death()
        {
            _death = false;
            if (_invulnerable == false){
            _invulnerable = true;
            _invulnerableWindow = 300;
            _p = new XY(250, 500);
            _.LifeCount--;
            Console.WriteLine("Miss, lifes now: "+_.LifeCount);
            }
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