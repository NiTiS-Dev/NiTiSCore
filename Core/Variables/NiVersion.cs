using System.Diagnostics;

namespace NiTiS.Core.Variables
{
    [DebuggerDisplay("NiVersion {versionDisplay} ({versionCode})")]
    public struct NiVersion
    {
        public int versionCode;
        public string versionDisplay;

        public NiVersion(int versionCode, string versionDisplay = null)
        {
            this.versionCode = versionCode;
            if (versionDisplay != null) { this.versionDisplay = versionDisplay; }
            else
            {
                this.versionDisplay = versionCode.ToString();
            }
        }
        public override string ToString()
        {
            return versionDisplay;
        }
        public override int GetHashCode()
        {
            return $"{versionDisplay}\\{versionCode}".GetHashCode();
        }
    }
}
