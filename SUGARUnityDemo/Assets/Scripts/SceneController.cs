using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private const string MenuSceneName = "1_SetupAndLogin";
    private const string FriendSceneName = "2_Friends";
    private const string GroupSceneName = "3_Groups";
    private const string ResourceSeneName = "4_Resources";
    private const string AchievementSceneName = "5_Achievements";
    private const string LeaderboardSceneName = "6_Leaderboards";

    protected void GoToMenu()
    {
        LoadScene(MenuSceneName);
    }

    protected void GoToFriends()
    {
        LoadScene(FriendSceneName);
    }

    protected void GoToGroups()
    {
        LoadScene(GroupSceneName);
    }

    protected void GoToResources()
    {
        LoadScene(ResourceSeneName);
    }

    protected void GoToAchievements()
    {
        LoadScene(AchievementSceneName);
    }

    protected void GoToLeaderboards()
    {
        LoadScene(LeaderboardSceneName);
    }

    private static void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
