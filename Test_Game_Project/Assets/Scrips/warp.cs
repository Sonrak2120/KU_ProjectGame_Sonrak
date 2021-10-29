using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class warp : MonoBehaviour
{
    public string sceneName;
    public AudioSource warpSound;
    private void OnTriggerEnter(Collider other)
    {
        //print(other.gameObject.name);
        if (other.gameObject.tag=="player")
        {
            Invoke("LoadNextScence", 1f);
            PlayerPrefs.SetString("PrevScene", sceneName);
            var player = other.gameObject.GetComponent<PlayerRegi>();
            PlayerPrefs.SetInt("coincount", player.coincount);
            //if(warpSound !=null)
            warpSound?.Play();
        }
    }

    void LoadNextScence()
    {
        SceneManager.LoadScene(sceneName);
    }
}
