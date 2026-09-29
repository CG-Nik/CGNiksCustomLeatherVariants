using MateriaLib;
using MelonLoader;
using UnityEngine;
using Alta;
using System.Reflection;

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

        private static void AddLeather(string name, int hash, MaterialConfig materialConfig, Vector4 color0, Vector4 color1, Vector4 color2)
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
        }

        public static void SetupMaterial()
        {
            AddLeather(
                "Natural Leather",
                37301,
                new MaterialConfig() { NailHealthMultiplier = 0.6f, MaxCraftingDamageMultiplier = 1f },
                new Vector4(0.35f * 1.5f, 0.14f * 1.5f, 0.06f * 1.5f, 1f),
                new Vector4(0.7f * 1.3f, 0.45f * 1.3f, 0.2f * 1.3f, 1f),
                new Vector4(0.91f * 1.1f, 0.59f * 1.1f, 0.35f * 1.1f, 1f)
            );

            AddLeather(
                "Charcoal Leather",
                37302,
                new MaterialConfig() { WeightMultiplier = 0.9f, NailHealthMultiplier = 1.1f, MaxCraftingDamageMultiplier = 0.9f },
                new Vector4(0.1f, 0.1f, 0.1f, 1f),
                new Vector4(0.2f, 0.2f, 0.2f, 1f),
                new Vector4(0.3f, 0.3f, 0.3f, 1f)
            );

            AddLeather(
                "Hazelnut Leather",
                37303,
                new MaterialConfig() { WeightMultiplier = 0.95f },
                new Vector4(0.3f, 0.2f, 0.1f, 1f),
                new Vector4(0.6f, 0.4f, 0.2f, 1f),
                new Vector4(0.9f, 0.6f, 0.3f, 1f)
            );

            AddLeather(
                "Walnut Leather",
                37304,
                new MaterialConfig() { WeightMultiplier = 0.8f, NailHealthMultiplier = 1.5f, MaxCraftingDamageMultiplier = 0.7f },
                new Vector4(0.1f, 0.05f, 0.025f, 1f),
                new Vector4(0.2f, 0.1f, 0.05f, 1f),
                new Vector4(0.4f, 0.2f, 0.1f, 1f)
            );

            /* this is an example for how you would do the material setting for a material that uses a different Non Forging Material, just because I already made it and don't want to make it again when I end up using it
            Material mainMat2 = UnityEngine.Object.Instantiate(charcoalLeather.physicalMaterial.GetMaterial(PhysicalMaterialChannel.A));
            object materialChannel2 = ((Array)typeof(PhysicalMaterial).GetField("materialChannels", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(charcoalLeather.physicalMaterial)).GetValue(0);
            Material nonForgeMat2 = UnityEngine.Object.Instantiate((Material)materialChannel1.GetType().GetField("atlasedMaterial", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(materialChannel1));
            */
        }
    }
}