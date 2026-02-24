from collections.abc import Mapping
from typing import Any

# Imports of base Archipelago modules must be absolute.
from worlds.AutoWorld import World

# Imports of your world's files must be relative.
from . import items, locations, regions, rules, web_world
from . import options as apquest_options  # rename due to a name conflict with World.options
from collections.abc import Mapping
from typing import Any

# Imports of base Archipelago modules must be absolute.
from worlds.AutoWorld import World

# Imports of your world's files must be relative.
#from . import items, locations, regions, rules, web_world
#from . import options as apquest_options  # rename due to a name conflict with World.options


class MMLWorld(World):
    """
    Mega Man Legends is a 1997 action-adventure game released by Capcom. It is the first game in the Mega Man Legends
    sub-series of Mega Man games from Capcom. Explore dungeons, fight pirates and save kattlelox island from its
    imminent demise
    """

    game = "MegaMan Legends"

    #web = web_world.MMLWebWorld()