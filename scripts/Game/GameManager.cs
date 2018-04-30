using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;
using Random = System.Random;

public class GameManager : MonoBehaviour{
    public static readonly string DIALOG_TAG = "Dialog";
    public int screenWidth = 1920;
    public int screenHeigth = 1080;
    public GUISkin Skin;
    private static int gameMode;
    private static List<Resolution> listResolution;

    private static Config config;

    // Use this for initialization
    void Start(){
        DontDestroyOnLoad(gameObject);
        config = new Config();
        config.Init();
        listResolution = new List<Resolution>();
        foreach (Resolution res in Screen.resolutions){
            if (!listResolution.Contains(res)){
                listResolution.Add(res);
                if (res.width.Equals(screenWidth) && res.height.Equals(screenHeigth)){
                    SetResolutionGame(res);
                }
            }
        }
    }

    public List<Resolution> GetListResolution(){
        return listResolution;
    }

    public void SetResolutionGame(Resolution resolution){
        Debug.Log("Resolution has been changed: " + resolution.width + "x" + resolution.height);
        Screen.SetResolution(resolution.width, resolution.height, true, resolution.refreshRate);
        Screen.fullScreen = true;
    }

    public void ToogleFullScreen(){
        Screen.fullScreen = !Screen.fullScreen;
    }

    public static bool IsNull(object obj){
        return obj == null || obj.Equals("");
    }

    public static bool IsNotNull(object obj){
        return !IsNull(obj);
    }

    public static IEnumerator ExitGame(float time){
        Debug.Log("Exiting...");
        yield return new WaitForSeconds(time);
        Debug.Log("Exited");
        Application.Quit();
    }

    public static void ChangeScreen(string screen, bool preload = false){
        if (preload){
            LoadingScene.SetNavigateScene(screen);
            SceneManager.LoadScene(GameScenes.LoadScene, LoadSceneMode.Single);
        } else{
            SceneManager.LoadScene(screen, LoadSceneMode.Single);
        }
        Time.timeScale = 1;
    }

    public static void Reload(){
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public static bool ArrayContains(Object[] array, Object item){
        return new List<Object>(array).Contains(item);
    }

    public static Component GetComponentWithName(string name){
        return GetComponentWithName(name, null);
    }

    public static Component GetComponentWithName(string name, string tag){
        Component retorno = null;
        Canvas c = FindObjectOfType<Canvas>();
        Component[] objs = c.GetComponentsInChildren(typeof(Transform), true);
        foreach (Component gObj in objs){
            if (gObj.name == name){
                if (tag != null){
                    if (gObj.CompareTag(tag)){
                        retorno = gObj;
                    }
                } else{
                    retorno = gObj;
                }
            }
        }
        return retorno;
    }

    public static InstantGuiElement GetGuiComponentWithName(string name){
        return GetGuiComponentWithName(name, null);
    }

    public static InstantGuiElement GetGuiComponentWithName(string name, string tag){
        InstantGuiElement retorno = null;
        InstantGui gui = FindObjectOfType<InstantGui>();
        InstantGuiElement[] elements = gui.GetComponentsInChildren<InstantGuiElement>(true);
        foreach (InstantGuiElement element in elements){
            if (element.name.Equals(name) || (tag != null && element.CompareTag(tag))){
                retorno = element;
                break;
            }
        }
        return retorno;
    }

    public static void MoveInHierarchy(GameObject gameObject){
        gameObject.transform.SetAsLastSibling();
    }

    public static Config GetConfig(){
        return config;
    }

    public static long GetCurrentTimestamp(){
        return (long) (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds * 1000;
    }

    public static DateTime GetDateTimeFromLong(long time){
        DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return start.AddMilliseconds(time).ToLocalTime();
    }

    public static int RandomBetween(){
        return RandomBetween(1, 50);
    }

    public static int RandomBetween(int end){
        return RandomBetween(1, end);
    }

    public static int RandomBetween(int start, int end){
        Random rnd = new Random();
        return rnd.Next(start, end + 1);
    }

    public static string CryptString(string inputString){
        SHA256Managed hash = new SHA256Managed();
        byte[] signatureData = hash.ComputeHash(new UnicodeEncoding().GetBytes(inputString));
        return Convert.ToBase64String(signatureData);
// For PHP read password
// print base64_encode(hash("sha256",mb_convert_encoding("abcdefg","UTF-16LE"),true));
    }

    public static string FillStringWithChar(object obj, string str, int maxLeng){
        StringBuilder result = new StringBuilder();
        int diff = maxLeng - obj.ToString().Length;
        for (int x = 0; x < diff; x++){
            result.Append(str);
        }
        result.Append(obj);
        return result.ToString();
    }

    public static double Round(double num){
        return Round(num, 2);
    }

    public static double Round(double num, int decimals){
        return Math.Round(num, decimals);
    }
}