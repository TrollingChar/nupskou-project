using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace NupskouProject.Rendering {

    public class SpriteInstance : IRenderable {

        private readonly Texture2D _texture;
        public           Vector2   Position;
        private readonly Rectangle _sourceRectangle;
        public           Color     Color;
        public           float     Rotation;
        private readonly Vector2   _origin;
        public           Vector2   Scale;
        private readonly float     _scaleCoeff;


        public SpriteInstance (Sprite sprite) {
            _texture         = sprite.Texture;
            _sourceRectangle = sprite.SourceRect;
            Color            = Color.White;
            _origin          = sprite.Origin;
            Scale            = Vector2.One;
            _scaleCoeff      = sprite.ScaleCoeff;
        }


        public void Render (SpriteBatch spriteBatch) {
            spriteBatch.Draw (
                _texture,
                Position,
                _sourceRectangle,
                Color,
                Rotation,
                _origin,
                Scale * _scaleCoeff,
                SpriteEffects.None,
                0
            );
        }

    }

}