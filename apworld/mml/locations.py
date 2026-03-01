from __future__ import annotations
from BaseClasses import Location
from enum import IntEnum
from typing import TYPE_CHECKING, NamedTuple

if TYPE_CHECKING:
    from .world import MMLWorld

class MMLLocationCategory(IntEnum):
    CONTAINER = 0
    QUEST = 1
    COMBAT = 2

class MMLLocation(Location):
    game = "Mega Man Legends"

class MMLLocationData(NamedTuple):
    name: str
    default_item: str
    category: MMLLocationCategory
    isMissable: bool

_allLocationDatas = [
    MMLLocationData("Ocean tower, Right chest",                                          1,  MMLLocationCategory.CONTAINER,  True),
    MMLLocationData("Ocean tower, Left chest",                                           2,  MMLLocationCategory.CONTAINER,  True),
    MMLLocationData("Apple market, Electric goods box",                                  3,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Apple market, Book store box",                                      4,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Apple market, Junk store box",                                      5,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Apple market, North pail",                                          6,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Apple market, South pail",                                          7,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Downtown, South east peace sign pail",                              8,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Downtown, Center east pail",                                        9,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Downtown, Don't kick us pail",                                     10,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Downtown, Center pail",                                            11,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Downtown, Library pail",                                           12,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Uptown, Hospital right pail",                                      13,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Uptown, Hospital left pail",                                       14,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Uptown, Ocean corner pail",                                        15,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Wily's Boat, Right box",                                           16,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Wily's Boat, Left box",                                            17,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Wily's Boat, Pail",                                                18,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Yass plains, Plateau house box",                                   19,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Yass plains, Plateau house pail",                                  20,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Yass plains, Behind hideout pail",                                 21,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Yass plains, Across hideout pail",                                 22,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Junk store man chest",                          23,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Junk store man hole",                           24,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Main gate entrance chest",                      25,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, 2 box ledge chest",                             26,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Miroc room ledge chest",                        27,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Cross room chest",                              28,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Miroc room left hole",                          29,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Miroc room right hole",                         30,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Arukoitan battle north chest",                  31,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Arukoitan battle south chest",                  32,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Obstacle room cliff east hole",                 33,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Obstacle room cliff west hole",                 34,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Shekuten pillar room chest",                    35,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Shekuten pillar room hole",                     36,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Kuruguru obstacle hole",                        37,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Gold Gorubesshu chest",                         38,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Drillable pillar room south chest",             39,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Drillable pillar room north chest",             40,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Undeground ruins, 3 chest room middle chest",                      41,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Drillable pillars room south hole",             42,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Drillable pillars room west hole",              43,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Drillable pillars room north hole",             44,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Fireball Orudakoitan chest",                    45,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Clozer exit chest",                             46,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Drillable wall room middle cliff chest",        47,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Drillable wall room west cliff chest",          48,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Drillable wall room east cliff chest",          49,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Trapped box hole",                              50,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Underground ruins, Drillable wall room east cliff hole",           51,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Cardon Forest Sub-Gate, Sharukurusu floor hole",                   52,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Cardon Forest Sub-Gate, Cliff hole",                               53,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Cardon Forest Sub-Gate, Cliff chest",                              54,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Cardon Forest Sub-Gate, Bottom conveyor hole",                     55,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Cardon Forest Sub-Gate, Middle conveyor hole",                     56,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Cardon Forest Sub-Gate, Middle switch chest",                      57,  MMLLocationCategory.CONTAINER, False),
  # MMLLocationData("Cardon Forest Sub-Gate, Sharukurusu starter key 1",                58,  MMLLocationCategory.CONTAINER, False),
  # MMLLocationData("Cardon Forest Sub-Gate, Conveyor key 2",                           59,  MMLLocationCategory.CONTAINER, False),
  # MMLLocationData("Cardon Forest Sub-Gate, Conveyor key get 3",                       60,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Lake Jyun Sub-Gate, Entrance right hole",                          61,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Lake Jyun Sub-Gate, Entrance left hole",                           62,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Lake Jyun Sub-Gate, Entrance chest",                               63,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Lake Jyun Sub-Gate, East corridor hole",                           64,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Lake Jyun Sub-Gate, West corridor hole",                           65,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Lake Jyun Sub-Gate, West corridor chest",                          66,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Lake Jyun Sub-Gate, Sharukurusu east chest",                       67,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Lake Jyun Sub-Gate, Sharukurusu middle chest",                     68,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Lake Jyun Sub-Gate, Sharukurusu west chest",                       69,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Lake Jyun Sub-Gate, Sharukurusu west hole",                        70,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Closer Woods Sub-Gate, Sharukurusu E room left hole",              71,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Closer Woods Sub-Gate, Sharukurusu E room right hole",             72,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Clozer woods Sub-Gate, Miroc+Gorubesshu west cliff chest",         73,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Clozer woods Sub-Gate, Miroc+Gorubesshu east cliff chest",         74,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Clozer woods Sub-Gate, Miroc+Gorubesshu southeast pillar hole",    75,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Clozer woods Sub-Gate, Miroc+Gorubesshu northeast pillar hole",    76,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Clozer woods Sub-Gate, Miroc+Gorubesshu northwest pillar hole",    77,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Clozer woods Sub-Gate, Miroc+Gorubesshu southwest pillar hole",    78,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Clozer Woods Sub-Gate, Generator room upper chest",                79,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Clozer Woods Sub-Gate, Gorubesshu corridor east chest",            80,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Clozer Woods Sub-Gate, Generator room lower chest",                81,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Main Gate, Maze Chest",                                            82,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Main Gate, Maze entrance hole",                                    83,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Main Gate, Maze Karumuna Bash hole",                               84,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Main Gate, Maze Reaverbot hole",                                   85,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Main Gate, Two Gorubesshu room chest",                             86,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Main Gate, Entrance hole",                                         87,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Main Gate, Boss corridor chest",                                   88,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Old City Sub-City, Chest",                                         89,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Downtown Sub-City, Chest",                                         90,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Uptown Sub-City, Chest",                                           91,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Flutter, Study chest",                                             92,  MMLLocationCategory.CONTAINER, False),
    MMLLocationData("Damaged Hanmuru Doll defeated",                                    93,  MMLLocationCategory.COMBAT,    False),
    MMLLocationData("Ferdinand defeated",                                               94,  MMLLocationCategory.COMBAT,    False),
    MMLLocationData("Bon Bonne defeated",                                               95,  MMLLocationCategory.COMBAT,    False),
    MMLLocationData("Marlwolf defeated",                                                96,  MMLLocationCategory.COMBAT,    False),
    MMLLocationData("Balkon Gerät defeated",                                            97,  MMLLocationCategory.COMBAT,    False),
    MMLLocationData("Garudoriten defeated",                                             98,  MMLLocationCategory.COMBAT,    False),
    MMLLocationData("Karumuna Bash Trio defeated",                                      99,  MMLLocationCategory.COMBAT,    False),
    MMLLocationData("Focke-Wulf defeated",                                              100, MMLLocationCategory.COMBAT,    False),
    MMLLocationData("Theodore Bruno defeated",                                          101, MMLLocationCategory.COMBAT,    False),
    MMLLocationData("Rescue the shop owner's husband",                                  102, MMLLocationCategory.QUEST,     False),
    MMLLocationData("Race Technical Course Rank A",                                     103, MMLLocationCategory.QUEST,     False),
    MMLLocationData("Beast Hunter Rank A",                                              104, MMLLocationCategory.QUEST,     False),
    MMLLocationData("Race Straight Course Rank A",                                      105, MMLLocationCategory.QUEST,     False),
    MMLLocationData("Baloon Fantasy Rank A",                                            106, MMLLocationCategory.QUEST,     False),
    MMLLocationData("Race Left Curve Course Rank A",                                    107, MMLLocationCategory.QUEST,     False),
    MMLLocationData("Save the missing woman",                                           108, MMLLocationCategory.QUEST,     False),
    MMLLocationData("Cure Ira's illness",                                               109, MMLLocationCategory.QUEST,     False),
    MMLLocationData("Museum donation, Old Bone",                                        112, MMLLocationCategory.QUEST,     False),
    MMLLocationData("Museum donation, Old Heater",                                      113, MMLLocationCategory.QUEST,     False),
    MMLLocationData("Museum donation, Old Doll",                                        114, MMLLocationCategory.QUEST,     False),
    MMLLocationData("Museum donation, Antique Bell",                                    115, MMLLocationCategory.QUEST,     False),
    MMLLocationData("Museum donation, Giant Horn",                                      116, MMLLocationCategory.QUEST,     False),
    MMLLocationData("Museum donation, Shiny Object",                                    117, MMLLocationCategory.QUEST,     False),
    MMLLocationData("Museum donation, Old Shield",                                      118, MMLLocationCategory.QUEST,     False),
    MMLLocationData("Museum donation, Shiny Red Stone",                                 119, MMLLocationCategory.QUEST,     False),
    MMLLocationData("Complete the Museum exhibit",                                      120, MMLLocationCategory.QUEST,     False),
    MMLLocationData("Take dangerous object from museum visitor",                        121, MMLLocationCategory.QUEST,     False),
    MMLLocationData("Give Flower to Roll",                                              122, MMLLocationCategory.QUEST,     False),
    MMLLocationData("Give Music Box to Roll",                                           123, MMLLocationCategory.QUEST,     False),
    MMLLocationData("Give Ring to Roll",                                                124, MMLLocationCategory.QUEST,     False)
]

LOCATION_NAME_TO_ID         = {locationData.name: locationData.id         for locationData in _allLocationDatas}
LOCATION_NAME_TO_CATEGORY   = {locationData.name: locationData.category   for locationData in _allLocationDatas}
LOCATION_NAME_TO_ISMISSABLE = {locationData.name: locationData.isMissable for locationData in _allLocationDatas}

def get_location_names_with_ids(location_names: list[str]) -> dict[str, int | None]:
    return {location_name: LOCATION_NAME_TO_ID[location_name] for location_name in location_names}

def create_all_locations(world: MMLWorld) -> None:
    create_regular_locations(world)
    create_events(world)
    return None

def create_regular_locations(world: MMLWorld) -> None:
    universe = world.get_region("Universe")
    universe.add_locations(LOCATION_NAME_TO_ID, MMLLocation)
    return None

def create_events(world: MMLWorld) -> None:
    return None