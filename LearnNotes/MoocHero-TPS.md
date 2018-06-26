## Project 《Mooc Hero》简易版

### 地形系统

> 介绍

Unity拥有功能强大的地形编辑器，支持以笔刷绘制的方式，实时绘制多种地形，还提供地表元素绘制工具，制作树木、草坪、石头等地表元素

> 创建地形

Hierarchy视图→鼠标右击→Create→3D Object→Terrain

> 属性

- Transform：
  - Position：设置地形系统在场景中的位置
  - Rotation&Scale：修改后对地形系统不产生影响
- Terrain：地形编辑工具

### 地形系统编辑工具

- Raise/Lower Terrain工具


- Paint Height工具
- Smooth Height工具
- Paint Texture工具
- Place Trees工具
- Paint Details工具
- Terrain Setting地形设置

#### Raise/Lower Terrain工具

> 用处

用于升高/降低地形

> 用法

升高是左键，降低是Shift键搭配左键

> 属性

- Brushes（笔刷）：绘制地形高度的笔刷样式
- Brush Size（笔刷尺寸）：用于确定笔刷的大小，取值范围为1~100
- Opacity（绘制强度）：用于确定每次点击后地形升高/降低的强度，范围为0~100

#### Paint Height（喷涂高度）

> 用处

用于将地形绘制到指定高度

> 用法

按住鼠标左键进行拖动，可以改变地形高度，直到地形高度达到指定值

> 属性

- Brushes（笔刷）：绘制地形高度的笔刷样式
- Brush Size（笔刷尺寸）：用于确定笔刷的大小，取值范围为1~100
- Opacity（绘制强度）：用于确定每次点击后地形升高/降低的强度，范围为0~100
- **Height（设定高度）：指定绘制的高度。**
- **Flatter按钮：将整个地形系统绘制至设定高度。**

#### Smooth Height（平滑高度）

> 用处

用于平滑地形高度

> 用法

在地形上拖动鼠标左键，即可提高地形的平滑度

> 属性

- Brushes（笔刷）：绘制地形高度的笔刷样式
- Brush Size（笔刷尺寸）：用于确定笔刷的大小，取值范围为1~100
- Opacity（绘制强度）：用于确定每次点击后地形升高/降低的强度，范围为0~100

#### Paint Texture（绘制纹理）

> 用处

用于绘制地形系统的地表纹理

> 用法

Edit Textures...

> 属性

- Brushes（笔刷）：绘制地形高度的笔刷样式
- Brush Size（笔刷尺寸）：用于确定笔刷的大小，取值范围为1~100
- Opacity（绘制强度）：用于确定每次点击后地形升高/降低的强度，范围为0~100
- **Target Strength（目标强度）：纹理绘制的最大影响程度。数字0表示纹理绘制完全没有影响。数字1表示纹理绘制将完全覆盖之前的图像**。第一张添加的纹理将应用到整个地形中，第二张添加的纹理将以笔刷的方式进行地形纹理绘制。

#### Place Trees（种植树）

> 用处

用于在地形上添加树模型

> 用法

- 树的添加/编辑/删除：Edit Trees→Add Tree/Edit Tree/Remove Tree
- 随机种植树木：Mass Place Trees→Number Of Trees（表示随机种植树木的个数）/Keep Existing Trees（表示是否保留以种植的树 ）
- 种植：点击Place按钮

> 属性

- Tree Density：树绘制的密度
- Tree Height：绘制的树的高度，可选择随机范围（勾选Random）
- Lock Width to Height：确定树的宽高比是否一致
- Tree Width：表示绘制的树宽度 ，可选择随机范围（勾选Random）
- Random Tree Rotation：确定树的朝向是否随机

#### Paint Details（绘制细节）

> 用处

用于在地形上添加草等其它细节元素

> 用法

- 开始细节的编辑：点击Edit Details→Add Grass Texture（用于草纹理的设置）/Add Detail Mesh（用于细节网格的设置） 

#### Terrain Settings（地形设置）

> 用处

用于设置地形系统的相关参数

> 属性

