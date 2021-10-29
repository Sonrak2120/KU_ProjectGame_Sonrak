using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScenManager : MonoBehaviour
{
    public void GoToPlayground()
    {
        //PlayerPrefs.SetInt("coincount",0);
        PlayerPrefs.DeleteKey("coincount");
        SceneManager.LoadScene("SampleScene");
    }

    public void CotinuePlay()
    {
        if (PlayerPrefs.HasKey("PrevScene"))
        {
            string previousScene = PlayerPrefs.GetString("PrevScene");
            SceneManager.LoadScene(previousScene);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
