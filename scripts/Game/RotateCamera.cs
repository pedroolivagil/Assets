using UnityEngine;

namespace Scenes{
    public class RotateCamera : MonoBehaviour{
        public float Aspect;
        private int _speed;
        private Quaternion _q;

        //        private Camera _camera;

        void Start(){
            _speed = GameManager.RandomBetween(1, 5);
//            _camera = GetComponent<Camera>();
//            _camera.aspect = Aspect;
        }

        void FixedUpdate(){
            var currentRotation = transform.rotation;
            var x = _speed * Time.time / 4;
            var desiredRotation = Quaternion.Euler(0, x, 0);
            var rotation = Quaternion.Slerp(currentRotation, desiredRotation, Time.deltaTime * 1000);
            transform.rotation = rotation;
        }
    }
}