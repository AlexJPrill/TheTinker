using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Abstracts;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Commands.Builders;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using TheTinker.TheTinkerCode.Character;

namespace TheTinker.TheTinkerCode.Cards;

[Pool(typeof(TheTinkerCardPool))]
public class CombatRig() : CustomCardModel(0, CardType.Attack, CardRarity.Basic, TargetType.AnyEnemy)
{

   protected override IEnumerable<IHoverTip> ExtraHoverTips =>
   [
      HoverTipFactory.FromKeyword(TheTinkerCode.Keywords.Worn)
   ];

   protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(7M, ValueProp.Move), new BlockVar(5M, ValueProp.Move)];


   protected override async Task OnPlay(
      PlayerChoiceContext choiceContext,
      CardPlay play)
   {
      CombatRig combatRig = this;
      AttackCommand attackCommand = await DamageCmd.Attack(combatRig.DynamicVars.Damage.BaseValue)
         .FromCard((CardModel)combatRig).Targeting(play.Target).Execute(choiceContext);
      Decimal num = await CreatureCmd.GainBlock(combatRig.Owner.Creature, combatRig.DynamicVars.Block, play);
      combatRig.EnergyCost.AddThisCombat(1);

   }
   
   protected override void  OnUpgrade() {
      this.DynamicVars.Damage.UpgradeValueBy(2M);
      this.DynamicVars.Block.UpgradeValueBy(3M);
      
   }
}