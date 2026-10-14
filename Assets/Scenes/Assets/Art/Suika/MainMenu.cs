using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject GameSubmenu;
    [SerializeField] GameObject CreditsMenu;
    [SerializeField] GameObject mainMenu;
    
    void Start()
    {
        GameSubmenu.SetActive(false);
        CreditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    // loads game submenu
    public void Play()
    {
        GameSubmenu.SetActive(true);
        CreditsMenu.SetActive(false);
        mainMenu.SetActive(false);
    }
    public void Suika()
    {
        SceneManager.LoadScene("Suika");
    }
    public void FlightCalc()
    {
        SceneManager.LoadScene("FlightCalc");
    }
    public void Back()
    {
        GameSubmenu.SetActive(false);
        CreditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    //closes application
    public void Exit()
    {
        Application.Quit();
    }
    //loads credit screen where I tell Kaylie I love her
    public void Credits()
    {
        GameSubmenu.SetActive(false);
        CreditsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
}
