using Game.Game;
using Photon;

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
                var playerEnergy = 100 / playerHp.GetInitialEnergy();
                HealthBar.relative.right = playerEnergy * playerHp.Energy;
                if (playerHp.Energy <= 0){
                    HealthBar.gameObject.SetActive(false);
                }
                var playerSh = _player.GetComponentInChildren<Shield>(true);
                var playerShield = 100 / playerSh.GetInitialShield();
                ShieldBar.relative.right = playerShield * playerSh.Energy;
                if (playerSh.Energy <= 0){
                    ShieldBar.gameObject.SetActive(false);
                } else{
                    ShieldBar.gameObject.SetActive(true);
                }
            }
        }
    }
}