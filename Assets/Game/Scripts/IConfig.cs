using System;
using System.Collections.Generic;

public interface IConfig
{ 
    void LoadBytes<T>(Action<List<T>> callBack);
}
