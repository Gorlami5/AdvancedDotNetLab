//Mutable yapılar nesne oluştuktan sonra referans üzerinden iç değerleri değiştirilebilir.Thread safe değildir fakat allocation az olacağından daha performanslıdır.
//Immutable yapılar ise tanımlandığı sınıfın yapıcı metodu dışında hherhangi bir değişiklik yapılmamasını garanti eder.

//Immutable yapıların en yaygın olanı string yapısıdır. Ilk olarak string yapısının nasıl bir işleyiş gerçekleştirdiğini inceleyelim;
using System.Collections.Immutable;

string s = "12345";
s.Remove(0,1);

//String yapıları immutable'dır fakat burada tanımlanan string içerisinden indeks'e göre bir eleman çıkarılıyor.Haliyle bu davranışın yapılamaması gerekibilir gibi düşünülecektir.
//Fakat burada eğer tanımlanan string değeri değişiyorsa aslında bellek üzerinde yeni bir kopya oluşturluyor demektir.Yeni bir kopya ile birlikte herhangi bir değişkene atanırsa yeni bir referans'da oluşmuş demektir.


var c = new ImmutableExampleClass(1, ImmutableList<int>.Empty);

class ImmutableExampleClass
{
    //Yol 1 : Sadece Getter Kullanmak
    public int MyProperty { get; } // bir property'i eğer sadece get; ile işaretlersek sadece ama sadece ctor içerisinde değer alabilir.Onun dışında ne class'ın içerisinden ne de instance üzerinden değer alabilir.
    public int MyProperty1 { get; private set; }


    //Private set Kullanımı
    //Private olarak işaretlenmiş set gördüğümüzde yapının immutable olduğu düşünülebilir fakat hatalıdır.Evet instance üzerinden değer değişimini engeller.
    //Private set immutable davranışını sergiletemez çünkü class içerisinden ctor haricinde de değişiklik yapılmasına olanak tanır.

    //Yol 2 : Collection nesneleri immutable hale getirmek
    //Collection nesnelerinde private set veya setter kullanmama herhangi bir çözüm sağlamaz çünkü listeyi manipüle etmeyi liste instance'ı üzerinden yapabilir.
    //Bu durumda ya ReadonlyList yapısı dışarı kontrollü açılır ya da ImmutableList tipinden yararlanılır.Aşağıda ikisinin de örneği olacak

    public ImmutableList<int> MyPropertyList { get; }
    public ImmutableExampleClass(int i,ImmutableList<int> items)
    {
        MyProperty = i;
        MyPropertyList = items;
    }
    //yukarıdaki örnekte listeye yeni bir elemanı eklemek için kullanılan yol gösterilmiştir.Burada direkt olarak List instance'ı verilemesin diye ilk olarak setter silinid.Daha önce de dediğimiz gibi collection yapılarda setter olmaması sadece immutable yapmak için yeterli değildir.
    //ImmutableList type'ı burada içerideki elemanlara karşı herhangi bir değişiklik yapılmasının önüne geçecek şekilde davranıyor.
    //Listeye bir eleman ekleme yapılırsa burda Add metodu yazarız ve bu add metodu yeni bir instance içerisinde yeni bir collection olacak şekilde düzeltilir.

}

// Collection'larda en yaygın ımmutable örneği
class Order
{
    //Burada public olarak işaretlediğimiz yapı değer alırken sadece _items field'ın değerini alabiliyor. 
    //_items field'ı ise readonly olarak işaretlendiğinden sadece ama sadece tanımlandığı class'ın ctor'unda değer atanabiliyor.
    //Bu da demek oluyor ki bu liste class'ın içerisinde değerleri manipüle edilemez. Peki public işaretlenmiş liste elemanları nasıl değişmiyor.
    //Burda da IReadonlyList interface'i class instance'ı üzerinden listenin değerlerinin değişmemesine yarıyor.
    private readonly List<Item> _items;
    public IReadOnlyList<Item> Items => _items;

    public Order(IEnumerable<Item> items)
    {
        _items = new List<Item>(items);
    }

    // NOT : yukarıdaki yapı liste yapısısnın immutable olarak kullanılması gerektiğinde uygulanması gereken en uygun yaklaşımdır.
}

class Item
{

}

//NOT : readonly işaretlenmiş bir member immutable hale geldiği anlamına gelmez.Çünkü nesnenin iç durumuna karışmayacaktır.
class A
{
    //Readonly keyword'ü sadece fiedl'lar ile birlikte kullabilirler.Amacı sadece tanımlandığı sırada veya tanımlandığı class'ın ctor'ı ieçrisinde değer alaiblri.
    private readonly int x;
    public A()
    {
        x = 1;
    }

    //public void X()
    //{
    //    x = 2;
    //} Burada görüldüğü üzere x değerine aynı class'ın memberı olan bir fonksiyonda bile değer ataması gerçekleştiremiyoruz.

    //Readonly olarak işaretlenmiş bir field her nesne için ayrıca farklı değer alabilir.Yani nesnenin lifetime oluşturma sırasında yeni değer alabilir.Bu da static readonly ile en büyük farkıdır.
}

class B
{
    //readonly keyword'ü static ile kullanıldığında düz readonly ile aynı kurallara sahip olacaktır.
    //En büyük fark static readonly instance'lara özel olmaz.Bu da demek oluyor ki nesne ilk oluşturulurken bir değer alır ve bundan sonra oluşacak tüm nesnelerde bu değer geçerli olacaktır.

    private static readonly int x;
}

record ExampleRecord(int MyProperty2) //Recordlar tek başlarına bir immutable yapı sunmaz. Nasıl kullandıldıkları bunu belirleyecektir.
{
    public int MyProperty { get; init; } // Örneğin bu yapılanma MyProperty'i sadece initialize durumunda değer vermesini sağlayacaktır.
    //Yukarıdaki MyProperty2 parametresi aslında MyProperty ile aynı davranışı sergiler sadece syntax olarak değişiklik gösterir.Yani o da artık immutable sayılır.


    // ONEMLI NOT : Record yapılanmaları teoride tamamen mutable olmalarına rağmen reflection davranışıyla immutable özelliklerini ezebiliriz.
    //Bunun sebebi bir property tanımlandığında CLR tarafında property'e karşılık private bir field oluşturulur.Reflection'da CLR üzerinden dinamil bir şekilde nesne yönetimi yapabildiğinden kaynaklı bunu ezip SetValue ile değer atayabilir.
}

public sealed class Money : IEquatable<Money>
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount));

        Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        Amount = amount;
    }

    public Money Add(Money other)
    {
        EnsureSameCurrency(other);
        return new Money(Amount + other.Amount, Currency);
    }

    public Money Subtract(Money other)
    {
        EnsureSameCurrency(other);
        return new Money(Amount - other.Amount, Currency);
    }

    private void EnsureSameCurrency(Money other)
    {
        if (other is null)
            throw new ArgumentNullException(nameof(other));

        if (Currency != other.Currency)
            throw new InvalidOperationException("Currency mismatch.");
    }

    public bool Equals(Money? other)
    {
        if (other is null) return false;
        return Amount == other.Amount && Currency == other.Currency;
    }

    public override bool Equals(object? obj) => Equals(obj as Money);

    public override int GetHashCode()
        => HashCode.Combine(Amount, Currency);
}

//Yukarıda Immutable olarak en yaygın kullanım olan value object'lere ait örnek var. Detaylı olarak incelenebilir.
