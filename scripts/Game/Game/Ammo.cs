using UnityEngine;
using MonoBehaviour = Photon.MonoBehaviour;

namespace Game.Game{
    public class Ammo : MonoBehaviour{
        public float TimeToDelete;

        // Use this for initialization
        void Start(){
            DestroyObject(gameObject, TimeToDelete);
        }

        void OnCollisionEnter2D(Collision2D other){
            Debug.Log("colision enter");
            if (other.gameObject.CompareTag("Enemy")){
                Debug.Log("colision enter with Enemy");
                DestroyObject(gameObject, 0.2f);
            }
        }
    }
}