using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public string Level;
    public Button PlayButton;
    public Button QuitButton;

    // Use this for initialization
    void Start()
    {
        PlayButton.onClick.AddListener(() => Play());
        QuitButton.onClick.AddListener(() => Quit());
    }

    private void Play()
    {
        Application.LoadLevel(Level);
    }

    private void Quit()
    {
        Application.Quit();
    }
}

