using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Table;
using UnityEngine;
using UnityEngine.UI;
using static ResHanderManager;

public partial class LoadingPanel : BasePanel
{
    ResHanderMono resHanderMono;
    public override void Init(params object[] args)
    {
        base.Init(args);
        panelLayer = PanelLayer.Tips;
       adressPath = "Overlay/Loading/LoadingPanel";
    }

    public override void OnShowing()
    {
        resHanderMono = ResHanderManager.Instance.Init();
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
        slider_LoadingBar.value = 0;
        yield return resHanderMono.InitCommonAudioRes();
        UpdateProgress(0.1f);
        float progress = 0.2f;
        yield return LoadExcel();

        for (int i = 0; i < 4; i++)
        {
            UpdateProgress(progress);
            progress += 0.2f;
            yield return new WaitForSeconds(0.4f);
        }

        UpdateProgress(1f);
        UIManager.Instance.Init();
        GameControler.Instance.Init();
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

    private IEnumerator LoadExcel()
    {
        int tabelCount = 0;
        Config<excel_affix>.InitConfig((data) => { tabelCount++; });
        Config<excel_character>.InitConfig((data) => { tabelCount++; });
        Config<excel_equip>.InitConfig((data) => { tabelCount++; });
        Config<excel_language>.InitConfig((data) => { tabelCount++; });
        Config<excel_material>.InitConfig((data) => { tabelCount++; });
        Config<excel_prop>.InitConfig((data) => { tabelCount++; });
        while (tabelCount<6)
        {
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
        UIManager.Instance.OpenPanel<TopBanner>();
        UIManager.Instance.OpenPanel<MainPanel>(()=> {
            Close();
        });
    }

    public void Update()
    {
        if (slider_progress != null && slider_LoadingBar != null)
        {
            slider_progress.text = (slider_LoadingBar.value).ToString("#00.00%");
        }
    }
}