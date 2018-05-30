using UnityEngine;

namespace Game.Game{
    public class Shield : MonoBehaviour{
        public int Energy = 1;
        private int _energy = 1;

        void Start(){
            _energy = Energy;
            transform.localScale = Vector3.zero;
        }

        public void Hit(int damage){
            Hit(damage, gameObject);
        }

        public void Hit(int damage, GameObject target){
            for (int i = 0; i < damage; i++){
                Energy--;
            }
            if (Energy <= 0){
                DestroyObject(target);
                GameManager.InstantiatePhoton("Actors/Effects/Explosions/Explosion", target.transform, null);
            }
        }

        public int GetInitialShield(){
            return _energy;
        }

        public void OpenShield(bool active){
            Vector3 originalScale = transform.localScale;
            Vector3 newScale;
            if (active){
                newScale = new Vector3(8, 8, 1);
            } else{
                newScale = Vector3.zero;
            }
            float currentTime = 0.0f;
            float time = 3f;
            do{
                transform.localScale = Vector3.Lerp(originalScale, newScale, currentTime / time);
                currentTime += Time.deltaTime;
            } while (currentTime <= time);
        }
    }
}