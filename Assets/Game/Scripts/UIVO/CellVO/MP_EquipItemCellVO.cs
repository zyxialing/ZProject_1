using EnhancedUI.EnhancedScroller;

public partial class MP_EquipItemCell : EnhancedScrollerCellView
{

   public void AutoInit()
   {
        ServiceBinder.Instance.RegisterObj(this);
   }
}
