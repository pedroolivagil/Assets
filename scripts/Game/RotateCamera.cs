using UnityEngine;

namespace Scenes{
    public class RotateCamera : MonoBehaviour{
        public int Speed;
        private Quaternion _q;

        void FixedUpdate(){
            var currentRotation = transform.rotation;
            var x = Speed * Time.time / 4;
            var desiredRotation = Quaternion.Euler(0, x, 0);
            var rotation = Quaternion.Slerp(currentRotation, desiredRotation, Time.deltaTime * 1000);
            transform.rotation = rotation;
        }
    }
}