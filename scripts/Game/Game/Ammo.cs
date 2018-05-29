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

//        void OnTriggerEnter(Collider other){
//            if (other.tag.Equals(Tag.Enemy.ToString()) || other.tag.Equals(Tag.Player.ToString())){
//                Health health = other.GetComponentInChildren<Health>();
//                health.Hit(Damage, other.gameObject);
//            }
//            DestroyObject(gameObject);
//        }
    }
}