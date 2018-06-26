## 《Mooc Hero2》

### Nav Mesh导航网络

> 介绍

- Nav Mesh导航是3D游戏中，用于实现动态物体自动寻路的技术
- 它将游戏场景中复杂的对象结构简化为带有一定信息的网格。在这些网格的基础上，通过一系列的计算实现自动寻路
- Unity能自动生成Nav Mesh导航网格



### Nav Mesh Agent导航代理组件

> 介绍

- Unity的Nav Mesh Agent是配合导航网格使用的导航代理组件；
- 给物体添加导航代理组件后，物体会自行根据目标位置和导航网格，寻找合适的路线，沿着找到的路线移动到目标位置。

#### 生成导航网格

- 第一步：标记用于生成导航网格的物体；


- 第二步：在Navigation视图中点击bake按钮生成导航网格。

##### 标记用于生成导航网格的物体

选中游戏对象→Inspector视图→调整为Navigation Static（表明选中的物体用于生成导航网格）

##### 打开Navigation视图

菜单栏Window→Navigation

##### 烘焙导航网络

- 单击Navigation视图右下角的Bake按钮，生成导航网格。

#### 为动态物体添加导航代理组件

> 添加方法

菜单栏Component→Navigation→Nav Mesh Agent

> 可设置属性

- 导航代理的尺寸
- 导航代理的运动属性
- 闪避、寻路等行为的属性

**注：寻路行为需要代码控制**

> 属性详细说明

##### Agent Size导航代理尺寸

- Unity导航代理组件使用一个圆柱体，代表导航物体。Unity导航系统会根据圆柱体的尺寸，避免导航物体与障碍物或其它导航物体，发生碰撞。
- Radius是导航代理的半径，Height是导航代理的高度，Base Offset是导航物体相对于圆柱体导航代理的垂直偏移量。

##### Steering控制属性

- Speed：最大移动速度
- Angular Speed：最大转向速度
- Acceleration：最大加速度
- Stopping Distance：停止距离。当导航代理与目标距离小于等于Stopping Distance时停止，为0时表示接触后停止。
- Auto Braking：自动刹车。勾选时，导航代理到达目标位置前，会逐渐减速，最终停止在目标位置上。

##### Obstacle Avoidance躲避属性

- 导航代理组件中Obstacle Avoidance标签下的属性，和导航代理的躲避行为有关。
- Quality属性
  - Quality表示躲避的质量，如果场景中存在大量的导航代理，降低质量可以减小CPU的利用率
  - 如果Quality属性设置为None，导航代理不会躲避其它导航代理和障碍物。
- Priority属性
  - Priority属性表示导航代理的优先级，范围从0到99，值越小优先级越高
  - 导航代理只会躲避比自己优先级高的其余导航代理。

#### 代码控制

> 下面是实现导航代理控制的代码实现

##### 获取导航代理组件

```csharp
protected NavMeshAgent agent;
void Start() {
    agent = GetComponent<NavMeshAgent>();
}
```

#### 标记导航目标位置

- destination属性用于表示导航的目标位置

```csharp
protected void SetDestination() {
    ...
    target.position = hit.point;
    agent.destination = target.position;
}
```

### 烘焙代理参数

> 介绍

导航系统使用一个圆柱体代表场景中参与导航的活动物体，来判断场景中哪些位置是可以通行的

> 参数

- Agent Radius：圆柱体烘焙代理的半径
- Agent Height：圆柱体烘焙代理的高度
- Max Slope：圆柱体烘焙代理的最大爬坡角度，最大爬坡角度不能超过60度
- Step Height：圆柱体烘焙代理的脚步高度，对于任意一个高于地面的平台，它的高度必须小于烘焙代理的脚步高度。**如果烘焙脚步高度大于代理本身高度，会用代理本身高度代替烘焙脚步高度。**
- Drop Height：表示烘焙代理导航物体可以直接从较高的平台跳落到较低的平台
- Jump Distance：表示烘焙代理的最大跳跃距离
- Off Mesh Link：允许开发者在不相连的导航区域间创建路径（类似于传送门）

#### Off Mesh Link

> 介绍

允许开发者在不相连的导航区域间创建路径（类似于传送门）

> 创建方法

