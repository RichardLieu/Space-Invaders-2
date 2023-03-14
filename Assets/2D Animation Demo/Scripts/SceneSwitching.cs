using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitching : MonoBehaviour
{
    public void ScenceSwitcher()
    {
        SceneManager.LoadScene("MainGame");
    }

    public static void MaintoCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
