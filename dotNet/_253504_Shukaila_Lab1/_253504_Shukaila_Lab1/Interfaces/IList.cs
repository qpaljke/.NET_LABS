namespace _253504_Shukaila_Lab1.Interfaces;

internal interface IList<T>
{
    T this[int index] { get; set; }
    void Reset();
    void Next();
    T Current();
    void Remove(T item);
    void Add(T item);
    T RemoveCurrent();
    int Count { get; }

}
