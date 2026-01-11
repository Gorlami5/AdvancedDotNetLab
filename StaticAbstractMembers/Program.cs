IInterface.X();
//IInterface.Y(); eğer abstract keyword'ünü kullanırsak direkt olarka tip üzeridnen erişimimiz olmayacaktır.
class MyClass : IInterface
{
    public static void Y()
    {
        throw new NotImplementedException();
    }
}

interface IInterface
{
    public static void X() { } // burada görüldüğü üzere static member'lar interface içerisinde scope ihtiyacı vardır.
    public abstract static void Y(); // eğer static bir class için implementasyonu zorunlu tutmak istiyorsak abstract keywordü kullanmamız yeterli olacaktır.
}
