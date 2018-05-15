using UnityEngine;
using MonoBehaviour = Photon.MonoBehaviour;

namespace Game.Game{
    public class Ammo : MonoBehaviour{
        public float TimeToDelete;

        // Use this for initialization
        void Start(){
            DestroyObject(gameObject, TimeToDelete);
        }

        
    }
}