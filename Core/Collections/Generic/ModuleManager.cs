using NiTiS.Core.Additions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.Core.Collections.Generic;

[Obsolete("Use HardTypedDictonary, same thing")]
public class ModuleManager<M> : HardTypedDictonary
{
    public ModuleManager()
    {
        throw new Exception("Use HardTypedDictonary");
    }
}