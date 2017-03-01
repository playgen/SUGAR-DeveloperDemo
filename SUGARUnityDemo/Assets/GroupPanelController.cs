using System.Collections;
using PlayGen.SUGAR.Unity;
using UnityEngine;

public class GroupPanelController : BasePanelController {

    public override void Display()
    {
        SUGARManager.UserGroup.Display();
        base.Display();
    }

    public override IEnumerator CheckPanel()
    {
        yield return base.CheckPanel();
        // Check if the panel is deactivated
        while (true)
        {
            if (!SUGARManager.UserGroup.IsActive)
            {
                GoToMenu();
            }
            yield return null;
        }
    }

}
