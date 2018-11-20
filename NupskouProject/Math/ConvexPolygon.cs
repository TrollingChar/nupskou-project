using System;
using System.Collections.Generic;


namespace NupskouProject.Math {

    public class ConvexPolygon {

        public XY[] Vertices;


        public ConvexPolygon (params XY[] vertices) {
            Vertices = vertices;
        }


        public bool ContainsPoint (XY p) {
            for (int i = 0, j = Vertices.Length - 1; i < Vertices.Length; j = i++) {
                if (XY.Cross (Vertices [i] - Vertices [j], p - Vertices [i]) < 0) return false;
            }
            return true;
        }

    }

}