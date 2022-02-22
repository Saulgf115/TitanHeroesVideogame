using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen instance;

    public GameObject loadingBarHolder;
    public Image loadingBarProgress;

    public float progressValue = 1.1f;

    public float progressMultiplier1 = 0.5f;
    public float progressMultiplier2 = 0.07f;


    public bool loadMainMenuFirstTime = false;

    private void Awake()
    {
        MakeSingleton();
    }

    private void Update()
    {
        ShowLoadingScreen();
    }

    void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void LoadLevel(string levelName)
    {
        loadingBarHolder.SetActive(true);
        progressValue = 0f;

        //tis will stop the timne,pause the game
        Time.timeScale = 0.0f;

        SceneManager.LoadScene(levelName);
    }

    void ShowLoadingScreen()
    {
        if(progressValue < 1f)
        {
            progressValue += progressMultiplier1 * progressMultiplier2;

            loadingBarProgress.fillAmount = progressValue;

            if(progressValue >= 1f)
            {
                progressValue = 1.1f;
                loadingBarProgress.fillAmount = 0f;

                loadingBarHolder.SetActive(false);

                Time.timeScale = 1.0f;
            }
        }
    } //show loading screen


    public void LoadLevelAsync(string levelName)
    {
        StartCoroutine(LoadAsynchronously(levelName));
    }

    IEnumerator LoadAsynchronously(string levelName)
    {
        AsyncOperation opertaion = SceneManager.LoadSceneAsync(levelName);

        loadingBarHolder.SetActive(true);


        //while the operation is not done
        while(!opertaion.isDone)
        {
            float progress = opertaion.progress / 0.9f;

            loadingBarProgress.fillAmount = progress;

            if(progress >= 1.0f)
            {
                loadingBarHolder.SetActive(false);

            }


            //yield return null will skip next frame
            yield return null;
        }
    }


}
