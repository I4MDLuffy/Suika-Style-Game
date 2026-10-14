using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private TextMeshProUGUI text;
    //private bool isPaused = false;
    [SerializeField] GameObject pauseMenu;
    //backgrounds
    [SerializeField] GameObject BackgroundMenu;
    [SerializeField] GameObject Background1;
    [SerializeField] GameObject Background2;
    [SerializeField] GameObject Background3;
    [SerializeField] GameObject Background4;
    [SerializeField] GameObject Background5;
    private string[] pochaccoWords = {"You make my heart flutter", "You can do it!!", "You're so gorgeous", "I love you Kay!!", "You're the cutest!!!!", "I love you forever Kaylie <3   -A", "You look beautiful today.", "You're the best!", "Your outfit is so cute today!!!"};
    private void Start() 
    {
     //   score = GameObject.Find("Score").GetComponent<Score>();
        text = GameObject.Find("PochacoMessage").GetComponent<TextMeshProUGUI>();
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        //isPaused = true;

    }
    public void Restart()
    {
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        //isPaused = false;
    }
    public void Pochaco()
    {
        text.text = pochaccoWords[Random.Range(0,9)];
    }
    public void BgMenu()
    {
        BackgroundMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }
    //BACKGROUNDS
    public void Back()
    {
        BackgroundMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
    public void Default()
    {
        Background1.SetActive(false);
        Background2.SetActive(false);
        Background3.SetActive(false);
        Background4.SetActive(false);
        Background5.SetActive(false);
    }
    public void BackGround1()
    {
        Background1.SetActive(true);
        Background2.SetActive(false);
        Background3.SetActive(false);
        Background4.SetActive(false);
        Background5.SetActive(false);
    }
    public void BackGround2()
    {
        Background1.SetActive(false);
        Background2.SetActive(true);
        Background3.SetActive(false);
        Background4.SetActive(false);
        Background5.SetActive(false);
    }
    public void BackGround3()
    {
        Background1.SetActive(false);
        Background2.SetActive(false);
        Background3.SetActive(true);
        Background4.SetActive(false);
        Background5.SetActive(false);
    }
    public void BackGround4()
    {
        Background1.SetActive(false);
        Background2.SetActive(false);
        Background3.SetActive(false);
        Background4.SetActive(true);
        Background5.SetActive(false);
    }
    public void BackGround5()
    {
        Background1.SetActive(false);
        Background2.SetActive(false);
        Background3.SetActive(false);
        Background4.SetActive(false);
        Background5.SetActive(true);
    }
}
