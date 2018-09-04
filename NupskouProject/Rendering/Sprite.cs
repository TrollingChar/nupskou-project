using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace NupskouProject {

    public class Sprite {

        public Texture2D Texture    { get; }
        public Rectangle SourceRect { get; }
        public Vector2   Origin     { get; }
        public float     ScaleCoeff { get; }


        private Sprite (Texture2D texture, Rectangle sourceRect, Vector2 origin, float scaleCoeff) {
            Texture    = texture;
            SourceRect = sourceRect;
            Origin     = origin;
            ScaleCoeff = scaleCoeff;
        }


        public static Sprite Load (Texture2D texture, float pixelsPerUnit) {
            return new Sprite (
                texture,
                texture.Bounds,
                new Vector2 (texture.Width * 0.5f, texture.Height * 0.5f),
                1 / pixelsPerUnit
            );
        }


        public static Sprite Load (Texture2D texture, float pixelsPerUnit, Vector2 origin) {
            return new Sprite (
                texture,
                texture.Bounds,
                origin,
                1 / pixelsPerUnit
            );
        }

    }

}