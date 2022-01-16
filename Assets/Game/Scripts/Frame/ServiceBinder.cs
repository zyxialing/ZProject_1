using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceBinder : Singleton<ServiceBinder>
{
     ZFrameworkContainer container;
     private ServiceBinder()
     {
        container = new ZFrameworkContainer();
        Binder();
      
     }
    public void RegisterObj(object obj)
    {
        container.Inject(obj);
    }
    private void Binder()
    {
        container.RegisterInstance<IPropMgr>(new PropMgr());
    }


}
