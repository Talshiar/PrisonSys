using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonSys.Interface
{
    public abstract class Subject
    {
        List<IObserver> observerList = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            observerList.Add(observer);
        }

        public void Delete(IObserver observer)
        {
            observerList.Remove(observer);
        }

        public void Notify()
        {
            foreach (IObserver observer in observerList)
            {
                observer.UpdateView();
            }
        }
    }
}
