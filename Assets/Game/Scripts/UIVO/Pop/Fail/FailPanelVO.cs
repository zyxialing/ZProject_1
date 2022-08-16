public partial class FailPanel : BasePanel
{
   private UnityEngine.UI.Button backBtn;

   public override void AutoInit()
   {
        ServiceBinder.Instance.RegisterObj(this);
    this.backBtn = panel.transform.Find("root/backBtn").GetComponent<UnityEngine.UI.Button>();
   }
}
