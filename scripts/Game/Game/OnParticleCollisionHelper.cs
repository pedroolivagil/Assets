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
            partSyst.GetCollisionEvents(other, _collisionEvents);
            Transform collisionHitLoc = _collisionEvents[0].colliderComponent.transform;
            Debug.Log("Position: " + collisionHitLoc);
            GameManager.Instantiate("Actors/Effects/ExplosionMini", collisionHitLoc, null);
            DestroyObject(other);
            _healthBar.Hit(1, gameObject);
        }
    }
}