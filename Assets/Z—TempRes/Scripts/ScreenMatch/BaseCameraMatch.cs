using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZFramework;

public class BaseCameraMatch : MonoBehaviour
{
    
    public AnimationCurve animationCurveX;
    public AnimationCurve animationCurveY;
    public Vector2 minYZ;
    public Vector2 maxYZ;

    public Vector2 minScreen;
    public Vector2 maxScreen;

    private void Awake()
    {
        FixedCameraPosition();
    }
    void FixedCameraPosition()
    {
        float scale = maxScreen.y / maxScreen.x - minScreen.y / minScreen.x;
        float screenScale = Screen.height / (float)Screen.width - minScreen.y / minScreen.x;

        float time = screenScale / scale;

        if (time < 0)
        {
            time = 0;
        }
        if (time > 1)
        {
            time = 1;
        }
      transform.position = new Vector3(0, ZMathUtil.GetEaseInOutFloat(time, animationCurveX),ZMathUtil.GetEaseInOutFloat(time, animationCurveY));

    }
}
