//Extension metotlar halihazırda var olan bir sınıfa veya interface'in kaynak koduna dokunmadan yeni bir metot member'ı kazandırmamıza yarar.
//Burada en güzel benzetme inheritance yapısının işlev olarak aynı fakat davranış olarak tam tersi olduğunu söylememiz olacaktır.
//Genellikle bu yapılar .net mimarisinde kaynak koduna ulaşamadığımız ve bize hazır verilen yapılara kendi özel metotlarımızı eklemek için kullanırız.


using System.Runtime.CompilerServices;

MyClass m = new();
m.X();

//Görüldüğü üzere MyClass içerisinde bulunmayan bir fonksiyon artık m instance'ı üzerinden erişiliebilir halde.
//Burada zaten direkt olarka neden MyClass içerisine eklemiyoruz sorusuna verilebilecek cevaplar vardır.
//Bunlardan ilki bazen kodu daha modüler şekilde tasarlamak istediğimizde bu modülerlik bize sorumlulukların ayrışmasını getiriyorsa kullanıbilir.
//Ama asıl neden kaynak kodlarına erişemediğimiz hazır sınıflarına veya interface'lerine kendi metotlarımıza eklememizi sağlar.
//Extension metotların en yaygın örneği IServiceCollection'a interface'i üzerinden IoC'ye register yaparken kendi metotlarımızı kullanmamız diyebiliriz.
class MyClass
{
    
}

static class ExtensionClass
{
    public static void X(this MyClass m)
    {
        Console.WriteLine("Extension class!");
    }
}