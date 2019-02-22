using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;


namespace NupskouProject.Raden.TestSpellcard {

    public class AcceleratingRoundBullet : RoundBullet {

        private readonly XY _p0;
        private readonly XY _v;
        
        
        // грейз саси, вот сделаешь чтобы у базового класса буллет был грейз тогда и писать ниче не придется

        
        public AcceleratingRoundBullet (XY p0, XY v, Color mainColor, Color borderColor, float r = 5) {
            _p0         = p0;
            _v          = v;
            MainColor   = mainColor;
            BorderColor = borderColor;
            R           = r;
        }


        protected override void Update (int t) {
            P = _p0 + t * Mathf.Sqrt(t) * _v;
            if (t > 30 && !Geom.CircleOverBox (new Circle (P, R + 2), World.Box)) {
                Despawn ();
            }
        }

    }

}