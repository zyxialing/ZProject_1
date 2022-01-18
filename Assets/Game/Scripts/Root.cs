using System.Collections;
using System.Collections.Generic;
using Table;
using UnityEngine;

public class Root : MonoBehaviour
{
    void Start()
    {

        UIManager.Instance.OpenPanel<LoadingPanel>(() =>
        {
            ResLoader.Instance.GetScene("GameScene", null);
        });

    }
}
