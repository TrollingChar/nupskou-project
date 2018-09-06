using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Hitboxes;
using NupskouProject.Math;
using NupskouProject.Rendering;


namespace NupskouProject.Rashka.Bullets {

    public class VerticalBounceRoundBullet : RoundBullet {

        private readonly XY _p0;
        private readonly XY _v;


        public VerticalBounceRoundBullet (XY p0, XY v, Color mainColor, Color borderColor, float r) {
            _p0         = p0;
            _v          = v;
            MainColor   = mainColor;
            BorderColor = borderColor;
            R           = r;
        }


        protected override void Update (int t) {
            P = _p0 + t * _v;
            var box = World.Box;
            if (P.Y > box.Bottom + 6) {
                Despawn ();
                return;
            }
            P.X = Mathf.PingPong (P.X - box.Left, box.Right - box.Left) + box.Left;
        }


    }

}