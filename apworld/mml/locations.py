from __future__ import annotations

from typing import TYPE_CHECKING

from BaseClasses import ItemClassification, Location

from . import items

if TYPE_CHECKING:
    from .world import MMLWorld

LOCATION_NAME_TO_ID = {
    "Ocean tower, Right chest" :  1,
    "Ocean tower, Left chest" :  2 ,
    "Apple market, Electric goods box" :  3,
    "Apple market, Book store box" :  4 ,
    "Apple market, Junk store box" :  5 ,
    "Apple market, North pail" :  6 ,
    "Apple market, South pail" :  7 ,
    "Downtown, South east peace sign pail" :  8 ,
    "Downtown, Center east pail" :  9 ,
    "Downtown, Don't kick us pail" : 10 ,
    "Downtown, Center pail" : 11 ,
    "Downtown, Library pail" : 12 ,
    "Uptown, Hospital right pail" : 13 ,
    "Uptown, Hospital left pail" : 14 ,
    "Uptown, Ocean corner pail" : 15 ,
    "Willy's Boat, Right box" : 16 ,
    "Willy's Boat, Left box" : 17 ,
    "Willy's Boat, Pail" : 18 ,
    "Yass plains, Plateau house box" : 19,
    "Yass plains, Plateau house pail" : 20,
    "Yass plains, Behind hideout pail" : 21,
    "Yass plains, Across hideout pail" : 22,
    "Underground ruins, Junk store man chest" : 23,
    "Underground ruins, Junk store man hole" : 24,
    "Underground ruins, Main gate entrance chest" : 25,
    "Underground ruins, 2 box ledge chest" : 26 ,
    "Underground ruins, Miroc room ledge chest" : 27 ,
    "Underground ruins, Cross room chest" : 28 ,
    "Underground ruins, Miroc room left hole" : 29 ,
    "Underground ruins, Miroc room right hole" : 30 ,
    "Underground ruins, Arukoitan battle north chest" : 31 ,
    "Underground ruins, Arukoitan battle south chest" : 32 ,
    "Underground ruins, Obstacle room cliff east hole" : 33 ,
    "Underground ruins, Obstacle room cliff west hole" : 34 ,
    "Underground ruins, Shekuten pillar room chest" : 35 ,
    "Underground ruins, Shekuten pillar room hole" : 36 ,
    "Underground ruins, Kuruguru obstacle hole" : 37 ,
    "Underground ruins, Gold Gorubesshu chest" : 38 ,
    "Underground ruins, Drillable pillar room south chest" : 39 ,
    "Underground ruins, Drillable pillar room north chest" : 40 ,
    "Undeground ruins, 3 chest room middle chest" : 41 ,
    "Underground ruins, Drillable pillars room south hole" : 42 ,
    "Underground ruins, Drillable pillars room west hole" : 43 ,
    "Underground ruins, Drillable pillars room north hole" : 44 ,
    "Underground ruins, Fireball Orudakoitan chest" : 45 ,
    "Underground ruins, Clozer exit chest" : 46,
    "Underground ruins, Drillable wall room middle cliff chest" : 47,
    "Underground ruins, Drillable wall room west cliff chest" : 48 ,
    "Underground ruins, Drillable wall room east cliff chest" : 49 ,
    "Underground ruins, Trapped box hole" : 50 ,
    "Underground ruins, Drillable wall room east cliff hole" : 51 ,
    "Cardon Forest Sub-Gate, Sharukurusu floor hole" : 52 ,
    "Cardon Forest Sub-Gate, Cliff hole" : 53 ,
    "Cardon Forest Sub-Gate, Cliff chest" : 54 ,
    "Cardon Forest Sub-Gate, Bottom conveyor hole" : 55 ,
    "Cardon Forest Sub-Gate, Middle conveyor hole" : 56 ,
    "Cardon Forest Sub-Gate, Middle switch chest" : 57 ,
    "Lake Jyun Sub-Gate, Entrance right hole" : 61 ,
    "Lake Jyun Sub-Gate, Entrance left hole" : 62 ,
    "Lake Jyun Sub-Gate, Entrance chest" : 63 ,
    "Lake Jyun Sub-Gate, East corridor hole" : 64,
    "Lake Jyun Sub-Gate, West corridor hole" : 65,
    "Lake Jyun Sub-Gate, West corridor chest" : 66,
    "Lake Jyun Sub-Gate, Sharukurusu east chest" : 67,
    "Lake Jyun Sub-Gate, Sharukurusu middle chest" : 68,
    "Lake Jyun Sub-Gate, Sharukurusu west chest" : 69,
    "Lake Jyun Sub-Gate, Sharukurusu west hole" : 70,
    "Closer Woods Sub-Gate, Sharukurusu E room left hole" : 71,
    "Closer Woods Sub-Gate, Sharukurusu E room right hole" : 72,
    "Clozer woods Sub-Gate, Miroc+Gorubesshu west cliff chest" : 73,
    "Clozer woods Sub-Gate, Miroc+Gorubesshu east cliff chest" : 74,
    "Clozer woods Sub-Gate, Miroc+Gorubesshu southeast pillar hole" : 75,
    "Clozer woods Sub-Gate, Miroc+Gorubesshu northeast pillar hole" : 76,
    "Clozer woods Sub-Gate, Miroc+Gorubesshu northwest pillar hole" : 77,
    "Clozer woods Sub-Gate, Miroc+Gorubesshu southwest pillar hole" : 78,
    "Clozer Woods Sub-Gate, Generator room upper chest" : 79,
    "Clozer Woods Sub-Gate, Gorubesshu corridor east chest" : 80,
    "Clozer Woods Sub-Gate, Generator room lower chest" : 81,
    "Main Gate, Maze Chest" : 82,
    "Main Gate, Maze entrance hole" : 83,
    "Main Gate, Maze Karumuna Bash hole" : 84,
    "Main Gate, Maze Reaverbot hole" : 85,
    "Main Gate, Two Gorubesshu room chest" : 86,
    "Main Gate, Entrance hole" : 87,
    "Main Gate, Boss corridor chest" : 88,
    "Old City Sub-City, Chest" : 89,
    "Downtown Sub-City, Chest" : 90,
    "Uptown Sub-City, Chest" : 91,
    "Flutter, Study chest" : 92
}

class MMLLocation(Location):
    game = "Mega Man Legends"

def get_location_names_with_ids(location_names: list[str]) -> dict[str, int | None]:
    return {location_name: LOCATION_NAME_TO_ID[location_name] for location_name in location_names}


def create_all_locations(world: MMLWorld) -> None:
    create_regular_locations(world)
    create_events(world)

def create_regular_locations(world: MMLWorld) -> None:
    universe = world.get_region("Universe")
    universe.add_locations(LOCATION_NAME_TO_ID, MMLLocation)

def create_events(world: MMLWorld) -> None:
    pass