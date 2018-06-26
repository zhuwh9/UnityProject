## C# 入门

### 命名空间

以下代码引用了System命名空间，可以使用该命名空间中定义的函数和类

```csharp
using System;
```

### 主函数

程序会从Main函数开始执行

```csharp
using System;

namespace HelloUnity
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
		}
	}
}
```

### C#基本语法结构

- 块结构语言：{}
- 代码块：N个语句组成，N = 0，1，2
- 严格区分大小写

### 变量声明

- 语法格式：`<type>`  `<name>`

### C#基本数据类型

- 整数类型

| 类型    | 别名             | 位数   | 允许的值                       |
| ------- | ---------------- | ------ | ------------------------------ |
| sbyte   | System.SByte     | 8      | 介于-2^7 ~ 2^7之间整数         |
| short   | System.Int16     | 16     | 介于-2^15 ~ 2^15-1之间整数     |
| **int** | **System.Int32** | **32** | **介于-2^31 ~ 2^31-1之间整数** |
| long    | System.Int64     | 64     | 介于-2^63 ~ 2^63-1之间整数     |

- 浮点数类型

| 类型      | 别名              | 近似的最小绝对值 | 近似的最大绝对值 |
| --------- | ----------------- | ---------------- | ---------------- |
| **float** | **System.Single** |                  |                  |
| double    | System.Double     |                  |                  |
| decimal   | System.Decimal    |                  |                  |

- 其它基本数据类型

| 类型   | 别名           | 允许的值                                   |
| ------ | -------------- | ------------------------------------------ |
| bool   | System.Boolean | 布尔值：true或false                        |
| char   | System.Char    | 存储0~65535之间的整数，对应一个Unicode字符 |
| string | System.String  | 一组字符，字符数量无上限                   |

### 变量的命名

规则：

- 第一个字符必须是字母，下划线或"@"
- 不能和关键字、已有变量、已有方法名、已有类名相同

### 变量的字面值

| 类型      | 后缀     | 实例        |
| --------- | -------- | ----------- |
| bool      | 无       | true或false |
| int, long | 无       | 24          |
| long      | l或L     | 24L         |
| float     | f或F     | 1.3f        |
| double    | 无、d或D | 1.3         |
| decimal   | m或M     | 1.3M        |
| char      | 无       | 'a'         |
| string    | 无       | "aaaaa"     |

### 枚举

```csharp
enum Day
{
	Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
}
```

### 结构

```csharp
struct Customer
{
    int id;
    string name;
    string phoneNum;
}
```

#### 访问结构成员

```csharp
public static void Main (string[] args)
{
    Customer cus;
    // 赋值
    cus.id = 147;
    cus.name = "fudan";
    cus.phoneNum = "18800000000";
	// 访问
    Console.WriteLine ("{0}", cus.id);
}
```

### 数组

#### 一维数组

```csharp
<baseType>[] <name>
// 举例
public static void Main (string[] args)
{
    int[] arr1 = {1, 2, 3, 4};
    const int size = 5;
    int[] arr2 = new int[size];
    int[] arr3 = new int[5];
    int[] arr4 = new int[5]{1, 2, 3, 4, 5};
}
```

#### 多维数组

```csharp
<baseType>[,,,,...,] <name>
// 举例：二维
int[,] myArr;
int[,] myArr1 = new int[2, 3];
int[,] myArr2 = {{0, 1, 2},{2, 4, 6}};
int[,] myArr3 = new int[2, 3]{{0, 1, 2},{2, 4, 6}};
```

### 函数

- 优点：
  - 简化代码
  - 提高可读性

#### 函数的定义与调用

```csharp
static void ConsoleOutput()
{
	Console.WriteLine("Hello Unity!");
}
public static void Main(string[] args)
{
    ConsoleOutput();
}
```

- 函数的返回类型：void
- 函数的名称：ConsoleOutput
- 函数的参数列表：无

#### 函数重载

C#允许生命多个同名函数，根据参数列表进行区分

### 值类型与引用类型

- 值类型：直接存储自身值的类型，如数值类型、布尔类型、结构类型
- 引用类型：委托、数组、接口类型

#### ref与out关键字

使用ref关键字可以使得函数对参数的修改，能影响调用函数方的这个变量。

（传入的参数必须在调用函数方初始化）

