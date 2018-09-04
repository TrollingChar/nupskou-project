using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;


namespace NupskouProject.Rendering {

    public class Layer {

        private List <SpriteInstance> _sprites = new List <SpriteInstance> ();


        public void Clear () {
            _sprites.Clear ();
        }


        public void Render (SpriteBatch batch) {
            foreach (var sprite in _sprites) {
                sprite.Render (batch);
            }
        }


        public void Add (SpriteInstance sprite) {
            _sprites.Add (sprite);
        }

    }

}