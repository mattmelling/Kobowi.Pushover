using Kobowi.Pushover.Models;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Kobowi.Pushover {
    public class Migrations : DataMigrationImpl {
        public int Create() {
            SchemaBuilder.CreateTable(typeof (PushoverSettingsPartRecord).Name,
                                      table => table.ContentPartRecord()
                                                   .Column<string>("ApiKey"));
            ContentDefinitionManager.AlterPartDefinition(typeof (PushoverSettingsPart).Name, part => part.Attachable());
            return 1;
        }

        public int UpdateFrom1() {
            SchemaBuilder.CreateTable(typeof (PushoverUserPartRecord).Name,
                                      table => table.ContentPartRecord()
                                                   .Column<string>("UserKey"));
            ContentDefinitionManager.AlterPartDefinition(typeof (PushoverUserPart).Name,
                                                         part => part.Attachable());
            return 2;
        }
    }
}