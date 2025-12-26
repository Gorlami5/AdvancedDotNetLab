// Multidimensional Array

int[,] mArray = new int[2, 2] { { 1, 2 }, { 3, 4 } }; //2D
int[,,] m3Array = new int[2, 3, 2] { { { 1, 2 }, { 2, 3 }, { 4, 5 } }, { { 1, 2 }, { 2, 3 }, { 4, 5 } } }; //3D

//Jagged Array


int[][] jArray = new int[2][]
{
    new int[] { 1, 2, 3 },
    new int[] { 1, 2, }
};

//List of list mantığı ile aynı düşünülebilir.İstersek çok boyutlu diziler de bir dizinin elemanları olabilir!
//Jagged Array'lerin en büyük dezavantajı performans olarak bellek yönetiminde daha karmaşık ve yetersiz kalmasıdır.

//CreateInstance ile array oluşturmak.

int[] cArray = (int[])Array.CreateInstance(typeof(int), 3);


//Tuple tiplerle array tanımı
(int a, string b)[] arr = new (int a, string b)[]
{
    (1,""),
    (2,"")
};