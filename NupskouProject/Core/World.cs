using System;
using System.Collections.Generic;
using NupskouProject.Entities;
using NupskouProject.Hitboxes;
using NupskouProject.Math;
using NupskouProject.Rendering;


namespace NupskouProject.Core {

    public class World {

        public static readonly Box Box       = new Box (30, 25, 470, 575);
        public static readonly Box PlayerBox = new Box (50, 45, 450, 555);

        private List <Entity> _entities      = new List <Entity> ();
        public Player Player { get; private set; }


        public void Update () {
            switch (_.Time) {
                case 0:
                    Spawn (Player = new Player (new XY (250, 500)));
                    break;
                case 120:
                    Spawn (new Clock (i => Spawn (new Enemy (new XY (Box.Left, 100), new XY (3, 0))), 10, 20));
                    break;
                case 420:
                    Spawn (new Clock (i => Spawn (new Enemy (new XY (Box.Right, 150), new XY (-3, 0))), 10, 20));
                    break;
                case 840:
                    Spawn (new Clock (i => Spawn (new Enemy (new XY (Box.Left,  150), new XY ( 3, 0))), 10, 20));
                    Spawn (new Clock (i => Spawn (new Enemy (new XY (Box.Right, 100), new XY (-3, 0))), 10, 20));
                    break;
                case 1200:
                    Spawn (new Enemy (new XY(250, World.Box.Top), new XY(0, 2)));
                    break;
            }
            

            for (int i = 0; i < _entities.Count; i++) {
                var e = _entities[i];
                if (!e.Despawned) e.Update ();
            }
            

            var players        = new List <Pair> ();
            var playerDamagers = new List <Pair> ();
            var enemies        = new List <Pair> ();
            var enemyDamagers  = new List <Pair> ();
            foreach (var e in _entities) {
                Hitbox hb;
                hb = e.PlayerHitbox       ; if (hb != null) players       .Add (new Pair(e, hb));
                hb = e.PlayerDamagerHitbox; if (hb != null) playerDamagers.Add (new Pair(e, hb));
                hb = e.EnemyHitbox        ; if (hb != null) enemies       .Add (new Pair(e, hb));
                hb = e.EnemyDamagerHitbox ; if (hb != null) enemyDamagers. Add (new Pair(e, hb));
            }

            // check hitboxes
            //  you - bullet
            foreach (var p in players) {
                if (p.Entity.Despawned) continue;
                foreach (var pd in playerDamagers) {
                    if (pd.Entity.Despawned) continue;
                    if (p.Hitbox.Over (pd.Hitbox)) {
                        pd.Entity.OnStrike (p.Entity);
                        p.Entity.OnStruck (pd.Entity);
                        break;
                    }
                }
            }

            //  you - enemy
//            if (Player != null && !Player.Despawned) {
//                foreach (var e in _enemies) {
//                    if (e.Despawned || !e.EnemyHitbox ().Over (Player.PlayerHitbox)) continue;
//                    Player.OnImpact (e);
//                    break;
//                }
//            }
            
            //  bomb - enemy
            //  bomb - bullet
            
            //  enemy - your bullet
            foreach (var e in enemies) {
                if (e.Entity.Despawned) continue;
                foreach (var ed in enemyDamagers) {
                    if (ed.Entity.Despawned) continue;
                    if (e.Hitbox.Over (ed.Hitbox)) {
                        ed.Entity.OnStrike (e.Entity);
                        e.Entity.OnStruck (ed.Entity);
                        break;
                    }
                }
            }
            
            //  graze - bullet

            _entities.RemoveAll (e => e.Despawned);
        }


        public void Spawn (Entity e) {
            if (e.Despawned) {
                throw new InvalidOperationException ("can not spawn dead entity");
            }
            _entities.Add (e);
//            if (e.BulletHitbox       != null) _bullets      .Add (e);
//            if (e.EnemyHitbox        != null) _enemies      .Add (e);
//            if (e.PlayerBulletHitbox != null) _playerBullets.Add (e);
//            if (e is Player)                  Player = (Player) e;
            e.OnSpawn ();
        }


        public void Render () {
            _.Renderer.UI.Add (new SpriteInstance (_.Assets.UI));
            foreach (var e in _entities) {
                if (!e.Despawned) e.Render ();
            }
        }
        
        
        private struct Pair {

            public Hitbox Hitbox;
            public Entity Entity;


            public Pair (Hitbox hitbox, Entity entity) {
                Hitbox = hitbox;
                Entity = entity;
            }


            public Pair (Entity entity, Hitbox hitbox) {
                Hitbox = hitbox;
                Entity = entity;
            }

        }

    }


}