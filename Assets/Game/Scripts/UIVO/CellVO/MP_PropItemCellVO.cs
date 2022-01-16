using EnhancedUI.EnhancedScroller;

public partial class MP_PropItemCell : EnhancedScrollerCellView
{

   public void AutoInit()
   {
        ServiceBinder.Instance.RegisterObj(this);
   }
}
