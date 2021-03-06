﻿using UnityEngine;

namespace Game.Game{
    public class Health : MonoBehaviour{
        public int Energy = 1;

        private int _energy = 1;

        public static int DEATH = -1;

        // Use this for initialization
        void Start(){
            _energy = Energy;
        }

        public void Hit(int damage){
            Hit(damage, gameObject);
        }

        public void Hit(int damage, GameObject target){
            if (damage > DEATH){
                for (int i = 0; i < damage; i++){
                    Energy--;
                }
            } else{
                Energy = DEATH;
            }
            if (Energy <= 0){
                DestroyObject(target);
                GameManager.InstantiatePhoton("Actors/Effects/Explosions/Explosion", target.transform, null);
            }
        }

        public int GetInitialEnergy(){
            return _energy;
        }
    }
}