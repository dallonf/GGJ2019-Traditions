using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void playTheGame()
    {
        SceneManager.LoadSceneAsync(SceneUtility.GetBuildIndexByScenePath("Scenes/GameLevels/ChristmasLights"));
    }

    public void quitGame()
    {
        Debug.Log("I quit");
        Application.Quit();
    }
}