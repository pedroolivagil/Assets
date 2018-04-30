using UnityEngine;

namespace Scenes{
    public class MainMenuScene : MonoBehaviour{
        private InstantGuiElement _dialog;

        void Start(){
            _dialog = GameManager.GetGuiComponentWithName("dialogExit");
        }

        void OptionButtonExit(){
            Debug.Log("Btn Exit has pressed");
            _dialog.gameObject.SetActive(true);
        }

        void DialogExitGame(){
            // Hacemos un fadOut de la pantalla o un fadeIn Oscuro y pasamos a la pantalla de salida
            GameManager.ChangeScreen(GameScenes.ExitScreen);
        }

        void DialogCancelExit(){
            _dialog.gameObject.SetActive(false);
        }
    }
}