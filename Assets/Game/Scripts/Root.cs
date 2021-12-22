using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    void Start()
    {
        ResLoader.Instance.GetScene("MainUI", ()=> {
            UIManager.Instance.OpenPanel<LoadingPanel>();
        });
    }
}
