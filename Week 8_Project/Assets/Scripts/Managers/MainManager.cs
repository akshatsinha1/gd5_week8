using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; } // auto implemented property
    public Color unitColour;

    private void Awake()
    {
        //makes sure that there is always one copy of this object
        if(Instance != null)
        {
            Destroy(gameObject);
        }

        // define the current object as  Instance.
        Instance = this;

        //makes the object persistent between scenes
        DontDestroyOnLoad(gameObject);
        LoadColour();
    }

    [System.Serializable]
    class SaveData
    {
        public Color _unitColour;
    }

    public void SaveColour()
    {
        Debug.Log("Saved");
        SaveData data = new SaveData();
        data._unitColour = unitColour;

        string jsonData = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonData);

    }

    public void LoadColour()
    {
        Debug.Log("Loaded");
        string path = Application.persistentDataPath + "/savefile.json";

        if(File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(jsonData);

            unitColour = data._unitColour;
        }
    }

}


