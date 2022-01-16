using EnhancedUI.EnhancedScroller;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public partial class MP_PropItemCell : EnhancedScrollerCellView
{
    [Inject]public IPropMgr propMgr { get; set; }

    private List<PropItem> _propItems;
    public override void RefreshCellView()
    {
        AutoInit();
        InitItems();
        UpdateItems();
    }

    private void UpdateItems()
    {
        int index = dataIndex * 5;
        for (int i = 0; i < _propItems.Count; i++)
        {
            PropData propData = propMgr.GetPropDataByIndex(index + i);
            if (propData != null)
            {
                _propItems[i].itemObj.SetActive(true);
                _propItems[i].itemCount.gameObject.SetActive(true);
                _propItems[i].itemCount.text = propData.count.ToString();
            }
            else
            {
                _propItems[i].itemObj.SetActive(false);
            }
     
        }
    }

    private void InitItems()
    {
        if (_propItems == null)
        {
            _propItems = new List<PropItem>();
            for (int i = 0; i < 5; i++)
            {
                Image itemIcon = transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>();
                Image itemFrame = transform.GetChild(i).GetChild(0).GetComponent<Image>();
                GameObject itemObj = transform.GetChild(i).gameObject;
                TextMeshProUGUI itemCount = transform.GetChild(i).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
                PropItem propItem = new PropItem(itemIcon,itemFrame,itemObj,itemCount);
                _propItems.Add(propItem);
            }
            
        }
     
    }
}