
//Exception sınıfları programın istisnai durumlar karşısında doğru şekilde hareket etmesine yarar.
//Exception sınıfı tüm hata sınıflarının base class'ıdır ve eğer custom bir exception sınıfı üretmek istersek kalıtım almaları gerekir.

try
{
    int a = 2;
    int b = 0;

    var result = a / b;
}
catch (DivideByZeroException ex)
{

    throw new CustomException(ex.Message);
}

//Yukaridaki örnekte basit bir try-catch mekanizması görüyoruz.Burada önemli olan catch kısmında exception sınıflarının hiyerarşisini anlamak.
//Catch olacak sınıf eğer hangi sınıfla yakalanacağını biliyorsak catch kısmında tipi belirleriz ve thhrow edilecek sınıf custom olabilir.
while (true)
{
    var key = Console.ReadKey();
    if (key.Key == ConsoleKey.R)
    {
        throw new CustomException("R tuşuna basmayınız!");
    }
}

// Burada throw keywordü nasıl kullanılacağını örnekliyoruz.
//throw edilen exception sınıfı kod sırasındaki senaryoya göre değişkenlik gösterebilir
class CustomException : Exception
{
    public CustomException()
    {
        
    }
    public CustomException(string message) : base(message)
    {
        
    }

}
