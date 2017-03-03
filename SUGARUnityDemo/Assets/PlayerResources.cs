using System.Collections;
using System.Collections.Generic;
using ICSharpCode.SharpZipLib.Core;
using PlayGen.SUGAR.Unity;
using PlayGen.Unity.Utilities.Loading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResources : MonoBehaviour
{
    public GameObject ResourceElement;
    public GameObject FriendElement;

    private Transform _content;

    private string _giftingResource;
    private long _giftingAmount;

    private Text _title;

    void Start()
    {
        _content = transform.GetComponentInChildren<ScrollRect>().content;
        _title = transform.FindChild("Title").GetComponent<Text>();
        GenerateResourceList();
    }

    private void GenerateResourceList()
    {
        _title.text = "Resources";
        _giftingResource = "";

        DestroyAllChildren(_content);

        foreach (var resource in SUGARManager.Resource.UserGameResources)
        {
            var go = Instantiate(ResourceElement);
            go.transform.SetParent(_content);
            go.GetComponent<ResourceElement>().Setup(resource.Key, resource.Value.ToString());
            go.GetComponent<Button>().onClick.AddListener(() => Gift(resource.Key, resource.Value));
        }
    }

    private void GenerateFriendsList()
    {
        _title.text = "Resources - " + _giftingResource + " (" + _giftingAmount + ")";
        DestroyAllChildren(_content);

        SUGARManager.UserFriend.GetFriendsList(success =>
        {
            foreach (var friend in SUGARManager.UserFriend.Friends)
            {
                var go = Instantiate(FriendElement);
                go.transform.SetParent(_content);
                go.GetComponent<FriendElement>().Setup(friend.Actor.Name);
                go.GetComponentInChildren<Button>().onClick.AddListener(() => GiveResourceToFriend(friend.Actor.Id));
            }
        });

        
    }

    private void DestroyAllChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }

    public void GiveResourceToFriend(int id)
    {
        if (_giftingAmount <= 0)
        {
            return;
        }
        SUGARManager.Resource.Transfer(id, _giftingResource, 1, GiveResourceCallback);
        SUGARManager.Unity.StartSpinner("Sending Gift");
    }

    private void GiveResourceCallback(bool success)
    {
        if (success)
        {
            _giftingAmount--;
            _title.text = "Resources - " + _giftingResource + " (" + _giftingAmount + ")";
            SUGARManager.Unity.StopSpinner("Success", 1f);
        }
        else
        {
            SUGARManager.Unity.StopSpinner("Failed", 1f);
        }
    }
    public void Gift(string resource, long available)
    {
        _giftingResource = resource;
        _giftingAmount = available;
        GenerateFriendsList();
    }
    public void Close()
    {
        if (_giftingResource != "")
        {
            GenerateResourceList();
        }
        else
        {
            SUGARManager.Unity.DisableObject(gameObject);
        }
    }
}
