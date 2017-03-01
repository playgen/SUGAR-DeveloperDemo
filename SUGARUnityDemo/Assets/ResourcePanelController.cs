using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePanelController : BasePanelController
{

    public GameObject ResourcePanel;

    public override void Display()
    {
        ResourcePanel.SetActive(true);
        base.Display();
    }

    public override IEnumerator CheckPanel()
    {
        yield return base.CheckPanel();
        // Check if the panel is deactivated
        while (true)
        {
            if (!ResourcePanel.activeSelf)
            {
                GoToMenu();
            }
            yield return null;
        }
    }
}
