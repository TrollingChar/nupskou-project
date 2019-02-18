using System;
using NupskouProject.Hitboxes;


namespace NupskouProject.Entities {

    public class Entity {

        public bool Despawned { get; private set; }


        public void Despawn () {
            if (Despawned) throw new InvalidOperationException ("object already despawned");
            Despawned = true;
            OnDespawn ();
        }


        public virtual void OnSpawn   () {}
        public virtual void OnDespawn () {}
        public virtual void Update () {}
        public virtual void Render () {}
        public virtual void OnStrike (Entity entity) {}
        public virtual void OnStruck (Entity entity) {}
        public virtual void OnGrazed (Entity entity) {}
        public virtual void OnGraze (Entity entity) {}



        public virtual Hitbox PlayerHitbox        => null;
        public virtual Hitbox PlayerDamagerHitbox => EnemyHitbox;
        public virtual Hitbox EnemyHitbox         => null;
        public virtual Hitbox EnemyDamagerHitbox  => null;
        public virtual Hitbox GrazeHitbox         => PlayerHitbox;

    }


}