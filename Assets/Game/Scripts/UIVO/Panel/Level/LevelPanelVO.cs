public partial class LevelPanel : BasePanel
{

   public override void AutoInit()
   {
        ServiceBinder.Instance.RegisterObj(this);
   }
}
