public partial class MainPanel : BasePanel
{
   private UnityEngine.RectTransform equip_Center;

   public override void AutoInit()
   {
    this.equip_Center = panel.transform.Find("Background/Equip_Center").GetComponent<UnityEngine.RectTransform>();
   }
}
