﻿using FluentMigrator;
//using FluentMigrator.Expressions;
using NzbDrone.Core.Datastore.Migration.Framework;
using NzbDrone.Core.Tv;

namespace NzbDrone.Core.Datastore.Migration
{
    [Migration(133)]
    public class add_minimumavailability : NzbDroneMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            if (!this.Schema.Schema("dbo").Table("NetImport").Column("MinimumAvailability").Exists())
            {
                Alter.Table("NetImport").AddColumn("MinimumAvailability").AsInt32().WithDefaultValue(MovieStatusType.PreDB);
            }
	        if (!this.Schema.Schema("dbo").Table("Movies").Column("MinimumAvailability").Exists())
	        {
		        Alter.Table("Movies").AddColumn("MinimumAvailability").AsInt32().WithDefaultValue(MovieStatusType.PreDB);
	        }
        }
    }
}
