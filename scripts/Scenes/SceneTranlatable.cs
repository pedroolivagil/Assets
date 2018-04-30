using UnityEngine;
using UnityEngine.UI;

namespace Scenes{
    public class SceneTranlatable : MonoBehaviour{
// Use this for initialization
        public Text[] excludeTranslate;

        private void Awake(){
            ReplaceText();
            ReplaceTextGUI();
        }

        private void ReplaceText(){
            Object[] objects = FindObjectsOfTypeAll(typeof(Text));
            foreach (Object obj in objects){
                Text item = (Text) obj;
                if (item != null){
                    if (excludeTranslate != null && GameManager.ArrayContains(excludeTranslate, item)){
                        continue;
                    }
                    string texto = LocaleManager.Inst().TranslateStr(item.text.Trim());
                    item.text = texto;
                }
            }
        }

        private void ReplaceTextGUI(){
            Object[] objects = FindObjectsOfTypeAll(typeof(InstantGuiElement));
            foreach (Object obj in objects){
                InstantGuiElement item = (InstantGuiElement) obj;
                if (item != null){
                    if (excludeTranslate != null && GameManager.ArrayContains(excludeTranslate, item)){
                        continue;
                    }
                    string texto = LocaleManager.Inst().TranslateStr(item.text.Trim());
                    item.text = texto;
                }
            }
        }
    }
}