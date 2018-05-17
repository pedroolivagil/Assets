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

        void OnTriggerEnter(Collider other){
            Debug.Log("TriggerEnter");
        }


        void OnParticleCollision(GameObject other){
            ParticleSystem partSyst = other.GetComponent<ParticleSystem>();
            int numCollisionEvents = partSyst.GetCollisionEvents(gameObject, _collisionEvents);
            Debug.Log("Collisions: " + numCollisionEvents);
            int i = 0;
            while (i < numCollisionEvents){
                var collisionHitLoc = _collisionEvents[0].colliderComponent;
                if (collisionHitLoc != null){
                    Vector3 position = new Vector3(collisionHitLoc.transform.position.x,
                        collisionHitLoc.transform.position.y, -2);
                    GameManager.Instantiate("Actors/Effects/ExplosionMini", position, Quaternion.identity, null);
                }
                i++;
            }
            DestroyObject(other);
            _healthBar.Hit(1, gameObject);
        }
    }
}