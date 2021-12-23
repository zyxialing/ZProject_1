public partial class LoadingPanel : BasePanel
{
   private UnityEngine.UI.Slider slider_LoadingBar;
   private TMPro.TextMeshProUGUI slider_progress;

   public override void AutoInit()
   {
    this.slider_LoadingBar = panel.transform.Find("Slider_LoadingBar").GetComponent<UnityEngine.UI.Slider>();
    this.slider_progress = panel.transform.Find("Slider_LoadingBar/Slider_progress").GetComponent<TMPro.TextMeshProUGUI>();
   }
}
