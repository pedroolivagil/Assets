using Scenes;
using UnityEngine;

namespace UI{
    public class ServerListListener : MonoBehaviour{
        private InstantGuiInputText _labelServerSelected;

        void Start(){
            _labelServerSelected = (InstantGuiInputText) GameManager.GetGuiComponentWithName("labelServerSelected");
        }

        public void SelectGalaxy(int buttonId){
            InstantGuiButton button = (InstantGuiButton) GameManager.GetGuiComponentWithName("sistema" + buttonId);
            _labelServerSelected.text = button.text;
        }

        public void BackToMenu(){
            _labelServerSelected.text = "";
        }

        public void StartGame(){
            StaticClass.InfoObject = _labelServerSelected.text;
            GameManager.ChangeScreen(GameScenes.GameScene, true);
        }

        // Investigar si es posible simplificar los métodos siguientes
        public void SelectGalaxy1(){
            SelectGalaxy(1);
        }

        public void SelectGalaxy2(){
            SelectGalaxy(2);
        }

        public void SelectGalaxy3(){
            SelectGalaxy(3);
        }

        public void SelectGalaxy4(){
            SelectGalaxy(4);
        }

        public void SelectGalaxy5(){
            SelectGalaxy(5);
        }

        public void SelectGalaxy6(){
            SelectGalaxy(6);
        }

        public void SelectGalaxy7(){
            SelectGalaxy(7);
        }

        public void SelectGalaxy8(){
            SelectGalaxy(8);
        }

        public void SelectGalaxy9(){
            SelectGalaxy(9);
        }

        public void SelectGalaxy10(){
            SelectGalaxy(10);
        }

        public void SelectGalaxy11(){
            SelectGalaxy(11);
        }

        public void SelectGalaxy12(){
            SelectGalaxy(12);
        }

        public void SelectGalaxy13(){
            SelectGalaxy(13);
        }

        public void SelectGalaxy14(){
            SelectGalaxy(14);
        }

        public void SelectGalaxy15(){
            SelectGalaxy(15);
        }

        public void SelectGalaxy16(){
            SelectGalaxy(16);
        }

        public void SelectGalaxy17(){
            SelectGalaxy(17);
        }

        public void SelectGalaxy18(){
            SelectGalaxy(18);
        }
    }
}