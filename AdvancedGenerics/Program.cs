//Generic yapılar veri türlerinin değişse dahi aynı işleri yapmalarını istediğimizde kullanılan yapılardır.
//Kod tekrarını ve performansı çok iyi şekilde azaltır ve çok yaygın bir kullanımdır.

var t = new MyClass1<int, string, char, float>();
rr<E>.tt<D> k = new(); 
//Yukarıdaki örnekte bir Generic Class'ın çoklu Generic parametre alma durumunda nasıl kullanılacağını gösteriyor.
//T tipi olmadan bu class ieçrisinde bir field ve property generic olarak tanımlanamaz.Sadece generic metotlar bunları yapabilir.

void X<T1,T2>(T1 t1, T2 t2)
{
    Console.WriteLine("asdas");
}
X(123, "232"); // Generic metot kullanımlarında parametrelerin tipleri otomatik olarak generic alanlar yerleşecektir.


A<int> a = new A<int>(); // A class'ı sadece value type alacaktır generic parametre olarak.Örneğin int,struct,char,enum,datetime
B<MyClass> b = new B<MyClass>();// B class'ı sadece reference type olan alacaktır generic parametre olarak.Örneğin class,object,string,interface,abstract class,delegate,Task
//Burada B : class olarak yazılsa da aslında burda reference type olan tüm değilkenlerin constraintini uygularız.
C<MyClass> c = new C<MyClass>(); // C class'ı sadece newlenebilir fakat parametre almayanları alacaktır generic parametre olarak.
//Örneğin Interface veya abstract class alamazlar.struct bir value type olsa da newlenerek kullanılabildiğinden geçerli bir parametre sayılır.


void Y<T> (T t1)where T : E { }
Y<D>(new()); // bu örnekte de Y fonksiyonu E ve E'den türeyen generic parametreler alabilir diyoruz.

//NOT : Generic parametreler bize class veya interface bazında overload yapma şansı sunar. Burada en kritik nokta parametre sayısıdır.
//Eğer farklı parametre sayıları varsa overload sorunsuz uygulanabilir.

class MyClass1<T1, T2, T3, T4>
{
    T1 a;

    public T2 MyProperty { get; set; }
    public void X<T3>  (T4 param)
    {
    }
}

class BaseClass<T>
{

}

class Pleb : BaseClass<int> // Eğer generic bir class'tan kalıtım alınacaksa T parametresi derived Class'ta verilmek zorundadır.
{//Eğer tam tersi olursa farklı bir şey yapmaya gerek yok.

}

class A<T> where T : struct //Value Type Constraint
{

}

class B<T> where T : class { } // reference type constraint

class C <T> where T : new() { } // new and parameterless 

class D: E { }
class E { }

class MyClass
{

}
struct MyStruct
{

}

abstract class MyAsbtractClass
{

}


class Rr<T1>
{
    public class Tt<T2> where T2 : T1
    {
        
    }
}