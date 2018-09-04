
using NupskouProject.Core;
using NupskouProject.Util;


namespace NupskouProject.Math {

    public static class Danmaku {

        public static XY[] Ring (XY dir, int bullets) {
            float step = Mathf.PI * 2 / bullets;
            var   arr  = new XY [bullets];
            for (int i = 0; i < bullets; i++) {
                arr[i] = dir.Rotated (step * i);
            }
            return arr;
        }


        public static XY[] Cloud (float radius, int bullets) {
            var arr = new XY [bullets];
            for (int i = 0; i < bullets; i++) {
                arr[i] = Cloud1 (radius);
            }
            return arr;
        }


        public static XY Cloud1 (float radius) {
            var   random = _.Random;
            float f      = 1 - random.Float () * random.Float () * random.Float ();
            return f * radius * new XY (random.Angle ());
        }


        public static XY[] Spray (XY dir, float cone, int bullets) {
            if (bullets == 1) return new[] {dir};

            var   arr  = new XY [bullets];
            float step = cone / (bullets - 1);
            float half = cone * 0.5f;
            for (int i = 0; i < bullets; i++) {
                arr[i] = dir.Rotated (step * i - half);
            }
            return arr;
        }


        public static XY[] Line (XY dir, float minCoeff, float maxCoeff, int bullets) {
            if (bullets == 1) {
                return new[] {0.5f * (minCoeff + maxCoeff) * dir};
            }
            var   arr = new XY [bullets];
            float div = bullets - 1;
            for (int i = 0; i < bullets; i++) {
                arr[i] = dir * Mathf.Lerp (minCoeff, maxCoeff, i / div);
            }
            return arr;
        }


        public static XY[] Shotgun (XY dir, float cone, float minCoeff, float maxCoeff, int bullets) {
            var arr = new XY [bullets];
            for (int i = 0; i < bullets; i++) {
                arr[i] = Shotgun1 (dir, cone, minCoeff, maxCoeff);
            }
            return arr;
        }


        public static XY Shotgun1 (XY dir, float cone, float minCoeff, float maxCoeff) {
            dir.Rotate (cone * _.Random.SignedFloat ());
            return dir * Mathf.Lerp (minCoeff, maxCoeff, _.Random.Float ());
        }

    }

}