using System.Collections.Generic;
using UnityEngine;

namespace Game.Game{
    public class OnParticleCollisionHelper : MonoBehaviour{
        private List<ParticleCollisionEvent> _collisionEvents;

        private Health _healthBar;

        void Start(){
            _healthBar = gameObject.GetComponentInChildren<Health>();
            _collisionEvents = new List<ParticleCollisionEvent>();
        }

        void OnParticleCollision(GameObject other){
            ParticleSystem partSyst = other.GetComponent<ParticleSystem>();
            int numCollisionEvents = partSyst.GetCollisionEvents(gameObject, _collisionEvents);
//            int i = 0;
//            while (i < numCollisionEvents){
            if (numCollisionEvents > 0){
                var collisionHitLoc = _collisionEvents[0].colliderComponent;
                if (collisionHitLoc != null){
                    Vector3 position = new Vector3(collisionHitLoc.transform.position.x,
                        collisionHitLoc.transform.position.y, -2);
                    GameManager.InstantiatePhoton("Actors/Effects/Explosions/ExplosionMini", position, Quaternion.identity,
                        null);
                }
//                i++;
            }
            DestroyObject(other);
            _healthBar.Hit(1, gameObject);
        }
    }
}