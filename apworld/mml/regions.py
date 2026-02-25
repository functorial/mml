from __future__ import annotations

from typing import TYPE_CHECKING

from BaseClasses import Entrance, Region

if TYPE_CHECKING:
    from .world import MMLWorld

# TODO: Current setup only has one big region. Create logical regions
# e.g. a region you can only get to with jump springs.
# It will make sense to eventually have regions be actual rooms in the game
# because it will make it possible to do entrance keys a la OoT.

def create_and_connect_regions(world: MMLWorld) -> None:
    create_all_regions(world)
    connect_regions(world)

def create_all_regions(world: MMLWorld) -> None:
    universe = Region("Universe", world.player, world.multiworld)
    regions = [universe]
    world.multiworld.regions += regions

def connect_regions(world: MMLWorld) -> None:
    universe = world.get_region("Universe")
    pass