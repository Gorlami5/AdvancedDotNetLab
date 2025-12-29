
// c#'da delegate'ler metotları temsil eden yapılardır.Yani metotların referanslarını temsil ederler.

XHandler x1 = X;
XHandler x2 = () => { };
XHandler x3 = new XHandler(X);

YHandler y1 = new YHandler(Y);
YHandler y2 = Y;
YHandler y3 = (q1, q2) => { return 1; };

//Delegate'lerin karşılayabildiği metotları delegatlere yukarıdakiler gibi atama yaklaşımları uygulanabilir.

x1.Invoke();
x2.Invoke();
x3();

y1((1,""),23);
y2.Invoke((4, "2"), 22);
y3.Invoke((5, "sad"), 22);

//Delegate referansları üzerinden istenen metotlar yukarıkdaki örnekler gibi tetiklenebilirler.

XHandler x4 = Method1;
XHandler x5 = Method2;
XHandler x6 = Method3;

XHandler sum = x4 + x5 + x6;

//Handler'lar eğer doğru imzaları karşılayan metotlarla kullanılırsa birden çok handler'ı karşılayabilirler.

ZHandler<int> z1 = Z;
z1.Invoke(2);

void X() { };
int Z(int t) { return t; }

//ZHandler bize generic olarak nasıl delegate kullanabilirizin bir örneğidir.

void Method1() => Console.WriteLine("Method1");
void Method2() => Console.WriteLine("Method2");
void Method3() => Console.WriteLine("Method3");

int Y ((int,string) y2,decimal y)
{
    return 1;
};

public delegate void XHandler();
public delegate int YHandler((int, string) t, decimal k);
public delegate T ZHandler<T>(T t);

//Delegate tanımlarken bu delegate'in referans olarak tutacağı metotların hangi tip return edeceğini hangi tip parametreler alması gerektiğini
//ve eğer generic tipse generic tipin nerelerde kullanılması gerektiğini belirtmek gerekiyor.