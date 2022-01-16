public partial class TopBanner : BasePanel
{
   private UnityEngine.GameObject stats_Energe;
   private UnityEngine.GameObject stats_Gold;
   private TMPro.TextMeshProUGUI text_Value;
   private UnityEngine.UI.Button button_Add;

   public override void AutoInit()
   {
        ServiceBinder.Instance.RegisterObj(this);
    this.stats_Energe = panel.transform.Find("StatusBar_Group/Stats_Energe").GetComponent<UnityEngine.GameObject>();
    this.stats_Gold = panel.transform.Find("StatusBar_Group/Stats_Gold").GetComponent<UnityEngine.GameObject>();
    this.text_Value = panel.transform.Find("StatusBar_Group/Stats_Gold/Text_Value").GetComponent<TMPro.TextMeshProUGUI>();
    this.button_Add = panel.transform.Find("StatusBar_Group/Stats_Gold/Button_Add").GetComponent<UnityEngine.UI.Button>();
   }
}
