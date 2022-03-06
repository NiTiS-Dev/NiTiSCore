using System;

namespace NiTiS.Core.Collections.Generic;

[Obsolete("Use HardTypedDictonary, same thing")]
public class ModuleManager<M> : HardTypedDictonary
{
    public ModuleManager()
    {
        throw new Exception("Use HardTypedDictonary");
    }
}