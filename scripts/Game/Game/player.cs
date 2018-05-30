using UnityEngine;
using MonoBehaviour = Photon.MonoBehaviour;

namespace Game.Game{
    public class Player : MonoBehaviour{
        private Camera _camera;
        public float Speed = 3.0f;
        public float Rotate = 100f;
        public float ZoomCamera = -10f;

        private Canon[] _canons;
        private Health _health;
        private Shield _shield;

        void Start(){
            if (photonView.isMine){
                _camera = FindObjectOfType<Camera>();
                _canons = gameObject.GetComponentsInChildren<Canon>();
                _health = gameObject.GetComponentInChildren<Health>();
                _shield = gameObject.GetComponentInChildren<Shield>(true);
            }
        }

        void Update(){
            if (photonView.isMine){
                Movement();
                Shoot();
                Controllers();
            }
        }

        // LateUpdate is called after Update each frame
        void LateUpdate(){
            if (photonView.isMine){
                UpdateCamera();
            }
        }

        private void UpdateCamera(){
            // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            _camera.transform.position = new Vector3(transform.position.x, transform.position.y, ZoomCamera);
        }

        private void Movement(){
            if (Speed > 0){
                var x = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
                var y = Time.deltaTime * Speed;
                Vector3 movement = new Vector3(0, 0, x * -1);
                transform.Rotate(movement, Time.deltaTime * Speed * Rotate);
                transform.Translate(x, y, 0);
            }
        }

        private void Shoot(){
            var shieldActive = _shield.gameObject.GetActive();
            if (Input.GetButtonDown("Jump") && !shieldActive){
                foreach (Canon canon in _canons){
                    GameManager.InstantiatePhoton("Actors/Effects/Weapons/Bullet", canon.transform,
                        transform.parent.gameObject);
                }
            }
        }

        public void Death(){
            _health.Hit(Health.DEATH);
        }

//        void OnTriggerEnter(Collider other){
//            if (other.CompareTag(Tag.Ammo.ToString())){
//                Debug.Log("PlayerCollider: " + other.tag);
//                Ammo bullet = other.GetComponent<Ammo>();
//                Debug.Log("AMMO: " + bullet);
//                if (bullet != null && _health != null){
//                    Debug.Log("Hit player");
//                    _health.Hit(bullet.Damage, gameObject);
//                }
//                DestroyObject(other);
//            }
//        }
        private void Controllers(){
            if (Input.GetButton("Fire2")){
                _shield.OpenShield(true);
            } else{
                _shield.OpenShield(false);
            }
        }
    }
}