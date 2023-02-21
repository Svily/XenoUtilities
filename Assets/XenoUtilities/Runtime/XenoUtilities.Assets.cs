﻿using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Xeno.Utilities
{
    /**
     * 资源相关
     */
    public static partial class XenoUtilities
    {
        public static string GetFileName(string assetPath)
        {
            if (assetPath.StartsWith("Assets"))
            {
                assetPath = $"{Application.dataPath}/{assetPath}";
            }
            return Path.GetFileName(assetPath);
        }
        
        public static string GetFileNameWithoutExtension(string assetPath) 
        {
            if (assetPath.StartsWith("Assets"))
            {
                assetPath = $"{Application.dataPath}/{assetPath}";
            }
            return Path.GetFileNameWithoutExtension(assetPath);
        }

        public static string GetDirectoryName(string assetPath)
        {
            if (assetPath.StartsWith("Assets"))
            {
                assetPath = $"{Application.dataPath}/{assetPath}";
            }
            return Path.GetDirectoryName(assetPath);
        }
        
        /// <summary>
        /// 加载指定资源
        /// </summary>
        /// <param name="path"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T LoadAsset<T>(string path) where T : UnityEngine.Object
        {
            if (File.Exists(path))
            {
                string assetPath = path.Substring(path.IndexOf("Assets", StringComparison.Ordinal));
                T asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);
                if (asset)
                {
                    return asset;
                }
            }

            return null;
        }
        
        /// <summary>
        /// 获取指定文件夹下所有指定类型的资源
        /// </summary>
        /// <param name="path"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> LoadAllAssets<T>(string path) where T : UnityEngine.Object
        {
            List<T> list = new List<T>();
            if (Directory.Exists(path))
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                FileInfo[] files = dir.GetFiles("*", SearchOption.AllDirectories);
                
                foreach (var file in files)
                {
                    if (file.Name.EndsWith(".meta")) continue;

                    string assetName = file.FullName;
                    string assetPath = assetName.Substring(assetName.IndexOf("Assets", StringComparison.Ordinal));
                    T asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);
                    if (asset)
                    {
                        list.Add(asset);
                    }
                }
            }
            
            return list;
        } 
        
        
       
    }
}