using UnityEngine;

public class AccountPanelController : BasePanelController
{
    public GameObject MainMenu;

    void Awake()
    {
        MainMenu.SetActive(false);
    }

    public override void Display()
    {
        MainMenu.SetActive(true);
    }
}
