//Reflection, bir assembly üzerinde kod elemanlarının çalışma zamanında bilgilerine erişerek işlemler yapabilme yeteneğidir.

using System.Reflection;

var types = Assembly.GetExecutingAssembly().GetTypes();
foreach (var item in types)
{
    Console.WriteLine(item.Name); //Assembly üzerinde tanımlanmış bütün type'ların name'leri console üzerinde yazılacaktır.
}

var assemblies = Assembly.Load("AdvancedGenerics");
//farkla bir assembly'de bu şekilde yüklenerek bu assembly'deki type vb yapılara ulaşabiliriz.

MyClass m = new MyClass();
Type type1 = m.GetType();

Type type2 = typeof(MyClass);

//Reflection yeteneği ile birlikte yukarıdaki 2 type discovery davranışı ile run time'da sınıfların type bilgileri alınabilir.

PropertyInfo[] properties = type1.GetProperties(); // O type'a ait bütün propertileri alırız
MethodInfo[] methods = type2.GetMethods();
FieldInfo[] fields = type1.GetFields();

var property = type1.GetProperty(nameof(MyClass.MyProperty)); // eğer spesifik olarak bir property'e erişmek istersek bu şekilde olur.Metot ve field'lar içinde aynı şekilde işlenebilir.
//property.SetValue(m, null);
//property.GetValue(m.MyProperty1);


var method = type1.GetMethod(nameof(MyClass.Method1));
method.Invoke(m,null); //metot çalıştırmak için gerekli yapı!Type bilgisini alsak dahi bir metot veya bir property set get metotlarını çalıştırmak için instance ihtiyacımız vardır.


var members = type1.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance);
//yukarıdaki GetMember içerisine verdiğimiz enum parametreler sayesinde private değişkenlere de erişimimiz olacaktır.



class MyClass
{
    private int x;
    private int y;
    private int z;

    public void Method1() => Console.Write("Method1");
    public void Method2() => Console.Write("Method2");

    public int MyProperty { get; set; }
    public int MyProperty1 { get; set; }
}
