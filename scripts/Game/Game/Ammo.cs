using UnityEngine;

public class Ammo : MonoBehaviour{
    public float TimeToDelete;

    // Use this for initialization
    void Start(){
        DestroyObject(gameObject, TimeToDelete);
    }
}