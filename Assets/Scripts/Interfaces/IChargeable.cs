using System;

public interface IChargeable {
    void Cancel();
    void Charge(Action onCompleted);
    bool IsReady();
    float GetDuration();
}