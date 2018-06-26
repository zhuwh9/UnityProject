## Unity 3D概览

### 游戏引擎功能模块

- 游戏中实时光影绘制
- 动画系统
- 物理模拟系统
- 游戏场景渲染系统
- 网络通讯、AI系统
- 平台移植功能



### 主流游戏引擎

- Unity引擎
- Unreal引擎
- Cry Engine引擎



### Unity的优点

- 个人版免费且支持多种游戏类型的开发
- 功能丰富高度灵活的编辑器
- 优质的资源管道
- 易用的脚本语言系统
- 跨平台开发和团队协作
- 良好的资源来源与技术论坛
- VR游戏开发



### Unity编辑器

- Document：文档
- Web Player：Unity网页播放器
- Standard Assets：官方标准资源
- Example Project：官方项目样例
- Microsoft Visual Studio Tools for Unity：VS集成开发环境
- XXX Build Support：操作系统部署支持

### 变换工具

![](G:\GameDevelopment\1.png)

### 辅助变换工具

![1525663946024](G:\GameDevelopment\2)

### 播放控制

![1525666831887](G:\GameDevelopment\3)

2D图形：

- 位图

> 位图图像（bitmap），通常称为点阵图像，它由多个单点像素组成。每个像素具有一个RGBA颜色值，所有像素按矩形进行排列，构成一幅图像

- 矢量

> 矢量文件中的图形元素称为对象，每个对象都是一个自成一体的实体，具有颜色、形状、轮廓、大小和屏幕位置等属性。

### 2D作图工具

位图：

- Microsoft Paint（免费）
- Adobe Photoshop
- GIMP（免费）
- Corel Painter

矢量图：

- Corel DRAW
- Adobe Illustrator
- Adobe Flash
- Inkscape（免费）

### 3D模型

文件格式：

- MB/MA（Autodesk Maya）
- MAX（Autodesk 3DS Max）
- BLENDER（Blender免费）
- FBX（Unity默认）
- OBJ：用于存储静态的3D物体

### 常见音频类型

- OGG：一种完全免费、开放，没有专利限制的压缩音频格式**（Unity最常用）**
- WAV：录音时经常使用的标准的Windows文件格式
- MP3
- AIF：用于苹果的操作系统

### 常见音频制作处理软件

- Adobe Audition
- Adobe Soundbooth
- Audacity（免费）
- 游戏引擎混音：Unity和Unreal



## Project 1《多米诺骨牌》

- 物理系统基础（Physics）
- 图形系统基础（Graphics）
  - 三维物体渲染
  - 光源
  - 摄像机
- 音频基础（Audio）
- 项目构建（Build & Deploy）



### 新建项目

新建项目步骤：

打开Unity编辑器→New→设置项目名称、项目路径设置、项目维度设置、资源包导入（仅限Unity标准资源包）→Create Project



#### 场景

一个Unity项目中可以包含多个场景

场景相关操作：File菜单栏→XXX Scene



#### 资源（Asset）导入

- Project视图→鼠标右键→Import New Asset/Package
- 将项目外的资源拖拽进入Project视图，从而导入



#### 资源商店（Asset Store）

菜单栏Window→Asset Store



### 工程创建与资源导入

#### 工程创建

打开Unity→New→完成项目相关的属性设置→Create Project



#### 资源导入

右键点击Project视图-Assets→选择Import Package→选择对应的unitypackage文件→确认导入资源，点击import



#### 场景保存

File→Save scenes→选择文件夹（一般会在Project视图下Assets栏中创建一个Scene文件夹）



### 游戏对象（GameObject）

游戏场景中存在的物体都可以称为**游戏对象**，如场景中的物体、环境元素、特效等



#### 创建游戏对象

- 方式一：菜单栏→GameObject→...（选择需要创建的游戏对象）
- 方式二：Hierarchy视图→鼠标右键→3D Object→Cube



#### 标签（Tag）

