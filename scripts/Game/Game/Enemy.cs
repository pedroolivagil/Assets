using System.Collections;
using UnityEngine;
using MonoBehaviour = Photon.MonoBehaviour;

namespace Game.Game{
    public class Enemy : MonoBehaviour{
        public bool ShowHealthBar = true;
        public float Speed = 3.0f;
        public float Rotate = 100f;
        public bool PlayerDetected = false;

        private Health _healthBar;
        private Transform _targetPlayer;
        private player _player;
        private float _dir = 0;
        private float _normalSpeed;

        void Start(){
            _normalSpeed = Speed;
            _healthBar = gameObject.GetComponentInChildren<Health>();
            _healthBar.gameObject.SetActive(ShowHealthBar);
            StartCoroutine(UpdateDir());
        }

        void Update(){
            if (_player == null && _targetPlayer == null){
                _player = FindObjectOfType<player>();
                if (_player != null){
                    _targetPlayer = _player.transform;
                }
            }
            Movement();
        }

        private IEnumerator UpdateDir(){
            yield return new WaitForSeconds(1);
            _dir = 0;
            yield return new WaitForSeconds(GameManager.RandomBetween(5, 20));
            _dir = GameManager.RandomBetween(-1, 1);
            yield return UpdateDir();
        }

        private void Movement(){
            float x;
            float y;
            if (!PlayerDetected){
                Speed = _normalSpeed;
                x = _dir * Time.deltaTime * Speed;
                y = Time.deltaTime * Speed;
            } else{
                Speed = _normalSpeed * 1.2f;
                x = _targetPlayer.position.x;
                y = Time.deltaTime * Speed;
            }
            Vector3 movement = new Vector3(0, 0, x * -1);
            transform.Rotate(movement, Time.deltaTime * Speed * Rotate);
            transform.Translate(x, y, 0);
        }
    }
}