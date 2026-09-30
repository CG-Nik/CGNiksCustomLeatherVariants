using Alta;
using Alta.Caves;
using Alta.Inventory;
using Alta.Networking;
using DifferentWyrmMaterials;
using MateriaLib;
using MelonLoader;
using System.Collections;
using System.Reflection;
using UnityEngine;
using static AltaMenuItemBase.Assets.Create.Township.Features;

[assembly: MelonInfo(typeof(CGNiksCustomLeatherVariants.Core), "CGNiksCustomLeatherVariants", "1.0.0", "CGNik", null)]
[assembly: MelonGame("Alta", "A Township Tale")]

namespace CGNiksCustomLeatherVariants
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
            MateriaLib.Main.SetupMaterial += SetupMaterial;
        }

        private static LibMaterial AddLeather(string name, int hash, MaterialConfig materialConfig, Vector4 color0, Vector4 color1, Vector4 color2, bool addToDistribution, float baseValue = 1f, float noAttributeValue = 1f, AttributeCurveRange[] multipliers = null)
        {
            LibMaterial libMaterial = new LibMaterial(name, hash, LibMaterial.MaterialType.leather);

            LibMaterial.NewMaterials.Add(libMaterial);

            libMaterial.Configure(materialConfig);

            Material material = UnityEngine.Object.Instantiate(libMaterial.physicalMaterial.GetMaterial(PhysicalMaterialChannel.A));

            material.name = name;

            material.SetVector("_Color", color0);
            material.SetVector("_Color1", color1);
            material.SetVector("_Color2", color2);

            libMaterial.ReplaceAllMaterials(material);

            if (addToDistribution)
            {
                Distribution leatherMaterialDistribution = Distribution.All.Where(dist => dist.Hash == 49220u).First();
                DifferentWyrmMaterials.Core.AddToDistribution(leatherMaterialDistribution, libMaterial.physicalMaterial, baseValue, noAttributeValue, multipliers);
            }

            return libMaterial;
        }

        public static void SetupMaterial()
        {
            AddLeather(
                "Natural Leather",
                37301,
                new MaterialConfig() { NailHealthMultiplier = 0.6f, MaxCraftingDamageMultiplier = 1f },
                new Vector4(0.35f * 1.5f, 0.14f * 1.5f, 0.06f * 1.5f, 1f),
                new Vector4(0.7f * 1.3f, 0.45f * 1.3f, 0.2f * 1.3f, 1f),
                new Vector4(0.91f * 1.1f, 0.59f * 1.1f, 0.35f * 1.1f, 1f),
                true,
                1f,
                1f,
                new AttributeCurveRange[]
                {
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "Wyrmness").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 0f),
                            new Keyframe(1f, 1f)
                        }),
                        1f,
                        0f
                    ),
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "_Depth").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 1f),
                            new Keyframe(1f, 0f)
                        }),
                        0f,
                        30f
                    )
                }
            );

            AddLeather(
                "Charcoal Leather",
                37302,
                new MaterialConfig() { WeightMultiplier = 0.9f, NailHealthMultiplier = 1.1f, MaxCraftingDamageMultiplier = 0.9f },
                new Vector4(0.1f, 0.1f, 0.1f, 1f),
                new Vector4(0.2f, 0.2f, 0.2f, 1f),
                new Vector4(0.3f, 0.3f, 0.3f, 1f),
                true,
                0.35f,
                0.35f,
                new AttributeCurveRange[]
                {
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "Wyrmness").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 0f),
                            new Keyframe(1f, 1f)
                        }),
                        1f,
                        0f
                    ),
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "_Depth").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 0.25f),
                            new Keyframe(1f, 1f)
                        }),
                        0f,
                        100f
                    )
                }
            );

            AddLeather(
                "Mahogany Leather",
                37303,
                new MaterialConfig() { WeightMultiplier = 0.95f },
                new Vector4(0.15f, 0.05f, 0f, 1f),
                new Vector4(0.3f, 0.1f, 0f, 1f),
                new Vector4(0.45f, 0.15f, 0f, 1f),
                true,
                0.35f,
                0.35f,
                new AttributeCurveRange[]
                {
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "Wyrmness").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 0f),
                            new Keyframe(1f, 1f)
                        }),
                        1f,
                        0f
                    ),
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "_Depth").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 0.25f),
                            new Keyframe(0.5f, 1f),
                            new Keyframe(1f, 0.25f)
                        }),
                        10f,
                        40f
                    )
                }
            );

            AddLeather(
                "Walnut Leather",
                37304,
                new MaterialConfig() { WeightMultiplier = 0.8f, NailHealthMultiplier = 1.5f, MaxCraftingDamageMultiplier = 0.7f },
                new Vector4(0.1f, 0.05f, 0.025f, 1f),
                new Vector4(0.2f, 0.1f, 0.05f, 1f),
                new Vector4(0.4f, 0.2f, 0.1f, 1f),
                true,
                0.35f,
                0.35f,
                new AttributeCurveRange[]
                {
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "Wyrmness").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 0f),
                            new Keyframe(1f, 1f)
                        }),
                        1f,
                        0f
                    ),
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "_Depth").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 0f),
                            new Keyframe(0.5f, 1f),
                            new Keyframe(1f, 0.25f)
                        }),
                        40f,
                        60f
                    )
                }
            );

            LibMaterial wyrmStomachLeather = AddLeather(
                "Wyrm Stomach Leather",
                37305,
                new MaterialConfig() { WeightMultiplier = 1.2f, NailHealthMultiplier = 1.4f, MaxCraftingDamageMultiplier = 0.8f },
                new Vector4(0.85f * 0.7f * 0.85f, 0.65f * 0.7f * 0.85f, 0.5f * 0.7f * 0.85f, 1f),
                new Vector4(0.85f * 0.7f, 0.65f * 0.7f, 0.5f * 0.7f, 1f),
                new Vector4(0.85f * 0.7f * 1.15f, 0.65f * 0.7f * 1.15f, 0.5f * 0.7f * 1.15f, 1f),
                true,
                0.5f,
                0f,
                new AttributeCurveRange[]
                {
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "Wyrmness").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 0f),
                            new Keyframe(1f, 1f)
                        }),
                        0f,
                        1f
                    )
                }
            );

            DifferentWyrmMaterials.Core.AddToDistribution(
                DifferentWyrmMaterials.Core.wyrmMaterialDistribution,
                wyrmStomachLeather.physicalMaterial,
                0.5f,
                0.5f,
                new AttributeCurveRange[] { }
            );

            LibMaterial wyrmBackLeather = AddLeather(
                "Wyrm Back Leather",
                37306,
                new MaterialConfig() { WeightMultiplier = 0.8f, NailHealthMultiplier = 1.6f, MaxCraftingDamageMultiplier = 0.6f },
                new Vector4(0.4f, 0.2f, 0.16f, 1f),
                new Vector4(0.5f, 0.25f, 0.2f, 1f),
                new Vector4(0.6f, 0.3f, 0.24f, 1f),
                true,
                0.5f,
                0f,
                new AttributeCurveRange[]
                {
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "Wyrmness").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 0f),
                            new Keyframe(1f, 1f)
                        }),
                        0f,
                        1f
                    )
                }
            );

            DifferentWyrmMaterials.Core.AddToDistribution(
                DifferentWyrmMaterials.Core.wyrmMaterialDistribution,
                wyrmBackLeather.physicalMaterial,
                0.5f,
                0.5f,
                new AttributeCurveRange[] { }
            );

            LibMaterial crystalWyrmFaceLeather = AddLeather(
                "Crystal Wyrm Face Leather",
                37307,
                new MaterialConfig() { WeightMultiplier = 0.6f, NailHealthMultiplier = 2f, MaxCraftingDamageMultiplier = 0.5f },
                new Vector4(0.27f, 0.29f, 0.25f, 1f),
                new Vector4(0.325f, 0.35f, 0.3f, 1f),
                new Vector4(0.38f, 0.41f, 0.35f, 1f),
                true,
                1f,
                0f,
                new AttributeCurveRange[]
                {
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "Wyrmness").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 0f),
                            new Keyframe(1f, 1f)
                        }),
                        0f,
                        1f
                    )
                }
            );

            DifferentWyrmMaterials.Core.AddToDistribution(
                DifferentWyrmMaterials.Core.crystalWyrmMaterialDistribution,
                crystalWyrmFaceLeather.physicalMaterial,
                1f,
                1f,
                new AttributeCurveRange[] { }
            );

            LibMaterial crystalWyrmStomachLeather = AddLeather(
                "Crystal Wyrm Stomach Leather",
                37308,
                new MaterialConfig() { WeightMultiplier = 1.3f, NailHealthMultiplier = 0.8f, MaxCraftingDamageMultiplier = 0.5f },
                new Vector4(0.6f * 0.7f, 0.625f * 0.7f, 0.525f * 0.7f, 1f),
                new Vector4(0.7f * 0.7f, 0.75f * 0.7f, 0.6f * 0.7f, 1f),
                new Vector4(0.8f * 0.7f, 0.875f * 0.7f, 0.675f * 0.7f, 1f),
                true,
                0.5f,
                0f,
                new AttributeCurveRange[]
                {
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "Wyrmness").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 0f),
                            new Keyframe(1f, 1f)
                        }),
                        0f,
                        1f
                    )
                }
            );

            DifferentWyrmMaterials.Core.AddToDistribution(
                DifferentWyrmMaterials.Core.crystalWyrmMaterialDistribution,
                crystalWyrmStomachLeather.physicalMaterial,
                0.5f,
                0.5f,
                new AttributeCurveRange[] { }
            );

            LibMaterial crystalWyrmBackLeather = AddLeather(
                "Crystal Wyrm Back Leather",
                37309,
                new MaterialConfig() { WeightMultiplier = 1.1f, NailHealthMultiplier = 1.3f, MaxCraftingDamageMultiplier = 0.9f },
                new Vector4(0.14f, 0.165f, 0.12f, 1f),
                new Vector4(0.19f, 0.22f, 0.16f, 1f),
                new Vector4(0.24f, 0.275f, 0.2f, 1f),
                true,
                0.5f,
                0f,
                new AttributeCurveRange[]
                {
                    new AttributeCurveRange(
                        (BiomeAttribute)Resources.FindObjectsOfTypeAll(typeof(BiomeAttribute)).Where(attribute => attribute.name == "Wyrmness").First(),
                        new AnimationCurve(new Keyframe[]
                        {
                            new Keyframe(0f, 0f),
                            new Keyframe(1f, 1f)
                        }),
                        0f,
                        1f
                    )
                }
            );

            DifferentWyrmMaterials.Core.AddToDistribution(
                DifferentWyrmMaterials.Core.crystalWyrmMaterialDistribution,
                crystalWyrmBackLeather.physicalMaterial,
                0.5f,
                0.5f,
                new AttributeCurveRange[] { }
            );

            List<Distribution.Item> items = (List<Distribution.Item>)DifferentWyrmMaterials.Core.crystalWyrmMaterialDistribution.GetType().GetField("items", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(DifferentWyrmMaterials.Core.crystalWyrmMaterialDistribution);
            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (items[i].Topic == PhysicalMaterial.All.Where(mat => mat.Hash == 63538u).First())
                {
                    items.RemoveAt(i);
                }
            }

            /* this is an example for how you would do the material setting for a material that uses a different Non Forging Material, just because I already made it and don't want to make it again when I end up using it
            Material mainMat2 = UnityEngine.Object.Instantiate(charcoalLeather.physicalMaterial.GetMaterial(PhysicalMaterialChannel.A));
            object materialChannel2 = ((Array)typeof(PhysicalMaterial).GetField("materialChannels", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(charcoalLeather.physicalMaterial)).GetValue(0);
            Material nonForgeMat2 = UnityEngine.Object.Instantiate((Material)materialChannel1.GetType().GetField("atlasedMaterial", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(materialChannel1));
            */
        }
    }
}