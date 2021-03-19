using System;
using System.Linq;
using HotChocolate.Language;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.GraphQl.Helpers
{
    public static class ParametersParser
    {
        private const RealmType DefaultRealm = RealmType.Ru;
        private const RequestLanguage DefaultRequestLanguage = RequestLanguage.En;

        public static RealmAndLanguage ParseOperation(this OperationDefinitionNode operationDefinition)
        {
            var realm = DefaultRealm;
            var language = DefaultRequestLanguage;
            var selections = operationDefinition?.SelectionSet.Selections.ToArray();
            if (selections != null && selections.Length == 1)
            {
                var node = selections[0] as FieldNode;
                if (node?.Arguments != null)
                {
                    foreach (var argument in node.Arguments.Where(a => a != null))
                    {
                        switch (argument.Name.Value)
                        {
                            case "realmType" when argument?.Value?.Value != null:
                                realm = (RealmType)Enum.Parse(typeof(RealmType), argument.Value.Value.ToString() ?? "Ru", true);
                                break;
                            case "requestLanguage" when argument?.Value?.Value != null:
                                language = (RequestLanguage)Enum.Parse(typeof(RequestLanguage), argument.Value.Value.ToString() ?? "En", true);
                                break;
                        }
                    }
                }
            }

            return new (realm, language);
        }

    }
}