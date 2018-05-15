using UnityEngine;
using MonoBehaviour = Photon.MonoBehaviour;

public class Shoot : MonoBehaviour{
    // Use this for initialization
    void Start(){ }

    // Update is called once per frame
    void Update(){ }

    void OnParticleCollision(GameObject other){
        Debug.Log(other.name);
    }
}