# 《Mooc Hero - FPS》

## 概览

### 控制方法

- WSAD控制玩家的前后左右移动
- 空格键控制玩家的跳跃
- 鼠标的移动控制玩家的转向与视角变化
- 鼠标点击实现玩家射击

### 与第三人称的对比

|   摄像机行为   |      TPS       |       FPS        |
| :------------: | :------------: | :--------------: |
|    **视角**    |    第三人称    |     第一人称     |
| **摄像机位置** |  玩家背后空中  |   玩家眼睛位置   |
| **摄像机朝向** | 随玩家朝向变化 | 随鼠标平移而变化 |

## uGUI

### 对比旧版GUI

- 旧GUI系统在`OnGUI`函数中调整GUI的布局，效率低下
- unity4.6后，使用uGUI系统

### 优点

- 与Unity引擎紧密的结合
- 灵活、快速、可视化编程技术
- 更强的屏幕自适应
- 全新的布局系统
- 简单易用的UI控件
- 强大的事件处理系统

### 创建方法

Hierarchy视图→鼠标右击→UI→...（uGUI控件选择）

## Canvas

- Canvas是uGUI控件的容器，uGUI控件必须是Canvas的子对象
- EventSystem是事件处理系统，用于响应与处理用户与uGUI的交互

> 绘制规则

- 按照在Canvas中的顺序进行绘制：Hierarchy视图中排列在前（上）的对象先绘制

### Canvas组件

> 属性

- Sort Order（表示Canvas之间绘制顺序）：值越小，越先绘制。

## Anchor（锚点）

> 介绍

锚点用于相对定位，每个控件都有各自的锚点



## 控件

### Text控件

> 属性

- Text：文本内容
- Font：字体样式
- Font Style：字体风格
- Font Size：字体大小
- Line Spacing：行间距
- Alignment：对齐方式
- Color：文字颜色
- Material：文字材质

### Image控件

> 属性

- Source Image：图像源
- Color：图像显示的颜色
- Material：材质

### Button控件

Button控件是复合组件，包括背景图案、按钮功能、文本信息（控件）

> 属性或函数

- On Click（）：设置Button点击的事件


#### Button事件

> 设置流程

1. 编写Button按钮触发的事件函数（需要使用public修饰函数）
2. 将包含该函数的脚本添加到场景中任意一个游戏对象中
3. 在Button组件的OnClick中添加事件函数

> 示例

```csharp
public class CreateCube : MonoBehavior {
    public void AutoCreateCube() {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.position = Vector3.zero;
    }
}
```

### Input Field控件

在Unity中创建的InputField控件是复合控件，包括：

- 输入栏背景图案
- 输入栏组件
- 输入栏提示文本
- 输入栏可编辑文本

#### Text Component属性

将`Text控件`赋给`Input Field控件`的`Text Component属性`，才可以在游戏中编辑Text组件。

#### Placeholder属性

将`Text控件`赋给`Input Field控件`的`Placeholder属性`，才可以在游戏中编辑Text组件。

### Slider控件

> 介绍

在Unity中创建的Slider控件是复合控件，它包括

- 滑动条背景
- 滑动条填充图案
- 滑动块手柄

> 属性

- Fill Rect：滑动条填充图案
- Handle Rect：滑动条上的滑块图案
- Direction：数值增加的方向
- Min/Max Value：滑动条的最小值/最大值
- Value：滑动条的当前值

### Toggle控件

> 介绍

Toggle表示开关控件，它包含勾选框背景、勾选图案以及Toggle文本信息

> 属性

- Is On：Toggle是否勾选
- Graphic：设置Toggle背景图案
- OnValueChanged：当Toggle勾选情况发生改变时对应的事件响应函数

## 游戏面板的切换

```csharp
public void ActiveStartPanel() {
    InitSubPanel.SetActive(false);
    StartSubPanel.SetActive(true);
    OptionSubPanel.SetActive(false);
}
```

## 游戏场景的载入

```csharp
public void StartGame() {
    SceneManager.LoadScene("GamePlay");
}
```

### 场景切换

场景切换时可能出现无法LoadScene的问题，这是因为在File→Build Setting中未将即将切换的场景加入Build列表中。

## 关闭应用

```csharp
public void ExitGame() {
    Application.Quit();
}
```

## 受伤/被攻击效果

> 实现思路

使用一个Image控件，在未被攻击时其Alpha值为0，当被攻击时Alpha值为1。

> 渐变效果

- 使用Color.Lerp函数（线性插值）控制，使得Alpha值的线性渐变

## 禁用鼠标光标

```csharp
Cursor.visible = false;	//禁用鼠标光标
```

## 移动平台触摸控制的实现方式

- 方法一：使用Input移动端输入函数，完成移动端输入的读取
- 方法二：用Cross Platform Input资源包快速实现跨平台输入UI

### Cross Platform Input资源包导入

> 介绍

Cross Platform Input是Unity Standard Assets中的跨平台输入控制资源，它包含移动端常用的控制UI与控制脚本。

> 导入方法

Project视图→鼠标右键→Import Package→Cross Platform Input

> 控制UI介绍

- JoyStick：操纵杆控制玩家移动
- TouchPad：触摸板（全透明）控制玩家转向
- ButtonHandler：控制跳跃/射击等操作

## 使用Cross Platform Input制作移动端控制UI

