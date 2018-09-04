namespace NupskouProject.Math {

    public struct Box {

        public float Top;
        public float Left;
        public float Right;
        public float Bottom;


        public Box (float left, float top, float right, float bottom) {
            Top    = top;
            Left   = left;
            Right  = right;
            Bottom = bottom;
        }


        public bool ContainsPoint (XY p) => p.X >= Left && p.X <= Right
                                         && p.Y >= Top && p.Y <= Bottom;

        public XY Center => 0.5f * new XY (Left + Right, Top + Bottom);

    }

}