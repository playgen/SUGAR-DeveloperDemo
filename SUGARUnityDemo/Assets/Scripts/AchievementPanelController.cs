using System.Collections;
using PlayGen.SUGAR.Unity;
using UnityEngine;

public class AchievementPanelController : BasePanelController
{
    public override void Display()
    {
        SUGARManager.Achievement.DisplayList();

        base.Display();
    }

    public override IEnumerator CheckPanel()
    {
        yield return base.CheckPanel();
        // Check if the panel is deactivated
        while (true)
        {
            if (!SUGARManager.Achievement.IsActive)
            {
                ReturnToMenu();
            }
            yield return null;
        }
    }
}