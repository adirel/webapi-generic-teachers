using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebAPIPrj.Models
{
    
    [Serializable]
    public class GenericMorim
    {
        private MORIM morim { get; set; }
        private List<MISROT> misrot { get; set; }

        public GenericMorim(MORIM morim, List<MISROT> misrot)
        {
            this.morim = new MORIM();
            this.morim = morim;
            this.misrot = new List<MISROT>();
            this.misrot = misrot;
        }

        public GenericMorim()
        {
        }

        public override bool Equals(object obj)
        {
            var morim = obj as GenericMorim;
            return morim != null &&
                   EqualityComparer<MORIM>.Default.Equals(this.morim, morim.morim) &&
                   EqualityComparer<List<MISROT>>.Default.Equals(misrot, morim.misrot);
        }

        public override int GetHashCode()
        {
            var hashCode = 959055920;
            hashCode = hashCode * -1521134295 + EqualityComparer<MORIM>.Default.GetHashCode(morim);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<MISROT>>.Default.GetHashCode(misrot);
            return hashCode;
        }
    }
}