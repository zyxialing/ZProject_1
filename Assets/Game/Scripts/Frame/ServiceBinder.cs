using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceBinder : Singleton<ServiceBinder>
{
     ZFrameworkContainer container;
     private ServiceBinder()
     {
        container = new ZFrameworkContainer();
        container.RegisterInstance<ITestMgr>(new TestMgr());
     }

    public void RegisterObj(object obj)
    {
        container.Inject(obj);
    }

}
