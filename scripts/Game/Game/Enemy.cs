using System.Collections;
using UnityEngine;
using MonoBehaviour = Photon.MonoBehaviour;

namespace Game.Game{
    public class Enemy : MonoBehaviour{
        public bool ShowHealthBar = true;
        public float Speed = 3.0f;
        public float Rotate = 100f;
        public float MinDist = 10f;
        public float MaxDist = 5f;
        public bool PlayerDetected;

        //Vector3 used to store the velocity of the enemy
        private Vector3 _velocity = Vector3.zero;

        private Health _healthBar;
        private Transform _targetPlayer;
        private player _player;
        private float _dir = 0;
        private float _normalSpeed;
        private float _smoothTime = .3f;

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
            if (!PlayerDetected){
                yield return new WaitForSeconds(1);
                _dir = 0;
                yield return new WaitForSeconds(GameManager.RandomBetween(5, 20));
                _dir = GameManager.RandomBetween(-1, 1);
                yield return UpdateDir();
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
//                        if (Vector3.Distance(transform.position, _targetPlayer.position) >= MinDist){
//                            transform.position = Vector2.MoveTowards(transform.position, _targetPlayer.position,
//                                Speed * Time.deltaTime);
//                        }
//                        Vector3 movement = new Vector3(0, 0, Time.deltaTime * Speed * -1);
//                        transform.Rotate(movement, Time.deltaTime * Speed * Rotate);

                        Vector3 forwardAxis = new Vector3(0, 0, -1);
                        transform.LookAt(_targetPlayer.position, -forwardAxis);
                        Debug.DrawLine(transform.position, _targetPlayer.position);
                        transform.eulerAngles = new Vector3(0, 0, -transform.eulerAngles.z);
//                        transform.position -= transform.TransformDirection(Vector2.up) * Speed * Time.deltaTime;
                        if (Vector3.Distance(transform.position, _targetPlayer.position) >= MinDist){
                            transform.position = Vector2.MoveTowards(transform.position, _targetPlayer.position,
                                Speed * Time.deltaTime);
                        }
                    }
                }
            }
            if (_targetPlayer != null && PlayerDetected &&
                Vector3.Distance(transform.position, _targetPlayer.position) <= MaxDist){
                //disparamos al player
                Debug.Log("Fire!!!");
            }
        }
    }
}