- Base Terrain：表示地形系统的基本参数设置
  - Draw：是否呈现地形系统
  - Pixel Error：像素容差，表示显示地形网格时允许的像素误差
  - Base Map Dist：用于设定高分辨率地形贴图的显示范围（为了提高效率，与摄像机距离超过该值的纹理，将以较低的分辨率显示）
  - Cast Shadows：地形是否投射阴影
- Tree & Detail Objects：表示树和细节的相关参数的设置
  - Draw：是否呈现树和细节
  - Detail Distance：设定超过摄像机多少距离的细节将停止渲染
  - Tree Distance：表示树的显示距离，与摄像机距离超过该值的树将停止渲染
- Resolution：表示地形系统的分辨率设置
  - Terrain Width：表示地形系统的宽度
  - Terrain Length：表示地形系统的长度
  - Terrain Height：表示地形系统的高度

### Mecanim动画系统

> 介绍

Mecanim是Unity一个丰富且精密的动画系统，提供了：

- 为人形角色提供的简易工作流和动画创建能力
- Retargeting（动画重定向）功能，即把动画从一个角色模型应用到另一个角色模型中
- 针对Animation Clips（动画片段）的简单工作流
- 一个用于管理动画间复杂交互动作的可视化编程工具
- 通过不同逻辑控制不同身体部分运动的能力

#### Mecanim 工作流

1. 资源的准备与导入
   - 3Dmax
   - Maya
2. 角色的建立
   - 人形角色
   - 一般角色
3. 角色的运动（动画控制器）

#### 导入模型与动画资源

> 方法

Project视图→鼠标右击→Import Package→Characters

> 模型参数

- Model：表示模型的网格 材质等模型渲染相关的设置
- Rig：表示模型的骨骼设置
- Animations：表示模型片段动画的设置

##### 向场景中添加人物模型

将Project视图中的模型对象添加到Hierarchy视图中，即可添加响应的模型对象

#### Animation Clip（动画片段）

> 介绍

Animation Clip（动画片段）是Unity中最小的动画构造模块，用于表示一段独立的动画效果，例如行走、奔跑、跳跃。

##### 分割Animation Clip

> 步骤

1. 在Inspector视图中的Clips列表下选择需要分割的动画片段
2. 使用动画预览确认动画片段的分割点（帧数）
3. 设置动画片段的起始与末尾帧，并修改动画片段名称
4. 新建动画片段（点击+号），重复上述步骤完成动画分割

##### Animation Clip首尾一致检查

- 绿色：首尾状态几乎一致
- 黄色：首尾状态存在些许差异
- 红色：首尾状态存在明显差异

> 条目

- 第一个条目（Loop Time）表示动画片段首尾姿势的一致检查（首帧左脚着地，尾帧左脚着地，循环播放时才连贯）
- 第二个条目（Root Transform Rotation）表示动画片段首尾Rotation属性的一致检查（直线跑时一致，左转跑时不一致）
- 第三个条目（Root Transform Position Y）表示动画片段首尾Position属性Y轴分量的一致检查（对于行走奔跑动画片段，动画片段的Position属性Y轴一致，对于跳跃动画而言不一致）
- 第四个条目（Root Transform Position XZ）表示动画片段首尾Position属性XZ轴分量的一致检查（对于行走奔跑动画片段，动画片段的Position的XZ属性不一致，对于原地向上起跳的动画片段，该条目首尾一致）

#### Avatar（角色替身）

- 人形骨架是在游戏中普遍采用的一种骨架结构，Unity为其提供了一个特别的工作流和一整套扩展的工具集。
- 由于人形骨架结构的相似性，开发者可以将人形动画效果从一个人形骨架映射到另一个人形骨架，实现动画重定向功能。
- 创建动画的一个基本步骤就是建立一个从Mecanim系统的简化人形骨架结构到用户实际提供的骨架结构的映射，这种映射关系被称为Avatar。

##### 动画类型

- Humanoid：用于人形动画
- Generic
- Legacy
- None

> 匹配

- 如果匹配成功，会在configure按钮旁边有一个正确符号（√），且会在Project视图自动生成Avatar文件
- 如果匹配失败，会有一个错误符号（×），此时需要点击Configure进行手动匹配

#### 动画重定向