```csharp
static void add(int x)
{
    x++;
}
static void ref_add(ref int x)
{
    x++;// 能改变调用这个函数时传入的外部参数在外部的值
}
public static void Main(string[] args)
{
    int x = 1, y = 1;
    Console.WriteLine("x={0} & y={1}", x, y);// x=1 & y=1
    add(x);
    ref_add(ref y);// 这里也需要写ref关键字
    Console.WriteLine("x={0} & y={1}", x, y);// x=1 & y=2
}
```

使用out关键字也可以实现类似的目的

（传入的参数必须在被调用函数内进行初始化）

```csharp
static void func(int x)
{
    x = 2;
    x++;
}
static void out_func(out int x)
{
    x = 2;
    x++;// 能改变调用这个函数时传入的外部参数在外部的值
}
public static void Main(string[] args)
{
    int x = 1, y = 1;
    Console.WriteLine("x={0} & y={1}", x, y);// x=1 & y=1
    func(x);
    out_func(out y);// 这里也需要写out关键字
    Console.WriteLine("x={0} & y={1}", x, y);// x=1 & y=3
}
```

##### 异同

|                                      |   ref    |   out    |
| :----------------------------------: | :------: | :------: |
|               传递方式               | 引用传递 | 引用传递 |
|       参数传入前是否需要初始化       |   需要   |  不需要  |
|        在函数中是否需要初始化        |  不需要  |   需要   |
| 函数定义和调用是否需要显式声明关键字 |   需要   |   需要   |

### 面向对象

```csharp
class Cup
{
    private float size;
    private string shape;
    public float Size//提供了访问和修改私有变量size的方法
    {
        get {
            return size;
        }
        set {
            size = value;
        }
    }
    public void FillLiquid(){}
    public void PourLiquid(){}
    public Cup(){}//构造函数
    ~Cup(){}//析构函数
}
```

#### 实例化

```csharp
public static void Main(string[] args)
{
	Cup coffeeCup = new Cup();
}
```

#### 访问修饰符

| 访问修饰符         | 说明                                                         |
| ------------------ | ------------------------------------------------------------ |
| public             | 公有访问。访问不受任何限制                                   |
| private            | 私有访问。只限于本类成员访问，子类、其它类都不能访问。       |
| protected          | 保护访问。只限于本类和子类访问，其它类不能访问。             |
| internal           | 只限于本项目内访问，其他不能访问                             |
| protected internal | 内部保护访问。只限于本项目、本类或是子类访问，其它类不能访问。 |

#### 继承

```csharp
class A : B
{
	...
}
```

#### 接口

> 定义接口

- 接口是定义了某些特定功能的集合，封装了一组未实现的方法和属性

```csharp
interface <interfaceName>
{
	<function definition>
}
```

> 接口的限制

- 不能单独存在，不能实例化
- 只能声明方法和属性，实现过程中必须在实现接口的类中完成

> 继承父类和实现接口

- 继承的父类必须放在实现的接口之前，否则编译器会报错

```csharp
class Animal
{
    public void EatFood(){}
}
interface IBusiness
{
    void Sale();
}
class Dog : Animal, IBusiness
{
	public void Wang(){}
	public void Sale(){}//实现接口的方法
}
```

#### 多态

多态还包括接口的多态

```csharp
class Dog : Animal, IBusiness
{
	public void Wang(){}
	public void Sale(){}	
}
public static void Main(string[] args)
{
    Dog dog = new Dog();
    IBusiness business = Dog;
    business.Sale();
}
```

#### 抽象类

使用`abstract`修饰符可以声明抽象类。

抽象类不能实例化，只能继承，可以包含抽象成员。

```csharp
public abstract class MyClass
{
    public int field;
    public void Func();
    public abstract void AbstractFunc();
}
public class MyClass2 : MyClass
{
	public override void AbstractFunc(){}//实现抽象父类的方法，需要使用override修饰符
}
```

#### 虚方法

使用`virtual`修饰符声明的方法可以被继承的类重写（重写时使用`override`修饰符）

```csharp
public class BaseClass
{
    public virtual void MyFunc()
    {
        Console.WriteLine(1);
    }
}
public class MyClass : BaseClass
{
	public override void MyFunc()
    {
    	Console.WriteLine(2);
    }
}
```

#### base与this关键字

base关键字可以访问父类定义的方法或属性

this关键字可以i访问本类定义/重写的方法或属性