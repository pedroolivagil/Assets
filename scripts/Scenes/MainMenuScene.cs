using UnityEngine;
using Vuforia;

namespace Scenes{
    public class MainMenuScene : MonoBehaviour{
        public Material[] MaterialSkyboxes;

        private bool _listGalaxyLoaded = false;

        void Start(){
            UpdateSkyBox();
        }


        private void UpdateSkyBox(){
            Material tmp = MaterialSkyboxes[GameManager.RandomBetween(0, MaterialSkyboxes.Length - 1)];
            RenderSettings.skybox = tmp;
        }

// Dialogo de salida de juego
        void DialogExitGame(){
            // Hacemos un fadOut de la pantalla o un fadeIn Oscuro y pasamos a la pantalla de salida
            GameManager.ChangeScreen(GameScenes.ExitScreen);
        }

// Ventana de configuración 
        void CancelWindowSettings(){
            // Hacer rollback de las settings si es necesario y dejarlas como estaban antes
        }

        void AcceptWindowSettings(){
            // aceptar las configuraciones del usuario
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

// Ventana de servidores
        void SelectServer(Object[] args){
            if (args != null){
                Object galaxy = args[0];
                Object system = args[1];
                Debug.Log("Galaxia: " + galaxy + "; Sistema: " + system);
            } else{
                Debug.Log("Error");
            }
        }
    }
}