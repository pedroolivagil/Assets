using UnityEngine;
using MonoBehaviour = Photon.MonoBehaviour;

namespace Game.Game{
    public class Enemy : MonoBehaviour{
        private Transform _targetPlayer;
        private player _player;
        public int Health = 5;
        public bool ShowHealthBar = true;

        void Update(){
            if (_player == null){
                _player = FindObjectOfType<player>();
                if (_player != null){
                    _targetPlayer = _player.transform;
                }
            }
        }

        void OnParticleCollision(GameObject other){
            DestroyObject(other);
            Health--;
            if (Health == 0){
                DestroyObject(gameObject, 0.2f);
            }
        }
    }
}