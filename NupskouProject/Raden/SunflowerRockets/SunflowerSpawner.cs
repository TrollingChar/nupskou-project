using System;
using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Util;


namespace NupskouProject.Raden.SunflowerRockets {

    public class SunflowerSpawner : StdEntity {

        private XY _p;
        private float _a0;
        private int _t;


        public SunflowerSpawner (XY p, int t) {
            _p = p;
            _a0 = _.Random.Angle ();
            _t = t;
        }

/*
        public override void OnSpawn () {
            base.OnSpawn ();
            foreach (var v in Danmaku.Ring (2 * new XY(_.Random.Angle ()), 24)) {
                _.World.Spawn (new LinearPetalBeamBullet (_p, v, Color.Yellow, Color.Yellow, 5));
            }
        }
*/

        protected override void Update (int t) {
            if (t == _t) {
                Despawn ();
                return;
            }
            foreach (var v in Danmaku.Ring (new XY (_a0 + t * Mathf.phiAngle / 2), 2)) {
                _.World.Spawn (new SunflowerSeed (_p, v, 10f, 3f, _t - t));
            }
//            _.World.Spawn (new SunflowerSeed (_p, new XY (_a0 + t * Mathf.phiAngle), 10f, 3f, _t - t));
        }

    }

}