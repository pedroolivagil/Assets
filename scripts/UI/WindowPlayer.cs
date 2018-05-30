using Game.Game;
using UnityEngine;
using MonoBehaviour = Photon.MonoBehaviour;

namespace UI{
    public class WindowPlayer : MonoBehaviour{
        public InstantGuiElement HealthBar;
        public InstantGuiElement ShieldBar;

        private Player _player;

        void Update(){
            if (_player == null){
                _player = FindObjectOfType<Player>();
                if (_player != null && !_player.photonView.isMine){
                    _player = null;
                }
            }
            UpdateInfo();
        }

        private void UpdateInfo(){
            if (_player != null && _player.photonView.isMine){
                var playerHp = _player.GetComponent<Health>();
                if (playerHp.Energy <= 0){
                    HealthBar.gameObject.SetActive(false);
                } else{
                    var playerEnergy = 100 / playerHp.GetInitialEnergy();
                    HealthBar.relative.right = playerEnergy * playerHp.Energy;
                }
                var playerSh = _player.GetComponentInChildren<Shield>(true);
                if (!playerSh.gameObject.GetActive()){
                    ShieldBar.gameObject.SetActive(false);
                } else{
                    if (playerSh.Energy <= 0){
                        ShieldBar.gameObject.SetActive(false);
                    } else{
                        var playerShield = 100 / playerSh.GetInitialShield();
                        Debug.Log("ShieldLifePart: " + playerShield);
                        Debug.Log("ShieldLife: " + playerSh.Energy);
                        ShieldBar.relative.right = playerShield * playerSh.Energy;
                        ShieldBar.gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}