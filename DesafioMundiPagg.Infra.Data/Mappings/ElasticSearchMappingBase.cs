using ElasticsearchCRUD;
using ElasticsearchCRUD.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DesafioMundiPagg.Infra.Data.Mapping
{
    public class ElasticSearchMappingBase : ElasticsearchMapping
    {

        public override void MapEntityValues(EntityContextInfo entityInfo, ElasticsearchCrudJsonWriter elasticsearchCrudJsonWriter, bool beginMappingTree = false, bool createPropertyMappings = false)
        {
            var propertyInfo = entityInfo.Document.GetType().GetProperties();
            foreach (var prop in propertyInfo)
            {
                MapValue(prop.Name, prop.GetValue(entityInfo.Document), elasticsearchCrudJsonWriter.JsonWriter);
            }

        }

        public override string GetDocumentType(Type type)
        {
            //return type.Name.ToLower();
            return "teste";
        }

        public override string GetIndexForType(Type type)
        {
            return "skills";
        }

    }
}
