using System.IO;
using UnityEngine;
using LitJson;
using System;
using System.Text;

/**
 * Maneja el idioma de la aplicación. Carga el idioma del sistema y el inglés por defecto. 
 * Si no encuentra una etiqueta en el idioma del sistema, la busca en el inglés. 
 * En caso que tampoco la encuentre, devuelve el texto de la etiqueta que se busca
 */
public class LocaleManager{
    private static LocaleManager instance;
    private JsonData jsonData;
    private JsonData jsonDataDef;
    public string textReplace = "{$VAR$}";
    public string textReplaceLineBreak = "{$BR$}";

    public static LocaleManager Inst(){
        init();
        return instance;
    }

    public static void init(){
        if (instance == null){
            instance = new LocaleManager();
            instance.ReadJSON();
        }
    }

    // Use this for initialization
    void Awake(){
        init();
    }

    public void ReadJSON(){
        TextAsset assetLocale;
        TextAsset assetLocaleDef;
        try{
            string url = Path.Combine("Locale", Application.systemLanguage.ToString());
            string defUrl = Path.Combine("Locale", "English");
            assetLocale = Resources.Load<TextAsset>(url);
            assetLocaleDef = Resources.Load<TextAsset>(defUrl);
        }
        catch (FileNotFoundException e){
            string url = Path.Combine("Locale", "English");
            Debug.Log(e.Message);
            assetLocale = Resources.Load<TextAsset>(url);
            assetLocaleDef = Resources.Load<TextAsset>(url);
        }
        if (assetLocale != null && assetLocaleDef != null){
            string sText = Encoding.UTF8.GetString(assetLocale.bytes);
            string sTextDef = Encoding.UTF8.GetString(assetLocaleDef.bytes);
            jsonData = JsonMapper.ToObject(sText);
            jsonDataDef = JsonMapper.ToObject(sTextDef);
        }
    }

    public object Translate(string key){
        object retorno = null;
        if (jsonData != null){
            try{
                retorno = jsonData[key];
            }
            catch (Exception e){
                Debug.Log(e.Message);
                try{
                    retorno = jsonDataDef[key];
                }
                catch (Exception ex){
                    Debug.Log(ex);
                    retorno = key;
                }
            }
        }
        return retorno;
    }

    public string TranslateStr(string key){
        string retorno = null;
        if (jsonData != null){
            try{
                retorno = jsonData[key].ToString();
                retorno = retorno.Replace(textReplaceLineBreak, "\n");
            }
            catch (Exception e){
                Debug.Log(e.Message);
                try{
                    retorno = jsonDataDef[key].ToString();
                    retorno = retorno.Replace(textReplaceLineBreak, "\n");
                }
                catch (Exception ex){
                    Debug.Log(ex.Message);
                    retorno = key;
                }
            }
        }
        return retorno;
    }

    public string TranslateStr(string key, string[] parametros){
        string texto = TranslateStr(key);
        foreach (string parm in parametros){
            texto = texto.Replace(textReplace, parm);
        }
        return texto;
    }

    public string ValuesString(){
        if (jsonData == null){
            if (jsonDataDef == null){
                return null;
            }
            return jsonDataDef.ToString();
        }
        return jsonData.ToString();
    }
}