from __future__ import annotations
from BaseClasses import Entrance, Region
from typing import TYPE_CHECKING

if TYPE_CHECKING:
    from .world import MMLWorld

# TODO: Current setup only has one big region. Create logical regions
# e.g. a region you can only get to with jump springs.
# It will make sense to eventually have regions be actual rooms in the game
# because it will make it possible to do entrance keys a la OoT.

def create_and_connect_regions(world: MMLWorld) -> None:
    create_all_regions(world)
    connect_regions(world)

def create_region(world: MMLWorld, region_name, location_table) -> Region:
    new_region = Region(region_name, world.player, world.multiworld)
    return new_region

def create_all_regions(world: MMLWorld) -> None:
    universe = Region("Universe", world.player, world.multiworld)
    regions = [
        Region("Ocean Tower - Intro cutscene", world.player, world.multiworld),    # 00 00
        Region("Ocean Tower - Room 1 (Entrance)", world.player, world.multiworld),    # 00 01
        Region("Ocean Tower - Room 2", world.player, world.multiworld),    # 00 02
        Region("Ocean Tower - Room 3 (Boss)", world.player, world.multiworld),    # 00 03
        Region("Ocean Tower - Outdoor Cutscene", world.player, world.multiworld),    # 00 04
        Region("Ocean Tower - Back To Title Screen", world.player, world.multiworld),    # 00 05
        Region("Ocean Tower - Empty?", world.player, world.multiworld),    # 00 06
        Region("Opening Text Cutscene - Scrolling Text", world.player, world.multiworld),    # 01 00
        Region("Crash Cutscene - Cutscene", world.player, world.multiworld),    # 02 00
        Region("Cardon Forest (Flutter Broken) - Near ruin entrance", world.player, world.multiworld),    # 03 00
        Region("Cardon Forest (Flutter Broken) - Crash Site", world.player, world.multiworld),    # 03 01
        Region("Cardon Forest (Flutter Broken) - City Entrance", world.player, world.multiworld),    # 03 02
        Region("Cardon Forest (Flutter Broken) - Unknown (floating model)", world.player, world.multiworld),    # 03 03
        Region("Cardon Forest (Flutter Broken) - Unknown (floating model)", world.player, world.multiworld),    # 03 04
        Region("Cardon Forest (Flutter Broken) - Barell's Room", world.player, world.multiworld),    # 03 05
        Region("Cardon Forest (Flutter Broken) - Roll's Room (no Roll)", world.player, world.multiworld),    # 03 06
        Region("Cardon Forest (Flutter Broken) - Flutter", world.player, world.multiworld),    # 03 07
        Region("Cardon Forest (Flutter Broken) - Mega Man's Room", world.player, world.multiworld),    # 03 08
        Region("Apple Market - Apple Market", world.player, world.multiworld),    # 04 00
        Region("Apple Market - Junk Shop", world.player, world.multiworld),    # 04 01
        Region("Apple Market - Electronics Shop", world.player, world.multiworld),    # 04 02
        Region("Apple Market - Hip Bone", world.player, world.multiworld),    # 04 03
        Region("Apple Market - Tailor Chinos", world.player, world.multiworld),    # 04 04
        Region("Apple Market - Record Shop", world.player, world.multiworld),    # 04 05
        Region("Downtown - Downtown", world.player, world.multiworld),    # 05 00
        Region("Downtown - (no music, no sub-city, missing door texture)", world.player, world.multiworld),    # 05 01
        Region("Downtown - Library", world.player, world.multiworld),    # 05 02
        Region("Downtown - Tron's Cockpit", world.player, world.multiworld),    # 05 03
        Region("Downtown - Stripe Burger", world.player, world.multiworld),    # 05 04
        Region("City Hall - Outdoors", world.player, world.multiworld),    # 06 00
        Region("City Hall - Amelia's Office", world.player, world.multiworld),    # 06 01
        Region("City Hall - Outdoors (no music, cars, or people)", world.player, world.multiworld),    # 06 02
        Region("City Hall - Teisel's Room", world.player, world.multiworld),    # 06 03
        Region("City Hall - Amelia's Office (wrecked)", world.player, world.multiworld),    # 06 04
        Region("Gesselschaft Interior - Empty?", world.player, world.multiworld),    # 07 00
        Region("Gesselschaft Interior - Engine Room", world.player, world.multiworld),    # 07 01
        Region("Gesselschaft Interior - Hallway", world.player, world.multiworld),    # 07 02
        Region("Gesselschaft Interior - Kitchen", world.player, world.multiworld),    # 07 03
        Region("Gesselschaft Interior - HQ", world.player, world.multiworld),    # 07 04
        Region("Gesselschaft Interior - First Meeting Room Cutscene", world.player, world.multiworld),    # 07 05
        Region("Gesselschaft Interior - Meeting Room", world.player, world.multiworld),    # 07 06
        Region("Gesselschaft Interior - Empty?", world.player, world.multiworld),    # 07 07
        Region("Uptown - Uptown", world.player, world.multiworld),    # 08 00
        Region("Uptown - Hospital", world.player, world.multiworld),    # 08 01
        Region("Uptown - TV Station", world.player, world.multiworld),    # 08 02
        Region("Uptown - Beast Hunter game", world.player, world.multiworld),    # 08 03
        Region("Uptown - Balloon Game", world.player, world.multiworld),    # 08 04
        Region("Uptown - Ira's Room", world.player, world.multiworld),    # 08 05
        Region("Underground Ruins - Room 1 (Junk Store Man Area)", world.player, world.multiworld),    # 09 00
        Region("Underground Ruins - Room 2", world.player, world.multiworld),    # 09 01
        Region("Underground Ruins - Room 3 (Sewer)", world.player, world.multiworld),    # 09 02
        Region("Underground Ruins - Room 4", world.player, world.multiworld),    # 09 03
        Region("Underground Ruins - Room 5", world.player, world.multiworld),    # 09 04
        Region("Underground Ruins - Room 6", world.player, world.multiworld),    # 09 05
        Region("Underground Ruins - Room 7", world.player, world.multiworld),    # 09 06
        Region("Underground Ruins - Room 8", world.player, world.multiworld),    # 09 07
        Region("Underground Ruins - Room 9", world.player, world.multiworld),    # 09 08
        Region("Clozer Woods (Tiesel) - Tiesel Area", world.player, world.multiworld),    # 0A 00
        Region("Lake Jyun - Inside Bonne Robot", world.player, world.multiworld),    # 0B 00
        Region("Lake Jyun - ???", world.player, world.multiworld),    # 0B 01
        Region("Lake Jyun - On the Lake", world.player, world.multiworld),    # 0B 02
        Region("Lake Jyun - Side River", world.player, world.multiworld),    # 0B 03
        Region("Lake Jyun - Inside Bonne Robot", world.player, world.multiworld),    # 0B 04
        Region("Lake Jyun - Empty?", world.player, world.multiworld),    # 0B 05
        Region("Lake Jyun - Door Opening Mechanism", world.player, world.multiworld),    # 0B 06
        Region("Lake Jyun - Subgate With Open Door", world.player, world.multiworld),    # 0B 07
        Region("Outside Cardon Forest Subgate - Outside", world.player, world.multiworld),    # 0C 00
        Region("Outside Cardon Forest Subgate - Door Opening Mechanism", world.player, world.multiworld),    # 0C 01
        Region("Outside Cardon Forest Subgate - Subgate With Open Door", world.player, world.multiworld),    # 0C 02
        Region("Outside Cardon Forest Subgate - Small Piece of Ground", world.player, world.multiworld),    # 0C 03
        Region("Wily's Boat - Walkway", world.player, world.multiworld),    # 0D 00
        Region("Wily's Boat - Inside", world.player, world.multiworld),    # 0D 01
        Region("Wily's Boat - Boat Area", world.player, world.multiworld),    # 0D 02
        Region("Wily's Boat - Inside The Boat", world.player, world.multiworld),    # 0D 03
        Region("Wily's Boat - Walkway (no box or woman)", world.player, world.multiworld),    # 0D 04
        Region("Wily's Boat - Walkway (no box, woman, or boat)", world.player, world.multiworld),    # 0D 05
        Region("Cardon Forest Sub-gate - Room 1", world.player, world.multiworld),    # 0E 00
        Region("Cardon Forest Sub-gate - Room 1", world.player, world.multiworld),    # 0E 01
        Region("Cardon Forest Sub-gate - Room 1", world.player, world.multiworld),    # 0E 02
        Region("City Hall (Indoors) - Police Station", world.player, world.multiworld),    # 0F 00
        Region("City Hall (Indoors) - Inspector's Office", world.player, world.multiworld),    # 0F 01
        Region("City Hall (Indoors) - City Hall 1st Floor", world.player, world.multiworld),    # 0F 02
        Region("City Hall (Indoors) - Bank", world.player, world.multiworld),    # 0F 03
        Region("Yass Plains - Yass Plains Outdoors", world.player, world.multiworld),    # 10 00
        Region("Yass Plains - Hideout Stage 1", world.player, world.multiworld),    # 10 01
        Region("Yass Plains - Hideout Stage 2", world.player, world.multiworld),    # 10 02
        Region("Yass Plains - Hideout Stage 3", world.player, world.multiworld),    # 10 03
        Region("Yass Plains - Empty House", world.player, world.multiworld),    # 10 04
        Region("Yass Plains - Junk Shop House", world.player, world.multiworld),    # 10 05
        Region("Clozer Woods With Bridge - Clozer Woods With Bridge", world.player, world.multiworld),    # 11 00
        Region("Outside Main Gate - Outside Main Gate", world.player, world.multiworld),    # 12 00
        Region("Clozer Woods Sub-Gate - Room 1 (Entrance)", world.player, world.multiworld),    # 13 00
        Region("Clozer Woods Sub-Gate - Room 2", world.player, world.multiworld),    # 13 01
        Region("Clozer Woods Sub-Gate - Room 3 (Key Room)", world.player, world.multiworld),    # 13 02
        Region("Clozer Woods Sub-Gate - Room 4", world.player, world.multiworld),    # 13 03
        Region("Clozer Woods Sub-Gate - Room 5", world.player, world.multiworld),    # 13 04
        Region("Clozer Woods Sub-Gate - Room 6", world.player, world.multiworld),    # 13 05
        Region("Clozer Woods Sub-Gate - Room 7", world.player, world.multiworld),    # 13 06
        Region("Clozer Woods Sub-Gate - Room 8", world.player, world.multiworld),    # 13 07
        Region("Clozer Woods Sub-Gate - Room 9 (Generator)", world.player, world.multiworld),    # 13 08
        Region("Clozer Woods Sub-Gate - Room 10", world.player, world.multiworld),    # 13 09
        Region("Clozer Woods Sub-Gate - Flutter Barell's Room", world.player, world.multiworld),    # 13 0A
        Region("Clozer Woods Sub-Gate - Flutter Roll's Room", world.player, world.multiworld),    # 13 0B
        Region("Clozer Woods Sub-Gate - Flutter Lobby", world.player, world.multiworld),    # 13 0C
        Region("Clozer Woods Sub-Gate - Flutter Mega Man's Room", world.player, world.multiworld),    # 13 0D
        Region("Lake Jyun Sub-Gate - Room 1 (Entrance)", world.player, world.multiworld),    # 14 00
        Region("Lake Jyun Sub-Gate - Room 2", world.player, world.multiworld),    # 14 01
        Region("Lake Jyun Sub-Gate - Room 3", world.player, world.multiworld),    # 14 02
        Region("Lake Jyun Sub-Gate - Room 4 ", world.player, world.multiworld),    # 14 03
        Region("Lake Jyun Sub-Gate - Refractor Room", world.player, world.multiworld),    # 14 04
        Region("Bonne Ending Boat - Boat Interior", world.player, world.multiworld),    # 15 00
        Region("Bonne Ending Boat - Ocean", world.player, world.multiworld),    # 15 01
        Region("Flutter To Subgate Cutscene - Cutscene", world.player, world.multiworld),    # 16 00
        Region("Flutter To Subgate Cutscene - Flutter Bridge", world.player, world.multiworld),    # 16 01
        Region("Flutter To Subgate Cutscene - Return Cutscene", world.player, world.multiworld),    # 16 02
        Region("Gesselschaft Battle - Small Bridge", world.player, world.multiworld),    # 17 00
        Region("Gesselschaft Battle - Flutter Bridge", world.player, world.multiworld),    # 17 01
        Region("Gesselschaft Battle - Gesselschaft HQ", world.player, world.multiworld),    # 17 02
        Region("Gesselschaft Battle - Scrolling Clouds", world.player, world.multiworld),    # 17 03
        Region("Flutter Takeoff - Cardon Forest with no Flutter (Yasmar Woods)", world.player, world.multiworld),    # 18 00
        Region("Flutter Takeoff - Flutter Engine Room", world.player, world.multiworld),    # 18 01
        Region("Flutter Takeoff - Glowing Refractor", world.player, world.multiworld),    # 18 02
        Region("Old City - Old City (no dogs, weapons usable)", world.player, world.multiworld),    # 19 00
        Region("Old City - Bonne's Warehouse", world.player, world.multiworld),    # 19 01
        Region("Old City - Power Plant", world.player, world.multiworld),    # 19 02
        Region("Old City - Old City (dogs, no weapons)", world.player, world.multiworld),    # 19 03
        Region("Main Gate - Second Area (where you unlock the sub-cities)", world.player, world.multiworld),    # 1A 00
        Region("Main Gate - Third Area (Watcher, Sleeper, Dreamer doors)", world.player, world.multiworld),    # 1A 01
        Region("Main Gate - Final Area", world.player, world.multiworld),    # 1A 02
        Region("Main Gate - First Area 1", world.player, world.multiworld),    # 1A 03
        Region("Main Gate - First Area 2", world.player, world.multiworld),    # 1A 04
        Region("Main Gate - First Area 3", world.player, world.multiworld),    # 1A 05
        Region("Main Gate - First Area 4", world.player, world.multiworld),    # 1A 06
        Region("Main Gate - First Area 5", world.player, world.multiworld),    # 1A 07
        Region("Main Gate - First Area 6", world.player, world.multiworld),    # 1A 08
        Region("Main Gate - First Area 7 (Entrance)", world.player, world.multiworld),    # 1A 09
        Region("Main Gate - Tiny Kattelox", world.player, world.multiworld),    # 1A 0A
        Region("Main Gate - Juno Wall", world.player, world.multiworld),    # 1A 0B
        Region("Main Gate - Amelia's Office (simplified)", world.player, world.multiworld),    # 1A 0C
        Region("Main Gate - Downtown (simplified)", world.player, world.multiworld),    # 1A 0D
        Region("Main Gate - Empty?", world.player, world.multiworld),    # 1A 0E
        Region("Main Gate - Juno's Room Without Door", world.player, world.multiworld),    # 1A 0F
        Region("Main Gate - Unknown (textures?)", world.player, world.multiworld),    # 1A 10
        Region("Cardon Forest (Flutter Fixed) - Near ruin entrance", world.player, world.multiworld),    # 1B 00
        Region("Cardon Forest (Flutter Fixed) - Crash Site", world.player, world.multiworld),    # 1B 01
        Region("Cardon Forest (Flutter Fixed) - City Entrance", world.player, world.multiworld),    # 1B 02
        Region("Cardon Forest (Flutter Fixed) - Unknown (floating model)", world.player, world.multiworld),    # 1B 03
        Region("Cardon Forest (Flutter Fixed) - Unknown (floating model)", world.player, world.multiworld),    # 1B 04
        Region("Cardon Forest (Flutter Fixed) - Barell's Room", world.player, world.multiworld),    # 1B 05
        Region("Cardon Forest (Flutter Fixed) - Roll's Room", world.player, world.multiworld),    # 1B 06
        Region("Cardon Forest (Flutter Fixed) - Flutter Lobby", world.player, world.multiworld),    # 1B 07
        Region("Cardon Forest (Flutter Fixed) - Mega Man's Room", world.player, world.multiworld),    # 1B 08
        Region("Museum - First Floor", world.player, world.multiworld),    # 1C 00
        Region("Museum - Second Floor", world.player, world.multiworld),    # 1C 01
        Region("Sub-Cities - Watcher Sub-City", world.player, world.multiworld),    # 1D 00
        Region("Sub-Cities - Sleeper Sub-City", world.player, world.multiworld),    # 1D 01
        Region("Sub-Cities - Dreamer Sub-City", world.player, world.multiworld),    # 1D 02
        Region("Sub-Cities - Watcher Chest Room", world.player, world.multiworld),    # 1D 03
        Region("Sub-Cities - Sleeper Chest Room", world.player, world.multiworld),    # 1D 04
        Region("Sub-Cities - Dreamer Chest Room", world.player, world.multiworld),    # 1D 05
        Region("Ending - Flutter Launch Area (different)", world.player, world.multiworld),    # 1E 00
        Region("Ending - Flutter Bridge", world.player, world.multiworld),    # 1E 01
        Region("Ending - Cliff and Ocean", world.player, world.multiworld),    # 1E 02
        Region("Ending - Empty?", world.player, world.multiworld),    # 1E 03
        Region("Ending - Empty?", world.player, world.multiworld),    # 1E 04
        Region("Ending - Tiny Kattelox", world.player, world.multiworld),    # 1E 05
    ]

    regions = [universe]
    world.multiworld.regions += regions

def connect_regions(world: MMLWorld) -> None:
    universe = world.get_region("Universe")
    pass