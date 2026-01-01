//Action

Action action1 = () => { };
Action<int> action2 = (t) => { };
Action<string,int,bool> action3 = (s,i,b) => { };

//Actionlar özel tanımlanmış delegate türlerdir.Bu türler eğer generic parametre alıyorsa bu parametreler fonksiyonun parametrelerine denk gelir.
//Eğer generic yapıda değilse parametre almadığı anlamına gelir.
//Action'lara karşılık gelecek olan fonksiyon void olarak işaretlenir yani bir dönüş tipi olmayacaktır.

//Func
Func<bool> func1 = () => true;
Func<string, int, bool> func2 =(s, i) => true;
Func<string,string,string,string,bool> func3= (_,_,_,_) => true;

//Funclar özel tanımlanmış delegate türleridir.Bu türe karşılık gelecek olan fonksiyon bir geri dönüş tipi almak zorundadır.
//Funclar ek olarak parametre de alırlar.Generic parametrelerden son parametre return type'ı belirlerken diğer generic parametreler fonksiyonun tipini belirlerler.
//Eğer bazı parametreleri boş geçmek istersek _ ile geçebiliriz.3.Örnek bu maddeyi anlatmak için tanımlanmıştır.

//Predicate

Predicate<int> predicate1 = (i) => true;
//Predicate sadece tek parametre alan ve return type olarak bool olan fonksiyonlara karşılık gelen özel tanımlı delegate türlerdir.


// NOT : Eğer delegate yapılanmlarına hakim olursak özel tanımlanmış parametreleri ayrıca kullanmadan bütün hepsinin görevlerini yerine getirebiliriz.
//Fakat özel tanımlı delegate türler çok yaygın kullanımdan kaynaklı olarak bilinmesinde ve kullanılmasında fayda vardır!
