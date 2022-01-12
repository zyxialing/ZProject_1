using EnhancedUI.EnhancedScroller;

public partial class MP_EquipItemCell : EnhancedScrollerCellView
{
   private bool isFirstInit = false;

   public void AutoInit()
   {
        if (isFirstInit) return;
        isFirstInit = true;
   }
}