游戏对象标签方便我们区分一些特殊种类的游戏对象

标签的设置方法：

- 选中目标游戏对象→Inspector视图→Tag
- 添加Tag标签：选中目标游戏对象→Inspector视图→Tag→Add Tag...



#### 组件（Component）

在游戏场景中，游戏对象之间的表现与行为存在差异。

Unity使用组件（Component）来表示游戏对象的某种属性或行为。

##### 给游戏对象添加组件

- 方式一：Hierarchy视图中选择游戏对象→Component菜单→...
- 方式二：Hierarchy视图中选择游戏对象→Inspector视图→Add Component



#### Transform组件

> 组件的用途

- 用于设置游戏对象在场景中的位置、朝向以及尺寸
- 绝大部分游戏对象（UI游戏对象除外）都包含Transform组件
- Transform组件无法手动添加或删除，创建游戏对象时自带的组件。

> 具体参数讲解

- Position：游戏对象相对于其父对象的坐标位置
- Rotation：游戏对象相对于其父对象的x、y、z轴的旋转角度（顺时针为正）
- Scale：游戏对象相对于其父对象在x、y、z轴方向的缩放倍数（1表示原始长度）

##### 对象之间的父子关系

子对象随父对象移动（保持相对位置）

- 设置父子关系：Hierarchy视图→将子对象拖至父对象下一层

> 父子关系与Transform组件

当游戏对象成为另一个游戏对象的子对象，该游戏对象的Transform组件属性会改变（参照系改变）



#### 预制件（Prefab）

> 优点

- 方便进行相同游戏对象的创建
- 相同游戏对象的修改可以批量进行

> 什么是预制件

- 预制件是一种资源类型——存储在Project（项目）视图中的游戏对象原型。
- 预制件可以放入多个场景中，通过拖拽预制件到场景实现（此操作是在场景中创建了该预制件的一个实例）

> 修改预制件和修改预制件实例的区别

- 对预制件的修改，会自动应用到所有预制件实例中（但对预制件实例不会影响其他同类实例）
- 如果修改了某个预制件实例，并使用Inspector→Prefab→Apply，会使得该修改影响到预制件

<img src="G:\GameDevelopment\4.png" style="width:50%;height:50%" />



### 物理引擎基础

物理系统：在虚拟世界中使用物理引擎，运用物理算法对游戏对象的运动进行模拟，例如重力、摩擦力、碰撞等，使游戏更加真实。

- Unity使用的物理引擎：**NVIDIA公司的PhysX物理引擎**

> 物理系统组件

- 刚体（Rigidbody）
- 恒定力（Constant Force）
- 碰撞体（Collider）

> 物理系统管理器（Physics Manager）

#### 刚体

刚体指物体受力时，外形、尺寸、内部结构组织等都不受影响的一个特性。

> 添加刚体

- 添加刚体：选中游戏对象→Add Component→Physics→Rigidbody

**注：每个游戏对象只能添加一个刚体组件**

> 属性详解

- Mass：对象的质量
- Drag：对象运动时的阻力
- Angular Drag：对象旋转时的角阻力
- Use Gravity：是否应用重力（默认勾选）
- Contraints：刚体约束
  - Freeze Position：位置约束，选中X项表示刚体受力后沿X轴不发生位移
  - Freeze Rotation：旋转约束，选中X项表示刚体受力后沿X轴不发生旋转

#### 恒定力

> 添加方法

- 添加恒定力：选中游戏对象→Add Component→Physics→Constant Force

> 实际游戏场景中的作用力

游戏模拟的场景中，作用力通常是通过游戏对象之间的交互产生的，同时，作用力不一定是恒定力

其次，通常使用**游戏脚本**，给游戏对象添加作用力。

#### 碰撞体（Collider）

> 什么是碰撞体

- 碰撞体定义了对象在物理系统中的碰撞形状，对象的碰撞形状用于物理模拟中的碰撞检测。
- 只有两个对象都有碰撞体组件时，物理引擎才会计算碰撞，否则物体会相互穿过

