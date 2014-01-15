using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    class ExtendedInteractionManager : InteractionManager
    {
        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;

            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    location = base.CreateLocation(locationTypeString, locationName);
                    break;
            }

            return location;
        }

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }

            return item;
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;

            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    person = base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
            }

            return person;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherCommand(commandWords[2], actor);
                    break;
                case "craft":
                    HandleCraftCommand(commandWords[2], commandWords[3], actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }

        }

        private void HandleCraftCommand(string itemToCraft, string itemNameString, Person actor)
        {
            switch (itemToCraft)
            {
                case "weapon":
                    if (actor.ListInventory().Exists(x => x.ItemType == ItemType.Iron) &&
                        actor.ListInventory().Exists(x => x.ItemType == ItemType.Wood))
                    {
                        this.AddToPerson(actor, new Weapon(itemNameString, actor.Location));
                    }
                    break;
                case "armor":
                    if (actor.ListInventory().Exists(x => x.ItemType == ItemType.Iron))
                        this.AddToPerson(actor, new Armor(itemNameString, actor.Location));
                    break;
                default:
                    break;
            };
        }

        private void HandleGatherCommand(string itemNameString, Person actor)
        {
            if (actor.Location.LocationType == LocationType.Forest && 
                actor.ListInventory().Exists(x => x.ItemType == ItemType.Weapon))
            {
                this.AddToPerson(actor, new Wood(itemNameString, actor.Location));
            }
            else if (actor.Location.LocationType == LocationType.Mine && 
                actor.ListInventory().Exists(x => x.ItemType == ItemType.Armor))
            {
                this.AddToPerson(actor, new Iron(itemNameString, actor.Location));
            }
        }
    }
}
