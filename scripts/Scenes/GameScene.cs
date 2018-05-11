using System.Collections;
using UnityEngine;

public class GameScene : MonoBehaviour{
    // Use this for initialization
    public Transform PrefabNetwork;

    void Start(){
        Instantiate(PrefabNetwork);
    }

}