using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene("SC_Main");
        //Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("SC_Main menu");
        Time.timeScale = 1f;
    }
    public void Test()
    {
        SceneManager.LoadScene("SC_Test");
        Time.timeScale = 1f;
    }
    public void TestLight()
    {
        SceneManager.LoadScene("SC_Test light");
        Time.timeScale = 1f;
    }
    public void TestBlock()
    {
        SceneManager.LoadScene("SC_Test block");
        Time.timeScale = 1f;
    }
    public void TestHealth()
    {
        SceneManager.LoadScene("SC_Test health");
        Time.timeScale = 1f;
    }
    public void TestDoors()
    {
        SceneManager.LoadScene("SC_Test doors");
        Time.timeScale = 1f;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
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
