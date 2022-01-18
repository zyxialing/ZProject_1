using EnhancedUI.EnhancedScroller;

public partial class MP_MenuItemCell : EnhancedScrollerCellView
{
   private UnityEngine.UI.Image icon;
   private UnityEngine.UI.Button cellBtn;

   public void AutoInit()
   {
        ServiceBinder.Instance.RegisterObj(this);
        this.icon = transform.Find("icon").GetComponent<UnityEngine.UI.Image>();
        this.cellBtn = transform.Find("icon").GetComponent<UnityEngine.UI.Button>();
   }
}
