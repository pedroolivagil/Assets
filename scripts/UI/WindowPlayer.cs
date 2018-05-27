using Game.Game;
using UnityEngine;

namespace UI{
    public class WindowPlayer : MonoBehaviour{
        public InstantGuiElement HealthBar;
        public InstantGuiElement ShieldBar;
        private Player _player;

        void Start(){ }

        void Update(){
            if (_player == null){
                _player = FindObjectOfType<Player>();
            }
            UpdateInfo();
        }

        private void UpdateInfo(){
            if (_player != null){
                var playerHp = _player.GetComponent<Health>();
                var playerEnergy = 100 / playerHp.GetInitialEnergy();
                var playerShield = 100 / playerHp.GetInitialShield();
                HealthBar.relative.right = playerEnergy * playerHp.Energy;
                ShieldBar.relative.right = playerShield * playerHp.Shield;
                if (playerHp.Energy <= 0){
                    HealthBar.gameObject.SetActive(false);
                }
                if (playerHp.Shield <= 0){
                    ShieldBar.gameObject.SetActive(false);
                }
            }
        }
    }
}