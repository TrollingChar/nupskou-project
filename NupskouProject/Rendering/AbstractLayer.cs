using Microsoft.Xna.Framework.Graphics;


namespace NupskouProject.Rendering {

    public abstract class AbstractLayer {


        public abstract void Clear ();

        public abstract void Render (SpriteBatch batch);

    }

}