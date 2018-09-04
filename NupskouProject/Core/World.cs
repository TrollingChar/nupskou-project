using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using NupskouProject.Math;


namespace NupskouProject {

    public class World {
        
        public static readonly Box Box = new Box (30, 25, 470, 575);
        public static readonly Box PlayerBox = new Box (50, 45, 450, 555);

        private List <Entity> _entities = new List <Entity> ();
        private List <Entity> _bullets  = new List <Entity> ();
        private Player        _player;


        public void Update () {
            if (_.Time == 0) {
                Spawn (new Player (new XY (250, 500)));
            }
            if (_.Time % 120 == 60) {
                foreach (var v in Danmaku.Cloud (2, 500)) {
                    Spawn (new RoundBullet (new XY (250, 300), v));
                }
            }

            for (int i = 0; i < _entities.Count; i++) {
                var e = _entities[i];
                if (!e.Despawned) e.Update ();
            }

            // check hitboxes
            //  you - bullet
            if (_player != null) {
                foreach (var b in _bullets) {
                    if (b.BulletHitbox ().Over (_player.PlayerHB)) {
                        _player.TakeBulletHit (b);
                        break;
                    }
                }
            }

            //  you - enemy
            //  bomb - enemy
            //  bomb - bullet
            //  enemy - your bullet
            //  graze - bullet

            _entities.RemoveAll (e => e.Despawned);
            _bullets .RemoveAll (e => e.Despawned);
            if (_player != null && _player.Despawned) _player = null;
        }


        public void Spawn (Entity e) {
            if (e.Despawned) {
                throw new InvalidOperationException ("can not spawn dead entity");
            }
            _entities.Add (e);
            if (e.BulletHitbox != null) _bullets.Add (e);
            if (e is Player)            _player = (Player) e;
            e.OnSpawn ();
        }


        public void Render () {
            _.Renderer.UI.Add (new SpriteInstance (_.Assets.UI));
            foreach (var e in _entities) {
                if (!e.Despawned) e.Render ();
            }
        }

    }


}