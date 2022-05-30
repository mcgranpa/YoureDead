using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{

    [SerializeField] GameObject licenseInfo;

    public void LicenseInfo(bool turnOn)
    {
        if (turnOn) { licenseInfo.SetActive(true); }
        else { licenseInfo.SetActive(false); }
    }

    public void SelectLevel(int difficulty)
    {
        if (difficulty == 1) { SceneManager.LoadScene("Dungeon Easy"); }
        else if (difficulty == 2) { SceneManager.LoadScene("Dungeon Hard"); }
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