利用Avatar可以实现人形动画的重定向

### 动画状态机

#### Animator组件

> 用途

用于控制游戏对象的动画

> 用法

选择游戏对象→Component菜单→Miscellaneous（杂项）→Animator

> 属性

- Controller：动画控制器
- Avatar：角色替身
- Apply Root Motion：角色的位移或旋转是否由动画片段控制。勾选表示由动画片段控制，不勾选表示由脚本控制。

#### Animator Controller（动画控制器）

> 用途

用于管理游戏对象的一系列动画片段 

> 功能

- Animation State Machine（动画状态机）：用于管理动画的播放和动画之间的过渡
- Animation Layers & Avatar Mask（动画层与身体遮罩）：用于管理不同身体部位的动画。

> 创建方法

Project视图→Assets→鼠标右击→Create→Animator Controller

#### Animation State Machine简介

> 用途

控制角色动画片段的播放与切换。

> 概念

- 状态：每个状态都对应着一个动画
- 状态过渡：改变角色所处的状态
- 参数：状态过渡时与限制条件相关的参数。

> 打开方法

菜单栏→Window→Animator



##### 创建 & 设置新状态

> 方法

在Layer视图中选中要编辑的Layer→鼠标右击→Create State→Empty

> 属性

- 状态的名称
- Motion：状态播放的动画片段
- Speed：动画片段的播放速度

##### 参数添加（用于状态过渡）

> 方法

Parameters视图→＋号按钮→选择类型→修改变量名



##### 动画状态的过渡

> 方法

鼠标右击动画过渡起始状态→Make Transition→鼠标左击动画过渡结束状态

> 动画状态过渡的常用参数

- Has Exit Time：动画状态过渡是否有退出时间。若勾选该属性，动画状态过渡将延迟执行，延迟的时间在Exit Time中设置
- 动画状态的过渡曲线
- 状态过渡条件设置

##### 脚本控制动画参数

> 脚本示例

```csharp
public class AnimationScript : MonoBehavior {
    private Animator myAnimator;
    void Start () {
        myAnimator = this.GetComponent<Animator> ();
    }
    void Update () {
        if (Input.GetKey (KeyCode.W)) {
            myAnimator.SetBool ("isStop", false);// 控制角色是否运动
        }
        if (Input.GetKey (KeyCode.S)) {
            myAnimator.SetBool ("isStop", true);
        }
        if (Input.GetKey (KeyCode.Z)) {
            myAnimator.SetBool ("Speed", 20.0f);// 控制角色速度
        }
        if (Input.GetKey (KeyCode.X)) {
            myAnimator.SetBool ("Speed", 0.0f);
        }
    }
}
```

> 将脚本应用于角色对象中

1. 不勾选Apply Root Motion
2. 添加脚本组件（直接将脚本拖至角色对象上）

#### Animation Layer（动画层）

> 用途

用于合成身体不同部位的动画。Unity使用Animation Layer（动画层）来管理身体不同部分的动画。

> 参数

- Weight：表示该动画层对角色整体动画的影响程度，取值范围为0~1，动画最底层的位置值固定为1
- Mask：动画层的身体遮罩设置，表示该动画层影响人形角色的身体关节

#### Avatar Mask（身体遮罩）

> 用途

可以使得开发者选择性地启用或禁用人形角色的相关关节，以控制动画片段对人形角色的影响。

- 启用的关节受动画的控制而产生动作
- 禁用的关节不受动画的控制

> 创建步骤

Project视图→鼠标右键→Create→Avatar Mask

#### 合成动画

> 步骤

1. 选中角色预制件
2. 在Project视图中创建动画控制器
3. 在Inspector视图中应用动画控制器
4. 在Project视图中创建两个Avatar Mask，分别命名为Lower Body与Upper Body
5. 在Inspector视图中设置Upper Body与Lower Body，分别只启用上半身关节与下半身关节
6. 在Animator视图中创建新的动画层，并重命名为Upper Layer与Lower Layer
7. 设置Upper Layer的初始动画状态：HumanoidFall，人形角色坠落，并设置Mask为Upper Body
8. 设置Lower Layer的初始动画状态：HumanoidRun，人性角色奔跑，并设置Weight为1，Mask为Lower Body。


