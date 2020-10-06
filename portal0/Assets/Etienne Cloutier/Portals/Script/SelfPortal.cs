using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfPortal : MonoBehaviour
{
    private PortalManager portalManager =null;

    public void SetPortalManager(PortalManager aPortalManager)
    {
        portalManager = aPortalManager;
    }
    public PortalManager getPortalManager()
    {
        return portalManager;
    }
}
