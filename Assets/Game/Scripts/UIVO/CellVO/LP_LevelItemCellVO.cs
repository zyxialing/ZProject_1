using EnhancedUI.EnhancedScroller;

public partial class LP_LevelItemCell : EnhancedScrollerCellView
{
   private UnityEngine.UI.Text levelTxt;
   private UnityEngine.UI.Button levelBtn;

   public void AutoInit()
   {
        ServiceBinder.Instance.RegisterObj(this);
        this.levelTxt = transform.Find("root/levelTxt").GetComponent<UnityEngine.UI.Text>();
        this.levelBtn = transform.Find("root/levelBtn").GetComponent<UnityEngine.UI.Button>();
   }
}