### 玩家运动实现

> 前后移动

- 按键获取：Input类的GetAxisRaw("Vertical")获取垂直输入
- 移动实现：Transform的Translate函数

> 左右转动

- 按键获取：Input类的GetAxisRaw("Horizontal")获取水平输入
- 转动实现：Transform的Rotate函数

> 代码实现示例

```csharp
void Update () {
    float h = Input.GetAxisRaw("Horizontal");
    float v = Input.GetAxisRaw("Vertical");
    MoveAndRotate(h, v);
    isGrounded = Physics.Raycast(transform.position, -Vector3.up, groundedRaycastDistance);//如果距离很小，判断为在地面上，被赋值为true
    Jump(isGrounded);
}
void MoveAndRotate (float h, float v) {
    if (v > 0)
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    else if (v < 0)
        transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);//实现移动
    if (v != 0.0f)
        animator.SetBool("isMove", true);//控制动画
    else
        animator.SetBool("isMove", false);
    transform.Rotate(Vector3.up * h * rotateSpeed * Time.deltaTime);//实现转动
}
```

#### 玩家跳跃

> 逻辑

玩家跳跃→检测按下跳跃键/检测是否在地面→向上跳跃/播放跳跃动画

> 实现

- 检测按下跳跃键：Input类的GetKeyDown函数
- 检测是否在地面上：Physics类的RayCast函数（以玩家位置为起点向下发射一条射线，根据射线与地面的碰撞检测结果判断玩家是否在地面上）
- 向上跳跃：RigidBody类的AddForce函数
- 播放跳跃动画：Animator类的SetBool函数

> 函数

```csharp
void Jump (bool isGround) {
    if (Input.GetKey(KeyCode.Space) && isGround) {
        rigidbody.AddForce(Vector3.up * jumpVelocity, ForceMode.VelocityChange);
        animator.SetBool("isJump", true);
    }
    else if (isGround) {
        animator.SetBool("isJump", false);
    }
}
```

#### 玩家攻击实现

> 逻辑

按下J键/距上次攻击经过了一定时间→准星射击/射击动画/枪口射线/射击音效

> 实现

- 距上次攻击经过了一定时间：Time类的deltaTime属性累加计时
- 准星射击：Physics类的RayCast函数
- 射击动画：Animator类的SetBool函数
- 射击音效：AudioSource类的PlayClipAtPoint函数
- 枪口射线：线渲染器

> 具体代码实现

- 射击：

```csharp
void LateUpdate() {//确保射击时位置使用的是移动后的位置，否则会出现偏差
    if (Input.GetKeyDown(KeyCode.J) && timer > timeBetweenShooting) {
        timer = 0.0f;
        animator.SetBool("isShooting", true);
        Invoke("Shoot", 0.5f);//抬手动画为0.5秒，因此射击函数Shoot在0.5秒后执行
    } else {
        timer += Time.deltaTime;
        animator.SetBool("isShooting", false);
    }
}
void shoot()
{
    AudioSource.PlayClipAtPoint(shootingAudio, transform.position);	//在枪口位置播放射击音效
    ray.origin = Camera.main.transform.position;	//设置射线发射的原点：摄像机所在的位置
    ray.direction = Camera.main.transform.forward;	//设置射线发射的方向：摄像机的正方向
    gunLine.SetPosition(0, transform.position);		//设置线渲染器（开枪后的激光射线）第一个端点的位置：玩家枪械的枪口位置（本游戏对象）
    //发射射线，射线有效长度为shootingRange，若射线击中任何游戏对象，则返回true，否则返回false
    if (Physics.Raycast(ray, out hitInfo, shootingRange))
    {
        if (hitInfo.collider.gameObject.tag == "Enemy")	//当被击中的游戏对象标签为Enemy，表明射线射中敌人
        {
            //获取该名敌人的EnemyHealth脚本组件
            EnemyHealth enemyHealth = hitInfo.collider.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                //调用EnemyHealth脚本的TakeDamage()函数，对敌人造成shootingDamage的伤害
                enemyHealth.TakeDamage(shootingDamage);	
            }
            if(enemyHealth.health>0)	//若敌人受伤且未死亡，敌人将会因受到攻击而被击退
                hitInfo.collider.gameObject.transform.position += transform.forward * 2;
        }
        gunLine.SetPosition(1, hitInfo.point);	//当射线击中游戏对象时，将线渲染器（开枪后的激光射线）第二个端点设为射线击中游戏对象的点
    }
    //若射线未射中游戏对象，则将线渲染器（开枪后的激光射线）第二个端点设为射线射出后的极限位置
    else gunLine.SetPosition(1, ray.origin + ray.direction * shootingRange);
    gunLine.enabled = true;	//将线渲染器（开枪后的激光射线）启用，显示玩家开枪后的效果。
}
```