菜单栏Component→Navigation→Off Mesh Link

> 属性

- Start：Link的第一个接口
- End：Link的第二个接口
- Bi Directional：表示双向路径
- Activated：表示激活路径

#### Nav  Mesh Obstacle障碍物组件

> 介绍

- 添加了Nav Mesh Obstacle障碍物组件的游戏对象会成为障碍物
- 添加了导航代理组件的物体，遇到障碍物，会绕开障碍物。

> 添加方法

菜单栏Component→Navigation→Nav Mesh Obstacle

### AI

> 介绍

- 基本行为操控：
  - 靠近、远离、追逐、逃避
- 寻路能力：
  - 从游戏场景中的一个位置移动到另一个位置
- 感知能力：
  - 自身状态，听觉和视觉等感知能力
- 自主决策能力：
  - 根据自身和外部环境条件，做出合理的反应

#### 感知游戏世界

- 模拟僵尸的听觉和视觉的方法：
  - 触发器（Trigger）
  - 向量计算（Vector）

##### 使用触发器Trigger进行感知

- Unity的Trigger触发器可以用于实现僵尸对外部世界的感知
- OnTriggerEnter、OnTriggerExit和OnTriggerStay分别会在其它对象进入、离开和停留于触发器范围内时被调用

##### 使用Vector模拟僵尸的听觉

- 如果玩家与僵尸的距离小于僵尸的听觉范围，说明僵尸可以感知到玩家（**使用Vector3.Distance方法**）

##### 视觉的模拟

- 视觉范围使用僵尸眼睛正前方的一个圆锥体来模拟，只要玩家位于这个圆锥体内部，且不被遮挡，我们就认为僵尸看见了玩家（**分别使用Vector3.Angle方法和Physics.Raycast方法**）

#### 有限状态机（Finite State Machine）

使用有限状态机可以实现敌人的自主决策能力

##### 更新状态机

- 在FixedUpdate函数中调用状态机更新函数（FSMUpdate）来不断更新状态机。
- 在FSMUpdate函数中，根据当前状态currentState的值，调用相应的状态处理函数。

### 前向动力学

> 什么是前向动力学？以下这种决定骨骼节点位置的方式就叫做前向动力学。

- 大多数角色动画都是通过将谷歌的关节角度旋转到预定值来实现的
- 一个子关节的位置由它的父节点的旋转角度来决定
- 节点链末端的节点位置，是由节点链上各个节点的旋转角度和相对位置决定的。

### 逆向动力学

- 给定末端节点的位置，从而逆推出节点链上所有其它节点的合理位置的方法称为逆向动力学，Inverse Kinematic，简称IK

#### Unity动画系统中的IK

- Unity的Mecanim动画系统，允许开发者通过脚本，实现角色模型的逆向动力学，涉及的函数和字段包括：
  - SetIKPosition()；
  - SetIKRotation()；
  - SetLookAtPosition()；
  - SetIKPositionWeight()；
  - SetIKRotationWeight()；
  - bodyPosition/bodyRotation

#### 实现玩家持枪动作的基本步骤

1. 在玩家动画控制器Animator中开启IK功能
2. 创建四个球体游戏对象，作为IK标记物，分别对应玩家的双手、头部、躯干
3. 通过IK控制脚本，把IK标记物的Position和Rotation属性，赋值给角色模型头部、手部和躯干等骨骼关节相应的IK属性
4. 在预览状态下，调整IK标记物的位置和朝向，使玩家头部，手部，躯干等骨骼节点，具有合适的位置和朝向，实现玩家的持枪动作

#### 开启动画层IK

> 方法

Animator视图→某个动画层Layer→点击齿轮图案→勾选IK Pass

#### IK Controller脚本

- 获取用于设置IK的Animator组件

```csharp
animator = GetComponent<Animator>();
```

- 使用lookObj对象的位置设置玩家的视线方向

```csharp
animator.SetLookAtWeight(1.0f);
animator.SetLookAtPosition(lookObj.position);
```

- 使用bodyObj对象的rotation属性，设置玩家躯干的旋转角度

```csharp
animator.bodyRotation = bodyObj.rotation;//使其朝向与IK标记物相关
```

- 设置左右手属性

