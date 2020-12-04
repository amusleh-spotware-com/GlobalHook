using System;
using System.Linq;
using System.Windows.Forms;

namespace Gma.UserActivityMonitor
{
    public static class KeyTypeToKeys
    {
        public static Keys GetKeys(this KeyType keyType)
        {
            return Enum.GetValues(typeof(Keys)).Cast<Keys>().FirstOrDefault(iKeys =>
                iKeys.ToString().Equals(keyType.ToString(),
                    StringComparison.InvariantCultureIgnoreCase));
        }
    }
}