using UnityEngine;
using MonoBehaviour = Photon.MonoBehaviour;

namespace Game.Game{
    public class Ammo : MonoBehaviour{
        public float TimeToDelete;

        // Use this for initialization
        void Start(){
            DestroyObject(gameObject, TimeToDelete);
        }

        void OnTriggerEnter(Collider other){
            Debug.Log("colision enter");
            if (other.tag.Equals("Enemy")){
                Debug.Log("colision enter with Enemy");
                DestroyObject(gameObject, 0.2f);
            }
        }
        
    }
}