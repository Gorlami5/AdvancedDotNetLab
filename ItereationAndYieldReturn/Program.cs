
using System.Collections;

    Stock ins = new Stock();
    foreach (var item in ins) // Burada GetEnumerator generic olmadığından kaynaklı item object oalrak tutulacaktır.
    {
        Console.WriteLine(item);
    }

    //yield 
    IEnumerable<string> GetNames()
{
    yield return "Name1";
    yield return "Name2";
    yield return "Name3";
    yield return "Name4";
}
foreach(var t in GetNames())
{
    Console.WriteLine(t);
}

//yield return itere edilecek olan yapı için bize farklı bir yaklaşım sunmaktadır.
//yield return geriye dönüş değeri olarak IEnumerable tipinde dönüş sağlar bu da zaten itere edilebilecek bir yapıda olduğunu gösterecektir.
//Normal iterasyon süreçlerinde tüm veri belleğe yüklenirken yield return bize lazy execution sağlar.Yani her itere olma sırasında gerekli veri execute edilecektir.
//Bu da bizlere belirli performans katkıları sağlar.Çünkü bazı durumlarda tüm verinin itere edilmesine ihtiyaç duyulmayabilir.
//Ek olarak yield return her iterenin kendine özel bir işlem yapılmasını da sağlayacaktır. Normal iterasyonda bu mantık her itere edilen değer için geçerli olur.





    class Stock : IEnumerable<string>
    {
        public List<string> materials = new List<string>() { "1231", "213123", "2312312", "2312312" };
        public IEnumerator GetEnumerator() // IEnumerator<> dönüş tipinin unboxing edilmiş halidir.
        {
            return materials.GetEnumerator();
        }

    IEnumerator<string> IEnumerable<string>.GetEnumerator()
    {
        return new StockEnumerator(materials);
    }
}

class StockEnumerator : IEnumerator<string>
{

    //IEnumerator itere edilecek olan yapının detaylı olarak nasıl davranış sergileyeceğinin konfigürasyonlarını belirler.
    //Aldığı bir koleksiyonun(source) itere edilmesindeki davranışlarının imzasıdır.
    //GetEnumerator fonksiyonu return edileceği zaman gerekli olacaktır.
    List<string> _source;
    int _currentIndex = -1;

    public StockEnumerator(List<string> source)
    {
        _source = source;
    }
    public string Current => _source[_currentIndex];

    object IEnumerator.Current => _source[_currentIndex];

    public void Dispose()
    {
        _source = null;
    }

    public bool MoveNext()
    {
        return ++_currentIndex < _source.Count;
    }

    public void Reset()
    {
        _currentIndex = -1;
    }
}
