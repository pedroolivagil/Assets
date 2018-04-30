using System.IO;
using SharpConfig;
using UnityEngine;

public class Config{
    public string ConfigFileName = Path.Combine(Application.persistentDataPath, "hundirlaflota.ini");
    private Configuration config;

    public enum Section{
        PlayerSettings,
        System,
        User
    }

    public enum Key{
        ScreenWidth,
        ScreenHeight,
        Locale,
        Level,
        Difficult,
        SoundLevel,
        MusicLevel,
        ID,
        AutoLogin
    }

    public Configuration GetConfig(){
        return config;
    }

    public void Init(){
        if (!File.Exists(ConfigFileName)){
            using (StreamWriter sw = new StreamWriter(ConfigFileName)){
                sw.WriteLine("");
            }
            config = Configuration.LoadFromFile(ConfigFileName);
            WriteConfig(Section.User, Key.ID, 0);
            WriteConfig(Section.User, Key.AutoLogin, 0);
            WriteConfig(Section.PlayerSettings, Key.Level, 1);
            WriteConfig(Section.PlayerSettings, Key.Difficult, 1);
            WriteConfig(Section.PlayerSettings, Key.SoundLevel, 10);
            WriteConfig(Section.PlayerSettings, Key.MusicLevel, 10);
            WriteConfig(Section.PlayerSettings, Key.ScreenWidth, 1920);
            WriteConfig(Section.PlayerSettings, Key.ScreenHeight, 1080);
            WriteConfig(Section.System, Key.Locale, Application.systemLanguage.ToString());
            config.SaveToFile(ConfigFileName);
        } else{
            config = Configuration.LoadFromFile(ConfigFileName);
        }
//        PreLoadDb.Inst().CleanDb();
//        PreLoadDb.Inst().CreateDb();
    }

    // Update is called once per frame
    public void UpdateFile(){
        config.SaveToFile(ConfigFileName);
    }

    public void WriteConfig(Section section, Key key, string value){
        if (config != null){
            Debug.Log(key + " => " + value);
            config[section.ToString()][key.ToString()].StringValue = value;
        }
    }

    public void WriteConfig(Section section, Key key, int value){
        if (config != null){
            Debug.Log(key + " => " + value);
            config[section.ToString()][key.ToString()].IntValue = value;
        }
    }

    public void WriteConfig(Section section, Key key, float value){
        if (config != null){
            Debug.Log(key + " => " + value);
            config[section.ToString()][key.ToString()].FloatValue = value;
        }
    }

    public void WriteConfig(Section section, Key key, double value){
        if (config != null){
            Debug.Log(key + " => " + value);
            config[section.ToString()][key.ToString()].DoubleValue = value;
        }
    }

    public void WriteConfig(Section section, Key key, bool value){
        if (config != null){
            Debug.Log(key + " => " + value);
            config[section.ToString()][key.ToString()].BoolValue = value;
        }
    }

    public string ReadConfigString(Section section, Key key){
        if (config != null){
            return config[section.ToString()][key.ToString()].StringValue;
        }
        return null;
    }

    public int ReadConfigInteger(Section section, Key key){
        if (config != null){
            return config[section.ToString()][key.ToString()].IntValue;
        }
        return 0;
    }

    public float ReadConfigFloat(Section section, Key key){
        if (config != null){
            return config[section.ToString()][key.ToString()].FloatValue;
        }
        return 0.0f;
    }

    public double ReadConfigDouble(Section section, Key key){
        if (config != null){
            return config[section.ToString()][key.ToString()].DoubleValue;
        }
        return 0.0;
    }

    public bool ReadConfigBoolean(Section section, Key key){
        if (config != null){
            return config[section.ToString()][key.ToString()].BoolValue;
        }
        return false;
    }
}