using UnityEngine;

namespace Game.Game{
    public class Shield : MonoBehaviour{
        public int Energy = 1;
        private int _energy = 1;

        void Start(){
            _energy = Energy;
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
    }
}