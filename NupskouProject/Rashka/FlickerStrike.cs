using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;

namespace NupskouProject.Rashka
{
    public class FlickerStrike: Entities.Enemy
    {
        private XY _p;
        private XY _v;


        public FlickerStrike(XY p, XY v)
        {
            HP = 9000;
            _p = p;
            _v = v;
        }
        
        public override void OnStruck(Entity entity)
        {
            HP = HP - 1;
            if (HP == 0) Despawn();
        }

        protected override void Update(int t)
        {
            if (t == 0)
            {
                _.World.Spawn(new SwordLongPetal(
                     new XY(_p.X,_p.Y), 
                     Mathf.PI/2,
                     Color.Red,
                     Color.Black,
                     5
                )
                );
            }
            P = _p;
        }
    }
}