```csharp
animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.Rotation);
```

### 换枪功能

> 玩家换枪功能的实现步骤

1. 为玩家对象添加新的枪械模型
2. 为新的枪械模型设置正确的角色模型IK；
3. 为新的枪械模型添加攻击脚本，设置攻击力，攻击距离，攻击速度和攻击特效等属性；
4. 为玩家添加换枪脚本，换枪脚本的武器列表用来记录玩家所有的枪械对象。

#### 添加新的机枪模型

与添加普通枪械IK方法一样设置机枪的IK标志物

#### 重新设置IK标记物

换枪后，需要重新设置IKController的IK标记物

```csharp
Transform newWeapon = weaponList[newIdx];
Transform rightHand = newWeapon.Find("RightHandObj");
Transform leftHand = newWeapon.Find("LeftHandObj");
Transform gunBarrelEnd = newWeapon.Find("GunBarrelEnd");
ikController.leftHandObj = leftHand;
ikController.rightHandObj = rightHand;
ikController.lookObj = gunBarrelEnd;

newWeapon.gameObject.SetActive(true);
weaponList[currentIdx].gameObject.SetActive(false);
```



## 光源

### 点光源

- 从光源位置向所有方向发射出强度相等的光线
- 在传输过程中不断的衰减，当传输距离达到预设的极限距离range时，光线强度衰减为0；
- 适合模拟灯笼、火把等局部光源


### 方向光

- 不会衰减，以相同强度和方向，照亮空间中的所有物体
- 位置信息没有任何意义
- 常用来模拟那些体积较大，距离游戏场景非常远的光源，比如日光和月光。

### 聚光灯

- 聚光灯从光源位置开始向某个特定方向照射，照亮一个圆锥体的空间区域，在传播过程中不断衰减
- 通常适用于模拟人造光源，比如手电，车灯，探照灯等。

### 面光源

- 使用一个矩形来定义，光线将从矩形的正面出发，照亮矩形前的一片区域
- 适用于模拟广告灯箱等光源
- **不能作为实时光源，只能在Baked GI模式下使用，且只有在烘焙完毕后才能看到面光源的效果**


## 光源的属性

- 类型以及与类型相关的属性
- 烘焙


- 颜色
- 强度/反射强度
- 阴影
- 渲染类型
- Cookies

### Type

- 方向光：Directional
- 点光源：Point
- 聚光灯：Spot
- 面光源：Area（Baked Only)

### Baking

烘焙属性

- 实时：Realtime，在没有开启任何全局光照的情况下，该光源选择局部光照，在开启Precomputed Baked GI的情况下，该光源产生实时全局光照
- 烘焙：Baked，表示该光源用于Baked GI模式下烘焙光照纹理，无法对非静态物体产生影响
- 混合：Mixed，表示该光源除了用于Baked GI模式下烘焙光照纹理，还会在运行时照亮非静态物体

### 颜色、强度与间接光照强度

- 光源的颜色：Color
- 光源的强度：Intensity
- 间接光照的强度：Bounce Intensity

### 阴影

- Shadow Type：光源产生的阴影类型

可选值包括：

- 无阴影：No Shadows
- 硬阴影：Hard Shadows
- 软阴影：Soft Shadows

### Cookie

Cookie：通过纹理，给光源添加了一层遮罩，改变光斑形状

- 方向光和聚光灯的Cookie：使用普通纹理
- 点光源的Cookie：使用Culling Mask纹理

### Halo

勾选Halo属性，会在光源所在位置绘制一个球形的光晕

### Flare

设置光源产生的镜头光晕效果

### Render Mode

- Render Mode：光源的渲染方式
  - 自动：Auto
  - 重要：Important，以逐像素的方式渲染被照射到的物体，这种渲染更加精细，能够产生阴影
  - 不重要：Not Important，以逐顶点或逐对象的方式渲染被照射到的物体，这种方式速度快，质量较差，不能产生阴影

### Culling Mask

- Culling Mask：设置光源所能照射到的物体类型，可选项为当前项目中的Layer，只有选中的Layer才能受到这个光源的影响

## 阴影

Unity渲染阴影的方式：

