using System.Collections.Generic;
using System.Threading;

public class ThreadSafeBigAssData<T>
{
    private List<T> _data;

    private int _writersCount;
    private bool _writerWorking;
    private int _readersCount;

    public ThreadSafeBigAssData()
    {
        _data = new List<T>();
        _writersCount = 0;
        _readersCount = 0;
        _writerWorking = false;
    }

    public T ReadData(int index)
    {
        Monitor.Enter(_data);
        {
            while (_writersCount > 0 || _writerWorking)
                Monitor.Wait(_data);
            _readersCount++;
        }
        Monitor.Exit(_data);

        Thread.Sleep(2000); // as if method is actually reading something

        Monitor.Enter(_data);
        {
            _readersCount--;
            if (_readersCount == 0)
                Monitor.PulseAll(_data);
        }
        Monitor.Exit(_data);

        return _data[index];
    }

    public void WriteData(T newData)
    {
        Monitor.Enter(_data);
        {
            _writersCount++;
            while (_readersCount > 0 || _writerWorking)
                Monitor.Wait(_data);
            _writersCount--;
            _writerWorking = true;
        }
        Monitor.Exit(_data);

        Thread.Sleep(2000); // as if method is actually write something
        _data.Add(newData);

        Monitor.Enter(_data);
        {
            _writerWorking = false;
            Monitor.PulseAll(_data);
        }
        Monitor.Exit(_data);
    }
}