using System.Collections;
using PlayGen.SUGAR.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasePanelController : SceneController
{
    
    void CheckLoggedIn()
    {
        if (SUGARManager.CurrentUser != null)
        {
            Display();
        }
        else
        {
            SUGARManager.Account.DisplayPanel(success =>
            {
                Display();
            });
        }
    }

    void OnEnable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += SceneManagerOnSceneLoaded;
    }
    void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= SceneManagerOnSceneLoaded;
    }

    private void SceneManagerOnSceneLoaded(Scene arg0, LoadSceneMode loadSceneMode)
    {
        CheckLoggedIn();    
    }
    public virtual void Display()
    {
        StartCoroutine(CheckPanel());
    }

    public virtual IEnumerator CheckPanel()
    {
        yield return new WaitForSeconds(1f);
    }

    protected void ReturnToMenu()
    {
        GoToMenu();
    }

}