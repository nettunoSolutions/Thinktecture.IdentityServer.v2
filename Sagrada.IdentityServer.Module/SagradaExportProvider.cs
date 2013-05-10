using Sagrada.IdentityServer.Module.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagrada.IdentityServer.Module
{
    /// <summary>
    /// Provider per MEF
    /// </summary>
    public class SagradaExportProvider : ExportProvider
    {
        private Dictionary<string, string> _mappings;

        public SagradaExportProvider()
        {
            _mappings = new Dictionary<string, string>
            {
                { typeof(ISagradaIdentityService).FullName, typeof(SagradaIdentityService).FullName }
                
            };

        }

        protected override IEnumerable<System.ComponentModel.Composition.Primitives.Export> GetExportsCore(System.ComponentModel.Composition.Primitives.ImportDefinition definition, AtomicComposition atomicComposition)
        {
            var exports = new List<Export>();

            string implementingType;
            if (_mappings.TryGetValue(definition.ContractName, out implementingType))
            {
                var t = Type.GetType(implementingType);
                if (t == null)
                {
                    throw new InvalidOperationException("Type not found for interface: " + definition.ContractName);
                }

                var instance = t.GetConstructor(Type.EmptyTypes).Invoke(null);
                var exportDefintion = new ExportDefinition(definition.ContractName, new Dictionary<string, object>());
                var toAdd = new Export(exportDefintion, () => instance);

                exports.Add(toAdd);
            }

            return exports;
        }
    }
}
