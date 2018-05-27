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
                if (playerHp.Energy != 0){
                    var playerEnergy = 100 / playerHp.Energy;
                    HealthBar.relative.right = 100 - (playerEnergy - 1);
                }
                if (playerHp.Shield != 0){
                    var playerShield = 100 / playerHp.Shield;
                    ShieldBar.relative.right = 100 - (playerShield - 1);
                }
            }
        }
    }
}