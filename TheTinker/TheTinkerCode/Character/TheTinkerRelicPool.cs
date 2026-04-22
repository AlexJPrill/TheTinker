using BaseLib.Abstracts;
using TheTinker.TheTinkerCode.Extensions;
using Godot;

namespace TheTinker.TheTinkerCode.Character;

public class TheTinkerRelicPool : CustomRelicPoolModel
{
    public override Color LabOutlineColor => TheTinker.Color;

    public override string BigEnergyIconPath => "charui/big_energy.png".ImagePath();
    public override string TextEnergyIconPath => "charui/text_energy.png".ImagePath();
}