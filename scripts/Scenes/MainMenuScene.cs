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

// Ventana de configuración 
        void OptionButtonSettings(){
            Debug.Log("Btn Settings has pressed");
            _windowSettings.gameObject.SetActive(true);
        }

        void CancelWindowSettings(){
            // Hacer rollback de las settings si es necesario y dejarlas como estaban antes
            _windowSettings.gameObject.SetActive(false);
        }

        void AcceptWindowSettings(){
            // aceptar las configuraciones del usuario
            _windowSettings.gameObject.SetActive(false);
        }

// Ventana de login
        void OptionButtonPlay(){
            Debug.Log("Btn Play has pressed");
            _windowUser.gameObject.SetActive(true);
        }

        void SignUpWindowPlay(){
            Debug.Log("Btn SignUp has pressed");
            _windowUser.gameObject.SetActive(false);
        }

        void LoginWindowPlay(){
            Debug.Log("Btn Login has pressed");
            _windowUser.gameObject.SetActive(false);
            InstantGuiElement userName = GameManager.GetGuiComponentWithName("userName");
            InstantGuiElement passWord = GameManager.GetGuiComponentWithName("passWord");
            Debug.Log("Data -> " + userName.text + " : " + passWord.text);            
        }
    }
}