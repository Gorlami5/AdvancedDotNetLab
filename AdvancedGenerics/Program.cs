//Generic yapılar veri türlerinin değişse dahi aynı işleri yapmalarını istediğimizde kullanılan yapılardır.
//Kod tekrarını ve performansı çok iyi şekilde azaltır ve çok yaygın bir kullanımdır.

var t = new MyClass1<int, string, char, float>();

//Yukarıdaki örnekte bir Generic Class'ın çoklu Generic parametre alma durumunda nasıl kullanılacağını gösteriyor.
//T tipi olmadan bu class ieçrisinde bir field ve property generic olarak tanımlanamaz.Sadece generic metotlar bunları yapabilir.



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