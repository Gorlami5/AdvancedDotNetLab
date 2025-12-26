#region Activator sınıfı ile nesne oluşturma.
using System.Dynamic;

Type t = typeof(MyClass);
MyClass m = (MyClass)Activator.CreateInstance(t);

//Activator ile dinamik şekilde obje oluşturmanın en büyük amacı run time sırasında tipi compile time'da belli olmayan nesnelerin
//instance'larını dinamik olarak yaratmaktır.Activator class'ı da bize bunu reflection mekanizmalarını kullanarak sağlar.
#endregion
#region dynamic sınıfı ile nesne oluşturma
dynamic dmy = new DynamicMyClass();
dmy.Prop1 = 234;
dmy.Prop2 = "asdas";

//Yukarıdaki örnekte aslında geleneksel instance yaratma keyword'ü olan new'i kullanıyoruz fakat burdaki en önemli taraf instance'ın tipi olan dynamic.
//Compile time sırasında nesne üretilirken tip belli olsa dahi instance dynmic ile tutulduğundan compiler tarafından bilinmez.
//Haliyle bu instance üzerinden class ieçrisindeki üyelere erişim yaparken hangisinin var olup olmadığı run time'da kontrol edilir.Compiler bunu bilmez.

#endregion
#region ExpandoObject sınıfı ile nesne oluşturma
dynamic d = new ExpandoObject();
d.Prop1 = "2";
d.Prop2 = 3;

Console.WriteLine(d.Prop1);
//Expando Object yapısı tanımlanmamış bir nesne olsa dahi böyle bir objenin var olduğunu ve bundan instance yaratılmasını sağlayan yapıdır.
#endregion

class MyClass
{
    public MyClass()
    {
        Console.WriteLine($"{typeof(MyClass)} türünde obje oluşturuldu!");
    }
}
class DynamicMyClass : DynamicObject
{
    public DynamicMyClass()
    {
        Console.WriteLine($"{typeof(DynamicMyClass)} türünde obje oluşturuldu!");
    }

    private readonly Dictionary<string, object> properties = new();

    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        properties.TryGetValue(binder.Name, out result);
        return true;
    }

    public override bool TrySetMember(SetMemberBinder binder, object? value)
    {
       
        properties.Add(binder.Name, value);
        return true;
    }

    //Bu sınıfta DynamicObject sınıfından kalıtım alarak override edebileceğimiz belirli metotları elde ederiz.Peki bu metotlar ne işe yararlar?
    //Bu metotlar dinamic olarak nesne içerisinde üye tanımı yapmamızı sağlar.Örneğin bir sınıf içerisinde daha önceden tanımlamadığımız üyeleri dinamik oalrak tanımlayıp kullanabilriiz.
    
}