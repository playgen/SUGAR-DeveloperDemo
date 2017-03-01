using System.Collections;
using PlayGen.SUGAR.Unity;
using UnityEngine;

public class FriendsPanelController : BasePanelController {

    public override void Display()
    {
        SUGARManager.UserFriend.Display();

        base.Display();
    }

    public override IEnumerator CheckPanel()
    {
        yield return base.CheckPanel();
        // Check if the panel is deactivated
        while (true)
        {
            if (!SUGARManager.UserFriend.IsActive)
            {
                ReturnToMenu();
            }
            yield return null;
        }
    }
}
