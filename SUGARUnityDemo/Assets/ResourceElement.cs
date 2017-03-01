using UnityEngine;
using UnityEngine.UI;

public class ResourceElement : MonoBehaviour {

    public void Setup(string resourceName, string resourceQuantity)
    {
        transform.FindChild("Name").GetComponent<Text>().text = resourceName;
        transform.FindChild("Quantity").GetComponent<Text>().text = resourceQuantity;
    }
}
