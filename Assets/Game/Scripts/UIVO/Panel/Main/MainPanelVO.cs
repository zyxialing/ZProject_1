public partial class MainPanel : BasePanel
{
   private UnityEngine.RectTransform equip_Center;
   private UnityEngine.UI.Button equip;
   private UnityEngine.UI.Button prop;
   private UnityEngine.UI.Button compose;
   private UnityEngine.UI.Button role;
   private UnityEngine.UI.Image equip_img;
   private UnityEngine.UI.Image prop_img;
   private UnityEngine.UI.Image compose_img;
   private UnityEngine.UI.Image role_img;
   private MP_EquipScroll mP_EquipScroll;
   private MP_PropScroll mP_PropScroll;
   private UnityEngine.RectTransform mp_Compose;
   private UnityEngine.RectTransform mp_Role;

   public override void AutoInit()
   {
    this.equip_Center = panel.transform.Find("Background/Equip_Center").GetComponent<UnityEngine.RectTransform>();
    this.equip = panel.transform.Find("Background/Tap_Menu/equip").GetComponent<UnityEngine.UI.Button>();
    this.prop = panel.transform.Find("Background/Tap_Menu/prop").GetComponent<UnityEngine.UI.Button>();
    this.compose = panel.transform.Find("Background/Tap_Menu/compose").GetComponent<UnityEngine.UI.Button>();
    this.role = panel.transform.Find("Background/Tap_Menu/role").GetComponent<UnityEngine.UI.Button>();
    this.equip_img = panel.transform.Find("Background/Tap_Menu/equip").GetComponent<UnityEngine.UI.Image>();
    this.prop_img = panel.transform.Find("Background/Tap_Menu/prop").GetComponent<UnityEngine.UI.Image>();
    this.compose_img = panel.transform.Find("Background/Tap_Menu/compose").GetComponent<UnityEngine.UI.Image>();
    this.role_img = panel.transform.Find("Background/Tap_Menu/role").GetComponent<UnityEngine.UI.Image>();
    this.mP_EquipScroll = panel.transform.Find("Background/MP_EquipScroll").GetComponent<MP_EquipScroll>();
    this.mP_PropScroll = panel.transform.Find("Background/MP_PropScroll").GetComponent<MP_PropScroll>();
    this.mp_Compose = panel.transform.Find("Background/Mp_Compose").GetComponent<UnityEngine.RectTransform>();
    this.mp_Role = panel.transform.Find("Background/Mp_Role").GetComponent<UnityEngine.RectTransform>();
   }
}
