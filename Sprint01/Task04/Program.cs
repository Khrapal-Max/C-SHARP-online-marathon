using System;
//Please, create class DisposePatternImplementer that implements Disposable pattern and inherits from CloseableResource class
//Print such lines of information in the method responsible for releasing managed and unmanaged resources:
//"Disposing by developer" if the object of the class is disposed by developer
//or "Disposing by GC" if the object is disposed by garbage collector
//also, you should ensure that method Close() is called in either case.
namespace Task04
{
    public abstract class CloseableResource
    {
        public void Close() { Console.WriteLine("Closing resource"); }
    }
    public class DisposePatternImplementer : CloseableResource, IDisposable
    {
        private bool IsDisposed = false;        

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    Console.WriteLine("Disposing by developer");
                    Close();
                }
                else
                {
                    Console.WriteLine("Disposing by GC");
                    Close();
                }
                IsDisposed = true;
            }
        }
        ~DisposePatternImplementer()
        {
            Dispose(false);            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DisposePatternImplementer disposePatternImplementer = new DisposePatternImplementer();
            disposePatternImplementer.Dispose();
            disposePatternImplementer.Dispose();
            Console.ReadLine();
        }
    }
}