>添加方法

- 添加碰撞体：选中游戏对象→Add Component→Physics→XXX Collider

> 属性

- Is Trigger：勾选后，碰撞体会变成触发器（即不再具有碰撞体的功能），用于检测是否有物体进入该触发器的区域
- 一个游戏对象可以拥有多个碰撞体

##### 分类

- 盒式碰撞体
- 球形碰撞体
- 胶囊碰撞体
- 网格碰撞体
- 车轮碰撞体
- 地形碰撞体

#### 物理材质

> 创建物理材质

方法：Project视图→鼠标右键→Create→Physic Material

> 属性

- Dynamic Friction：动摩擦力
- Static Friction：静摩擦力
- Bounciness：弹力
- Friction/Bounce Combine：定义两个碰撞体之间的摩擦力/弹力如何相互作用

#### 物理系统管理器(Physics Manager)

> 打开方法

- Edit菜单→Project Settings→Physics

> 属性

- Gravity：设置物理系统中的重力
- Default Material：碰撞体组件默认使用的物理材质
- Bounce Threshold：弹性阈值
- Default Contact Offset：表示两个对象发生碰撞的距离，当两个对象的距离小于该碰撞距离时，该两个对象会发生碰撞

### 图形系统

#### 网格（Mesh）

游戏中的三维物体使用网格来描述自身的形状和尺寸，一个模型由若干网格面组成，每一个面由若干个三角形组成。

> 网格渲染器与网格过滤器必须成对使用，缺少任意一个都会导致游戏对象渲染失败

- 网格过滤器相当于骨骼，决定了游戏对象的几何形状
- 网格渲染器相当于血肉，决定了游戏对象的外观、颜色等表面特质

##### 网格过滤器（Mesh Filter）

网格过滤器存放游戏对象的网格信息，并把网格信息传递到网格渲染器中，最后将网格渲染到屏幕中。

主要目的是用于确定模型的形状与尺寸。

> 属性

- Cast Shadows：表示是否产生阴影
- Receive Shadows：是否接受阴影
- Materials：网格所用的材质组

##### 网格渲染器（Mesh Renderer）

不勾选时，游戏对象不可见

#### 材质（Material）

> 创建方法

Project视图→鼠标右击→Create→Material

#### 着色器

着色器用于图像的渲染过程，具有可编辑性，不受显卡的固定渲染管线限制，可以实现丰富的图像效果

##### 标准着色器

> 适用对象

大多数表面效果的渲染（人物、风景、环境），标准着色器都是最好的选择。

> 属性

- Rendering Mode
  - Opaque：不透明
  - Transparent：制作头盔、玻璃等透明效果
  - Fade：制作淡入淡出的效果
  - Cutout：允许透明、不透明的效果同时存在并有明显的边界（如有破洞的衣服、叶子、草）
- Main Maps
  - Albedo：表示光的反照率，描绘物体的基本颜色
  - Normal Map：法向贴图，可以通过改变光的反射角度，使物体显得凹凸不平。
  - Emission：自发光，使物体看起来“自发光”

##### 天空盒（Skybox）

一种用于设置场景中天空背景图案的着色器类型。

- Skybox/6 Sided：一种常用天空盒类型，其通常由x+、x-、y+、y-、z+、z-六个方向的贴图构成




### 光源（Light）

> 创建光源

Hierarchy视图→鼠标右键→Light→...

#### 光源（Light）组件

> 属性

- Type：光源类型
  - 方向光
  - 点光源
  - 聚光灯
  - 面光源
- Color：光源颜色
- Intensity：光照强度
- Bounce Intensity：反射光强度

#### 环境光

> 打开方式

菜单栏→Window→Lighting→Scene

> 属性

- Skybox：场景天空盒设置
- Ambient Source：环境光来源
- Ambient Intensity：环境光强度

