using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public GameObject credits;

    public GameObject buttons;
    public GameObject title;

    bool videoRodando = false;

    public GameObject video;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (videoRodando == false)
        {
            if (video.GetComponent<VideoPlayer>().isPlaying == true) { videoRodando = true; }
        }
        else
        {
            if (video.GetComponent<VideoPlayer>().isPlaying == false)
            {
                video.SetActive(false);
                buttons.SetActive(true);
                title.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            video.SetActive(false);
            buttons.SetActive(true);
            title.SetActive(true);
        }
    }

    public void Play() 
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credits() 
    {
        title.SetActive(false);
        buttons.SetActive(false);
        credits.SetActive(true);
    }

    public void Return() 
    {
        title.SetActive(true);
        buttons.SetActive(true);
        credits.SetActive(false);
    }

}
