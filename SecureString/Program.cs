//Secure string yazılımda kritik arz eden değerlerin bellek üzerinde şifreli bir şekilde saklanmasına yarayacaktır.
//Bazı bilgiler oldukça kritik önem arz eder ve bellekte bunları direkt olarka string olarak saklamak belleğe izinsiz erişenler için açık anlamına gelir.
//Eğer string'i kendi yöntemlerimizle şifrelemek istesek bile string yapısı immutable bir yapı olacağından ilk hali her zaman bellekte olacaktır.
//Onun için secure string sınıfı ile kritik bilgileri bellekte bu şekilde saklayabiliriz.


using System.Runtime.InteropServices;
using System.Security;

string bankNo = "1234 5678";
SecureString secure = new();
bankNo.ToList().ForEach(bank => secure.AppendChar(bank));
secure.MakeReadOnly();

//yukarıdaki örnekte bankNo secure string sınfı ile nasıl kullanılır gösteriliyor.
//NOT : sadece örneklemek için yapılmıştır.Zaten string olarak tanımlı olması örneği göstermek içindir.

var bstr = Marshal.SecureStringToBSTR(secure);
var value = Marshal.PtrToStringUni(bstr);
Console.WriteLine(value);

//Secure string yapısına eklenen değer tekrar bu şekilde okunabilecektir.


//ONEMLI NOT : Secure string yapısı eğer direkt olarak secureString sınıfı alan bir dış apiye parametre olarak gönderilmiyorsa
//pek de kullanmak mantıklı değil. Microsoft zaten yeni dönemde secure string sınıfının kullanımı pek önermiyor.
//Haliyle secure string sınıfı scope içerisinde tekrardan çözülüp kullanılmak istendiğinde(herhangi bir iş akışı olabilir) mantığının dışına çıkacaktır.