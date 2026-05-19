using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        HealthManager.instance.RestartHp();
        SceneManager.LoadScene("Level1");
    }
    public void BackToIntro()
    {
        SceneManager.LoadScene("Intro");
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
