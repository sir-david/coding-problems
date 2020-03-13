using System;
using System.Collections.Generic;
using System.Text;

namespace PollyPhrases
{
    public class MatchWordValidator
    {
        private string normalizeString(string inputString) => inputString.Normalize(NormalizationForm.FormD).Replace("/[\u0300-\u036f] / g", "");
        private byte[] getASCIIArray(string inputString) => Encoding.ASCII.GetBytes(inputString);
        ///
        ///	Parametro 1: * source: Texto en el que se va a buscar
        ///	Parametro 2: * textToFind: Frase a buscar 
        ///	Parametro 3: * caseSensitiveEnabled: Por defecto esta deshabilitado. Validar mayusculas y minusculas
        ///	Parametro 4: * normalizeStringEnabled: Por defecto esta habilitado. Quitar tildes basados en NFD (Forma de Normalización de Composición Canónica.)
        ///
        public string[] matchWord(string source, string textToFind, bool caseSensitiveEnabled = false, bool normalizeStringEnabled = true)
        {
            string sourceText = caseSensitiveEnabled ? source : source.ToLower();
            string textToSearch = caseSensitiveEnabled ? textToFind : textToFind.ToLower();
            sourceText = normalizeStringEnabled ? normalizeString(sourceText) : source;
            textToSearch = normalizeStringEnabled ? normalizeString(textToSearch) : textToFind;
            var vectorForSearch = getASCIIArray(sourceText);
            var vectorToFind = getASCIIArray(textToSearch);
            var res = new List<string>();

            for (var i = 0; i < vectorForSearch.Length; i++)
            {
                if (vectorForSearch[i] == vectorToFind[0])
                {
                    var suspectedInitialPoint = i;
                    bool wasFullMatch = true;
                    for (var j = 1; j < vectorToFind.Length; j++)
                    {
                        i++;
                        if (vectorToFind[j] != vectorForSearch[i] || i >= vectorForSearch.Length)
                        {
                            wasFullMatch = false;
                            break;
                        }
                    }
                    if (wasFullMatch)
                        res.Add((suspectedInitialPoint + 1).ToString());
                    else
                        i--;
                }

            }
            if (res.Count == 0) res.Add("<no matches>");
            return res.ToArray();
        }
    }
}
