using System.Collections;
using PlayGen.SUGAR.Unity;
using UnityEngine;

public class LeaderboardPanelController : BasePanelController {

    public override void Display()
    {
        SUGARManager.GameLeaderboard.DisplayList();
        base.Display();
    }

    public override IEnumerator CheckPanel()
    {
        yield return base.CheckPanel();
        // Check if the panel is deactivated
        while (true)
        {
            if (!SUGARManager.GameLeaderboard.IsActive)
            {
                ReturnToMenu();
            }
            yield return null;
        }
    }
}
