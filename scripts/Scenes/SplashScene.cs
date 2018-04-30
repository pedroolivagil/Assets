using System.Collections;
using UnityEngine;

namespace Scenes{
    public class SplashScene : MonoBehaviour{
        // Use this for initialization
        public float timeWait = 0f;

        void Start(){
            StartCoroutine(LoadGame());
        }

        IEnumerator LoadGame(){
            yield return new WaitForSeconds(timeWait);
            GameManager.ChangeScreen(GameScenes.MainMenuScene, true);
        }
    }
}