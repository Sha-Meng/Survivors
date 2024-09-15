using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActor
{
    Vector3 Position { get; }
    Quaternion Rotation { get; }
    // Vector3 Velocity { get; }
    float Speed { get; }
    ActorType ActorType { get; }
    void Init(ActorType actorType);

    void Recycle();

    void SetLocalPosition(Vector3 localPosition);

    void SetRotation(Quaternion rotation);

    void SetVelocity(Vector3 velocity);

    // 加减速
    void AddSpeed(float deltaVel);

    void Rotate(float deltaAngle);

    void Update(float deltaTime);
}
