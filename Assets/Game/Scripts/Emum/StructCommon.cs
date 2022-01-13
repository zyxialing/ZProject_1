﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public struct PropItem
{
    public Image itemIcon;
    public Image itemFrame;
    public GameObject itemObj;
    public TextMeshPro itemCount;

    public PropItem(Image icon,Image frame,GameObject obj,TextMeshPro textMesh)
    {
        itemIcon = icon;
        itemFrame = frame;
        itemObj = obj;
        itemCount = textMesh;
    }
}