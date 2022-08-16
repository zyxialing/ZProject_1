using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Table;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static ResHanderManager;

public partial class LoadingPanel : BasePanel
{
    public override void Init(params object[] args)
    {
        base.Init(args);
        panelLayer = PanelLayer.Tips;
       adressPath = "Overlay/Loading/LoadingPanel";
    }

    public override void OnShowing()
    {

    }

    public override void OnOpen()
    {
        StartCoroutine(LoadRes());
    }

    public override void OnHide()
    {

    }

    public override void OnClosing()
    {

    }

    private IEnumerator LoadRes()
    {
        ZLogUtil.LogError("���ؿ�ʼ");
        slider_LoadingBar.value = 0;
        AdressablePath adressablePath = Resources.Load<AdressablePath>(typeof(AdressablePath).ToString());
        bool loadCompleted = false;
        ResHanderManager.Instance.PreloadAudioAssets(adressablePath.commonAudioPaths,()=> {
            loadCompleted = true;
        });

        while (!loadCompleted)
        {
            yield return null;
        }
        ZLogUtil.LogError("���ع�����Ч���");
        UpdateProgress(0.1f);
        float progress = 0.2f;
        ExcelConfig.Instance.LoadAllExcel();//���ر�
        //var data = ExcelConfig.Instance.GetExcelData().excel_characterMap;
        //foreach (var item in data)
        //{
        //    Debug.Log(item.Value.id);
        //}
        Destroy(GameObject.Find("ExcelLoader"));
        yield return null;
        ZLogUtil.LogError("���ر����");
        UpdateProgress(progress);
        for (int i = 0; i < 4; i++)
        {
            UpdateProgress(progress);
            progress += 0.2f;
            yield return new WaitForSeconds(0.4f);
        }

        UpdateProgress(1f);
        UIManager.Instance.Init();
        ZLogUtil.LogError("UI��ʼ�����");
        //GameControler.Instance.Init();
        yield return null;
        while (true)
        {
            if (slider_LoadingBar.value >= 1)
            {
                EnterGame();
                break;
            }
            yield return null;
        }

    }

    private void UpdateProgress(float progress)
    {
        slider_LoadingBar.DOKill(false);
        slider_LoadingBar.DOValue(progress, 1f);
    }

    private void EnterGame()
    {
        ZLogUtil.LogError("����ؿ�ѡ�����");
        JumpManager.JumpPanel<LevelPanel>();
        Close();
    }

    public void Update()
    {
        if (slider_progress != null && slider_LoadingBar != null)
        {
            slider_progress.text = (slider_LoadingBar.value).ToString("#00.00%");
        }
    }
}