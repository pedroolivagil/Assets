using UnityEngine;

namespace Scenes{
    public class RotateCamera : MonoBehaviour{
        private int _speed;
        private Quaternion _q;

        void Start(){
            _speed = GameManager.RandomBetween(1, 5);
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