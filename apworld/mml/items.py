from __future__ import annotations
from BaseClasses import Item, ItemClassification
from typing import TYPE_CHECKING, NamedTuple

if TYPE_CHECKING:
    from .world import MMLWorld

class MMLItem(Item):
    game = "Mega Man Legends"

class MMLItemData(NamedTuple):
    # Keeping this in case we need to add more members
    name: str
    itemClassification: ItemClassification
    id: int

_all_itemDatas = [
    MMLItemData("Nothing",                             ItemClassification.filler,                                  0x00FF),
    MMLItemData("Power Raiser",                        ItemClassification.filler,                                  0x020D),
    MMLItemData("Buster Max",                          ItemClassification.useful,                                  0x0210), # strong buster part -> useful
    MMLItemData("Power Stream",                        ItemClassification.useful,                                  0x0211), # strong buster part -> useful
    MMLItemData("Blaster Unit R",                      ItemClassification.useful,                                  0x0212), # strong buster part -> useful
    MMLItemData("Buster Unit Omega",                   ItemClassification.useful,                                  0x0213), # strong buster part -> useful
    MMLItemData("Rapid Striker",                       ItemClassification.filler,                                  0x0217),
    MMLItemData("Omni-Unit",                           ItemClassification.filler,                                  0x0219),
    MMLItemData("Buster Unit",                         ItemClassification.filler,                                  0x021E),
    MMLItemData("Rapid Fire",                          ItemClassification.filler,                                  0x021F),
  # MMLItemData("Cardon Forest Sub-Gate Key 1",        ItemClassification.progression,                             0x022E), # progresses main story -> progression
  # MMLItemData("Cardon Forest Sub-Gate Key 2",        ItemClassification.progression,                             0x022F), # progresses main story -> progression
  # MMLItemData("Cardon Forest Sub-Gate Key 3",        ItemClassification.progression,                             0x0230), # progresses main story -> progression
    MMLItemData("Lake Jyun Sub-Gate Starter Key 1",    ItemClassification.progression,                             0x0231), # progresses main story -> progression
    MMLItemData("Lake Jyun Sub-Gate Starter Key 2",    ItemClassification.progression,                             0x0232), # progresses main story -> progression
    MMLItemData("Lake Jyun Sub-Gate Starter Key 3",    ItemClassification.progression,                             0x0233), # progresses main story -> progression
    MMLItemData("Clozer Woods Sub-Gate Key 1",         ItemClassification.progression,                             0x0234), # progresses main story -> progression
    MMLItemData("Clozer Woods Sub-Gate Key 2",         ItemClassification.progression,                             0x0235), # progresses main story -> progression
    MMLItemData("Clozer Woods Sub-Gate Key 3",         ItemClassification.progression,                             0x0236), # progresses main story -> progression
    MMLItemData("Watcher' Key",                        ItemClassification.progression,                             0x0237), # progresses main story -> progression
    MMLItemData("Sleeper' Key",                        ItemClassification.progression,                             0x0238), # progresses main story -> progression
    MMLItemData("Dreamer' Key",                        ItemClassification.progression,                             0x0239), # progresses main story -> progression
    MMLItemData("Bag",                                 ItemClassification.filler,                                  0x0245),
    MMLItemData("Saw",                                 ItemClassification.filler,                                  0x0248),
    MMLItemData("Music Box",                           ItemClassification.progression,                             0x024A), # give to roll -> progression
    MMLItemData("Old Bone",                            ItemClassification.progression,                             0x024B), # progresses museum -> progression
  # MMLItemData("Old Heater",                          ItemClassification.progression,                             0x024C), # progresses museum -> progression
    MMLItemData("Old Doll",                            ItemClassification.progression,                             0x024D), # progresses museum -> progression
    MMLItemData("Antique Bell",                        ItemClassification.progression,                             0x024E), # progresses museum -> progression
    MMLItemData("Giant Horn",                          ItemClassification.progression,                             0x024F), # progresses museum -> progression
    MMLItemData("Shiny Object",                        ItemClassification.progression,                             0x0250), # progresses museum -> progression
    MMLItemData("Old Shield",                          ItemClassification.progression,                             0x0251), # progresses museum -> progression
    MMLItemData("Shiny Red Stone",                     ItemClassification.progression,                             0x0252), # progresses museum -> progression
    MMLItemData("Ring",                                ItemClassification.progression,                             0x0256), # give to roll -> progression
    MMLItemData("Mine Parts Kit",                      ItemClassification.filler,                                  0x0258),
    MMLItemData("Cannon Kit",                          ItemClassification.filler,                                  0x0259),
    MMLItemData("Grenade Kit",                         ItemClassification.filler,                                  0x025A),
    MMLItemData("Blumebear Parts",                     ItemClassification.useful,                                  0x025B), # strong special weapon -> useful
    MMLItemData("Mystic Orb",                          ItemClassification.filler,                                  0x025C),
    MMLItemData("Broken Motor",                        ItemClassification.filler,                                  0x025E),
    MMLItemData("Broken Propeller",                    ItemClassification.filler,                                  0x025F),
    MMLItemData("Broken Cleaner",                      ItemClassification.filler,                                  0x0260),
    MMLItemData("Bomb Schematic",                      ItemClassification.progression,                             0x0261), # breaks walls -> progression
    MMLItemData("Blunted Drill",                       ItemClassification.progression,                             0x0262), # breaks walls -> progression
    MMLItemData("Guidance Unit",                       ItemClassification.useful,                                  0x0263), # strong special weapon -> useful
    MMLItemData("Zetsabre",                            ItemClassification.filler,                                  0x0264),
    MMLItemData("Pen Light",                           ItemClassification.filler,                                  0x0265),
    MMLItemData("Old Launcher",                        ItemClassification.filler,                                  0x0266),
    MMLItemData("Ancient Book",                        ItemClassification.filler,                                  0x0267),
    MMLItemData("Weapon Plans",                        ItemClassification.useful,                                  0x026A),
    MMLItemData("Prism Crystal",                       ItemClassification.useful,                                  0x026B),
    MMLItemData("Spring Set",                          ItemClassification.progression | ItemClassification.useful, 0x026C), # powerup / convenience special items -> useful
    MMLItemData("Safety Helmet",                       ItemClassification.useful,                                  0x026D), # powerup / convenience special items -> useful
    MMLItemData("Rollerboard",                         ItemClassification.progression | ItemClassification.useful, 0x026E), # powerup / convenience special items -> useful
    MMLItemData("Old Hoverjets",                       ItemClassification.progression | ItemClassification.useful, 0x026F), # powerup / convenience special items -> useful
    MMLItemData("Joint Plug",                          ItemClassification.useful,                                  0x0270), # powerup / convenience special items -> useful
    MMLItemData("Main Core Shard",                     ItemClassification.filler,                                  0x0272),
    MMLItemData("Sun-light",                           ItemClassification.filler,                                  0x0273),
    MMLItemData("Rapidfire Barrel",                    ItemClassification.filler,                                  0x0274),
    MMLItemData("Gatling Part",                        ItemClassification.filler,                                  0x0277),
    MMLItemData("Flower Pearl",                        ItemClassification.filler,                                  0x0278),
    MMLItemData("Autofire Barrel",                     ItemClassification.filler,                                  0x0279),
    MMLItemData("Generator Part",                      ItemClassification.filler,                                  0x027A),
    MMLItemData("Target Sensor",                       ItemClassification.filler,                                  0x027B),
    MMLItemData("Tele-lens",                           ItemClassification.filler,                                  0x027C),
    MMLItemData("10 Zenny",                            ItemClassification.filler,                                  0x8001),
    MMLItemData("20 Zenny",                            ItemClassification.filler,                                  0x8002),
    MMLItemData("30 Zenny",                            ItemClassification.filler,                                  0x8003),
    MMLItemData("50 Zenny",                            ItemClassification.filler,                                  0x8005),
    MMLItemData("100 Zenny",                           ItemClassification.filler,                                  0x800A),
    MMLItemData("200 Zenny",                           ItemClassification.filler,                                  0x8014),
    MMLItemData("220 Zenny",                           ItemClassification.filler,                                  0x8016),
    MMLItemData("300 Zenny",                           ItemClassification.filler,                                  0x801E),
    MMLItemData("450 Zenny",                           ItemClassification.filler,                                  0x802D),
    MMLItemData("560 Zenny",                           ItemClassification.filler,                                  0x8038),
    MMLItemData("660 Zenny",                           ItemClassification.filler,                                  0x8042),
    MMLItemData("780 Zenny",                           ItemClassification.filler,                                  0x804E),
    MMLItemData("820 Zenny",                           ItemClassification.filler,                                  0x8052),
    MMLItemData("920 Zenny",                           ItemClassification.filler,                                  0x805C),
    MMLItemData("1180 Zenny",                          ItemClassification.filler,                                  0x8076),
    MMLItemData("1200 Zenny",                          ItemClassification.filler,                                  0x8078),
    MMLItemData("1240 Zenny",                          ItemClassification.filler,                                  0x807C),
    MMLItemData("1510 Zenny",                          ItemClassification.filler,                                  0x8097),
    MMLItemData("1620 Zenny",                          ItemClassification.filler,                                  0x80A2),
    MMLItemData("1780 Zenny",                          ItemClassification.filler,                                  0x80B2),
    MMLItemData("1840 Zenny",                          ItemClassification.filler,                                  0x80B8),
    MMLItemData("2170 Zenny",                          ItemClassification.filler,                                  0x80D9),
    MMLItemData("2280 Zenny",                          ItemClassification.filler,                                  0x80E4),
    MMLItemData("2300 Zenny",                          ItemClassification.filler,                                  0x80E6),
    MMLItemData("2600 Zenny",                          ItemClassification.filler,                                  0x8104),
    MMLItemData("2840 Zenny",                          ItemClassification.filler,                                  0x811C),
    MMLItemData("4520 Zenny",                          ItemClassification.filler,                                  0x81C4),
    MMLItemData("5130 Zenny",                          ItemClassification.filler,                                  0x8201),
    MMLItemData("5600 Zenny",                          ItemClassification.filler,                                  0x8230),
    MMLItemData("9240 Zenny",                          ItemClassification.useful,                                  0x839C), # Large amount of zenny -> useful
    MMLItemData("10000 Zenny",                         ItemClassification.useful,                                  0x83E8)  # Large amount of zenny -> useful
]

