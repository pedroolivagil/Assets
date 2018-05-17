using UnityEngine;
using MonoBehaviour = Photon.MonoBehaviour;

namespace Game.Game{
    public class Enemy : MonoBehaviour{
        private Transform _targetPlayer;
        private player _player;
        public bool ShowHealthBar = true;

        private Health _healthBar;

        void Start(){
            _healthBar = gameObject.GetComponentInChildren<Health>();
            _healthBar.gameObject.SetActive(ShowHealthBar);
        }

        void Update(){
            if (_player == null){
                _player = FindObjectOfType<player>();
                if (_player != null){
                    _targetPlayer = _player.transform;
                }
            }
        }
//
//        void OnParticleCollision(GameObject other){
//            DestroyObject(other);
//            int safeLength = GetComponent<ParticleSystem>().safeCollisionEventSize;
//            if (collisionEvents.Length < safeLength)
//                collisionEvents = new ParticleSystem.CollisionEvent[safeLength];
//            int numCollisionEvents = particleSystem.GetCollisionEvents(other, collisionEvents);
//            int i = 0;
//            while (i < numCollisionEvents) {
//                Vector3 collisionHitLoc = collisionEvents[i].intersection;
//                myExplosion = Instantiate (prefabExplosion, collisionHitLoc, Quaternion.identity) as GameObject;
//                i++;
//            }
//            GameManager.Instantiate("Actors/Effects/ExplosionMini", other.transform, null);   
//            _healthBar.Hit(1, gameObject);
//        }
    }
}