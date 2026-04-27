using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Abstracts;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.CardSelection;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Factories;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.CardPools;
using MegaCrit.Sts2.Core.Models.Cards;
using TheTinker.TheTinkerCode.Character;

namespace TheTinker.TheTinkerCode.Cards;

 //This card could very well be a pain in the ass to build. 
[Pool(typeof(TheTinkerCardPool))]
public class BattleTools() : CustomCardModel(1, CardType.Skill, CardRarity.Common, TargetType.None)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [];
    

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        BattleTools source = this;
        CardModel card = (await CardSelectCmd.FromHand(
            choiceContext,
            source.Owner,
            new CardSelectorPrefs(CardSelectorPrefs.ExhaustSelectionPrompt, 1),
            c => c.Tags.Contains<CardTag>(TheTinkerEnums.Scrap),
            (AbstractModel)source)).FirstOrDefault();
        if (card != null)
            await CardCmd.Exhaust(choiceContext, card);
        CardPileAddResult combat =
            await CardPileCmd.AddGeneratedCardToCombat((CardModel) source.CombatState.CreateCard<CombatRig>(source.Owner), PileType.Hand, true);
        CardCmd.Upgrade(combat.cardAdded);
    }
    
}