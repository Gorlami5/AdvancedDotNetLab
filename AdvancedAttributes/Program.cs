//Attribute,c# programlama dilinde yazılım elemanlarının davranışına,yapılandırmasına veya görünümüne müdahele etmek için kullanılan bir özelliktir.
//Yani programatik yapılar için metadata'ları temsil eden yapılardır.
//Metadata : kod içerisinde veri/yapı/eleman hakkında bilgi içeren ekstra verilerdir.

using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();
var types = assembly.GetTypes()
            .Where(x => x.GetCustomAttribute<MyAttribute>() is not null)
            .ToList();

foreach (var type in types)
{
    var attribute = type.GetCustomAttribute<MyAttribute>();
    Console.WriteLine($"{attribute} {type.Name}");
}

//Yukarıdaki örnekte derlenecek assembly içerisindeki bütün type'ların ieçrisidne MyAttribute kullanan sınıfların type'larını buluyoruz.
//Reflection yapılanması proje içerisinde çok daha derinlemesine incelenecek.

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)] // attribute'ların hangi yapılarda çalışabileceğini belirttiğimiz bir diğer attribute
class MyAttribute : Attribute
{
    public int MyProperty { get; set; }
}

[AttributeUsage(AttributeTargets.Class)]
class My2Attribute : Attribute
{
    public int MyProperty { get; set; }
    
}

[MyAttribute(MyProperty = 123)] // Isımlendirme convention kuralından kaynaklı Attribute ismi eklenmelidir.Fakat attribute kullanılırken attribute eki kullanılmasa da olur.
[My2] // Bir sınıf çoklu Attribute'da alabilir.

//Attribute class'ların içerisindeki memberlardan sadece property'lere Attribute use kısmında değer verilebilir.
//Yukarıdaki MyAttribute kullanımında örneklendirilmiştir.
class MyClass2
{

}

[My(MyProperty = f)] // Attribute'un verildiği yapıda attribute property'sine bu yapı üzerinden değer vermek istersek bu değerin const olarak tanımlamış olması zorunludur.
class MyClass3
{
    private const int f = 0;
}
