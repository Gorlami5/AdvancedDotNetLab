int a = 10;
short b = 11;
a = b;

long t = 22;
float k = 23;

k = t; // implicit

t = (long)k; // explicit

// Yukarıdaki örnekte birer örnek bulunuyor.Eğer herhangi bir cast işlemi açıkça belirtilmemişse bu implicit conversion olarak adlandırılır.
// Eğer açık bir cast işlemi varsa explicit olarak adlandırılır.Burada her tip aslında kendi içerisinde bir overload işlemi yapar fakat bunu bizim özel olarak yapmamıza gerke kalmaz.



//Kendi özel türlerimizde implicit ve explicit overloading kullanılabilir fakat bunu bizim özel olarak geliştirmemiz gerekecektir.
//Kendi özel sınıfımızda bir implicit overlad işlemi tanımladığımızda artık tür dönüşümünü açık bir şekilde belirtebiliriz.
//Burada karıştırılmaması gerekilen en önemli konu polymorphism kurallarının hali hazırda geçersiz olduğu varsaymaktır.

//Implicit overlad yapıldıysa artık açık bir şekidle cast işlemi şeklinde olan expilicit overload işlemi de yapılabilir.Implicit overload Expliciti kapsıyor gibi düşünebiliriz.

A a1 = new B();
A b1 = (A)new B();

B b2 = (B)new A(); // Burada sadece expilicit overload işlemi tanımlandığı için implicit uygulamayız. 
//Fakat tam tersi olsaydı yani sadece implicit olsaydı hem açık bir cast işlemiyle(expilicit) hem de implicit olarak kullanımını yapabiliyoruz.

//Gerektiği durumlarda bu overload işlemleri kolaylıkla gerçekleştirilebilir.Fakat performans noktasında zincir halde bulunmaması daha önemlidir.



// Value Object Operator overload işlemleri

decimal d = 2;
Money m = d; // decimalin bir value object olan money tipine dönüşümü gösteriliyor.Implicit.

d = (decimal)m; // Money tipinde bir value object decimal tipine dönüşümü sağlanıyor.Explicit.
class A
{

    public static implicit operator A(B instance)
    {
        return new A();
    }

    public static explicit operator B(A? instance)
    {
        if(instance == null) // null bir instance üzerinden yapılabilecek işlemlerde null kontrolleri kritiktir.
        {
            var emptyInstance = new A();
        }
            

        return new B();
    }
}


class B
{

}

// Gerçek hayat kullanımında genelde value objectler içerisinde tür dönüşümleri gerçekleştirilir.

public sealed class Money
{
    public decimal Amount { get; }

    public Money(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException("Negatif olamaz");

        Amount = amount;
    }

    public static implicit operator Money(decimal value)
        => new Money(value);

    public static explicit operator decimal(Money money)
        => money.Amount;
}


// Mesela yukarıdaki örnekte bir Money Value Object içerisinde implicit ve explicit overloading örnekleri vardır.

