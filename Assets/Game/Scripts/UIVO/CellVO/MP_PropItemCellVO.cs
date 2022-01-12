using EnhancedUI.EnhancedScroller;

public partial class MP_PropItemCell : EnhancedScrollerCellView
{
   private bool isFirstInit = false;

   public void AutoInit()
   {
        if (isFirstInit) return;
        isFirstInit = true;
   }
}
