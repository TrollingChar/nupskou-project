using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Util;

namespace NupskouProject.Rashka.SmallSpells
{
    public class RashkaOpenerNonspell : StdEntity
    {
        private  XY _p;
        private float _deltaAngle = _.Difficulty.Choose(Mathf.PI/6, Mathf.PI/9, Mathf.PI/12, Mathf.PI/18);
        private float _angle, _angle2;

        public RashkaOpenerNonspell(XY p)
        {
            _p = p;
            _angle = Mathf.PI/2;
            _angle2 = -Mathf.PI/2 + Mathf.PI/36;
        }
        
        protected override void Update(int t)
        { 
            if (t % 60 == 0)
                _p = new XY(_p.X+_.Random.Float(-40,40),_p.Y);
            if (t % 3 == 0){
            var world = _.World;
            _angle = _angle + _deltaAngle;
            _angle2 = _angle2 - _deltaAngle;
            world.Spawn(new LinearPetalBeamBullet(
                _p,
                new XY(_angle).WithLength(2.5f),
                Color.Red,
                Color.Yellow,
                5                
                ));
                if (t >= 60)
            world.Spawn(new LinearPetalBeamBullet(
                _p,
                new XY(_angle2).WithLength(5f),
                Color.Red,
                Color.Yellow,
                5                
            ));
                }
        }
    }
}