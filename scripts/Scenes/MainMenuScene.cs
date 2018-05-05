using UnityEngine;
using Vuforia;

namespace Scenes{
    public class MainMenuScene : MonoBehaviour{
        public Material[] MaterialSkyboxes;

        private bool _listGalaxyLoaded = false;
        private InstantGuiElement _panelGalaxy;

        void Start(){
            _panelGalaxy = GameManager.GetGuiComponentWithName("panelGalaxy");
            UpdateSkyBox();
        }

        void OnGUI(){
            if (!_listGalaxyLoaded){
                WindowGalaxy();
                _listGalaxyLoaded = true;
            }
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

        void WindowGalaxy(){
            InstantGuiWindow galaxy0 = GameManager.GetGuiComponentWithName("galaxy0") as InstantGuiWindow;
            InstantGuiList lista0 = galaxy0.GetComponentInChildren<InstantGuiList>();
            foreach (InstantGuiElement list in lista0.elements){
                    lista0.a
                        
                        
                }
            lista0.labels[]
        }
    }
}