using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URL : MonoBehaviour
{
    [SerializeField] private string url;

    public void OnClick()
    {
        Application.OpenURL(url);
    }
}
