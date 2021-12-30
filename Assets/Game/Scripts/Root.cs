using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    void Start()
    {
        UIManager.Instance.OpenPanel<LoadingPanel>(()=> {
            ResLoader.Instance.GetScene("GameScene",null);
        });
       
    }
}
