using System.Collections;
using PlayGen.SUGAR.Unity;

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
                GoToMenu();
            }
            yield return null;
        }
    }
}