步骤：

1. 将Unity编辑平台更改为Android平台
2. 向场景中添加Mobile Control Rig脚本
3. 在场景中添加用于接受移动端输入的UI对象
4. 给UI对象绑定Cross Platform Input中的脚本，用于获取移动端输入
5. 根据获取的输入在角色控制脚本中实现对玩家的控制

### 更改Unity编辑平台

File→Build Setting→选择Android平台→Switch Platform

### 向场景中添加Mobile Control Rig脚本

在Scene中创建Canvas（重命名为MobileControlCanvas），并将MobileControlRig脚本绑定到该Canvas中，该脚本是移动端UI输入事件的控制器。

### 移动端玩家移动的实现（Joystick）

1. 在MobileControlCanvas中新建Image，并命名为JoyStick，将其移动到合适的位置，并设置其图案（SourceImage）与透明度（Color）。——作为移动杆的背景图案
2. 在Joystick下创建Image对象，重命名为MobileJoyStick，将其移动到Joystick中央，并设置其图案（SourceImage）与透明度（Color）。——作为移动杆的移动图案
3. 给MobileJoystick绑定Joystick脚本，完成移动端玩家移动的控制。

### 移动端玩家转向的实现（TouchPad）

1. 在MobileControlCanvas中新建Image，并重命名为RotateTouchPad，将其移动至屏幕右侧，并将其设为全透明（Alpha=0）
2. 给RotateTouchPad添加TouchPad脚本，并将TouchPad的Control Style更改为Swipe，完成移动端玩家转向的控制。

### 移动端玩家跳跃射击的实现（ButtonHandler）

1. 将CrossPlatformInput中的预制件MobileSingleStickControl拖入场景中。
2. 将MobileSingleStickControl中JumpButton拖至MobileControlCanvas中，并删除预制件中的其它内容，同时删除JumpButton的Text子对象。
3. 此时JumpButton将作为实现移动端玩家跳跃与射击的按钮，它包含Event Trigger组件与Button Handler脚本组件，这两个组件将用于处理移动端的点击输入
4. 赋值JumpButton，在MobileControlCanvas粘贴，重命名为ShootButton，并将它们移动至屏幕右下角，并设置其图案与透明度。
5. 修改JumpButton与ShootButton的ButtonHandler脚本，将ButtonHandler脚本的Name属性分别更改为"Jump"与"Fire1"；

#### InputManager打开方式

Edit菜单→Project Settings→Input



## 移动平台UI适配

当项目运行平台的屏幕尺寸与分辨率发生变化时，UI元素会发生缩放，在画布对象中的Canvas Scaler的组件中，可以设置UI的缩放模式，主要包含以下三种可选参数：

- 固定像素尺寸（Constant Pixel Size）
- 尺寸随屏幕缩放（Scale With Screen Size）
- 固定物理尺寸（Constant Physical Size）：在这种缩放模式下UI元素保持固定的物理大小

## Unity编辑器中控制方式的切换

- 用移动平台的UI进行玩家控制：Mobile Input菜单栏→Enable
- 用PC端的鼠标键盘进行玩家控制：Mobile Input菜单栏→Disable

## 粒子系统（Particle System）

- 粒子是三维空间中渲染出来的二维图像，用于表现如爆炸、烟、火、水等效果
- Shuriken粒子系统采用模块化的管理方式，使用个性化的粒子模块配合粒子曲线编辑器，使用户更容易创作出各种缤纷复杂的粒子效果

### 创建粒子系统

Hierarchy视图→鼠标右击→Particle System

### 粒子系统效果模拟（Particle Effect）

- Pause：控制粒子系统的播放与暂停
- Stop：停止粒子系统
- Playback Speed：表示粒子系统的播放速度
- Playback Time：表示粒子系统的播放时间
- Particle Count：表示粒子系统包含的粒子个数

> 属性

- Start Lifetime：粒子初始存活时间
- Start Speed：粒子初始速度
- Start Size：粒子初始大小
- Start Rotation：粒子初始朝向
- Gravity：重力
- Max Particles：粒子最大个数

### Emission（发射模块）

- Rate：粒子发射速率

### Shape（形状模块）

- Shape：粒子喷射形状
- Angle：Cone角度
- Radius：Cone底部半径

### ColorOverLifetime（粒子生命周期颜色模块）

- Color：粒子颜色
- 初始颜色
- 末尾颜色

#### SizeOverLifetime（粒子生命周期尺寸模块）

- Size：尺寸
- 曲线设置


## 线渲染器

线渲染器（Line Renderer），使用一组3D点，在相邻两点之间使用材质绘制一条线

### 添加线渲染器组件

> 步骤

选择游戏对象→Component菜单→Effects→Line Renderer

## 线渲染器材质

- Materials：表示线渲染器绘制所使用的材质
- Positions
  - Size：表示线渲染器3D点的个数
  - Element：表示3D点的位置，数量由Size属性设置
- Parameters
  - Start Width：始端宽度
  - End Width：末端宽度
  - Start Color：始端颜色
  - End Color：末端颜色

## 物品收集实现

> 目标

玩家接近血瓶→玩家加血/播放音效/物品删除

> 实现方法

- 玩家接近血瓶：给物品设置触发器，使用OnTriggerEnter函数检测
- 物品删除：使用GameObject类的Destroy函数