using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;


namespace NupskouProject.Raden.Airstrike {

    public class Bomber : LinearPetalBullet {

        private const int Cooldown = 6; // нормал, на ИЗИ МОДО будет ⑨ а может лучше просто спавнить больше самолетов

        private XY _bv0;
        private int _t;


        protected Bomber (XY p0, XY v) : base (p0, v, Color.Lime, Color.Green, 10) {
            _bv0 = v * 0.15f;
            _t = _.Random.Next (Cooldown);
        }


        public static Bomber FromLeft  (float y) => new Bomber (new XY (World.Box.Left  - 10, y), 5 * XY.Right);
        public static Bomber FromRight (float y) => new Bomber (new XY (World.Box.Right + 10, y), 5 * XY.Left);


        protected override void Update (int t) {
            base.Update (t);
            if (t % Cooldown == _t) {
                _.World.Spawn (new Bomb (P, _bv0));
                //if (_.Difficulty < Difficulty.Hard) _.World.Spawn (new Bomb       (P, _bv0));
                //else                                _.World.Spawn (new NapalmBomb (P, _bv0));
            }
        }

    }

}