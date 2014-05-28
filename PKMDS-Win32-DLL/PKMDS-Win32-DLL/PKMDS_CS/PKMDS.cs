using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
namespace PKMDS_CS
{
    public class PKMDS
    {
        #region Constants
        private const string PKMDS_WIN32_DLL = "PKMDS-Win32-DLL.dll";
        private const int LANG_ID = 9;
        private const int VERSION_GROUP = 11;
        private const int GENERATION = 5;
        private const int BUFF_SIZE = 955;
        private const int NICKLENGTH = 11;
        private const int OTLENGTH = 8;
        #endregion

        #region Enums
        public enum PKMSpecies
        {
            NOTHING,
            Bulbasaur,
            Ivysaur,
            Venusaur,
            Charmander,
            Charmeleon,
            Charizard,
            Squirtle,
            Wartortle,
            Blastoise,
            Caterpie,
            Metapod,
            Butterfree,
            Weedle,
            Kakuna,
            Beedrill,
            Pidgey,
            Pidgeotto,
            Pidgeot,
            Rattata,
            Raticate,
            Spearow,
            Fearow,
            Ekans,
            Arbok,
            Pikachu,
            Raichu,
            Sandshrew,
            Sandslash,
            Nidoran_f,
            Nidorina,
            Nidoqueen,
            Nidoran_m,
            Nidorino,
            Nidoking,
            Clefairy,
            Clefable,
            Vulpix,
            Ninetales,
            Jigglypuff,
            Wigglytuff,
            Zubat,
            Golbat,
            Oddish,
            Gloom,
            Vileplume,
            Paras,
            Parasect,
            Venonat,
            Venomoth,
            Diglett,
            Dugtrio,
            Meowth,
            Persian,
            Psyduck,
            Golduck,
            Mankey,
            Primeape,
            Growlithe,
            Arcanine,
            Poliwag,
            Poliwhirl,
            Poliwrath,
            Abra,
            Kadabra,
            Alakazam,
            Machop,
            Machoke,
            Machamp,
            Bellsprout,
            Weepinbell,
            Victreebel,
            Tentacool,
            Tentacruel,
            Geodude,
            Graveler,
            Golem,
            Ponyta,
            Rapidash,
            Slowpoke,
            Slowbro,
            Magnemite,
            Magneton,
            Farfetchd,
            Doduo,
            Dodrio,
            Seel,
            Dewgong,
            Grimer,
            Muk,
            Shellder,
            Cloyster,
            Gastly,
            Haunter,
            Gengar,
            Onix,
            Drowzee,
            Hypno,
            Krabby,
            Kingler,
            Voltorb,
            Electrode,
            Exeggcute,
            Exeggutor,
            Cubone,
            Marowak,
            Hitmonlee,
            Hitmonchan,
            Lickitung,
            Koffing,
            Weezing,
            Rhyhorn,
            Rhydon,
            Chansey,
            Tangela,
            Kangaskhan,
            Horsea,
            Seadra,
            Goldeen,
            Seaking,
            Staryu,
            Starmie,
            Mr_Mime,
            Scyther,
            Jynx,
            Electabuzz,
            Magmar,
            Pinsir,
            Tauros,
            Magikarp,
            Gyarados,
            Lapras,
            Ditto,
            Eevee,
            Vaporeon,
            Jolteon,
            Flareon,
            Porygon,
            Omanyte,
            Omastar,
            Kabuto,
            Kabutops,
            Aerodactyl,
            Snorlax,
            Articuno,
            Zapdos,
            Moltres,
            Dratini,
            Dragonair,
            Dragonite,
            Mewtwo,
            Mew,
            Chikorita,
            Bayleef,
            Meganium,
            Cyndaquil,
            Quilava,
            Typhlosion,
            Totodile,
            Croconaw,
            Feraligatr,
            Sentret,
            Furret,
            Hoothoot,
            Noctowl,
            Ledyba,
            Ledian,
            Spinarak,
            Ariados,
            Crobat,
            Chinchou,
            Lanturn,
            Pichu,
            Cleffa,
            Igglybuff,
            Togepi,
            Togetic,
            Natu,
            Xatu,
            Mareep,
            Flaaffy,
            Ampharos,
            Bellossom,
            Marill,
            Azumarill,
            Sudowoodo,
            Politoed,
            Hoppip,
            Skiploom,
            Jumpluff,
            Aipom,
            Sunkern,
            Sunflora,
            Yanma,
            Wooper,
            Quagsire,
            Espeon,
            Umbreon,
            Murkrow,
            Slowking,
            Misdreavus,
            Unown,
            Wobbuffet,
            Girafarig,
            Pineco,
            Forretress,
            Dunsparce,
            Gligar,
            Steelix,
            Snubbull,
            Granbull,
            Qwilfish,
            Scizor,
            Shuckle,
            Heracross,
            Sneasel,
            Teddiursa,
            Ursaring,
            Slugma,
            Magcargo,
            Swinub,
            Piloswine,
            Corsola,
            Remoraid,
            Octillery,
            Delibird,
            Mantine,
            Skarmory,
            Houndour,
            Houndoom,
            Kingdra,
            Phanpy,
            Donphan,
            Porygon2,
            Stantler,
            Smeargle,
            Tyrogue,
            Hitmontop,
            Smoochum,
            Elekid,
            Magby,
            Miltank,
            Blissey,
            Raikou,
            Entei,
            Suicune,
            Larvitar,
            Pupitar,
            Tyranitar,
            Lugia,
            Ho_Oh,
            Celebi,
            Treecko,
            Grovyle,
            Sceptile,
            Torchic,
            Combusken,
            Blaziken,
            Mudkip,
            Marshtomp,
            Swampert,
            Poochyena,
            Mightyena,
            Zigzagoon,
            Linoone,
            Wurmple,
            Silcoon,
            Beautifly,
            Cascoon,
            Dustox,
            Lotad,
            Lombre,
            Ludicolo,
            Seedot,
            Nuzleaf,
            Shiftry,
            Taillow,
            Swellow,
            Wingull,
            Pelipper,
            Ralts,
            Kirlia,
            Gardevoir,
            Surskit,
            Masquerain,
            Shroomish,
            Breloom,
            Slakoth,
            Vigoroth,
            Slaking,
            Nincada,
            Ninjask,
            Shedinja,
            Whismur,
            Loudred,
            Exploud,
            Makuhita,
            Hariyama,
            Azurill,
            Nosepass,
            Skitty,
            Delcatty,
            Sableye,
            Mawile,
            Aron,
            Lairon,
            Aggron,
            Meditite,
            Medicham,
            Electrike,
            Manectric,
            Plusle,
            Minun,
            Volbeat,
            Illumise,
            Roselia,
            Gulpin,
            Swalot,
            Carvanha,
            Sharpedo,
            Wailmer,
            Wailord,
            Numel,
            Camerupt,
            Torkoal,
            Spoink,
            Grumpig,
            Spinda,
            Trapinch,
            Vibrava,
            Flygon,
            Cacnea,
            Cacturne,
            Swablu,
            Altaria,
            Zangoose,
            Seviper,
            Lunatone,
            Solrock,
            Barboach,
            Whiscash,
            Corphish,
            Crawdaunt,
            Baltoy,
            Claydol,
            Lileep,
            Cradily,
            Anorith,
            Armaldo,
            Feebas,
            Milotic,
            Castform,
            Kecleon,
            Shuppet,
            Banette,
            Duskull,
            Dusclops,
            Tropius,
            Chimecho,
            Absol,
            Wynaut,
            Snorunt,
            Glalie,
            Spheal,
            Sealeo,
            Walrein,
            Clamperl,
            Huntail,
            Gorebyss,
            Relicanth,
            Luvdisc,
            Bagon,
            Shelgon,
            Salamence,
            Beldum,
            Metang,
            Metagross,
            Regirock,
            Regice,
            Registeel,
            Latias,
            Latios,
            Kyogre,
            Groudon,
            Rayquaza,
            Jirachi,
            Deoxys,
            Turtwig,
            Grotle,
            Torterra,
            Chimchar,
            Monferno,
            Infernape,
            Piplup,
            Prinplup,
            Empoleon,
            Starly,
            Staravia,
            Staraptor,
            Bidoof,
            Bibarel,
            Kricketot,
            Kricketune,
            Shinx,
            Luxio,
            Luxray,
            Budew,
            Roserade,
            Cranidos,
            Rampardos,
            Shieldon,
            Bastiodon,
            Burmy,
            Wormadam,
            Mothim,
            Combee,
            Vespiquen,
            Pachirisu,
            Buizel,
            Floatzel,
            Cherubi,
            Cherrim,
            Shellos,
            Gastrodon,
            Ambipom,
            Drifloon,
            Drifblim,
            Buneary,
            Lopunny,
            Mismagius,
            Honchkrow,
            Glameow,
            Purugly,
            Chingling,
            Stunky,
            Skuntank,
            Bronzor,
            Bronzong,
            Bonsly,
            Mime_Jr,
            Happiny,
            Chatot,
            Spiritomb,
            Gible,
            Gabite,
            Garchomp,
            Munchlax,
            Riolu,
            Lucario,
            Hippopotas,
            Hippowdon,
            Skorupi,
            Drapion,
            Croagunk,
            Toxicroak,
            Carnivine,
            Finneon,
            Lumineon,
            Mantyke,
            Snover,
            Abomasnow,
            Weavile,
            Magnezone,
            Lickilicky,
            Rhyperior,
            Tangrowth,
            Electivire,
            Magmortar,
            Togekiss,
            Yanmega,
            Leafeon,
            Glaceon,
            Gliscor,
            Mamoswine,
            Porygon_Z,
            Gallade,
            Probopass,
            Dusknoir,
            Froslass,
            Rotom,
            Uxie,
            Mesprit,
            Azelf,
            Dialga,
            Palkia,
            Heatran,
            Regigigas,
            Giratina,
            Cresselia,
            Phione,
            Manaphy,
            Darkrai,
            Shaymin,
            Arceus,
            Victini,
            Snivy,
            Servine,
            Serperior,
            Tepig,
            Pignite,
            Emboar,
            Oshawott,
            Dewott,
            Samurott,
            Patrat,
            Watchog,
            Lillipup,
            Herdier,
            Stoutland,
            Purrloin,
            Liepard,
            Pansage,
            Simisage,
            Pansear,
            Simisear,
            Panpour,
            Simipour,
            Munna,
            Musharna,
            Pidove,
            Tranquill,
            Unfezant,
            Blitzle,
            Zebstrika,
            Roggenrola,
            Boldore,
            Gigalith,
            Woobat,
            Swoobat,
            Drilbur,
            Excadrill,
            Audino,
            Timburr,
            Gurdurr,
            Conkeldurr,
            Tympole,
            Palpitoad,
            Seismitoad,
            Throh,
            Sawk,
            Sewaddle,
            Swadloon,
            Leavanny,
            Venipede,
            Whirlipede,
            Scolipede,
            Cottonee,
            Whimsicott,
            Petilil,
            Lilligant,
            Basculin,
            Sandile,
            Krokorok,
            Krookodile,
            Darumaka,
            Darmanitan,
            Maractus,
            Dwebble,
            Crustle,
            Scraggy,
            Scrafty,
            Sigilyph,
            Yamask,
            Cofagrigus,
            Tirtouga,
            Carracosta,
            Archen,
            Archeops,
            Trubbish,
            Garbodor,
            Zorua,
            Zoroark,
            Minccino,
            Cinccino,
            Gothita,
            Gothorita,
            Gothitelle,
            Solosis,
            Duosion,
            Reuniclus,
            Ducklett,
            Swanna,
            Vanillite,
            Vanillish,
            Vanilluxe,
            Deerling,
            Sawsbuck,
            Emolga,
            Karrablast,
            Escavalier,
            Foongus,
            Amoonguss,
            Frillish,
            Jellicent,
            Alomomola,
            Joltik,
            Galvantula,
            Ferroseed,
            Ferrothorn,
            Klink,
            Klang,
            Klinklang,
            Tynamo,
            Eelektrik,
            Eelektross,
            Elgyem,
            Beheeyem,
            Litwick,
            Lampent,
            Chandelure,
            Axew,
            Fraxure,
            Haxorus,
            Cubchoo,
            Beartic,
            Cryogonal,
            Shelmet,
            Accelgor,
            Stunfisk,
            Mienfoo,
            Mienshao,
            Druddigon,
            Golett,
            Golurk,
            Pawniard,
            Bisharp,
            Bouffalant,
            Rufflet,
            Braviary,
            Vullaby,
            Mandibuzz,
            Heatmor,
            Durant,
            Deino,
            Zweilous,
            Hydreigon,
            Larvesta,
            Volcarona,
            Cobalion,
            Terrakion,
            Virizion,
            Tornadus,
            Thundurus,
            Reshiram,
            Zekrom,
            Landorus,
            Kyurem,
            Keldeo,
            Meloetta,
            Genesect
        }
        public enum Moves
        {
            Pound,
            Karate_Chop,
            DoubleSlap,
            Comet_Punch,
            Mega_Punch,
            Pay_Day,
            Fire_Punch,
            Ice_Punch,
            ThunderPunch,
            Scratch,
            ViceGrip,
            Guillotine,
            Razor_Wind,
            Swords_Dance,
            Cut,
            Gust,
            Wing_Attack,
            Whirlwind,
            Fly,
            Bind,
            Slam,
            Vine_Whip,
            Stomp,
            Double_Kick,
            Mega_Kick,
            Jump_Kick,
            Rolling_Kick,
            Sand_Attack,
            Headbutt,
            Horn_Attack,
            Fury_Attack,
            Horn_Drill,
            Tackle,
            Body_Slam,
            Wrap,
            Take_Down,
            Thrash,
            Double_Edge,
            Tail_Whip,
            Poison_Sting,
            Twineedle,
            Pin_Missile,
            Leer,
            Bite,
            Growl,
            Roar,
            Sing,
            Supersonic,
            SonicBoom,
            Disable,
            Acid,
            Ember,
            Flamethrower,
            Mist,
            Water_Gun,
            Hydro_Pump,
            Surf,
            Ice_Beam,
            Blizzard,
            Psybeam,
            BubbleBeam,
            Aurora_Beam,
            Hyper_Beam,
            Peck,
            Drill_Peck,
            Submission,
            Low_Kick,
            Counter,
            Seismic_Toss,
            Strength,
            Absorb,
            Mega_Drain,
            Leech_Seed,
            Growth,
            Razor_Leaf,
            SolarBeam,
            PoisonPowder,
            Stun_Spore,
            Sleep_Powder,
            Petal_Dance,
            String_Shot,
            Dragon_Rage,
            Fire_Spin,
            ThunderShock,
            Thunderbolt,
            Thunder_Wave,
            Thunder,
            Rock_Throw,
            Earthquake,
            Fissure,
            Dig,
            Toxic,
            Confusion,
            Psychic,
            Hypnosis,
            Meditate,
            Agility,
            Quick_Attack,
            Rage,
            Teleport,
            Night_Shade,
            Mimic,
            Screech,
            Double_Team,
            Recover,
            Harden,
            Minimize,
            SmokeScreen,
            Confuse_Ray,
            Withdraw,
            Defense_Curl,
            Barrier,
            Light_Screen,
            Haze,
            Reflect,
            Focus_Energy,
            Bide,
            Metronome,
            Mirror_Move,
            Selfdestruct,
            Egg_Bomb,
            Lick,
            Smog,
            Sludge,
            Bone_Club,
            Fire_Blast,
            Waterfall,
            Clamp,
            Swift,
            Skull_Bash,
            Spike_Cannon,
            Constrict,
            Amnesia,
            Kinesis,
            Softboiled,
            Hi_Jump_Kick,
            Glare,
            Dream_Eater,
            Poison_Gas,
            Barrage,
            Leech_Life,
            Lovely_Kiss,
            Sky_Attack,
            Transform,
            Bubble,
            Dizzy_Punch,
            Spore,
            Flash,
            Psywave,
            Splash,
            Acid_Armor,
            Crabhammer,
            Explosion,
            Fury_Swipes,
            Bonemerang,
            Rest,
            Rock_Slide,
            Hyper_Fang,
            Sharpen,
            Conversion,
            Tri_Attack,
            Super_Fang,
            Slash,
            Substitute,
            Struggle,
            Sketch,
            Triple_Kick,
            Thief,
            Spider_Web,
            Mind_Reader,
            Nightmare,
            Flame_Wheel,
            Snore,
            Curse,
            Flail,
            Conversion_2,
            Aeroblast,
            Cotton_Spore,
            Reversal,
            Spite,
            Powder_Snow,
            Protect,
            Mach_Punch,
            Scary_Face,
            Faint_Attack,
            Sweet_Kiss,
            Belly_Drum,
            Sludge_Bomb,
            Mud_Slap,
            Octazooka,
            Spikes,
            Zap_Cannon,
            Foresight,
            Destiny_Bond,
            Perish_Song,
            Icy_Wind,
            Detect,
            Bone_Rush,
            Lock_On,
            Outrage,
            Sandstorm,
            Giga_Drain,
            Endure,
            Charm,
            Rollout,
            False_Swipe,
            Swagger,
            Milk_Drink,
            Spark,
            Fury_Cutter,
            Steel_Wing,
            Mean_Look,
            Attract,
            Sleep_Talk,
            Heal_Bell,
            Return,
            Present,
            Frustration,
            Safeguard,
            Pain_Split,
            Sacred_Fire,
            Magnitude,
            DynamicPunch,
            Megahorn,
            DragonBreath,
            Baton_Pass,
            Encore,
            Pursuit,
            Rapid_Spin,
            Sweet_Scent,
            Iron_Tail,
            Metal_Claw,
            Vital_Throw,
            Morning_Sun,
            Synthesis,
            Moonlight,
            Hidden_Power,
            Cross_Chop,
            Twister,
            Rain_Dance,
            Sunny_Day,
            Crunch,
            Mirror_Coat,
            Psych_Up,
            ExtremeSpeed,
            AncientPower,
            Shadow_Ball,
            Future_Sight,
            Rock_Smash,
            Whirlpool,
            Beat_Up,
            Fake_Out,
            Uproar,
            Stockpile,
            Spit_Up,
            Swallow,
            Heat_Wave,
            Hail,
            Torment,
            Flatter,
            Will_O_Wisp,
            Memento,
            Facade,
            Focus_Punch,
            SmellingSalt,
            Follow_Me,
            Nature_Power,
            Charge,
            Taunt,
            Helping_Hand,
            Trick,
            Role_Play,
            Wish,
            Assist,
            Ingrain,
            Superpower,
            Magic_Coat,
            Recycle,
            Revenge,
            Brick_Break,
            Yawn,
            Knock_Off,
            Endeavor,
            Eruption,
            Skill_Swap,
            Imprison,
            Refresh,
            Grudge,
            Snatch,
            Secret_Power,
            Dive,
            Arm_Thrust,
            Camouflage,
            Tail_Glow,
            Luster_Purge,
            Mist_Ball,
            FeatherDance,
            Teeter_Dance,
            Blaze_Kick,
            Mud_Sport,
            Ice_Ball,
            Needle_Arm,
            Slack_Off,
            Hyper_Voice,
            Poison_Fang,
            Crush_Claw,
            Blast_Burn,
            Hydro_Cannon,
            Meteor_Mash,
            Astonish,
            Weather_Ball,
            Aromatherapy,
            Fake_Tears,
            Air_Cutter,
            Overheat,
            Odor_Sleuth,
            Rock_Tomb,
            Silver_Wind,
            Metal_Sound,
            GrassWhistle,
            Tickle,
            Cosmic_Power,
            Water_Spout,
            Signal_Beam,
            Shadow_Punch,
            Extrasensory,
            Sky_Uppercut,
            Sand_Tomb,
            Sheer_Cold,
            Muddy_Water,
            Bullet_Seed,
            Aerial_Ace,
            Icicle_Spear,
            Iron_Defense,
            Block,
            Howl,
            Dragon_Claw,
            Frenzy_Plant,
            Bulk_Up,
            Bounce,
            Mud_Shot,
            Poison_Tail,
            Covet,
            Volt_Tackle,
            Magical_Leaf,
            Water_Sport,
            Calm_Mind,
            Leaf_Blade,
            Dragon_Dance,
            Rock_Blast,
            Shock_Wave,
            Water_Pulse,
            Doom_Desire,
            Psycho_Boost,
            Roost,
            Gravity,
            Miracle_Eye,
            Wake_Up_Slap,
            Hammer_Arm,
            Gyro_Ball,
            Healing_Wish,
            Brine,
            Natural_Gift,
            Feint,
            Pluck,
            Tailwind,
            Acupressure,
            Metal_Burst,
            U_turn,
            Close_Combat,
            Payback,
            Assurance,
            Embargo,
            Fling,
            Psycho_Shift,
            Trump_Card,
            Heal_Block,
            Wring_Out,
            Power_Trick,
            Gastro_Acid,
            Lucky_Chant,
            Me_First,
            Copycat,
            Power_Swap,
            Guard_Swap,
            Punishment,
            Last_Resort,
            Worry_Seed,
            Sucker_Punch,
            Toxic_Spikes,
            Heart_Swap,
            Aqua_Ring,
            Magnet_Rise,
            Flare_Blitz,
            Force_Palm,
            Aura_Sphere,
            Rock_Polish,
            Poison_Jab,
            Dark_Pulse,
            Night_Slash,
            Aqua_Tail,
            Seed_Bomb,
            Air_Slash,
            X_Scissor,
            Bug_Buzz,
            Dragon_Pulse,
            Dragon_Rush,
            Power_Gem,
            Drain_Punch,
            Vacuum_Wave,
            Focus_Blast,
            Energy_Ball,
            Brave_Bird,
            Earth_Power,
            Switcheroo,
            Giga_Impact,
            Nasty_Plot,
            Bullet_Punch,
            Avalanche,
            Ice_Shard,
            Shadow_Claw,
            Thunder_Fang,
            Ice_Fang,
            Fire_Fang,
            Shadow_Sneak,
            Mud_Bomb,
            Psycho_Cut,
            Zen_Headbutt,
            Mirror_Shot,
            Flash_Cannon,
            Rock_Climb,
            Defog,
            Trick_Room,
            Draco_Meteor,
            Discharge,
            Lava_Plume,
            Leaf_Storm,
            Power_Whip,
            Rock_Wrecker,
            Cross_Poison,
            Gunk_Shot,
            Iron_Head,
            Magnet_Bomb,
            Stone_Edge,
            Captivate,
            Stealth_Rock,
            Grass_Knot,
            Chatter,
            Judgment,
            Bug_Bite,
            Charge_Beam,
            Wood_Hammer,
            Aqua_Jet,
            Attack_Order,
            Defend_Order,
            Heal_Order,
            Head_Smash,
            Double_Hit,
            Roar_of_Time,
            Spacial_Rend,
            Lunar_Dance,
            Crush_Grip,
            Magma_Storm,
            Dark_Void,
            Seed_Flare,
            Ominous_Wind,
            Shadow_Force,
            Hone_Claws,
            Wide_Guard,
            Guard_Split,
            Power_Split,
            Wonder_Room,
            Psyshock,
            Venoshock,
            Autotomize,
            Rage_Powder,
            Telekinesis,
            Magic_Room,
            Smack_Down,
            Storm_Throw,
            Flame_Burst,
            Sludge_Wave,
            Quiver_Dance,
            Heavy_Slam,
            Synchronoise,
            Electro_Ball,
            Soak,
            Flame_Charge,
            Coil,
            Low_Sweep,
            Acid_Spray,
            Foul_Play,
            Simple_Beam,
            Entrainment,
            After_You,
            Round,
            Echoed_Voice,
            Chip_Away,
            Clear_Smog,
            Stored_Power,
            Quick_Guard,
            Ally_Switch,
            Scald,
            Shell_Smash,
            Heal_Pulse,
            Hex,
            Sky_Drop,
            Shift_Gear,
            Circle_Throw,
            Incinerate,
            Quash,
            Acrobatics,
            Reflect_Type,
            Retaliate,
            Final_Gambit,
            Bestow,
            Inferno,
            Water_Pledge,
            Fire_Pledge,
            Grass_Pledge,
            Volt_Switch,
            Struggle_Bug,
            Bulldoze,
            Frost_Breath,
            Dragon_Tail,
            Work_Up,
            Electroweb,
            Wild_Charge,
            Drill_Run,
            Dual_Chop,
            Heart_Stamp,
            Horn_Leech,
            Sacred_Sword,
            Razor_Shell,
            Heat_Crash,
            Leaf_Tornado,
            Steamroller,
            Cotton_Guard,
            Night_Daze,
            Psystrike,
            Tail_Slap,
            Hurricane,
            Head_Charge,
            Gear_Grind,
            Searing_Shot,
            Techno_Blast,
            Relic_Song,
            Secret_Sword,
            Glaciate,
            Bolt_Strike,
            Blue_Flare,
            Fiery_Dance,
            Freeze_Shock,
            Ice_Burn,
            Snarl,
            Icicle_Crash,
            V_create,
            Fusion_Flare,
            Fusion_Bolt
        }
        public enum Items
        {
            NOTHING = 0x0000,
            Master_Ball = 0x0001,
            Ultra_Ball = 0x0002,
            Great_Ball = 0x0003,
            Poke_Ball = 0x0004,
            Safari_Ball = 0x0005,
            Net_Ball = 0x0006,
            Dive_Ball = 0x0007,
            Nest_Ball = 0x0008,
            Repeat_Ball = 0x0009,
            Timer_Ball = 0x000A,
            Luxury_Ball = 0x000B,
            Premier_Ball = 0x000C,
            Dusk_Ball = 0x000D,
            Heal_Ball = 0x000E,
            Quick_Ball = 0x000F,
            Cherish_Ball = 0x0010,
            Potion = 0x0011,
            Antidote = 0x0012,
            Burn_Heal = 0x0013,
            Ice_Heal = 0x0014,
            Awakening = 0x0015,
            Parlyz_Heal = 0x0016,
            Full_Restore = 0x0017,
            Max_Potion = 0x0018,
            Hyper_Potion = 0x0019,
            Super_Potion = 0x001A,
            Full_Heal = 0x001B,
            Revive = 0x001C,
            Max_Revive = 0x001D,
            Fresh_Water = 0x001E,
            Soda_Pop = 0x001F,
            Lemonade = 0x0020,
            Moomoo_Milk = 0x0021,
            EnergyPowder = 0x0022,
            Energy_Root = 0x0023,
            Heal_Powder = 0x0024,
            Revival_Herb = 0x0025,
            Ether = 0x0026,
            Max_Ether = 0x0027,
            Elixir = 0x0028,
            Max_Elixir = 0x0029,
            Lava_Cookie = 0x002A,
            Berry_Juice = 0x002B,
            Sacred_Ash = 0x002C,
            HP_Up = 0x002D,
            Protein = 0x002E,
            Iron = 0x002F,
            Carbos = 0x0030,
            Calcium = 0x0031,
            Rare_Candy = 0x0032,
            PP_Up = 0x0033,
            Zinc = 0x0034,
            PP_Max = 0x0035,
            Old_Gateau = 0x0036,
            Guard_Spec = 0x0037,
            Dire_Hit = 0x0038,
            X_Attack = 0x0039,
            X_Defend = 0x003A,
            X_Speed = 0x003B,
            X_Accuracy = 0x003C,
            X_Special = 0x003D,
            X_Sp_Def = 0x003E,
            Poke_Doll = 0x003F,
            Fluffy_Tail = 0x0040,
            Blue_Flute = 0x0041,
            Yellow_Flute = 0x0042,
            Red_Flute = 0x0043,
            Black_Flute = 0x0044,
            White_Flute = 0x0045,
            Shoal_Salt = 0x0046,
            Shoal_Shell = 0x0047,
            Red_Shard = 0x0048,
            Blue_Shard = 0x0049,
            Yellow_Shard = 0x004A,
            Green_Shard = 0x004B,
            Super_Repel = 0x004C,
            Max_Repel = 0x004D,
            Escape_Rope = 0x004E,
            Repel = 0x004F,
            Sun_Stone = 0x0050,
            Moon_Stone = 0x0051,
            Fire_Stone = 0x0052,
            Thunderstone = 0x0053,
            Water_Stone = 0x0054,
            Leaf_Stone = 0x0055,
            TinyMushroom = 0x0056,
            Big_Mushroom = 0x0057,
            Pearl = 0x0058,
            Big_Pearl = 0x0059,
            Stardust = 0x005A,
            Star_Piece = 0x005B,
            Nugget = 0x005C,
            Heart_Scale = 0x005D,
            Honey = 0x005E,
            Growth_Mulch = 0x005F,
            Damp_Mulch = 0x0060,
            Stable_Mulch = 0x0061,
            Gooey_Mulch = 0x0062,
            Root_Fossil = 0x0063,
            Claw_Fossil = 0x0064,
            Helix_Fossil = 0x0065,
            Dome_Fossil = 0x0066,
            Old_Amber = 0x0067,
            Armor_Fossil = 0x0068,
            Skull_Fossil = 0x0069,
            Rare_Bone = 0x006A,
            Shiny_Stone = 0x006B,
            Dusk_Stone = 0x006C,
            Dawn_Stone = 0x006D,
            Oval_Stone = 0x006E,
            Odd_Keystone = 0x006F,
            Adamant_Orb = 0x0087,
            Lustrous_Orb = 0x0088,
            Cheri_Berry = 0x0095,
            Chesto_Berry = 0x0096,
            Pecha_Berry = 0x0097,
            Rawst_Berry = 0x0098,
            Aspear_Berry = 0x0099,
            Leppa_Berry = 0x009A,
            Oran_Berry = 0x009B,
            Persim_Berry = 0x009C,
            Lum_Berry = 0x009D,
            Sitrus_Berry = 0x009E,
            Figy_Berry = 0x009F,
            Wiki_Berry = 0x00A0,
            Mago_Berry = 0x00A1,
            Aguav_Berry = 0x00A2,
            Iapapa_Berry = 0x00A3,
            Razz_Berry = 0x00A4,
            Bluk_Berry = 0x00A5,
            Nanab_Berry = 0x00A6,
            Wepear_Berry = 0x00A7,
            Pinap_Berry = 0x00A8,
            Pomeg_Berry = 0x00A9,
            Kelpsy_Berry = 0x00AA,
            Qualot_Berry = 0x00AB,
            Hondew_Berry = 0x00AC,
            Grepa_Berry = 0x00AD,
            Tamato_Berry = 0x00AE,
            Cornn_Berry = 0x00AF,
            Magost_Berry = 0x00B0,
            Rabuta_Berry = 0x00B1,
            Nomel_Berry = 0x00B2,
            Spelon_Berry = 0x00B3,
            Pamtre_Berry = 0x00B4,
            Watmel_Berry = 0x00B5,
            Durin_Berry = 0x00B6,
            Belue_Berry = 0x00B7,
            Occa_Berry = 0x00B8,
            Passho_Berry = 0x00B9,
            Wacan_Berry = 0x00BA,
            Rindo_Berry = 0x00BB,
            Yache_Berry = 0x00BC,
            Chople_Berry = 0x00BD,
            Kebia_Berry = 0x00BE,
            Shuca_Berry = 0x00BF,
            Coba_Berry = 0x00C0,
            Payapa_Berry = 0x00C1,
            Tanga_Berry = 0x00C2,
            Charti_Berry = 0x00C3,
            Kasib_Berry = 0x00C4,
            Haban_Berry = 0x00C5,
            Colbur_Berry = 0x00C6,
            Babiri_Berry = 0x00C7,
            Chilan_Berry = 0x00C8,
            Liechi_Berry = 0x00C9,
            Ganlon_Berry = 0x00CA,
            Salac_Berry = 0x00CB,
            Petaya_Berry = 0x00CC,
            Apicot_Berry = 0x00CD,
            Lansat_Berry = 0x00CE,
            Starf_Berry = 0x00CF,
            Enigma_Berry = 0x00D0,
            Micle_Berry = 0x00D1,
            Custap_Berry = 0x00D2,
            Jaboca_Berry = 0x00D3,
            Rowap_Berry = 0x00D4,
            BrightPowder = 0x00D5,
            White_Herb = 0x00D6,
            Macho_Brace = 0x00D7,
            Exp_Share = 0x00D8,
            Quick_Claw = 0x00D9,
            Soothe_Bell = 0x00DA,
            Mental_Herb = 0x00DB,
            Choice_Band = 0x00DC,
            Kings_Rock = 0x00DD,
            SilverPowder = 0x00DE,
            Amulet_Coin = 0x00DF,
            Cleanse_Tag = 0x00E0,
            Soul_Dew = 0x00E1,
            DeepSeaTooth = 0x00E2,
            DeepSeaScale = 0x00E3,
            Smoke_Ball = 0x00E4,
            Everstone = 0x00E5,
            Focus_Band = 0x00E6,
            Lucky_Egg = 0x00E7,
            Scope_Lens = 0x00E8,
            Metal_Coat = 0x00E9,
            Leftovers = 0x00EA,
            Dragon_Scale = 0x00EB,
            Light_Ball = 0x00EC,
            Soft_Sand = 0x00ED,
            Hard_Stone = 0x00EE,
            Miracle_Seed = 0x00EF,
            BlackGlasses = 0x00F0,
            Black_Belt = 0x00F1,
            Magnet = 0x00F2,
            Mystic_Water = 0x00F3,
            Sharp_Beak = 0x00F4,
            Poison_Barb = 0x00F5,
            NeverMeltIce = 0x00F6,
            Spell_Tag = 0x00F7,
            TwistedSpoon = 0x00F8,
            Charcoal = 0x00F9,
            Dragon_Fang = 0x00FA,
            Silk_Scarf = 0x00FB,
            Up_Grade = 0x00FC,
            Shell_Bell = 0x00FD,
            Sea_Incense = 0x00FE,
            Lax_Incense = 0x00FF,
            Lucky_Punch = 0x0100,
            Metal_Powder = 0x0101,
            Thick_Club = 0x0102,
            Stick = 0x0103,
            Red_Scarf = 0x0104,
            Blue_Scarf = 0x0105,
            Pink_Scarf = 0x0106,
            Green_Scarf = 0x0107,
            Yellow_Scarf = 0x0108,
            Wide_Lens = 0x0109,
            Muscle_Band = 0x010A,
            Wise_Glasses = 0x010B,
            Expert_Belt = 0x010C,
            Light_Clay = 0x010D,
            Life_Orb = 0x010E,
            Power_Herb = 0x010F,
            Toxic_Orb = 0x0110,
            Flame_Orb = 0x0111,
            Quick_Powder = 0x0112,
            Focus_Sash = 0x0113,
            Zoom_Lens = 0x0114,
            Metronome = 0x0115,
            Iron_Ball = 0x0116,
            Lagging_Tail = 0x0117,
            Destiny_Knot = 0x0118,
            Black_Sludge = 0x0119,
            Icy_Rock = 0x011A,
            Smooth_Rock = 0x011B,
            Heat_Rock = 0x011C,
            Damp_Rock = 0x011D,
            Grip_Claw = 0x011E,
            Choice_Scarf = 0x011F,
            Sticky_Barb = 0x0120,
            Power_Bracer = 0x0121,
            Power_Belt = 0x0122,
            Power_Lens = 0x0123,
            Power_Band = 0x0124,
            Power_Anklet = 0x0125,
            Power_Weight = 0x0126,
            Shed_Shell = 0x0127,
            Big_Root = 0x0128,
            Choice_Specs = 0x0129,
            Flame_Plate = 0x012A,
            Splash_Plate = 0x012B,
            Zap_Plate = 0x012C,
            Meadow_Plate = 0x012D,
            Icicle_Plate = 0x012E,
            Fist_Plate = 0x012F,
            Toxic_Plate = 0x0130,
            Earth_Plate = 0x0131,
            Sky_Plate = 0x0132,
            Mind_Plate = 0x0133,
            Insect_Plate = 0x0134,
            Stone_Plate = 0x0135,
            Spooky_Plate = 0x0136,
            Draco_Plate = 0x0137,
            Dread_Plate = 0x0138,
            Iron_Plate = 0x0139,
            Odd_Incense = 0x013A,
            Rock_Incense = 0x013B,
            Full_Incense = 0x013C,
            Wave_Incense = 0x013D,
            Rose_Incense = 0x013E,
            Luck_Incense = 0x013F,
            Pure_Incense = 0x0140,
            Protector = 0x0141,
            Electirizer = 0x0142,
            Magmarizer = 0x0143,
            Dubious_Disc = 0x0144,
            Reaper_Cloth = 0x0145,
            Razor_Claw = 0x0146,
            Razor_Fang = 0x0147,
            TM01 = 0x0148,
            TM02 = 0x0149,
            TM03 = 0x014A,
            TM04 = 0x014B,
            TM05 = 0x014C,
            TM06 = 0x014D,
            TM07 = 0x014E,
            TM08 = 0x014F,
            TM09 = 0x0150,
            TM10 = 0x0151,
            TM11 = 0x0152,
            TM12 = 0x0153,
            TM13 = 0x0154,
            TM14 = 0x0155,
            TM15 = 0x0156,
            TM16 = 0x0157,
            TM17 = 0x0158,
            TM18 = 0x0159,
            TM19 = 0x015A,
            TM20 = 0x015B,
            TM21 = 0x015C,
            TM22 = 0x015D,
            TM23 = 0x015E,
            TM24 = 0x015F,
            TM25 = 0x0160,
            TM26 = 0x0161,
            TM27 = 0x0162,
            TM28 = 0x0163,
            TM29 = 0x0164,
            TM30 = 0x0165,
            TM31 = 0x0166,
            TM32 = 0x0167,
            TM33 = 0x0168,
            TM34 = 0x0169,
            TM35 = 0x016A,
            TM36 = 0x016B,
            TM37 = 0x016C,
            TM38 = 0x016D,
            TM39 = 0x016E,
            TM40 = 0x016F,
            TM41 = 0x0170,
            TM42 = 0x0171,
            TM43 = 0x0172,
            TM44 = 0x0173,
            TM45 = 0x0174,
            TM46 = 0x0175,
            TM47 = 0x0176,
            TM48 = 0x0177,
            TM49 = 0x0178,
            TM50 = 0x0179,
            TM51 = 0x017A,
            TM52 = 0x017B,
            TM53 = 0x017C,
            TM54 = 0x017D,
            TM55 = 0x017E,
            TM56 = 0x017F,
            TM57 = 0x0180,
            TM58 = 0x0181,
            TM59 = 0x0182,
            TM60 = 0x0183,
            TM61 = 0x0184,
            TM62 = 0x0185,
            TM63 = 0x0186,
            TM64 = 0x0187,
            TM65 = 0x0188,
            TM66 = 0x0189,
            TM67 = 0x018A,
            TM68 = 0x018B,
            TM69 = 0x018C,
            TM70 = 0x018D,
            TM71 = 0x018E,
            TM72 = 0x018F,
            TM73 = 0x0190,
            TM74 = 0x0191,
            TM75 = 0x0192,
            TM76 = 0x0193,
            TM77 = 0x0194,
            TM78 = 0x0195,
            TM79 = 0x0196,
            TM80 = 0x0197,
            TM81 = 0x0198,
            TM82 = 0x0199,
            TM83 = 0x019A,
            TM84 = 0x019B,
            TM85 = 0x019C,
            TM86 = 0x019D,
            TM87 = 0x019E,
            TM88 = 0x019F,
            TM89 = 0x01A0,
            TM90 = 0x01A1,
            TM91 = 0x01A2,
            TM92 = 0x01A3,
            HM01 = 0x01A4,
            HM02 = 0x01A5,
            HM03 = 0x01A6,
            HM04 = 0x01A7,
            HM05 = 0x01A8,
            HM06 = 0x01A9,
            Explorer_Kit = 0x01AC,
            Loot_Sack = 0x01AD,
            Rule_Book = 0x01AE,
            Poke_Radar = 0x01AF,
            Point_Card = 0x01B0,
            Journal = 0x01B1,
            Seal_Case = 0x01B2,
            Fashion_Case = 0x01B3,
            Seal_Bag = 0x01B4,
            Pal_Pad = 0x01B5,
            Works_Key = 0x01B6,
            Old_Charm = 0x01B7,
            Galactic_Key = 0x01B8,
            Red_Chain = 0x01B9,
            Town_Map = 0x01BA,
            Vs_Seeker = 0x01BB,
            Coin_Case = 0x01BC,
            Old_Rod = 0x01BD,
            Good_Rod = 0x01BE,
            Super_Rod = 0x01BF,
            Sprayduck = 0x01C0,
            Poffin_Case = 0x01C1,
            Bicycle = 0x01C2,
            Suite_Key = 0x01C3,
            Oaks_Letter = 0x01C4,
            Lunar_Wing = 0x01C5,
            Member_Card = 0x01C6,
            Azure_Flute = 0x01C7,
            SS_Ticket = 0x01C8,
            Contest_Pass = 0x01C9,
            Magma_Stone = 0x01CA,
            Parcel = 0x01CB,
            Coupon_1 = 0x01CC,
            Coupon_2 = 0x01CD,
            Coupon_3 = 0x01CE,
            Storage_Key = 0x01CF,
            SecretPotion = 0x01D0,
            Griseous_Orb = 0x0070,
            Vs_Recorder = 0x01D1,
            Gracidea = 0x01D2,
            Secret_Key = 0x01D3,
            Apricorn_Box = 0x01D4,
            Berry_Pots = 0x01D6,
            SquirtBottle = 0x01DD,
            Lure_Ball = 0x01EE,
            Level_Ball = 0x01ED,
            Moon_Ball = 0x01F2,
            Heavy_Ball = 0x01EF,
            Fast_Ball = 0x01EC,
            Friend_Ball = 0x01F1,
            Love_Ball = 0x01F0,
            Park_Ball = 0x01F4,
            Sport_Ball = 0x01F3,
            Red_Apricorn = 0x01E5,
            Blu_Apricorn = 0x01E6,
            Ylw_Apricorn = 0x01E7,
            Grn_Apricorn = 0x01E8,
            Pnk_Apricorn = 0x01E9,
            Wht_Apricorn = 0x01EA,
            Blk_Apricorn = 0x01EB,
            Dowsing_MCHN = 0x01D7,
            RageCandyBar = 0x01F8,
            Red_Orb = 0x0216,
            Blue_Orb = 0x0217,
            Jade_Orb = 0x0214,
            Enigma_Stone = 0x0218,
            Unown_Report = 0x01D5,
            Blue_Card = 0x01D8,
            SlowpokeTail = 0x01D9,
            Clear_Bell = 0x01DA,
            Card_Key = 0x01DB,
            Basement_Key = 0x01DC,
            Red_Scale = 0x01DE,
            Lost_Item = 0x01DF,
            Pass = 0x01E0,
            Machine_Part = 0x01E1,
            Silver_Wing = 0x01E2,
            Rainbow_Wing = 0x01E3,
            Mystery_Egg = 0x01E4,
            GB_Sounds = 0x01F6,
            Tidal_Bell = 0x01F7,
            Data_Card_01 = 0x01F9,
            Data_Card_02 = 0x01FA,
            Data_Card_03 = 0x01FB,
            Data_Card_04 = 0x01FC,
            Data_Card_05 = 0x01FD,
            Data_Card_06 = 0x01FE,
            Data_Card_07 = 0x01FF,
            Data_Card_08 = 0x0200,
            Data_Card_09 = 0x0201,
            Data_Card_10 = 0x0202,
            Data_Card_11 = 0x0203,
            Data_Card_12 = 0x0204,
            Data_Card_13 = 0x0205,
            Data_Card_14 = 0x0206,
            Data_Card_15 = 0x0207,
            Data_Card_16 = 0x0208,
            Data_Card_17 = 0x0209,
            Data_Card_18 = 0x020A,
            Data_Card_19 = 0x020B,
            Data_Card_20 = 0x020C,
            Data_Card_21 = 0x020D,
            Data_Card_22 = 0x020E,
            Data_Card_23 = 0x020F,
            Data_Card_24 = 0x0210,
            Data_Card_25 = 0x0211,
            Data_Card_26 = 0x0212,
            Data_Card_27 = 0x0213,
            Lock_Capsule = 0x0215,
            Photo_Album = 0x01F5,
            Douse_Drive = 0x0074,
            Shock_Drive = 0x0075,
            Burn_Drive = 0x0076,
            Chill_Drive = 0x0077,
            Sweet_Heart = 0x0086,
            Greet_Mail = 0x0089,
            Favored_Mail = 0x008A,
            RSVP_Mail = 0x008B,
            Thanks_Mail = 0x008C,
            Inquiry_Mail = 0x008D,
            Like_Mail = 0x008E,
            Reply_Mail = 0x008F,
            BridgeMail_S = 0x0090,
            BridgeMail_D = 0x0091,
            BridgeMail_T = 0x0092,
            BridgeMail_V = 0x0093,
            BridgeMail_M = 0x0094,
            Prism_Scale = 0x0219,
            Eviolite = 0x021A,
            Float_Stone = 0x021B,
            Rocky_Helmet = 0x021C,
            Air_Balloon = 0x021D,
            Red_Card = 0x021E,
            Ring_Target = 0x021F,
            Binding_Band = 0x0220,
            Absorb_Bulb = 0x0221,
            Cell_Battery = 0x0222,
            Eject_Button = 0x0223,
            Fire_Gem = 0x0224,
            Water_Gem = 0x0225,
            Electric_Gem = 0x0226,
            Grass_Gem = 0x0227,
            Ice_Gem = 0x0228,
            Fighting_Gem = 0x0229,
            Poison_Gem = 0x022A,
            Ground_Gem = 0x022B,
            Flying_Gem = 0x022C,
            Psychic_Gem = 0x022D,
            Bug_Gem = 0x022E,
            Rock_Gem = 0x022F,
            Ghost_Gem = 0x0230,
            Dark_Gem = 0x0232,
            Steel_Gem = 0x0233,
            Health_Wing = 0x0235,
            Muscle_Wing = 0x0236,
            Resist_Wing = 0x0237,
            Genius_Wing = 0x0238,
            Clever_Wing = 0x0239,
            Swift_Wing = 0x023A,
            Pretty_Wing = 0x023B,
            Cover_Fossil = 0x023C,
            Plume_Fossil = 0x023D,
            Liberty_Pass = 0x023E,
            Pass_Orb = 0x023F,
            Dream_Ball = 0x0240,
            Poke_Toy = 0x0241,
            Prop_Case = 0x0242,
            Dragon_Skull = 0x0243,
            BalmMushroom = 0x0244,
            Big_Nugget = 0x0245,
            Pearl_String = 0x0246,
            Comet_Shard = 0x0247,
            Relic_Copper = 0x0248,
            Relic_Silver = 0x0249,
            Relic_Gold = 0x024A,
            Relic_Vase = 0x024B,
            Relic_Band = 0x024C,
            Relic_Statue = 0x024D,
            Relic_Crown = 0x024E,
            Casteliacone = 0x024F,
            Dire_Hit_2 = 0x0250,
            X_Speed_2 = 0x0251,
            X_Special_2 = 0x0252,
            X_Sp_Def_2 = 0x0253,
            X_Defend_2 = 0x0254,
            X_Attack_2 = 0x0255,
            X_Accuracy_2 = 0x0256,
            X_Speed_3 = 0x0257,
            X_Special_3 = 0x0258,
            X_Sp_Def_3 = 0x0259,
            X_Defend_3 = 0x025A,
            X_Attack_3 = 0x025B,
            X_Accuracy_3 = 0x025C,
            X_Speed_6 = 0x025D,
            X_Special_6 = 0x025E,
            X_Sp_Def_6 = 0x025F,
            X_Defend_6 = 0x0260,
            X_Attack_6 = 0x0261,
            X_Accuracy_6 = 0x0262,
            Ability_Urge = 0x0263,
            Item_Drop = 0x0264,
            Item_Urge = 0x0265,
            Reset_Urge = 0x0266,
            Dire_Hit_3 = 0x0267,
            Light_Stone = 0x0268,
            Dark_Stone = 0x0269,
            TM93 = 0x026A,
            TM94 = 0x026B,
            TM95 = 0x026C,
            Xtransceiver = 0x026D,
            god_stone = 0x026E,
            Gram_1 = 0x026F,
            Gram_2 = 0x0270,
            Gram_3 = 0x0271,
            Dragon_Gem = 0x0231,
            Normal_Gem = 0x0234,
            Medal_Box = 0x0273,
            DNA_Splicers = 0x0274,
            Permit = 0x0276,
            Oval_Charm = 0x0277,
            Shiny_Charm = 0x0278,
            Plasma_Card = 0x0279,
            Grubby_Hanky = 0x027A,
            Colress_MCHN = 0x027B,
            Dropped_Item = 0x027C,
            Reveal_Glass = 0x027E
        }
        public enum Abilities
        {
            Stench,
            Drizzle,
            Speed_Boost,
            Battle_Armor,
            Sturdy,
            Damp,
            Limber,
            Sand_Veil,
            Static,
            Volt_Absorb,
            Water_Absorb,
            Oblivious,
            Cloud_Nine,
            Compoundeyes,
            Insomnia,
            Color_Change,
            Immunity,
            Flash_Fire,
            Shield_Dust,
            Own_Tempo,
            Suction_Cups,
            Intimidate,
            Shadow_Tag,
            Rough_Skin,
            Wonder_Guard,
            Levitate,
            Effect_Spore,
            Synchronize,
            Clear_Body,
            Natural_Cure,
            Lightningrod,
            Serene_Grace,
            Swift_Swim,
            Chlorophyll,
            Illuminate,
            Trace,
            Huge_Power,
            Poison_Point,
            Inner_Focus,
            Magma_Armor,
            Water_Veil,
            Magnet_Pull,
            Soundproof,
            Rain_Dish,
            Sand_Stream,
            Pressure,
            Thick_Fat,
            Early_Bird,
            Flame_Body,
            Run_Away,
            Keen_Eye,
            Hyper_Cutter,
            Pickup,
            Truant,
            Hustle,
            Cute_Charm,
            Plus,
            Minus,
            Forecast,
            Sticky_Hold,
            Shed_Skin,
            Guts,
            Marvel_Scale,
            Liquid_Ooze,
            Overgrow,
            Blaze,
            Torrent,
            Swarm,
            Rock_Head,
            Drought,
            Arena_Trap,
            Vital_Spirit,
            White_Smoke,
            Pure_Power,
            Shell_Armor,
            Air_Lock,
            Tangled_Feet,
            Motor_Drive,
            Rivalry,
            Steadfast,
            Snow_Cloak,
            Gluttony,
            Anger_Point,
            Unburden,
            Heatproof,
            Simple,
            Dry_Skin,
            Download,
            Iron_Fist,
            Poison_Heal,
            Adaptability,
            Skill_Link,
            Hydration,
            Solar_Power,
            Quick_Feet,
            Normalize,
            Sniper,
            Magic_Guard,
            No_Guard,
            Stall,
            Technician,
            Leaf_Guard,
            Klutz,
            Mold_Breaker,
            Super_Luck,
            Aftermath,
            Anticipation,
            Forewarn,
            Unaware,
            Tinted_Lens,
            Filter,
            Slow_Start,
            Scrappy,
            Storm_Drain,
            Ice_Body,
            Solid_Rock,
            Snow_Warning,
            Honey_Gather,
            Frisk,
            Reckless,
            Multitype,
            Flower_Gift,
            Bad_Dreams,
            Pickpocket,
            Sheer_Force,
            Contrary,
            Unnerve,
            Defiant,
            Defeatist,
            Cursed_Body,
            Healer,
            Friend_Guard,
            Weak_Armor,
            Heavy_Metal,
            Light_Metal,
            Multiscale,
            Toxic_Boost,
            Flare_Boost,
            Harvest,
            Telepathy,
            Moody,
            Overcoat,
            Poison_Touch,
            Regenerator,
            Big_Pecks,
            Sand_Rush,
            Wonder_Skin,
            Analytic,
            Illusion,
            Imposter,
            Infiltrator,
            Mummy,
            Moxie,
            Justified,
            Rattled,
            Magic_Bounce,
            Sap_Sipper,
            Prankster,
            Sand_Force,
            Iron_Barbs,
            Zen_Mode,
            Victory_Star,
            Turboblaze,
            Teravolt,
        }
        public enum SpindaSpots
        {
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight
        }
        public enum SpindaColorsBase : uint
        {
            BaseLight = 0xffe6d6a5,
            BaseShaded = 0xffcea573
        }
        public enum SpindaColorsNormalSpot : uint
        {
            NormalSpotLight = 0xffef524a,
            NormalSpotShaded = 0xffbd4a31
        }
        public enum SpindaColorsShinySpot : uint
        {
            ShinySpotLight = 0xffa5ce10,
            ShinyShaded = 0xff7b9c00
        }
        #endregion

