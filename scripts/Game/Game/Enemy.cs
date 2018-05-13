using UnityEngine;
using MonoBehaviour = Photon.MonoBehaviour;

namespace Game.Game{
    public class Enemy : MonoBehaviour{
        private Transform _targetPlayer;
        private player _player;

        // Use this for initialization
        void Start(){ }

        // Update is called once per frame
        void Update(){
            if (_player == null){
                _player = FindObjectOfType<player>();
                if (_player != null){
                    _targetPlayer = _player.transform;
                }
            }
        }
    }
}