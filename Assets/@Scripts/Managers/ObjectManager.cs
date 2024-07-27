using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : ContentManager {

    public HashSet<Domino> Dominos { get; private set; } = new();

    #region Generals

    public void Clear() {
        Destroy(Dominos);
        Dominos.Clear();
    }

    private T Instantiate<T>(string prefabName = null, bool pooling = true) where T : Entity {
        if (string.IsNullOrEmpty(prefabName)) prefabName = typeof(T).Name;

        GameObject prefab = Main.Resource.Get<GameObject>(prefabName);
        if (prefab == null) {
            Debug.LogError($"[ObjectManager] Instantiate<{typeof(T).Name}>({prefabName}, {pooling}): Failed to load prefab.");
            return null;
        }

        T entity;
        if (pooling) entity = Main.Pool.Pop(prefab).GetOrAddComponent<T>();
        else {
            GameObject obj = GameObject.Instantiate(prefab);
            obj.name = prefab.name;
            entity = obj.GetOrAddComponent<T>();
        }

        return entity;
    }

    private void Destroy(Entity entity) {
        if (entity == null) return;
        if (Main.Pool.Push(entity.gameObject)) return;

        Object.Destroy(entity.gameObject);
    }

    private void Destroy(IEnumerable<Entity> entities) {
        foreach (Entity entity in entities) Destroy(entity);
    }

    #endregion

    #region Domino

    public Domino NewDomino() {
        Domino domino = Instantiate<Domino>();
        Dominos.Add(domino);
        domino.SetInfo();

        return domino;
    }

    public void RemoveDomino(Domino domino) {
        Dominos.Remove(domino);
        Destroy(domino);
    }

    #endregion

}