using PlayGen.SUGAR.Unity;
using UnityEngine.UI;

public class MainMenuNavigation : SceneController
{ 
    private Text _usernameText;

    private Button _friendsButton;
    private Button _groupsButton;
    private Button _resourcesButton;
    private Button _achievementsButton;
    private Button _leaderboardButton;

    void Awake()
    {
        _usernameText = transform.FindChild("Username").GetComponent<Text>();
        _friendsButton = transform.FindChild("FriendsButton").GetComponent<Button>();
        _groupsButton = transform.FindChild("GroupsButton").GetComponent<Button>();
        _resourcesButton = transform.FindChild("ResourcesButton").GetComponent<Button>();
        _achievementsButton = transform.FindChild("AchievementsButton").GetComponent<Button>();
        _leaderboardButton = transform.FindChild("LeaderboardsButton").GetComponent<Button>();
    }

    void OnEnable()
    {
        _usernameText.text = SUGARManager.CurrentUser != null ? "Logged in as: " + SUGARManager.CurrentUser.Name : "";

        _friendsButton.onClick.AddListener(GoToFriends);
        _groupsButton.onClick.AddListener(GoToGroups);
        _resourcesButton.onClick.AddListener(GoToResources);
        _achievementsButton.onClick.AddListener(GoToAchievements);
        _leaderboardButton.onClick.AddListener(GoToLeaderboards);
    }

    void OnDisable()
    {
        _friendsButton.onClick.RemoveAllListeners();
        _groupsButton.onClick.RemoveAllListeners();
        _resourcesButton.onClick.RemoveAllListeners();
        _achievementsButton.onClick.RemoveAllListeners();
        _leaderboardButton.onClick.RemoveAllListeners();
    }
}
