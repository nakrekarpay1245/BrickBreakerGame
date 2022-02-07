using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public float staticProgres;

    public float dynamicProgres;

    public Slider progresSlider;

    public GameObject levelFinishPanel;

    public GameObject startText;

    public GameObject retryButton;

    public GameObject nextButton;

    public ParticleSystem confettiParticle;

    bool isGameSaved;

    //private void Awake()
    //{
    //    startText.SetActive(true);
    //    levelFinishPanel.SetActive(false);
    //}
    void Update()
    {
       // progresSlider.value = dynamicProgres / staticProgres;
    }

    public void IncreaseProgress()
    {
        dynamicProgres++;

        if (dynamicProgres >= staticProgres)
        {
            LevelCompleted();
        }
    }

    public void LevelCompleted()
    {
        levelFinishPanel.SetActive(true);
        confettiParticle.Play();
    }

    public void GameStarted()
    {
        //startText.SetActive(false);
    }

    public void LevelChanger(string name)
    {
        SceneManager.LoadScene(name);
    }
}