##### 天空盒材质

> 创建天空盒的材质

Project视图→鼠标右击Asset→Create→Material→Skybox→6 sided

> 应用到Lighting视图中

Lighting视图→Environment Lighting→Skybox→选择Asset中对应的材质

##### 环境光来源（Ambient Source）

- 天空盒（Skybox）
- 梯度光（Gradient）
  - Sky：天空的光颜色
  - Equator：赤道的光颜色
  - Ground：地面的光颜色
- 单色光（Color）

### 摄像机

> 有什么用

Unity的场景中必须有一个摄像机用于绘制场景。引擎对摄像机能看到的游戏世界中的空间区域进行渲染，生成最终的游戏画面。

> 摄像机创建

Hierarchy视图→鼠标右键→Camera

> 属性

- Clear Flags：摄像机清楚标记，摄像机未绘制部分的图像显示
- Projection：摄像机的投射方式
- Field of View：摄像机视角
- Clipping Planes：摄像机远近剪切平面
- **Depth**：默认为-1，参数值越小，对应的游戏画面越早绘制。但，后绘制的图像会覆盖前期绘制的图像

#### 摄像机清除标记（Clear Flags）

- Skybox（预设）：以天空盒作为摄像机的清除标记
- Solid Color：以某种颜色作为摄像机的清除标记
- Depth Only：以深度值较低的摄像机渲染的图案作为该摄像机的清除标记
  - 用于多个摄像机的同时绘制
- Don't Clear：不清除，摄像机的清除标记为上次渲染过的图像

#### 摄像机其他组件

- GUI Layer：GUI（Unity4.6之前的旧版）显示组件，使摄像机中能显示旧版GUI控件
- Flare Layer：镜头耀斑显示组件，使镜头耀斑特效显示在摄像机所渲染的图形中
- Audio Listener：音频监听组件，用于收集游戏场景中的声音并播放

#### 分类

摄影机视角的不同：

- 第一人称（FPS）
- 第三人称（TPS）

摄影机显示个数：

- 单人模式
- 多人模式（多人同屏）

其他摄像机行为：

- 赛车游戏中的后视镜
- 射击游戏中人物死亡后的摄像机切换

### 音频（Audio）

> Unity中的音频实现

Unity中的音频系统通过下列两部分实现：

- AudioSource（播放）：用于场景中声音的播放
- AudioListener（监听）：用于收集场景中发出的声音并播放

#### 音频监听（AudioListener）

> 介绍

- 摄像机对象中预置了AudioListener组件
- 可以通过添加组件的方式，给游戏对象添加音频监听组件

> 注意

- 当场景中存在多个AudioListener时，Unity编辑器会随机选择将其中一个AudioListener生效，其余均保持静默。

> 添加方法

选择游戏对象→Add Component→Audio→Audio Listener

#### 音频源（AudioSource）

> 介绍

音频源在场景中播放音频片段（Audio Clip）

> 添加方法

选择游戏对象→Add Component→Audio→AudioSource

> Inspector视图中的属性

- AudioClip：音频片段
- Mute：是否静音（默认不勾选，即不静音）
- Play On Awake：是否自动播放（默认勾选）
- Loop：是否循环（默认不勾选）
- Volume：音量大小
- Pitch：音调高低

#### 音频系统管理器（AudioManager）

> 介绍

负责管理整个项目中音频系统的相关参数

> 打开方式

菜单栏→Edit→Project Settings→Audio

> 属性

- Global Volume：全局音量大小设置
- Disable Unity Audio：是否停用Unity的音频系统（默认不勾选）

### 项目构建（Build）

> 为什么需要项目构建

当Unity项目制作完毕后，需要对项目进行构建，使Unity项目脱离Unity编辑器独立运行

> 构建方法

菜单栏→File→Build Settings

> 构建步骤

1. 将场景添加到构建列表
2. 选择项目发布的平台
   - 平台切换：选择想要切换的平台，点击Switch Platform按钮
