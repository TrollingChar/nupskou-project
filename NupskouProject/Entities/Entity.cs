﻿using System;


namespace NupskouProject {

    public class Entity {

        public bool Despawned { get; private set; }


        public void Despawn () {
            if (Despawned) throw new InvalidOperationException ("object already despawned");
            Despawned = true;
        }


        public virtual void OnSpawn   () {}
        public virtual void OnDespawn () {}
        public virtual void Update () {}
        public virtual void Render () {}


        public Func<Hitbox> BulletHitbox { get; protected set; }

    }


}