# 《Tank！！》

### 实现缓慢改变Vector的方法

使用Vector3.SmoothDamp方法，令一个Vector3缓慢地变到另一个Vector3

```csharp
transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
```

