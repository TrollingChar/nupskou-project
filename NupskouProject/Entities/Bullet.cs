using System;
using NupskouProject.Core;


namespace NupskouProject.Entities {

    public class Bullet : StdEntity {

        private bool _grazed;
        // с лазерами можно добавить еще переменную чтобы грейз шел все время


        public override void OnGrazed (Entity entity) {
            if (_grazed) return;
            _grazed = true;
            GameData.Graze++;
        }

    }

}