using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Hitboxes;
using NupskouProject.Math;
using Sprite = NupskouProject.Rendering.SpriteInstance;


namespace NupskouProject.Raden.Revolt {

    public class HugeStar : StdEntity {
        
        private static readonly XY V0 = Size * XY.Right;
        private static readonly XY V5 = Size * XY.Left * (1 - Mathf.phi);
        private static readonly XY V2 = V0.Rotated (0.4f * Mathf.PI);
        private static readonly XY V4 = V0.Rotated (0.8f * Mathf.PI);
        private static readonly XY V6 = V0.Rotated (1.2f * Mathf.PI);
        private static readonly XY V8 = V0.Rotated (1.6f * Mathf.PI);
        private static readonly XY V7 = V5.Rotated (0.4f * Mathf.PI);
        private static readonly XY V3 = V5.Rotated (1.6f * Mathf.PI);
        

        public const float Size = 200;

        private XY    _p, _p0, _v;
        private float _a, _a0, _av;


        public HugeStar (XY p0, XY v, float a0, float av) {
            _p = _p0 = p0;
            _a = _a0 = a0;
            _v = v;
            _av = av;
        }


        public override Hitbox PlayerDamagerHitbox => new CompoundHitbox (
            new PolygonHitbox (new ConvexPolygon (_p + V0.Rotated (_a), _p + V4.Rotated (_a), _p + V7.Rotated (_a))),
            new PolygonHitbox (new ConvexPolygon (_p + V0.Rotated (_a), _p + V3.Rotated (_a), _p + V6.Rotated (_a))),
            new PolygonHitbox (new ConvexPolygon (_p + V2.Rotated (_a), _p + V5.Rotated (_a), _p + V8.Rotated (_a)))
        );


        protected override void Update (int t) {
            _p = _p0 + t * _v;
            _a = _a0 + t * _av;
            if (t > 30 && !Geom.CircleOverBox (new Circle (_p, Size + 10), World.Box)) {
                Despawn ();
            }
        }


        protected override void Render (int t) {
            _.Renderer.TestBackground.Add (
                new Sprite (_.Assets.RedStar) {
                    Position = _p,
                    Color = Color.White,
                    Rotation = _a,
                    Scale = new Vector2 (Size)
                }
            );
        }

    }

}