using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NupskouProject.Rendering
{
    public class Text {

        public Texture2D Texture    { get; }
        public Rectangle SourceRect { get; }
        public Vector2   Origin     { get; }
        public float     ScaleCoeff { get; }


        private Text (Texture2D texture, Rectangle sourceRect, Vector2 origin, float scaleCoeff) {
            Texture    = texture;
            SourceRect = sourceRect;
            Origin     = origin;
            ScaleCoeff = scaleCoeff;
        }


        public static Text Load (Texture2D texture, float pixelsPerUnit) {
            return new Text (
                texture,
                texture.Bounds,
                new Vector2 (texture.Width * 0.5f, texture.Height * 0.5f),
                1 / pixelsPerUnit
            );
        }


        public static Text Load (Texture2D texture, float pixelsPerUnit, Vector2 origin) {
            return new Text (
                texture,
                texture.Bounds,
                origin,
                1 / pixelsPerUnit
            );
        }

    }
}