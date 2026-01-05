
using Microsoft.VisualBasic;

var aObject = new
{
    A = 123,
    B = "123",
    C = 123.123
};
Console.WriteLine(aObject.A);
Console.WriteLine(aObject.B);
Console.WriteLine(aObject.C);

//Yukarıdaki örnekte görüldüğü üzere aObject instance'ı daha önceden tanımlanmış bir nesne tipinde değildir.
//Anonymous tipler o an bir tipe sahip olmasalar dahi bir nesnenin instance'ına karşılık gelebilirler.s
//Oluşan instance içerisindeki elemanlar atanan değerlere göre kendi tiplerine sahip olacaktırlar.
//Anonymous instance'lar genellikle tek seferlik kullanım sırasında tanımlanırlar ve başka yerde kullanılması amaçlanmaz.En
//önemli artısı anlık olarak gereksiz tanımlama yapmaktan kurtarır.
//En önemli dezavantajları ise kodun karmaşıklığını ve anlaşılaiblirliğini azaltabilirler.
//Anonymous objectlerin içerisindeki property'ler readonly olarak işaretli şekilde tanımlanacaktır.


Topla topla = (i1,i2) => { i1 = i2; };
Topla topla1 = new Topla((i1, i2) => i1 = i2);
Topla topla2 = X;



//Yukarıda delegate referencte type'ına karşılık verilen fonksiyonlar görülmekte. Burada dikkat edilmesi gerken nokta
//delegate'e uygun fakat daha önceden tanımlanmamış fonksiyonlar anonymous type olarak delegate'lere atanabiliyor.
//topla2 instance'ında ise daha önceden tanımlanmış ve tipi belli olan X fonksiyonunun kullanımı gösterilmekte

var x = new[] { 3, 2, 1 };

//Bir array'in nasıl anonymous olarak tanımlanabileceğine bir örnek.

var y = new Collection()
{
    new {A = 1},
    new {B = 2},
};

void X(int i1, int i2) { }
public delegate void Topla(int x1, int x2);