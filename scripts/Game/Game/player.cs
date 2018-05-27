using UnityEngine;

namespace Game.Game{
    public class Player : Photon.MonoBehaviour{
        private Camera _camera;
        public float Speed = 3.0f;
        public float Rotate = 100f;
        public float ZoomCamera = -10f;

        private Canon[] _canons;

        void Start(){
            if (photonView.isMine){
                _camera = FindObjectOfType<Camera>();
                _canons = gameObject.GetComponentsInChildren<Canon>();
            }
        }

        void Update(){
            if (photonView.isMine){
                Movement();
                Shoot();
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
            if (Input.GetButtonDown("Jump")){
                foreach (Canon canon in _canons){
                    GameManager.InstantiatePhoton("Actors/Effects/Weapons/Ammo", canon.transform,
                        transform.parent.gameObject);
                }
            }
        }

        public void Death(){
            
        }
    }
}