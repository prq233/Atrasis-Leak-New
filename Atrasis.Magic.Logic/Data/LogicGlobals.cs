using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000153 RID: 339
	public class LogicGlobals : LogicDataTable
	{
		// Token: 0x060012EC RID: 4844 RVA: 0x0000C0DF File Offset: 0x0000A2DF
		public LogicGlobals(CSVTable table, LogicDataType index) : base(table, index)
		{
		}

		// Token: 0x060012ED RID: 4845 RVA: 0x0004ECB8 File Offset: 0x0004CEB8
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.int_26 = this.method_2("FREE_UNIT_HOUSING_CAP_PERCENTAGE");
			this.int_27 = this.method_2("FREE_HERO_HEALTH_CAP");
			this.int_0 = this.method_2("SPEED_UP_DIAMOND_COST_1_MIN");
			this.int_1 = this.method_2("SPEED_UP_DIAMOND_COST_1_HOUR");
			this.int_2 = this.method_2("SPEED_UP_DIAMOND_COST_24_HOURS");
			this.int_3 = this.method_2("SPEED_UP_DIAMOND_COST_1_WEEK");
			this.int_4 = this.method_2("VILLAGE2_SPEED_UP_DIAMOND_COST_1_MIN");
			this.int_5 = this.method_2("VILLAGE2_SPEED_UP_DIAMOND_COST_1_HOUR");
			this.int_6 = this.method_2("VILLAGE2_SPEED_UP_DIAMOND_COST_24_HOURS");
			this.int_7 = this.method_2("VILLAGE2_SPEED_UP_DIAMOND_COST_1_WEEK");
			this.int_8 = this.method_2("RESOURCE_DIAMOND_COST_100");
			this.int_9 = this.method_2("RESOURCE_DIAMOND_COST_1000");
			this.int_10 = this.method_2("RESOURCE_DIAMOND_COST_10000");
			this.int_11 = this.method_2("RESOURCE_DIAMOND_COST_100000");
			this.int_12 = this.method_2("RESOURCE_DIAMOND_COST_1000000");
			this.int_13 = this.method_2("RESOURCE_DIAMOND_COST_10000000");
			this.int_14 = this.method_2("VILLAGE2_RESOURCE_DIAMOND_COST_100");
			this.int_15 = this.method_2("VILLAGE2_RESOURCE_DIAMOND_COST_1000");
			this.int_16 = this.method_2("VILLAGE2_RESOURCE_DIAMOND_COST_10000");
			this.int_17 = this.method_2("VILLAGE2_RESOURCE_DIAMOND_COST_100000");
			this.int_18 = this.method_2("VILLAGE2_RESOURCE_DIAMOND_COST_1000000");
			this.int_19 = this.method_2("VILLAGE2_RESOURCE_DIAMOND_COST_10000000");
			this.int_20 = this.method_2("DARK_ELIXIR_DIAMOND_COST_1");
			this.int_21 = this.method_2("DARK_ELIXIR_DIAMOND_COST_10");
			this.int_22 = this.method_2("DARK_ELIXIR_DIAMOND_COST_100");
			this.int_23 = this.method_2("DARK_ELIXIR_DIAMOND_COST_1000");
			this.int_24 = this.method_2("DARK_ELIXIR_DIAMOND_COST_10000");
			this.int_25 = this.method_2("DARK_ELIXIR_DIAMOND_COST_100000");
			this.int_28 = this.method_2("STARTING_DIAMONDS");
			this.int_31 = this.method_2("STARTING_GOLD");
			this.int_29 = this.method_2("STARTING_ELIXIR");
			this.int_32 = this.method_2("STARTING_GOLD2");
			this.int_30 = this.method_2("STARTING_ELIXIR2");
			this.int_33 = this.method_2("LIVE_REPLAY_UPDATE_FREQUENCY_SECONDS");
			this.int_34 = this.method_2("CHALLENGE_BASE_SAVE_COOLDOWN");
			this.int_41 = this.method_2("ALLIANCE_CREATE_COST");
			this.int_42 = 60 * this.method_2("CLOCK_TOWER_BOOST_COOLDOWN_MINS");
			this.int_43 = this.method_2("CLAMP_LONG_TIME_STAMPS_TO_DAYS");
			this.int_44 = this.method_2("WORKER_COST_2ND");
			this.int_45 = this.method_2("WORKER_COST_3RD");
			this.int_46 = this.method_2("WORKER_COST_4TH");
			this.int_47 = this.method_2("WORKER_COST_5TH");
			this.int_48 = this.method_2("CHALLENGE_BASE_COOLDOWN_ENABLED_ON_TH");
			this.int_49 = this.method_2("OBSTACLE_RESPAWN_SECONDS");
			if (this.int_49 < 3600)
			{
				Debugger.Error("Globals.csv - OBSTACLE_RESPAWN_SECONDS is smaller than 3600");
			}
			this.int_51 = this.method_2("OBSTACLE_COUNT_MAX");
			this.int_52 = this.method_2("RESOURCE_PRODUCTION_LOOT_PERCENTAGE");
			this.int_53 = this.method_2("RESOURCE_PRODUCTION_LOOT_PERCENTAGE_DARK_ELIXIR");
			this.int_54 = this.method_2("VILLAGE2_DO_NOT_ALLOW_CLEAR_OBSTACLE_TH");
			this.int_55 = this.method_2("ATTACK_PREPARATION_LENGTH_VILLAGE2_SEC");
			this.int_56 = this.method_2("ATTACK_PREPARATION_LENGTH_SEC");
			this.int_57 = this.method_2("ATTACK_LENGTH_SEC");
			this.int_58 = this.method_2("VILLAGE2_START_UNIT_LEVEL");
			this.int_59 = 60 * this.method_2("RESOURCE_PRODUCTION_BOOST_MINS");
			this.int_60 = 60 * this.method_2("BARRACKS_BOOST_MINS");
			this.int_61 = 60 * this.method_2("SPELL_FACTORY_BOOST_MINS");
			this.int_62 = 60 * this.method_2("HERO_REST_BOOST_MINS");
			this.int_63 = this.method_2("TROOP_TRAINING_SPEED_UP_COST_TUTORIAL");
			this.int_64 = this.method_2("NEW_TRAINING_BOOST_BARRACKS_COST");
			this.int_65 = this.method_2("NEW_TRAINING_BOOST_LABORATORY_COST");
			this.int_66 = this.method_2("PERSONAL_BREAK_LIMIT_SECONDS");
			this.int_35 = this.method_2("ALLIANCE_TROOP_REQUEST_COOLDOWN");
			this.int_36 = this.method_2("ARRANGE_WAR_COOLDOWN");
			this.int_37 = this.method_2("CLAN_MAIL_COOLDOWN");
			this.int_38 = this.method_2("REPLAY_SHARE_COOLDOWN");
			this.int_39 = this.method_2("ELDER_KICK_COOLDOWN");
			this.int_40 = this.method_2("CHALLENGE_COOLDOWN");
			this.int_67 = this.method_2("ENABLE_PRESETS_TH_LEVEL") - 1;
			this.int_68 = this.method_2("MAX_ALLIANCE_FEEDBACK_MESSAGE_LENGTH");
			this.int_69 = this.method_2("MAX_ALLIANCE_MAIL_LENGTH");
			this.int_70 = this.method_2("MAX_MESSAGE_LENGTH");
			this.int_50 = this.method_2("TALLGRASS_RESPAWN_SECONDS");
			this.int_74 = this.method_2("ENABLE_NAME_CHANGE_TH_LEVEL") - 1;
			this.int_116 = this.method_2("VILLAGE2_FIRST_VICTORY_TROPHIES");
			this.int_117 = this.method_2("VILLAGE2_FIRST_VICTORY_GOLD");
			this.int_118 = this.method_2("VILLAGE2_FIRST_VICTORY_ELIXIR");
			this.int_119 = this.method_2("DUEL_LOOT_LIMIT_FREE_SPEEDUPS");
			this.int_71 = this.method_2("MAX_TROOP_DONATION_COUNT");
			this.int_72 = this.method_2("MAX_SPELL_DONATION_COUNT");
			this.int_73 = this.method_2("DARK_SPELL_DONATION_XP");
			this.int_75 = this.method_2("STAR_BONUS_COOLDOWN_MINUTES");
			this.int_77 = this.method_2("CLAN_CASTLE_RADIUS") << 9;
			this.int_78 = this.method_2("CASTLE_DEFENDER_SEARCH_RADIUS");
			this.int_76 = this.method_2("BUNKER_SEARCH_TIME");
			this.int_120 = this.method_2("NEWBIE_SHIELD_HOURS");
			this.int_79 = 60 * this.method_2("LOOT_CART_REENGAGEMENT_MINUTES_MIN");
			this.int_80 = 60 * this.method_2("LOOT_CART_REENGAGEMENT_MINUTES_MAX");
			this.int_81 = this.method_2("WAR_MAX_EXCLUDE_MEMBERS");
			this.int_132 = this.method_2("SHIELD_TRIGGER_PERCENTAGE_HOUSING_SPACE");
			this.int_133 = this.method_2("DEFAULT_DEFENSE_VILLAGE_GUARD");
			this.int_82 = this.method_2("MINER_TARGET_RAND_P");
			this.int_83 = this.method_2("MINER_SPEED_RAND_P");
			this.int_84 = this.method_2("MINER_HIDE_TIME");
			this.int_85 = this.method_2("MINER_HIDE_TIME_RANDOM");
			if (this.int_85 <= 0)
			{
				this.int_85 = 1;
			}
			this.int_86 = this.method_2("TOWN_HALL_LOOT_PERCENTAGE");
			this.int_87 = (this.method_2("CHAR_VS_CHAR_RANDOM_DIST_LIMIT") << 9) / 100;
			this.int_88 = this.method_2("CHAR_VS_CHAR_RADIUS_FOR_ATTACKER") << 9;
			this.int_135 = this.method_2("HIDDEN_BUILDING_APPEAR_DESTRUCTION_PERCENTAGE");
			this.int_136 = this.method_2("HERO_HEAL_MULTIPLIER");
			this.int_137 = this.method_2("HERO_RAGE_MULTIPLIER");
			this.int_138 = this.method_2("HERO_RAGE_SPEED_MULTIPLIER");
			this.int_134 = this.method_2("WALL_COST_BASE");
			if (this.int_134 > 1500)
			{
				Debugger.Warning("WALL_COST_BASE is too big");
				this.int_134 = 1500;
			}
			else if (this.int_134 < 100)
			{
				this.int_134 = 100;
			}
			if (this.int_76 < 100)
			{
				Debugger.Warning("m_bunkerSearchTime too small");
			}
			if (this.int_86 != -1 && this.int_86 > 100)
			{
				Debugger.Error("globals.csv: Invalid loot percentage!");
			}
			this.int_91 = this.method_2("CLOCK_TOWER_BOOST_MULTIPLIER");
			this.int_92 = this.method_2("RESOURCE_PRODUCTION_BOOST_MULTIPLIER");
			this.int_93 = this.method_2("SPELL_TRAINING_COST_MULTIPLIER");
			this.int_94 = this.method_2("SPELL_SPEED_UP_COST_MULTIPLIER");
			this.int_95 = this.method_2("HERO_HEALTH_SPEED_UP_COST_MULTIPLIER");
			this.int_96 = this.method_2("TROOP_REQUEST_SPEED_UP_COST_MULTIPLIER");
			this.int_97 = this.method_2("TROOP_TRAINING_COST_MULTIPLIER");
			this.int_98 = this.method_2("SPEEDUP_BOOST_COOLDOWN_COST_MULTIPLIER");
			this.int_110 = this.method_2("CLOCK_TOWER_SPEEDUP_MULTIPLIER");
			this.int_107 = this.method_2("BARRACKS_BOOST_MULTIPLIER");
			this.int_106 = this.method_2("BARRACKS_BOOST_MULTIPLIER_NEW");
			this.int_108 = this.method_2("SPELL_FACTORY_BOOST_MULTIPLIER_NEW");
			this.int_109 = this.method_2("SPELL_FACTORY_BOOST_MULTIPLIER");
			this.int_111 = this.method_2("HERO_REST_BOOST_MULTIPLIER");
			this.int_112 = this.method_2("BUILD_CANCEL_MULTIPLIER");
			this.int_114 = this.method_2("TRAIN_CANCEL_MULTIPLIER");
			this.int_113 = this.method_2("SPELL_CANCEL_MULTIPLIER");
			this.int_115 = this.method_2("HERO_UPGRADE_CANCEL_MULTIPLIER");
			this.int_99 = this.method_2("SPELL_HOUSING_COST_MULTIPLIER");
			this.int_100 = this.method_2("UNIT_HOUSING_COST_MULTIPLIER");
			this.int_101 = this.method_2("HERO_HOUSING_COST_MULTIPLIER");
			this.int_102 = this.method_2("UNIT_HOUSING_COST_MULTIPLIER_FOR_TOTAL");
			this.int_103 = this.method_2("SPELL_HOUSING_COST_MULTIPLIER_FOR_TOTAL");
			this.int_104 = this.method_2("HERO_HOUSING_COST_MULTIPLIER_FOR_TOTAL");
			this.int_105 = this.method_2("ALLIANCE_UNIT_HOUSING_COST_MULTIPLIER_FOR_TOTAL");
			this.int_121 = this.method_2("BOOKMARKS_MAX_ALLIANCES");
			this.int_122 = this.method_2("LAYOUT_SLOT_2_TH_LEVEL") - 1;
			this.int_123 = this.method_2("LAYOUT_SLOT_3_TH_LEVEL") - 1;
			this.int_124 = this.method_2("LAYOUT_SLOT_2_TH_LEVEL_VILLAGE2") - 1;
			this.int_125 = this.method_2("LAYOUT_SLOT_3_TH_LEVEL_VILLAGE2") - 1;
			this.int_126 = this.method_2("SCORE_MULTIPLIER_ON_ATTACK_LOSE");
			this.int_127 = this.method_2("ELO_OFFSET_DAMPENING_FACTOR");
			this.int_128 = this.method_2("ELO_OFFSET_DAMPENING_LIMIT");
			this.int_129 = this.method_2("ELO_OFFSET_DAMPENING_SCORE_LIMIT");
			this.int_130 = this.method_2("STAR_BONUS_STAR_COUNT");
			this.int_131 = this.method_2("LOOT_CART_ENABLED_FOR_TH");
			this.int_139 = this.method_2("WAR_LOOT_PERCENTAGE");
			this.int_140 = this.method_2("BLOCKED_ATTACK_POSITION_PENALTY");
			this.int_89 = this.method_2("TARGET_LIST_SIZE");
			if (this.int_89 <= 2)
			{
				Debugger.Error("TARGET_LIST_SIZE too small");
			}
			this.int_141 = this.method_2("WALL_BREAKER_SMART_CNT_LIMIT");
			this.int_142 = (this.method_2("WALL_BREAKER_SMART_RADIUS") << 9) / 100;
			this.int_143 = this.method_2("WALL_BREAKER_SMART_RETARGET_LIMIT");
			this.int_144 = this.method_2("SELECTED_WALL_TIME");
			this.int_146 = this.method_2("SKELETON_SPELL_STORAGE_MULTIPLIER");
			this.int_147 = (this.method_2("ALLIANCE_ALERT_RADIUS") << 9) / 100;
			this.int_145 = this.method_2("FORGET_TARGET_TIME");
			if (this.int_145 < 5000)
			{
				Debugger.Warning("FORGET_TARGET_TIME is too small");
				this.int_145 = 5000;
			}
			this.int_90 = this.method_2("CHAINED_PROJECTILE_BOUNCE_COUNT");
			this.int_148 = this.method_2("SHRINK_SPELL_DURATION_SECONDS");
			this.bool_10 = this.method_1("USE_NEW_PATH_FINDER");
			this.bool_3 = this.method_1("USE_TROOP_WALKS_OUT_FROM_TRAINING");
			this.bool_4 = this.method_1("USE_VILLAGE_OBJECTS");
			this.bool_5 = this.method_1("USE_VERSUS_BATTLE");
			this.bool_6 = this.method_1("MORE_ACCURATE_TIME");
			this.bool_2 = this.method_1("USE_NEW_TRAINING");
			this.bool_7 = this.method_1("DRAG_IN_TRAINING");
			this.bool_8 = this.method_1("DRAG_IN_TRAINING_FIX");
			this.bool_9 = this.method_1("DRAG_IN_TRAINING_FIX2");
			this.bool_12 = this.method_1("REVERT_BROKEN_WAR_LAYOUTS");
			this.bool_11 = this.method_1("LIVE_REPLAY_ENABLED");
			this.bool_13 = this.method_1("REMOVE_REVENGE_WHEN_BATTLE_IS_LOADED");
			this.bool_14 = this.method_1("COMPLETE_CONSTRUCTIONS_ONLY_HOME");
			this.bool_15 = this.method_1("USE_NEW_SPEEDUP_CALCULATION");
			this.bool_16 = this.method_1("CLAMP_BUILDING_TIMES");
			this.bool_17 = this.method_1("CLAMP_UPGRADE_TIMES");
			this.bool_18 = this.method_1("CLAMP_AVATAR_TIMERS_TO_MAX");
			this.bool_19 = this.method_1("STOP_BOOST_PAUSE_WHEN_BOOST_TIME_ZERO_ON_LOAD");
			this.bool_20 = this.method_1("FIX_CLAN_PORTAL_BATTLE_NOT_ENDING");
			this.bool_21 = this.method_1("FIX_MERGE_OLD_BARRACK_BOOST_PAUSING");
			this.bool_22 = this.method_1("SAVE_VILLAGE_OBJECTS");
			this.bool_24 = this.method_1("WORKER_FOR_ZERO_BUILD_TIME");
			this.bool_25 = this.method_1("ADJUST_END_SUBTICK_USE_CURRENT_TIME");
			this.bool_26 = this.method_1("COLLECT_ALL_RESOURCES_AT_ONCE");
			this.bool_27 = this.method_1("USE_SWAP_BUILDINGS");
			this.bool_28 = this.method_1("TREASURY_SIZE_BASED_ON_TH");
			this.bool_23 = this.method_1("START_IN_LAST_USED_VILLAGE");
			this.bool_29 = this.method_1("USE_TESLA_TRIGGER_CMD");
			this.bool_30 = this.method_1("USE_TRAP_TRIGGER_CMD");
			this.bool_31 = this.method_1("VALIDATE_TROOP_UPGRADE_LEVELS");
			this.bool_32 = this.method_1("ALLOW_CANCEL_BUILDING_CONSTRUCTION");
			this.bool_33 = this.method_1("V2_TRAINING_ONLY_USE_REGULAR_STORAGE");
			this.bool_34 = this.method_1("ENABLE_TROOP_DELETION");
			this.bool_35 = this.method_1("ENABLE_PRESETS");
			this.bool_39 = this.method_1("USE_TOWNHALL_LOOT_PENALTY_IN_WAR");
			this.bool_36 = this.method_1("ENABLE_NAME_CHANGE");
			this.bool_37 = this.method_1("ENABLE_QUICK_DONATE");
			this.bool_38 = this.method_1("ENABLE_QUICK_DONATE_WAR");
			this.bool_40 = this.method_1("ALLOW_CLANCASTLE_DEPLOY_ON_OBSTACLES");
			this.bool_41 = this.method_1("SKELETON_TRIGGER_TESLA");
			this.bool_42 = this.method_1("SKELETON_OPEN_CC");
			this.bool_43 = this.method_1("CASTLE_TROOP_TARGET_FILTER");
			this.bool_44 = this.method_1("USE_TROOP_REQUEST_SPEED_UP");
			this.bool_45 = this.method_1("NO_COOLDOWN_FROM_MOVE_EDITMODE_ACTIVE");
			this.bool_46 = this.method_1("SCORING_ONLY_FROM_MM");
			this.bool_47 = this.method_1("ELO_OFFSET_DAMPENING_ENABLED");
			this.bool_48 = this.method_1("ENABLE_LEAGUES");
			this.bool_49 = this.method_1("REVENGE_GIVE_LEAGUE_BONUS");
			this.bool_50 = this.method_1("REVENGE_GIVE_STAR_BONUS");
			this.bool_51 = this.method_1("ALLOW_STARS_OVERFLOW_IN_STAR_BONUS");
			this.bool_52 = this.method_1("LOAD_V2_AS_SNAPSHOT");
			this.bool_53 = this.method_1("READY_FOR_WAR_ATTACK_CHECK");
			this.bool_54 = this.method_1("USE_MORE_ACCURATE_LOOT_CAP");
			this.bool_55 = this.method_1("ENABLE_DEFENDING_ALLIANCE_TROOP_JUMP");
			this.bool_56 = this.method_1("USE_WALL_WEIGHTS_FOR_JUMP_SPELL");
			this.bool_57 = this.method_1("JUMP_WHEN_HIT_JUMPABLE");
			this.bool_58 = this.method_1("SLIDE_ALONG_OBSTACLES");
			this.bool_59 = this.method_1("GUARD_POST_NOT_FUNCTIONAL_UNDER_UGPRADE");
			this.bool_60 = this.method_1("REPATH_DURING_FLY");
			this.bool_61 = this.method_1("USE_STICK_TO_CLOSEST_UNIT_HEALER");
			this.bool_62 = this.method_1("HERO_USES_ATTACK_POS_RANDOM");
			this.bool_63 = this.method_1("USE_ATTACK_POS_RANDOM_ON_1ST_TARGET");
			this.bool_64 = this.method_1("TARGET_SELECTION_CONSIDERS_WALLS_ON_PATH");
			this.bool_65 = this.method_1("VALKYRIE_PREFERS_4_BUILDINGS");
			this.bool_66 = this.method_1("TIGHTER_ATTACK_POSITION");
			this.bool_67 = this.method_1("ALLIANCE_TROOPS_PATROL");
			this.bool_68 = this.method_1("WALL_BREAKER_USE_ROOMS");
			this.bool_69 = this.method_1("REMEMBER_ORIGINAL_TARGET");
			this.bool_70 = this.method_1("IGNORE_ALLIANCE_ALERT_FOR_NON_VALID_TARGETS");
			this.bool_71 = this.method_1("RESTART_ATTACK_TIMER_ON_AREA_DAMAGE_TURRETS");
			this.bool_72 = this.method_1("CLEAR_ALERT_STATE_IF_NO_TARGET_FOUND");
			this.bool_74 = this.method_1("MORE_PRECISE_TARGET_SELECTION");
			this.bool_73 = this.method_1("MOVING_UNITS_USE_SIMPLE_SELECT");
			this.bool_75 = this.method_1("USE_SMARTER_HEALER");
			this.bool_76 = this.method_1("USE_POISON_AVOIDANCE");
			this.bool_77 = this.method_1("REMOVE_UNTRIGGERED_TESLA");
			this.bool_78 = this.method_1("USE_STAR_BONUS");
			this.logicResourceData_0 = LogicDataTables.GetResourceByName(this.method_0("ALLIANCE_CREATE_RESOURCE").GetTextValue(), null);
			this.logicCharacterData_0 = LogicDataTables.GetCharacterByName(this.method_0("VILLAGE2_START_UNIT").GetTextValue(), null);
			LogicGlobalData logicGlobalData = this.method_0("TROOP_HOUSING_V2_COST");
			this.int_149 = new int[logicGlobalData.GetNumberArraySize()];
			for (int i = 0; i < this.int_149.Length; i++)
			{
				this.int_149[i] = logicGlobalData.GetNumberArray(i);
			}
			LogicGlobalData logicGlobalData2 = this.method_0("TROOP_HOUSING_V2_BUILD_TIME_SECONDS");
			this.int_150 = new int[logicGlobalData2.GetNumberArraySize()];
			for (int j = 0; j < this.int_150.Length; j++)
			{
				this.int_150[j] = logicGlobalData2.GetNumberArray(j);
			}
			LogicGlobalData logicGlobalData3 = this.method_0("LOOT_MULTIPLIER_BY_TH_DIFF");
			this.int_151 = new int[logicGlobalData3.GetNumberArraySize()];
			for (int k = 0; k < this.int_151.Length; k++)
			{
				this.int_151[k] = logicGlobalData3.GetNumberArray(k);
			}
			LogicGlobalData logicGlobalData4 = this.method_0("BARRACK_REDUCE_TRAINING_DIVISOR");
			this.int_152 = new int[logicGlobalData4.GetNumberArraySize()];
			for (int l = 0; l < this.int_152.Length; l++)
			{
				this.int_152[l] = logicGlobalData4.GetNumberArray(l);
			}
			LogicGlobalData logicGlobalData5 = this.method_0("DARK_BARRACK_REDUCE_TRAINING_DIVISOR");
			this.int_153 = new int[logicGlobalData5.GetNumberArraySize()];
			for (int m = 0; m < this.int_153.Length; m++)
			{
				this.int_153[m] = logicGlobalData5.GetNumberArray(m);
			}
			LogicGlobalData logicGlobalData6 = this.method_0("CLOCK_TOWER_BOOST_MINS");
			this.int_154 = new int[logicGlobalData6.GetNumberArraySize()];
			for (int n = 0; n < this.int_154.Length; n++)
			{
				this.int_154[n] = logicGlobalData6.GetNumberArray(n) * 60;
			}
			LogicGlobalData logicGlobalData7 = this.method_0("ALLIANCE_SCORE_LIMIT");
			this.int_155 = new int[logicGlobalData7.GetNumberArraySize()];
			for (int num = 0; num < this.int_155.Length; num++)
			{
				this.int_155[num] = logicGlobalData7.GetNumberArray(num);
			}
			LogicGlobalData logicGlobalData8 = this.method_0("SHIELD_HOURS");
			this.int_159 = new int[logicGlobalData8.GetNumberArraySize()];
			for (int num2 = 0; num2 < this.int_159.Length; num2++)
			{
				this.int_159[num2] = logicGlobalData8.GetNumberArray(num2);
			}
			LogicGlobalData logicGlobalData9 = this.method_0("DESTRUCTION_TO_SHIELD");
			this.int_158 = new int[logicGlobalData9.GetNumberArraySize()];
			for (int num3 = 0; num3 < this.int_158.Length; num3++)
			{
				this.int_158[num3] = logicGlobalData9.GetNumberArray(num3);
			}
			Debugger.DoAssert(this.int_159.Length == this.int_158.Length, string.Empty);
			LogicGlobalData logicGlobalData10 = this.method_0("ATTACK_SHIELD_REDUCE_HOURS");
			this.int_160 = new int[logicGlobalData10.GetNumberArraySize()];
			for (int num4 = 0; num4 < this.int_160.Length; num4++)
			{
				this.int_160[num4] = logicGlobalData10.GetNumberArray(num4);
			}
			LogicGlobalData logicGlobalData11 = this.method_0("HEAL_STACK_PERCENT");
			this.int_161 = new int[logicGlobalData11.GetNumberArraySize()];
			for (int num5 = 0; num5 < logicGlobalData11.GetNumberArraySize(); num5++)
			{
				this.int_161[num5] = logicGlobalData11.GetNumberArray(num5);
			}
			LogicGlobalData logicGlobalData12 = this.method_0("LEAGUE_BONUS_PERCENTAGES");
			this.int_156 = new int[logicGlobalData12.GetNumberArraySize()];
			this.int_157 = new int[logicGlobalData12.GetNumberArraySize()];
			for (int num6 = 0; num6 < this.int_156.Length; num6++)
			{
				this.int_156[num6] = logicGlobalData12.GetNumberArray(num6);
				this.int_157[num6] = logicGlobalData12.GetAltNumberArray(num6);
			}
		}

		// Token: 0x060012EE RID: 4846 RVA: 0x0000CA6F File Offset: 0x0000AC6F
		private LogicGlobalData method_0(string string_1)
		{
			return LogicDataTables.GetGlobalByName(string_1, null);
		}

		// Token: 0x060012EF RID: 4847 RVA: 0x0000CA78 File Offset: 0x0000AC78
		private bool method_1(string string_1)
		{
			return this.method_0(string_1).GetBooleanValue();
		}

		// Token: 0x060012F0 RID: 4848 RVA: 0x0000CA86 File Offset: 0x0000AC86
		private int method_2(string string_1)
		{
			return this.method_0(string_1).GetNumberValue();
		}

		// Token: 0x060012F1 RID: 4849 RVA: 0x0000CA94 File Offset: 0x0000AC94
		public int GetFreeUnitHousingCapPercentage()
		{
			return this.int_26;
		}

		// Token: 0x060012F2 RID: 4850 RVA: 0x0000CA9C File Offset: 0x0000AC9C
		public int GetFreeHeroHealthCap()
		{
			return this.int_27;
		}

		// Token: 0x060012F3 RID: 4851 RVA: 0x0000CAA4 File Offset: 0x0000ACA4
		public int GetStartingDiamonds()
		{
			return this.int_28;
		}

		// Token: 0x060012F4 RID: 4852 RVA: 0x0000CAAC File Offset: 0x0000ACAC
		public int GetStartingGold()
		{
			return this.int_31;
		}

		// Token: 0x060012F5 RID: 4853 RVA: 0x0000CAB4 File Offset: 0x0000ACB4
		public int GetStartingElixir()
		{
			return this.int_29;
		}

		// Token: 0x060012F6 RID: 4854 RVA: 0x0000CABC File Offset: 0x0000ACBC
		public int GetStartingGold2()
		{
			return this.int_32;
		}

		// Token: 0x060012F7 RID: 4855 RVA: 0x0000CAC4 File Offset: 0x0000ACC4
		public int GetStartingElixir2()
		{
			return this.int_30;
		}

		// Token: 0x060012F8 RID: 4856 RVA: 0x0000CACC File Offset: 0x0000ACCC
		public int GetLiveReplayUpdateFrequencySecs()
		{
			return this.int_33;
		}

		// Token: 0x060012F9 RID: 4857 RVA: 0x0000CAD4 File Offset: 0x0000ACD4
		public int GetChallengeBaseSaveCooldown()
		{
			return this.int_34;
		}

		// Token: 0x060012FA RID: 4858 RVA: 0x0000CADC File Offset: 0x0000ACDC
		public int GetAllianceTroopRequestCooldown()
		{
			return this.int_35;
		}

		// Token: 0x060012FB RID: 4859 RVA: 0x0000CAE4 File Offset: 0x0000ACE4
		public int GetArrangeWarCooldown()
		{
			return this.int_36;
		}

		// Token: 0x060012FC RID: 4860 RVA: 0x0000CAEC File Offset: 0x0000ACEC
		public int GetClanMailCooldown()
		{
			return this.int_37;
		}

		// Token: 0x060012FD RID: 4861 RVA: 0x0000CAF4 File Offset: 0x0000ACF4
		public int GetReplayShareCooldown()
		{
			return this.int_38;
		}

		// Token: 0x060012FE RID: 4862 RVA: 0x0000CAFC File Offset: 0x0000ACFC
		public int GetElderKickCooldown()
		{
			return this.int_39;
		}

		// Token: 0x060012FF RID: 4863 RVA: 0x0000CB04 File Offset: 0x0000AD04
		public int GetAllianceCreateCost()
		{
			return this.int_41;
		}

		// Token: 0x06001300 RID: 4864 RVA: 0x0000CB0C File Offset: 0x0000AD0C
		public int GetClockTowerBoostMultiplier()
		{
			return this.int_91;
		}

		// Token: 0x06001301 RID: 4865 RVA: 0x0000CB14 File Offset: 0x0000AD14
		public int GetResourceProductionBoostMultiplier()
		{
			return this.int_92;
		}

		// Token: 0x06001302 RID: 4866 RVA: 0x0000CB1C File Offset: 0x0000AD1C
		public int GetResourceProductionBoostSecs()
		{
			return this.int_59;
		}

		// Token: 0x06001303 RID: 4867 RVA: 0x0000CB24 File Offset: 0x0000AD24
		public int GetSpellFactoryBoostMultiplier()
		{
			return this.int_109;
		}

		// Token: 0x06001304 RID: 4868 RVA: 0x0000CB2C File Offset: 0x0000AD2C
		public int GetSpellFactoryBoostNewMultiplier()
		{
			return this.int_108;
		}

		// Token: 0x06001305 RID: 4869 RVA: 0x0000CB34 File Offset: 0x0000AD34
		public int GetSpellFactoryBoostSecs()
		{
			return this.int_61;
		}

		// Token: 0x06001306 RID: 4870 RVA: 0x0000CB3C File Offset: 0x0000AD3C
		public int GetBarracksBoostNewMultiplier()
		{
			return this.int_106;
		}

		// Token: 0x06001307 RID: 4871 RVA: 0x0000CB44 File Offset: 0x0000AD44
		public int GetBarracksBoostMultiplier()
		{
			return this.int_107;
		}

		// Token: 0x06001308 RID: 4872 RVA: 0x0000CB4C File Offset: 0x0000AD4C
		public int GetBuildCancelMultiplier()
		{
			return this.int_112;
		}

		// Token: 0x06001309 RID: 4873 RVA: 0x0000CB54 File Offset: 0x0000AD54
		public int GetTrainCancelMultiplier()
		{
			return this.int_114;
		}

		// Token: 0x0600130A RID: 4874 RVA: 0x0000CB5C File Offset: 0x0000AD5C
		public int GetSpellCancelMultiplier()
		{
			return this.int_113;
		}

		// Token: 0x0600130B RID: 4875 RVA: 0x0000CB64 File Offset: 0x0000AD64
		public int GetHeroUpgradeCancelMultiplier()
		{
			return this.int_115;
		}

		// Token: 0x0600130C RID: 4876 RVA: 0x0000CB6C File Offset: 0x0000AD6C
		public int GetBarracksBoostSecs()
		{
			return this.int_60;
		}

		// Token: 0x0600130D RID: 4877 RVA: 0x0000CB74 File Offset: 0x0000AD74
		public int GetClockTowerBoostCooldownSecs()
		{
			return this.int_42;
		}

		// Token: 0x0600130E RID: 4878 RVA: 0x0000CB7C File Offset: 0x0000AD7C
		public int GetHeroRestBoostSecs()
		{
			return this.int_62;
		}

		// Token: 0x0600130F RID: 4879 RVA: 0x0000CB84 File Offset: 0x0000AD84
		public int GetClampLongTimeStampsToDays()
		{
			return this.int_43;
		}

		// Token: 0x06001310 RID: 4880 RVA: 0x0000CB8C File Offset: 0x0000AD8C
		public int GetObstacleRespawnSecs()
		{
			return this.int_49;
		}

		// Token: 0x06001311 RID: 4881 RVA: 0x0000CB94 File Offset: 0x0000AD94
		public int GetTallGrassRespawnSecs()
		{
			return this.int_50;
		}

		// Token: 0x06001312 RID: 4882 RVA: 0x0000CB9C File Offset: 0x0000AD9C
		public int GetObstacleMaxCount()
		{
			return this.int_51;
		}

		// Token: 0x06001313 RID: 4883 RVA: 0x0000CBA4 File Offset: 0x0000ADA4
		public int GetNewTrainingBoostBarracksCost()
		{
			return this.int_64;
		}

		// Token: 0x06001314 RID: 4884 RVA: 0x0000CBAC File Offset: 0x0000ADAC
		public int GetNewTrainingBoostLaboratoryCost()
		{
			return this.int_65;
		}

		// Token: 0x06001315 RID: 4885 RVA: 0x0000CBB4 File Offset: 0x0000ADB4
		public int GetUnitHousingCostMultiplierForTotal()
		{
			return this.int_102;
		}

		// Token: 0x06001316 RID: 4886 RVA: 0x0000CBBC File Offset: 0x0000ADBC
		public int GetSpellHousingCostMultiplierForTotal()
		{
			return this.int_103;
		}

		// Token: 0x06001317 RID: 4887 RVA: 0x0000CBC4 File Offset: 0x0000ADC4
		public int GetHeroHousingCostMultiplierForTotal()
		{
			return this.int_104;
		}

		// Token: 0x06001318 RID: 4888 RVA: 0x0000CBCC File Offset: 0x0000ADCC
		public int GetAllianceUnitHousingCostMultiplierForTotal()
		{
			return this.int_105;
		}

		// Token: 0x06001319 RID: 4889 RVA: 0x0000CBD4 File Offset: 0x0000ADD4
		public int GetPersonalBreakLimitSeconds()
		{
			return this.int_66;
		}

		// Token: 0x0600131A RID: 4890 RVA: 0x0000CBDC File Offset: 0x0000ADDC
		public int GetMaxTroopDonationCount()
		{
			return this.int_71;
		}

		// Token: 0x0600131B RID: 4891 RVA: 0x0000CBE4 File Offset: 0x0000ADE4
		public int GetMaxSpellDonationCount()
		{
			return this.int_72;
		}

		// Token: 0x0600131C RID: 4892 RVA: 0x0000CBEC File Offset: 0x0000ADEC
		public int GetDarkSpellDonationXP()
		{
			return this.int_73;
		}

		// Token: 0x0600131D RID: 4893 RVA: 0x0000CBF4 File Offset: 0x0000ADF4
		public int GetStarBonusCooldownMinutes()
		{
			return this.int_75;
		}

		// Token: 0x0600131E RID: 4894 RVA: 0x0000CBFC File Offset: 0x0000ADFC
		public int GetChallengeCooldown()
		{
			return this.int_40;
		}

		// Token: 0x0600131F RID: 4895 RVA: 0x0000CC04 File Offset: 0x0000AE04
		public int GetNewbieShieldHours()
		{
			return this.int_120;
		}

		// Token: 0x06001320 RID: 4896 RVA: 0x0000CC0C File Offset: 0x0000AE0C
		public int GetLayoutTownHallLevelSlot2()
		{
			return this.int_122;
		}

		// Token: 0x06001321 RID: 4897 RVA: 0x0000CC14 File Offset: 0x0000AE14
		public int GetLayoutTownHallLevelSlot3()
		{
			return this.int_123;
		}

		// Token: 0x06001322 RID: 4898 RVA: 0x0000CC1C File Offset: 0x0000AE1C
		public int GetLayoutTownHallLevelVillage2Slot2()
		{
			return this.int_124;
		}

		// Token: 0x06001323 RID: 4899 RVA: 0x0000CC24 File Offset: 0x0000AE24
		public int GetLayoutTownHallLevelVillage2Slot3()
		{
			return this.int_125;
		}

		// Token: 0x06001324 RID: 4900 RVA: 0x0000CC2C File Offset: 0x0000AE2C
		public int GetScoreMultiplierOnAttackLose()
		{
			return this.int_126;
		}

		// Token: 0x06001325 RID: 4901 RVA: 0x0000CC34 File Offset: 0x0000AE34
		public int GetEloDampeningFactor()
		{
			return this.int_127;
		}

		// Token: 0x06001326 RID: 4902 RVA: 0x0000CC3C File Offset: 0x0000AE3C
		public int GetEloDampeningLimit()
		{
			return this.int_128;
		}

		// Token: 0x06001327 RID: 4903 RVA: 0x0000CC44 File Offset: 0x0000AE44
		public int GetEloDampeningScoreLimit()
		{
			return this.int_129;
		}

		// Token: 0x06001328 RID: 4904 RVA: 0x0000CC4C File Offset: 0x0000AE4C
		public int GetShieldTriggerPercentageHousingSpace()
		{
			return this.int_132;
		}

		// Token: 0x06001329 RID: 4905 RVA: 0x0000CC54 File Offset: 0x0000AE54
		public int GetDefaultDefenseVillageGuard()
		{
			return this.int_133;
		}

		// Token: 0x0600132A RID: 4906 RVA: 0x0000CC5C File Offset: 0x0000AE5C
		public int GetMinerTargetRandomPercentage()
		{
			return this.int_82;
		}

		// Token: 0x0600132B RID: 4907 RVA: 0x0000CC64 File Offset: 0x0000AE64
		public int GetMinerSpeedRandomPercentage()
		{
			return this.int_83;
		}

		// Token: 0x0600132C RID: 4908 RVA: 0x0000CC6C File Offset: 0x0000AE6C
		public int GetMinerHideTime()
		{
			return this.int_84;
		}

		// Token: 0x0600132D RID: 4909 RVA: 0x0000CC74 File Offset: 0x0000AE74
		public int GetMinerHideTimeRandom()
		{
			return this.int_85;
		}

		// Token: 0x0600132E RID: 4910 RVA: 0x0000CC7C File Offset: 0x0000AE7C
		public int GetTownHallLootPercentage()
		{
			return this.int_86;
		}

		// Token: 0x0600132F RID: 4911 RVA: 0x0000CC84 File Offset: 0x0000AE84
		public int GetTargetListSize()
		{
			return this.int_89;
		}

		// Token: 0x06001330 RID: 4912 RVA: 0x0000CC8C File Offset: 0x0000AE8C
		public int GetWallBreakerSmartCountLimit()
		{
			return this.int_141;
		}

		// Token: 0x06001331 RID: 4913 RVA: 0x0000CC94 File Offset: 0x0000AE94
		public int GetWallBreakerSmartRadius()
		{
			return this.int_142;
		}

		// Token: 0x06001332 RID: 4914 RVA: 0x0000CC9C File Offset: 0x0000AE9C
		public int GetWallBreakerSmartRetargetLimit()
		{
			return this.int_143;
		}

		// Token: 0x06001333 RID: 4915 RVA: 0x0000CCA4 File Offset: 0x0000AEA4
		public int GetSelectedWallTime()
		{
			return this.int_144;
		}

		// Token: 0x06001334 RID: 4916 RVA: 0x0000CCAC File Offset: 0x0000AEAC
		public int GetForgetTargetTime()
		{
			return this.int_145;
		}

		// Token: 0x06001335 RID: 4917 RVA: 0x0000CCB4 File Offset: 0x0000AEB4
		public int GetSkeletonSpellStorageMultipler()
		{
			return this.int_146;
		}

		// Token: 0x06001336 RID: 4918 RVA: 0x0000CCBC File Offset: 0x0000AEBC
		public int GetAllianceAlertRadius()
		{
			return this.int_147;
		}

		// Token: 0x06001337 RID: 4919 RVA: 0x0000CCC4 File Offset: 0x0000AEC4
		public int GetHiddenBuildingAppearDestructionPercentage()
		{
			return this.int_135;
		}

		// Token: 0x06001338 RID: 4920 RVA: 0x0000CCCC File Offset: 0x0000AECC
		public int GetWallCostBase()
		{
			return this.int_134;
		}

		// Token: 0x06001339 RID: 4921 RVA: 0x0000CCD4 File Offset: 0x0000AED4
		public int GetHeroHealMultiplier()
		{
			return this.int_136;
		}

		// Token: 0x0600133A RID: 4922 RVA: 0x0000CCDC File Offset: 0x0000AEDC
		public int GetHeroRageMultiplier()
		{
			return this.int_137;
		}

		// Token: 0x0600133B RID: 4923 RVA: 0x0000CCE4 File Offset: 0x0000AEE4
		public int GetHeroRageSpeedMultiplier()
		{
			return this.int_138;
		}

		// Token: 0x0600133C RID: 4924 RVA: 0x0000CCEC File Offset: 0x0000AEEC
		public int GetChainedProjectileBounceCount()
		{
			return this.int_90;
		}

		// Token: 0x0600133D RID: 4925 RVA: 0x0000CCF4 File Offset: 0x0000AEF4
		public int GetShrinkSpellDurationSeconds()
		{
			return this.int_148;
		}

		// Token: 0x0600133E RID: 4926 RVA: 0x0000CCFC File Offset: 0x0000AEFC
		public int GetResourceProductionLootPercentage(LogicResourceData data)
		{
			if (LogicDataTables.GetDarkElixirData() == data)
			{
				return this.int_53;
			}
			return this.int_52;
		}

		// Token: 0x0600133F RID: 4927 RVA: 0x0000CD13 File Offset: 0x0000AF13
		public int GetLootMultiplierByTownHallDiff(int townHallLevel1, int townHallLevel2)
		{
			return this.int_151[LogicMath.Clamp(townHallLevel1 + 4 - townHallLevel2, 0, this.int_151.Length - 1)];
		}

		// Token: 0x06001340 RID: 4928 RVA: 0x0000CD31 File Offset: 0x0000AF31
		public int[] GetBarrackReduceTrainingDevisor()
		{
			return this.int_152;
		}

		// Token: 0x06001341 RID: 4929 RVA: 0x0000CD39 File Offset: 0x0000AF39
		public int[] GetDarkBarrackReduceTrainingDevisor()
		{
			return this.int_153;
		}

		// Token: 0x06001342 RID: 4930 RVA: 0x00050098 File Offset: 0x0004E298
		public int GetWorkerCost(LogicLevel level)
		{
			switch (level.GetWorkerManagerAt(level.GetVillageType()).GetTotalWorkers() + level.GetUnplacedObjectCount(LogicDataTables.GetWorkerData()))
			{
			case 1:
				return this.int_44;
			case 2:
				return this.int_45;
			case 3:
				return this.int_46;
			case 4:
				return this.int_47;
			default:
				return this.int_47;
			}
		}

		// Token: 0x06001343 RID: 4931 RVA: 0x0000CD41 File Offset: 0x0000AF41
		public int GetChallengeBaseCooldownEnabledTownHall()
		{
			return this.int_48;
		}

		// Token: 0x06001344 RID: 4932 RVA: 0x0000CD49 File Offset: 0x0000AF49
		public int GetSpellTrainingCostMultiplier()
		{
			return this.int_93;
		}

		// Token: 0x06001345 RID: 4933 RVA: 0x0000CD51 File Offset: 0x0000AF51
		public int GetSpellSpeedUpCostMultiplier()
		{
			return this.int_94;
		}

		// Token: 0x06001346 RID: 4934 RVA: 0x0000CD59 File Offset: 0x0000AF59
		public int GetHeroHealthSpeedUpCostMultipler()
		{
			return this.int_95;
		}

		// Token: 0x06001347 RID: 4935 RVA: 0x0000CD61 File Offset: 0x0000AF61
		public int GetTroopRequestSpeedUpCostMultiplier()
		{
			return this.int_96;
		}

		// Token: 0x06001348 RID: 4936 RVA: 0x0000CD69 File Offset: 0x0000AF69
		public int GetTroopTrainingCostMultiplier()
		{
			return this.int_97;
		}

		// Token: 0x06001349 RID: 4937 RVA: 0x0000CD71 File Offset: 0x0000AF71
		public int GetSpeedUpBoostCooldownCostMultiplier()
		{
			return this.int_98;
		}

		// Token: 0x0600134A RID: 4938 RVA: 0x0000CD79 File Offset: 0x0000AF79
		public int GetClockTowerSpeedUpMultiplier()
		{
			return this.int_110;
		}

		// Token: 0x0600134B RID: 4939 RVA: 0x0000CD81 File Offset: 0x0000AF81
		public int GetMinVillage2TownHallLevelForDestructObstacle()
		{
			return this.int_54;
		}

		// Token: 0x0600134C RID: 4940 RVA: 0x0000CD89 File Offset: 0x0000AF89
		public int GetAttackPreparationLengthSecs()
		{
			return this.int_56;
		}

		// Token: 0x0600134D RID: 4941 RVA: 0x0000CD91 File Offset: 0x0000AF91
		public int GetAttackVillage2PreparationLengthSecs()
		{
			return this.int_55;
		}

		// Token: 0x0600134E RID: 4942 RVA: 0x0000CD99 File Offset: 0x0000AF99
		public int GetAttackLengthSecs()
		{
			return this.int_57;
		}

		// Token: 0x0600134F RID: 4943 RVA: 0x0000CDA1 File Offset: 0x0000AFA1
		public int GetVillage2StartUnitLevel()
		{
			return this.int_58;
		}

		// Token: 0x06001350 RID: 4944 RVA: 0x0000CDA9 File Offset: 0x0000AFA9
		public int GetHeroRestBoostMultiplier()
		{
			return this.int_111;
		}

		// Token: 0x06001351 RID: 4945 RVA: 0x0000CDB1 File Offset: 0x0000AFB1
		public int GetEnablePresetsTownHallLevel()
		{
			return this.int_67;
		}

		// Token: 0x06001352 RID: 4946 RVA: 0x0000CDB9 File Offset: 0x0000AFB9
		public int GetMaxAllianceFeedbackMessageLength()
		{
			return this.int_68;
		}

		// Token: 0x06001353 RID: 4947 RVA: 0x0000CDC1 File Offset: 0x0000AFC1
		public int GetMaxMessageLength()
		{
			return this.int_70;
		}

		// Token: 0x06001354 RID: 4948 RVA: 0x0000CDC9 File Offset: 0x0000AFC9
		public int GetAllianceMailLength()
		{
			return this.int_69;
		}

		// Token: 0x06001355 RID: 4949 RVA: 0x0000CDD1 File Offset: 0x0000AFD1
		public int GetUnitHousingCostMultiplier()
		{
			return this.int_100;
		}

		// Token: 0x06001356 RID: 4950 RVA: 0x0000CDD9 File Offset: 0x0000AFD9
		public int GetHeroHousingCostMultiplier()
		{
			return this.int_101;
		}

		// Token: 0x06001357 RID: 4951 RVA: 0x0000CDE1 File Offset: 0x0000AFE1
		public int GetSpellHousingCostMultiplier()
		{
			return this.int_99;
		}

		// Token: 0x06001358 RID: 4952 RVA: 0x0000CDE9 File Offset: 0x0000AFE9
		public int GetEnableNameChangeTownHallLevel()
		{
			return this.int_74;
		}

		// Token: 0x06001359 RID: 4953 RVA: 0x0000CDF1 File Offset: 0x0000AFF1
		public int GetDuelLootLimitFreeSpeedUps()
		{
			return this.int_119;
		}

		// Token: 0x0600135A RID: 4954 RVA: 0x0000CDF9 File Offset: 0x0000AFF9
		public int GetBunkerSearchTime()
		{
			return this.int_76;
		}

		// Token: 0x0600135B RID: 4955 RVA: 0x0000CE01 File Offset: 0x0000B001
		public int GetClanCastleRadius()
		{
			return this.int_77;
		}

		// Token: 0x0600135C RID: 4956 RVA: 0x0000CE09 File Offset: 0x0000B009
		public int GetClanDefenderSearchRadius()
		{
			return this.int_78;
		}

		// Token: 0x0600135D RID: 4957 RVA: 0x0000CE11 File Offset: 0x0000B011
		public int GetLootCartReengagementMinSeconds()
		{
			return this.int_79;
		}

		// Token: 0x0600135E RID: 4958 RVA: 0x0000CE19 File Offset: 0x0000B019
		public int GetLootCartReengagementMaxSeconds()
		{
			return this.int_80;
		}

		// Token: 0x0600135F RID: 4959 RVA: 0x0000CE21 File Offset: 0x0000B021
		public int GetBookmarksMaxAlliances()
		{
			return this.int_121;
		}

		// Token: 0x06001360 RID: 4960 RVA: 0x0000CE29 File Offset: 0x0000B029
		public int GetStarBonusStarCount()
		{
			return this.int_130;
		}

		// Token: 0x06001361 RID: 4961 RVA: 0x0000CE31 File Offset: 0x0000B031
		public int GetLootCartEnabledTownHall()
		{
			return this.int_131;
		}

		// Token: 0x06001362 RID: 4962 RVA: 0x0000CE39 File Offset: 0x0000B039
		public int GetWarMaxExcludeMembers()
		{
			return this.int_81;
		}

		// Token: 0x06001363 RID: 4963 RVA: 0x0000CE41 File Offset: 0x0000B041
		public int GetCharVersusCharRandomDistanceLimit()
		{
			return this.int_87;
		}

		// Token: 0x06001364 RID: 4964 RVA: 0x0000CE49 File Offset: 0x0000B049
		public int GetCharVersusCharRadiusForAttacker()
		{
			return this.int_88;
		}

		// Token: 0x06001365 RID: 4965 RVA: 0x0000CE51 File Offset: 0x0000B051
		public int GetWarLootPercentage()
		{
			return this.int_139;
		}

		// Token: 0x06001366 RID: 4966 RVA: 0x0000CE59 File Offset: 0x0000B059
		public int GetBlockedAttackPositionPenalty()
		{
			return this.int_140;
		}

		// Token: 0x06001367 RID: 4967 RVA: 0x0000CE61 File Offset: 0x0000B061
		public bool CastleTroopTargetFilter()
		{
			return this.bool_43;
		}

		// Token: 0x06001368 RID: 4968 RVA: 0x0000CE69 File Offset: 0x0000B069
		public bool MoreAccurateTime()
		{
			return this.bool_6;
		}

		// Token: 0x06001369 RID: 4969 RVA: 0x0000CE71 File Offset: 0x0000B071
		public bool UseNewTraining()
		{
			return this.bool_2;
		}

		// Token: 0x0600136A RID: 4970 RVA: 0x0000CE79 File Offset: 0x0000B079
		public bool UseTroopWalksOutFromTraining()
		{
			return this.bool_3;
		}

		// Token: 0x0600136B RID: 4971 RVA: 0x0000CE81 File Offset: 0x0000B081
		public bool UseVillageObjects()
		{
			return this.bool_4;
		}

		// Token: 0x0600136C RID: 4972 RVA: 0x0000CE89 File Offset: 0x0000B089
		public bool UseTownHallLootPenaltyInWar()
		{
			return this.bool_39;
		}

		// Token: 0x0600136D RID: 4973 RVA: 0x0000CE91 File Offset: 0x0000B091
		public bool UseDragInTraining()
		{
			return this.bool_7;
		}

		// Token: 0x0600136E RID: 4974 RVA: 0x0000CE99 File Offset: 0x0000B099
		public bool UseDragInTrainingFix()
		{
			return this.bool_8;
		}

		// Token: 0x0600136F RID: 4975 RVA: 0x0000CEA1 File Offset: 0x0000B0A1
		public bool UseDragInTrainingFix2()
		{
			return this.bool_9;
		}

		// Token: 0x06001370 RID: 4976 RVA: 0x0000CEA9 File Offset: 0x0000B0A9
		public bool RevertBrokenWarLayouts()
		{
			return this.bool_12;
		}

		// Token: 0x06001371 RID: 4977 RVA: 0x0000CEB1 File Offset: 0x0000B0B1
		public bool LiveReplayEnabled()
		{
			return this.bool_11;
		}

		// Token: 0x06001372 RID: 4978 RVA: 0x0000CEB9 File Offset: 0x0000B0B9
		public bool RemoveRevengeWhenBattleIsLoaded()
		{
			return this.bool_13;
		}

		// Token: 0x06001373 RID: 4979 RVA: 0x0000CEC1 File Offset: 0x0000B0C1
		public bool UseNewPathFinder()
		{
			return this.bool_10;
		}

		// Token: 0x06001374 RID: 4980 RVA: 0x0000CEC9 File Offset: 0x0000B0C9
		public bool CompleteConstructionOnlyHome()
		{
			return this.bool_14;
		}

		// Token: 0x06001375 RID: 4981 RVA: 0x0000CED1 File Offset: 0x0000B0D1
		public bool UseNewSpeedUpCalculation()
		{
			return this.bool_15;
		}

		// Token: 0x06001376 RID: 4982 RVA: 0x0000CED9 File Offset: 0x0000B0D9
		public bool ClampBuildingTimes()
		{
			return this.bool_16;
		}

		// Token: 0x06001377 RID: 4983 RVA: 0x0000CEE1 File Offset: 0x0000B0E1
		public bool ClampUpgradeTimes()
		{
			return this.bool_17;
		}

		// Token: 0x06001378 RID: 4984 RVA: 0x0000CEE9 File Offset: 0x0000B0E9
		public bool ClampAvatarTimersToMax()
		{
			return this.bool_18;
		}

		// Token: 0x06001379 RID: 4985 RVA: 0x0000CEF1 File Offset: 0x0000B0F1
		public bool StopBoostPauseWhenBoostTimeZeroOnLoad()
		{
			return this.bool_19;
		}

		// Token: 0x0600137A RID: 4986 RVA: 0x0000CEF9 File Offset: 0x0000B0F9
		public bool FixClanPortalBattleNotEnding()
		{
			return this.bool_20;
		}

		// Token: 0x0600137B RID: 4987 RVA: 0x0000CF01 File Offset: 0x0000B101
		public bool FixMergeOldBarrackBoostPausing()
		{
			return this.bool_21;
		}

		// Token: 0x0600137C RID: 4988 RVA: 0x0000CF09 File Offset: 0x0000B109
		public bool SaveVillageObjects()
		{
			return this.bool_22;
		}

		// Token: 0x0600137D RID: 4989 RVA: 0x0000CF11 File Offset: 0x0000B111
		public bool StartInLastUsedVillage()
		{
			return this.bool_23;
		}

		// Token: 0x0600137E RID: 4990 RVA: 0x0000CF19 File Offset: 0x0000B119
		public bool WorkerForZeroBuilTime()
		{
			return this.bool_24;
		}

		// Token: 0x0600137F RID: 4991 RVA: 0x0000CF21 File Offset: 0x0000B121
		public bool AdjustEndSubtickUseCurrentTime()
		{
			return this.bool_25;
		}

		// Token: 0x06001380 RID: 4992 RVA: 0x0000CF29 File Offset: 0x0000B129
		public bool CollectAllResourcesAtOnce()
		{
			return this.bool_26;
		}

		// Token: 0x06001381 RID: 4993 RVA: 0x0000CF31 File Offset: 0x0000B131
		public bool UseSwapBuildings()
		{
			return this.bool_27;
		}

		// Token: 0x06001382 RID: 4994 RVA: 0x0000CF39 File Offset: 0x0000B139
		public bool TreasurySizeBasedOnTownHall()
		{
			return this.bool_28;
		}

		// Token: 0x06001383 RID: 4995 RVA: 0x0000CF41 File Offset: 0x0000B141
		public bool UseTeslaTriggerCommand()
		{
			return this.bool_29;
		}

		// Token: 0x06001384 RID: 4996 RVA: 0x0000CF49 File Offset: 0x0000B149
		public bool UseTrapTriggerCommand()
		{
			return this.bool_30;
		}

		// Token: 0x06001385 RID: 4997 RVA: 0x0000CF51 File Offset: 0x0000B151
		public bool ValidateTroopUpgradeLevels()
		{
			return this.bool_31;
		}

		// Token: 0x06001386 RID: 4998 RVA: 0x0000CF59 File Offset: 0x0000B159
		public bool AllowCancelBuildingConstruction()
		{
			return this.bool_32;
		}

		// Token: 0x06001387 RID: 4999 RVA: 0x0000CF61 File Offset: 0x0000B161
		public bool Village2TrainingOnlyUseRegularStorage()
		{
			return this.bool_33;
		}

		// Token: 0x06001388 RID: 5000 RVA: 0x0000CF69 File Offset: 0x0000B169
		public bool EnableTroopDeletion()
		{
			return this.bool_34;
		}

		// Token: 0x06001389 RID: 5001 RVA: 0x0000CF71 File Offset: 0x0000B171
		public bool EnablePresets()
		{
			return this.bool_35;
		}

		// Token: 0x0600138A RID: 5002 RVA: 0x0000CF79 File Offset: 0x0000B179
		public bool EnableNameChange()
		{
			return this.bool_36;
		}

		// Token: 0x0600138B RID: 5003 RVA: 0x0000CF81 File Offset: 0x0000B181
		public bool EnableQuickDonate()
		{
			return this.bool_37;
		}

		// Token: 0x0600138C RID: 5004 RVA: 0x0000CF89 File Offset: 0x0000B189
		public bool EnableQuickDonateWar()
		{
			return this.bool_38;
		}

		// Token: 0x0600138D RID: 5005 RVA: 0x0000CF91 File Offset: 0x0000B191
		public bool AllowClanCastleDeployOnObstacles()
		{
			return this.bool_40;
		}

		// Token: 0x0600138E RID: 5006 RVA: 0x0000CF99 File Offset: 0x0000B199
		public bool SkeletonTriggerTesla()
		{
			return this.bool_41;
		}

		// Token: 0x0600138F RID: 5007 RVA: 0x0000CFA1 File Offset: 0x0000B1A1
		public bool SkeletonOpenClanCastle()
		{
			return this.bool_42;
		}

		// Token: 0x06001390 RID: 5008 RVA: 0x0000CFA9 File Offset: 0x0000B1A9
		public bool UseTroopRequestSpeedUp()
		{
			return this.bool_44;
		}

		// Token: 0x06001391 RID: 5009 RVA: 0x0000CFB1 File Offset: 0x0000B1B1
		public bool NoCooldownFromMoveEditModeActive()
		{
			return this.bool_45;
		}

		// Token: 0x06001392 RID: 5010 RVA: 0x0000CFB9 File Offset: 0x0000B1B9
		public bool UseVersusBattle()
		{
			return this.bool_5;
		}

		// Token: 0x06001393 RID: 5011 RVA: 0x0000CFC1 File Offset: 0x0000B1C1
		public bool ScoringOnlyFromMatchedMode()
		{
			return this.bool_46;
		}

		// Token: 0x06001394 RID: 5012 RVA: 0x0000CFC9 File Offset: 0x0000B1C9
		public bool EloOffsetDampeningEnabled()
		{
			return this.bool_47;
		}

		// Token: 0x06001395 RID: 5013 RVA: 0x0000CFD1 File Offset: 0x0000B1D1
		public bool EnableLeagues()
		{
			return this.bool_48;
		}

		// Token: 0x06001396 RID: 5014 RVA: 0x0000CFD9 File Offset: 0x0000B1D9
		public bool RevengeGiveLeagueBonus()
		{
			return this.bool_49;
		}

		// Token: 0x06001397 RID: 5015 RVA: 0x0000CFE1 File Offset: 0x0000B1E1
		public bool RevengeGiveStarBonus()
		{
			return this.bool_50;
		}

		// Token: 0x06001398 RID: 5016 RVA: 0x0000CFE9 File Offset: 0x0000B1E9
		public bool AllowStarsOverflowInStarBonus()
		{
			return this.bool_51;
		}

		// Token: 0x06001399 RID: 5017 RVA: 0x0000CFF1 File Offset: 0x0000B1F1
		public bool LoadVillage2AsSnapshot()
		{
			return this.bool_52;
		}

		// Token: 0x0600139A RID: 5018 RVA: 0x0000CFF9 File Offset: 0x0000B1F9
		public bool ReadyForWarAttackCheck()
		{
			return this.bool_53;
		}

		// Token: 0x0600139B RID: 5019 RVA: 0x0000D001 File Offset: 0x0000B201
		public bool UseMoreAccurateLootCap()
		{
			return this.bool_54;
		}

		// Token: 0x0600139C RID: 5020 RVA: 0x0000D009 File Offset: 0x0000B209
		public bool EnableDefendingAllianceTroopJump()
		{
			return this.bool_55;
		}

		// Token: 0x0600139D RID: 5021 RVA: 0x0000D011 File Offset: 0x0000B211
		public bool UseWallWeightsForJumpSpell()
		{
			return this.bool_56;
		}

		// Token: 0x0600139E RID: 5022 RVA: 0x0000D019 File Offset: 0x0000B219
		public bool JumpWhenHitJumpable()
		{
			return this.bool_57;
		}

		// Token: 0x0600139F RID: 5023 RVA: 0x0000D021 File Offset: 0x0000B221
		public bool SlideAlongObstacles()
		{
			return this.bool_58;
		}

		// Token: 0x060013A0 RID: 5024 RVA: 0x0000D029 File Offset: 0x0000B229
		public bool GuardPostNotFunctionalUnderUpgrade()
		{
			return this.bool_59;
		}

		// Token: 0x060013A1 RID: 5025 RVA: 0x0000D031 File Offset: 0x0000B231
		public bool RepathDuringFly()
		{
			return this.bool_60;
		}

		// Token: 0x060013A2 RID: 5026 RVA: 0x0000D039 File Offset: 0x0000B239
		public bool UseStickToClosestUnitHealer()
		{
			return this.bool_61;
		}

		// Token: 0x060013A3 RID: 5027 RVA: 0x0000D041 File Offset: 0x0000B241
		public bool HeroUsesAttackPosRandom()
		{
			return this.bool_62;
		}

		// Token: 0x060013A4 RID: 5028 RVA: 0x0000D049 File Offset: 0x0000B249
		public bool UseAttackPosRandomOn1stTarget()
		{
			return this.bool_63;
		}

		// Token: 0x060013A5 RID: 5029 RVA: 0x0000D051 File Offset: 0x0000B251
		public bool TargetSelectionConsidersWallsOnPath()
		{
			return this.bool_64;
		}

		// Token: 0x060013A6 RID: 5030 RVA: 0x0000D059 File Offset: 0x0000B259
		public bool ValkyriePrefers4Buildings()
		{
			return this.bool_65;
		}

		// Token: 0x060013A7 RID: 5031 RVA: 0x0000D061 File Offset: 0x0000B261
		public bool TighterAttackPosition()
		{
			return this.bool_66;
		}

		// Token: 0x060013A8 RID: 5032 RVA: 0x0000D069 File Offset: 0x0000B269
		public bool AllianceTroopsPatrol()
		{
			return this.bool_67;
		}

		// Token: 0x060013A9 RID: 5033 RVA: 0x0000D071 File Offset: 0x0000B271
		public bool WallBreakerUseRooms()
		{
			return this.bool_68;
		}

		// Token: 0x060013AA RID: 5034 RVA: 0x0000D079 File Offset: 0x0000B279
		public bool RememberOriginalTarget()
		{
			return this.bool_69;
		}

		// Token: 0x060013AB RID: 5035 RVA: 0x0000D081 File Offset: 0x0000B281
		public bool IgnoreAllianceAlertForNonValidTargets()
		{
			return this.bool_70;
		}

		// Token: 0x060013AC RID: 5036 RVA: 0x0000D089 File Offset: 0x0000B289
		public bool RestartAttackTimerOnAreaDamageTurrets()
		{
			return this.bool_71;
		}

		// Token: 0x060013AD RID: 5037 RVA: 0x0000D091 File Offset: 0x0000B291
		public bool ClearAlertStateIfNoTargetFound()
		{
			return this.bool_72;
		}

		// Token: 0x060013AE RID: 5038 RVA: 0x0000D099 File Offset: 0x0000B299
		public bool MorePreciseTargetSelection()
		{
			return this.bool_74;
		}

		// Token: 0x060013AF RID: 5039 RVA: 0x0000D0A1 File Offset: 0x0000B2A1
		public bool MovingUnitsUseSimpleSelect()
		{
			return this.bool_73;
		}

		// Token: 0x060013B0 RID: 5040 RVA: 0x0000D0A9 File Offset: 0x0000B2A9
		public bool UseSmarterHealer()
		{
			return this.bool_75;
		}

		// Token: 0x060013B1 RID: 5041 RVA: 0x0000D0B1 File Offset: 0x0000B2B1
		public bool UsePoisonAvoidance()
		{
			return this.bool_76;
		}

		// Token: 0x060013B2 RID: 5042 RVA: 0x0000D0B9 File Offset: 0x0000B2B9
		public bool RemoveUntriggeredTesla()
		{
			return this.bool_77;
		}

		// Token: 0x060013B3 RID: 5043 RVA: 0x0000D0C1 File Offset: 0x0000B2C1
		public bool UseStarBonus()
		{
			return this.bool_78;
		}

		// Token: 0x060013B4 RID: 5044 RVA: 0x0000D0C9 File Offset: 0x0000B2C9
		public LogicResourceData GetAllianceCreateResourceData()
		{
			return this.logicResourceData_0;
		}

		// Token: 0x060013B5 RID: 5045 RVA: 0x0000D0D1 File Offset: 0x0000B2D1
		public LogicCharacterData GetVillage2StartUnitData()
		{
			return this.logicCharacterData_0;
		}

		// Token: 0x060013B6 RID: 5046 RVA: 0x0000D0D9 File Offset: 0x0000B2D9
		public LogicResourceData GetAttackResource()
		{
			return LogicDataTables.GetGoldData();
		}

		// Token: 0x060013B7 RID: 5047 RVA: 0x0000D0E0 File Offset: 0x0000B2E0
		public int GetVillage2FirstVictoryTrophies()
		{
			return this.int_116;
		}

		// Token: 0x060013B8 RID: 5048 RVA: 0x0000D0E8 File Offset: 0x0000B2E8
		public int GetVillage2FirstVictoryGold()
		{
			return this.int_117;
		}

		// Token: 0x060013B9 RID: 5049 RVA: 0x0000D0F0 File Offset: 0x0000B2F0
		public int GetVillage2FirstVictoryElixir()
		{
			return this.int_118;
		}

		// Token: 0x060013BA RID: 5050 RVA: 0x0000D0F8 File Offset: 0x0000B2F8
		public int GetFriendlyBattleCost(int townHallLevel)
		{
			return LogicDataTables.GetTownHallLevel(townHallLevel).GetFriendlyCost();
		}

		// Token: 0x060013BB RID: 5051 RVA: 0x00050100 File Offset: 0x0004E300
		public int GetTroopHousingBuildCostVillage2(LogicLevel level)
		{
			LogicBuildingData buildingByName = LogicDataTables.GetBuildingByName("Troop Housing2", null);
			if (buildingByName != null)
			{
				return this.int_149[LogicMath.Clamp(level.GetGameObjectManagerAt(1).GetGameObjectCountByData(buildingByName), 0, this.int_149.Length - 1)];
			}
			Debugger.Error("Could not find Troop Housing2 data");
			return 0;
		}

		// Token: 0x060013BC RID: 5052 RVA: 0x0005014C File Offset: 0x0004E34C
		public int GetTroopHousingBuildTimeVillage2(LogicLevel level, int ignoreBuildingCnt)
		{
			LogicBuildingData buildingByName = LogicDataTables.GetBuildingByName("Troop Housing2", null);
			if (buildingByName != null)
			{
				return this.int_150[LogicMath.Clamp(level.GetGameObjectManagerAt(1).GetGameObjectCountByData(buildingByName) - ignoreBuildingCnt, 0, this.int_150.Length - 1)];
			}
			Debugger.Error("Could not find Troop Housing2 data");
			return 0;
		}

		// Token: 0x060013BD RID: 5053 RVA: 0x0000D105 File Offset: 0x0000B305
		public int GetClockTowerBoostSecs(int upgLevel)
		{
			if (this.int_154.Length > upgLevel)
			{
				return this.int_154[upgLevel];
			}
			return this.int_154[this.int_154.Length - 1];
		}

		// Token: 0x060013BE RID: 5054 RVA: 0x0000D12C File Offset: 0x0000B32C
		public int GetTutorialTrainingSpeedUpCost()
		{
			return this.int_63;
		}

		// Token: 0x060013BF RID: 5055 RVA: 0x0000D134 File Offset: 0x0000B334
		public int GetHealStackPercent(int idx)
		{
			if (this.int_161.Length != 0)
			{
				if (idx >= this.int_161.Length)
				{
					idx = this.int_161.Length - 1;
				}
				return this.int_161[idx];
			}
			return 100;
		}

		// Token: 0x060013C0 RID: 5056 RVA: 0x0005019C File Offset: 0x0004E39C
		public int GetResourceDiamondCost(int count, LogicResourceData data)
		{
			if (LogicDataTables.GetDarkElixirData() == data)
			{
				return this.GetDarkElixirDiamondCost(count);
			}
			int num;
			int num2;
			int num3;
			int num4;
			int num5;
			int num6;
			if (data.GetVillageType() == 1)
			{
				num = this.int_14;
				num2 = this.int_15;
				num3 = this.int_16;
				num4 = this.int_17;
				num5 = this.int_18;
				num6 = this.int_19;
			}
			else
			{
				num = this.int_8;
				num2 = this.int_9;
				num3 = this.int_10;
				num4 = this.int_11;
				num5 = this.int_12;
				num6 = this.int_13;
			}
			if (count < 1)
			{
				return 0;
			}
			if (count < 100)
			{
				return num;
			}
			if (count < 1000)
			{
				return num + ((num2 - num) * (count - 100) + 450) / 900;
			}
			if (count < 10000)
			{
				return num2 + ((num3 - num2) * (count - 1000) + 4500) / 9000;
			}
			if (count < 100000)
			{
				return num3 + ((num4 - num3) * (count / 10 - 1000) + 4500) / 9000;
			}
			if (count >= 1000000)
			{
				return num5 + ((num6 - num5) * (count / 1000 - 1000) + 4500) / 9000;
			}
			return num4 + ((num5 - num4) * (count / 100 - 1000) + 4500) / 9000;
		}

		// Token: 0x060013C1 RID: 5057 RVA: 0x000502E4 File Offset: 0x0004E4E4
		public int GetDarkElixirDiamondCost(int count)
		{
			if (count < 1)
			{
				return 0;
			}
			if (count < 10)
			{
				return this.int_20 + ((this.int_21 - this.int_20) * (count - 1) + 4) / 9;
			}
			if (count < 100)
			{
				return this.int_21 + ((this.int_22 - this.int_21) * (count - 10) + 45) / 90;
			}
			if (count < 1000)
			{
				return this.int_22 + ((this.int_23 - this.int_22) * (count - 100) + 450) / 900;
			}
			if (count >= 10000)
			{
				return this.int_24 + ((this.int_25 - this.int_24) * (count - 10000) + 45000) / 90000;
			}
			return this.int_23 + ((this.int_24 - this.int_23) * (count - 1000) + 4500) / 9000;
		}

		// Token: 0x060013C2 RID: 5058 RVA: 0x000503D0 File Offset: 0x0004E5D0
		public int GetSpeedUpCost(int time, int multiplier, int villageType)
		{
			if (time > 0)
			{
				int num;
				int num2;
				int num3;
				int num4;
				if (villageType == 1)
				{
					num = this.int_4;
					num2 = this.int_5;
					num3 = this.int_6;
					num4 = this.int_7;
				}
				else
				{
					num = this.int_0;
					num2 = this.int_1;
					num3 = this.int_2;
					num4 = this.int_3;
				}
				int num5 = multiplier;
				int num6 = 100;
				if (this.bool_15)
				{
					num5 = 100;
					num6 = multiplier;
				}
				int num7 = num;
				if (time >= 60)
				{
					if (time >= 3600)
					{
						if (time >= 86400)
						{
							int num8 = (num4 - num3) * (time - 86400);
							num7 = num6 * num3 / 100 + num8 / 100 * num6 / 518400;
							if (num7 < 0 || num8 / 100 > 2147483647 / num6)
							{
								num7 = num6 * (num3 + num8 / 518400) / 100;
							}
						}
						else
						{
							num7 = num6 * num2 / 100 + (num3 - num2) * (time - 3600) / 100 * num6 / 82800;
						}
					}
					else
					{
						num7 = num6 * num / 100 + (num2 - num) * (time - 60) * num6 / 354000;
					}
				}
				else if (this.bool_15)
				{
					num7 = num6 * num * time / 6000;
				}
				return LogicMath.Max(num7 * num5 / 100, 1);
			}
			return 0;
		}

		// Token: 0x060013C3 RID: 5059 RVA: 0x00050508 File Offset: 0x0004E708
		public int GetLeagueBonusPercentage(int destructionPercentage)
		{
			if (this.int_156.Length != 0 && this.int_157.Length != 0)
			{
				int i = 0;
				int num = 0;
				int num2 = 0;
				while (i < this.int_156.Length)
				{
					if (this.int_156[i] >= destructionPercentage)
					{
						return num2 + (this.int_157[i] - num2) * (destructionPercentage - num) / (this.int_156[i] - num);
					}
					num = this.int_156[i];
					num2 = this.int_157[i];
					i++;
				}
			}
			return 100;
		}

		// Token: 0x060013C4 RID: 5060 RVA: 0x0000D161 File Offset: 0x0000B361
		public int GetAllianceScoreLimit(int idx)
		{
			return this.int_155[idx];
		}

		// Token: 0x060013C5 RID: 5061 RVA: 0x0000D16B File Offset: 0x0000B36B
		public int GetAllianceScoreLimitCount()
		{
			return this.int_155.Length;
		}

		// Token: 0x060013C6 RID: 5062 RVA: 0x0005057C File Offset: 0x0004E77C
		public int GetDestructionToShield(int destructionPercentage)
		{
			int result = 0;
			for (int i = 0; i < this.int_158.Length; i++)
			{
				if (this.int_158[i] <= destructionPercentage)
				{
					result = this.int_159[i];
				}
			}
			return result;
		}

		// Token: 0x060013C7 RID: 5063 RVA: 0x0000D175 File Offset: 0x0000B375
		public int GetAttackShieldReduceHours(int idx)
		{
			if (idx >= this.int_160.Length)
			{
				idx = this.int_160.Length - 1;
			}
			return this.int_160[idx];
		}

		// Token: 0x0400092A RID: 2346
		private int int_0;

		// Token: 0x0400092B RID: 2347
		private int int_1;

		// Token: 0x0400092C RID: 2348
		private int int_2;

		// Token: 0x0400092D RID: 2349
		private int int_3;

		// Token: 0x0400092E RID: 2350
		private int int_4;

		// Token: 0x0400092F RID: 2351
		private int int_5;

		// Token: 0x04000930 RID: 2352
		private int int_6;

		// Token: 0x04000931 RID: 2353
		private int int_7;

		// Token: 0x04000932 RID: 2354
		private int int_8;

		// Token: 0x04000933 RID: 2355
		private int int_9;

		// Token: 0x04000934 RID: 2356
		private int int_10;

		// Token: 0x04000935 RID: 2357
		private int int_11;

		// Token: 0x04000936 RID: 2358
		private int int_12;

		// Token: 0x04000937 RID: 2359
		private int int_13;

		// Token: 0x04000938 RID: 2360
		private int int_14;

		// Token: 0x04000939 RID: 2361
		private int int_15;

		// Token: 0x0400093A RID: 2362
		private int int_16;

		// Token: 0x0400093B RID: 2363
		private int int_17;

		// Token: 0x0400093C RID: 2364
		private int int_18;

		// Token: 0x0400093D RID: 2365
		private int int_19;

		// Token: 0x0400093E RID: 2366
		private int int_20;

		// Token: 0x0400093F RID: 2367
		private int int_21;

		// Token: 0x04000940 RID: 2368
		private int int_22;

		// Token: 0x04000941 RID: 2369
		private int int_23;

		// Token: 0x04000942 RID: 2370
		private int int_24;

		// Token: 0x04000943 RID: 2371
		private int int_25;

		// Token: 0x04000944 RID: 2372
		private int int_26;

		// Token: 0x04000945 RID: 2373
		private int int_27;

		// Token: 0x04000946 RID: 2374
		private int int_28;

		// Token: 0x04000947 RID: 2375
		private int int_29;

		// Token: 0x04000948 RID: 2376
		private int int_30;

		// Token: 0x04000949 RID: 2377
		private int int_31;

		// Token: 0x0400094A RID: 2378
		private int int_32;

		// Token: 0x0400094B RID: 2379
		private int int_33;

		// Token: 0x0400094C RID: 2380
		private int int_34;

		// Token: 0x0400094D RID: 2381
		private int int_35;

		// Token: 0x0400094E RID: 2382
		private int int_36;

		// Token: 0x0400094F RID: 2383
		private int int_37;

		// Token: 0x04000950 RID: 2384
		private int int_38;

		// Token: 0x04000951 RID: 2385
		private int int_39;

		// Token: 0x04000952 RID: 2386
		private int int_40;

		// Token: 0x04000953 RID: 2387
		private int int_41;

		// Token: 0x04000954 RID: 2388
		private int int_42;

		// Token: 0x04000955 RID: 2389
		private int int_43;

		// Token: 0x04000956 RID: 2390
		private int int_44;

		// Token: 0x04000957 RID: 2391
		private int int_45;

		// Token: 0x04000958 RID: 2392
		private int int_46;

		// Token: 0x04000959 RID: 2393
		private int int_47;

		// Token: 0x0400095A RID: 2394
		private int int_48;

		// Token: 0x0400095B RID: 2395
		private int int_49;

		// Token: 0x0400095C RID: 2396
		private int int_50;

		// Token: 0x0400095D RID: 2397
		private int int_51;

		// Token: 0x0400095E RID: 2398
		private int int_52;

		// Token: 0x0400095F RID: 2399
		private int int_53;

		// Token: 0x04000960 RID: 2400
		private int int_54;

		// Token: 0x04000961 RID: 2401
		private int int_55;

		// Token: 0x04000962 RID: 2402
		private int int_56;

		// Token: 0x04000963 RID: 2403
		private int int_57;

		// Token: 0x04000964 RID: 2404
		private int int_58;

		// Token: 0x04000965 RID: 2405
		private int int_59;

		// Token: 0x04000966 RID: 2406
		private int int_60;

		// Token: 0x04000967 RID: 2407
		private int int_61;

		// Token: 0x04000968 RID: 2408
		private int int_62;

		// Token: 0x04000969 RID: 2409
		private int int_63;

		// Token: 0x0400096A RID: 2410
		private int int_64;

		// Token: 0x0400096B RID: 2411
		private int int_65;

		// Token: 0x0400096C RID: 2412
		private int int_66;

		// Token: 0x0400096D RID: 2413
		private int int_67;

		// Token: 0x0400096E RID: 2414
		private int int_68;

		// Token: 0x0400096F RID: 2415
		private int int_69;

		// Token: 0x04000970 RID: 2416
		private int int_70;

		// Token: 0x04000971 RID: 2417
		private int int_71;

		// Token: 0x04000972 RID: 2418
		private int int_72;

		// Token: 0x04000973 RID: 2419
		private int int_73;

		// Token: 0x04000974 RID: 2420
		private int int_74;

		// Token: 0x04000975 RID: 2421
		private int int_75;

		// Token: 0x04000976 RID: 2422
		private int int_76;

		// Token: 0x04000977 RID: 2423
		private int int_77;

		// Token: 0x04000978 RID: 2424
		private int int_78;

		// Token: 0x04000979 RID: 2425
		private int int_79;

		// Token: 0x0400097A RID: 2426
		private int int_80;

		// Token: 0x0400097B RID: 2427
		private int int_81;

		// Token: 0x0400097C RID: 2428
		private int int_82;

		// Token: 0x0400097D RID: 2429
		private int int_83;

		// Token: 0x0400097E RID: 2430
		private int int_84;

		// Token: 0x0400097F RID: 2431
		private int int_85;

		// Token: 0x04000980 RID: 2432
		private int int_86;

		// Token: 0x04000981 RID: 2433
		private int int_87;

		// Token: 0x04000982 RID: 2434
		private int int_88;

		// Token: 0x04000983 RID: 2435
		private int int_89;

		// Token: 0x04000984 RID: 2436
		private int int_90;

		// Token: 0x04000985 RID: 2437
		private int int_91;

		// Token: 0x04000986 RID: 2438
		private int int_92;

		// Token: 0x04000987 RID: 2439
		private int int_93;

		// Token: 0x04000988 RID: 2440
		private int int_94;

		// Token: 0x04000989 RID: 2441
		private int int_95;

		// Token: 0x0400098A RID: 2442
		private int int_96;

		// Token: 0x0400098B RID: 2443
		private int int_97;

		// Token: 0x0400098C RID: 2444
		private int int_98;

		// Token: 0x0400098D RID: 2445
		private int int_99;

		// Token: 0x0400098E RID: 2446
		private int int_100;

		// Token: 0x0400098F RID: 2447
		private int int_101;

		// Token: 0x04000990 RID: 2448
		private int int_102;

		// Token: 0x04000991 RID: 2449
		private int int_103;

		// Token: 0x04000992 RID: 2450
		private int int_104;

		// Token: 0x04000993 RID: 2451
		private int int_105;

		// Token: 0x04000994 RID: 2452
		private int int_106;

		// Token: 0x04000995 RID: 2453
		private int int_107;

		// Token: 0x04000996 RID: 2454
		private int int_108;

		// Token: 0x04000997 RID: 2455
		private int int_109;

		// Token: 0x04000998 RID: 2456
		private int int_110;

		// Token: 0x04000999 RID: 2457
		private int int_111;

		// Token: 0x0400099A RID: 2458
		private int int_112;

		// Token: 0x0400099B RID: 2459
		private int int_113;

		// Token: 0x0400099C RID: 2460
		private int int_114;

		// Token: 0x0400099D RID: 2461
		private int int_115;

		// Token: 0x0400099E RID: 2462
		private int int_116;

		// Token: 0x0400099F RID: 2463
		private int int_117;

		// Token: 0x040009A0 RID: 2464
		private int int_118;

		// Token: 0x040009A1 RID: 2465
		private int int_119;

		// Token: 0x040009A2 RID: 2466
		private int int_120;

		// Token: 0x040009A3 RID: 2467
		private int int_121;

		// Token: 0x040009A4 RID: 2468
		private int int_122;

		// Token: 0x040009A5 RID: 2469
		private int int_123;

		// Token: 0x040009A6 RID: 2470
		private int int_124;

		// Token: 0x040009A7 RID: 2471
		private int int_125;

		// Token: 0x040009A8 RID: 2472
		private int int_126;

		// Token: 0x040009A9 RID: 2473
		private int int_127;

		// Token: 0x040009AA RID: 2474
		private int int_128;

		// Token: 0x040009AB RID: 2475
		private int int_129;

		// Token: 0x040009AC RID: 2476
		private int int_130;

		// Token: 0x040009AD RID: 2477
		private int int_131;

		// Token: 0x040009AE RID: 2478
		private int int_132;

		// Token: 0x040009AF RID: 2479
		private int int_133;

		// Token: 0x040009B0 RID: 2480
		private int int_134;

		// Token: 0x040009B1 RID: 2481
		private int int_135;

		// Token: 0x040009B2 RID: 2482
		private int int_136;

		// Token: 0x040009B3 RID: 2483
		private int int_137;

		// Token: 0x040009B4 RID: 2484
		private int int_138;

		// Token: 0x040009B5 RID: 2485
		private int int_139;

		// Token: 0x040009B6 RID: 2486
		private int int_140;

		// Token: 0x040009B7 RID: 2487
		private int int_141;

		// Token: 0x040009B8 RID: 2488
		private int int_142;

		// Token: 0x040009B9 RID: 2489
		private int int_143;

		// Token: 0x040009BA RID: 2490
		private int int_144;

		// Token: 0x040009BB RID: 2491
		private int int_145;

		// Token: 0x040009BC RID: 2492
		private int int_146;

		// Token: 0x040009BD RID: 2493
		private int int_147;

		// Token: 0x040009BE RID: 2494
		private int int_148;

		// Token: 0x040009BF RID: 2495
		private bool bool_2;

		// Token: 0x040009C0 RID: 2496
		private bool bool_3;

		// Token: 0x040009C1 RID: 2497
		private bool bool_4;

		// Token: 0x040009C2 RID: 2498
		private bool bool_5;

		// Token: 0x040009C3 RID: 2499
		private bool bool_6;

		// Token: 0x040009C4 RID: 2500
		private bool bool_7;

		// Token: 0x040009C5 RID: 2501
		private bool bool_8;

		// Token: 0x040009C6 RID: 2502
		private bool bool_9;

		// Token: 0x040009C7 RID: 2503
		private bool bool_10;

		// Token: 0x040009C8 RID: 2504
		private bool bool_11;

		// Token: 0x040009C9 RID: 2505
		private bool bool_12;

		// Token: 0x040009CA RID: 2506
		private bool bool_13;

		// Token: 0x040009CB RID: 2507
		private bool bool_14;

		// Token: 0x040009CC RID: 2508
		private bool bool_15;

		// Token: 0x040009CD RID: 2509
		private bool bool_16;

		// Token: 0x040009CE RID: 2510
		private bool bool_17;

		// Token: 0x040009CF RID: 2511
		private bool bool_18;

		// Token: 0x040009D0 RID: 2512
		private bool bool_19;

		// Token: 0x040009D1 RID: 2513
		private bool bool_20;

		// Token: 0x040009D2 RID: 2514
		private bool bool_21;

		// Token: 0x040009D3 RID: 2515
		private bool bool_22;

		// Token: 0x040009D4 RID: 2516
		private bool bool_23;

		// Token: 0x040009D5 RID: 2517
		private bool bool_24;

		// Token: 0x040009D6 RID: 2518
		private bool bool_25;

		// Token: 0x040009D7 RID: 2519
		private bool bool_26;

		// Token: 0x040009D8 RID: 2520
		private bool bool_27;

		// Token: 0x040009D9 RID: 2521
		private bool bool_28;

		// Token: 0x040009DA RID: 2522
		private bool bool_29;

		// Token: 0x040009DB RID: 2523
		private bool bool_30;

		// Token: 0x040009DC RID: 2524
		private bool bool_31;

		// Token: 0x040009DD RID: 2525
		private bool bool_32;

		// Token: 0x040009DE RID: 2526
		private bool bool_33;

		// Token: 0x040009DF RID: 2527
		private bool bool_34;

		// Token: 0x040009E0 RID: 2528
		private bool bool_35;

		// Token: 0x040009E1 RID: 2529
		private bool bool_36;

		// Token: 0x040009E2 RID: 2530
		private bool bool_37;

		// Token: 0x040009E3 RID: 2531
		private bool bool_38;

		// Token: 0x040009E4 RID: 2532
		private bool bool_39;

		// Token: 0x040009E5 RID: 2533
		private bool bool_40;

		// Token: 0x040009E6 RID: 2534
		private bool bool_41;

		// Token: 0x040009E7 RID: 2535
		private bool bool_42;

		// Token: 0x040009E8 RID: 2536
		private bool bool_43;

		// Token: 0x040009E9 RID: 2537
		private bool bool_44;

		// Token: 0x040009EA RID: 2538
		private bool bool_45;

		// Token: 0x040009EB RID: 2539
		private bool bool_46;

		// Token: 0x040009EC RID: 2540
		private bool bool_47;

		// Token: 0x040009ED RID: 2541
		private bool bool_48;

		// Token: 0x040009EE RID: 2542
		private bool bool_49;

		// Token: 0x040009EF RID: 2543
		private bool bool_50;

		// Token: 0x040009F0 RID: 2544
		private bool bool_51;

		// Token: 0x040009F1 RID: 2545
		private bool bool_52;

		// Token: 0x040009F2 RID: 2546
		private bool bool_53;

		// Token: 0x040009F3 RID: 2547
		private bool bool_54;

		// Token: 0x040009F4 RID: 2548
		private bool bool_55;

		// Token: 0x040009F5 RID: 2549
		private bool bool_56;

		// Token: 0x040009F6 RID: 2550
		private bool bool_57;

		// Token: 0x040009F7 RID: 2551
		private bool bool_58;

		// Token: 0x040009F8 RID: 2552
		private bool bool_59;

		// Token: 0x040009F9 RID: 2553
		private bool bool_60;

		// Token: 0x040009FA RID: 2554
		private bool bool_61;

		// Token: 0x040009FB RID: 2555
		private bool bool_62;

		// Token: 0x040009FC RID: 2556
		private bool bool_63;

		// Token: 0x040009FD RID: 2557
		private bool bool_64;

		// Token: 0x040009FE RID: 2558
		private bool bool_65;

		// Token: 0x040009FF RID: 2559
		private bool bool_66;

		// Token: 0x04000A00 RID: 2560
		private bool bool_67;

		// Token: 0x04000A01 RID: 2561
		private bool bool_68;

		// Token: 0x04000A02 RID: 2562
		private bool bool_69;

		// Token: 0x04000A03 RID: 2563
		private bool bool_70;

		// Token: 0x04000A04 RID: 2564
		private bool bool_71;

		// Token: 0x04000A05 RID: 2565
		private bool bool_72;

		// Token: 0x04000A06 RID: 2566
		private bool bool_73;

		// Token: 0x04000A07 RID: 2567
		private bool bool_74;

		// Token: 0x04000A08 RID: 2568
		private bool bool_75;

		// Token: 0x04000A09 RID: 2569
		private bool bool_76;

		// Token: 0x04000A0A RID: 2570
		private bool bool_77;

		// Token: 0x04000A0B RID: 2571
		private bool bool_78;

		// Token: 0x04000A0C RID: 2572
		private int[] int_149;

		// Token: 0x04000A0D RID: 2573
		private int[] int_150;

		// Token: 0x04000A0E RID: 2574
		private int[] int_151;

		// Token: 0x04000A0F RID: 2575
		private int[] int_152;

		// Token: 0x04000A10 RID: 2576
		private int[] int_153;

		// Token: 0x04000A11 RID: 2577
		private int[] int_154;

		// Token: 0x04000A12 RID: 2578
		private int[] int_155;

		// Token: 0x04000A13 RID: 2579
		private int[] int_156;

		// Token: 0x04000A14 RID: 2580
		private int[] int_157;

		// Token: 0x04000A15 RID: 2581
		private int[] int_158;

		// Token: 0x04000A16 RID: 2582
		private int[] int_159;

		// Token: 0x04000A17 RID: 2583
		private int[] int_160;

		// Token: 0x04000A18 RID: 2584
		private int[] int_161;

		// Token: 0x04000A19 RID: 2585
		private LogicResourceData logicResourceData_0;

		// Token: 0x04000A1A RID: 2586
		private LogicCharacterData logicCharacterData_0;
	}
}
