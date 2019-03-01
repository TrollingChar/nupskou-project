using System.Collections.Generic;
using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Rashka.Bullets;
using NupskouProject.Util;


namespace NupskouProject.Rashka {

    public class ScarletSignBunchOfGrenadesSpawner : StdEntity {

        private XY _p;


        public ScarletSignBunchOfGrenadesSpawner (XY p) {
            _p = p;
        }


        protected override void Update (int t) {
            var world = _.World;

            if (t % 360 != 0) return;

            var list = new List <XY> ();
            for (int i = 0, n = _.Difficulty.Choose (18, 30, 36, 42); i < n; i++) {
                list.Add (Danmaku.FarFrom (list, () => _.Random.Point (World.Box), XY.SqrDistance, 3));
            }

            foreach (var p in list) {
                world.Spawn (
                    new GrenadeBullet (
                        _p,
                        (p - _p) / 150,
                        Color.Red,
                        Color.Red,
                        5f,
                        150
                    )
                );
            }
        }

    }

}