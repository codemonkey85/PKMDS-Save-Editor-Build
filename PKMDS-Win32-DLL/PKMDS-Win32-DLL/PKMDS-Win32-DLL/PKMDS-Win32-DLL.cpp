// PKMDS-Win32-DLL.cpp : Defines the exported functions for the DLL application.
//
#include "stdafx.h"
#include "../../../PKMDS/include/pkmds/pkmds_sql.h"
#include <comutil.h>
BSTR UTF8toBSTR(const char* input);
#define EXPORT extern "C" __declspec(dllexport)
EXPORT int HasFemaleSprite(pokemon_obj * pkm)
{
	return (pkmhasgenddiff(pkm) && (calcpkmgender(pkm) == Genders::female)) & (pkm->species != Species::torchic) & (pkm->species != Species::buizel) & (pkm->species != Species::floatzel);
}
EXPORT int HasFemaleIcon(pokemon_obj * pkm)
{
	return ((pkm->species == Species::unfezant) | (pkm->species == Species::frillish) | (pkm->species == Species::jellicent)) && (calcpkmgender(pkm) == Genders::female);
}
EXPORT void OpenDB(const char * dbfilename)
{
	opendb(dbfilename);
}
EXPORT void CloseDB()
{
	closedb();
}
EXPORT void OpenImgDB(const char * dbfilename)
{
	openimgdb(dbfilename);
}
EXPORT void CloseImgDB()
{
	openimgdb();
}
EXPORT BSTR GetAString(const char * sql)
{
	std::string str_pkmname = getastring(sql);
	return UTF8toBSTR(str_pkmname.c_str());
}
EXPORT int GetAnInt(const char * sql)
{
	return getanint(sql);
}
EXPORT void GetAPic_INTERNAL(const char * sql, byte ** picdata, int * size)
{
	getapic(sql, picdata, size);
}
EXPORT void GetSAVData_INTERNAL(bw2sav_obj * save, const wchar_t * savefile)
{
	read(savefile, save);
};
EXPORT BSTR GetItemName_INTERNAL(int itemid, int generation, int langid)
{
	std::string ret = lookupitemname(itemid, generation, langid).c_str();
	return UTF8toBSTR(ret.c_str());
}
EXPORT BSTR GetItemFlavor_INTERNAL(int itemid, int generation, int langid, int versiongroup)
{
	std::string ret = lookupitemflavortext(itemid, generation, langid, versiongroup).c_str();
	return UTF8toBSTR(ret.c_str());
}
EXPORT BSTR GetAbilityName_INTERNAL(int abilityid, int langid)
{
	std::string ret = lookupabilityname(abilityid, langid);
	return UTF8toBSTR(ret.c_str());
}
EXPORT BSTR GetAbilityFlavor_INTERNAL(int abilityid, int versiongroup, int langid)
{
	std::string ret = lookupabilityflavortext(abilityid, versiongroup, langid);
	return UTF8toBSTR(ret.c_str());
}
EXPORT BSTR GetMoveName(int moveid, int langid)
{
	std::string ret = lookupmovename(moveid, langid).c_str();
	return UTF8toBSTR(ret.c_str());
}
EXPORT BSTR GetMoveFlavor(int moveid, int langid, int versiongroup)
{
	std::string ret = lookupmoveflavortext(moveid, langid, versiongroup).c_str();
	return UTF8toBSTR(ret.c_str());
}
EXPORT BSTR GetTypeName(int type)
{
	std::string ret = lookuptypename(type);
	return UTF8toBSTR(ret.c_str());
}
EXPORT BSTR GetMoveTypeName(uint16 moveid, int langid)
{
	std::string ret = lookupmovetypename(moveid, langid).c_str();
	return UTF8toBSTR(ret.c_str());
}
EXPORT void GetTrainerName_FromSav_INTERNAL(bw2sav_obj * sav, wchar_t ** name, int* length)
{
	wstring wstr_otname = getsavtrainername(&(sav->cur));
	*length = wstr_otname.length();
	*name = new wchar_t[OTLENGTH];
	memset(*name, 0xff, OTLENGTH);
	for (int i = 0; i < OTLENGTH; i++)
	{
		if (i < wstr_otname.length())
		{
			(*name)[i] = wstr_otname[i];
		}
	}
}
EXPORT void SetTrainerName_FromSav_INTERNAL(bw2sav_obj * sav, wchar_t * name, int namelength)
{
	setsavetrainername(sav, name, namelength);
}
EXPORT BSTR GetCharacteristic(pokemon_obj * pkm)
{
	std::string characteristic = lookupcharacteristic(pkm);
	return UTF8toBSTR(characteristic.c_str());
}
EXPORT int GetNatureIncrease(pokemon_obj * pkm)
{
	return getnatureincrease(pkm);
}
EXPORT int GetNatureDecrease(pokemon_obj * pkm)
{
	return getnaturedecrease(pkm);
}
EXPORT BSTR GetNatureName(int natureid, int langid)
{
	std::string nature = getnaturename(natureid, langid);
	return UTF8toBSTR(nature.c_str());
}
EXPORT BSTR GetLocationName(int locationid, int generation, int langid)
{
	std::string location = lookuplocname(locationid, generation, langid);
	return UTF8toBSTR(location.c_str());
}
EXPORT int GetBoxWallpaper(bw2sav_obj * sav, int box)
{
	return int(sav->cur.boxwallpapers[box]);
}
EXPORT void SetBoxWallpaper(bw2sav_obj * sav, int box, int wallpaper)
{
	sav->cur.boxwallpapers[box] = Wallpapers::wallpapers(wallpaper);
}
EXPORT uint16 GetTrainerTID_FromSav(bw2sav_obj * sav)
{
	return sav->cur.tid;
}
EXPORT void SetTrainerTID_FromSav(bw2sav_obj * sav, int tid)
{
	sav->cur.tid = tid;
}
EXPORT void SetTrainerSID_FromSav(bw2sav_obj * sav, int sid)
{
	sav->cur.sid = sid;
}
EXPORT uint32 GetPKMColorValue(pokemon_obj * pkm)
{
	if (pkm->isegg)
	{
		if (pkm->species == Species::manaphy)
		{
			return getpkmcolorhex(PokemonColors::blue);
		}
		else
		{
			return getpkmcolorhex(PokemonColors::white);
		}
	}
	return getpkmcolor(pkm->species);
}
EXPORT uint16 GetTrainerSID_FromSav(bw2sav_obj * sav)
{
	return sav->cur.sid;
}
EXPORT uint32 GetPKMTNL(pokemon_obj * pkm)
{
	return getpkmexptonext(pkm);
}
EXPORT uint32 GetPKMEXPCurLevel(pokemon_obj * pkm)
{
	return getpkmexpatcur(pkm);
}
EXPORT uint32 GetPKMEXPGivenLevel(pokemon_obj * pkm, int level)
{
	return getpkmexpatlevel(pkm->species, level);
}
EXPORT void GetBoxName_INTERNAL(bw2sav_obj * sav, int box, wchar_t ** boxname, int* length)
{
	wstring wstr_boxname = getboxname(&(sav->cur), box);
	*length = wstr_boxname.length();
	*boxname = new wchar_t[BOXNAMELENGTH];
	memset(*boxname, 0xff, BOXNAMELENGTH);
	for (int i = 0; i < BOXNAMELENGTH; i++)
	{
		if (i < wstr_boxname.length())
		{
			(*boxname)[i] = wstr_boxname[i];
		}
	}
}
EXPORT int GetPKMStat(bw2sav_obj * sav, int box, int slot, int stat)
{
	pokemon_obj * pkm = &(sav->cur.boxes[box].pokemon[slot]);
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	int ret = getpkmstat(pkm, Stat_IDs::stat_ids(stat));
	return ret;
}
EXPORT int GetMovePower(uint16 moveid)
{
	return getmovepower(Moves::moves(moveid));
}
EXPORT int GetMoveAccuracy(uint16 moveid)
{
	return getmoveaccuracy(Moves::moves(moveid));
}
EXPORT int GetMoveBasePP(uint16 moveid)
{
	return getmovepp(Moves::moves(moveid));
}
EXPORT void GetBoxGrid_INTERNAL(bw2sav_obj * sav, int box, byte ** picdata)
{
	//*picdata = new byte[57600];
	//pokemon_obj * pkm = new pokemon_obj();
	//for (int slot = 0; slot < 30; slot++)
	//{
	//	pkm = &(sav->cur.boxes[box].pokemon[slot]);
	//	if (!pkm->isboxdatadecrypted)
	//	{
	//		decryptpkm(pkm);
	//	}
	//	uint32 color = getpkmcolor(pkm->species);
	//	memcpy((*picdata) + (slot * 4), &color, 4);
	//}
}
EXPORT void GetTypePic_INTERNAL(int type, byte ** picdata, int * size)
{
	std::ostringstream o;
	gettypesql(o, type);
	getapic(o, picdata, size);
}
EXPORT void GetShinyStar_INTERNAL(byte ** picdata, int * size)
{
	std::ostringstream o;
	o << "select image from misc where identifier = \"shiny\"";
	getapic(o, picdata, size);
}
EXPORT void GetGenderPic_INTERNAL(int gender, byte ** picdata, int * size)
{
	std::ostringstream o;
	std::string strgender = "male";
	if (gender == int(Genders::female))
	{
		strgender = "female";
	}
	o << "select image from misc where identifier = \"" + strgender + "\"";
	getapic(o, picdata, size);
}
EXPORT void GetWallpaperImage_INTERNAL(int wallpaper, byte ** picdata, int * size)
{
	std::ostringstream o;
	getwallpapersql(o, wallpaper);
	getapic(o, picdata, size);
}
EXPORT int ValidateSave_INTERNAL(bw2sav_obj * sav, wchar_t ** message, int * length)
{
	int result = 1;
	wstring wstr_message = L"";
	bool isbw2 = savisbw2(sav);
	if (!((getchecksum(sav->cur, (long)BW2_OFFSETS::chkcalcloc, (long)BW2_OFFSETS::chkcalclen)) == (getchkfromsav(sav->cur, true))) ||
		(getchecksum(sav->cur, (long)BW_OFFSETS::chkcalcloc, (long)BW_OFFSETS::chkcalclen)) == (getchkfromsav(sav->cur, false)))
	{
		result = 0;
		wstr_message = L"Invalid save file!";
	}
	*length = wstr_message.length();
	*message = new wchar_t[wstr_message.length()];
	for (int i = 0; i < wstr_message.length(); i++)
	{
		if (i < wstr_message.length())
		{
			(*message)[i] = wstr_message[i];
		}
	}
	return result;
}
EXPORT BSTR GetItemIdentifier(uint16 item)
{
	string ret = "";
	if (((item >= (uint16)Items::tm01) & (item <= (uint16)Items::tm92)) | ((item >= (uint16)Items::tm93) & (item <= (uint16)Items::tm95)) | ((item >= (uint16)Items::hm01) & (item <= (uint16)Items::hm06)))
	{
		std::string mprefix = "tm-";
		if ((item >= (uint16)Items::hm01) & (item <= (uint16)Items::hm06)){ mprefix = "hm-"; }
		ret = mprefix + getmachinetypename(Items::items(item));
	}
	else if ((item >= (uint16)Items::datacard01) & (item <= (uint16)Items::datacard27))
	{
		ret = "data-card";
	}
	else
	{
		ostringstream o;
		o << ""
			<< "SELECT items.identifier "
			<< "FROM   items "
			<< "       INNER JOIN item_game_indices "
			<< "               ON items.id = item_game_indices.item_id "
			<< "WHERE  ( item_game_indices.game_index = " << (int)(item) << " ) "
			<< "       AND ( item_game_indices.generation_id = " << GENERATION << ") ";
		ret = getastring(o);
	}
	return UTF8toBSTR(ret.c_str());
}
EXPORT void GetItemImage_INTERNAL(int item, byte ** picdata, int * size)
{
	std::ostringstream o;
	if (((item >= (int)Items::tm01) & (item <= (int)Items::tm92)) | ((item >= (int)Items::tm93) & (item <= (int)Items::tm95)) | ((item >= (int)Items::hm01) & (item <= (int)Items::hm06)))
	{
		std::string mprefix = "tm-";
		if ((item >= (int)Items::hm01) & (item <= (int)Items::hm06)){ mprefix = "hm-"; }
		std::string sql = "select image from items where (identifier = \"" + mprefix + getmachinetypename(Items::items(item)) + "\")";
		o << sql.c_str();
	}
	else if ((item >= (int)Items::datacard01) & (item <= (int)Items::datacard27))
	{
		std::string sql = "select image from items where (identifier = \"data-card\")";
		o << sql.c_str();
	}
	else
	{
		getitemsql(o, item);
	}
	getapic(o, picdata, size);
}
EXPORT int GetPKMType_INTERNAL(pokemon_obj * pkm, int type, int generation)
{
	return lookuppkmtype(pkm, type, generation);
}
EXPORT void GetMarkingImage_INTERNAL(int marking, bool marked, byte ** picdata, int * size)
{
	std::ostringstream o;
	getmarkingsql(o, Markings::markings(marking), marked);
	getapic(o, picdata, size);
}
EXPORT void GetBallPic_INTERNAL(byte ball, byte ** picdata, int * size)
{
	std::ostringstream o;
	getballsql(o, Balls::balls(ball));
	getapic(o, picdata, size);
}
EXPORT BSTR GetMoveCategory(uint16 move)
{
	string catname = "";
	switch((MoveCategories::movecategories)getmovecategory(Moves::moves(move)))
	{
	case MoveCategories::physical:
		catname = "physical";
		break;
	case MoveCategories::special:
		catname = "special";
		break;
	case MoveCategories::other:
		catname = "other";
		break;
	}
	return UTF8toBSTR(catname.c_str());
}
EXPORT void GetMoveCategoryImage_INTERNAL(int move, byte ** picdata, int * size)
{
	std::ostringstream o;
	getmovecatsql(o, Moves::moves(move));
	getapic(o, picdata, size);
}
EXPORT void GetMoveTypeImage_INTERNAL(uint16 move, byte ** picdata, int * size)
{
	GetTypePic_INTERNAL(int(getmovetype(Moves::moves(move))), picdata, size);
}
EXPORT void GetPokerusImage_INTERNAL(int strain, int days, byte ** picdata, int * size)
{
	std::ostringstream o;
	if (strain != 0)
	{
		if (days > 0)
		{
			o << "select image from misc where identifier = \"pokerus_infected\"";
		}
		else
		{
			o << "select image from misc where identifier = \"pokerus_cured\"";
		}
	}
	getapic(o, picdata, size);
}
EXPORT void GetRibbonImage_INTERNAL(string ribbon, bool hoenn, byte ** picdata, int * size)
{
	std::ostringstream o;
	o << getribbonsql(ribbon, hoenn);
	getapic(o, picdata, size);
}
EXPORT void FixSaveChecksums(bw2sav_obj * sav)
{
	bool isbw2 = savisbw2(sav);
	pokemon_obj * pkm = new pokemon_obj();
	party_pkm * ppkm = new party_pkm();
	for (int partyslot = 0; partyslot < sav->cur.party.size; partyslot++)
	{
		ppkm = &(sav->cur.party.pokemon[partyslot]);
		if (ppkm->isboxdatadecrypted)
		{
			calcchecksum(ppkm);
			encryptpkm(ppkm);
		}
		else if (ppkm->isboxdatadecrypted)
		{
			pkm = ppkm;
			calcchecksum(pkm);
			encryptpkm(pkm);
		}
		else
		{
			decryptpkm(pkm);
			calcchecksum(pkm);
			encryptpkm(pkm);
		}
	}
	calcpartychecksum(&(sav->cur), isbw2);
	for (int box = 0; box < 24; box++)
	{
		for (int slot = 0; slot < 30; slot++)
		{
			pkm = &(sav->cur.boxes[box].pokemon[slot]);
			if (pkm->isboxdatadecrypted)
			{
				calcchecksum(pkm);
				encryptpkm(pkm);
			}
			else
			{
				decryptpkm(pkm);
				calcchecksum(pkm);
				encryptpkm(pkm);
			}
		}
		calcboxchecksum(&(sav->cur), box, isbw2);
	}
	sav->cur.block1checksum = getchecksum(&(sav->cur), 0x0, 0x3e0);
	fixtrainerdatachecksum(&(sav->cur));
	fixbagchecksum(&(sav->cur));
	fixsavchecksum(sav, isbw2);
}
EXPORT void WriteSaveFile(bw2sav_obj * sav, const wchar_t * filename)
{
	FixSaveChecksums(sav);
	write(filename, sav);
}
EXPORT int GetCurrentBox(bw2sav_obj * sav)
{
	return sav->cur.curbox;
}
EXPORT void SetCurrentBox(bw2sav_obj * sav, int box)
{
	sav->cur.curbox = box;
}
EXPORT int GetPartySize(bw2sav_obj * sav)
{
	return sav->cur.party.size;
}
EXPORT void SetPartySize(bw2sav_obj * sav, int size)
{
	sav->cur.party.size = size;
}
EXPORT void SetBoxName(bw2sav_obj * sav, int box, wchar_t * name, int namelength)
{
	setsaveboxname(sav, box, name, namelength);
}
EXPORT BSTR GetPKMName(int speciesid, int langid)
{
	std::string ret = lookuppkmname(speciesid, langid).c_str();
	return UTF8toBSTR(ret.c_str());
}
EXPORT void WritePokemonFile(pokemon_obj * pkm, const wchar_t * filename, bool encrypt = false)
{
	if (pkm->isboxdatadecrypted)
	{
		calcchecksum(pkm);
	}
	else
	{
		decryptpkm(pkm);
		calcchecksum(pkm);
	}
	if (encrypt)
	{
		encryptpkm(pkm);
	}
	write(filename, pkm);
}
EXPORT void GetPKMData_INTERNAL(pokemon_obj * pokemon, bw2sav_obj * sav, int box, int slot)
{
	pokemon_obj * pkm = &(sav->cur.boxes[box].pokemon[slot]);
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	*pokemon = *pkm;
};
EXPORT void GetPartyPKMData_INTERNAL(party_pkm * pokemon, bw2sav_obj * sav, int slot)
{
	party_pkm * pkm = &(sav->cur.party.pokemon[slot]);
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	*pokemon = *pkm;
};
EXPORT void SetPartyPKMData_INTERNAL(party_pkm * pokemon, bw2sav_obj * sav, int slot)
{
	if (!(pokemon->isboxdatadecrypted))
	{
		decryptpkm(pokemon);
	}
	calcchecksum(pokemon);
	sav->cur.party.pokemon[slot] = *pokemon;
};
EXPORT void GetPKMDataFromFile_INTERNAL(pokemon_obj * pokemon, const wchar_t * filename, bool encrypted = false)
{
	read(filename, pokemon);
	if (encrypted)
	{
		decryptpkm(pokemon);
	}
	pokemon->isboxdatadecrypted = true;
};
EXPORT void SetPKMData_INTERNAL(pokemon_obj * pokemon, bw2sav_obj * sav, int box, int slot)
{
	if (!(pokemon->isboxdatadecrypted))
	{
		decryptpkm(pokemon);
	}
	calcchecksum(pokemon);
	sav->cur.boxes[box].pokemon[slot] = *pokemon;
};
EXPORT void GetPKMName_FromObj_INTERNAL(pokemon_obj * pkm, wchar_t ** pkmname, int* length)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	std::wstring wstr_pkmname = lookuppkmnamewstring(pkm);
	*length = wstr_pkmname.length();
	*pkmname = new wchar_t[NICKLENGTH];
	memset(*pkmname, 0xff, NICKLENGTH);
	for (int i = 0; i < NICKLENGTH; i++)
	{
		if (i < wstr_pkmname.length())
		{
			(*pkmname)[i] = wstr_pkmname[i];
		}
	}
}
EXPORT uint16 GetPKMMoveID(pokemon_obj * pokemon, int moveid)
{
	if (!(pokemon->isboxdatadecrypted))
	{
		decryptpkm(pokemon);
	}
	return pokemon->move_ints[moveid];
}
EXPORT void SetPKMMoveID(pokemon_obj * pokemon, int moveid, uint16 moveindex)
{
	if (!(pokemon->isboxdatadecrypted))
	{
		decryptpkm(pokemon);
	}
	pokemon->move_ints[moveid] = moveindex;
}
EXPORT int GetPKMStat_FromObj(pokemon_obj * pkm, int stat)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	int ret = getpkmstat(pkm, Stat_IDs::stat_ids(stat));
	return ret;
}
EXPORT void GetPKMSprite_INTERNAL(pokemon_obj * pkm, byte ** picdata, int * size, int generation)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	std::ostringstream o;
	getspritesql(o, pkm, generation);
	getapic(o, picdata, size);
}
EXPORT void GetPKMIcon_INTERNAL(pokemon_obj * pkm, byte ** picdata, int * size, int generation)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	std::ostringstream o;
	geticonsql(o, pkm, generation);
	getapic(o, picdata, size);
}
EXPORT int GetPKMLevel(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return getpkmlevel(pkm);
}
EXPORT void SetPKMLevel(pokemon_obj * pkm, int level)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->exp = getpkmexpatlevel(pkm->species, level);
}
EXPORT uint16 GetPKMSpeciesID(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->species_int;
}
EXPORT void SetPKMSpeciesID(pokemon_obj * pkm, int speciesid)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->species_int = speciesid;
}
EXPORT uint32 GetPKMPID(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->pid;
}
EXPORT void SetPKMPID(pokemon_obj * pkm, int pid)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->pid = pid;
}
EXPORT uint16 GetPKMItemIndex(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->item_int;
}
EXPORT void SetPKMItemIndex(pokemon_obj * pkm, int item)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->item_int = item;
}
EXPORT uint16 GetPKMTID(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->tid;
}
EXPORT void SetPKMTID(pokemon_obj * pkm, int tid)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->tid = tid;
}
EXPORT uint16 GetPKMSID(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->sid;
}
EXPORT void SetPKMSID(pokemon_obj * pkm, int sid)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->sid = sid;
}
EXPORT uint32 GetPKMEXP(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->exp;
}
EXPORT void SetPKMEXP(pokemon_obj * pkm, uint32 exp)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->exp = exp;
}
EXPORT int GetPKMTameness(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->tameness;
}
EXPORT void SetPKMTameness(pokemon_obj * pkm, int tameness)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->tid = tameness;
}
EXPORT uint16 GetPKMAbilityIndex(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->ability_int;
}
EXPORT void SetPKMAbilityIndex(pokemon_obj * pkm, int ability)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->ability_int = ability;
}
EXPORT bool GetPKMMarking(pokemon_obj * pkm, int marking)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}

	switch (Markings::markings(marking))
	{
	case Markings::circle:
		return (pkm->markings.circle == true);
		break;
	case Markings::diamond:
		return (pkm->markings.diamond == true);
		break;
	case Markings::heart:
		return (pkm->markings.heart == true);
		break;
	case Markings::square:
		return (pkm->markings.square == true);
		break;
	case Markings::star:
		return (pkm->markings.star == true);
		break;
	case Markings::triangle:
		return (pkm->markings.triangle == true);
		break;
	default:
		return false;
		break;
	}
}
EXPORT void SetPKMMarking(pokemon_obj * pkm, int marking, bool marked)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	switch (Markings::markings(marking))
	{
	case Markings::circle:
		pkm->markings.circle = (marked == true);
		break;
	case Markings::diamond:
		pkm->markings.diamond = (marked == true);
		break;
	case Markings::heart:
		pkm->markings.heart = (marked == true);
		break;
	case Markings::square:
		pkm->markings.square = (marked == true);
		break;
	case Markings::star:
		pkm->markings.star = (marked == true);
		break;
	case Markings::triangle:
		pkm->markings.triangle = (marked == true);
		break;
	}
}
EXPORT byte GetPKMLanguage(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->country_int;
}
EXPORT void SetPKMLanguage(pokemon_obj * pkm, byte language)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->country_int = language;
}
EXPORT int GetPKMEV(pokemon_obj * pkm, int evindex)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	switch (Stats::stats(evindex))
	{
	case Stats::attack:
		return pkm->evs.attack;
		break;
	case Stats::defense:
		return pkm->evs.defense;
		break;
	case Stats::hp:
		return pkm->evs.hp;
		break;
	case Stats::spatk:
		return pkm->evs.spatk;
		break;
	case Stats::spdef:
		return pkm->evs.spdef;
		break;
	case Stats::speed:
		return pkm->evs.speed;
		break;
	}
}
EXPORT void SetPKMEV(pokemon_obj * pkm, int evindex, int ev)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	switch (Stats::stats(evindex))
	{
	case Stats::attack:
		pkm->evs.attack = ev;
		break;
	case Stats::defense:
		pkm->evs.defense = ev;
		break;
	case Stats::hp:
		pkm->evs.hp = ev;
		break;
	case Stats::spatk:
		pkm->evs.spatk = ev;
		break;
	case Stats::spdef:
		pkm->evs.spdef = ev;
		break;
	case Stats::speed:
		pkm->evs.speed = ev;
		break;
	}
}
EXPORT int GetPKMIV(pokemon_obj * pkm, int ivindex)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	switch (Stats::stats(ivindex))
	{
	case Stats::attack:
		return pkm->ivs.attack;
		break;
	case Stats::defense:
		return pkm->ivs.defense;
		break;
	case Stats::hp:
		return pkm->ivs.hp;
		break;
	case Stats::spatk:
		return pkm->ivs.spatk;
		break;
	case Stats::spdef:
		return pkm->ivs.spdef;
		break;
	case Stats::speed:
		return pkm->ivs.speed;
		break;
	}
}
EXPORT void SetPKMIV(pokemon_obj * pkm, int ivindex, int iv)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	switch (Stats::stats(ivindex))
	{
	case Stats::attack:
		pkm->ivs.attack = iv;
		break;
	case Stats::defense:
		pkm->ivs.defense = iv;
		break;
	case Stats::hp:
		pkm->ivs.hp = iv;
		break;
	case Stats::spatk:
		pkm->ivs.spatk = iv;
		break;
	case Stats::spdef:
		pkm->ivs.spdef = iv;
		break;
	case Stats::speed:
		pkm->ivs.speed = iv;
		break;
	}
}
EXPORT int GetPKMContest(pokemon_obj * pkm, int contestindex)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	switch (ContestStats::conteststats(contestindex))
	{
	case ContestStats::beauty:
		return pkm->contest.beauty;
		break;
	case ContestStats::cool:
		return pkm->contest.cool;
		break;
	case ContestStats::cute:
		return pkm->contest.cute;
		break;
	case ContestStats::sheen:
		return pkm->contest.sheen;
		break;
	case ContestStats::smart:
		return pkm->contest.smart;
		break;
	case ContestStats::tough:
		return pkm->contest.tough;
		break;
	}
}
EXPORT void SetPKMContest(pokemon_obj * pkm, int contestindex, int contest)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	switch (ContestStats::conteststats(contestindex))
	{
	case ContestStats::beauty:
		pkm->contest.beauty = contest;
		break;
	case ContestStats::cool:
		pkm->contest.cool = contest;
		break;
	case ContestStats::cute:
		pkm->contest.cute = contest;
		break;
	case ContestStats::sheen:
		pkm->contest.sheen = contest;
		break;
	case ContestStats::smart:
		pkm->contest.smart = contest;
		break;
	case ContestStats::tough:
		pkm->contest.tough = contest;
		break;
	}
}
EXPORT int GetPKMMovePP(pokemon_obj * pkm, int move)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->pp[move];
}
EXPORT void SetPKMMovePP(pokemon_obj * pkm, int move, int pp)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->pp[move] = pp;
}
EXPORT int GetPKMMovePPUp(pokemon_obj * pkm, int move)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->ppup[move];
}
EXPORT void SetPKMMovePPUp(pokemon_obj * pkm, int move, int ppup)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->ppup[move] = ppup;
}
EXPORT int GetPKMIsEgg(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return (pkm->isegg == true);
}
EXPORT void SetPKMIsEgg(pokemon_obj * pkm, bool isegg)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->isegg = isegg;
}
EXPORT int GetPKMIsNicknamed(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return (pkm->isnicknamed == true);
}
EXPORT void SetPKMIsNicknamed(pokemon_obj * pkm, bool isnicknamed)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->isnicknamed = isnicknamed;
}
EXPORT int GetPKMFateful(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return (pkm->fencounter == true);
}
EXPORT void SetPKMFateful(pokemon_obj * pkm, bool isfateful)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->fencounter = isfateful;
}
EXPORT int GetPKMGender(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	if (pkm->genderless == true)
	{
		return 2;
	}
	else
	{
		return int(calcpkmgender(pkm));
	}
}
EXPORT void SetPKMGender(pokemon_obj * pkm, int gender)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	setpkmgender(pkm, gender);
}
EXPORT BSTR GetPKMFormNames_INTERNAL(uint16 speciesid)
{
	std::ostringstream forms;
	switch (Species::species(speciesid))
	{
	case Species::castform:
		forms << "" << ",";
		break;
	case Species::rotom:
		forms << "" << ",";
		break;
	case Species::kyurem:
		forms << "" << ",";
		break;
	case Species::genesect:
		forms << "" << ",";
		break;
	default:
		break;
	}
	for (int formid = 0; formid < 28; formid++)
	{
		std::string formname = getpkmformname((int)(speciesid), formid);
		if (formname != "")
		{
			forms << formname << ",";
		}
	}
	return UTF8toBSTR(forms.str().c_str());
	//std::string formsreturned = forms.str();
	//formsreturned = formsreturned.erase(formsreturned.length - 1, 1);
	//return UTF8toBSTR(formsreturned.c_str);
}
EXPORT BSTR GetPKMFormName_INTERNAL(uint16 speciesid, byte formid)
{
	//	ostringstream o;
	//o << ""
	//	<< "select pokemon_form_names.form_name "
	//	<< "from pokemon "
	//	<< "inner join pokemon_forms on pokemon.id = pokemon_forms.pokemon_id "
	//	<< "inner join pokemon_form_names on pokemon_forms.id = pokemon_form_names.pokemon_form_id "
	//	<< "inner join pokemon_form_generations on pokemon_forms.id = pokemon_form_generations.pokemon_form_id "
	//	<< "where local_language_id = " << 9 << " "
	//	<< "and generation_id = " << 5 << " "
	//	<< "and species_id = " << (int)speciesid << " "
	//	<< "and game_index = " << (int)formid << " "
	//	<< "order by pokemon_form_generations.game_index";
	std::string formname = getpkmformname((int)(speciesid), formid);
	return UTF8toBSTR(formname.c_str());
}
EXPORT byte GetPKMForm(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->form_int;
}
EXPORT void SetPKMForm(pokemon_obj * pkm, int form)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->form_int = form;
}
EXPORT byte GetPKMNature(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->nature_int;
}
EXPORT void SetPKMNature(pokemon_obj * pkm, int nature)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->nature_int = nature;
}
EXPORT bool GetPKMDWAbility(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return (pkm->hasdwability == true);
}
EXPORT void SetPKMDWAbility(pokemon_obj * pkm, bool hasdwability)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->hasdwability = hasdwability;
}
EXPORT int GetPKMNsPokemon(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return (pkm->n_pkm == true);
}
EXPORT void SetPKMNsPokemon(pokemon_obj * pkm, bool isnspokemon)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->n_pkm = isnspokemon;
}
EXPORT void SetPKMNickname(pokemon_obj * pkm, wchar_t * nickname, int nicknamelength)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	setpkmnickname(pkm, nickname, nicknamelength);
}
EXPORT byte GetPKMHometown(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->hometown_int;
}
EXPORT void SetPKMHometown(pokemon_obj * pkm, byte hometown)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->hometown_int = hometown;
}
EXPORT void GetPKMOTName_INTERNAL(pokemon_obj * pkm, wchar_t ** otname, int* length)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	wstring wstr_otname = getpkmotname(pkm);
	*length = wstr_otname.length();
	*otname = new wchar_t[OTLENGTH];
	memset(*otname, 0xff, OTLENGTH);
	for (int i = 0; i < OTLENGTH; i++)
	{
		if (i < wstr_otname.length())
		{
			(*otname)[i] = wstr_otname[i];
		}
	}
}
EXPORT void GetPKMNickName_INTERNAL(pokemon_obj * pkm, wchar_t ** nickname, int* length)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	wstring wstr_nickname = getpkmnickname(pkm);
	*length = wstr_nickname.length();
	*nickname = new wchar_t[NICKLENGTH];
	memset(*nickname, 0xff, NICKLENGTH);
	for (int i = 0; i < NICKLENGTH; i++)
	{
		if (i < wstr_nickname.length())
		{
			(*nickname)[i] = wstr_nickname[i];
		}
	}
}
EXPORT void SetPKMOTName(pokemon_obj * pkm, wchar_t * otname, int otnamelength)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	setpkmotname(pkm, otname, otnamelength);
}
EXPORT bool GetPKMMetAsEgg(pokemon_obj * pkm)
{
	return pkmmetasegg(pkm);
}
EXPORT int GetPKMEggYear(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->eggdate.year + 2000;
}
EXPORT void SetPKMEggYear(pokemon_obj * pkm, int year)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->eggdate.year = year - 2000;
}
EXPORT int GetPKMEggMonth(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->eggdate.month;
}
EXPORT void SetPKMEggMonth(pokemon_obj * pkm, int month)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->eggdate.month = month;
}
EXPORT int GetPKMEggDay(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->eggdate.day;
}
EXPORT void SetPKMEggDay(pokemon_obj * pkm, int day)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->eggdate.day = day;
}
EXPORT int GetPKMMetYear(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->metdate.year + 2000;
}
EXPORT void SetPKMMetYear(pokemon_obj * pkm, int year)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->metdate.year = year - 2000;
}
EXPORT int GetPKMMetMonth(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->metdate.month;
}
EXPORT void SetPKMMetMonth(pokemon_obj * pkm, int month)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->metdate.month = month;
}
EXPORT int GetPKMMetDay(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->metdate.day;
}
EXPORT void SetPKMMetDay(pokemon_obj * pkm, int day)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->metdate.day = day;
}
EXPORT uint16 GetPKMEggLocation(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->eggmet_int;
}
EXPORT void SetPKMEggLocation(pokemon_obj * pkm, int location)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->eggmet_int = location;
}
EXPORT uint16 GetPKMMetLocation(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->met_int;
}
EXPORT void SetPKMMetLocation(pokemon_obj * pkm, int location)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->met_int = location;
}
EXPORT int GetPKMPokerusStrain(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->pkrs.strain;
}
EXPORT void SetPKMPokerusStrain(pokemon_obj * pkm, int strain)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->pkrs.strain = strain;
}
EXPORT int GetPKMPokerusDays(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->pkrs.days;
}
EXPORT void SetPKMPokerusDays(pokemon_obj * pkm, int days)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->pkrs.days = days;
}
EXPORT byte GetPKMBall(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->ball_int;
}
EXPORT void SetPKMBall(pokemon_obj * pkm, int ball)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->ball_int = ball;
}
EXPORT byte GetPKMMetLevel(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->metlevel;
}
EXPORT void SetPKMMetLevel(pokemon_obj * pkm, byte level)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->metlevel = level;
}
EXPORT int GetPKMOTGender(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return int(pkm->otgender);
}
EXPORT void SetPKMOTGender(pokemon_obj * pkm, int gender)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->otgender = Genders::genders(gender);
}
EXPORT int GetPKMEncounter(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return pkm->encounter_int;
}
EXPORT void SetPKMEncounter(pokemon_obj * pkm, int encounter)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	pkm->encounter_int = encounter;
}
EXPORT bool IsPKMModified(pokemon_obj * pkm)
{
	uint16 chk = pkm->checksum;
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	return (chk != getchecksum(pkm));
}
EXPORT void FixPokemonChecksum(pokemon_obj * pkm)
{
	if (!(pkm->isboxdatadecrypted))
	{
		decryptpkm(pkm);
	}
	calcchecksum(pkm);
}
EXPORT bool IsPKMShiny(pokemon_obj * pkm)
{
	return (getpkmshiny(pkm) == true);
}
EXPORT int GetBoxCount(bw2sav_obj * sav, int box)
{
	int count = 0;
	pokemon_obj * pkm = new pokemon_obj();
	for (int slot = 0; slot < 30; slot++)
	{
		pkm = &(sav->cur.boxes[box].pokemon[slot]);
		if (!(pkm->isboxdatadecrypted))
		{
			decryptpkm(pkm);
		}
		if (pkm->species != 0)
		{
			count++;
		}
	}
	return count;
}
EXPORT bool DepositPKM(bw2sav_obj * sav, pokemon_obj * pkm, int startbox, bool failiffull)
{
	if (failiffull)
	{
		if (GetBoxCount(sav, startbox) == 30)
		{
			return false;
		}
	}
	storepkm(sav, pkm, startbox);
	return true;
}
EXPORT bool WithdrawPKM(bw2sav_obj * sav, pokemon_obj * pkm)
{
	if (sav->cur.party.size == 6)
	{
		return false;
	}
	party_pkm * ppkm = new party_pkm();
	pctoparty(ppkm, pkm);
	int startsize = sav->cur.party.size;
	for (int slot = 0; slot < 6; slot++)
	{
		if ((sav->cur.party.pokemon[slot].species == Species::NOTHING) && (slot == startsize))
		{
			sav->cur.party.pokemon[slot] = *ppkm;
			sav->cur.party.size++;
		}
	}
	return true;
}
EXPORT void DeletePartyPKM(bw2sav_obj * sav, int slot)
{
	if (sav->cur.party.size >= 1)
	{
		//remove_pkm(&(sav->cur.party.pokemon[slot]));
		if (sav->cur.party.pokemon[slot].species != Species::NOTHING)
		{
			sav->cur.party.size--;
		}
		remove_pkm(sav, slot);
	}
}
EXPORT void DeleteStoredPKM(bw2sav_obj * sav, int box, int slot)
{
	remove_pkm(&(sav->cur.boxes[box].pokemon[slot]));
}
EXPORT void SwapBoxParty(bw2sav_obj * sav, int box, int boxslot, int partyslot)
{
	if (sav->cur.party.pokemon[partyslot].species == Species::NOTHING)
	{
		sav->cur.party.size++;
	}
	swap_pkm(&(sav->cur.boxes[box].pokemon[boxslot]), &(sav->cur.party.pokemon[partyslot]));
}
EXPORT void SwapPartyBox(bw2sav_obj * sav, int partyslot, int box, int boxslot)
{
	if (sav->cur.boxes[box].pokemon[boxslot].species == Species::NOTHING)
	{
		sav->cur.party.size--;
	}
	swap_pkm(&(sav->cur.party.pokemon[partyslot]), &(sav->cur.boxes[box].pokemon[boxslot]));
}
EXPORT void SwapBoxBox(bw2sav_obj * sav, int boxa, int boxslota, int boxb, int boxslotb)
{
	swap_pkm(&(sav->cur.boxes[boxa].pokemon[boxslota]), &(sav->cur.boxes[boxb].pokemon[boxslotb]));
}
EXPORT void SwapPartyParty(bw2sav_obj * sav, int partyslota, int partyslotb)
{
	swap_pkm(&(sav->cur.party.pokemon[partyslota]), &(sav->cur.party.pokemon[partyslotb]));
}
EXPORT void RecalcPartyPKM(party_pkm * ppkm)
{
	pctoparty(ppkm, ppkm);
}
BSTR UTF8toBSTR(const char* input)
{
	BSTR result = NULL;
	int lenA = lstrlenA(input);
	int lenW = ::MultiByteToWideChar(CP_UTF8, 0, input, lenA, NULL, 0);
	if (lenW > 0)
	{
		result = ::SysAllocStringLen(0, lenW);
		::MultiByteToWideChar(CP_UTF8, 0, input, lenA, result, lenW);
	}
	return result;
}
