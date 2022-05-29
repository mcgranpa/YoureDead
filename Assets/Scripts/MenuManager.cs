using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{


    public void SelectLevel(int difficulty)
    {
        if (difficulty == 1) { SceneManager.LoadScene("Dungeon01"); }
        else if (difficulty == 2) { SceneManager.LoadScene("Dungeon02"); }
    }

    public void exitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }
}
