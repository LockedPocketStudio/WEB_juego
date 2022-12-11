using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Creditos : MonoBehaviour
{
    public Button btnS;
    public VideoPlayer cred;

    void Start()
    {
        btnS.onClick.AddListener(() => SceneManager.LoadScene(0));
        cred = GetComponent<VideoPlayer>();
        cred.Play();
        cred.loopPointReached += CheckOver;
        //StartCoroutine("WaitForMovieEnd");

    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(0);//the scene that you want to load after the video has ended.
    }

    /*
    public IEnumerator WaitForMovieEnd()
    {
        while (cred.isPlaying)
        {
            yield return new WaitForEndOfFrame();
         
        }
        OnMovieEnded();
    }
 
     void OnMovieEnded()
    {
        SceneManager.LoadScene(0);
    }
    */
}

