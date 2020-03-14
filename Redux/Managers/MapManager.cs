using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using Redux.Space;
using Redux.Game_Server;

namespace Redux.Managers
{
    public static class MapManager
    {
        public static ConcurrentDictionary<uint, Map> ActiveMaps = new ConcurrentDictionary<uint, Map>();

        /// <summary>
        /// Recovers map instance by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Map PullMapByID(uint id)
        {
            Map toRet;
            ActiveMaps.TryGetValue(id, out toRet);
            return toRet;
        }

        /// <summary>
        /// Insert player into map and get their surroundings
        /// </summary>
        /// <param name="p">player to insert</param>
        /// <param name="mapID">map id to insert into</param>
        public static void AddPlayer(Player p, uint mapID)
        {
            var map = PullMapByID(mapID);
            if (map != null)
                map.Insert(p);
            else
            {
                map = new Map(mapID, mapID);
                map.Insert(p);
                ActiveMaps.TryAdd(map.DynamicID, map);
            }
            p.UpdateSurroundings(true);
        }
        public static bool MapExist(uint mapid)
        {
            return ActiveMaps.ContainsKey(mapid);
        }

        public static bool AddMap(uint mapID)
        {
            var map = PullMapByID(mapID);
            if (map == null)
            {
                map = new Map(mapID, mapID);
                ActiveMaps.TryAdd(map.DynamicID, map);
            }
            return MapExist(mapID);
        }

        /// <summary>
        /// Removes player from all possible maps and removes them from screen of all entities
        /// </summary>
        /// <param name="p"></param>
        public static void RemovePlayer(Player p)
        {
            foreach (Map m in ActiveMaps.Values)
                if (m.Objects.ContainsKey(p.UID))
                {
                    m.Remove(p);
                    if (m.Objects.Count == 0)
                    {
                        Map x;
                        ActiveMaps.TryRemove(m.DynamicID, out x);
                    }
                }
        }   

        /// <summary>
        /// Remove entities from eachother's visible object list.
        /// </summary>
        /// <param name="p">player to no longer see object</param>
        /// <param name="id">uid of object to despawn</param>
        public static void DespawnByUID(Entity p, uint id)
        {
            var t = p.Map.Search(id);
            if (t == null || t == p)
                return;
            if (t is Entity)
            {
                var target = t as Entity;
                if (target.VisibleObjects != null && target.VisibleObjects.ContainsKey(p.UID))
                {
                    uint x;
                    target.VisibleObjects.TryRemove(p.UID, out x);
                }
            }

            if (p.VisibleObjects != null && p.VisibleObjects.ContainsKey(t.UID))
            {
                uint x;
                p.VisibleObjects.TryRemove(t.UID, out x);
            }
        }

        /// <summary>
        /// Spawn entities to eachother as well as spawning basic objects (items, npcs, sobs, traps) to players
        /// </summary>
        /// <param name="p">player to see spawned objects</param>
        /// <param name="id">uid of object to spawn</param>
        public static void SpawnByUID(Entity p, uint id)
        {
            
            var sob = p.Map.Search<SOB>(id);
            if (sob != null)
            {
                if (p is Player && !p.VisibleObjects.ContainsKey(sob.UID))
                {
                    ((Player)p).Send(Packets.Game.SpawnSob.Create(sob));
                    p.VisibleObjects.TryAdd(sob.UID, sob.UID);
                }
                return;
            }
            var target = p.Map.Search<Entity>(id);
            if (target != null && target != p)
            {
                if (!p.VisibleObjects.ContainsKey(target.UID))
                {
                    p.VisibleObjects.TryAdd(target.UID, target.UID);
                    p.Send(target.SpawnPacket);
                }
                if (!target.VisibleObjects.ContainsKey(p.UID))
                {
                    target.VisibleObjects.TryAdd(p.UID, p.UID);
                    target.Send(p.SpawnPacket);
                    if(target is Player && p is Player)
                        if ((target as Player).Shop != null && (target as Player).Shop.Vending && (target as Player).Shop.HawkMsg.Words.Length > 1)
                            p.Send((target as Player).Shop.HawkMsg);
                }
                return;
            }
            var npc = p.Map.Search<Npc>(id);
            if (npc != null)
            {
                if (p is Player && !p.VisibleObjects.ContainsKey(npc.UID))
                {
                    ((Player)p).Send(npc.SpawnPacket);
                    p.VisibleObjects.TryAdd(npc.UID, npc.UID);
                }
                return;
            }
            var item = p.Map.Search<GroundItem>(id);
            if (item != null)
            {
                if (p is Player && !p.VisibleObjects.ContainsKey(item.UID))
                {
                    ((Player)p).Send(item.SpawnPacket);
                    p.VisibleObjects.TryAdd(item.UID, item.UID);
                }
                return;
            }

            
        }

        public static void MapManager_Tick()
        {
            foreach (var map in ActiveMaps.Values)
            {
                foreach (var i in map.Objects.Values)
                    if (i is GroundItem)
                    {
                        var item = i as GroundItem;
                        if (Common.Clock - item.DroppedAt > Common.MS_PER_MINUTE)
                            item.RemoveFromMap();
                    }
                
            }



        }
    }
}
