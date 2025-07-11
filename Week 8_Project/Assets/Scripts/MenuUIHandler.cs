using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
        MainManager.Instance.unitColour = color;
       
    }
    
    private void Start()
    {
        
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
        ColorPicker.SelectColor(MainManager.Instance.unitColour);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        MainManager.Instance.SaveColour();
#if UNITY_EDITOR
        Debug.Log("This is the game in the editor");
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
        Debug.Log("This is a build of the game");
#endif
    }

    public void SaveColorClicked()
    {
        MainManager.Instance.SaveColour();
    }

    public void LoadColorClicked()
    {
        MainManager.Instance.LoadColour();
        ColorPicker.SelectColor(MainManager.Instance.unitColour);

    }
}
