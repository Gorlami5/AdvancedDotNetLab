
using System.Threading.Channels;

MyClass m = new MyClass();
m.event1 += X;
m.T();
void X()
{
    Console.WriteLine("event triggered!");
}

//Path Control
PathControl p = new PathControl();
PathControl.YHandler x = X;
void MessageForControl() => Console.WriteLine("Mb limit exceeded!");
p.event2 += MessageForControl;  
class MyClass
{
    public delegate void XHandler();
    public event XHandler event1;

    internal void T()
    {
        event1 ();
    }
}

//Yukarıdaki örnekte görüldüğü gibi event'ler tip olarak bir delegate tip alırlar.
//Eventlerin asıl amacı olay gerçekleştiğinde senaryoya göre çalıştırmak istediğimiz yapıları çalıştırmayı amaçlarlar.
//Yukarıdaki örnekte de T metodu çalıştığı durumda tetiklenecek event, delegate tipine uygun olan ve event'e bağlanan metodu tetikleyecektir.

//NOT : Delegate yapılar direkt olarak sınıf instance'ı üzerinden erişilemezler fakat event'ler buna olanak sağlar.

class PathControl
{
    public delegate void YHandler();
    public event YHandler event2;

    public async Task Control(string path)
    {
        while (true)
        {
            await Task.Delay(1000);
            DirectoryInfo info = new(path);
            var files = info.GetFiles();
            var size = await Task.Run(() => info.EnumerateFiles("*",SearchOption.AllDirectories).Sum(files => files.Length));
            var sizeMb = (size / 1024) / 1024;
            if (sizeMb > 100)
                event2();
        }
    }
}
