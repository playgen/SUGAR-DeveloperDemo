using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendElement : MonoBehaviour {

    public void Setup(string friendName)
    {
        transform.FindChild("Name").GetComponent<Text>().text = friendName;
    }
}