- 在光源位置摆放摄像机，渲染一遍场景，渲染过程只计算当前视角下可见的物体的深度信息，并以ShadowMap的方法保存下来
  - ShadowMap记录了场景中哪些物体离光源最近，能够被光线直接照射到。
  - 场景中不在ShadowMap图像上的部分都是阴影区域
- 最后场景摄像机正式绘制场景时，参考ShadowMap绘制出阴影

### 在Unity中渲染阴影

1. 在Light组件中，设置光源的Shadow Type为Hard Shadows（边缘锐利）或者Soft Shadows（边缘柔和）
2. 设置Shadow的相关属性
   - Strength：表示阴影的强度（阴影有多黑）
   - Resolution：表示之前提到的ShadowMap的分辨率
   - Shadow Near Plane：表示阴影的最小距离，任何以光源的最小距离小于这个值的物体表面上都不会产生阴影
3. 设置Render Mode为Auto或Important（不可以是Not Important，这会导致无阴影）
4. 对于遮挡光线并在其它物体上产生阴影的对象，设置其Mesh Renderer组件的Cast Shadows为On。
5. 对于接收阴影的物体，在Mesh Renderer组件中，勾选Receive Shadows属性。

#### 阴影缺失的原因

- 显卡不支持阴影渲染
- **项目质量（Quality）设置中关闭了阴影。**
- 产生阴影的光源Rendering Mode为Auto，但被Unity自动判定为Not Important类型的光源**（因此需要手动设置为Important）**
- 产生阴影的物体是透明物体
- 接受阴影的物体使用了Standard Shader，且Rendering Mode为Transparent
- 接收阴影的物体使用了其它逐顶点的着色器

#### 阴影马赫带（条纹或斑点）与光源Bias属性

- 开启阴影后，可能会在物体表面出现一些奇怪的条纹*（马赫带）*或者斑点，这是由于Unity在计算阴影时，ShadowMap的**精度不足**造成的
  - **可以通过调高Bias属性的值解决马赫带问题**
  - Bias值设置过大，会导致阴影面积减小，或者消失

## 光照

- 局部光照：Local Illumination
- 全局光照：Global Illumination，简称GI

### 局部光照（local illumination）

**概念**：在计算物体光照时，孤立看待物体，不考虑物体之间的相互影响，每次只考虑：

- 一个光源
- 一个物体表面
- 一个观察者

**特点**：

- 简单、快速、资源消耗少
- 与真实世界差异较大


### 全局光照（Global Illumination）

**概念**：在计算物体光照时，既考虑光源直接照射所产生的影响，也考虑间接光照，也就是物体之间的反射光线和折射光线，产生的影响

**特点**：

- 效果接近真实世界
- 算法复杂，计算量大
- 难以用于实时图形程序

**步骤**：

1. 静态物体的设置

> - 选中需要应用全局光照的游戏对象
> - 在Inspector视图中，勾选Static下的Lightmap Static

2. 启动全局光照功能

> - 点击Window菜单栏下的Lighting，打开Lighting设置窗口
> - 点击Lighting窗口顶端中部的Scene按钮，打开场景配置页
> - 根据需要勾选Precomputed Realtime GI或者Baked GI，也可以二者都勾选
> - 勾选窗口底端Build按钮左侧的Auto复选框

3. 设置光源的Baking属性为**Baked**，表示该光源用于Baked GI模式下烘焙光照纹理。

**烘焙和应用**

- **Baked GI模式**：在Baked GI模式下，每当增删静态物体或者修改静态物体的属性，修改Baked或者Mixed光源的属性后，Unity都会自动重新烘焙，并在烘焙结束后自动应用全局光照效果。
- **Precomputed Realtime GI模式**：在Precomputed Realtime GI模式下，每当我们增删静态物体或者修改静态物体的一部分属性后，Unity都会自动重新烘焙，并在烘焙结束后自动应用全局光照效果。
  - 但，增删Realtime光源，或者修改光源属性，都不会重新烘焙。**这是因为该模式允许运行时动态改变光源。**
- 区别：增删/修改光源后是否会重新烘焙

#### Baked GI

- 需要预计算（Unity称其为**烘焙**），只对静态物体有效
- 编辑阶段：
  - 在编辑器中，标记出场景中不会运动的静态物体
  - **烘焙（Bake）**：预先计算静态物体的全局光照效果
  - 结果保存为光照纹理**LightMap**
