using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    public interface IObserver
    {
          void Update();
          void SetSubject(ISubject sub);
    }
}
