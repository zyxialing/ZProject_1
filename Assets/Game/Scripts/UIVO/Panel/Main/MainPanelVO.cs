public partial class MainPanel : BasePanel
{
   private UnityEngine.UI.Button test;

   public override void AutoInit()
   {
    this.test = panel.transform.Find("test").GetComponent<UnityEngine.UI.Button>();
   }
}
