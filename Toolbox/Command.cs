using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.Database
{
    /// <summary>
    /// Classe qui contient toutes les infos nécessaires a l'éxécution de la commande SQL
    /// </summary>
    public class Command
    {
        public Command(string commandText,bool isStoredProcedure = false)
        {
            CommandText = commandText;
            IsStoredProcedure = isStoredProcedure;
            Parameters = new Dictionary<string, object>();
        }
        public string CommandText { get; }
        public Dictionary<string,object> Parameters { private set; get; }
        public bool IsStoredProcedure { get; }

        public void AddParameter(string parameterName, object value)
        {
            Parameters.Add(parameterName,value);
        }

        public void AddParameters(Dictionary<string,object> parameters)
        {
            foreach (KeyValuePair<string, object> keyValuePair in parameters)
                AddParameter(keyValuePair.Key, keyValuePair.Value);
        }
    }
}
