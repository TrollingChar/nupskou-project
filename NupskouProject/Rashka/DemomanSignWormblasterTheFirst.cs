using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Rashka.Bullets;
using NupskouProject.Util;

namespace NupskouProject.Rashka
{
    public class DemomanSignWormblasterTheFirst : StdEntity
    {
        private float _r;
        private float _radius = 35;
        private  XY _p;
        private float _angle = -Mathf.PI / 2;
        private float _deltaAngle = Mathf.PI / 150;

        public DemomanSignWormblasterTheFirst(XY p)
        {
            _p = p;
            _r = XY.Distance(_p, _.Player.Position);
        }

        protected override void Update(int t)
        {
            if (_r > XY.Distance(_p, _.Player.Position))
                _r = _r - 0.9f;
            else
                _r = _r + 0.9f;
            var world = _.World;
            if (t % 6 == 0)
                world.Spawn(new Blast(new XY(_p.X + _r * Mathf.Cos(_angle), _p.Y + _r * Mathf.Sin(_angle)),
                    _radius,
                    150));
            if (t % 18 == 0)
            {
                foreach (var v in Danmaku.Cloud(1f, 5))
                {
                    world.Spawn(new LinearRoundBullet(
                            new XY(_p.X + _r * Mathf.Cos(_angle), _p.Y + _r * Mathf.Sin(_angle)),
                            v,
                            Color.Yellow,
                            Color.Red,
                            5
                        )
                    );
                }

            }
            _angle = _angle + _deltaAngle;

        }
    }
}