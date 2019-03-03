using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;


namespace NupskouProject.Raden.Bullets {

    public class DesignerBullet : RoundBullet {

        private readonly XY _p0, // начальная позиция
                            _p1; // позиция в которой мы должны оказаться
        private XY _pp0,         // позиция игрока в момент t0
                   _pp1;         // последняя известная позиция игрока

        private readonly int   _t1;  // момент в который мы меняем пульку
        private readonly float _t05; // момент в который пулька будет на середине пути


        public DesignerBullet (XY p0, XY p1, int t1, float t05) {
            _p0         = p0;
            _p1         = p1;
            _pp0        = XY.NaN;
            _pp1        = XY.NaN;
            MainColor   = Color.Yellow;
            BorderColor = Color.Orange;
            R           = 5;
            _t1         = t1;
            _t05        = t05;
        }


        protected override void Update (int t) {
            var player = _.Player;
            if (player != null && !player.Despawned) {
                if (_pp0.IsNaN) {
                    _pp0 = player.Position;
                }
                _pp1 = player.Position;
            }
            if (t >= _t1) {
                if (!_pp1.IsNaN) {
                    _.World.Spawn (
                        new LinearPetalBullet (
                            _p1,
                            (_pp1 + _pp1 - _pp0 - _p1).WithLength (3),
                            Color.Yellow,
                            Color.Orange,
                            5
                        )
                    );
                }
                Despawn ();
            }
            P = XY.Lerp (_p1, _p0, Mathf.Pow (0.5f, t / _t05));
        }


    }

}