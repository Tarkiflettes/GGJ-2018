using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public string Level1;
    public string Level2;
    public Button PlayButton1;
    public Button PlayButton2;
    public Button QuitButton;

    // Use this for initialization
    void Start()
    {
        PlayButton1.onClick.AddListener(() => Play1());
        PlayButton2.onClick.AddListener(() => Play2());
        QuitButton.onClick.AddListener(() => Quit());
    }

    private void Play1()
    {
        SceneManager.LoadScene(Level1);
    }
    private void Play2()
    {
        SceneManager.LoadScene(Level2);
    }

    private void Quit()
    {
        Application.Quit();
    }
}

