using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SLS
{
    public enum WhiskyType
    {
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        AlleSoorten,
        singleMalt,
        singleGrain,
        singleCask,
        Vintage,
        Blended,
        Grain
    }
}
