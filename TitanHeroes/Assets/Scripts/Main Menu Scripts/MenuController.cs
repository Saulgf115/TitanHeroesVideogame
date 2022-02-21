using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject heroSelectPanel;


    public void StartGame()
    {
        SceneManager.LoadScene(SceneNames.GAMEPLAY);
    }

    public void OpenSelectPanel()
    {
        heroSelectPanel.SetActive(true);
    }

    public void CloseHeroSelectPanel()
    {
        heroSelectPanel.SetActive(false);
    }

    public void HeroSelected()
    {
        print("The selected index is : " + EventSystem.current.currentSelectedGameObject.name);
    }

}