        #region DBAccess
        public static class SQL
        {
            [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
            public static extern void OpenDB(string dbfilename);
            [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
            public static extern void CloseDB();
            [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            [return: MarshalAs(UnmanagedType.BStr)]
            public static unsafe extern string GetAString(string sql);
            [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
            public static extern int GetAnInt(string sql);
        }
        #endregion

        #region Resources
        public static System.Drawing.Image GetResourceByName(string name)
        {
            if ((name == "") || (name == null))
            {
                return null;
            }
            else
            {
                return (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(name);
            }
        }
        public static System.Drawing.Image GetSprite(UInt16 Species, bool Shiny = false, byte Form = 0, bool Female = false)
        {
            System.Drawing.Image ret = null;
            string sprite = "s";
            if (Female)
            {
                sprite += "f";
            }
            if (Shiny)
            {
                sprite += "s";
            }
            sprite += "_" + Species.ToString();
            if (Form != 0)
            {
                string basestr = sprite;
                sprite += "_" + Form.ToString();
                ret = PKMDS.GetResourceByName(sprite);
                if (ret == null)
                {
                    sprite = basestr;
                    string formname = "";
                    switch ((PKMSpecies)(Species))
                    {
                        case PKMSpecies.Unown:
                            switch (Form)
                            {
                                case 26:
                                    formname = "exclamation";
                                    break;
                                case 27:
                                    formname = "question";
                                    break;
                                default:
                                    formname = GetPKMFormName_INTERNAL(Species, Form).Split(' ')[0];
                                    break;
                            }
                            break;
                        case PKMSpecies.Keldeo:
                            if (Form == 1)
                            {
                                formname = "resolute";
                            }
                            break;
                        case PKMSpecies.Meloetta:
                            if (Form == 1)
                            {
                                formname = "pirouette";
                            }
                            break;
                        default:
                            formname = GetPKMFormName_INTERNAL(Species, Form).Split(' ')[0];
                            break;
                    }
                    sprite += "_" + formname.ToLower();
                    ret = PKMDS.GetResourceByName(sprite.Replace('-', '_'));
                }
            }
            else
            {
                ret = PKMDS.GetResourceByName(sprite.Replace('-', '_'));
            }
            return ret;
        }
        public static System.Drawing.Image GetIcon(UInt16 Species, byte Form = 0, bool Female = false)
        {
            System.Drawing.Image ret = null;
            string icon = "bi_" + Species.ToString();
            if (Female)
            {
                icon = "f" + icon;
            }
            if (Form != 0)
            {
                string basestr = icon;
                icon += "_" + Form.ToString();
                ret = PKMDS.GetResourceByName(icon);
                if (ret == null)
                {
                    icon = basestr + "_" + PKMDS.GetPKMFormName_INTERNAL(Species, Form).Split(' ')[0].ToLower();
                }
            }
            ret = PKMDS.GetResourceByName(icon);
            return ret;
        }
        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int HasFemaleSprite([In][Out] Pokemon pkm);
        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int HasFemaleIcon([In][Out] Pokemon pkm);
        public static System.Drawing.Image GetItemImage(UInt16 itemid)
        {
            if (itemid == 0U)
            {
                return null;
            }
            else
            {
                string identifier = GetItemIdentifier(itemid);
                if ((identifier != "") && identifier != null)
                {
                    identifier = identifier.Replace('-', '_');
                    return GetResourceByName(identifier);
                }
                else
                {
                    return null;
                }
            }
        }
        public static System.Drawing.Image GetBallImage(byte ballid)
        {
            return GetResourceByName("b_" + ballid.ToString());
        }
        public static System.Drawing.Image GetTypeImage(int typeid)
        {
            string type = GetTypeName(typeid);
            if ((type == "") || (type == null))
            {
                return null;
            }
            else
            {
                return GetResourceByName(type.ToLower());
            }
        }
        public static System.Drawing.Image GetMarkingImage(int marking, bool marked)
        {
            int markedint = 0;
            if (marked)
            {
                markedint = 1;
            }
            return GetResourceByName("m_" + marking.ToString() + markedint.ToString());
        }
        public static System.Drawing.Image GetGenderIcon(int gender)
        {
            switch (gender)
            {
                case 0:
                    return GetResourceByName("male");
                case 1:
                    return GetResourceByName("female");
                default:
                    return null;
            }
        }
        public static System.Drawing.Image GetShinyStar(bool shiny)
        {
            if (shiny)
            {
                return GetResourceByName("shiny");
            }
            else
            {
                return null;
            }
        }
        public static System.Drawing.Image GetMoveCategoryImage(UInt16 move)
        {
            return GetResourceByName(GetMoveCategory(move));
        }
        #endregion

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetTypeName(int type);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetMoveCategory(UInt16 move);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetItemIdentifier(UInt16 item);

        public static System.Drawing.Bitmap GetSpindaSprite(bool Shiny = false)
        {
            if (Shiny)
            {
                return PKMDS_CS.Properties.Resources.spindashiny;
            }
            else
            {
                return PKMDS_CS.Properties.Resources.spinda;
            }
        }
        public static System.Drawing.Bitmap GetSpindaSpot(SpindaSpots spot)
        {
            switch (spot)
            {
                case SpindaSpots.TopLeft:
                    return PKMDS_CS.Properties.Resources.spot_1;
                case SpindaSpots.TopRight:
                    return PKMDS_CS.Properties.Resources.spot_2;
                case SpindaSpots.BottomLeft:
                    return PKMDS_CS.Properties.Resources.spot_3;
                case SpindaSpots.BottomRight:
                    return PKMDS_CS.Properties.Resources.spot_4;
                default:
                    return null;
            }
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static extern unsafe int ValidateSave_INTERNAL([In][Out] Save sav, [In][Out] IntPtr* nickname, [In][Out] int* length);
        private static unsafe bool ValidateSave([In][Out] Save sav, out string message)
        {
            IntPtr test = new IntPtr();
            int length = new int();
            int ret = PKMDS.ValidateSave_INTERNAL(sav, &test, &length);
            string msg = System.Runtime.InteropServices.Marshal.PtrToStringAuto(test);
            message = msg.Substring(0, length);
            return ret == 1;
        }
        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static unsafe extern void GetPKMOTName_INTERNAL([In][Out] Pokemon pkm, [In][Out] IntPtr* otname, [In][Out] int* length);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static unsafe extern void GetPKMNickName_INTERNAL([In][Out] Pokemon pkm, [In][Out] IntPtr* nickname, [In][Out] int* length);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern bool DepositPKM([In][Out] Save sav, Pokemon pkm, int startbox, bool failiffull);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern bool WithdrawPKM([In][Out] Save sav, Pokemon pkm);

        private static unsafe string GetPKMOTName([In][Out]Pokemon pkm)
        {
            IntPtr test = new IntPtr();
            int length = new int();
            PKMDS.GetPKMOTName_INTERNAL(pkm, &test, &length);
            string ret = System.Runtime.InteropServices.Marshal.PtrToStringAuto(test);
            return ret.Substring(0, length);
        }
        private static unsafe string GetPKMNickname([In][Out]Pokemon pkm)
        {
            IntPtr test = new IntPtr();
            int length = new int();
            PKMDS.GetPKMNickName_INTERNAL(pkm, &test, &length);
            string ret = System.Runtime.InteropServices.Marshal.PtrToStringAuto(test);
            return ret.Substring(0, length);
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetPKMName(int speciesid, int langid = LANG_ID);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetPKMFormNames_INTERNAL(UInt16 speciesid);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetPKMFormName_INTERNAL(UInt16 speciesid, byte formid);

        public static string[] GetPKMFormNames(UInt16 speciesid)
        {
            string formnames = GetPKMFormNames_INTERNAL(speciesid);
            if (formnames != null)
            {
                formnames = formnames.Remove(formnames.Length - 1, 1);
                if ((formnames != null) && (formnames != ""))
                {
                    return formnames.Split(',');
                }
            }
            string[] formnamesarray = { "" };
            return formnamesarray;
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern unsafe void GetPKMName_FromObj_INTERNAL([In][Out] Pokemon pkm, [In][Out] IntPtr* nickname, [In][Out] int* length);

        private static unsafe string GetPKMName_FromObj([In][Out] Pokemon pkm)
        {
            IntPtr test = new IntPtr();
            int length = new int();
            PKMDS.GetPKMName_FromObj_INTERNAL(pkm, &test, &length);
            string ret = System.Runtime.InteropServices.Marshal.PtrToStringAuto(test);
            return ret.Substring(0, length);
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern unsafe void GetTrainerName_FromSav_INTERNAL([In][Out] Save sav, [In][Out] IntPtr* name, [In][Out] int* length);

        private static unsafe string GetTrainerName_FromSav([In][Out] Save sav)
        {
            IntPtr test = new IntPtr();
            int length = new int();
            PKMDS.GetTrainerName_FromSav_INTERNAL(sav, &test, &length);
            string ret = System.Runtime.InteropServices.Marshal.PtrToStringAuto(test);
            return ret.Substring(0, length);
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetCharacteristic([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static extern void WritePokemonFile([In][Out] Pokemon pkm, string filename, bool encrypt = false);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static extern void WriteSaveFile([In][Out] Save sav, string filename);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool IsPKMShiny([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool GetPKMMetAsEgg([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static extern void SetTrainerName_FromSav_INTERNAL([In][Out] Save sav, string name, int namelength);

        private static void SetTrainerName_FromSav([In][Out] Save sav, string name)
        {
            SetTrainerName_FromSav_INTERNAL(sav, name, name.Length);
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 GetTrainerTID_FromSav([In][Out] Save sav);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 GetTrainerSID_FromSav([In][Out] Save sav);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetTrainerTID_FromSav([In][Out] Save sav, UInt16 tid);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetBoxWallpaper([In][Out] Save sav, int box);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt32 GetPKMColorValue([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetBoxWallpaper([In][Out] Save sav, int box, int wallpaper);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetTrainerSID_FromSav([In][Out] Save sav, int sid);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static extern unsafe void GetBoxName_INTERNAL([In][Out] Save sav, int box, [In][Out] IntPtr* nickname, [In][Out] int* length);

        private static unsafe string GetBoxName([In][Out]Save sav, int box)
        {
            IntPtr test = new IntPtr();
            int length = new int();
            PKMDS.GetBoxName_INTERNAL(sav, box, &test, &length);
            string ret = System.Runtime.InteropServices.Marshal.PtrToStringAuto(test);
            return ret.Substring(0, length);
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static extern void SetBoxName([In][Out] Save sav, int box, string name, int namelength);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetBoxCount([In][Out] Save sav, int box);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetMovePower(UInt16 moveid);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetMoveAccuracy(UInt16 moveid);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetMoveBasePP(UInt16 moveid);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetNatureIncrease([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetNatureDecrease([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMStat([In][Out] Save sav, int box, int slot, int stat);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMStat_FromObj([In][Out] Pokemon pkm, int stat);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMLevel([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMLevel([In][Out] Pokemon pkm, int level);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 GetPKMSpeciesID([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMSpeciesID([In][Out] Pokemon pkm, UInt16 speciesid);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPartySize([In][Out] Save sav);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPartySize([In][Out] Save sav, int size);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetCurrentBox([In][Out] Save sav);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetCurrentBox([In][Out] Save sav, int box);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 GetPKMMoveID([In][Out] Pokemon pokemon, int moveid);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMMoveID([In][Out] Pokemon pokemon, int moveid, UInt16 moveindex);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool IsPKMModified([In][Out] Pokemon pokemon);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void FixPokemonChecksum([In][Out] Pokemon pokemon);





        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SwapBoxParty([In][Out] Save sav, int box, int boxslot, int partyslot);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SwapPartyBox([In][Out] Save sav, int partyslot, int box, int boxslot);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SwapBoxBox([In][Out] Save sav, int boxa, int boxslota, int boxb, int boxslotb);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SwapPartyParty([In][Out] Save sav, int partyslota, int partyslotb);






        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt32 GetPKMTNL([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt32 GetPKMEXPGivenLevel([In][Out] Pokemon pkm, int level);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt32 GetPKMEXPCurLevel([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetItemName_INTERNAL(int itemid, int generation, int langid);

        public static string GetItemName(int itemid, int generation = GENERATION, int langid = LANG_ID)
        {
            return GetItemName_INTERNAL(itemid, generation, langid);
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetItemFlavor_INTERNAL(int itemid, int generation, int langid, int versiongroup);

        public static string GetItemFlavor(int itemid, int generation = GENERATION, int langid = LANG_ID, int versiongroup = VERSION_GROUP)
        {
            return GetItemFlavor_INTERNAL(itemid, generation, langid, versiongroup);
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetAbilityName_INTERNAL(int abilityid, int langid = LANG_ID);

        public static string GetAbilityName(int abilityid, int langid = LANG_ID)
        {
            return GetAbilityName_INTERNAL(abilityid, langid);
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetAbilityFlavor_INTERNAL(int abilityid, int versiongroup = VERSION_GROUP, int langid = LANG_ID);

        public static string GetAbilityFlavor(int abilityid, int versiongroup = VERSION_GROUP, int langid = LANG_ID)
        {
            return GetAbilityFlavor_INTERNAL(abilityid, versiongroup, langid);
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetNatureName(int natureid, int langid = LANG_ID);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetLocationName(int locationid, int generation = GENERATION, int langid = LANG_ID);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetMoveName(int moveid, int langid = LANG_ID);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetMoveFlavor(int moveid, int langid = LANG_ID, int versiongroup = VERSION_GROUP);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetMoveTypeName(int moveid, int langid = LANG_ID);

        private static System.Drawing.Image GetWallpaperImage(int wallpaper)
        {
            return GetResourceByName("wc_" + wallpaper.ToString());
        }

        private static string[] GetPKMMoveNames([In][Out] Pokemon pkm, int langid = LANG_ID)
        {
            string[] moves = { "", "", "", "" };
            for (int move = 0; move < 4; move++)
            {
                moves[move] = GetMoveName(GetPKMMoveID(pkm, move), langid);
            }
            return moves;
        }

        private static string[] GetPKMMoveTypeNames([In][Out] Pokemon pkm, int langid = LANG_ID)
        {
            string[] moves = { "", "", "", "" };
            for (int move = 0; move < 4; move++)
            {
                moves[move] = GetMoveTypeName(GetPKMMoveID(pkm, move), langid);
            }
            return moves;
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt32 GetPKMPID([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMType_INTERNAL([In][Out] Pokemon pkm, int type, int generation);

        private static int GetPKMType(Pokemon pokemon, int slot, int generation = GENERATION)
        {
            return GetPKMType_INTERNAL(pokemon, slot, generation);
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMPID([In][Out] Pokemon pkm, UInt32 pid);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 GetPKMItemIndex([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMItemIndex([In][Out] Pokemon pkm, UInt16 item);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 GetPKMTID([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMTID([In][Out] Pokemon pkm, UInt16 tid);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 GetPKMSID([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMSID([In][Out] Pokemon pkm, UInt16 sid);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt32 GetPKMEXP([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMEXP([In][Out] Pokemon pkm, UInt32 exp);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMTameness([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMTameness([In][Out] Pokemon pkm, int tameness);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 GetPKMAbilityIndex([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMAbilityIndex([In][Out] Pokemon pkm, int ability);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        /*private*/
        private static extern bool GetPKMMarking([In][Out] Pokemon pkm, int marking);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMMarking([In][Out] Pokemon pkm, int marking, bool marked);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte GetPKMLanguage([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMLanguage([In][Out] Pokemon pkm, Byte language);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMEV([In][Out] Pokemon pkm, int evindex);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMEV([In][Out] Pokemon pkm, int evindex, int ev);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMIV([In][Out] Pokemon pkm, int evindex);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMIV([In][Out] Pokemon pkm, int ivindex, int iv);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMContest([In][Out] Pokemon pkm, int contestindex);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMContest([In][Out] Pokemon pkm, int contestindex, int contest);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMMovePP([In][Out] Pokemon pkm, int move);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMMovePP([In][Out] Pokemon pkm, int move, int pp);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMMovePPUp([In][Out] Pokemon pkm, int move);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMMovePPUp([In][Out] Pokemon pkm, int move, int ppup);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMIsEgg([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMIsEgg([In][Out] Pokemon pkm, bool isegg);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMIsNicknamed([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMIsNicknamed([In][Out] Pokemon pkm, bool isnicknamed);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMFateful([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMFateful([In][Out] Pokemon pkm, bool isfateful);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMGender([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMGender([In][Out] Pokemon pkm, int gender);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte GetPKMForm([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMForm([In][Out] Pokemon pkm, int form);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte GetPKMNature([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMNature([In][Out] Pokemon pkm, Byte nature);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool GetPKMDWAbility([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMDWAbility([In][Out] Pokemon pkm, bool hasdwability);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMNsPokemon([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMNsPokemon([In][Out] Pokemon pkm, bool isnspokemon);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static extern void SetPKMNickname([In][Out] Pokemon pkm, string nickname, int nicknamelength);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte GetPKMHometown([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMHometown([In][Out] Pokemon pkm, Byte hometown);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static extern void SetPKMOTName([In][Out] Pokemon pkm, string otname, int otnamelength);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMEggYear([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMEggYear([In][Out] Pokemon pkm, int year);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMEggMonth([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMEggMonth([In][Out] Pokemon pkm, int month);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMEggDay([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMEggDay([In][Out] Pokemon pkm, int day);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMMetYear([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMMetYear([In][Out] Pokemon pkm, int year);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMMetMonth([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMMetMonth([In][Out] Pokemon pkm, int month);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMMetDay([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMMetDay([In][Out] Pokemon pkm, int day);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 GetPKMEggLocation([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMEggLocation([In][Out] Pokemon pkm, UInt16 location);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt16 GetPKMMetLocation([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMMetLocation([In][Out] Pokemon pkm, UInt16 location);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMPokerusStrain([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMPokerusStrain([In][Out] Pokemon pkm, int strain);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMPokerusDays([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMPokerusDays([In][Out] Pokemon pkm, int days);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte GetPKMBall([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMBall([In][Out] Pokemon pkm, int ball);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte GetPKMMetLevel([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMMetLevel([In][Out] Pokemon pkm, Byte level);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMOTGender([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMOTGender([In][Out] Pokemon pkm, int gender);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetPKMEncounter([In][Out] Pokemon pkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMEncounter([In][Out] Pokemon pkm, int encounter);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void DeletePartyPKM([In][Out] Save sav, int slot);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void DeleteStoredPKM([In][Out] Save sav, int box, int slot);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void GetPKMData_INTERNAL([In][Out] Pokemon pokemon, [In][Out] Save sav, int box, int slot);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void RecalcPartyPKM([In][Out] PartyPokemon ppkm);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void GetPartyPKMData_INTERNAL([In][Out] PartyPokemon pokemon, [In][Out] Save sav, int slot);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static extern void GetPKMDataFromFile_INTERNAL([In][Out] Pokemon pokemon, string filename, bool encrypted);

        private static void GetPKMData([In][Out] ref Pokemon pokemon, [In][Out] Save sav, int box, int slot)
        {
            Pokemon pkm = new Pokemon();
            int size = Marshal.SizeOf(typeof(Pokemon));
            IntPtr pkmptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(pkm, pkmptr, false);
            GetPKMData_INTERNAL(pkm, sav, box, slot);
            pokemon = pkm;
            Marshal.FreeHGlobal(pkmptr);
            pkmptr = IntPtr.Zero;
        }

        private static void GetPartyPKMData([In][Out] ref PartyPokemon pokemon, [In][Out] Save sav, int slot)
        {
            PartyPokemon pkm = new PartyPokemon();
            int size = Marshal.SizeOf(typeof(PartyPokemon));
            IntPtr pkmptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(pkm, pkmptr, false);
            GetPartyPKMData_INTERNAL(pkm, sav, slot);
            pokemon = pkm;
            Marshal.FreeHGlobal(pkmptr);
            pkmptr = IntPtr.Zero;
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPKMData_INTERNAL([In][Out] Pokemon pokemon, [In][Out] Save sav, int box, int slot);

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetPartyPKMData_INTERNAL([In][Out] PartyPokemon pokemon, [In][Out] Save sav, int slot);

        private static void SetPKMData([In][Out] Pokemon pokemon, [In][Out] Save sav, int box, int slot)
        {
            SetPKMData_INTERNAL(pokemon, sav, box, slot);
        }

        public static void SetPartyPKMData([In][Out] PartyPokemon pokemon, [In][Out] Save sav, int slot)
        {
            SetPartyPKMData_INTERNAL(pokemon, sav, slot);
        }

        [DllImport(PKMDS_WIN32_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static extern void GetSAVData_INTERNAL([In][Out] Save save, string savefile);


        public static System.Drawing.Color GetSpindaColor(SpindaColorsBase spindacolor)
        {
            return System.Drawing.ColorTranslator.FromHtml("#" + ((int)(spindacolor)).ToString("X6"));
        }
        public static System.Drawing.Color GetSpindaColor(SpindaColorsNormalSpot spindacolor)
        {
            return System.Drawing.ColorTranslator.FromHtml("#" + ((int)(spindacolor)).ToString("X6"));
        }
        public static System.Drawing.Color GetSpindaColor(SpindaColorsShinySpot spindacolor)
        {
            return System.Drawing.ColorTranslator.FromHtml("#" + ((int)(spindacolor)).ToString("X6"));
        }


        public static Save ReadSaveFile(string savefile)
        {
            Save sav = new Save();
            Save save = new Save();
            int size = Marshal.SizeOf(typeof(Save));
            IntPtr savptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(sav, savptr, false);
            GetSAVData_INTERNAL(sav, savefile);
            save = sav;
            Marshal.FreeHGlobal(savptr);
            savptr = IntPtr.Zero;
            return save;
        }

        public static Pokemon ReadPokemonFile(string pokemonfile, bool encrypted = false)
        {
            Pokemon pkm = new Pokemon();
            Pokemon pokemon = new Pokemon();
            int size = Marshal.SizeOf(typeof(Pokemon));
            IntPtr savptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(pkm, savptr, false);
            GetPKMDataFromFile_INTERNAL(pkm, pokemonfile, encrypted);
            pokemon = pkm;
            Marshal.FreeHGlobal(savptr);
            savptr = IntPtr.Zero;
            return pokemon;
        }

        public class Item
        {
            public Item()
            {
                this.itemid = 0;
            }
            public Item(UInt16 itemid)
            {
                this.itemid = itemid;
            }
            private UInt16 itemid;
            public UInt16 ItemID
            {
                get
                {
                    return itemid;
                }
                set
                {
                    itemid = value;
                }
            }
            public string ItemName
            {
                get
                {
                    string name = PKMDS.GetItemName(this.itemid);
                    if (name == null)
                    {
                        return "";
                    }
                    else
                    {
                        return name;
                    }
                }
            }
            public string ItemFlavor
            {
                get
                {
                    string flavor = PKMDS.GetItemFlavor(this.itemid);
                    if (flavor == null)
                    {
                        return "";
                    }
                    else
                    {
                        return flavor.Replace("\n", " ");
                    }
                }
            }
            public System.Drawing.Image ItemImage
            {
                get
                {
                    if (itemid == 0)
                    {
                        return null;
                    }
                    else
                    {
                        return PKMDS.GetItemImage(this.itemid);
                    }
                }
            }
        }

        public class Ability
        {
            private UInt16 abilityid;
            public Ability(UInt16 abilityid)
            {
                this.abilityid = abilityid;
            }
            public Ability()
            {
                this.abilityid = 0;
            }
            public UInt16 AbilityID
            {
                get
                {
                    return abilityid;
                }
                set
                {
                    abilityid = value;
                }
            }
            public string AbilityName
            {
                get
                {
                    return PKMDS.GetAbilityName(this.AbilityID);
                }
            }
            public string AbilityFlavor
            {
                get
                {
                    return PKMDS.GetAbilityFlavor(this.AbilityID);
                }
            }
        }

        public class Species
        {
            private UInt16 speciesid;
            public Species(UInt16 speciesid)
            {
                this.speciesid = speciesid;
            }
            public Species()
            {
                this.speciesid = 0;
            }
            public UInt16 SpeciesID
            {
                get
                {
                    return speciesid;
                }
                set
                {
                    speciesid = value;
                }
            }
            public string SpeciesName
            {
                get
                {
                    return PKMDS.GetPKMName(SpeciesID);
                }
            }
        }

        public class Ball
        {
            private Byte ballid;
            public Ball(Byte ballid)
            {
                this.ballid = ballid;
            }
            public Ball()
            {
                this.ballid = 0;
            }
            public Byte BallID
            {
                get
                {
                    return ballid;
                }
                set
                {
                    ballid = value;
                }
            }
            public string BallName
            {
                get
                {
                    switch (BallID)
                    {
                        case 0:
                            return "Poké Ball";
                        case 1:
                            return "Master Ball";
                        case 2:
                            return "Ultra Ball";
                        case 3:
                            return "Great Ball";
                        case 4:
                            return "Poké Ball";
                        case 5:
                            return "Safari Ball";
                        case 6:
                            return "Net Ball";
                        case 7:
                            return "Dive Ball";
                        case 8:
                            return "Nest Ball";
                        case 9:
                            return "Repeat Ball";
                        case 10:
                            return "Timer Ball";
                        case 11:
                            return "Luxury Ball";
                        case 12:
                            return "Premier Ball";
                        case 13:
                            return "Dusk Ball";
                        case 14:
                            return "Heal Ball";
                        case 15:
                            return "Quick Ball";
                        case 16:
                            return "Cherish Ball";
                        case 17:
                            return "Fast Ball";
                        case 18:
                            return "Level Ball";
                        case 19:
                            return "Lure Ball";
                        case 20:
                            return "Heavy Ball";
                        case 21:
                            return "Love Ball";
                        case 22:
                            return "Friend Ball";
                        case 23:
                            return "Moon Ball";
                        case 24:
                            return "Sport Ball";
                        default:
                            return "Dream Ball";
                    }
                }
            }
            public System.Drawing.Image BallImage
            {
                get
                {
                    return GetBallImage(ballid);
                }
            }
        }

        public class Nature
        {
            private Byte natureid;
            public Nature(Byte natureid)
            {
                this.natureid = natureid;
            }
            public Nature()
            {
                this.natureid = 0;
            }
            public Byte NatureID
            {
                get
                {
                    return natureid;
                }
                set
                {
                    natureid = value;
                }
            }
            public string NatureName
            {
                get
                {
                    return PKMDS.GetNatureName(NatureID);
                }
            }
        }

        public class Location
        {
            private UInt16 locationid;
            public Location(UInt16 locationid)
            {
                this.locationid = locationid;
            }
            public Location()
            {
                this.locationid = 0;
            }
            public UInt16 LocationID
            {
                get
                {
                    return locationid;
                }
                set
                {
                    locationid = value;
                }
            }
            public string LocationName
            {
                get
                {
                    switch (LocationID)
                    {
                        case 2000:
                            return "Day-Care Couple (Gen IV)";
                        case 30001:
                            return "Poké Transfer";
                        case 30012:
                            return "a special place (1)";
                        case 30013:
                            return "a special place (2)";
                        case 30015:
                            return "Pokémon Dream Radar";
                        case 40001:
                            return "Lovely Place";
                        case 40069:
                            return "Wi-Fi Gift";
                        case 60002:
                            return "Day-Care Couple";
                        default:
                            return PKMDS.GetLocationName(LocationID);
                    }
                }
            }
        }

        public class Move
        {
            private UInt16 moveid;
            public Move(UInt16 moveid)
            {
                this.moveid = moveid;
            }
            public Move()
            {
                this.moveid = 0;
            }
            public UInt16 MoveID
            {
                get
                {
                    return moveid;
                }
                set
                {
                    moveid = value;
                }
            }
            public string MoveName
            {
                get
                {
                    string ret = PKMDS.GetMoveName(MoveID);
                    if (ret == null)
                    {
                        return "";
                    }
                    else
                    {
                        return ret;
                    }
                }
            }
            public string MoveFlavor
            {
                get
                {
                    string ret = PKMDS.GetMoveFlavor(MoveID);
                    if (ret == null)
                    {
                        return "";
                    }
                    else
                    {
                        return ret;
                    }
                }
            }
            public unsafe System.Drawing.Image MoveTypeImage
            {
                get
                {
                    return PKMDS.GetResourceByName(PKMDS.GetMoveTypeName(MoveID).ToLower());
                }
            }
            public unsafe System.Drawing.Image MoveCategoryImage
            {
                get
                {
                    return GetMoveCategoryImage(this.MoveID);
                }
            }
            public int MovePower
            {
                get
                {
                    return GetMovePower(MoveID);
                }
            }
            public decimal MoveAccuracy
            {
                get
                {
                    return GetMoveAccuracy(MoveID);
                }
            }
            public int MoveBasePP
            {
                get
                {
                    return GetMoveBasePP(MoveID);
                }
            }
        }

        public class Hometown
        {
            private Byte hometownid;
            public Hometown(Byte hometownid)
            {
                this.hometownid = hometownid;
            }
            public Hometown()
            {
                this.hometownid = 0;
            }
            public Byte HometownID
            {
                get
                {
                    return hometownid;
                }
                set
                {
                    hometownid = value;
                }
            }
            public string HometownName
            {
                get
                {
                    switch (HometownID)
                    {
                        case 0:
                            return "Colosseum Bonus";
                        case 1:
                            return "Sapphire";
                        case 2:
                            return "Ruby";
                        case 3:
                            return "Emerald";
                        case 4:
                            return "FireRed";
                        case 5:
                            return "LeafGreen";
                        case 7:
                            return "HeartGold";
                        case 8:
                            return "SoulSilver";
                        case 10:
                            return "Diamond";
                        case 11:
                            return "Pearl";
                        case 12:
                            return "Platinum";
                        case 15:
                            return "Colosseum / XD";
                        case 20:
                            return "White";
                        case 21:
                            return "Black";
                        case 22:
                            return "White 2";
                        case 23:
                            return "Black 2";
                        default:
                            return "";
                    }
                }
            }
        }

        public class Country
        {
            private Byte countryid;
            public Country(Byte countryid)
            {
                this.countryid = countryid;
            }
            public Country()
            {
                this.countryid = 0;
            }
            public Byte CountryID
            {
                get
                {
                    return countryid;
                }
                set
                {
                    countryid = value;
                }
            }
            public string CountryName
            {
                get
                {
                    switch (CountryID)
                    {
                        case 1:
                            return "JA";
                        case 2:
                            return "ENG/UK/AUS";
                        case 3:
                            return "FR";
                        case 4:
                            return "ITA";
                        case 5:
                            return "DE";
                        case 7:
                            return "SPA";
                        case 8:
                            return "SOK";
                        default:
                            return "";
                    }
                }
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public class Pokemon
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 136)]
            public byte[] Data;
            public string SpeciesName
            {
                get
                {
                    return PKMDS.GetPKMName_FromObj(this);
                }
            }
            public unsafe System.Drawing.Image Sprite
            {
                get
                {
                    if (this.SpeciesID != (UInt16)(PKMDS.PKMSpecies.Spinda))
                    {
                        return PKMDS.GetSprite(this.SpeciesID, this.IsShiny, this.FormID, PKMDS.HasFemaleSprite(this) == 1);
                    }
                    else
                    {
                        System.Drawing.Point TopLeftOrigin = new System.Drawing.Point(23, 15);
                        System.Drawing.Point TopRightOrigin = new System.Drawing.Point(47, 17);
                        System.Drawing.Point BottomLeftOrigin = new System.Drawing.Point(26, 33);
                        System.Drawing.Point BottomRightOrigin = new System.Drawing.Point(38, 33);
                        System.Drawing.Point[] SpotOrigins = { TopLeftOrigin, TopRightOrigin, BottomLeftOrigin, BottomRightOrigin };
                        System.Drawing.Point TopLeftOffsets = new System.Drawing.Point((int)(this.PID & 0xf), (int)(this.PID >> 4 & 0xf));
                        System.Drawing.Point TopRightOffsets = new System.Drawing.Point((int)(this.PID >> 8 & 0xf), (int)(this.PID >> 12 & 0xf));
                        System.Drawing.Point BottomLeftOffsets = new System.Drawing.Point((int)(this.PID >> 16 & 0xf), (int)(this.PID >> 20 & 0xf));
                        System.Drawing.Point BottomRightOffsets = new System.Drawing.Point((int)(this.PID >> 24 & 0xf), (int)(this.PID >> 28 & 0xf));
                        System.Drawing.Point[] SpotOffsets = { TopLeftOffsets, TopRightOffsets, BottomLeftOffsets, BottomRightOffsets };
                        System.Drawing.Bitmap BaseSprite = GetSpindaSprite(this.IsShiny);
                        System.Drawing.Bitmap TopLeft = GetSpindaSpot(SpindaSpots.TopLeft);
                        System.Drawing.Bitmap TopRight = GetSpindaSpot(SpindaSpots.TopRight);
                        System.Drawing.Bitmap BottomLeft = GetSpindaSpot(SpindaSpots.BottomLeft);
                        System.Drawing.Bitmap BottomRight = GetSpindaSpot(SpindaSpots.BottomRight);
                        System.Drawing.Bitmap[] Spots = { TopLeft, TopRight, BottomLeft, BottomRight };
                        System.Drawing.Imaging.BitmapData bData = BaseSprite.LockBits(new System.Drawing.Rectangle(0, 0, 96, 96), System.Drawing.Imaging.ImageLockMode.ReadWrite, BaseSprite.PixelFormat);
                        byte* scan0 = (byte*)bData.Scan0.ToPointer();
                        uint color;
                        int startx;
                        int starty;
                        for (int i = 0; i < 4; i++)
                        {
                            startx = SpotOrigins[i].X + SpotOffsets[i].X;
                            starty = SpotOrigins[i].Y + SpotOffsets[i].Y;
                            for (int x = 0; x < 96; x++)
                            {
                                for (int y = 0; y < 96; y++)
                                {
                                    color = 0;
                                    if (((x >= startx) && (y >= starty) && (x < startx + Spots[i].Width) && (y < starty + Spots[i].Height)) && (Spots[i].GetPixel(x - startx, y - starty).ToArgb() != -1))
                                    {
                                        byte* data = scan0 + y * bData.Stride + x * 4;
                                        if (data[0] != 0)
                                        {
                                            byte[] datab = { data[0], data[1], data[2], data[3] };
                                            uint SpriteColor = BitConverter.ToUInt32(datab, 0);
                                            if (SpriteColor == (uint)(SpindaColorsBase.BaseLight))
                                            {
                                                if (this.IsShiny)
                                                {
                                                    color = (uint)(SpindaColorsShinySpot.ShinySpotLight);
                                                }
                                                else
                                                {
                                                    color = (uint)(SpindaColorsNormalSpot.NormalSpotLight);
                                                }
                                            }
                                            if (SpriteColor == (uint)(SpindaColorsBase.BaseShaded))
                                            {
                                                if (this.IsShiny)
                                                {
                                                    color = (uint)(SpindaColorsShinySpot.ShinyShaded);
                                                }
                                                else
                                                {
                                                    color = (uint)(SpindaColorsNormalSpot.NormalSpotShaded);
                                                }
                                            }
                                            if (color != 0)
                                            {
                                                byte[] colordata = BitConverter.GetBytes(color);
                                                data[0] = colordata[0];
                                                data[1] = colordata[1];
                                                data[2] = colordata[2];
                                                data[3] = 0xFF;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        BaseSprite.UnlockBits(bData);
                        return BaseSprite;
                    }
                }
            }
            public int[] GetStats
            {
                get
                {
                    int[] ret = new int[6];
                    for (int stat = 0; stat < ret.Length; stat++)
                    {
                        ret[stat] = GetPKMStat_FromObj(this, stat + 1);
                    }
                    return ret;
                }
            }
            public int Level
            {
                get
                {
                    return GetPKMLevel(this);
                }
                set
                {
                    SetPKMLevel(this, value);
                }
            }
            public UInt16 SpeciesID
            {
                get
                {
                    return GetPKMSpeciesID(this);
                }
                set
                {
                    SetPKMSpeciesID(this, value);
                }
            }
            public void WriteToFile(string FileName, bool encrypt = false)
            {
                WritePokemonFile(this, FileName, encrypt);
            }
            public UInt32 PID
            {
                get
                {
                    return GetPKMPID(this);
                }
                set
                {
                    SetPKMPID(this, value);
                }
            }
            public UInt16 ItemID
            {
                get
                {
                    return GetPKMItemIndex(this);
                }
                set
                {
                    SetPKMItemIndex(this, value);
                }
            }
            public UInt16 TID
            {
                get
                {
                    return GetPKMTID(this);
                }
                set
                {
                    SetPKMTID(this, value);
                }
            }
            public UInt16 SID
            {
                get
                {
                    return GetPKMSID(this);
                }
                set
                {
                    SetPKMSID(this, value);
                }
            }
            public UInt32 EXP
            {
                get
                {
                    return GetPKMEXP(this);
                }
                set
                {
                    SetPKMEXP(this, value);
                }
            }
            public int Tameness
            {
                get
                {
                    return GetPKMTameness(this);
                }
                set
                {
                    SetPKMTameness(this, value);
                }
            }
            public UInt16 AbilityID
            {
                get
                {
                    return GetPKMAbilityIndex(this);
                }
                set
                {
                    SetPKMAbilityIndex(this, value);
                }
            }
            public bool GetMarking(int marking)
            {
                return GetPKMMarking(this, marking);
            }
            public void SetMarking(int marking, bool marked)
            {
                SetPKMMarking(this, marking, marked);
            }
            public Byte LanguageID
            {
                get
                {
                    return GetPKMLanguage(this);
                }
                set
                {
                    SetPKMLanguage(this, value);
                }
            }
            public int GetEV(int evindex)
            {
                return GetPKMEV(this, evindex);
            }
            public void SetEV(int evindex, int ev)
            {
                SetPKMEV(this, evindex, ev);
            }
            public int GetIV(int ivindex)
            {
                return GetPKMIV(this, ivindex);
            }
            public void SetIV(int ivindex, int iv)
            {
                SetPKMIV(this, ivindex, iv);
            }
            public int GetContest(int contestindex)
            {
                return GetPKMContest(this, contestindex);
            }
            public void SetContest(int contestindex, int contest)
            {
                SetPKMContest(this, contestindex, contest);
            }
            public UInt16[] GetMoveIDs
            {
                get
                {
                    UInt16[] moveids = { 0, 0, 0, 0 };
                    for (int movenum = 0; movenum < 4; movenum++)
                    {
                        moveids[movenum] = GetPKMMoveID(this, movenum);
                    }
                    return moveids;
                }
            }
            public void SetMoveID(int moveid, UInt16 movenum)
            {
                SetPKMMoveID(this, moveid, movenum);
            }
            public int GetMovePP(int move)
            {
                return GetPKMMovePP(this, move);
            }
            public void SetMovePP(int move, int pp)
            {
                SetPKMMovePP(this, move, pp);
            }
            public int GetMovePPUp(int move)
            {
                return GetPKMMovePPUp(this, move);
            }
            public void SetMovePPUp(int move, int ppup)
            {
                SetPKMMovePPUp(this, move, ppup);
            }
            public bool MetAsEgg
            {
                get
                {
                    return GetPKMMetAsEgg(this);
                }
            }
            public bool IsEgg
            {
                get
                {
                    return GetPKMIsEgg(this) == 1;
                }
                set
                {
                    SetPKMIsEgg(this, value);
                }
            }
            public bool IsNicknamed
            {
                get
                {
                    return GetPKMIsNicknamed(this) == 1;
                }
                set
                {
                    SetPKMIsNicknamed(this, value);
                }
            }
            public bool IsFateful
            {
                get
                {
                    return GetPKMFateful(this) == 1;
                }
                set
                {
                    SetPKMFateful(this, value);
                }
            }
            public int GenderID
            {
                get
                {
                    return GetPKMGender(this);
                }
                set
                {
                    SetPKMGender(this, value);
                }
            }
            public Byte FormID
            {
                get
                {
                    return GetPKMForm(this);
                }
                set
                {
                    SetPKMForm(this, value);
                }
            }
            public Byte NatureID
            {
                get
                {
                    return GetPKMNature(this);
                }
                set
                {
                    SetPKMNature(this, value);
                }
            }
            public bool HasDWAbility
            {
                get
                {
                    return GetPKMDWAbility(this);
                }
                set
                {
                    SetPKMDWAbility(this, value);
                }
            }
            public bool IsNsPokemon
            {
                get
                {
                    return GetPKMNsPokemon(this) == 1;
                }
                set
                {
                    SetPKMNsPokemon(this, value);
                }
            }
            public string Nickname
            {
                get
                {
                    return GetPKMNickname(this);
                }
                set
                {
                    SetPKMNickname(this, value, value.Length);
                }
            }
            public Byte HometownID
            {
                get
                {
                    return GetPKMHometown(this);
                }
                set
                {
                    SetPKMHometown(this, value);
                }
            }
            public string OTName
            {
                get
                {
                    return GetPKMOTName(this);
                }
                set
                {
                    SetPKMOTName(this, value, value.Length);
                }
            }
            public void SetNoEggDate()
            {
                this.Data[0x78] = 0;
                this.Data[0x79] = 0;
                this.Data[0x7A] = 0;
            }
            public DateTime EggDate
            {
                get
                {
                    return new DateTime(GetPKMEggYear(this), GetPKMEggMonth(this), GetPKMEggDay(this));
                }
                set
                {
                    SetPKMEggYear(this, value.Year);
                    SetPKMEggMonth(this, value.Month);
                    SetPKMEggDay(this, value.Day);
                }
            }
            public DateTime MetDate
            {
                get
                {
                    return new DateTime(GetPKMMetYear(this), GetPKMMetMonth(this), GetPKMMetDay(this));
                }
                set
                {
                    SetPKMMetYear(this, value.Year);
                    SetPKMMetMonth(this, value.Month);
                    SetPKMMetDay(this, value.Day);
                }
            }
            public UInt16 EggLocationID
            {
                get
                {
                    return GetPKMEggLocation(this);
                }
                set
                {
                    SetPKMEggLocation(this, value);
                }
            }
            public UInt16 MetLocationID
            {
                get
                {
                    return GetPKMMetLocation(this);
                }
                set
                {
                    SetPKMMetLocation(this, value);
                }
            }
            public int PokerusStrain
            {
                get
                {
                    return GetPKMPokerusStrain(this);
                }
                set
                {
                    SetPKMPokerusStrain(this, value);
                }
            }
            public int PokerusDays
            {
                get
                {
                    return GetPKMPokerusDays(this);
                }
                set
                {
                    SetPKMPokerusDays(this, value);
                }
            }
            public Byte BallID
            {
                get
                {
                    return GetPKMBall(this);
                }
                set
                {
                    SetPKMBall(this, value);
                }
            }
            public Byte MetLevel
            {
                get
                {
                    return GetPKMMetLevel(this);
                }
                set
                {
                    SetPKMMetLevel(this, value);
                }
            }
            public int OTGenderID
            {
                get
                {
                    return GetPKMOTGender(this);
                }
                set
                {
                    SetPKMOTGender(this, value);
                }
            }
            public int EncounterID
            {
                get
                {
                    return GetPKMEncounter(this);
                }
                set
                {
                    SetPKMEncounter(this, value);
                }
            }
            public bool IsModified
            {
                get
                {
                    return IsPKMModified(this);
                }
            }
            public void FixChecksum()
            {
                FixPokemonChecksum(this);
            }
            public System.Drawing.Image Icon
            {
                get
                {
                    return PKMDS.GetIcon(this.SpeciesID, this.FormID, PKMDS.HasFemaleIcon(this) == 1);
                }
            }
            public bool IsShiny
            {
                get
                {
                    return PKMDS.IsPKMShiny(this);
                }
            }
            public int GetType(int Slot)
            {
                return GetPKMType(this, Slot);
            }
            public System.Drawing.Image GetTypePic(int Slot)
            {
                if ((Slot == 1) | (Slot == 2))
                {
                    return PKMDS.GetTypeImage(this.GetType(Slot));
                }
                else
                {
                    return null;
                }
            }
            public UInt32 TNL
            {
                get
                {
                    return PKMDS.GetPKMTNL(this);
                }
            }
            public UInt32 EXPAtCurLevel
            {
                get
                {
                    return PKMDS.GetPKMEXPCurLevel(this);
                }
            }
            public UInt32 EXPAtGivenLevel(int Level)
            {
                return GetPKMEXPGivenLevel(this, Level);
            }
            public System.Drawing.Color Color
            {
                get
                {
                    return System.Drawing.ColorTranslator.FromHtml("#" + GetPKMColorValue(this).ToString("X6"));
                }
            }
            public System.Drawing.Image ShinyIcon
            {
                get
                {
                    return GetShinyStar(this.IsShiny);
                }
            }
            public System.Drawing.Image GenderIcon
            {
                get
                {
                    return PKMDS.GetGenderIcon(this.GenderID);
                }
            }
            public System.Drawing.Image ItemPic
            {
                get
                {
                    return PKMDS.GetItemImage(this.ItemID);
                }
            }
            public System.Drawing.Image GetMarkingImage(int marking)
            {
                return PKMDS.GetMarkingImage(marking, this.GetMarking(marking));
            }
            public System.Drawing.Image BallPic
            {
                get
                {
                    return PKMDS.GetBallImage(this.BallID);
                }
            }
            public System.Drawing.Image MoveCategoryPic(UInt16 move)
            {
                return PKMDS.GetMoveCategoryImage(move);
            }
            public System.Drawing.Image PokerusIcon
            {
                get
                {
                    if (this.PokerusStrain > 0)
                    {
                        if (this.PokerusDays > 0)
                        {
                            return GetResourceByName("pokerus_infected");
                        }
                        else
                        {
                            return GetResourceByName("pokerus_cured");
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            public string Characteristic
            {
                get
                {
                    return GetCharacteristic(this);
                }
            }
            public int NatureIncrease
            {
                get
                {
                    return GetNatureIncrease(this);
                }
            }
            public int NatureDecrease
            {
                get
                {
                    return GetNatureDecrease(this);
                }
            }
            public Pokemon Clone()
            {
                byte[] ClonedData = new byte[this.Data.Length];
                Data.CopyTo(ClonedData, 0);
                return new Pokemon { Data = ClonedData };
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public class PartyPokemon
        {
            public PartyPokemon()
            {
                this.PokemonData = new PKMDS.Pokemon();
                this.PartyData = new byte[84];
            }
            public Pokemon PokemonData;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 84)]
            private byte[] PartyData;
            public void WriteToFile(string FileName, bool encrypt = false)
            {
                WritePokemonFile(this.PokemonData, FileName, encrypt);
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public class Save
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x80000)]
            private byte[] Data;
            public string TrainerName
            {
                get
                {
                    return GetTrainerName_FromSav(this);
                }
                set
                {
                    SetTrainerName_FromSav(this, value);
                }
            }
            public UInt16 TID
            {
                get
                {
                    return GetTrainerTID_FromSav(this);
                }
                set
                {
                    SetTrainerTID_FromSav(this, value);
                }
            }
            public UInt16 SID
            {
                get
                {
                    return GetTrainerSID_FromSav(this);
                }
                set
                {
                    SetTrainerSID_FromSav(this, value);
                }
            }
            public string GetBoxName(int Box)
            {
                return PKMDS.GetBoxName(this, Box);
            }
            public void SetBoxName(int Box, string Name)
            {
                PKMDS.SetBoxName(this, Box, Name, Name.Length);
            }
            public int GetBoxWallpaperIndex(int Box)
            {
                return PKMDS.GetBoxWallpaper(this, Box);
            }
            public void SetBoxWallpaperIndex(int Box, int Wallpaper)
            {
                PKMDS.SetBoxWallpaper(this, Box, Wallpaper);
            }
            public System.Drawing.Image GetBoxWallpaper(int box)
            {
                return GetWallpaperImage(GetBoxWallpaperIndex(box));
            }
            public void WriteToFile(string FileName)
            {
                WriteSaveFile(this, FileName);
            }
            public Pokemon GetStoredPokemon(int Box, int Slot)
            {
                Pokemon pkm = new Pokemon();
                GetPKMData(ref pkm, this, Box, Slot);
                return pkm;
            }
            public void SetStoredPokemon(Pokemon pokemon, int Box, int Slot)
            {
                SetPKMData(pokemon, this, Box, Slot);
            }
            public PartyPokemon GetPartyPokemon(int Slot)
            {
                PartyPokemon pkm = new PartyPokemon();
                GetPartyPKMData(ref pkm, this, Slot);
                return pkm;
            }
            public void SetPartyPokemon(PartyPokemon pokemon, int Slot)
            {
                SetPartyPKMData(pokemon, this, Slot);
            }
            public int PartySize
            {
                get
                {
                    return GetPartySize(this);
                }
                set
                {
                    SetPartySize(this, value);
                }
            }
            public int CurrentBox
            {
                get
                {
                    return GetCurrentBox(this);
                }
                set
                {
                    SetCurrentBox(this, value);
                }
            }
            public unsafe System.Drawing.Bitmap GetBoxGrid(int box)
            {
                System.Drawing.Bitmap b = new System.Drawing.Bitmap(60, 50);
                System.Drawing.Imaging.BitmapData bData = b.LockBits(new System.Drawing.Rectangle(0, 0, 60, 50), System.Drawing.Imaging.ImageLockMode.ReadWrite, b.PixelFormat);
                byte* scan0 = (byte*)bData.Scan0.ToPointer();
                for (int sloty = 0; sloty < 5; sloty++)
                {
                    for (int slotx = 0; slotx < 6; slotx++)
                    {
                        Pokemon pkm = GetStoredPokemon(box, (sloty * 6 + slotx));
                        if (pkm.SpeciesID != 0)
                        {
                            int color = pkm.Color.ToArgb();
                            for (int x = 0; x < 10; x++)
                            {
                                for (int y = 0; y < 10; y++)
                                {
                                    int yabs = (sloty * 10) + y;
                                    int xabs = (slotx * 10) + x;
                                    byte* data = scan0 + yabs * bData.Stride + xabs * 4;
                                    byte[] colordata = BitConverter.GetBytes(color);
                                    data[0] = colordata[0];
                                    data[1] = colordata[1];
                                    data[2] = colordata[2];
                                    data[3] = 0xFF;
                                }
                            }
                        }
                    }
                }
                b.UnlockBits(bData);
                return b;
            }
            public int BoxCount(int box)
            {
                return PKMDS.GetBoxCount(this, box);
            }
            public bool DepositPokemon(Pokemon pokemon, int box)
            {
                return PKMDS.DepositPKM(this, pokemon, box, true);
            }
            public bool WithdrawPokemon(Pokemon pokemon)
            {
                return PKMDS.WithdrawPKM(this, pokemon);
            }
            public void RemovePartyPokemon(int slot)
            {
                PKMDS.DeletePartyPKM(this, slot);
            }
            public void RecalculateParty()
            {
                for (int slot = 0; slot < this.PartySize; slot++)
                {
                    PartyPokemon ppkm = this.GetPartyPokemon(slot);
                    if (ppkm.PokemonData.SpeciesID != 0)
                    {
                        PKMDS.RecalcPartyPKM(ppkm);
                        this.SetPartyPokemon(ppkm, slot);
                    }
                }
            }
            public void RemoveStoredPokemon(int box, int slot)
            {
                PKMDS.DeleteStoredPKM(this, box, slot);
            }
            public bool Validate(out string message)
            {
                return ValidateSave(this, out message);
            }
        }
    }
}
