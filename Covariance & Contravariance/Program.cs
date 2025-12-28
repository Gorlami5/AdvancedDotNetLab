object[] arr = new string[3]; // Array coviarance
IEnumerable<object> e = new List<string>(); //Generic type covarience

Func<A> a = X; // Delegate covarience
B X() => new();

//Covarience ve Contravarience terimler ; array types,delegate types,return types ve generic types için implicit conversionları ifade eden terimlerdir.
//Yukarıdaki örneklerde implicit dönüşümleri belirtilen type'larla beraber nasıl kullanırızın cevapları var.
//Yukarıdaki örneklerde polymorphic davranışlar da sergilendiği gibi implicit davranış da beraberinde gelecektir.
//Covarience'ı Contravarience'den ayıran özellik spesifik türün genel türe dönüşümünü sağlaması.Contravarience'da ise tam tersi uygulanacaktır.



Action<A> action1 = (a) => { }; // Delegate type contravarience
Action<B> action = action1;

//Yukarıda görüldüğü gibi genel tip referanc'ı spesifik tip tarafından karşılanabiliyor.
//Bunun sebebi aslında action instance'ı sadece B ile çağrılabilir olması.Genel türün garantisi atanan Action'nın generic parametre tipi ile sağlaması alınıyor.

IMyClass<B> i = new MyClass();
//Bu generic type contravarienttir. Bunun sebebi T'nin in ile sadece consume edileceğinin garantisi IMyClass içerisinde T parametresi tanımlama sırasında verilir.
//Eğer out olsaydı covarience olacaktı çünkü out ile T tipinin return edilmesi gerekecekti.
class A 
{
    public virtual A GetA() => new(); // return type covarience
}

class B : A
{
    public override B GetA() // Return type covarience
    {
        return new();
    }
}

interface IMyClass<in T>
{

}
class MyClass : IMyClass<A>
{

}
