using System;

public interface IAnimatable
{
    void Animate(float duration, Action onCompleted);
    void Stop();
}