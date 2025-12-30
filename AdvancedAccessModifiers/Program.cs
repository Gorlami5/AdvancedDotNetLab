public class XProtected
{
    //Protected access modifier member'ın tanımlandığı class'ın içerisinden ve bu class'tan türeyen diğer class'lar içerisinden
    //erişbilmesini zorunlu kılacaktır.
    //Namespace seviyesinde protected bir access modifier kullanılamaz.

    //NOT : protected member eğer public bir class içerisindeyse ve bu class başka bir projede kalıtım veridği class'lar varsa
    //Bu durumda başka projedeki o class'lar bu member'lara erişebilecektir.

    //Protected access modifier'ın en önemli özelliklerinden biri de class instance'ı üzerinden bu memberler private gibi davranmasıdır.
    //Bu da demek oluyor ki instnace üzerinden erişimleri yoktur.
    protected int MyProperty { get; set; }

    protected void MyFunc() { }
}

internal class XInternal
{

    //Internal access modifier'ı tanımlandığı assembly dışından herhangi bir yerde erişmemize olana tanımaz.
    //Bu da demek oluyor ki tanımlanan proje dışarısına internal olarak tanımlamış eleman çıkarılamaz.

    //NOT : Farklı bir projede kalıtım alan başka bir sınıf üzerinden erişilmek istenirse(protected'da olduğu gibi) buna yine de izin vermez.
    //Namespace seviyesinde tanımlanacak elemanlar default olarak internal işaretlidir.
    internal int MyProperty { get; set; }
    internal void X() { }
}
 class XProtectedInternal 
{
    //Protected internal AM'si protected'ın internal'ı internal'ın protected'ı aşmasına yaradığı biribirini tamamlayan erişim belirleme yaklaşımıdır.
    //Internal olduğu için hem aynı assembly'de istenilidği gibi kullanılabiliyor protected olduğu için de diğer assembly'lerde inheritance yoluyla erişim sağlanabiliyor.
    //Bu da demek oluyor ki ikisinin de özelliklerinden fayda sağlanıyor.
    protected internal void X() { }


}

class XPrivateProtected
{
    //Private protetected AM'ının genel amacı protected'ın farklı asssembly'lerde kalıtımla birlikte kullanılmasının önüne geçmektir.
    //Yani private ile protected daha da kısıtlı kalıyor.Fakat hala aynı assembly'de kaltım alınan sınıflarda kullanılabiliyor.
    private protected void X() { }
}

//NOT : Private ile Public erişim belirleyicileri özel olarak işlenmemiştir.


class X
{

}

public class Y
{
    //public X MyProperty { get; set; }
}

//Yukarıda X ve Y için özel bir durum görülmekte. Internal işaretlenmiş bir class public işaretlenmiş bir class içerisidne kullanılmak isteniyor.
//Bu durumda mantıksal bir tutarsızlık olacağı için compiler bizi uyaracaktır.