using System;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000163 RID: 355
	public static class LogicResources
	{
		// Token: 0x060014E5 RID: 5349 RVA: 0x000520CC File Offset: 0x000502CC
		public static LogicArrayList<LogicDataTableResource> CreateDataTableResourcesArray()
		{
			LogicArrayList<LogicDataTableResource> logicArrayList = new LogicArrayList<LogicDataTableResource>(44);
			logicArrayList.Add(new LogicDataTableResource("logic/buildings.csv", LogicDataType.BUILDING, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/locales.csv", LogicDataType.LOCALE, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/resources.csv", LogicDataType.RESOURCE, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/characters.csv", LogicDataType.CHARACTER, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/projectiles.csv", LogicDataType.PROJECTILE, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/building_classes.csv", LogicDataType.BUILDING_CLASS, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/obstacles.csv", LogicDataType.OBSTACLE, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/effects.csv", LogicDataType.EFFECT, 0));
			logicArrayList.Add(new LogicDataTableResource("csv/particle_emitters.csv", LogicDataType.PARTICLE_EMITTER, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/experience_levels.csv", LogicDataType.EXPERIENCE_LEVEL, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/traps.csv", LogicDataType.TRAP, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/alliance_badges.csv", LogicDataType.ALLIANCE_BADGE, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/globals.csv", LogicDataType.GLOBAL, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/townhall_levels.csv", LogicDataType.TOWNHALL_LEVEL, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/alliance_portal.csv", LogicDataType.ALLIANCE_PORTAL, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/npcs.csv", LogicDataType.NPC, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/decos.csv", LogicDataType.DECO, 0));
			logicArrayList.Add(new LogicDataTableResource("csv/resource_packs.csv", LogicDataType.RESOURCE_PACK, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/shields.csv", LogicDataType.SHIELD, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/missions.csv", LogicDataType.MISSION, 0));
			logicArrayList.Add(new LogicDataTableResource("csv/billing_packages.csv", LogicDataType.BILLING_PACKAGE, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/achievements.csv", LogicDataType.ACHIEVEMENT, 0));
			logicArrayList.Add(new LogicDataTableResource("csv/credits.csv", LogicDataType.CREDIT, 0));
			logicArrayList.Add(new LogicDataTableResource("csv/faq.csv", LogicDataType.FAQ, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/spells.csv", LogicDataType.SPELL, 0));
			logicArrayList.Add(new LogicDataTableResource("csv/hints.csv", LogicDataType.HINT, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/heroes.csv", LogicDataType.HERO, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/leagues.csv", LogicDataType.LEAGUE, 0));
			logicArrayList.Add(new LogicDataTableResource("csv/news.csv", LogicDataType.NEWS, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/war.csv", LogicDataType.WAR, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/regions.csv", LogicDataType.REGION, 0));
			logicArrayList.Add(new LogicDataTableResource("csv/client_globals.csv", LogicDataType.CLIENT_GLOBAL, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/alliance_badge_layers.csv", LogicDataType.ALLIANCE_BADGE_LAYER, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/alliance_levels.csv", LogicDataType.ALLIANCE_LEVEL, 0));
			logicArrayList.Add(new LogicDataTableResource("csv/helpshift.csv", LogicDataType.HELPSHIFT, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/variables.csv", LogicDataType.VARIABLE, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/gem_bundles.csv", LogicDataType.GEM_BUNDLE, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/village_objects.csv", LogicDataType.VILLAGE_OBJECT, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/calendar_event_functions.csv", LogicDataType.CALENDAR_EVENT_FUNCTION, 0));
			logicArrayList.Add(new LogicDataTableResource("csv/boombox.csv", LogicDataType.BOOMBOX, 0));
			logicArrayList.Add(new LogicDataTableResource("csv/event_entries.csv", LogicDataType.EVENT_ENTRY, 0));
			logicArrayList.Add(new LogicDataTableResource("csv/deeplinks.csv", LogicDataType.DEEPLINK, 0));
			logicArrayList.Add(new LogicDataTableResource("logic/leagues2.csv", LogicDataType.LEAGUE_VILLAGE2, 0));
			return logicArrayList;
		}

		// Token: 0x060014E6 RID: 5350 RVA: 0x0005240C File Offset: 0x0005060C
		public static void Load(LogicArrayList<LogicDataTableResource> resources, int idx, CSVNode node)
		{
			LogicDataTableResource logicDataTableResource = resources[idx];
			int tableType = logicDataTableResource.GetTableType();
			if (tableType != 0)
			{
				if (tableType != 3)
				{
					Debugger.Error("LogicResources::Invalid resource type");
				}
			}
			else
			{
				LogicDataTables.InitDataTable(node, logicDataTableResource.GetTableIndex());
			}
			if (resources.Size() - 1 == idx)
			{
				LogicDataTables.CreateReferences();
			}
		}
	}
}
