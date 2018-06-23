### Survival Shooter

*Unity官方示例教程*

#### 简介

这是Unity官方提供的项目，[链接](https://unity3d.com/cn/learn/tutorials/s/survival-shooter-tutorial)

#### 技术栈

- UI
  - Canvas：显示游戏基本UI（血量、分数）
  - Mobile Control Canvas：移动端控制UI（采用CrossPlatformInput提供的预制件）
- Camera
  - Following：摄像机始终跟随人物，并保持同一个俯视角度和距离
- Lighting
  - Directional Light：用于场景的方向光
  - Lighting Probe Group：为了避免实时光照带来的性能消耗，而采用的局部光照策略中的光照探头，降低计算量
- Particle System：用于子弹射击时的火光渲染
- Line Renderer：用于射击产生的射线的渲染
- Nav Mesh Agent：通过导航控件，设置参数，对场景中的静态障碍物进行标识，烘焙后可产生怪物的可导航网格，从而计算出到达目标物的最短可行走路径

### 展示效果

![](https://github.com/zhuwh9/UnityProject/blob/master/SurvivalShooter/Images/survival_shooter.png?raw=true)

### Pre-built Version

见`Build/Survival Shooter.apk`

#### TODO

- 部署到移动端
  - ~~添加Joystick以实现~~