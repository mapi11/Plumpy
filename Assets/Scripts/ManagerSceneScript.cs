using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerSceneScript : MonoBehaviour
{
    public static ManagerSceneScript Instance;
    [SerializeField] private GameObject LoadingPanel;

    private string targetScene;

    private void Awake()
    {
        //if (Instance == null)
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}

        LoadingPanel.SetActive(false);
    }

    public void LoadScene(string SceneName)
    {
        targetScene = SceneName;
        StartCoroutine(LoadSceneRoutine());
        Time.timeScale = 1f;
    }


    private IEnumerator LoadSceneRoutine()
    {
        LoadingPanel.SetActive(true);

        AsyncOperation op = SceneManager.LoadSceneAsync(targetScene);
        while(!op.isDone)
            yield return null;

        LoadingPanel.SetActive(false);
    }




    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
    }
}