ITEM_NAME_TO_ID = {itemData.name: itemData.id for itemData in _all_itemDatas}
DEFAULT_ITEM_CLASSIFICATIONS = {itemData.name: itemData.itemClassification for itemData in _all_itemDatas}

def get_random_filler_item_name(world: MMLWorld) -> str:
    return "100 Zenny"

def create_item_with_correct_classification(world: MMLWorld, name: str) -> MMLItem:
    classification = DEFAULT_ITEM_CLASSIFICATIONS[name]
    return MMLItem(name, classification, ITEM_NAME_TO_ID[name], world.player)

def create_all_items(world: MMLWorld) -> None:
    itemPool: list[MMLItem] = []
    for mmlItemData in _all_itemDatas:
        match mmlItemData.name:
            case "Nothing":
                for _ in range(5):
                    itemPool.append(world.create_item(mmlItemData.name))
            case "10 Zenny":
                for _ in range(2):
                    itemPool.append(world.create_item(mmlItemData.name))
            case "20 Zenny":
                for _ in range(2):
                    itemPool.append(world.create_item(mmlItemData.name))
            case "920 Zenny":
                for _ in range(2):
                    itemPool.append(world.create_item(mmlItemData.name))
            case "Buster Max":
                pass
            case _:
                itemPool.append(world.create_item(mmlItemData.name))

    number_of_items = len(itemPool)
    number_of_unfilled_locations = len(world.multiworld.get_unfilled_locations(world.player))
    needed_number_of_filler_items = number_of_unfilled_locations - number_of_items
    itemPool += [world.create_filler() for _ in range(needed_number_of_filler_items)]
    world.multiworld.itempool += itemPool
    return None
