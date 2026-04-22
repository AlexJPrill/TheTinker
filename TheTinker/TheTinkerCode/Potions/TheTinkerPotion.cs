using BaseLib.Abstracts;
using BaseLib.Utils;
using TheTinker.TheTinkerCode.Character;

namespace TheTinker.TheTinkerCode.Potions;

[Pool(typeof(TheTinkerPotionPool))]
public abstract class TheTinkerPotion : CustomPotionModel;