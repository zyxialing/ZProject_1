public partial class MainPanel : BasePanel
{
   private UnityEngine.RectTransform equip_Center;
   private MP_EquipScroll mP_EquipScroll;
   private MP_PropScroll mP_PropScroll;
   private UnityEngine.RectTransform mp_Compose;
   private UnityEngine.RectTransform mp_Role;

   public override void AutoInit()
   {
    this.equip_Center = panel.transform.Find("Background/Equip_Center").GetComponent<UnityEngine.RectTransform>();
    this.mP_EquipScroll = panel.transform.Find("Background/MP_EquipScroll").GetComponent<MP_EquipScroll>();
    this.mP_PropScroll = panel.transform.Find("Background/MP_PropScroll").GetComponent<MP_PropScroll>();
    this.mp_Compose = panel.transform.Find("Background/Mp_Compose").GetComponent<UnityEngine.RectTransform>();
    this.mp_Role = panel.transform.Find("Background/Mp_Role").GetComponent<UnityEngine.RectTransform>();
   }
}
