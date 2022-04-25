using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerSceneScript : MonoBehaviour
{
    [Header("Loading panel")]
    [SerializeField] private static ManagerSceneScript Instance;
    [SerializeField] private GameObject LoadingPanel;
    private string targetScene;
    [SerializeField] private Image FadeImage;
    private float FadeTime = 0.3f;
    [Header("Image weel")]
    [SerializeField] private GameObject LoadingWeel;
    private float WheelSpeed = 2;
    private bool IsLoading;
    private float MinLoadTime = 1.5f;

    private void Awake()
    {
        //if (Instance == null)
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}

        LoadingPanel.SetActive(false);
        FadeImage.gameObject.SetActive(false);
    }

    public void LoadScene(string SceneName)
    {
        targetScene = SceneName;
        StartCoroutine(LoadSceneRoutine());
        Time.timeScale = 1f;
    }

    private IEnumerator LoadSceneRoutine()
    {
        IsLoading = true;

        FadeImage.gameObject.SetActive(true);
        FadeImage.canvasRenderer.SetAlpha(0);

        while (!Fade(1))
        {
            yield return null;
        }

        LoadingPanel.SetActive(true);
        StartCoroutine(SpinWheelRoutine());

        while (!Fade(0))
        {
            yield return null;
        }

        AsyncOperation op = SceneManager.LoadSceneAsync(targetScene);
        float elapsedLoadTime = 0f;

        while (!op.isDone)
        {
            elapsedLoadTime += Time.deltaTime;
            yield return null;
        }
        while (elapsedLoadTime < MinLoadTime)
        {
            elapsedLoadTime += Time.deltaTime;
            yield return null;
        }

        while (!Fade(1))
        {
            yield return null;
        }

        LoadingPanel.SetActive(false);

        while (!Fade(0))
        {
            yield return null;
        }

        IsLoading = false;
    }
    private bool Fade(float target)
    {
        FadeImage.CrossFadeAlpha(target, FadeTime, true);

        if (Mathf.Abs(FadeImage.canvasRenderer.GetAlpha() - target) <= 0.05f)
        {
            FadeImage.canvasRenderer.SetAlpha(target);
            return true;
        }
        return false;
    }

    private IEnumerator SpinWheelRoutine()
    {
        while (IsLoading)
        {
            LoadingWeel.transform.Rotate(0, 0, -WheelSpeed);
            yield return null;
        }
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
