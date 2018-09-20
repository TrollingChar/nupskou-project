using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using NupskouProject.Core;
using NupskouProject.Hitboxes;
using NupskouProject.Math;
using NupskouProject.Rendering;


namespace NupskouProject.Entities {

    public class Player : StdEntity {

        private XY   _p;
        private bool _hitboxVisible;

        public          XY     P            => _p;
        public override Hitbox PlayerHitbox => new CircleHitbox (_p, 2);
        public XY Position => _p;


        public Player (XY p) {
            _p = p;
        }


        public override void OnStruck (Entity entity) {
            _.Assets.Pjiu.Play ();
            Despawn ();
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
        }


        private void Shoot (int t) {
            if (t % 5 != 0) return;
            foreach (var p in Danmaku.Spray (new XY (0,  30), Mathf.PI / 3, 4))
            foreach (var q in Danmaku.Spray (new XY (0, -30), Mathf.PI / 3, 4)) {
                _.World.Spawn (new PlayerBullet (_p + p, (q - p).WithLength (10)));
            }
        }


        private void ShootShift (int t) {
            Shoot (t);
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