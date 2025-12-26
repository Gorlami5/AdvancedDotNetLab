
var student = new Student();
var book = new Book();

var result = student + book;

//Operator overloading mevcut operatörlerin davranışlarına kendi özel sınıflarımız için yeni yetenekler eklememizdir.
//Yukarıdaki örnekte görüldüğü gibi iki farklı nesneyi + operatörüyle kullandık ve sonuçta bir student elde ettik.
//Operator overloading yaparken opeartörün overload işlemi kullanılacak olan sınıfın ieçrisinde tanımlanmak zorundadır.

//+,-,*,%,++,--,true,false,== , != ,< , > ,>> ,<< gibi operatörler overloading için kullanılabilirler.


var server = new Server();
if(server >> 5)
{
    // Upload işlemi ile ilgili işlemler.s
}
if(server << 2)
{
    //..
}   

// Yukarıdaki örnekte çift taraflı yani simetrik olarak kullanılan operatorlere bir overlad işlemi örneklenmiştir.
// Aslında Download ve Upload işemleri server instance'ı üzerinden erişilip tetiklenebilirken operatorler tarafından imgelenmiştir.
// Çok yüksek sayıda bu metotlara ihtiyaç duyulduğı takdirde bu kullanım çok daha iyi olacaktır.
// Genel kullanım value object yapılarında eşitlik durumlarında daha fazla denk gelir.



class Student
{
    public int Id { get; set; }
    public List<Book> Books { get; set; } = new();

    public static Student operator +(Student a, Book b)
    {
        a.Books.Add(b);
        return a;
    }
}

class Book
{
    public int BookId { get; set; }

}

class Server
{
    public static void Download(int fileCount)
    {
        for (int i = 0; i < fileCount; i++) 
        {
            Console.WriteLine($"{i + 1} file downloaded!");
        }
    }

    public static void Upload(int fileCount)
    {
        for (int i = 0; i < fileCount; i++)
            Console.WriteLine($"{i + 1} file uploaded!");
    }

    public static bool operator >>(Server server, int fileCount)
    {
        try
        {
            Upload(fileCount);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
        
    }
    public static bool operator <<(Server server, int fileCount)
    {
        try
        {
            Download(fileCount);
            return true;
        }
        catch (Exception)
        {

            return false;
        }
        
    }
}