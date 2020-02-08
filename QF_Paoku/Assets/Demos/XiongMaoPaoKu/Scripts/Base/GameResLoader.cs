using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.PaokuDemo
{
    public class GameResLoader : ResLoader
    {
        // private Dictionary<string, Object[]> mAtlasDic = new Dictionary<string, Object[]>();



        // public static new GameResLoader Allocate(IResLoaderStrategy strategy = null)
        // {
        //     var loader = SafeObjectPool<GameResLoader>.Instance.Allocate();
        //     return loader;
        // }


        // public Sprite LoadAtlasSprite(string atlasPath, string spriteName)
        // {
        //     Sprite sprite = FindSpriteFormBuffer(atlasPath, spriteName);
        //     if (sprite == null)
        //     {
        //         Object[] atlas = Resources.LoadAll(atlasPath);
        //         mAtlasDic.Add(atlasPath, atlas);
        //         sprite = SpriteFormAtlas(atlas, spriteName);
        //     }
        //     return sprite;
        // }

        // private Sprite FindSpriteFormBuffer(string atlasPath, string spriteName)
        // {
        //     if (mAtlasDic.ContainsKey(atlasPath))
        //     {
        //         Object[] atlas = mAtlasDic[atlasPath];
        //         Sprite sprite = SpriteFormAtlas(atlas, spriteName);
        //         return sprite;
        //     }
        //     return null;
        // }

        // private Sprite SpriteFormAtlas(Object[] atlas, string spriteName)
        // {
        //     for (int i = 0; i < atlas.Length; i++)
        //     {
        //         if (atlas[i].GetType() == typeof(UnityEngine.Sprite))
        //         {
        //             if (atlas[i].name == spriteName)
        //             {
        //                 return (Sprite)atlas[i];
        //             }
        //         }
        //     }
        //     return null;
        // }
    }
}
