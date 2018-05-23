using System.Collections;
using UnityEditor;
using UnityEngine;
using MonoBehaviour = Photon.MonoBehaviour;

namespace Game.Game{
    public class Enemy : MonoBehaviour{
        public bool ShowHealthBar = true;
        public float Speed = 3.0f;
        public float Rotate = 100f;
        public float MinDist = 10f;
        public float RadiusDetectPlayer = 5f;
        public float TimeShooting = 1;
        public bool PlayerDetected;

        private Health _healthBar;
        private Transform _targetPlayer;
        private Player _player;
        private Canon[] _canons;
        private SphereCollider _sphereCollider;
        private float _dir = 0;
        private float _normalSpeed;
        private float _smoothTime = .3f;
        private float _currentTime = 0;
        private float _directionTime = 0;

        void Start(){
            _normalSpeed = Speed;
            _healthBar = gameObject.GetComponentInChildren<Health>();
            _canons = gameObject.GetComponentsInChildren<Canon>();
            _sphereCollider = gameObject.GetComponentInChildren<SphereCollider>();
            _sphereCollider.radius = RadiusDetectPlayer;
            _healthBar.gameObject.SetActive(ShowHealthBar);
        }

        void Update(){
            if (_player == null && _targetPlayer == null){
                _player = FindObjectOfType<Player>();
                if (_player != null){
                    _targetPlayer = _player.transform;
                }
            }
            Movement();
            UpdateDir();
        }

        void UpdateDir(){
            if (Time.time > _directionTime){
                _dir = Random.Range(-1.0f, 1.1f);
                _directionTime = Time.time + GameManager.RandomBetween(3, 15);
            } else{
                if (!_dir.Equals(0)){
                    _dir = 0;
                }
            }
        }

        private void Movement(){
            if (Speed > 0){
                if (!PlayerDetected){
                    Speed = _normalSpeed;
                    float x = _dir * Time.deltaTime * Speed;
                    float y = Time.deltaTime * Speed;
                    Vector3 movement = new Vector3(0, 0, x * -1);
                    transform.Rotate(movement, Time.deltaTime * Speed * Rotate);
                    transform.Translate(x, y, 0);
                } else{
                    if (_targetPlayer != null){
                        if (Vector3.Distance(transform.position, _targetPlayer.position) > MinDist){
                            //move if distance from target is greater than 1
                            Vector3 diff = new Vector3(Speed * Time.deltaTime, 0, 0) -
                                           new Vector3(0, -Speed * Time.deltaTime, 0);
                            transform.Translate(diff);
                        }
                        //rotate to look at the player
                        transform.LookAt(_targetPlayer.position);
                        //correcting the original rotation
                        transform.Rotate(new Vector3(0, -90, transform.rotation.z - 90), Space.Self);
                    }
                }
            }
        }

        private void Shoot(){
            if (Time.time > _currentTime && _targetPlayer != null && PlayerDetected){
                foreach (Canon canon in _canons){
                    GameManager.Instantiate("Actors/Effects/Weapons/Ammo", canon.transform, gameObject.gameObject);
                    _currentTime = Time.time + TimeShooting;
                }
            }
        }

        void OnTriggerEnter(Collider other){
            var capsuleCollider = other.GetComponent<CapsuleCollider>();
            Debug.Log(capsuleCollider);
            if (other.tag.Equals(Tag.Player.ToString())){
                PlayerDetected = true;
            }
            if (capsuleCollider != null && other.tag.Equals(Tag.Enemy.ToString())){
                _dir = _dir * -1f;
            }
        }

        void OnTriggerStay(Collider other){
            if (other.tag.Equals(Tag.Player.ToString())){
                Shoot();
            }
        }

        void OnTriggerExit(Collider other){
            if (other.tag.Equals(Tag.Player.ToString())){
                PlayerDetected = false;
            }
            if (other.tag.Equals(Tag.Enemy.ToString())){
                _dir = 0;
            }
        }
    }
}