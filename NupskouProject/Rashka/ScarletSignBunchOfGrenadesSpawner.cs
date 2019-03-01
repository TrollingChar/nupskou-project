using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Rashka.Bullets;
using NupskouProject.Util;


namespace NupskouProject.Rashka {

    public class ScarletSignBunchOfGrenadesSpawner : StdEntity {

        private int   N          = _.Difficulty.Choose (18, 30, 36, 42);
        private XY [] coordinate = new XY[_.Difficulty.Choose (18, 30, 36, 42)];
        private XY    _p;


        public ScarletSignBunchOfGrenadesSpawner (XY p) {
            _p = p;
        }


        protected override void Update (int t) {
            var world = _.World;
            
            if (t % 360 != 0) return;

            for (int i = 0; i < N; i++) {
                coordinate [i] = new XY (-9000, -9000);
            }

            for (int i = 0; i < N; i++)
            for (int attempt = 0; attempt < 10; attempt++) {
                var a = _.Random.Point (World.Box);
                if (Check (a, i)) break;
            }

            for (int j = 0; j < N; j++) {
                world.Spawn (
                    new GrenadeBullet (
                        _p,
                        (coordinate [j] - _p) / 150,
                        Color.Red,
                        Color.Red,
                        5f,
                        150
                    )
                );
            }

        }


        private bool Check (XY a, int index) {
            for (int i = 0; i < N; i++) {
                if (XY.SqrDistance (a, coordinate [i]) < 100) return false;
            }
            if (a.Y < World.PlayerBox.Bottom * 0.95) {
                coordinate [index] = a;
            }
            return true;
        }

    }

}