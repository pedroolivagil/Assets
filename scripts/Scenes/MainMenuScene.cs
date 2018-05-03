using UnityEngine;

namespace Scenes{
    public class MainMenuScene : MonoBehaviour{
        private InstantGuiElement _dialog;
        private InstantGuiElement _windowSettings;
        private InstantGuiElement _windowUser;

        void Start(){
            _dialog = GameManager.GetGuiComponentWithName("dialogExit");
            _windowSettings = GameManager.GetGuiComponentWithName("windowSettings");
            _windowUser = GameManager.GetGuiComponentWithName("windowUser");
        }

// Dialogo de salida de juego
        void DialogExitGame(){
            // Hacemos un fadOut de la pantalla o un fadeIn Oscuro y pasamos a la pantalla de salida
            GameManager.ChangeScreen(GameScenes.ExitScreen);
        }

// Ventana de configuración 
        void CancelWindowSettings(){
            // Hacer rollback de las settings si es necesario y dejarlas como estaban antes
//            _windowSettings.gameObject.SetActive(false);
        }

        void AcceptWindowSettings(){
            // aceptar las configuraciones del usuario
//            _windowSettings.gameObject.SetActive(false);
        }

// Ventana de login

        void SignUpWindowPlay(){
            Debug.Log("Btn SignUp has pressed");
        }

        void LoginWindowPlay(){
            Debug.Log("Btn Login has pressed");
            InstantGuiInputText userName = (InstantGuiInputText) GameManager.GetGuiComponentWithName("userName");
            InstantGuiInputText passWord = (InstantGuiInputText) GameManager.GetGuiComponentWithName("passWord");
            Debug.Log("Data -> " + userName.text + " : " + passWord.text);
        }
    }
}