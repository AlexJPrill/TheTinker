using BaseLib.Abstracts;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using TheTinker.TheTinkerCode.Character;

namespace TheTinker.TheTinkerCode.Cards;

[Pool(typeof(TheTinkerCardPool))]
public class DefendTheTinker() : CustomCardModel(1, CardType.Skill, CardRarity.Basic, TargetType.None)
{
   public override bool GainsBlock => true;
   protected override HashSet<CardTag> CanonicalTags => [CardTag.Defend];
   protected override IEnumerable<DynamicVar> CanonicalVars => [new BlockVar(5, ValueProp.Move)];

   protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
   {
      await CommonActions.CardBlock(this, play);
   }


   protected override void OnUpgrade()
   {
      DynamicVars.Block.UpgradeValueBy(3m);
   }
}