3. 设置平台参数
4. 生成游戏项目

#### Android移动平台的项目构建

1. Android SDK与JDK的下载与设置
   - Android要求Android SDK的**API Level大于等于21**
2. Android项目参数设置
3. Android手机连接设置

##### SDK与JDK设置方法

> 方法

菜单栏→Edit→Preferences→External Tools→设置SDK与JDK的目录

##### 项目设置

> 方法

File→Build Settings→Android→Player Settings

> 属性

- Default Orientation：设置屏幕默认朝向
- Status Bar Hidden：状态栏隐藏
- Other Settings
  - Bundle Identifier：Android应用的标识符，用于区别该应用与其他应用，不能使用默认值

#### 发布

> 方法

File→Build Setting→Build

## Unity脚本基础

> 创建脚本

Project视图→鼠标右击→Create→C# Script

> 脚本编辑

Edit菜单→Preferences→External Tools

### 控制台（Console）视图

> 使用脚本在控制台输出相关信息

```csharp
Debug.Log();//消息
Debug.LogWarning();//警告
Debug.LogError();//错误
```

### Unity脚本生命周期

- Unity编辑器中创建的C#脚本创建的类继承自`MonoBehaviour`，
- Unity在游戏运行的各个阶段调用脚本的事件函数，如start函数和update函数

### Unity事件函数

- Reset()：脚本编辑阶段执行，脚本绑定到游戏对象上执行一次 
- Awake()：当脚本链接的游戏对象被激活时执行（无论该脚本控件是否启用）
- OnEnable()：当该脚本启用时执行一次
- Start()：当该脚本启用时进行检查（如果场景中Start()函数从未执行过，则OnEnable()函数执行后执行一次；否则，不会执行Start()函数，以确保Start()函数只执行一次）
- OnDisable()：当脚本禁用时执行一次。
- OnDestroy()：当脚本被移除（解除绑定）时执行一次。
- FixedUpdate()：每隔固定时间执行一次，常用于物理模拟，如作用力的添加等
- OnTriggerXXX()：每隔固定时刻检测一次，包括OnTriggerEnter()、OnTriggerStay()、OnTriggerExit()函数，分别用于有物体进入、停留、离开Trigger（触发器）范围时执行
- OnCollisionXXX()：每个固定时刻检测一次，包括OnCollisionEnter()、OnCollisionStay()、OnCollisionExit()函数，分别用于有物体进入、停留、离开Collider（碰撞体）范围时执行。
- OnMouseXXX()：输入阶段，用于响应鼠标的输入事件
- Update()：每帧执行一次，常用于游戏逻辑等相关行为的执行
- LateUpdate()：每帧执行一次，在Update()函数后执行。

> 举例：第三人称游戏的摄影机跟随，Update()中执行玩家角色移动，LateUpdate()中执行摄像机跟随玩家，能防止摄像机的抖动现象。

- OnGUI()：每帧执行多次，绘制Unity的图形用户界面。

![1525771194915](G:\GameDevelopment\life_circle.jpg)

注：在脚本禁用前，循环执行物理循环~OnGui()的函数序列。

### Unity脚本之间执行顺序

以堆栈的方式执行脚本：先设置的脚本，后执行；后设置的脚本，先执行。

#### 管理脚本的执行顺序

> 使用MonoManager对脚本的执行顺序进行排序

打开MonoManager方法：Edit菜单→Project Setting→Script Execution Order

##### 优先级

优先级越小，脚本越早执行（相当于越晚放入堆栈）。

> 一些注意事项

- 未在MonoManager进行脚本设置，则脚本优先级默认为0（Default Time）
- 对于优先级相等的脚本，则采用默认的“**先设置，后执行**”的执行方式
- 优先级只表示脚本的执行顺序，并不表示脚本执行时间的延迟（即优先级=100不表示延迟100ms运行）

