using System.Collections;
using System.Collections.Generic;
using ICSharpCode.SharpZipLib.Core;
using PlayGen.SUGAR.Unity;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResources : MonoBehaviour
{
    public GameObject ResourceElement;

    private Transform _content;

    struct Resource
    {
        public string Name;
        public string Quantity;
    }

    private List<Resource> resources = new List<Resource>
    {
        new Resource {Name = "Gold", Quantity = "1"},
        new Resource {Name = "Silver", Quantity = "5"},
        new Resource {Name = "Bronze", Quantity = "15"}
    };
    void Start()
    {
        _content = transform.GetComponentInChildren<ScrollRect>().content;
        GenerateResourceList();
    }

    private void GenerateResourceList()
    {
        DestroyAllChildren(_content);

        foreach (var resource in SUGARManager.Resource.UserGameResources)
        {
            var go = Instantiate(ResourceElement);
            go.transform.SetParent(_content);
            go.GetComponent<ResourceElement>().Setup(resource.Key, resource.Value.ToString());
        }

        //foreach (var resource in resources)
        //{
        //    var go = Instantiate(ResourceElement);
        //    go.transform.SetParent(_content);
        //    go.GetComponent<ResourceElement>().Setup(resource.Name, resource.Quantity);
        //}
    }

    private void DestroyAllChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child);
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
