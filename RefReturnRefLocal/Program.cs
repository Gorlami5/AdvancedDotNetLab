//Ref Keyword'ü
// Bir metoda gönderilecek olan value type bir değişkende deep copy yapmak istemeyip referencre type gibi davranmasını
//sağlamak istediğimiz durumlarda ref keywordü kullanırız. Aşağıdaki örnekte Test fonksiyonu çalıştığında artık x ile aynı 
//adresi gösterdikleriden aynı değişikliklere maruz kalacaklardır.

using Microsoft.VisualBasic;

int x = 10;
 Test(ref x);
void Test(ref int y)
{
    y = 13;
}

//Ref return
// Ref return bize metot üzerinden dönecek değer değil de artık reference type'ı vermeye yarayacaktır.Aşağıdaki örnekte artık
// q1 değeri artık bir adres tutacaktır. Aslında bu q1 değeri bakıldığında t ile aynı adresi gösteriyor diyebiliriz.
// Sonuç olarak artık q1 değeri de t değeri de k değeri de 33 olacaktır.
int t = 10;
ref var q1 = ref Test2(ref t);
q1 = 33;
ref int Test2(ref int k)
{
    k = 22;
    return ref k;
}

// NOT : Burada önemli bir nokta return ref değeri local bir değişken olamaz. Parametre üzerindeki dğeişken de local gibi gözükse de
// aslında bu değikene global bir değişken adresi yolluyoruz bu yüzden parametre değişkeni global gibi davranacaktır.


int t2 = 10;
var q2 = Test3(ref t2);
q1 = 33;
ref int Test3(ref int k)
{
    k = 22;
    return ref k;
}

//Yukarıda Test3'ten ref dönsede q2 ile sadece value yakalanıyor yani artık q2 üzerinde yapılacak değişikler bir deep copy'dir ve 
// artık memory'de ayrı bir yerde allocate olmuştur. Bir önceki örnekten en büyük farkı budur.

//Ref Local

int u = 10;
ref int z = ref u;

//ref return ile metot üzerinden return ile adres alıyorken ref local ile direkt olarka iki değişkenin referans atamaları yapılabiliyor.


//SONUC : Ref parametresi gerekli durumlarda optimizasyon için kullanılır ve tercih edilir. Özellikle performansı kritik olan bazı
// durumlarda gereksiz değişken tanımlaması ve karmaşıklığından kurtulmak için ref keywordü tercih edilir.

int[] prices = { 123, 332, 330, 666 };

ref int GetPrice(ref int[] _prices,int index)
{
    return ref _prices[index] ;
}

ref var dd = ref GetPrice(ref prices, 2);
dd = dd * 100 / 10;


// Yukaridaki örnekte eğer ref kullanmasaydık ilk olarka parametre direkt olarak kopyalama yapardı ve bellekte ayrıca yer kaplardı.
// Sonra dönen değeri yine bellekte(stack) ayrıca allocate(slot) edeceğimiz bir değişkene verirdik bu da ayrı bir alan kaplardı. Ama buradaki örnekte
// bellekte kaplanacak yer neredeyse tamamen göz ardı edilecek kadar ucuzdur. Bundan dolayı ref return eğer dönecek değer üzerinde  çok fazla
// işlem yapılacaksa kullanılmalı ve performans ciddi anlamda kritik olmalıdır.