using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;


namespace NupskouProject.Rendering {

    public class Layer : AbstractLayer {

        private List <IRenderable> _renderables = new List <IRenderable> ();


        public override void Clear () {
            _renderables.Clear ();
        }


        public override void Render (SpriteBatch batch) {
            foreach (var r in _renderables) {
                r.Render (batch);
            }
        }


        public void Add (IRenderable r) {
            _renderables.Add (r);
        }


        public void Add (params IRenderable[] arr) {
            _renderables.AddRange (arr);
        }

    }

}