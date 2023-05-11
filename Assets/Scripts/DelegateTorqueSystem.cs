using UnityEngine;

public class DelegateTorqueSystem : ITorqueSystem
{
    TorqueSystemDelegate torqueSystemDelegate;

    public DelegateTorqueSystem(TorqueSystemDelegate torqueSystemDelegate)
    {
        this.torqueSystemDelegate = torqueSystemDelegate;
    }

    public void Torque(Vector3 eulerAngles)
    {
        torqueSystemDelegate(eulerAngles);
    }
}
public delegate void TorqueSystemDelegate(Vector3 eulerAngles);