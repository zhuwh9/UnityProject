## 《Survival Shooter Tutorial》

### Navigation视图

> 打开方法

Window菜单→Navigation

### Nav Mesh Agent（寻路导航组件）

> 添加方法

Add Component→Navigation→Nav Mesh Agent

#### Bake

> 通过设置Navigation中关于如何跨越/躲避障碍物的设定，怪物会以最有效的方式躲避障碍物寻找目标

Bake其实就是渲染出实际可寻路的Mesh区域，并在Scene视图中可视化出来（以检查是否符合预期）

### 关闭scene视图选中边框

> 也就是一些黄色的边缘线

Scene视图→Gizmos→取消勾选Selection Outline

### 显示Scene视图的Frame

在Scene视图中按F键，可以看到Canvas

### Canvas

- Render Mode
  - Screen Space - Overlay：Unity自动设置好了UICamera，且其Depth值大于100（即永远显示在最前面）
  - Screen Space - Camera：需要一个Camera，将其投射获得的界面当作UI界面，一般情况下UI界面是一个二维平面，所以把相机的投影设置为Orthographic，Culling Mask设置为UI（只显示UI层相关的信息），并设置相机的Z值，保证Canvas在相机之前绘制
  - World Space：将UI对象当作三维对象看待

## 在脚本中获取另外一个脚本作为对象

- 将`A脚本`赋给`对象O`
- 将`对象O`作为参数传递给`B脚本`
- `B脚本`可以通过`GetComponent`的方式获取`A脚本`（作为一个实例），并可以调用这个脚本的`public`方法

## 禁用游戏对象

- 调用GameObject类的SetActive

## 禁用游戏对象组件

- 获取组件后，将组件的enabled属性设为false

## 动画状态机适用范围

状态机实际上并非只能用于导入的FBX动画，而是所有Unity中的GameObject上的public组件上的public属性都可以，而动画只是其中一种public属性

### 创建动画

> 打开animation视图

Window菜单→Animation

> 创建动画

Animation视图→Create Animation