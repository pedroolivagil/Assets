using UnityEngine;
using MonoBehaviour = Photon.MonoBehaviour;

namespace Game.Game{
    public class Ammo : MonoBehaviour{
        public float TimeToDelete;
        public float Speed = 1;
        public int Damage = 1;

        void Start(){
            DestroyObject(gameObject, TimeToDelete);
        }

        void Update(){
            var x = 0;
            var y = Time.deltaTime * Speed;
            transform.Translate(x, y, 0);
        }

        void OnTriggerEnter(Collider other){
            if (other.CompareTag(Tag.Player.ToString())){
                Debug.Log("AmmoCollider: " + other.tag);
                Shield shield = other.GetComponentInChildren<Shield>(true);
                if (!shield.gameObject.GetActive()){
                    Health health = other.GetComponent<Health>();
                    Debug.Log("Hit player");
                    health.Hit(Damage);
                } else{
                    shield.Hit(Damage);
                }
            }
            DestroyObject(gameObject);
        }
    }
}