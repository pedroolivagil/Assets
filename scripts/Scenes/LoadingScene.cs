using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scenes{
    public class LoadingScene : MonoBehaviour{
        public bool IsMockBar;
        public Slider SliderLoader;
        public Text TextTitleStatus;
        public Text TextStatus;
        public Text TextStatusBg;
        private AsyncOperation _loadScene;
        public static string NavigateScene;
        public RawImage ObjectBackground;
        public Texture[] Backgrounds;

        void Start(){
            SliderLoader.value = 0;
            if (TextStatus){
                TextStatus.text = "0 %";
            }
            if (!IsMockBar && NavigateScene != null){
                _loadScene = SceneManager.LoadSceneAsync(NavigateScene, LoadSceneMode.Single);
            }
            RandomBackground();
        }

        private void RandomBackground(){
            int rand = GameManager.RandomBetween(0, Backgrounds.Length - 1);
            ObjectBackground.texture = Backgrounds[rand];
        }

        void Update(){
            PreLoadScene();
            MockBar();
            UpdateTextTitleStatus();
            TextStatusBg.text = TextStatus.text;
        }

        private void UpdateTextTitleStatus(){
            if (TextTitleStatus != null && SliderLoader != null){
                if (SliderLoader.value >= 0 && SliderLoader.value < 15){
                    TextTitleStatus.text = LocaleManager.Inst().TranslateStr("PRELOAD_SCREEN_GAME1");
                } else if (SliderLoader.value >= 15 && SliderLoader.value < 30){
                    TextTitleStatus.text = LocaleManager.Inst().TranslateStr("PRELOAD_SCREEN_GAME2");
                } else if (SliderLoader.value >= 30 && SliderLoader.value < 45){
                    TextTitleStatus.text = LocaleManager.Inst().TranslateStr("PRELOAD_SCREEN_GAME3");
                } else if (SliderLoader.value >= 45 && SliderLoader.value < 60){
                    TextTitleStatus.text = LocaleManager.Inst().TranslateStr("PRELOAD_SCREEN_GAME4");
                } else if (SliderLoader.value >= 60 && SliderLoader.value < 75){
                    TextTitleStatus.text = LocaleManager.Inst().TranslateStr("PRELOAD_SCREEN_GAME5");
                } else if (SliderLoader.value >= 75){
                    TextTitleStatus.text = LocaleManager.Inst().TranslateStr("PRELOAD_SCREEN_GAME6");
                }
            }
        }

        private void MockBar(){
            if (IsMockBar){
                if (TextStatus){
                    TextStatus.text = Mathf.Round(SliderLoader.value) + " %";
                }
            }
        }

        private void PreLoadScene(){
            if (_loadScene != null){
                Debug.Log("Preload scene progress: " + Mathf.Round(_loadScene.progress * 100));
                if (SliderLoader.value <= 100){
                    SliderLoader.value = Mathf.Round(_loadScene.progress * 100);
                }
                if (TextStatus){
                    TextStatus.text = Mathf.Round(_loadScene.progress * 100) + " %";
                }
            }
        }

        public static void SetNavigateScene(string navigateScene){
            NavigateScene = navigateScene;
        }
    }
}