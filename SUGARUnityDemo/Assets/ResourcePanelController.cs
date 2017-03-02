using System.Collections;
using System.Collections.Generic;
using PlayGen.SUGAR.Unity;
using UnityEngine;

public class ResourcePanelController : BasePanelController
{
    private GameObject _resourcePanel;

    public override void Display()
    {
        _resourcePanel = SUGARManager.Unity.CustomInterfaces["ResourcePanel"];
        SUGARManager.Unity.EnableObject(_resourcePanel);

        base.Display();
    }

    public override IEnumerator CheckPanel()
    {
        yield return base.CheckPanel();
        // Check if the panel is deactivated
        while (true)
        {
            if (!_resourcePanel.activeSelf)
            {
                GoToMenu();
            }
            yield return null;
        }
    }
}
