using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.myXFToast
{
    [Preserve(AllMembers = true)]
    public interface ImyXFToast
    {
        void Show(string message, bool IsLong = false, string bgColorHex = "#000000");
    }
}
