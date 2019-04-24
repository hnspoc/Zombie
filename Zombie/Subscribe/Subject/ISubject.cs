using System;
using System.Collections.Generic;
using System.Text;


namespace Zombie
{
    public abstract class ISubject
    {
        private List<IObserver> mObservers = new List<IObserver>();

        public void RegisterObserver(IObserver ob)
        {
            mObservers.Add(ob);
        }
        public void RemoveObserver(IObserver ob)
        {
            mObservers.Remove(ob);
        }
        public virtual void Notify()
        {
            foreach (IObserver ob in mObservers)
            {
                ob.Update();
            }
        }
    }
}
