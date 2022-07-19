using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCameraFllow : MonoBehaviour
{
    public Transform byFllow;
    public float positionSpeed;
    void Start()
    {
        byFllow = GameObject.FindGameObjectWithTag("SceneCamera").transform;
    }

    private void LateUpdate()
    {
        byFllow.position = Vector3.Lerp(byFllow.position, transform.position, Time.deltaTime * positionSpeed);
    }
}
