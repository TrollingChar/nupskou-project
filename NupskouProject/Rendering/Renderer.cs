using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NupskouProject.Core;
using NupskouProject.Math;


namespace NupskouProject.Rendering {

    public class Renderer {

        public Layer            Player, TestBackground, TestForeground, Hitbox, UI;
        public TextLayer        Text,   UIText;
        public AbstractLayer [] Layers;


        public Renderer () {
            Layers = new [] {
                Player         = new Layer (),
                TestBackground = new Layer (),
                TestForeground = new Layer (),
                Hitbox         = new Layer (),
                UI             = new Layer (),
//                UItext         = new Layer (),
            };
        }


        public void Begin () {
            foreach (var layer in Layers) {
                layer.Clear ();
            }
        }


        public void End (SpriteBatch batch) {
            batch.Begin ();
            batch.DrawString (
                _.Assets.InterfaceText,
                "ФЕДЯ ЛОХ!\nкак текст крутить",
                new Vector2 (300),
                Color.Red,
                -Mathf.phiAngle,
                Vector2.Zero, 
                1,
                SpriteEffects.None,
                0
            );
            foreach (var layer in Layers) {
                layer.Render (batch);
            }
            batch.End ();
        }

    }


}