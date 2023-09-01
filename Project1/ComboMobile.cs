
using System;
using System.Collections.Generic;

namespace LibMobile
{
    [Serializable]
    public class ComboMobile
    {
        public string Codice { get; set; }
        public string Valore { get; set; }
        public int Ordine { get; set; } = -100;

        public Dictionary<string, object> AltriDati { get; set; }

        public virtual T Clone<T>()
        {
            return (T)MemberwiseClone();
        }

        //[Filtro]
        public string CodiceValore
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Codice))
                {
                    return "";
                }
                else
                {
                    return Codice + " - " + Valore;
                }
            }
        }

        public ComboMobile Find(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Controlla se l'oggetto Combo è vuoto andando a controllare che Codice non sia null.
        /// Torna TRUE se il valore è pieno.
        /// </summary>
        /// <param name="Valore"></param>
        /// <returns></returns>
        public static bool CheckComboValue(ComboMobile Valore)
        {
            return Valore != null && Valore.Codice != null;
        }
    }
}