### 摄像机行为

> 如何实现跟随拍摄

将摄像机设为玩家的子对象，使得摄像机跟随玩家进行移动与旋转，且摄像机和玩家相对距离朝向不变。

### 水平/竖直方向默认输入行为

> 设置方法

菜单栏→Edit→Project Setting→Input

### 敌人运动实现

#### 敌人的追踪逻辑

> 主要在Update函数中实现逻辑的实现

- 敌人是否存活 && 敌人追踪目标是否设置 && 游戏是否处于游戏状态 && 敌人与目标距离是否大于追踪的最小值
- 如果上述条件满足，则敌人调整朝向面向追踪目标，并向追踪目标移动一定距离

> 代码实现

```csharp
void Update () {
    if (enemyHealth!=null && enemyHealth.health <= 0) return;	//当敌人死亡时，敌人无法追踪目标
    if (target == null) {					//当追踪目标未设置时，敌人无法追踪目标
        animator.SetBool ("isStop", true);	//设置动画参数，将布尔型参数isStop设为true：敌人未追踪目标，播放停驻动画
        return;
    }
    dist = Vector3.Distance (transform.position, target.transform.position);	//计算敌人与追踪目标之间的距离
    //当游戏状态为游戏进行中（Playing）时
    if (GameManager.gm==null || GameManager.gm.gameState == GameManager.GameState.Playing) {			
        if (dist > minDist) {	//当敌人与目标的距离大于追踪距离时
            transform.LookAt (target.transform);				//敌人面向追踪目标
            transform.eulerAngles=new Vector3(0.0f,transform.eulerAngles.y,0.0f);	//设置敌人的Rotation属性，确保敌人只在y轴旋转
            transform.position += 
                transform.forward * moveSpeed * Time.deltaTime;	//敌人以moveSpeed的速度向追踪目标靠近
        }
        animator.SetBool ("isStop", false);	//设置动画参数，将布尔型参数isStop设为false：敌人追踪目标，播放奔跑动画
    }
}
```

#### 敌人攻击实现

- 当玩家进入敌人攻击范围，敌人攻击玩家，玩家受到伤害
- 敌人攻击时抬手击打，脚本播放敌人攻击音效
- 敌人不会持续攻击，攻击之间有时间间隔

> 代码实现

- 检测是否在攻击范围：OnTriggerStay函数

### 生命值管理

#### 敌人生命值管理

- 敌人被玩家攻击时，减少生命值
- 敌人受伤时，出现流血效果，并发出受伤的声音
- 若敌人死亡，敌人会倒地并消失，同时玩家得分增加。

> 逻辑设计

生命值降低/敌人受伤音效→敌人倒地/玩家得分/敌人消失

> 代码实现

- 生命值降低：内置字段health值降低
- 玩家得分：GameManager类的AddScore函数实现主角得分
- 敌人消失：GameObject类的Destroy函数

#### 玩家生命值管理

```csharp
public int health = 10;
public bool isAlive = true;
void Update () {
    if (health <= 0)
        isAlive = false;
}
public void TakeDamage (int damage) {
    health -= damage;
    if (health < 0)
        health = 0;
}
```

### 游戏管理器

- 管理游戏状态（游戏进行中/胜利/失败）
- 管理玩家积分
- 管理场景中对象之间的交互
- 显示游戏状态（玩家生命值与玩家得分）

![1526053127682](G:\GameDevelopment\5.png)