- 游戏运行阶段：
  - 直接从**LightMap**中获取光照信息

#### Precomputed Realtime GI

- Unity5.0之后的版本支持预计算实时GI
- 需要预计算（烘焙），但只对静态对象有效
- 烘焙结果中保存和Baked GI不同的信息
- 运行时实时计算全局光照
- 优点：
  - 可以在运行时动态改变光源的数量，位置，朝向，以及物体的材质

##### 比较

|                   Empty                    | Baked GI | Precomputed Realtime GI |
| :----------------------------------------: | :------: | :---------------------: |
| 实时改变光源的数量、位置、朝向和物体的材质 |  不允许  |          允许           |
|                 软阴影效果                 |   较好   |          一般           |
|            运行时消耗的计算资源            |   较少   |          较多           |
|                 适合的设备                 |  手机端  |          PC端           |

#### 局限性

- 全局光照预计算（烘焙）需要花费较长的时间
- 只对静态物体有效
- 非静态物体反射的光线无法影响其它物体
- 非静态物体也无法直接受到烘焙光源和静态物体反射光线的影响

### 光照探头

> 光照探头技术用于解决全局光照模式下，非静态物体与静态场景之间光照不协调问题。

**基本思想**：

- 编辑阶段：在场景中放置光照探头，并在探头的位置对光照进行采样，然后保存采样数据。
- 运行阶段：选择非静态物体附近的几个光照探头，使用这些探头的采样数据，**插值**获得静态物体的光照效果。



## 着色器

- 着色器本质上是一种运行在显卡GPU上的程序，用于控制显卡的图形渲染过程

### 着色器语言

- GPU采用的是不同于CPU的并行计算结构，需要一种适用于GPU的编程语言，就是着色器语言
- 着色器语言主要包括：HLSL（针对Direct3D图形库的High Level Shading Language）、GLSL（基于OpenGL图形库的GLSL）、Cg（NVidia与微软合作研发）

### Unity的ShaderLab语言

- Unity使用自定义ShaderLab开发语言来组织着色器，针对不同平台进行编译

### 材质与着色器

- **材质**定义了物体表面的显示效果，每个材质必须绑定一个**着色器**
- 材质绑定的着色器决定了该材质的渲染方式，以及可配置属性的类型和数量

#### 着色器的使用

- 新建材质后，首先为材质选择着色器

> 选择方法

选中材质→Inspector视图→Shader下拉列表选择着色器

- 选择着色器后，配置材质的各个属性，并在Inspector视图下方预览材质效果

### Unity内建着色器

- Unity提供了逾80种内建着色器，能够实现从简单的顶点光照到高光、透明、反射等材质效果
- 可以在材质的Inspector视图中找到并使用这些着色器，内建着色器按功能分类存放

#### 分类

- Standard和Standard（Specular setup）：标准着色器
- FX：光照，水与玻璃效果着色器
- GUI和UI：用户界面着色器
- Mobile：移动平台使用的简单着色器
- Nature：植被和地形着色器
- Particles：粒子系统使用的着色器
- SkyBox：天空盒等背景环境着色器
- Sprites：2D精灵系统着色器
- Unlit：忽略一切光照和阴影效果的着色器
- Legacy：过时着色器

##### 标准着色器

- 可配置属性种类多
- 只有设置了的属性，其相应功能才会启用，未设置的属性保持禁用

##### 玻璃着色器（FX/Glass/Stained BumpDistort）

- 一般用于渲染建筑或者交通工具中的玻璃材质

> 属性

- Distortion：玻璃的投射畸变，值越大，透过玻璃看到物体的扭曲现象越严重
- Tint Color：玻璃的颜色
- NormalMap：玻璃的法向量

##### 内建移动平台着色器（Mobile）

> 以下着色器计算开销从低到高，显示效果从差到好

- Unlit：忽略光照和阴影的着色器
- VertexLit：顶点光照着色器
- Diffuse：漫反射效果
- Bumped Diffuse：带法向贴图的漫反射着色器
- Bumped Specular：带法向贴图和镜面反射效果的漫反射着色器