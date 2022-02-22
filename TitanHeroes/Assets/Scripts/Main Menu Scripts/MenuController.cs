using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MenuController : MonoBehaviour
{
    public GameObject heroSelectPanel;


    public void StartGame()
    {
        //SceneManager.LoadScene(SceneNames.GAMEPLAY);
        LoadingScreen.instance.LoadLevel(SceneNames.GAMEPLAY);
        //LoadingScreen.instance.LoadLevelAsync(SceneNames.GAMEPLAY);
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

        GameManager.instance.selectedHeroIndex = int.Parse(EventSystem.current.currentSelectedGameObject.name);

        //if(!EventSystem.current.currentSelectedGameObject.activeInHierarchy)
        //{
        //    EventSystem.current.currentSelectedGameObject.SetActive(true);
        //}
    }

}
