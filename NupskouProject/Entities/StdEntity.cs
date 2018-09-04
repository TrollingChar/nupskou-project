using NupskouProject.Core;


namespace NupskouProject.Entities {

    public class StdEntity : Entity {

        public int T0;


        public override void OnSpawn () => T0 = _.Time;
        public override void Update  () => Update (_.Time - T0);
        public override void Render  () => Render (_.Time - T0);


        protected virtual void Update (int t) {}
        protected virtual void Render (int t) {}

    }

}