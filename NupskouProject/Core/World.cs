using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using NupskouProject.Entities;
using NupskouProject.Hitboxes;
using NupskouProject.Math;
using NupskouProject.Rashka;
using NupskouProject.Rendering;
using NupskouProject.Stages;

namespace NupskouProject.Core {

    public class World {

        public static readonly Box Box       = new Box (30, 25, 470, 575);
        public static readonly Box PlayerBox = new Box (50, 45, 450, 555);

        private List <Entity> _entities = new List <Entity> ();
        public Player Player { get; private set; }


        public void Update () {
            if (_.Time == 0) {
                Spawn (_.Player = new Player (new XY (250, 500)));
                Spawn(new FlickerStrike(new XY(100, 100), new XY(1, 1)));
//                  Spawn(new LinearRoundBullet(new XY(275, 450),new XY(0,0), Color.Red,Color.Red,5 ));
//                  Spawn (new Stage1 ());
//                Spawn(new DemomanSignDelayedExplosionSpawner());
//                Spawn(new DemomanSignWormblasterTheFirst(World.Box.Center));
//                Spawn(new LinearPetalBeamBuszzllet(Box.Center, new XY(0,0), Color.Blue, Color.Aqua, 5 ));
                //Spawn(new SmileSpawner());
            }
            if (_.Time == 120) {
//                Spawn(new LazinessAttackSurvival());
            }
                

//                Spawn (new HugeStar (World.Box.Center, XY.Zero, 0, 0));
//                Spawn (new Airstrike ());
//                Spawn (new Revolt ());
//                Spawn (new SunflowerSpawner (Box.Center, 60));
                /*Spawn (
                    new Clock (
                        i => {
                            var enemy = new PurbleBlueShooter () {
                                HP = 100,
                                P = new XY (Mathf.Lerp (Box.Left, Box.Right, (i + 1) * 0.25f), Box.Top + 100)
                            };
                            _.World.Spawn (enemy);
                        },
                        3,
                        60
                    )
                );*/
     //           Spawn(new SphereBullets(Box.Center, 125, 8, Mathf.PI / 2.5f));
              //  Spawn(new RashkaOpenerNonspell(Box.Center));
            

            for (int i = 0; i < _entities.Count; i++) {
                var e = _entities[i];
                if (!e.Despawned) e.Update ();
            }
            

            var players        = new List <Pair> ();
            var playerDamagers = new List <Pair> ();
            var enemies        = new List <Pair> ();
            var enemyDamagers  = new List <Pair> ();
            var playerGraze  = new List <Pair> ();
            foreach (var e in _entities) {
                Hitbox hb;
                hb = e.PlayerHitbox       ; if (hb != null) players       .Add (new Pair(e, hb));
                hb = e.PlayerDamagerHitbox; if (hb != null) playerDamagers.Add (new Pair(e, hb));
                hb = e.EnemyHitbox        ; if (hb != null) enemies       .Add (new Pair(e, hb));
                hb = e.EnemyDamagerHitbox ; if (hb != null) enemyDamagers. Add (new Pair(e, hb));
                hb = e.GrazeHitbox  ; if (hb != null) playerGraze. Add (new Pair(e, hb));

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

            foreach (var pg in playerGraze) {
                if (pg.Entity.Despawned) continue;
                foreach (var pd in playerDamagers) {
                    if (pd.Entity.Despawned) continue;
                    if (pg.Hitbox.Over (pd.Hitbox)) {
                        pd.Entity.OnGrazed (pg.Entity);
                        pg.Entity.OnGraze (pd.Entity);
                        break;
                    }
                }
            }

            _entities.RemoveAll (e => e.Despawned);
        }


        public void Spawn (Entity e) {
            if (e.Despawned) {
                throw new InvalidOperationException ("can not spawn dead entity");
            }
            _entities.Add (e);
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